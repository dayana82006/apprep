using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface ICarteraService
    {
        Task<IEnumerable<CarteraDto>> ObtenerCartera();
    }
}
