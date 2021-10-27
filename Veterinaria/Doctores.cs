using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CN_VETERINARIA;

namespace Veterinaria
{
    public partial class Doctores : Form
    {
        CN_Doctores objetoCN = new CN_Doctores();
        private string idDoctor = null;
        private bool edit = false; //Bandera que nos informara cuando se selecciono la opcion de editar
        public Doctores()
        {
            InitializeComponent();
        }
        private void MostrarDoctores()
        {
            CN_Doctores objeto = new CN_Doctores();            
            dataGridView1.DataSource = objeto.MostrarDoctores();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void Doctores_Load(object sender, EventArgs e)
        {
            MostrarDoctores();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home inicio = new Home();
            inicio.Show();
        }

        private void limpiarForm()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEspecialidad.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    objetoCN.InsertarDoctores(txtNombre.Text, txtApellido.Text,txtEspecialidad.Text);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Inserccion Exitosa");
                    MostrarDoctores();
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
                    objetoCN.EditarDoctores(txtNombre.Text, txtApellido.Text,txtEspecialidad.Text, idDoctor);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Registro Actualizado de manera satisfacctoria");
                    MostrarDoctores();
                    edit = false;
                    limpiarForm();
                }
                catch (Exception exp)
                {
                    MessageBox.Show($"Error al editar el registro : {exp}");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;//Igual a true ; indicando que se desea editar los campos
                txtNombre.Text = dataGridView1.CurrentRow.Cells["NOMBRE"].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells["APELLIDO"].Value.ToString();
                txtEspecialidad.Text = dataGridView1.CurrentRow.Cells["ESPECIALIDAD"].Value.ToString();
                idDoctor = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

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
                idDoctor = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarDoctores(idDoctor);
                MessageBox.Show("ELiminado de manera satisfactoria");
                MostrarDoctores();
            }
            else
            {
                MessageBox.Show("Seleccione el registro");
            }
        }
    }
}
