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
    public partial class Sales_Return_Batch : Form
    {
        public static string ItemCode; public static string Unit;
        public static decimal Quantity, Last_qty; public static string InvNum;
        decimal curent_Stock = 0; public decimal TotalQty = 0;
        public decimal TotalStock = 0; DataTable dtb = new DataTable();
        Sales_Return_Batch_Controller cntrl = new Sales_Return_Batch_Controller();
        public Sales_Return_Batch()
        {
            InitializeComponent();
        }

        public Sales_Return_Batch(string itemCode_From_List, decimal qty, string text1, string text2)
        {
            InitializeComponent();
            ItemCode = itemCode_From_List;
            Quantity = qty;
            InvNum = text1;
            Unit = text2;  
        }

        private void Sales_Return_Batch_Load(object sender, EventArgs e)
        {
            DataTable dt_items = this.cntrl.Get_unites(ItemCode);
            DataTable dt_batchSale = this.cntrl.dtb_load(InvNum, ItemCode);
            if (Convert.ToDecimal(dt_batchSale.Rows[0]["RetQty"].ToString()) > 0)
            {
                decimal qty = 0;
                if (dt_batchSale.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_batchSale.Rows.Count; i++)
                    {
                        dgv_batchSale.Rows.Add();
                        dgv_batchSale.Rows[i].Cells["colbatchNo"].Value = dt_batchSale.Rows[i]["BatchNumber"].ToString();
                        qty = Convert.ToDecimal(dt_batchSale.Rows[i]["Qty"].ToString()) - Convert.ToDecimal(dt_batchSale.Rows[i]["RetQty"].ToString()); 
                        dgv_batchSale.Rows[i].Cells["ColQty"].Value = qty;
                        dgv_batchSale.Rows[i].Cells["colBatchentry"].Value = dt_batchSale.Rows[i]["BatchEntry"].ToString();
                        dgv_batchSale.Rows[i].Cells["oldstock"].Value = dt_batchSale.Rows[i]["Stock"].ToString();
                        dgv_batchSale.Rows[i].Cells["colEntry"].Value = dt_batchSale.Rows[i]["Entry_No"].ToString();
                        TotalStock = TotalStock + Convert.ToDecimal(dt_batchSale.Rows[i]["Qty"].ToString());
                        dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = dt_batchSale.Rows[i]["Stock"].ToString();
                    }
                }
            }
            else
            {
                if (dt_batchSale.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_batchSale.Rows.Count; i++)
                    {

                        dgv_batchSale.Rows.Add();
                        dgv_batchSale.Rows[i].Cells["colbatchNo"].Value = dt_batchSale.Rows[i]["BatchNumber"].ToString();
                        dgv_batchSale.Rows[i].Cells["ColQty"].Value = Convert.ToDecimal(dt_batchSale.Rows[i]["Qty"].ToString()).ToString();
                        dgv_batchSale.Rows[i].Cells["colBatchentry"].Value = dt_batchSale.Rows[i]["BatchEntry"].ToString();
                        dgv_batchSale.Rows[i].Cells["colEntry"].Value = dt_batchSale.Rows[i]["Entry_No"].ToString();
                        dgv_batchSale.Rows[i].Cells["oldstock"].Value = dt_batchSale.Rows[i]["Stock"].ToString();
                        TotalStock = TotalStock + Convert.ToDecimal(dt_batchSale.Rows[i]["Qty"].ToString());
                        dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = dt_batchSale.Rows[i]["Stock"].ToString();
                    }
                }
            }

            calc();
            dgv_batchSale.Columns["colbatchNo"].ReadOnly = true;
            dgv_batchSale.Columns["ColQty"].ReadOnly = true;
            dgv_batchSale.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_batchSale.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_batchSale.EnableHeadersVisualStyles = false;
            dgv_batchSale.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
            foreach (DataGridViewColumn cl in dgv_batchSale.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            decimal qty = 0;
            dtb.Columns.Clear();
            dtb.Rows.Clear();
            foreach (DataGridViewRow dr in dgv_batchSale.Rows)
            {
                if (dr.Cells["colReturnQty"].Value != null && dr.Cells["colReturnQty"].Value.ToString() != "")
                {
                    qty = qty + Convert.ToDecimal(dr.Cells["colReturnQty"].Value.ToString());
                }
            }
            if (qty == TotalQty)
            {
                if (dgv_batchSale.Rows.Count > 0)
                {
                    foreach (DataGridViewColumn col in dgv_batchSale.Columns)
                    {
                        dtb.Columns.Add(col.Name);
                    }
                    foreach (DataGridViewRow row in dgv_batchSale.Rows)
                    {
                        DataRow dRow = dtb.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dRow[cell.ColumnIndex] = cell.Value;
                        }
                        dtb.Rows.Add(dRow);
                    }
                }
                if (dtb.Rows.Count > 0)
                {
                    var form2 = new Sales_Return(dtb);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please make sure the quanties are equall !..", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            var form2 = new Sales_Return();
            form2.Closed += (sender1, args) => this.Close();
            this.Close();
        }

        private void dgv_batchSale_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                e.Control.KeyPress +=
               new KeyPressEventHandler(Control_KeyPress);
            }
            catch (Exception ex)
            {

            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgv_batchSale_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (Convert.ToDecimal(dgv_batchSale.Rows[dgv_batchSale.CurrentRow.Index].Cells["ColQty"].Value) <= 0)
                {
                    MessageBox.Show("There is no stock existed in this batch", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void calc()
        {
            DataTable dt_unit1 = this.cntrl.get_item_unitmf(ItemCode);
            decimal Remaning_qty = 0;
            Remaning_qty = Quantity;
            TotalQty = Quantity;
            decimal stk_value = 0;
            if (dt_unit1.Rows[0]["OneUnitOnly"].ToString() == "False")
            {
                decimal unitmf = Convert.ToDecimal(dt_unit1.Rows[0]["UnitMF"].ToString());
                if (dt_unit1.Rows[0]["Unit1"].ToString() == Unit)
                {
                    Remaning_qty = Quantity * unitmf;
                    TotalQty = Quantity * unitmf;
                    if (TotalQty <= TotalStock)
                    {
                        for (int i = 0; i < dgv_batchSale.Rows.Count; i++)
                        {
                            if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value))
                            {
                                dgv_batchSale.Rows[i].Cells["colReturnQty"].Value = Remaning_qty.ToString();
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["oldstock"].Value.ToString()) + Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["colReturnQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                break;
                            }
                            else
                            {
                                stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colReturnQty"].Value = stk_value;
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["oldstock"].Value.ToString()) + Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["colReturnQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                Remaning_qty = Remaning_qty - stk_value;
                            }
                        }
                    }
                }
                else
                {
                    if (TotalQty <= TotalStock)
                    {
                        for (int i = 0; i < dgv_batchSale.Rows.Count; i++)
                        {
                            if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value))
                            {
                                dgv_batchSale.Rows[i].Cells["colReturnQty"].Value = Remaning_qty.ToString();
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["oldstock"].Value.ToString()) + Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["colReturnQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                break;
                            }
                            else
                            {
                                stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colReturnQty"].Value = stk_value;
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["oldstock"].Value.ToString()) + Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["colReturnQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                Remaning_qty = Remaning_qty - stk_value;
                            }
                        }
                    }
                }
            }
            else
            {
                if (TotalQty <= TotalStock)
                {
                    for (int i = 0; i < dgv_batchSale.Rows.Count; i++)
                    {
                        if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value))
                        {
                            dgv_batchSale.Rows[i].Cells["colReturnQty"].Value = Remaning_qty.ToString();
                            curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["oldstock"].Value.ToString()) + Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["colReturnQty"].Value.ToString());
                            dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                            break;
                        }
                        else
                        {
                            stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                            dgv_batchSale.Rows[i].Cells["colReturnQty"].Value = stk_value;
                            curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["oldstock"].Value.ToString()) + Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["colReturnQty"].Value.ToString());
                            dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                            Remaning_qty = Remaning_qty - stk_value;
                        }
                    }
                }
            }
        }
    }
}
