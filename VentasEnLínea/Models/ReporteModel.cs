using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace VentasEnLíneaVista.Models
{
    public class ReporteModel
    {
        private readonly string baseUrl = "https://localhost:44311"; //44311 / 44308 Reemplaza esto con la URL correcta de tu controlador
        public List<Reporte> listar()
        {
            List<Reporte> reportes = new List<Reporte>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método Buscar Cliente
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/reporte").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Cliente
                        reportes = JsonConvert.DeserializeObject<List<Reporte>>(jsonResponse);
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

            return reportes;
        }//listar

        public List<Reporte> buscarReporte(string parametroBusqueda1, string parametroBusqueda2)
        {
            List<Reporte> reportes = new List<Reporte>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Hacer la solicitud GET al método BuscarCliente
                    HttpResponseMessage response = client.GetAsync($"{baseUrl}/reporte/buscarReporte?parametroBusqueda1={parametroBusqueda1}&parametroBusqueda2={parametroBusqueda2}").Result;

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        // Leer el contenido de la respuesta como una cadena JSON
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Deserializar la cadena JSON en una lista de Cliente
                        reportes = JsonConvert.DeserializeObject<List<Reporte>>(jsonResponse);
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

            return reportes;
        }//buscarClienteNombre

        //public Reporte buscarReporte()
        //{
        //    Reporte reporte = new Reporte();

        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            // Hacer la solicitud GET al método BuscarCliente
        //            HttpResponseMessage response = client.GetAsync($"{baseUrl}/reporte/buscarReporte").Result;

        //            // Verificar si la solicitud fue exitosa
        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Leer el contenido de la respuesta como una cadena JSON
        //                string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //                // Deserializar la cadena JSON en una lista de Comunidad
        //                reporte = JsonConvert.DeserializeObject<Reporte>(jsonResponse);
        //            }
        //            else
        //            {
        //                // Manejar el caso en el que la solicitud no fue exitosa
        //                Console.WriteLine($"Error en la solicitud HTTP: {response.StatusCode}");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar cualquier excepción que pueda ocurrir durante la solicitud HTTP
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }

        //    return reporte;
        //}//buscarReporte



    }//fin clase
}
