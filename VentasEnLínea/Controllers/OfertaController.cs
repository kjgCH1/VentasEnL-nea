using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class OfertaController : Controller
    {
        public IActionResult CrearOferta()
        {
            return View();
        }

        public IActionResult BuscarOferta() {
            return View();
        }

        public IActionResult ModificarOferta() {  
            return View();
            
        }
    }
}
