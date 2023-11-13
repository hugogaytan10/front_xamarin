using Parqueadero.Data;
using Parqueadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parqueadero.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MisVehiculos : ContentPage
	{
		private readonly ApiService apiService;

		public MisVehiculos()
		{
			InitializeComponent();
			apiService = new ApiService();
			MostrarTodo();
		}

		public async void MostrarTodo()
		{
			var vehiculos = await apiService.ObtenerVehiculos();
			listView.ItemsSource = vehiculos;
		}

		public async void Search1_TextChanged(object sender, TextChangedEventArgs e)
		{
			var vehiculos = await apiService.ObtenerVehiculos();
			var searchResult = vehiculos.Where(c => c.Modelo.Contains(search1.Text));
			listView.ItemsSource = searchResult;
		}

		private async void SwipeItem_Clicked(object sender, EventArgs e)
		{
			var item = sender as SwipeItem;
			var veh = item.CommandParameter as Vehiculo;
			var result = await DisplayAlert("Aviso", $"¿Seguro que desea borrar el vehículo {veh.Modelo}?", "Si", "No");
			if (result)
			{
				// Aquí deberías llamar al método del servicio para eliminar el vehículo en el API
				// await apiService.EliminarVehiculo(veh.Id);

				// Luego, vuelves a obtener la lista actualizada de vehículos
				MostrarTodo();
			}
		}

		private async void SwipeItem_Clicked1(object sender, EventArgs e)
		{
			var item = sender as SwipeItem;
			var veh = item.CommandParameter as Vehiculo;
			await Navigation.PushAsync(new Editar(veh));
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RegistrarVehiculo());
		}
	}
}
