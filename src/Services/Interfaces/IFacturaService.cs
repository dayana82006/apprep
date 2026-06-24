using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<IEnumerable<FacturasDto>> GetFacturas(int numpag);
    }
}
