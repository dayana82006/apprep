using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancosController : ControllerBase
    {
        private readonly IBancoService _service;

        public BancosController(IBancoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerBancos();
            return Ok(result);
        }
    }
}
