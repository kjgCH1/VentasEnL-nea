using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace VentasEnLíneaVista.Controllers
{
    public class PendienteController : Controller
    {
        [Authorize(Roles = "Salonero")]
        public IActionResult Notificacion()
        {
            return View();
        }
    }
}
