using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IPedidoRepository
{
    Task<RespuestaPedidoDto> GuardarPedido(RecPedidoDto pedido);
}
