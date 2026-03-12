using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IPrecioRepository
{
    Task<List<PrecioDto>> GetAllPrecio(int numpag);
}
