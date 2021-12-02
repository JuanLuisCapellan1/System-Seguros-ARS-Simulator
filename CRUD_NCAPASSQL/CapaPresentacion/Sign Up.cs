using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Sign_Up : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        CN_Productos objetoCN = new CN_Productos();

        public Sign_Up()
        {
            InitializeComponent();
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
        private void btnlogin_Click(object sender, EventArgs e)
        {
            DateTime created_user = DateTime.Now;
            //INSERTAR
            try
            {
                objetoCN.InsertarPRod(textBox3.Text, textBox1.Text, textBox2.Text, textBox4.Text, created_user);
                MessageBox.Show("User Created Successfully");
                CleanForm();

             }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating new user: " + ex);
            }
        }

        private void CleanForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();

            login.Show();
            this.Hide();
        }

        private void Sign_Up_Load(object sender, EventArgs e)
        {

        }
    }
}
