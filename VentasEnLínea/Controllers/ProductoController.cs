using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using VentasEnLíneaVista.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace VentasEnLíneaVista.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProductoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult CrearProducto()
        {
            Producto producto = new Producto();
            CategoriaModel categoriaModel = new CategoriaModel();
            List<Categoria> categorias = categoriaModel.listar();
            ProductoVistaModel productoVistaModel = new ProductoVistaModel();
            productoVistaModel.Producto = producto;
            productoVistaModel.Categorias = categorias;
            
            return View(productoVistaModel);
        }
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult CrearProducto(Producto producto, IFormFile imagen) {
            // Crear el directorio si no existe
            if (imagen != null && imagen.Length > 0)
            {
                var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "imagen/Productos");

                // Crear el directorio si no existe
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Obtener la extensión del archivo original
                var extension = Path.GetExtension(imagen.FileName);

                // Utilizar el ID del producto como nombre de archivo
                var nombreArchivo = producto.Nombre;

                // Ruta completa del archivo con el nombre del ID del producto y la extensión original
                var filePath = Path.Combine(uploadsFolder, nombreArchivo + extension);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }

                // Guardar la ruta de la imagen en el objeto Producto
                producto.Imagen = "imagen/Productos/" + nombreArchivo + extension;
                if (ModelState.IsValid)
                {
                    ProductoModel model = new ProductoModel();
                    producto.Habilitado = true;
                    if (model.crearProducto(producto))
                    {
                        ViewBag.Mensaje = "El producto " + producto.Nombre +
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
               
            }
            CategoriaModel categoriaModel = new CategoriaModel();
            List<Categoria> categorias = categoriaModel.listar();
            ProductoVistaModel productoVistaModel = new ProductoVistaModel();
            productoVistaModel.Producto = producto;
            productoVistaModel.Categorias = categorias;
            producto = new Producto();
            return View(productoVistaModel);
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult ModificarProducto()
        {
            return View();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult BuscarProducto() {
            return View();
        }
        [Authorize(Roles = "Cliente")]
        public IActionResult menu() {
            ProductoModel model = new ProductoModel();
            CategoriaModel categoriaModel = new CategoriaModel();
           
            MenuVistaModel menu = new MenuVistaModel();
            menu.Categorias = categoriaModel.listar();
            menu.Productos = model.listarProductos();
            return View(menu); 
        }
        [Authorize(Roles = "Cliente")]
        [HttpPost]
        public IActionResult menu(int categoria)
        {
            ProductoModel model = new ProductoModel();
            CategoriaModel categoriaModel = new CategoriaModel();

            MenuVistaModel menu = new MenuVistaModel();
            menu.Categorias = categoriaModel.listar();
            menu.Productos = model.buscarProductoCategoria(categoria);
            return View(menu);
        }
    }
}
