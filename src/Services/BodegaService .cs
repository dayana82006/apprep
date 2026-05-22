using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class BodegaService : IBodegaService
{
    private readonly IBodegaRepository _repository;
    private readonly ILogger<BodegaService> _logger;

    public BodegaService(IBodegaRepository repository, ILogger<BodegaService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<BodegaDto>> GetBodegasActivasAsync()
    {
        var data = await _repository.GetBodegasActivasAsync();
        return data;
    }
}