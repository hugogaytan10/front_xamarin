using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parqueadero.Models;

namespace Parqueadero.Data
{
	public class ApiService
	{
		private readonly HttpClient httpClient;

		public ApiService()
		{
			httpClient = new HttpClient();
			// Puedes configurar aquí la URL base del API
			 httpClient.BaseAddress = new Uri("http://192.168.0.6:45455/");
		}

		public async Task<List<Vehiculo>> ObtenerVehiculos()
		{
			var response = await httpClient.GetAsync("api/vehiculos");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<List<Vehiculo>>(content);
			}
			return null;
		}

		// Puedes agregar más métodos para realizar otras operaciones como agregar, actualizar, eliminar, etc.
	}
}
