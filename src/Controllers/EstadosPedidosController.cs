using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Services;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AplMovilBexsolucionesApi.Controllers
{
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
        /// Consulta de la lista de items disponibles para Estados de Pedidos.
        /// </summary>
        /// <param name="numpag">Numero entero correspondiente a la pagina a consultar.  MAXIMO 500 items por pagina.</param>
        /// <response code="200">Retorna un listado de items</response>
        /// <response code="401">apikey no encontrada o invalidada.</response>
        /// <response code="500">Error de servidor</response>
        /// <response code="501">Metodo no implementado</response>
        /// <returns> Un IActionResult que contiene la lista paginada de elementos de Estados de Pedidos para la página especificada. MAXIMO 500 items por pagina.</returns>
        [HttpGet("EstadoPedido")]
        [ProducesResponseType(typeof(IEnumerable<EstadoPedidoDto>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [ProducesResponseType(501)]
        public async Task<IActionResult> Get(int numpag)
        {

            return StatusCode((int)HttpStatusCode.NotImplemented);
            var result = await _service.ObtenerEstadoPedido(numpag);
            return Ok(result);
        }
        /// <summary>
        /// Envía un pedido al sistema para su procesamiento. 
        /// </summary>
        ///  /// <response code="200">Retorna un listado de items</response>
        /// <response code="400">Sintaxis No válida.</response>
        /// <response code="500">Error de servidor</response>
        [HttpPost("Pedido")]
        public async Task<IActionResult> RecibirPedido([FromBody] RecPedidoDto pedido)
        {
            await _service.GuardarPedido(pedido);

            return Ok();
        }
    }
}
