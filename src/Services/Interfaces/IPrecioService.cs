using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IPrecioService
    {
        Task<IEnumerable<PrecioDto>> ObtenerPrecios(int numpag);
    }
}
