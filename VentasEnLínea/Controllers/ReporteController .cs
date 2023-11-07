using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VentasEnLíneaVista.Models;

namespace VentasEnLíneaVista.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ReporteController : Controller
    {

        public IActionResult BuscarReporte()
        {
            ReporteModel model = new ReporteModel();
            return View(model.listar());
        }//BuscarReportee

        [HttpPost]
        public IActionResult BuscarReporte(string parametroBusqueda1, string parametroBusqueda2)
        {
            ReporteModel model = new ReporteModel();
            List<Reporte> clientes = model.buscarReporte(parametroBusqueda1, parametroBusqueda2);
            if (clientes.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron resultados para '" + parametroBusqueda1 + " al " + parametroBusqueda2 + "'";
            }
            return View(clientes);
        }//BuscarCliente

    }//fin clase

}
