using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class RuteroService
{

    private readonly IRuteroRepository _repository;

    public RuteroService(IRuteroRepository repository)
    {
        _repository = repository;
    }

}
