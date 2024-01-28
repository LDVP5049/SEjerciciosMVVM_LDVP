using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using SEjerciciosMVVM_LDVP.Vista.Navegar;

namespace SEjerciciosMVVM_LDVP
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Nav();
            this.Detail = new Xamarin.Forms.NavigationPage(new Inicio());
            App.MasterDet = this;
        }
    }
}
