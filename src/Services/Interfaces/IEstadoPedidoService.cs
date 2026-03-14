using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services.Interfaces
{
    public interface IEstadoPedidoService
    {
        Task<IEnumerable<EstadoPedidoDto>> ObtenerEstadoPedido(int numpag);
        Task GuardarPedido(RecPedidoDto pedido);
    }
}