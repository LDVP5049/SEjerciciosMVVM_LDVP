using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SEjerciciosMVVM_LDVP.Datos;
using SEjerciciosMVVM_LDVP.Modelo;
using SEjerciciosMVVM_LDVP.Vista;
using SEjerciciosMVVM_LDVP.VistaModelo;
using System.ComponentModel;


namespace SEjerciciosMVVM_LDVP.VistaModelo
{
    public class VMeliminar : BaseViewModel
    {
        #region VARIABLES
        string _peso;
        string _kilometros;
        string _validacion;
        string _imagen;
        public Mregistro _registro {  get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMeliminar(INavigation navigation, Mregistro registro)
        {
            Navigation = navigation;
            _registro = registro;
        }
        #endregion
        #region OBJETOS
        public string Kilometros
        {
            get { return _registro.Kilometros; }
            set { SetValue(ref _kilometros, value); }
        }
        public string Peso
        {
            get { return _registro.Peso; }
            set { SetValue(ref _peso, value); }
        }
        public string Validacion
        {
            get { return _registro.Validacion; }
            set { SetValue(ref _validacion, value); }
        }
        public string Imagen
        {
            get { return _registro.Imagen; }
            set { SetValue(ref _imagen, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Eliminar()
        {
            var funcion = new Dejer();
            await funcion.EliminaRegistro(_registro);
            await Regresar(); 
        }
        public async Task Editar()
        {
            var funcion = new Dejer();
            var parametros = new Mregistro();
            parametros.Id = _registro.Id;
            parametros.Kilometros = Kilometros;
            parametros.Peso = Peso;
            parametros.Validacion = Validacion;


            await funcion.Update(parametros);
            await Regresar();
        }
        public async Task Regresar()
        {
            await Navigation.PopModalAsync();
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
        public ICommand Deletecommand => new Command(async () => await Eliminar());
        public ICommand ProcesoSimpCommand => new Command(ProcesoSimple);
        public ICommand Regresarcommand => new Command(async () => await Regresar());
        #endregion
    }
}
