using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using CN_VETERINARIA;


namespace Veterinaria
{
    public partial class Form1 : Form
    {
        CN_Citas objetoCN = new CN_Citas();//Instanciacion de instancia
        CN_Doctores doctores = new CN_Doctores();
        private string idCita = null;
        private bool edit = false; //Bandera que nos informara cuando se selecciono la opcion de editar

        //Propiedades de cita
        private string doctor;
        private string cliente;
        private string mascota;
        private string idcita;

        public string Doctor { get => doctor; set => doctor = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public string Mascota { get => mascota; set => mascota = value; }
        public string IdCita { get => idcita; set => idcita = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarCitas()//Declaracion de metodo para mostar alumnos
        {
            CN_Citas objeto = new CN_Citas();
            // ; Se vuelve a instancia ya que se necesita volver a cargar al momento de mostar
            dataGridView1.DataSource = objeto.MostrarCitas();//Asignado datos al dataGrid
        }

        private void MostrarCitasFormato()
        {
            CN_Citas objeto = new CN_Citas();
            dataGridView1.DataSource = objeto.MostarCitasFormato();
        }

        private void MostrarDoctores()
        {
            SqlDataReader dr = objetoCN.MostrarListaDoctores();
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

        private void MostrarClientes()
        {
            SqlDataReader dr = objetoCN.MostrarListaClientes();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Origen de datos

                    int dato = dr.GetInt32(0);
                    this.listBox2.Items.Add(dato);
                }
            }
        }

        private void MostrarMascotas()
        {
            SqlDataReader dr = objetoCN.MostrarListaMascotas();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Origen de datos

                    int dato = dr.GetInt32(0);
                    this.listBox3.Items.Add(dato);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MostrarCitas();
            MostrarCitasFormato();
            MostrarDoctores();
            MostrarClientes();
            MostrarMascotas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();//Indica que oculta la clase this; Hace referencia a la clase en la que se encuentra
            Clientes frm = new Clientes();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home Inicio = new Home();
            Inicio.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                try
                {
                    objetoCN.InsertarCitas(txtDoctor.Text, txtCliente.Text,txtMascota.Text);//Le paso el el valor de las variables de los textBox
                    MessageBox.Show("Inserccion Exitosa");
                    MostrarCitasFormato();
                    limpiarForm();//lIMPIAR CAMPOS
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show($"Error al editar el registro : {ex}");
                }
            }
            if (edit == true)
            {
                try
                {
                    objetoCN.EditarCitas(txtDoctor.Text, txtCliente.Text, txtMascota.Text,idCita);
                    MessageBox.Show("Registro Actualizado de manera satisfacctoria");
                    MostrarCitasFormato();
                    edit = false;
                    limpiarForm();
                }
                catch (Exception ex)
                {                   
                        MessageBox.Show($"Error al editar el registro : {ex}");
                }
            }

        }

        public void limpiarForm()
        {
            txtDoctor.Clear();
            txtCliente.Clear();
            txtMascota.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;//Igual a true ; indicando que se desea editar los campos
                txtDoctor.Text = dataGridView1.CurrentRow.Cells["DOCTOR"].Value.ToString();
                txtCliente.Text = dataGridView1.CurrentRow.Cells["CLIENTE"].Value.ToString();
                txtMascota.Text = dataGridView1.CurrentRow.Cells["MASCOTA"].Value.ToString();
                idCita= dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

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
                idCita = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                objetoCN.EliminarCitas(idCita);
                MessageBox.Show("ELiminado de manera satisfactoria");
                MostrarCitasFormato();
            }
            else
            {
                MessageBox.Show("Seleccione el registro");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mascotas pets = new Mascotas();
            pets.Show();
        }

        private void button8_Click(object sender, EventArgs e)//Boton de Reporte
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {                
                //Doctor = this.dataGridView1.CurrentRow.Cells["DOCTOR"].Value.ToString();
                //Cliente = this.dataGridView1.CurrentRow.Cells["CLIENTE"].Value.ToString();
                //Mascota = this.dataGridView1.CurrentRow.Cells["MASCOTA"].Value.ToString();s
                //IdCita =this.dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                Reporte report = new Reporte();

                report.txtDoctor.Text = dataGridView1.CurrentRow.Cells["DOCTOR"].Value.ToString(); ;
                report.txtDueño.Text = dataGridView1.CurrentRow.Cells["CLIENTE"].Value.ToString(); ;
                report.txtPaciente.Text = dataGridView1.CurrentRow.Cells["MASCOTA"].Value.ToString(); ;

                this.Hide();
               
                report.Show();

            }
            else
            {
                MessageBox.Show("Seleccione un registro a editar por favor");
            }



        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                edit = true;//Igual a true ; indicando que se desea editar los campos
                txtDoctor.Text = dataGridView1.CurrentRow.Cells["DOCTOR"].Value.ToString();
                txtCliente.Text = dataGridView1.CurrentRow.Cells["CLIENTE"].Value.ToString();
                txtMascota.Text = dataGridView1.CurrentRow.Cells["MASCOTA"].Value.ToString();
                idCita = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();                
            }
            else
            {
                MessageBox.Show("Seleccione un registro a editar por favor");
            }
        }
    }
}
