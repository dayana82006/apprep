using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IDescuentoService
    {
     Task<IEnumerable<DescuentoDto>> ObtenerDescuentos();
    }
}
