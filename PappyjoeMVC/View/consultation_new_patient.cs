using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net; // For SMS
using System.IO;// For SMS streaming
using PappyjoeMVC.Controller;

namespace PappyjoeMVC.View
{
    public partial class consultation_new_patient : Form
    {
        Consultatio_add_Patient_controller cntrl = new Consultatio_add_Patient_controller();
        string contact_no = "";
        string str_Clinic = "";
        string id = "";
        public consultation_new_patient()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((String.IsNullOrWhiteSpace(txtpatname.Text)) || (String.IsNullOrWhiteSpace(txtmobile.Text)))
            {
                if (String.IsNullOrWhiteSpace(txtpatname.Text))
                {
                    MessageBox.Show("Enter the patient name.. !!", "Data not found.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (String.IsNullOrWhiteSpace(txtmobile.Text))
                {
                    MessageBox.Show("Enter the patient mobile number.. !!", "Data not found.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (txtmobile.TextLength < 10)
                {
                    MessageBox.Show("Enter the valied mobile number.. !!", "Invalied. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string gender = "";
                if (radmail.Checked == true)
                {
                    gender = radmail.Text;
                }
                else
                {
                    gender = radfemail.Text;
                }
                int i = this.cntrl.save_patient(txtpatname.Text, txtPatientId.Text, gender, txtmobile.Text);
                if (i > 0)
                {
                    string pid = this.cntrl.patient_maxid();
                    id = pid;
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
                    try
                    {
                        string smsName1 = PappyjoeMVC.Model.GlobalVariables.smsName.ToString();
                        string smsPass1 = PappyjoeMVC.Model.GlobalVariables.smsPass.ToString();
                        string url = "https://www.smscountry.com/SMSCwebservice_bulk.aspx?User=" + smsName1 + "&passwd=" + smsPass1 + "&mobilenumber=91" + txtmobile.Text + "&message=Dear " + txtpatname.Text + ",Welcome to " + str_Clinic + "," + contact_no;
                        WebRequest request = WebRequest.Create(url);
                        WebResponse response = request.GetResponse();
                        string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        txtpatname.Text = "";
                        loadptid();
                        txtmobile.Text = "";
                        var form2 = new Consultation(txtpatname.Text, id);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }
                    catch
                    {
                        var form2 = new Consultation(txtpatname.Text, id);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }
                }
            }
        }
        private void consultation_new_patient_Load(object sender, EventArgs e)
        {
            radfemail.Checked = true;
            loadptid();
            string clinicn = "";
            DataTable clinicname = this.cntrl.get_practice_details();
            if (clinicname.Rows.Count > 0)
            {
                clinicn = clinicname.Rows[0][0].ToString();
                str_Clinic = clinicn.Replace("¤", "'");
                contact_no = clinicname.Rows[0][1].ToString();
            }
        }
        public void loadptid()
        {
            DataTable auto = this.cntrl.data_from_automaticid();
            if (auto.Rows.Count > 0)
            {
                if (auto.Rows[0]["patient_automation"].ToString() == "Yes")
                {
                    txtPatientId.Text = auto.Rows[0]["patient_prefix"].ToString() + auto.Rows[0]["patient_number"].ToString();
                    txtPatientId.ReadOnly = true;
                }
            }
        }
        private void txtmobile_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
