using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Purchase_Item_Report : Form
    {
        
        int pur_id1 = 0;
        DateTime from1, to1;
        Purchase_Item_Report_controller ctrlr = new Purchase_Item_Report_controller();
        public Purchase_Item_Report(int pur_id, DateTime from, DateTime to)
        {
            InitializeComponent();
            pur_id1 = pur_id;
            from1 = from;
            to1 = to;
        }
        private void Purchase_Item_Report_Load(object sender, EventArgs e)
        {
            dptMonthly_From.Value = from1;
            dptMonthly_To.Value = to1;
            txtPurch_no.Text = pur_id1.ToString();
            decimal total = 0;
            decimal total1 = 0;
            DataTable dt = this.ctrlr.purchitem(pur_id1.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvPurchase.Rows.Add();
                    dgvPurchase.Rows[i].Cells["SL_NO"].Value = i + 1;
                    dgvPurchase.Rows[i].Cells["PurchDate"].Value = Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("yyyy-MM-dd");
                    dgvPurchase.Rows[i].Cells["Item_id"].Value = dt.Rows[i]["Item_Code"].ToString();
                    dgvPurchase.Rows[i].Cells["Desccription"].Value = dt.Rows[i]["Desccription"].ToString();
                    dgvPurchase.Rows[i].Cells["PACKING"].Value = dt.Rows[i]["Packing"].ToString();
                    dgvPurchase.Rows[i].Cells["UNIT"].Value = dt.Rows[i]["Unit"].ToString();
                    dgvPurchase.Rows[i].Cells["QTY"].Value = dt.Rows[i]["Qty"].ToString();
                    dgvPurchase.Rows[i].Cells["FREE"].Value = dt.Rows[i]["FreeQty"].ToString();
                    dgvPurchase.Rows[i].Cells["UNIT_COST"].Value = dt.Rows[i]["Rate"].ToString();
                    dgvPurchase.Rows[i].Cells["GST"].Value = dt.Rows[i]["GST"].ToString();
                    dgvPurchase.Rows[i].Cells["IGST"].Value = dt.Rows[i]["IGST"].ToString();
                    dgvPurchase.Rows[i].Cells["AMOUNT"].Value = dt.Rows[i]["Amount"].ToString();
                    total = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                    total1 = total + total1;
                }
                txtTotalItem.Text = dgvPurchase.Rows.Count.ToString();
                txtGrandTotal.Text = total1.ToString();
            }
            dgvPurchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvPurchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPurchase.EnableHeadersVisualStyles = false;
            dgvPurchase.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
       
    }
}
