using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmovilController : ControllerBase
    {
        private readonly IAmovilService _service;

        public AmovilController(IAmovilService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerAmovil();
            return Ok(result);
        }
    }
}
