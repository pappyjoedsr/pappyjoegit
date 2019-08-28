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

namespace PappyjoeMVC.View
{
    public partial class communication_settings : Form
    {
        public communication_settings()
        {
            InitializeComponent();
        }
        communication_setting_controller cntrl=new communication_setting_controller();
        //public string SMSUName
        //{
        //    get { return this.textSmsUname.Text; }
        //    set { this.textSmsUname.Text = value; }
        //}
        //public string SMSPassword
        //{
        //    get { return this.textSmsPassword.Text; }
        //    set { this.textSmsPassword.Text = value; }
        //}
        //public string EmailUNAme
        //{
        //    get { return this.textEmailUname.Text; }
        //    set { this.textEmailUname.Text = value; }
        //}
        //public string EmailPassword
        //{
        //    get { return this.textEmailPassword.Text; }
        //    set { this.textEmailPassword.Text = value; }
        //}
        public void SetController(communication_setting_controller controller)
        {
            cntrl = controller;
        }
        private void communication_settings_Load(object sender, EventArgs e)
        {
            DataTable sms =this.cntrl. getsmstabledata();
            if (sms.Rows.Count > 0)
            {
                if (String.IsNullOrWhiteSpace(sms.Rows[0]["smsName"].ToString()))
                {
                    label24.Visible = true;
                }
                else
                {
                    label24.Visible = false;
                    textSmsUname.Text = sms.Rows[0]["smsName"].ToString();
                }
                if (String.IsNullOrWhiteSpace(sms.Rows[0]["smsPass"].ToString()))
                {
                    label24.Visible = true;
                }
                else
                {
                    label24.Visible = false;
                    textSmsPassword.Text = sms.Rows[0]["smsPass"].ToString();
                }
                if (String.IsNullOrWhiteSpace(sms.Rows[0]["emailName"].ToString()))
                {
                    label25.Visible = true;
                }
                else
                {
                    label25.Visible = false;
                    textEmailUname.Text = sms.Rows[0]["emailName"].ToString();
                }
                if (String.IsNullOrWhiteSpace(sms.Rows[0]["emailPass"].ToString()))
                {
                    label25.Visible = true;
                }
                else
                {
                    label25.Visible = false;
                    textEmailPassword.Text = sms.Rows[0]["emailPass"].ToString();
                }
            }
            else
            {
                label24.Visible = true;
                label25.Visible = true;
            }
        }

        private void buttonSms_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable sms = this.cntrl.Getsmaname();
                if (sms.Rows.Count > 0)
                {
                    this.cntrl.update_sms(textSmsUname.Text, textSmsPassword.Text);
                    MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.cntrl.save_sms(textSmsUname.Text, textSmsPassword.Text);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataTable sms1 = this.cntrl.getsmstabledata();
                if (sms.Rows.Count > 0)
                {
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["smsName"].ToString()))
                    {
                        label24.Visible = true;
                    }
                    else
                    {
                        label24.Visible = false;
                        textSmsUname.Text = sms1.Rows[0]["smsName"].ToString();
                    }
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["smsPass"].ToString()))
                    {
                        label24.Visible = true;
                    }
                    else
                    {
                        label24.Visible = false;
                        textSmsPassword.Text = sms1.Rows[0]["smsPass"].ToString();
                    }
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["emailName"].ToString()))
                    {
                        label25.Visible = true;
                    }
                    else
                    {
                        label25.Visible = false;
                        textEmailUname.Text = sms1.Rows[0]["emailName"].ToString();
                    }
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["emailPass"].ToString()))
                    {
                        label25.Visible = true;
                    }
                    else
                    {
                        label25.Visible = false;
                        textEmailPassword.Text = sms1.Rows[0]["emailPass"].ToString();
                    }
                }
                else
                {
                    label24.Visible = true;
                    label25.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable sms = this.cntrl.Getsmaname();
                if (sms.Rows.Count > 0)
                {
                    this.cntrl.update_email(textEmailUname.Text, textEmailPassword.Text);
                    MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.cntrl.Save_email(textEmailUname.Text, textEmailPassword.Text);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataTable sms1 = this.cntrl.getsmstabledata();
                if (sms1.Rows.Count > 0)
                {
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["smsName"].ToString()))
                    {
                        label24.Visible = true;
                    }
                    else
                    {
                        label24.Visible = false;
                        textSmsUname.Text = sms1.Rows[0]["smsName"].ToString();
                    }
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["smsPass"].ToString()))
                    {
                        label24.Visible = true;
                    }
                    else
                    {
                        label24.Visible = false;
                        textSmsPassword.Text = sms1.Rows[0]["smsPass"].ToString();
                    }
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["emailName"].ToString()))
                    {
                        label25.Visible = true;
                    }
                    else
                    {
                        label25.Visible = false;
                        textEmailUname.Text = sms1.Rows[0]["emailName"].ToString();
                    }
                    if (String.IsNullOrWhiteSpace(sms1.Rows[0]["emailPass"].ToString()))
                    {
                        label25.Visible = true;
                    }
                    else
                    {
                        label25.Visible = false;
                        textEmailPassword.Text = sms1.Rows[0]["emailPass"].ToString();
                    }
                }
                else
                {
                    label24.Visible = true;
                    label25.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }
    }
}
