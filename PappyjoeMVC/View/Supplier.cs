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
    public partial class Supplier : Form
    {
        Supplier_controller cntrl=new Supplier_controller();
        int SupplierNumber = 0;
        int supplerName = 0;
        string id;
        public string flag = "";
        public Supplier()
        {
            InitializeComponent();
        }
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            try
            {
               string dt_doc=this.cntrl.Document_number();
                DocumentNumber(dt_doc);
                DataTable dtb= this.cntrl.load_grid();
                LoadGrid(dtb);
                txtSupplierName.Clear();
                dgvSupplier.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvSupplier.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvSupplier.EnableHeadersVisualStyles = false;
                dgvSupplier.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
                foreach (DataGridViewColumn cl in dgvSupplier.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DocumentNumber(string supplier_Count)
        {
            if (String.IsNullOrWhiteSpace(supplier_Count))
            {
                txtSupplierCode.Text = "1";
            }
            else
            {
                int Count = Convert.ToInt32(supplier_Count);
                int incrValue = Convert.ToInt32(Count);
                incrValue += 1;
                txtSupplierCode.Text = incrValue.ToString();
            }
        }

        public void LoadGrid(DataTable dt)
        {
            try
            {
                int num = 1;
                dgvSupplier.RowCount = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvSupplier.Rows.Add();
                        dgvSupplier.Rows[i].Cells["ColslNo"].Value = num;
                        dgvSupplier.Rows[i].Cells["Supplier_Code"].Value = dt.Rows[i]["Supplier_Code"].ToString();
                        dgvSupplier.Rows[i].Cells["Supplier_Name"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                        dgvSupplier.Rows[i].Cells["colEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                        dgvSupplier.Rows[i].Cells["ColDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        num = num + 1;
                    }
                }
                dgvSupplier.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable suppler_Name = this.cntrl.get_suppliername(txtSupplierName.Text);
                if (suppler_Name.Rows.Count <= 0)
                {
                    supplerName = 1;
                }
                else
                {
                    supplerName = 0;
                }
                DataTable Supplier_No = this.cntrl.get_suplier_phone(txtPhone.Text);
                if (Supplier_No.Rows.Count <= 0)
                {
                    SupplierNumber = 1;
                }
                else
                {
                    SupplierNumber = 0;
                }
                if (!string.IsNullOrWhiteSpace(txtSupplierName.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) && !string.IsNullOrWhiteSpace(txtContactPerson.Text) && !string.IsNullOrWhiteSpace(txtOB.Text))
                {
                    if (btnSaveSupplier.Text != "UPDATE SUPPLIER")
                    {
                        if (supplerName == 1 || SupplierNumber == 1)
                        {
                            int i = this.cntrl.Save(txtSupplierCode.Text, txtSupplierName.Text, txtContactPerson.Text, txtPhone.Text, txtphone2.Text, txtEmail.Text, txt_fax.Text, txtWeb.Text, txtAddress1.Text, txtaddress2.Text, txtAddresss3.Text, txtOB.Text);
                            btnSaveSupplier.Text = "SAVE SUPPLIER";
                            btn_Cancel.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Supplier already existed...", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtSupplierName.Focus();
                        }
                    }
                    else
                    {
                        this.cntrl.update(id, txtSupplierCode.Text, txtSupplierName.Text, txtContactPerson.Text, txtPhone.Text, txtphone2.Text, txtEmail.Text, txt_fax.Text, txtWeb.Text, txtAddress1.Text, txtaddress2.Text, txtAddresss3.Text, txtOB.Text);
                        btnSaveSupplier.Text = "Save Supplier";
                        btn_Cancel.Visible = false;
                    }
                    Clear();
                   string sup_code= this.cntrl.Document_number();
                    DocumentNumber(sup_code);
                    DataTable dtb= this.cntrl.load_grid();
                    LoadGrid(dtb);
                    txtSupplierName.Focus();
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                    {
                        MessageBox.Show("Enter the supplier name", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSupplierName.Focus(); return;
                    }
                    else if (string.IsNullOrWhiteSpace(txtPhone.Text))
                    {
                        MessageBox.Show("Enter the supplier phone number", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPhone.Focus(); return;
                    }
                    else if (string.IsNullOrWhiteSpace(txtContactPerson.Text))
                    {
                        MessageBox.Show("Enter the Contact Person name", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtContactPerson.Focus(); return;
                    }
                    else if (string.IsNullOrWhiteSpace(txtOB.Text))
                    {
                        MessageBox.Show("Enter the opening balance", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtOB.Focus(); return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex != -1)
                {
                    if (dgvSupplier.CurrentCell.OwningColumn.Name == "colEdit")
                    {
                        id = dgvSupplier.CurrentRow.Cells["Supplier_Code"].Value.ToString();
                        if (id != "")
                        {
                          DataTable dtb=this.cntrl.Get_suplierDetails(id);
                            Fill_SuplierDetails(dtb);
                        }
                    }
                    else if (dgvSupplier.CurrentCell.OwningColumn.Name == "ColDelete")
                    {
                        int r = dgvSupplier.CurrentRow.Index;
                        id = dgvSupplier.Rows[r].Cells["Supplier_Code"].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            int i = this.cntrl.delete(id);
                            if (i > 0)
                            {
                               DataTable dtb=this.cntrl.load_grid();
                                LoadGrid(dtb);
                                btnSaveSupplier.Text = "SAVE SUPPLIER";
                            }
                        }
                      string dt_doc=this.cntrl.Document_number();
                        DocumentNumber(dt_doc);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void Fill_SuplierDetails(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txtSupplierCode.Text = dt.Rows[0]["Supplier_Code"].ToString();
                    txtSupplierName.Text = dt.Rows[0]["Supplier_Name"].ToString();
                    txtContactPerson.Text = dt.Rows[0]["Contact_Person"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone1"].ToString();
                    txtphone2.Text = dt.Rows[0]["Phone2"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    txt_fax.Text = dt.Rows[0]["Fax"].ToString();
                    txtWeb.Text = dt.Rows[0]["Web"].ToString();
                    txtAddress1.Text = dt.Rows[0]["Address1"].ToString();
                    txtaddress2.Text = dt.Rows[0]["Address2"].ToString();
                    txtAddresss3.Text = dt.Rows[0]["Address3"].ToString();
                    txtOB.Text = dt.Rows[0]["Opeinig_Balance"].ToString();
                    btnSaveSupplier.Text = "UPDATE SUPPLIER";
                    btn_Cancel.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Clear()
        {
            txtSupplierCode.Text ="";
            txtSupplierName.Text = "";
            txtContactPerson.Text = "";
            txtPhone.Text ="";
            txtphone2.Text = "";
            txtEmail.Text = "";
            txt_fax.Text = "";
            txtWeb.Text = "";
            txtAddress1.Text = "";
            txtaddress2.Text = "";
            txtAddresss3.Text = "";
            txtOB.Text = "";
        }
        private void txtSupplierCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtSupplierCode.Text == null)
            {
                MessageBox.Show("Enter Supplier Code", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSupplierCode.Text = "";
                txtSupplierCode.Focus();
            }
        }

        private void txtSupplierName_Validating(object sender, CancelEventArgs e)
        {
            if (txtSupplierName.Text == null)
            {
                MessageBox.Show("Enter Supplier Name", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSupplierName.Focus();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Clear();
            btnSaveSupplier.Text = "SAVE SUPPLIER";
            btn_Cancel.Visible = false;
            this.cntrl.Document_number();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtphone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!PappyjoeMVC.Model.Connection.checkforemail(txtEmail.Text.ToString()) && txtEmail.Text != "")
            {
                MessageBox.Show("invalid Email address/Password", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.TextLength != 10)
            {
                Lab_InvalidNumber.Visible = true;
                return;
            }
            else
            {
                Lab_InvalidNumber.Visible = false;
            }
        }

        private void txtphone2_Leave(object sender, EventArgs e)
        {
            
            if(txtphone2.Text!="")
            {
                if (txtphone2.TextLength != 10)
                {
                    label5.Visible = true;
                    return;
                }
                else
                {
                    label5.Visible = false;
                }
            }
            else
            {
                label5.Visible = false;
            }
            
        }
    }
}
