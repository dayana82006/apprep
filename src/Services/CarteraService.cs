using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class CarteraService : ICarteraService
{

    private readonly ICarteraRepository _repository;
    private readonly ILogger _logger;

    public CarteraService(ICarteraRepository repository, ILogger<CarteraService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public async Task<IEnumerable<CarteraDto>> ObtenerCartera(int numpag)
    {
        if (numpag <= 0){numpag = 1;};
        var data = await _repository.GetAllCartera(numpag);
        return data;
    }
}
