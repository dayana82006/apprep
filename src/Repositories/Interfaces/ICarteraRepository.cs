using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface ICarteraRepository
{
    Task<List<CarteraDto>> GetAllCartera(int numpag);
}
