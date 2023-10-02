using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class ReporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
