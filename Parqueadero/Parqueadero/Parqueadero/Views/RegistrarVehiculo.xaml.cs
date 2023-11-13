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
        public RegistrarVehiculo()
        {
            InitializeComponent();
            txtnombre.Items.Add("Moto");
            txtnombre.Items.Add("Carro");
        }
        private async void Insertar(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtapellido.Text) && !string.IsNullOrWhiteSpace(txtedad.Text))
            {
                string apellido = txtapellido.Text;
                string edad = txtedad.Text;

               Vehiculo vehiculo = new Vehiculo()
                {
                    id_usuario = 0,
                    Marca = Convert.ToString(txtnombre.SelectedItem),
                    Modelo = apellido,
                    Placa = edad
                };
                try
                {
                    int resul = await App.DataBase.Agregar(vehiculo);
                    if (resul != 0)
                    {
                        await DisplayAlert("Insertar", "Se agrego con éxito", "Aceptar");
                        await Navigation.PushAsync(new MisVehiculos());
                        txtedad.Text = "";
                        txtapellido.Text = "";
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