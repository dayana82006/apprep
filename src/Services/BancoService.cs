using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class BancoService
{

    private readonly IBancoRepository _repository;

    public BancoService(IBancoRepository repository)
    {
        _repository = repository;
    }

}
