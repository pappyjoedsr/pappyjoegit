using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Patient_Profile_Details : Form
    {
        public string patient_id = "0";
        public string doctor_id = "0", admin_id = "0";
        Profile_Details_controller cntrl = new Profile_Details_controller();
        Connection db = new Connection();
        public string ptid { get; set; }
        public Patient_Profile_Details()
        {
            InitializeComponent();
        }

        private void patient_profile_details_Load(object sender, EventArgs e)
        {
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;//to set to the screen size
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.get_dctr_privillage(doctor_id);
                if (int.Parse(id) > 0)
                {
                    editpatient.Enabled = false;
                }
                else
                {
                    editpatient.Enabled = true;
                }
            }
            
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            DataTable dtadvance = this.cntrl.Get_Advance(patient_id);
            if (dtadvance.Rows.Count > 0)
            {
                lblAdvance.Show();
                lblAdvance.Text = "Available advance: " + string.Format("{0:C}", decimal.Parse(dtadvance.Rows[0][0].ToString()));
            }
            else
            {
                lblAdvance.Text = "Available advance: " + string.Format("{0:C}", 0);
            }
            BTNCunsultation.Hide();
            toolStripButton1.Text = this.cntrl.Load_CompanyName();
            string docnam = this.cntrl.Get_DoctorName(doctor_id);
            if (docnam != "")
            {
                toolStripldoc.Text = "Logged As:Dr." + docnam;
            }

            DataTable dtb = this.cntrl.Get_Patient_details(patient_id);
            patientload(dtb);
        }
        public void patientload(DataTable rs_patients)
        {
            if (rs_patients.Rows.Count > 0)
            {
                int YX1 = 141;
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    lab_PatientName.Show();
                    linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                }
                else
                {
                    txtPatientName.Hide();
                    lab_PatientName.Hide();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    labPatientId.Show();
                    labPatientId.Location = new Point(415, YX1);
                    labPatientId.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                //DateTime date_of_submission = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
                //DateTime date_of_submission = DateTime.Now;
                //DateTime _effective_date = Convert.ToDateTime(rs_patients.Rows[0]["Visited"].ToString());
                //TimeSpan difference = date_of_submission - _effective_date;
                try
                {
                    int YX = 20;
                    if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                    {
                        txtPatientName.Text = rs_patients.Rows[0]["pt_name"].ToString();
                        txtPatientName.BackColor = Color.White;
                        lab_PatientName.Show();
                        linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                    }
                    else
                    {
                        txtPatientName.Hide();
                        lab_PatientName.Hide();
                    }
                    if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                    {
                        txtPatientId.Text = rs_patients.Rows[0]["pt_id"].ToString();
                        txtPatientId.BackColor = Color.White;
                        YX = YX + 30;
                        txtPatientId.Location = new Point(303, YX);
                        txtPatientId.Show();
                        labPatientId.Show();
                        labPatientId.Location = new Point(201, YX);
                        linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                    }
                    else
                    {
                        txtPatientId.Hide();
                        labPatientId.Hide();
                    }
                    if (rs_patients.Rows[0]["aadhar_id"].ToString() != "")
                    {
                        txtAdhaarId.Text = rs_patients.Rows[0]["aadhar_id"].ToString();
                        txtAdhaarId.BackColor = Color.White;
                        txtAdhaarId.Show();
                        YX = YX + 30;
                        txtAdhaarId.Location = new Point(303, YX);
                        labAdhaarId.Show();
                        labAdhaarId.Location = new Point(192, YX);
                    }
                    else
                    {
                        txtAdhaarId.Hide();
                        labAdhaarId.Hide();
                    }
                    if (rs_patients.Rows[0]["gender"].ToString() != "")
                    {
                        txtGender.Text = rs_patients.Rows[0]["gender"].ToString();
                        YX = YX + 30;
                        txtGender.Location = new Point(303, YX);
                        txtGender.BackColor = Color.White;
                        txtGender.Show();
                        labGender.Show();
                        labGender.Location = new Point(217, YX);
                    }
                    else
                    {
                        txtGender.Hide();
                        labGender.Hide();
                    }
                    int a = 0;
                    if (rs_patients.Rows[0]["date_of_birth"].ToString() != "")
                    {
                        txtDob.Text = DateTime.Parse(rs_patients.Rows[0]["date_of_birth"].ToString()).ToString("MM/dd/yyyy");
                        txtDob.BackColor = Color.White;
                        YX = YX + 30;
                        txtDob.Location = new Point(303, YX);
                        txtDob.Show();
                        labDob.Show();
                        labDob.Location = new Point(182, YX);
                        a = 1;
                    }
                    else
                    {
                        txtDob.Hide();
                        labDob.Hide();
                    }
                    if (rs_patients.Rows[0]["refferedby"].ToString() != "")
                    {
                        txtRefferedBy.Text = rs_patients.Rows[0]["refferedby"].ToString();
                        txtRefferedBy.BackColor = Color.White;
                        YX = YX + 30;
                        txtRefferedBy.Location = new Point(303, YX);
                        txtRefferedBy.Show();
                        labRefferedBy.Show();
                        labRefferedBy.Location = new Point(188, YX);
                    }
                    else
                    {
                        txtRefferedBy.Hide();
                        labRefferedBy.Hide();
                    }
                    if (rs_patients.Rows[0]["blood_group"].ToString() != "")
                    {
                        txtBloodGroup.Text = rs_patients.Rows[0]["blood_group"].ToString();
                        txtBloodGroup.BackColor = Color.White;
                        YX = YX + 30;
                        txtBloodGroup.Location = new Point(303, YX);
                        txtBloodGroup.Show();
                        labBloodGroup.Show();
                        labBloodGroup.Location = new Point(180, YX);
                    }
                    else
                    {
                        txtBloodGroup.Hide();
                        labBloodGroup.Hide();
                    }
                    if (rs_patients.Rows[0]["family"].ToString() != "")
                    {
                        txtAccompainedBy.Text = rs_patients.Rows[0]["family"].ToString();
                        txtAccompainedBy.BackColor = Color.White;
                        YX = YX + 30;
                        txtAccompainedBy.Location = new Point(303, YX);
                        txtAccompainedBy.Show();
                        labAccompainedBy.Show();
                        labAccompainedBy.Location = new Point(153, YX);
                    }
                    else
                    {
                        txtAccompainedBy.Hide();
                        labAccompainedBy.Hide();
                    }
                    YX = YX + 30;
                    labhead.Location = new Point(180, YX);
                    labhead.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    YX = YX + 10;
                    if (rs_patients.Rows[0]["primary_mobile_number"].ToString() != "")
                    {
                        txtPrimaryMobNo.Text = rs_patients.Rows[0]["primary_mobile_number"].ToString();
                        txtPrimaryMobNo.BackColor = Color.White;
                        YX = YX + 30;
                        txtPrimaryMobNo.Location = new Point(303, YX);
                        txtPrimaryMobNo.Show();
                        labPrimaryMobileNumber.Show();
                        labPrimaryMobileNumber.Location = new Point(100, YX);
                    }
                    else
                    {
                        txtPrimaryMobNo.Hide();
                        labPrimaryMobileNumber.Hide();
                    }
                    if (rs_patients.Rows[0]["secondary_mobile_number"].ToString() != "")
                    {
                        txtSecondaryMobNo.Text = rs_patients.Rows[0]["secondary_mobile_number"].ToString();
                        txtSecondaryMobNo.BackColor = Color.White;
                        YX = YX + 30;
                        txtSecondaryMobNo.Location = new Point(305, YX);
                        txtSecondaryMobNo.Show();
                        labSecondaryMobileNumbr.Show();
                        labSecondaryMobileNumbr.Location = new Point(120, YX);
                    }
                    else
                    {
                        txtSecondaryMobNo.Hide();
                        labSecondaryMobileNumbr.Hide();
                    }
                    if (rs_patients.Rows[0]["landline_number"].ToString() != "")
                    {
                        txtLandLineNo.Text = rs_patients.Rows[0]["landline_number"].ToString();
                        txtLandLineNo.BackColor = Color.White;
                        YX = YX + 30;
                        txtLandLineNo.Location = new Point(305, YX);
                        txtLandLineNo.Show();
                        labLandLineNo.Show();
                        labLandLineNo.Location = new Point(178, YX);
                    }
                    else
                    {
                        txtLandLineNo.Hide();
                        labLandLineNo.Hide();
                    }
                    if (rs_patients.Rows[0]["email_address"].ToString() != "")
                    {
                        txtEmailAddress.Text = rs_patients.Rows[0]["email_address"].ToString();
                        txtEmailAddress.BackColor = Color.White;
                        YX = YX + 30;
                        txtEmailAddress.Location = new Point(305, YX);
                        txtEmailAddress.Show();
                        labEmailAddress.Show();
                        labEmailAddress.Location = new Point(172, YX);
                    }
                    else
                    {
                        txtEmailAddress.Hide();
                        labEmailAddress.Hide();
                    }
                    if (rs_patients.Rows[0]["street_address"].ToString() != "")
                    {
                        txtStreetAddress.Text = rs_patients.Rows[0]["street_address"].ToString();
                        txtStreetAddress.BackColor = Color.White;
                        YX = YX + 30;
                        txtStreetAddress.Location = new Point(305, YX);
                        txtStreetAddress.Show();
                        labStreetAddress.Show();
                        labStreetAddress.Location = new Point(170, YX);
                    }
                    else
                    {
                        txtStreetAddress.Hide();
                        labStreetAddress.Hide();
                    }
                    if (rs_patients.Rows[0]["locality"].ToString() != "")
                    {
                        txtLocality.Text = rs_patients.Rows[0]["locality"].ToString();
                        txtLocality.BackColor = Color.White;
                        YX = YX + 30;
                        txtLocality.Location = new Point(305, YX);
                        txtLocality.Show();
                        labLocality.Show();
                        labLocality.Location = new Point(217, YX);
                    }
                    else
                    {
                        txtLocality.Hide();
                        labLocality.Hide();
                    }
                    if (rs_patients.Rows[0]["city"].ToString() != "")
                    {
                        txtCity.Text = rs_patients.Rows[0]["city"].ToString();
                        txtCity.BackColor = Color.White;
                        YX = YX + 30;
                        txtCity.Location = new Point(305, YX);
                        txtCity.Show();
                        labCity.Show();
                        labCity.Location = new Point(243, YX);
                    }
                    else
                    {
                        txtCity.Hide();
                        labCity.Hide();
                    }
                    if (rs_patients.Rows[0]["pincode"].ToString() != "")
                    {
                        txtPinCode.Text = rs_patients.Rows[0]["pincode"].ToString();
                        txtPinCode.BackColor = Color.White;
                        YX = YX + 30;
                        txtPinCode.Location = new Point(305, YX);
                        txtPinCode.Show();
                        labPinCode.Show();
                        labPinCode.Location = new Point(216, YX);
                    }
                    else
                    {
                        txtPinCode.Hide();
                        labPinCode.Hide();
                    }
                    if (rs_patients.Rows[0]["nationality"].ToString() != "")
                    {
                        txtnationality.Text = rs_patients.Rows[0]["nationality"].ToString();
                        txtnationality.BackColor = Color.White;
                        YX = YX + 30;
                        txtnationality.Location = new Point(305, YX);
                        txtnationality.Show();
                        labnationality.Show();
                        labnationality.Location = new Point(200, YX);
                    }
                    else
                    {
                        txtnationality.Hide();
                        labnationality.Hide();
                    }
                    if (rs_patients.Rows[0]["passport_no"].ToString() != "")
                    {
                        txtpassport.Text = rs_patients.Rows[0]["passport_no"].ToString();
                        txtpassport.BackColor = Color.White;
                        YX = YX + 30;
                        txtpassport.Location = new Point(305, YX);
                        txtpassport.Show();
                        labpassport.Show();
                        labpassport.Location = new Point(200, YX);
                    }
                    else
                    {
                        txtpassport.Hide();
                        labpassport.Hide();
                    }
                    YX = 50;
                    if (rs_patients.Rows[0]["Opticket"].ToString() != "")
                    {
                        txtopticket.Text = rs_patients.Rows[0]["Opticket"].ToString();
                        txtopticket.BackColor = Color.White;
                        txtopticket.Location = new Point(634, YX);
                        txtopticket.Show();
                        lblopti.Show();
                        txtopticket.Show();
                        lblopti.Location = new Point(553, YX);
                    }
                    else
                    {
                        txtopticket.Hide();
                        lblopti.Hide();
                    }
                    if (a == 1)
                    {
                        if (rs_patients.Rows[0]["age"].ToString() != "")
                        {
                            if (Convert.ToInt32(rs_patients.Rows[0]["age"].ToString()) != 0)
                            {
                                txtAge.Text = rs_patients.Rows[0]["age"].ToString();
                                txtAge.Show();
                                txtAge.BackColor = Color.White;
                                YX = YX + 30;
                                txtAge.Location = new Point(634, YX);
                                txtAge.Show();
                                labAge.Show();
                                labAge.Location = new Point(579, YX);
                            }
                        }
                        else
                        {
                            txtAge.Hide();
                            labAge.Hide();
                        }
                    }
                    else
                    {
                        if (rs_patients.Rows[0]["age"].ToString() != "")
                        {
                            if (Convert.ToInt32(rs_patients.Rows[0]["age"].ToString()) != 0)
                            {
                                txtAge.Text = rs_patients.Rows[0]["age"].ToString();
                                txtAge.Show();
                                txtAge.BackColor = Color.White;
                                YX = YX + 30;
                                txtAge.Location = new Point(634, YX);
                                txtAge.Show();
                                labAge.Show();
                                labAge.Location = new Point(579, YX);
                            }
                        }
                        else
                        {
                            txtAge.Hide();
                            labAge.Hide();
                        }
                    }
                    int ba=0;
                    if (rs_patients.Rows[0]["Visited"].ToString() != "")
                    {
                        if (DateTime.Parse(rs_patients.Rows[0]["Visited"].ToString()).ToString("MM/dd/yyyy") != "")
                        {
                            txtvisiteddate.Text = DateTime.Parse(rs_patients.Rows[0]["Visited"].ToString()).ToString("MM/dd/yyyy");
                            txtvisiteddate.BackColor = Color.White;
                            YX = YX + 30;
                            txtvisiteddate.Location = new Point(634, YX);
                            txtvisiteddate.Show();
                            LabDateOfAdm.Show();
                            LabDateOfAdm.Location = new Point(510, YX);
                            ba = 1;
                        }
                    }
                    else
                    {
                        txtvisiteddate.Hide();
                        LabDateOfAdm.Hide();
                    }
                    if (rs_patients.Rows[0]["doctorname"].ToString() != "")
                    {
                        YX = YX + 30;
                        txtDoctor.Text = rs_patients.Rows[0]["doctorname"].ToString();
                        txtDoctor.BackColor = Color.White;
                        txtDoctor.Location = new Point(634, YX);
                        txtDoctor.Show();
                        LabDoctorName.Show();
                        LabDoctorName.Location = new Point(512, YX);
                    }
                    else
                    {
                        txtDoctor.Hide();
                        LabDoctorName.Hide();
                    }
                    if (rs_patients.Rows[0]["Occupation"].ToString() != "")
                    {
                        YX = YX + 30;
                        txtOccupation.Text = rs_patients.Rows[0]["Occupation"].ToString();
                        txtOccupation.BackColor = Color.White;
                        txtOccupation.Location = new Point(634, YX);
                        txtOccupation.Show();
                        LabOccupation.Show();
                        LabOccupation.Location = new Point(525, YX);
                    }
                    else
                    {
                        txtOccupation.Hide();
                        LabOccupation.Hide();
                    }
                    try
                    {
                        string curFile = this.cntrl.getserver() + "\\Pappyjoe_utilities\\patient_image\\" + patient_id;
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
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    DataTable dt8 = this.cntrl.pt_medical(patient_id);
                    grmedical.Visible = true;
                    grmedical.RowCount = 0;
                    grmedical.ColumnCount = 1;
                    grmedical.ColumnHeadersHeight = 10;
                    grmedical.RowHeadersVisible = false;
                    grmedical.ColumnHeadersVisible = false;
                    grmedical.Columns[0].Name = "preid";
                    grmedical.Columns[0].Width = 200;
                    for (int j = 0; j < dt8.Rows.Count; j++)
                    {
                        grmedical.Rows.Add(dt8.Rows[j][0].ToString());
                    }
                    DataTable dt9 = this.cntrl.patrint_goup(patient_id);
                    gridgroups.Visible = true;
                    gridgroups.RowCount = 0;
                    gridgroups.ColumnCount = 1;
                    gridgroups.ColumnHeadersHeight = 10;
                    gridgroups.RowHeadersVisible = false;
                    gridgroups.ColumnHeadersVisible = false;
                    gridgroups.Columns[0].Name = "preid";
                    gridgroups.Columns[0].Width = 200;
                    for (int j = 0; j < dt9.Rows.Count; j++)
                    {
                        gridgroups.Rows.Add(dt9.Rows[j][0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public void Setcontroller(Profile_Details_controller controller)
        {
            cntrl = controller;
        }

        private void medicalcertificate_Click(object sender, EventArgs e)
        {
            var dlg = new Medical_Certificate();
            dlg.patient_id = patient_id;
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void BtnConsent_Click(object sender, EventArgs e)
        {
            var dlg = new Consent();
            dlg.patient_id = patient_id;
            dlg.doctor_id = doctor_id;
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void BtnCaseSheet_Click(object sender, EventArgs e)
        {
            var dlg = new CaseSheet();
            dlg.patient_id = patient_id;
            dlg.doctor_id = doctor_id;
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void editpatient_Click(object sender, EventArgs e)
        {
            var form2 = new Patient_Profile_Edit();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                listpatientsearch.DataSource = dtdr;
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStrip1.Width - 360, 37);
                //listpatientsearch.Location = new Point(toolStripTextBox1.Width + 750, 32);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
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
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
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
                    form2.Show();
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
                form2.Show();
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labl_Lab_Click(object sender, EventArgs e)
        {
            var form2 = new LabWorks();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new StockReport();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void BtnCard_Click(object sender, EventArgs e)
        {
            try
            {
                string barCode = txtPatientId.Text;
                Bitmap bitMap = new Bitmap(barCode.Length * 40, 20);
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAutomationHC39M", 16);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString(barCode, oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, ImageFormat.Png);
                    pictureBox_barcode.Image = bitMap;
                    pictureBox_barcode.Height = bitMap.Height;
                    pictureBox_barcode.Width = bitMap.Width;
                }
                PrintDocument printdocument = new PrintDocument();
                printdocument.PrintPage += print_Patient_Card_PrintPage;
                printdocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check your printer...!!", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void print_Patient_Card_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int yy = 2;
            string sexage = "";
            int Dexist = 0;
            System.Data.DataTable dt1 = this.cntrl.Get_Patient_details(patient_id);
            if (dt1.Rows.Count > 0)
            {
                e.Graphics.DrawImage(pictureBox_Logo.Image, 10, yy);
                yy = yy + 160;
                e.Graphics.DrawImage(pictureBox_barcode.Image, 80, yy);
                using (System.Drawing.Font printFont = new System.Drawing.Font("Segoe UI", 15.0f))
                {
                    yy = yy + 30;
                    e.Graphics.DrawString(dt1.Rows[0]["pt_name"].ToString(), printFont, Brushes.Black, 10, yy);
                }
                using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 15.0f))
                {
                    //yy = yy + 20;
                    e.Graphics.DrawString(dt1.Rows[0]["pt_Id"].ToString(), printFont2, Brushes.Black, 80, yy);
                }
                using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 10.0f, FontStyle.Bold))
                {
                    if (dt1.Rows[0]["gender"].ToString() != "")
                    {
                        sexage = dt1.Rows[0]["gender"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["age"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            sexage = sexage +"  "+ "Age:" + dt1.Rows[0]["age"].ToString() + " Y";
                        }
                        else
                        {
                            sexage = dt1.Rows[0]["age"].ToString() + " Y";
                        }
                    }
                    yy = yy + 40;
                    e.Graphics.DrawString("Reg.Dt :" + Convert.ToDateTime(dt1.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy") + "        " + sexage, printFont1, Brushes.Black, 10, yy);
                  
                    if(dt1.Rows[0]["Street_address"].ToString()!="")
                    {
                        yy = yy + 20;
                        e.Graphics.DrawString(dt1.Rows[0]["Street_address"].ToString(), printFont1, Brushes.Black, 10, yy);
                    }
                   else if(dt1.Rows[0]["locality"].ToString()!="")
                    {
                        yy = yy + 20;
                        e.Graphics.DrawString(dt1.Rows[0]["locality"].ToString(), printFont1, Brushes.Black, 10, yy);
                    }
                    else if(dt1.Rows[0]["primary_mobile_number"].ToString()!="")
                    {
                        yy = yy + 20;
                        e.Graphics.DrawString("Ph :" + dt1.Rows[0]["primary_mobile_number"].ToString(), printFont1, Brushes.Black, 10, yy);
                    }
                    else if (dt1.Rows[0]["nationality"].ToString() != "")
                    {
                        yy = yy + 20;
                        e.Graphics.DrawString("Nationality :" + dt1.Rows[0]["nationality"].ToString(), printFont1, Brushes.Black, 10, yy);
                    }
                    else if (dt1.Rows[0]["passport_no"].ToString() != "")
                    {
                        yy = yy + 20;
                        e.Graphics.DrawString("Passport No :" + dt1.Rows[0]["passport_no"].ToString(), printFont1, Brushes.Black, 10, yy);
                    }
                }
                
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintDocument printdocument = new PrintDocument  ();
            printdocument.PrintPage += printDocument1_PrintPage;
            printdocument.Print();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }  

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int w = e.MarginBounds.Width / 2;
            int x = e.MarginBounds.Left;
            int y = e.MarginBounds.Top;
            Font printFont = new Font("Segoe UI", 10);
            string tabDataText = toolStripButton1.Text;
            var tabDataForeColor = Color.Blue;
            var txtDataWidth = e.Graphics.MeasureString(tabDataText, printFont).Width;
            using (var sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(tabDataText, new Font(this.Font.Name, 18),
                     new SolidBrush(tabDataForeColor),
                     e.MarginBounds.Left + (e.MarginBounds.Width / 2),
                     e.MarginBounds.Top - 55,
                     sf);
            }
            e.HasMorePages = false;
            int iLeftMargin = e.MarginBounds.Left;
            string date = System.DateTime.Now.ToShortDateString();
            e.Graphics.DrawString("Patient Registration Form", new Font("Segoe UI", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 200, 75);
            string underLine = "--------------------------------------------";
            e.Graphics.DrawString(underLine, new Font("Segoe UI", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 200, 95);
            e.Graphics.DrawString("Printed By:", new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 1, 130);
            e.Graphics.DrawString("Admin", new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 75, 130);
            e.Graphics.DrawString("Date:", new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 150, 130);
            e.Graphics.DrawString(date, new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 195, 130);
            e.Graphics.DrawString("No: " + patient_id, new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 370, 130);
            e.Graphics.DrawString("Personal Details", new Font("Segoe UI", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 10, 160);

            int xyy = 190;
            if (txtPatientName.Visible == true)
            {
                e.Graphics.DrawString(this.lab_PatientName.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtPatientName.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtPatientId.Visible == true)
            {
                e.Graphics.DrawString(this.labPatientId.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtPatientId.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtAdhaarId.Visible == true)
            {
                e.Graphics.DrawString(this.labAdhaarId.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtAdhaarId.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtGender.Visible == true)
            {
                e.Graphics.DrawString(this.labGender.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtGender.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtDob.Visible == true)
            {
                e.Graphics.DrawString(this.labDob.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtDob.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtRefferedBy.Visible == true)
            {
                e.Graphics.DrawString(this.labRefferedBy.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtRefferedBy.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtBloodGroup.Visible == true)
            {
                e.Graphics.DrawString(this.labAdhaarId.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtAdhaarId.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                txtBloodGroup.Hide();
                labBloodGroup.Hide();
                xyy = xyy + 30;
            }
            if (txtAccompainedBy.Visible == true)
            {
                e.Graphics.DrawString(this.labAccompainedBy.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtAccompainedBy.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtPrimaryMobNo.Visible == true)
            {
                e.Graphics.DrawString(this.labPrimaryMobileNumber.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtPrimaryMobNo.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);

                xyy = xyy + 30;
            }
            if (txtSecondaryMobNo.Visible == true)
            {
                e.Graphics.DrawString(this.labSecondaryMobileNumbr.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtSecondaryMobNo.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);

                xyy = xyy + 30;
            }
            if (txtLandLineNo.Visible == true)
            {
                e.Graphics.DrawString(this.labLandLineNo.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtLandLineNo.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);

                xyy = xyy + 30;
            }
            if (txtEmailAddress.Visible == true)
            {
                e.Graphics.DrawString(this.labEmailAddress.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtEmailAddress.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtStreetAddress.Visible == true)
            {
                e.Graphics.DrawString(this.labStreetAddress.Text, new Font("Arial", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtStreetAddress.Text, new Font("Arial", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);

                xyy = xyy + 30;
            }
            if (txtLocality.Visible == true)
            {
                e.Graphics.DrawString(this.labLocality.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtLocality.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtCity.Visible == true)
            {
                e.Graphics.DrawString(this.labCity.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtCity.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtPinCode.Visible == true)
            {
                e.Graphics.DrawString(this.labPinCode.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtPinCode.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtnationality.Visible == true)
            {
                e.Graphics.DrawString(this.labPinCode.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtPinCode.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtpassport.Visible == true)
            {
                e.Graphics.DrawString(this.labPinCode.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtPinCode.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }

            if (txtopticket.Visible == true)
            {
                e.Graphics.DrawString(this.lblopti.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtopticket.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtAge.Visible == true)
            {
                e.Graphics.DrawString(this.labAge.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtAge.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtvisiteddate.Visible == true)
            {
                e.Graphics.DrawString(this.LabDateOfAdm.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtvisiteddate.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtDoctor.Visible == true)
            {
                e.Graphics.DrawString(this.LabDoctorName.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtDoctor.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }
            if (txtOccupation.Visible == true)
            {
                e.Graphics.DrawString(this.LabOccupation.Text, new Font("Segoe UI", 10, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                e.Graphics.DrawString(this.txtOccupation.Text, new Font("Segoe UI", 11, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 230, xyy);
                xyy = xyy + 30;
            }

            if (grmedical.Rows.Count > 0)
            {
                xyy = xyy + 60;
                e.Graphics.DrawString("Medical History", new Font("Segoe UI", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 10, xyy);
                xyy = xyy + 30;
                for (int j = 0; j < grmedical.Rows.Count; j++)
                {
                    e.Graphics.DrawString(grmedical.Rows[j].Cells[0].Value.ToString(), new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, xyy);
                    xyy = xyy + 20;
                }
            }

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
    }
}
