using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Purchase_order_list : Form
    {
        Purchase_order_list_controller cntrl = new Purchase_order_list_controller();
        public Purchase_order_list()
        {
            InitializeComponent();
        }
        public Purchase_order_list(string date1, string date2)
        {
            InitializeComponent();
            dateFrom = date1;
            dateTo = date2;
            flag_fromm_inventory = true;
        }
        public static int purch_id;
        public static int Pur_order_no;
        string dateTo;
        string dateFrom; bool flag_fromm_inventory = false;
        public static string Pur_order_Print;
        public static int purchOrderNo;
        public static int rowindex;
        private void Purchase_order_list_Load(object sender, EventArgs e)
        {
            {
                if (flag_fromm_inventory == true)
                {
                    Lab_Msg.Hide();
                    dtpFrom.Value = Convert.ToDateTime(dateFrom);
                    dtpTo.Value = Convert.ToDateTime(dateTo);
                    int slno = 0;
                    DataTable dt = this.cntrl.PurchaseDataBydate(dateFrom, dateTo);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            slno = i + 1;
                            dgvItemData.Rows.Add(slno, dt.Rows[i]["Pur_order_no"].ToString(), Convert.ToDateTime(dt.Rows[i]["Purch_order_date"].ToString()).ToString("MM/dd/yyyy"), dt.Rows[i]["Supplier_Name"].ToString(), dt.Rows[i]["qty"].ToString(), dt.Rows[i]["amount"].ToString());
                        }
                    }
                    else
                    {
                        int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Show();
                    }
                }
                else
                {
                    load();
                }
                dgvItemData.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvItemData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvItemData.EnableHeadersVisualStyles = false;
                dgvItemData.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvItemData.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvItemData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvItemData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvItemData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvItemData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        public void load()
        {
            int slno = 0;
            Lab_Msg.Hide();
            PappyjoeMVC.Model.Connection.MyGlobals.Date_From = dtpFrom.Value.ToString("yyyy-MM-dd");
            PappyjoeMVC.Model.Connection.MyGlobals.Date_To = dtpTo.Value.ToString("yyyy-MM-dd");
            dgvItemData.Rows.Clear();
            string fromdate = dtpFrom.Value.ToString("yyyy-MM-dd");
            string todate = dtpTo.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(fromdate).Date > Convert.ToDateTime(todate).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFrom.Value = DateTime.Today;
            }
            else
            {
                DataTable dt = this.cntrl.Purchase(dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"));
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        slno = i + 1;
                        dgvItemData.Rows.Add(slno, dt.Rows[i]["Pur_order_no"].ToString(), Convert.ToDateTime(dt.Rows[i]["Purch_order_date"].ToString()).ToString("MM/dd/yyyy"), dt.Rows[i]["Supplier_Name"].ToString(), dt.Rows[i]["qty"].ToString(), dt.Rows[i]["amount"].ToString());
                    }
                }
                else
                {
                    int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
            }
        }

        private void dgvItemData_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvItemData.Rows.Count > 0)
            {
                purch_id = Convert.ToInt32(dgvItemData.CurrentRow.Cells["Pur_order_noee"].Value.ToString());
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPurchase_Click(object sender, EventArgs e)
        {
            if (purch_id > 0)
            {
                PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
                var form2 = new PappyjoeMVC.View.Purchase(purch_id);
                form2.ShowDialog();
                form2.Dispose();
            }
        }
        private void dgvItemData_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {
                if (dgvItemData.Rows.Count > 0)
                {
                    purch_id = Convert.ToInt32(dgvItemData.CurrentRow.Cells["Pur_order_noee"].Value.ToString());
                    int rowindex = dgvItemData.CurrentRow.Index;
                    if (dgvItemData.CurrentCell.OwningColumn.Name == "edit")
                    {
                        PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
                        var form2 = new PappyjoeMVC.View.PurchaseOrder(purch_id);
                        form2.ShowDialog();
                    }
                    else if (dgvItemData.CurrentCell.OwningColumn.Name == "del")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            int purodno = Convert.ToInt32(dgvItemData.Rows[rowindex].Cells["Pur_order_noee"].Value.ToString());
                            this.cntrl.Get_PrchseData(purodno);
                            dgvItemData.Rows.RemoveAt(rowindex);
                        }
                    }
                }
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            load();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            load();
        }

        private void dgvItemData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
            rowindex = dgvItemData.CurrentRow.Index;
            purchOrderNo = Convert.ToInt32(dgvItemData.Rows[rowindex].Cells["Pur_order_noee"].Value.ToString());
        }
    }
}
