using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEjerciciosMVVM_LDVP.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SEjerciciosMVVM_LDVP.Modelo;
namespace SEjerciciosMVVM_LDVP.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Veliminar : ContentPage
	{
		public Veliminar (Mregistro registros)
		{
			InitializeComponent ();
			BindingContext = new VMeliminar(Navigation, registros);
		}
	}
}