using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class ItemListForSales : Form
    {
        public static string Form_Name = "";
        public static string Item_Code = "";
        string item_code = ""; string item_Name = ""; string Stock = ""; string ItemID = "";
        ItemListForSales_controller cntrl=new ItemListForSales_controller();
        public ItemListForSales()
        {
            InitializeComponent();
        }

        public ItemListForSales(string formName)
        {
            InitializeComponent();
            Form_Name = formName;
        }

        public ItemListForSales(string formName, string text)
        {
            InitializeComponent();
            Form_Name = formName;
            Item_Code = text;
        }
       
        private void ItemListForSales_Load(object sender, EventArgs e)
        {
            try
            {
                string itemid = this.cntrl.get_itemid(Item_Code);
                if (Form_Name == "Sales")
                {
                    if (Item_Code != "")
                    {
                      DataTable dtb=this.cntrl.Load_items_wit_itemcode(itemid);
                      fill_Grid(dtb);
                    }
                    else
                    {
                      DataTable dt_load=this.cntrl.Load_items();
                      fill_Grid(dt_load);
                    }
                }
                if (Form_Name == "Sales Order")
                {
                    if (Item_Code != "")
                    {
                        DataTable dtb = this.cntrl.Load_items_wit_itemcode(itemid);
                        fill_Grid(dtb);
                    }
                    else
                    {
                     DataTable dt_load=this.cntrl.Load_items();
                        fill_Grid(dt_load);
                    }
                }
                dgv_item.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_item.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_item.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dgv_item.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgv_item.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fill_Grid(DataTable dtb)
        {
            dgv_item.RowCount = 0;
            if (dtb.Rows.Count > 0)
            {
                Lab_Msg.Visible = false;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_item.Rows.Add();
                    dgv_item.Rows[i].Cells["id"].Value = dtb.Rows[i]["id"].ToString();
                    dgv_item.Rows[i].Cells["ColItemCode"].Value = dtb.Rows[i]["item_code"].ToString();
                    dgv_item.Rows[i].Cells["colItemName"].Value = dtb.Rows[i]["item_name"].ToString();
                    dgv_item.Rows[i].Cells["colCategory"].Value = dtb.Rows[i]["Name"].ToString();
                    dgv_item.Rows[i].Cells["colStock"].Value = Convert.ToDecimal(dtb.Rows[i]["Current_Stock"].ToString()).ToString("##");
                    dgv_item.Rows[i].Cells["ColPrize"].Value = Convert.ToDecimal(dtb.Rows[i]["Cost (Unit1)"].ToString()).ToString("#0.00");
                    dgv_item.Rows[i].Cells["colCost2"].Value = Convert.ToDecimal(dtb.Rows[i]["Cost (Unit2)"].ToString()).ToString("#0.00");
                }
            }
            else
            {
                Lab_Msg.Visible = true;
                Lab_Msg.Location = new Point(194, 282);
                dgv_item.RowCount = 0;
            }
        }

        private void txt_ItemCode_Click(object sender, EventArgs e)
        {
            txt_ItemCode.Text = "";
        }

        private void txt_ItemCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_ItemCode.Text != "")
                {
                  DataTable dtb= this.cntrl.search_wit_itemcode(txt_ItemCode.Text);
                    fill_Grid(dtb);
                }
                else
                {
                    Lab_Msg.Visible = false;
                   DataTable dt_load=this.cntrl.Load_items();
                    fill_Grid(dt_load);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_item.Rows.Count > 0)
                {
                    if (Form_Name == "Sales")
                    {
                        ItemID= dgv_item.CurrentRow.Cells["id"].Value.ToString();
                        item_code = dgv_item.CurrentRow.Cells["ColItemCode"].Value.ToString();
                        item_Name = dgv_item.CurrentRow.Cells["colItemName"].Value.ToString();
                        Stock = dgv_item.CurrentRow.Cells["colStock"].Value.ToString();
                    }
                    if (Form_Name == "Sales Order")
                    {
                        ItemID= dgv_item.CurrentRow.Cells["id"].Value.ToString();
                        item_code = dgv_item.CurrentRow.Cells["ColItemCode"].Value.ToString();
                        item_Name = dgv_item.CurrentRow.Cells["colItemName"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (item_code != "")
                {
                    if (Form_Name == "Sales")
                    {
                        var form2 = new Sales(item_code, item_Name, Stock, ItemID);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }
                    else if (Form_Name == "Sales Order")
                    {
                        var form2 = new SalesOrder(item_code, item_Name, Form_Name, ItemID);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }

                }
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Batches_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_item.Rows.Count > 0)
                {
                    int rowindex = dgv_item.CurrentRow.Index;
                    if (rowindex >= 0)
                    {
                        string itemcode = dgv_item.CurrentRow.Cells["id"].Value.ToString();
                        string isbatch = this.cntrl.check_batch(itemcode);
                        if (isbatch == "True")
                        {
                            var form2 = new ItemBatchDetails(itemcode);
                            form2.Show();
                        }
                        else
                        {
                            MessageBox.Show("This item does not have batch...", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_item_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (item_code != "")
                {
                    if (Form_Name == "Sales")
                    {
                        var form2 = new Sales(item_code, item_Name, Stock, ItemID);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }
                    else if (Form_Name == "Sales Order")
                    {
                        var form2 = new SalesOrder(item_code, item_Name, Form_Name, ItemID);
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                    }

                }
                else
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
