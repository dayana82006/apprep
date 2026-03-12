using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class PrecioRepository : IPrecioRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<PrecioRepository> _logger;

    public PrecioRepository(DapperContext context, ILogger<PrecioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<PrecioDto>> GetAllPrecio()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Precios");

        var result = (await connection.QueryAsync<PrecioDto>(sql)).ToList();

        return result;
    }
}