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
        public MisVehiculos()
        {
            InitializeComponent();
            MostrarTodo();
        }

        public async void MostrarTodo()
        {
            Vehiculo vehiculo = new Vehiculo();
            var vehiculoo = await App.DataBase.BuscarTodo(vehiculo);
            listView.ItemsSource = vehiculoo;
        }
        public async void Search1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            var vehiculoo = await App.DataBase.BuscarTodo(vehiculo);
            var Searchresult = vehiculoo.Where(c => c.Modelo.Contains(search1.Text));
            listView.ItemsSource = Searchresult;
        }
        private async void SwipeItem_Clicked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var veh = item.CommandParameter as Vehiculo;
            var result = await DisplayAlert("Aviso", $"¿Seguro que desea borrar el vehiculo {veh.Modelo}?", "Si", "No");
            if (result)
            {
                await App.DataBase.Eliminar(veh);
                Vehiculo vehiculo = new Vehiculo();
                var vehiculoo = await App.DataBase.BuscarTodo(vehiculo);
                listView.ItemsSource = vehiculoo;
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