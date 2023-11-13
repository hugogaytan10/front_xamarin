using Parqueadero.Data;
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
    public partial class Historial : ContentPage
    {
        private readonly ApiServiceHistorial apiService;
        public Historial()
        {
            InitializeComponent();
			apiService = new ApiServiceHistorial();
			Todo();
		}
		public async void Todo()
		{
			var reservas = await apiService.ObtenerReservas();
			listView.ItemsSource = reservas;
		}
	}
}