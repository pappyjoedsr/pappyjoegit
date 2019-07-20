using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class AddAmount : Form
    {
        public AddAmount()
        {
            InitializeComponent();
        }
        public int rowindex = 0;
        private void AddAmount_Load(object sender, EventArgs e)
        {
            txt_Amount.Focus();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txt_Amount.Text.Trim() != "")
            {
                Connection.MyGlobals.PaidAmount = Convert.ToDecimal(txt_Amount.Text);
                this.Close();
            }
            else
            {

                txt_Amount.Focus();
                Lab_Msg.Visible = true;
                Connection.MyGlobals.PaidAmount = 0;
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
