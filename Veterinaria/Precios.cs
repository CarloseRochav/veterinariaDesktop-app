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
    public partial class Precios : Form
    {
        CN_Precios objetoCN = new CN_Precios();//Instanciacion de instancia        
        private string idPrecio = null;
        private bool edit = false; //Bandera que nos informara cuando s
        public Precios()
        {
            InitializeComponent();
        }

        public void MostrarPrecios()
        {
            CN_Precios objeto = new CN_Precios();
            // ; Se vuelve a instancia ya que se necesita volver a cargar al momento de mostar
            dataGridView1.DataSource = objeto.MostrarPrecios();//Asignado datos al dataGrid
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 citas = new Form1();
            citas.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    objetoCN.InsertarPrecios(txtServicio.Text, txtPrecio.Text);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Inserccion Exitosa");
                    MostrarPrecios();
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
                    objetoCN.EditarPrecios(txtServicio.Text, txtPrecio.Text, idPrecio);
                    MessageBox.Show("Registro Actualizado de manera satisfacctoria");
                    MostrarPrecios();
                    edit = false;
                    limpiarForm();
                }
                catch (Exception exp)
                {
                    MessageBox.Show($"Error al editar el registro : {exp}");
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home inicio = new Home();
            inicio.Show();
        }
        public void limpiarForm()
        {
            txtServicio.Clear();
            txtPrecio.Clear();
        }

        private void Precios_Load(object sender, EventArgs e)
        {
            MostrarPrecios();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
