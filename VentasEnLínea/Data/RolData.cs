using Dominio;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace VentasEnLíneaVista.Data
{
    public class RolData
    {
        private readonly string baseUrl = "https://localhost:7150";
        public Rol busacarRolId(int id)
        {
            Rol rol = new Rol();


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarComunidad
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/rol/buscarRolId?id={id}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Comunidad
                        rol = JsonConvert.DeserializeObject<Rol>(jsonResponse);
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

            return rol;
        }
    }
}
