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
    public partial class dentalwork : Form
    {
        public dentalwork()
        {
            InitializeComponent();
        }
        Dentalwork_controller ctrlr=new Dentalwork_controller();
        public string patient_id = "", doctor_id = "", workid = "", flag = "", strclinic = "", contact_no = "", clinicn = "", mob_number = "", strPatientName = "",smsName = "", smsPass = "";
        private void dentalwork_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable lab = this.ctrlr.labdata();
                cmblabname.DataSource = lab;
                cmblabname.DisplayMember = "labname";
                cmblabname.ValueMember = "id";
                DataTable den = this.ctrlr.dentalwrk(patient_id, workid);
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
                DataTable dentalproperty = this.ctrlr.dentalproperty(patient_id, txtjobno.Text);
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
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                DataTable clinicname=this.ctrlr.practicedetails();
                if (clinicname.Rows.Count > 0)
                {
                    clinicn = clinicname.Rows[0][0].ToString();
                    strclinic = clinicn.Replace("¤", "'");
                    contact_no = clinicname.Rows[0][2].ToString();
                }
                DataTable rs_patients=this.ctrlr.Get_Patient_Details(patient_id);
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    strPatientName = rs_patients.Rows[0]["pt_name"].ToString();
                    mob_number = "91" + rs_patients.Rows[0]["primary_mobile_number"].ToString();
                }
                DataTable smstb=this.ctrlr.smsinfo();
                if (smstb.Rows.Count > 0)
                {
                    smsName = smstb.Rows[0]["smsName"].ToString();
                    smsPass = smstb.Rows[0]["smsPass"].ToString();
                }
                if (smsName != "" && smsPass != "")
                {
                    
                    string res = this.ctrlr.SendSMS(smsName, smsPass, mob_number, "Dear " + strPatientName + ", Your dental lab work [Tooth:" + txttooth.Text + "]  deliver  on " + Convert.ToDateTime(dateTimePickerdue.Text).ToString("dd MMM yyyy") + " @ " + strclinic + "," + contact_no);
                    if (res == "SMS message(s) sent")
                    { MessageBox.Show("SMS send successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.None); }
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
