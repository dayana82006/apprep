using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class DescuentoService
{

    private readonly IDescuentoRepository _repository;

    public DescuentoService(IDescuentoRepository repository)
    {
        _repository = repository;
    }

}
