using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class PrecioService
{

    private readonly IPrecioRepository _repository;

    public PrecioService(IPrecioRepository repository)
    {
        _repository = repository;
    }

}
