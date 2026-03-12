using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreciosController : ControllerBase
    {
        private readonly IPrecioService _service;

        public PreciosController(IPrecioService service)
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
