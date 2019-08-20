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
    public partial class Add_Attachments : Form, Add_Attachments_interface
    {
        public string doctor_id = "0";
        Add_Attachments_controller ctrlr;
        Add_Attachments_model mdl = new Add_Attachments_model();
        PictureBox[] pics = new PictureBox[50];
        int flag = 0;
        public string patient_id = "0";
        string pth;
        string admin_id = "0";
        public int len;
        Image photo;
        int p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0;
        OpenFileDialog open2 = new OpenFileDialog();
        OpenFileDialog open3 = new OpenFileDialog();
        OpenFileDialog open4 = new OpenFileDialog();
        OpenFileDialog open5 = new OpenFileDialog();
        OpenFileDialog open6 = new OpenFileDialog();
        OpenFileDialog open7 = new OpenFileDialog();
        OpenFileDialog open8 = new OpenFileDialog();
        OpenFileDialog open9 = new OpenFileDialog();
        public Add_Attachments()
        {
            InitializeComponent();
        }
        public void setController(Add_Attachments_controller controller)
        {
            ctrlr = controller;
        }
        public string id
        {
            get { return this.txt_path8.Text; }
            set { this.txt_path8.Text= value; }
        }
        public string catgryname
        {
            get { return this.txt_Path2.Text; }
            set { this.txt_Path2.Text = value; }
        }
        public string name
        {
            get { return this.mdl.cliname; }
            set { this.mdl.cliname = value; }
        }
        public string docname
        {
            get { return this.mdl.dname; }
            set { this.mdl.dname = value; }
        }
        public string category
        {
            get { return this.mdl.category; }
            set { this.mdl.category = value; }
        }
        public string patid
        {
            get { return this.mdl.patid; ; }
            set { this.mdl.patid = value; }
        }
        public string path
        {
            get { return this.txt_path3.Text; }
            set { this.txt_path3.Text = value; }
        }
        public string image
        {
            get { return this.txt_Path1.Text; }
            set { this.txt_Path1.Text = value; }
        }
        public string payment
        {
            get { return this.mdl.payment; }
            set { this.mdl.payment = value; }
        }
        public string mobileno
        {
            get { return this.mdl.mobileno; }
            set { this.mdl.mobileno = value; }
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
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

        public void selid(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["id"].ToString() != doctor_id)
                {
                    admin_id = dt.Rows[0]["id"].ToString();
                }
                txt_path8.Text = dt.Rows[0]["id"].ToString();
            }
        }
        public void Get_CompanyNAme(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = dt.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
        }
        public void Get_DoctorName(string dt1)
        {
            if (dt1!="")
            {
                toolStripTextDoctor.Text = "Logged In As : " + dt1;
            }
        }
        public void getcategory(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Cmb_category1.DataSource = dt;
                    Cmb_category1.DisplayMember = "CategoryName";
                    Cmb_category1.ValueMember = "id";
                    Cmb_category1.SelectedIndex = 0;
                    Cmb_category2.BindingContext = new BindingContext();
                    Cmb_category2.DataSource = dt;
                    Cmb_category2.DisplayMember = "CategoryName";
                    Cmb_category2.ValueMember = "id";
                    Cmb_category2.SelectedIndex = 0;
                    Cmb_category3.BindingContext = new BindingContext();
                    Cmb_category3.DataSource = dt;
                    Cmb_category3.DisplayMember = "CategoryName";
                    Cmb_category3.ValueMember = "id";
                    Cmb_category3.SelectedIndex = 0;
                    Cmb_category4.BindingContext = new BindingContext();
                    Cmb_category4.DataSource = dt;
                    Cmb_category4.DisplayMember = "CategoryName";
                    Cmb_category4.ValueMember = "id";
                    Cmb_category4.SelectedIndex = 0;
                    Cmb_category5.BindingContext = new BindingContext();
                    Cmb_category5.DataSource = dt;
                    Cmb_category5.DisplayMember = "CategoryName";
                    Cmb_category5.ValueMember = "id";
                    Cmb_category5.SelectedIndex = 0;
                    Cmb_category6.BindingContext = new BindingContext();
                    Cmb_category6.DataSource = dt;
                    Cmb_category6.DisplayMember = "CategoryName";
                    Cmb_category6.ValueMember = "id";
                    Cmb_category6.SelectedIndex = 0;
                    Cmb_category7.BindingContext = new BindingContext();
                    Cmb_category7.DataSource = dt;
                    Cmb_category7.DisplayMember = "CategoryName";
                    Cmb_category7.ValueMember = "id";
                    Cmb_category7.SelectedIndex = 0;
                    Cmb_category8.BindingContext = new BindingContext();
                    Cmb_category8.DataSource = dt;
                    Cmb_category8.DisplayMember = "CategoryName";
                    Cmb_category8.ValueMember = "id";
                    Cmb_category8.SelectedIndex = 0;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getpatdetails(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                linkLabel_id.Text = dt.Rows[0]["pt_id"].ToString();
                linkLabel_Name.Text = dt.Rows[0]["pt_name"].ToString();
            }
        }
        public void getpayment(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Lab_due.Text = dt.Rows[0]["total_payment"].ToString() + " due";
            }
        }
        public void srchtxt(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                listpatientsearch.DataSource = dt;
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

        private void Add_Attachments_Load(object sender, EventArgs e)
        {
            try
            {
                this.ctrlr.selid();
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                patid= patient_id;
                this.ctrlr.Get_CompanyNAme();
                this.ctrlr.Get_DoctorName(doctor_id);
                this.ctrlr.getcategory();
                this.ctrlr.getpatdetails(patient_id);
                this.ctrlr.getpayment(patient_id);
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.ctrlr.Patient_search(toolStripTextBox1.Text);
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patient_profile_details();
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Pb_5_Click(object sender, EventArgs e)
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PB_6_Click(object sender, EventArgs e)
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PB_7_Click(object sender, EventArgs e)
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PB_8_Click(object sender, EventArgs e)
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
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void PB_8_MouseLeave(object sender, EventArgs e)
        {
            PB_8.BackColor = Color.Gainsboro;
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controllr = new Communication_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            Reports_controller controller = new Reports_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                doctor_controller controlr = new doctor_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
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
            Attachments frm = new Attachments();
            frm.doctor_id = doctor_id;
            Attachments_controller controller = new Attachments_controller(frm);
            frm.ShowDialog(this);
            
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (doctor_id == "0")
            {
                doctor_id = admin_id;
            }
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("Pappyjoe");
            string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
            pathlength();
            string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - len);
            if (p2 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open2.FileName);
                string catName = Cmb_category1.GetItemText(Cmb_category1.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open2.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }
            if (p3 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open3.FileName);
                string catName = Cmb_category2.GetItemText(Cmb_category2.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open3.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }
            if (p4 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open4.FileName);
                string catName = Cmb_category3.GetItemText(Cmb_category3.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open4.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }
            if (p5 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open5.FileName);
                string catName = Cmb_category4.GetItemText(Cmb_category4.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open5.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }
            if (p6 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open6.FileName);
                string catName = Cmb_category5.GetItemText(Cmb_category5.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open6.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }
            if (p7 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open7.FileName);
                string catName = Cmb_category6.GetItemText(Cmb_category6.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open7.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }

            if (p8 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open8.FileName);
                string catName = Cmb_category7.GetItemText(Cmb_category7.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open8.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
            }
            if (p9 == 0)
            {
                string realfile = System.IO.Path.GetFileName(open9.FileName);
                string catName = Cmb_category8.GetItemText(Cmb_category8.SelectedItem);
                txt_Path1.Text = realfile;
                txt_Path2.Text = catName;
                if (realfile != "")
                {
                    try
                    {
                        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                        {
                        }
                        else
                        {
                            System.IO.File.Copy(open9.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    string pathimage = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Attachments\\" + "\\" + realfile;
                    txt_path3.Text = pathimage;
                    this.ctrlr.insattach();
                    flag = 1;
                }
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
                Attachments_controller controller = new Attachments_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
    }
}

