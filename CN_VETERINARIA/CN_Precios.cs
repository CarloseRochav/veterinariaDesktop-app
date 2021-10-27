using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CD_VETERINARIA;

namespace CN_VETERINARIA
{
    public class CN_Precios
    {
        private CD_Precios objetoCD = new CD_Precios();

        public DataTable MostrarPrecios()
        {
            DataTable tabla = new DataTable();//Para guardar lo que regrese la consulta
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public void InsertarPrecios(string servicio, string precio)
        {
            objetoCD.Insertar(servicio,precio);
        }

        public void EditarPrecios(string servicio, string precio, string id)
        {
            objetoCD.Editar(servicio, precio, Convert.ToInt32(id));
        }

        //Metodo para eliminar 
        public void EliminarPrecios(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
