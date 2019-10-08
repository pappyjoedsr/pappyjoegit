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
//using System.Data;
namespace PappyjoeMVC.View
{
    public partial class Batch_Sale : Form
    {
        batchsale_controller cntrl=new batchsale_controller();
        public static string ItemCode;
        public static decimal Quantity;
        public static string Unit;
        public static string Unit_edit;
        public decimal TotalStock = 0;
        public static bool edit_flag = false;
        public string item_Code_edit;
        public DataTable dtbBatchsale;
        public decimal TotalQty = 0; decimal curent_Stock;
        DataTable dtb_Sales = new DataTable();
        public Batch_Sale()
        {
            InitializeComponent();
        }

        public Batch_Sale(string item_Code, decimal qty, string unit)
        {
            InitializeComponent();
            ItemCode = item_Code;
            Quantity = qty;
            Unit = unit;
        }

        public Batch_Sale(string item_Code, decimal qty, DataTable frmBatchsale_edit, string unit)
        {
            InitializeComponent();
            ItemCode = item_Code;
            Quantity = qty;
            dtbBatchsale = frmBatchsale_edit;
            Unit = unit;
            edit_flag = true;
        }
        private void frmbatchSale_Load(object sender, EventArgs e)
        {
            dgv_batchSale.Columns["colbatchNo"].ReadOnly = true;
            dgv_batchSale.Columns["ColStock"].ReadOnly = true;
            dgv_batchSale.Columns["ColPrd_Date"].ReadOnly = true;
            dgv_batchSale.Columns["colExpDate"].ReadOnly = true;
            DataTable dtb= this.cntrl.get_batchdetails(ItemCode);
            fill_grid(dtb);
            if (edit_flag == true)
            {
                if (dtbBatchsale.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbBatchsale.Rows.Count; i++)
                    {
                        dgv_batchSale.Rows[i].Cells["ColStock"].Value = dtbBatchsale.Rows[i]["colStock"].ToString();
                        TotalStock = TotalStock + Convert.ToDecimal(dtbBatchsale.Rows[i]["colStock"].ToString());
                        dgv_batchSale.Rows[i].Cells["ColPrd_Date"].Value = Convert.ToDateTime(dtbBatchsale.Rows[i]["prddate"].ToString()).ToString("MM/dd/yyyy");
                        if (dtbBatchsale.Rows[i]["expdate"].ToString() != "")
                            dgv_batchSale.Rows[i].Cells["colExpDate"].Value = Convert.ToDateTime(dtbBatchsale.Rows[i]["expdate"].ToString()).ToString("MM/dd/yyyy");
                        else
                            dgv_batchSale.Rows[i].Cells["colExpDate"].Value = "";
                    }
                    calc();
                }
                else
                {
                    MessageBox.Show("No Records Found..", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                calc();
            }
            dgv_batchSale.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_batchSale.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_batchSale.EnableHeadersVisualStyles = false;
            dgv_batchSale.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
            dgv_batchSale.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_batchSale.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn cl in dgv_batchSale.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void fill_grid(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_batchSale.Rows.Add();
                    dgv_batchSale.Rows[i].Cells["colentryNo"].Value = dtb.Rows[i]["Entry_No"].ToString();
                    dgv_batchSale.Rows[i].Cells["colbatchNo"].Value = dtb.Rows[i]["BatchNumber"].ToString();
                    dgv_batchSale.Rows[i].Cells["ColStock"].Value = dtb.Rows[i]["Qty"].ToString();
                    TotalStock = TotalStock + Convert.ToDecimal(dtb.Rows[i]["Qty"].ToString());
                    dgv_batchSale.Rows[i].Cells["ColPrd_Date"].Value = Convert.ToDateTime(dtb.Rows[i]["PrdDate"].ToString()).ToString("MM/dd/yyyy");
                    if (dtb.Rows[i]["ExpDate"].ToString() != "")
                    {
                        dgv_batchSale.Rows[i].Cells["colExpDate"].Value = Convert.ToDateTime(dtb.Rows[i]["ExpDate"].ToString()).ToString("MM/dd/yyyy");
                    }
                    else
                        dgv_batchSale.Rows[i].Cells["colExpDate"].Value = "";
                }
            }
        }
        public void calc()
        {
            try
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
                                if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value))
                                {
                                    dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                    dgv_batchSale.Rows[i].Cells["ColQty"].Value = Remaning_qty.ToString();
                                    curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                    dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                    break;
                                }
                                else
                                {
                                    stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString());
                                    dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                    dgv_batchSale.Rows[i].Cells["ColQty"].Value = stk_value;
                                    curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
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
                                if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value))
                                {
                                    dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                    dgv_batchSale.Rows[i].Cells["ColQty"].Value = Remaning_qty.ToString();
                                    curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                    dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                    break;
                                }
                                else
                                {
                                    stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString());
                                    dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                    dgv_batchSale.Rows[i].Cells["ColQty"].Value = stk_value;
                                    curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
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
                            if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value))
                            {
                                dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                dgv_batchSale.Rows[i].Cells["ColQty"].Value = Remaning_qty.ToString();
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                break;
                            }
                            else
                            {
                                stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                dgv_batchSale.Rows[i].Cells["ColQty"].Value = stk_value;
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                Remaning_qty = Remaning_qty - stk_value;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantity is greater than the stock", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void stock_Calculation()
        {
            try
            {
                DataTable dt_unit1 = this.cntrl.get_item_unitmf(ItemCode);
                decimal Remaning_qty = 0;
                Remaning_qty = Quantity;
                TotalQty = Quantity;
                for (int i = 0; i < dgv_batchSale.Rows.Count; i++)
                {
                    decimal stk_value = 0;
                    if (dt_unit1.Rows[0]["OneUnitOnly"].ToString() == "False")
                    {
                        decimal unitmf = Convert.ToDecimal(dt_unit1.Rows[0]["UnitMF"].ToString());
                        if (dt_unit1.Rows[0]["Unit1"].ToString() == Unit)
                        {
                            Remaning_qty = Quantity * unitmf;
                            TotalQty = Quantity * unitmf;
                            if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value))
                            {
                                dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                dgv_batchSale.Rows[i].Cells["ColQty"].Value = Remaning_qty.ToString();
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                break;
                            }
                            else
                            {
                                stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                dgv_batchSale.Rows[i].Cells["ColQty"].Value = stk_value;
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                Remaning_qty = Remaning_qty - stk_value;
                            }
                        }
                        else
                        {
                            if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value))
                            {
                                dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                dgv_batchSale.Rows[i].Cells["ColQty"].Value = Remaning_qty.ToString();
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                break;
                            }
                            else
                            {
                                stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                                dgv_batchSale.Rows[i].Cells["ColQty"].Value = stk_value;
                                curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                                dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                                Remaning_qty = Remaning_qty - stk_value;
                            }
                        }
                    }
                    else
                    {
                        if (Remaning_qty <= Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value))
                        {
                            dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                            dgv_batchSale.Rows[i].Cells["ColQty"].Value = Remaning_qty.ToString();
                            curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                            dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                            break;
                        }
                        else
                        {
                            stk_value = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString());
                            dgv_batchSale.Rows[i].Cells["clUnit"].Value = Unit;
                            dgv_batchSale.Rows[i].Cells["ColQty"].Value = stk_value;
                            curent_Stock = Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColStock"].Value.ToString()) - Convert.ToDecimal(dgv_batchSale.Rows[i].Cells["ColQty"].Value.ToString());
                            dgv_batchSale.Rows[i].Cells["colCurrentStock"].Value = curent_Stock.ToString();
                            Remaning_qty = Remaning_qty - stk_value;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                decimal qty = 0;
                dtb_Sales.Columns.Clear();
                dtb_Sales.Rows.Clear();
                foreach (DataGridViewRow dr in dgv_batchSale.Rows)
                {
                    if (dr.Cells["ColQty"].Value != null && dr.Cells["ColQty"].Value.ToString() != "")
                    {
                        qty = qty + Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString());
                    }
                    else
                    {
                        dr.Cells["colCurrentStock"].Value = dr.Cells["ColStock"].Value.ToString();
                    }
                }
                if (edit_flag == true)
                {
                    if (qty == TotalQty)
                    {
                        foreach (DataGridViewColumn col in dgv_batchSale.Columns)
                        {
                            dtb_Sales.Columns.Add(col.Name);
                        }
                        foreach (DataGridViewRow row in dgv_batchSale.Rows)
                        {
                            DataRow dRow = dtb_Sales.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {

                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dtb_Sales.Rows.Add(dRow);
                        }
                        if (dtb_Sales.Rows.Count > 0)
                        {
                            var form2 = new Sales(dtb_Sales);
                            form2.Closed += (sender1, args) => this.Close();
                            edit_flag = false;
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure the quanties are equall ", "Not Equall", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (qty == TotalQty)
                    {
                        foreach (DataGridViewColumn col in dgv_batchSale.Columns)
                        {
                            dtb_Sales.Columns.Add(col.Name);
                        }
                        foreach (DataGridViewRow row in dgv_batchSale.Rows)
                        {
                            DataRow dRow = dtb_Sales.NewRow();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                dRow[cell.ColumnIndex] = cell.Value;
                            }
                            dtb_Sales.Rows.Add(dRow);
                        }
                        if (dtb_Sales.Rows.Count > 0)
                        {
                            var form2 = new Sales(dtb_Sales);
                            form2.Closed += (sender1, args) => this.Close();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please make sure the quanties are equall ", "Not Equall", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_batchSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_batchSale.CurrentCell.OwningColumn.Name == "ColQty")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DataTable newTable = (DataTable)dgv_batchSale.DataSource;
            var form2 = new Sales(newTable);
            form2.Closed += (sender1, args) => this.Close();
            this.Close();
        }
    }
}
