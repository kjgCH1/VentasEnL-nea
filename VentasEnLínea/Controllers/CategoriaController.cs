using Microsoft.AspNetCore.Mvc;
using Entidades;
using VentasEnLíneaVista.Models;
using System.Collections.Generic;

namespace VentasEnLíneaVista.Controllers
{
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
    }
}
