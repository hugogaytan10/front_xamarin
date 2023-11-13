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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Carnet());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
		private async void Login(object sender, EventArgs e)
		{
			string apiUrl = "http://192.168.0.6:45455/api/login/login";
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
						Button_Clicked(sender, e);
					}
					else
					{
						await DisplayAlert("alerta", "Fallo en inicio de sesion", "cancelar");
					}
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine("fallo");
			}
		}
	}
}