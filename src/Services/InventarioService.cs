using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class InventarioService : IInventarioService
{

    private readonly IInventarioRepository _repository;
    private readonly ILogger<InventarioService> _logger;

    public InventarioService(IInventarioRepository repository, ILogger<InventarioService> logger )
    {
        _repository = repository;
        _logger = logger;
    }
     async Task<IEnumerable<InventarioDto>> IInventarioService.ObtenerInventario()
    {
        var data = await _repository.GetAll();
        return data;
    }
}
