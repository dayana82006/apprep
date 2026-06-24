using System.Collections.Generic;
using System.Threading.Tasks;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Repositories.Interfaces
{
    public interface IFacturaRepository
    {
        Task<List<FacturasDto>> GetAll(int numpag);

        
    }
} 