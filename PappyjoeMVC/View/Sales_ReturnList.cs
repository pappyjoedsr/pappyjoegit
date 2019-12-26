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
    public partial class Sales_ReturnList : Form
    {
        Sales_Return_List_Controller cntrl = new Sales_Return_List_Controller();
        public Sales_ReturnList()
        {
            InitializeComponent();
        }

        private void Sales_ReturnList_Load(object sender, EventArgs e)
        {

            Lab_Msg.Visible = false;
            DateTime date = DateTime.Now.Date;
            DataTable dtb = new DataTable();
            dtb = this.cntrl.Load_grid(date.ToString("yyyy-MM-dd"));
            if (dtb.Rows.Count > 0)
            {
                grid_fill(dtb);
            }
            else
            {
                int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Visible = true;
            }
            dgv_sales.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_sales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_sales.EnableHeadersVisualStyles = false;
            dgv_sales.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
            dgv_sales.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_sales.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_sales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn cl in dgv_sales.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void grid_fill(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_sales.Rows.Clear();
                int num = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_sales.Rows.Add();
                    dgv_sales.Rows[i].Cells["colslNo"].Value = num;
                    dgv_sales.Rows[i].Cells["RetNumber"].Value = dtb.Rows[i]["RetNumber"].ToString();
                    dgv_sales.Rows[i].Cells["ReturnDate"].Value =Convert.ToDateTime(dtb.Rows[i]["ReturnDate"].ToString()).ToString("MM/dd/yyyy");
                    dgv_sales.Rows[i].Cells["InvNumber"].Value = dtb.Rows[i]["InvNumber"].ToString();
                    dgv_sales.Rows[i].Cells["InvDate"].Value =Convert.ToDateTime(dtb.Rows[i]["InvDate"].ToString()).ToString("MM/dd/yyyy");
                    dgv_sales.Rows[i].Cells["colcustNo"].Value = dtb.Rows[i]["cust_number"].ToString();
                    dgv_sales.Rows[i].Cells["colItems"].Value = dtb.Rows[i]["items"].ToString();
                    dgv_sales.Rows[i].Cells["ColAmount"].Value = dtb.Rows[i]["TotalAmount"].ToString();
                    num = num + 1;
                }
            }
        }
        private void dgv_sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_sales.CurrentCell.OwningColumn.Name == "RetNumber")
                {
                    int Ret_no = Convert.ToInt32(dgv_sales.CurrentRow.Cells["RetNumber"].Value.ToString());
                    if (Ret_no >0)
                    {
                        var form2 = new Sales_Return(Ret_no);
                        form2.ShowDialog();
                        form2.Dispose();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Lab_Msg.Visible = false;
            DateTime date = DateTime.Now.Date;
            DataTable dtb = this.cntrl.Load_return_detail(date.ToString("yyyy-MM-dd"));
            if (dtb.Rows.Count > 0)
            {
                grid_fill(dtb);
            }
            else
            {
                int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Visible = true;
            }
        }

        private void Btn_Show_Click(object sender, EventArgs e)
        {
            string from = DTP_From.Value.ToString("yyyy-MM-dd"); 
            string to = DTP_To.Value.ToString("yyyy-MM-dd");
            Lab_Msg.Visible = false;
            if (Convert.ToDateTime(from).Date > Convert.ToDateTime(to).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DTP_From.Value = DateTime.Today;
            }
            else
            {
                DataTable dt = this.cntrl.load_details_wit_date(from, to);
                if (dt.Rows.Count > 0)
                {
                    grid_fill(dt);
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Visible = true;
                }
            }
        }
    }
}
