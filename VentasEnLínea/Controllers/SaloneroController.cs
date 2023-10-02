using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class SaloneroController : Controller
    {
        public IActionResult CrearSalonero()
        {
            return View();
        }

        public IActionResult BuscarSalonero() {
            return View();
        }
    }

}
