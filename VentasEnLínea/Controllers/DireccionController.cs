using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace VentasEnLíneaVista.Controllers
{
    [Authorize(Roles = "Cliente")]
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
