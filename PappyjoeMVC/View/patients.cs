﻿using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Patients : Form
    {
        public string doctor_id = "";
        Patients_controller cntrl = new Patients_controller(); public int i;
        Add_New_patient_controller contr = new Add_New_patient_controller();
        Common_model mdl = new Common_model();
        Connection db = new Connection();
        Contacts ad = new Contacts();
        public static string id4;
        string id1;
        public string id2 = "", id7;//doctor_id = "0";
        public Image image; bool Inactive_Flag = false, Group_flag = false;
        string gender;// clinical_finding_id = "", docname_id = "0", gender;
        int left_button_click = 0;//, clinical_finding_Rowid = 0;
        public string patient_id { get; set; }
        double weight, height, BMI;
        bool AllPatient_Flag = false, Recently_Visited_Flag = false, RecentalyAdded_flag = false, upcommingAppoinments_Flag = false, Upcomingbirthday_flag = false, CancelledAppoinmnt_Flag = false;

        private void labelappointment_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelappointment.BackColor = Color.DodgerBlue;
                labelappointment.ForeColor = Color.White;
                panel_Search.Visible = false;
                lb_showall.Visible = false;
                lab_Change_AppoinmtName.Visible = true;
                panel_Appmnt.Visible = true;
                var dateFrom = dateTimePickefrom.Value.ToShortDateString();
                var dateTo = dateTimePicketo.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than to date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dateTimePicketo.Value = DateTime.Today;
                    return;
                }
                lab_7.Visible = true;
                panl_FilterPatient.Visible = false;
                lab_Change_AppoinmtName.Text = "APPOINTMENTS";
                left_button_click = 1;
                dateTimePickefrom.Show();
                lab_To.Show();
                dateTimePicketo.Show();
                butt_Go.Show();
                panl_DisplayingPatient.Show();
                panelmain.Controls.Remove(ad);// add after add appoint form  
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 12;
                DGV_Patients.Columns[0].Name = "id";
                DGV_Patients.Columns[0].Width = 0;
                DGV_Patients.Columns[1].Name = "id";
                DGV_Patients.Columns[1].Width = 0;
                DGV_Patients.Columns[2].Name = "edit";
                DGV_Patients.Columns[2].Width = 40;
                DGV_Patients.Columns[3].Name = "del";
                DGV_Patients.Columns[3].Width = 40;
                DGV_Patients.Columns[4].Name = "Name";
                DGV_Patients.Columns[4].Width = 200;
                DGV_Patients.Columns[5].Name = "payment";
                DGV_Patients.Columns[5].Width = 125;
                DGV_Patients.Columns[6].Name = "sum";
                DGV_Patients.Columns[6].Width = 125;
                DGV_Patients.Columns[7].Name = "sum";
                DGV_Patients.Columns[7].Width = 75;
                DGV_Patients.Columns[8].Name = "sum";
                DGV_Patients.Columns[8].Width = 75;
                DGV_Patients.Columns[9].Name = "sum";
                DGV_Patients.Columns[9].Width = 75;
                DGV_Patients.Columns[10].Name = "sum";
                DGV_Patients.Columns[10].Width = 75;
                DGV_Patients.Columns[11].Name = "sum";
                DGV_Patients.Columns[11].Width = 75;
                DGV_Patients.Columns[0].Visible = false;
                DGV_Patients.Columns[1].Visible = false;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd") + " 00:01");
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd") + " 23:59");
                DataTable dt_pt5 = new DataTable();
                DataTable dtb = this.cntrl.Get_appointment_data(startDateTime, startDateTime1);
                Appointment_Data(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Appointment_Data(DataTable dt_pt5)
        {
            if (dt_pt5.Rows.Count > 0)
            {
                DataGridViewImageColumn img5 = new DataGridViewImageColumn();
                DGV_Patients.Columns.Add(img5);
                lab_LongMsg.Hide();
                lab_LongMsg.Location = new Point(350, 350);
                lab_7.Location = new Point(73, 7);
                lab_Displaying.Visible = true;
                lab_7.Text = dt_pt5.Rows.Count.ToString() + " Patient(s)";
                for (int j = 0; j < dt_pt5.Rows.Count; j++)
                {
                    DateTime time = Convert.ToDateTime(dt_pt5.Rows[j]["start_datetime"].ToString());
                    string timestring = time.ToString("MM/dd/yyyy HH:mm");
                    DGV_Patients.Rows.Add(dt_pt5.Rows[j]["id"].ToString(), dt_pt5.Rows[j]["a_id"].ToString(), "", "", dt_pt5.Rows[j]["pt_name"].ToString() + "\r\n" + "Patient Id  : " + dt_pt5.Rows[j]["pt_id"].ToString() + "\r\n" + "Mobile No:  " + dt_pt5.Rows[j]["primary_mobile_number"].ToString(), "DOCTOR" + "\r\n" + dt_pt5.Rows[j]["doctor_name"].ToString(), "APPOINTMENT " + "\r\n............................\r\n" + timestring,//Convert.ToDateTime(dt_pt5.Rows[j]["start_datetime"].ToString()).ToShortTimeString(),
                        "STATUS " + "\r\n....................\r\n" + dt_pt5.Rows[j]["status"].ToString(), "SCHEDULE " + "\r\n....................\r\n" + dt_pt5.Rows[j]["schedule"].ToString(), "WAITING  " + "\r\n....................\r\n" + dt_pt5.Rows[j]["waiting"].ToString(),
                        "ENGAGED " + "\r\n....................\r\n" + dt_pt5.Rows[j]["engaged"].ToString(), "CHECK OUT " + "\r\n....................\r\n" + dt_pt5.Rows[j]["checkout"].ToString(), "");
                    DGV_Patients.Rows[j].Height = 70;
                    timestring = null;
                    try
                    {
                        string pt_id = dt_pt5.Rows[j]["id"].ToString();
                        img5.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        try
                        {
                            string curFile = db.server() + "\\Pappyjoe_utilities\\patient_image\\" + pt_id;
                            if (System.IO.File.Exists(curFile))
                            {
                                DGV_Patients.Rows[j].Cells[12].Value = Image.FromFile(curFile);
                            }
                            else
                            {
                                DGV_Patients.Rows[j].Cells[12].Value = PappyjoeMVC.Properties.Resources.nophoto;
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    DGV_Patients.Rows[j].Cells[2].Style.ForeColor = Color.FromArgb(34, 139, 34);
                    DGV_Patients.Rows[j].Cells[2].Value = "Edit";
                    DGV_Patients.Rows[j].Cells[3].Style.ForeColor = Color.FromArgb(255, 69, 0);
                    DGV_Patients.Rows[j].Cells[3].Value = "Delete";
                }
            }
            else
            {
                lab_LongMsg.Show();
                lab_LongMsg.Location = new Point(91, 177);
                lab_7.Location = new Point(4, 5);
                lab_7.Text = " 0 Patient(s)";
                lab_Displaying.Visible = false;
            }
        }
        public void b_normal()
        {
            labelprofile.ForeColor = Color.DimGray;
            labelprofile.BackColor = Color.White;
            labelappointment.ForeColor = Color.DimGray;
            labelappointment.BackColor = Color.White;
            labelclinical.BackColor = Color.White;
            labelclinical.ForeColor = Color.DimGray;
            labeltreatment.BackColor = Color.White;
            labeltreatment.ForeColor = Color.DimGray;
            labelfinished.BackColor = Color.White;
            labelfinished.ForeColor = Color.DimGray;
            labelprescription.BackColor = Color.White;
            labelprescription.ForeColor = Color.DimGray;
            labelpayment.BackColor = Color.White;
            labelpayment.ForeColor = Color.DimGray;
            labelinvoice.BackColor = Color.White;
            labelinvoice.ForeColor = Color.DimGray;
            LabVitalSign.BackColor = Color.White;
            LabVitalSign.ForeColor = Color.DimGray;
            labelremaindersms.BackColor = Color.White;
            labelremaindersms.ForeColor = Color.DimGray;
            labellog.BackColor = Color.White;
            labellog.ForeColor = Color.DimGray;
        }

        private void butt_Go_Click(object sender, EventArgs e)
        {
            if (left_button_click == 1)
            {
                labelappointment_Click(null, null);
            }
            else if (left_button_click == 2)
            {
                labelclinical_Click(null, null);
            }
            else if (left_button_click == 3)
            {
                labeltreatment_Click_1(null, null);
            }
            else if (left_button_click == 4)
            {
                labelfinished_Click(null, null);
            }
            else if (left_button_click == 5)
            {
                labelprescription_Click(null, null);
            }
            else if (left_button_click == 6)
            {
                labelinvoice_Click(null, null);
            }
            else if (left_button_click == 7)
            {
                labelpayment_Click(null, null);
            }
            else if (left_button_click == 9)
            {
                LabVitalSign_Click(null, null);
            }
        }

        private void LabVitalSign_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                LabVitalSign.BackColor = Color.DodgerBlue;
                LabVitalSign.ForeColor = Color.White;
                lb_showall.Visible = false;
                lab_Change_AppoinmtName.Text = "VITAL SIGNS";
                left_button_click = 9;
                panl_DisplayingPatient.Visible = true;
                check_visiblecontrolls();
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 4;
                DGV_Patients.Columns[0].Name = "id";
                DGV_Patients.Columns[0].Width = 0;
                DGV_Patients.Columns[1].Name = "title";
                DGV_Patients.Columns[1].Width = 550;
                DGV_Patients.Columns[2].Name = "line";
                DGV_Patients.Columns[2].Width = 1;
                DGV_Patients.Columns[3].Name = "content";
                DGV_Patients.Columns[3].Width = 550;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                System.Data.DataTable dt_cf_main = new DataTable();
                DataTable dtb = this.cntrl.Get_vitalSigns(startDateTime, startDateTime1);
                VitalSigns(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void VitalSigns(DataTable dt_cf_main)
        {
            try
            {
                DataGridViewImageColumn img5 = new DataGridViewImageColumn();
                DGV_Patients.Columns.Add(img5);
                DGV_Patients.Columns[4].Width = 20;
                DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[4].Visible = false;
                DGV_Patients.Columns[0].Visible = false;
                int i = 0;
                if (dt_cf_main.Rows.Count > 0)
                {
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dt_cf_main.Rows.Count.ToString() + " Patient(s)";
                    lab_LongMsg.Hide();
                    for (int j = 0; j < dt_cf_main.Rows.Count; j++)
                    {
                        int rowcout = DGV_Patients.Rows.Count;
                        DGV_Patients.Rows.Add(dt_cf_main.Rows[j]["pt_id"].ToString(), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_cf_main.Rows[j]["date"].ToString())), "", "", "");
                        DGV_Patients.Rows[i].Height = 35;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;//DarkGray
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.Gainsboro;
                        DataTable rs_patients = this.cntrl.Patient_details(dt_cf_main.Rows[j]["pt_id"].ToString());
                        gender = "";
                        if (rs_patients.Rows.Count > 0)
                        {
                            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[3].Value = "PATIENT NAME :  " + rs_patients.Rows[0]["pt_name"].ToString();
                                DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                            }
                            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[3].Value = DGV_Patients.Rows[i].Cells[3].Value + "\r\nPATIENT ID :  " + rs_patients.Rows[0]["pt_id"].ToString();
                                DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                            }
                            if (rs_patients.Rows[0]["gender"].ToString() != "")
                            {
                                gender = rs_patients.Rows[0]["gender"].ToString();
                            }
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Pulse", "", dt_cf_main.Rows[j]["pulse"].ToString(), "");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Temperature", "", dt_cf_main.Rows[j]["temp"].ToString(), "(" + dt_cf_main.Rows[j]["temp_type"].ToString() + ")");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Blood Pressure (Systolic)", "", dt_cf_main.Rows[j]["bp_syst"].ToString() + "(" + dt_cf_main.Rows[j]["bp_type"].ToString() + ")", "");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Blood Pressure (Diastolic)", "", dt_cf_main.Rows[j]["bp_dia"].ToString() + "(" + dt_cf_main.Rows[j]["bp_type"].ToString() + ")", "");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Height", "", dt_cf_main.Rows[j]["Height"].ToString() + "(Cm)", "");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Weight", "", dt_cf_main.Rows[j]["weight"].ToString() + "(Kg)", "");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Respiratory Rate", "", dt_cf_main.Rows[j]["resp"].ToString(), "");
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        /////////////
                        if (dt_cf_main.Rows[j]["weight"].ToString() != null && dt_cf_main.Rows[j]["weight"].ToString() != "" && dt_cf_main.Rows[j]["Height"].ToString() != null && dt_cf_main.Rows[j]["Height"].ToString() != "")
                        {
                            weight = Convert.ToDouble(dt_cf_main.Rows[j]["weight"].ToString());
                            height = Convert.ToDouble(dt_cf_main.Rows[j]["Height"].ToString());
                        }
                        else
                        {
                            weight = Convert.ToDouble("0.00");
                            height = Convert.ToDouble("0.00");
                        }

                        string msg = "";
                        if (weight > 0 && height > 0)
                        {
                            BMI = Math.Round((weight / (height * height)) * 10000, 1);
                            if (BMI != null)
                            {
                                if (BMI < 19 && gender == "Female")
                                {
                                    msg = "Underweight";
                                }
                                if (BMI >= 19 & BMI <= 24 & gender == "Female")
                                {
                                    msg = "Normal";
                                }
                                if (BMI > 24 & gender == "Female")
                                {
                                    msg = "Overweight";
                                }
                                if (BMI < 20 & gender == "Male")
                                {
                                    msg = "Underweight";
                                }
                                if (BMI >= 20 & BMI <= 25 & gender == "Male")
                                {
                                    msg = "Normal";
                                }
                                if (BMI > 25 & gender == "Male")
                                {
                                    msg = "Overweight";
                                }
                            }
                            if (BMI > 0)
                            {
                                DGV_Patients.Rows.Add("0", "BMI (Body Mass Index) ", "", BMI + "," + msg, "", "");

                                if (msg == "Underweight")
                                    DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                                else if (msg == "Normal")
                                    DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                                else if (msg == "Overweight")
                                    DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                                i = i + 1;
                            }
                            ///////////
                            DGV_Patients.Rows.Add("0", "Recorded By : " + dt_cf_main.Rows[j]["dr_name"].ToString() + "", "", "", "");
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                            DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "", "", "", "", "");
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            i = i + 1;
                        }
                    }
                }
                else
                {
                    lab_LongMsg.Visible = true;
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " 0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void check_visiblecontrolls()
        {
            panl_FilterPatient.Visible = false;
            printlabel.Visible = false;
            addnewpatient.Visible = false;
            panel_Search.Visible = false;
            txt_Search.Visible = false;
            panel_Appmnt.Visible = true;
            lab_Displaying.Visible = true;
            dateTimePickefrom.Show();
            lab_To.Show();
            dateTimePicketo.Show();
            lab_7.Visible = true;
            lab_Change_AppoinmtName.Visible = true;
            panl_DisplayingPatient.Show();
            lab_7.Text = "";
            butt_Go.Show();
            dateTimePickefrom.MaxDate = DateTime.Now;
            dateTimePicketo.MinDate = DateTime.Now;
            panelmain.Controls.Remove(ad);
        }

        private void labelclinical_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelclinical.BackColor = Color.DodgerBlue;
                labelclinical.ForeColor = Color.White;
                lb_showall.Visible = false;
                lab_Change_AppoinmtName.Text = "CLINICAL FINDINGS";
                left_button_click = 2;
                panl_DisplayingPatient.Visible = true;
                check_visiblecontrolls();
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 4;
                DGV_Patients.Columns[0].Name = "id";
                DGV_Patients.Columns[0].Width = 0;
                DGV_Patients.Columns[1].Name = "title";
                DGV_Patients.Columns[1].Width = 350;
                DGV_Patients.Columns[2].Name = "line";
                DGV_Patients.Columns[2].Width = 1;
                DGV_Patients.Columns[3].Name = "content";
                DGV_Patients.Columns[3].Width = 750;
                DataGridViewImageColumn img5 = new DataGridViewImageColumn();
                DGV_Patients.Columns.Add(img5);
                DGV_Patients.Columns[4].Width = 20;
                DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[4].Visible = false;
                DGV_Patients.Columns[0].Visible = false;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                DataTable dtb = this.cntrl.clinic_findings(startDateTime, startDateTime1);
                ClinicFindings(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ClinicFindings(DataTable dt_cf_main)
        {
            try
            {
                int i = 0;
                if (dt_cf_main.Rows.Count > 0)
                {
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dt_cf_main.Rows.Count.ToString() + " Patient(s)";
                    lab_LongMsg.Hide();
                    lab_LongMsg.Location = new Point(350, 350);
                    for (int j = 0; j < dt_cf_main.Rows.Count; j++)
                    {
                        DGV_Patients.Rows.Add(dt_cf_main.Rows[j]["pt_id"].ToString(), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_cf_main.Rows[j]["date"].ToString())), "", "", "");
                        DGV_Patients.Rows[i].Height = 35;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.Gainsboro;
                        System.Data.DataTable rs_patients = this.cntrl.Patient_details(dt_cf_main.Rows[j]["pt_id"].ToString());
                        if (rs_patients.Rows.Count > 0)
                        {
                            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[3].Value = "PATIENT NAME :  " + rs_patients.Rows[0]["pt_name"].ToString();
                            }
                            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[3].Value = DGV_Patients.Rows[i].Cells[3].Value + "\r\nPATIENT ID :  " + rs_patients.Rows[0]["pt_id"].ToString();
                            }
                        }
                        System.Data.DataTable dt_cf_Complaints = this.cntrl.complaints(dt_cf_main.Rows[j]["id"].ToString());
                        if (dt_cf_Complaints.Rows.Count > 0)
                        {
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "Complaints", "", dt_cf_Complaints.Rows[0]["complaint_id"].ToString(), "");
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            for (int k = 1; k < dt_cf_Complaints.Rows.Count; k++)
                            {
                                i = i + 1;
                                DGV_Patients.Rows.Add("0", "", "", dt_cf_Complaints.Rows[k]["complaint_id"].ToString(), "");
                                DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Height = 20;
                            }
                        }
                        System.Data.DataTable dt_cf_observe = this.cntrl.observation(dt_cf_main.Rows[j]["id"].ToString());
                        if (dt_cf_observe.Rows.Count > 0)
                        {
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "", "", "", "");
                            DGV_Patients.Rows[i].Height = 1;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "Observation", "", dt_cf_observe.Rows[0]["observation_id"].ToString(), "");
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            for (int k = 1; k < dt_cf_observe.Rows.Count; k++)
                            {
                                i = i + 1;
                                DGV_Patients.Rows.Add("0", "", "", dt_cf_observe.Rows[k]["observation_id"].ToString(), "");
                                DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Height = 20;
                            }
                        }
                        System.Data.DataTable dt_cf_investigation = this.cntrl.investgation(dt_cf_main.Rows[j]["id"].ToString());
                        if (dt_cf_investigation.Rows.Count > 0)
                        {
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "", "", "", "");
                            DGV_Patients.Rows[i].Height = 1;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "Investigation", "", dt_cf_investigation.Rows[0]["investigation_id"].ToString(), "");
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            for (int k = 1; k < dt_cf_investigation.Rows.Count; k++)
                            {
                                i = i + 1;
                                DGV_Patients.Rows.Add("0", "", "", dt_cf_investigation.Rows[k]["investigation_id"].ToString(), "");
                                DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Height = 20;
                            }
                        }
                        System.Data.DataTable dt_cf_diagnosis = this.cntrl.diagnosis(dt_cf_main.Rows[j]["id"].ToString());
                        if (dt_cf_diagnosis.Rows.Count > 0)
                        {
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "", "", "", "");
                            DGV_Patients.Rows[i].Height = 1;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "Diagnosis", "", dt_cf_diagnosis.Rows[0]["diagnosis_id"].ToString(), "");
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            for (int k = 1; k < dt_cf_diagnosis.Rows.Count; k++)
                            {
                                i = i + 1;
                                DGV_Patients.Rows.Add("0", "", "", dt_cf_diagnosis.Rows[k]["diagnosis_id"].ToString(), "");
                                DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Height = 20;
                            }
                        }
                        System.Data.DataTable dt_cf_note = this.cntrl.notes(dt_cf_main.Rows[j]["id"].ToString());
                        if (dt_cf_note.Rows.Count > 0)
                        {
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "", "", "", "");
                            DGV_Patients.Rows[i].Height = 1;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            DGV_Patients.Rows.Add("0", "Note", "", dt_cf_note.Rows[0]["note_name"].ToString(), "");
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                            for (int k = 1; k < dt_cf_note.Rows.Count; k++)
                            {
                                i = i + 1;
                                DGV_Patients.Rows.Add("0", "", "", dt_cf_note.Rows[k]["note_name"].ToString(), "");
                                DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Height = 20;
                            }
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Note by ", "", dt_cf_main.Rows[j]["doctor_name"].ToString(), "");
                        DGV_Patients.Rows[i].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.Red;
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "", "", "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Value = PappyjoeMVC.Properties.Resources.blank;
                        i = i + 1;
                    }
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " 0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void labelclinical_MouseEnter(object sender, EventArgs e)
        {
            if (labelclinical.BackColor != Color.DodgerBlue)
            {
                labelclinical.ForeColor = Color.DarkGreen;
            }
        }

        private void labelclinical_MouseLeave(object sender, EventArgs e)
        {
            if (labelclinical.BackColor != Color.DodgerBlue)
            {
                labelclinical.ForeColor = Color.DimGray;
            }
        }

        private void labeltreatment_Click_1(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labeltreatment.BackColor = Color.DodgerBlue;
                labeltreatment.ForeColor = Color.White;
                left_button_click = 3;
                lb_showall.Visible = false;
                panl_DisplayingPatient.Visible = true;
                lab_Change_AppoinmtName.Text = "TREATMENT PLANS";
                check_visiblecontrolls();
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 6;
                DGV_Patients.Columns[0].Name = "pid";
                DGV_Patients.Columns[0].Width = 0;
                DGV_Patients.Columns[1].Name = "Procedure";
                DGV_Patients.Columns[1].Width = 260;
                DGV_Patients.Columns[2].Name = "Cost";
                DGV_Patients.Columns[2].Width = 280;
                DGV_Patients.Columns[3].Name = "Discount";
                DGV_Patients.Columns[3].Width = 160;
                DGV_Patients.Columns[4].Name = "Total";
                DGV_Patients.Columns[4].Width = 160;
                DGV_Patients.Columns[5].Name = "Note";
                DGV_Patients.Columns[5].Width = 200;
                DGV_Patients.Columns[0].Visible = false;
                DGV_Patients.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Patients.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                DataTable dtb = this.cntrl.treatmentPlan(startDateTime, startDateTime1);
                TreatmentPlan(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void TreatmentPlan(DataTable dt_pt_main)
        {
            try
            {
                int i = 0;
                if (dt_pt_main.Rows.Count > 0)
                {
                    lab_LongMsg.Hide();
                    lab_LongMsg.Location = new Point(350, 350);
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dt_pt_main.Rows.Count.ToString() + " Patient(s)";
                    for (int j = 0; j < dt_pt_main.Rows.Count; j++)
                    {
                        DGV_Patients.Rows.Add(dt_pt_main.Rows[j]["pt_id"].ToString(), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pt_main.Rows[j]["date"].ToString())), "", "", "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Height = 35;
                        DataTable rs_patients = this.cntrl.Patient_details(dt_pt_main.Rows[j]["pt_id"].ToString());
                        if (rs_patients.Rows.Count > 0)
                        {
                            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[2].Value = "PATIENT NAME :  " + rs_patients.Rows[0]["pt_name"].ToString();
                            }
                            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[2].Value = DGV_Patients.Rows[i].Cells[2].Value + "\r\nPATIENT ID :  " + rs_patients.Rows[0]["pt_id"].ToString();
                            }
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "PROCEDURE", "COST", "DISCOUNT", "TOTAL", "NOTE");
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[4].Style.ForeColor = Color.White;
                        DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        DGV_Patients.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        DGV_Patients.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.DarkGray;
                        System.Data.DataTable dt_pt_sub = this.cntrl.treatements_items(dt_pt_main.Rows[j]["id"].ToString());
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
                            DGV_Patients.Rows.Add("0", dt_pt_sub.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discount_inrs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), dt_pt_sub.Rows[k]["note"].ToString() + " " + dt_pt_sub.Rows[k]["tooth"].ToString());
                            DGV_Patients.Rows[i].Height = 25;
                            totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Planned by " + dt_pt_main.Rows[j]["dr_name"].ToString(), "", "Estimated amount:", String.Format("{0:C}", Convert.ToDecimal(totalEst)), "");
                        DGV_Patients.Rows[i].Cells[4].Style.ForeColor = Color.Red;
                        DGV_Patients.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "", "", "", "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                        i = i + 1;
                    }
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " 0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labelfinished_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelfinished.BackColor = Color.DodgerBlue;
                labelfinished.ForeColor = Color.White;
                left_button_click = 4;
                lb_showall.Visible = false;
                lab_Change_AppoinmtName.Text = "FINISHED TREATMENTS";
                check_visiblecontrolls();
                panl_DisplayingPatient.Visible = true;
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 6;
                DGV_Patients.Columns[0].Name = "pid";
                DGV_Patients.Columns[0].Width = 0;
                DGV_Patients.Columns[1].Name = "Procedure";
                DGV_Patients.Columns[1].Width = 260;
                DGV_Patients.Columns[2].Name = "Cost";
                DGV_Patients.Columns[2].Width = 280;
                DGV_Patients.Columns[3].Name = "Discount";
                DGV_Patients.Columns[3].Width = 160;
                DGV_Patients.Columns[4].Name = "Total";
                DGV_Patients.Columns[4].Width = 160;
                DGV_Patients.Columns[5].Name = "Note";
                DGV_Patients.Columns[5].Width = 200;
                DGV_Patients.Columns[0].Visible = false;
                DGV_Patients.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                DataTable dtb = this.cntrl.finishedprocedure(startDateTime, startDateTime1);
                FinishedProcedure(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void FinishedProcedure(DataTable dt_pt_main)
        {
            try
            {
                int i = 0;
                if (dt_pt_main.Rows.Count > 0)
                {
                    lab_LongMsg.Hide();
                    lab_LongMsg.Location = new Point(350, 350);
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dt_pt_main.Rows.Count.ToString() + " Patient(s)";
                    for (int j = 0; j < dt_pt_main.Rows.Count; j++)
                    {
                        DGV_Patients.Rows.Add(dt_pt_main.Rows[j]["patient_id"].ToString(), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pt_main.Rows[j]["completed_date"].ToString())), "", "", "", "", "0");
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Height = 35;
                        System.Data.DataTable rs_patients = this.cntrl.Patient_details(dt_pt_main.Rows[j]["patient_id"].ToString());
                        if (rs_patients.Rows.Count > 0)
                        {
                            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                            { DGV_Patients.Rows[i].Cells[2].Value = "PATIENT NAME :  " + rs_patients.Rows[0]["pt_name"].ToString(); }
                            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[2].Value = DGV_Patients.Rows[i].Cells[2].Value + "\r\nPATIENT ID :  " + rs_patients.Rows[0]["pt_id"].ToString();
                            }
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "PROCEDURE", "COST", "DISCOUNT", "TOTAL", "NOTE");
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[4].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.DarkGray;
                        System.Data.DataTable dt_pt_sub = this.cntrl.finished_sub(dt_pt_main.Rows[j]["id"].ToString());
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
                            DGV_Patients.Rows.Add("0", dt_pt_sub.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discount_inrs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), dt_pt_sub.Rows[k]["note"].ToString() + " " + dt_pt_sub.Rows[k]["tooth"].ToString() + "(Finished by- Dr." + dt_pt_sub.Rows[k]["doctor_name"].ToString() + ")");
                            DGV_Patients.Rows[i].Height = 30;
                            DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                            totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "", "", "", "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                        i = i + 1;
                    }
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " 0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labelprescription_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelprescription.BackColor = Color.DodgerBlue;
                labelprescription.ForeColor = Color.White;
                lb_showall.Visible = false;
                lab_Change_AppoinmtName.Text = "PRESCRIPTIONS";
                left_button_click = 5;
                ClearAll_grid2_Properties();
                check_visiblecontrolls();
                panl_DisplayingPatient.Visible = true;
                DGV_Patients.ColumnCount = 5;
                DGV_Patients.Columns[0].Name = "id";
                DGV_Patients.Columns[0].Width = 0;
                DGV_Patients.Columns[0].Visible = false;
                DGV_Patients.Columns[1].Name = "Drug";
                DGV_Patients.Columns[1].Width = 220;
                DGV_Patients.Columns[2].Name = "Frequency";
                DGV_Patients.Columns[2].Width = 250;
                DGV_Patients.Columns[3].Name = "Duration";
                DGV_Patients.Columns[3].Width = 200;
                DGV_Patients.Columns[4].Name = "Instruction";
                DGV_Patients.Columns[4].Width = 400;
                DGV_Patients.ColumnHeadersVisible = false;
                DGV_Patients.RowHeadersVisible = false;
                DGV_Patients.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                System.Data.DataTable dt_pre_main = new DataTable();
                DataTable dtb = this.cntrl.Prescription(startDateTime, startDateTime1);
                Prescription(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labelinvoice_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelinvoice.BackColor = Color.DodgerBlue;
                labelinvoice.ForeColor = Color.White;
                lb_showall.Visible = false;
                lab_Change_AppoinmtName.Text = "INVOICE/BILL";
                left_button_click = 6;
                check_visiblecontrolls();
                panl_DisplayingPatient.Visible = true;
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 10;
                DGV_Patients.Columns[0].Width = 100;
                DGV_Patients.Columns[1].Width = 30;
                DGV_Patients.Columns[2].Width = 280;
                DGV_Patients.Columns[3].Width = 200;
                DGV_Patients.Columns[4].Width = 100;
                DGV_Patients.Columns[5].Width = 100;
                DGV_Patients.Columns[6].Width = 100;
                DGV_Patients.Columns[7].Width = 100;
                DGV_Patients.Columns[8].Width = 100;
                DGV_Patients.Columns[9].Width = 100;
                DGV_Patients.Columns[0].Visible = false;
                DGV_Patients.Columns[1].Visible = false;
                DGV_Patients.Columns[8].Visible = false;
                DGV_Patients.Columns[9].Visible = false;
                DGV_Patients.ColumnHeadersVisible = false;
                DGV_Patients.RowHeadersVisible = false;
                DGV_Patients.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                DataTable dtb = this.cntrl.invoice(startDateTime, startDateTime1);
                Invoice(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Invoice(DataTable dt_invoice_main)
        {
            try
            {
                int i = 0;
                if (dt_invoice_main.Rows.Count > 0)
                {
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dt_invoice_main.Rows.Count.ToString() + " Patient(s)";
                    lab_LongMsg.Hide(); string patientName = "", Pt_id = "";
                    lab_LongMsg.Location = new Point(350, 350);
                    for (int j = 0; j < dt_invoice_main.Rows.Count; j++)
                    {
                        DataTable pat = this.cntrl.Patient_details(dt_invoice_main.Rows[j]["pt_id"].ToString());
                        if (pat.Rows.Count > 0)
                        {
                            patientName = pat.Rows[0][0].ToString();
                            Pt_id = pat.Rows[0][1].ToString();
                        }
                        DGV_Patients.Rows.Add("0", "", String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_invoice_main.Rows[j]["date"].ToString())), " Patient Name :" + patientName + "\n Patient Id : " + Pt_id, "", "", "", "", "", "");//dt_invoice_main.Rows[j]["pt_id"].ToString()
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Height = 35;
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                        i = i + 1;
                        DGV_Patients.Rows.Add(dt_invoice_main.Rows[j]["pt_id"].ToString(), "", "INVOICE NUMBER", "TREATMENT & PRODUCTS", "COST", "DISCOUNT", "TAX", "TOTAL", dt_invoice_main.Rows[j]["status"].ToString(), "");
                        DGV_Patients.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.gry;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[4].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[5].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[6].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[6].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[7].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[7].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[8].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[8].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.DarkGray;
                        System.Data.DataTable dt_pt_sub = this.cntrl.invoice_sub(dt_invoice_main.Rows[j]["id"].ToString());
                        Double totalEst = 0;
                        int row_no = 0;
                        for (int k = 0; k < dt_pt_sub.Rows.Count; k++)
                        {
                            string discount_string = "";
                            string Dr_name = "";
                            string dt_dr = mdl.Get_DoctorName(dt_pt_sub.Rows[k]["dr_id"].ToString());
                            if (dt_dr != "")
                            {
                                Dr_name = dt_dr;
                            }
                            if (dt_pt_sub.Rows[k]["discount_type"].ToString() == "INR")
                            {
                                discount_string = "";
                            }
                            else
                            {
                                discount_string = "(" + dt_pt_sub.Rows[k]["discount"].ToString() + "%)";
                            }
                            Decimal totalcost = Convert.ToDecimal(dt_pt_sub.Rows[k]["cost"].ToString()) * Convert.ToDecimal(dt_pt_sub.Rows[k]["unit"].ToString());
                            if (k == 0 || k > 2)
                            {
                                i = i + 1;
                                if (k == 0)
                                {
                                    DGV_Patients.Rows.Add(dt_pt_sub.Rows[k]["id"].ToString(), "", dt_invoice_main.Rows[j]["invoice"].ToString(), dt_pt_sub.Rows[k]["services"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString())), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), "");
                                    DGV_Patients.Rows[i].Height = 30;
                                    DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                    DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DodgerBlue;
                                    DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                    DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DodgerBlue;
                                }
                                else
                                {
                                    DGV_Patients.Rows.Add(dt_pt_sub.Rows[k]["id"].ToString(), "", "", dt_pt_sub.Rows[k]["services"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString())), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), "");
                                    DGV_Patients.Rows[i].Height = 30;
                                    DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                    DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DodgerBlue;
                                    DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                    DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DodgerBlue;
                                    i = i + 1;
                                    DGV_Patients.Rows.Add("0", "", "", "Completed by " + Dr_name, "", "", "", "", "", "");
                                    DGV_Patients.Rows[i].Height = 15;
                                    DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.Red;

                                    DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                                    DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                                    DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                                }
                            }
                            if (k == 0)
                            {
                                i = i + 1;
                                DGV_Patients.Rows.Add("0", "", "Balance", "Completed by " + Dr_name, "", "", "", "", "", "");
                                DGV_Patients.Rows[i].Height = 20;
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                                i = i + 1;
                                row_no = i;
                                // DGV_Patients.Rows.Add("0", "", "5000.50", "", "", "", "", "", "", "");
                                DGV_Patients.Rows.Add("0", "", "00.00", "", "", "", "", "", "", "");
                                DGV_Patients.Rows[i].Height = 20;
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                                DGV_Patients.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                                DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                                i = i + 1;
                                //DGV_Patients.Rows.Add("0", "", "Total Paid", "", "", "", "", "", "", "");
                                DGV_Patients.Rows.Add("0", "", "", "", "", "", "", "", "", "");
                                DGV_Patients.Rows[i].Height = 20;
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                                i = i + 1;
                                //  DGV_Patients.Rows.Add("0", "", "1000.50", "", "", "", "", "", "", "");
                                DGV_Patients.Rows.Add("0", "", "", "", "", "", "", "", "", "");
                                DGV_Patients.Rows[i].Height = 15;
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                                DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                            }
                            if (k == 1)
                            {
                                DGV_Patients.Rows[i - 3].Cells[0].Value = dt_pt_sub.Rows[k]["id"].ToString();
                                DGV_Patients.Rows[i - 3].Cells[3].Value = dt_pt_sub.Rows[k]["services"].ToString();
                                DGV_Patients.Rows[i - 3].Cells[4].Value = String.Format("{0:C}", Convert.ToDecimal(totalcost));
                                DGV_Patients.Rows[i - 3].Cells[5].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string;
                                DGV_Patients.Rows[i - 3].Cells[6].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString()));
                                DGV_Patients.Rows[i - 3].Cells[7].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString()));
                                DGV_Patients.Rows[i - 3].Cells[8].Value = "";
                                DGV_Patients.Rows[i - 3].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                DGV_Patients.Rows[i - 3].Cells[3].Style.ForeColor = Color.DodgerBlue;
                                DGV_Patients.Rows[i - 2].Cells[3].Value = "Completed by " + Dr_name;
                            }
                            else if (k == 2)
                            {
                                DGV_Patients.Rows[i - 1].Cells[0].Value = dt_pt_sub.Rows[k]["id"].ToString();
                                DGV_Patients.Rows[i - 1].Cells[3].Value = dt_pt_sub.Rows[k]["services"].ToString();
                                DGV_Patients.Rows[i - 1].Cells[4].Value = String.Format("{0:C}", Convert.ToDecimal(totalcost));
                                DGV_Patients.Rows[i - 1].Cells[5].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string;
                                DGV_Patients.Rows[i - 1].Cells[6].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString()));
                                DGV_Patients.Rows[i - 1].Cells[7].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString()));
                                DGV_Patients.Rows[i - 1].Cells[8].Value = "";
                                DGV_Patients.Rows[i - 1].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                DGV_Patients.Rows[i - 1].Cells[3].Style.ForeColor = Color.DodgerBlue;
                                DGV_Patients.Rows[i].Cells[3].Value = "Completed by " + Dr_name;
                            }
                            totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "", "", "", "", "", "", "", "", "");
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[5].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[6].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[7].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[8].Style.BackColor = Color.WhiteSmoke;
                        i = i + 1;
                        Double gtotal = 0;
                        gtotal = totalEst;
                        DGV_Patients.Rows[row_no].Cells[2].Value = gtotal.ToString("F");
                        DGV_Patients.Rows[row_no + 3].Cells[2].Value = totalEst.ToString("F") + "        ";
                    }
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Visible = true;
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " 0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void labelpayment_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelpayment.BackColor = Color.DodgerBlue;
                labelpayment.ForeColor = Color.White;
                left_button_click = 7;
                lb_showall.Visible = false;
                check_visiblecontrolls();
                lab_7.Visible = false;
                panl_DisplayingPatient.Visible = true;
                lab_Displaying.Visible = false;
                lab_Change_AppoinmtName.Text = "RECEIPT";
                panelmain.Controls.Remove(ad);
                ClearAll_grid2_Properties();
                DGV_Patients.ColumnCount = 4;
                DGV_Patients.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Patients.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Patients.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Patients.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Patients.Columns[0].Width = 150;
                DGV_Patients.Columns[1].Width = 150;
                DGV_Patients.Columns[2].Width = 300;
                DGV_Patients.Columns[3].Width = 295;
                DateTime startDateTime = Convert.ToDateTime(dateTimePickefrom.Value.ToString("yyyy-MM-dd"));
                DateTime startDateTime1 = Convert.ToDateTime(dateTimePicketo.Value.ToString("yyyy-MM-dd"));
                DataTable dtb = this.cntrl.Payment(startDateTime, startDateTime1);
                Payments(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Payments(DataTable Payment)
        {
            try
            {
                int j = 0;
                string patientName = ""; string patientId = "";
                lab_LongMsg.Hide();
                for (int i = 0; i < Payment.Rows.Count; i++)
                {
                    DataTable pat = this.cntrl.Patient_details(Payment.Rows[i]["pt_id"].ToString());
                    if (pat.Rows.Count > 0)
                    {
                        patientName = pat.Rows[0][0].ToString();
                        patientId = pat.Rows[0][1].ToString();
                    }
                    DGV_Patients.Rows.Add(String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(Payment.Rows[i]["payment_date"].ToString())), "Patient Id  : " + patientId + "\n Patient Name : " + patientName, "", "");
                    DGV_Patients.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    DGV_Patients.Rows[j].Cells[0].Style.ForeColor = Color.DarkGreen;
                    DGV_Patients.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                    DGV_Patients.Rows[j].Cells[1].Style.ForeColor = Color.DarkGreen;
                    DGV_Patients.Rows[j].Height = 35;
                    DGV_Patients.Rows[j].Cells[0].Style.BackColor = Color.Gainsboro;
                    DGV_Patients.Rows[j].Cells[1].Style.BackColor = Color.Gainsboro;
                    DGV_Patients.Rows[j].Cells[2].Style.BackColor = Color.Gainsboro;
                    DGV_Patients.Rows[j].Cells[3].Style.BackColor = Color.Gainsboro;
                    j = j + 1;
                    DGV_Patients.Rows.Add("RECEIPT NUMBER", "INVOICES", "TOWARDS", "AMOUNT PAID");
                    DGV_Patients.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    DGV_Patients.Rows[j].Cells[0].Style.ForeColor = Color.White;
                    DGV_Patients.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    DGV_Patients.Rows[j].Cells[1].Style.ForeColor = Color.White;
                    DGV_Patients.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    DGV_Patients.Rows[j].Cells[2].Style.ForeColor = Color.White;
                    DGV_Patients.Rows[j].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    DGV_Patients.Rows[j].Cells[3].Style.ForeColor = Color.White;
                    DGV_Patients.Rows[j].Cells[0].Style.BackColor = Color.DarkGray;
                    DGV_Patients.Rows[j].Cells[1].Style.BackColor = Color.DarkGray;
                    DGV_Patients.Rows[j].Cells[2].Style.BackColor = Color.DarkGray;
                    DGV_Patients.Rows[j].Cells[3].Style.BackColor = Color.DarkGray;
                    System.Data.DataTable Payments = this.cntrl.payment_sub(Payment.Rows[i]["payment_date"].ToString());
                    for (int k = 0; k < Payments.Rows.Count; k++)
                    {
                        DGV_Patients.Rows.Add(Payments.Rows[k]["receipt_no"].ToString(), Payments.Rows[k]["invoice_no"].ToString(), Payments.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(Payments.Rows[k]["amount_paid"].ToString())));
                        j = j + 1;
                        DGV_Patients.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                        DGV_Patients.Rows[j].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                        DGV_Patients.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                        DGV_Patients.Rows[j].Cells[2].Style.ForeColor = Color.DodgerBlue;
                        DGV_Patients.Rows[j].Cells[0].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[j].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[j].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[j].Cells[3].Style.BackColor = Color.WhiteSmoke;
                    }
                    j = j + 1;
                    DGV_Patients.Rows.Add("", "", "", "");
                    DGV_Patients.Rows[j].Cells[0].Style.BackColor = Color.WhiteSmoke;
                    DGV_Patients.Rows[j].Cells[1].Style.BackColor = Color.WhiteSmoke;
                    DGV_Patients.Rows[j].Cells[2].Style.BackColor = Color.WhiteSmoke;
                    DGV_Patients.Rows[j].Cells[3].Style.BackColor = Color.WhiteSmoke;
                    j = j + 1;
                }
                if (Payment.Rows.Count > 0)
                {
                    lab_Displaying.Visible = true; lab_7.Visible = true;
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = Payment.Rows.Count.ToString() + " Patient(s)";
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Visible = true;
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = "0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_AllPatient_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                AllPatient_Flag = true;
                Recently_Visited_Flag = false;
                RecentalyAdded_flag = false;
                upcommingAppoinments_Flag = false;
                Upcomingbirthday_flag = false;
                CancelledAppoinmnt_Flag = false;
                Inactive_Flag = false;
                Group_flag = false;
                lab_7.Text = "";
                btn_AllPatient.BackColor = Color.DarkGray;
                if (doctor_id == "1")
                {
                    ClearAll_grid2_Properties();
                    left_button_click = 8;
                    txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                    SetPatient_SearchControlls();
                    DataTable drtb = this.cntrl.Get_all_Patients();
                    griddata(drtb);
                    Design_Datagrid();
                }
                else
                {
                    ClearAll_grid2_Properties();
                    txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                    SetPatient_SearchControlls();
                    DataTable dtb = this.cntrl.Get_all_Patients();
                    griddata(dtb);
                    Design_Datagrid();
                }
                grgroup.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void colorChange()
        {
            btn_AllPatient.BackColor = Color.Gainsboro;
            btn_RecentelyVisited.BackColor = Color.Gainsboro;
            btn_RecentlyAddes.BackColor = Color.Gainsboro;
            btn_Upcomming.BackColor = Color.Gainsboro;
            btn_Birthday.BackColor = Color.Gainsboro;
            bt_cancelled_appointment.BackColor = Color.Gainsboro;
            btnPaymentDue.BackColor = Color.Gainsboro;
            grgroup.ClearSelection();
        }

        private void btn_RecentelyVisited_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                btn_RecentelyVisited.BackColor = Color.DarkGray;
                AllPatient_Flag = false;
                Recently_Visited_Flag = true;
                RecentalyAdded_flag = false;
                upcommingAppoinments_Flag = false;
                Upcomingbirthday_flag = false;
                CancelledAppoinmnt_Flag = false;
                Inactive_Flag = false;
                Group_flag = false;
                string sqlstr = "";
                lab_7.Visible = true;
                lab_Displaying.Visible = true;
                txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                SetPatient_SearchControlls();
                left_button_click = 8;
                DateTime d = DateTime.Now;
                d = d.AddMonths(-1);
                DateTime todate = DateTime.Now;
                ClearAll_grid2_Properties();
                DataTable dtb = this.cntrl.recently_visited(d, todate);
                griddata(dtb);
                Design_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btn_RecentlyAddes_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                btn_RecentlyAddes.BackColor = Color.DarkGray;
                AllPatient_Flag = false;
                Recently_Visited_Flag = false;
                RecentalyAdded_flag = true;
                upcommingAppoinments_Flag = false;
                Upcomingbirthday_flag = false;
                CancelledAppoinmnt_Flag = false;
                Inactive_Flag = false;
                Group_flag = false;
                //string sqlstr = "";
                txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                SetPatient_SearchControlls();
                left_button_click = 8;
                ClearAll_grid2_Properties();
                DateTime d = DateTime.Now;
                d = d.AddMonths(-1);
                string todate = DateTime.Now.ToString("yyyy/MM/dd");
                DataTable dtb = this.cntrl.Recently_added(Convert.ToDateTime(d).ToString("yyyy/MM/dd"), todate);
                griddata(dtb);
                Design_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Upcomming_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                btn_Upcomming.BackColor = Color.DarkGray;
                AllPatient_Flag = false;
                Recently_Visited_Flag = false;
                RecentalyAdded_flag = false;
                upcommingAppoinments_Flag = true;
                Upcomingbirthday_flag = false;
                CancelledAppoinmnt_Flag = false;
                Inactive_Flag = false;
                Group_flag = false;
                string sqlstr = "";
                SetPatient_SearchControlls();
                txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                ClearAll_grid2_Properties();
                left_button_click = 8;
                DateTime startDateTime = Convert.ToDateTime(DateTime.Today.ToString("d") + " " + DateTime.Now.ToString("hh:mm:ss tt"));
                DataTable dtb = this.cntrl.upcomming_appointments(startDateTime);
                griddata(dtb);
                Design_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Birthday_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                btn_Birthday.BackColor = Color.DarkGray;
                AllPatient_Flag = false;
                Recently_Visited_Flag = false;
                RecentalyAdded_flag = false;
                upcommingAppoinments_Flag = false;
                Upcomingbirthday_flag = true;
                CancelledAppoinmnt_Flag = false;
                Inactive_Flag = false;
                Group_flag = false;
                string sqlstr = "";
                SetPatient_SearchControlls();
                txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                ClearAll_grid2_Properties();
                left_button_click = 8;
                DataTable dtb = this.cntrl.birthday();
                griddata(dtb);
                Design_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_cancelled_appointment_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                bt_cancelled_appointment.BackColor = Color.DarkGray;
                AllPatient_Flag = false;
                Recently_Visited_Flag = false;
                RecentalyAdded_flag = false;
                upcommingAppoinments_Flag = false;
                Upcomingbirthday_flag = false;
                Inactive_Flag = false;
                Group_flag = false;
                CancelledAppoinmnt_Flag = true;
                ClearAll_grid2_Properties();
                SetPatient_SearchControlls();
                txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                left_button_click = 8;
                DataTable dtb = this.cntrl.cancelled_appointment();
                griddata(dtb);
                Design_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPaymentDue_Click(object sender, EventArgs e)
        {
            try
            {
                colorChange();
                btnPaymentDue.BackColor = Color.DarkGray;
                AllPatient_Flag = false;
                Recently_Visited_Flag = false;
                RecentalyAdded_flag = false;
                upcommingAppoinments_Flag = false;
                Upcomingbirthday_flag = false;
                Inactive_Flag = true;
                Group_flag = false;
                CancelledAppoinmnt_Flag = false;
                ClearAll_grid2_Properties();
                SetPatient_SearchControlls();
                txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                DataTable dtb = this.cntrl.innactive_patients();
                griddata(dtb);
                Design_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grgroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DGV_Patients.Show();
            try
            {
                if (grgroup.Rows.Count > 0)
                {
                    AllPatient_Flag = false;
                    Recently_Visited_Flag = false;
                    RecentalyAdded_flag = false;
                    upcommingAppoinments_Flag = false;
                    Upcomingbirthday_flag = false;
                    Inactive_Flag = false;
                    CancelledAppoinmnt_Flag = false;
                    Group_flag = true;
                    txt_Search.Text = "Search Patient Id, Patient Name, Mobile No, Address";
                    ClearAll_grid2_Properties();
                    id4 = "";
                    lab_7.Visible = true;
                    lab_7.Text = "";
                    lab_Displaying.Visible = true;
                    int g = e.RowIndex;
                    id4 = grgroup.Rows[g].Cells[1].Value.ToString();
                    DataTable dtb = this.cntrl.patients_wit_group(id4);
                    griddata(dtb);
                    Design_Datagrid();
                    lab_Displaying.Visible = true;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source, "Patient Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void labelprofile_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                if (doctor_id == "1")
                {
                    SetPatient_SearchControlls();
                    left_button_click = 0;
                    labelprofile.BackColor = Color.DodgerBlue;
                    labelprofile.ForeColor = Color.White;
                    panl_DisplayingPatient.Visible = true;
                    ClearAll_grid2_Properties();
                    lab_LongMsg.Hide();
                    DataTable dtb = this.cntrl.Get_all_Patients();
                    Create_Datagrid(dtb);
                    Design_Datagrid();
                }
                else
                {
                    labelprofile.BackColor = Color.DodgerBlue;
                    labelprofile.ForeColor = Color.White;
                    SetPatient_SearchControlls();
                    ClearAll_grid2_Properties();
                    panl_DisplayingPatient.Visible = true;
                    DataTable dtb = this.cntrl.Get_all_Patients();
                    Create_Datagrid(dtb);
                    Design_Datagrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printlabel_Click(object sender, EventArgs e)
        {
            Print_Label frm = new Print_Label();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void addnewpatient_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = mdl.doctr_privillage_for_addnewPatient(doctor_id);
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

        private void DGV_Patients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_Patients.RowCount > 0)
            {
                if (left_button_click == 1)
                {
                    if (e.ColumnIndex == 3 && e.RowIndex >= 0)
                    {
                        string id;
                        id = this.cntrl.privilege_D(doctor_id);
                        if (int.Parse(id) > 0)
                        {
                            MessageBox.Show("There is No Privilege to Delete Appointment", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (MessageBox.Show("Delete this appointment.. Confirm?", "Remove Appointment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                int ua = e.RowIndex;
                                string uaa = DGV_Patients.Rows[e.RowIndex].Cells[1].Value.ToString();
                                int i = this.cntrl.delete(uaa);
                                butt_Go_Click(this, new System.EventArgs());// buttonapp_Click(this, new System.EventArgs());
                            }
                        }
                    }
                    else if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                    {
                        int r = e.RowIndex;
                        id1 = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form2 = new Show_Appointment();
                        form2.patient_id = id1.ToString();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 2)
                {
                    if (e.ColumnIndex == 3 && DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString() != "0" && e.RowIndex >= 0)
                    {
                        var form2 = new Clinical_Findings();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 3)
                {
                    if (e.ColumnIndex == 2 && DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString() != "0" && e.RowIndex >= 0)
                    {
                        var form2 = new Treatment_Plans();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 4)
                {
                    if (e.ColumnIndex == 2 && DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString() != "0" && e.RowIndex >= 0)
                    {
                        var form2 = new Finished_Procedure();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 5)
                {
                    if (e.ColumnIndex == 2 && DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString() != "0" && e.RowIndex >= 0)
                    {
                        var form2 = new Prescription_Show();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 6)
                {
                    if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                    {
                        int r = e.RowIndex;
                        id1 = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form2 = new Patient_Profile_Details();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = id1.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 7)
                {
                    if (e.ColumnIndex == 6 && e.RowIndex >= 0)
                    {
                        int r = e.RowIndex;
                        id1 = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form2 = new Patient_Profile_Details();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = id1.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 8)
                {
                    if (e.ColumnIndex == 2 && e.RowIndex >= 0)
                    {
                        int r = e.RowIndex;
                        id1 = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form2 = new Patient_Profile_Details();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = id1.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 9)
                {
                    if (e.ColumnIndex == 3 && DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString() != "0" && e.RowIndex >= 0)
                    {
                        var form2 = new Vital_Signs();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else if (left_button_click == 0 && Inactive_Flag == false)
                {
                    if (e.RowIndex >= 0)
                    {
                        int r = e.RowIndex;
                        id1 = DGV_Patients.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form2 = new Patient_Profile_Details();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = id1.ToString();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
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

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
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
                listpatientsearch.BringToFront();
            }
            else
            {
                listpatientsearch.Visible = false;
            }
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

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            //if (doctor_id != "1")
            //{
            //    string id;
            //    id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
            //    if (int.Parse(id) > 0)
            //    {
            //        MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    }
            //    else
            //    {
            //        var form2 = new Add_New_Patients();
            //        form2.doctor_id = doctor_id;
            //        form2.Closed += (sender1, args) => this.Close();
            //        this.Hide();
            //        form2.Show();
            //    }
            //}
            //else
            //{
            //    var form2 = new Add_New_Patients();
            //    form2.doctor_id = doctor_id;
            //    form2.Closed += (sender1, args) => this.Close();
            //    this.Hide();
            //    form2.Show();
            //}
            var form2 = new Practice_Details();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.inventry_prevlage(doctor_id);
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
                    form2.Show();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        public void SetPatient_SearchControlls()
        {
            txt_Search.Visible = true;
            panel_Search.Visible = true;
            printlabel.Visible = true;
            addnewpatient.Visible = true;
            panl_FilterPatient.Visible = true;
            lab_7.Visible = true;
            panel_Search.Location = new Point(2, 3);
            lab_7.Text = "";
            panel_Appmnt.Visible = false;
            dateTimePickefrom.Visible = false;
            dateTimePicketo.Visible = false;
            lab_Change_AppoinmtName.Visible = false;
            lab_Displaying.Visible = true;
        }
        public void Prescription(DataTable dt_pre_main)
        {
            try
            {
                int i = 0;
                DGV_Patients.ScrollBars = ScrollBars.Vertical;
                if (dt_pre_main.Rows.Count > 0)
                {
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dt_pre_main.Rows.Count.ToString() + " Patient(s)";
                    lab_LongMsg.Hide();
                    lab_LongMsg.Location = new Point(350, 350);
                    for (int j = 0; j < dt_pre_main.Rows.Count; j++)
                    {
                        DGV_Patients.Rows.Add(dt_pre_main.Rows[j]["pt_id"].ToString(), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pre_main.Rows[j]["date"].ToString())), "", "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.DarkGreen;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.Gainsboro;
                        DGV_Patients.Rows[i].Height = 35;
                        System.Data.DataTable rs_patients = this.cntrl.Patient_details(dt_pre_main.Rows[j]["pt_id"].ToString());
                        if (rs_patients.Rows.Count > 0)
                        {
                            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                            { DGV_Patients.Rows[i].Cells[2].Value = "PATIENT :  " + rs_patients.Rows[0]["pt_name"].ToString(); }
                            if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                            {
                                DGV_Patients.Rows[i].Cells[3].Value = DGV_Patients.Rows[i].Cells[3].Value + "PATIENT ID :  " + rs_patients.Rows[0]["pt_id"].ToString();
                            }
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "DRUG", "FREQUENCY", "DURATION", "INSTRUCTION");
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[2].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[3].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[4].Style.ForeColor = Color.White;
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                        System.Data.DataTable dt_prescription = this.cntrl.prescription_details(dt_pre_main.Rows[j]["id"].ToString());
                        if (dt_prescription.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt_prescription.Rows.Count; k++)
                            {
                                i = i + 1;
                                string morning = "";
                                string noon = "";
                                string night = "";
                                string a1 = dt_prescription.Rows[k]["morning"].ToString();
                                string[] b1 = a1.Split('.');
                                int right1 = int.Parse(b1[1]);
                                morning = Convert.ToString(int.Parse(b1[0]));
                                if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                                string a2 = dt_prescription.Rows[k]["noon"].ToString();
                                string[] b2 = a2.Split('.');
                                int right2 = int.Parse(b2[1]);
                                noon = Convert.ToString(int.Parse(b2[0]));
                                if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                                string a3 = dt_prescription.Rows[k]["night"].ToString();
                                string[] b3 = a3.Split('.');
                                int right3 = int.Parse(b3[1]);
                                night = Convert.ToString(int.Parse(b3[0]));
                                if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                                DGV_Patients.Rows.Add("0", dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString() + " " + dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString(), morning + " - " + noon + " - " + night, dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString(), dt_prescription.Rows[k]["add_instruction"].ToString());
                                DGV_Patients.Rows[i].Height = 30;
                                DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                                DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                            }
                        }
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "Prescribed by " + dt_pre_main.Rows[j]["doctor_name"].ToString(), "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                        DGV_Patients.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                        i = i + 1;
                        DGV_Patients.Rows.Add("0", "", "", "", "");
                        DGV_Patients.Rows[i].Cells[1].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[2].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[3].Style.BackColor = Color.WhiteSmoke;
                        DGV_Patients.Rows[i].Cells[4].Style.BackColor = Color.WhiteSmoke;
                        i = i + 1;
                    }
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(91, 177);
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " 0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txt_Search_KeyUp(object sender, KeyEventArgs e)
        {
            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            DateTime todate = DateTime.Now;
            string sqlstr = "";
            lab_7.Text = ""; lab_Displaying.Visible = true;
            DateTime startDateTime = Convert.ToDateTime(DateTime.Today.ToString("d") + " " + DateTime.Now.ToString("hh:mm:ss tt"));
            ClearAll_grid2_Properties();
            if (AllPatient_Flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.Get_all_Patients();
                    griddata(dtb); //Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.allpatient_search(txt_Search.Text);//
                    griddata(dtb);//Create_Datagrid(dtb);
                }
            }
            else if (RecentalyAdded_flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.Recently_added(d.ToString("yyyy/MM/dd"), todate.ToString("yyyy/MM/dd"));
                    Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.recently_added_search(d.ToString("yyyy/MM/dd"), todate.ToString("yyyy/MM/dd"), txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }

            else if (Recently_Visited_Flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.recently_visited(d, todate); Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.recently_visited_search(d, todate, txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }
            else if (upcommingAppoinments_Flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.upcomming_appointments(startDateTime);
                    Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.upcomming_appointments_search(startDateTime, txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }
            else if (Upcomingbirthday_flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.birthday();
                    Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.birthday_search(txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }
            else if (CancelledAppoinmnt_Flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.cancelled_appointment();
                    Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.cancelled_appointmnt_search(txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }
            else if (Inactive_Flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.innactive_patients();
                    Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.innactive_patients_search(txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }
            else if (Group_flag == true)
            {
                if (String.IsNullOrWhiteSpace(txt_Search.Text))
                {
                    DataTable dtb = this.cntrl.patients_wit_group(id4);
                    Create_Datagrid(dtb);
                }
                else
                {
                    DataTable dtb = this.cntrl.patients_wit_group_search(id4, txt_Search.Text);
                    Create_Datagrid(dtb);
                }
            }
            Design_Datagrid();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            btn_AllPatient_Click(null, null);
        }

        private void lab_Displaying_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void labelremaindersms_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labelremaindersms.BackColor = Color.DodgerBlue;
                labelremaindersms.ForeColor = Color.White;
                string clinic = "", locality = "", contact_no = "";

                System.Data.DataTable clinicname = this.cntrl.clinicdetails();// db.table("select name,locality,contact_no from tbl_practice_details");
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    clinic = clinicn.Replace("¤", "'");
                    locality = clinicname.Rows[0][1].ToString();
                    contact_no = clinicname.Rows[0][2].ToString();
                }

                string text = "";
                string smsName = "", smsPass = "", emailName = "", emailPass = "";
                DataTable sms = this.cntrl.sms_details();// db.table("select smsName,smsPass,emailName,emailPass from tbl_SmsEmailConfig");
                if (sms.Rows.Count > 0)
                {
                    smsName = sms.Rows[0]["smsName"].ToString();
                    smsPass = sms.Rows[0]["smsPass"].ToString();
                    emailName = sms.Rows[0]["emailName"].ToString();
                    emailPass = sms.Rows[0]["emailPass"].ToString();
                }



                string str_sql = "", sqlstring = "";
                DateTime dtNow = new DateTime(DateTime.Now.Ticks);
                DateTime startDateTime = Convert.ToDateTime(DateTime.Today.ToString("d") + " 01:01:00 AM");
                DateTime startDateTime1 = Convert.ToDateTime(DateTime.Today.ToString("d") + " 11:59:00 PM");
                //str_sql = "SELECT id,doctor_name,mobile_number,email_id FROM tbl_doctor   where activate_login='yes'";
                DataTable dt_dr = this.cntrl.doctor_details();// db.table(str_sql + " ORDER BY id");
                startDateTime = startDateTime.AddDays(1);
                startDateTime1 = startDateTime1.AddDays(1);
                if (dt_dr.Rows.Count > 0)
                {

                    for (int j = 0; j < dt_dr.Rows.Count; j++)
                    {
                        //sqlstring = "SELECT id,pt_name,start_datetime,plan_New_procedure ,status,EHR_status,start_datetime FROM tbl_appointment where start_datetime between  '" + Convert.ToDateTime(startDateTime).ToString("yyyy-MM-dd HH:mm") + "' AND '" + Convert.ToDateTime(startDateTime1).ToString("yyyy-MM-dd HH:mm") + "' AND dr_id='" + dt_dr.Rows[j]["id"].ToString() + "' ORDER BY start_datetime";

                        DataTable dt_app = this.cntrl.get_reminder_sms_details(startDateTime, startDateTime1, dt_dr.Rows[j]["id"].ToString());// db.table(sqlstring);
                        long long_app_count = 0;
                        string mob_number = "91" + dt_dr.Rows[j]["mobile_number"].ToString();
                        string email = dt_dr.Rows[j]["email_id"].ToString();
                        string text_email = "";
                        if (dt_app.Rows.Count > 0)
                        {

                            for (int i = 0; i < dt_app.Rows.Count; i++)
                            {
                                long_app_count += 1;
                                text_email = text_email + "<tr><td></td><td style='border: 1px solid #dddddd;'>" + (i + 1) + "</td><td style='border: 1px solid #dddddd;' >" + dt_app.Rows[i]["pt_name"].ToString() + "</td><td style='border: 1px solid #dddddd;'>Not Provided </td><td style='border: 1px solid #dddddd;'>" + Convert.ToDateTime(dt_app.Rows[i]["start_datetime"].ToString()).ToString("dd MMM, HH:mm") + "</td></tr>";
                            }

                            if (long_app_count > 0)
                            {
                                SMS_model send_sms_class = new SMS_model();
                                text = "Good Morning Dr. " + dt_dr.Rows[j]["doctor_name"].ToString() + ", You have " + long_app_count + " Appointment[s] today at " + clinic;
                                send_sms_class.SendSMS(smsName, smsPass, mob_number, text, "DRTOMS", dt_dr.Rows[j]["id"].ToString(), startDateTime.ToString("dd/MM/yyyy"), DateTime.Now.ToString("dd/MM/yyyy"));

                                if (emailName != "" && emailPass != "")
                                {

                                    try
                                    {
                                        string sr1 = "<table align='center' style='width:700px;border: 1px solid ;border-collapse: collapse; background: #EAEAEA; height:500px'><tr><td  align='left' height='27'><FONT  color='#666666'  face='Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Reminder @ " + clinic + "</font></td></tr><tr><td  align='left' height='400px'><table  height='423' align='center' style='width:600px; background: #FFFFFF; height:400px'><tr><td  align='left' height='6px'><FONT  color='#000000'  face='Arial' SIZE=6>" + clinic + "</font></td></tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr><tr><td  align='left' height='62' valign='bottom'><FONT  color='#000000'  face='Arial' SIZE=3>Good morning <b>Dr." + dt_dr.Rows[j]["doctor_name"].ToString() + "</b> </font></td></tr> <tr><td align='left' height='197' valign='top'><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have " + long_app_count + " appointment(s) today at " + clinic + ".<br /><br /> Details of appointments : <table style='width:600px;border: 1px solid #dddddd ;border-collapse: collapse; background: #EAEAEA; '> <tbody><tr ><FONT  face='Arial' ><td width='31' height='31' valign='bottom' align='left' style='border: 1px solid #dddddd;'>No.</td><td width='219' height='31' valign='bottom' align='left' style='border: 1px solid #dddddd;'>  Patient Name</td> <td width='219' valign='bottom' style='border: 1px solid #dddddd;'>Patient Contact </td> <td width='95' height='31' valign='bottom' align='left' style='border: 1px solid #dddddd;'>Timing</td>  </FONT></tr>" + text_email + "</tbody></table><tr><td height='25'> For any queries, contact us at : " + contact_no + "</td>  </tr><tr><td  align='left' height='1px' bgcolor='#666666'></td></tr> <tr><td height='25'  align='right' valign='bottom'>Powered by&nbsp;&nbsp; </td></tr> <tr><td height='81'  align='right' valign='top'><img src='http://pappyjoe.com/assets/images/pappyjoe-logo.PNG' alt='pappyjoe official logo'>&nbsp;&nbsp;</td></tr></table></td></tr></table>";

                                        MailMessage message = new MailMessage();
                                        message.From = new MailAddress(email);
                                        message.To.Add(email);
                                        message.BodyEncoding = System.Text.Encoding.GetEncoding(1252); //bijeesh
                                        message.IsBodyHtml = true; //bijeesh
                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                        message.Subject = long_app_count + " appointment(s) scheduled for Today (" + startDateTime.ToString("dd MMM yyyy") + ") @ " + clinic;
                                        message.Body = sr1.ToString();
                                        smtp.Port = 587;
                                        smtp.Host = "smtp.gmail.com";
                                        smtp.EnableSsl = true;
                                        smtp.UseDefaultCredentials = false;
                                        smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                        smtp.Send(message);
                                    }
                                    catch
                                    {
                                    }

                                }
                            }

                        }
                    }
                    MessageBox.Show("Reminder sms saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }
            catch { MessageBox.Show("Please check email/sms configurations", "Failed", MessageBoxButtons.OK, MessageBoxIcon.None); }
        }

        private void listpatientsearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labellog_Click(object sender, EventArgs e)
        {
            try
            {
                b_normal();
                labellog.BackColor = Color.DodgerBlue;
                labellog.ForeColor = Color.White;
                DataTable rs_log = this.cntrl.log_details();
                DGV_Log.DataSource = rs_log;
                if (rs_log.Rows.Count > 0)
                {
                    DGV_Log.Columns[0].Width = 30;
                    DGV_Log.Columns[1].Width = 50;
                    DGV_Log.Columns[2].Width = 70;
                    DGV_Log.Columns[3].Width = 120;
                    DGV_Log.Columns[4].Width = 90;
                    panellog.Visible = true;
                    btnCancel.Visible = true;
                    panellog.Location = new Point(23, 100);
                    DGV_Log.Visible = true;
                }
                else
                {
                    panellog.Visible = false;
                    btnCancel.Visible = false;
                }
                DGV_Log.EnableHeadersVisualStyles = false;
                DGV_Log.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
                DGV_Log.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_Log.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                DGV_Log.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                DGV_Log.ColumnHeadersVisible = true;
                DGV_Log.ScrollBars = ScrollBars.Vertical;
                foreach (DataGridViewColumn column in DGV_Log.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panellog.Visible = false;
        }

        private void lb_showall_Click(object sender, EventArgs e)
        {
            griddata(dtb);
            Design_Datagrid();
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
        }

        public Patients()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        string FileName;
        private void lbl_imprt_patients_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel File to Import";
                ofd.FileName = "";
                ofd.Filter = "Excel File|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;
                    if (FileName.Trim() != "")
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(FileName);
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                        int iRow;//						

                        if (xlWorkSheet.Cells[1, 1].value == "Patient Name" && xlWorkSheet.Cells[1, 2].value == "Gender" && xlWorkSheet.Cells[1, 3].value == "Age" && xlWorkSheet.Cells[1, 4].value == "Mobile" && xlWorkSheet.Cells[1, 5].value == "Street Address" && xlWorkSheet.Cells[1, 6].value == "Locality" && xlWorkSheet.Cells[1, 7].value == "File")
                        {
                            for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
                            {
                                if (xlWorkSheet.Cells[iRow, 1].value == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string patid = "";
                                    DataTable auto = this.contr.data_from_automaticid();
                                    if (auto.Rows.Count > 0)
                                    {
                                        if (auto.Rows[0]["patient_automation"].ToString() == "Yes")
                                        {
                                            patid = auto.Rows[0]["patient_prefix"].ToString() + auto.Rows[0]["patient_number"].ToString();
                                        }
                                    }
                                    string patientname = ""; string gender = ""; string age = ""; string mobile = ""; string street = ""; string locality = ""; string file = "";
                                    string adhar = ""; string dob = ""; string bldgrp = ""; string accmpnied = ""; string secmob = ""; string landno = ""; string mail = ""; string city = ""; string pin = ""; string referdby = ""; string visited = DateTime.Now.ToString(); string doctor = ""; string occupation = ""; string nation = ""; string passport = "";
                                    patientname = Convert.ToString(xlWorkSheet.Cells[iRow, 1].value);
                                    gender = Convert.ToString(xlWorkSheet.Cells[iRow, 2].value);
                                    age = Convert.ToString(xlWorkSheet.Cells[iRow, 3].value);
                                    mobile = Convert.ToString(xlWorkSheet.Cells[iRow, 4].value);
                                    street = Convert.ToString(xlWorkSheet.Cells[iRow, 5].value);
                                    locality = Convert.ToString(xlWorkSheet.Cells[iRow, 6].value);
                                    file = Convert.ToString(xlWorkSheet.Cells[iRow, 7].value);
                                    DataTable patSearch = this.contr.Get_patient_details(patientname);
                                    if (patSearch.Rows.Count == 0)
                                    {
                                        i = this.contr.Save(patientname, patid, adhar, gender, dob, age, bldgrp, accmpnied, mobile, secmob, landno, mail, street, locality, city, pin, referdby, file, visited, doctor, occupation, nation, passport);

                                    }
                                    DataTable cmd = this.contr.automaticid();
                                    if (cmd.Rows.Count > 0)
                                    {
                                        int n = 0;
                                        n = int.Parse(cmd.Rows[0]["patient_number"].ToString()) + 1;
                                        if (n != 0)
                                        {
                                            this.contr.update_autogenerateid(n);
                                        }
                                    }
                                }
                            }
                            b_normal();
                            if (doctor_id == "1")
                            {
                                SetPatient_SearchControlls();
                                left_button_click = 0;
                                labelprofile.BackColor = Color.DodgerBlue;
                                labelprofile.ForeColor = Color.White;
                                panl_DisplayingPatient.Visible = true;
                                ClearAll_grid2_Properties();
                                lab_LongMsg.Hide();
                                DataTable dtb = this.cntrl.Get_all_Patients();
                                Create_Datagrid(dtb);
                                Design_Datagrid();
                            }
                            else
                            {
                                labelprofile.BackColor = Color.DodgerBlue;
                                labelprofile.ForeColor = Color.White;
                                SetPatient_SearchControlls();
                                ClearAll_grid2_Properties();
                                panl_DisplayingPatient.Visible = true;
                                DataTable dtb = this.cntrl.Get_all_Patients();
                                Create_Datagrid(dtb);
                                Design_Datagrid();
                            }
                            xlWorkBook.Close();
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                            MessageBox.Show("Successfully Imported !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Excel sheet data is not in the standard format", "Format mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Setcontroller(Patients_controller controller)
        {
            cntrl = controller;
        }

        private void panel_titile_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dtb;
        private void patients_Load(object sender, EventArgs e)
        {
            lb_showall.Visible = false;
            toolStripButton3.BackColor = Color.SkyBlue;
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            string docnam = mdl.Get_DoctorName(doctor_id);
            if (docnam != "")
            {
                toolStripTextDoctor.Text = "Logged In As : " + docnam;
            }
            AllPatient_Flag = true;
            DataTable clinicname = mdl.Get_CompanyNAme();
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
            if (doctor_id == "1")
            {
                panel_Search.Visible = true;
                lab_Groups.Visible = true;
                panel_Search.Location = new Point(2, 3);
                panel_Appmnt.Visible = false;
                //string sqlstr = "";
                DGV_Patients.RowTemplate.Height = 25;
                DGV_Patients.Visible = true;
                dtb = this.cntrl.Get_all_Patients();
                if (dtb.Rows.Count < 0)
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(350, 350);
                    lab_7.Visible = true;
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = " Zero Patient(s)";
                    lab_Displaying.Visible = false;
                }
                else
                {
                    lab_Displaying.Visible = true;
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dtb.Rows.Count.ToString() + " Patient(s)";
                }
                Create_Datagrid(dtb);
                Design_Datagrid();
                //-----Group Add------
                grgroup.ColumnCount = 2;
                grgroup.ColumnHeadersVisible = false;
                grgroup.RowHeadersVisible = false;
                grgroup.Columns[0].Name = "id";
                grgroup.Columns[0].Width = 0;
                grgroup.Columns[1].Name = "group";
                grgroup.Columns[1].Width = 250;
                grgroup.Columns[0].Visible = false;
                grgroup.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                DataTable dt_grp = this.cntrl.group();
                Load_Group(dt_grp);
            }
            else
            {
                panel_Search.Visible = true;
                lab_Groups.Visible = true;
                panel_Search.Location = new Point(2, 3);
                panel_Appmnt.Visible = false;
                DGV_Patients.RowTemplate.Height = 25;
                DGV_Patients.Visible = true;
                ClearAll_grid2_Properties();
                dtb = this.cntrl.Get_all_Patients();
                Create_Datagrid(dtb);
                Design_Datagrid();
                //-----Group Add------
                grgroup.ColumnCount = 2;
                grgroup.ColumnHeadersVisible = false;
                grgroup.RowHeadersVisible = false;
                grgroup.Columns[0].Name = "id";
                grgroup.Columns[0].Width = 0;
                grgroup.Columns[1].Name = "group";
                grgroup.Columns[1].Width = 250;
                grgroup.Columns[0].Visible = false;
                grgroup.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                DataTable dt_grp = this.cntrl.group();
                Load_Group(dt_grp);
            }
            dateTimePickefrom.Value = DateTime.Now;
            dateTimePicketo.Value = DateTime.Now;
        }

        public void Load_Group(DataTable dt_gd)
        {
            for (int j = 0; j < dt_gd.Rows.Count; j++)
            {
                grgroup.Rows.Add(dt_gd.Rows[j]["id"].ToString(), dt_gd.Rows[j]["name"].ToString());
            }
            if (grgroup.Rows.Count > 0)
            {
                grgroup.CurrentCell.Selected = false;
            }
        }
        public void Create_Datagrid(DataTable dtb)
        {
            if (dtb.Rows.Count > 18)
            {
                lb_showall.Visible = true;
            }
            if (dtb.Columns.Count > 0)
            {
                if (dtb.Rows.Count > 0)
                {
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dtb.Rows.Count.ToString() + " Patient(s)";
                    panellog.Visible = false;
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(350, 350);
                    lab_7.Visible = true;
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = "0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
                lab_LongMsg.Hide();
                DGV_Patients.ColumnHeadersVisible = true;
                DGV_Patients.Columns.Clear();
                DGV_Patients.Rows.Clear();
                DataTable data = this.cntrl.get_few_patients();
                foreach (DataColumn column in data.Columns)
                {
                    DGV_Patients.Columns.Add(column.ColumnName, column.ColumnName);
                }
                if (DGV_Patients.Columns.Count > 0)
                {
                    for (int j = 0; j < data.Rows.Count; j++)
                    {
                        DGV_Patients.Rows.Add();
                        for (int i = 0; i < data.Columns.Count; i++)
                        {
                            DGV_Patients.Rows[j].Cells[i].Value = data.Rows[j][i].ToString();
                            DGV_Patients.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            DGV_Patients.SelectionMode = DataGridViewSelectionMode.CellSelect;
                            DGV_Patients.AllowUserToResizeColumns = false;
                            DGV_Patients.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                            DGV_Patients.Rows[j].Cells[i].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                            DGV_Patients.CellBorderStyle = DataGridViewCellBorderStyle.None;
                        }
                    }
                    DGV_Patients.Columns[0].Visible = false;
                }
            }
            else
            {
                lab_LongMsg.Show();
                lab_LongMsg.Location = new Point(91, 177);
                lab_7.Visible = true;
                lab_7.Location = new Point(4, 5);
                lab_7.Text = " 0 Patient(s)";
                lab_Displaying.Visible = false;
            }
        }
        public void griddata(DataTable dtb)
        {
            lb_showall.Visible = false;
            if (dtb.Columns.Count > 0)
            {
                if (dtb.Rows.Count > 0)
                {
                    lab_7.Location = new Point(73, 7);
                    lab_7.Text = dtb.Rows.Count.ToString() + " Patient(s)";
                    panellog.Visible = false;
                }
                else
                {
                    lab_LongMsg.Show();
                    lab_LongMsg.Location = new Point(350, 350);
                    lab_7.Visible = true;
                    lab_7.Location = new Point(4, 5);
                    lab_7.Text = "0 Patient(s)";
                    lab_Displaying.Visible = false;
                }
                lab_LongMsg.Hide();
                DGV_Patients.ColumnHeadersVisible = true;
                DGV_Patients.Columns.Clear();
                DGV_Patients.Rows.Clear();
                foreach (DataColumn column in dtb.Columns)
                {
                    DGV_Patients.Columns.Add(column.ColumnName, column.ColumnName);
                }
                if (DGV_Patients.Columns.Count > 0)
                {
                    for (int j = 0; j < dtb.Rows.Count; j++)
                    {
                        DGV_Patients.Rows.Add();
                        for (int i = 0; i < dtb.Columns.Count; i++)
                        {
                            DGV_Patients.Rows[j].Cells[i].Value = dtb.Rows[j][i].ToString();
                            DGV_Patients.RowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
                            DGV_Patients.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            DGV_Patients.SelectionMode = DataGridViewSelectionMode.CellSelect;
                            DGV_Patients.AllowUserToResizeColumns = false;
                            DGV_Patients.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                            DGV_Patients.Rows[j].Cells[i].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                            DGV_Patients.CellBorderStyle = DataGridViewCellBorderStyle.None;
                        }
                    }
                    DGV_Patients.Columns[0].Visible = false;
                }
            }
            else
            {
                lab_LongMsg.Show();
                lab_LongMsg.Location = new Point(91, 177);
                lab_7.Visible = true;
                lab_7.Location = new Point(4, 5);
                lab_7.Text = " 0 Patient(s)";
                lab_Displaying.Visible = false;
            }
        }
        public void Design_Datagrid()
        {
            if (DGV_Patients.Columns.Count > 0)
            {
                DGV_Patients.Columns[0].Width = 1;
                DGV_Patients.Columns[1].Width = 45;
                DGV_Patients.Columns[2].Width = 200;
                DGV_Patients.Columns[3].Width = 60;
                DGV_Patients.Columns[4].Width = 40;
                DGV_Patients.Columns[5].Width = 80;
                DGV_Patients.Columns[6].Width = 140;
                DGV_Patients.Columns[7].Width = 140;
                DGV_Patients.Columns[8].Width = 100;
            }
            DGV_Patients.EnableHeadersVisualStyles = false;
            DGV_Patients.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            DGV_Patients.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGV_Patients.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Patients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DGV_Patients.ColumnHeadersVisible = true;
            DGV_Patients.ScrollBars = ScrollBars.Vertical;
            foreach (DataGridViewColumn column in DGV_Patients.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void ClearAll_grid2_Properties()
        {
            DGV_Patients.DataSource = null;
            DGV_Patients.ColumnHeadersVisible = false;
            DGV_Patients.RowHeadersVisible = false;
            DGV_Patients.RowCount = 0;
            DGV_Patients.ColumnCount = 0;
            DGV_Patients.RowTemplate.Height = 25;
        }
    }
}
