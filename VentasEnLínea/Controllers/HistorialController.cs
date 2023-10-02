using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class HistorialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
