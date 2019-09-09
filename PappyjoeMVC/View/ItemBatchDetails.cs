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
namespace PappyjoeMVC.View
{
    public partial class ItemBatchDetails : Form
    {
        public static string ItemCode;
        Inventory_model _model = new Inventory_model();
        public ItemBatchDetails()
        {
            InitializeComponent();
        }

        public ItemBatchDetails(string itemcode)
        {
            InitializeComponent();
            ItemCode = itemcode;
        }

        private void FrmItemBatchDetails_Load(object sender, EventArgs e)
        {
            try
            {
                Lab_Msg.Visible = false;
                if (ItemCode != "")
                {
                    DataTable dtb = this._model.Load_batch(ItemCode);
                    if (dtb.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtb.Rows)
                        {
                            dgv_batch.Rows.Add(dr["BatchNumber"].ToString(), dr["Qty"].ToString(), Convert.ToDateTime(dr["ExpDate"].ToString()).ToString("MM/dd/yyyy"), Convert.ToDateTime(dr["PrdDate"].ToString()).ToString("MM/dd/yyyy"), dr["PurchNumber"].ToString(), Convert.ToDateTime(dr["PurchDate"].ToString()).ToString("MM/dd/yyyy"), dr["Sup_Code"].ToString());
                        }
                    }
                    else
                        Lab_Msg.Visible = true;
                }
                dgv_batch.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_batch.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_batch.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dgv_batch.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgv_batch.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
