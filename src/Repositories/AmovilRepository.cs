using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Models.DTOs;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class AmovilRepository : IAmovilRepository
{
    private readonly DapperContext _context;
    private readonly ILogger<AmovilRepository> _logger;

    public AmovilRepository(DapperContext context, ILogger<AmovilRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<AmovilDto>> GetAmovil()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando amoviles");

        var result = (await connection.QueryAsync<AmovilDto>(sql)).ToList();
        return result;
    }

    public async Task<List<string>> GetAmovilPipe()
    {
        var amoviles = await GetAmovil();

        var pipeList = amoviles
            .Select(a => $"{a.NitCliente}|{a.SucCliente}|{a.Anio}|{a.Mes}|{a.CodVendedor}|{a.Valor}")
            .ToList();

        return pipeList;
    }
}