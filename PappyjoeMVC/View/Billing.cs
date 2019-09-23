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
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class Billing : Form
    {
        Billing_controller cntrl=new Billing_controller();
        public string BillId = "";
        public Billing()
        {
            InitializeComponent();
        }
        public void FillBillGrid(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                int i = 0;
                dataGridView_Billing.Rows.Clear();
                foreach(DataRow dr in dtb.Rows)
                {
                    dataGridView_Billing.Rows.Add();
                    dataGridView_Billing.Rows[i].Cells["id"].Value = dr["id"].ToString();
                    dataGridView_Billing.Rows[i].Cells["name"].Value = dr["tax_name"].ToString();
                    dataGridView_Billing.Rows[i].Cells["tax"].Value = dr["tax_value"].ToString();
                    i++;
                }
            }
        }
        private void buttonsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(text_taxname.Text) && !string.IsNullOrWhiteSpace(text_taxvalue.Text))
                {
                    if (buttonsave.Text == "Save")
                    {
                      int i=this.cntrl.save(text_taxname.Text, text_taxvalue.Text);
                        if(i>0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        int i = this.cntrl.update(BillId, text_taxname.Text, text_taxvalue.Text);
                        if(i>0)
                        {
                            MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    text_taxname.Text = "";
                    buttonsave.Text = "Save";
                    text_taxvalue.Text = "";
                    DataTable dtb = this.cntrl.Fill_BillGrid();
                    FillBillGrid(dtb);
                }
                else
                {
                    MessageBox.Show("Data Not Found..!!!", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error !..",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
           
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            DataTable dtb= this.cntrl.Fill_BillGrid();
            FillBillGrid(dtb);
            dataGridView_Billing.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_Billing.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_Billing.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_Billing.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_Billing.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dataGridView_Billing_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    BillId = dataGridView_Billing.CurrentRow.Cells["id"].Value.ToString();
                    if (dataGridView_Billing.CurrentCell.OwningColumn.Name == "Edit")
                    {
                        text_taxname.Text = dataGridView_Billing.CurrentRow.Cells["name"].Value.ToString();
                        text_taxvalue.Text = dataGridView_Billing.CurrentRow.Cells["tax"].Value.ToString();
                        buttonsave.Text = "Update";
                    }
                    else if (dataGridView_Billing.CurrentCell.OwningColumn.Name == "Delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            int i = this.cntrl.Delete(BillId);
                            if (i > 0)
                            {
                                dataGridView_Billing.Rows.RemoveAt(dataGridView_Billing.CurrentRow.Index);
                                DataTable dtb= this.cntrl.Fill_BillGrid();
                                FillBillGrid(dtb);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void buttonclear_Click(object sender, EventArgs e)
        {
            text_taxname.Clear();
            text_taxvalue.Clear();
            buttonsave.Text = "Save"; 
        }
    }
}
