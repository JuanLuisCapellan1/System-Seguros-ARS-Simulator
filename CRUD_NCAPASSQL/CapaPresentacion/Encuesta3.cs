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
    public partial class Encuesta3 : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        internal static string nameUserLogin;
        internal static string idUserLogin;

        CN_Productos objetoCN = new CN_Productos();

        public Encuesta3()
        {
            InitializeComponent();
        }

        private void Encuesta3_Load(object sender, EventArgs e)
        {
            Console.WriteLine(idUserLogin);
            label10.Text = nameUserLogin;
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count != 0)
            {
                // If so, loop through all checked items and print results.  
                string s = "";
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    s += checkedListBox1.CheckedItems[x].ToString() + "\n";
                }

                objetoCN.InsertEncuestaClient(label3.Text, s, idUserLogin);
                Encuesta4 encuesta4 = new Encuesta4();

                Encuesta4.idUserLogin = idUserLogin;
                Encuesta4.nameUserLogin = nameUserLogin;

                encuesta4.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Seleccione Una de las opciones");
            }
        }

        private void panelE1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
