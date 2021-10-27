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
    public partial class Reporte : Form
    {
        CN_Medicamentos objetoMe = new CN_Medicamentos();
        CN_Precios objetoPre = new CN_Precios();
        private string idMedicamento = null;
        private bool edit = false; //Bandera que nos informara cuando se selecciono la opcion de editar
        public Reporte()
        {
            InitializeComponent();
        }
        private void MostrarPrecios()//Declaracion de metodo para mostar alumnos
        {
            CN_Precios objeto = new CN_Precios();
            // ; Se vuelve a instancia ya que se necesita volver a cargar al momento de mostar
            dataGridView1.DataSource = objeto.MostrarPrecios();//Asignado datos al dataGrid
        }

        private void MostrarMedicamentos()//Declaracion de metodo para mostar alumnos
        {
            CN_Medicamentos objeto = new CN_Medicamentos();
            // ; Se vuelve a instancia ya que se necesita volver a cargar al momento de mostar
            dataGridView2.DataSource = objeto.MostrarMedicamentos();//Asignado datos al dataGrid
        }

        private void getData()
        {
            Form1 citas = new Form1();
            txtDoctor.Text = citas.Doctor;
            txtDueño.Text = citas.Cliente;
            txtPaciente.Text = citas.Mascota;
        }
        private void Reporte_Load(object sender, EventArgs e)
        {
            MostrarPrecios();
            MostrarMedicamentos();
            getData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home inicio = new Home();
            inicio.Show();
        }
    }
}
