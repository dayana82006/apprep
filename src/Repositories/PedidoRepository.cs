using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

using AplMovilBexsolucionesApi.Data;
using Dapper;

namespace AplMovilBexsolucionesApi.Repositories;

public class PedidoRepository : IEstadoPedidoRepository
{
    public readonly DapperContext _context;
    public readonly ILogger<PedidoRepository> _logger;

    public PedidoRepository(DapperContext context, ILogger<PedidoRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<EstadoPedidoDto>> GetAllEstados(int numpag)
    {
        const string sql = @"";

        using var connection = _context.CreateConnection();

        _logger.LogInformation("Consultando estados de pedidos");

        var result = await connection.QueryAsync<EstadoPedidoDto>(sql, new { numpag = numpag });

        return result.ToList();
    }
    public async Task<List<EstadoPedidoDto>> GuardarPedido(RecPedidoDto pedido)
    {
        using var connection = _context.CreateConnection();

       const string sql = @"SELECT 1";
        var result = await connection.QueryAsync<EstadoPedidoDto>(sql,pedido);

        return result.ToList();
    }
}