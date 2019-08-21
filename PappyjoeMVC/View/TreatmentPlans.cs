using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class TreatmentPlans : Form,treatment_interface
    {
        treatment_controller cntrl;
        Connection db = new Connection();common_model cmodel = new common_model();
        public string doctor_id = "";
        public string patient_id = "";
        string logo_name = "";
        string path = "";
        int btnEnabled = 0;
        string treatment_plan_id = "0";
        public TreatmentPlans()
        {
            InitializeComponent();
        }
        public void SetController(treatment_controller controller)
        {
            cntrl = controller;
        }
        private void TreatmentPlans_Load(object sender, EventArgs e)
        {
             if (doctor_id != "1")
            {
                string privid;
                privid = this.cntrl.check_privillege(doctor_id);
                if (int.Parse(privid) > 0)
                {
                    BtnAdd.Enabled = false;
                }
                else
                {
                    BtnAdd.Enabled = true;
                }
                //..Edit
                privid = this.cntrl.check_edit_privillege(doctor_id);
                if (int.Parse(privid) > 0)
                {
                    editToolStripMenuItem1.Enabled = false;
                }
                else
                {
                    editToolStripMenuItem1.Enabled = true;
                }
                //Delete
                privid = this.cntrl.delete_privillege(doctor_id);
                if (int.Parse(privid) > 0)
                {
                    deleteToolStripMenuItem1.Enabled = false;
                }
                else
                {
                    deleteToolStripMenuItem1.Enabled = true;
                }
            }
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            DataTable clinicname = cmodel.Get_CompanyNAme();
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
                path = clinicname.Rows[0]["path"].ToString();
                string docnam = cmodel.Get_DoctorName(doctor_id);
                if (docnam!="")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                if (path != "")
                {
                    if (File.Exists(db.server() + path))
                    {
                        logo_name = "";
                        logo_name = path;
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        if (!File.Exists(Apppath + "\\" + logo_name))
                        {
                            System.IO.File.Copy(db.server() + path, Apppath + "\\" + logo_name);
                        }
                    }
                    else
                    {
                        logo_name = "";
                    }
                }
            }
            System.Data.DataTable rs_patients = cmodel.Get_Patient_Details(patient_id);
            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
            {
                linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
            }
            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
            {
                linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
            }
            dataGridView1_treatment_paln.ColumnHeadersVisible = false;
            dataGridView1_treatment_paln.RowHeadersVisible = false;
            dataGridView1_treatment_paln.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1_treatment_paln.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1_treatment_paln.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1_treatment_paln.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.cntrl.get_treatments(patient_id);
        }
        public void load_treatment(DataTable dt_pt_main)
        {
            try
            {
                if (dt_pt_main.Rows.Count > 0)
                {
                    int i = 0;
                    for (int j = 0; j < dt_pt_main.Rows.Count; j++)
                    {
                        dataGridView1_treatment_paln.Rows.Add("0", "", String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pt_main.Rows[j]["date"].ToString())), "", "", "", "", "0");
                        dataGridView1_treatment_paln.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                        dataGridView1_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                        dataGridView1_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        dataGridView1_treatment_paln.Rows.Add(dt_pt_main.Rows[j]["id"].ToString(), "", "TREATMENTS", "COST", "DISCOUNT", "TOTAL", "NOTE", "0", "");
                        dataGridView1_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.gry;
                        dataGridView1_treatment_paln.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[2].Style.ForeColor = Color.White;
                        dataGridView1_treatment_paln.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        dataGridView1_treatment_paln.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[4].Style.ForeColor = Color.White;
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        dataGridView1_treatment_paln.Rows[i].Cells[6].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[6].Style.ForeColor = Color.White;
                        dataGridView1_treatment_paln.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                        dataGridView1_treatment_paln.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                        dataGridView1_treatment_paln.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                        dataGridView1_treatment_paln.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.BackColor = Color.DarkGray;
                        dataGridView1_treatment_paln.Rows[i].Cells[6].Style.BackColor = Color.DarkGray;
                        dataGridView1_treatment_paln.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1_treatment_paln.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.Bill;
                        DataTable dt_pt_sub = this.cntrl.treatment_sub_details(dt_pt_main.Rows[j]["id"].ToString());
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
                            dataGridView1_treatment_paln.Rows.Add(dt_pt_sub.Rows[k]["id"].ToString(), "", dt_pt_sub.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discount_inrs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), dt_pt_sub.Rows[k]["note"].ToString() + " " + dt_pt_sub.Rows[k]["tooth"].ToString(), dt_pt_sub.Rows[k]["status"].ToString());
                            dataGridView1_treatment_paln.Rows[i].Height = 30;
                            dataGridView1_treatment_paln.Columns[6].Width = 200;
                            dataGridView1_treatment_paln.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1_treatment_paln.Rows[i].Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dataGridView1_treatment_paln.Rows[i].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            if (dt_pt_sub.Rows[k]["status"].ToString() == "0")
                            {
                                dataGridView1_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.TickRed;
                            }
                            else
                            {
                                dataGridView1_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.Borderblank;
                            }
                            totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());
                            dataGridView1_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                        }
                        i = i + 1;
                        dataGridView1_treatment_paln.Rows.Add("", "", "Planned by " + dt_pt_main.Rows[j]["dr_name"].ToString(), "", "Estimated amount:", String.Format("{0:C}", Convert.ToDecimal(totalEst)), "", "0");
                        dataGridView1_treatment_paln.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.ForeColor = Color.Red;
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        dataGridView1_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                        dataGridView1_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                        dataGridView1_treatment_paln.Rows[i].Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        i = i + 1;
                        dataGridView1_treatment_paln.Rows.Add("", "", "", "", "", "", "", "0");
                        dataGridView1_treatment_paln.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                        dataGridView1_treatment_paln.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                    }
                    if (dataGridView1_treatment_paln.Rows.Count <= 0)
                    {
                        lab_NoRecordFound_AlertMsg.Show();
                        lab_NoRecordFound_AlertMsg.Location = new System.Drawing.Point(165, 165);
                    }
                    else
                    {
                        lab_NoRecordFound_AlertMsg.Hide();
                        lab_NoRecordFound_AlertMsg.Location = new System.Drawing.Point(165, 165);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_treatment_paln_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1_treatment_paln.Rows.Count > 0 && (dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "1" || dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "2"))
                {
                    if (e.ColumnIndex == 1)
                    {
                        if (dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "1")
                        {
                            btnEnabled = btnEnabled + 1;
                            dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[7].Value = "2";
                            dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[1].Value = PappyjoeMVC .Properties.Resources.Bordertick;
                        }
                        else if (dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[7].Value.ToString() == "2")
                        {
                            dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[7].Value = "1";
                            dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[1].Value = PappyjoeMVC.Properties.Resources.Borderblank;
                            btnEnabled = btnEnabled - 1;
                        }
                        if (btnEnabled > 0)
                        {
                            BtnMarkAsFinished.Enabled = true;
                        }
                        else
                        {
                            BtnMarkAsFinished.Enabled = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_treatment_paln_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentMouseOverRow = dataGridView1_treatment_paln.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dataGridView1_treatment_paln.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 8)
                    {
                        if (dataGridView1_treatment_paln.Rows[currentMouseOverRow].Cells[0].Value.ToString() != "0" && dataGridView1_treatment_paln.Rows[currentMouseOverRow].Cells[2].Value.ToString() == "TREATMENTS")
                        {
                            treatment_plan_id = dataGridView1_treatment_paln.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                            contextMenuStrip1.Show(dataGridView1_treatment_paln, new System.Drawing.Point(870 - 120, e.Y));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = this.cntrl.delete_privillege(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Delete Treatment Plan", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        dlt_Privilage();
                    }
                }
                else
                {
                    dlt_Privilage();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void dlt_Privilage()
        {
            if (treatment_plan_id != "0")
            {
                DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    System.Data.DataTable dt_pt_check = this.cntrl.get_plan_id(treatment_plan_id);
                    if (dt_pt_check.Rows.Count > 0)
                    {
                        MessageBox.Show("Treatment Plan is used in procedures. Cannot Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        this.cntrl.delete_treatment(treatment_plan_id);
                        dataGridView1_treatment_paln.RowCount = 0;
                        dataGridView1_treatment_paln.ColumnHeadersVisible = false;
                        dataGridView1_treatment_paln.RowHeadersVisible = false;
                        dataGridView1_treatment_paln.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1_treatment_paln.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dataGridView1_treatment_paln.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        this.cntrl.get_treatments(patient_id);
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.check_privillege(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Treatment Plan", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new AddTreatmentPlan();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    add_treatmentplan_controller controller = new add_treatmentplan_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new AddTreatmentPlan();
                form2.doctor_id = doctor_id;
                form2.patient_id = patient_id;
                add_treatmentplan_controller controller = new add_treatmentplan_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void BtnMarkAsFinished_Click(object sender, EventArgs e)
        {
            try
            {
                int rec_count = 0;
                string a_plan_id = "";
                for (int i = 0; i < dataGridView1_treatment_paln.Rows.Count; i++)
                {
                    if (dataGridView1_treatment_paln.Rows[i].Cells[7].Value.ToString() == "2")
                    {
                        rec_count = rec_count + 1;
                        a_plan_id = a_plan_id + "," + dataGridView1_treatment_paln.Rows[i].Cells[0].Value.ToString();
                    }
                }
                if (rec_count != 0)
                {
                    a_plan_id = a_plan_id.Substring(1, a_plan_id.Length - 1);
                    var form2 = new AddFinishedprocedure();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    form2.treatment_plan = a_plan_id;
                    addfinsed_treatment_controller controller = new addfinsed_treatment_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please select the Treatment..!", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void emailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mprintosave();
        }
        public void mprintosave()
        {
            System.Data.DataTable dt_cf = this.cntrl.Get_treatment_details(treatment_plan_id);
            string doctor_name = "";
            string tr_date = "";
            if (dt_cf.Rows.Count > 0)
            {
                doctor_name = dt_cf.Rows[0]["dr_name"].ToString();
                tr_date = dt_cf.Rows[0]["date"].ToString();
            }
            System.Data.DataTable patient = cmodel.Get_Patient_Details(patient_id);
            string Pname = "", Gender = "", address = "", DOA = "", age = "", Mobile = "", DOB = "";
            if (patient.Rows.Count > 0)
            {
                Pname = patient.Rows[0]["pt_name"].ToString();
                Gender = patient.Rows[0]["gender"].ToString();
                address = patient.Rows[0]["street_address"].ToString() + " , " + patient.Rows[0]["city"].ToString();
                Mobile = patient.Rows[0]["primary_mobile_number"].ToString();
                DOA = DateTime.Parse(patient.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                DOB = patient.Rows[0]["date_of_birth"].ToString();
                age = patient.Rows[0]["age"].ToString();
            }
            string contact_no = "";
            string clinic_name = "";
            System.Data.DataTable dtp = cmodel.get_company_details();
            if (dtp.Rows.Count > 0)
            {
                string clinicn = "";
                string clinic = "";
                clinicn = dtp.Rows[0]["name"].ToString();
                clinic = clinicn.Replace("¤", "'");
                clinic_name = clinic;
                contact_no = dtp.Rows[0]["contact_no"].ToString();
            }
            string Apppath = System.IO.Directory.GetCurrentDirectory();
            StreamWriter sWrite = new StreamWriter(Apppath + "\\TreatmentMail.html");
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<body >");
            sWrite.WriteLine("<br><br><br>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=4>" + clinic_name.ToString() + "</font></th></tr>");
            sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>" + contact_no.ToString() + "</font></th></tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>Treatment Details </font></th></tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<br>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine(" <tr height='40px'>");
            sWrite.WriteLine("    <td align='left' width='400px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Consulted by : <b> " + doctor_name.ToString() + " </b></font></td>");
            sWrite.WriteLine("	<td align='left' width='170px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2></font></td>");
            sWrite.WriteLine("	<td align='left' width='130px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2></font></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("  <tr>  <td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Name :<b>" + Pname.ToString() + " </b></font></td><td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Gender : <b>" + Gender.ToString() + " </b></font></td> </tr>");
            sWrite.WriteLine("   <tr>  <td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Address :<b> " + address.ToString() + "</b></font></td> <td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Age : <b> " + age + "</b></font></td> </tr>");
            sWrite.WriteLine("  <tr>  <td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Mobile No:<b> " + Mobile.ToString() + "</b></font></td> <td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Tratment Date : <b> " + DateTime.Parse(dt_cf.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy") + "</b></font></td> </tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<br>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td>");
            sWrite.WriteLine("<hr>");
            sWrite.WriteLine("<table align='center'  style='width:700px; border: 1px ;border-collapse: collapse;' >");
            //Treatment
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("    <td align='left' colspan='2' >");
            sWrite.WriteLine("<table align='center'  style='border: 1px ;border-collapse: collapse;' >");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' width='100px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;Treatment</b></font></td>");
            sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;Cost</b></font></td>");
            sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;Discount</b></font></td>");
            sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;Total Cost</b></font></td>");
            sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;Total</b></font></td>");
            sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;&nbsp;&nbsp;&nbsp;Notes</b> </font></td>");
            sWrite.WriteLine("</tr>");
            System.Data.DataTable dt_Treat_Plan = this.cntrl.treatment_sub_details(treatment_plan_id);
            if (dt_Treat_Plan.Rows.Count > 0)
            {
                int i = 0;
                Double totalEst = 0;
                for (i = 0; i < dt_Treat_Plan.Rows.Count; i++)
                {

                    Double totaldiscount = 0;
                    string discount_string = "";
                    if (dt_Treat_Plan.Rows[i]["discount_type"].ToString() == "INR")
                    {
                        discount_string = "";
                    }
                    else
                    {
                        discount_string = "(" + dt_Treat_Plan.Rows[i]["discount"].ToString() + "%)";
                    }
                    Decimal totalcost = Convert.ToDecimal(dt_Treat_Plan.Rows[i]["cost"].ToString()) * Convert.ToDecimal(dt_Treat_Plan.Rows[i]["quantity"].ToString());
                    //clculation
                    decimal cost = 0; int qty = 0; decimal paid = 0;
                    decimal totCost = 0;
                    decimal totalsubst = 0;
                    cost = decimal.Parse(dt_Treat_Plan.Rows[i]["cost"].ToString());
                    qty = Convert.ToInt32(dt_Treat_Plan.Rows[i]["quantity"].ToString());
                    paid = decimal.Parse(dt_Treat_Plan.Rows[i]["total"].ToString());
                    totCost = cost * qty;
                    totalsubst = totCost - paid;
                    //end calulation
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'   width='250px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt_Treat_Plan.Rows[i]["procedure_name"].ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='right'  width='250px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_Treat_Plan.Rows[i]["cost"].ToString())) + "</font></td>");
                    sWrite.WriteLine("<td align='right'  width='250px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[i]["discount_inrs"].ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right'   width='250px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(totalcost)) + " </font></td>");
                    sWrite.WriteLine("<td align='right'  width='250px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_Treat_Plan.Rows[i]["total"].ToString())) + "</font></td>");
                    sWrite.WriteLine("<td align='left'  width='250px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[i]["note"].ToString() + " " + dt_Treat_Plan.Rows[i]["tooth"].ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    totalEst = totalEst + Convert.ToDouble(dt_Treat_Plan.Rows[i]["total"].ToString());
                    totaldiscount = totaldiscount + Convert.ToDouble(dt_Treat_Plan.Rows[i]["discount_inrs"].ToString());
                    sWrite.WriteLine("<tr >");
                }
                sWrite.WriteLine("<td align='Right'   colspan='5'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + "Estimated Amount : <b>" + String.Format("{0:C}", Convert.ToDecimal(totalEst)) + "</b> </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                // mail senting...
                string email = "", emailName = "", emailPass = "";
                System.Data.DataTable sr = cmodel.getpatemail(patient_id);
                if (sr.Rows.Count > 0)
                {
                    email = sr.Rows[0]["email_address"].ToString();
                    if (email != "")
                    {
                        System.Data.DataTable sms = cmodel.send_email();
                        if (sms.Rows.Count > 0)
                        {
                            emailName = sms.Rows[0]["emailName"].ToString();
                            emailPass = sms.Rows[0]["emailPass"].ToString();
                            try
                            {
                                StreamReader reader = new StreamReader(Apppath + "\\TreatmentMail.html");
                                string readFile = reader.ReadToEnd();
                                string StrContent = "";
                                StrContent = readFile;
                                MailMessage message = new MailMessage();
                                message.From = new MailAddress(email);
                                message.To.Add(email);
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                message.Subject = "Treatment Details";
                                message.Body = StrContent.ToString();
                                message.IsBodyHtml = true;
                                smtp.Port = 587;
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                smtp.Send(message);
                                MessageBox.Show("Email is Sent To : " + email, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Mail server authentication failed ", "Mail Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email is not Correct", "Invalid Email !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            printhtml();
        }
        public void printhtml()
        {
            int kw = 0;
            System.Data.DataTable dt1 = cmodel.Get_Patient_Details(patient_id);
            System.Data.DataTable dt_cf = this.cntrl.Get_treatment_details(treatment_plan_id);
            string doctor_name = "";
            string tr_date = "";
            if (dt_cf.Rows.Count > 0)
            {
                doctor_name = dt_cf.Rows[0]["dr_name"].ToString();
                tr_date = dt_cf.Rows[0]["date"].ToString();
            }
            string Pname = "", Gender = "", address = "", DOA = "", age = "", Mobile = "";
            if (dt1.Rows.Count > 0)
            {
                Pname = dt1.Rows[0]["pt_name"].ToString();
                Gender = dt1.Rows[0]["gender"].ToString();
                Mobile = dt1.Rows[0]["primary_mobile_number"].ToString();
                DOA = DateTime.Parse(dt1.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                if (dt1.Rows[0]["date_of_birth"].ToString() != "")
                {
                    age = DateTime.Parse(dt1.Rows[0]["date_of_birth"].ToString()).ToString("dd/MM/yyyy");
                }
            }
            int Dexist = 0;
            string clinicn = "";
            string Clinic = "";
            System.Data.DataTable dtp =cmodel.get_company_details();
            if (dtp.Rows.Count > 0)
            {
                clinicn = dtp.Rows[0]["name"].ToString();
                Clinic = clinicn.Replace("¤", "'");
            }
            string Apppath = System.IO.Directory.GetCurrentDirectory();
            StreamWriter sWrite = new StreamWriter(Apppath + "\\TreatmentMail.html");
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<body >");
            sWrite.WriteLine("<br>");
            if (logo_name != "")
            {
                string Appath = System.IO.Directory.GetCurrentDirectory();
                if (File.Exists(Appath + "\\" + logo_name))
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
                    sWrite.WriteLine("<td width='588' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + Clinic + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + dtp.Rows[0]["street_address"].ToString() + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + dtp.Rows[0]["contact_no"].ToString() + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + Clinic + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + dtp.Rows[0]["street_address"].ToString() + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + dtp.Rows[0]["contact_no"].ToString() + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                }
            }
            else
            {
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + Clinic + "</font></td></tr>");
                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + dtp.Rows[0]["street_address"].ToString() + "</font></td></tr>");
                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + dtp.Rows[0]["contact_no"].ToString() + "</font></td></tr>");
                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                sWrite.WriteLine("</table>");
            }
            string sexage = "";
            address = "";
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr>");
            if (dt1.Rows[0]["gender"].ToString() != "")
            {
                sexage = dt1.Rows[0]["gender"].ToString();
                Dexist = 1;
            }
            if (dt1.Rows[0]["age"].ToString() != "")
            {
                if (Dexist == 1)
                {
                    sexage = sexage + ", " + dt1.Rows[0]["age"].ToString() + " Years";
                }
                else
                {
                    sexage = dt1.Rows[0]["age"].ToString() + " Years";
                }
            }
            sWrite.WriteLine(" <td align='left' height=25><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>" + dt1.Rows[0]["pt_name"].ToString() + "</b><i> (" + sexage + ")</i></font></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Patient Id:" + dt1.Rows[0]["pt_id"].ToString() + " </font></td>");
            sWrite.WriteLine(" </tr>");
            Dexist = 0;
            if (dt1.Rows[0]["street_address"].ToString() != "")
            {
                address = dt1.Rows[0]["street_address"].ToString();
                Dexist = 1;
            }
            if (dt1.Rows[0]["locality"].ToString() != "")
            {
                if (Dexist == 1)
                {
                    address = address + ",";
                }
                address = address + dt1.Rows[0]["locality"].ToString();
                Dexist = 1;
            }
            if (dt1.Rows[0]["city"].ToString() != "")
            {
                if (Dexist == 1)
                {
                    address = address + ",";
                }
                address = address + dt1.Rows[0]["city"].ToString();
                Dexist = 1;
            }
            if (dt1.Rows[0]["pincode"].ToString() != "")
            {
                if (Dexist == 1)
                {
                    address = address + ",";
                }
                address = address + dt1.Rows[0]["pincode"].ToString();
                Dexist = 1;
            }
            if (address != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + address + " </font></td>");
                sWrite.WriteLine(" </tr>");
            }
            if (dt1.Rows[0]["aadhar_id"].ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + "Aadhaar ID:" + dt1.Rows[0]["aadhar_id"].ToString() + " </font></td>");
                sWrite.WriteLine(" </tr>");
            }
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt1.Rows[0]["primary_mobile_number"].ToString() + " </font></td>");
            sWrite.WriteLine(" </tr>");
            if (dt1.Rows[0]["email_address"].ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt1.Rows[0]["email_address"].ToString() + " </font></td>");
                sWrite.WriteLine(" </tr>");
            }
            sWrite.WriteLine("<tr><td colspan=2><hr></td></tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' width='400px' height='30px'><FONT FACE='Geneva, Segoe UI' SIZE=2><FONT COLOR=black >By</FONT> :Dr. <b>" + doctor_name + " </b></font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<br>");
            sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>Treatment Plan</FONT></td>");
            sWrite.WriteLine("<td width=250px></td>");
            if (dt_cf.Rows.Count > 0)
            {
                sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(dt_cf.Rows[0]["date"].ToString()).ToString("dd MMM yyyy") + "</font></td>");
            }
            else
            {
                sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Now.ToString("dd MMM yyyy") + "</font></td>");
            }
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
            sWrite.WriteLine("<tr style='background:#999999'>");
            sWrite.WriteLine("<td align='left' width='151px' height='30' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Treatment</font></td>");
            sWrite.WriteLine("<td align='right' width='64px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Quantity </font></td>");
            sWrite.WriteLine("<td align='right' width='72px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Cost</font></td>");
            sWrite.WriteLine("<td align='right' width='75px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Discount</font></td>");
            sWrite.WriteLine("<td align='right' width='90px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Total Cost</font></td>");
            sWrite.WriteLine("<td align='right' width='80px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Total</font></td>");
            sWrite.WriteLine("<td align='right' width='136px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Notes </font></td>");
            sWrite.WriteLine("</tr>");
            System.Data.DataTable dt_Treat_Plan = this.cntrl.treatment_sub_details(treatment_plan_id);
            if (dt_Treat_Plan.Rows.Count > 0)
            {
                Double totaldiscount = 0;
                string discount_string = "";
                if (dt_Treat_Plan.Rows[kw]["discount_type"].ToString() == "INR")
                {
                    discount_string = "";
                }
                else
                {
                    discount_string = "(" + dt_Treat_Plan.Rows[kw]["discount"].ToString() + "%)";
                }
                decimal totalcot_treat = 0;
                for (int i = 0; i < dt_Treat_Plan.Rows.Count; i++)
                {
                    Decimal totalcost = Convert.ToDecimal(dt_Treat_Plan.Rows[i]["cost"].ToString()) * Convert.ToDecimal(dt_Treat_Plan.Rows[i]["quantity"].ToString());
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' height='30'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[i]["procedure_name"].ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='center'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[i]["quantity"].ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_Treat_Plan.Rows[i]["cost"].ToString())) + "</font></td>");
                    sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_Treat_Plan.Rows[i]["discount_inrs"].ToString())) + "</font></td>");
                    sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(totalcost)) + " </font></td>");
                    sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_Treat_Plan.Rows[i]["total"].ToString())) + "</font></td>");
                    sWrite.WriteLine("<td align='char' style='text-align:right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[i]["note"].ToString() + " " + dt_Treat_Plan.Rows[i]["tooth"].ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    totalcot_treat = totalcot_treat + Convert.ToDecimal(totalcost);
                    totaldiscount = totaldiscount + Convert.ToDouble(dt_Treat_Plan.Rows[i]["discount_inrs"].ToString());
                }
                sWrite.WriteLine("<tr><td align='left' colspan=7><hr/></td></tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right' colspan=4><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>&nbsp;" + "Estimated Amount : " + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=2><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(totalcot_treat)) + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\TreatmentMail.html");
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

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controllr = new Communication_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
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

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                System.Data.DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 350, 40);
            }
            else
            {
                listpatientsearch.Visible = false;
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
                id = this.cntrl.permission_for_settings(doctor_id);
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
    }
   
}
