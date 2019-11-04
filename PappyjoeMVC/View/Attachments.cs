using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Attachments : Form
    {
        public int attach_id;
        public bool APTDelete = false;
        public string doctor_id = "", privid = "", dctr = "", File_Type = "", patient_id = "";
        Attachments_controller ctrlr = new Attachments_controller();
        public Attachments()
        {
            InitializeComponent();
        }
        public void privillage_A(string id)
        {
            if (doctor_id != "1")
            {
                string privid;
                privid = id;
                if (int.Parse(privid) > 0)
                {
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                }
            }
            else
            {
                string previd = this.ctrlr.getprevid(doctor_id);
                getprevid(previd);
            }
        }
        public void getprevid(string id)
        {
            privid = id;
            if (int.Parse(privid) > 0)
            {
                APTDelete = false;
            }
            else
            {
                APTDelete = true;
            }
        }
        public void Get_DoctorName(string dt1)
        {
            if (dt1 != "")
            {
                dctr = dt1;
                toolStripTextDoctor.Text = "Logged In As : " + dt1;
            }
        }
        public void GetCategory(DataTable dtb)
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
        public void GetPatientDetails(DataTable dt)
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.ctrlr.privillage_A(doctor_id);
                if (id != "")
                {
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Add Attachment", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var form2 = new Add_Attachments();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = patient_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                }
            }
            else
            {
                var form2 = new Add_Attachments();
                form2.doctor_id = doctor_id;
                form2.patient_id = patient_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        public void getattachment(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                FillAttachmentGrid(dt);
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
        public void getattachment2(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Lab_Msg.Visible = false;
                FillAttachmentGrid(dt);
            }
            else
            {
                int x = (panel7.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
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
                    string paths = this.ctrlr.getserver();
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
                        int i = this.ctrlr.inscatgry(txt_Category.Text);
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
                        int i = this.ctrlr.update(txt_Category.Text, Dgv_Category.CurrentRow.Cells["colid"].Value.ToString());
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
        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            txt_Category.Visible = true;
            lab_Category.Visible = true;
            btn_CategoryAdd.Visible = true;
            Btn_CategoryClose.Visible = true;
            Dgv_Category.Location = new Point(0, 100);
        }
        private void Btn_CategoryClose_Click(object sender, EventArgs e)
        {
            controll_visibility();
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
                                this.ctrlr.delete(cid);
                                Dgv_Category.Rows.RemoveAt(index);
                                Dgv_Category.Rows.Clear();
                                DataTable dt = this.ctrlr.GetCategory();
                                GetCategory(dt);
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
                                DataTable dt = this.ctrlr.getattachment(patient_id);
                                getattachment(dt);
                            }
                            else
                            {
                                Dgv_Attachment.Rows.Clear();
                                DataTable dt = this.ctrlr.getattachment2(patient_id, name);
                                getattachment2(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void Attachments_Load(object sender, EventArgs e)
        {
            string id = this.ctrlr.privillage_A(doctor_id);
            privillage_A(id);
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            toolStripButton1.Text = this.ctrlr.Load_CompanyName();
            dctr = this.ctrlr.Get_DoctorName(doctor_id);
            if (dctr != "")
            {
                toolStripTextDoctor.Text = "Logged In As : " + dctr;
            }
            txt_Category.Visible = false;
            lab_Category.Visible = false;
            btn_CategoryAdd.Visible = false;
            Btn_CategoryClose.Visible = false;
            btn_CategoryAdd.Location = new Point(138, 70);
            Dgv_Category.Location = new Point(0, 45);
            DataTable catgry = this.ctrlr.GetCategory();
            GetCategory(catgry);
            DataTable patnt = this.ctrlr.GetPatientDetails(patient_id);
            GetPatientDetails(patnt);
            string pay = this.ctrlr.GetPayment(patient_id);
            if (pay != "")
            {
                label8.Text = pay + " due";
            }
            DataTable attach = this.ctrlr.getattachment(patient_id);
            getattachment(attach);
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
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.ctrlr.privilge_for_inventory(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
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
        private void toolStripButton7_Click(object sender, EventArgs e)
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
        public void doctr_privillage_for_addnewPatient(string patnt)
        {
            if (patnt != "")
            {
                string id = patnt;
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog(); ;
                }
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string prvlge = this.ctrlr.settingsprivilage(doctor_id);
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
        public void setcontrolls_aftersave()
        {
            Dgv_Category.Rows.Clear();
            DataTable catgry = this.ctrlr.GetCategory();
            GetCategory(catgry);
            txt_Category.Text = "";
            controll_visibility();
            Dgv_Category.Location = new Point(0, 45);
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
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
        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labl_Lab_Click(object sender, EventArgs e)
        {
            var form2 = new LabWorks();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtb = this.ctrlr.Patient_search(toolStripTextBox1.Text);
            Patient_search(dtb);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 365, 32);
            }
            else
            {
                listpatientsearch.Visible = false;
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
                        this.ctrlr.delattach(attach_id);
                        Dgv_Attachment.Rows.Clear();
                        DataTable dtb = this.ctrlr.getattachment(patient_id);
                        getattachment(dtb);
                    }
                }
            }
            else if (e.ColumnIndex == 6)
            {
                try
                {
                    string path = this.ctrlr.getpath(attach_id);
                    getpath(path);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                            Image_Zoom frm = new Image_Zoom();
                            frm.attach_id = attach_id;
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
    }
}

