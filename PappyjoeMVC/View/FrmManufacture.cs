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
    public partial class FrmManufacture : Form,manufacture_interface
    {
        public FrmManufacture()
        {
            InitializeComponent();
        }
        Manufacture_controller cntrl;
        public static string id;
        public string Code
        {
            get { return this.txt_Code.Text; }
            set { this.txt_Code.Text = value; }
        }
        public string Name
        {
            get { return this.txt_name.Text; }
            set { this.txt_name.Text = value; }
        }
        public string Shortname
        {
            get { return this.txt_Shrtname.Text; }
            set { this.txt_Shrtname.Text = value; }
        }
        public string Email
        {
            get { return this.txt_Email.Text; }
            set { this.txt_Email.Text = value; }
        }
        public string CName
        {
            get { return this.txt_Contactname.Text; }
            set { this.txt_Contactname.Text = value; }
        }
        public string Web
        {
            get { return this.Txt_Web.Text; }
            set { this.Txt_Web.Text = value; }
        }
        public string Fax
        {
            get { return this.Txt_Fax.Text; }
            set { this.Txt_Fax.Text = value; }
        }
        public string Phone
        {
            get { return this.txt_phone.Text; }
            set { this.txt_phone.Text = value; }
        }
        public string Address1
        {
            get { return this.txt_Address1.Text; }
            set { this.txt_Address1.Text = value; }
        }
        public string Address2
        {
            get { return this.txt_Address2.Text; }
            set { this.txt_Address2.Text = value; }
        }
        public string Address3
        {
            get { return this.txt_Address3.Text; }
            set { this.txt_Address3.Text = value; }
        }
        public void SetController(Manufacture_controller controller)
        {
            cntrl = controller;
        }

        private void FrmManufacture_Load(object sender, EventArgs e)
        {
            this.cntrl.Load_grid();
            txt_name.Text = "";
            Dgv_Manufacture.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Manufacture.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Manufacture.EnableHeadersVisualStyles = false;
            Dgv_Manufacture.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
            foreach (DataGridViewColumn cl in Dgv_Manufacture.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void Fill_grid(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Dgv_Manufacture.Rows.Clear();
                int num = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Dgv_Manufacture.Rows.Add();
                    Dgv_Manufacture.Rows[i].Cells["ColSlNo"].Value = num;
                    Dgv_Manufacture.Rows[i].Cells["colCode"].Value = dt.Rows[i]["Code"].ToString();
                    Dgv_Manufacture.Rows[i].Cells["clname"].Value = dt.Rows[i]["manufacturer"].ToString();
                    Dgv_Manufacture.Rows[i].Cells["clShrtname"].Value = dt.Rows[i]["ShortName"].ToString();
                    Dgv_Manufacture.Rows[i].Cells["colEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    Dgv_Manufacture.Rows[i].Cells["colDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    Dgv_Manufacture.Rows[i].Cells["m_id"].Value = dt.Rows[i]["id"].ToString();
                    num = num + 1;
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txt_Code.Text != "" && txt_name.Text != "" && txt_phone.Text != "")
            {
              
                if (btn_Save.Text == "SAVE")
                {
                    i = this.cntrl.Save();
                    if (i > 0)
                    {
                        this.cntrl.Load_grid();
                        clear();
                    }
                }
                else if (btn_Save.Text == "UPDATE")
                {
                    i = this.cntrl.update(id);
                    if (i > 0)
                    {
                        this.cntrl.Load_grid();
                        clear();
                        btn_Save.Text = "SAVE"; cancel.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Updation failed...", "Save error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                if (txt_Code.Text == "")
                {
                    MessageBox.Show("Enter the manufacture code ", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_Code.Focus();return;
                }
                else if (txt_name.Text == "")
                {
                    MessageBox.Show("Enter the manufacture name", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_name.Focus(); return;
                }
                else if (txt_phone.Text == "")
                {
                    MessageBox.Show("Enter the phone number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_phone.Focus(); return;
                }
            }
        }

        public void clear()
        {
            txt_name.Text = "";
            txt_Code.Text = "";
            txt_phone.Text = "";
            txt_Shrtname.Text = "";
            txt_Address1.Text = "";
            txt_Address2.Text = "";
            txt_Address3.Text = "";
            Txt_Fax.Text = "";
            txt_Contactname.Text = "";
            txt_Email.Text = "";
            Txt_Web.Text = "";
        }


        private void Dgv_Manufacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != -1)
            {
                if (Dgv_Manufacture.Rows.Count > 0)
                {
                    id = Dgv_Manufacture.CurrentRow.Cells["m_id"].Value.ToString();
                    int index = Dgv_Manufacture.CurrentRow.Index;
                    if (Dgv_Manufacture.CurrentCell.OwningColumn.Name == "colEdit")
                    {
                        if (id != null)
                        {
                            DataTable dtb =this.cntrl.get_manufacture(id);
                            if (dtb.Rows.Count > 0)
                            {
                                txt_name.Text = dtb.Rows[0]["manufacturer"].ToString();
                                txt_Code.Text = dtb.Rows[0]["Code"].ToString();
                                txt_phone.Text = dtb.Rows[0]["Phone"].ToString();
                                txt_Shrtname.Text = dtb.Rows[0]["ShortName"].ToString();
                                txt_Address1.Text = dtb.Rows[0]["Address1"].ToString();
                                txt_Address2.Text = dtb.Rows[0]["Address2"].ToString();
                                txt_Address3.Text = dtb.Rows[0]["Address3"].ToString();
                                Txt_Fax.Text = dtb.Rows[0]["fax"].ToString();
                                txt_Contactname.Text = dtb.Rows[0]["Contact_Name"].ToString();
                                txt_Email.Text = dtb.Rows[0]["Email"].ToString();
                                Txt_Web.Text = dtb.Rows[0]["Web"].ToString();
                                btn_Save.Text = "UPDATE"; cancel.Visible = true;
                            }
                        }
                    }
                    else if (Dgv_Manufacture.CurrentCell.OwningColumn.Name == "colDelete")
                    {
                        int i = 0;
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            i = this.cntrl.delete(id);
                            if (i > 0)
                            {
                                Dgv_Manufacture.Rows.RemoveAt(index);
                                this.cntrl.Load_grid();
                            }
                        }
                    }
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            clear();
            btn_Save.Text = "SAVE";
            cancel.Visible = false;
        }

        private void txt_Email_Validating(object sender, CancelEventArgs e)
        {
            if (!PappyjoeMVC.Model.Connection.checkforemail(txt_Email.Text.ToString()) && txt_Email.Text != "")
            {
                MessageBox.Show("Invalid Email address/Password..", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Email.Focus();
            }
        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_phone_Leave(object sender, EventArgs e)
        {
          
        }
    }
}
