using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces;

public interface IObsequioRepository
{
    Task<List<ObsequioDto>> GetAllObsequio();
}