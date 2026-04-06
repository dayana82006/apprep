using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedoresController : ControllerBase
    {
        private readonly IVendedorService _service;

        public VendedoresController(IVendedorService service)
        {
            _service = service;
        }

        /// <summary>
        /// Consulta de la lista de items disponibles para Vendedores.
        /// </summary>
        /// <param name="numpag">Numero entero correspondiente a la pagina a consultar.  MAXIMO 500 items por pagina.</param>
        /// <response code="200">Retorna un listado de items</response>
        /// <response code="401">apikey no encontrada o invalidada.</response>
        /// <response code="500">Error de servidor</response>
        /// <response code="501">Metodo no implementado</response>
        /// <returns> Un IActionResult que contiene la lista paginada de elementos de Vendedores para la página especificada. MAXIMO 500 items por pagina.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VendedorDto>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [ProducesResponseType(501)]
        public async Task<IActionResult> Get(int numpag)
        {
            var result = await _service.ObtenerVendedor(numpag);
            return Ok(result);
        }
    }
}
