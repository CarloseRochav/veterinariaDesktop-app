using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CD_VETERINARIA;

namespace CN_VETERINARIA
{
    public class CN_Clientes
    {
        private CD_Clientes objetoCD = new CD_Clientes();

        public DataTable MostrarClientes()
        {
            DataTable tabla = new DataTable();//Para guardar lo que regrese la consulta
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public SqlDataReader ListarClientes()
        {
            SqlDataReader lista;
            lista = objetoCD.MostrarLista();
            return lista;
        }

        public void InsertarClientes(string nombre, string apellido)
        {
            objetoCD.Insertar(nombre, apellido);
        }

        public void EditarClientes(string nombre, string apellido, string id)
        {
            objetoCD.Editar(nombre, apellido,Convert.ToInt32(id));
        }

        //Metodo para eliminar 
        public void EliminarClientes(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
