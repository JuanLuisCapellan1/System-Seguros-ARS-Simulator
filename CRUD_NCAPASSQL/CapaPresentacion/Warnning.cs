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
    public partial class Warnning : Form
    {
        public Warnning()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Encuesta encuesta = new Encuesta();
            encuesta.Show();

            this.Hide();
        }
    }
}
