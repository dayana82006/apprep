using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class VendedorService : IVendedorService
{
    private readonly IVendedorRepository _repository;

    public VendedorService(IVendedorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<VendedorDto>> GetAll()
    {
        return await _repository.GetAll();
    }
}