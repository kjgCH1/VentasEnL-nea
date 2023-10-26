using Entidades;
using System.Collections.Generic;

namespace VentasEnLíneaVista.Models
{
    public class ProductoVistaModel
    {
            public Producto Producto { get; set; }
            public List<Categoria> Categorias { get; set; }
    }
}
