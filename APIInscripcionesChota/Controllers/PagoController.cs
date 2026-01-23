using Microsoft.AspNetCore.Mvc;

namespace APIInscripcionesChota.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Listado de pagos");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok($"Pago {id}");
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok("Pago creado");
        }
    }
}
