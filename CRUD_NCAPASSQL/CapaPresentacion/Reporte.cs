using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

using System.IO;
using System.Data;
using System.Reflection;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace CapaPresentacion
{
    public partial class Reporte : Form
    {
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);

        CN_Productos objetoCN = new CN_Productos();


        public Reporte()
        {
            InitializeComponent();
        }
        private void MostrarClientsWithEncuesta()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarCompleteData();
            dataGridView1.Columns[2].Width = 600;
            dataGridView1.Columns[3].Width = 300;
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            MostrarClientsWithEncuesta();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF files|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Document doc = new Document(iTextSharp.text.PageSize.A4, 10, 10, 42, 35);
                        PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        PdfContentByte pdfContent = pdfWriter.DirectContent;
                        iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(doc.PageSize);

                        //customized border sizes
                        rectangle.Left += doc.LeftMargin - 5;
                        rectangle.Right -= doc.RightMargin - 5;
                        rectangle.Top -= doc.TopMargin - 5;
                        rectangle.Bottom += doc.BottomMargin - 5;

                        pdfContent.SetColorStroke(BaseColor.WHITE);//setting the color of the border to white
                        pdfContent.Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, rectangle.Height);
                        pdfContent.Stroke();

                        //setting font type, font size and font color
                        iTextSharp.text.Font headerFont = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_ROMAN, 25, BaseColor.BLACK);
                        Paragraph p = new Paragraph();

                        p.Alignment = Element.ALIGN_CENTER;//adjust the alignment of the heading
                        p.Add(new Chunk("Customers", headerFont));//adding a heading to the PDF
                        doc.Add(p);//adding component to the document
                        iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont(FontFactory.TIMES_ROMAN, 15, BaseColor.BLACK);
                        
                        //creating pdf table
                        PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            PdfPCell cell = new PdfPCell(); //create object from the pdfpcell
                            cell.BackgroundColor = BaseColor.WHITE;//set color of cells
                            cell.AddElement(new Chunk(dataGridView1.Columns[j].HeaderText.ToUpper(), font));
                            table.AddCell(cell);
                        }

                        //adding rows from gridview to table
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            table.WidthPercentage = 100;//set width of the table
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                if (dataGridView1[j, i].Value != null)
                                    table.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));
                            }
                        }
                        //adding table to document
                        doc.Add(table);
                        doc.Close();
                        MessageBox.Show("You have successfully exported the file.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();

            this.Hide();
        }
    }
}
