using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Add_Appointment : Form
    {
        int j=0;
        public DateTime StartT,StartT1,EndTime,Dateonly ;
        public static string gender, smsName = "", smsPass = "",appointid="", p_mobile = "", p_email = "";
        public string doctor_id = "", appointment_id, patient_id = "",send_on_day,name = "", diff1 = "0",send_before_day,day_time, pat_id, doc,before_time, patient_name = "", clinicn = "", locality = "", contact_no = "", text = "", dr_id = "", emailName = "", emailPass = "";
        Add_Appointment_controller ctrlr=new Add_Appointment_controller();
        public Add_Appointment()
        {
            InitializeComponent();
            InitializeControls();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType!= "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string doctrid = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
                if (doctor_id != "1")
                {
                    string id;
                    id = doctrid;
                    if (int.Parse(id) > 0)
                    {
                        var form2 = new AddNewPatients();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog(); ;
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    var form2 = new AddNewPatients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string doctrid = this.ctrlr.settingsprivilage(doctor_id);
                if (doctor_id != "1")
                {
                    string id;
                    id = doctrid;
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
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void InitializeControls()
        {
            DateTime dtHours = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            for (int cnt = 0; cnt < 288; cnt++)
            {
                cmbStartTime.Items.Insert(cnt, dtHours.ToShortTimeString());
                cmbEndTime.Items.Insert(cnt, dtHours.ToShortTimeString());
                dtHours = dtHours.AddMinutes(5);
            }
            cmbStartTime.SelectedIndex = 90;
            cmbEndTime.SelectedIndex = 91;
            combocategory.SelectedIndex = 0;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void cmbStartTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartTime.SelectedIndex < 287)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex + 1;
            }
            else
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex;
            }
        }
       public void Get_Practice_details(DataTable dt)
        {
            String ClinicName = "";
            if (dt.Rows.Count > 0)
            {
                ClinicName = dt.Rows[0]["Name"].ToString();
                toolStripButton1.Text = ClinicName.Replace("¤", "'");
                clinicn = ClinicName.Replace("¤", "'");
                locality =dt.Rows[0]["locality"].ToString();
                contact_no = dt.Rows[0]["contact_no"].ToString();
            }
        }
        public void getdoctrname(string dt)
        {
            if(dt!="")
            {
                int index = Cmb_doctor.FindString(dt);
                if (index >= 0)
                {
                    Cmb_doctor.SelectedIndex = index;
                }
                else
                {
                    Cmb_doctor.SelectedIndex = 0;
                }
            }
        }
        public void dt_appointment(DataTable dt)
        {
            try
            {
                if (appointment_id != "0")
                {
                    if (dt.Rows.Count > 0)
                    {
                        doc = dt.Rows[0]["dr_id"].ToString();
                        string dct=this.ctrlr.getdoctrname(dt.Rows[0]["dr_id"].ToString());
                        getdoctrname(dct);
                        if (dt.Rows[0]["plan_new_procedure"].ToString() != "")
                        {
                            int index = compoprocedure.FindString(Convert.ToString(dt.Rows[0]["plan_new_procedure"].ToString()));
                            if (index >= 0)
                            {
                                compoprocedure.SelectedIndex = index;
                            }
                            else
                            {
                                compoprocedure.SelectedIndex = 0;
                            }
                        }
                        int int_duration = Convert.ToInt16(dt.Rows[0]["duration"].ToString());
                        DateTime StartTime, StartTime1, Endtime1, Endtime;
                        dpStartTimeDate.Value = Convert.ToDateTime(dt.Rows[0]["start_datetime"].ToString());
                        StartTime1 = dpStartTimeDate.Value;
                        StartTime = Convert.ToDateTime(StartTime1.ToString("h:mm tt"));
                        int mis = 0;
                        mis = StartTime.Minute / 5;
                        cmbStartTime.SelectedIndex = (int)(StartTime.Hour * 12 + mis);
                        Endtime1 = Convert.ToDateTime(StartTime1.ToString("h:mm tt"));
                        Endtime = Endtime1.AddMinutes(int_duration);
                        mis = Endtime.Minute / 5;
                        cmbEndTime.SelectedIndex = (int)(Endtime.Hour * 12 + mis);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void get_all_doctorname(DataTable dt)
        {
            try
            {
                if (doctor_id != "0")
                {
                    int dr_index = 0;
                    if (dt.Rows.Count > 0)
                    {
                        Cmb_doctor.DataSource = dt;
                        Cmb_doctor.DisplayMember = "doctor_name";
                        Cmb_doctor.ValueMember = "id";
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
                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        Cmb_doctor.DataSource = dt;
                        Cmb_doctor.DisplayMember = "doctor_name";
                        Cmb_doctor.ValueMember = "id";
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getpatdetails(DataTable rs_patients)
        {
            try
            {
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                    patient_name = rs_patients.Rows[0]["pt_name"].ToString();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                if (rs_patients.Rows[0]["primary_mobile_number"].ToString() != "")
                {
                    p_mobile = rs_patients.Rows[0]["primary_mobile_number"].ToString();
                }
                if (rs_patients.Rows[0]["email_address"].ToString() != "")
                {
                    p_email = rs_patients.Rows[0]["email_address"].ToString();
                }

                gender = rs_patients.Rows[0]["gender"].ToString();
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void smsdetails(DataTable sms)
        {
            try
            {
                if (sms.Rows.Count > 0)
                {
                    smsName = sms.Rows[0]["smsName"].ToString();
                    smsPass = sms.Rows[0]["smsPass"].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void smsreminder(DataTable smsreminder)
        {
            try
            { 
                if (smsreminder.Rows.Count > 0)
                {
                    send_on_day = smsreminder.Rows[0]["send_on_day"].ToString();
                    send_before_day = smsreminder.Rows[0]["send_before_day"].ToString();
                    day_time = smsreminder.Rows[0]["day_time"].ToString();
                    before_time = smsreminder.Rows[0]["day_time"].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void Get_Patient_Details(DataTable pat)
        {
            try
            {
                if (pat.Rows.Count > 0)
                {
                    string number = "91" + pat.Rows[0]["primary_mobile_number"].ToString();
                    text = "Dear " + pat.Rows[0]["pt_name"].ToString() + " " + "Your appointment for " + compoprocedure.Text + " has been confirmed at " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " with " + "Dr " + Cmb_doctor.Text + " Regards " + clinicn + "," + contact_no;
                    string smspatnt=this.ctrlr.SendSMS(smsName, smsPass, number, text);
                    string txt = "Dear " + pat.Rows[0]["pt_name"].ToString() + " " + "Your appointment for " + compoprocedure.Text + " has been confirmed at " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " with " + "Dr " + Cmb_doctor.Text + "Regards";
                    this.ctrlr.inssms(patient_id, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), txt);
                    //For Remainder SMS
                    if (day_time != null)
                    {
                        if (dpStartTimeDate.Value > DateTime.Now.Date)
                        {
                            text = "Dear " + pat.Rows[0]["pt_name"].ToString() + ", " + "Today you have an appointment at " + clinicn + " on " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " for " + compoprocedure.Text + " .Regards  " + clinicn + "," + contact_no;
                            string smspatnt2=this.ctrlr.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + " 09:10:00 am", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        }
                    }
                    if (before_time != null)
                    {
                        if (dpStartTimeDate.Value > DateTime.Now.Date)
                        {
                            text = "Dear " + pat.Rows[0]["pt_name"].ToString() + ", " + "Today you have an appointment at " + clinicn + " on " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " for " + compoprocedure.Text + " .Regards  " + clinicn + "," + contact_no;
                            string smspatnt3=this.ctrlr.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + before_time, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        }
                    }
                }//SMS End Patient
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Add_Appointment_Load(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id == "0" || doctor_id == "")
                {
                    doctor_id = "0";
                }
                toolStripButton8.ToolTipText = "Settings";
                toolStripDropDownButton1.ToolTipText = "Add New";
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                DataTable dt=this.ctrlr.Get_Practice_details();
                Get_Practice_details(dt);
                string doctr=this.ctrlr.Get_DoctorName(doctor_id);
                toolStripTextDoctor.Text = "Logged In As : " + doctr;
                DataTable ptntdtls=this.ctrlr.getpatdetails(patient_id);
                getpatdetails(ptntdtls);
                DataTable dctrs=this.ctrlr.get_all_doctorname();
                get_all_doctorname(dctrs);
                DataTable procedure=this.ctrlr.get_All_procedure();
                compoprocedure.DataSource = procedure;
                compoprocedure.DisplayMember = "name";
                compoprocedure.ValueMember = "id";
                DataTable apnt=this.ctrlr.dt_appointment(appointment_id);
                dt_appointment(apnt);
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void send_email(DataTable email)
        {
            if (email.Rows.Count > 0)
            {
                emailName = email.Rows[0]["emailName"].ToString();
                emailPass = email.Rows[0]["emailPass"].ToString();
                try
                {
                    string sr1 = "<table align='center' style='width:700px;border: 1px solid ;border-collapse: collapse; background: #EAEAEA; height:500px'><tr><td  align='left' height='27'><FONT  color='#666666'  face='Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Reminder:" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinicn + "</font></td></tr><tr><td  align='left' height='400px'><table  height='423' align='center' style='width:600px; background: #FFFFFF; height:400px'><tr><td  align='left' height='6px'><FONT  color='#000000'  face='Arial' SIZE=6>" + clinicn + "</font></td></tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr><tr><td  align='left' height='62' valign='bottom'><FONT  color='#000000'  face='Arial' SIZE=3>Good morning <b>" + label21.Text + "</b></font></td></tr> <tr><td align='left' height='197' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Just to remind you about your appointment at " + clinicn + ".<table><tbody><tr><td width='188' height='31' valign='bottom' align='right'>WHEN :</td><td width='30' height='31' valign='bottom' align='right'></td><td width='358' valign='bottom'> <strong>" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + "</strong></td>  </tr><tr><td height='76' valign='top'  align='right'>WHERE :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + locality + "</td></tr></tbody></table> For any queries, contact us at : " + contact_no + "</td>  </tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr> <tr><td height='25'  align='right' valign='bottom'>Powered by&nbsp;&nbsp; </td></tr> <tr><td height='81'  align='right' valign='top'><img src='http://pappyjoe.com/assets/images/pappyjoe-logo.PNG' alt='pappyjoe official logo'>&nbsp;&nbsp;</td></tr></table></td></tr></table>";
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress(p_email);
                    message.To.Add(p_email);
                    message.BodyEncoding = System.Text.Encoding.GetEncoding(1252);
                    message.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    message.Subject = "Appointment Reminder: " + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinicn;
                    message.Body = sr1.ToString();
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (Exception ex)
                { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        public void getappointment(DataTable dt)
        {
            try
            {
                string dr_color = "0", dr_mobile = "0", dr_email = "";
                if (dt.Rows.Count > 0)
                {
                    dr_color = dt.Rows[0]["calendar_color"].ToString();
                    name = "Dr " + dt.Rows[0]["doctor_name"].ToString();
                    dr_mobile = dt.Rows[0]["mobile_number"].ToString();
                    dr_email = dt.Rows[0]["email_id"].ToString();
                }
                Dateonly = Convert.ToDateTime(DateTime.Now.ToLocalTime());
                DateTime StartT, EndTime;
                StartT = dpStartTimeDate.Value.Date;
                EndTime = dpStartTimeDate.Value.Date;
                StartT = StartT.AddHours(cmbStartTime.SelectedIndex / 12);
                EndTime = EndTime.AddHours(cmbEndTime.SelectedIndex / 12);
                int md = cmbStartTime.SelectedIndex % 12;
                int en_ms = cmbEndTime.SelectedIndex % 12;
                StartT1 = StartT.AddMinutes(md * 5);
                EndTime = EndTime.AddMinutes(en_ms * 5);
                var diff = EndTime.Subtract(StartT);
                diff1 = Convert.ToString(diff.Minutes);
                if (Dateonly > StartT)
                {
                    MessageBox.Show("Appointment Date should be greater than Current Date...", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cmbStartTime.SelectedIndex <= cmbEndTime.SelectedIndex)
                    {
                        if (appointment_id !="")
                        {
                            j = this.ctrlr.apntupdate(Convert.ToDateTime(StartT1).ToString("yyyy-MM-dd HH:mm"), diff1, txtDescription.Text, dr_id, compoprocedure.Text,name, appointment_id);
                        }
                        else
                        {
                            j = this.ctrlr.insappointment(Convert.ToDateTime(Dateonly).ToString("yyyy-MM-dd"), Convert.ToDateTime(StartT1).ToString("yyyy-MM-dd H:mm:ss"), diff1, txtDescription.Text, patient_id,linkLabel_Name.Text,dr_id,p_mobile,p_email,compoprocedure.Text,name);
                        }
                        if (checkBox1.Checked)
                        {
                            DataTable sms=this.ctrlr.smsdetails();
                            smsdetails(sms);
                            DataTable ptnt=this.ctrlr.Get_Patient_Details(patient_id);
                            Get_Patient_Details(ptnt);
                            DataTable rem=this.ctrlr.smsreminder();
                            smsreminder(rem);
                        }
                        if (checkBox3.Checked)
                        {
                            if (dr_mobile != "0")
                            {
                                string number = "91" + dr_mobile;
                                text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + patient_name + " for " + compoprocedure.Text + " at " + clinicn + "," + contact_no;
                                string smsdctr=this.ctrlr.SendSMS(smsName, smsPass, number, text);
                                //For Remainder SMS
                                if (day_time != null)
                                {
                                    if (dpStartTimeDate.Value > DateTime.Now.Date)
                                    {
                                        text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + patient_name + " for " + compoprocedure.Text + " at " + clinicn + "," + contact_no;
                                        string smsdctr2=this.ctrlr.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + " 09:10:00 am", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                    }
                                }
                                if (before_time != null)
                                {
                                    if (dpStartTimeDate.Value > DateTime.Now.Date)
                                    {
                                        text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + patient_name + " for " + compoprocedure.Text + " at " + clinicn + "," + contact_no;
                                        string smsdctr3=this.ctrlr.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + before_time, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                    }
                                }
                            }
                        }//Doctor SMS End
                        if (checkBox2.Checked)
                        {
                            DataTable email=this.ctrlr.send_email();
                            send_email(email);
                        }// email end
                        if (checkBox4.Checked) // Doctor Email
                        {
                            if (dr_email != "")
                            {
                                DataTable email = this.ctrlr.send_email();
                                send_email(email);
                            }
                        }// Doctor Email end
                        if (j > 0)
                        {
                            var form2 = new PappyjoeMVC.View.Show_Appointment();
                            form2.patient_id = patient_id;
                            form2.doctor_id = doctor_id;
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
                        MessageBox.Show("Appointment Time is incorrect,Please change the time", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                dr_id = Cmb_doctor.GetItemText(Cmb_doctor.SelectedValue);
                DataTable getapnt=this.ctrlr.getappointment(dr_id);
                getappointment(getapnt);
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        public void Patient_search(DataTable dtb)
        {
            try
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
                    listpatientsearch.Location = new Point(toolStrip1.Width - 350, 32);
                }
                else
                {
                    listpatientsearch.Visible = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable srch=this.ctrlr.Patient_search(toolStripTextBox1.Text);
            Patient_search(srch);
        }
    }
}
