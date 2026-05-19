using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using Dapper;
using SQLitePCL;

namespace AplMovilBexsolucionesApi.Repositories;

public class InventarioRepository : IInventarioRepository
{
    public readonly DapperContext _contex;
    public readonly ILogger<InventarioRepository> _logger;
    
    public InventarioRepository(DapperContext contex,  ILogger<InventarioRepository> logger)
    {
        _contex = contex;
        _logger = logger;
    }
    public async Task<List<InventarioDto>> GetAll(int numpag)
    {

        const string sql = @"
                          DECLARE @PageNumber INT = @numpag;
                            DECLARE @RowsPerPage INT = 1000000;

                            SELECT 
                                T.BodegaId AS codbodega, 
                                T2.Valor AS iva,
                                T.ProductoId AS codproducto,
                                T.Existencia AS cantidadinventario
                            FROM ProductosBodegas T
                            INNER JOIN dbo.Productos T1 ON T.ProductoId = T1.ProductoId
                            INNER JOIN dbo.Ivas T2 ON T2.IvaId = T1.IvaVentaId
                            WHERE T.ProductoId IN ( 
                                SELECT DISTINCT T3.ProductoId 
                                FROM dbo.ProductosCaracteristicasSucursal T3 
                                WHERE T3.Estado = 1 
                            )
                            ORDER BY T.ProductoId
                            OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
                            FETCH NEXT @RowsPerPage ROWS ONLY;
";

        using var connection = _contex.CreateConnection();
        _logger.LogInformation("Consultando inventario");
        var result = (await connection.QueryAsync<InventarioDto>(sql, new { numpag = numpag })).ToList();
        return result;
    }
}
