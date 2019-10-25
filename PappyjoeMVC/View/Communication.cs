using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Communication : Form
    {
        bool flag = false;
        int tabstatus = 0, tabstatus1 = 0;
        public static string template = "";
        public string doctor_id = "", staff_id = "", patient_id = "", id1 = "";
        Communication_controller ctrlr = new Communication_controller();
        public Communication()
        {
            InitializeComponent();
        }
        public void selecttemp(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    DGV_SMSTemplates.Visible = true;
                    Panl_AddTemplate.Visible = false;
                    DGV_SMSTemplates.Rows.Clear();
                    int t1 = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DGV_SMSTemplates.Rows.Add();
                        DGV_SMSTemplates.Rows[t1].Cells[0].Value = dr["id"].ToString();
                        DGV_SMSTemplates.Rows[t1].Cells[1].Value = dr["template"].ToString();
                        t1++;
                        DGV_SMSTemplates.RowsDefaultCellStyle.ForeColor = Color.Black;
                        DGV_SMSTemplates.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                    }
                    DGV_SMSTemplates.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    DGV_SMSTemplates.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    DGV_SMSTemplates.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    DGV_SMSTemplates.EnableHeadersVisualStyles = false;
                    foreach (DataGridViewColumn cln in DGV_SMSTemplates.Columns)
                    {
                        cln.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                else
                {
                    MessageBox.Show("Error occured!...Please try again later", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DGV_SMSTemplates.Visible = false;
                    Panl_AddTemplate.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void selgrp(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string pid = dt.Rows[0][0].ToString();
                string pname = dt.Rows[0][2].ToString();
                string mobno = "91" + dt.Rows[0][3].ToString();
                string txt = "Dear " + pname + ", " + txt_SMS.Text.ToString();
                msg.Text = txt;
                no.Text = mobno;
            }
        }
        public void selsms(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("SMS service not activated..Please select Communication Settings..!", "Service Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    var form2 = new Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    if (tabstatus1 == 0)
                    {
                        string smsName = "", smsPass = "";
                        smsName = dt.Rows[0]["smsName"].ToString();
                        smsPass = dt.Rows[0]["smsPass"].ToString();
                        int j = 0;
                        int i = 0;
                        if (tabstatus == 0)
                        {
                            for (i = 0; i < DGV_Patient.Rows.Count; i++)
                            {
                                if (Convert.ToBoolean(DGV_Patient.Rows[i].Cells[3].Value) == true)
                                {
                                    string number = "91" + DGV_Patient.Rows[i].Cells[2].Value.ToString();
                                    string text = "Dear " + DGV_Patient.Rows[i].Cells[1].Value.ToString() + ", " + txt_SMS.Text.ToString();
                                    msg.Text = text;
                                    string s = this.ctrlr.SendSMS(smsName, smsPass, number, text);
                                    if (s == "SMS message(s) sent")
                                    { MessageBox.Show("Messages will be sent to entered numbers", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    this.ctrlr.inssms(patient_id, DateTime.Now.ToString("yyyy-MM-dd"), text);
                                }
                            }
                            txt_Recipients.Text = "";
                            txt_SMS.Text = "";
                        }
                        else if (tabstatus == 1)
                        {
                            for (j = 0; j < dgv_Group.Rows.Count; j++)
                            {
                                if (Convert.ToBoolean(dgv_Group.Rows[j].Cells[3].Value) == true)
                                {
                                    DataTable grp = this.ctrlr.selgrp();
                                    selgrp(grp);
                                    string sm = this.ctrlr.SendSMS(smsName, smsPass, no.Text, msg.Text);
                                    if (sm == "SMS message(s) sent")
                                    { MessageBox.Show("Messages will be sent to entered numbers", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    this.ctrlr.inssmsgrp(patient_id, msg.Text);
                                }
                            }
                            txt_Recipients.Text = "";
                            txt_SMS.Text = "";
                        }
                        else if (tabstatus == 2)
                        {
                            for (int y = 0; y < DGV_Staff.Rows.Count; y++)
                            {
                                if (Convert.ToBoolean(DGV_Staff.Rows[y].Cells[3].Value) == true)
                                {
                                    string n = "91" + DGV_Staff.Rows[y].Cells[2].Value.ToString();
                                    string t = "Dear " + DGV_Staff.Rows[y].Cells[1].Value.ToString() + ", " + txt_SMS.Text.ToString();
                                    msg.Text = t;
                                    string sms = this.ctrlr.SendSMS(smsName, smsPass, n, msg.Text.ToString());
                                    if (sms == "SMS message(s) sent")
                                    { MessageBox.Show("Messages will be sent to entered numbers", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    this.ctrlr.insmsstaff(patient_id, msg.Text.ToString());
                                }
                            }
                            txt_Recipients.Text = "";
                            txt_SMS.Text = "";
                        }
                    }
                    if (tabstatus1 == 2)
                    {
                        string smsName = "", smsPass = "";
                        smsName = dt.Rows[0]["smsName"].ToString();
                        smsPass = dt.Rows[0]["smsPass"].ToString();
                        int j = 0;
                        int i = 0;
                        bool flag = false;
                        for (i = 0; i < DGV_upcoming_birthday.Rows.Count; i++)
                        {
                            if (template != null)
                            {
                                if (Convert.ToBoolean(DGV_upcoming_birthday.Rows[i].Cells[4].Value) == true)
                                {
                                    string pid = DGV_upcoming_birthday.Rows[i].Cells[0].Value.ToString();
                                    string number = "91" + DGV_upcoming_birthday.Rows[i].Cells[2].Value.ToString();
                                    string ptName = DGV_upcoming_birthday.Rows[i].Cells[1].Value.ToString();
                                    string text = "Dear " + ptName + ", " + template.ToString();
                                    msg.Text = text;
                                    string brth = this.ctrlr.SendSMS(smsName, smsPass, number, msg.Text);
                                    if (brth == "SMS message(s) sent")
                                    { MessageBox.Show("Messages will be sent to entered numbers", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                    this.ctrlr.insbrthsms(patient_id, msg.Text);
                                }
                                flag = true;
                            }
                        }
                        if (flag == false)
                        {
                            MessageBox.Show("choose the Template and Patient", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void srchstaff(DataTable dt)
        {
            if (txt_StaffSearch.Text != "")
            {
                btn_staffSelectall.Visible = false;
                DGV_Patient.DataSource = null;
                btnStaffDeselectAll.Visible = false;
                if (dt.Rows.Count > 0)
                {
                    DGV_Staff.DataSource = dt;
                    btn_StaffBack.Visible = true;
                }
                else
                {
                    MessageBox.Show("Entered data could not be found", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_StaffSearch.Text = "";
                }
            }
        }
        public void LoadData(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (flag == false)
                        DGV_Patient.Rows.Clear();
                    int t1 = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DGV_Patient.Rows.Add();
                        DGV_Patient.Rows[t1].Cells[0].Value = dr["pt_id"].ToString();
                        DGV_Patient.Rows[t1].Cells[1].Value = dr["pt_name"].ToString();
                        DGV_Patient.Rows[t1].Cells[2].Value = dr["primary_mobile_number"].ToString();
                        t1++;
                        DGV_Patient.RowsDefaultCellStyle.ForeColor = Color.Black;
                        DGV_Patient.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                    }
                    DGV_Patient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    DGV_Patient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    DGV_Patient.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    DGV_Patient.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    DGV_Patient.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    DGV_Patient.EnableHeadersVisualStyles = false;
                    foreach (DataGridViewColumn cl in DGV_Patient.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadGrp(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                int row = 0;
                DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
                foreach (DataRow dr in dt.Rows)
                {
                    dgv_Group.Rows.Add();
                    dgv_Group.Rows[row].Cells[0].Value = dr[0].ToString();
                    row++;
                }
                dgv_Group.Columns.Add(Deletelink);
                DataGridViewCheckBoxColumn check1 = new DataGridViewCheckBoxColumn()
                {

                };
                dgv_Group.Columns.Add(check1);
                check1.Width = 25;
                check1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv_Group.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_Group.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_Group.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                dgv_Group.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Group.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_Group.EnableHeadersVisualStyles = false;
            }
        }
        public void LoadStaff(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                int t1 = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    DGV_Staff.Rows.Add();
                    DGV_Staff.Rows[t1].Cells[0].Value = dr["id"].ToString();
                    DGV_Staff.Rows[t1].Cells[1].Value = dr["doctor_name"].ToString();
                    DGV_Staff.Rows[t1].Cells[2].Value = dr["mobile_number"].ToString();
                    t1++;
                    DGV_Staff.RowsDefaultCellStyle.ForeColor = Color.Black;
                    DGV_Staff.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                }
                DGV_Staff.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                DGV_Staff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_Staff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                DGV_Staff.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Staff.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Staff.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_Staff.EnableHeadersVisualStyles = false;
            }
        }
        private void Communication_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton4.BackColor = Color.SkyBlue;
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                listpatientsearch.Hide();
                DataTable dt = this.ctrlr.Get_CompanyNAme();
                if (dt.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = dt.Rows[0][0].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                }
                string dt1 = this.ctrlr.Get_DoctorName(doctor_id);
                if (dt1 != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + dt1;
                }
                DataTable data = this.ctrlr.LoadData();
                if (data.Rows.Count > 0)
                {
                    flag = true;
                    LoadData(data);
                    DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn()
                    {

                    };
                    DGV_Patient.Columns.Add(check);
                    check.Width = 25;
                    check.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                DataTable grp = this.ctrlr.LoadGrp();
                LoadGrp(grp);
                DataTable staff = this.ctrlr.LoadStaff();
                DGV_Staff.Visible = true;
                if (staff.Rows.Count > 0)
                {
                    LoadStaff(staff);
                    if (DGV_Staff.Rows.Count > 0)
                    {
                        DataGridViewCheckBoxColumn check2 = new DataGridViewCheckBoxColumn()
                        {
                           
                        };
                        DGV_Staff.Columns.Add(check2);
                        check2.Width = 50;
                        check2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    foreach (DataGridViewColumn cl in DGV_Staff.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                DGV_transactional.RowsDefaultCellStyle.ForeColor = Color.Black;
                DGV_transactional.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                btn_Deselectall.Visible = false;
                btnStaffDeselectAll.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_SearchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_searchPatient.Text != "")
                {
                    btn_selectall.Visible = false;
                    btn_Deselectall.Visible = false;
                    DataTable sr = this.ctrlr.srch(txt_searchPatient.Text);
                    if (sr.Rows.Count > 0)
                    {
                        flag = false;
                        LoadData(sr);
                        btn_Back.Visible = true;
                        btn_Back.Location = new Point(356, 36);
                    }
                    else
                    {
                        MessageBox.Show("Entered data could not be found", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Staff_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_StaffSearch.Text != "")
                {
                    btn_staffSelectall.Visible = false;
                    btnStaffDeselectAll.Visible = false;
                    DataTable dt = this.ctrlr.srchstaff(txt_StaffSearch.Text);
                    if (dt.Rows.Count > 0)
                    {
                        DGV_Staff.Rows.Clear();
                        LoadStaff(dt);
                        btn_StaffBack.Visible = true;
                        btn_StaffBack.Location = new Point(348, 37);
                    }
                    else
                    {
                        MessageBox.Show("Entered data could not be found", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    txt_StaffSearch.Text = "";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_selectall_Click(object sender, EventArgs e)
        {
            try
            {
                btn_selectall.Visible = false;
                btn_Deselectall.Visible = true;
                btn_Deselectall.Location = new Point(343, 36);
                txt_Recipients.Text = "";
                btn_Back.Visible = false;
                int i = 0;
                foreach (DataGridViewRow row in DGV_Patient.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    chk.Value = true;
                    if (txt_Recipients.Text == "")
                    {
                        string name = DGV_Patient.Rows[i].Cells[1].Value.ToString();
                        txt_Recipients.Text = txt_Recipients.Text.ToString() + name;
                    }
                    else
                    {
                        string name = DGV_Patient.Rows[i].Cells[1].Value.ToString();
                        txt_Recipients.Text = txt_Recipients.Text.ToString() + "," + name;
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Deselectall_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Recipients.Text = "";
                btn_Deselectall.Visible = false;
                btn_selectall.Visible = true;
                btn_Back.Visible = false;
                int i = 0;
                foreach (DataGridViewRow row in DGV_Patient.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    chk.Value = false;
                    string name = DGV_Patient.Rows[i].Cells[1].Value.ToString();
                    int index = txt_Recipients.Text.IndexOf(name);
                    if (index != -1)
                    {
                        txt_Recipients.Text = txt_Recipients.Text.Replace("," + name, "");
                        txt_Recipients.Text = txt_Recipients.Text.Replace(name + ",", "");
                        txt_Recipients.Text = txt_Recipients.Text.Replace(name, "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Group_SelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Group_SelectAll.Visible = false;
                btn_Group_Deselect.Visible = true;
                txt_Recipients.Text = "";
                btn_Group_Deselect.Location = new Point(384, 7);
                int i = 0;
                foreach (DataGridViewRow row in dgv_Group.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    chk.Value = true;
                    if (txt_Recipients.Text == "")
                    {
                        string name = dgv_Group.Rows[i].Cells[0].Value.ToString();
                        txt_Recipients.Text = txt_Recipients.Text.ToString() + name;
                    }
                    else
                    {
                        string name = dgv_Group.Rows[i].Cells[0].Value.ToString();
                        txt_Recipients.Text = txt_Recipients.Text.ToString() + "," + name;
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Group_Deselect_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Recipients.Text = "";
                btn_Group_Deselect.Visible = false;
                btn_Group_SelectAll.Visible = true;
                int i = 0;
                foreach (DataGridViewRow row in dgv_Group.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    chk.Value = false;
                    string name = dgv_Group.Rows[i].Cells[0].Value.ToString();
                    int index = txt_Recipients.Text.IndexOf(name);
                    if (index != -1)
                    {
                        txt_Recipients.Text = txt_Recipients.Text.Replace("," + name, "");
                        txt_Recipients.Text = txt_Recipients.Text.Replace(name + ",", "");
                        txt_Recipients.Text = txt_Recipients.Text.Replace(name, "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_staffSelectall_Click(object sender, EventArgs e)
        {
            try
            {
                btn_staffSelectall.Visible = false;
                btnStaffDeselectAll.Visible = true;
                txt_Recipients.Text = "";
                btnStaffDeselectAll.Location = new Point(348, 37);
                btn_StaffBack.Visible = false;
                int i = 0;
                foreach (DataGridViewRow row in DGV_Staff.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    chk.Value = true;
                    if (txt_Recipients.Text == "")
                    {
                        string name = DGV_Staff.Rows[i].Cells[1].Value.ToString();
                        txt_Recipients.Text = txt_Recipients.Text.ToString() + name;
                    }
                    else
                    {
                        string name = DGV_Staff.Rows[i].Cells[1].Value.ToString();
                        txt_Recipients.Text = txt_Recipients.Text.ToString() + "," + name;
                    }
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnStaffDeselectAll_Click(object sender, EventArgs e)
        {
            try
            {
                txt_Recipients.Text = "";
                btnStaffDeselectAll.Visible = false;
                btn_staffSelectall.Visible = true;
                btn_StaffBack.Visible = false;
                int i = 0;
                foreach (DataGridViewRow row in DGV_Staff.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                    chk.Value = false;
                    string name = DGV_Staff.Rows[i].Cells[1].Value.ToString();
                    int index = txt_Recipients.Text.IndexOf(name);
                    if (index != -1)
                    {
                        txt_Recipients.Text = txt_Recipients.Text.Replace("," + name, "");
                        txt_Recipients.Text = txt_Recipients.Text.Replace(name + ",", "");
                        txt_Recipients.Text = txt_Recipients.Text.Replace(name, "");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGV_Patient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex > -1)
                {
                    lst_GridItems.Items.Clear();
                    bool value = Convert.ToBoolean(DGV_Patient.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                    string name = DGV_Patient.Rows[e.RowIndex].Cells["patient_name"].Value.ToString();
                    if (value == false)
                    {
                        
                        if (txt_Recipients.Text == "")
                        {
                            lst_GridItems.Items.Add(name);
                            txt_Recipients.Text = txt_Recipients.Text.ToString() + name;
                        }
                        else
                        {
                            if (!lst_GridItems.Items.Contains(name))
                            {
                                lst_GridItems.Items.Add(name);
                                txt_Recipients.Text = txt_Recipients.Text.ToString() + "," + name;
                            }
                        }
                    }
                    else
                    {
                        int index = txt_Recipients.Text.IndexOf(name);
                        int idx = lst_GridItems.Items.IndexOf(name);
                        if (index != -1)
                        {
                            txt_Recipients.Text = txt_Recipients.Text.Replace("," + name, "");
                            txt_Recipients.Text = txt_Recipients.Text.Replace(name + ",", "");
                            txt_Recipients.Text = txt_Recipients.Text.Replace(name  , "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgv_Group_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex > -1)
                {
                    bool value = Convert.ToBoolean(dgv_Group.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                        if (value == false)
                        {
                            string name1 = dgv_Group.Rows[e.RowIndex].Cells[0].Value.ToString();
                            int index = txt_Recipients.Text.IndexOf(name1);
                            if (index != -1)
                            {
                                txt_Recipients.Text = txt_Recipients.Text.Replace("," + name1, "");
                                txt_Recipients.Text = txt_Recipients.Text.Replace(name1 + ",", "");
                                txt_Recipients.Text = txt_Recipients.Text.Replace(name1, "");
                            }
                            if (txt_Recipients.Text == "")
                            {
                                string name = dgv_Group.Rows[e.RowIndex].Cells[0].Value.ToString();
                                txt_Recipients.Text = txt_Recipients.Text.ToString() + name;
                            }
                            else
                            {
                                string name = dgv_Group.Rows[e.RowIndex].Cells[0].Value.ToString();
                                txt_Recipients.Text = txt_Recipients.Text.ToString() + "," + name;
                            }
                        }
                        else
                        {
                            string name = dgv_Group.Rows[e.RowIndex].Cells[0].Value.ToString();
                            int index = txt_Recipients.Text.IndexOf(name);
                            if (index != -1)
                            {
                                txt_Recipients.Text = txt_Recipients.Text.Replace("," + name, "");
                                txt_Recipients.Text = txt_Recipients.Text.Replace(name + ",", "");
                                txt_Recipients.Text = txt_Recipients.Text.Replace(name, "");
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGV_Staff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.RowIndex > -1)
                {
                    lst_GridItems.Items.Clear();
                    bool value = Convert.ToBoolean(DGV_Staff.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue);
                    string name = DGV_Staff.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (value == false)
                    {
                        if (txt_Recipients.Text == "")
                        {
                            lst_GridItems.Items.Add(name);
                            txt_Recipients.Text = txt_Recipients.Text.ToString() + name;
                        }
                        else
                        {
                            if (!lst_GridItems.Items.Contains(name))
                            {
                                lst_GridItems.Items.Add(name);
                                txt_Recipients.Text = txt_Recipients.Text.ToString() + "," + name;
                            }
                        }
                    }
                    else
                    {
                        int index = txt_Recipients.Text.IndexOf(name);
                        int idx = lst_GridItems.Items.IndexOf(name);
                        if (index != -1)
                        {
                            txt_Recipients.Text = txt_Recipients.Text.Replace("," + name, "");
                            txt_Recipients.Text = txt_Recipients.Text.Replace(name + ",", "");
                            txt_Recipients.Text = txt_Recipients.Text.Replace(name, "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Back_Click(object sender, EventArgs e)
        {
            try
            {
                TabControl_SMSCentre.Visible = true;
                txt_searchPatient.Text = "";
                txt_Recipients.Text = "";
                btn_selectall.Visible = true;
                btn_Deselectall.Visible = false;
                DGV_Patient.Visible = true;
                flag = false;
                DataTable dt = this.ctrlr.LoadData();
                if (dt.Rows.Count > 0)
                {
                    LoadData(dt);
                    btn_Back.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_StaffBack_Click(object sender, EventArgs e)
        {
            try
            {
                TabControl_SMSCentre.Visible = true;
                txt_StaffSearch.Text = "";
                txt_Recipients.Text = "";
                btn_staffSelectall.Visible = true;
                btnStaffDeselectAll.Visible = false;
                DGV_Staff.Visible = true;
                DataTable dt = this.ctrlr.staffback();
                if (dt.Rows.Count > 0)
                {
                    DGV_Staff.DataSource = dt;
                }
                btn_StaffBack.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btprom_Click(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = DTP_DateFrom.Value.ToShortDateString();
                var dateTo = DTP_DateTo.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than to date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DTP_DateFrom.Value = DateTime.Today;
                    return;
                }
                DGV_transactional.Rows.Clear();
                DateTime startDateTime = Convert.ToDateTime(DTP_DateFrom.Value.Date.ToString("d") + " 00:01:00 AM");
                DateTime endDateTime = Convert.ToDateTime(DTP_DateTo.Value.Date.ToString("d") + " 23:59:00 PM");
                DataTable st = this.ctrlr.status(DTP_DateFrom.Value.Date.ToString("yyyy-MM-dd"), DTP_DateTo.Value.Date.ToString("yyyy-MM-dd"));
                status(st);
                string failcnt = this.ctrlr.failcount(DTP_DateFrom.Value.Date.ToString("yyyy-MM-dd"), DTP_DateTo.Value.Date.ToString("yyyy-MM-dd"));
                if (Convert.ToInt32(failcnt) != 0)
                {
                    txtFailedSms.Text = "";
                    txtFailedSms.Text = failcnt.ToString();
                    lab_Msg.Visible = false;
                }
                string smscnt = this.ctrlr.smscount(DTP_DateFrom.Value.Date.ToString("yyyy-MM-dd"), DTP_DateTo.Value.Date.ToString("yyyy-MM-dd"));
                if (Convert.ToInt32(smscnt) != 0)
                {
                    txt_Sendsms.Text = "";
                    txt_Sendsms.Text = smscnt.ToString();
                    lab_Msg.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void status(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int t1 = 0;
                    lab_Msg.Visible = false;
                    foreach (DataRow dr in dt.Rows)
                    {
                        DGV_transactional.Rows.Add();
                        DGV_transactional.Rows[t1].Cells[0].Value = dr["pt_id"].ToString();
                        DGV_transactional.Rows[t1].Cells[1].Value = dr["pt_name"].ToString();
                        DGV_transactional.Rows[t1].Cells[2].Value = dr["message"].ToString();
                        DGV_transactional.Rows[t1].Cells[3].Value = dr["send_datetime"].ToString();
                        t1++;
                        DGV_transactional.RowsDefaultCellStyle.ForeColor = Color.Black;  
                        DGV_transactional.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                    }
                }
                else
                {
                    lab_Msg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_add_template_Click(object sender, EventArgs e)
        {
            TabControl_SMSCentre.Visible = false;
            panl_templates.Visible = true;
            Panl_AddTemplate.Visible = true;
            btn_save_template.Show();
            DGV_SMSTemplates.Visible = false;
            Btn_useTemplates.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            txt_Recipients.Visible = false;
            txt_SMS.Visible = false;
            txt_AddTemplates.Show();
        }
        private void Btn_useTemplates_Click(object sender, EventArgs e)
        {
            TabControl_SMSCentre.Visible = false;
            panl_templates.Visible = true;
            Panl_AddTemplate.Visible = false;
            DGV_SMSTemplates.Visible = true;
            DataTable tmp = this.ctrlr.selecttemp();
            selecttemp(tmp);
        }
        private void btn_TemplateCancel_Click(object sender, EventArgs e)
        {
            panl_templates.Visible = false;
            TabControl_SMSCentre.Visible = true;
            txt_Recipients.Visible = true;
            txt_SMS.Visible = true;
            Btn_useTemplates.Visible = true;
            btn_SendSMS.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
        }
        private void btn_addtemplateCancel_Click(object sender, EventArgs e)
        {
            Panl_AddTemplate.Visible = false;
            panl_templates.Visible = true;
            DGV_SMSTemplates.Visible = true;
            TabControl_SMSCentre.Visible = false;
        }
        private void btn_save_template_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (txt_AddTemplates.Text != "")
                {
                    i = this.ctrlr.Save(txt_AddTemplates.Text);
                    if (i > 0)
                    {
                        txt_AddTemplates.Text = "";
                        DataTable dtb = this.ctrlr.selecttemp();
                        selecttemp(dtb);
                    }
                    else
                    {
                        MessageBox.Show("Enter templates", "Add templates ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DGV_SMSTemplates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                txt_SMS.Text = DGV_SMSTemplates.Rows[e.RowIndex].Cells["colName"].Value.ToString();
            }
        }
        public void upfollowup(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int l = 0;
                    while (l < dt.Rows.Count)
                    {
                        DGV_upcoming_followups.Rows.Add();
                        DGV_upcoming_followups.Rows[l].Cells[0].Value = dt.Rows[l][0].ToString();
                        DGV_upcoming_followups.Rows[l].Cells[1].Value = dt.Rows[l][1].ToString();
                        DGV_upcoming_followups.Rows[l].Cells[3].Value = dt.Rows[l][3].ToString();
                        DGV_upcoming_followups.RowsDefaultCellStyle.ForeColor = Color.Black;
                        DGV_upcoming_followups.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                        l++;
                    }
                    if (DGV_upcoming_followups.Rows.Count > 0)
                    {
                        DGV_upcoming_followups.CurrentCell.Selected = false;
                    }
                }
                else
                {
                    Lab_Tabpg2MSG.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void upbirthday(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Lab_Tabpg2MSG.Visible = false;
                    int l = 0;
                    while (l < dt.Rows.Count)
                    {
                        DGV_upcoming_birthday.Rows.Add();
                        DGV_upcoming_birthday.Rows[l].Cells[0].Value = dt.Rows[l][0].ToString();
                        DGV_upcoming_birthday.Rows[l].Cells[1].Value = dt.Rows[l][1].ToString();
                        DGV_upcoming_birthday.Rows[l].Cells[2].Value = dt.Rows[l][2].ToString();
                        DGV_upcoming_birthday.Rows[l].Cells[3].Value = dt.Rows[l][3].ToString();
                        DGV_upcoming_birthday.Rows[l].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                        DGV_upcoming_birthday.Rows[l].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                        l++;
                    }
                    if (DGV_upcoming_birthday.Rows.Count > 0)
                    {
                        DGV_upcoming_birthday.CurrentCell.Selected = false;
                    }
                }
                else
                {
                    Lab_Tabpg2MSG.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_SendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txt_SMS.Text))
                {
                    MessageBox.Show("Please enter Message....!!", "Message Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(txt_Recipients.Text))
                    {
                        MessageBox.Show("Please enter Mobile number(s)....!!", "Number Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DataTable snd = this.ctrlr.selsms();
                        selsms(snd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_UpcomingFollowups_Click(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = DTP_Tab2From.Value.ToShortDateString();
                var dateTo = DTP_Tab2TO.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than to date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DTP_Tab2From.Value = DateTime.Today;
                    return;
                }
                DGV_upcoming_birthday.Hide();
                DGV_upcoming_followups.Rows.Clear();
                DGV_upcoming_followups.Visible = true;
                DGV_upcoming_followups.Height = 591;
                DGV_upcoming_followups.Height = 798;
                dgvtempNew.Visible = false;
                Btn_birthSMS.Visible = false;
                Lab_Tabpg2MSG.Visible = false;
                DataTable follow = this.ctrlr.upfollowup(DTP_Tab2From.Value.Date.ToString("yyyy-MM-dd"), DTP_Tab2TO.Value.Date.ToString("yyyy-MM-dd"));
                upfollowup(follow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_UpcommingBirthday_Click(object sender, EventArgs e)
        {
            try
            {
                var dateFrom = DTP_Tab2From.Value.ToShortDateString();
                var dateTo = DTP_Tab2TO.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than to date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DTP_Tab2From.Value = DateTime.Today;
                    return;
                }
                DGV_upcoming_followups.Visible = false;
                DGV_upcoming_birthday.Visible = true;
                Btn_birthSMS.Visible = true;
                dgvtempNew.Visible = true;
                dgvtempNew.Rows.Clear();
                Lab_Tabpg2MSG.Visible = false;
                DGV_upcoming_birthday.Rows.Clear();
                DataTable brth = this.ctrlr.upbirthday(DTP_Tab2From.Value.Month.ToString(), DTP_Tab2From.Value.Day.ToString(), DTP_Tab2TO.Value.Month.ToString(), DTP_Tab2TO.Value.Day.ToString());
                upbirthday(brth);
                DataTable brthtmp = this.ctrlr.birthdaytemp();
                birthdaytemp(brthtmp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void birthdaytemp(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int t2 = 0;
                    dgvtempNew.RowCount = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        dgvtempNew.Rows.Add();
                        dgvtempNew.Rows[t2].Cells[0].Value = dr["id"].ToString();
                        dgvtempNew.Rows[t2].Cells[1].Value = dr["template"].ToString();
                        t2++;
                        dgvtempNew.RowsDefaultCellStyle.ForeColor = Color.Black;
                        dgvtempNew.RowsDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                    }
                    dgvtempNew.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    dgvtempNew.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgvtempNew.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    dgvtempNew.EnableHeadersVisualStyles = false;
                    foreach (DataGridViewColumn cln in dgvtempNew.Columns)
                    {
                        cln.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TabControl_SMSCentre_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TabControl_SMSCentre.SelectedIndex)
            {
                case 0:
                    {
                        tabstatus = 0;
                        txt_Recipients.Text = "";
                        txt_searchPatient.Text = "";
                        txt_SMS.Text = "";
                        foreach (DataGridViewRow row in DGV_Staff.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        foreach (DataGridViewRow row in dgv_Group.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        break;
                    }
                case 1:
                    {
                        tabstatus = 1;
                        txt_SMS.Text = "";
                        txt_Recipients.Text = "";
                        txt_searchPatient.Text = "";
                        foreach (DataGridViewRow row in DGV_Staff.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        foreach (DataGridViewRow row in DGV_Patient.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        break;
                    }
                case 2:
                    {
                        tabstatus = 2;
                        txt_SMS.Text = "";
                        txt_Recipients.Text = "";
                        txt_searchPatient.Text = "";
                        foreach (DataGridViewRow row in dgv_Group.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        foreach (DataGridViewRow row in DGV_Patient.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        break;
                    }
            }
        }
        private void Btn_birthSMS_Click(object sender, EventArgs e)
        {
            DataTable sm = this.ctrlr.selsms();
            selsms(sm);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        tabstatus1 = 0;
                        txt_Sendsms.Text = "";
                        txtFailedSms.Text = "";
                        DGV_transactional.Rows.Clear();
                        DGV_upcoming_birthday.Rows.Clear();
                        DGV_upcoming_followups.Rows.Clear();
                        DTP_DateFrom.Text = DateTime.Now.Date.ToString();
                        DTP_DateTo.Text = DateTime.Now.Date.ToString();
                        DTP_Tab2From.Text = DateTime.Now.Date.ToString();
                        DTP_Tab2TO.Text = DateTime.Now.Date.ToString();
                        break;
                    }
                case 1:
                    {
                        tabstatus1 = 1;
                        txt_Recipients.Text = "";
                        txt_searchPatient.Text = "";
                        DGV_upcoming_birthday.Rows.Clear();
                        DGV_upcoming_followups.Rows.Clear();
                        foreach (DataGridViewRow row in DGV_Patient.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        DTP_Tab2From.Text = DateTime.Now.Date.ToString();
                        DTP_Tab2TO.Text = DateTime.Now.Date.ToString();
                        break;
                    }
                case 2:
                    {
                        tabstatus1 = 2;
                        txt_Recipients.Text = "";
                        txt_searchPatient.Text = "";
                        txt_Sendsms.Text = "";
                        txtFailedSms.Text = "";
                        DTP_DateFrom.Text = DateTime.Now.Date.ToString();
                        DTP_DateTo.Text = DateTime.Now.Date.ToString();
                        foreach (DataGridViewRow row in DGV_Patient.Rows)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[3];
                            chk.Value = false;
                        }
                        DGV_transactional.Rows.Clear();
                        break;
                    }
            }
        }
        private void dgvtempNew_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvtempNew.Rows.Count > 0)
            {
                template = dgvtempNew.CurrentRow.Cells["Templates"].Value.ToString();
            }
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                System.Drawing.Font TabFont;
                Brush BackBrush = new SolidBrush(Color.Transparent);
                Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);
                if (e.Index == this.tabControl1.SelectedIndex)
                {
                    TabFont = new System.Drawing.Font(e.Font, FontStyle.Italic);
                }
                else
                {
                    TabFont = e.Font;
                }
                string TabName = this.tabControl1.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                e.Graphics.FillRectangle(BackBrush, e.Bounds);
                System.Drawing.Rectangle r = e.Bounds;
                r = new System.Drawing.Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
                sf.Dispose();
                if (e.Index == this.tabControl1.SelectedIndex)
                {
                    TabFont.Dispose();
                    BackBrush.Dispose();
                }
                else
                {
                    BackBrush.Dispose();
                    ForeBrush.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TabControl_SMSCentre_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                System.Drawing.Font TabFont;
                Brush BackBrush = new SolidBrush(Color.Transparent);
                Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);
                if (e.Index == this.TabControl_SMSCentre.SelectedIndex)
                {
                    TabFont = new System.Drawing.Font(e.Font, FontStyle.Italic);
                }
                else
                {
                    TabFont = e.Font;
                }
                string TabName = this.TabControl_SMSCentre.TabPages[e.Index].Text;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                e.Graphics.FillRectangle(BackBrush, e.Bounds);
                System.Drawing.Rectangle r = e.Bounds;
                r = new System.Drawing.Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
                e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
                sf.Dispose();
                if (e.Index == this.TabControl_SMSCentre.SelectedIndex)
                {
                    TabFont.Dispose();
                    BackBrush.Dispose();
                }
                else
                {
                    BackBrush.Dispose();
                    ForeBrush.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.ctrlr.frmInventory(doctor_id);
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
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
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
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.permission_for_settings(doctor_id);
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
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dtb = this.ctrlr.Patient_search(toolStripTextBox1.Text);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 350, -2);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }
    }
}

