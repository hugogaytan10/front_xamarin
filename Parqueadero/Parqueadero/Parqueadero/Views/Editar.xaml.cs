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
    public partial class Editar : ContentPage
    {
        public Editar()
        {
            InitializeComponent();
        }
        Models.Vehiculo vehiculo;
        public Editar(Models.Vehiculo vehiculo)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            txtId.Text = Convert.ToString(vehiculo.Id);
            txtnombre.Text = vehiculo.Tipo;
            txtapellido.Text = vehiculo.Modelo;
            txtedad.Text = vehiculo.Matricula;
            txtId.Focus();
        }
        private async void Actualizar(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text) && !string.IsNullOrWhiteSpace(txtnombre.Text) && !string.IsNullOrWhiteSpace(txtapellido.Text) && !string.IsNullOrWhiteSpace(txtedad.Text))
            {
                try
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    string nombre = txtnombre.Text;
                    string apellido = txtapellido.Text;
                    string edad = txtedad.Text;
                    Vehiculo vehiculo = new Vehiculo
                    {
                        Id = Convert.ToInt32(txtId.Text),
                        Tipo = nombre,
                        Modelo = apellido,
                        Matricula = edad
                    };
                    if (vehiculo.Id != 0)
                    {
                        int personaActualizada = await App.DataBase.Actualizar(vehiculo);
                        if (personaActualizada != 0)
                        {
                            await DisplayAlert("Aviso", "Se actualizó con exito", "Cerrar");
                            await Navigation.PushAsync(new MisVehiculos());
                        }
                        else
                        {
                            await DisplayAlert("Aviso", "El id ingresado no coincide en la base de datos", "Cerrar");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se encontró en la base de datos el id ingresado", "Cerrar");
                    }
                }
                catch (Exception error)
                {
                    var err = error.Message;
                    await DisplayAlert("Aviso", "El id ingresado no coincide en la base de datos", "Cerrar");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Faltan campos por rellenar", "Cerrar");
            }
        }
    }
}