using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CN_VETERINARIA;

namespace Veterinaria
{
    public partial class Mascotas : Form
    {
        CN_Mascotas objetoCN = new CN_Mascotas();//Instanciacion de instancia
        private string idMascota = null;
        private bool edit = false; //Bandera que nos informara cuando se selecciono la opcion de editar

        public Mascotas()
        {
            InitializeComponent();
        }

        private void MostrarMascotas()//Declaracion de metodo para mostar alumnos
        {
            CN_Mascotas objeto = new CN_Mascotas();
            // ; Se vuelve a instancia ya que se necesita volver a cargar al momento de mostar
            dataGridView1.DataSource = objeto.MostrarMascotas();//Asignado datos al dataGrid
        }

        private void MostrarClientesLista()
        {
            CN_Clientes clientes = new CN_Clientes();
            SqlDataReader dr = clientes.ListarClientes();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Origen de datos

                    int dato = dr.GetInt32(0);
                    this.listBox1.Items.Add(dato);
                }
            }
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Mascotas_Load(object sender, EventArgs e)
        {
            MostrarMascotas();//DOnde se carga el form se invoca el metodo
            MostrarClientesLista();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    objetoCN.InsertarMascotas(txtDueño.Text, txtAnimal.Text,txtNombre.Text);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Inserccion Exitosa");
                    MostrarMascotas();
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
                    objetoCN.EditarMascotas(txtDueño.Text, txtAnimal.Text, txtNombre.Text,idMascota);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Registro Actualizado de manera satisfacctoria");
                    MostrarMascotas();
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
            txtDueño.Clear();
            txtAnimal.Clear();
            txtNombre.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Inicio = new Home();
            Inicio.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;//Igual a true ; indicando que se desea editar los campos
                txtDueño.Text = dataGridView1.CurrentRow.Cells["ID_DUEÑO"].Value.ToString();
                txtAnimal.Text = dataGridView1.CurrentRow.Cells["ANIMAL"].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                idMascota = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

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
                idMascota = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarMascotas(idMascota);
                MessageBox.Show("ELiminado de manera satisfactoria");
                MostrarMascotas();
            }
            else
            {
                MessageBox.Show("Seleccione el registro");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 dates = new Form1();
            dates.Show();
        }
    }
}
