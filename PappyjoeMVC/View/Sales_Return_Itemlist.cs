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
    public partial class Sales_Return_Itemlist : Form
    {
        
        public DataTable ItemList; public static string invNumber;
        Sales_Retuen_Itemlist_Controller cntrl = new Sales_Retuen_Itemlist_Controller();
        
        public Sales_Return_Itemlist()
        {
            InitializeComponent();
        }
         
        public Sales_Return_Itemlist(DataTable dtb_itemlist, string text)
        {
            InitializeComponent();
            ItemList = dtb_itemlist;
            invNumber = text;
        }

        private void Sales_Return_Itemlist_Load(object sender, EventArgs e)
        {
            if (ItemList.Rows.Count > 0)
            {
                for (int i = 0; i < ItemList.Rows.Count; i++)
                {
                    dgv_Item.Rows.Add();
                    dgv_Item.Rows[i].Cells["colitem"].Value = ItemList.Rows[i]["Item_Code"].ToString();
                    dgv_Item.Rows[i].Cells["colBatch"].Value = ItemList.Rows[i]["item_name"].ToString();
                    dgv_Item.Rows[i].Cells["id"].Value = ItemList.Rows[i]["id"].ToString();
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

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string itemcode = dgv_Item.CurrentRow.Cells["id"].Value.ToString();
            if (itemcode != "")
            {
                var form2 = new Sales_Return(itemcode);
                form2.Closed += (sender1, args) => this.Close();
                this.Close();
            }
        }

        private void dgv_Item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string itemcode = dgv_Item.CurrentRow.Cells["id"].Value.ToString();
            if (itemcode != "")
            {
                var form2 = new Sales_Return(itemcode);
                form2.Closed += (sender1, args) => this.Close();
                this.Close();
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (txt_Search.Text != "")
            {
                DataTable dtb = this.cntrl.search_itemlist(invNumber, txt_Search.Text);
                if (dtb.Rows.Count > 0)
                {
                    dgv_Item.Rows.Clear();
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        dgv_Item.Rows.Add();
                        dgv_Item.Rows[i].Cells["colitem"].Value = dtb.Rows[i]["Item_Code"].ToString();
                        dgv_Item.Rows[i].Cells["colBatch"].Value = dtb.Rows[i]["item_name"].ToString();
                        dgv_Item.Rows[i].Cells["id"].Value = dtb.Rows[i]["id"].ToString();
                    }
                }
                else
                {
                    dgv_Item.RowCount = 0;
                    Lab_Msg.Visible = true;
                }
            }
            else
            {
                Lab_Msg.Visible = false;
                DataTable dt1 = new DataTable();
                dt1 = this.cntrl.itemdetails_from_salesit(invNumber);
                if (dt1.Rows.Count > 0)
                {
                    dgv_Item.Rows.Clear();
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        dgv_Item.Rows.Add();
                        dgv_Item.Rows[i].Cells["colitem"].Value = dt1.Rows[i]["Item_Code"].ToString();
                        dgv_Item.Rows[i].Cells["colBatch"].Value = dt1.Rows[i]["item_name"].ToString();
                        dgv_Item.Rows[i].Cells["id"].Value = dt1.Rows[i]["id"].ToString();
                    }
                }
            }
        }
    }
}
