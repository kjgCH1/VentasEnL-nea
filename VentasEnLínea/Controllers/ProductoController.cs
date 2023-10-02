using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult CrearProducto()
        {
            return View();
        }

        public IActionResult ModificarProducto()
        {
            return View();
        }

        public IActionResult BuscarProducto() {
            return View();
        }

        public IActionResult menu() { 
            return View(); 
        }
    }
}
