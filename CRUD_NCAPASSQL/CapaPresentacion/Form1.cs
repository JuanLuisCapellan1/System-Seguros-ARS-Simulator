using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class form : Form
    {

        CN_Productos objetoCN = new CN_Productos();
        private string idClient = null;
        private bool Editar = false;

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        public form()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarClients();
        }

        private void MostrarClients()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarClient();
        }

        public void FindClient()
        {
            SqlConnection conexion = new SqlConnection("Server = localhost; Database = PracticeSystem; Trusted_Connection = True;");
            conexion.Open();
            SqlCommand comando = new SqlCommand("select max(ID) from Clients", conexion);
            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                //Console.WriteLine(registro.GetValue(0).ToString());
                Encuesta encuesta = new Encuesta();
                Encuesta.idUserLogin = registro.GetValue(0).ToString();
            }
            conexion.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text == "" || txtEmail.Text == "" || txtCedula.Text == "" || txtTel.Text == "" || txtDirec.Text == "")
            {
                MessageBox.Show("Ingrese los datos por favor");
            }
            else
            {
                //INSERTAR
                if (Editar == false)
                {
                    try
                    {
                        DateTime created_user = DateTime.Now;
                        objetoCN.InsertarClientPRod(txtNombre.Text, txtEmail.Text, txtCedula.Text, txtTel.Text, txtDirec.Text, created_user);
                        MessageBox.Show("se inserto correctamente");
                        MostrarClients();
                        FindClient();

                        Encuesta.nameUserLogin = txtNombre.Text;
                        Encuesta encuesta = new Encuesta();

                        limpiarForm();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo insertar los datos por: " + ex);
                    }
                }

                //EDITAR
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.EditarClient(txtNombre.Text, txtEmail.Text, txtCedula.Text, txtTel.Text, txtDirec.Text, idClient);
                        MessageBox.Show("se edito correctamente");
                        MostrarClients();
                        limpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("no se pudo editar los datos por: " + ex);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtCedula.Text = dataGridView1.CurrentRow.Cells["No_Cedula"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
                txtTel.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
                txtDirec.Text = dataGridView1.CurrentRow.Cells["Direction"].Value.ToString();
                idClient = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void limpiarForm()
        {
            txtEmail.Clear();
            txtCedula.Text = "";
            txtTel.Clear();
            txtDirec.Clear();
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idClient = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarClient(idClient);
                MessageBox.Show("Eliminado correctamente");
                MostrarClients();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit This Program ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Warnning warnning = new Warnning();

            warnning.Show();
            this.Hide();
        }
    }
    
}
