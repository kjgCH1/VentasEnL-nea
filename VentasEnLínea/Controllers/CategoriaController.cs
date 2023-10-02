using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult CrearCategoria()
        {
            return View();
        }

        public IActionResult BuscarCategoria() {
            return View();
        }

        public IActionResult ModificarCategoria() {
            return View();
        }
    }
}
