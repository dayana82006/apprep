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

          SELECT 
            BodegaId AS codbodega, 
            T2.Valor  AS iva,
            T.ProductoId AS codproducto,
            Existencia AS cantidadinventario
            FROM ProductosBodegas	T 
            INNER JOIN DBO.Productos T1 ON ( T.ProductoId=T1.ProductoId ) 
            INNER JOIN dbo.Ivas T2 ON ( T2.IvaId = T1.IvaVentaId )
";

        using var connection = _contex.CreateConnection();
        _logger.LogInformation("Consultando inventario");
        var result = (await connection.QueryAsync<InventarioDto>(sql, new { numpag = numpag })).ToList();
        return result;
    }
}
