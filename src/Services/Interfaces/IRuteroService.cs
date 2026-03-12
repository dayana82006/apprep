using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IRuteroService
    {
        Task<IEnumerable<RuteroDto>> ObtenerRuteros();
    }
}
