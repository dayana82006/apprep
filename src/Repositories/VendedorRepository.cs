using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class VendedorRepository : IVendedorRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<VendedorRepository> _logger;
    public VendedorRepository(DapperContext context, ILogger<VendedorRepository> logger)

    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<VendedorDto>> GetAllVendedor(int numpag)
    {
        const string sql = @"SELECT * FROM Vendedor";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Vendedors");

        var result = (await connection.QueryAsync<VendedorDto>(sql, new { numpag = numpag })).ToList();

        return result;
    }
}