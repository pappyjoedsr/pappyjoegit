using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Purchase_Return_List : Form
    {
        Purchase_return_list_controller cntrl = new Purchase_return_list_controller();
        public Purchase_Return_List()
        {
            InitializeComponent();
        }
        string datefrm, dateto;
        bool flag_frm_invntry = false;
        int rowindex, purchRetNo;
        public Purchase_Return_List(string date1, string date2)
        {
            InitializeComponent();
            datefrm = date1;
            dateto = date2;
            flag_frm_invntry = true;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
            PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
            string fromdate = DTP_From.Value.ToString("yyyy-MM-dd");
            string todate = DTP_To.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(fromdate).Date > Convert.ToDateTime(todate).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DTP_From.Value = DateTime.Today;
                return;
            }
            DataTable dt = this.cntrl.get_purchaseretnList_data(DTP_From.Value.ToString("yyyy-MM-dd"), DTP_To.Value.ToString("yyyy-MM-dd"));
            load(dt);
        }

        private void dgv_Purchase_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
            rowindex = dgv_Purchase.CurrentRow.Index;
            purchRetNo = Convert.ToInt32(dgv_Purchase.Rows[rowindex].Cells["Purchase_Return_No"].Value.ToString());
            var form2 = new Purchase_Return(purchRetNo);
            form2.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Purchase_Return_List_Load(object sender, EventArgs e)
        {

            {
                if (flag_frm_invntry == true)
                {
                    DataTable dt = this.cntrl.get_purchaseretnList_data(Convert.ToDateTime(datefrm).ToString("yyyy-MM-dd"), Convert.ToDateTime(dateto).ToString("yyyy-MM-dd"));
                    load(dt);
                }
                else
                {
                    DataTable dt = this.cntrl.get_purchaseretnList_data(DTP_From.Value.ToString("yyyy-MM-dd"), DTP_To.Value.ToString("yyyy-MM-dd"));
                    load(dt);
                }
                dgv_Purchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_Purchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_Purchase.EnableHeadersVisualStyles = false;
                dgv_Purchase.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_Purchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        public void load(DataTable dt)
        {
            Lab_Msg.Hide();
            int slno = 0;
            if (dt.Rows.Count > 0)
            {
                dgv_Purchase.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    slno = i + 1;
                    dgv_Purchase.Rows.Add();
                    dgv_Purchase.Rows[i].Cells["colslNo"].Value = slno.ToString();
                    dgv_Purchase.Rows[i].Cells["colPurNum"].Value = dt.Rows[i]["PurchNumber"].ToString();
                    dgv_Purchase.Rows[i].Cells["Purchase_Return_No"].Value = dt.Rows[i]["RetNumber"].ToString();
                    dgv_Purchase.Rows[i].Cells["ReturnDate"].Value = Convert.ToDateTime(dt.Rows[i]["ReturnDate"].ToString()).ToString("MM/dd/yyyy");
                    dgv_Purchase.Rows[i].Cells["SupplierId"].Value = dt.Rows[i]["Sup_Code"].ToString();
                    dgv_Purchase.Rows[i].Cells["colSupplierName"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                    dgv_Purchase.Rows[i].Cells["colTotalAmount"].Value = Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString()).ToString("##.00");
                }
            }
            else
            {
                Lab_Msg.Show();
            }
            dgv_Purchase.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
            dgv_Purchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

    }
}
