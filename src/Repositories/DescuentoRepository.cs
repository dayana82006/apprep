using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class DescuentoRepository : IDescuentoRepository
{
    public readonly DapperContext _context;
    public readonly ILogger _logger;

    public DescuentoRepository(DapperContext context, ILogger<DescuentoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<List<DescuentoDto>> GetAllDescuento()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();
        _logger.LogInformation("Consultando Descuento");
        var result = await connection.QueryAsync<DescuentoDto>(sql);
        return result.ToList();
    }

   
}
