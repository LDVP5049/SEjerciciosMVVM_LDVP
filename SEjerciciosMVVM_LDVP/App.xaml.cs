using SEjerciciosMVVM_LDVP.Vista;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SEjerciciosMVVM_LDVP.Modelo;
namespace SEjerciciosMVVM_LDVP
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
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
