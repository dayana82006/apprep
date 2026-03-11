using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Repositories;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class AmovilService : IAmovilService
{

    private readonly IAmovilRepository _repository;

    public AmovilService(IAmovilRepository repository)
    {
        _repository = repository;
    }

}
