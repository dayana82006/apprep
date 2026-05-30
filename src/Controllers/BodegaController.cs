using AplMovilBexsolucionesApi.Attributes;
using AplMovilBexsolucionesApi.Models.DTOs;
using AplMovilBexsolucionesApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AplMovilBexsolucionesApi.Controllers
{
    [ApiKey]
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : ControllerBase
    {
        private readonly IBodegaService _service;

        public BodegaController(IBodegaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Consulta de bodegas activas.
        /// </summary>
        /// <response code="200">Listado de bodegas activas.</response>
        /// <response code="401">ApiKey inválida.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BodegaDto>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetBodegasActivasAsync();

            return Ok(result);
        }
    }
}