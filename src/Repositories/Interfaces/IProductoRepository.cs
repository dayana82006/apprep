using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IProductoRepository
{
    Task<List<ProductoDto>> GetAllProducto();
}
