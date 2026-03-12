using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IVendedorRepository
{
    Task<List<VendedorDto>> GetAllVendedor(int numpag);
}
