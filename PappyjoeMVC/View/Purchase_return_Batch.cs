using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Purchase_return_Batch : Form
    {
        string itemcode1, unit1; int Pur_no1; decimal qty = 0;
        public static decimal retqty1 = 0;
        purchase_return_batch_controller cntrl = new purchase_return_batch_controller();
        public static DataTable batch = new DataTable();
        public Purchase_return_Batch()
        {
            InitializeComponent();
        }
        public Purchase_return_Batch(string text1, string text2, int v, decimal qtty)
        {
            InitializeComponent();
            unit1 = text1;
            itemcode1 = text2;
            Pur_no1 = v;
            qty = qtty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal qty = 0;
            decimal qty1 = 0;
            decimal retqty = 0;
            decimal retqtyy = 0;
            bool flagRet = false;
            for (int i = 0; i < dgvPurchaseBatch.Rows.Count; i++)
            {
                if (dgvPurchaseBatch.Rows[i].Cells["Return_Qty"].Value != null && dgvPurchaseBatch.Rows[i].Cells["Return_Qty"].Value.ToString() != "")
                {
                    if (Convert.ToDecimal(dgvPurchaseBatch.Rows[i].Cells["Return_Qty"].Value.ToString()) <= Convert.ToDecimal(dgvPurchaseBatch.Rows[i].Cells["Quantity"].Value.ToString()))
                    {
                        retqty = Convert.ToDecimal(dgvPurchaseBatch.Rows[i].Cells["Return_Qty"].Value.ToString());
                        retqtyy = retqtyy + retqty;
                    }
                    else
                    {
                        retqtyy = 0;
                    }
                }
            }
            if (retqtyy > 0)
            {
                flagRet = true;
            }
            if (retqtyy == 0)
            {
                MessageBox.Show("The Return Quantity is greater than Purchace quantity", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            retqty1 = retqtyy;
            if (flagRet == true)
            {
                for (int i = 0; i < dgvPurchaseBatch.Rows.Count; i++)
                {
                    if (dgvPurchaseBatch.Rows[i].Cells["Quantity"].Value != null && dgvPurchaseBatch.Rows[i].Cells["Quantity"].Value.ToString() != "")
                    {
                        qty = Convert.ToDecimal(dgvPurchaseBatch.Rows[i].Cells["Quantity"].Value.ToString());
                        qty1 = qty1 + qty;
                    }
                }
                if (qty1 >= retqtyy)
                {
                    batch.Columns.Clear();
                    batch.Rows.Clear();
                    foreach (DataGridViewColumn col in dgvPurchaseBatch.Columns)
                    {
                        batch.Columns.Add(col.Name);
                    }
                    foreach (DataGridViewRow row in dgvPurchaseBatch.Rows)
                    {
                        DataRow dRow = batch.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dRow[cell.ColumnIndex] = cell.Value;
                        }
                        batch.Rows.Add(dRow);
                    }
                    if (batch.Rows.Count > 0)
                    {
                        var frm = new Purchase_Return(batch, retqty1);
                        frm.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("The Return Quantity is greater than Purchace quantity", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (flagRet == false)
            {
                MessageBox.Show("Enter Return Quantity", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPurchaseBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvPurchaseBatch_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgvPurchaseBatch_KeyPress);
            if (dgvPurchaseBatch.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgvPurchaseBatch_KeyPress);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Purchase_return_Batch_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtunit = new DataTable();
            DataTable dtuni2_1 = new DataTable();
            decimal qtytemp = 0;
            decimal retQty = 0;
            decimal qtytemp1 = 0;
            dtunit = this.cntrl.Get_unites(itemcode1);
            string unit2 = this.cntrl.get_unti2(Pur_no1, itemcode1);
            dt = this.cntrl.get_batch_details(Pur_no1, itemcode1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvPurchaseBatch.Rows.Add();
                dgvPurchaseBatch.Rows[i].Cells["Branch_No"].Value = dt.Rows[i]["BatchNumber"].ToString();
                dgvPurchaseBatch.Rows[i].Cells["col_unit"].Value = unit1.ToString();
                qtytemp = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                retQty = Convert.ToDecimal(dt.Rows[i]["RetQty"].ToString());
                if (unit1 == dtunit.Rows[0]["Unit1"].ToString().Trim())
                {
                    if (Convert.ToDecimal(dtunit.Rows[0]["UnitMF"].ToString()) != 0 && dtunit.Rows[0]["Unit2"].ToString() != "null")
                    {
                        qtytemp = qtytemp / Convert.ToDecimal(dtunit.Rows[0]["UnitMF"].ToString());
                        retQty = retQty / Convert.ToDecimal(dtunit.Rows[0]["UnitMF"].ToString());
                    }
                }
                qtytemp1 = qtytemp - retQty;
                qtytemp1 = System.Math.Round(qtytemp1, 1);
                dgvPurchaseBatch.Rows[i].Cells["Quantity"].Value = qtytemp1;
                dgvPurchaseBatch.Rows[i].Cells["Prd_Date"].Value = Convert.ToDateTime(dt.Rows[i]["PrdDate"].ToString()).ToString("MM/dd/yyyy");
                if (dt.Rows[i]["IsExpDate"].ToString().Trim() != "NO")
                {
                    dgvPurchaseBatch.Rows[i].Cells["Exp_Date"].Value = Convert.ToDateTime(dt.Rows[i]["ExpDate"].ToString()).ToString("MM/dd/yyyy");
                }
                else
                {
                    dgvPurchaseBatch.Rows[i].Cells["Exp_Date"].Value = "";
                }
            }
        }
    }
}
