using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IVendedorService
    {
        Task<IEnumerable<VendedorDto>> ObtenerVendedor(int numpag);
    }
}
