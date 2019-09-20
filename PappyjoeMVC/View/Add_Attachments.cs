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
    public partial class Add_Attachments : Form
    {
        Image photo;
        PictureBox[] pics = new PictureBox[50];
        OpenFileDialog open2 = new OpenFileDialog();
        OpenFileDialog open3 = new OpenFileDialog();
        OpenFileDialog open4 = new OpenFileDialog();
        OpenFileDialog open5 = new OpenFileDialog();
        OpenFileDialog open6 = new OpenFileDialog();
        OpenFileDialog open7 = new OpenFileDialog();
        OpenFileDialog open8 = new OpenFileDialog();
        OpenFileDialog open9 = new OpenFileDialog();
        public string patient_id = "", admin_id ="", doctor_id ="", pth="";
        public int flag = 0, len,p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0;
        Add_Attachments_controller ctrlr = new Add_Attachments_controller();
        public Add_Attachments()
        {
            InitializeComponent();
        }
        public void Patient_search(DataTable dtb)
        {
            if (toolStripTextBox1.Text != "")
            {
                listpatientsearch.DataSource = dtb;
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStrip1.Width - 350, 32);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }
        public DataTable GetCategory(DataTable dtcatgry)
        {
            try
            {
                if (dtcatgry.Rows.Count > 0)
                {
                    Cmb_category1.DataSource = dtcatgry;
                    Cmb_category1.DisplayMember = "CategoryName";
                    Cmb_category1.ValueMember = "id";
                    Cmb_category1.SelectedIndex = 0;
                    Cmb_category2.BindingContext = new BindingContext();
                    Cmb_category2.DataSource = dtcatgry;
                    Cmb_category2.DisplayMember = "CategoryName";
                    Cmb_category2.ValueMember = "id";
                    Cmb_category2.SelectedIndex = 0;
                    Cmb_category3.BindingContext = new BindingContext();
                    Cmb_category3.DataSource = dtcatgry;
                    Cmb_category3.DisplayMember = "CategoryName";
                    Cmb_category3.ValueMember = "id";
                    Cmb_category3.SelectedIndex = 0;
                    Cmb_category4.BindingContext = new BindingContext();
                    Cmb_category4.DataSource = dtcatgry;
                    Cmb_category4.DisplayMember = "CategoryName";
                    Cmb_category4.ValueMember = "id";
                    Cmb_category4.SelectedIndex = 0;
                    Cmb_category5.BindingContext = new BindingContext();
                    Cmb_category5.DataSource = dtcatgry;
                    Cmb_category5.DisplayMember = "CategoryName";
                    Cmb_category5.ValueMember = "id";
                    Cmb_category5.SelectedIndex = 0;
                    Cmb_category6.BindingContext = new BindingContext();
                    Cmb_category6.DataSource = dtcatgry;
                    Cmb_category6.DisplayMember = "CategoryName";
                    Cmb_category6.ValueMember = "id";
                    Cmb_category6.SelectedIndex = 0;
                    Cmb_category7.BindingContext = new BindingContext();
                    Cmb_category7.DataSource = dtcatgry;
                    Cmb_category7.DisplayMember = "CategoryName";
                    Cmb_category7.ValueMember = "id";
                    Cmb_category7.SelectedIndex = 0;
                    Cmb_category8.BindingContext = new BindingContext();
                    Cmb_category8.DataSource = dtcatgry;
                    Cmb_category8.DisplayMember = "CategoryName";
                    Cmb_category8.ValueMember = "id";
                    Cmb_category8.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return dtcatgry;
        }
        private void Add_Attachments_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                string doctrid=this.ctrlr.selectdoctrid();
                if (doctrid != "")
                {
                    if (doctrid != doctor_id)
                    {
                        admin_id = doctrid;
                    }
                }
                string clinic=this.ctrlr.clinicname();
                if (clinic != "")
                {
                    toolStripButton1.Text = clinic.Replace("¤", "'");
                }
                string doctrname=this.ctrlr.Get_DoctorName(doctor_id);
                if (doctrname != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + doctrname;
                }
                DataTable catgry=this.ctrlr.GetCategory();
                GetCategory(catgry);
                DataTable patntdtls=this.ctrlr.GetPatientDetails(patient_id);
                if (patntdtls.Rows.Count > 0)
                {
                    linkLabel_id.Text = patntdtls.Rows[0]["pt_id"].ToString();
                    linkLabel_Name.Text = patntdtls.Rows[0]["pt_name"].ToString();
                }
                string paymnt=this.ctrlr.GetPayment(patient_id);
                if (paymnt != "")
                {
                    Lab_due.Text = paymnt + " due";
                }
                if (PB_1.Image == null)
                {
                    PB_1.Image = PappyjoeMVC.Properties.Resources.upload;
                    p2 = 1;
                }
                if (Pb_2.Image == null)
                {
                    Pb_2.Image = PappyjoeMVC.Properties.Resources.upload;
                    p3 = 1;
                }
                if (Pb_3.Image == null)
                {
                    Pb_3.Image = PappyjoeMVC.Properties.Resources.upload;
                    p4 = 1;
                }
                if (PB_4.Image == null)
                {
                    PB_4.Image = PappyjoeMVC.Properties.Resources.upload;
                    p5 = 1;
                }
                if (Pb_5.Image == null)
                {
                    p6 = 1;
                    Pb_5.Image = PappyjoeMVC.Properties.Resources.upload;
                }
                if (PB_6.Image == null)
                {
                    p7 = 1;
                    PB_6.Image = PappyjoeMVC.Properties.Resources.upload;
                }
                if (PB_7.Image == null)
                {
                    p8 = 1;
                    PB_7.Image = PappyjoeMVC.Properties.Resources.upload;
                }
                if (PB_8.Image == null)
                {
                    p9 = 1;
                    PB_8.Image = PappyjoeMVC.Properties.Resources.upload;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt=this.ctrlr.Patient_search(toolStripTextBox1.Text);
            Patient_search(dt);
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Show();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }
        public void pathlength()
        {
            string fullpath = Application.StartupPath.Substring(0, Application.StartupPath.Length);
            if (fullpath.Substring((Application.StartupPath.Length) - 1) == "e")
            {
                len = 11;
            }
            else if (fullpath.Substring((Application.StartupPath.Length - 1)) == "g")
            {
                len = 10;
            }
        }
        private void Add_Attachments_Resize(object sender, EventArgs e)
        {
            //btn_Save.Location = new System.Drawing.Point(this.Width - 226, 94);
            //btn_Close.Location = new System.Drawing.Point(this.Width - 126, 94);
        }
        private void PB_1_Click(object sender, EventArgs e)
        {
            try
            {
                open2.ShowDialog();
                string ext = Path.GetExtension(open2.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    PB_1.Image = Image.FromFile(open2.FileName);
                    PB_1.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open2.FileName;
                    p2 = 0;
                    photo = PB_1.Image;
                    txt_Path1.Text = System.IO.Path.GetFileName(open2.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    PB_1.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    PB_1.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_Path1.Text = System.IO.Path.GetFileName(open2.FileName);
                    p2 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    PB_1.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    PB_1.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_Path1.Text = System.IO.Path.GetFileName(open2.FileName);
                    p2 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    PB_1.Image = PappyjoeMVC.Properties.Resources.pdf;
                    PB_1.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_Path1.Text = System.IO.Path.GetFileName(open2.FileName);
                    p2 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void PB_1_MouseEnter(object sender, EventArgs e)
        {
            PB_1.BackColor = Color.White;
        }
        private void PB_1_MouseLeave(object sender, EventArgs e)
        {
            PB_1.BackColor = Color.Gainsboro;
        }
        private void btn_Delete1_Click(object sender, EventArgs e)
        {
            PB_1.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_Path1.Clear();
            p2 = 1;
        }
        private void Pb_2_Click(object sender, EventArgs e)
        {
            try
            {
                open3.ShowDialog();
                string ext = Path.GetExtension(open3.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    Pb_2.Image = Image.FromFile(open3.FileName);
                    Pb_2.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open3.FileName;
                    p3 = 0;
                    photo = Pb_2.Image;
                    txt_Path2.Text = System.IO.Path.GetFileName(open3.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    Pb_2.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    Pb_2.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_Path2.Text = System.IO.Path.GetFileName(open3.FileName);
                    p3 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    Pb_2.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    Pb_2.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_Path2.Text = System.IO.Path.GetFileName(open3.FileName);
                    p3 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    Pb_2.Image = PappyjoeMVC.Properties.Resources.pdf;
                    Pb_2.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_Path2.Text = System.IO.Path.GetFileName(open3.FileName);
                    p3 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void Pb_2_MouseEnter(object sender, EventArgs e)
        {
            Pb_2.BackColor = Color.White;
        }
        private void Pb_2_MouseLeave(object sender, EventArgs e)
        {
            Pb_2.BackColor = Color.Gainsboro;
        }
        private void Pb_3_Click(object sender, EventArgs e)
        {
            try
            {
                open4.ShowDialog();
                string ext = Path.GetExtension(open4.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    Pb_3.Image = Image.FromFile(open4.FileName);
                    Pb_3.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open4.FileName;
                    p4 = 0;
                    photo = Pb_3.Image;
                    txt_path3.Text = System.IO.Path.GetFileName(open4.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    Pb_3.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    Pb_3.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path3.Text = System.IO.Path.GetFileName(open4.FileName);
                    p4 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    Pb_3.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    Pb_3.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path3.Text = System.IO.Path.GetFileName(open4.FileName);
                    p4 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    Pb_3.Image = PappyjoeMVC.Properties.Resources.pdf;
                    Pb_3.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path3.Text = System.IO.Path.GetFileName(open4.FileName);
                    p4 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void PB_4_Click(object sender, EventArgs e)
        {
            try
            {
                open5.ShowDialog();
                string ext = Path.GetExtension(open5.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    PB_4.Image = Image.FromFile(open5.FileName);
                    PB_4.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open5.FileName;
                    p5 = 0;
                    photo = PB_4.Image;
                    txt_path4.Text = System.IO.Path.GetFileName(open5.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    PB_4.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    PB_4.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path4.Text = System.IO.Path.GetFileName(open5.FileName);
                    p5 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    PB_4.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    PB_4.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path4.Text = System.IO.Path.GetFileName(open5.FileName);
                    p5 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    PB_4.Image = PappyjoeMVC.Properties.Resources.pdf;
                    PB_4.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path4.Text = System.IO.Path.GetFileName(open5.FileName);
                    p5 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void Pb_5_Click(object sender, EventArgs e)
        {
            try
            {
                open6.ShowDialog();
                string ext = Path.GetExtension(open5.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    Pb_5.Image = Image.FromFile(open5.FileName);
                    Pb_5.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open6.FileName;
                    p6 = 0;
                    photo = Pb_5.Image;
                    txt_path5.Text = System.IO.Path.GetFileName(open6.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    Pb_5.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    Pb_5.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path5.Text = System.IO.Path.GetFileName(open6.FileName);
                    p6 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    Pb_5.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    Pb_5.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path5.Text = System.IO.Path.GetFileName(open6.FileName);
                    p6 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    Pb_5.Image = PappyjoeMVC.Properties.Resources.pdf;
                    Pb_5.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path5.Text = System.IO.Path.GetFileName(open6.FileName);
                    p6 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
        private void PB_6_Click(object sender, EventArgs e)
        {
            try
            {
                open7.ShowDialog();
                string ext = Path.GetExtension(open6.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    PB_6.Image = Image.FromFile(open7.FileName);
                    PB_6.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open7.FileName;
                    p7 = 0;
                    photo = PB_6.Image;
                    txt_path6.Text = System.IO.Path.GetFileName(open7.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    PB_6.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    PB_6.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path6.Text = System.IO.Path.GetFileName(open7.FileName);
                    p7 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    PB_6.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    PB_6.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path6.Text = System.IO.Path.GetFileName(open7.FileName);
                    p7 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    PB_6.Image = PappyjoeMVC.Properties.Resources.pdf;
                    PB_6.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path6.Text = System.IO.Path.GetFileName(open7.FileName);
                    p7 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void PB_7_Click(object sender, EventArgs e)
        {
            try
            {
                open8.ShowDialog();
                string ext = Path.GetExtension(open8.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    PB_7.Image = Image.FromFile(open8.FileName);
                    PB_7.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open8.FileName;
                    p8 = 0;
                    photo = PB_7.Image;
                    txt_path7.Text = System.IO.Path.GetFileName(open8.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    PB_7.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    PB_7.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path7.Text = System.IO.Path.GetFileName(open8.FileName);
                    p8 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    PB_7.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    PB_7.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path7.Text = System.IO.Path.GetFileName(open8.FileName);
                    p8 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    PB_7.Image = PappyjoeMVC.Properties.Resources.pdf;
                    PB_7.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path7.Text = System.IO.Path.GetFileName(open8.FileName);
                    p8 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void PB_8_Click(object sender, EventArgs e)
        {
            try
            {
                open9.ShowDialog();
                string ext = Path.GetExtension(open9.FileName);
                if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                {
                    PB_8.Image = Image.FromFile(open9.FileName);
                    PB_8.BackgroundImageLayout = ImageLayout.Zoom;
                    pth = open9.FileName;
                    p9 = 0;
                    photo = PB_8.Image;
                    txt_path8.Text = System.IO.Path.GetFileName(open9.FileName);
                }
                else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                {
                    PB_8.Image = PappyjoeMVC.Properties.Resources.word_doc_icon;
                    PB_8.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path8.Text = System.IO.Path.GetFileName(open9.FileName);
                    p9 = 0;
                }
                else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                {
                    PB_8.Image = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                    PB_8.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path8.Text = System.IO.Path.GetFileName(open9.FileName);
                    p9 = 0;
                }
                else if (ext.ToLower() == ".pdf")
                {
                    PB_8.Image = PappyjoeMVC.Properties.Resources.pdf;
                    PB_8.BackgroundImageLayout = ImageLayout.Zoom;
                    txt_path8.Text = System.IO.Path.GetFileName(open9.FileName);
                    p9 = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Pb_3_MouseEnter(object sender, EventArgs e)
        {
            Pb_3.BackColor = Color.White;
        }
        private void PB_4_MouseEnter(object sender, EventArgs e)
        {
            PB_4.BackColor = Color.White;
        }
        private void Pb_5_MouseEnter(object sender, EventArgs e)
        {
            Pb_5.BackColor = Color.White;
        }
        private void PB_6_MouseEnter(object sender, EventArgs e)
        {
            PB_6.BackColor = Color.White;
        }
        private void PB_7_MouseEnter(object sender, EventArgs e)
        {
            PB_7.BackColor = Color.White;
        }
        private void PB_8_MouseEnter(object sender, EventArgs e)
        {
            PB_8.BackColor = Color.White;
        }
        private void Pb_3_MouseLeave(object sender, EventArgs e)
        {
            Pb_3.BackColor = Color.Gainsboro;
        }
        private void PB_4_MouseLeave(object sender, EventArgs e)
        {
            PB_4.BackColor = Color.Gainsboro;
        }
        private void Pb_5_MouseLeave(object sender, EventArgs e)
        {
            Pb_5.BackColor = Color.Gainsboro;
        }
        private void PB_6_MouseLeave(object sender, EventArgs e)
        {
            PB_6.BackColor = Color.Gainsboro;
        }
        private void PB_7_MouseLeave(object sender, EventArgs e)
        {
            PB_7.BackColor = Color.Gainsboro;
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            string addpatient = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
            doctr_privillage_for_addnewPatient(addpatient);
        }
        public void doctr_privillage_for_addnewPatient(string doctrid)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = doctrid;
                    if (int.Parse(id) > 0)
                    {
                        var form2 = new Add_New_Patients();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog(); ;
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        } 
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        private void PB_8_MouseLeave(object sender, EventArgs e)
        {
            PB_8.BackColor = Color.Gainsboro;
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string prvlge=this.ctrlr.settingsprivilage(doctor_id);
            settingsprivilage(prvlge);
        }
        public void settingsprivilage(string doctrid)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = doctrid;
                    if (int.Parse(id) > 0)
                    {
                        var form2 = new Practice_Details();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    var form2 = new Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void btn_Delete2_Click(object sender, EventArgs e)
        {
            Pb_2.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_Path2.Clear();
            p3 = 1;
        }
        private void btn_Delete3_Click(object sender, EventArgs e)
        {
            Pb_3.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_path3.Clear();
            p4 = 1;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void btn_Delete4_Click(object sender, EventArgs e)
        {
            PB_4.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_path4.Clear();
            p5 = 1;
        }
        private void btn_Delete5_Click(object sender, EventArgs e)
        {
            Pb_5.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_path5.Clear();
            p6 = 1;
        }
        private void btn_Delete6_Click(object sender, EventArgs e)
        {
            PB_6.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_path6.Clear();
            p7 = 1;
        }
        private void btn_Delete7_Click(object sender, EventArgs e)
        {
            PB_7.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_path7.Clear();
            p8 = 1;
        }
        private void btn_Delete8_Click(object sender, EventArgs e)
        {
            PB_8.Image = PappyjoeMVC.Properties.Resources.upload;
            txt_path8.Clear();
            p9 = 1;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id == "0")
                {
                    doctor_id = admin_id;
                }
                string server = this.ctrlr.getserver();
                if (p2 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open2.FileName);
                    string catName = Cmb_category1.GetItemText(Cmb_category1.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open2.FileName, catName);
                }
                if (p3 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open3.FileName);
                    string catName = Cmb_category2.GetItemText(Cmb_category2.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open3.FileName, catName);
                }
                if (p4 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open4.FileName);
                    string catName = Cmb_category3.GetItemText(Cmb_category3.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open4.FileName, catName);
                }
                if (p5 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open5.FileName);
                    string catName = Cmb_category4.GetItemText(Cmb_category4.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open5.FileName, catName);
                }
                if (p6 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open6.FileName);
                    string catName = Cmb_category5.GetItemText(Cmb_category5.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open6.FileName, catName);
                }
                if (p7 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open7.FileName);
                    string catName = Cmb_category6.GetItemText(Cmb_category6.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open7.FileName, catName);
                }

                if (p8 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open8.FileName);
                    string catName = Cmb_category7.GetItemText(Cmb_category7.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open8.FileName, catName);
                }
                if (p9 == 0)
                {
                    string realfile = System.IO.Path.GetFileName(open9.FileName);
                    string catName = Cmb_category8.GetItemText(Cmb_category8.SelectedItem);
                    txt_Path1.Text = realfile;
                    txt_Path2.Text = catName;
                    save_image(realfile, server, open9.FileName, catName);
                }
                if (doctor_id == admin_id)
                {
                    doctor_id = "0";
                }
                if (flag == 0)
                {
                    MessageBox.Show("Choose an Image First !!", "No Image Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var form2 = new Attachments();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void save_image(string realfile, string server, string filename,string catgry)
        {
            if (realfile != "")
            {
                try
                {
                    if (File.Exists(@"\\" + server + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                    {
                    }
                    else
                    {
                        System.IO.File.Copy(filename, @"\\" + server + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                txt_path3.Text = pathimage;
                this.ctrlr.insattach(patient_id,realfile,pathimage,doctor_id,catgry);
                flag = 1;
            }
        }
    }
}

