using AplMovilBexsolucionesApi.Repositories.Interfaces;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;

namespace AplMovilBexsolucionesApi.Services;

public class ProductoService : IProductoService
{

    private readonly IProductoRepository _repository;
    private readonly ILogger _logger;

    public ProductoService(IProductoRepository repository, ILogger<ProductoService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    async Task<IEnumerable<ProductoDto>> IProductoService.ObtenerProductos(int numpag)
    {
        if (numpag <= 0) { numpag = 1; }
        var data = await _repository.GetAllProducto(numpag);
        return data;
    }

}
