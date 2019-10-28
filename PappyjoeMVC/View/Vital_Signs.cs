using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Vital_Signs : Form
    {
        Vital_Signs_controller cntrl=new Vital_Signs_controller();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        double weight;
        double height;
        string gender;
        double BMI;
        public Vital_Signs()
        {
            InitializeComponent();
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Add_Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
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
                        form2.ShowDialog();
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
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = this.cntrl.permission_for_settings(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        var form2 = new PappyjoeMVC.View.Practice_Details();
                        form2.doctor_id = doctor_id;
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolStripTextBox1.Text != "")
                {
                    DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
                    listpatientsearch.DataSource = dtdr;
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
                    listpatientsearch.Location = new System.Drawing.Point(toolStrip1.Width - 350, 38);
                }
                else
                {
                    listpatientsearch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Show();
        }

        private void Vital_Signs_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                toolStripButton8.ToolTipText = "Settings";
                toolStripDropDownButton1.ToolTipText = "Add New";
                DataTable clinicname = this.cntrl.Get_CompanyNAme();
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0]["name"].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                }
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                DataTable rs_patients = this.cntrl.Get_patient_id_name_gender(patient_id);
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                dataGridView_invoice.Show();
                dataGridView_invoice.ColumnCount = 4;
                dataGridView_invoice.Columns[0].Width = 225;
                dataGridView_invoice.Columns[1].Width = 15;
                dataGridView_invoice.Columns[2].Width = 250;
                dataGridView_invoice.Columns[3].Width = 900;
                dataGridView_invoice.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView_invoice.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DataTable vital = this.cntrl.vital(patient_id);
                if (vital.Rows.Count > 0)
                {
                    int i = 0;
                    for (int j = 0; j < vital.Rows.Count; j++)
                    {
                        dataGridView_invoice.Rows.Add(String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(vital.Rows[j]["date"].ToString())), "", "", "");
                        dataGridView_invoice.Rows.Add("", "", "", "");
                        dataGridView_invoice.Rows[i].Cells[0].Style.BackColor = Color.Gray;
                        dataGridView_invoice.Rows[i].Cells[1].Style.BackColor = Color.Gray;
                        dataGridView_invoice.Rows[i].Cells[2].Style.BackColor = Color.Gray;
                        dataGridView_invoice.Rows[i].Cells[3].Style.BackColor = Color.Gray;
                        dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.White;
                        dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        i = i + 1;
                        if (vital.Rows[j]["pulse"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("PULSE ", ":", vital.Rows[j]["pulse"].ToString(), "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["temp"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("TEMPERATURE ", ":", vital.Rows[j]["temp"].ToString() + " ( " + vital.Rows[j]["temp_type"].ToString() + " ) ", "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["bp_syst"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("BLOOD PRESSURE ( SYSTOLIC ) ", ":", vital.Rows[j]["bp_syst"].ToString() + " ( " + vital.Rows[j]["bp_type"].ToString() + " ) ", "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["bp_dia"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("BLOOD PRESSURE ( DIASTOLIC )  ", ":", vital.Rows[j]["bp_dia"].ToString() + " ( " + vital.Rows[j]["bp_type"].ToString() + " ) ", "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["Height"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("HEIGHT  ", ":", vital.Rows[j]["Height"].ToString() + "(Cm)", "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["weight"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("WEIGHT  ", ":", vital.Rows[j]["weight"].ToString() + "(Kg)", "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["resp"].ToString() != "")
                        {
                            dataGridView_invoice.Rows.Add("RESPIRATORY RATE ", ":", vital.Rows[j]["resp"].ToString(), "");
                            i = i + 1;
                            dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                            dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                            dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        }
                        if (vital.Rows[j]["weight"].ToString() != null && vital.Rows[j]["weight"].ToString() != "" && vital.Rows[j]["Height"].ToString() != null && vital.Rows[j]["Height"].ToString() != "")
                        {
                            weight = Convert.ToDouble(vital.Rows[j]["weight"].ToString());
                            height = Convert.ToDouble(vital.Rows[j]["Height"].ToString());
                        }
                        else
                        {
                            weight = Convert.ToDouble("0.00");
                            height = Convert.ToDouble("0.00");
                        }
                        gender = rs_patients.Rows[0]["gender"].ToString();
                        string msg = "";
                        if (weight > 0 && height > 0)
                        {
                            BMI = Math.Round((weight / (height * height)) * 10000, 1);
                            if (BMI != null)
                            {
                                if (BMI < 19 && gender == "Female")
                                {
                                    msg = "BMI is low";
                                }
                                if (BMI >= 19 & BMI <= 24 & gender == "Female")
                                {
                                    msg = "Normal";
                                }
                                if (BMI > 24 & gender == "Female")
                                {
                                    msg = "BMI is High";
                                }
                                if (BMI < 20 & gender == "Male")
                                {
                                    msg = "BMI is low";
                                }
                                if (BMI >= 20 & BMI <= 25 & gender == "Male")
                                {
                                    msg = "Normal";
                                }
                                if (BMI > 25 & gender == "Male")
                                {
                                    msg = "BMI is High";
                                }
                            }
                            if (BMI > 0)
                            {
                                dataGridView_invoice.Rows.Add("BMI(BOADY MASS INDEX) ", ":", BMI + "  ,   " + msg, "");
                                i = i + 1;
                                if (msg == "BMI is low")
                                    dataGridView_invoice.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                                else if (msg == "Normal")
                                    dataGridView_invoice.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                                else if (msg == "BMI is High")
                                    dataGridView_invoice.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                                dataGridView_invoice.Rows[i].Cells[0].Style.ForeColor = Color.DimGray;
                                dataGridView_invoice.Rows[i].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                                dataGridView_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                                dataGridView_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                            }
                        }
                        dataGridView_invoice.Rows.Add("Recorded By : Dr." + vital.Rows[j]["dr_name"].ToString(), "", "", "");
                        dataGridView_invoice.Rows[i + 1].Cells[0].Style.ForeColor = Color.Red;
                        dataGridView_invoice.Rows[i + 1].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Italic);
                        i = i + 2;
                    }
                }
                if (dataGridView_invoice.Rows.Count <= 0)
                {
                    Lab_Msg.Show();
                    Lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                else
                {
                    Lab_Msg.Hide();
                    Lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                if (PappyjoeMVC.Model.Connection.MyGlobals.Staff_id != "")
                {
                    btn_ADD.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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
        private void labelsms_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
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
            form2.patient_id = patient_id; ;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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

        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
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

        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.privilge_for_inventory(doctor_id);
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

        private void labl_Lab_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.LabWorks();
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
    }
}
