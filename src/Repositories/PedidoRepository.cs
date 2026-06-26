using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Mappers;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AplMovilBexsolucionesApi.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly DapperContext _context;
    private readonly IConfiguration _config;
    private readonly ILogger<PedidoRepository> _logger;

    public PedidoRepository(DapperContext context, IConfiguration config, ILogger<PedidoRepository> logger)
    {
        _context = context;
        _config = config;
        _logger = logger;
    }

    public async Task<RespuestaPedidoDto> GuardarPedido(RecPedidoDto pedido)
    {
        if (pedido is null)
            throw new ArgumentException("El pedido es nulo.");
        if (string.IsNullOrWhiteSpace(pedido.Cliente))
            throw new ArgumentException("El pedido no incluye el cliente (CC).");
        if (pedido.Lineas is null || pedido.Lineas.Count == 0)
            throw new ArgumentException("El pedido no incluye líneas de producto.");

        var sucursalErp = pedido.SucursalErp is > 0
            ? pedido.SucursalErp.Value
            : _config.GetValue<int?>("Pedidos:SucursalErp")
                ?? throw new InvalidOperationException("No se ha definido la sucursal del ERP (Pedidos:SucursalErp).");
        var usuarioId = _config.GetValue<int?>("Pedidos:UsuarioId") ?? 1;
        var clienteId = _config.GetValue<int?>("Pedidos:ClienteId") ?? 1;
        var fecha = NormalizarFecha(pedido.FechaMov) ?? DateTime.Now;

        _logger.LogInformation("Pedido recibido. sucursalErp(request)={Request}, sucursalErp(usada)={Usada}",
            pedido.SucursalErp, sucursalErp);

        await using var connection = (SqlConnection)_context.CreateConnection();
        await connection.OpenAsync();
        await using var tx = (SqlTransaction)await connection.BeginTransactionAsync();

        try
        {
            await connection.ExecuteAsync(
                "EXEC sp_getapplock @Resource = @Resource, @LockMode = 'Exclusive', @LockOwner = 'Transaction';",
                new { Resource = $"wc_salida_{sucursalErp}" }, tx);

           
            var caja = await connection.QuerySingleOrDefaultAsync<CajaConfig>(QueryA, new { sucursalErp }, tx)
                ?? throw new InvalidOperationException($"No hay caja web configurada para la sucursal {sucursalErp}.");

            var persona = await connection.QueryFirstOrDefaultAsync<PersonaErp>(QueryB, new { cc = pedido.Cliente }, tx)
                ?? throw new InvalidOperationException($"El cliente con identificación {pedido.Cliente} no existe en Personas.");

            var detalle = new List<SalidaMercanciaDetalle>(pedido.Lineas.Count);
            foreach (var linea in pedido.Lineas)
            {
                var d = await connection.QuerySingleOrDefaultAsync<SalidaMercanciaDetalle>(QueryC, new
                {
                    idproducto = linea.CodProduct,
                    Cantidad = linea.CantMov,
                    PrecioVenta = linea.PrecioMov,
                    Observacion = pedido.Observacion,
                    FechaPedido = fecha,
                    sucursalErp
                }, tx) ?? throw new InvalidOperationException(
                    $"El producto {linea.CodProduct} no está disponible (Productos/ProductosPrecios/ProductosPuntos) para la sucursal {sucursalErp}.");

                detalle.Add(d);
            }

   
            var consecutivo = await connection.ExecuteScalarAsync<int>(QueryD, new { sucursalErp }, tx);
            var noDoc = PedidoMapper.NoDocumento(caja.EquipoId, consecutivo);

            var salida = PedidoMapper.CrearSalida(pedido, caja, consecutivo, noDoc, usuarioId, clienteId, fecha, detalle);
            var salidaId = await connection.QuerySingleAsync<int>(InsertSalida, salida, tx);

       
            PedidoMapper.CompletarDetalle(detalle, noDoc, salidaId);
            foreach (var renglon in detalle)
            {
                await connection.ExecuteAsync(InsertDetalle, renglon, tx);
            }

  
            var tercero = PedidoMapper.CrearTercero(persona, noDoc, salidaId, usuarioId);
            await connection.ExecuteAsync(InsertTercero, tercero, tx);

            var movimiento = PedidoMapper.CrearMovimiento(caja, noDoc, fecha, usuarioId);
            await connection.ExecuteAsync(InsertMovimiento, movimiento, tx);

            await tx.CommitAsync();

            _logger.LogInformation("Pedido insertado. SalidaId={SalidaId}, NoDocumento={NoDocumento}", salidaId, noDoc);
            return new RespuestaPedidoDto { SalidaId = salidaId, NoDocumento = noDoc, Total = salida.TotalSalida };
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            _logger.LogError(ex, "Error insertando el pedido del cliente {Cliente}. Se hizo rollback.", pedido.Cliente);
            throw;
        }
    }

   
    private static DateTime? NormalizarFecha(DateTime? fecha)
    {
        if (fecha is null)
            return null;

        return fecha.Value.Kind == DateTimeKind.Utc
            ? fecha.Value.ToLocalTime()
            : DateTime.SpecifyKind(fecha.Value, DateTimeKind.Unspecified);
    }

    #region SQL

    private const string QueryA = @"
        SELECT TOP 1 pc.EquipoId, pc.BodegaId, pc.SucursalId, s.EmpresaId
        FROM ParametrizarCajas pc
            JOIN Sucursal s ON s.SucursalId = pc.SucursalId
        WHERE pc.CajaWeb = 1 AND pc.SucursalId = @sucursalErp;";

    private const string QueryB = @"
        SELECT TOP 1 PersonaId, TipoDeDocumentoId, NoIdentificacion, RazonSocial, NombreCompleto,
            PrimerNombre, PrimerApellido, SegundoNombre, SegundoApellido, Direccion, Telefono1, Email,
            PaisId, CiudadId, DepartamentoId, RegimenId, EquipoId
        FROM Personas
        WHERE NoIdentificacion = @cc;";

    private const string QueryC = @"
        SELECT
            '' AS NoDocumento,
            0  AS Id,
            p.ProductoId,
            CAST(p.ProductoId AS NVARCHAR(50)) AS CodigoAlterno,
            p.DescripcionLarga, p.DescripcionCorta, p.Embalaje,
            p.IvaVentaId, p.IvaCompraId, p.ImpoConsumo,
            pp.PrecioCosto,
            @PrecioVenta             AS PrecioPublico,
            @PrecioVenta             AS PrecioPublicoReal,
            0                        AS CantidadEntrada,
            @Cantidad                AS CantidadSalida,
            pu.Valor                 AS BasePuntos,
            pu.NoPuntos              AS NoPuntos,
            0                        AS TotalPuntos,
            0 AS D1, 0 AS D2, 0 AS D3, 0 AS D4,
            0                        AS D5,
            @PrecioVenta * @Cantidad AS TotalRegistro,
            null AS NoRemision, null AS NoApartado,
            @Observacion             AS Observacion,
            null AS CanalId, null AS ListaId, NULL AS ZonaId, NULL AS EventoId, null AS VendedorId,
            11                       AS TipoDocumento,
            iv.Valor                 AS TarifaIvaVenta,
            ic.Valor                 AS TarifaIvaCompra,
            @PrecioVenta             AS PrecioVenta,
            pu.Aplica                AS AplicaPuntos,
            1 AS CantidadDpc, 0 AS DescuentoProducto,
            0                        AS Ahorro,
            1 AS MostrarDescuento,
            p.VenderXPeso, p.VenderXFraccion, p.NoManejaInventario, p.EsConjunto, p.TieneLote, p.TieneSerial,
            p.EsServicio, p.EsProduccion, p.EsAncheta, p.EsConcesion, p.EsObsequio, p.PerteneceAsociacion,
            p.ProductoWeb AS Productoweb, p.EsBolsa, p.Interno,
            @FechaPedido             AS Fecha,
            0 AS UsuarioId, 0 AS EquipoId, 0 AS TipoLiquidacionId,
            null AS NoCotizacion, null AS NoPedido, null AS NoFacturaTemporal,
            p.AplicaGrupoDeCosto, p.NoAplicaRedondeo, p.EsInsumo,
            0 AS Id1, NULL AS Id2, 0 AS SalidaId
        FROM Productos p
            JOIN ProductosPrecios pp ON pp.ProductoId = p.ProductoId AND pp.SucursalId = @sucursalErp
            JOIN ProductosPuntos  pu ON pu.ProductoId = p.ProductoId AND pu.SucursalId = @sucursalErp
            JOIN Ivas iv ON p.IvaVentaId = iv.IvaId
            JOIN Ivas ic ON p.IvaCompraId = ic.IvaId
        WHERE p.ProductoId = @idproducto;";

    private const string QueryD = @"
        SELECT ISNULL(MAX(Consecutivo), 0) + 1
        FROM SalidasDeMercancia
        WHERE TipoDocumentoId = 11
            AND EquipoId = (SELECT TOP 1 EquipoId FROM ParametrizarCajas WHERE CajaWeb = 1 AND SucursalId = @sucursalErp);";

    private const string InsertSalida = @"
        INSERT INTO dbo.SalidasDeMercancia
            (SalidaId, NoDocumento, Procesada, EmpresaId, BodegaId, CentroDeCostoId, VendedorId, MotivoId,
             DomiciliarioId, NoCotizacion, FechaDeSalida, HoraDeSalida, TotalSalida, TotalUtilidad, TotalCancelo,
             TotalPuntos, TotalAhorro, TotalDescuento, TotalCredito, Resolucion, Observacion, EquipoId, UsuarioId,
             FechaDeSistema, EquipoDestinoTemporalId, FechaFin, EstadoApartado, TotalAbono, EstadoCotizacion,
             TipoDevolucion, ModoDevolucion, ModoEnSa, TipoDocumento, Discriminator, Consecutivo, NoFacturaDevolucion,
             EstadoPedido, RutaPedidoId, EstadoTemporal, ClienteId, NoPedido, TotalIva, Cartera, Domicilio,
             ChequePosFechado, RutaFacturaId, ActualizaPrecios, NoApartado, FechaDePedidoFactura, NoIdentificacionNuevo,
             SucursalId, EstadoDomicilio, PropinaFactura, PropinaTemporal, NoTemporal, NoRemisionDevolucion,
             TipoDevolucionRemision, ModoDevolucionRemision, MotivoRemisionId, EstadoRemision, EstadoRemisionTemporal,
             EquipoDestinoRemisionTemporalId, PropinaRemisionTemporal, FechaDePedidoRemision, RutaRemisionId, Prefijo,
             TotalConcesion, EsFacturaDomicilio, Email, TipoDocumentoFactura, TipoDocumentoGenerar, PendienteCobro,
             Id2, Id1, EsFacturaConCanal, CanalId, ListaId, AplicaCanalTemporal, NoPedidoGenerado, FechaVencimiento,
             TipoDocumentoId, TipoFacturacion, Anulada, EsConversion, NoFacturaOrigen, Letra, TotalCosto, Id3,
             AjusteAlPeso, TotalDomicilioTercero)
        OUTPUT inserted.SalidaId
        VALUES
            ((SELECT ISNULL(MAX(SalidaId), 0) + 1 FROM SalidasDeMercancia), @NoDocumento, @Procesada, @EmpresaId,
             @BodegaId, @CentroDeCostoId, @VendedorId, @MotivoId, @DomiciliarioId, @NoCotizacion, @FechaDeSalida,
             CAST(@FechaDeSalida AS TIME), @TotalSalida, @TotalUtilidad, @TotalCancelo, @TotalPuntos, @TotalAhorro,
             @TotalDescuento, @TotalCredito, @Resolucion, @Observacion, @EquipoId, @UsuarioId, @FechaDeSistema,
             @EquipoDestinoTemporalId, @FechaFin, @EstadoApartado, @TotalAbono, @EstadoCotizacion, @TipoDevolucion,
             @ModoDevolucion, @ModoEnSa, @TipoDocumento, @Discriminator, @Consecutivo, @NoFacturaDevolucion,
             @EstadoPedido, @RutaPedidoId, @EstadoTemporal, @ClienteId, @NoPedido, @TotalIva, @Cartera, @Domicilio,
             @ChequePosFechado, @RutaFacturaId, @ActualizaPrecios, @NoApartado, @FechaDePedidoFactura,
             @NoIdentificacionNuevo, @SucursalId, @EstadoDomicilio, @PropinaFactura, @PropinaTemporal, @NoTemporal,
             @NoRemisionDevolucion, @TipoDevolucionRemision, @ModoDevolucionRemision, @MotivoRemisionId, @EstadoRemision,
             @EstadoRemisionTemporal, @EquipoDestinoRemisionTemporalId, @PropinaRemisionTemporal, @FechaDePedidoRemision,
             @RutaRemisionId, @Prefijo, @TotalConcesion, @EsFacturaDomicilio, @Email, @TipoDocumentoFactura,
             @TipoDocumentoGenerar, @PendienteCobro, @Id2, @Id1, @EsFacturaConCanal, @CanalId, @ListaId,
             @AplicaCanalTemporal, @NoPedidoGenerado, @FechaVencimiento, @TipoDocumentoId, @TipoFacturacion, @Anulada,
             @EsConversion, @NoFacturaOrigen, @Letra, @TotalCosto, @Id3, @AjusteAlPeso, 0);";

    private const string InsertDetalle = @"
        INSERT INTO dbo.SalidasDeMercanciaDetalle
            (NoDocumento, Id, ProductoId, CodigoAlterno, DescripcionLarga, DescripcionCorta, Embalaje, IvaVentaId,
             IvaCompraId, ImpoConsumo, PrecioCosto, PrecioPublico, PrecioPublicoReal, CantidadEntrada, CantidadSalida,
             BasePuntos, NoPuntos, TotalPuntos, D1, D2, D3, D4, D5, TotalRegistro, NoRemision, NoApartado, Observacion,
             CanalId, ListaId, ZonaId, EventoId, VendedorId, TipoDocumento, TarifaIvaVenta, TarifaIvaCompra, PrecioVenta,
             AplicaPuntos, CantidadDpc, DescuentoProducto, Ahorro, MostrarDescuento, VenderXPeso, VenderXFraccion,
             NoManejaInventario, EsConjunto, TieneLote, TieneSerial, EsServicio, EsProduccion, EsAncheta, EsConcesion,
             EsObsequio, PerteneceAsociacion, Productoweb, EsBolsa, Interno, Fecha, UsuarioId, EquipoId, TipoLiquidacionId,
             NoCotizacion, NoPedido, NoFacturaTemporal, AplicaGrupoDeCosto, NoAplicaRedondeo, EsInsumo, Id1, Id2, SalidaId,
             EsKit, ImpuestoId, TarifaIvaImpuesto)
        VALUES
            (@NoDocumento, @Id, @ProductoId, @CodigoAlterno, @DescripcionLarga, @DescripcionCorta, @Embalaje, @IvaVentaId,
             @IvaCompraId, @ImpoConsumo, @PrecioCosto, @PrecioPublico, @PrecioPublicoReal, @CantidadEntrada, @CantidadSalida,
             @BasePuntos, @NoPuntos, @TotalPuntos, @D1, @D2, @D3, @D4, @D5, @TotalRegistro, @NoRemision, @NoApartado,
             @Observacion, @CanalId, @ListaId, @ZonaId, @EventoId, @VendedorId, @TipoDocumento, @TarifaIvaVenta,
             @TarifaIvaCompra, @PrecioVenta, @AplicaPuntos, @CantidadDpc, @DescuentoProducto, @Ahorro, @MostrarDescuento,
             @VenderXPeso, @VenderXFraccion, @NoManejaInventario, @EsConjunto, @TieneLote, @TieneSerial, @EsServicio,
             @EsProduccion, @EsAncheta, @EsConcesion, @EsObsequio, @PerteneceAsociacion, @Productoweb, @EsBolsa, @Interno,
             @Fecha, @UsuarioId, @EquipoId, @TipoLiquidacionId, @NoCotizacion, @NoPedido, @NoFacturaTemporal,
             @AplicaGrupoDeCosto, @NoAplicaRedondeo, @EsInsumo, @Id1, @Id2, @SalidaId, 0, 0, 0);";

    private const string InsertTercero = @"
        INSERT INTO dbo.SalidasDeMercanciaTercero
            (SalidaId, NoDocumento, Procesada, TipoDeDocumentoId, NoIdentificacion, CiudadDeExpedicionId, NombreCompleto,
             PrimerNombre, PrimerApellido, SegundoNombre, SegundoApellido, Alias, Direccion, Telefono, Telefono3, Email,
             Genero, FechaNacimiento, PaisId, DepartamentoId, CiudadId, BarrioId, RutaId, TipoPersona, RegimenId,
             TipoDeContribuyenteId, EquipoId, UsuarioId, DigitoDeChequeo, RazonSocial, Representante)
        VALUES
            (@SalidaId, @NoDocumento, @Procesada, @TipoDeDocumentoId, @NoIdentificacion, @CiudadDeExpedicionId,
             @NombreCompleto, @PrimerNombre, @PrimerApellido, @SegundoNombre, @SegundoApellido, @Alias, @Direccion,
             @Telefono, @Telefono3, @Email, @Genero, @FechaNacimiento, @PaisId, @DepartamentoId, @CiudadId, @BarrioId,
             @RutaId, @TipoPersona, @RegimenId, @TipoDeContribuyenteId, @EquipoId, @UsuarioId, @DigitoDeChequeo,
             @RazonSocial, @Representante);";

    private const string InsertMovimiento = @"
        INSERT INTO dbo.MovimientosxProcesar
            (Id, NoDocumento, EmpresaId, SucursalId, BodegaId, Procesada, Contabilizada, FechaDeSistema,
             FechaDeProceso, TipoProceso, UsuarioId, FechaDocumento, EquipoId)
        VALUES
            ((SELECT ISNULL(MAX(Id), 0) + 1 FROM dbo.MovimientosxProcesar), @NoDocumento, @EmpresaId, @SucursalId,
             @BodegaId, @Procesada, @Contabilizada, @FechaDeSistema, @FechaDeProceso, @TipoProceso, @UsuarioId,
             @FechaDocumento, @EquipoId);";

    #endregion
}
