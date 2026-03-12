using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class ClienteService : IClienteService
{

    private readonly IClienteRepository _repository;
    private readonly ILogger<ClienteService> _logger;

    public ClienteService(IClienteRepository repository, ILogger<ClienteService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<IEnumerable<ClienteDto>> ObtenerClientes(int numpag)
    {
        var data = await _repository.GetAllClientes(numpag);
        return data;
    }

}
