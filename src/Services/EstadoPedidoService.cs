using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Services;

public class EstadoPedidoService : IEstadoPedidoService
{
    private readonly IPedidoRepository _repository;
    private readonly ILogger<EstadoPedidoService> _logger;

    public EstadoPedidoService(IPedidoRepository repository, ILogger<EstadoPedidoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<RespuestaPedidoDto> GuardarPedido(RecPedidoDto pedido)
    {
        _logger.LogInformation("Recibiendo un nuevo pedido");
        return await _repository.GuardarPedido(pedido);
    }
}
