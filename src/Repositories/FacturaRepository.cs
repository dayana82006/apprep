using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using Dapper;
using MySqlX.XDevAPI.Common;
using System.Data;

namespace AplMovilBexsolucionesApi.Repositories;

public class FacturaRepository : IFacturaRepository
{
    public readonly DapperContext _context;
    public readonly ILogger _logger;

    public FacturaRepository(DapperContext context, ILogger<FacturaRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task AddAsync(FacturasDto factura)
    {
        throw new NotImplementedException();
    }

    public async Task<List<FacturasDto>> GetAll(int numpag)
    {
        const string sql = @"
                DECLARE @PageNumber INT = @numpag;
                DECLARE @RowsPerPage INT = 10000;

                SELECT 
                    ISNULL(T.VendedorId, 0) AS codvendedor,
                    T1.NoIdentificacion AS number_customer,
                    null AS code_place,
                    T1.NombreCompleto AS razon_social,
                    T1.Direccion AS address,
                    '' AS geolocation,
                    T1.Telefono AS phone,
                    T.Email AS email,
                    T3.Codigo AS city,
                    T4.Codigo AS state,
                    T.Observacion AS observations,
                    T.FechaDeSalida AS date,
                    null AS date_delivery,
                    null AS codfpagovta,
                    CASE 
                        WHEN T.Cartera = 1 THEN DATEDIFF(day, T.FechaVencimiento, T.FechaDeSalida) 
                        ELSE 0 
                    END AS periodfpagovta,
                    T.Consecutivo AS order_number,
                    T.Prefijo AS type,
                    T2.CodigoAlterno AS coditem,
                    T2.DescripcionLarga AS name_item,
                    T2.CantidadSalida AS amount,
                    ISNULL(T6.Descripcion, '') AS unit_of_measurement,
                    T6.Descripcion AS name_of_measurement,
                    T2.PrecioVenta AS price,
                    '' AS type_item,
                    T2.ProductoId AS rowid,
                    T7.Peso AS weight,
                    null AS volumen,
                    T.TotalSalida AS Grand_total,
                    ISNULL((SELECT SUM(Valor) FROM dbo.Tesoreria WHERE NoDocumento = t.NoDocumento AND TipoDePago = 12), 0) AS retencion,
                    CASE 
                        WHEN T.Cartera = 1 OR T.Domicilio = 1 THEN 'CREDITO' 
                        ELSE 'CONTADO' 
                    END AS type_of_charge,
                    T.BodegaId AS code_warehouse,
                    '' AS operative_center,
                    T.CentroDeCostoId AS cost_center,
                    T.SucursalId AS unidneg,
                    '' AS type_transaction
                FROM dbo.SalidasDeMercancia T  
                INNER JOIN dbo.SalidasDeMercanciaTercero T1 ON (T.NoDocumento = T1.NoDocumento)  
                INNER JOIN dbo.SalidasDeMercanciaDetalle T2 ON (T.NoDocumento = T2.NoDocumento)  
                INNER JOIN dbo.Ciudad T3 ON (T3.CiudadId = T1.CiudadId)  
                INNER JOIN dbo.Departamentos T4 ON (T4.DepartamentoId = T1.CiudadId) 
                INNER JOIN dbo.Productos T5 ON (T5.ProductoId = T2.ProductoId)  
                LEFT JOIN dbo.UnidadesDeMedida T6 ON (T6.UnidadDeMedidaId = T5.UnidadDeMedidaId)  
                INNER JOIN dbo.ProductosCaracteristicas T7 ON (T7.ProductoId = T5.ProductoId)  
                INNER JOIN dbo.MovimientosxProcesar T8 ON (T8.NoDocumento = T.NoDocumento AND T8.TipoProceso = 6)  
                WHERE T8.FechaDeProceso >= '2026-06-01' AND T.TipoDocumentoId = 1  
                ORDER BY T.FechaDeSalida, T.Prefijo, T.Consecutivo, T2.ProductoId
                OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                FETCH NEXT @RowsPerPage ROWS ONLY;
            ";

        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando facturas planas, página {Numpag}", numpag);

        var result = (await connection.QueryAsync<FacturasDto>(sql, new { numpag })).ToList();
        return result;
    }

   

  
}