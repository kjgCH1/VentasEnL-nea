using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VentasEnLíneaVista.Models;
using Entidades;

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
            ComunidadModel model = new ComunidadModel();
            List<Comunidad> comunidades = model.listar();
            return View(comunidades); 
        }

        [HttpPost]
        public IActionResult BuscarComunidad(string parametroBusqueda)
        {
            ComunidadModel model = new ComunidadModel();
            List<Comunidad> comunidades = model.buscarComunidad(parametroBusqueda);
            return View(comunidades);
        }

        [HttpPost]
        public IActionResult ModificarComunidad(int id) 
        {   
            return View(id);
        }
    }

}
