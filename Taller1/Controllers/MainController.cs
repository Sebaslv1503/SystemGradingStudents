using Microsoft.AspNetCore.Mvc;

namespace Taller1.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inscripcion()
        {
            return View();
        }
        public IActionResult GalardonPremios()
        {
            return View();
        }
    }
}
