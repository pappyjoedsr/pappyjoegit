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
    public partial class Image_Zoom : Form
    {
        public int attach_id;
        private Point firstPoint = new Point();
        private Image imgOriginal;
        public static string paths = "";
        Image_Zoom_controller ctrlr=new Image_Zoom_controller();
        public Image_Zoom()
        {
            InitializeComponent();
            INIT();
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
                    string paths = this.ctrlr.getserver();
                    if (dt.Rows.Count > 0)
                    {
                        path = dt.Rows[0]["path"].ToString();
                        if (File.Exists(paths + path) == true)
                        {
                            pictureBox1.Image = Image.FromFile(paths + path);
                            imgOriginal = Image.FromFile(paths+ path);
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
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void frmimagezoom_Load(object sender, EventArgs e)
        {
            DataTable dt=this.ctrlr.attach(attach_id);
            attach(dt);
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
