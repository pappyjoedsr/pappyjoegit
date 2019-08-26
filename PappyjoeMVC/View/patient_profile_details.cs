using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PappyjoeMVC.Model;
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.View
{
    public partial class patient_profile_details : Form,profile_details_interface
    {
        public string patient_id = "0";
        public string doctor_id = "0", admin_id = "0";
        profile_details_controller cntrl;
        Connection db = new Connection();
        public string ptid { get; set; }
        public patient_profile_details()
        {
            InitializeComponent();
        }

        private void patient_profile_details_Load(object sender, EventArgs e)
        {
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
            string clinicname = this.cntrl.Load_CompanyName();
            if (clinicname !="")
            {
                toolStripButton1.Text = clinicname;
            }
            string docnam =this.cntrl.Get_DoctorName(doctor_id);
            if (docnam != "")
            {
                toolStripldoc.Text = "Logged As:Dr." + docnam;
            }
            
            this.cntrl.Get_Patient_details(patient_id); 
        }
        public void patientload(DataTable rs_patients)
        {
            if(rs_patients.Rows.Count>0)
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
                DateTime date_of_submission = DateTime.Now;
                DateTime _effective_date = Convert.ToDateTime(rs_patients.Rows[0]["Visited"].ToString());
                TimeSpan difference = date_of_submission - _effective_date;
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
                        //if (DateTime.Parse(rs_patients.Rows[0]["date_of_birth"].ToString()).ToString("MM/dd/yyyy") != "")
                        //{
                            txtDob.Text = DateTime.Parse(rs_patients.Rows[0]["date_of_birth"].ToString()).ToString("MM/dd/yyyy");
                            txtDob.BackColor = Color.White;
                            YX = YX + 30;
                            txtDob.Location = new Point(303, YX);
                            txtDob.Show();
                            labDob.Show();
                            labDob.Location = new Point(182, YX);
                            a = 1;
                        //}
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
                    int ba = 0;
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
        public void Setcontroller(profile_details_controller controller)
        {
            cntrl = controller;
        }

        private void medicalcertificate_Click(object sender, EventArgs e)
        {
            var dlg = new MedicalCertificate();
            dlg.patient_id = patient_id;
            dlg.ShowDialog();
        }

        private void BtnConsent_Click(object sender, EventArgs e)
        {
            var dlg = new consent();
            dlg.patient_id = patient_id;
            dlg.doctor_id = doctor_id;
            dlg.ShowDialog();
        }

        private void BtnCaseSheet_Click(object sender, EventArgs e)
        {
            var dlg = new CaseSheet();
            dlg.patient_id = patient_id;
            dlg.doctor_id = doctor_id;
            dlg.ShowDialog();
        }

        private void editpatient_Click(object sender, EventArgs e)
        {
            var form2 = new patient_profile_Edit();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            patient_edit_controller controller = new patient_edit_controller(form2);
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

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            Reports_controller controller = new Reports_controller(form2);
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controllr = new Communication_controller(form2);
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
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
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

        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            listpatientsearch.Visible = false;
            Clinical_Findings_controller controller = new Clinical_Findings_controller(form2);
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
            Ledger_controller controller = new Ledger_controller(form2);
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
