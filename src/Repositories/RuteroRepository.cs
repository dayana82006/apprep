using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class ObsequioRepository : IObsequioRepository
{
    public readonly DapperContext _context;
<<<<<<< HEAD
    public readonly ILogger<ObsequioRepository> _logger;

    public ObsequioRepository(DapperContext context, ILogger<ObsequioRepository> logger)
=======
    public readonly ILogger<RuteroRepository> _logger;

    public RuteroRepository(DapperContext context, ILogger<RuteroRepository> logger)
>>>>>>> c0fb9dd (Terminados los repositorios)
    {
        _context = context;
        _logger = logger;
    }

<<<<<<< HEAD
    public async Task<List<ObsequioDto>> GetAllObsequio()
    {
        const string sql = @"SELECT * FROM obsequio";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Obsequios");

        var result = (await connection.QueryAsync<ObsequioDto>(sql)).ToList();
=======
    public async Task<List<RuteroDto>> GetAllRutero()
    {
        const string sql = @"SELECT * FROM Rutero";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Ruteros");

        var result = (await connection.QueryAsync<RuteroDto>(sql)).ToList();
>>>>>>> c0fb9dd (Terminados los repositorios)

        return result;
    }
}