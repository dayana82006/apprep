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
    public async Task<List<InventarioDto>> GetAll()
    {
<<<<<<< HEAD
        const string sql = @""
=======
        const string sql = @"";
>>>>>>> c0fb9dd (Terminados los repositorios)

        using var connection = _contex.CreateConnection();
        _logger.LogInformation("Consultando inventario");
        var result = (await connection.QueryAsync<InventarioDto>(sql)).ToList();
        return result;
    }
}
