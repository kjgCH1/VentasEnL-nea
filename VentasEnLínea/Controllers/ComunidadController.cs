using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VentasEnLíneaVista.Models;
using Entidades;
using System.Runtime.InteropServices;
using System.Globalization;

namespace VentasEnLíneaVista.Controllers
{
    public class ComunidadController : Controller
    {
        public IActionResult CrearComunidad()
        {
            Comunidad comunidad = new Comunidad();
            return View(comunidad);
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
            if (comunidades.Count==0) {
                ViewBag.Mensaje = "No se encontraron resultados para '"+parametroBusqueda+"'";
            }
            return View(comunidades);
        }

        [HttpGet]
        public IActionResult ModificarComunidad(int id) 
        {   
            ComunidadModel model = new ComunidadModel();
           
            return View(model.buscarComunidadId(id));
        }

        [HttpPost]
        public IActionResult CrearComunidad(Comunidad comunidad) {
            if (ModelState.IsValid) {
                ComunidadModel model = new ComunidadModel();
              
                if (model.crearComunidad(comunidad))
                {
                    ViewBag.Mensaje = "La Comunidad " + comunidad.Nombre +
                    " ha sido agregada con el Precio ₡" + comunidad.Precio;
                    ModelState.Clear();
                    ViewBag.etiqueta = "alert alert-success"; 
                }
                else {
                    ViewBag.Mensaje = "Algo salio mal";
                    ViewBag.etiqueta = "alert alert-danger";
                }
                
            }

            comunidad = new Comunidad();
            return View(comunidad);
        }

        [HttpPost]
        public IActionResult ModificarComunidad(Comunidad comunidad) {
            if (ModelState.IsValid)
            {
                ComunidadModel model = new ComunidadModel();

                if (model.modificarComunidad(comunidad))
                {
                    ViewBag.Mensaje = "La Comunidad " + comunidad.Nombre +
                    " ha sido modificada con el Precio ₡" + comunidad.Precio;
                    ModelState.Clear();
                    ViewBag.etiqueta = "alert alert-success";
                }
                else
                {
                    ViewBag.Mensaje = "Algo salio mal";
                    ViewBag.etiqueta = "alert alert-danger";
                }

            }
            
            return View(comunidad);
        }

    }

}
