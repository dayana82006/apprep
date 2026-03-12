using AplMovilBexsolucionesApi.Data;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class ClienteRepository : IClienteRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<ClienteRepository> _logger;

    public ClienteRepository(DapperContext context,  ILogger<ClienteRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<ClienteDto>>GetAllClientes()
    {
        const string sql = @"";
        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando clientes");

        var cliente = (await connection.QueryAsync<ClienteDto>(sql)).ToList();
        return cliente;
       
}

}
