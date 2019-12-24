using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net; // For SMS
using System.IO;// For SMS streaming
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.View
{
    public partial class consultation_new_patient : Form
    {
        public consultation_new_patient()
        {
            InitializeComponent();
        }
        string contact_no = "";
        string str_Clinic = "";
        string id = "";
        public string doctor_id = "";
        Consultatio_add_Patient_controller cntrl = new Consultatio_add_Patient_controller();

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
                if (txtmobile.TextLength <10)
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
                int i;
                if (lblmore.Text=="+ More")
                {
                    i = this.cntrl.save_patient(txtpatname.Text , txtPatientId.Text ,  gender ,  txtmobile.Text);
                }
                else
                {
                    i = this.cntrl.save_patient_else(txtpatname.Text, txtPatientId.Text, gender, txtmobile.Text, txtxAge.Text, txtxStreet.Text, txtLocality.Text, txtCity.Text, txtFileNo.Text, ddldoctor.Text);
                }
               
                if (i > 0)
                {
                    DataTable pid = this.cntrl.patient_maxid();
                    id = pid.Rows[0][0].ToString();
                    DataTable cmd = this.cntrl.select_patnt_num();
                    if (cmd.Rows.Count > 0)
                    {
                        int n = 0;
                        n = int.Parse(cmd.Rows[0]["patient_number"].ToString()) + 1;
                        if (n != 0)
                        {
                            this.cntrl.update_autoId(n);
                        }
                    }

                    if (lblmore.Text == "- More")
                    {
                        for (int count = 0; count < grmedical.Rows.Count; count++)

                        {
                            if (Convert.ToBoolean(grmedical.Rows[count].Cells[0].Value) == true)
                            {
                                int med = this.cntrl.med_hist(id, grmedical.Rows[count].Cells[1].Value.ToString());
                            }
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
            doctornamebind();
            DataTable dt = this.cntrl.name_medhistory();
            grmedical.DataSource = dt;
            DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn()
            {
                Name = "Check"
            };
            grmedical.Columns.Add(check);
            check.Width = 100;
            check.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
        }
        public void loadptid()
        {
            DataTable auto = this.cntrl.autom_id();
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
        public void doctornamebind()
        {
            try
            {
                if (doctor_id != "0")
                {
                    int dr_index = 0;
                    DataTable dt = this.cntrl.Load_doctor();
                    if (dt.Rows.Count > 0)
                    {
                        ddldoctor.DisplayMember = "doctor_name";
                        ddldoctor.ValueMember = "id";
                        ddldoctor.DataSource = dt;
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["id"].ToString() == doctor_id)
                            {
                                dr_index = j;
                            }
                        }
                        ddldoctor.SelectedIndex = dr_index;
                    }
                }
                else
                {
                    DataTable dt = this.cntrl.doc_info();
                    if (dt.Rows.Count > 0)
                    {
                        ddldoctor.DisplayMember = "doctor_name";
                        ddldoctor.ValueMember = "id";
                        ddldoctor.DataSource = dt;
                        ddldoctor.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
            }
        }

        private void lblmore_Click(object sender, EventArgs e)
        {
            if(lblmore.Text=="+ More")
            { lblmore.Text = "- More";
            button1.Location = new Point(252, 550);
            pnlmore.Visible = true;
            pnlmore.Location = new Point(2, 122);
            this.Size = new Size(365, 624);
            }
            else
            { lblmore.Text = "+ More";
            button1.Location = new Point(257, 123);
            pnlmore.Visible = false;
            this.Size = new Size(365, 206);
            }
        }

        private void txtxAge_KeyPress(object sender, KeyPressEventArgs e)
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
