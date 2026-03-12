using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarteraController : ControllerBase
    {
        private readonly ICarteraService _service;

        public CarteraController(ICarteraService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int numpag)
        {
            var result = await _service.ObtenerCartera(numpag);
            return Ok(result);
        }
    }
}
