using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEjerciciosMVVM_LDVP.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SEjerciciosMVVM_LDVP.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vinformacion : ContentPage
    {
        public Vinformacion()
        {
            InitializeComponent();
            BindingContext = new VMregistrar(Navigation);
        }
    }
}