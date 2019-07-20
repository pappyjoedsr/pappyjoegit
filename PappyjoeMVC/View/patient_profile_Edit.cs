﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class patient_profile_Edit : Form,patient_edit_interface
    {
        public string patient_id = "";
        public string doctor_id = "";
        patient_edit_controller cntrl;
        common_model mdl = new common_model();
        Connection db = new Connection();
        public string aa, bb, gg, caaa, uaaa, ubbb, loadedPath = "";
        public string path = "";
        private void grmedical_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int b = e.RowIndex;
            bb = grmedical.Rows[b].Cells[0].Value.ToString();
        }

        private void DateTimePickerDob_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Now.Year - DateTimePickerDob.Value.Year - (DateTime.Now.DayOfYear < DateTimePickerDob.Value.DayOfYear ? 1 : 0);
            txtAge.Text = age.ToString();
        }

        private void txtPrimaryMobNbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtAdmitDate_Click(object sender, EventArgs e)
        {
            DateTimePickerAdmitDate.Show();
            txtAdmitDate.Hide();
        }

        private void txtSecondaryMobNbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtLandLineNbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
        public string Ptname
        {
            get { return this.txtPatientName.Text; }
            set{txtPatientName.Text = value;}
        }
        public string patId
        {
            get { return this.txtPatientId.Text; }
            set { txtPatientId.Text = value; }
        }
        public string aadhar
        {
            get { return this.txtAdhaarId.Text; }
            set { txtAdhaarId.Text = value; }
        }
        public string age
        {
            get { return this.txtAge.Text; }
            set { txtAge.Text = value; }
        }
        public string blood
        {
            get
            {
                if (cmbBloodGroup.Text != "Select")
                {
                    return  cmbBloodGroup.Text;
                }
                else
                    return  "";
                
            }
            set { cmbBloodGroup.Text = value; }
        }
        public string family
        {
            get { return this.txtAccompaniedBy.Text; }
            set { txtAccompaniedBy.Text = value; }
        }
        public string Pmob
        {
            get { return this.txtPrimaryMobNbr.Text; }
            set { txtPrimaryMobNbr.Text = value; }
        }
        public string Smob
        {
            get { return this.txtSecondaryMobNbr.Text; }
            set { txtSecondaryMobNbr.Text = value; }
        }
        public string Landline
        {
            get { return this.txtLandLineNbr.Text; }
            set { txtLandLineNbr.Text = value; }
        }
        public string street
        {
            get { return this.txtStreetAddress.Text; }
            set { txtStreetAddress.Text = value; }
        }

        public string email
        {
            get { return this.txtEmail.Text; }
            set { txtEmail.Text = value; }
        }
        public string locality
        {
            get { return this.txtLocality.Text; }
            set { txtLocality.Text = value; }
        }
        public string city
        {
            get { return this.txtCity.Text; }
            set { txtCity.Text = value; }
        }
        public string opticket
        {
            get { return this.txtFileNo.Text; }
            set { txtFileNo.Text = value; }
        }

        public string pin
        {
            get { return this.txtPin.Text; }
            set { txtPin.Text = value; }
        }
        
        public string refferedby
        {
            get { return this.txtReferredBy.Text; }
            set { txtReferredBy.Text = value; }
        }
        public string doctername
        {
            get { return this.cmbDoctorName.Text; }
            set { cmbDoctorName.Text = value; }
        }
        public string occupation
        {
            get { return this.txtOccupation.Text; }
            set { txtOccupation.Text = value; }
        }
       
        public string Gender
        {
            get
            {
                if (RBtnMale.Checked == true)
                    return "Male";
                else
                    return "Female";
            }
            set
            {
                if (value == "Male")
                    RBtnMale.Checked = true;
                else
                    RBtnFemale.Checked = true;
            }
        }
        public string AdmitDate
        {
            get
            {
                if (DateTime.Now.Date.ToString("MM/dd/yyyy") == DateTimePickerAdmitDate.Value.ToString("MM/dd/yyyy"))
                {
                    return DateTimePickerAdmitDate.Value.ToString("yyyy-MM-dd");
                }
                else
                {
                    return DateTimePickerAdmitDate.Value.ToString("yyyy-MM-dd");
                }
            }
            set
            {
                DateTimePickerAdmitDate.Value =Convert.ToDateTime(value);
            }
        }
        public string Visited
        {
            get
            {
                if (DateTimePickerAdmitDate.Visible == true)
                {
                    if (DateTime.Now.Date.ToString("MM/dd/yyyy") == DateTimePickerAdmitDate.Value.ToString("MM/dd/yyyy"))
                    {
                        return  DateTimePickerAdmitDate.Value.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        return  DateTimePickerAdmitDate.Value.ToString("yyyy-MM-dd");
                    } 
                }
                return DateTimePickerAdmitDate.Value.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTimePickerAdmitDate.Value = Convert.ToDateTime(value); 
            }
        }
        string dob = "null";
        public string Dob
        {
            get
            {
                if (DateTimePickerDob.Visible == true)
                {
                    if (DateTime.Now.Date.ToString("MM/dd/yyyy") == DateTimePickerDob.Value.ToString("MM/dd/yyyy"))
                    {
                        dob= null;
                    }
                    else
                    {
                        dob= DateTimePickerDob.Value.ToString("yyyy-MM-dd");
                    }
                }
                return dob;
            }
            set
            {
                DateTimePickerDob.Value =Convert.ToDateTime(value);
            }
        }
        private void btnSavePatient_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (String.IsNullOrWhiteSpace(txtPatientName.Text))
                {
                    MessageBox.Show("Please enter Patient Name", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (txtPrimaryMobNbr.Text != "")
                    {
                        i = this.cntrl.update(patient_id);
                        if (i > 0)
                        {
                            if (pictureBox_PatientPhoto.Image == null)
                            {
                                pictureBox_PatientPhoto.Image = PappyjoeMVC.Properties.Resources.nophoto;
                                txtPic.Text = "";
                            }
                            int delete = db.execute("delete  from tbl_pt_medhistory where pt_id='" + patient_id + "'");
                            for (int q = 0; q < grmedical.Rows.Count; q++)
                            {
                                if (Convert.ToBoolean(grmedical.Rows[q].Cells[1].Value) == true)
                                {
                                    int medi = db.execute("insert into tbl_pt_medhistory (pt_id,med_id) values('" + patient_id + "','" + grmedical.Rows[q].Cells[0].Value.ToString() + "')");
                                }
                            }
                            ///////update pt_group ////////   
                            int dele = db.execute("delete from tbl_pt_group where pt_id='" + patient_id + "'");
                            for (int d = 0; d < gridgroups.Rows.Count; d++)
                            {
                                if (Convert.ToBoolean(gridgroups.Rows[d].Cells[1].Value) == true)
                                {
                                    int inse = db.execute("insert into  tbl_pt_group(pt_id,group_id) values('" + patient_id + "','" + gridgroups.Rows[d].Cells[0].Value.ToString() + "')");
                                }
                            }
                            //string imagepath = "";
                            //try
                            //{
                            //    imagepath = db.server() + "\\Pappyjoe_utilities\\patient_image\\" + patient_id;
                            //    if (!File.Exists(imagepath))
                            //    {
                            //        string p = db.server() + "\\Pappyjoe_utilities\\patient_image\\" + patient_id;
                            //        string realfile = System.IO.Path.GetFileName(path);
                            //        System.IO.File.Copy(path, db.server() + "\\Pappyjoe_utilities\\patient_image\\" + realfile);
                            //    }
                            //}
                            //catch (Exception ex)
                            //{ }
                            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("Pappyjoe");
                            string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
                            if (path != "")
                            {

                                try
                                {
                                if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\patient_image\\" + patient_id))
                                {
                                }
                                else
                                {
                                    System.IO.File.Copy(path, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\patient_image\\" + patient_id);
                                }
                            }
                                catch (Exception ex)
                                {
                                }
                            }
                            var form2 = new patient_profile_details();
                            form2.doctor_id = doctor_id;
                            form2.patient_id = patient_id;
                            profile_details_controller controller = new profile_details_controller(form2);
                            form2.Closed += (sender1, args) => this.Close();
                            this.Hide();
                            form2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Updation Failed !!!....", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter valid Mobile Number", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox_PatientPhoto_Click(object sender, EventArgs e)
        {
            DialogResult ok = MessageBox.Show("The image can be saved just once. Do you wish to add one now?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ok == DialogResult.Yes)
            {
                openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
                DialogResult res = openFileDialog1.ShowDialog();
                path = openFileDialog1.FileName;
                if (res == DialogResult.OK)
                {
                    pictureBox_PatientPhoto.Image = Image.FromFile(openFileDialog1.FileName);
                    txtPic.Text = openFileDialog1.FileName;
                }
            }
            else if (ok == DialogResult.No)
            {
                pictureBox_PatientPhoto.Image = PappyjoeMVC.Properties.Resources.nophoto;
                txtPic.Text = "";
            }
            else
            {
                pictureBox_PatientPhoto.Image = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = patient_id;
            try
            {
                if (MessageBox.Show("Are you sure you want to permanently delete the patient details?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int i = 0;
                    i = this.cntrl.delete_patient(id);
                    if (i > 0)
                    {
                        MessageBox.Show("Patient Deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var form2 = new patients();
                        form2.doctor_id = doctor_id;
                        patients_controller controller = new patients_controller(form2);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMedicalHistoryAddnew_Click(object sender, EventArgs e)
        {
            btnMedicalHistoryCancel.Show();
            btnSave.Show();
            txtMedicalHistory.Show();
            btnMedicalHistoryAddnew.Hide();
            grmedical.Location = new Point(6, 61);
            grmedical.Height = 176;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtMedicalHistory.Text))
            {
               this.cntrl.save(txtMedicalHistory.Text);
                grmedical.Rows.Add(txtMedicalHistory.Text);
            }
            btnMedicalHistoryCancel.Hide();
            btnSave.Hide();
            txtMedicalHistory.Hide();
            btnMedicalHistoryAddnew.Show();
            txtMedicalHistory.Text = "";
            grmedical.Location = new Point(6, 30);
            grmedical.Height = 207;
        }

        private void btnMedicalHistoryCancel_Click(object sender, EventArgs e)
        {
            btnMedicalHistoryCancel.Hide();
            btnSave.Hide();
            txtMedicalHistory.Hide();
            btnMedicalHistoryAddnew.Show();
            grmedical.Location = new Point(6, 30);
            grmedical.Height = 207;
        }

        private void btnGroupsAddNew_Click(object sender, EventArgs e)
        {
            btnGroupsCancel.Show();
            btnGroupsSave.Show();
            txtGroups.Show();
            btnGroupsAddNew.Hide();
            gridgroups.Location = new Point(6,60);
            gridgroups.Height = 168;
        }

        private void btnGroupsSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtGroups.Text))
            {
                this.cntrl.save_group(txtGroups.Text);
                gridgroups.Rows.Add(txtGroups.Text);
            }
            btnGroupsCancel.Hide();
            btnGroupsSave.Hide();
            txtGroups.Hide();
            btnGroupsAddNew.Show();
            txtGroups.Text = "";
            gridgroups.Location = new Point(6,30);
            gridgroups.Height = 198;
        }

        private void btnGroupsCancel_Click(object sender, EventArgs e)
        {
            btnGroupsCancel.Hide();
            btnGroupsSave.Hide();
            txtGroups.Hide();
            btnGroupsAddNew.Show();
            gridgroups.Location = new Point(6,30);
            gridgroups.Height = 198;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form2 = new patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            profile_details_controller controller = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void cmbBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbDoctorName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public patient_profile_Edit()
        {
            InitializeComponent();
        }
        public void Setcontroller(patient_edit_controller cntroller)
        {
            cntrl = cntroller;
        }

        private void patient_profile_Edit_Load(object sender, EventArgs e)
        {
            DataTable dt_doc = mdl.get_all_doctorname();
            cmbDoctorName.DataSource = dt_doc;
            cmbDoctorName.ValueMember = "id";
            cmbDoctorName.DisplayMember = "doctor_name";
            DateTimePickerDob.MaxDate = DateTime.Now.Date;
            try
            {
               
                if (doctor_id != "1")
                {
                    string id;
                    id = mdl.privillage_E(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        btnSavePatient.Enabled = false;
                    }
                    else
                    {
                        btnSavePatient.Enabled = true;
                    }
                    id = mdl.privillage_D(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                        btnDelete.Enabled = true;
                    }
                }
                this.MinimumSize = new System.Drawing.Size(570, 650);
                this.AutoSize = true;
                this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                this.cntrl.get_medicalId(patient_id);
                this.cntrl.get_groupid(patient_id);
                DataTable dt7 = mdl.Get_Patient_Details(patient_id);
                txtPatientName.Text = dt7.Rows[0]["pt_name"].ToString();
                txtPatientId.Text = dt7.Rows[0]["pt_id"].ToString();
                txtPatientId.BackColor = Color.White;
                txtAdhaarId.Text = dt7.Rows[0]["aadhar_id"].ToString();
                if (dt7.Rows[0]["gender"].ToString() == "Male")
                {
                    RBtnMale.Checked = true;
                }
                else
                {
                    RBtnFemale.Checked = true;
                }
                string aa = dt7.Rows[0]["date_of_birth"].ToString();
                if (dt7.Rows[0]["date_of_birth"].ToString() != "")
                {
                    DateTimePickerDob.Show();
                    txtDob.Hide();
                    DateTimePickerDob.Value = DateTime.Parse(DateTime.Parse(dt7.Rows[0]["date_of_birth"].ToString()).ToString("yyyy-MM-dd"));
                }
                else
                {
                    txtDob.Show();
                    DateTimePickerDob.Hide();
                    txtDob.Text = "click here to choose a date";
                }
                if (dt7.Rows[0]["age"].ToString() != "0")
                {
                    txtAge.Text = dt7.Rows[0]["age"].ToString();
                }
                else
                {
                    txtAge.Text = "";
                }
                cmbBloodGroup.Text = dt7.Rows[0]["blood_group"].ToString();
                txtAccompaniedBy.Text = dt7.Rows[0]["family"].ToString();
                txtOccupation.Text = dt7.Rows[0]["Occupation"].ToString();
                txtPrimaryMobNbr.Text = dt7.Rows[0]["primary_mobile_number"].ToString();
                txtSecondaryMobNbr.Text = dt7.Rows[0]["secondary_mobile_number"].ToString();
                txtLandLineNbr.Text = dt7.Rows[0]["landline_number"].ToString();
                txtEmail.Text = dt7.Rows[0]["email_address"].ToString();
                txtStreetAddress.Text = dt7.Rows[0]["street_address"].ToString();
                txtLocality.Text = dt7.Rows[0]["locality"].ToString();
                txtCity.Text = dt7.Rows[0]["city"].ToString();
                txtPin.Text = dt7.Rows[0]["pincode"].ToString();
                txtReferredBy.Text = dt7.Rows[0]["refferedby"].ToString();
                txtFileNo.Text = dt7.Rows[0]["Opticket"].ToString();
                string bb = dt7.Rows[0]["Visited"].ToString();
                if (dt7.Rows[0]["Visited"].ToString() != "")
                {
                    DateTimePickerAdmitDate.Show();
                    txtAdmitDate.Hide();
                    DateTimePickerAdmitDate.Value = DateTime.Parse(DateTime.Parse(dt7.Rows[0]["Visited"].ToString()).ToString("yyyy-MM-dd"));
                }
                else
                {
                    DateTimePickerAdmitDate.Hide();
                    txtAdmitDate.Text = "click here to choose a date";
                }
                cmbDoctorName.Text = dt7.Rows[0]["doctorname"].ToString();
                try
                {
                    string curFile = db.server() + "\\Pappyjoe_utilities\\patient_image\\" + patient_id;
                    if (System.IO.File.Exists(curFile))
                    {
                        pictureBox_PatientPhoto.Image = Image.FromFile(curFile);
                    }
                    else
                    {
                        pictureBox_PatientPhoto.Image = PappyjoeMVC.Properties.Resources.nophoto;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Fill_modeical(DataTable dt8)
        {
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn()
            {
                Name = "Check"
            };
            grmedical.Columns.Add(check);
            check.Width = 100;
            check.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (dt8.Rows.Count > 0)
            {
                for (int j = 0; j < dt8.Rows.Count; j++)
                {
                    grmedical.Rows.Add(dt8.Rows[j][0].ToString());
                    grmedical.Rows[j].Cells[1].Value = true;
                    grmedical.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(62, 165, 195);
                    grmedical.Rows[j].Cells[1].Style.BackColor = Color.FromArgb(62, 165, 195);
                }
            }
            DataTable dt35 = this.cntrl.Get_medicalname();
            for (int j = 0; j < dt35.Rows.Count; j++)
            {
                DataTable mht = this.cntrl.patient_medical(patient_id, dt35.Rows[j][0].ToString());
                if (mht.Rows.Count == 0)
                {
                    grmedical.Rows.Add(dt35.Rows[j][0].ToString());
                }
            }
        }

        public void Fill_Group(DataTable group)
        {
            DataGridViewCheckBoxColumn checkgroup = new DataGridViewCheckBoxColumn()
            {
                Name = "Check"
            };
            gridgroups.Columns.Add(checkgroup);
            checkgroup.Width = 100;
            checkgroup.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            for (int j = 0; j < group.Rows.Count; j++)
            {
                gridgroups.Rows.Add(group.Rows[j][0].ToString());
                gridgroups.Rows[j].Cells[1].Value = true;
                gridgroups.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(62, 165, 195);
                gridgroups.Rows[j].Cells[1].Style.BackColor = Color.FromArgb(62, 165, 195);
            }
            DataTable dt9 = this.cntrl.groupname();
            for (int j = 0; j < dt9.Rows.Count; j++)
            {
                DataTable gt = this.cntrl.patient_group(patient_id, dt9.Rows[j][0].ToString());
                if (gt.Rows.Count == 0)
                {
                    gridgroups.Rows.Add(dt9.Rows[j][0].ToString());
                }
            }
        }

        private void gridgroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;
            aa = gridgroups.Rows[a].Cells[0].Value.ToString();
        }

    }
}