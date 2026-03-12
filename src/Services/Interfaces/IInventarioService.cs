using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IInventarioService
    {
        Task<IEnumerable<InventarioDto>> ObtenerInventario();
    }
}
