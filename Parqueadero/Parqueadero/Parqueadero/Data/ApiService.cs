using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parqueadero.Models;
using Xamarin.Essentials;

namespace Parqueadero.Data
{
	public class ApiService
	{
		private readonly HttpClient httpClient;

		public ApiService()
		{
			httpClient = new HttpClient();
			// Puedes configurar aquí la URL base del API
			 httpClient.BaseAddress = new Uri("http://192.168.8.15:5150/");
		}

		public async Task<List<Vehiculo>> ObtenerVehiculos()
		{
            /*var response = await httpClient.GetAsync("api/vehiculos");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Vehiculo>>(content);
			}
			*/
            string apiUrl = "http://192.168.8.15:45455/api/Vehiculos";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(content);

                        return JsonConvert.DeserializeObject<List<Vehiculo>>(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener vehículos: {ex.Message}");
            }

            return null;
        }

		// Puedes agregar más métodos para realizar otras operaciones como agregar, actualizar, eliminar, etc.
	}
}
