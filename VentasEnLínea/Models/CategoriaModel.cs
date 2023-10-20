using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VentasEnLíneaVista.Models
{
    public class CategoriaModel
    {
        private readonly string baseUrl = "https://localhost:44311"; // Reemplaza esto con la URL correcta de tu controlador

        public List<Categoria> listar()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método Buscar Categoria
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/Categoria").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        categorias = JsonConvert.DeserializeObject<List<Categoria>>(jsonResponse);
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

            return categorias;
        }

        public List<Categoria> buscarCategoria(string parametroBusqueda)
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/categoria/buscarCategoria?parametroBusqueda={parametroBusqueda}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        categorias = JsonConvert.DeserializeObject<List<Categoria>>(jsonResponse);
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

            return categorias;
        }

        public Categoria buscarCategoria(int id)
        {
            Categoria categoria = new Categoria();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/categoria/buscarCategoriaId?id={id}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        categoria = JsonConvert.DeserializeObject<Categoria>(jsonResponse);
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

            return categoria;
        }

        public bool modificarCategoria(Categoria categoria)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(categoria), Encoding.UTF8, "application/json");

                // Realizar una solicitud PUT a la API que recibe la solicitud
                HttpResponseMessage response = client.PutAsync("categoria/modificarCategoria", content).Result;

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

        public bool crearCategoria(Categoria categoria)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(categoria), Encoding.UTF8, "application/json");

                // Realizar una solicitud POST a la API que recibe la solicitud
                HttpResponseMessage response = client.PostAsync("categoria/crearCategoria", content).Result;

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
    }
}
