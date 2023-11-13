using Newtonsoft.Json;
using Parqueadero.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Data
{
    public class ApiServiceHistorial
    {


        public async Task<List<Historial>> ObtenerReservas()
        {
            string apiUrl = "http://192.168.8.15:45455/api/Historial";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);

                        return JsonConvert.DeserializeObject<List<Historial>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener vehículos: {ex.Message}");
            }

            return null;
        }
    }

}
