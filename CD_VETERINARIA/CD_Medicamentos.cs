using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CD_VETERINARIA
{
    public class CD_Medicamentos {
        private CD_Conexion conexion = new CD_Conexion();//Conexion a la base de datos
        SqlDataReader leer;//Leera las filas de la tabla ; Metodo para leer
        DataTable tabla = new DataTable();//Para almacenar las consultas en la tabla
        SqlCommand comando = new SqlCommand(); //Nos permite ejecutar instruccion SQL

        public DataTable Mostrar()
        {
            //Opcion 1; Instruccion SQL Server directa / TRANSAC
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "SELECT*FROM MEDICAMENTOS";//Instruccion a ejecutar
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

            ////Opcion 2 ; Con un procedimiento Almacenado
            //comando.Connection = conexion.AbrirConexion();
            //comando.CommandText = "MostrarAlumnos";//Reenplazamos la transacc por el netodo
            //comando.CommandType = CommandType.StoredProcedure;//Debemos a especificar en esta linea que es de tipo procedimiento
            //leer = comando.ExecuteReader();//Solo para consultas
            //tabla.Load(leer);
            //conexion.CerrarConexion();
            //return tabla;
        }

        public void Insertar(string nombre, string horario)
        {
            comando.Connection = conexion.AbrirConexion();//Abrimos la conexion para poder hacer operaciones con nuestra database
            comando.CommandText = "INSERT INTO MEDICAMENTOS VALUES('" + nombre + "','" + horario + "')";//Ponemos las variables
            comando.CommandType = CommandType.Text;//Tenemos que especificar de nuevo que usamos transact
            //comando.CommandText = "InsertarAlumnos";//Usando /*Proc*/
            //comando.CommandType = CommandType.StoredProcedure;//Indica que usaras Proc
            //comando.Parameters.AddWithValue("@nombre", name);
            //comando.Parameters.AddWithValue("@apellidoP", lastNameP);
            //comando.Parameters.AddWithValue("@apellidoM", lastNameM);
            //comando.Parameters.AddWithValue("@carrera", deegre); //Sustitumos parametros y valores del proc

            comando.ExecuteNonQuery();//Solo para insertar filas

            comando.Parameters.Clear(); //Limpiar parametros del objeto;

        }

        public void Editar(string medicamento, string horario, int id)//Metodo para editar un registro
        {
            comando.Connection = conexion.AbrirConexion();//Importante abrir la conexion !!!
            comando.CommandText = "UPDATE MEDICAMENTOS(NOMBRE, HORARIO) VALUES(@NOMBRE, @HORARIO) WHERE ID = '" + id + "' ";
            comando.CommandType = CommandType.Text;//Tenemos que especificar de nuevo que usamos transact
            //comando.CommandText = "EditarAlumnos";//Usando Proc
            //comando.CommandType = CommandType.StoredProcedure;//Indica que usaras Proc
            comando.Parameters.AddWithValue("@NOMBRE", medicamento);
            comando.Parameters.AddWithValue("@HORARIO", horario);
            comando.Parameters.AddWithValue("@ID", id);

            comando.ExecuteNonQuery();//Solo para insertar filas

            comando.Parameters.Clear(); //Limpiar parametros del objeto;
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DELETE FROM MEDICAMENTOS WHERE ID = @id";
            comando.CommandType = CommandType.Text;//Tenemos que especificar de nuevo que usamos transact
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }


    }
}
