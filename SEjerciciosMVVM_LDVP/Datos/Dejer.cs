using SEjerciciosMVVM_LDVP.Conexion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SEjerciciosMVVM_LDVP.Modelo;
using Firebase.Database.Query;
using System.Linq;
using System.Collections.ObjectModel;
using Firebase.Database;

namespace SEjerciciosMVVM_LDVP.Datos
{
    public class Dejer
    {
        //AgregarRegistros
        public async Task InsertarRegistro(Mregistro parametros)
        {
            await Cconexion.firebase.Child("Ejercicio").PostAsync(new Mregistro
            {
                Kilometros = parametros.Kilometros,
                Peso = parametros.Peso,
                Validacion = parametros.Validacion,
                Imagen = parametros.Imagen,
            });
        }

        public async Task<List<Mregistro>> MostrarRegistros()
        {
            return (await Cconexion.firebase
                .Child("Ejercicio")
                .OnceAsync<Mregistro>())
                .Select(item => new Mregistro
                {
                    Id = item.Key,
                    Kilometros = item.Object.Kilometros,
                    Peso = item.Object.Peso,
                    Validacion = item.Object.Validacion,
                    Imagen = item.Object.Imagen
                }).ToList();
            /*var data = await Task.Run(() => Cconexion.firebase
                .Child("Ejercicio")
                .AsObservable<Mregistro>()
                .AsObservableCollection());
            return data;*/
        }

        public async Task EliminaRegistro(Mregistro mregistro)
        {
            string Id = mregistro.Id;
            await Cconexion.firebase.Child("Ejercicio").Child(Id).DeleteAsync();
        }
        public async Task Update(Mregistro parametros)
        {
            await Cconexion.firebase.Child("Gasto").Child(parametros.Id).PutAsync(new Mregistro
            {
                Kilometros = parametros.Kilometros,
                Peso = parametros.Peso,
                Validacion = parametros.Validacion,
                Imagen = parametros.Imagen
            });

        }
        //Que flojeraaaa... 8:36 pm 

    }
}
