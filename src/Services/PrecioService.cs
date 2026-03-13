using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class PrecioService : IPrecioService
{

    private readonly IPrecioRepository _repository;
    private readonly ILogger _logger;

    public PrecioService(IPrecioRepository repository, ILogger<PrecioService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
     async Task<IEnumerable<PrecioDto>> IPrecioService.ObtenerPrecios(int numpag)
    {
        if (numpag <= 0) { numpag = 1; }
        var data = await _repository.GetAllPrecio(numpag);
        return data;
    }
}
