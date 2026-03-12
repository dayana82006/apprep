using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosPedidosController : ControllerBase
    {
        private readonly IEstadoPedidoService _service;

        public EstadosPedidosController(IEstadoPedidoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.ObtenerEstadoPedido();
            return Ok(result);
        }
    }
}
