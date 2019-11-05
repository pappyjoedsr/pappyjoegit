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
    public partial class Purchase_Return_ItemList : Form
    {
        Purchase_Return_ItemList_controller cntrl = new Purchase_Return_ItemList_controller();
        int pur_no1 = 0;
        string Pur_date1;
        string sup_name1;
        int sup_id1 = 0;
        public static string itemcd = "";
        public Purchase_Return_ItemList()
        {
            InitializeComponent();
        }

        public Purchase_Return_ItemList(int pur_no, string pur_date, string sup_name, int sup_id)
        {
            InitializeComponent();
            pur_no1 = pur_no;
            Pur_date1 = pur_date;
            sup_name1 = sup_name;
            sup_id1 = sup_id;
        }
        private void Purchase_Return_ItemList_Load(object sender, EventArgs e)
        {
            DataTable dt = this.cntrl.Load_Items(pur_no1);
            if (dt.Rows.Count > 0)
            {
                fill_grid(dt);
            }
        }
        public void fill_grid(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgvItemList.Rows.Clear();
                foreach (DataRow dr in dtb.Rows)
                {
                    dgvItemList.Rows.Add(dr["id"].ToString(), dr["Item_Code"].ToString(), dr["item_name"].ToString());
                }
            }
        }
        private void dgvItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItemList.Rows.Count > 0)
            {
                int rowindex = dgvItemList.CurrentRow.Index;
                itemcd = dgvItemList.Rows[rowindex].Cells["id"].Value.ToString();
            }
        }

        private void dgvItemList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItemList.Rows.Count > 0)
            {
                int rowindex = dgvItemList.CurrentRow.Index;
                itemcd = dgvItemList.Rows[rowindex].Cells["id"].Value.ToString();
                var form = new Purchase_Return(itemcd, pur_no1, Pur_date1, sup_name1, sup_id1);
                form.Closed += (sender1, args) => this.Close();
                this.Hide();
            }
        }
        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text != "")
            {
                DataTable dtb = this.cntrl.search_items(pur_no1, txt_Search.Text);
                if (dtb.Rows.Count > 0)
                {
                    fill_grid(dtb);
                }
                else
                {
                    dgvItemList.RowCount = 0;
                    Lab_Msg.Visible = true;
                }
            }
            else
            {
                Lab_Msg.Visible = false;
                DataTable dt1 = new DataTable();
                dt1 = this.cntrl.Load_Items(pur_no1);
                if (dt1.Rows.Count > 0)
                {
                    fill_grid(dt1);
                }
            }
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text != "")
            {
                txt_Search.Text = "";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
