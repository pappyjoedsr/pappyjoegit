using Microsoft.Win32;
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
    public partial class Add_New_Patients : Form, AddNew_patient_interface
    {
        AddNew_patient_controller cntrl; common_model mdl = new common_model();
        public string patient_name = "", doctor_id = "", staff_id = "", PatientId = "", path = "";
        string pat_id = "";
        int medhisStatus = 0, selectGrp = 0;
        public int statusForNewPatient = 0; string clinicn = "";
        public static bool SetFlag = false;
        private bool setFlag;

        public string PatientName
        {
            get { return this.txtPatName.Text; }
            set { txtPatName.Text = value; }
        }
        public string Patient_Id
        {
            get { return this.txtPatientId.Text; }
            set { txtPatientId.Text = value; }
        }
        public string Aadhaar
        {
            get { return this.txtAadhar.Text; }
            set { txtAadhar.Text = value; }
        }
        public string Gender
        {
            get
            {
                if (radMale.Checked == true)
                    return "Male";
                else
                    return "Female";
            }
            set
            {
                if (value == "Male")
                    radMale.Checked = true;
                else
                    radFemale.Checked = true;
            }

        }
        public string DOB//change
        {
           
            get
            {
                if (DateTime.Now.Date.ToString("MM/dd/yyyy") == DTP_Dob.Value.ToString("MM/dd/yyyy"))
                {
                  return  null;
                }
                else
                {
                   return DTP_Dob.Value.ToString("yyyy-MM-dd");
                }
            }
            set {
                if(value==null)
                {

                }
                else
                {
                    DTP_Dob.Text = value;
                }
            }
        }
        public string ReferredBy
        {
            get { return this.txtReferedby.Text; }
            set { txtReferedby.Text = value; }
        }
        public string Blood
        {
            get { return this.cmdBloodbroup.Text; }
            set { cmdBloodbroup.Text = value; }
        }
        public string Accompainedby
        {
            get { return this.txtAccompained.Text; }
            set { txtAccompained.Text = value; }
        }
        public string FileNo
        {
            get { return this.txtFileNo.Text; }
            set { txtFileNo.Text = value; }
        }
        public string Age
        {
            get
            {
                if (this.txtxAge.Text != "")
                { }
                else
                    this.txtxAge.Text = "0";
                return this.txtxAge.Text;
            }
            set { txtxAge.Text = value.ToString(); }
        }
        //if (DateTime.Now.Date.ToString("MM/dd/yyyy") == dateTimePickervisited.Value.ToString("MM/dd/yyyy"))
        //{
        //    datevisited = DateTime.Now.Date.ToString("yyyy-MM-dd");
        //}
        //else
        //{
        //    datevisited = dateTimePickervisited.Value.ToString("yyyy-MM-dd");
        //}
        public string DateofAdmit //chabge
        {
            get {
                if (DateTime.Now.Date.ToString("MM/dd/yyyy") == dateTimePickervisited.Value.ToString("MM/dd/yyyy"))
                {
                    return  DateTime.Now.Date.ToString("yyyy-MM-dd");
                }
                else
                {
                    return dateTimePickervisited.Value.ToString("yyyy-MM-dd");
                }
                //return DateofAdmit;
            }
            set { dateTimePickervisited.Text = value; }
        }
        public string Occupation
        {
            get { return this.txtOccupation.Text; }
            set { txtOccupation.Text = value; }
        }
        public string Doctor
        {
            get { return this.ddldoctor.Text; }
            set { ddldoctor.Text = value; }
        }
        public string PrimaryMob
        {
            get { return this.txtPMobNumber.Text; }
            set { txtPMobNumber.Text = value; }
        }
        public string SecondaryMob
        {
            get { return this.txtSMobileNumber.Text; }
            set { txtSMobileNumber.Text = value; }
        }
        public string Landline
        {
            get { return this.txtLandline.Text; }
            set { txtLandline.Text = value; }

        }
        public string Email
        {
            get { return this.txtEmail.Text; }
            set { txtEmail.Text = value; }

        }
        public string Street
        {
            get { return this.txtxStreet.Text; }
            set { txtxStreet.Text = value; }

        }
        public string Locality
        {
            get { return this.txtLocality.Text; }
            set { txtLocality.Text = value; }
        }
        public string City
        {
            get { return this.txtCity.Text; }
            set { txtCity.Text = value; }
        }
        public string Pincode
        {
            get { return this.txtPincode.Text; }
            set { txtPincode.Text = value; }
        }
        public string Medical
        {
            get { return this.txtMedHistory.Text; }
            set { txtMedHistory.Text = value; }
        }

        private void txtPMobNumber_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPMobNumber_Leave(object sender, EventArgs e)
        {
            if (txtPMobNumber.TextLength != 10)
            {
                Lab_InvalidNumber.Visible = true;
                validatenumber();
                return;
            }
            else
                Lab_InvalidNumber.Visible = false;
        }
        public void validatenumber()
        {
            DataTable patSearchnumber = this.cntrl.Get_pnonenumber(txtPMobNumber.Text);
            if (patSearchnumber.Rows.Count > 0)
            {
                MessageBox.Show("User with same Number already exists", "Number exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPMobNumber.Focus();
            }
        }

        private void txtPatName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPatName.Text != "")
            {
            }
            else
            {
                Lab_UsernameAvailable.Hide();
            }
        }

        private void txtPatName_Leave(object sender, EventArgs e)
        {
            Lab_UsernameAvailable.Show();
            DataTable patSearch = this.cntrl.Get_patient_details(txtPatName.Text);
            if (patSearch.Rows.Count > 0)
            {
                Lab_UsernameAvailable.Text = "User with same name already exists";
                Lab_UsernameAvailable.ForeColor = Color.Red;
                Lab_ViewDetails.Show();
            }
            else
            {
                Lab_UsernameAvailable.Text = "User Available";
                Lab_UsernameAvailable.ForeColor = Color.LimeGreen;
                Lab_ViewDetails.Hide();
            }
        }

        private void DTP_Dob_ValueChanged(object sender, EventArgs e)//tyytr
        {
            int age = DateTime.Now.Year - DTP_Dob.Value.Year - (DateTime.Now.DayOfYear < DTP_Dob.Value.DayOfYear ? 1 : 0);
            txtxAge.Text = age.ToString();
        }

        private void btn_SavePatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPMobNumber.TextLength != 10)
                {
                    MessageBox.Show("Enter the mobile number.. !!", "Data not found.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtPatientId.Text != "")
                {
                    DataTable dtb = this.cntrl.get_patientid(txtPatientId.Text);
                    if (dtb.Rows.Count > 0)
                    {
                        MessageBox.Show("This patient id already exists", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (String.IsNullOrWhiteSpace(txtPatName.Text))
                {
                    txtPatName.Focus();
                    return;
                }
                else
                {
                    Lab_UsernameAvailable.Show();
                    DataTable patSearch = this.cntrl.Get_patient_details(txtPatName.Text);
                    if (patSearch.Rows.Count > 0)
                    {
                        Lab_UsernameAvailable.Text = "User with same name already exists";
                        Lab_UsernameAvailable.ForeColor = Color.Red;
                        Lab_ViewDetails.Show();
                    }
                    else
                    {
                        Lab_UsernameAvailable.Text = "User Available";
                        Lab_UsernameAvailable.ForeColor = Color.LimeGreen;
                        Lab_ViewDetails.Hide();
                    }
                    if (txtPMobNumber.Text != "")
                    {
                        int i = 0;
                        //Addfunction();
                        string smsName1 = PappyjoeMVC.Model.GlobalVariables.smsName.ToString();
                        string smsPass1 = PappyjoeMVC.Model.GlobalVariables.smsPass.ToString();
                        i = this.cntrl.Save();
                        DataTable cmd = this.cntrl.automaticid();
                        if (cmd.Rows.Count > 0)
                        {
                            int n = 0;
                            n = int.Parse(cmd.Rows[0]["patient_number"].ToString()) + 1;
                            if (n != 0)
                            {
                                this.cntrl.update_autogenerateid(n);
                            }
                        }
                        //a.SendSMS(smsName1, smsPass1, txtPMobNumber.Text, "Dear " + txtPatName.Text + " welcome to " + toolStripButton1.Text);
                        Clear_data();
                        if (i > 0)
                        {
                            txtPic.Text = "";
                            string rs_patient = this.cntrl.get_maxId();
                            pat_id = rs_patient;
                            if (medhisStatus == 0)
                            {
                                for (int count = 0; count < grmedical.Rows.Count; count++)
                                {
                                    if (Convert.ToBoolean(grmedical.Rows[count].Cells[1].Value) == true)
                                    {
                                        this.cntrl.save_medical(pat_id, grmedical.Rows[count].Cells[0].Value.ToString()); //db.execute("insert into tbl_pt_medhistory (pt_id,med_id) values('" + pat_id + "','" + grmedical.Rows[count].Cells[0].Value.ToString() + "')");
                                    }
                                }
                            }
                            else
                            {
                                for (int count = 0; count < grmedical.Rows.Count; count++)
                                {
                                    if (Convert.ToBoolean(grmedical.Rows[count].Cells[0].Value) == true)
                                    {
                                        this.cntrl.save_medical(pat_id, grmedical.Rows[count].Cells[1].Value.ToString());
                                    }
                                }
                            }

                            if (selectGrp == 0)
                            {
                                for (int count = 0; count < gridgroups.Rows.Count; count++)
                                {
                                    if (Convert.ToBoolean(gridgroups.Rows[count].Cells[1].Value) == true)
                                    {
                                        this.cntrl.save_group(pat_id, gridgroups.Rows[count].Cells[0].Value.ToString());
                                    }
                                }
                            }
                            else
                            {
                                for (int count = 0; count < gridgroups.Rows.Count; count++)
                                {
                                    if (Convert.ToBoolean(gridgroups.Rows[count].Cells[0].Value) == true)
                                    {
                                        this.cntrl.save_group(pat_id, gridgroups.Rows[count].Cells[1].Value.ToString());
                                    }
                                }
                            }
                           
                            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("Pappyjoe");
                            string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
                            if (path != "")
                            {

                                try
                                {
                                    if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\patient_image\\" + pat_id))
                                    {
                                    }
                                    else
                                    {
                                        System.IO.File.Copy(path, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\patient_image\\" + pat_id);
                                    }
                                }
                                catch
                                {
                                }
                            }
                            //RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("Pappyjoe");
                            //string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
                            //pathlength();
                            //if (path != "")
                            //{
                            //    try
                            //    {
                            //        if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\patient_image\\" + pat_id))
                            //        {
                            //        }
                            //        else
                            //        {
                            //            System.IO.File.Copy(open.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\patient_image\\" + pat_id);
                            //        }

                            //        //if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile))
                            //        //{
                            //        //}
                            //        //else
                            //        //{
                            //        //    System.IO.File.Copy(open2.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Attachments\\" + realfile);
                            //        //}
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //    }
                            //}
                            if (statusForNewPatient == 1)
                            {
                                ActiveForm.Close();
                            }
                            else
                            {
                                var form2 = new Patient_Profile_Details();
                                profile_details_controller cntrl = new profile_details_controller(form2);
                                form2.patient_id = pat_id;
                                form2.doctor_id = doctor_id;
                                form2.Closed += (sender1, args) => this.Close();
                                this.Hide();
                                form2.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Inseration Failed,Error occured !!", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter the mobile number.. !!", "Data not found.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Lab_InvalidNumber.Visible = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Clear_data()
        {
            txtPatName.Text = "";
            txtPatientId.Text = "";
            txtAadhar.Text = "";
            txtxAge.Text = "";
            cmdBloodbroup.SelectedIndex = 0;
            txtAccompained.Text = "";
            DTP_Dob.Value = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
            dateTimePickervisited.Value = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy"));
            txtPMobNumber.Text = "";
            txtSMobileNumber.Text = "";
            txtLandline.Text = "";
            radFemale.Checked = false;
            radMale.Checked = false;
            txtEmail.Text = "";
            txtxStreet.Text = "";
            txtLocality.Text = "";
            txtCity.Text = "";
            txtPincode.Text = "";
            txtFileNo.Text = "";
            txtOccupation.Text = "";
            txtReferedby.Text = "";
        }
        public int len;
        public void pathlength()
        {
            string fullpath = Application.StartupPath.Substring(0, Application.StartupPath.Length);
            if (fullpath.Substring((Application.StartupPath.Length) - 1) == "e")
            {
                len = 11;
            }
            else if (fullpath.Substring((Application.StartupPath.Length - 1)) == "g")
            {
                len = 10;
            }
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            grmedical.Visible = false;
            txtMedHistory.Visible = true;
            dataGridViewmedical.Visible = true;
            btnMED_Add.Visible = true;
            btnMED_Cancle.Visible = true;
            DataTable dt = this.cntrl.load_medical();
            dataGridViewmedical.DataSource = dt;
            btnAddNew.Visible = false;
        }

        private void btnMED_Add_Click(object sender, EventArgs e)
        {
            medhisStatus = 1;
            this.cntrl.check_medical(txtMedHistory.Text);
            DataTable dt = this.cntrl.load_medical();
            grmedical.DataSource = dt;
        }
        public void insertMED(DataTable checkdatacc)
        {
            try
            {
                if (checkdatacc.Rows.Count > 0)
                {
                    MessageBox.Show("Medical History " + txtMedHistory.Text + " already exist");
                }
                else
                {
                    if (txtMedHistory.Text != "")
                    {
                        this.cntrl.insert_medical();
                        txtMedHistory.Text = "";
                        btnAddNew.Visible = true;
                        grmedical.Visible = true;
                        txtMedHistory.Visible = false;
                        dataGridViewmedical.Visible = false;
                        btnMED_Add.Visible = false;
                        btnMED_Cancle.Visible = false;
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void btnMED_Cancle_Click(object sender, EventArgs e)
        {
            DataTable dt = this.cntrl.load_medical();
            grmedical.DataSource = dt;
            btnAddNew.Visible = true;
            grmedical.Visible = true;
            txtMedHistory.Visible = false;
            dataGridViewmedical.Visible = false;
            btnMED_Add.Visible = false;
            btnMED_Cancle.Visible = false;
        }

        private void btn_addgrps_Click(object sender, EventArgs e)
        {
            DataTable dt1 = this.cntrl.load_group();
            grouptext.Text = "";
            gridgroup1.DataSource = dt1;
            btn_addgrps.Visible = false;
            gridgroups.Visible = false;
            grouptext.Visible = true;
            btnGrp_Add.Visible = true;
            btn_GrpCancel.Visible = true;
            gridgroup1.Visible = true;
        }

        private void btnGrp_Add_Click(object sender, EventArgs e)
        {
            selectGrp = 1;
            this.cntrl.check_group(grouptext.Text);
            DataTable dt1 = this.cntrl.load_group();
            grouptext.Text = "";
            gridgroups.DataSource = dt1;
        }
        public void insertgroup(DataTable checkdatacc)
        {
            try
            {
                if (checkdatacc.Rows.Count > 0)
                {
                    MessageBox.Show("Group  " + grouptext.Text + " already exist");
                }
                else
                {
                    if (grouptext.Text != "")
                    {
                        this.cntrl.insert_group();
                        grouptext.Text = "";
                        btn_addgrps.Visible = true;
                        gridgroups.Visible = true;
                        grouptext.Visible = false;
                        btnGrp_Add.Visible = false;
                        btn_GrpCancel.Visible = false;
                        gridgroup1.Visible = false;
                    }
                    else
                    {
                    }
                }
            }
            catch
            {
            }
        }

        private void btn_GrpCancel_Click(object sender, EventArgs e)
        {
            DataTable dt1 = this.cntrl.load_group();
            grouptext.Text = "";
            gridgroups.DataSource = dt1;
            btn_addgrps.Visible = true;
            gridgroups.Visible = true;
            grouptext.Visible = false;
            btnGrp_Add.Visible = false;
            btn_GrpCancel.Visible = false;
            gridgroup1.Visible = false;
        }

        private void Lab_ViewDetails_Click(object sender, EventArgs e)
        {
            if (Lab_ViewDetails.Text == "View Details")
            {
                DataTable dtb = new DataTable();
                dtb = this.cntrl.Get_patient_details(txtPatName.Text);
                Search_Available_Patient frm = new Search_Available_Patient(dtb, doctor_id);
                frm.ShowDialog();
                frm.Closed += (sender1, args) => this.Close();
                if (SetFlag == true)
                {
                    this.Hide();
                    this.Visible = false;
                    SetFlag = false;
                }
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int w = e.MarginBounds.Width / 2;
                int x = e.MarginBounds.Left;
                int y = e.MarginBounds.Top;
                Font printFont = new Font("Arial", 10);
                string tabDataText = clinicn.Replace("¤", "'");
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
                e.Graphics.DrawString("Patient Registration Form", new Font("Arial", 16, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 200, 75);
                string underLine = "--------------------------------------------";
                e.Graphics.DrawString(underLine, new Font("Arial", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 200, 95);
                e.Graphics.DrawString("Printed By:", new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 1, 130);
                e.Graphics.DrawString("Admin", new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 75, 130);
                e.Graphics.DrawString("Date:", new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 150, 130);
                e.Graphics.DrawString(date, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 195, 130);
                e.Graphics.DrawString("Personal Details", new Font("Arial", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 10, 160);
                e.Graphics.DrawString(this.label1.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 210);
                e.Graphics.DrawString(this.label8.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 260);
                e.Graphics.DrawString(this.txtPatientId.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 200, 260);
                e.Graphics.DrawString(this.label10.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 310);
                e.Graphics.DrawString(this.label14.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 360);
                e.Graphics.DrawString(this.label17.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 410);
                e.Graphics.DrawString(this.label16.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 460);
                e.Graphics.DrawString(this.label19.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 510);
                e.Graphics.DrawString("General Details", new Font("Arial", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 10, 560);
                e.Graphics.DrawString(this.label21.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 610);
                e.Graphics.DrawString(this.label9.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 660);
                e.Graphics.DrawString("Male", new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 200, 660);
                Pen blackPen = new Pen(Color.Black, 1);
                Rectangle re_Male = new Rectangle(0, 0, 50, 50);
                re_Male.X = 250;
                re_Male.Y = 660;
                re_Male.Width = 25;
                re_Male.Height = 25;
                e.Graphics.DrawRectangle(blackPen, re_Male);
                e.Graphics.DrawString("Female", new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 300, 660);
                Rectangle refamale = new Rectangle(0, 0, 50, 50);
                refamale.X = 355;
                refamale.Y = 660;
                refamale.Width = 25;
                refamale.Height = 25;
                e.Graphics.DrawRectangle(blackPen, refamale);
                e.Graphics.DrawString(this.label4.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 710);
                Rectangle rect = new Rectangle(0, 0, 50, 50);
                rect.X = 190;
                rect.Y = 710;
                rect.Width = 25;
                rect.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect);
                Rectangle rect1 = new Rectangle(0, 0, 50, 50);
                rect1.X = 220;
                rect1.Y = 710;
                rect1.Width = 25;
                rect1.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect1);
                Rectangle rect2 = new Rectangle(0, 0, 50, 50);
                rect2.X = 265;
                rect2.Y = 710;
                rect2.Width = 25;
                rect2.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect2);
                Rectangle rect3 = new Rectangle(0, 0, 50, 50);
                rect3.X = 297;
                rect3.Y = 710;
                rect3.Width = 25;
                rect3.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect3);
                Rectangle rect4 = new Rectangle(0, 0, 50, 50);
                rect4.X = 350;
                rect4.Y = 710;
                rect4.Width = 25;
                rect4.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect4);
                Rectangle rect5 = new Rectangle(0, 0, 50, 50);
                rect5.X = 380;
                rect5.Y = 710;
                rect5.Width = 25;
                rect5.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect5);
                Rectangle rect6 = new Rectangle(0, 0, 50, 50);
                rect6.X = 400;
                rect6.Y = 710;
                rect6.Width = 25;
                rect6.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect);
                Rectangle rect7 = new Rectangle(0, 0, 50, 50);
                rect7.X = 410;
                rect7.Y = 710;
                rect7.Width = 25;
                rect7.Height = 25;
                e.Graphics.DrawRectangle(blackPen, rect7);
                e.Graphics.DrawString(this.label23.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 760);
                e.Graphics.DrawString(this.label30.Text, new Font("Arial", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point), Brushes.Black, 25, 810);
                e.Graphics.DrawString("Medical History", new Font("Arial", 12, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point), Brushes.Black, 10, 860);
                DataTable dt = this.cntrl.load_medical();
                grmedical.DataSource = dt;
                Graphics graphics = e.Graphics;
                Font font = new Font("Arial", 10);
                float fontHeight = font.GetHeight();
                int startX = 25; int LineY = 900;
                int startY = 875;
                int Offset = 10;
                Rectangle recta = new Rectangle(0, 0, 50, 50);
                int a = grmedical.Rows.Count;
                for (int i = 0; i < a; i++)
                {
                    recta.X = startX + 150;
                    recta.Y = startY + 50;
                    recta.Width = 15;
                    recta.Height = 15;
                    graphics.DrawString(Convert.ToString(grmedical.Rows[i].Cells[0].Value), new Font("Arial", 10), new SolidBrush(Color.Black), startX, LineY + Offset);
                    graphics.DrawString("\t\n" + Convert.ToString(grmedical.Rows[i].Cells[1].Value), new Font("Arial", 10), new SolidBrush(Color.Black), startX, LineY + Offset);
                    e.Graphics.DrawRectangle(blackPen, recta);
                    startY = startY + 30; Offset = Offset + 30;
                }
            }
            catch
            {
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            PrintDocument printdocument = new PrintDocument();
            printdocument.PrintPage += printDocument1_PrintPage;
            printdocument.Print();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
        }

        public string Group
        {
            get { return this.grouptext.Text; }
            set { grouptext.Text = value; }
        }
        OpenFileDialog open = new OpenFileDialog();
        private void PB_Image_Click(object sender, EventArgs e)
        {
            DialogResult ok = MessageBox.Show("The image can be saved just once. Do you wish to add one now? Or You can add later from patient profile.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (ok == DialogResult.Yes)
            {
                open.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
                DialogResult res = open.ShowDialog();
                path = open.FileName;
                if (res == DialogResult.OK)
                {
                    PB_Image.Image = Image.FromFile(open.FileName);
                }
            }
            else
            {
                PB_Image.Image = null;
                path = "";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
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
            form2.patient_id=Patient_Id;
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

        public Add_New_Patients()
        {
            InitializeComponent();
        }

        public Add_New_Patients(bool setFlag)
        {
            InitializeComponent();
            SetFlag = true;
        }

        public void SetController(AddNew_patient_controller controller)
        {
            cntrl = controller;
        }
        private void AddNewPatients_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                if (SetFlag == false)
                {
                    txtxAge.Text = ""; txtPic.Text = "";
                    doctornamebind();
                    btnAddNew.Visible = true;
                    string docnam = mdl.Get_DoctorName(doctor_id);//change 
                    if (docnam!="")
                    {
                        toolStripldoc.Text = "Logged As:Dr." + docnam;
                    }
                    DataTable auto = this.cntrl.data_from_automaticid();
                    if (auto.Rows.Count > 0)
                    {
                        if (auto.Rows[0]["patient_automation"].ToString() == "Yes")
                        {
                            txtPatientId.Text = auto.Rows[0]["patient_prefix"].ToString() + auto.Rows[0]["patient_number"].ToString();
                            txtPatientId.ReadOnly = true;
                        }
                    }
                    this.Size = new System.Drawing.Size(500, 500);
                    //DataTable clinicname = this.cntrl.Get_CompanyNAme();
                    //if (clinicname.Rows.Count > 0)
                    //{
                        //clinicn = clinicname.Rows[0][0].ToString();
                        toolStripButton1.Text = this.cntrl.Load_CompanyName();// clinicn.Replace("¤", "'");
                    //}
                    if (statusForNewPatient == 1)
                    {
                        txtPatName.Text = patient_name;
                    }
                    listpatientsearch.Hide();
                    gridgroups.Show();
                    Lab_InvalidNumber.Visible = false;
                    gridgroups.Visible = true;
                    Lab_UsernameAvailable.Visible = false;
                    txtReferedby.Visible = true;
                    grmedical.Visible = true;
                    DTP_Dob.MaxDate = DateTime.Now.Date;
                    DataTable dt = this.cntrl.load_medical();
                    grmedical.DataSource = dt;
                    DataTable dt1 = this.cntrl.load_group();
                    grouptext.Text = "";
                    gridgroups.DataSource = dt1;
                    DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn()
                    {
                        Name = "Check"
                    };
                    grmedical.Columns.Add(check);
                    check.Width = 100;
                    check.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DataGridViewCheckBoxColumn check1 = new DataGridViewCheckBoxColumn()
                    {
                        Name = "Check1"
                    };
                    gridgroups.Columns.Add(check1);
                    check1.Width = 100;
                    check1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    // Barcode Printing
                    if (txtPatientId.Text.Trim() != "")
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
                    }
                    txtxAge.Text = "";
                }
                grmedical.CurrentCell.Selected = false;
                gridgroups.CurrentCell.Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void doctornamebind()
        {
            try
            {
                if (doctor_id != "0")
                {
                    int dr_index = 0;
                    DataTable dt = this.cntrl.get_all_doctorname();
                    if (dt.Rows.Count > 0)
                    {
                        ddldoctor.DataSource = dt;
                        ddldoctor.DisplayMember = "doctor_name";
                        ddldoctor.ValueMember = "id";
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["id"].ToString() == doctor_id)
                            {
                                dr_index = j;
                            }
                        }
                        ddldoctor.SelectedIndex = dr_index;
                    }
                }
                else
                {
                    DataTable dt = this.cntrl.get_all_doctorname();
                    if (dt.Rows.Count > 0)
                    {
                        ddldoctor.DataSource = dt;
                        ddldoctor.DisplayMember = "doctor_name";
                        ddldoctor.ValueMember = "id";
                        ddldoctor.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
            }
        }
    }
}
