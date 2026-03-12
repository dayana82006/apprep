using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IAmovilService
    {
        Task<IEnumerable<AmovilDto>> GetAmovil();
    }
}
 