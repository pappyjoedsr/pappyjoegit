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
using Microsoft.Win32;
using System.IO;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class Doctor_Profile : Form
    {
        Doctor_Controller cntrl =new Doctor_Controller();
        public string doctor_id = "";
        public string patient_id = "0";
        public string doc = "0";
        Connection db = new Connection();
        string clinicpath; 
        string  clinicservice, clinicspecial;
        public Doctor_Profile()
        {
            InitializeComponent();
        }
        private void cmbDrProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDrProfile.Text == "SERVICES")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_service.Location = new Point(20, 7);
                panel_service.Visible = true;
                panel_specialization.Visible = false;
                panel_education.Visible = false;
                panel_experience.Visible = false;
                panel_recognition.Visible = false;
                panel_membership.Visible = false;
                panel_register.Visible = false;
            }
            else if (cmbDrProfile.Text == "SPECIALIZATION")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_specialization.Visible = true;
                panel_specialization.Location = new Point(20, 7);
                panel_service.Visible = false;
                panel_education.Visible = false;
                panel_experience.Visible = false;
                panel_recognition.Visible = false;
                panel_membership.Visible = false;
                panel_register.Visible = false;
            }
            else if (cmbDrProfile.Text == "EDUCATION")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_education.Visible = true;
                panel_education.Location = new Point(20, 7);
                panel_service.Visible = false;
                panel_specialization.Visible = false;
                panel_experience.Visible = false;
                panel_recognition.Visible = false;
                panel_membership.Visible = false;
                panel_register.Visible = false;
            }
            else if (cmbDrProfile.Text == "EXPERIENCE")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_experience.Visible = true;
                panel_experience.Location = new Point(20, 7);
                panel_service.Visible = false;
                panel_specialization.Visible = false;
                panel_education.Visible = false;
                panel_recognition.Visible = false;
                panel_membership.Visible = false;
                panel_register.Visible = false;
                DataTable dt11 = this.cntrl.load_city();
                combo_experience_city.DataSource = dt11;
                combo_experience_city.DisplayMember = "city";
                combo_experience_city.ValueMember = "id";
            }
            else if (cmbDrProfile.Text == "AWARDS")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_recognition.Visible = true;
                panel_recognition.Location = new Point(20, 7);
                panel_service.Visible = false;
                panel_specialization.Visible = false;
                panel_education.Visible = false;
                panel_experience.Visible = false;
                panel_membership.Visible = false;
                panel_register.Visible = false;
            }
            else if (cmbDrProfile.Text == "MEMBERSHIPS")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_membership.Visible = true;
                panel_membership.Location = new Point(20, 7);
                panel_service.Visible = false;
                panel_specialization.Visible = false;
                panel_education.Visible = false;
                panel_experience.Visible = false;
                panel_recognition.Visible = false;
                panel_register.Visible = false;
            }
            else if (cmbDrProfile.Text == "REGISTRATION")
            {
                panel_DoctorProfile_Add.Visible = true;
                panel_register.Visible = true;
                panel_register.Location = new Point(20, 7);
                panel_service.Visible = false;
                panel_specialization.Visible = false;
                panel_education.Visible = false;
                panel_experience.Visible = false;
                panel_recognition.Visible = false;
                panel_membership.Visible = false;
            }
        }

        private void button_add_service_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "1";
            frm.ShowDialog(this);
        }

        private void button_add_special_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "6";
            frm.ShowDialog(this);
        }

        private void button_education_adddegree_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "2";
            frm.ShowDialog(this);
        }

        private void button_education_add_college_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "3";
            frm.ShowDialog(this);
        }

        private void button_add_membership_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "4";
            frm.ShowDialog(this);
        }

        private void button_reg_add_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "5";
            frm.ShowDialog(this);
        }

        private void button_save_service_Click(object sender, EventArgs e)
        {
            try
            {
                int flagService = 0;
                if (dataGridView_services.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView_services.Rows.Count; i++)
                    {
                        if (dataGridView_services.Rows[i].Cells["Col_service"].Value.ToString().Trim() == combo_service.Text.Trim())
                        {
                            flagService = 1;
                        }
                    }
                }
                if (flagService == 0)
                {
                    if (combo_service.Text != "")
                    {
                        string c = this.cntrl.get_servicecount(doctor_id);
                        string ser_id = this.cntrl.getserviceid(combo_service.Text);
                        this.cntrl.save_drservice(doctor_id, ser_id);
                    }
                    DataTable service1 = this.cntrl.load_servicegrid(doctor_id);
                    dataGridView_services.DataSource = service1;
                }
                else
                {
                    MessageBox.Show("Service with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_save_special_Click(object sender, EventArgs e)
        {
            try
            {
                int flagspecial = 0;
                if (dataGridView_specialization.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView_specialization.Rows.Count; i++)
                    {
                        if (dataGridView_specialization.Rows[i].Cells["Col_Col_special"].Value.ToString().Trim() == combo_special.Text.Trim())
                        {
                            flagspecial = 1;
                        }
                    }
                }
                if (flagspecial == 0)
                {
                    if (combo_special.Text != "")
                    {
                        string ser_id = this.cntrl.get_specilizationid(combo_special.Text);
                        this.cntrl.dr_savespecilization(doctor_id, ser_id);
                    }
                    DataTable special = this.cntrl.load_dr_specilizaion(doctor_id);
                    dataGridView_specialization.DataSource = special;
                }
                else
                {
                    MessageBox.Show("Specialization with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_save_education_Click(object sender, EventArgs e)
        {
            try
            {
                int flageducation = 0;
                if (dataGridView_education.Rows.Count != 0)
                {

                    for (int i = 0; i < dataGridView_education.Rows.Count; i++)
                    {
                        if (dataGridView_education.Rows[i].Cells["Col_degree"].Value.ToString().Trim() == combo_education_degree.Text.Trim() && dataGridView_education.Rows[i].Cells["Col_college"].Value.ToString().Trim() == combo_education_college.Text.Trim() && dataGridView_education.Rows[i].Cells["Col_year"].Value.ToString().Trim() == combo_education_year.Text.Trim())
                        {
                            flageducation = 1;
                        }
                    }
                }
                if (flageducation == 0)
                {
                    string degree = "", college = "", year = "", eDegree = "0", eCollege = "0", eYear = "0";
                    if (combo_education_degree.Text != "" && combo_education_degree.Visible == true)
                    {
                        errorProvider1.Dispose();
                        degree = combo_education_degree.Text;
                        eDegree = "0";
                        string serviceCheck = this.cntrl.check_degreeexists(combo_education_degree.SelectedValue.ToString(), doctor_id);
                        if (serviceCheck != "")
                        {
                            int eduid = Convert.ToInt32(serviceCheck);
                            if (eduid > 0)
                            {
                                MessageBox.Show("Degree with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(combo_education_degree, "can't be empty");
                        eDegree = "1";
                    }
                    if (combo_education_college.Text != "" && combo_education_college.Visible == true)
                    {
                        errorProvider2.Dispose();
                        college = combo_education_college.Text;
                        eCollege = "0";
                    }
                    else
                    {
                        errorProvider2.SetError(combo_education_college, "can't be empty");
                        eCollege = "1";
                    }
                    if (combo_education_year.Text != "")
                    {
                        errorProvider3.Dispose();
                        year = combo_education_year.Text;
                        eYear = "0";
                        string year_ = this.cntrl.check_yearexists(year, doctor_id);
                        if (year_ != "")
                        {
                            int checkyear = Convert.ToInt32(year_);
                            if (checkyear > 0)
                            {
                                MessageBox.Show("Same year already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    else
                    {
                        errorProvider3.SetError(combo_education_year, "can't be empty");
                        eYear = "1";
                    }

                    if (eCollege == "0" && eDegree == "0" && eYear == "0")
                    {
                        string degId = "", colgId = "";
                        DataTable deg_id = this.cntrl.get_degreeid(degree);
                        if (deg_id.Rows.Count > 0)
                        {
                            degId = deg_id.Rows[0]["id"].ToString();
                        }
                        DataTable colg_id = this.cntrl.get_collegeid(college);
                        if (colg_id.Rows.Count > 0)
                        {
                            colgId = colg_id.Rows[0]["id"].ToString();
                        }
                        this.cntrl.save_dr_education(doctor_id, degId, colgId, combo_education_year.Text);
                        DataTable education1 = this.cntrl.load_educationgrid(doctor_id);
                        dataGridView_education.DataSource = education1;
                    }
                }
                else
                {
                    MessageBox.Show("Education details with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_service_Click(object sender, EventArgs e)
        {
            DataTable service = this.cntrl.load_serviceCombo();
            combo_service.DataSource = service;
            combo_service.DisplayMember = "service";
            combo_service.ValueMember = "id";
            combo_service.Text = "";
        }

        private void combo_special_Click(object sender, EventArgs e)
        {
            DataTable special = this.cntrl.load_cmbspecilization();
            combo_special.DataSource = special;
            combo_special.DisplayMember = "name";
            combo_special.ValueMember = "id";
            combo_special.Text = "";
        }

        private void dataGridView_services_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_services.CurrentCell.OwningColumn.Name == "Del_Services")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        int rowindex = Convert.ToInt32(dataGridView_services.CurrentRow.Cells["Colm_Id"].Value.ToString());
                        string drid = dataGridView_services.CurrentRow.Cells["ColmDr_id"].Value.ToString();
                        if (rowindex >0 && drid != null)
                        {
                            this.cntrl.delete_dr_service(rowindex, drid);
                            DataTable service = this.cntrl.load_servicegrid(doctor_id);
                            dataGridView_services.DataSource = service;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_specialization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_specialization.CurrentCell.OwningColumn.Name == "Del_Spe")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        int rowindex = Convert.ToInt32(dataGridView_specialization.CurrentRow.Cells["colm_Spec_id"].Value.ToString());
                        string drid = dataGridView_specialization.CurrentRow.Cells["ColmDr_id_Spec"].Value.ToString();
                        if (rowindex>0 && drid != null)
                        {
                            this.cntrl.delete_dr_specilization(rowindex, drid);
                            DataTable special = this.cntrl.load_dr_specilizaion(doctor_id);
                            dataGridView_specialization.DataSource = special;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_education_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_education.CurrentCell.OwningColumn.Name == "Del_Degre")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        string degid = dataGridView_education.CurrentRow.Cells["colm_Degree_Id"].Value.ToString();
                        string colgid = dataGridView_education.CurrentRow.Cells["colm_Collage_id"].Value.ToString();
                        string drid = dataGridView_education.CurrentRow.Cells["colm_Edu_Dr_id"].Value.ToString();
                        if (degid != null && colgid != null && drid != null)
                        {
                            this.cntrl.delete_education(drid, degid, colgid);
                            DataTable education = this.cntrl.load_educationgrid(drid);
                            dataGridView_education.DataSource = education;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_education_degree_Click(object sender, EventArgs e)
        {
            DataTable degree = this.cntrl.load_degreecombo();
            combo_education_degree.DataSource = degree;
            combo_education_degree.DisplayMember = "degree";
            combo_education_degree.ValueMember = "id";
            combo_education_degree.Text = "";
        }

        private void combo_education_college_Click(object sender, EventArgs e)
        {
            DataTable college = this.cntrl.load_collegecombo();
            combo_education_college.DataSource = college;
            combo_education_college.DisplayMember = "college";
            combo_education_college.ValueMember = "id";
            combo_education_college.Text = "";
        }
        string tempId = "0";
        private void Doctor_Profile_Load(object sender, EventArgs e)
        {
            for (int i = 1914; i <= DateTime.Now.Year; i++)
            {
                combo_education_year.Items.Add(i.ToString());
                combo_eperience_from.Items.Add(i.ToString());
                combo_experience_to.Items.Add(i.ToString());
                combo_award_year.Items.Add( i.ToString());
                combo_reg_year.Items.Add(i.ToString());
            }
            fill_all_combo();
            cmbDrProfile.Text = "Select values";
            toolStripButton7.BackColor = Color.SkyBlue;
            toolStripDropDownButton1.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;

            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                if (doc != "0")
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    button2.Show();
                    toolStrip1.Hide();
                    tempId = doctor_id;
                    doctor_id = doc;
                }
                else
                {
                    tempId = doctor_id;
                }
               
                    toolStripButton1.Text = this.cntrl.Load_CompanyName();
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                //listpatientsearch.Hide();
                panel_clinicaldetails.Visible = false;
                panel_education.Hide();
                panel_experience.Hide();
                panel_membership.Hide();
                panel_recognition.Hide();
                panel_register.Hide();
                panel_service.Hide();
                panel_specialization.Hide();
                panel_edit_dr.Show();
                DataTable name = this.cntrl.get_doctor_details(doctor_id);
                text_drname.Text = name.Rows[0]["doctor_name"].ToString();
                string gen = name.Rows[0]["gender"].ToString();
                if (gen == "Male")
                {
                    radio_male.Checked = true;
                }
                else
                {
                    radio_female.Checked = true;
                }
                combo_year.Text = name.Rows[0]["experience"].ToString();
                rich_about.Text = name.Rows[0]["about"].ToString();
                text_phone.Text = name.Rows[0]["mobile_number"].ToString();
                text_email.Text = name.Rows[0]["email_id"].ToString();
                textPassword.Text = name.Rows[0]["password"].ToString();
                try
                {
                    string curFile = db.server() + "\\Pappyjoe_utilities\\doctor_image\\" + doctor_id;
                    if (System.IO.File.Exists(curFile))
                    {
                        pictureBox_Docter_Image.Image = Image.FromFile(curFile);
                    }
                    else
                    {
                        pictureBox_Docter_Image.Image = PappyjoeMVC.Properties.Resources.nophoto;
                    }
                }
                catch (Exception ex)
                {
                    pictureBox_Docter_Image.Image = PappyjoeMVC.Properties.Resources.nophoto;
                }
                dataGridView_services.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_services.EnableHeadersVisualStyles = false;
                DataTable service = this.cntrl.load_servicegrid(doctor_id);
                if (service.Rows.Count > 0)
                    dataGridView_services.DataSource = service;
                dataGridView_specialization.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_specialization.EnableHeadersVisualStyles = false;
                DataTable special = this.cntrl.load_dr_specilizaion(doctor_id);
                if (special.Rows.Count > 0)
                    dataGridView_specialization.DataSource = special;
                dataGridView_education.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_education.EnableHeadersVisualStyles = false;
                DataTable education = this.cntrl.load_educationgrid(doctor_id);
                if (education.Rows.Count > 0)
                    dataGridView_education.DataSource = education;
                dataGridView_experience.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_experience.EnableHeadersVisualStyles = false;
                DataTable experience = this.cntrl.load_experiecncegrid(doctor_id);
                if (experience.Rows.Count > 0)
                    dataGridView_experience.DataSource = experience;
                dataGridView_awards.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_awards.EnableHeadersVisualStyles = false;
                DataTable awards = this.cntrl.load_awards(doctor_id);
                if (awards.Rows.Count > 0)
                    dataGridView_awards.DataSource = awards;
                dataGridView_member.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_member.EnableHeadersVisualStyles = false;
                DataTable member = this.cntrl.load_member(doctor_id);
                if (member.Rows.Count > 0)
                    dataGridView_member.DataSource = member;
                dataGridView_reg.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                dataGridView_reg.EnableHeadersVisualStyles = false;
                DataTable register = this.cntrl.load_council(doctor_id);
                if (register.Rows.Count > 0)
                    dataGridView_reg.DataSource = register;
                if (dataGridView_services.Rows.Count > 0)
                {
                    dataGridView_services.CurrentCell.Selected = false;
                }
                if (dataGridView_specialization.Rows.Count > 0)
                {
                    dataGridView_specialization.CurrentCell.Selected = false;
                }
                if (dataGridView_education.Rows.Count > 0)
                {
                    dataGridView_education.CurrentCell.Selected = false;
                }
                if (dataGridView_experience.Rows.Count > 0)
                {
                    dataGridView_experience.CurrentCell.Selected = false;
                }
                if (dataGridView_awards.Rows.Count > 0)
                {
                    dataGridView_awards.CurrentCell.Selected = false;
                }
                if (dataGridView_reg.Rows.Count > 0)
                {
                    dataGridView_reg.CurrentCell.Selected = false;
                }
                if (dataGridView_member.Rows.Count > 0)
                {
                    dataGridView_member.CurrentCell.Selected = false;
                }
            }
            else
            {
                panel_edit_dr.Hide();
                panel_clinicaldetails.Hide();
            }
        }

        private void button_experience_save_Click(object sender, EventArgs e)
        {
            try
            {
                int flagExp = 0;
                if (dataGridView_experience.Rows.Count != 0)
                {

                    for (int i = 0; i < dataGridView_experience.Rows.Count; i++)
                    {
                        if (dataGridView_experience.Rows[i].Cells["Col_from"].Value.ToString().Trim() == combo_eperience_from.Text.Trim() && dataGridView_experience.Rows[i].Cells["Col_To"].Value.ToString().Trim() == combo_experience_to.Text.Trim() && dataGridView_experience.Rows[i].Cells["Col_Role"].Value.ToString().Trim() == text_experience_role.Text.Trim() && dataGridView_experience.Rows[i].Cells["Exp_Company"].Value.ToString().Trim() == text_experience_company.Text.Trim() && dataGridView_experience.Rows[i].Cells["Col_city"].Value.ToString().Trim() == combo_experience_city.Text.Trim())
                        {
                            flagExp = 1;
                        }
                    }
                }
                if (flagExp == 0)
                {
                    int fromYear = 0, toYear = 0;

                    if (combo_eperience_from.Text != "" && combo_experience_to.Text != "" && text_experience_role.Text != "" && text_experience_company.Text != "" && combo_experience_city.Text != "")
                    {
                        fromYear = int.Parse(combo_eperience_from.Text);
                        toYear = int.Parse(combo_experience_to.Text);
                        if (toYear < fromYear)
                        {
                            errorProvider1.SetError(combo_experience_to, "Choose a higher Year");
                            combo_eperience_from.Focus();
                            return;
                        }
                        else
                        {
                            errorProvider1.Dispose();
                            this.cntrl.save_dr_experiences(doctor_id, combo_eperience_from.Text, combo_experience_to.Text, text_experience_role.Text, text_experience_company.Text, combo_experience_city.Text);
                            DataTable experience1 = this.cntrl.load_experiecncegrid(doctor_id);
                            dataGridView_experience.DataSource = experience1;
                            text_experience_role.Text = "";
                            text_experience_company.Text = "";
                            combo_experience_city.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Check if all values are filled", "empty fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Experiance details with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_experience_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_experience.CurrentCell.OwningColumn.Name == "Del_Exp")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        string expid = dataGridView_experience.CurrentRow.Cells["Exp_Dr_id"].Value.ToString();
                        string expcompany = dataGridView_experience.CurrentRow.Cells["Exp_Company"].Value.ToString();
                        if (expid != null && expcompany != "")
                        {
                            this.cntrl.delete_experience(expid, expcompany);
                        }
                        DataTable experience = this.cntrl.load_experiecncegrid(expid);
                        dataGridView_experience.DataSource = experience;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_save_awards_Click(object sender, EventArgs e)
        {
            try
            {
                int flagaward = 0;
                if (dataGridView_awards.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView_awards.Rows.Count; i++)
                    {
                        if (dataGridView_awards.Rows[i].Cells["Award_name"].Value.ToString().Trim() == text_awardname.Text.Trim() && dataGridView_awards.Rows[i].Cells["year"].Value.ToString().Trim() == combo_award_year.Text.Trim())
                        {
                            flagaward = 1;
                        }
                    }
                }
                if (flagaward == 0)
                {
                    this.cntrl.save_awards(doctor_id, text_awardname.Text, combo_award_year.Text);
                    text_awardname.Text = "";
                    combo_award_year.SelectedIndex = 0;
                    DataTable awards1 = this.cntrl.load_awards(doctor_id);
                    dataGridView_awards.DataSource = awards1;
                }
                else
                {
                    MessageBox.Show("Award with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_membership_Click(object sender, EventArgs e)
        {
            DataTable member = this.cntrl.load_membercombo();
            combo_membership.DataSource = member;
            combo_membership.DisplayMember = "name";
            combo_membership.ValueMember = "id";
            combo_membership.Text = "";
        }

        private void button_save_membership_Click(object sender, EventArgs e)
        {
            try
            {
                int flagmember = 0;
                if (dataGridView_member.Rows.Count != 0)
                {

                    for (int i = 0; i < dataGridView_member.Rows.Count; i++)
                    {
                        if (dataGridView_member.Rows[i].Cells["col_member"].Value.ToString().Trim() == combo_membership.Text.Trim())
                        {
                            flagmember = 1;
                        }
                    }
                }
                if (flagmember == 0)
                {
                    string member = "";
                    member = combo_membership.Text;
                    string mem_id = this.cntrl.check_membership(member);
                    this.cntrl.save_member(doctor_id, mem_id);
                }
                else
                {
                    MessageBox.Show("Membership with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DataTable member1 = this.cntrl.load_member(doctor_id);
                dataGridView_member.DataSource = member1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_member_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           try
            {
                int r = e.RowIndex;
                if (dataGridView_member.CurrentCell.OwningColumn.Name == "Del_Mebr")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        string memberid = dataGridView_member.CurrentRow.Cells["colm_Member_id"].Value.ToString();
                        if (memberid != null)
                        {
                            this.cntrl.delete_member(doctor_id, memberid);
                        }
                        DataTable member = this.cntrl.load_member(doctor_id);
                        dataGridView_member.DataSource = member;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_reg_save_Click(object sender, EventArgs e)
        {
            try
            {
                int flagReg = 0;
                if (dataGridView_reg.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView_reg.Rows.Count; i++)
                    {
                        if (dataGridView_reg.Rows[i].Cells["col_reg"].Value.ToString().Trim() == combo_reg_regcouncil.Text.Trim() && dataGridView_reg.Rows[i].Cells["column_year"].Value.ToString().Trim() == combo_reg_year.Text.Trim() && dataGridView_reg.Rows[i].Cells["col_regNo"].Value.ToString().Trim() == text_reg_number.Text.Trim())
                        {
                            flagReg = 1;
                        }
                    }
                }
                if (flagReg == 0)
                {
                    string regCouncil = "";
                    regCouncil = combo_reg_regcouncil.Text;
                    string mem_id = this.cntrl.check_council(regCouncil);
                    int mem = int.Parse(mem_id);
                    this.cntrl.save_council(doctor_id, text_reg_number.Text, combo_reg_year.Text, mem_id);
                    text_reg_number.Text = "";
                }
                else
                {
                    MessageBox.Show("Registration Details with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DataTable register = this.cntrl.load_council(doctor_id);
                dataGridView_reg.DataSource = register;
                combo_reg_regcouncil.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_reg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                if (dataGridView_reg.CurrentCell.OwningColumn.Name == "Del_Reg")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        string regid = dataGridView_reg.CurrentRow.Cells["col_regNo"].Value.ToString();
                        if (regid != null)
                        {
                            this.cntrl.delete_council(doctor_id, regid);
                        }
                        DataTable register = this.cntrl.load_council(doctor_id);
                        dataGridView_reg.DataSource = register;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_awards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                if (dataGridView_awards.CurrentCell.OwningColumn.Name == "Del_Awrd")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        string awardname = dataGridView_awards.CurrentRow.Cells["Award_name"].Value.ToString();
                        string dr_id = dataGridView_awards.CurrentRow.Cells["award_colm_Dr_id"].Value.ToString();
                        string stryear = dataGridView_awards.CurrentRow.Cells["year"].Value.ToString();
                        if (awardname != "" && dr_id != null)
                        {
                            this.cntrl.delete_awards(dr_id, awardname, stryear);
                        }
                        DataTable awards = this.cntrl.load_awards(doctor_id);
                        dataGridView_awards.DataSource = awards;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combo_reg_regcouncil_Click(object sender, EventArgs e)
        {
            DataTable reg = this.cntrl.load_councilcombo();
            combo_reg_regcouncil.DataSource = reg;
            combo_reg_regcouncil.DisplayMember = "name";
            combo_reg_regcouncil.ValueMember = "id";
            combo_reg_regcouncil.Text = "";
        }

        public void fill_all_combo()
        {
            combo_reg_regcouncil_Click(null, null);
            combo_membership_Click(null, null);
            combo_service_Click(null, null);
            combo_special_Click(null, null);
            combo_education_college_Click(null, null);
            combo_education_degree_Click(null, null);
        }

        private void button_edit_drname_Click(object sender, EventArgs e)//hiuihi
        {
            if (text_drname.Text == "")
            {
                errorProvider1.SetError(text_drname, "can't be empty");
            }
            else if (text_phone.TextLength < 10)
            {
                errorProvider1.SetError(text_phone, "invalied phone!!");
                MessageBox.Show("Invalied Phone Number !!", "Invalied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                errorProvider1.Dispose();
                string gender = "";
                if (radio_male.Checked == true)
                    gender= "Male";
                else
                    gender= "Female";
                DataTable dt = this.cntrl.get_doctor_deteils(doctor_id);
                string mobile = text_phone.Text;
                string email = dt.Rows[0]["email_id"].ToString();
                try
                {
                    if (txtPic.Text == openFileDialog1.FileName || txtPic.Text == "Image")
                    {
                        RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
                        string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
                        if (txtPic.Text != "")
                        {
                            try
                            {
                                if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\doctor_image\\" + doctor_id))
                                {
                                }
                                else
                                {
                                    System.IO.File.Copy(txtPic.Text, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\doctor_image\\" + doctor_id);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        this.cntrl.update_doctor(doctor_id, text_drname.Text,text_phone.Text, text_email.Text, gender, combo_year.Text, rich_about.Text, txtPic.Text);
                    }
                    else
                    {
                        this.cntrl.update_doctor(doctor_id, text_drname.Text, text_phone.Text, text_email.Text, gender, combo_year.Text, rich_about.Text, txtPic.Text); 
                        MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
      
        private void pictureBox_Docter_Image_Click(object sender, EventArgs e)
        {
            DialogResult ok = MessageBox.Show("Do you wish to add image now?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ok == DialogResult.Yes)
            {
                openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    pictureBox_Docter_Image.Image = Image.FromFile(openFileDialog1.FileName);
                    txtPic.Text = openFileDialog1.FileName;
                }
            }
            else if (ok == DialogResult.No)
            {
                pictureBox_Docter_Image.Image = PappyjoeMVC.Properties.Resources.nophoto;
                txtPic.Text = "";
            }
            else
            {
                pictureBox_Docter_Image.Image = null;
            }
        }
        //clinic details
        private void button_GoToClinic_Click(object sender, EventArgs e)
        {
            try
            {
                string clinicid = "";
                clinic_combo();
                panel_edit_dr.Visible=false;
                panel_clinicaldetails.Visible=true;
                panel_clinicaldetails.Location = new Point(2,42);
                DataTable practice = this.cntrl.get_companydetails();
                if (practice.Rows.Count > 0)
                {
                    clinicid = practice.Rows[0]["id"].ToString();
                    DataTable service1 = this.cntrl.clinic_service(clinicid);
                    dataGridView_clinic_service.DataSource = service1;
                    DataTable special = this.cntrl.cinic_specilization(clinicid);
                    dataGridView_clinic_special.DataSource = special;
                    if (practice.Rows[0]["name"].ToString() != "")
                    {
                        string clinicn = "";
                        clinicn = practice.Rows[0]["name"].ToString();
                        text_clinic_name.Text = clinicn.Replace("¤", "'");
                    }

                    text_website.Text = practice.Rows[0]["website"].ToString();
                    text_tagline.Text = practice.Rows[0]["tagline"].ToString();
                    rich_clinic_about.Text = practice.Rows[0]["about"].ToString();
                    text_clinic_mobile.Text = practice.Rows[0]["contact_no"].ToString();
                    text_clinic_email.Text = practice.Rows[0]["email"].ToString();
                    string path = practice.Rows[0]["path"].ToString();
                    try
                    {
                        pictureBox_logo.Image = Image.FromFile(db.server() + path);
                    }
                    catch
                    {
                        pictureBox_logo.Image = PappyjoeMVC.Properties.Resources.nophoto;
                    }
                    if (dataGridView_clinic_service.Rows.Count > 0)
                    {
                        dataGridView_clinic_service.CurrentCell.Selected = false;
                    }
                    if (dataGridView_clinic_special.Rows.Count > 0)
                    {
                        dataGridView_clinic_special.CurrentCell.Selected = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button_clinic_servaddnew_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "1";
            frm.ShowDialog(this);
        }

        private void button_clinic_specialaddnew_Click(object sender, EventArgs e)
        {
            Doctors_Practice_Details frm = new Doctors_Practice_Details();
            frm.frameid = "6";
            frm.ShowDialog(this);
        }

        private void combo_clinic_service_Click(object sender, EventArgs e)
        {
            DataTable service = this.cntrl.load_serviceCombo();
            combo_clinic_service.DataSource = service;
            combo_clinic_service.DisplayMember = "service";
            combo_clinic_service.ValueMember = "id";
            combo_clinic_service.Text = "";
        }

        private void combo_clinic_special_Click(object sender, EventArgs e)
        {
            DataTable special = this.cntrl.load_cmbspecilization();
            combo_clinic_special.DataSource = special;
            combo_clinic_special.DisplayMember = "name";
            combo_clinic_special.ValueMember = "id";
            combo_clinic_special.Text = "";
        }
        public void clinic_combo()
        {
            combo_clinic_service_Click(null, null);
            combo_clinic_special_Click(null, null);
        }

        private void button_clinicservicesave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable clinicid = this.cntrl.practice_id();
                 if (dataGridView_clinic_service.Rows.Count > 0)
                 {
                     if (itemcheck() == 0)
                     {
                         string ser_id = this.cntrl.getserviceid(combo_clinic_service.Text);
                         int serv = int.Parse(ser_id);
                         this.cntrl.save_clinic_service(clinicid.Rows[0]["id"].ToString(), ser_id);
                     }
                 }
                 else
                 {
                     string ser_id = this.cntrl.getserviceid(combo_clinic_service.Text);
                     int serv = int.Parse(ser_id);
                     this.cntrl.save_clinic_service(clinicid.Rows[0]["id"].ToString(), ser_id);
                 }
                 DataTable service1 = this.cntrl.load_clinic_services(clinicid.Rows[0]["id"].ToString());
                 dataGridView_clinic_service.DataSource = service1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        public int itemcheck()
        {
            int affected = 0;
            for (int i = 0; i < dataGridView_clinic_service.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_clinic_service.Columns.Count; j++)
                {
                    if (dataGridView_clinic_service.Rows[i].Cells[j].Value != null && combo_clinic_service.Text == dataGridView_clinic_service.Rows[i].Cells[j].Value.ToString())
                    {
                        MessageBox.Show("The value already existed ", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        affected = 1;
                    }
                }
            }
            return affected;
        }

        private void button_clinic_servdelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable clinicid = this.cntrl.get_companyName();
                this.cntrl.delete_clinic_service(clinicservice, clinicid.Rows[0]["id"].ToString());
                DataTable service1 = this.cntrl.load_clinic_services(clinicid.Rows[0]["id"].ToString());
                dataGridView_clinic_service.DataSource = service1;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_clinic_service_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                clinicservice = dataGridView_clinic_service.Rows[r].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clinicspecialsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable clinicid = this.cntrl.practice_id();
                if (dataGridView_clinic_special.Rows.Count > 0)
                {
                    if(specilization_itemcheck()==0)
                    {
                        string spc_id = this.cntrl.get_specilizationid(combo_clinic_special.Text);
                        int serv = int.Parse(spc_id);
                        this.cntrl.save_clinic_specilization(clinicid.Rows[0]["id"].ToString(),spc_id);
                    }
                }
                else
                {
                    string spc_id = this.cntrl.get_specilizationid(combo_clinic_special.Text);
                    int serv = int.Parse(spc_id);
                    this.cntrl.save_clinic_specilization(clinicid.Rows[0]["id"].ToString(), spc_id);
                }
                DataTable specialGrid = this.cntrl.cinic_specilization(clinicid.Rows[0]["id"].ToString());
                dataGridView_clinic_special.DataSource = specialGrid;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int specilization_itemcheck()
        {
            int affected = 0;
            for (int i = 0; i < dataGridView_clinic_special.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_clinic_special.Columns.Count; j++)
                {
                    if (dataGridView_clinic_special.Rows[i].Cells[j].Value != null && combo_clinic_special.Text == dataGridView_clinic_special.Rows[i].Cells[j].Value.ToString())
                    {
                        MessageBox.Show("The value already existed ", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        affected = 1;
                    }
                }
            }
            return affected;
        }

        private void button_clinic_specialdelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable clinicid = this.cntrl.practice_id();
                this.cntrl.delete_clinicspecilization(clinicspecial, clinicid.Rows[0]["id"].ToString());
                DataTable special = this.cntrl.cinic_specilization(clinicid.Rows[0]["id"].ToString());
                dataGridView_clinic_special.DataSource = special;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_clinic_special_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                clinicspecial = dataGridView_clinic_special.Rows[r].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox_logo_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog2.ShowDialog();
                openFileDialog2.Filter = "Images|*.jpeg;*.jpg;*.png;*.gif";
                pictureBox_logo.Image = Image.FromFile(openFileDialog2.FileName);
                clinicpath = openFileDialog2.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_clinic_logo_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtb = this.cntrl.get_company_details();
                if(dtb.Rows.Count>0)
                {
                    this.cntrl.update_clinicdetails(text_clinic_name.Text, text_tagline.Text, text_clinic_mobile.Text, text_clinic_email.Text, text_website.Text, rich_clinic_about.Text);
                }
                else
                {
                    this.cntrl.save_details(text_clinic_name.Text, text_tagline.Text, text_clinic_mobile.Text, text_clinic_email.Text, text_website.Text, rich_clinic_about.Text);
                }
                MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            panel_clinicaldetails.Hide();
            panel_edit_dr.Show();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 330, 1);
            }
            else
            {
                listpatientsearch.Visible = false;
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

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id=this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.Add_New_Patients();
                form2.doctor_id = doctor_id;
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Login();
            form2.Closed += (sender1, args) => this.Close();
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

        private void panel_edit_dr_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
