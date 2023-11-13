using Parqueadero.Data;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parqueadero.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Carros : ContentPage
	{
		private readonly ApiServicePuestos apiService;

		public Carros()
		{
			InitializeComponent();
			apiService = new ApiServicePuestos();
			MostrarPuestos(); // Agregamos esta llamada para mostrar los puestos al cargar la página
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Reservar());
		}

		private async void MostrarPuestos()
		{
			var puestos = await apiService.ObtenerPuestos();

			if (puestos != null && puestos.Count > 0)
			{
				Grid grid = new Grid();

				// Definir columnas según la cantidad de puestos
				for (int j = 0; j < 5; j++)
				{
					grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				}

				// Calcular el número de filas necesarias
				int numRows = (int)Math.Ceiling((double)puestos.Count / 5);

				// Definir filas según la cantidad de puestos
				for (int i = 0; i < numRows; i++)
				{
					grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });

					for (int j = 0; j < 5; j++)
					{
						int puestoIndex = i * 5 + j;

						if (puestoIndex < puestos.Count)
						{
							var puesto = puestos[puestoIndex];
							var label = new Label
							{
								Text = $"Puesto {puesto.numero}",
								BackgroundColor = GetColorForEstado(puesto.estado),
								VerticalOptions = LayoutOptions.Center,
								HorizontalOptions = LayoutOptions.FillAndExpand,
							};
							grid.Children.Add(label, j, i);

							// Agrega un gesture recognizer para detectar el clic en el puesto
							var tapGestureRecognizer = new TapGestureRecognizer();
							tapGestureRecognizer.Tapped += (s, e) =>
							{
								// Aquí puedes agregar la lógica para manejar el clic en el puesto
								// por ejemplo, mostrar detalles o realizar alguna acción
								DisplayAlert("Puesto Clickeado", $"Puesto {puesto.numero} clickeado", "Aceptar");
							};
							label.GestureRecognizers.Add(tapGestureRecognizer);
						}
					}
				}

				// Agregar la rejilla dinámica al ScrollView
				scrollView.Content = grid;
			}
		}



		private Color GetColorForEstado(string estado)
		{
			// Implementa la lógica necesaria para asignar colores según el estado
			// Puedes usar el convertidor de valores que definimos en el código anterior si lo prefieres
			// Aquí se proporciona un ejemplo simple
			switch (estado)
			{
				case "libre":
					return Color.Green;
				case "ocupado":
					return Color.Red;
				case "inactivo":
					return Color.Gray;
				default:
					return Color.Default;
			}
		}
	}
}
