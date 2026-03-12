using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class EstadoPedidoService : IEstadoPedidoService
{

    private readonly IEstadoPedidoRepository _repository;

    public EstadoPedidoService(IEstadoPedidoRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<EstadoPedidoDto>> ObtenerEstadoPedido()
    {
        var data = await _repository.GetAll();
        return data;
    }
}

