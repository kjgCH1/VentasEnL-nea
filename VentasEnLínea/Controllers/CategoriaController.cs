using Microsoft.AspNetCore.Mvc;
using Entidades;
using VentasEnLíneaVista.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace VentasEnLíneaVista.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CategoriaController : Controller
    {   

        public IActionResult CrearCategoria()
        {
            Categoria categoria = new Categoria();
            return View(categoria);
        }

        public IActionResult BuscarCategoria() {
            CategoriaModel model = new CategoriaModel();
            return View(model.listar());
        }

        [HttpPost]
        public IActionResult BuscarCategoria(string parametroBusqueda)
        {
            CategoriaModel model = new CategoriaModel();
            List<Categoria> categorias = model.buscarCategoria(parametroBusqueda);
            if (categorias.Count == 0)
            {
                ViewBag.Mensaje = "No se encontraron resultados para '" + parametroBusqueda + "'";
            }
            return View(categorias);
        }

        [HttpGet]
        public IActionResult ModificarCategoria(int id) {
            CategoriaModel model = new CategoriaModel();
            return View(model.buscarCategoria(id));
        }

        [HttpPost]
        public IActionResult ModificarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriaModel model = new CategoriaModel();

                if (model.modificarCategoria(categoria))
                {
                    ViewBag.Mensaje = "La categoria " + categoria.Nombre +
                    " ha sido modificada";
                    ModelState.Clear();
                    ViewBag.etiqueta = "alert alert-success";
                }
                else
                {
                    ViewBag.Mensaje = "Algo salio mal";
                    ViewBag.etiqueta = "alert alert-danger";
                }

            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult crearCategoria(Categoria categoria)
        {
            ViewBag.Mensaje = "Algo salio mal";
            ViewBag.etiqueta = "alert alert-danger";
            if (ModelState.IsValid)
            {
                CategoriaModel model = new CategoriaModel();

                if (model.crearCategoria(categoria))
                {
                    ViewBag.Mensaje = "La categoria " + categoria.Nombre +
                    " ha sido creada";
                    ModelState.Clear();
                    ViewBag.etiqueta = "alert alert-success";
                }
                else
                {
                    ViewBag.Mensaje = "Algo salio mal";
                    ViewBag.etiqueta = "alert alert-danger";
                }

            }
            categoria = new Categoria();
            return View(categoria);
        }


        [HttpPost]
        public string habilitarCategoria(int id, bool habilitado)
        {
            CategoriaModel model = new CategoriaModel();
            Categoria categoria = model.buscarCategoria(id);
            categoria.Habilitado = habilitado;
            string mensaje= "";
            if (model.modificarCategoria(categoria)) {
                mensaje = habilitado ? "Ahora está habilitada" : "Ya no está habilitada";
            }
            else 
            {
                mensaje = "Algo salio mal";
            }
            return JsonConvert.SerializeObject(mensaje);
            
        }
    }
}
