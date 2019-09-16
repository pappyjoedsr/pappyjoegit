using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class dentalwork : Form,dentalwork_interface
    {
        public dentalwork()
        {
            InitializeComponent();
        }
        dentalwork_controller ctrlr;
        public string patient_id = "", doctor_id = "", workid = "", flag = "", strclinic = "", contact_no = "", clinicn = "", mob_number = "", strPatientName = "",smsName = "", smsPass = "";
        private void dentalwork_Load(object sender, EventArgs e)
        {
            this.ctrlr.labdata();
            this.ctrlr.dentalwrk(patient_id, workid);
            this.ctrlr.dentalproperty(patient_id, txtjobno.Text);
        }
        public void setController(dentalwork_controller controller)
        {
            ctrlr = controller;
        }
        private void btnSaveorder_Click(object sender, EventArgs e)
        {
            try
            {
                int j = this.ctrlr.labupdate(cmblabname.Text, Convert.ToDateTime(dateTimePickerassgndate.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(dateTimePickerdue.Text).ToString("yyyy-MM-dd"), patient_id, txtjobno.Text);
                if (j > 0)
                {
                    MessageBox.Show("Order sent Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnsms_Click(object sender, EventArgs e)
        {
            try
            {
                this.ctrlr.practicedetails();
                this.ctrlr.Get_Patient_Details(patient_id);
                this.ctrlr.smsinfo();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void labdata(DataTable lab)
        {
            try
            {
                cmblabname.DataSource = lab;
                cmblabname.DisplayMember = "labname";
                cmblabname.ValueMember = "id";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void dentalwrk(DataTable den)
        {
            try
            {
                if (den.Rows.Count > 0)
                {
                    txtjobno.Text = den.Rows[0][0].ToString();
                    txtWorkname.Text = den.Rows[0][2].ToString();
                    if (den.Rows[0]["labname"].ToString() != "")
                    {
                        cmblabname.Text = den.Rows[0]["labname"].ToString();
                    }
                    if (den.Rows[0]["assign_date"].ToString() != "")
                    {
                        dateTimePickerassgndate.Value = Convert.ToDateTime(den.Rows[0]["assign_date"].ToString());
                    }
                    if (den.Rows[0]["duedate"].ToString() != "")
                    {
                        dateTimePickerdue.Value = Convert.ToDateTime(den.Rows[0]["duedate"].ToString());
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void dentalproperty(DataTable dentalproperty)
        {
            try
            {
                if (dentalproperty.Rows.Count > 0)
                {
                    txttooth.Text = dentalproperty.Rows[0][0].ToString();
                    txtAloytype.Text = dentalproperty.Rows[0][1].ToString();
                    txtShade.Text = dentalproperty.Rows[0][2].ToString();
                    txtWorktype.Text = dentalproperty.Rows[0][3].ToString();
                }
                if (flag == "1")
                {
                    btnSaveorder.Visible = false;
                    btnCancel.Text = "OK";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void practicedetails(DataTable clinicname)
        {
            if (clinicname.Rows.Count > 0)
            {
                clinicn = clinicname.Rows[0][0].ToString();
                strclinic = clinicn.Replace("¤", "'");
                contact_no = clinicname.Rows[0][2].ToString();
            }
        }
        public void Get_Patient_Details(DataTable rs_patients)
        {
            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
            {
                strPatientName = rs_patients.Rows[0]["pt_name"].ToString();
                mob_number = "91" + rs_patients.Rows[0]["primary_mobile_number"].ToString();
            }
        }
        public void smsinfo(DataTable smstb)
        {
            try
            {
                if (smstb.Rows.Count > 0)
                {
                    smsName = smstb.Rows[0]["smsName"].ToString();
                    smsPass = smstb.Rows[0]["smsPass"].ToString();
                }
                if (smsName != "" && smsPass != "")
                {
                    sms_model send_sms_class = new sms_model();
                    string res = send_sms_class.SendSMS(smsName, smsPass, mob_number, "Dear " + strPatientName + ", Your dental lab work [Tooth:" + txttooth.Text + "]  deliver  on " + Convert.ToDateTime(dateTimePickerdue.Text).ToString("dd MMM yyyy") + " @ " + strclinic + "," + contact_no);
                    if (res == "SMS message(s) sent")
                    { MessageBox.Show("SMS send successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.None); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
