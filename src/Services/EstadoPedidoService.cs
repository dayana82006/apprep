using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Services;

public class EstadoPedidoService : IEstadoPedidoService
{

    private readonly IEstadoPedidoRepository _repository;
    private readonly ILogger<EstadoPedidoService> _logger;

    public EstadoPedidoService(IEstadoPedidoRepository repository, ILogger<EstadoPedidoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<IEnumerable<EstadoPedidoDto>> ObtenerEstadoPedido(int numpag)
    {
        if (numpag <= 0) { numpag = 1; }
        var data = await _repository.GetAllEstados(numpag);
        return data;
    }
    public async Task GuardarPedido(RecPedidoDto pedido)
    {
        _logger.LogInformation("Recibiendo un nuevo pedido");

        await _repository.GuardarPedido(pedido);
    }


}


