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
    public partial class Add_Categeory : Form
    {
        public Add_Categeory()
        {
            InitializeComponent();
        }
        Add_Category_controller cntrl=new Add_Category_controller(); string Id;
        private void frmAddCategeory_Load(object sender, EventArgs e)
        {
            clear();
            DataTable dtb= this.cntrl.Load_data();
            Load_Data(dtb);
            dgvCategory.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvCategory.EnableHeadersVisualStyles = false;
            dgvCategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public void clear()
        {
            txt_Cat_Name.Clear();
            txtCategoryNumber.Clear();
            txtDescription.Clear();
        }
        public void Load_Data(DataTable dt)
        {
            if(dt.Rows.Count>0)
            {
                dgvCategory.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvCategory.Rows.Add(dt.Rows[i]["id"].ToString(), dt.Rows[i]["Cat_Number"].ToString(), dt.Rows[i]["Name"].ToString(), dt.Rows[i]["Description"].ToString());
                    dgvCategory.Rows[i].Cells["DEL"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dgvCategory.Rows[i].Cells["EDIT"].Value = PappyjoeMVC.Properties.Resources.editicon;
                }
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvCategory.CurrentCell.OwningColumn.Name == "EDIT")
                    {
                        DataTable dt = new DataTable();
                        Id = dgvCategory.CurrentRow.Cells["colid"].Value.ToString();
                        dt = this.cntrl.get_details(Id);
                        txtCategoryNumber.Text = dt.Rows[0]["Cat_Number"].ToString();
                        txt_Cat_Name.Text = dt.Rows[0]["Name"].ToString();
                        txtDescription.Text = dt.Rows[0]["Description"].ToString();
                        btnOK.Text = "UPDATE";
                        btnCancel.Text = "CANCEL";
                    }
                    if (dgvCategory.CurrentCell.OwningColumn.Name == "DEL")
                    {
                        Id = dgvCategory.CurrentRow.Cells["colid"].Value.ToString(); ;
                        DialogResult res = MessageBox.Show("Are you sure, you want to delete?", "Delete confirmation",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            int i = this.cntrl.delete(Id);
                            if (i > 0)
                            {
                             DataTable dtb= this.cntrl.Load_data();
                             Load_Data(dtb);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOK.Text == "SAVE")
                {
                    if (txt_Cat_Name.Text != "")
                    {
                        DataTable dt = this.cntrl.Get_catdetails(txt_Cat_Name.Text, txtCategoryNumber.Text); 
                        if (dt.Rows.Count == 0)
                        {
                            this.cntrl.save(txt_Cat_Name.Text, txtCategoryNumber.Text, txtDescription.Text);
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                            DataTable dtb= this.cntrl.Load_data();
                            Load_Data(dtb);
                        }
                        else
                        {
                            MessageBox.Show("" + txt_Cat_Name.Text + "  already existed", "Duplication Encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter the Category Name", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (btnOK.Text == "UPDATE")
                {
                    if (txt_Cat_Name.Text != "")
                    {
                        DataTable dt = new DataTable();
                        this.cntrl.update(txt_Cat_Name.Text, txtCategoryNumber.Text, txtDescription.Text,Id);
                        MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        DataTable dtb= this.cntrl.Load_data();
                        Load_Data(dtb);
                        btnOK.Text = "SAVE";
                        btnCancel.Text = "CLOSE";
                    }
                    else
                    {
                        MessageBox.Show("Enter the category Name", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "CANCEL")
            {
                btnOK.Text = "SAVE";
                btnCancel.Text = "CLOSE";
                clear();
            }
            else if (btnCancel.Text == "CLOSE")
            {
                this.Close();
            }
        }
    }
}
