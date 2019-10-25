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
        string contact_no = "";
        string str_Clinic = "";
        Consultatio_add_Patient_controller cntrl = new Consultatio_add_Patient_controller();
        public consultation_new_patient()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtpatname.Text != "" && txtmobile.Text != "")
            {
                string gender = "";
                if (radmail.Checked == true)
                {
                    gender = radmail.Text;
                }
                else
                {
                    gender = radfemail.Text;
                }
                int i = this.cntrl.save_patient(txtpatname.Text , txtPatientId.Text , gender , txtmobile.Text);// db.execute("insert into tbl_patient (pt_name,pt_id,gender,primary_mobile_number,Profile_Status)values('" + txtpatname.Text + "','" + txtPatientId.Text + "','" + gender + "','" + txtmobile.Text + "','Active')");
                if (i > 0)
                {
                    string pid = this.cntrl.patient_maxid();// db.table("SELECT MAX(id) from tbl_patient");
                    string id =Convert.ToInt32( pid).ToString();
                    DataTable cmd = this.cntrl.automaticid();// db.table("select patient_number from tbl_patient_automaticid where patient_automation='Yes'");
                    if (cmd.Rows.Count > 0)
                    {
                        int n = 0;
                        n = int.Parse(cmd.Rows[0]["patient_number"].ToString()) + 1;
                        if (n != 0)
                        {
                            this.cntrl.update_autogenerateid(n);// db.execute("update tbl_patient_automaticid set patient_number='" + n + "'");
                        }
                    }

                    string smsName1 = PappyjoeMVC.Model.GlobalVariables.smsName.ToString();
                    string smsPass1 = PappyjoeMVC.Model.GlobalVariables.smsPass.ToString();
                    string url = "https://www.smscountry.com/SMSCwebservice_bulk.aspx?User=" + smsName1 + "&passwd=" + smsPass1 + "&mobilenumber=91" + txtmobile.Text + "&message=Dear " + txtpatname.Text + ",Welcome to " + str_Clinic + "," + contact_no;
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    // Using WebClient
                    //string result1 = new WebClient().DownloadString(url);

                    // MessageBox  .Show("Data saved successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtpatname.Text = "";
                    loadptid();
                    txtmobile.Text = "";
                    var form2 = new Consultation(txtpatname.Text, id);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Close();
                }

            }
        }

        public void loadptid()
        {
            DataTable auto = this.cntrl.data_from_automaticid();// db.table("select * from tbl_patient_automaticid ");
            if (auto.Rows.Count > 0)
            {
                if (auto.Rows[0]["patient_automation"].ToString() == "Yes")
                {
                    txtPatientId.Text = auto.Rows[0]["patient_prefix"].ToString() + auto.Rows[0]["patient_number"].ToString();
                    txtPatientId.ReadOnly = true;
                }
            }
        }

        private void consultation_new_patient_Load(object sender, EventArgs e)
        {
            radfemail.Checked = true;
            loadptid();
            string clinicn = "";
            DataTable clinicname = this.cntrl.get_practice_details();// db.table("select name,contact_no from tbl_practice_details");
            if (clinicname.Rows.Count > 0)
            {
                clinicn = clinicname.Rows[0][0].ToString();
                str_Clinic = clinicn.Replace("¤", "'");
                contact_no = clinicname.Rows[0][1].ToString();
            }
        }
    }
}
