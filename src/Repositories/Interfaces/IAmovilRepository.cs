using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IAmovilRepository
{
    Task<List<AmovilDto>>GetAmovil();
    Task<List<string>> GetAmovilPipe();
}
