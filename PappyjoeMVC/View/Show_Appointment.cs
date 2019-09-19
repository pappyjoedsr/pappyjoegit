using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Show_Appointment : Form
    {
        bool dltflag = false;
        bool Editflag = false;
        public static string apntid="";
        public string patient_id = "",doctor_id="",appointment_id="";
        Show_Appointment_controller ctrlr = new Show_Appointment_controller();
        public Show_Appointment()
        {
            InitializeComponent();
        }
        public void Get_Patient_Details(DataTable dt)
        {
            try
            {
                if (dt.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = dt.Rows[0]["pt_name"].ToString();
                }
                if (dt.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = dt.Rows[0]["pt_id"].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
       
        public void show(DataTable dt)
        {
            try
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dataGridView2.Rows.Add(dt.Rows[j]["id"].ToString(), dt.Rows[j]["a_id"].ToString(), "", "", dt.Rows[j]["pt_name"].ToString() + "\r\n" + "Patient Id  : " + dt.Rows[j]["pt_id"].ToString() + "\r\n" + "Mobile No:  " + dt.Rows[j]["primary_mobile_number"].ToString(), "DOCTOR" + "\r\n" + dt.Rows[j]["doctor_name"].ToString(), "APPOINTMENT " + "\r\n............................\r\n" + dt.Rows[j]["start_datetime"].ToString(),
                        "STATUS " + "\r\n....................\r\n" + dt.Rows[j]["status"].ToString(), "SCHEDULE " + "\r\n....................\r\n" + dt.Rows[j]["schedule"].ToString(), "WAITING  " + "\r\n....................\r\n" + dt.Rows[j]["waiting"].ToString(),
                        "ENGAGED " + "\r\n....................\r\n" + dt.Rows[j]["engaged"].ToString(), "CHECK OUT " + "\r\n....................\r\n" + dt.Rows[j]["checkout"].ToString(), "");
                    dataGridView2.Rows[j].Height = 70;
                    dataGridView2.Rows[j].Cells[2].Style.ForeColor = Color.FromArgb(34, 139, 34);
                    dataGridView2.Rows[j].Cells[2].Value = "Edit";
                    dataGridView2.Rows[j].Cells[3].Style.ForeColor = Color.FromArgb(255, 69, 0);
                    dataGridView2.Rows[j].Cells[3].Value = "Delete";
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Show_Appointment_Load(object sender, EventArgs e)
        {
            try
            {
                string doctr_id=this.ctrlr.privilege_A(doctor_id);
                if (doctr_id != "1")
                {
                btn_Add.Enabled = false;
                }
                else
                {
                btn_Add.Enabled = true;
                }
                DataTable ptntdtls=this.ctrlr.Get_Patient_Details(patient_id);
                Get_Patient_Details(ptntdtls);
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                DataTable cmpny=this.ctrlr.Get_CompanyNAme();
                if (cmpny.Rows.Count > 0)
                {
                  string clinicn = "";
                  clinicn = cmpny.Rows[0][0].ToString();
                  toolStripButton1.Text = clinicn.Replace("¤", "'");
                }
                string docname=this.ctrlr.Get_DoctorName(doctor_id);
                if (docname != "")
                {
                  toolStripTextDoctor.Text = "Logged In As : " + docname;
                }
                panelmain.Show();
                label41.Text = "APPOINTMENTS";
                dataGridView2.Width = 1040;
                dataGridView2.Height = 510;
                dataGridView2.Visible = true;
                dataGridView2.RowCount = 0;
                dataGridView2.Height = 404;
                dataGridView2.ColumnCount = 12;
                dataGridView2.ColumnHeadersVisible = false;
                dataGridView2.RowHeadersVisible = false;
                dataGridView2.Columns[0].Name = "id";
                dataGridView2.Columns[0].Width = 0;
                dataGridView2.Columns[1].Name = "id";
                dataGridView2.Columns[1].Width = 0;
                dataGridView2.Columns[2].Name = "edit";
                dataGridView2.Columns[2].Width = 40;
                dataGridView2.Columns[3].Name = "del";
                dataGridView2.Columns[3].Width = 40;
                dataGridView2.Columns[4].Name = "Name";
                dataGridView2.Columns[4].Width = 200;
                dataGridView2.Columns[5].Name = "payment";
                dataGridView2.Columns[5].Width = 200;
                dataGridView2.Columns[6].Name = "sum";
                dataGridView2.Columns[6].Width = 150;
                dataGridView2.Columns[7].Name = "sum";
                dataGridView2.Columns[7].Width = 75;
                dataGridView2.Columns[8].Name = "sum";
                dataGridView2.Columns[8].Width = 75;
                dataGridView2.Columns[9].Name = "sum";
                dataGridView2.Columns[9].Width = 75;
                dataGridView2.Columns[10].Name = "sum";
                dataGridView2.Columns[10].Width = 75;
                dataGridView2.Columns[11].Name = "sum";
                dataGridView2.Columns[11].Width = 75;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Visible = false;
                DataTable dt=this.ctrlr.show(patient_id);
                show(dt);
                if (dataGridView2.Rows.Count <= 0)
                {
                    Lab_Msg.Show();
                    Lab_Msg.Location = new System.Drawing.Point(146, 233);
                }
                else
                {
                    Lab_Msg.Hide();
                    Lab_Msg.Location = new System.Drawing.Point(146, 233);
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    apntid = this.dataGridView2.Rows[i].Cells[1].Value.ToString();
                }
                var form2 = new PappyjoeMVC.View.Add_Appointment();
                form2.patient_id = patient_id;
                form2.doctor_id = doctor_id;
                form2.appointment_id = apntid;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        public void Patient_search(DataTable dtb)
        {
            try
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
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable srch=this.ctrlr.Patient_search(toolStripTextBox1.Text);
            Patient_search(srch);
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
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
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
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
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
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
        try
        {
            string doctrid = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
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
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
            string doctrid=this.ctrlr.settingsprivilage(doctor_id);
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
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0 && e.ColumnIndex == 3)
                {
                    if (doctor_id != "1")
                    {
                        dltflag = false;
                    }
                    else
                    {
                        dltflag = true;
                    }
                    if (dltflag == false)
                    {
                        string doctr_id=this.ctrlr.privilege_D(doctor_id);
                        if (int.Parse(doctr_id) > 0)
                        {
                            dltflag = false;
                        }
                        else
                        {
                            dltflag = true;
                        }
                    }
                    if (dltflag == true)
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            string app_id = "0";
                            app_id = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                            this.ctrlr.delete(app_id);
                            dataGridView2.RowCount = 0;
                            dataGridView2.Height = 404;
                            dataGridView2.ColumnCount = 12;
                            dataGridView2.ColumnHeadersVisible = false;
                            dataGridView2.RowHeadersVisible = false;
                            dataGridView2.Columns[0].Name = "id";
                            dataGridView2.Columns[0].Width = 0;
                            dataGridView2.Columns[1].Name = "id";
                            dataGridView2.Columns[1].Width = 0;
                            dataGridView2.Columns[2].Name = "edit";
                            dataGridView2.Columns[2].Width = 40;
                            dataGridView2.Columns[3].Name = "del";
                            dataGridView2.Columns[3].Width = 40;
                            dataGridView2.Columns[4].Name = "Name";
                            dataGridView2.Columns[4].Width = 200;
                            dataGridView2.Columns[5].Name = "payment";
                            dataGridView2.Columns[5].Width = 200;
                            dataGridView2.Columns[6].Name = "sum";
                            dataGridView2.Columns[6].Width = 150;
                            dataGridView2.Columns[7].Name = "sum";
                            dataGridView2.Columns[7].Width = 75;
                            dataGridView2.Columns[8].Name = "sum";
                            dataGridView2.Columns[8].Width = 75;
                            dataGridView2.Columns[9].Name = "sum";
                            dataGridView2.Columns[9].Width = 75;
                            dataGridView2.Columns[10].Name = "sum";
                            dataGridView2.Columns[10].Width = 75;
                            dataGridView2.Columns[11].Name = "sum";
                            dataGridView2.Columns[11].Width = 75;
                            dataGridView2.Columns[0].Visible = false;
                            dataGridView2.Columns[1].Visible = false;
                            DataTable dt=this.ctrlr.show(patient_id);
                            show(dt);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Delete Appointment", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else if (dataGridView2.Rows.Count > 0 && e.ColumnIndex == 2)
                {
                    if (doctor_id != "1")
                    {
                        Editflag = false;
                    }
                    else
                    {
                        Editflag = true;
                    }
                    if (Editflag == false)
                    {
                        string id;
                        id = this.ctrlr.privilege_E(doctor_id);
                        if (int.Parse(id) > 0)
                        {
                            Editflag = false;
                        }
                        else
                        {
                            Editflag = true;
                        }
                    }
                    if (Editflag == true)
                    {
                        var form2 = new PappyjoeMVC.View.Add_Appointment();
                        form2.patient_id = patient_id;
                        form2.doctor_id = doctor_id;
                        form2.appointment_id = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Edit Appointment", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
