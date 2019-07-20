using Microsoft.Win32;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class frmimagezoom : Form,frmimagezoom_interface
    {
        public int attach_id;
        Connection c = new Connection();
        private Point firstPoint = new Point();
        private Image imgOriginal;
        frmimagezoom_controller ctrlr;
        public frmimagezoom(int atid)
        {
            attach_id = atid;
            InitializeComponent();
            INIT();
        }
        public int attachid
        {
            get { return attach_id; }
            set { attach_id = value; }
        }
        public void setController(frmimagezoom_controller controller)
        {
            ctrlr = controller;
        }
        public void attach(DataTable dt)
        {
            try
            {
                if (attach_id != 0)
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
                    string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
                    string path = "";
                    string paths = c.server();
                    if (dt.Rows.Count > 0)
                    {
                        path = dt.Rows[0]["path"].ToString();
                        paths = c.server();
                        if (File.Exists(paths + path) == true)
                        {
                            pictureBox1.Image = Image.FromFile(c.server() + path);
                            imgOriginal = Image.FromFile(c.server() + path);
                            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                            this.Text = "Patient : " + dt.Rows[0]["pt_name"].ToString() + ";     Id: " + dt.Rows[0]["pt_id"].ToString() + ";   File name: " + dt.Rows[0]["photo_name"].ToString();
                            trackBar2.Value = pictureBox1.Size.Width;
                            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
                            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
                        }
                        else
                        {
                            MessageBox.Show("No image Found", "Image Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Check your systems..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmimagezoom_Load(object sender, EventArgs e)
        {
            this.ctrlr.attach(attach_id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        public void INIT()
        {
            pictureBox1.MouseDown += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left) { firstPoint = Control.MousePosition; }
            };
            pictureBox1.MouseMove += (ss, ee) =>
            {
                if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);
                    pictureBox1.Location = new Point(pictureBox1.Location.X - res.X, pictureBox1.Location.Y - res.Y);

                    firstPoint = temp;
                }
            };
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(trackBar2.Value, trackBar2.Value);
            pictureBox1.Left = (this.ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (this.ClientSize.Height - pictureBox1.Height) / 2;
        }
    }
}
