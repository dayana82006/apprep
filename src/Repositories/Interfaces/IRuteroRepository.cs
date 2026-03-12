using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IRuteroRepository
{
    Task<List<RuteroDto>> GetAllRutero(int numpag);
}
