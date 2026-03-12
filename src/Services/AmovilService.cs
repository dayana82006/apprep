using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class AmovilService : IAmovilService 
{
    private readonly IAmovilRepository _repository;
    private readonly ILogger<AmovilService> _logger;

    public AmovilService(IAmovilRepository repository, ILogger<AmovilService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<AmovilDto>> GetAmovil()
    {
        var data = await _repository.GetAmovil();
        return data;
    }
}
