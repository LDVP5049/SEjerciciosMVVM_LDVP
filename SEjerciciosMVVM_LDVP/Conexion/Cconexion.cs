using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace SEjerciciosMVVM_LDVP.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://mvvmini-default-rtdb.firebaseio.com/");
    }
}
