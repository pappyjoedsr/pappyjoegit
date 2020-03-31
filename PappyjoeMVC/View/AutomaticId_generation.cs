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
    public partial class AutomaticId_generation : Form
    {
        Autoid_Generation_controller cntrl=new Autoid_Generation_controller();
        public string ptcheck = "", invcheck = "", reciptcheck = "";
        public AutomaticId_generation()
        {
            InitializeComponent();
        }
        private void AutomaticId_generation_Load(object sender, EventArgs e)
        {
            label5.Hide();
            label7.Hide();
            label12.Hide();
            DataTable dtb= this.cntrl.load_patientid();
            LoadPatientId(dtb);
            DataTable dtb_invoice= this.cntrl.load_Invoiceid();
            LoadInvoiceId(dtb_invoice);
            DataTable dtb_recepit= this.cntrl.load_receiptid();
            LoadReceiptId(dtb_recepit);
        }
        public void LoadPatientId(DataTable patient)
        {
            if (patient.Rows.Count > 0)
            {
                text_prefix.Text = patient.Rows[0]["patient_prefix"].ToString();
                text_number.Text = patient.Rows[0]["patient_number"].ToString();
                string pat_generate = patient.Rows[0]["patient_automation"].ToString();
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
        private void button_save_Click(object sender, EventArgs e)//patient
        {
            string cmd = "";// this.cntrl.patient_prefix();
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
                }
                else
                {
                    ptcheck = "No";
                }
                if (chk_ip_patient.Checked==true)
                {
                    cmd = this.cntrl.IP_patient_prefix();
                    if(cmd=="0")
                    {
                        int i = this.cntrl.save_IP_patientid(text_number.Text, text_prefix.Text, ptcheck);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            chk_ip_patient.Checked = false;
                        }
                    }
                    else
                    {
                        int i = this.cntrl.update_IP_patientid(text_number.Text, text_prefix.Text, ptcheck);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    cmd = this.cntrl.patient_prefix();
                    if (cmd == "0")
                    {
                        int i = this.cntrl.save_patientid(text_number.Text, text_prefix.Text, ptcheck);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        int i = this.cntrl.update_patientid(text_number.Text, text_prefix.Text, ptcheck);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }


                //////
               
                
            }
        }
        private void button_invoice_save_Click(object sender, EventArgs e)
        {
            DataTable cmd = this.cntrl.Invoice_prefix();
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
                }
                else
                {
                    invcheck = "No";
                }
                if (cmd.Rows.Count == 0)
                {
                    this.cntrl.save_invoice(text_invoice_number.Text, text_invoice_prefix.Text,invcheck);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.cntrl.update_invoice(text_invoice_number.Text, text_invoice_prefix.Text,invcheck);
                    MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_receipt_save_Click(object sender, EventArgs e)
        {
            DataTable cmd = this.cntrl.Recipt_prefix();
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
                }
                else
                {
                    reciptcheck = "No";
                }
                if (cmd.Rows.Count == 0)
                {
                    this.cntrl.save_receipt(text_receipt_number.Text, text_receipt_prefix.Text,reciptcheck);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.cntrl.update_receipt(text_receipt_number.Text, text_receipt_prefix.Text,reciptcheck);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void chk_ip_patient_Click(object sender, EventArgs e)
        {
            if(chk_ip_patient.Checked==true)
            {
                DataTable dtb = this.cntrl.load_ippatient_id();
                if(dtb.Rows.Count>0)
                {
                    text_prefix.Text = dtb.Rows[0]["IP_prefix"].ToString();
                    text_number.Text = dtb.Rows[0]["IP_number"].ToString();
                    if(dtb.Rows[0]["IP_automation"].ToString()== "Yes")
                    {
                        check_patient.Checked = true;
                    }
                    else
                    {
                        check_patient.Checked = false;
                    }
                }
            }
            else 
            {
                DataTable dtb = this.cntrl.load_patientid();
                if (dtb.Rows.Count > 0)
                {
                    text_prefix.Text = dtb.Rows[0]["patient_prefix"].ToString();
                    text_number.Text = dtb.Rows[0]["patient_number"].ToString();
                    if (dtb.Rows[0]["patient_automation"].ToString() == "Yes")
                    {
                        check_patient.Checked = true;
                    }
                    else
                    {
                        check_patient.Checked = false;
                    }
                }
            }
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
    }
}
