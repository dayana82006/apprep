using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IVendedoreService
    {
        Task<IEnumerable<VendedorDto>> ObtenerVendedores();
    }
}
