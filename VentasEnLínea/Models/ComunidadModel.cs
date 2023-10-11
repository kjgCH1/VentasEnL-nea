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
    public class ComunidadModel
    {
        private readonly string baseUrl = "https://localhost:44311"; // Reemplaza esto con la URL correcta de tu controlador

        
        public List<Comunidad> listar()


        {
            List<Comunidad> comunidades = new List<Comunidad>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/Comunidad").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        comunidades = JsonConvert.DeserializeObject<List<Comunidad>>(jsonResponse);
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

            return comunidades;
        }

        public List<Comunidad> buscarComunidad(string parametroBusqueda)


        {
            List<Comunidad> comunidades = new List<Comunidad>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/comunidad/buscarComunidad?parametroBusqueda={parametroBusqueda}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        comunidades = JsonConvert.DeserializeObject<List<Comunidad>>(jsonResponse);
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

            return comunidades;
        }

        public Comunidad buscarComunidadId(int id)
        {
            Comunidad comunidad = new Comunidad();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/comunidad/buscarComunidadId?id={id}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        comunidad = JsonConvert.DeserializeObject<Comunidad>(jsonResponse);
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

            return comunidad;
        }

        public bool crearComunidad(Comunidad comunidad)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(comunidad), Encoding.UTF8, "application/json");

                // Realizar una solicitud POST a la API que recibe la solicitud
                HttpResponseMessage response = client.PostAsync("comunidad/crearComunidad", content).Result;

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

        public bool modificarComunidad(Comunidad comunidad) {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(comunidad), Encoding.UTF8, "application/json");

                // Realizar una solicitud PUT a la API que recibe la solicitud
                HttpResponseMessage response = client.PutAsync("comunidad/modificarComunidad", content).Result;

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
