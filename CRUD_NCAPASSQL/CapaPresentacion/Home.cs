using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Home : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        internal static string nameUserLogin;

        public Home()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form form = new form();
            form.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Login login  = new Login();
            login.Activate();
            label5.Text = nameUserLogin;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {
            form form = new form();
            form.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            reporte.Show();
            this.Hide();
        }
    }
}
