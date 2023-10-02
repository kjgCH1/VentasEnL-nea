using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class ComunidadController : Controller
    {
        public IActionResult CrearComunidad()
        {
            return View();
        }

        public IActionResult BuscarComunidad() 
        { 
            return View(); 
        }

        public IActionResult ModificarComunidad() 
        {
            return View();
        }
    }

}
