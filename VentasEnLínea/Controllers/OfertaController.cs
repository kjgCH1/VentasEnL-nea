using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace VentasEnLíneaVista.Controllers
{
    public class OfertaController : Controller
    {
        [Authorize(Roles = "Administrador")]
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
