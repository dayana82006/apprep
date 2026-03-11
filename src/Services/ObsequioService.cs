using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class ObsequioService
{

    private readonly IObsequioRepository _repository;

    public ObsequioService(IObsequioRepository repository)
    {
        _repository = repository;
    }

}
