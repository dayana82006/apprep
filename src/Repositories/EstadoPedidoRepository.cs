using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class EstadoPedidoRepository : IEstadoPedidoRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<EstadoPedidoRepository> _logger;

    public EstadoPedidoRepository(DapperContext context, ILogger<EstadoPedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<EstadoPedidoDto>> GetAll(int numpag)
    {
        const string sql = @"SELECT * FROM estado_pedido";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando estados de pedidos");

        var result = await connection.QueryAsync<EstadoPedidoDto>(sql, new { numpag = numpag });

        return result.ToList();
    }
}