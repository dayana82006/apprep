using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuterosController : ControllerBase
    {
        private readonly IRuteroService _service;

        public RuterosController(IRuteroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int numpag)
        {
            var result = await _service.ObtenerRuteros(numpag);
            return Ok(result);
        }
    }
}
