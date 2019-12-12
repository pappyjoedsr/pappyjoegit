using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class New_Debit_Account : Form
    {
        New_Debit_Account_controller cntrl=new New_Debit_Account_controller();
        public New_Debit_Account()
        {
            InitializeComponent();
        }
        private void New_DebitAccount_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtb = this.cntrl.load_ledger();
                cmbLedger.DisplayMember = "Group_Name";
                cmbLedger.ValueMember = "Id";
                cmbLedger.DataSource = dtb;
            }
            catch (Exception ex)
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
                        MessageBox.Show("Already exist", "Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAccountName.Focus();
                        txtAccountName.Clear();
                    }
                    else
                    {
                        int i = this.cntrl.insert( txtAccountName.Text, cmbLedger.Text);
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
