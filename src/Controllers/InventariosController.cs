using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventariosController : ControllerBase
    {
        private readonly IInventarioService _service;

        public InventariosController(IInventarioService service)
        {
            _service = service;
        }



        /// <summary>
        /// Consulta de la lista de items disponibles para Inventario.
        /// </summary>
        /// <param name="numpag">Numero entero correspondiente a la pagina a consultar.  MAXIMO 20 items por pagina.</param>
        /// <response code="200">Retorna un listado de items</response>
        /// <response code="401">apikey no encontrada o invalidada.</response>
        /// <response code="500">Error de servidor</response>
        /// <response code="501">Metodo no implementado</response>
        /// <returns> Un IActionResult que contiene la lista paginada de elementos de Inventario para la página especificada. MAXIMO 20 items por pagina.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InventarioDto>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [ProducesResponseType(501)]
        public async Task<IActionResult> Get(int numpag)
        {
            var result = await _service.ObtenerInventario(numpag);
            return Ok(result);
        }
    }
}
