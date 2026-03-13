using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class DescuentoService : IDescuentoService
{

    private readonly IDescuentoRepository _repository;
    private readonly ILogger<DescuentoService> _logger;

    public DescuentoService(IDescuentoRepository repository, ILogger<DescuentoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<DescuentoDto>> ObtenerDescuentos(int numpag)
    {
        if (numpag <= 0) { numpag = 1; }
        var data = await _repository.GetAllDescuento(numpag);
        return data;
    }

}
