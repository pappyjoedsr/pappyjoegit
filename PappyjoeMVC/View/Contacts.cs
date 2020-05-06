
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
    public partial class Contacts : Form
    {
        Contact_controller cntrl=new Contact_controller();
        public string ContactId = "";
        public Contacts()
        {
            InitializeComponent();
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(text_contact.Text)&&txtMobNumber.Text!="")
            {
                if(txtMobNumber.TextLength != 10)
                {
                    MessageBox.Show("Enter the mobile number.. !!", "Data not found.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (buttonsave.Text=="Save")
                {
                    int i =this.cntrl.Save(text_contact.Text,txtMobNumber.Text,RTB_AddNotes.Text);
                    if(i>0)
                    {
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    int i = this.cntrl.Update(ContactId, text_contact.Text,txtMobNumber.Text,RTB_AddNotes.Text);
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                text_contact.Clear();
                txtMobNumber.Clear();
                RTB_AddNotes.Clear();
                DataTable dtb= this.cntrl.FillGrid();
                Fill_ContactGrid(dtb);
            }
            else
            {
                MessageBox.Show("Data Not Found..!!!", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                text_contact.Focus();
            }
        }
        public void Fill_ContactGrid(DataTable dtb)
        {
            if(dtb.Rows.Count>0)
            {
                int i = 0;
                dgv_Contact.Rows.Clear();
                foreach (DataRow dr in dtb.Rows)
                {
                    dgv_Contact.Rows.Add();
                    dgv_Contact.Rows[i].Cells[0].Value = dr["id"].ToString();
                    dgv_Contact.Rows[i].Cells[1].Value = dr["contact"].ToString();
                    dgv_Contact.Rows[i].Cells[2].Value= dr["Mobile_no"].ToString();
                    dgv_Contact.Rows[i].Cells[3].Value = dr["Notes"].ToString();
                    i++;
                }
            }
            else
            { dgv_Contact.Rows.Clear(); }
        }

        private void dgv_Contact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    ContactId = dgv_Contact.CurrentRow.Cells[0].Value.ToString();
                    if (dgv_Contact.CurrentCell.OwningColumn.Name == "edit")
                    {
                        text_contact.Text = dgv_Contact.CurrentRow.Cells[1].Value.ToString();
                        txtMobNumber.Text= dgv_Contact.CurrentRow.Cells[2].Value.ToString();
                        RTB_AddNotes.Text = dgv_Contact.CurrentRow.Cells[3].Value.ToString();
                        buttonsave.Text = "Update";
                    }
                    else if (dgv_Contact.CurrentCell.OwningColumn.Name == "delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            int i = this.cntrl.Delete_data(ContactId);
                            if (i > 0)
                            {
                                dgv_Contact.Rows.RemoveAt(dgv_Contact.CurrentRow.Index);
                                DataTable dtb= this.cntrl.FillGrid();
                                Fill_ContactGrid(dtb);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            buttonsave.Text = "Save";
            text_contact.Text = "";
            txtMobNumber.Text = "";
            RTB_AddNotes.Text = "";
            btn_Cancel.Visible = false;
            text_contact.Focus();
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            text_contact.Clear();
            txtMobNumber.Clear();
            RTB_AddNotes.Clear();
            Lab_InvalidNumber.Visible = false;
            buttonsave.Text = "Save";
        }

        private void Contacts_Load(object sender, EventArgs e)
        {
            DataTable dtb= this.cntrl.FillGrid();
            Fill_ContactGrid(dtb);
            dgv_Contact.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_Contact.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_Contact.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dgv_Contact.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dgv_Contact.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Lab_InvalidNumber.Visible = false;
        }
        private void text_search_KeyUp(object sender, KeyEventArgs e)
        {
          DataTable dtb= this.cntrl.search(text_search.Text);
          Fill_ContactGrid(dtb);
        }

        private void txtMobNumber_Leave(object sender, EventArgs e)
        {
                if (txtMobNumber.TextLength != 10)
                {
                    Lab_InvalidNumber.Visible = true;
                    return;
                }
                else
                {
                    Lab_InvalidNumber.Visible = false;
                }
        }
    }
}
