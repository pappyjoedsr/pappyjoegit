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
    public partial class New_CreditAccount : Form,NewCreditAccount_interface
    {
        NewCreditAccount_controller cntrl;
        public New_CreditAccount()
        {
            InitializeComponent();
        }
        public void SetController(NewCreditAccount_controller controller)
        {
            cntrl = controller;
        }
        public string AccountName
        {
            get { return this.txtAccountName.Text; }
            set { this.txtAccountName.Text = value; }
        }
        public string Ledger
        {
            get { return this.cmbLedger.Text; }
            set { this.cmbLedger.Text = value; }
        }
        private void NewAccount_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtb = this.cntrl.load_credit_combo();
                cmbLedger.DataSource = dtb;
                cmbLedger.DisplayMember = "Group_Name";
                cmbLedger.ValueMember = "Id";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtAccountName.Text) && !string.IsNullOrWhiteSpace(cmbLedger.Text))
                {
                    DataTable Account_Name = this.cntrl.Submit(txtAccountName.Text);
                    if (Account_Name.Rows.Count > 0)
                    {
                        MessageBox.Show("Already Exist !!", "Already", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAccountName.Focus();
                        txtAccountName.Clear();
                    }
                    else
                    {
                        this.cntrl.submit_data();
                        MessageBox.Show("Successfully Submited !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAccountName.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
