using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class CarteraRepository : ICarteraRepository
{
    public readonly DapperContext _context;
    public readonly ILogger _logger;

    public CarteraRepository(DapperContext context, ILogger<CarteraRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<CarteraDto>> GetAllCartera()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();
        _logger .LogInformation("Consultando cartera");
        var result = (await connection.QueryAsync<CarteraDto>(sql)).ToList();
        return result;
    }

}
