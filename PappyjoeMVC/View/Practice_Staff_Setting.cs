using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Practice_Staff_Setting : Form
    {
        Staff_controller cntrl = new Staff_controller();
        public string idd = "";
        int status_pre = 0;
        DataTable dt_mail = new DataTable();
        public string dr_id = "1"; string userid = "";
        public bool flag_mail = false; string id = "";
        public string status = "No";
        string calendrcolor = "0";
        public Practice_Staff_Setting()
        {
            InitializeComponent();
        }
        private void Practice_Staff_Setting_Load(object sender, EventArgs e)
        {
            try
            {
                tabControl1.Controls.Remove(tabPage3);
                if (chkPATadd.Checked == true && chkPATedit.Checked == true && chkPATdelete.Checked == true)
                {
                    chkPAT.Checked = true;
                }
                else
                {
                    chkPAT.Checked = false;
                }
                if (chkAPTadd.Checked == true && chkAPTedit.Checked == true && chkAPTdelete.Checked == true)
                {
                    chkAPT.Checked = true;
                }
                else
                {
                    chkAPT.Checked = false;
                }
                if (chkPMTadd.Checked == true)
                {
                    chkPMT.Checked = true;
                }
                else
                {
                    chkPMT.Checked = false;
                }
                DataTable dtb = this.cntrl.Fill_StaffGrid();
                FillStaffGrid(dtb);
                panel_color.Hide();
                dataGridView_Staff.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView_Staff.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView_Staff.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridView_Staff.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView_Staff.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView_notification.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView_notification.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView_notification.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridView_notification.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView_notification.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView_users.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView_users.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView_users.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridView_users.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView_users.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                DataTable d1 = this.cntrl.Get_DoctorId(dr_id);
                if (d1.Rows.Count > 0)
                {
                    if (d1.Rows[0]["login_type"].ToString() == "admin")
                    {
                        button__manage_addoctor.Show();
                        status_pre = 1;
                    }
                    else
                    {
                        tabPage4.Hide();
                        button__manage_addoctor.Hide();
                        status_pre = 0;
                    }
                }
                RefreshCheckboxes();
                cmbStaffType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void FillStaffGrid(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    int i = 0;
                    dataGridView_Staff.Rows.Clear();
                    foreach (DataRow dr in dtb.Rows)
                    {
                        dataGridView_Staff.Rows.Add();
                        dataGridView_Staff.Rows[i].Cells["S_ID"].Value = dr["id"].ToString();
                        dataGridView_Staff.Rows[i].Cells["Doctor_Name"].Value = dr["doctor_name"].ToString();
                        dataGridView_Staff.Rows[i].Cells["Mobile_Number"].Value = dr["mobile_number"].ToString();
                        dataGridView_Staff.Rows[i].Cells["Role"].Value = dr["login_type"].ToString();
                        dataGridView_Staff.Rows[i].Cells["Activated_Login"].Value = dr["activate_login"].ToString();
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_Staff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dataGridView_Staff.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView_Staff.CurrentCell.ColumnIndex == 4)
                {
                    string Active_Login = dataGridView_Staff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    if (Active_Login == "Yes")
                    {
                        DialogResult res;
                        if (dataGridView_Staff.Rows[e.RowIndex].Cells["Role"].Value.ToString() == "doctor")
                        {
                            res = MessageBox.Show("Are you sure you want to Deactivate this Doctor?", "Deactivation confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        else
                        {
                            res = MessageBox.Show("Are you sure you want to Deactivate this Staff?", "Deactivation confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        if (res == DialogResult.Yes)
                        {
                            dataGridView_Staff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "No";
                            this.cntrl.Update_Login(id);
                        }
                    }
                    if (Active_Login == "No")
                    {
                        DialogResult res;
                        if (dataGridView_Staff.Rows[e.RowIndex].Cells["Role"].Value.ToString() == "doctor")
                        {
                            res = MessageBox.Show("Are you sure you want to Activate this Doctor?", "Activation confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        else
                        {
                            res = MessageBox.Show("Are you sure you want to Activate this Staff?", "Activation confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                        if (res == DialogResult.Yes)
                        {
                            dataGridView_Staff.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Yes";
                            this.cntrl.update_loginstatus_Yes(id);
                        }
                    }
                }
                if (e.RowIndex >= 0)
                {
                    if (dataGridView_Staff.CurrentCell.OwningColumn.Name == "Edit")
                    {
                        id = dataGridView_Staff.Rows[e.RowIndex].Cells[0].Value.ToString();
                        var form2 = new Doctor_Profile();
                        form2.doctor_id = id;
                        form2.doc = id;
                        form2.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.Fill_StaffGrid();
            FillStaffGrid(dtb);
        }
        //notification
        public void refresh()
        {
            button_refresh.Hide();
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn()
            {
                Name = "Confirm sms"
            };
            dataGridView_notification.Columns.Add(col);
            col.Width = 100;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn()
            {
                Name = "Schedule sms"
            };
            dataGridView_notification.Columns.Add(col1);
            col1.Width = 100;
            col1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCheckBoxColumn col2 = new DataGridViewCheckBoxColumn()
            {
                Name = "Confirm email"
            };
            dataGridView_notification.Columns.Add(col2);
            col2.Width = 100;
            col2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCheckBoxColumn col3 = new DataGridViewCheckBoxColumn()
            {
                Name = "Schedule email"
            };
            dataGridView_notification.Columns.Add(col3);
            col3.Width = 100;
            col3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataTable dtb = this.cntrl.Get_DctrDetails();
            GetDctrDetails(dtb);
            DataTable dtb1 = this.cntrl.GetDctr_notificationvalue();
            GetNotificationData(dtb1);
        }
        public void GetDctrDetails(DataTable dtb)
        {
            dataGridView_notification.DataSource = null;
            if (dtb.Rows.Count > 0)
            {
                dataGridView_notification.DataSource = dtb;
            }
        }
        public void GetNotificationData(DataTable dt4)
        {
            try
            {
                if (dt4.Rows.Count > 0)
                {
                    for (int i = 0; i < dt4.Rows.Count; i++)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row = dataGridView_notification.Rows[i];
                        string confirmsms = dt4.Rows[i][2].ToString();
                        if (confirmsms == "1")
                        {
                            row.Cells[0].Value = true;
                        }
                        else
                        {
                            row.Cells[0].Value = false;
                        }
                        string schedulesms = dt4.Rows[i][3].ToString();
                        if (schedulesms == "1")
                        {
                            row.Cells[1].Value = true;
                        }
                        else
                        {
                            row.Cells[1].Value = false;
                        }
                        string confirmemail = dt4.Rows[i][4].ToString();
                        if (confirmemail == "1")
                        {
                            row.Cells[2].Value = true;
                        }
                        else
                        {
                            row.Cells[2].Value = false;
                        }
                        string schedemail = dt4.Rows[i][5].ToString();
                        if (schedemail == "1")
                        {
                            row.Cells[3].Value = true;
                        }
                        else
                        {
                            row.Cells[3].Value = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (button_refresh.Visible == true)
                {
                    refresh();
                }
            }
            else if (tabControl1.SelectedIndex == 3)
            {
                if (status_pre == 1)//Admin User only
                {
                    DataTable dtUserprivilege = this.cntrl.User_privillage();
                    dataGridView_users.DataSource = dtUserprivilege;
                    dataGridView_users.ClearSelection();
                }
                else
                {
                    this.tabControl1.TabPages[3].Dispose();
                }
            }
        }

        private void button_notification_Save_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView_notification.Rows.Count; i++)
                {
                    DataTable dt_dctrId = this.cntrl.Doctr_id();
                    string idd = dt_dctrId.Rows[i][0].ToString();
                    string name = dt_dctrId.Rows[i][1].ToString();
                   
                    if (Convert.ToBoolean(dataGridView_notification.Rows[i].Cells[0].Value) == true)
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.Update_notification(dt_notification, idd);
                        }
                        else
                        {
                            this.cntrl.Save_Notification(idd);
                        }
                    }
                    else// if checkbox1 confirm sms not checked
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_confirm_sms(dt_notification, idd);
                        }
                    }
                    if (Convert.ToBoolean(dataGridView_notification.Rows[i].Cells[1].Value) == true) // for second checkbox schedule sms
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_shedule_sms1(dt_notification, idd);
                        }
                        else
                        {
                            this.cntrl.save_shedule_sms(idd);
                        }
                    }
                    else
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_shedule_sms0(dt_notification, idd);
                        }
                    }
                    if (Convert.ToBoolean(dataGridView_notification.Rows[i].Cells[2].Value) == true)// for checkbox 3 confirm email
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_confirm_email1(dt_notification, idd);
                        }
                        else
                        {
                            this.cntrl.save_confirm_email(idd);
                        }
                    }
                    else
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_confirmemail0(dt_notification, idd);
                        }
                    }
                    if (Convert.ToBoolean(dataGridView_notification.Rows[i].Cells[3].Value) == true)// checkbox 4 schedule email
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_shedule_email1(dt_notification, idd);
                        }
                        else
                        {
                            this.cntrl.save_shedule_email(idd);
                        }
                    }
                    else
                    {
                        DataTable dt_doc = this.cntrl.Get_Doctor_notification(idd);
                        if (dt_doc.Rows.Count > 0)
                        {
                            DataTable dt_notification = this.cntrl.ifexsists_dctrnotification(idd);
                            this.cntrl.update_shedule_email0(dt_notification, idd);
                        }
                    }
                }
                MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush BackBrush = new SolidBrush(Color.Transparent);
            Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);
            TabPage page = tabControl1.TabPages[e.Index];
            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
            //Rasmi User privilege
            if (status_pre == 1)//Admin User only
            {
                if (e.Index == 2)//User Privilege tab page fill- becoz 1 & 2 Remove, Automaticaly rearranged index 3 to 1 
                {
                    DataTable dtUserprivilege = this.cntrl.User_privillage();
                    dataGridView_users.DataSource = dtUserprivilege;
                    dataGridView_users.ClearSelection();
                }
            }
            else if (e.Index == 3)
            {
                this.tabControl1.TabPages[3].Dispose();
            }
            //user privilege code ends here
        }

        private void btnAssignPrivilege_Click(object sender, EventArgs e)
        {
            if (userid == "")
            {
                MessageBox.Show("Select a User !!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string strvalue = "";
                if (chkAPTadd.Checked == false)
                    strvalue = ",('" + userid + "','APT','A')";//Add permission for appointment section
                if (chkAPTedit.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','APT','E')";//Edit permission for appointment section
                if (chkAPTdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','APT','D')";//Delete permission for appointment section
                if (chkAPTClinicAppoinment.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','APT','AP')";
                if (chkPATadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','PAT','A')";//Add permission for Patient section
                if (chkPATedit.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','PAT','E')";//Edit permission for Patient section
                if (chkPATdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','PAT','D')";//Delete permission for Patient section
                if (chkPMTadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','PMT','A')";//Add permission for Payment section
                if (chkCLMSadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','CLMS','A')";//Add permission for Clinic Management setting section
                if (chkEMRCFadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRCF','A')";//Add permission for EMR Clinical Finding  section
                if (chkEMRCFedit.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRCF','E')";//Edit permission for  EMR Clinical Finding section
                if (chkEMRCFdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRCF','D')";//Delete permission for  EMR Clinical Finding section
                if (chkEMRTPadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRTP','A')";//Add permission for EMR Treatment Plans section
                if (chkEMRTPedit.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRTP','E')";//Edit permission for  EMR Treatment Plans  section
                if (chkEMRTPdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRTP','D')";//Delete permission for  EMR  Treatment Plans section
                if (chkEMRFPadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRFP','A')";//Add permission for EMR  Finished Procedure  section
                if (chkEMRFPdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRFP','D')";//Delete permission for  EMR  Finished Procedure section
                if (chkEMRFadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRF','A')";//Add permission for EMR Files  section
                if (chkEMRPadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRP','A')";//Add permission for EMR Prescription  section
                if (chkEMRPedit.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRP','E')";//Edit permission for  EMR Prescription section
                if (chkEMRPdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRP','D')";//Delete permission for  EMR Prescription section
                if (chkEMRIadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRI','A')";//Add permission for EMR Invoice  section
                if (chkEMRIedit.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRI','E')";//Edit permission for  EMR Invoice section
                if (chkEMRIdelete.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','EMRI','D')";//Delete permission for  EMR Invoice section
                if (chkRPTDSadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTDS','A')";//Add permission for Report Section Daily Summary  section
                if (chkRPTINCadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTINC','A')";//Add permission for Report Section Income  section
                if (chkRPTPAYadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTPAY','A')";//Add permission for Report Section Payment  section
                if (chkRPTAPTadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTAPT','A')";//Add permission for Report Section Appointment  section
                if (chkRPTPATadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTPAT','A')";//Add permission for Report Section Patient  section
                if (chkRPTEXPadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTEXP','A')";//Add permission for Report Section Expenses  section
                if (chkRPTINVadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTINV','A')";//Add permission for Report Section Inventory  section
                if (chkRPTIncom.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTINCM','A')";
                if (chkRPTEMRadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','RPTEMR','A')";//Add permission for Report Section EMR  section
                if (chkINVAIadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVAI','A')";//Add permission for Inventory Add Item  section
                if (chkINVASadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVAS','A')";//Add permission for Inventory Add Stock  section
                if (chkINVCSadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVCS','A')";//Add permission for Inventory Consume Stock  section
                if (chkINVPIadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVPI','A')";//Add permission for Inventory Print Items section
                if (chkINVVSadd.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVVS','A')";//Add permission for Inventory View Stock section
                if (chkInvenSale.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVSALE','A')";//Add permission for Inventory View Stock section
                if (chkInventory.Checked == false)
                    strvalue = strvalue + ",('" + userid + "','INVENTORY','A')";
                this.cntrl.delete_userprivillage(userid);
                if (strvalue != "")
                {
                    string strvalue1 = "";
                    strvalue1 = strvalue.Substring(1, strvalue.Length - 1);
                    this.cntrl.save_userprivillage(strvalue1);
                }
                MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ", Select Privileges and  Try Again !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dataGridView_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            userid = dataGridView_users.Rows[r].Cells[0].Value.ToString();
        }
        //user privillage
        private void RefreshCheckboxes()
        {
            chkAPT.Checked = true;
            chkAPTadd.Checked = true;
            chkAPTedit.Checked = true;
            chkAPTdelete.Checked = true;
            chkAPTClinicAppoinment.Checked = true;
            chkPAT.Checked = true;
            chkPATadd.Checked = true;
            chkPATedit.Checked = true;
            chkPATdelete.Checked = true;
            chkPMT.Checked = true;
            chkPMTadd.Checked = true;
            chkCLMSadd.Checked = true;
            chkEMR.Checked = true;
            chkEMRCF.Checked = true;
            chkEMRF.Checked = true;
            chkEMRFP.Checked = true;
            chkEMRP.Checked = true;
            chkEMRTP.Checked = true;
            chkEMRCFadd.Checked = true;
            chkEMRCFedit.Checked = true;
            chkEMRCFdelete.Checked = true;
            chkEMRFadd.Checked = true;
            chkEMRI.Checked = true;
            chkEMRIadd.Checked = true;
            chkEMRIdelete.Checked = true;
            chkEMRIedit.Checked = true;
            chkEMRFPadd.Checked = true;
            chkEMRFPdelete.Checked = true;
            chkEMRPadd.Checked = true;
            chkEMRPedit.Checked = true;
            chkEMRPdelete.Checked = true;
            chkEMRTPadd.Checked = true;
            chkEMRTPedit.Checked = true;
            chkEMRTPdelete.Checked = true;
            chkRPT.Checked = true;
            chkRPTAPTadd.Checked = true;
            chkRPTDSadd.Checked = true;
            chkRPTEMRadd.Checked = true;
            chkRPTEXPadd.Checked = true;
            chkRPTINCadd.Checked = true;
            chkRPTINVadd.Checked = true;
            chkRPTIncom.Checked = true;
            chkRPTPATadd.Checked = true;
            chkRPTPAYadd.Checked = true;
            chkINV.Checked = true;
            chkINVAIadd.Checked = true;
            chkINVASadd.Checked = true;
            chkINVCSadd.Checked = true;
            chkINVPIadd.Checked = true;
            chkINVVSadd.Checked = true;
            chkInvenSale.Checked = true;
            chkInventory.Checked = true;
        }

        private void dataGridView_users_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                userid = dataGridView_users.Rows[r].Cells[0].Value.ToString();
                DataTable dt = this.cntrl.Get_userPrivillageData(userid);
                RefreshCheckboxes();
                SetCheckboxfromDB(dt);
            }
            catch (Exception ex)
            {
            }
        }
        private void SetCheckboxfromDB(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Category"].ToString() == "PAT")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkPATadd.Checked = false;
                    if (dr["Permission"].ToString() == "E")
                        chkPATedit.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkPATdelete.Checked = false;
                    if (chkPATadd.Checked == true || chkPATedit.Checked == true || chkPATdelete.Checked == true)
                    {
                        chkPAT.Checked = true;
                    }
                    else
                    {
                        chkPAT.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "APT")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkAPTadd.Checked = false;
                    if (dr["Permission"].ToString() == "E")
                        chkAPTedit.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkAPTdelete.Checked = false;
                    if (dr["Permission"].ToString() == "AP")
                        chkAPTClinicAppoinment.Checked = false;
                    if (chkAPTadd.Checked == true || chkAPTedit.Checked == true || chkAPTdelete.Checked == true || chkAPTClinicAppoinment.Checked == true)
                    {
                        chkAPT.Checked = true;
                    }
                    else
                    {
                        chkAPT.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "PMT")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkPMTadd.Checked = false;
                    if (chkPMTadd.Checked == true)
                    {
                        chkPMT.Checked = true;
                    }
                    else
                    {
                        chkPMT.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "CLMS")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkCLMSadd.Checked = false;
                }
                else if (dr["Category"].ToString() == "EMRCF")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkEMRCFadd.Checked = false;

                    if (dr["Permission"].ToString() == "E")
                        chkEMRCFedit.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkEMRCFdelete.Checked = false;
                    if (chkEMRCFadd.Checked == true || chkEMRCFedit.Checked == true || chkEMRCFdelete.Checked == true)
                    {
                        chkEMRCF.Checked = true;
                        chkEMR.Checked = true;
                    }
                    else
                    {
                        chkEMRCF.Checked = false;
                        chkEMR.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "EMRTP")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkEMRTPadd.Checked = false;
                    if (dr["Permission"].ToString() == "E")
                        chkEMRTPedit.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkEMRTPdelete.Checked = false;
                    if (chkEMRTPadd.Checked == true || chkEMRTPedit.Checked == true || chkEMRTPdelete.Checked == true)
                    {
                        chkEMRTP.Checked = true;
                        chkEMR.Checked = true;
                    }
                    else
                    {
                        chkEMRTP.Checked = false;
                        chkEMR.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "EMRFP")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkEMRFPadd.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkEMRFPdelete.Checked = false;
                    if (chkEMRFPadd.Checked == true || chkEMRFPdelete.Checked == true)
                    {
                        chkEMRFP.Checked = true;
                        chkEMR.Checked = true;
                    }
                    else
                    {
                        chkEMRFP.Checked = false;
                        chkEMR.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "EMRF")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkEMRFadd.Checked = false;
                    if (chkEMRFadd.Checked == true)
                    {
                        chkEMRF.Checked = true;
                    }
                    else
                    {
                        chkEMRF.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "EMRP")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkEMRPadd.Checked = false;
                    if (dr["Permission"].ToString() == "E")
                        chkEMRPedit.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkEMRPdelete.Checked = false;
                    if (chkEMRPadd.Checked == true || chkEMRPedit.Checked == true || chkEMRPdelete.Checked == true)
                    {
                        chkEMRP.Checked = true;
                        chkEMR.Checked = true;
                    }
                    else
                    {
                        chkEMRP.Checked = false;
                        chkEMR.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "EMRI")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkEMRIadd.Checked = false;
                    if (dr["Permission"].ToString() == "E")
                        chkEMRIedit.Checked = false;
                    if (dr["Permission"].ToString() == "D")
                        chkEMRIdelete.Checked = false;
                    if (chkEMRIadd.Checked == true || chkEMRIedit.Checked == true || chkEMRIdelete.Checked == true)
                    {
                        chkEMRI.Checked = true;
                        chkEMR.Checked = true;
                    }
                    else
                    {
                        chkEMRI.Checked = false;
                        chkEMR.Checked = false;
                    }
                }
                else if (dr["Category"].ToString() == "RPTDS")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTDSadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTINC")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTINCadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTINCM")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTIncom.Checked = false;
                    chkRPT.Checked = false;
                }

                else if (dr["Category"].ToString() == "RPTPAY")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTPAYadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTAPT")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTAPTadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTPAT")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTPATadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTEXP")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTEXPadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTINV")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTINVadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "RPTEMR")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkRPTEMRadd.Checked = false;
                    chkRPT.Checked = false;
                }
                else if (dr["Category"].ToString() == "INVAI")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkINVAIadd.Checked = false;
                    chkINV.Checked = false;
                }
                else if (dr["Category"].ToString() == "INVAS")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkINVASadd.Checked = false;

                }
                else if (dr["Category"].ToString() == "INVCS")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkINVCSadd.Checked = false;
                }
                else if (dr["Category"].ToString() == "INVPI")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkINVPIadd.Checked = false;
                }
                else if (dr["Category"].ToString() == "INVVS")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkINVVSadd.Checked = false;
                }
                else if (dr["Category"].ToString() == "INVSALE")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkInvenSale.Checked = false;
                }
                else if (dr["Category"].ToString() == "INVENTORY")
                {
                    if (dr["Permission"].ToString() == "A")
                        chkInventory.Checked = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView_users.ClearSelection();
            RefreshCheckboxes();
        }

        private void chkPAT_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkPAT.Checked == true)
            {
                chkPATadd.Checked = true;
                chkPATedit.Checked = true;
                chkPATdelete.Checked = true;
            }
            else
            {
                chkPATadd.Checked = false;
                chkPATedit.Checked = false;
                chkPATdelete.Checked = false;
            }
        }

        private void chkAPT_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkAPT.Checked == true)
            {
                chkAPTadd.Checked = true;
                chkAPTedit.Checked = true;
                chkAPTdelete.Checked = true;
                chkAPTClinicAppoinment.Checked = true;
            }
            else
            {
                chkAPTadd.Checked = false;
                chkAPTedit.Checked = false;
                chkAPTdelete.Checked = false;
                chkAPTClinicAppoinment.Checked = false;
            }
        }

        private void chkPMT_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkPMT.Checked == true)
            {
                chkPMTadd.Checked = true;
            }
            else
            {
                chkPMTadd.Checked = false;
            }
        }

        private void chkEMR_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMR.Checked == true)
            {
                chkEMRCF.Checked = true;
                chkEMRTP.Checked = true;
                chkEMRP.Checked = true;
                chkEMRFP.Checked = true;
                chkEMRF.Checked = true;
                chkEMRI.Checked = true;
            }
            else
            {
                chkEMRCF.Checked = false;
                chkEMRTP.Checked = false;
                chkEMRP.Checked = false;
                chkEMRFP.Checked = false;
                chkEMRF.Checked = false;
                chkEMRI.Checked = false;
            }
        }

        private void chkEMRCF_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMRCF.Checked == true)
            {
                chkEMRCFadd.Checked = true;
                chkEMRCFedit.Checked = true;
                chkEMRCFdelete.Checked = true;
            }
            else
            {
                chkEMRCFadd.Checked = false;
                chkEMRCFedit.Checked = false;
                chkEMRCFdelete.Checked = false;
            }
        }

        private void chkEMRTP_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMRTP.Checked == true)
            {
                chkEMRTPadd.Checked = true;
                chkEMRTPedit.Checked = true;
                chkEMRTPdelete.Checked = true;
            }
            else
            {
                chkEMRTPadd.Checked = false;
                chkEMRTPedit.Checked = false;
                chkEMRTPdelete.Checked = false;
            }
        }

        private void chkEMRP_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMRP.Checked == true)
            {
                chkEMRPadd.Checked = true;
                chkEMRPedit.Checked = true;
                chkEMRPdelete.Checked = true;
            }
            else
            {
                chkEMRPadd.Checked = false;
                chkEMRPedit.Checked = false;
                chkEMRPdelete.Checked = false;
            }
        }

        private void chkEMRFP_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMRFP.Checked == true)
            {
                chkEMRFPadd.Checked = true;
                chkEMRFPdelete.Checked = true;
            }
            else
            {
                chkEMRFPadd.Checked = false;
                chkEMRFPdelete.Checked = false;
            }
        }

        private void chkEMRF_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMRF.Checked == true)
            {
                chkEMRFadd.Checked = true;
            }
            else
            {
                chkEMRFadd.Checked = false;
            }
        }

        private void chkEMRI_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkEMRI.Checked == true)
            {
                chkEMRIadd.Checked = true;
                chkEMRIedit.Checked = true;
                chkEMRIdelete.Checked = true;
            }
            else
            {
                chkEMRIadd.Checked = false;
                chkEMRIedit.Checked = false;
                chkEMRIdelete.Checked = false;
            }
        }

        private void chkRPT_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkRPT.Checked == true)
            {
                chkRPTDSadd.Checked = true;
                chkRPTAPTadd.Checked = true;
                chkRPTPATadd.Checked = true;
                chkRPTPAYadd.Checked = true;
                chkRPTINCadd.Checked = true;
                chkRPTEMRadd.Checked = true;
                chkRPTINVadd.Checked = true;
                chkRPTEXPadd.Checked = true;
                chkRPTIncom.Checked = true;
            }
            else
            {
                chkRPTDSadd.Checked = false;
                chkRPTAPTadd.Checked = false;
                chkRPTPATadd.Checked = false;
                chkRPTPAYadd.Checked = false;
                chkRPTINCadd.Checked = false;
                chkRPTEMRadd.Checked = false;
                chkRPTINVadd.Checked = false;
                chkRPTEXPadd.Checked = false;
                chkRPTIncom.Checked = false;
            }
        }

        private void cmbStaffType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbStaffType_MouseLeave(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
        }

        private void cmbStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStaffType.SelectedItem != null)
            {
                errorProvider1.Dispose();
            }
        }

        private void text_doctorname_KeyPress(object sender, KeyPressEventArgs e)
        {
            string arr = "!@#$%^&*()+=-[]0123456789\\\';,./{}|\":<>?";
            for (int k = 0; k < arr.Length; k++)
            {
                if (e.KeyChar == arr[k])
                {
                    e.Handled = true;
                    break;
                }
            }
        }

        private void text_doctorname_TextChanged(object sender, EventArgs e)
        {
            if (text_doctorname.Text != "")
            {
                errorProvider1.Dispose();
                label_doctor_error.Hide();
            }
        }

        private void text_password_TextChanged(object sender, EventArgs e)
        {
            if (text_password.Text != "" && text_PassConfrim.Text != "")
            {
                errorProvider1.Dispose();
                labPasword.Hide();
            }
        }

        private void text_PassConfrim_TextChanged(object sender, EventArgs e)
        {
            if (text_password.Text != "" && text_PassConfrim.Text != "")
            {
                errorProvider1.Dispose();
                labPasword.Hide();
            }
        }

        private void text_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
                errorProvider1.SetError(text_mobile, "error");
            }
            else
            {
                if (text_mobile.TextLength != 10 && text_mobile.Text != "")
                {
                    e.Handled = false;
                    errorProvider1.Dispose();
                }
                else if (text_mobile.TextLength == 10)
                {
                    e.Handled = false;
                    errorProvider1.Dispose();
                    Lab_InvalidNumber.Hide();
                }
            }
        }

        private void text_mobile_Leave(object sender, EventArgs e)
        {
            if (text_mobile.TextLength != 10 && text_mobile.Text != "")
            {
                Lab_InvalidNumber.Visible = true;
                return;
            }
            else
                Lab_InvalidNumber.Visible = false;
        }

        private void text_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider1.Dispose();
            label_email_error.Hide();
        }
        private void text_email_Leave(object sender, EventArgs e)
        {
            string _mail = this.cntrl.GetMailId(text_email.Text);
            if (dt_mail.Rows.Count == 0)
            {
                flag_mail = true;
            }
            else
            {
                flag_mail = false;
            }
        }

        private void radio_login_yes_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            lab_Activation.Hide();
        }

        private void radio_login_no_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            lab_Activation.Hide();
        }

        private void choosecolor_Click(object sender, EventArgs e)
        {
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_color.Show();
            choosecolor.Show();
        }
        private void label57_Click(object sender, EventArgs e)
        {
            calendrcolor = "0";
            Color a = label57.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label58_Click(object sender, EventArgs e)
        {
            calendrcolor = "1";
            Color a = label58.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label59_Click(object sender, EventArgs e)
        {
            calendrcolor = "2";
            Color a = label59.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label60_Click(object sender, EventArgs e)
        {
            calendrcolor = "3";
            Color a = label60.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label61_Click(object sender, EventArgs e)
        {
            calendrcolor = "4";
            Color a = label61.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label62_Click(object sender, EventArgs e)
        {
            calendrcolor = "5";
            Color a = label62.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label56_Click(object sender, EventArgs e)
        {
            calendrcolor = "6";
            Color a = label56.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label63_Click(object sender, EventArgs e)
        {
            calendrcolor = "7";
            Color a = label63.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label64_Click(object sender, EventArgs e)
        {
            calendrcolor = "8";
            Color a = label64.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label65_Click(object sender, EventArgs e)
        {
            calendrcolor = "9";
            Color a = label65.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void label66_Click(object sender, EventArgs e)
        {
            calendrcolor = "10";
            Color a = label66.ForeColor;
            button1.BackColor = a;
            panel_color.Hide();
            choosecolor.Hide();
        }

        private void button__manage_addoctor_Click(object sender, EventArgs e)
        {
            panel_manage.Hide();
            errorProvider1.Dispose();
        }
        private void button_savedoctor_Click(object sender, EventArgs e)
        {
            if (radio_login_no.Checked == true)
            {
                status = "No";
            }
            if (radio_login_yes.Checked == true)
            {
                status = "Yes";
            }
            if (text_password.Text != "" && text_password.Text == text_PassConfrim.Text && flag_mail == true)
            {
                if (radio_login_no.Checked == true || radio_login_yes.Checked == true)
                {
                    this.cntrl.save_staff(text_doctorname.Text, text_mobile.Text, text_email.Text, text_reg_no.Text, calendrcolor, status, cmbStaffType.Text, text_PassConfrim.Text);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    text_doctorname.Clear();
                    text_email.Clear();
                    text_mobile.Clear();
                    text_reg_no.Clear();
                    text_PassConfrim.Clear();
                    text_password.Clear();
                    radio_login_yes.Checked = false;
                    radio_login_no.Checked = false;
                    DataTable dtb = this.cntrl.Fill_StaffGrid();
                    FillStaffGrid(dtb);
                }
                else
                {
                    errorProvider1.SetError(label7, "Choose Yes Or No");
                }
            }
            else if (flag_mail == false)
            {
                MessageBox.Show("Email Id already exist..", "Existed Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Please Confirm the password Correctly..", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_closedoctor_Click(object sender, EventArgs e)
        {
            panel_manage.Show();
            errorProvider1.Dispose();
            DataTable dtb = this.cntrl.Fill_StaffGrid();
            FillStaffGrid(dtb);
        }

        private void Practice_Staff_Setting_Activated(object sender, EventArgs e)
        {
            if (chkPATadd.Checked == true && chkPATedit.Checked == true && chkPATdelete.Checked == true)
            {
                chkPAT.Checked = true;
            }
            else
            {
                chkPAT.Checked = false;
            }
            if (chkAPTadd.Checked == true && chkAPTedit.Checked == true && chkAPTdelete.Checked == true && chkAPTClinicAppoinment.Checked == true)
            {
                chkAPT.Checked = true;
            }
            else
            {
                chkAPT.Checked = false;
            }
            if (chkPMTadd.Checked == true)
            {
                chkPMT.Checked = true;
            }
            else
            {
                chkPMT.Checked = false;
            }
        }
    }
}
