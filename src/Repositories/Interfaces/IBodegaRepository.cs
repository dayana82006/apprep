using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IBodegaRepository
{
    Task<IEnumerable<BodegaDto>> GetBodegasActivasAsync();
}
