using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using SQLitePCL;

namespace AplMovilBexsolucionesApi.Repositories;

public class InventarioRepository : IInventarioRepository
{
    public readonly DapperContext _contex;
    public readonly ILogger<InventarioRepository> _logger;
    
    public InventarioRepository(DapperContext contex,  ILogger<InventarioRepository> logger)
    {
        _context = contex;
        _logger = logger;
    }
    public async Task<List<InventarioDto>> GetAll()
    {
        const string sql = @""

        using var connection = _contex.CreateConnection();
        _logger.LogInformation("Consultando inventario");
        var result = (await connection.QueryAsync<InventarioDto>(sql)).ToList();
        return result;
    }
}
