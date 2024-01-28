using SEjerciciosMVVM_LDVP.Datos;
using SEjerciciosMVVM_LDVP.Vista.Navegar;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SEjerciciosMVVM_LDVP.Modelo;
using SEjerciciosMVVM_LDVP.Vista;

namespace SEjerciciosMVVM_LDVP.VistaModelo
{
    class VMregistrar : BaseViewModel
    {
        #region VARIABLES
        string _peso;
        string _kilometros;
        string _resultado;
        string _validacion;
        string _operacion;
        string _imagen;
        bool _calpresio;
        bool _calregi = false;

        #endregion
        #region CONSTRUCTOR
        public VMregistrar(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public bool Calpresio
        {
            get { return _calpresio; }
            set { SetValue(ref _calpresio, value); }
        }
        public bool Calregi
        {
            get { return _calregi; }
            set { SetValue(ref _calregi, value); }
        }
        public string Peso
        {
            get { return _peso; }
            set { SetValue(ref _peso, value); }
        }
        public string Kilometros
        {
            get { return _kilometros; }
            set { SetValue(ref _kilometros, value); }
        }
        public string Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value); }
        }
        public string Validacion
        {
            get { return _validacion; }
            set { SetValue(ref _validacion, value); }
        }
        public string Operacion
        {
            get { return _operacion; }
            set { SetValue(ref _operacion, value); }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { SetValue(ref _imagen, value); }
        }
        #endregion
        #region PROCESOS

        public void Calcular()
        {
            Calregi = true;
            double peso, kilometros, resu;
            if (double.TryParse(Peso, out peso) && double.TryParse(Kilometros, out kilometros))
            {
                resu = peso * kilometros * 0.8;

                string mensajeAlerta = $"Calorías quemadas: {resu}";

                if (resu > 300)
                {
                    DisplayAlert("Calorías quemadas:", mensajeAlerta, "Ok");
                    Validacion = "Se logró";
                    Imagen = "https://i.ibb.co/yPKrV2T/winner.png";
                }
                else
                {
                    DisplayAlert("Calorías quemadas:", mensajeAlerta, "Ok");
                    Validacion = "Se falló";
                    Imagen = "https://i.ibb.co/RvfWR8V/Loser.png";
                }
                Resultado = $"{resu}";
            }
            else
            {
                DisplayAlert("Error", "Por favor, ingrese valores válidos para Peso y Kilómetros.", "Ok");
            }
        }
        public async Task InsertarRegistro()
        {
            var funcion = new Dejer();
            var parametros = new Mregistro();
            parametros.Kilometros = Kilometros;
            parametros.Peso = Peso;
            parametros.Validacion = Validacion;
            parametros.Imagen = Imagen;
            await funcion.InsertarRegistro(parametros);
            Calregi = false;
        }
        public async Task IrAInicio()
        {
            await Navigation.PushModalAsync(new Nav());
        }

        public void ProcesoSimple()
        {
            DisplayAlert("Estado || Meta", "Rojo: No cumplida || Verde: Cumplida","Ok");
        }
        #endregion
        #region COMANDOS
        public ICommand Insertarcommand => new Command(async () => await InsertarRegistro());
        public ICommand Iniciocommand => new Command(async () => await IrAInicio());
        public ICommand ProcesoSimpleCommand => new Command(ProcesoSimple);
        public ICommand Calcularcommand => new Command(Calcular);
        #endregion
    }
}
