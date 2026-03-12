using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerCartera();
            return Ok(result);
        }
    }
}
