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
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.View
{
    public partial class AutomaticId_generation : Form, autoid_generation_interface
    {
        autoid_generation_controller cntrl;
        public string ptcheck = "", invcheck = "", reciptcheck = "";
        public AutomaticId_generation()
        {
            InitializeComponent();
        }
        public void SetController(autoid_generation_controller controller)
        {
            cntrl = controller;
        }
        private void AutomaticId_generation_Load(object sender, EventArgs e)
        {
            label5.Hide();
            label7.Hide();
            label12.Hide();
            this.cntrl.load_patientid();
            this.cntrl.load_Invoiceid();
            this.cntrl.load_receiptid();
        }
        public void LoadPatientId(DataTable patient)
        {
            if (patient.Rows.Count > 0)
            {
                text_prefix.Text = patient.Rows[0][2].ToString();
                text_number.Text = patient.Rows[0][1].ToString();
                string pat_generate = patient.Rows[0][3].ToString();
                if (pat_generate == "Yes")
                {
                    check_patient.Checked = true;
                }
                else
                {
                    check_patient.Checked = false;
                }
            }
        }

        public void LoadInvoiceId(DataTable invoice)
        {
            if (invoice.Rows.Count > 0)
            {
                text_invoice_prefix.Text = invoice.Rows[0][2].ToString();
                text_invoice_number.Text = invoice.Rows[0][1].ToString();
                string invoice_generate = invoice.Rows[0][3].ToString();
                if (invoice_generate == "Yes")
                {
                    check_invoice.Checked = true;
                }
                else
                {
                    check_invoice.Checked = false;
                }
            }
        }
        public void LoadReceiptId(DataTable receipt)
        {
            if (receipt.Rows.Count > 0)
            {
                text_receipt_prefix.Text = receipt.Rows[0][2].ToString();
                text_receipt_number.Text = receipt.Rows[0][1].ToString();
                string receipt_generate = receipt.Rows[0][3].ToString();
                if (receipt_generate == "Yes")
                {
                    check_receipt.Checked = true;
                }
                else
                {
                    check_receipt.Checked = false;
                }
            }
        }

        private void text_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

        private void text_number_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            label5.Hide();
        }
        public string PtNumber
        {
            get { return this.text_number.Text; }
            set { this.text_number.Text = value; }
        }
        public string ptPrefix
        {
            get { return this.text_prefix.Text; }
            set { this.text_prefix.Text = value; }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            DataTable cmd = this.cntrl.patient_prefix();
            if (cmd.Rows.Count == 0)
            {
                if (text_number.Text == "")
                {
                    errorProvider1.SetError(text_number, "error");
                    label5.Show();
                    return;
                }
                else
                {
                    if (check_patient.Checked == true)
                    {
                        ptcheck = "Yes";
                        int i = this.cntrl.save_patientid(ptcheck);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        ptcheck = "No";
                        int j = this.cntrl.save_patientid(ptcheck);
                        //int j = db.execute("insert into tbl_patient_automaticid (patient_number,patient_prefix,patient_automation) values ('" + text_number.Text + "','" + text_prefix.Text + "','No')");
                        if (j > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            if (text_number.Text == "")
            {
                errorProvider1.SetError(text_number, "error");
                label5.Show();
            }
            else
            {
                if (check_patient.Checked == true)
                {
                    ptcheck = "Yes";
                    int i = this.cntrl.update_patientid(ptcheck);
                    //int i = db.execute("update tbl_patient_automaticid set patient_number='" + text_number.Text + "', patient_prefix='" + text_prefix.Text + "',patient_automation='Yes'");
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    ptcheck = "No";
                    int i = this.cntrl.update_patientid(ptcheck);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public string InvNumber
        {
            get { return this.text_invoice_number.Text; }
            set { this.text_invoice_number.Text = value; }
        }
        public string InvPrefix
        {
            get { return this.text_invoice_prefix.Text; }
            set { this.text_invoice_prefix.Text = value; }
        }

        private void button_invoice_save_Click(object sender, EventArgs e)
        {
            DataTable cmd = this.cntrl.Invoice_prefix();
            if (cmd.Rows.Count == 0)
            {
                if (text_invoice_number.Text == "")
                {
                    errorProvider1.SetError(text_invoice_number, "error");
                    label7.Show();
                    return;
                }
                else
                {
                    if (check_invoice.Checked == true)
                    {
                        invcheck = "Yes";
                        this.cntrl.save_invoice(invcheck);
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        invcheck = "No";
                        this.cntrl.save_invoice(invcheck);
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (text_invoice_number.Text == "")
                {
                    errorProvider1.SetError(text_invoice_number, "error");
                    label7.Show();
                }
                else
                {
                    if (check_invoice.Checked == true)
                    {
                        invcheck = "Yes";
                        this.cntrl.update_invoice(invcheck);
                        MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        invcheck = "No";
                        this.cntrl.update_invoice(invcheck);
                        MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_receipt_save_Click(object sender, EventArgs e)
        {
            DataTable cmd = this.cntrl.Recipt_prefix();
            if (cmd.Rows.Count == 0)
            {
                if (text_receipt_number.Text == "")
                {
                    errorProvider1.SetError(text_receipt_number, "error");
                    label12.Show();
                }
                else
                {
                    if (check_receipt.Checked == true)
                    {
                        reciptcheck = "Yes";
                        this.cntrl.save_receipt(reciptcheck);
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        reciptcheck = "No";
                        this.cntrl.save_receipt(reciptcheck);
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (text_receipt_number.Text == "")
                {
                    errorProvider1.SetError(text_receipt_number, "error");
                    label12.Show();
                }
                else
                {
                    if (check_receipt.Checked == true)
                    {
                        reciptcheck = "Yes";
                        this.cntrl.update_receipt(reciptcheck);
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        reciptcheck = "Yes";
                        this.cntrl.update_receipt(reciptcheck);
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font TabFont;
            Brush BackBrush = new SolidBrush(Color.Transparent); //Set background color
            Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);//Set foreground color
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                TabFont = new Font(e.Font, FontStyle.Italic);
            }
            else
            {
                TabFont = e.Font;
            }
            string TabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
            sf.Dispose();
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                TabFont.Dispose();
                BackBrush.Dispose();
            }
            else
            {
                BackBrush.Dispose();
                ForeBrush.Dispose();
            }
        }

        private void text_receipt_number_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            label12.Hide();
        }

        private void text_invoice_number_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            label7.Hide();
        }

        private void text_invoice_number_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            //{ e.Handled = true; }
        }

        private void text_receipt_number_KeyUp(object sender, KeyEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            //{ e.Handled = true; }
        }

        private void text_receipt_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

        private void text_invoice_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            { e.Handled = true; }
        }

        public string ReciptNumber
        {
            get { return this.text_receipt_number.Text; }
            set { this.text_receipt_number.Text = value; }
        }
        public string ReciptPrefix
        {
            get { return this.text_receipt_prefix.Text; }
            set { this.text_receipt_prefix.Text = value; }
        }
    }
}
