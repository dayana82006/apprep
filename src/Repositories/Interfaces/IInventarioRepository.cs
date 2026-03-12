using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IInventarioRepository
{
    Task<List<InventarioDto>> GetAll(int numpag);
}
