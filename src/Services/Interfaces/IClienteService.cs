using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> ObtenerClientes(int numpag);
    }
}
