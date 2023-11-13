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
	public partial class RegistrarVehiculo : ContentPage
	{
		private readonly ApiService apiService;
		public RegistrarVehiculo()
		{
			InitializeComponent();
			apiService = new ApiService();

		}
		private async void Insertar(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(txtPlaca.Text) && !string.IsNullOrWhiteSpace(txtColor.Text) && !string.IsNullOrEmpty(txtMarca.Text) && !string.IsNullOrEmpty(txtModelo.Text))
			{
				string placa = txtPlaca.Text;
				string color = txtColor.Text;
				string modelo = txtModelo.Text;
				string marca = txtMarca.Text;

				Vehiculo vehiculo = new Vehiculo()
				{
					id_usuario = 1,
					Marca = marca,
					Modelo = modelo,
					Placa = placa,
					Color = color
				};
				try
				{
					int resul = await apiService.AgregarVehiculo(vehiculo);
					if (resul != 0)
					{
						await DisplayAlert("Insertar", "Se agrego con éxito", "Aceptar");
						await Navigation.PushAsync(new MisVehiculos());
						txtColor.Text = "";
						txtMarca.Text = "";
						txtModelo.Text = "";
						txtPlaca.Text = "";
					}
				}
				catch (Exception ex)
				{
					var err = ex.Message;
					throw;
				}
			}
			else
			{
				await DisplayAlert("Aviso", "Faltan campos por rellenar", "Cerrar");
			}
		}
	}
}