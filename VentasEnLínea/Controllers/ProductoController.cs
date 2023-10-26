using Entidades;
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
                var nombreArchivo = 1.ToString();

                // Ruta completa del archivo con el nombre del ID del producto y la extensión original
                var filePath = Path.Combine(uploadsFolder, nombreArchivo + extension);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imagen.CopyTo(fileStream);
                }

                // Guardar la ruta de la imagen en el objeto Producto
                producto.Imagen = "imagen/Productos/" + nombreArchivo + extension;
                ViewBag.Mensaje = producto.Imagen;
            }
            CategoriaModel categoriaModel = new CategoriaModel();
            List<Categoria> categorias = categoriaModel.listar();
            ProductoVistaModel productoVistaModel = new ProductoVistaModel();
            productoVistaModel.Producto = producto;
            productoVistaModel.Categorias = categorias;
            ViewBag.Producto = "Nombre: " + producto.Nombre
                + ", Imagen :" + producto.Imagen
                + ", Descripción: " + producto.Descripcion
                +", Categoria: "+ producto.Categoria
                +",Precio: " + producto.Precio
                +",Habilitado: " + producto.Habilitado
                +",Id: " + producto.Id;
            return View(productoVistaModel);
        }

        public IActionResult ModificarProducto()
        {
            return View();
        }

        public IActionResult BuscarProducto() {
            return View();
        }

        public IActionResult menu() { 
            return View(); 
        }
    }
}
