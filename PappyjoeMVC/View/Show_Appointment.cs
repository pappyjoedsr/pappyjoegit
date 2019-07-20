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
    public partial class Show_Appointment : Form,Show_Appointment_interface
    {
        bool dltflag = false;
        bool Editflag = false;
        common_model cmdl = new common_model();
        Show_Appointment_model mdl = new Show_Appointment_model();
        public string pat_id = "",doctor_id="";
        public Show_Appointment()
        {
            InitializeComponent();
        }
        Show_Appointment_controller ctrlr;
        public void setController(Show_Appointment_controller controller)
        {
            ctrlr = controller;
        }
        public string apid
        {
            get { return this.dataGridView2.Rows[0].Cells[1].Value.ToString(); }
            set { this.dataGridView2.Rows[0].Cells[1].Value = value; }
        }
        public string patient_id
        {
            get { return pat_id; }
            set { pat_id = value; }
        }
        public void privilege_A(string doctor_id)
        {
            if (doctor_id != "1")
            {
              btn_Add.Enabled = false;
            }
            else
            {
             btn_Add.Enabled = true;
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
        public void Get_DoctorName(DataTable dt1)
        {
            if (dt1.Rows.Count > 0)
            {
                toolStripTextDoctor.Text = "Logged In As : " + dt1.Rows[0][0].ToString();
            }
        }
        public void show(DataTable dt)
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
        public void getdays(DataTable dt)
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
            catch(Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Show_Appointment_Load(object sender, EventArgs e)
        {
            if(doctor_id!="1")
            {
                this.ctrlr.privilege_A(doctor_id);
            }
               
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                this.ctrlr.Get_CompanyNAme();
                this.ctrlr.Get_DoctorName(doctor_id);
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
                this.ctrlr.show(patient_id);
                this.ctrlr.getdays(patient_id);
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
        private void btn_Add_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Add_Appointment();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            Add_Appointment_controller ctrlr = new Add_Appointment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 350, 43);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.ctrlr.Patient_search(toolStripTextBox1.Text);
        }
        public void privilege_D(string doctor_id)
        {
            string id;
            id = doctor_id;
            if (int.Parse(id) > 0)
            {
                dltflag = false;
            }
            else
            {
                dltflag = true;
            }
        }
        public void privilege_E(string doctor_id)
        {
            string id;
            id = doctor_id;
            if(int.Parse(id) > 0)
             {
              Editflag = false;
             }
             else
             {
              Editflag = true;
             }
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

        private void labelallpatient_Click(object sender, EventArgs e)
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

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            expense_controller controller = new expense_controller(form2);
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

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            profile_details_controller controller = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            profile_details_controller controller = new profile_details_controller(form2);
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

        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Attachments_controller controller = new Attachments_controller(form2);
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

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new AddNewPatients();
                    form2.doctor_id = doctor_id;
                    AddNew_patient_controller controller = new AddNew_patient_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new AddNewPatients();
                form2.doctor_id = doctor_id;
                AddNew_patient_controller controller = new AddNew_patient_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new PracticeDetails();
                    form2.doctor_id = doctor_id;
                    Practice_Controller controller = new Practice_Controller(form2);
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
                var form2 = new PracticeDetails();
                form2.doctor_id = doctor_id;
                Practice_Controller controller = new Practice_Controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
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

        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Ledger_controller controller = new Ledger_controller(form2);
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

        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new prescriptionShow();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            prescriptionshow_controller controller = new prescriptionshow_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
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
                    this.ctrlr.privilege_D(doctor_id);
                }
                if (dltflag == true)
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        string app_id = "0";
                        app_id = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                        this.ctrlr.delete();
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
                        this.ctrlr.show(patient_id);
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
                    this.ctrlr.privilege_E(doctor_id);
                }
                if (Editflag == true)
                {
                    var form2 = new PappyjoeMVC.View.Add_Appointment();
                    form2.patient_id = patient_id;
                    form2.doctor_id = doctor_id;
                    form2.appointment_id = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Add_Appointment_controller ctrlr = new Add_Appointment_controller(form2);
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
    }
}
