using Microsoft.AspNetCore.Mvc;

namespace APIInscripcionesChota.Controllers
{
    public class PostulanteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
