using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parqueadero.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            string apiUrl = "http://192.168.8.15:45455/api/login";
            string correoelectronico = email.Text;
            string contrasena = password.Text;
            try
            {
                var datos = new
                {
                    correoelectronico,
                    contrasena,
                };
                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                HttpContent contenido = new StringContent(jsonData, Encoding.UTF8, "application/json");
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(apiUrl, contenido);
                    if (response.IsSuccessStatusCode)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("alerta", "Fallo en registro", "aceptar");
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }
    }
}