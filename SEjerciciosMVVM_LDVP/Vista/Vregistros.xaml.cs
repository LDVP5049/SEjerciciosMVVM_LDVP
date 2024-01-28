using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using System.Threading.Tasks;
using SEjerciciosMVVM_LDVP.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SEjerciciosMVVM_LDVP.Vista;


namespace SEjerciciosMVVM_LDVP.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vregistros : ContentPage
    {
        public Vregistros()
        {
            InitializeComponent();
            BindingContext = new VMlistaregistros(Navigation);
        
        }
    }
}