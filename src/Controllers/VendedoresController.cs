using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;
namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedorService _service;

        public VendedoresController(IVendedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int numpag)
        {
            var result = await _service.ObtenerVendedor(numpag);
            return Ok(result);
        }
    }
}
