using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;//Libreria necesaria para trabajar con SqlServer

namespace CD_VETERINARIA
{
    class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=(local);Database=VET;Trusted_Connection=True;Application Name=MyApp");
        //string connetionString = "Data Source=localhost,1400;Network Library = DBMSSOCN; Initial Catalog = testdocker;User ID = sa; Password=@force-XD1234Omega";
        //private SqlConnection Conexion = new SqlConnection("Data Source=localhost,1400;Initial Catalog = testdocker;User ID = sa; Password=@force-XD1234Omega");

        //Metodo para abrir conexion
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();

            return Conexion;
        }

        //Metodo para cerrar conexion
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }
}
