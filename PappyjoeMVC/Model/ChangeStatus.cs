using PappyjoeMVC.Controller;
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
    public partial class ChangeStatus : Form,ChangeStatus_interface
    {
        ChangeStatus_controller ctrlr;
        public string patient_id = "", doctor_id = "";
        public ChangeStatus(string jobno, string patient, string doctor, string lab, string workname, string due, string status)
        {
            try
            {
                InitializeComponent();
                txtjobno.Text = jobno;
                txtjobno.Enabled = false;
                txtpatient.Text = patient;
                txtpatient.Enabled = false;
                txtlab.Text = lab;
                txtlab.Enabled = false;
                txtworkname.Text = workname;
                txtworkname.Enabled = false;
                txtdue.Text = due;
                txtdue.Enabled = false;
                textBox1.Text = doctor;
                textBox1.Enabled = false;
                comboBox1.Items.Add("Active");
                comboBox1.Items.Add("Sent");
                comboBox1.Items.Add("In Production");
                comboBox1.Items.Add("In Transit");
                comboBox1.Items.Add("Recieved");
                comboBox1.Items.Add("Over Due");
                comboBox1.SelectedItem = status;
                label7.Text = jobno;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void setController(ChangeStatus_controller controller)
        {
            ctrlr = controller;
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                int i = this.ctrlr.statusupdate(comboBox1.SelectedItem.ToString().Trim(), label7.Text);
                if (i > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

    }
}
