using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class InventarioService
{

    private readonly IInventarioRepository _repository;

    public InventarioService(IInventarioRepository repository)
    {
        _repository = repository;
    }

}
