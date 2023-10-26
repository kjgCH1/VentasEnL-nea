using Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using VentasEnLíneaVista.Models;

namespace VentasEnLíneaVista.Controllers
{
    public class SaloneroController : Controller
    {
        public IActionResult CrearSalonero()
        {
            return View();
        }

        public IActionResult BuscarSalonero() {
            SaloneroModel model = new SaloneroModel();
            return View(model.listar());
        }

        [HttpPost]
        public IActionResult BuscarSalonero(string parametroBusqueda)
        {
            SaloneroModel model = new SaloneroModel();
            List<Salonero> saloneros = model.buscarSalonero(parametroBusqueda);
            if (saloneros.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron resultados para '" + parametroBusqueda + "'";
            }
            return View(saloneros);
        }

        [HttpGet]
        public IActionResult ModificarSalonero(int id)
        {   
            SaloneroModel salonero = new SaloneroModel();
            return View(salonero.buscarSalonero(id));
        }
        [HttpPost]
        public IActionResult ModificarSalonero(Salonero salonero)
        {
            if (ModelState.IsValid)
            {
                SaloneroModel model = new SaloneroModel();

                if (model.modificarSalonero(salonero))
                {
                    ViewBag.Mensaje = "La categoria " + salonero.Nombre +
                    " ha sido modificado";
                    ModelState.Clear();
                    ViewBag.etiqueta = "alert alert-success";
                }
                else
                {
                    ViewBag.Mensaje = "Algo salio mal";
                    ViewBag.etiqueta = "alert alert-danger";
                }

            }
            return View(salonero);
        }

        [HttpPost]
        public string habilitarSalonero(int id, bool habilitado)
        {
            SaloneroModel model = new SaloneroModel();
            Salonero salonero = model.buscarSalonero(id);
            salonero.Habilitado = habilitado;
            string mensaje = "";
            if (model.modificarSalonero(salonero))
            {
                mensaje = habilitado ? "Ahora está habilitado" : "Ya no está habilitado";
            }
            else
            {
                mensaje = "Algo salio mal";
            }
            return JsonConvert.SerializeObject(mensaje);

        }
        [HttpPost]
        public IActionResult crearSalonero(Salonero salonero)
        {
            if (ModelState.IsValid)
            {
                SaloneroModel model = new SaloneroModel();

                if (model.crearSalonero(salonero))
                {
                    ViewBag.Mensaje = "El salonero " + salonero.Nombre +
                    " ha sido creado";
                    ModelState.Clear();
                    ViewBag.etiqueta = "alert alert-success";
                }
                else
                {
                    ViewBag.Mensaje = "Algo salio mal";
                    ViewBag.etiqueta = "alert alert-danger";
                }

            }
            salonero = new Salonero();
            return View(salonero);
        }
    }

}
