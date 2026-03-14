using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IEstadoPedidoRepository
{
    Task<List<EstadoPedidoDto>> GetAllEstados(int numpag);
    Task<List<EstadoPedidoDto>> GuardarPedido(RecPedidoDto pedido);
}
