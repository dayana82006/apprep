using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;
public class ObsequioRepository : IObsequioRepository
{
    private readonly DapperContext _context;
    private readonly ILogger<ObsequioRepository> _logger;
    public ObsequioRepository(DapperContext context, ILogger<ObsequioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<ObsequioDto>> GetAllObsequio()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();


        _logger.LogInformation("Consultando obsequios");

        var result = (await connection.QueryAsync<ObsequioDto>(sql)).ToList();

        return result;
    }

}
