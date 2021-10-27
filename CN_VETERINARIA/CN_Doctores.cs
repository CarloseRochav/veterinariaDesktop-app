using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CD_VETERINARIA;

namespace CN_VETERINARIA
{
    public class CN_Doctores
    {
        private CD_Doctores objetoCD = new CD_Doctores();

        public DataTable MostrarDoctores()
        {
            DataTable tabla = new DataTable();//Para guardar lo que regrese la consulta
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarDoctores(string nombre, string apellido, string especialidad)
        {
            objetoCD.Insertar(nombre, apellido, especialidad);
        }

        public void EditarDoctores(string nombre, string apellido, string especialidad, string id)
        {
            objetoCD.Editar(nombre, apellido, especialidad, Convert.ToInt32(id));
        }

        //Metodo para eliminar 
        public void EliminarDoctores(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
