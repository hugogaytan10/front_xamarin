using Parqueadero.Models;
using Parqueadero.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parqueadero
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Carnet : ContentPage
    {
        public Carnet()
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
            await Navigation.PushAsync(new MainPage());
        }


    }
}