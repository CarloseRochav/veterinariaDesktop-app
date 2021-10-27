using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using System.Data;
using CN_VETERINARIA;

namespace Veterinaria
{
    public partial class Clientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();//Instanciacion de instancia
        private string idCliente = null;
        private bool edit = false; //Bandera que nos informara cuando se selecciono la opcion de editar

        public Clientes() //Metodo donde se cargan todos los componentes del FORM
        {
            InitializeComponent();
        }

        private void MostrarClientes()//Declaracion de metodo para mostar alumnos
        {
            CN_Clientes objeto = new CN_Clientes();
            // ; Se vuelve a instancia ya que se necesita volver a cargar al momento de mostar
            dataGridView1.DataSource = objeto.MostrarClientes();//Asignado datos al dataGrid
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            MostrarClientes();//Metodo que carga los clientes en el DataView
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    objetoCN.InsertarClientes(txtNombre.Text, txtApellido.Text);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Inserccion Exitosa");
                    MostrarClientes();
                    limpiarForm();//lIMPIAR CAMPOS
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hubo un problema {ex}");
                }
            }
            if (edit == true)
            {
                try
                {
                    objetoCN.EditarClientes(txtNombre.Text, txtApellido.Text, idCliente);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Registro Actualizado de manera satisfacctoria");
                    MostrarClientes();
                    edit = false;
                    limpiarForm();
                }
                catch (Exception exp)
                {
                    MessageBox.Show($"Error al editar el registro : {exp}");
                }
            }

        }

        public void limpiarForm()//Metodo para limpiar Campos
        {
            txtNombre.Clear();
            txtApellido.Clear();            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//Editar 
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;//Igual a true ; indicando que se desea editar los campos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["APELLIDO"].Value.ToString();               
                idCliente = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione un registro a editar por favor");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idCliente = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarClientes(idCliente);
                MessageBox.Show("ELiminado de manera satisfactoria");
                MostrarClientes();
            }
            else
            {
                MessageBox.Show("Seleccione el registro");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mascotas mascotas = new Mascotas();
            mascotas.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Inicio = new Home();
            Inicio.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
