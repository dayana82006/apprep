using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IDescuentoRepository
{
    Task<List<DescuentoDto>> GetAllDescuento(int numpag);
}
