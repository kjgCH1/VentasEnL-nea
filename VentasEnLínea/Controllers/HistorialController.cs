using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace VentasEnLíneaVista.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class HistorialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
