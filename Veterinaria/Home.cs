using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Veterinaria
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 citas = new Form1();
            citas.Show();//Mostras citas

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clientes clientes = new Clientes();
            clientes.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctores docs = new Doctores();
            docs.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Precios precio = new Precios();
            precio.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mascotas mascotas = new Mascotas();
            mascotas.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
