using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IBodegaService
    {
        Task<IEnumerable<BodegaDto>> GetBodegasActivasAsync();
    }
}
