using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Add_Vital_Signs : Form
    {
        Add_Vital_Signs_controller cntrl = new Add_Vital_Signs_controller();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public static string gender;
        double weight;
        double height;
        public Add_Vital_Signs()
        {
            InitializeComponent();
        }
        private void Add_Vital_Signs_Load(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id == "0" || doctor_id == "")
                {
                    doctor_id = "0";
                }
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                //DataTable clinicname = this.cntrl.Get_CompanyNAme();
                //if (clinicname.Rows.Count > 0)
                //{
                //string clinicn = "";
                //clinicn = clinicname.Rows[0]["Name"].ToString();
                toolStripButton1.Text = this.cntrl.Load_CompanyName();
                //}
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
                gender = rs_patients.Rows[0]["gender"].ToString();
                int dr_index = 0;
                DataTable dt = this.cntrl.get_all_doctorname();
                if (dt.Rows.Count > 0)
                {
                    Cmb_doctor.DataSource = dt;
                    Cmb_doctor.DisplayMember = "doctor_name";
                    Cmb_doctor.ValueMember = "id";
                    if (doctor_id != "0")
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["id"].ToString() == doctor_id)
                            {
                                dr_index = j;
                            }
                        }
                        Cmb_doctor.SelectedIndex = dr_index;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patients();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var dlg = new Expense();
            dlg.doctor_id = doctor_id;
            //expense_controller ctrl = new expense_controller(dlg);
            dlg.ShowDialog();
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
                        var form2 = new PappyjoeMVC.View.Add_New_Patients();
                        //Add_New_patient_controller cnt = new Add_New_patient_controller(form2);
                        form2.doctor_id = doctor_id;
                        form2.ShowDialog();
                        //form2.Closed += (sender1, args) => this.Close();
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.Add_New_Patients();
                    //Add_New_patient_controller cnt = new Add_New_patient_controller(form2);
                    form2.doctor_id = doctor_id;
                    form2.ShowDialog();
                    //form2.Closed += (sender1, args) => this.Close();
                    //this.Hide();
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
                        //form2.Closed += (sender1, args) => this.Close();
                        //this.Hide();
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
                    //form2.Closed += (sender1, args) => this.Close();
                    //this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    listpatientsearch.Location = new System.Drawing.Point(toolStrip1.Width - 352, 38);
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
            form2.ShowDialog();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }

        private void labelallpatient_Click_1(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patients();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }

        private void text_Pulse_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void text_Pulse_KeyUp(object sender, KeyEventArgs e)
        {
            if (text_Pulse.Text != "")
            {
                if (decimal.Parse(text_Pulse.Text) < 10)
                {
                    label7.Show();
                    label7.Text = "Pulse can't be less than 10";
                }
                else if (decimal.Parse(text_Pulse.Text) > 200)
                {
                    label7.Show();
                    label7.Text = "Pulse can't be greater than 200";
                }
                else
                {
                    label7.Hide();
                }
            }
            else
            {
                label7.Hide();
            }
        }

        private void text_Temp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void text_Temp_KeyUp(object sender, KeyEventArgs e)
        {
            if (text_Temp.Text != "")
            {
                if (decimal.Parse(text_Temp.Text) < 10)
                {
                    label7.Show();
                    label7.Text = "Temperature can't be less than 10";
                }
                else if (decimal.Parse(text_Temp.Text) > 111)
                {
                    label7.Show();
                    label7.Text = "Temperature can't be greater than 111";
                }
                else
                {
                    label7.Hide();
                }
            }
            else
            {
                label7.Hide();
            }
        }

        private void text_Bp_Syst_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void text_Bp_Syst_KeyUp(object sender, KeyEventArgs e)
        {
            if (text_Bp_Syst.Text != "")
            {
                if (decimal.Parse(text_Bp_Syst.Text) < 50)
                {
                    label7.Show();
                    label7.Text = "Systolic blood pressure can't be less than 50";
                }
                else if (decimal.Parse(text_Bp_Syst.Text) > 300)
                {
                    label7.Show();
                    label7.Text = "Systolic blood pressure can't be more than 300";
                }
                else
                {
                    label7.Hide();
                }
            }
            else
            {
                label7.Hide();
            }
        }

        private void text_Bp_Dias_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void text_Bp_Dias_KeyUp(object sender, KeyEventArgs e)
        {
            if (text_Bp_Dias.Text != "")
            {
                if (decimal.Parse(text_Bp_Dias.Text) < 25)
                {
                    label7.Show();
                    label7.Text = "Diastolic blood pressure can't be less than 25";
                }
                else if (decimal.Parse(text_Bp_Dias.Text) > 200)
                {
                    label7.Show();
                    label7.Text = "Diastolic blood pressure can't be more than 200";
                }
                else
                {
                    label7.Hide();
                }
            }
            else
            {
                label7.Hide();
            }
        }

        private void Txtheight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void Txtheight_TextChanged(object sender, EventArgs e)
        {
            BMI_Calculate(gender);
        }

        private void text_Weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void text_Weight_TextChanged(object sender, EventArgs e)
        {
            BMI_Calculate(gender);
        }

        private void text_Resp_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void text_Resp_KeyUp(object sender, KeyEventArgs e)
        {
            if (text_Resp.Text != "")
            {
                if (decimal.Parse(text_Resp.Text) < 10)
                {
                    label7.Show();
                    label7.Text = "Respiratory rate can't be less than 10";
                }
                else if (decimal.Parse(text_Resp.Text) > 70)
                {
                    label7.Show();
                    label7.Text = "Respiratory rate can't be more than 70";
                }
                else
                {
                    label7.Hide();
                }
            }
            else
            {
                label7.Hide();
            }
        }

        private void txtBMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Vital_Signs();
            if (doctor_id == "0" || doctor_id == "") { form2.staff_id = staff_id; } else { form2.doctor_id = doctor_id; }
            //Vital_Signs_controller controller = new Vital_Signs_controller(form2);
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string temp_type = "", bp_type = ""; int i = 0;
                if (!String.IsNullOrWhiteSpace(text_Temp.Text))
                {
                    temp_type = combo_Te.Text;
                }
                if (!String.IsNullOrWhiteSpace(text_Bp_Syst.Text) || !String.IsNullOrWhiteSpace(text_Bp_Dias.Text))
                {
                    bp_type = combo_Bp.Text;
                }
                if (!String.IsNullOrWhiteSpace(text_Pulse.Text) || !String.IsNullOrWhiteSpace(text_Temp.Text) || !String.IsNullOrWhiteSpace(Txtheight.Text) || !String.IsNullOrWhiteSpace(text_Bp_Syst.Text) || !String.IsNullOrWhiteSpace(text_Bp_Dias.Text) || !String.IsNullOrWhiteSpace(text_Resp.Text) || !String.IsNullOrWhiteSpace(text_Weight.Text))
                {
                    string doctor = "";
                    string dr_id = doctor_id;
                    if (doctor_id != "0")
                    {
                        doctor = Cmb_doctor.Text;
                        dr_id = Cmb_doctor.SelectedValue.ToString();
                    }
                    i = this.cntrl.submit(patient_id, dr_id, doctor, temp_type, bp_type, text_Pulse.Text, text_Temp.Text, text_Bp_Syst.Text, text_Bp_Dias.Text, text_Weight.Text, text_Resp.Text, dtp_date.Text, Txtheight.Text);
                    if (i > 0)
                    {
                        var form2 = new PappyjoeMVC.View.Vital_Signs();
                        if (doctor_id == "0" || doctor_id == "")
                        { form2.staff_id = staff_id; }
                        else { form2.doctor_id = doctor_id; }
                        form2.patient_id = patient_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Inseration Failed!..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    label7.Show();
                    label7.Text = "Data not found...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void BMI_Calculate(string gd)
        {
            try
            {
                if (text_Weight.Text != "" && Txtheight.Text != "")
                {
                    gender = gd;
                    weight = Double.Parse(text_Weight.Text);
                    height = Double.Parse(Txtheight.Text);
                    double BMI = Math.Round((weight / (height * height)) * 10000, 1);
                    if (BMI != null)
                    {
                        label10.Visible = true;
                        txtBMI.Text = BMI.ToString();
                        if (BMI < 19 && gender == "Female")
                        {
                            label10.Text = "BMI is Low";
                            label10.ForeColor = Color.Red;
                        }
                        if (BMI >= 19 & BMI <= 24 & gender == "Female")
                        {
                            label10.Text = "Normal";
                            label10.ForeColor = Color.LightGreen;
                        }
                        if (BMI > 24 & gender == "Female")
                        {
                            label10.Text = "BMI is High";
                            label10.ForeColor = Color.Red;
                        }

                        if (BMI < 20 & gender == "Male")
                        {
                            label10.Text = "BMI is Low";
                            label10.ForeColor = Color.Red;
                        }
                        if (BMI >= 20 & BMI <= 25 & gender == "Male")
                        {
                            label10.Text = "Normal";
                            label10.ForeColor = Color.LightGreen;
                        }
                        if (BMI > 25 & gender == "Male")
                        {
                            label10.Text = "BMI is High";
                            label10.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    txtBMI.Text = "";
                    label10.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            //Reports_controller controller = new Reports_controller(form2);
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
                //doctor_controller controlr = new doctor_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
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
    }
}
