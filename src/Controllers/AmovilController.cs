using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;
using AplMovilBexsolucionesApi.Models.DTOs;
using System.Net;

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


        /// <summary>
        /// Consulta de la lista de items disponibles para Amovil.
        /// </summary>
        /// <param name="numpag">Numero entero correspondiente a la pagina a consultar.  MAXIMO 20 items por pagina.</param>
        /// <response code="200">Retorna un listado de items</response>
        /// <response code="401">apikey no encontrada o invalidada.</response>
        /// <response code="500">Error de servidor</response>
        /// <response code="501">Metodo no implementado</response>
        /// <returns> Un IActionResult que contiene la lista paginada de elementos de Amovil para la página especificada. MAXIMO 20 items por pagina.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AmovilDto>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [ProducesResponseType(501)]
        public async Task<IActionResult> Get(int numpag)
        {
            return StatusCode((int)HttpStatusCode.NotImplemented);

            var result = await _service.GetAmovil(numpag);
            return Ok(result);
        }
    }
}
