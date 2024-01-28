using SEjerciciosMVVM_LDVP.Datos;
using SEjerciciosMVVM_LDVP.Modelo;
using SEjerciciosMVVM_LDVP.Vista;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace SEjerciciosMVVM_LDVP.VistaModelo
{
    class VMlistaregistros : BaseViewModel
    {
        #region VARIABLES
        List<Mregistro> _Listaregistro;
        #endregion
        #region CONSTRUCTOR
        public VMlistaregistros(INavigation navigation)
        {
            Navigation = navigation;
            Mostrarregistro();
        }
        #endregion
        #region OBJETOS
        public List<Mregistro> Listaregistro
        {
            get { return _Listaregistro; }
            set { SetValue(ref _Listaregistro, value);
                OnpropertyChanged();
            }
        }

        #endregion
        #region PROCESOS

        public async Task Mostrarregistro()
        {
            var funcion = new Dejer();
            Listaregistro = await funcion.MostrarRegistros();
        }

        public async Task IrARegistrar()
        {
            await Navigation.PushModalAsync(new Vinformacion());
        }
        public async Task IrAEliminar(Mregistro registros)
        {
            await Navigation.PushModalAsync(new Veliminar(registros));
        }
        public async Task IrARegistros()
        {
            await Navigation.PushModalAsync(new Vregistros());
        }
        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand Registrarcommand => new Command(async () => await IrARegistrar());
        public ICommand IrEliminarcommand => new Command<Mregistro>(async (p) => await IrAEliminar(p));
        public ICommand Registrocommand => new Command(async () => await IrARegistros());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
