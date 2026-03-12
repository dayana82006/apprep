using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreciosController : ControllerBase
    {
        private readonly IPreciosService _service;

        public PreciosController(IPreciosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerPrecios();
            return Ok(result);
        }
    }
}
