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

        const string sql = @"SELECT 
                            BodegaId AS codbodega, 
                            null AS iva,
                            ProductoId AS codproducto,
                            Existencia AS cantidadinventario
                            FROM ProductosBodegas";

        using var connection = _contex.CreateConnection();
        _logger.LogInformation("Consultando inventario");
        var result = (await connection.QueryAsync<InventarioDto>(sql, new { numpag = numpag })).ToList();
        return result;
    }
}
