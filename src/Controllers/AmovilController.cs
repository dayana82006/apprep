using Microsoft.AspNetCore.Mvc;
using AplMovilBexsolucionesApi.Services.Interfaces;

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
        public async Task<IActionResult> Get(int numpag)
        {
            var result = await _service.GetAmovil(numpag);
            return Ok(result);
        }
    }
}
