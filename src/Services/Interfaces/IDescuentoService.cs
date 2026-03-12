using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexSolucionesApi.Services.Interfaces
{
    public interface IDescuentoService
    {
     Task<IEnumerable<DescuentoDto>> ObtenerDescuentos();
    }
}
