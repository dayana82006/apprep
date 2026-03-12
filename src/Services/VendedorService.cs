using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class VendedorService : IVendedorService
{
    private readonly IVendedorRepository _repository;
    private readonly ILogger _logger;

    public VendedorService(IVendedorRepository repository, ILogger logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<VendedorDto>>ObtenerVendedor()
    {
        return await _repository.GetAllVendedor();
    }
}