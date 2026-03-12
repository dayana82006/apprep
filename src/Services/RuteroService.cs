using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Services;

public class RuteroService : IRuteroService
{

    private readonly IRuteroRepository _repository;
    private readonly ILogger<RuteroService> _logger;
    public RuteroService(IRuteroRepository repository, ILogger<RuteroService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<IEnumerable<RuteroDto>> ObtenerRuteros()
    {
        var data = await _repository.GetAllRutero();
        return data;
    }

}
