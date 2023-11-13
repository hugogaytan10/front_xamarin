using Parqueadero.Data;
using Parqueadero.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parqueadero.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Editar : ContentPage
	{
		private readonly ApiService apiService;

		public Editar()
		{
			InitializeComponent();
			apiService = new ApiService();
		}

		Models.Vehiculo vehiculo;

		public Editar(Models.Vehiculo vehiculo)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);

			// Asegúrate de asignar el valor al objeto vehiculo en este constructor
			this.vehiculo = vehiculo;

			txtColor.Text = vehiculo.Color;
			txtMarca.Text = vehiculo.Marca;
			txtModelo.Text = vehiculo.Modelo;
			txtPlaca.Text = vehiculo.Placa;
			txtIdU.Text = vehiculo.id_usuario.ToString();
		}

		private async void Actualizar(object sender, EventArgs e)
		{
			if (this.vehiculo != null &&
				!string.IsNullOrWhiteSpace(txtColor.Text) &&
				!string.IsNullOrWhiteSpace(txtMarca.Text) &&
				!string.IsNullOrWhiteSpace(txtModelo.Text) &&
				!string.IsNullOrWhiteSpace(txtPlaca.Text))
			{
				try
				{
					long? Id = this.vehiculo?.id_usuario;
					string color = txtColor.Text;
					string marca = txtMarca.Text;
					string modelo = txtModelo.Text;
					string placa = txtPlaca.Text;
					string idU = txtIdU.Text;

					Vehiculo vehiculo = new Vehiculo
					{
						id_usuario = Convert.ToInt32(idU),
						Marca = marca,
						Modelo = modelo,
						Placa = placa,
						Color = color
					};


					int vehiculoActualizado = await apiService.ActualizarVehiculo(placa, vehiculo);
					if (vehiculoActualizado != 0)
					{
						await DisplayAlert("Aviso", "Se actualizó con éxito", "Cerrar");
						await Navigation.PushAsync(new MisVehiculos());
					}
					else
					{
						await DisplayAlert("Aviso", "El id ingresado no coincide en la base de datos", "Cerrar");
					}
				}
				catch (Exception error)
				{
					var err = error.Message;
					await DisplayAlert("Aviso", error.ToString(), "Cerrar");
				}
			}
			else
			{
				await DisplayAlert("Aviso", "Faltan campos por rellenar o vehiculo es nulo", "Cerrar");
			}
		}

	}
}
