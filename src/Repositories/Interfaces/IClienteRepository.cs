using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IClienteRepository
{
    Task<List<ClienteDto>> GetAllClientes(int numpag);
}
