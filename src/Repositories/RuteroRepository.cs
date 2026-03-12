using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class RuteroRepository : IRuteroRepository
{
    public readonly DapperContext _context;

    public readonly ILogger<RuteroRepository> _logger;

    public RuteroRepository(DapperContext context, ILogger<RuteroRepository> logger)

    {
        _context = context;
        _logger = logger;
    }



    public async Task<List<RuteroDto>> GetAllRutero()
    {
        const string sql = @"SELECT * FROM Rutero";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Ruteros");

        var result = (await connection.QueryAsync<RuteroDto>(sql)).ToList();


        return result;
    }
}