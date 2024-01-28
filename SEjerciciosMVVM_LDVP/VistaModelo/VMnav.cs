using SEjerciciosMVVM_LDVP.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SEjerciciosMVVM_LDVP.VistaModelo
{
    public class VMnav : BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMnav(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion
        #region PROCESOS
        public async Task IrAInformacion()
        {
            await Navigation.PushModalAsync(new Vinformacion());
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
        public ICommand Informacioncommand => new Command(async () => await IrAInformacion());
        public ICommand Registrocommand => new Command(async () => await IrARegistros());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        #endregion
    }
}
