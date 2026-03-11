using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class CarteraService
{

    private readonly ICarteraRepository _repository;

    public CarteraService(ICarteraRepository repository)
    {
        _repository = repository;
    }

}
