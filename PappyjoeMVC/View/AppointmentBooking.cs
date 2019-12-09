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
using XtremeCalendarControl;
using System.Net.Mail;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class AppointmentBooking : Form
    {
        Connection db = new Connection();
        public string doctor_id = "0";
        public string gpl_app_id = "0";
        string app_Doctor_id = "0";
        public string patient_id = "0";
        public string patient_name;
        public int status1 = 0;
        Booking_controller cntrl =new Booking_controller();
        private System.Windows.Forms.Label lblShowTimeAs;
        private System.Windows.Forms.Button cmdRecurrence;
        public CalendarEvent EditingEvent;
        public Boolean IsNewEvent = true;
        internal System.Windows.Forms.ComboBox cmbReminder;

        static public AppointmentBooking Instance;
        public string send_on_day { get; set; }
        public string send_before_day { get; set; }
        public string day_time { get; set; }
        public string before_time { get; set; }
        public AppointmentBooking()
        {
            Instance = this;
            InitializeComponent();
            InitializeControls();
        }
        private void InitializeControls()
        {
            cmbLabel.Items.Insert(0, "None");
            cmbLabel.Items.Insert(1, "Important");
            cmbLabel.Items.Insert(2, "Business");
            cmbLabel.Items.Insert(3, "Personal");
            cmbLabel.Items.Insert(4, "Vacation");
            cmbLabel.Items.Insert(5, "Must Attend");
            cmbLabel.Items.Insert(6, "Travel Required");
            cmbLabel.Items.Insert(7, "Needs Preparation");
            cmbLabel.Items.Insert(8, "Birthday");
            cmbLabel.Items.Insert(9, "Anniverserary");
            cmbLabel.Items.Insert(10, "Phone Call");
            cmbLabel.SelectedIndex = 0;
            cmbShowTimeAs.Items.Insert(0, "Free");
            cmbShowTimeAs.Items.Insert(1, "Tentative");
            cmbShowTimeAs.Items.Insert(2, "Busy");
            cmbShowTimeAs.Items.Insert(3, "Out of Office");
            cmbShowTimeAs.SelectedIndex = 0;
            DateTime dtHours = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            for (int cnt = 0; cnt < 288; cnt++)
            {
                cmbStartTime.Items.Insert(cnt, dtHours.ToString("h:mm tt"));
                cmbEndTime.Items.Insert(cnt, dtHours.ToString("h:mm tt"));
                dtHours = dtHours.AddMinutes(5);
            }
            cmbStartTime.SelectedIndex = 10;
            cmbEndTime.SelectedIndex = 11;

        }
        private class CalReminderMinutes
        {
            public Int32 m_nMinutes;
            public String m_strMinutes;
            public CalReminderMinutes(Int32 nMinutes, String strMinutes)
            {
                m_nMinutes = nMinutes;
                m_strMinutes = strMinutes;
            }
            public CalReminderMinutes()
            {
                m_nMinutes = 0;
                m_strMinutes = "";
            }
            public override String ToString()
            {
                return m_strMinutes;
            }
        }
        private void AppointmentBooking_Load(object sender, EventArgs e)
        {
            try
            {
                string i;
                i = this.cntrl.Add_privillege(doctor_id);
                if (int.Parse(i) > 0)
                {
                    DataTable dt = this.cntrl.doctor_name(doctor_id);
                    combodoctor.DataSource = dt;
                    combodoctor.DisplayMember = "doctor_name";
                    combodoctor.ValueMember = "id";
                }
                else
                {
                    DataTable dt = this.cntrl.get_all_doctorname();
                    combodoctor.DataSource = dt;
                    combodoctor.DisplayMember = "doctor_name";
                    combodoctor.ValueMember = "id";
                }
                DataTable dt1 = this.cntrl.get_All_proceure();
                compoprocedure.DataSource = dt1;
                compoprocedure.DisplayMember = "name";
                compoprocedure.ValueMember = "id";
                combocategory.SelectedIndex = 0;
                if (combodoctor.Items.Count > 0)
                {
                    if (gpl_app_id != "0")
                    {
                        String doctor = this.cntrl.getdocid(app_Doctor_id);
                        if (doctor!="")
                        {
                            int index = combodoctor.FindString(Convert.ToString(doctor));
                            if (index >= 0)
                            {
                                combodoctor.SelectedIndex = index;
                            }
                            else
                            {
                                combodoctor.SelectedIndex = 0;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void lab_edit_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
         
        private void lab_edit_MouseEnter(object sender, EventArgs e)
        {
            lab_edit.ForeColor = Color.FromArgb(5, 32, 59);
        }

        private void lab_edit_MouseLeave(object sender, EventArgs e)
        {
            lab_edit.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void txt_p_name_KeyUp(object sender, KeyEventArgs e)
        {
            label14.Visible = false;
            DataTable dt = this.cntrl.search_patient(txt_p_name.Text);
            list_p_details.DataSource = dt;
            list_p_details.DisplayMember = "pt_name";
            list_p_details.ValueMember = "id";
            list_p_details.Location = new Point(146, 39);
            list_p_details.Show();
            patient_id = "0";
            if (e.KeyCode == Keys.Down && list_p_details.Items.Count > 0)
            {
                list_p_details.Focus();
            }
            else if (e.KeyCode == Keys.Enter && list_p_details.Items.Count > 0)
            {
                patient_id = list_p_details.GetItemText(list_p_details.SelectedValue);
                DataTable dt_p = this.cntrl.Getpat_MobNamme(patient_id);
                Fill_search_patient(dt_p);
                list_p_details.Hide();
            }
            if (dt.Rows.Count <= 0)
            {
                list_p_details.Hide();
            }
        }

        private void txt_p_id_KeyUp(object sender, KeyEventArgs e)
        {
            label14.Visible = false;
            patient_id = "0";
            DataTable dt = this.cntrl.search_ptid(txt_p_id.Text);
            list_p_details.DataSource = dt;
            list_p_details.DisplayMember = "pt_name";
            list_p_details.ValueMember = "id";
            list_p_details.Location = new Point(146, 71);
            list_p_details.Show();
            if (e.KeyCode == Keys.Down && list_p_details.Items.Count > 0)
            {
                list_p_details.Focus();
            }
            else if (e.KeyCode == Keys.Enter && list_p_details.Items.Count > 0)
            {
                patient_id = list_p_details.GetItemText(list_p_details.SelectedValue);
               DataTable dt_p = this.cntrl.Getpat_MobNamme(patient_id);
                Fill_search_patient(dt_p);
                list_p_details.Hide();
                if (dt.Rows.Count <= 0)
                {
                    list_p_details.Hide();
                }
                else
                {
                    list_p_details.Show();
                }
            }
        }

        public void Fill_search_patient(DataTable dt_p)
        {
            if (dt_p.Rows.Count > 0)
            {
                txt_p_name.Text = dt_p.Rows[0][0].ToString();
                lab_p_name.Text = dt_p.Rows[0][0].ToString() + "(" + dt_p.Rows[0][1].ToString() + ")";
                lab_p_ph.Text = dt_p.Rows[0][2].ToString();
                patient_name = dt_p.Rows[0][0].ToString();
                lab_p_email.Text = dt_p.Rows[0][3].ToString();
                panel1.Hide();
            }
        }

        private void txt_p_mobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_p_mobile_KeyUp(object sender, KeyEventArgs e)
        {
            label14.Visible = false;
            patient_id = "0";
            DataTable dt = this.cntrl.search_ptid(txt_p_mobile.Text);
            list_p_details.DataSource = dt;
            list_p_details.DisplayMember = "pt_name";
            list_p_details.ValueMember = "id";
            list_p_details.Location = new Point(146, 109);
            list_p_details.Show();
            if (e.KeyCode == Keys.Down && list_p_details.Items.Count > 0)
            {
                list_p_details.Focus();
            }
            else if (e.KeyCode == Keys.Enter && list_p_details.Items.Count > 0)
            {
                patient_id = list_p_details.GetItemText(list_p_details.SelectedValue);
               DataTable dt_p = this.cntrl.Getpat_MobNamme(patient_id);
                Fill_search_patient(dt_p);
                list_p_details.Hide();
            }
            if (dt.Rows.Count <= 0)
            {
                list_p_details.Hide();
            }
            else
            {
                list_p_details.Show();
            }
        }

        private void list_p_details_KeyUp(object sender, KeyEventArgs e)
        {
            patient_id = "0";
            if (e.KeyCode == Keys.Enter && list_p_details.Items.Count > 0)
            {
                patient_id = list_p_details.GetItemText(list_p_details.SelectedValue);
               DataTable dt_p =  this.cntrl.Getpat_MobNamme(patient_id);
                Fill_search_patient(dt_p);
                list_p_details.Hide(); 
            }
        }

        private void list_p_details_Click(object sender, EventArgs e)
        {
            patient_id = "0";
            if (list_p_details.Items.Count > 0)
            {
                patient_id = list_p_details.GetItemText(list_p_details.SelectedValue);
                DataTable dt_p = this.cntrl.Getpat_MobNamme(patient_id);
                Fill_search_patient(dt_p);
                list_p_details.Hide();
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                 string neworold = "0"; DataTable dtpSearch = new DataTable();
                DataTable dtb = this.cntrl.patient_details(txt_p_name.Text);
                Appointment_for_newPAtient(dtb);
                if (cmbStartTime.SelectedIndex <= cmbEndTime.SelectedIndex)
                {
                    if (patient_id != "0")
                    {
                        string dr_id = combodoctor.GetItemText(combodoctor.SelectedValue);
                        string dr_color = "0";
                        long app_id = 0;
                        DateTime Dateonly = DateTime.Now.Date;
                        string dr_mobile = "0";
                        string dr_email = "";
                        DataTable dt_d = this.cntrl.Get_calenderColor(dr_id);
                        if (dt_d.Rows.Count > 0)
                        {
                            dr_color = dt_d.Rows[0][0].ToString();
                            dr_mobile = dt_d.Rows[0][1].ToString();
                            dr_email = dt_d.Rows[0][2].ToString();
                        }
                        string diff1 = "0";
                        DateTime StartTime1 = DateTime.Now.Date;
                        // string Stime; 
                        if (EditingEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceNotRecurring ||
                            EditingEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceException)
                        {
                            DateTime StartTime, EndTime;
                            StartTime = dpStartTimeDate.Value;
                            EndTime = dpStartTimeDate.Value;
                            StartTime = StartTime.AddHours(cmbStartTime.SelectedIndex / 12);
                            EndTime = EndTime.AddHours(cmbEndTime.SelectedIndex / 12);
                            int st_ms = 0;
                            st_ms = cmbStartTime.SelectedIndex % 12;
                            StartTime = StartTime.AddMinutes(st_ms * 5);
                            st_ms = cmbEndTime.SelectedIndex % 12;
                            EndTime = EndTime.AddMinutes(st_ms * 5);
                            EditingEvent.StartTime = StartTime;
                            EditingEvent.EndTime = EndTime;
                            var diff = EndTime.Subtract(StartTime);
                            if (diff.Hours.ToString() != "")
                            {
                                int valh = diff.Hours;
                                valh = valh * 60;
                                int valm = diff.Minutes;
                                diff1 = Convert.ToString(valh + valm);
                            }
                            else
                            {
                                diff1 = Convert.ToString(diff.Minutes);
                            }
                            StartTime1 = StartTime;
                        }

                        DateTime Dateonly1 = DateTime.Now;

                        if (Dateonly1 > StartTime1)
                        {
                            MessageBox.Show("Appointment Date should be greater than Current Date...", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (IsNewEvent)
                        {
                            DateTime StartT;
                            StartT = dpStartTimeDate.Value;
                            StartT = StartT.AddHours(cmbStartTime.SelectedIndex / 12);
                            int md = cmbStartTime.SelectedIndex % 12;
                            StartT = StartT.AddMinutes(md * 5);
                            //*********Booking Name***********//
                            string Name = "";
                            DataTable doctor = this.cntrl.get_doctor_login(PappyjoeMVC.Model.Connection.MyGlobals.Doctor_id);
                            if (doctor.Rows.Count > 0)
                            {
                                if (doctor.Rows[0]["login_type"].ToString() == "doctor")
                                {
                                    Name = "Dr ";
                                }

                                Name = Name + doctor.Rows[0]["doctor_name"].ToString();
                            }
                            dtpSearch = this.cntrl.patient_details_byname(txt_p_name.Text);
                            if (dtpSearch.Rows.Count <= 0)
                            {
                                this.cntrl.insappointment(Convert.ToDateTime(Dateonly).ToString("yyyy-MM-dd"), Convert.ToDateTime(StartT).ToString("yyyy-MM-dd HH:mm"), diff1, txtDescription.Text, patient_id, txt_p_name.Text, dr_id, txt_p_mobile.Text, txt_p_email.Text, compoprocedure.Text, Name);
                            }
                            else
                            {
                                this.cntrl.insappointment(Convert.ToDateTime(Dateonly).ToString("yyyy-MM-dd"), Convert.ToDateTime(StartT).ToString("yyyy-MM-dd HH:mm"), diff1, txtDescription.Text, patient_id, patient_name, dr_id, lab_p_ph.Text, lab_p_email.Text, compoprocedure.Text, Name);
                            }

                            DataTable dt_a = this.cntrl.appointmentId();
                            if (dt_a.Rows.Count > 0)
                            {
                                app_id = Convert.ToInt32(dt_a.Rows[dt_a.Rows.Count - 1][0].ToString());
                            }
                            EditingEvent.Subject = patient_name;
                            EditingEvent.Location = Convert.ToString(cmbStartTime.GetItemText(cmbStartTime.SelectedItem)) + "-" + Convert.ToString(cmbEndTime.GetItemText(cmbEndTime.SelectedItem));
                            EditingEvent.Body = Convert.ToString(app_id);
                            EditingEvent.Label = Convert.ToInt32(dr_color);
                            EditingEvent.AllDayEvent = (chkAllDayEvent.Checked ? true : false);
                            EditingEvent.BusyStatus = (CalendarEventBusyStatus)cmbShowTimeAs.SelectedIndex;
                            EditingEvent.PrivateFlag = (chkPrivate.Checked ? true : false);
                            EditingEvent.MeetingFlag = (chkMeeting.Checked ? true : false);
                            EditingEvent.Reminder = chkReminder.Checked;
                            if (EditingEvent.Reminder)
                            {
                                CalReminderMinutes pRmd = (CalReminderMinutes)cmbReminder.SelectedItem;
                                if (pRmd != null)
                                {
                                    EditingEvent.ReminderMinutesBeforeStart = pRmd.m_nMinutes;
                                }
                            }
                            Main_Calendar.Instance.wndCalendarControl.DataProvider.AddEvent(EditingEvent);
                            string clinic = "", locality = "", contact_no = "";

                            System.Data.DataTable clinicname = this.cntrl.clinicdetails();
                            if (checkBox1.Checked)
                            {
                                string text = "";
                                string smsName = "", smsPass = "";
                                DataTable sms = this.cntrl.smsdetails();
                                if(sms.Rows.Count>0)
                                {
                                    smsName = sms.Rows[0]["smsName"].ToString();
                                    smsPass = sms.Rows[0]["smsPass"].ToString();
                                }
                                SMS_model a = new SMS_model();
                                DataTable pat = this.cntrl.Get_Patient_Details(patient_id);
                                DataTable smsreminder = this.cntrl.Get_reminderSmS();
                                if (smsreminder.Rows.Count > 0)
                                {
                                    send_on_day = smsreminder.Rows[0]["send_on_day"].ToString();
                                    send_before_day = smsreminder.Rows[0]["send_before_day"].ToString();
                                    day_time = smsreminder.Rows[0]["day_time"].ToString();
                                    before_time = smsreminder.Rows[0]["day_time"].ToString();
                                }
                                if (pat.Rows.Count > 0)
                                {
                                    string number = "91" + pat.Rows[0]["primary_mobile_number"].ToString();
                                    if (neworold == "1")
                                    {

                                        a.SendSMS(smsName, smsPass, number, "Dear " + pat.Rows[0]["pt_name"].ToString() + " welcome to " + clinic + "," + contact_no);
                                    }

                                    text = "Dear " + pat.Rows[0]["pt_name"].ToString() + " " + "Your appointment for " + compoprocedure.Text + " has been confirmed at " + StartT.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " with " + "Dr " + combodoctor.Text + " Regards " + clinic + "," + contact_no;
                                    a.SendSMS(smsName, smsPass, number, text);
                                    this.cntrl.save_Pt_SMS(patient_id, pat.Rows[0]["pt_name"].ToString(), compoprocedure.Text, StartT.ToString("dd/MM/yyyy"), cmbStartTime.Text, combodoctor.Text);
                                    //For Remainder SMS
                                    if (day_time != null)
                                    {
                                        if (dpStartTimeDate.Value > DateTime.Now.Date)
                                        {
                                            text = "Dear " + pat.Rows[0]["pt_name"].ToString() + ", " + "Today you have an appointment at " + clinic + " on " + StartT.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " for " + compoprocedure.Text + " .Regards  " + clinic + "," + contact_no;
                                            a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT.ToString("dd/MM/yyyy") + " 09:10:00 am", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                        }
                                    }
                                    if (before_time != null)
                                    {
                                        if (dpStartTimeDate.Value > DateTime.Now.Date)
                                        {

                                            text = "Dear " + pat.Rows[0]["pt_name"].ToString() + ", " + "Today you have an appointment at " + clinic + " on " + StartT.ToString("dd/MM/yyyy") + " " + cmbStartTime.Text + " for " + compoprocedure.Text + " .Regards  " + clinic + "," + contact_no;
                                            a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT.ToString("dd/MM/yyyy") + before_time, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                        }
                                    }
                                }
                            }

                            if (checkBox3.Checked)
                            {
                                if (dr_mobile != "0")
                                {
                                    string text = "";
                                    string smsName = "", smsPass = "";
                                    SMS_model a = new SMS_model();
                                    string number = "91" + dr_mobile;
                                    text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + txt_p_name.Text + " for " + compoprocedure.Text + " at " + clinic + "," + contact_no;
                                    a.SendSMS(smsName, smsPass, number, text);
                                    //For Remainder SMS
                                    if (day_time != null)
                                    {
                                        if (dpStartTimeDate.Value > DateTime.Now.Date)
                                        {

                                            text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + txt_p_name.Text + " for " + compoprocedure.Text + " at " + clinic + "," + contact_no;
                                            // a.SendSMS(smsName, smsPass, number, text);
                                            a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT.ToString("dd/MM/yyyy") + " 09:10:00 am", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                        }
                                    }
                                    if (before_time != null)
                                    {
                                        if (dpStartTimeDate.Value > DateTime.Now.Date)
                                        {
                                            text = "You have an appointment on " + dpStartTimeDate.Value.ToShortDateString() + " " + cmbStartTime.Text + " With " + txt_p_name.Text + " for " + compoprocedure.Text + " at " + clinic + "," + contact_no;
                                            a.SendSMS(smsName, smsPass, number, text, "DRTOMS", patient_id.ToString(), StartT.ToString("dd/MM/yyyy") + before_time, DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                        }
                                    }
                                }
                            }

                            if (checkBox2.Checked)
                            {
                                string email = "", emailName = "", emailPass = "";

                                string query = "select email_address,pt_name from tbl_patient where id='" + patient_id + "'";

                                DataTable sr = this.cntrl.getpatemail(patient_id);
                                if (sr.Rows.Count > 0)
                                {
                                    email = sr.Rows[0]["email_address"].ToString();
                                    DataTable sms = this.cntrl.send_email();
                                    if (sms.Rows.Count > 0)
                                    {
                                        emailName = sms.Rows[0]["emailName"].ToString();
                                        emailPass = sms.Rows[0]["emailPass"].ToString();

                                        try
                                        {
                                            string sr1 = "<table align='center' style='width:700px;border: 1px solid ;border-collapse: collapse; background: #EAEAEA; height:500px'><tr><td  align='left' height='27'><FONT  color='#666666'  face='Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Reminder:" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinic + "</font></td></tr><tr><td  align='left' height='400px'><table  height='423' align='center' style='width:600px; background: #FFFFFF; height:400px'><tr><td  align='left' height='6px'><FONT  color='#000000'  face='Arial' SIZE=6>" + clinic + "</font></td></tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr><tr><td  align='left' height='62' valign='bottom'><FONT  color='#000000'  face='Arial' SIZE=3>Good morning <b>" + sr.Rows[0]["pt_name"].ToString() + "</b></font></td></tr> <tr><td align='left' height='197' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Just to remind you about your appointment at " + clinic + ".<table><tbody><tr><td width='188' height='31' valign='bottom' align='right'>WHEN :</td><td width='30' height='31' valign='bottom' align='right'></td><td width='358' valign='bottom'> <strong>" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + "</strong></td>  </tr><tr><td height='76' valign='top'  align='right'>WHERE :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + locality + "</td></tr></tbody></table> For any queries, contact us at : " + contact_no + "</td>  </tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr> <tr><td height='25'  align='right' valign='bottom'>Powered by&nbsp;&nbsp; </td></tr> <tr><td height='81'  align='right' valign='top'><img src='http://pappyjoe.com/assets/images/pappyjoe-logo.PNG' alt='pappyjoe official logo'>&nbsp;&nbsp;</td></tr></table></td></tr></table>";
                                            MailMessage message = new MailMessage();
                                            message.From = new MailAddress(email);
                                            message.To.Add(email);
                                            message.BodyEncoding = System.Text.Encoding.GetEncoding(1252); //bijeesh
                                            message.IsBodyHtml = true; //bijeesh
                                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                            message.Subject = "Appointment Reminder: " + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinic;
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
                                        {
                                        }
                                    }
                                }
                            } 
                            if (checkBox4.Checked) // Doctor Email
                            {
                                string emailName = "", emailPass = "";
                                if (dr_email != "")
                                {
                                    DataTable sms = this.cntrl.send_email();
                                    if (sms.Rows.Count > 0)
                                    {
                                        emailName = sms.Rows[0]["emailName"].ToString();
                                        emailPass = sms.Rows[0]["emailPass"].ToString();
                                        try
                                        {
                                            string sr1 = "<table align='center' style='width:700px;border: 1px solid ;border-collapse: collapse; background: #EAEAEA; height:500px'><tr><td  align='left' height='27'><FONT  color='#666666'  face='Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Reminder:" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinic + "</font></td></tr><tr><td  align='left' height='400px'><table  height='423' align='center' style='width:600px; background: #FFFFFF; height:400px'><tr><td  align='left' height='6px'><FONT  color='#000000'  face='Arial' SIZE=6>" + clinic + "</font></td></tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr><tr><td  align='left' height='62' valign='bottom'><FONT  color='#000000'  face='Arial' SIZE=3>Dear <b>" + combodoctor.Text + "</b></font></td></tr> <tr><td align='left' height='197' valign='top'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Just to remind you about your appointment at " + clinic + ".<table><tbody><tr><td width='188' height='31' valign='bottom' align='right'>WHEN :</td><td width='30' height='31' valign='bottom' align='right'></td><td width='358' valign='bottom'> <strong>" + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + "</strong></td>  </tr><tr><td height='31' valign='top'  align='right'>PATIENT :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + txt_p_name.Text + "</td></tr><tr><td height='76' valign='top'  align='right'>FOR :</td><td width='30' height='31' valign='bottom' align='right'></td><td  valign='top'>" + compoprocedure.Text + "</td></tr></tbody></table> For any queries, contact us at : " + contact_no + "</td>  </tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr> <tr><td height='25'  align='right' valign='bottom'>Powered by&nbsp;&nbsp; </td></tr> <tr><td height='81'  align='right' valign='top'><img src='http://pappyjoe.com/assets/images/pappyjoe-logo.PNG' alt='pappyjoe official logo'>&nbsp;&nbsp;</td></tr></table></td></tr></table>";
                                            MailMessage message = new MailMessage();
                                            message.From = new MailAddress(dr_email);
                                            message.To.Add(dr_email);
                                            message.BodyEncoding = System.Text.Encoding.GetEncoding(1252); //bijeesh
                                            message.IsBodyHtml = true; //bijeesh
                                            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                            message.Subject = "Appointment(s) scheduled for Today: " + dpStartTimeDate.Value.ToString("ddd, dd MMM yyyy") + ' ' + cmbStartTime.Text + " @ " + clinic;
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
                                        {

                                        }
                                    }
                                }
                            }// Doctor Email end
                        }
                        else
                        {
                            DateTime StartT;
                            StartT = dpStartTimeDate.Value;
                            StartT = StartT.AddHours(cmbStartTime.SelectedIndex / 12);
                            int md = cmbStartTime.SelectedIndex % 12;
                            StartT = StartT.AddMinutes(md * 5);
                            EditingEvent.Subject = patient_name;
                            EditingEvent.Location = Convert.ToString(cmbStartTime.GetItemText(cmbStartTime.SelectedItem)) + "-" + Convert.ToString(cmbEndTime.GetItemText(cmbEndTime.SelectedItem));
                            EditingEvent.Body = Convert.ToString(gpl_app_id);
                            EditingEvent.Label = Convert.ToInt32(dr_color);
                            if (cmbStartTime.SelectedIndex % 2 > 0)
                            {
                                StartT = StartT.AddMinutes(30);
                            }
                            this.cntrl.update_appointment(Convert.ToDateTime(StartT), diff1, txtDescription.Text,compoprocedure.Text, patient_id, patient_name, dr_id, lab_p_ph.Text, lab_p_email.Text, gpl_app_id);
                        }
                        EditingEvent = null;
                        Main_Calendar.Instance.ContextEvent = null;
                        Main_Calendar.Instance.wndCalendarControl.Populate();
                        Main_Calendar.Instance.wndCalendarControl.RedrawControl();
                        if (Convert.ToDateTime(DateTime.Today.ToString("d")) == dpStartTimeDate.Value)
                        {
                            Main_Calendar.Instance.listAppointment("0");
                        }
                        this.Close();
                        Main_Calendar.Instance.Activate();
                    }
                    else
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Appointment Date should be greater than Current Date...", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (dtpSearch.Rows.Count <= 0)
                {
                    status1 = 1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
        public void ModifyEvent(CalendarEvent ModEvent)
        {
            gpl_app_id = "0";
            gpl_app_id = ModEvent.Body;
            IsNewEvent = false;
            txtSubject.Text = ModEvent.Subject;
            txtLocation.Text = ModEvent.Location;
            chkAllDayEvent.Checked = (ModEvent.AllDayEvent ? true : false);
            cmbLabel.SelectedIndex = ModEvent.Label;
            cmbShowTimeAs.SelectedIndex = (int)ModEvent.BusyStatus;
            chkPrivate.Checked = (ModEvent.PrivateFlag ? true : false);
            chkMeeting.Checked = (ModEvent.MeetingFlag ? true : false);
            if (ModEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceNotRecurring ||
                ModEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceException)
            {
                SetStartEnd(ModEvent.StartTime, ModEvent.EndTime, ModEvent.AllDayEvent);
            }
            EditingEvent = ModEvent;
            panel1.Hide();
            DataTable dt_a = this.cntrl.get_appointment_procedure(ModEvent.Body);
            if (dt_a.Rows.Count > 0)
            {
                patient_id = dt_a.Rows[0][0].ToString();
                app_Doctor_id = dt_a.Rows[0]["dr_id"].ToString();
                txtDescription.Text = dt_a.Rows[0]["note"].ToString();
                compoprocedure.Text = dt_a.Rows[0]["plan_new_procedure"].ToString();
            }
            else
            {
                patient_id = "0";
            }

            txt_p_name.Text = ModEvent.Subject;
            patient_name = ModEvent.Subject;
            DataTable dt_p = this.cntrl.Getpat_MobNamme(patient_id);
            if (dt_p.Rows.Count > 0)
            {
                lab_p_name.Text = dt_p.Rows[0][0].ToString() + "(" + dt_p.Rows[0][1].ToString() + ")";
                lab_p_ph.Text = dt_p.Rows[0][2].ToString();
                lab_p_email.Text = dt_p.Rows[0][3].ToString();
            }
        }
        public void SetStartEnd(DateTime BeginSelection, DateTime EndSelection, Boolean AllDay)
        {
            DateTime StartDate, StartTime, EndDate, EndTime;

            StartDate = BeginSelection.Date;
            StartTime = BeginSelection;

            EndDate = EndSelection.Date;
            EndTime = EndSelection;

            if (AllDay)
            {
                cmbStartTime.Visible = false;
                cmbEndTime.Visible = false;
            }
              
            dpStartTimeDate.Value = StartDate;

            int mis = 0;
            mis = StartTime.Minute / 5;
            cmbStartTime.SelectedIndex = (int)(StartTime.Hour * 12 + mis);
            //UpdateEndTimeCombo();
            dpEndTimeDate.Value = EndDate;
            mis = EndTime.Minute / 5;    
            cmbEndTime.SelectedIndex = (int)(EndTime.Hour * 12 + mis);
            var diff = EndTime.Subtract(StartTime);
            lbl_scheduledtime.Text = dpStartTimeDate.Value.ToString("dd MMM yyyy") + " at " + cmbStartTime.Text + " for " + Convert.ToString(diff.Minutes) + " mins";

        }
        public void Appointment_for_newPAtient(DataTable dtpSearch)
        {
            list_p_details.DataSource = dtpSearch;
            string neworold = "0";
            if (dtpSearch.Rows.Count <= 0)
            {
                if (!String.IsNullOrWhiteSpace(txt_p_name.Text))
                {
                    if (txt_p_mobile.TextLength >= 10)
                    {
                        string patid_ = "";
                        DataTable patidGeneration = this.cntrl.get_patientPrefix();
                        if (patidGeneration.Rows.Count > 0)
                        {
                            patid_ = patidGeneration.Rows[0]["patient_prefix"].ToString() + patidGeneration.Rows[0]["patient_number"].ToString();
                        }
                        else
                        {
                            patid_ = txt_p_id.Text;
                        }
                        if (!PappyjoeMVC.Model.Connection.checkforemail(txt_p_email.Text.ToString()) && txt_p_email.Text != "")
                        {
                            MessageBox.Show("invalid Email address", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_p_email.Focus();
                            txt_p_email.BackColor = Color.Coral;
                        }
                        else
                        {
                            this.cntrl.Save_patient( txt_p_name.Text , patid_ ,"", "", "" ,"", "", "",  txt_p_mobile.Text , "", "",  "","", "", "", "",   "","",DateTime.Now.ToString("yyyy-MM-dd") , combodoctor.Text ,"");
                            DataTable rs_patient = this.cntrl.get_max_patid();
                            patient_name = txt_p_name.Text;
                            patient_id = rs_patient.Rows[0][0].ToString();
                            neworold = "1";
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
                        }
                    }
                    else
                    {
                        label14.Text = " * You must enter a valid mobile number..!!";
                        label14.Visible = true;
                    }
                }
                else
                {
                    label14.Text = "* You must enter a value in the  Patient Name/Mobile field..!!";
                    label14.Visible = true;
                }
            }
        }
        public void CreateNewEvent()
        {
            try
            {
                EditingEvent = PappyjoeMVC.View.Main_Calendar.Instance.wndCalendarControl.DataProvider.CreateEvent();
                IsNewEvent = true;
                DateTime BeginSelection, EndSelection;
                Boolean AllDay;
                BeginSelection = EndSelection = DateTime.Now;
                AllDay = false;
                PappyjoeMVC.View.Main_Calendar.Instance.wndCalendarControl.ActiveView.GetSelection(ref BeginSelection, ref EndSelection, ref AllDay);
                AllDay = false;
                SetStartEnd(BeginSelection, EndSelection, AllDay);
                if (AllDay)
                {
                    PappyjoeMVC.View.Main_Calendar.Instance.ContextEvent = null;
                    this.Close();
                }
                //Bijeesh chkAllDayEvent.Checked = (AllDay ? true : false);
                txtSubject.Text = "New Event";
                cmbShowTimeAs.SelectedIndex = (AllDay ? 0 : 2);
                cmbLabel.SelectedIndex = 0;

                PappyjoeMVC.View.Main_Calendar.Instance.ContextEvent = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AppointmentBooking_Click(object sender, EventArgs e)
        {
            list_p_details.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            EditingEvent = null;
            Main_Calendar.Instance.ContextEvent = null;
            this.Close();
        }
        //protected override void OnLoad(EventArgs e)//not sure it is use
        //{
        //    base.OnLoad(e);

        //    if (EditingEvent != null)
        //    {
        //        if (EditingEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceMaster)
        //        {
        //            pnlTimes.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        pnlTimes.Visible = true;
        //    }

        //    //-----------------------------------------------------------------
        //    cmbReminder.Items.Add(new CalReminderMinutes(0, "0 minutes"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(1, "1 minute"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(5, "5 minutes"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(10, "10 minutes"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(15, "15 minutes"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(30, "30 minutes"));

        //    cmbReminder.Items.Add(new CalReminderMinutes(60, "1 hour"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(120, "2 hour"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(180, "3 hour"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(60 * 12, "12 hour"));

        //    cmbReminder.Items.Add(new CalReminderMinutes(60 * 24, "1 day"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(60 * 24 * 2, "2 days"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(60 * 24 * 3, "3 days"));

        //    cmbReminder.Items.Add(new CalReminderMinutes(60 * 24 * 7, "1 week"));
        //    cmbReminder.Items.Add(new CalReminderMinutes(60 * 24 * 7 * 2, "2 weeks"));

        //    chkReminder.Checked = EditingEvent.Reminder;
        //    chkReminder_CheckedChanged(this, new System.EventArgs());

        //    Boolean bRmdExist = false;
        //    CalReminderMinutes pRmd = null;
        //    for (int i = 0; i < cmbReminder.Items.Count; i++)
        //    {
        //        pRmd = (CalReminderMinutes)cmbReminder.Items[i];

        //        if (pRmd.m_nMinutes == EditingEvent.ReminderMinutesBeforeStart)
        //        {
        //            bRmdExist = true;
        //            break;
        //        }
        //    }

        //    if (!bRmdExist)
        //    {
        //        pRmd = new CalReminderMinutes();
        //        pRmd.m_nMinutes = EditingEvent.ReminderMinutesBeforeStart;
        //        pRmd.m_strMinutes = EditingEvent.ReminderMinutesBeforeStart.ToString() + " minutes";
        //        cmbReminder.Items.Add(pRmd);
        //    }

        //    cmbReminder.SelectedItem = pRmd;
        //}
    }
}
