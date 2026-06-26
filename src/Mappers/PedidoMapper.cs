using AplMovilBexsolucionesApi.Helpers;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Mappers;

public static class PedidoMapper
{
    
    public static string NoDocumento(int equipoId, int consecutivo) =>
        "011" + equipoId.ToString().PadLeft(4, '0') + consecutivo.ToString().PadLeft(10, '0');

    public static SalidaMercancia CrearSalida(
        RecPedidoDto input, CajaConfig caja, int consecutivo, string noDocumento,
        int usuarioId, int clienteId, DateTime fecha,
        IReadOnlyList<SalidaMercanciaDetalle> detalle)
    {
        var salida = new SalidaMercancia
        {
            NoDocumento = noDocumento,
            Procesada = false,
            EmpresaId = caja.EmpresaId,
            BodegaId = caja.BodegaId,
            CentroDeCostoId = 1,
            FechaDeSalida = fecha,
            TotalCancelo = 0,
            TotalDescuento = 0,
            TotalCredito = 0,
            TotalConcesion = 0,
            TotalAhorro = 0,
            Consecutivo = consecutivo,
            Prefijo = null,
            Resolucion = null,
            Observacion = $"PEDIDO REF:{noDocumento}{Environment.NewLine}{input.Observacion}",
            EquipoId = caja.EquipoId,
            UsuarioId = usuarioId,
            FechaDeSistema = fecha,
            TipoDocumento = "11",
            EstadoPedido = 1,
            ClienteId = clienteId,
            Cartera = false,
            Domicilio = true,
            ChequePosFechado = false,
            ActualizaPrecios = false,
            FechaDePedidoFactura = fecha,
            SucursalId = caja.SucursalId,
            EstadoDomicilio = 1,
            PropinaFactura = 0,
            PropinaTemporal = 0,
            FechaDePedidoRemision = fecha,
            EsFacturaDomicilio = true,
            Email = false,
            TipoDocumentoFactura = 0,
            TipoDocumentoGenerar = 0,
            PendienteCobro = false,
            Id2 = 0,
            Id1 = false,
            EsFacturaConCanal = false,
            AplicaCanalTemporal = false,
            FechaVencimiento = fecha,
            TipoDocumentoId = 11,
            TipoFacturacion = 0,
            Anulada = false,
            EsConversion = true,
            Letra = "0",
            Id3 = fecha
        };
        foreach (var d in detalle)
        {
            salida.TotalSalida += d.PrecioVenta * d.CantidadSalida;
            salida.TotalUtilidad += d.TotalRegistro;
            salida.TotalPuntos += d.BasePuntos == 0 ? 0 : (int)(d.TotalRegistro / d.BasePuntos * d.TotalPuntos);
            salida.TotalCosto += d.PrecioCosto * d.CantidadSalida;
            salida.TotalIva += d.TarifaIvaVenta / 100m * (d.PrecioVenta - d.ImpoConsumo) * d.CantidadSalida;
        }

        return salida;
    }

    public static void CompletarDetalle(
        IReadOnlyList<SalidaMercanciaDetalle> detalle, string noDocumento, int salidaId)
    {
        var id = 1;
        foreach (var d in detalle)
        {
            d.NoDocumento = noDocumento;
            d.Id = id++;
            d.SalidaId = salidaId;
            d.D5 = 0; // sin descuento
        }
    }

    /// <summary>Tercero del documento, desde el cliente existente en Personas.</summary>
    public static SalidaMercanciaTercero CrearTercero(PersonaErp p, string noDocumento, int salidaId, int usuarioId) => new()
    {
        SalidaId = salidaId,
        NoDocumento = noDocumento,
        Procesada = false,
        TipoDeDocumentoId = p.TipoDeDocumentoId,
        NoIdentificacion = p.NoIdentificacion,
        CiudadDeExpedicionId = p.CiudadId,
        NombreCompleto = $"{p.PrimerNombre} {p.SegundoNombre} {p.PrimerApellido} {p.SegundoApellido}".Replace("  ", " ").Trim(),
        PrimerNombre = p.PrimerNombre ?? string.Empty,
        PrimerApellido = p.PrimerApellido ?? string.Empty,
        SegundoNombre = p.SegundoNombre ?? string.Empty,
        SegundoApellido = p.SegundoApellido,
        Alias = string.Empty,
        Direccion = p.Direccion ?? string.Empty,
        Telefono = p.Telefono1,
        Telefono3 = string.Empty,
        Email = p.Email ?? string.Empty,
        Genero = 3,
        FechaNacimiento = null,
        PaisId = 1,
        DepartamentoId = p.DepartamentoId,
        CiudadId = p.CiudadId,
        BarrioId = 1,
        RutaId = null,
        TipoPersona = p.TipoDeDocumentoId,
        RegimenId = p.RegimenId,
        TipoDeContribuyenteId = 1,
        EquipoId = p.EquipoId,
        UsuarioId = usuarioId,
        DigitoDeChequeo = Identificacion.CalcularDigito(p.NoIdentificacion),
        RazonSocial = p.RazonSocial,
        Representante = p.RazonSocial
    };

    /// <summary>Movimiento a procesar (TipoProceso 15 = salida de mercancía).</summary>
    public static MovimientoProcesar CrearMovimiento(CajaConfig caja, string noDocumento, DateTime fecha, int usuarioId) => new()
    {
        NoDocumento = noDocumento,
        EmpresaId = caja.EmpresaId,
        SucursalId = caja.SucursalId,
        BodegaId = caja.BodegaId,
        Procesada = false,
        Contabilizada = false,
        FechaDeSistema = fecha,
        FechaDeProceso = fecha,
        TipoProceso = 15,
        UsuarioId = usuarioId,
        FechaDocumento = fecha,
        EquipoId = caja.EquipoId
    };
}
