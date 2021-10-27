using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CD_VETERINARIA;

namespace CN_VETERINARIA
{
    public class CN_Mascotas
    {
        private CD_Mascotas objetoCD = new CD_Mascotas();

        public DataTable MostrarMascotas()  
        {
            DataTable tabla = new DataTable();//Para guardar lo que regrese la consulta
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarMascotas(string dueño, string animal, string nombre)
        {
            objetoCD.Insertar(Convert.ToInt32(dueño), animal, nombre);
        }

        public void EditarMascotas(string dueño, string animal, string nombre,string id)
        {
            objetoCD.Editar(Convert.ToInt32(dueño), animal, nombre, Convert.ToInt32(id));
        }

        //Metodo para eliminar 
        public void EliminarMascotas(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
