using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class ObsequioService : IObsequioService
{

    private readonly IObsequioRepository _repository;
    private readonly ILogger<ObsequioService> _logger;

    public ObsequioService(IObsequioRepository repository, ILogger<ObsequioService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<IEnumerable<ObsequioDto>> ObtenerObsequios(int numpag)
    {
        var data = await _repository.GetAllObsequio(numpag);
        return data;
    }

}
