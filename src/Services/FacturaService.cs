using System.Collections.Generic;
using System.Threading.Tasks;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _repository;

        public FacturaService(IFacturaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FacturasDto>> GetFacturas(int numpag)
        {
    
            return await _repository.GetAll(numpag);
        }
    }
}