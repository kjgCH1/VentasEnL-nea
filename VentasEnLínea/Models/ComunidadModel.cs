using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
    }
}
