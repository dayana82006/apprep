using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuterosController : ControllerBase
    {
        private readonly IRuterosService _service;

        public RuterosController(IRuterosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerRuteros();
            return Ok(result);
        }
    }
}
