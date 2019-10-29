using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class SalesOrder : Form
    {
        sales_order_controller cntrl = new sales_order_controller();
        public bool sales_Edit = false;
        public static int invnum_Edit;
        public static string itemid;
        public static string ItemCode_From_List = "";
        public static string ItemName_From_List = "";
        string FormName = "";
        public static int rowindex;
        bool flagSup = false;
        public SalesOrder()
        {
            InitializeComponent();
        }
        public SalesOrder(int invnum)
        {
            InitializeComponent();
            invnum_Edit = invnum;
            sales_Edit = true;
        }
        public SalesOrder(string item_code, string item_Name, string form_Name, string itemID)
        {
            InitializeComponent();
            ItemCode_From_List = item_code;
            ItemName_From_List = item_Name;
            FormName = form_Name;
            itemid = itemID;
        }
        private void frmSalesOrder_Load(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            if (sales_Edit == true)
            {
                if (invnum_Edit > 0)
                {
                    btnPrint.Visible = true;
                    DataTable dtb = this.cntrl.order_master(invnum_Edit);
                    Load_master(dtb);
                    DataTable dtb1 = this.cntrl.order_details(invnum_Edit);
                    load_items(dtb1);
                }
            }
            else
            {
                DataTable Document_Number = this.cntrl.doc_number();
                if (String.IsNullOrWhiteSpace(Document_Number.Rows[0][0].ToString()))
                {
                    txtDocumentNumber.Text = "1";
                }
                else
                {
                    int Count = Convert.ToInt32(Document_Number.Rows[0][0]);
                    int incrValue = Convert.ToInt32(Count);
                    incrValue += 1;
                    txtDocumentNumber.Text = incrValue.ToString();
                }
            }
            txt_Street.Enabled = false;
            txt_Locality.Enabled = false;
            txt_City.Enabled = false;
            txt_PhoneNo.Enabled = false;
            dgv_SalesItem.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgv_SalesItem.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgv_SalesItem.EnableHeadersVisualStyles = false;
            dgv_SalesItem.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
            dgv_SalesItem.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_SalesItem.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_SalesItem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_SalesItem.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_SalesItem.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_SalesItem.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn cl in dgv_SalesItem.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void Load_master(DataTable dtb_SalesOrder_Master)
        {
            if (dtb_SalesOrder_Master.Rows.Count > 0)
            {
                txtDocumentNumber.Text = dtb_SalesOrder_Master.Rows[0]["DocNumber"].ToString();
                dtpDocumentDate.Text = dtb_SalesOrder_Master.Rows[0]["DocDate"].ToString();
                lbPatient.Visible = false;
                txt_OrderNo.Text = dtb_SalesOrder_Master.Rows[0]["OrderNo"].ToString();
                DTP_OrderDate.Text = dtb_SalesOrder_Master.Rows[0]["OrderDate"].ToString();
                txtPatient.Text = dtb_SalesOrder_Master.Rows[0]["CustomerName"].ToString();
                txtPatientID.Text = dtb_SalesOrder_Master.Rows[0]["Cus_Id"].ToString();
                txt_Street.Text = dtb_SalesOrder_Master.Rows[0]["Address1"].ToString();
                txt_Locality.Text = dtb_SalesOrder_Master.Rows[0]["adr2"].ToString();
                txt_City.Text = dtb_SalesOrder_Master.Rows[0]["adr3"].ToString();
                txt_PhoneNo.Text = dtb_SalesOrder_Master.Rows[0]["Phone"].ToString();
            }
        }
        public void load_items(DataTable dtb_SalesOrder)
        {
            int qty = 0;
            decimal totalamount = 0;
            if (dtb_SalesOrder.Rows.Count > 0)
            {
                for (int i = 0; i < dtb_SalesOrder.Rows.Count; i++)
                {
                    dgv_SalesItem.Rows.Add();
                    dgv_SalesItem.Rows[i].Cells["colItemCode"].Value = dtb_SalesOrder.Rows[i]["ItemCode"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colDiscription"].Value = dtb_SalesOrder.Rows[i]["Discription"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColQty"].Value = dtb_SalesOrder.Rows[i]["Qty"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value = dtb_SalesOrder.Rows[i]["Cost"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colAmount"].Value = dtb_SalesOrder.Rows[i]["TotalAmount"].ToString();
                    totalamount = totalamount + Convert.ToDecimal(dtb_SalesOrder.Rows[i]["TotalAmount"].ToString());
                    dgv_SalesItem.Rows[i].Cells["colEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgv_SalesItem.Rows[i].Cells["colDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                }
                qty = dtb_SalesOrder.Rows.Count;
                txt_totalItems.Text = qty.ToString();
                Txt_TotalAmount.Text = totalamount.ToString();
                btnSave.Text = "UPDATE";
            }
        }
        private void txt_Qty_Click(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "0")
            {
                txt_Qty.Text = "";
            }
        }

        private void txt_UnitCost_Click(object sender, EventArgs e)
        {
            if (txt_UnitCost.Text == "0.00")
            {
                txt_UnitCost.Text = "";
            }
        }

        private void txt_Amount_Click(object sender, EventArgs e)
        {
            if (txt_Amount.Text == "0.00")
            {
                txt_Amount.Text = "";
            }
        }

        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            string a = txt_Qty.Text;
            string b = a.TrimStart('0');
            txt_Qty.Text = b;
        }

        private void txt_Qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_ItemCode.Text) && !string.IsNullOrWhiteSpace(txt_Qty.Text))
            {
                DataTable dtb = this.cntrl.Get_stock(itemid);
                checkstock(dtb);
            }
            if (txt_UnitCost.Text != "")
            {
                TotalAmount_Calculations();
            }
            else
            {
                txt_UnitCost.Text = "0.00";
            }
        }
        public void checkstock(DataTable dtb_qty)
        {
            if (dtb_qty.Rows.Count > 0 && dtb_qty.Rows[0][0].ToString() != "")
            {
                if (Convert.ToDecimal(dtb_qty.Rows[0][0].ToString()) < Convert.ToDecimal(txt_Qty.Text))
                {
                    MessageBox.Show("low Quantity...only have limited stock" + dtb_qty.Rows[0][0].ToString(), "Limited Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_Qty.Clear();
                }
            }
        }
        public void TotalAmount_Calculations()
        {
            Decimal qty = 0, unitcost = 0, TotalAmount = 0;
            decimal d;
            if (decimal.TryParse(txt_UnitCost.Text, out d))
            {
                unitcost = Convert.ToDecimal(txt_UnitCost.Text);
            }
            if (decimal.TryParse(txt_Qty.Text, out d))
            {
                qty = Convert.ToDecimal(txt_Qty.Text);
            }
            TotalAmount = (qty * unitcost);
            txt_Amount.Text = Convert.ToDecimal(TotalAmount.ToString()).ToString("##.00");
        }
        public void Clear_ItemControlls()
        {
            txt_ItemCode.Text = "";
            txt_Discription.Text = "";
            txt_Qty.Text = "0";
            txt_UnitCost.Text = "0.00";
            txt_Amount.Text = "0.00";
        }

        private void btn_item_Choose_Click(object sender, EventArgs e)
        {
            FormName = "Sales Order";
            if (txt_ItemCode.Text != "")
            {
                var form2 = new ItemListForSales(FormName, txt_ItemCode.Text);
                //ItemListForSales_controller controller = new ItemListForSales_controller(form2);
                form2.ShowDialog();
                if (itemid != "")
                {
                    txt_ItemCode.Text = ItemCode_From_List;
                    if (itemcheck() == 0)
                    {
                        txt_Discription.Text = ItemName_From_List;
                        DataTable dtb = this.cntrl.get_salesrate(itemid);
                        load_unitcost(dtb);
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                var form2 = new ItemListForSales(FormName);
                //ItemListForSales_controller controller = new ItemListForSales_controller(form2);
                form2.ShowDialog();
                if (itemid != "")
                {
                    txt_ItemCode.Text = ItemCode_From_List;
                    if (itemcheck() == 0)
                    {
                        txt_Discription.Text = ItemName_From_List;
                        DataTable dtb = this.cntrl.get_salesrate(itemid);
                        load_unitcost(dtb);
                    }
                }
            }
        }
        public void load_unitcost(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                txt_UnitCost.Text = Convert.ToDecimal(dtb.Rows[0][0].ToString()).ToString();
            }
        }
        public int itemcheck()
        {
            int affected = 0;
            for (int i = 0; i < dgv_SalesItem.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_SalesItem.Columns.Count; j++)
                {
                    if (dgv_SalesItem.Rows[i].Cells[j].Value != null && txt_ItemCode.Text == dgv_SalesItem.Rows[i].Cells[j].Value.ToString())
                    {
                        MessageBox.Show("This item already existed..", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        affected = 1;
                    }
                }
            }
            return affected;
        }

        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "")
            {
                txt_Qty.Text = "0";
            }
        }

        private void txt_UnitCost_Leave(object sender, EventArgs e)
        {
            if (txt_UnitCost.Text == "")
            {
                txt_UnitCost.Text = "0.00";
            }
        }

        private void txt_Amount_Leave(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "")
            {
                txt_Qty.Text = "0";
            }
        }

        private void btn_AddtoGrid_Click(object sender, EventArgs e)
        {
            int Totalqty = 0;
            Decimal TotalAmount = 0;
            Decimal TotalCost = 0;
            if (!string.IsNullOrWhiteSpace(itemid) && !string.IsNullOrWhiteSpace(txt_ItemCode.Text) && !string.IsNullOrWhiteSpace(txt_Discription.Text) && Convert.ToDecimal(txt_Qty.Text) > 0)
            {
                if (txt_UnitCost.Text == "")
                {
                    txt_UnitCost.Text = "0.00";
                }
                if (btn_AddtoGrid.Text == "Add")
                {
                    dgv_SalesItem.Rows.Add(itemid,txt_ItemCode.Text, txt_Discription.Text, txt_Qty.Text, txt_UnitCost.Text, txt_Amount.Text, PappyjoeMVC.Properties.Resources.editicon, PappyjoeMVC.Properties.Resources.deleteicon);
                }
                else
                {
                    if (rowindex > 0)
                    {
                        dgv_SalesItem.Rows[rowindex].Cells["id"].Value = itemid;
                        dgv_SalesItem.Rows[rowindex].Cells["colItemCode"].Value = txt_ItemCode.Text;
                        dgv_SalesItem.Rows[rowindex].Cells["colDiscription"].Value = txt_Discription.Text;
                        dgv_SalesItem.Rows[rowindex].Cells["ColQty"].Value = txt_Qty.Text;
                        dgv_SalesItem.Rows[rowindex].Cells["colUnitcost"].Value = txt_UnitCost.Text;
                        dgv_SalesItem.Rows[rowindex].Cells["colAmount"].Value = txt_Amount.Text;
                        btn_AddtoGrid.Text = "Add";
                        btn_cancel.Visible = false;
                    }
                }
                foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                {
                    if (dr.Cells["colUnitcost"].Value != null && dr.Cells["colUnitcost"].Value.ToString() != "")
                    {
                        TotalCost = TotalCost + (Convert.ToInt32(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString()));
                    }
                    if (dr.Cells["colAmount"].Value != null && dr.Cells["colAmount"].Value.ToString() != "")
                    {
                        TotalAmount = TotalAmount + Convert.ToDecimal(dr.Cells["colAmount"].Value.ToString());
                    }
                }
                Totalqty = dgv_SalesItem.Rows.Count;
                if (Totalqty > 0)
                {
                    txt_totalItems.Text = Totalqty.ToString("##0.00");
                }
                if (TotalAmount > 0)
                {
                    Txt_TotalAmount.Text = TotalAmount.ToString("##0.00");
                }
                Clear_ItemControlls();
            }
            else
            {
                MessageBox.Show("Mandatory fileds should not be empty", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ItemCode.Focus();
            }
        }

        private void txt_UnitCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_UnitCost.Text != "")
            {
                TotalAmount_Calculations();
            }
        }

        private void dgv_SalesItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Decimal Qty = 0;
            Decimal TotalItems = 0;
            Decimal TotalAmount = 0;
            string itmCode = "";
            if (e.RowIndex >= 0)
            {
                rowindex = dgv_SalesItem.CurrentRow.Index;
                if (dgv_SalesItem.CurrentCell.OwningColumn.Name == "colEdit")
                {
                    txt_ItemCode.Text = dgv_SalesItem.Rows[rowindex].Cells["colItemCode"].Value.ToString();
                    txt_Discription.Text = dgv_SalesItem.Rows[rowindex].Cells["colDiscription"].Value.ToString();
                    txt_Qty.Text = dgv_SalesItem.Rows[rowindex].Cells["ColQty"].Value.ToString();
                    txt_UnitCost.Text = dgv_SalesItem.Rows[rowindex].Cells["colUnitcost"].Value.ToString();
                    txt_Amount.Text = dgv_SalesItem.Rows[rowindex].Cells["colAmount"].Value.ToString();
                    btn_AddtoGrid.Text = "Update"; btn_cancel.Visible = true;
                }
                else if (dgv_SalesItem.CurrentCell.OwningColumn.Name == "colDelete")
                {
                    int index = dgv_SalesItem.CurrentRow.Index;
                    itmCode = dgv_SalesItem.CurrentRow.Cells["colItemCode"].Value.ToString();
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        Qty = Convert.ToDecimal(dgv_SalesItem.Rows[index].Cells["ColQty"].Value.ToString());
                        if (txt_totalItems.Text != "")
                        {
                            TotalItems = Convert.ToDecimal(txt_totalItems.Text) - Convert.ToDecimal(1);
                            txt_totalItems.Text = Convert.ToDecimal(TotalItems).ToString("##0.00");
                        }
                        if (Txt_TotalAmount.Text != "")
                        {
                            TotalAmount = Convert.ToDecimal(Txt_TotalAmount.Text) - Convert.ToDecimal(dgv_SalesItem.Rows[index].Cells["colAmount"].Value.ToString());
                            Txt_TotalAmount.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
                        }
                        dgv_SalesItem.Rows.RemoveAt(index);
                    }
                }
            }
        }
        public void clear_All_Data()
        {
            dtpDocumentDate.Text = DateTime.Now.ToString();
            lbPatient.Visible = false;
            txt_OrderNo.Text = "";
            DTP_OrderDate.Text = DateTime.Now.ToString();
            txtPatient.Text = "";
            txtPatientID.Text = "";
            txt_Street.Text = "";
            txt_Locality.Text = "";
            txt_City.Text = "";
            txt_PhoneNo.Text = "";
            txt_totalItems.Text = "0";
            Txt_TotalAmount.Text = "0.00";
            dgv_SalesItem.Rows.Clear();
        }

        private void txtPatient_TextChanged(object sender, EventArgs e)
        {
            if (flagSup == false)
            {
                if (txtPatient.Text != "")
                {
                    lbPatient.Show();
                    lbPatient.Location = new Point(429, 37);
                    DataTable dtdr = this.cntrl.patient_keydown(txtPatient.Text);
                    lbPatient.DataSource = dtdr;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "pt_id";
                }
            }
            else
                flagSup = false;
        }

        private void txtPatient_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtPatient.Text == "")
            {
                txtPatient.Text = "";
                txtPatientID.Text = "";
                txt_Locality.Text = "";
                txt_Street.Text = "";
                txt_PhoneNo.Text = "";
                txt_City.Text = "";
            }
            if (flagSup == false)
            {
                DataTable dt = new DataTable();
                dt = this.cntrl.patients(txtPatient.Text);
                if (dt.Rows.Count > 0)
                {
                    lbPatient.DataSource = dt;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "pt_id";
                    lbPatient.Show();
                    if (txtPatient.Text == "")
                    {
                        lbPatient.Focus();
                        lbPatient.SelectedIndex = 0;
                    }
                    if (e.KeyCode == Keys.Down)
                    {
                        if (lbPatient.Items.Count == 1)
                        {
                            lbPatient.SelectedIndex = 0;
                            lbPatient.Focus();
                        }
                        else if (lbPatient.Items.Count > 1)
                        {
                            lbPatient.SelectedIndex = 0;
                            lbPatient.Focus();
                        }
                    }
                }
                else
                {
                }
            }
            flagSup = false;
        }

        private void lbPatient_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbPatient.SelectedItems.Count > 0)
            {
                string value = lbPatient.SelectedValue.ToString();
                DataTable patient = new DataTable();
                patient = this.cntrl.get_ptid(value);
                if (patient.Rows.Count > 0)
                {
                    txtPatient.Text = patient.Rows[0]["pt_name"].ToString();
                    txtPatientID.Text = patient.Rows[0]["pt_id"].ToString();
                    lbPatient.Visible = false;
                }
                else
                {
                    MessageBox.Show("Please choose Correct patient....", "Data Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txt_UnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_ItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string item = txt_ItemCode.Text;
                if (item != "")
                {
                    FormName = "Sales Order";
                    var form2 = new ItemListForSales(FormName, txt_ItemCode.Text);
                    form2.ShowDialog();
                    if (ItemCode_From_List != "")
                    {
                        txt_ItemCode.Text = ItemCode_From_List;
                        txt_Discription.Text = ItemName_From_List;
                    }
                }
            }
        }

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if (txtPatient.Text != "")
            {
                string id = txtPatientID.Text;
                DataTable dtb = this.cntrl.patients(id);
                if (dtb.Rows.Count > 0)
                {
                    txt_Street.Text = dtb.Rows[0]["street_address"].ToString();
                    txt_Locality.Text = dtb.Rows[0]["locality"].ToString();
                    txt_City.Text = dtb.Rows[0]["city"].ToString();
                    txt_PhoneNo.Text = dtb.Rows[0]["primary_mobile_number"].ToString();
                    lbPatient.Hide();
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Clear_ItemControlls();
            btn_AddtoGrid.Text = "Add";
            btn_cancel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear_All_Data();
            Clear_ItemControlls();
        }

        private void lbPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flagSup = true;
                string value = lbPatient.SelectedValue.ToString();
                DataTable supplier = new DataTable();
                supplier = this.cntrl.get_ptid(value);
                txtPatient.Text = supplier.Rows[0]["pt_name"].ToString();
                txtPatientID.Text = supplier.Rows[0]["pt_id"].ToString();
                lbPatient.Hide();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lbPatient.Focus();
                int indicee = lbPatient.SelectedIndex;
                indicee++;
            }
            else if (e.KeyCode == Keys.Down)
            {
                lbPatient.Focus();
                int indicee = lbPatient.SelectedIndex;
                indicee++;
            }
        }

        private void txt_ItemCode_Leave(object sender, EventArgs e)
        {
            if (txt_ItemCode.Text != "")
            {
                DataTable dt = this.cntrl.get_item(txt_ItemCode.Text);
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
                {
                    txt_ItemCode.Text = dt.Rows[0][0].ToString();
                    txt_Discription.Text = dt.Rows[0][1].ToString();
                    txt_UnitCost.Text = Convert.ToDecimal(dt.Rows[0][2].ToString()).ToString();
                }
                else
                {
                    MessageBox.Show("This Item Code does not exist in the table !!", "Not Existed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ItemCode.Text = "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatient.Text))
            {
                MessageBox.Show("Customer could not be found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPatient.Focus();
                return;
            }
            if (dgv_SalesItem.Rows.Count == 0)
            {
                MessageBox.Show("Products not found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ItemCode.Focus();
                return;
            }
            int i = 0, j = 0;
            if (btnSave.Text == "SAVE")
            {
                i = this.cntrl.save_master(txtDocumentNumber.Text, dtpDocumentDate.Value.ToString("yyyy-MM-dd"), txt_OrderNo.Text, DTP_OrderDate.Value.ToString(), txtPatient.Text, txtPatientID.Text, txt_Street.Text, txt_Locality.Text, txt_City.Text, txt_PhoneNo.Text);
                if (i > 0)
                {
                    foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                    {
                        j = this.cntrl.save_items(txtDocumentNumber.Text, dtpDocumentDate.Value.ToString("yyyy-MM-dd"), dr.Cells["id"].Value.ToString(), dr.Cells["colDiscription"].Value.ToString(), dr.Cells["ColQty"].Value.ToString(), dr.Cells["colUnitcost"].Value.ToString(), dr.Cells["colAmount"].Value.ToString());
                    }
                }
            }
            else
            {
                this.cntrl.delete_order(invnum_Edit);
                i = this.cntrl.save_master(txtDocumentNumber.Text, dtpDocumentDate.Value.ToString("yyyy-MM-dd"), txt_OrderNo.Text, DTP_OrderDate.Value.ToString(), txtPatient.Text, txtPatientID.Text, txt_Street.Text, txt_Locality.Text, txt_City.Text, txt_PhoneNo.Text);
                if (i > 0)
                {
                    foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                    {
                        j = j = this.cntrl.save_items(txtDocumentNumber.Text, dtpDocumentDate.Value.ToString("yyyy-MM-dd"), dr.Cells["id"].Value.ToString(), dr.Cells["colDiscription"].Value.ToString(), dr.Cells["ColQty"].Value.ToString(), dr.Cells["colUnitcost"].Value.ToString(), dr.Cells["colAmount"].Value.ToString());
                    }
                }
                btnSave.Text = "SAVE";
            }
            if (i > 0 && j > 0)
            {
                DialogResult res = MessageBox.Show("Data inserted Successfully,Do you want to print ?", "",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    printhtml();
                }
                else
                {
                }
                clear_All_Data();
            }
        }

        public void printhtml()
        {
            string strclinicname = "", strphone = "", DlNumber = "", DlNumber2 = "", website = "";
            decimal totalamount = 0;
            System.Data.DataTable dtp = this.cntrl.companydetails();
            if (dtp.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = dtp.Rows[0]["name"].ToString();
                strclinicname = clinicn.Replace("¤", "'");
                strphone = dtp.Rows[0]["contact_no"].ToString();
                DlNumber = dtp.Rows[0]["street_address"].ToString();
                DlNumber2 = dtp.Rows[0]["email"].ToString();
                website = dtp.Rows[0]["website"].ToString();
            }
            string Apppath = System.IO.Directory.GetCurrentDirectory();
            StreamWriter sWrite = new StreamWriter(Apppath + "\\salesOrder.html");
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("<style>");
            sWrite.WriteLine("table { border-collapse: collapse;}");
            sWrite.WriteLine("p.big {line-height: 400%;}");
            sWrite.WriteLine("</style>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<body >");
            sWrite.WriteLine("<div>");
            sWrite.WriteLine("<table align=center width=900>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<th colspan=8><center><br><br><FONT COLOR=black FACE='Segoe UI'  SIZE=4> SALES ORDER BILL </font></center></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td  colspan=5 align='left'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>  <b> " + strclinicname + "</b> </font></left></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + strphone + " </b> </font></left></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DlNumber + "</b> </font></left></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + DlNumber2 + "</b> </font></left></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><FONT COLOR=black FACE='Segoe UI'   SIZE=2>" + website + " </b> </font></left></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Sold To : " + txtPatient.Text + "</font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td  colspan=4  align='left' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Date  :" + DateTime.Now.ToString("dd-MM-yyyy") + " </font></td>");
            sWrite.WriteLine("<td colspan=4  align='right' ><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>Invoice No:" + txtDocumentNumber.Text + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr><td align='left' colspan=5><hr/></td></tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left'  width='150'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3>Item Code</font></td>");
            sWrite.WriteLine("<td align='left'  width='200'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3>Description</font></td>");
            sWrite.WriteLine("<td align='right'  width='65'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3>Quantity</font></td>");
            sWrite.WriteLine("<td align='right'  width='82'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3>Cost</font></td>");
            sWrite.WriteLine("<td align='right'  width='82'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3>Total Amount</font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr><td align='left' colspan=5><hr/></td></tr>");
            for (int i = 0; i < dgv_SalesItem.Rows.Count; i++)
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["colItemCode"].Value.ToString() + "</font></td>");
                sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["colDiscription"].Value.ToString() + "</font></td>");
                sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["ColQty"].Value.ToString() + "</font></td>");
                sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>" + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value.ToString()).ToString("##0.00") + "</font></td>");
                sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>" + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colAmount"].Value.ToString()).ToString("##0.00") + "</font></td>");
                totalamount = totalamount + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colAmount"].Value.ToString());
                sWrite.WriteLine("</tr>");
            }
            sWrite.WriteLine("<tr><td align='left'  colspan=5><hr/></td></tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2> Total Items :</font></td>");
            sWrite.WriteLine("<td align='right'  colspan=5 ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3> &nbsp " + txt_totalItems.Text + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>Total Amount :  </font></td>");
            sWrite.WriteLine("<td align='right'  colspan=5 ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>&nbsp" + String.Format("{0:C}",decimal.Parse(Txt_TotalAmount.Text)) + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<script>window.print();</script>");
            sWrite.WriteLine("</body >");
            sWrite.WriteLine("</html>");
            sWrite.Close();
            System.Diagnostics.Process.Start(Apppath + "\\salesOrder.html");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printhtml();
        }
    }
}
