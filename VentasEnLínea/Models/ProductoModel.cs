using Entidades;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System;
using System.Collections.Generic;

namespace VentasEnLíneaVista.Models
{
    public class ProductoModel
    {
        private readonly string baseUrl = "https://localhost:44311"; // Reemplaza esto con la URL correcta de tu controlador
        public bool crearProducto(Producto producto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");

                // Realizar una solicitud POST a la API que recibe la solicitud
                HttpResponseMessage response = client.PostAsync("producto/crearProducto", content).Result;

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    // La solicitud fue exitosa, puedes realizar acciones adicionales aquí
                    Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
                    string jsonResponse = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(jsonResponse);
                }
                else
                {
                    // Manejar el caso en el que la solicitud no fue exitosa
                    Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
                    return false;
                }
            }
        }

        public List<Producto> buscarProductoCategoria(int categoria)
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/producto/buscarProductoCategoria?categoria={categoria}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        productos = JsonConvert.DeserializeObject<List<Producto>>(jsonResponse);
                    }
                    else
                    {
                        // Manejar el caso en el que la solicitud no fue exitosa
                        Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la solicitud HTTP
                Console.WriteLine($"Error: {ex.Message}");
            }

            return productos;
        }

        public List<Producto> listarProductos()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/producto").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        productos = JsonConvert.DeserializeObject<List<Producto>>(jsonResponse);
                    }
                    else
                    {
                        // Manejar el caso en el que la solicitud no fue exitosa
                        Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la solicitud HTTP
                Console.WriteLine($"Error: {ex.Message}");
            }

            return productos;
        }
    }
}
