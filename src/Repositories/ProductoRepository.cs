using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class ProductoRepository : IProductoRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<ProductoRepository> _logger;

    public ProductoRepository(DapperContext context, ILogger<ProductoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<ProductoDto>> GetAllProducto()
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando Productos");

        var result = (await connection.QueryAsync<ProductoDto>(sql)).ToList();

        return result;
    }
}