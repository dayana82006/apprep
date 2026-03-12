using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IProductoService
    {
        Task<IEnumerable<ProductoDto>> ObtenerProductos();
    }
}
