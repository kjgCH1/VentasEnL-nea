using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class DireccionController : Controller
    {
        public IActionResult CrearDireccion()
        {
            return View();
        }

        public IActionResult BuscarDireccion() { 
            return View();
        }
    }
}
