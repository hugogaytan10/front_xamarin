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
			//httpClient = new HttpClient();
			// Puedes configurar aquí la URL base del API
			// httpClient.BaseAddress = new Uri("http://192.168.0.6:45455/");
		}

		public async Task<IEnumerable<Vehiculo>> ObtenerVehiculos()
		{
			string apiUrl = "http://192.168.0.6:45455/api/Vehiculos";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						string content = await response.Content.ReadAsStringAsync();
						Console.WriteLine(content);

						return JsonConvert.DeserializeObject<IEnumerable<Vehiculo>>(content);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al obtener vehículos: {ex.Message}");
			}

			return null;
		}

		public async Task<int> AgregarVehiculo(Vehiculo nuevoVehiculo)
		{
			string apiUrl = "http://192.168.0.6:45455/api/Vehiculos";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					string json = JsonConvert.SerializeObject(nuevoVehiculo);
					HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PostAsync(apiUrl, content);

					if (response.IsSuccessStatusCode)
					{
						string result = await response.Content.ReadAsStringAsync();
						return int.Parse(result);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al agregar vehículo: {ex.Message}");
			}

			return 0;
		}

		public async Task<int> ActualizarVehiculo(string placa, Vehiculo vehiculoActualizado)
		{
			string apiUrl = $"http://192.168.0.6:45455/api/Vehiculos/{placa}";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					string json = JsonConvert.SerializeObject(vehiculoActualizado);
					HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

					HttpResponseMessage response = await client.PutAsync(apiUrl, content);

					if (response.IsSuccessStatusCode)
					{
						string result = await response.Content.ReadAsStringAsync();
						return int.Parse(result);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al actualizar vehículo: {ex.Message}");
			}

			return 0;
		}

		public async Task<int> EliminarVehiculo(string placa)
		{
			string apiUrl = $"http://192.168.0.6:45455/api/Vehiculos/{placa}";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.DeleteAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						string result = await response.Content.ReadAsStringAsync();
						return int.Parse(result);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al eliminar vehículo: {ex.Message}");
			}

			return 0;
		}

	}
}
