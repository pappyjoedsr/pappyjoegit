using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class FinishedProcedure : Form,finishedprocedure_interface
    {
        public string patient_id = "0";
        public string doctor_id = "";
        int btnEnabled = 0;
        string treatment_complete_id = "0";
        finishedprocedre_controller cntrl;
        //common_model cmodel = new common_model();
        public FinishedProcedure()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var form2 = new AddFinishedprocedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            addfinsed_treatment_controller controller = new addfinsed_treatment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        public void Setcontroller(finishedprocedre_controller controller)
        {
            cntrl = controller;
        }

        private void FinishedProcedure_Load(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string privid;
                privid = this.cntrl.Add_privilliege(doctor_id);
                if (int.Parse(privid) > 0)
                {
                    btn_Add.Enabled = true;
                }
                else
                {
                    btn_Add.Enabled = false;
                }
                privid = this.cntrl.edit_privillege(doctor_id);
                if (int.Parse(privid) > 0)
                {
                    editToolStripMenuItem1.Enabled = true;
                }
                else
                {
                    editToolStripMenuItem1.Enabled = false;
                }
                privid = this.cntrl.delete_privillage(doctor_id);
                if (int.Parse(privid) > 0)
                {
                    deleteToolStripMenuItem1.Enabled = true;
                }
                else
                {
                    deleteToolStripMenuItem1.Enabled = false;
                }
            }
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
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
            System.Data.DataTable rs_patients = this.cntrl.Get_Patient_id_NAme(patient_id);
            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
            {
                linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
            }
            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
            {
                linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
            }
            dgv_treatment_paln.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv_treatment_paln.ColumnHeadersVisible = false;
            dgv_treatment_paln.RowHeadersVisible = false;
            dgv_treatment_paln.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_treatment_paln.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_treatment_paln.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.cntrl.get_completed_id_date(patient_id);
        }

        public void Load_Data(DataTable dt_pt_main)
        {
            try
            {
                int i = 0;
                if(dt_pt_main.Rows.Count>0)
                {
                    for (int j = 0; j < dt_pt_main.Rows.Count; j++)
                    {
                        dgv_treatment_paln.Rows.Add("", "", String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pt_main.Rows[j]["completed_date"].ToString())), "", "", "", "", "0");
                        dgv_treatment_paln.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                        dgv_treatment_paln.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                        dgv_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                        dgv_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        dgv_treatment_paln.Rows.Add("", "", "TREATMENTS", "COST", "DISCOUNT", "TOTAL", "NOTE", "0");
                        dgv_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.gry;
                        dgv_treatment_paln.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        dgv_treatment_paln.Rows[i].Cells[2].Style.ForeColor = Color.White;
                        dgv_treatment_paln.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dgv_treatment_paln.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        dgv_treatment_paln.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dgv_treatment_paln.Rows[i].Cells[4].Style.ForeColor = Color.White;
                        dgv_treatment_paln.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dgv_treatment_paln.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        dgv_treatment_paln.Rows[i].Cells[6].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dgv_treatment_paln.Rows[i].Cells[6].Style.ForeColor = Color.White;
                        dgv_treatment_paln.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                        dgv_treatment_paln.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                        dgv_treatment_paln.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                        dgv_treatment_paln.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                        dgv_treatment_paln.Rows[i].Cells[5].Style.BackColor = Color.DarkGray;
                        dgv_treatment_paln.Rows[i].Cells[6].Style.BackColor = Color.DarkGray;
                        dgv_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.gry;
                        dgv_treatment_paln.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_treatment_paln.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_treatment_paln.Rows[i].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        foreach (DataGridViewColumn column in dgv_treatment_paln.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        System.Data.DataTable dt_pt_sub = this.cntrl.get_completed_details(dt_pt_main.Rows[j]["id"].ToString());
                        Double totalEst = 0;
                        for (int k = 0; k < dt_pt_sub.Rows.Count; k++)
                        {
                            string discount_string = "";
                            if (dt_pt_sub.Rows[k]["discount_type"].ToString() == "INR")
                            {
                                discount_string = "";
                            }
                            else
                            {
                                discount_string = "(" + dt_pt_sub.Rows[k]["discount"].ToString() + "%)";
                            }
                            Decimal totalcost = Convert.ToDecimal(dt_pt_sub.Rows[k]["cost"].ToString()) * Convert.ToDecimal(dt_pt_sub.Rows[k]["quantity"].ToString());
                            i = i + 1;
                            dgv_treatment_paln.Rows.Add(dt_pt_sub.Rows[k]["id"].ToString(), "", dt_pt_sub.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discount_inrs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), dt_pt_sub.Rows[k]["note"].ToString() + " " + dt_pt_sub.Rows[k]["tooth"].ToString() + "(Finished by- Dr." + dt_pt_sub.Rows[k]["doctor_name"].ToString() + ")", dt_pt_sub.Rows[k]["status"].ToString());
                            dgv_treatment_paln.Rows[i].Height = 30;
                            if (dt_pt_sub.Rows[k]["status"].ToString() == "0")
                            {
                                dgv_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.billed;
                            }
                            else
                            {
                                dgv_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.Borderblank;
                            }
                            totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());
                            dgv_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.Bill;

                            dgv_treatment_paln.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv_treatment_paln.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgv_treatment_paln.Rows[i].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        i = i + 1;
                        dgv_treatment_paln.Rows.Add("", "", "", "", "", "", "", "0");
                        dgv_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                        dgv_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                    }
                }
                if (dgv_treatment_paln.Rows.Count <= 0)
                {
                    lab_Msg.Show();
                    lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                else
                {
                    lab_Msg.Hide();
                    lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_treatment_paln_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_treatment_paln.Rows.Count > 0 && (dgv_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "1" || dgv_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "2"))
                {
                    if (e.ColumnIndex == 1)
                    {
                        if (dgv_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "1")
                        {
                            btnEnabled = btnEnabled + 1;
                            dgv_treatment_paln.Rows[e.RowIndex].Cells[7].Value = "2";
                            dgv_treatment_paln.Rows[e.RowIndex].Cells[1].Value = PappyjoeMVC.Properties.Resources.Bordertick;
                        }
                        else if (dgv_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "2")
                        {
                            btnEnabled = btnEnabled - 1;
                            dgv_treatment_paln.Rows[e.RowIndex].Cells[7].Value = "1";
                            dgv_treatment_paln.Rows[e.RowIndex].Cells[1].Value = PappyjoeMVC.Properties.Resources.Borderblank;
                        }
                        if (btnEnabled > 0)
                        {
                            btn_InvoiceSelectTemnt.Enabled = true;
                        }
                        else
                        {
                            btn_InvoiceSelectTemnt.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_treatment_paln_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentMouseOverRow = dgv_treatment_paln.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dgv_treatment_paln.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 8)
                    {
                        if (dgv_treatment_paln.Rows[currentMouseOverRow].Cells[0].Value.ToString() != "")
                        {
                            if (dgv_treatment_paln.Rows[currentMouseOverRow].Cells[7].Value.ToString() == "0")
                            {
                                treatment_complete_id = dgv_treatment_paln.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                                deleteToolStripMenuItem1.Enabled = false;
                                contextMenuStrip1.Show(dgv_treatment_paln, new System.Drawing.Point(881 - 120, e.Y));
                            }
                            else if (dgv_treatment_paln.Rows[currentMouseOverRow].Cells[7].Value.ToString() == "1" || dgv_treatment_paln.Rows[currentMouseOverRow].Cells[7].Value.ToString() == "2")
                            {
                                treatment_complete_id = dgv_treatment_paln.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                                contextMenuStrip1.Show(dgv_treatment_paln, new System.Drawing.Point(881 - 120, e.Y));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = this.cntrl.delete_privillage(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Delete Finished Procedure", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        dlt_privilage();
                    }
                }
                else
                {
                    dlt_privilage();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void dlt_privilage()
        {
            if (treatment_complete_id != "0")
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes) 
                {
                    System.Data.DataTable dt_pt_complete = this.cntrl.get_plamManin_id(treatment_complete_id);
                    string completed_main_id = "0";
                    string plan_main_id = "0";
                    if (dt_pt_complete.Rows.Count > 0)
                    {
                        completed_main_id = dt_pt_complete.Rows[0]["plan_main_id"].ToString();
                        plan_main_id = dt_pt_complete.Rows[0]["completed_id"].ToString();
                    }
                    this.cntrl.delete(treatment_complete_id);
                    this.cntrl.update_status1(plan_main_id);
                    System.Data.DataTable dt_pt_complete2 = this.cntrl.chek_planmain_id(completed_main_id);
                    if (dt_pt_complete2.Rows.Count == 0)
                    {
                        this.cntrl.delete_completedid(completed_main_id);
                    }
                    dgv_treatment_paln.RowCount = 0;
                    dgv_treatment_paln.ColumnHeadersVisible = false;
                    dgv_treatment_paln.RowHeadersVisible = false;
                    dgv_treatment_paln.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_treatment_paln.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_treatment_paln.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.cntrl.get_completed_id_date(patient_id);
                }
            }
        }

        private void btn_InvoiceSelectTemnt_Click(object sender, EventArgs e)
        {
            try
            {
                int rec_count = 0;
                string a_plan_id = "";
                for (int i = 0; i < dgv_treatment_paln.Rows.Count; i++)
                {
                    if (dgv_treatment_paln.Rows[i].Cells[7].Value.ToString() == "2")
                    {
                        rec_count = rec_count + 1;
                        a_plan_id = a_plan_id + "," + dgv_treatment_paln.Rows[i].Cells[0].Value.ToString();
                    }
                }
                if (rec_count != 0)
                {
                    a_plan_id = a_plan_id.Substring(1, a_plan_id.Length - 1);
                    var form2 = new Add__invoice();
                    form2.patient_id = patient_id;
                    form2.doctor_id = doctor_id;
                    form2.complete_proce_id = a_plan_id;
                    Add_invoice_controller controller = new Add_invoice_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select the Treatment..", "No Data To add !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 352, 39);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
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
                id = this .cntrl.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new PracticeDetails();
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
                var form2 = new PracticeDetails();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
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
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            //Reports_controller controller = new Reports_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            //expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                //doctor_controller controlr = new doctor_controller(form2);
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

        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void lab_Vitalsigns_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            //Vital_Signs_controller controller = new Vital_Signs_controller(form2);
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
            //Clinical_Findings_controller controller = new Clinical_Findings_controller(form2);
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
        private void labl_Lab_Click(object sender, EventArgs e)
        {
        }
    }
}
