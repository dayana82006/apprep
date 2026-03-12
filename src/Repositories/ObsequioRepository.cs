using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class ObsequioRepository : IObsequioRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<ObsequioRepository> _logger;

    public ObsequioRepository(DapperContext context, ILogger<ObsequioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<ObsequioDto>> GetAllObsequio()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Obsequios");

        var result = (await connection.QueryAsync<ObsequioDto>(sql)).ToList();

        return result;
    }
}