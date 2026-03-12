using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;
<<<<<<< HEAD
=======

>>>>>>> c0fb9dd (Terminados los repositorios)

namespace AplMovilBexsolucionesApi.Repositories;

public class ObsequioRepository : IObsequioRepository
{
<<<<<<< HEAD
    public readonly DapperContext _context;
    public readonly ILogger<ObsequioRepository> _logger;
=======
    private readonly DapperContext _context;
    private readonly ILogger<ObsequioRepository> _logger;
>>>>>>> c0fb9dd (Terminados los repositorios)

    public ObsequioRepository(DapperContext context, ILogger<ObsequioRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<ObsequioDto>> GetAllObsequio()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();

<<<<<<< HEAD
        _logger.LogInformation("Consultando Obsequios");
=======
        _logger.LogInformation("Consultando obsequios");
>>>>>>> c0fb9dd (Terminados los repositorios)

        var result = (await connection.QueryAsync<ObsequioDto>(sql)).ToList();

        return result;
    }
<<<<<<< HEAD
}
=======
} 
>>>>>>> c0fb9dd (Terminados los repositorios)
