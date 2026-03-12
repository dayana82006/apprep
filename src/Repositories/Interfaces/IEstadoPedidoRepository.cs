using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IEstadoPedidoRepository
{
    Task<List<EstadoPedidoDto>> GetAll(int numpag);
}
