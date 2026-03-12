using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IBancoService
    {
        Task<IEnumerable<BancoDto>> ObtenerBancos();
    }
}
