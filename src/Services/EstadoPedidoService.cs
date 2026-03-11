using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class EstadoPedidoService
{

    private readonly IEstadoPedidoRepository _repository;

    public EstadoPedidoService(IEstadoPedidoRepository repository)
    {
        _repository = repository;
    }

}
