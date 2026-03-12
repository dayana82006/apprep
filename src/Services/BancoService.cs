using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class BancoService : IBancoService
{

    private readonly IBancoRepository _repository;
    private readonly ILogger<BancoService> _logger;

    public BancoService(IBancoRepository repository, ILogger<BancoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<IEnumerable<BancoDto>> ObtenerBancos()
    {
        var data = await _repository.GetBanco();
        return data;
    }

}
