using AplMovilBexsolucionesApi.Models.DTOs;
namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IEstadoPedidoService
    {
        Task<IEnumerable<EstadoPedidoDto>> ObtenerEstadosPedidos();
    }
}
