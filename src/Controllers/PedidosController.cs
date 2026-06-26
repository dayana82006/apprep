using AplMovilBexsolucionesApi.Attributes;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("api/")]
    public class EstadosPedidosController : ControllerBase
    {
        private readonly IEstadoPedidoService _service;

        public EstadosPedidosController(IEstadoPedidoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Recibe un pedido (cabecera + lista de productos) y lo inserta en el ERP como salida de mercancía (documento tipo 11).
        /// </summary>
        /// <param name="pedido">Cabecera del pedido más la lista de líneas (producto, cantidad y precio).</param>
        /// <response code="200">Pedido insertado. Devuelve SalidaId y NoDocumento generados.</response>
        /// <response code="400">Datos del pedido inválidos (cliente o productos inexistentes, sin líneas, etc.).</response>
        /// <response code="401">apikey no encontrada o invalidada.</response>
        /// <response code="500">Error de servidor.</response>
        [HttpPost("Pedido")]
        [ProducesResponseType(typeof(RespuestaPedidoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RecibirPedido([FromBody] RecPedidoDto pedido)
        {
            try
            {
                var resultado = await _service.GuardarPedido(pedido);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
