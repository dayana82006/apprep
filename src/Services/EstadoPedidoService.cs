using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

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
        var data = await _repository.GetAll(numpag);
        return data;
    }
}

