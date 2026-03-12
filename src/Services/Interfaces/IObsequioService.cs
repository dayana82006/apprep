using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces { 
    public interface IObsequioService
    {
        Task<IEnumerable<ObsequioDto>> ObtenerObsequios(int numpag);
    }
}
