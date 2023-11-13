using Newtonsoft.Json;
using Parqueadero.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Parqueadero.Data
{
	public class ApiServicePuestos
	{
		public async Task<List<Puesto>> ObtenerPuestos()
		{
			string apiUrl = "http://192.168.0.6:45455/api/Puestos";

			try
			{
				using (HttpClient client = new HttpClient())
				{
					HttpResponseMessage response = await client.GetAsync(apiUrl);

					if (response.IsSuccessStatusCode)
					{
						string content = await response.Content.ReadAsStringAsync();
						Console.WriteLine(content);

						return JsonConvert.DeserializeObject<List<Puesto>>(content);
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
