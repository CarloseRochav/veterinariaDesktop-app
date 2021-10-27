using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CD_VETERINARIA;

namespace CN_VETERINARIA
{
    public class CN_Citas
    {
        private CD_Citas objetoCD = new CD_Citas();
        private CD_Doctores objetoDoc = new CD_Doctores();
        private CD_Clientes objetoCl = new CD_Clientes();
        private CD_Mascotas objetoMas = new CD_Mascotas();

        public DataTable MostrarCitas()
        {
            DataTable tabla = new DataTable();//Para guardar lo que regrese la consulta
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        //LIstar doctores
        public SqlDataReader MostrarListaDoctores()
        {
            SqlDataReader lista;
            lista = objetoDoc.MostrarLista();
            return lista;
        }
        //LIstar Clientes
        public SqlDataReader MostrarListaClientes()
        {
            SqlDataReader lista;
            lista = objetoCl.MostrarLista();
            return lista;
        }
        //LIstar Mascotas
        public SqlDataReader MostrarListaMascotas()
        {
            SqlDataReader lista;
            lista = objetoMas.MostrarLista();
            return lista;
        }

        public DataTable MostarCitasFormato()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarCitasFormateadas();
            return tabla;

        }

        public void InsertarCitas(string doctor, string cliente, string mascota)
        {
            objetoCD.Insertar(Convert.ToInt32(doctor), Convert.ToInt32(cliente), Convert.ToInt32(mascota));
        }

        public void EditarCitas(string doctor, string cliente, string mascota, string id)
        {
            objetoCD.Editar(Convert.ToInt32(doctor), Convert.ToInt32(cliente), Convert.ToInt32(mascota), Convert.ToInt32(id));
        }

        //Metodo para eliminar 
        public void EliminarCitas(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }

}
       

