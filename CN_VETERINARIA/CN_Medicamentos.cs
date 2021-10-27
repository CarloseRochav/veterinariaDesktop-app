using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CD_VETERINARIA;

namespace CN_VETERINARIA
{
    public class CN_Medicamentos
    {
        private CD_Medicamentos objetoCD = new CD_Medicamentos();      
        private CD_Precios objetoPre = new CD_Precios();

        public DataTable MostrarMedicamentos()
        {
            DataTable tabla = new DataTable();//Para guardar lo que regrese la consulta
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        //LIstar doctores
        public DataTable MostrarPrecios()
        {
            DataTable table = new DataTable();
             table = objetoPre.Mostrar();
            return table;
        }     
        

        public void InsertarMedicamentos(string nombre, string horario)
        {
            objetoCD.Insertar(nombre,horario);
        }

        public void EditarMedicamentos(string nombre, string horario, string id)
        {
            objetoCD.Editar(nombre,horario, Convert.ToInt32(id));
        }

        //Metodo para eliminar 
        public void EliminarMedicamentos(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }

    }
}
