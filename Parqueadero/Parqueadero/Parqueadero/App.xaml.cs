using Parqueadero.Data;
using Parqueadero.Dependency;
using Parqueadero.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parqueadero
{
    public partial class App : Application
    {
        private static VehiculosDatabase database;

        public static VehiculosDatabase DataBase
        {
            get
            {
                if (database == null)
                {
                    return database = new VehiculosDatabase(DependencyService.Get<IGetRuta>().GetRutaDB("BaseDatoss1.db3"));
                }
                else
                {
                    return database;
                }
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
