using Microsoft.AspNetCore.Mvc;

namespace VentasEnLíneaVista.Controllers
{
    public class PendienteController : Controller
    {
        public IActionResult Notificacion()
        {
            return View();
        }
    }
}
