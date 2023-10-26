using Entidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace VentasEnLíneaVista.Models
{
    public class SaloneroModel
    {
        private readonly string baseUrl = "https://localhost:44311"; // Reemplaza esto con la URL correcta de tu controlador
        public List<Salonero> listar()
        {
            List<Salonero> saloneros = new List<Salonero>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/salonero").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        saloneros = JsonConvert.DeserializeObject<List<Salonero>>(jsonResponse);
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

            return saloneros;
        }

        public List<Salonero> buscarSalonero(string parametroBusqueda)
        {
            List<Salonero> saloneros = new List<Salonero>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/salonero/buscarSalonero?parametroBusqueda={parametroBusqueda}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        saloneros = JsonConvert.DeserializeObject<List<Salonero>>(jsonResponse);
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

            return saloneros;
        }

        public Salonero buscarSalonero(int id)
        {
            Salonero salonero = new Salonero();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/salonero/buscarSaloneroId?id={id}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        salonero = JsonConvert.DeserializeObject<Salonero>(jsonResponse);
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

            return salonero;
        }

        public bool modificarSalonero(Salonero salonero)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(salonero), Encoding.UTF8, "application/json");

                // Realizar una solicitud PUT a la API que recibe la solicitud
                HttpResponseMessage response = client.PutAsync("salonero/modificarSalonero", content).Result;

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

        public bool crearSalonero(Salonero salonero)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Convertir el objeto Comunidad a JSON
                var content = new StringContent(JsonConvert.SerializeObject(salonero), Encoding.UTF8, "application/json");

                // Realizar una solicitud POST a la API que recibe la solicitud
                HttpResponseMessage response = client.PostAsync("salonero/crearSalonero", content).Result;

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
