using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosPedidosController : ControllerBase
    {
        private readonly IEstadosPedidosService _service;

        public EstadosPedidosController(IEstadosPedidosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerEstadosPedidos();
            return Ok(result);
        }
    }
}
