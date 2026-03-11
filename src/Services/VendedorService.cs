using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class VendedorService
{

    private readonly IVendedorRepository _repository;

    public VendedorService(IVendedorRepository repository)
    {
        _repository = repository;
    }

}
