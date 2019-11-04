using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PappyjoeMVC.View
{
    public partial class Print_Label_Print : Form
    {
        public Print_Label_Print()
        {
            InitializeComponent();
        }
        public DataTable dt_Load { get; set; }
        int r_Count = 0;
        private void print_label_print_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            if (dt_Load != null)
            {
                Dgv_Print.RowCount = 0;
                Dgv_Print.ColumnCount = 3;
                Dgv_Print.ColumnHeadersVisible = false;
                Dgv_Print.RowHeadersVisible = false;
                Dgv_Print.Columns[0].Name = "id";
                Dgv_Print.Columns[0].Width = 300;
                Dgv_Print.Columns[1].Name = "id";
                Dgv_Print.Columns[1].Width = 300;
                Dgv_Print.Columns[2].Name = "id";
                Dgv_Print.Columns[2].Width = 300;
                int R = 0;
                int c = 0;
                DataTable dt_pt = dt_Load;
                r_Count = dt_Load.Rows.Count;
                for (int j = 0; j < dt_pt.Rows.Count; j++)
                {
                    if (c == 0)
                    {
                        Dgv_Print.Rows.Add("Patient Id #:" + dt_pt.Rows[j][1].ToString() + "\r\n" + dt_pt.Rows[j][2].ToString() + "\r\n" + dt_pt.Rows[j][6].ToString() + "\r\n" + "Admission #:" +dt_pt.Rows[j][7].ToString() + "\r\nFile Number :" + dt_pt.Rows[j][8].ToString() + "\r\nPhone :" + dt_pt.Rows[j][5].ToString());
                        Dgv_Print.Rows[R].Height = 150;
                        c = 1;
                    }
                    else if (c == 1)
                    {
                        Dgv_Print.Rows[R].Cells[1].Value = "Patient Id #:" + dt_pt.Rows[j][1].ToString() + "\r\n" + dt_pt.Rows[j][2].ToString() + "\r\n" + dt_pt.Rows[j][6].ToString() + "\r\n" + "Admission #:" + dt_pt.Rows[j][7].ToString() + "\r\nFile Number :" + dt_pt.Rows[j][8].ToString() + "\r\nPhone :" + dt_pt.Rows[j][5].ToString();
                        c = 2;
                    }
                    else if (c == 2)
                    {
                        Dgv_Print.Rows[R].Cells[2].Value = "Patient Id #:" + dt_pt.Rows[j][1].ToString() + "\r\n" + dt_pt.Rows[j][2].ToString() + "\r\n" + dt_pt.Rows[j][6].ToString() + "\r\n" + "Admission #:" + dt_pt.Rows[j][7].ToString() + "\r\nFile Number :" + dt_pt.Rows[j][8].ToString() + "\r\nPhone :" + dt_pt.Rows[j][5].ToString();
                        R = R + 1;
                        c = 0;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument printdocument = new PrintDocument();
            printdocument.PrintPage += printDocument1_PrintPage;
            printdocument.Print();
            printPreviewDialog1.Document = printDocument1;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                using (Font printFont = new Font("Segoe UI", 10.0f))
                {
                    int height = 0;
                    Pen p = new Pen(Brushes.Black, 2.5f);
                    int i = 0;
                    height = 10;
                    while (i < Dgv_Print.Rows.Count)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(20, height, Dgv_Print.Columns[0].Width - 20, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawString(Dgv_Print.Rows[i].Cells[0].FormattedValue.ToString(), new Font("Segoe UI", 10f), Brushes.Black, new System.Drawing.Rectangle(30, height + 10, Dgv_Print.Columns[0].Width, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(Dgv_Print.Columns[0].Width, height, Dgv_Print.Columns[0].Width - 20, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawString(Dgv_Print.Rows[i].Cells[1].FormattedValue.ToString(), new Font("Segoe UI", 10f), Brushes.Black, new System.Drawing.Rectangle(Dgv_Print.Columns[0].Width + 10, height + 10, Dgv_Print.Columns[0].Width, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle((Dgv_Print.Columns[0].Width + Dgv_Print.Columns[0].Width) - 20, height, Dgv_Print.Columns[0].Width - 70, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawString(Dgv_Print.Rows[i].Cells[2].FormattedValue.ToString(), new Font("Segoe UI", 10f), Brushes.Black, new System.Drawing.Rectangle(Dgv_Print.Columns[0].Width + Dgv_Print.Columns[0].Width, height + 10, Dgv_Print.Columns[0].Width, Dgv_Print.Rows[0].Height));
                        height += Dgv_Print.Rows[0].Height;
                        i++;
                    }
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                using (Font printFont = new Font("Segoe UI", 13.0f))
                {
                    int height = 0;
                    Pen p = new Pen(Brushes.Black, 2.5f);
                    int i = 0;
                    height = 25;
                    while (i < Dgv_Print.Rows.Count)
                    {
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(30, height, Dgv_Print.Columns[0].Width - 30, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawString(Dgv_Print.Rows[i].Cells[0].FormattedValue.ToString(), new Font("Segoe UI", 13f), Brushes.Black, new System.Drawing.Rectangle(30, height + 10, Dgv_Print.Columns[0].Width, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(Dgv_Print.Columns[0].Width, height, Dgv_Print.Columns[0].Width - 20, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawString(Dgv_Print.Rows[i].Cells[1].FormattedValue.ToString(), new Font("Segoe UI", 13f), Brushes.Black, new System.Drawing.Rectangle(Dgv_Print.Columns[0].Width + 10, height + 10, Dgv_Print.Columns[0].Width, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle((Dgv_Print.Columns[0].Width + Dgv_Print.Columns[0].Width) - 20, height, Dgv_Print.Columns[0].Width - 70, Dgv_Print.Rows[0].Height));
                        e.Graphics.DrawString(Dgv_Print.Rows[i].Cells[2].FormattedValue.ToString(), new Font("Segoe UI", 13f), Brushes.Black, new System.Drawing.Rectangle(Dgv_Print.Columns[0].Width + Dgv_Print.Columns[0].Width, height + 10, Dgv_Print.Columns[0].Width, Dgv_Print.Rows[0].Height));
                        height += Dgv_Print.Rows[0].Height;
                        i++;
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                foreach (DataGridViewRow dr in Dgv_Print.Rows)
                {
                    dr.Cells[0].Style.Font = new Font("Segoe UI", 10);
                    dr.Cells[1].Style.Font = new Font("Segoe UI", 10);
                    dr.Cells[2].Style.Font = new Font("Segoe UI", 10);
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                foreach (DataGridViewRow dr in Dgv_Print.Rows)
                {
                    dr.Cells[0].Style.Font = new Font("Segoe UI", 13);
                    dr.Cells[1].Style.Font = new Font("Segoe UI", 13);
                    dr.Cells[2].Style.Font = new Font("Segoe UI", 13);
                }

            }
        }
    }
}
