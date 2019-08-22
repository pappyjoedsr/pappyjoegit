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
    public partial class Add_Appointment : Form,Add_Appointment_interface
    {
        int j=0;
        public string doctor_id = "",ap_id;
        public string pat_id,doc;
        string d_id = "",name = "", diff1 = "0";
        public DateTime StartT,StartT1,EndTime,Dateonly ;
        public static string gender;
        public string appointment_id = "0";
        sms a = new sms();
        public string send_on_day,send_before_day,day_time,before_time;
        string patient_name = "", p_mobile = "", p_email = "",clinicn = "", contact_no = "",text = "",smsName = "", smsPass = "",emailName = "", emailPass = "";
        Communication_model cmdl=new Communication_model();
        Add_Appointment_model mdl = new Add_Appointment_model();
        Add_Appointment_controller ctrlr;
        common_model c=new common_model();
        public Add_Appointment()
        {
            InitializeComponent();
            InitializeControls();
        }
        public DateTime start_date
        {
            get { return StartT1; }
            set { StartT1 = value; }
        }
        public DateTime book_datetime
        {
            get { return Dateonly; }
            set { Dateonly = value; }
        }
        public string message
        {
            get { return text; }
            set {text = value; }
        }
        public string duration
        {
            get { return diff1; }
            set {diff1 = value; }
        }
        public string pt_name
        {
            get { return patient_name; }
            set {patient_name = value; }
        }
        public string pt_mobile
        {
            get { return p_mobile; }
            set { p_mobile = value; }
        }
        public string pt_email
        {
            get { return p_email; }
            set { p_email = value; }
        }
        public string note
        {
            get { return this.txtDescription.Text ; }
            set { this.txtDescription.Text = value; }
        }
        public string plan_new_procedure
        {
            get { return this.compoprocedure.Text; }
            set { this.compoprocedure.Text = value; }
        }
        public string booked_by
        {
            get { return name; }
            set {name= value; }
        }
        public string patient_id
        {
            get { return pat_id; }
            set { pat_id = value; }
        }
        public string clname
        {
            get { return this.mdl.clname; }
            set { this.mdl.clname= value; }
        }
        public string locality
        {
            get { return this.mdl.locality; }
            set { this.mdl.locality = value; }
        }
        public string contactno
        {
            get { return this.mdl.contactno; }
            set { this.mdl.contactno= value; }
        }
        //public string appointment_id
        //{
        //    get { return ap_id; }
        //    set { ap_id = value; }
        //}
        public string docid
        {
            get { return doc ; }
            set { doc= value; }
        }
        public string dr_id
        {
            get { return d_id; }
            set { d_id = value; }
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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controllr = new Communication_controller(form2);
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

        private void toolStripButton11_Click(object sender, EventArgs e)
        {

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

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.permission_for_settings(doctor_id);
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

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
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

        public void setController(Add_Appointment_controller controller)
        {
            ctrlr = controller;
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
            var form2 = new PappyjoeMVC.View.Show_Appointment();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            Show_Appointment_controller ctrlr = new Show_Appointment_controller(form2);
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
        //functions
        public void clinicdetails(DataTable dt)
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
        public void Get_DoctorName(string dt1)
        {
            if (dt1!="")
            {
                toolStripTextDoctor.Text = "Logged In As : " + dt1;
            }
        }
        public void getdocid(DataTable dt)
        {
            if(dt.Rows.Count>0)
            {
                int index = Cmb_doctor.FindString(Convert.ToString(dt.Rows[0]["doctor_name"].ToString()));
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
            if(ap_id!="0")
            {
                if (dt.Rows.Count > 0)
                {
                    doc = dt.Rows[0]["dr_id"].ToString();
                    this.ctrlr.getdocid(doc);
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
        public void getapid(string apid)
        {
           ap_id = apid;
        }
        public void get_All_proceure(DataTable dt)
        {
            compoprocedure.DataSource = dt; ;
            compoprocedure.DisplayMember = "name";
            compoprocedure.ValueMember = "id";
        }
        public void get_all_doctorname(DataTable dt)
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
        public void getpatdetails(DataTable dt1)
        {
            if (dt1.Rows[0]["pt_name"].ToString() != "")
            {
                linkLabel_Name.Text = dt1.Rows[0]["pt_name"].ToString();
                patient_name =dt1.Rows[0]["pt_name"].ToString();
            }
            if (dt1.Rows[0]["pt_id"].ToString() != "")
            {
                linkLabel_id.Text = dt1.Rows[0]["pt_id"].ToString();
            }
            if (dt1.Rows[0]["primary_mobile_number"].ToString() != "")
            {
                p_mobile = dt1.Rows[0]["primary_mobile_number"].ToString();
            }
            if (dt1.Rows[0]["email_address"].ToString() != "")
            {
                p_email = dt1.Rows[0]["email_address"].ToString();
            }
            gender = dt1.Rows[0]["gender"].ToString();
        }
        public void getdays(DataTable dt)
        {
            if(dt.Rows.Count>0)
            {
                string number = "91" + dt.Rows[0]["primary_mobile_number"].ToString();
                text = "Dear " +dt.Rows[0]["pt_name"].ToString() + " " + "Your appointment for " + compoprocedure.Text + " has been confirmed at " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " with " + "Dr " + Cmb_doctor.Text + " Regards " + clinicn + "," + contact_no;
                a.SendSMS(smsName, smsPass, number, text);
                this.ctrlr.inssms();
                //For Remainder SMS
                if (day_time != null)
                {
                    if (dpStartTimeDate.Value > DateTime.Now.Date)
                    {
                        text = "Dear " + dt.Rows[0]["pt_name"].ToString() + ", " + "Today you have an appointment at " + clinicn + " on " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " for " + compoprocedure.Text + " .Regards  " + clinicn + "," + contact_no;
                        a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + " 09:10:00 am", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    }
                }
                if (before_time != null)
                {
                    if (dpStartTimeDate.Value > DateTime.Now.Date)
                    {
                        text = "Dear " + dt.Rows[0]["pt_name"].ToString() + ", " + "Today you have an appointment at " + clinicn + " on " + StartT1.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " for " + compoprocedure.Text + " .Regards  " + clinicn + "," + contact_no;
                        a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + before_time, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    }
                }
            }//SMS End Patient 
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
                this.ctrlr.clinicdetails();
                this.ctrlr.Get_DoctorName(doctor_id);
                this.ctrlr.getpatdetails(patient_id);
                this.ctrlr.get_all_doctorname();
                this.ctrlr.get_All_proceure();
                //this.ctrlr.getapid();
                this.ctrlr.dt_appointment(appointment_id);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data loading error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getappointment(DataTable dt)
        {
            string dr_color = "0",dr_mobile = "0",dr_email = "";
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
                    if (appointment_id != "0")
                    {
                        j=this.ctrlr.update(appointment_id);
                    }
                    else
                    {
                        j=this.ctrlr.insappointment();
                    }
                    if (checkBox1.Checked)
                    {
                        DataTable sms = this.cmdl.selsms();
                        if (sms.Rows.Count > 0)
                        {
                            smsName = sms.Rows[0]["smsName"].ToString();
                            smsPass = sms.Rows[0]["smsPass"].ToString();
                        }
                        DataTable smsreminder = this.mdl.smsreminder();
                        if (smsreminder.Rows.Count > 0)
                        {
                            send_on_day = smsreminder.Rows[0]["send_on_day"].ToString();
                            send_before_day = smsreminder.Rows[0]["send_before_day"].ToString();
                            day_time = smsreminder.Rows[0]["day_time"].ToString();
                            before_time = smsreminder.Rows[0]["day_time"].ToString();
                        }
                        this.ctrlr.getdays(patient_id);
                    }
                    if (checkBox3.Checked)
                    {
                        if (dr_mobile != "0")
                        {
                            string number = "91" + dr_mobile;
                            text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + patient_name + " for " + compoprocedure.Text + " at " + clinicn + "," + contact_no;
                            a.SendSMS(smsName, smsPass, number, text);
                            //For Remainder SMS
                            if (day_time != null)
                            {
                                if (dpStartTimeDate.Value > DateTime.Now.Date)
                                {
                                    text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + patient_name + " for " + compoprocedure.Text + " at " + clinicn + "," + contact_no;
                                    a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + " 09:10:00 am", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                }
                            }
                            if (before_time != null)
                            {
                                if (dpStartTimeDate.Value > DateTime.Now.Date)
                                {
                                    text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + patient_name + " for " + compoprocedure.Text + " at " + clinicn + "," + contact_no;
                                    a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT1.ToString("dd/MM/yyyy") + before_time, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                }
                            }
                        }
                    }//Doctor SMS End
                    if (checkBox2.Checked)
                    {
                            DataTable sms = this.c.send_email();
                            if (sms.Rows.Count > 0)
                            {
                                emailName = sms.Rows[0]["emailName"].ToString();
                                emailPass = sms.Rows[0]["emailPass"].ToString();
                                try
                                {
                                    string sr1 = "<table align='center' style='width:700px;border: 1px solid ;border-collapse: collapse; background: #EAEAEA; height:500px'><tr><td  align='left' height='27'><FONT  color='#666666'  face='Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Reminder:" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinicn + "</font></td></tr><tr><td  align='left' height='400px'><table  height='423' align='center' style='width:600px; background: #FFFFFF; height:400px'><tr><td  align='left' height='6px'><FONT  color='#000000'  face='Arial' SIZE=6>" + clinicn + "</font></td></tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr><tr><td  align='left' height='62' valign='bottom'><FONT  color='#000000'  face='Arial' SIZE=3>Good morning <b>" + pt_name+ "</b></font></td></tr> <tr><td align='left' height='197' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Just to remind you about your appointment at " + clinicn + ".<table><tbody><tr><td width='188' height='31' valign='bottom' align='right'>WHEN :</td><td width='30' height='31' valign='bottom' align='right'></td><td width='358' valign='bottom'> <strong>" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + "</strong></td>  </tr><tr><td height='76' valign='top'  align='right'>WHERE :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + locality + "</td></tr></tbody></table> For any queries, contact us at : " + contact_no + "</td>  </tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr> <tr><td height='25'  align='right' valign='bottom'>Powered by&nbsp;&nbsp; </td></tr> <tr><td height='81'  align='right' valign='top'><img src='http://pappyjoe.com/assets/images/pappyjoe-logo.PNG' alt='pappyjoe official logo'>&nbsp;&nbsp;</td></tr></table></td></tr></table>";
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
                                catch(Exception ex)
                                {
                                    MessageBox.Show("Sending Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }// email end
                    if (checkBox4.Checked) // Doctor Email
                        {
                            if (dr_email != "")
                            {
                                DataTable sms =this.c.send_email();
                                if (sms.Rows.Count > 0)
                                {
                                    emailName = sms.Rows[0]["emailName"].ToString();
                                    emailPass = sms.Rows[0]["emailPass"].ToString();
                                    try
                                    {
                                        string sr1 = "<table align='center' style='width:700px;border: 1px solid ;border-collapse: collapse; background: #EAEAEA; height:500px'><tr><td  align='left' height='27'><FONT  color='#666666'  face='Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Reminder:" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinicn + "</font></td></tr><tr><td  align='left' height='400px'><table  height='423' align='center' style='width:600px; background: #FFFFFF; height:400px'><tr><td  align='left' height='6px'><FONT  color='#000000'  face='Arial' SIZE=6>" + clinicn + "</font></td></tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr><tr><td  align='left' height='62' valign='bottom'><FONT  color='#000000'  face='Arial' SIZE=3>Dear <b>" + Cmb_doctor.Text + "</b></font></td></tr> <tr><td align='left' height='197' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Just to remind you about your appointment at " + clinicn + ".<table><tbody><tr><td width='188' height='31' valign='bottom' align='right'>WHEN :</td><td width='30' height='31' valign='bottom' align='right'></td><td width='358' valign='bottom'> <strong>" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + "</strong></td>  </tr><tr><td height='31' valign='top'  align='right'>PATIENT :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + patient_name + "</td></tr><tr><td height='76' valign='top'  align='right'>FOR :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + compoprocedure.Text + "</td></tr></tbody></table> For any queries, contact us at : " + contact_no + "</td>  </tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr> <tr><td height='25'  align='right' valign='bottom'>Powered by&nbsp;&nbsp; </td></tr> <tr><td height='81'  align='right' valign='top'><img src='http://pappyjoe.com/assets/images/pappyjoe-logo.PNG' alt='pappyjoe official logo'>&nbsp;&nbsp;</td></tr></table></td></tr></table>";
                                        MailMessage message = new MailMessage();
                                        message.From = new MailAddress(dr_email);
                                        message.To.Add(dr_email);
                                        message.BodyEncoding = System.Text.Encoding.GetEncoding(1252); //bijeesh
                                        message.IsBodyHtml = true; //bijeesh
                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                        message.Subject = "Appointment(s) scheduled for Today: " + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinicn;
                                        message.Body = sr1.ToString();
                                        smtp.Port = 587;
                                        smtp.Host = "smtp.gmail.com";
                                        smtp.EnableSsl = true;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        smtp.Send(message);
                                    }
                                    catch(Exception ex)
                                    {
                                        MessageBox.Show("Sending Error!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }// Doctor Email end
                    if (j > 0)
                    {
                        var form2 = new PappyjoeMVC.View.Show_Appointment();
                        form2.patient_id = patient_id;
                        form2.doctor_id = doctor_id;
                        Show_Appointment_controller ctrlr = new Show_Appointment_controller(form2);
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
                    MessageBox.Show("Appointment Time is inncorrect,Please change the time", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                d_id = Cmb_doctor.GetItemText(Cmb_doctor.SelectedValue);
                this.ctrlr.getappointment();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Inseration Failed!..", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        public void Patient_search(DataTable dtb)
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
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.ctrlr.Patient_search(toolStripTextBox1.Text);
        }
    }
}
