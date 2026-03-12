using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IBancoRepository
{
    Task<List<BancoDto>> GetBanco();
}
