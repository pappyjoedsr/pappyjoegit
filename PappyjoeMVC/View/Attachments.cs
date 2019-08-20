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
    public partial class Attachments : Form, Attachments_interface
    {
        public string doctor_id = "";
        public string dctr = "";
        public int attach_id;
        public string File_Type = "";
        public string patient_id = "0";
        public bool APTDelete = false;
        string privid;
        Attachments_model mdl = new Attachments_model();
        Add_Attachments_model m = new Add_Attachments_model();
        Attachments_controller ctrlr;
        common_model cm = new common_model();
        Connection c = new Connection();
        public Attachments()
        {
            InitializeComponent();
        }
        public string id
        {
            get { return this.mdl.docid; }
            set { this.mdl.docid = value; }
        }
        public string patid
        {
            get { return patient_id; }
            set { patient_id = value; }
        }
        public string catgryname
        {
            get { return this.txt_Category.Text; }
            set { this.txt_Category.Text = value; }
        }
        public string catgryid
        {
            get { return this.Dgv_Category.CurrentRow.Cells["colid"].Value.ToString(); }
            set { this.Dgv_Category.CurrentRow.Cells["colid"].Value = value; }
        }
        public int attachid
        {
            get { return attach_id; }
            set { attach_id = value; }
        }
        public void setController(Attachments_controller controller)
        {
            ctrlr = controller;
        }
        public void selid(string id)
        {
            if (doctor_id != "1")
            {
                string privid;
                privid = id;
                if (int.Parse(privid) > 0)
                {
                    button1.Visible = false;
                }
                else
                {
                    button1.Visible = true;
                }
            }
            else
            {
                this.ctrlr.getid(doctor_id);
                APTDelete = true;
            }
        }
        public void getid(string gid)
        {
            privid = gid;
            if (int.Parse(privid) > 0)
            {
                APTDelete = false;
            }
            else
            {
                APTDelete = true;
            }
        }
        public void Get_DoctorName(DataTable dt1)
        {
            if (dt1.Rows.Count > 0)
            {
                dctr = dt1.Rows[0][0].ToString();
                toolStripTextDoctor.Text = "Logged In As : " + dt1.Rows[0][0].ToString();
            }
        }
        public void getcategory(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                fill_DgvCategory(dt);
            }
        }
        public void getpatdetails(DataTable dt)
        {
            if (patient_id != "0")
            {
                if (dt.Rows.Count > 0)
                {
                    linkLabel_id.Text = dt.Rows[0]["pt_id"].ToString();
                    linkLabel_Name.Text = dt.Rows[0]["pt_name"].ToString();
                }
            }
        }
        public void getpayment(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                label8.Text = dt.Rows[0]["total_payment"].ToString() + " due";
            }
        }
        public void getattachment(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                FillAttachmentGrid(dt);
            }
        }
        public void getattachment2(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Lab_Msg.Visible = false;
                FillAttachmentGrid(dt);
            }
            else
            {
                Lab_Msg.Visible = true;
            }
        }

        public void FillAttachmentGrid(DataTable attach)
        {
            if (attach.Rows.Count > 0)
            {
                string doctor = "";
                for (int i = 0; i < attach.Rows.Count; i++)
                {
                    string paths = this.ctrlr.getserver();// c.server();
                    string path = attach.Rows[i]["path"].ToString();
                    if (decimal.Parse(attach.Rows[i]["dr_id"].ToString()) > 0)
                    {
                        this.ctrlr.Get_DoctorName(attach.Rows[i]["dr_id"].ToString());
                        doctor = dctr;
                    }
                    string ext = Path.GetExtension(attach.Rows[i]["Path"].ToString());
                    //                     0                          1                                                   2                                             3                       4                            5                    6  
                    Dgv_Attachment.Rows.Add("", "Date : " + String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(attach.Rows[i]["date"].ToString())), "Category:" + attach.Rows[i]["CategoryName"].ToString(), "Added By : Dr." + doctor, attach.Rows[i]["photo_name"].ToString(), attach.Rows[i]["id"].ToString(), ext);
                    Dgv_Attachment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Dgv_Attachment.Columns[1].DefaultCellStyle.Font = new System.Drawing.Font("Seigo", 8, FontStyle.Regular);
                    Dgv_Attachment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Dgv_Attachment.Columns[3].DefaultCellStyle.Font = new System.Drawing.Font("Seigo", 9, FontStyle.Bold);
                    Dgv_Attachment.Columns[3].DefaultCellStyle.ForeColor = Color.Green;
                    Dgv_Attachment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Dgv_Attachment.Columns[2].DefaultCellStyle.Font = new System.Drawing.Font("Seigo", 7, FontStyle.Bold);
                    Dgv_Attachment.Columns[5].Visible = false;
                    Dgv_Attachment.Columns[0].Width = 50;
                    Dgv_Attachment.Columns[1].Width = 225;
                    Dgv_Attachment.Columns[2].Width = 210;
                    Dgv_Attachment.Columns[3].Width = 150;
                    Dgv_Attachment.Columns[4].Width = 150;
                    Dgv_Attachment.Columns[5].Width = 10;
                    Dgv_Attachment.Rows[i].Cells[0].Value = PappyjoeMVC.Properties.Resources.erase_icon;
                    Dgv_Attachment.Rows[i].Height = 85;
                    if (File.Exists(paths + path) == true)
                    {
                        if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
                        {
                            try
                            {
                                using (FileStream stream = new FileStream(paths + path, FileMode.Open, FileAccess.Read))
                                {
                                    Image image = Image.FromStream(stream);
                                    stream.Dispose();
                                    Dgv_Attachment.Rows[i].Cells[6].Value = image;
                                }
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else if (ext.ToLower() == ".docx" || ext.ToLower() == ".doc")
                        {
                            Dgv_Attachment.Rows[i].Cells[6].Value = PappyjoeMVC.Properties.Resources.word_doc_icon;
                        }
                        else if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
                        {
                            Dgv_Attachment.Rows[i].Cells[6].Value = PappyjoeMVC.Properties.Resources.excel_doc_icon;
                        }
                        else if (ext.ToLower() == ".pdf")
                        {
                            Dgv_Attachment.Rows[i].Cells[6].Value = PappyjoeMVC.Properties.Resources.pdf;
                        }
                    }
                    else
                    {
                        Dgv_Attachment.Rows[i].Cells[6].Value = PappyjoeMVC.Properties.Resources.no_image_icon_6;
                    }
                }
            }
            else
            {
                if (Dgv_Attachment.Rows.Count <= 0)
                {
                    Lab_Msg.Show();
                    Lab_Msg.Location = new System.Drawing.Point(134, 177);
                }
                else
                {
                    Lab_Msg.Hide();
                    Lab_Msg.Location = new System.Drawing.Point(134, 177);
                }
            }
        }

        public void fill_DgvCategory(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    Dgv_Category.Rows.Add();
                    Dgv_Category.Rows[0].Cells["colid"].Value = 0;
                    Dgv_Category.Rows[0].Cells["ColCategory"].Value = "All Category";
                    Dgv_Category.Rows[0].Cells["ColEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    Dgv_Category.Rows[0].Cells["ColDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    for (int i = 1; i < dtb.Rows.Count + 1; i++)
                    {
                        Dgv_Category.Rows.Add();
                        Dgv_Category.Rows[i].Cells["colid"].Value = dtb.Rows[i - 1]["id"].ToString();
                        Dgv_Category.Rows[i].Cells["ColCategory"].Value = dtb.Rows[i - 1]["CategoryName"].ToString();
                        Dgv_Category.Rows[i].Cells["ColEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                        Dgv_Category.Rows[i].Cells["ColDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void privillage_A(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string id = dt.Rows[0][0].ToString();
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Attachment", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new Add_Attachments();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    form2.Show();
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                this.cm.privillage_A(doctor_id);
            }
            else
            {
                var form2 = new Add_Attachments();
                form2.doctor_id = doctor_id;
                form2.patient_id = patient_id;
                Add_Attachments_controller ctrlr = new Add_Attachments_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void Attachments_Load(object sender, EventArgs e)
        {
            this.ctrlr.selid(doctor_id);
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            toolStripButton1.Text =  this.ctrlr.Load_CompanyName();
            this.ctrlr.Get_DoctorName(doctor_id);
            txt_Category.Visible = false;
            lab_Category.Visible = false;
            btn_CategoryAdd.Visible = false;
            Btn_CategoryClose.Visible = false;
            btn_CategoryAdd.Location = new Point(138, 70);
            Dgv_Category.Location = new Point(0, 45);
            this.ctrlr.getcategory();
            this.ctrlr.getpatdetails(patient_id);
            this.m.getpayment(patient_id);
            this.ctrlr.getattachment();
        }
        public void doctr_privillage_for_addnewPatient(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string id = dt.Rows[0][0].ToString();
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new AddNewPatients();
                    form2.doctor_id = doctor_id;
                    form2.Show();
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                }
            }
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                this.cm.doctr_privillage_for_addnewPatient(doctor_id);
            }
            else
            {
                var form2 = new AddNewPatients();
                form2.doctor_id = doctor_id;
                form2.Show();
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
            }
        }

        private void btn_CategoryAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Category.Text != "")
                {
                    Lab_Msg1.Visible = false;
                    if (btn_CategoryAdd.Text == "Save")
                    {
                        int i = this.ctrlr.inscatgry();
                        if (i > 0)
                        {
                            setcontrolls_aftersave();
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed !..", "Failed ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        btn_CategoryCancel.Visible = true;
                        int i = this.ctrlr.update();
                        if (i > 0)
                        {
                            setcontrolls_aftersave();
                            btn_CategoryAdd.Text = "Save";
                        }
                        else
                        {
                            MessageBox.Show("Updation failed !..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Lab_Msg1.Visible = true;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void setcontrolls_aftersave()
        {
            Dgv_Category.Rows.Clear();
            this.ctrlr.getcategory();
            txt_Category.Text = "";
            controll_visibility();
            Dgv_Category.Location = new Point(0, 45);
        }
        
        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            txt_Category.Visible = true;
            lab_Category.Visible = true;
            btn_CategoryAdd.Visible = true;
            Btn_CategoryClose.Visible = true;
            Dgv_Category.Location = new Point(0, 108);
        }

        private void btn_CategoryCancel_Click(object sender, EventArgs e)
        {
            btn_CategoryAdd.Text = "Save";
            txt_Category.Text = "";
            Lab_Msg1.Visible = false;
            btn_CategoryCancel.Visible = false;
            btn_CategoryAdd.Location = new Point(124, 70);
            btn_CategoryAdd.Visible = true;
        }

        private void Btn_CategoryClose_Click(object sender, EventArgs e)
        {
            controll_visibility();
        }
        public void controll_visibility()
        {
          
            Lab_Msg1.Visible = false;
            btn_CategoryCancel.Visible = false;
            txt_Category.Visible = false;
            lab_Category.Visible = false;
            btn_CategoryAdd.Visible = false;
            Dgv_Category.Location = new Point(0, 45);
            Btn_CategoryClose.Visible = false;
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.ctrlr.Patient_search(toolStripTextBox1.Text);

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

        private void Dgv_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cid;
                if (e.RowIndex > -1)
                {
                    Lab_Msg.Visible = false;
                    if (Dgv_Category.CurrentCell.OwningColumn.Name == "ColEdit")//&& 
                    {
                        cid = Dgv_Category.CurrentRow.Cells["colid"].Value.ToString();
                        if (cid != "")
                        {
                            if (Dgv_Category.CurrentRow.Cells["ColCategory"].Value.ToString() != "General" && Dgv_Category.CurrentRow.Cells["ColCategory"].Value.ToString() != "All Category")
                            {
                                txt_Category.Text = Dgv_Category.CurrentRow.Cells["ColCategory"].Value.ToString();
                                btn_CategoryAdd.Text = "Update";
                                btn_CategoryCancel.Visible = true;
                                btn_CategoryCancel.Location = new Point(138, 70);
                                btn_CategoryAdd.Location = new Point(74, 70);
                                Dgv_Category.Location = new Point(0, 108);
                                txt_Category.Visible = true;
                                lab_Category.Visible = true;
                                btn_CategoryAdd.Visible = true;
                                Btn_CategoryClose.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show("Can't update this category !...", "Can't update", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (Dgv_Category.CurrentCell.OwningColumn.Name == "ColDelete")
                    {
                        cid = Dgv_Category.CurrentRow.Cells["colid"].Value.ToString();
                        string name = Dgv_Category.CurrentRow.Cells["ColCategory"].Value.ToString();
                        int index = Dgv_Category.CurrentRow.Index;
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            if (name != "General" && name != "All Category")
                            {
                                this.ctrlr.delete();
                                Dgv_Category.Rows.RemoveAt(index);
                                Dgv_Category.Rows.Clear();
                                this.ctrlr.getcategory();
                            }
                            else
                            {
                                MessageBox.Show("Can't delete this category  !...", "Can't delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else if (Dgv_Category.CurrentCell.OwningColumn.Name == "ColCategory")
                    {
                        string name = Dgv_Category.CurrentRow.Cells["ColCategory"].Value.ToString();
                        {
                            if (name == "All Category")
                            {
                                Dgv_Attachment.Rows.Clear();
                                this.ctrlr.getattachment();

                            }
                            else
                            {
                                Dgv_Attachment.Rows.Clear();
                                this.ctrlr.getattachment2();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void getpath(string path1)
        {
            try
            {
                string realfile = "";
                string paths = this.ctrlr.getserver();
                if (path1 != "")
                {
                    realfile = paths + path1;
                    if (File.Exists(realfile) == true)
                    {
                        if (File_Type.ToLower() == ".jpeg" || File_Type.ToLower() == ".jpg" || File_Type.ToLower() == ".gif" || File_Type.ToLower() == ".png")
                        {
                            frmimagezoom frm = new frmimagezoom(attach_id);
                            frmimagezoom_controller controller = new frmimagezoom_controller(frm);
                            frm.ShowDialog(this);
                        }
                        else if (File_Type.ToLower() == ".docx" || File_Type.ToLower() == ".doc")
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                            saveFileDialog1.Filter = "Word Documents|*.doc | Word Documents 2010|*.docx";
                            saveFileDialog1.Title = "Save an Image File";
                            saveFileDialog1.ShowDialog();
                            if (saveFileDialog1.FileName != "")
                            { 
                                if (attach_id != 0)
                                {
                                    if (File.Exists(realfile))
                                    {
                                        System.IO.File.Copy(realfile, saveFileDialog1.FileName);
                                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("File Not Found", "Not Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        else if (File_Type.ToLower() == ".xls" || File_Type.ToLower() == ".xlsx")
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                            saveFileDialog1.Filter = "Excel Worksheets|*.xls | Excel Worksheets 2010|*.xlsx";
                            saveFileDialog1.Title = "Save an Image File";
                            saveFileDialog1.ShowDialog();
                            if (saveFileDialog1.FileName != "")
                            {
                                if (attach_id != 0)
                                {
                                    if (File.Exists(realfile))
                                    {
                                        System.IO.File.Copy(realfile, saveFileDialog1.FileName);
                                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("File Not Found", "Not Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        else if (File_Type.ToLower() == ".pdf")
                        {
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                            saveFileDialog1.Filter = "Pdf Files|*.pdf";
                            saveFileDialog1.Title = "Save an Image File";
                            saveFileDialog1.ShowDialog();
                            if (saveFileDialog1.FileName != "")
                            {
                                if (attach_id != 0)
                                {
                                    if (File.Exists(realfile))
                                    {
                                        System.IO.File.Copy(realfile, saveFileDialog1.FileName);
                                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("File Not Found", "Not Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Image Not Found", "Not Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_Attachment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string ext1 = "";
            attach_id = int.Parse(Dgv_Attachment.Rows[e.RowIndex].Cells[5].Value.ToString());
            ext1 = Dgv_Attachment.Rows[e.RowIndex].Cells[4].Value.ToString();
            File_Type = Path.GetExtension(ext1);
            if (e.ColumnIndex == 0)
            {
                if (APTDelete == true)
                {
                    DialogResult res = new System.Windows.Forms.DialogResult();
                    res = MessageBox.Show("Are you Sure You Want To Delete it?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        this.ctrlr.delattach();
                        Dgv_Attachment.Rows.Clear();
                        this.ctrlr.getattachment();
                    }
                }
            }
            else if (e.ColumnIndex == 6)
            {
                try
                {
                    this.ctrlr.getpath();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File loading error..", "File Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            profile_details_controller ctr = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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

        private void toolStripButton5_Click(object sender, EventArgs e)
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

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
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

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            profile_details_controller ctr = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Show_Appointment_controller controller = new Show_Appointment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Vital_Signs_controller controller = new Vital_Signs_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Clinical_Findings_controller controller = new Clinical_Findings_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new TreatmentPlans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            treatment_controller controller = new treatment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new FinishedProcedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            finishedprocedre_controller controller = new finishedprocedre_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            invoice_controller controller = new invoice_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Receipt_controller controller = new Receipt_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}

