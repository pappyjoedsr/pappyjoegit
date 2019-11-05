using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Purchase : Form
    {
        purchase_controller cntrl = new purchase_controller();
        DataTable editgrid = new DataTable();
        GeneralFunctions GF = new GeneralFunctions();
        public DataTable data_from_Pur_Master1 = new DataTable();
        public DataTable data_from_purchase1 = new DataTable();
        decimal amtUntchange = 0;
        decimal ttlamt = 0;
        public static string itemCode;
        public static string Item_id;
        public static bool Item_flag = false;
        bool flagSup = false;
        public bool flagedit = false;
        bool purchOrder_flag = false;
        bool flag_save = false;
        bool flagcheck = false;
        public string form_name;
        public static int freeQty;
        bool Pur_List_flag = false;
        public static int qty;
        string unit2Is;
        public int Rowindex = 0;
        int Pur_order_no1 = 0;
        public static DataTable dt_forBatch;
        public string edit;
        public Purchase()
        {
            InitializeComponent();
        }
        public Purchase(int purch_id)
        {
            InitializeComponent();
            Pur_order_no1 = purch_id;
            purchOrder_flag = true;
        }
        public Purchase(string item_code)
        {
            InitializeComponent();
            itemCode = item_code;
            Item_flag = true;
        }
        public Purchase(DataTable gridData)
        {
            InitializeComponent();
            dt_forBatch = gridData;
        }
        public Purchase(string item_code, string item_id) : this(item_code)
        {
            Item_id = item_id;
            itemCode = item_code;
        }
        public Purchase(DataTable data_from_Pur_Master, DataTable data_from_purchase)
        {
            InitializeComponent();
            data_from_Pur_Master1 = data_from_Pur_Master;
            data_from_purchase1 = data_from_purchase;
            Pur_List_flag = true;
        }
        private void Btn_itemCode_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new PurchaseItemLIst("Purchase", txt_Itemcode.Text);
                form.ShowDialog();
                txt_Itemcode.Text = itemCode;
                if (checkRep() == 1)
                {
                    MessageBox.Show("Item already existed", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataTable dtb = this.cntrl.Get_itemdetails(Item_id);
                    Load_item_in_textbox(dtb);
                }
                itemCode = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int checkRep()
        {
            int affecte = 0;
            for (int i = 0; i < dgvItemData.Rows.Count; i++)
            {
                if (dgvItemData.Rows[i].Cells["itemid"].Value.ToString() == txt_Itemcode.Text)
                {
                    affecte = 1;
                }
            }
            return affecte;
        }

        private void txt_Itemcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string item = txt_Itemcode.Text;
                    if (item != "")
                    {
                        string formname = "Purchase";
                        var form = new PurchaseItemLIst(formname, item);
                        form.ShowDialog();
                        txt_Itemcode.Text = itemCode;
                        if (checkRep() == 1)
                        {
                            MessageBox.Show("This item already exists", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            DataTable dtb = this.cntrl.Get_itemdetails(Item_id);
                            Load_item_in_textbox(dtb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Load_item_in_textbox(DataTable dtitems)
        {
            if (dtitems.Rows.Count > 0)
            {
                unitload(dtitems);
                txtDescription.Text = dtitems.Rows[0]["item_name"].ToString();
                txtPacking.Text = dtitems.Rows[0]["Packing"].ToString();
                txtUnitCost.Text = dtitems.Rows[0]["Purch_Rate"].ToString();
                txtAmount.Text = "0.00";
            }
        }

        private void cmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cmbUnit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (flagedit == false)
                {
                    if (cmbUnit.Text != "")
                    {
                        decimal gstamt = 0;
                        DataTable dtitems = this.cntrl.Get_item_units(Item_id);
                        decimal gst = Convert.ToDecimal(txtGst.Text);
                        decimal igst = Convert.ToDecimal(txtIgst.Text);
                        string unit2 = dtitems.Rows[0]["Unit2"].ToString();
                        string unit1 = dtitems.Rows[0]["Unit1"].ToString();
                        string unit;
                        int UnitMf = Convert.ToInt32(dtitems.Rows[0]["UnitMF"].ToString());
                        if (txt_qty.Text != "" && txtUnitCost.Text != "")
                        {
                            unit = cmbUnit.Text;
                            if (unit == unit2)
                            {
                                int qty = int.Parse(txt_qty.Text);
                                decimal unitcost = Convert.ToDecimal(txtUnitCost.Text) / UnitMf;
                                if (txtGst.Text != "0.0")
                                {
                                    gstamt = (((unitcost * qty) * gst) / 100) + (unitcost * qty);
                                    txtAmount.Text = gstamt.ToString("##.00");
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                }
                                else if (txtIgst.Text != "0.0")
                                {
                                    gstamt = (((unitcost * qty) * igst) / 100) + (unitcost * qty);
                                    txtAmount.Text = gstamt.ToString("##.00");
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                }
                                else if (txtGst.Text == "0.0" && txtIgst.Text == "0.0")
                                {
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                    amtUntchange = unitcost * qty;
                                    txtAmount.Text = amtUntchange.ToString("##.00");
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                }
                                amtUntchange = (unitcost * qty);
                            }
                            if (unit == unit1)
                            {
                                unit = cmbUnit.Text;
                                int qty = int.Parse(txt_qty.Text);
                                decimal unitcost = Convert.ToDecimal(txtUnitCost.Text) * UnitMf;
                                if (txtGst.Text != "0.0")
                                {
                                    gstamt = (((unitcost * qty) * gst) / 100) + (unitcost * qty);
                                    txtAmount.Text = gstamt.ToString("##.00");
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                }
                                else if (txtIgst.Text != "0.0")
                                {
                                    gstamt = (((unitcost * qty) * igst) / 100) + (unitcost * qty);
                                    txtAmount.Text = gstamt.ToString("##.00");
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                }
                                else if (txtGst.Text == "0.0" && txtIgst.Text == "0.0")
                                {
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                    amtUntchange = unitcost * qty;
                                    txtAmount.Text = amtUntchange.ToString("##.00");
                                    txtUnitCost.Text = unitcost.ToString("##.00");
                                }
                                amtUntchange = (unitcost * qty);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtGst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (txtGst.Text != "0.0")
            {
                string a = txtGst.Text;
                string b = a.TrimStart('0');
                txtGst.Text = b;
            }
        }

        private void txtGst_Click(object sender, EventArgs e)
        {
            if (txtGst.Text == "0.0")
            {
                txtGst.Text = "";
            }
        }

        private void txtGst_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtGst.Text == "" || txtGst.Text == ".")
            {
                txtGst.Text = "0.0";
            }
        }

        private void txtGst_Leave(object sender, EventArgs e)
        {
            if (txtGst.Text == "")
            {
                txtGst.Text = "0.0";
            }
            else if (Convert.ToDecimal(txtGst.Text) > 0)
            {
                txtIgst.Text = "0.0";
            }
        }

        private void txtGst_TextChanged(object sender, EventArgs e)
        {
            calculaton();
        }
        public void calculaton()
        {
            try
            {
                if (txtGst.Text.Trim() != "" && txtIgst.Text.Trim() != "" && txtGst.Text != "." && txtIgst.Text != ".")
                {
                    if (txt_qty.Text != "" && txtUnitCost.Text != "")
                    {
                        decimal gstamt = 0;
                        decimal igstamt = 0;
                        decimal unitcost = 0;
                        decimal igst = 0;
                        int qty = 0;
                        decimal gst = 0;
                        unitcost = Convert.ToDecimal(txtUnitCost.Text);
                        qty = Convert.ToInt32(txt_qty.Text);
                        gst = Convert.ToDecimal(txtGst.Text);
                        igst = Convert.ToDecimal(txtIgst.Text);
                        if (txtGst.Text != "0.0")
                        {
                            gstamt = (((unitcost * qty) * gst) / 100) + (unitcost * qty);
                            txtAmount.Text = gstamt.ToString("##.00");
                        }
                        else if (txtIgst.Text != "0.0")
                        {
                            igstamt = (((unitcost * qty) * igst) / 100) + (unitcost * qty);
                            txtAmount.Text = igstamt.ToString("##.00");
                        }
                        else if (txtGst.Text == "0.0" && txtIgst.Text == "0.0")
                        {
                            txtAmount.Text = (unitcost * qty).ToString("##.00");
                        }
                        ttlamt = (unitcost * qty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtIgst_Click(object sender, EventArgs e)
        {
            if (txtIgst.Text == "0.0")
            {
                txtIgst.Text = "";
            }
        }

        private void txtIgst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if (txtIgst.Text != "0.0")
            {
                string a = txtIgst.Text;
                string b = a.TrimStart('0');
                txtIgst.Text = b;
            }
        }

        private void txtIgst_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtIgst.Text == "" || txtIgst.Text == ".")
            {
                txtIgst.Text = "0.0";
            }
        }

        private void txtIgst_Leave(object sender, EventArgs e)
        {
            if (txtIgst.Text == "")
            {
                txtIgst.Text = "0.0";
            }
            else if (Convert.ToDecimal(txtIgst.Text) > 0)
            {
                txtGst.Text = "0.0";
            }
        }

        private void txtIgst_TextChanged(object sender, EventArgs e)
        {
            calculaton();
        }

        private void txt_qty_Click(object sender, EventArgs e)
        {
            if (txt_qty.Text == "0")
                txt_qty.Text = "";
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            string a = txt_qty.Text;
            string b = a.TrimStart('0');
            txt_qty.Text = b;
        }

        private void txt_qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_qty.Text == "")
            {
                txt_qty.Text = "0";
            }
            calculaton();
        }

        private void txt_qty_Leave(object sender, EventArgs e)
        {
            if (txt_qty.Text == "")
            {
                txt_qty.Text = "0";
            }
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            if (txt_qty.Text != "0" && txt_qty.Text != "")
            {
                calculaton();
            }
        }

        private void txt_free_Click(object sender, EventArgs e)
        {
            if (txt_free.Text == "0")
            {
                txt_free.Text = "";
            }
        }

        private void txt_free_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            string a = txt_free.Text;
            string b = a.TrimStart('0');
            txt_free.Text = b;
        }

        private void txt_free_Leave(object sender, EventArgs e)
        {
            if (txt_free.Text == "")
            {
                txt_free.Text = "0";
            }
        }

        private void txtUnitCost_Click(object sender, EventArgs e)
        {
            if (txtUnitCost.Text == "0.0")
                txtUnitCost.Text = "";
        }

        private void txtUnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            string a = txtUnitCost.Text;
            string b = a.TrimStart('0');
            txtUnitCost.Text = b;
        }

        private void txtUnitCost_KeyUp(object sender, KeyEventArgs e)
        {
            calculaton();
        }

        private void txtSupplierName_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.Load_Suplier();

            Load_Suplier(dtb);
        }

        public void Load_Suplier(DataTable dt)
        {
            lstbox_Supplier.DataSource = dt;
            lstbox_Supplier.DisplayMember = "Supplier_Name";
            lstbox_Supplier.ValueMember = "Supplier_Code";
            lstbox_Supplier.Show();
        }

        private void txtSupplierName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (lstbox_Supplier.Visible != false)
                {
                    lstbox_Supplier.Focus();
                }
            }
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            if (flagSup == false)
            {
                DataTable dtb = this.cntrl.LoadSuplier_wit_supname(txtSupplierName.Text);
                Load_Suplier(dtb);
            }
            flagSup = false;
        }

        private void lstbox_Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    flagSup = true;
                    txtSupplierName.Text = lstbox_Supplier.Text;
                    txt_SupplierId.Text = lstbox_Supplier.SelectedValue.ToString();
                    lstbox_Supplier.Hide();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    lstbox_Supplier.Focus();
                    int indicee = lstbox_Supplier.SelectedIndex;
                    indicee++;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    lstbox_Supplier.Focus();
                    int indicee = lstbox_Supplier.SelectedIndex;
                    indicee++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstbox_Supplier_MouseClick(object sender, MouseEventArgs e)
        {
            string sup_code = lstbox_Supplier.SelectedValue.ToString();
            txtSupplierName.Text = lstbox_Supplier.Text;
            txt_SupplierId.Text = lstbox_Supplier.SelectedValue.ToString();
            lstbox_Supplier.Hide();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Itemcode.Text != "" && txtDescription.Text != "" && txt_qty.Text != "0" && txtUnitCost.Text != "0.0")
                {
                    decimal amount1 = 0;
                    decimal amount = 0;
                    decimal amt = 0;
                    decimal amt1 = 0;
                    decimal igstcal = 0;
                    decimal igstcalc1 = 0;
                    decimal igstcalc = 0;
                    decimal cgstcal = 0;
                    decimal cgstcalc = 0;
                    decimal cgstcalc1 = 0;
                    decimal cgstcalc2 = 0;
                    decimal unitcost = 0;
                    int Qty = 0;
                    int qtycal = 0;
                    decimal unitcostcal = 0;
                    decimal gst = Convert.ToDecimal(txtGst.Text);
                    decimal igst = Convert.ToDecimal(txtIgst.Text);
                    decimal ucost = Convert.ToDecimal(txtUnitCost.Text);
                    int qtty = Convert.ToInt32(txt_qty.Text);
                    decimal gstcalc = 0;
                    decimal igstcalcc = 0;
                    if (ttlamt == 0)
                    {
                        ttlamt = Convert.ToDecimal(txtUnitCost.Text) * Convert.ToInt32(txt_qty.Text);
                    }
                    if (txt_free.Text == "")
                    {
                        freeQty = 0;
                    }
                    else
                    {
                        freeQty = int.Parse(txt_free.Text);
                    }
                    qty = freeQty + int.Parse(txt_qty.Text);
                    DataTable dtb = this.cntrl.check_batch(Item_id);

                    if (Btn_Add.Text == "Update")
                    {
                        if (purchOrder_flag == false)
                        {
                            editgrid.Columns.Clear();
                            editgrid.Rows.Clear();
                            foreach (DataGridViewColumn col in dgvGridData.Columns)
                            {
                                editgrid.Columns.Add(col.Name);
                            }
                            foreach (DataGridViewRow row in dgvGridData.Rows)
                            {
                                DataRow dRow = editgrid.NewRow();
                                if (row.Cells["tempItem_code"].Value.ToString() == Item_id)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        dRow[cell.ColumnIndex] = cell.Value;
                                    }
                                    editgrid.Rows.Add(dRow);
                                }
                            }
                            form_name = "purchase";
                            var form = new Purchase_Batch(cmbUnit.Text, txt_Itemcode.Text, Item_id, editgrid, qty, form_name, txtPurchInvNumber.Text);
                            form.ShowDialog();
                        }
                        if (purchOrder_flag == true)
                        {
                            var form = new Purchase_Batch(cmbUnit.Text, qty, txt_Itemcode.Text, Item_id, txtPurchInvNumber.Text);
                            form.ShowDialog();
                        }
                    }
                    if (Btn_Add.Text == "Add")
                    {
                        var form = new Purchase_Batch(cmbUnit.Text, qty, txt_Itemcode.Text, Item_id, txtPurchInvNumber.Text);
                        form.ShowDialog();
                    }
                    if (txt_qty.Text == "")
                    {
                        txt_qty.Text = "0";
                    }
                    if (Btn_Add.Text == "Update")
                    {
                        amtUntchange = Convert.ToDecimal(txtUnitCost.Text) * Convert.ToDecimal(txt_qty.Text);
                        dgvItemData.Rows[Rowindex].Cells["id"].Value = Item_id;
                        dgvItemData.Rows[Rowindex].Cells["itemid"].Value = txt_Itemcode.Text;
                        dgvItemData.Rows[Rowindex].Cells["description"].Value = txtDescription.Text;
                        dgvItemData.Rows[Rowindex].Cells["Packing"].Value = txtPacking.Text;
                        dgvItemData.Rows[Rowindex].Cells["note"].Value = cmbUnit.Text;
                        dgvItemData.Rows[Rowindex].Cells["GST"].Value = txtGst.Text;
                        dgvItemData.Rows[Rowindex].Cells["IGST"].Value = txtIgst.Text;
                        dgvItemData.Rows[Rowindex].Cells["col_qty"].Value = txt_qty.Text;
                        dgvItemData.Rows[Rowindex].Cells["free"].Value = txt_free.Text;
                        dgvItemData.Rows[Rowindex].Cells["Unit_Cost"].Value = txtUnitCost.Text;
                        dgvItemData.Rows[Rowindex].Cells["Amount"].Value = txtAmount.Text;
                        dgvItemData.Rows[Rowindex].Cells["amt"].Value = amtUntchange.ToString();
                        dgvItemData.Rows[Rowindex].Cells["gstCal"].Value = ((Convert.ToDecimal(txtUnitCost.Text) * Convert.ToDecimal(txt_qty.Text) * Convert.ToDecimal(txtGst.Text)) / 100);
                        dgvItemData.Rows[Rowindex].Cells["igstCal"].Value = ((Convert.ToDecimal(txtUnitCost.Text) * Convert.ToDecimal(txt_qty.Text) * Convert.ToDecimal(txtIgst.Text)) / 100);
                        if (dtb.Rows[0]["ISBatch"].ToString() == "True")
                        {
                            if (dgvItemData.Rows.Count == 1)
                            {
                                dgvGridData.Rows.Clear(); fill_Updategrid(); dt_forBatch.Clear();
                            }
                            else
                            {
                                update_Grid(); fill_Updategrid(); dt_forBatch.Clear();
                            }
                        }
                        else
                        {
                            if (dgvItemData.Rows.Count == 1)
                            {
                                dgvGridData.Rows.Clear(); fill_Updategrid();
                            }
                            else
                            {
                                update_Grid(); fill_Updategrid();
                            }
                        }
                        foreach (DataGridViewRow row1 in dgvItemData.Rows)
                        {
                            if (row1.Cells["Amount"].Value != null && row1.Cells["Amount"].Value.ToString() != "")
                            {
                                amount = Convert.ToDecimal(row1.Cells["Amount"].Value.ToString());
                                amount1 = amount1 + amount;
                                amt = Convert.ToDecimal(row1.Cells["amt"].Value.ToString());
                                amt1 = amt1 + amt;
                                if (row1.Cells["igst"].Value != null)
                                {
                                    igstcal = Convert.ToDecimal(row1.Cells["igst"].Value.ToString());
                                    unitcostcal = Convert.ToDecimal(row1.Cells["Unit_Cost"].Value.ToString());
                                    qtycal = Convert.ToInt32(row1.Cells["col_qty"].Value.ToString());
                                    igstcalc = (((unitcostcal * qtycal) * igstcal) / 100);
                                    igstcalc1 = igstcalc1 + igstcalc;
                                }
                                if (row1.Cells["gst"].Value != null)
                                {
                                    cgstcal = Convert.ToDecimal(row1.Cells["gst"].Value.ToString());
                                    cgstcalc = (((unitcostcal * qtycal) * cgstcal) / 100);
                                    cgstcalc1 = cgstcalc1 + cgstcalc;
                                    cgstcalc2 = cgstcalc1 / 2;
                                }
                            }
                        }
                        txtTotal_item.Text = dgvItemData.Rows.Count.ToString();
                        txtIgstResult.Text = igstcalc1.ToString();
                        txt_TotalAmount.Text = amount1.ToString();
                        txtTotalCost.Text = amt1.ToString();
                        txtCgst.Text = cgstcalc2.ToString();
                        txtSgst.Text = cgstcalc2.ToString();
                        clear();
                        Btn_itemCode.Enabled = true;
                        Btn_Add.Text = "Add";
                        BtnCancel.Visible = false;
                        txt_Itemcode.Enabled = true;
                    }
                    else if (Btn_Add.Text == "Add")
                    {
                        int qty = 0;
                        if (txtGst.Text != "0.0")
                        {
                            qtycal = Convert.ToInt32(txt_qty.Text);
                            gstcalc = (((ucost * qtycal) * gst) / 100);
                        }
                        else if (txtIgst.Text != "0.0")
                        {
                            qtycal = Convert.ToInt32(txt_qty.Text);
                            igstcalcc = (((ucost * qtycal) * igst) / 100);
                        }
                        if (dtb.Rows[0]["ISBatch"].ToString() == "true")
                        {
                            if (dt_forBatch != null)
                            {
                                dgvItemData.Rows.Add(Item_id, txt_Itemcode.Text, txtDescription.Text, txtPacking.Text, cmbUnit.Text, txtGst.Text, txtIgst.Text, txt_qty.Text, txt_free.Text, txtUnitCost.Text, txtAmount.Text, ttlamt, gstcalc, igstcalcc);
                                for (int i = 0; i < dt_forBatch.Rows.Count; i++)
                                {
                                    if (dt_forBatch.Rows[i][0].ToString() != "")
                                    {
                                        dgvGridData.Rows.Add(Item_id, dt_forBatch.Rows[i]["Branch_No"].ToString(), dt_forBatch.Rows[i]["col_Unit"].ToString(), dt_forBatch.Rows[i]["Quantity"].ToString(), dt_forBatch.Rows[i]["Prd_Date"].ToString(), dt_forBatch.Rows[i]["Exp_Date"].ToString(), dt_forBatch.Rows[i]["prd"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Does not add batch", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            dgvItemData.Rows.Add(Item_id, txt_Itemcode.Text, txtDescription.Text, txtPacking.Text, cmbUnit.Text, txtGst.Text, txtIgst.Text, txt_qty.Text, txt_free.Text, txtUnitCost.Text, txtAmount.Text, ttlamt, gstcalc, igstcalcc);
                            dgvGridData.Rows.Add(Item_id, dt_forBatch.Rows[0]["Branch_No"].ToString(), cmbUnit.Text, txt_qty.Text, dt_forBatch.Rows[0]["Prd_Date"].ToString(), dt_forBatch.Rows[0]["Exp_Date"].ToString(), dt_forBatch.Rows[0]["prd"].ToString());
                        }
                        clear();
                        qty = dgvItemData.Rows.Count;
                        txtTotal_item.Text = qty.ToString();
                        foreach (DataGridViewRow row1 in dgvItemData.Rows)
                        {
                            if (row1.Cells["Amount"].Value != null && row1.Cells["Amount"].Value.ToString() != "")
                            {
                                amount = Convert.ToDecimal(row1.Cells["Amount"].Value.ToString());
                                amount1 = amount1 + amount;
                                if (Convert.ToDecimal(row1.Cells["amt"].Value) == 0)
                                {
                                    amt = unitcost * Qty;
                                }
                                else
                                {
                                    amt = Convert.ToDecimal(row1.Cells["amt"].Value.ToString());
                                }
                                amt1 = amt1 + amt;
                                if (row1.Cells["gstCal"].Value != null)
                                {
                                    cgstcalc = Convert.ToDecimal(row1.Cells["gstCal"].Value.ToString());
                                    cgstcalc1 = cgstcalc + cgstcalc1;
                                    cgstcalc2 = cgstcalc1 / 2;
                                }
                                else if (row1.Cells["gstCal"].Value == null)
                                {
                                    cgstcalc = gstcalc;
                                    cgstcalc1 = cgstcalc + cgstcalc1;
                                    cgstcalc2 = cgstcalc1 / 2;
                                }
                                if (row1.Cells["igstCal"].Value != null)
                                {
                                    igstcalc = Convert.ToDecimal(row1.Cells["igstCal"].Value.ToString());
                                    igstcalc1 = igstcalc + igstcalc1;
                                }
                                else if (row1.Cells["igstCal"].Value == null)
                                {
                                    igstcalc = igstcalcc;
                                    igstcalc1 = igstcalc + igstcalc1;
                                }
                            }
                        }
                        Btn_itemCode.Enabled = true;
                        txt_TotalAmount.Text = amount1.ToString();
                        txtTotalCost.Text = amt1.ToString();
                        txtIgstResult.Text = igstcalc1.ToString();
                        txt_TotalAmount.Text = amount1.ToString();
                        txtCgst.Text = cgstcalc2.ToString();
                        txtSgst.Text = cgstcalc2.ToString();
                        txtGrandTotal.Text = amount1.ToString();
                    }
                }
                else if (txt_Itemcode.Text == "")
                {
                    MessageBox.Show("Item not found..", "Item Data Not Found...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txt_qty.Text == "0")
                {
                    MessageBox.Show("Quantity not found", "Quantity Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (txtUnitCost.Text == "0.0")
                {
                    MessageBox.Show("Unit Cost not found..", "Cost Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void update_Grid()
        {
            DataTable dt_Update = new DataTable();
            dt_Update.Columns.Clear();
            dt_Update.Rows.Clear();
            dt_Update.Columns.Add("tempItem_code");
            dt_Update.Columns.Add("Branch_No");
            dt_Update.Columns.Add("Item_unit");
            dt_Update.Columns.Add("col_temp_qty");
            dt_Update.Columns.Add("Prd_Date");
            dt_Update.Columns.Add("Exp_Date");
            dt_Update.Columns.Add("period");
            if (dt_Update.Columns.Count > 0)
            {
                for (int i = 0; i < dgvGridData.Rows.Count; i++)
                {
                    if (dgvGridData.Rows[i].Cells["tempItem_code"].Value.ToString() != Item_id)
                    {
                        dt_Update.Rows.Add(dgvGridData.Rows[i].Cells["tempItem_code"].Value.ToString(), dgvGridData.Rows[i].Cells["Branch_No"].Value.ToString(), dgvGridData.Rows[i].Cells["Item_unit"].Value.ToString(), dgvGridData.Rows[i].Cells["col_temp_qty"].Value.ToString(), dgvGridData.Rows[i].Cells["Prd_Date"].Value.ToString(), dgvGridData.Rows[i].Cells["Exp_Date"].Value.ToString(), dgvGridData.Rows[i].Cells["period"].Value.ToString());
                    }
                }
            }
            if (dt_Update.Rows.Count > 0)
            {
                dgvGridData.Rows.Clear();
                foreach (DataRow dr in dt_Update.Rows)
                {
                    dgvGridData.Rows.Add(dr["tempItem_code"].ToString(), dr["Branch_No"].ToString(), dr["Item_unit"].ToString(), dr["col_temp_qty"].ToString(), dr["Prd_Date"].ToString(), dr["Exp_Date"].ToString(), dr["period"].ToString());
                }
            }
        }
        public void fill_Updategrid()
        {
            int rowindex = dgvGridData.Rows.Count;
            for (int j = 0; j < dt_forBatch.Rows.Count; j++)
            {
                if (dt_forBatch.Rows[j]["Quantity"].ToString() != "")
                {
                    dgvGridData.Rows.Add();
                    dgvGridData.Rows[rowindex].Cells["tempItem_code"].Value = Item_id;
                    dgvGridData.Rows[rowindex].Cells["Branch_No"].Value = dt_forBatch.Rows[j]["Branch_No"].ToString();
                    dgvGridData.Rows[rowindex].Cells["Item_unit"].Value = dt_forBatch.Rows[j]["col_Unit"].ToString();
                    dgvGridData.Rows[rowindex].Cells["col_temp_qty"].Value = dt_forBatch.Rows[j]["Quantity"].ToString();
                    dgvGridData.Rows[rowindex].Cells["Prd_Date"].Value = dt_forBatch.Rows[j]["Prd_Date"].ToString();
                    dgvGridData.Rows[rowindex].Cells["Exp_Date"].Value = dt_forBatch.Rows[j]["Exp_Date"].ToString();
                    dgvGridData.Rows[rowindex].Cells["period"].Value = dt_forBatch.Rows[j]["prd"].ToString();
                }
                rowindex++;
            }
        }
        public void clear()
        {
            txt_Itemcode.Clear();
            txtDescription.Clear();
            txtPacking.Clear();
            txt_qty.Text = "0";
            txt_free.Text = "0";
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.00";
            txtGst.Text = "0.0";
            txtIgst.Text = "0.0";
            cmbUnit.Text = "";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            txt_Itemcode.Clear();
            txtDescription.Clear();
            txtGst.Text = "0.0";
            txtIgst.Text = "0.0";
            txtGst.Text = "0.0";
            txtIgst.Text = "0.0";
            txtPacking.Clear();
            txt_qty.Text = "0";
            txt_free.Clear();
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.00";
            cmbUnit.Text = "";
            Btn_Add.Text = "Add"; BtnCancel.Visible = false;
            Btn_itemCode.Enabled = true; txt_Itemcode.Enabled = true;
            cmbUnit.Items.Clear();
        }

        private void dgvItemData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    bool flagDel = false;
                    Rowindex = dgvItemData.CurrentRow.Index;
                    if (dgvItemData.Rows.Count > 0)
                    {
                        if (dgvItemData.CurrentCell.OwningColumn.Name == "ItemEdit")
                        {
                            flagedit = true;
                            txt_Itemcode.Enabled = false;
                            Btn_itemCode.Enabled = false;
                            BtnCancel.Visible = true;
                            if (txt_Itemcode.Text == "")
                            {
                                txt_Itemcode.Text = dgvItemData.Rows[Rowindex].Cells["itemid"].Value.ToString();
                                txtDescription.Text = dgvItemData.Rows[Rowindex].Cells["description"].Value.ToString();
                                txt_qty.Text = dgvItemData.Rows[Rowindex].Cells["col_qty"].Value.ToString();
                                txt_free.Text = dgvItemData.Rows[Rowindex].Cells["free"].Value.ToString();
                                txtUnitCost.Text = dgvItemData.Rows[Rowindex].Cells["Unit_Cost"].Value.ToString();
                                txtAmount.Text = dgvItemData.Rows[Rowindex].Cells["Amount"].Value.ToString();
                                txtGst.Text = dgvItemData.Rows[Rowindex].Cells["gst"].Value.ToString();
                                txtIgst.Text = dgvItemData.Rows[Rowindex].Cells["igst"].Value.ToString();
                                Btn_Add.Text = "Update";
                                txt_qty.Focus();
                                Item_id = dgvItemData.Rows[Rowindex].Cells["id"].Value.ToString();
                                DataTable dtitems = this.cntrl.Get_unites(Item_id);
                                unitload(dtitems);
                                flagedit = false;
                            }
                        }
                        else if (dgvItemData.CurrentCell.OwningColumn.Name == "Del")
                        {
                            DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.No)
                            {
                            }
                            else
                            {
                                if (purchOrder_flag == true)
                                {
                                    if (txt_Itemcode.Text == "")
                                    {
                                        flagDel = true;
                                    }
                                    else
                                    {
                                        flagDel = false;
                                    }
                                }
                                else
                                {
                                    flagDel = true;
                                }
                                if (flagDel == true)
                                {
                                    DataTable dt_for_delete = new DataTable();
                                    dt_for_delete.Columns.Clear();
                                    dt_for_delete.Rows.Clear();
                                    dt_for_delete.Columns.Add("tempItem_code");
                                    dt_for_delete.Columns.Add("Branch_No");
                                    dt_for_delete.Columns.Add("Item_unit");
                                    dt_for_delete.Columns.Add("col_temp_qty");
                                    dt_for_delete.Columns.Add("Prd_Date");
                                    dt_for_delete.Columns.Add("Exp_Date");
                                    dt_for_delete.Columns.Add("period");
                                    string itemid = dgvItemData.CurrentRow.Cells["id"].Value.ToString();
                                    string itemcode = dgvItemData.CurrentRow.Cells["itemid"].Value.ToString();
                                    decimal amount = Convert.ToDecimal(dgvItemData.CurrentRow.Cells["Amount"].Value.ToString());
                                    decimal amt = Convert.ToDecimal(dgvItemData.CurrentRow.Cells["amt"].Value.ToString());
                                    decimal totalamount = Convert.ToDecimal(txtTotalCost.Text);
                                    decimal totalamt = Convert.ToDecimal(txt_TotalAmount.Text);
                                    decimal total = (totalamount - amt);
                                    txtTotalCost.Text = total.ToString();
                                    txt_TotalAmount.Text = (totalamt - amount).ToString();
                                    decimal gst = Convert.ToDecimal(dgvItemData.CurrentRow.Cells["gst"].Value.ToString());
                                    decimal igst = Convert.ToDecimal(dgvItemData.CurrentRow.Cells["igst"].Value.ToString());
                                    decimal unitcostDl = Convert.ToDecimal(dgvItemData.CurrentRow.Cells["Unit_Cost"].Value.ToString());
                                    int qtyDl = Convert.ToInt32(dgvItemData.CurrentRow.Cells["col_qty"].Value.ToString());
                                    decimal cgstDl = Convert.ToDecimal(txtCgst.Text);
                                    decimal newcgst = (((unitcostDl * qtyDl) * gst) / 100) / 2;
                                    txtCgst.Text = (cgstDl - newcgst).ToString();
                                    txtSgst.Text = (cgstDl - newcgst).ToString();
                                    decimal igstDL = Convert.ToDecimal(txtIgstResult.Text);
                                    decimal Igstnew = (((unitcostDl * qtyDl) * igst) / 100);
                                    txtIgstResult.Text = (igstDL - Igstnew).ToString();
                                    if (txt_TotalAmount.Text == "0.0")
                                    {
                                        txtDic.Text = "0.00";
                                    }
                                    dgvItemData.Rows.RemoveAt(Rowindex);
                                    foreach (DataGridViewRow row in dgvGridData.Rows)
                                    {
                                        if (row.Cells["tempItem_code"].Value.ToString() != itemid)
                                        {
                                            dt_for_delete.Rows.Add(row.Cells["tempItem_code"].Value, row.Cells["Branch_No"].Value, row.Cells["Item_unit"].Value, row.Cells["col_temp_qty"].Value, row.Cells["Prd_Date"].Value, row.Cells["Exp_Date"].Value, row.Cells["period"].Value);
                                        }
                                    }
                                    if (dt_for_delete.Rows.Count > 0)
                                    {
                                        dgvGridData.Rows.Clear();
                                        for (int i = 0; i < dt_for_delete.Rows.Count; i++)
                                        {
                                            dgvGridData.Rows.Add();
                                            dgvGridData.Rows[i].Cells[0].Value = dt_for_delete.Rows[i]["tempItem_code"].ToString();
                                            dgvGridData.Rows[i].Cells[1].Value = dt_for_delete.Rows[i]["Branch_No"].ToString();
                                            dgvGridData.Rows[i].Cells[2].Value = dt_for_delete.Rows[i]["Item_unit"].ToString();
                                            dgvGridData.Rows[i].Cells[3].Value = dt_for_delete.Rows[i]["col_temp_qty"].ToString();
                                            dgvGridData.Rows[i].Cells[4].Value = dt_for_delete.Rows[i]["Prd_Date"].ToString();
                                            dgvGridData.Rows[i].Cells[5].Value = dt_for_delete.Rows[i]["Exp_Date"].ToString();
                                            dgvGridData.Rows[i].Cells[6].Value = dt_for_delete.Rows[i]["period"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        dgvGridData.Rows.Clear();
                                    }
                                }
                            }
                        }
                    }
                    if (dgvItemData.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in dgvItemData.Rows)
                        {
                            if (row.Cells["col_qty"].Value != null && row.Cells["col_qty"].Value.ToString() != "")
                            {
                                qty = dgvItemData.Rows.Count;
                            }
                        }
                        txtTotal_item.Text = qty.ToString();
                    }
                    else
                    {
                        txtTotal_item.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void unitload(DataTable dtitems)
        {
            if (dtitems.Rows.Count > 0)
            {
                txtPacking.Text = dtitems.Rows[0]["packing"].ToString();
                cmbUnit.Items.Clear();
                if (Convert.ToInt32(dtitems.Rows[0]["UnitMF"].ToString()) == 0)
                {
                    cmbUnit.Items.Add(dtitems.Rows[0]["Unit1"].ToString());
                    cmbUnit.SelectedIndex = 0;
                }
                else
                {
                    cmbUnit.Items.Add(dtitems.Rows[0]["Unit1"].ToString());
                    cmbUnit.Items.Add(dtitems.Rows[0]["Unit2"].ToString());
                    cmbUnit.SelectedIndex = 0;
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            flag_save = true;
            try
            {
                if (flag_save == true)
                {
                    int newQty = 0;
                    int qty = 0;
                    int mf = 0;
                    DataTable dtunit2 = new DataTable();
                    check();
                    if (flagcheck == true)
                    {
                        if (txt_SupplierId.Text != "")
                        {
                            string IsExpDate = "";
                            DataTable dt = new DataTable();
                            DataTable batch_entry = new DataTable();
                            int i = 0;
                            i = this.cntrl.save_purchase(txtPurchInvNumber.Text, txtinvoiceno.Text, dtpPurchDate.Value.ToString("yyyy-MM-dd"), txt_SupplierId.Text, txt_TotalAmount.Text, txtGrandTotal.Text, txtDic.Text, txt_Discount.Text, txtTotalCost.Text);
                            if (i > 0)
                            {
                                int freeQty;
                                foreach (DataGridViewRow dr in dgvItemData.Rows)
                                {
                                    dtunit2 = this.cntrl.Get_unites(dr.Cells["id"].Value.ToString());
                                    if (dr.Cells["free"].Value == null || dr.Cells["free"].Value.ToString() == "")
                                    {
                                        freeQty = 0;
                                    }
                                    else
                                    {
                                        freeQty = Convert.ToInt32(dr.Cells["free"].Value.ToString());
                                    }
                                    if (dtunit2.Rows.Count > 0)
                                    {
                                        if (dr.Cells["note"].Value.ToString() == dtunit2.Rows[0]["Unit2"].ToString())
                                        {
                                            unit2Is = "Yes";
                                        }
                                        else
                                        {
                                            unit2Is = "No";
                                        }
                                    }
                                    this.cntrl.save_purchaseit(txtPurchInvNumber.Text, dtpPurchDate.Value.ToString("yyyy-MM-dd"), dr.Cells["id"].Value.ToString(), dr.Cells["description"].Value.ToString(), dr.Cells["Packing"].Value.ToString(), dr.Cells["note"].Value.ToString(), dr.Cells["col_qty"].Value.ToString(), freeQty, dr.Cells["Unit_Cost"].Value.ToString(), dr.Cells["Amount"].Value.ToString(), unit2Is, dtunit2.Rows[0]["UnitMF"].ToString(), Convert.ToDecimal(dr.Cells["gst"].Value.ToString()), Convert.ToDecimal(dr.Cells["igst"].Value.ToString()));
                                }
                                int a = 0;
                                decimal tempqty;
                                for (int l = 0; l < dgvGridData.Rows.Count; l++)
                                {
                                    if (dgvGridData.Rows[l].Cells["Exp_Date"].Value.ToString() != "" && dgvGridData.Rows[l].Cells["Exp_Date"].Value.ToString() != null)
                                    {
                                        IsExpDate = "Yes";
                                    }
                                    else
                                    {
                                        IsExpDate = "NO";
                                    }
                                    dt = this.cntrl.Get_unites(dgvGridData.Rows[l].Cells["tempItem_code"].Value.ToString());
                                    if (dt.Rows.Count > 0)
                                    {
                                        if (dt.Rows[0]["Unit2"].ToString() == dgvGridData.Rows[l].Cells["Item_unit"].Value.ToString())
                                        {
                                            unit2Is = "Yes";
                                        }
                                        else
                                        {
                                            unit2Is = "No";
                                        }
                                    }
                                    if (dt.Rows[0]["Unit2"].ToString() != "null")
                                    {
                                        if (unit2Is == "No")
                                        {
                                            mf = Convert.ToInt32(dt.Rows[0]["UnitMF"].ToString());
                                            qty = Convert.ToInt32(dgvGridData.Rows[l].Cells["col_temp_qty"].Value.ToString());
                                            newQty = Convert.ToInt32(mf * qty);
                                        }
                                        else
                                        {
                                            newQty = Convert.ToInt32(dgvGridData.Rows[l].Cells["col_temp_qty"].Value.ToString());
                                        }
                                    }
                                    else
                                    {
                                        newQty = Convert.ToInt32(dgvGridData.Rows[l].Cells["col_temp_qty"].Value.ToString());
                                    }
                                    a = this.cntrl.save_batchNumber(dgvGridData.Rows[l].Cells["tempItem_code"].Value.ToString(), dgvGridData.Rows[l].Cells["Branch_No"].Value.ToString(), newQty, unit2Is, dt.Rows[0]["UnitMF"].ToString(), txtPurchInvNumber.Text, Convert.ToDateTime(dgvGridData.Rows[l].Cells["Prd_Date"].Value.ToString()).ToString("yyyy-MM-dd"),dgvGridData.Rows[l].Cells["Exp_Date"].Value.ToString(), dgvGridData.Rows[l].Cells["period"].Value.ToString(), txt_SupplierId.Text, dtpPurchDate.Value.ToString("yyyy-MM-dd"), IsExpDate);
                                    if (a > 0)
                                    {
                                        batch_entry = this.cntrl.get_maxEntryNo();
                                        if (batch_entry != null)
                                        {
                                            if (dt.Rows[0]["Unit2"].ToString() != "null")
                                            {
                                                if (unit2Is == "No")
                                                {
                                                    tempqty = Convert.ToDecimal(dgvGridData.Rows[l].Cells["col_temp_qty"].Value.ToString());
                                                    tempqty = tempqty * Convert.ToDecimal(dt.Rows[0]["UnitMF"].ToString());
                                                }
                                                else
                                                {
                                                    tempqty = Convert.ToDecimal(dgvGridData.Rows[l].Cells["col_temp_qty"].Value.ToString());
                                                }
                                            }
                                            else
                                            {
                                                tempqty = Convert.ToDecimal(dgvGridData.Rows[l].Cells["col_temp_qty"].Value.ToString());
                                            }

                                            this.cntrl.save_batchpurchase(txtPurchInvNumber.Text, dtpPurchDate.Value.ToString("yyyy-MM-dd"), txt_SupplierId.Text, dgvGridData.Rows[l].Cells["tempItem_code"].Value.ToString(), dgvGridData.Rows[l].Cells["Branch_No"].Value.ToString(), tempqty, unit2Is, dt.Rows[0]["UnitMF"].ToString(), Convert.ToDateTime(dgvGridData.Rows[l].Cells["Prd_Date"].Value.ToString()).ToString("yyyy-MM-dd"),dgvGridData.Rows[l].Cells["Exp_Date"].Value.ToString(), IsExpDate, batch_entry.Rows[0][0].ToString());
                                        }
                                    }
                                }
                                Update_Itemstable();
                                if (purchOrder_flag == true)
                                {
                                    this.cntrl.update_purchaseorder(Pur_order_no1);
                                }
                            }
                            clear();
                            DialogResult res = MessageBox.Show("Data inserted Successfully,Do you want to print ?", "Success ",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                print();
                            }
                            else
                            {
                            }
                            dgvItemData.Rows.Clear();
                            dgvGridData.Rows.Clear();
                            DataTable dtb = this.cntrl.incrementDocnumber();
                            DocNumber_increment(dtb);
                            txtDic.Text = "0.00";
                            txt_Discount.Text = "0.00";
                            txtGrandTotal.Text = "0.00";
                            txtTotalCost.Text = "0.00";
                            txtTotal_item.Text = "0";
                            txt_TotalAmount.Text = "0.00";
                            txtCgst.Text = "0.00";
                            txtSgst.Text = "0.00";
                            txtIgstResult.Text = "0.00";
                            txtSupplierName.Clear();
                            txt_SupplierId.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Please select supplier", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please choose item with batch number", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Update_Itemstable()
        {
            try
            {
                string percen_SalesRate = "0", percen_SalesMin = "0", percen_SalesMax = "0", percen_SalesRate1 = "0", percen_SalesMin1 = "0", percen_SalesMax1 = "0"; decimal value1 = 0; decimal value2 = 0;
                decimal Sales1 = 0, purchaserate2 = 0; decimal SalesMin = 0; decimal SalesMax = 0; decimal Sales2 = 0; decimal SalesMin1 = 0; decimal SalesMax1 = 0;
                decimal Sales1_ = 0; decimal SalesMin_ = 0; decimal SalesMax_ = 0; decimal Sales2_ = 0; decimal SalesMin1_ = 0; decimal SalesMax1_ = 0;
                for (int i = 0; i < dgvItemData.Rows.Count; i++)
                {
                    DataTable dtb_cost = this.cntrl.get_itemdetails(dgvItemData.Rows[i].Cells["id"].Value.ToString());
                    DataTable dtb_Avg = this.cntrl.Get_itemdetails_from_purchaseit(dgvItemData.Rows[i].Cells["id"].Value.ToString());
                    if (dtb_cost.Rows.Count > 0)
                    {
                        decimal costbase1 = 0, unitcost = 0;
                        unitcost = Convert.ToDecimal(dgvItemData.Rows[i].Cells["Unit_Cost"].Value.ToString());
                        if (Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString()) != unitcost)
                        {
                            value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString());
                            value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString())) * 100;
                            percen_SalesRate = Convert.ToDecimal(value2).ToString("#0.00");
                            value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate_min"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString());
                            value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString())) * 100;
                            percen_SalesMin = Convert.ToDecimal(value2).ToString("#0.00");
                            value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate_Max"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString());
                            value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate"].ToString())) * 100;
                            percen_SalesMax = Convert.ToDecimal(value2).ToString("#0.00");
                            if (dtb_cost.Rows[0]["Unit1"].ToString() == dgvItemData.Rows[i].Cells["note"].Value.ToString())
                            {
                                Sales1 = (Convert.ToDecimal(unitcost) * Convert.ToDecimal(percen_SalesRate)) / 100;
                                Sales1_ = Convert.ToDecimal(unitcost) + Sales1;
                                SalesMin = (Convert.ToDecimal(unitcost) * Convert.ToDecimal(percen_SalesMin)) / 100;
                                SalesMin_ = Convert.ToDecimal(unitcost) + SalesMin;
                                SalesMax = (Convert.ToDecimal(unitcost) * Convert.ToDecimal(percen_SalesMax)) / 100;
                                SalesMax_ = Convert.ToDecimal(unitcost) + SalesMax;
                                costbase1 = Convert.ToDecimal(dgvItemData.Rows[i].Cells["col_qty"].Value.ToString());
                                if (Convert.ToDecimal(dtb_cost.Rows[0]["UnitMF"].ToString()) > 0)
                                {
                                    purchaserate2 = Convert.ToDecimal(unitcost) / Convert.ToDecimal(dtb_cost.Rows[0]["UnitMF"].ToString());
                                    value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate2"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString());
                                    value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString())) * 100;
                                    percen_SalesRate1 = Convert.ToDecimal(value2).ToString("#0.00");
                                    value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate_min2"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString());
                                    value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString())) * 100;
                                    percen_SalesMin1 = Convert.ToDecimal(value2).ToString("#0.00");
                                    value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate_Max2"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString());
                                    value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString())) * 100;
                                    percen_SalesMax1 = Convert.ToDecimal(value2).ToString("#0.00");
                                    Sales2 = (Convert.ToDecimal(purchaserate2) * Convert.ToDecimal(percen_SalesRate1)) / 100;
                                    Sales2_ = Convert.ToDecimal(purchaserate2) + Sales2;
                                    SalesMin1 = (Convert.ToDecimal(purchaserate2) * Convert.ToDecimal(percen_SalesMin1)) / 100;
                                    SalesMin1_ = Convert.ToDecimal(purchaserate2) + SalesMin1;
                                    SalesMax1 = (Convert.ToDecimal(purchaserate2) * Convert.ToDecimal(percen_SalesMax1)) / 100;
                                    SalesMax1_ = Convert.ToDecimal(purchaserate2) + SalesMax1;
                                }
                                this.cntrl.update_itemtable(unitcost, Sales1_, SalesMin_, SalesMax_, costbase1, purchaserate2, Sales2_, SalesMin1_, SalesMax1_, dgvItemData.Rows[i].Cells["id"].Value.ToString());
                            }
                            else if (dtb_cost.Rows[0]["Unit2"].ToString() == dgvItemData.Rows[i].Cells["note"].Value.ToString())
                            {
                                value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate2"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString());
                                value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString())) * 100;
                                percen_SalesRate1 = Convert.ToDecimal(value2).ToString("#0.00");
                                value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate_min2"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString());
                                value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString())) * 100;
                                percen_SalesMin1 = Convert.ToDecimal(value2).ToString("#0.00");
                                value1 = Convert.ToDecimal(dtb_cost.Rows[0]["Sales_Rate_Max2"].ToString()) - Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString());
                                value2 = (value1 / Convert.ToDecimal(dtb_cost.Rows[0]["Purch_Rate2"].ToString())) * 100;
                                percen_SalesMax1 = Convert.ToDecimal(value2).ToString("#0.00");
                                Sales2 = (Convert.ToDecimal(unitcost) * Convert.ToDecimal(percen_SalesRate1)) / 100;
                                Sales2_ = Convert.ToDecimal(unitcost) + Sales2;
                                SalesMin1 = (Convert.ToDecimal(unitcost) * Convert.ToDecimal(percen_SalesMin1)) / 100;
                                SalesMin1_ = Convert.ToDecimal(unitcost) + SalesMin1;
                                SalesMax1 = (Convert.ToDecimal(unitcost) * Convert.ToDecimal(percen_SalesMax1)) / 100;
                                SalesMax1_ = Convert.ToDecimal(unitcost) + SalesMax1;
                                purchaserate2 = Convert.ToDecimal(unitcost) * Convert.ToDecimal(dtb_cost.Rows[0]["UnitMF"].ToString());
                                Sales1 = (Convert.ToDecimal(purchaserate2) * Convert.ToDecimal(percen_SalesRate)) / 100;
                                Sales1_ = Convert.ToDecimal(purchaserate2) + Sales1;
                                SalesMin = (Convert.ToDecimal(purchaserate2) * Convert.ToDecimal(percen_SalesMin)) / 100;
                                SalesMin_ = Convert.ToDecimal(purchaserate2) + SalesMin;
                                SalesMax = (Convert.ToDecimal(purchaserate2) * Convert.ToDecimal(percen_SalesMax)) / 100;
                                SalesMax_ = Convert.ToDecimal(purchaserate2) + SalesMax;
                                costbase1 = Convert.ToDecimal(dgvItemData.Rows[i].Cells["col_qty"].Value.ToString()) / Convert.ToDecimal(dtb_cost.Rows[0]["UnitMF"].ToString());
                                this.cntrl.update_itemtable(purchaserate2, Sales1_, SalesMin_, SalesMax_, costbase1, unitcost, Sales2_, SalesMin1_, SalesMax1_, dgvItemData.Rows[i].Cells["id"].Value.ToString());
                            }
                        }
                        else
                        {}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void check()
        {
            for (int j = 0; j < dgvItemData.Rows.Count; j++)
            {

                for (int k = 0; k < dgvGridData.Rows.Count; k++)
                {
                    if (dgvItemData.Rows[j].Cells["id"].Value.ToString() == dgvGridData.Rows[k].Cells["tempItem_code"].Value.ToString())
                    {
                        flagcheck = true;
                    }
                    else
                    {
                        flagcheck = false;
                    }
                }
            }
        }

        public void DocNumber_increment(DataTable dtb)
        {
            GF.ResetAll_GroupBox(gbDocumentDetails);
            if (String.IsNullOrWhiteSpace(dtb.Rows[0][0].ToString()))
            {
                txtPurchInvNumber.Text = "1";
            }
            else
            {
                int Count = Convert.ToInt32(dtb.Rows[0][0]);
                int incrValue = Convert.ToInt32(Count);
                incrValue += 1;
                txtPurchInvNumber.Text = incrValue.ToString();
            }
        }
        private void print()
        {
            string message = "Do you want Header on Print?";
            string caption = "Verification";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            int c = 0;
            string strclinicname = "";
            string strStreet = "";
            string stremail = "";
            string strwebsite = "";
            string strphone = "";
            try
            {
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Data.DataTable dtp = this.cntrl.get_companydetails();
                    if (dtp.Rows.Count > 0)
                    {
                        string clinicn = "";
                        clinicn = dtp.Rows[0]["name"].ToString();
                        strclinicname = clinicn.Replace("¤", "'");
                        strphone = dtp.Rows[0]["contact_no"].ToString();
                        strStreet = dtp.Rows[0]["street_address"].ToString();
                        stremail = dtp.Rows[0]["email"].ToString();
                        strwebsite = dtp.Rows[0]["website"].ToString();
                    }
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\Purcahse.html");
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
                sWrite.WriteLine("<col >");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=11><center><br><br><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PURCHASE INVOICE </font></center></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  colspan=11 align='left'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>  <b> " + strclinicname + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  colspan=11 align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=1>  <b> " + strStreet + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  colspan=11 align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=1>  <b> " + strphone + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=11  align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=1>  <b> " + stremail + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  colspan=11 align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=1> <b> " + strwebsite + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  colspan=11  align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=2> Printed Date : " + DateTime.Now.ToString("d/MM/yyyy") + " </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=11  align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=2>   Purchase No :" + txtPurchInvNumber.Text + " </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=11  align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=2>   Invoice No :" + txtinvoiceno.Text + " </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=11 align='left'><left><FONT COLOR=black FACE='Segoe UI'  SIZE=2>   Supplier Name : " + txtSupplierName.Text + " </font></left></td>");
                sWrite.WriteLine("</tr>");
                if (dgvItemData.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='center' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Sl.No.</font></th>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Item Code</font></th>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Description</font></th>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Packing</font></th>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Unit</font></th>");
                    sWrite.WriteLine("    <td align='Right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>GST</font></th>");
                    sWrite.WriteLine("    <td align='Right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>IGST</font></th>");
                    sWrite.WriteLine("    <td align='Right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Quantity</font></th>");
                    sWrite.WriteLine("    <td align='Right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Free</font></th>");
                    sWrite.WriteLine("    <td align='Right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Unit Cost</font></th>");
                    sWrite.WriteLine("    <td align='Right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=3>Amount</font></th>");
                    sWrite.WriteLine("</tr>");
                    int k = 1;
                    while (c < dgvItemData.Rows.Count)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + k + "</font></th>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["itemid"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["description"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["Packing"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["note"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='Right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["gst"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='Right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["igst"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='Right' style='border:1px solid #000'  ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["col_qty"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='Right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["free"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='Right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["Unit_Cost"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='Right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dgvItemData.Rows[c].Cells["Amount"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("</tr>");
                        k = k + 1;
                        c++;
                    }
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td colspan=10 align='right'><right><FONT COLOR=black FACE='Segoe UI' SIZE=2>   &nbsp;Total Amount  &nbsp;:</td><td align='right'><b>" + txt_TotalAmount.Text + "</b></td>");
                    sWrite.WriteLine("</tr >");
                    if (txtDic.Text != "0.00")
                    {
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td colspan=10 align='right'><right><FONT COLOR=black FACE='Segoe UI' SIZE=2>   &nbsp;Total Discount Percent &nbsp;:</td><td align='right'><b>" + txtDic.Text + "</b></td>");
                        sWrite.WriteLine("</tr >");
                    }
                    if (txt_Discount.Text != "0.00")
                    {
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td colspan=10 align='right'><right><FONT COLOR=black FACE='Segoe UI' SIZE=2>   &nbsp;Discount Amount  &nbsp;:</td><td align='right'><b>" + txt_Discount.Text + "</b></td>");
                        sWrite.WriteLine("</tr >");
                    }
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td colspan=10 align='right'><right><FONT COLOR=black FACE='Segoe UI' SIZE=2>   &nbsp;Grand Total  &nbsp;:</td><td align='right'><b>" + txtGrandTotal.Text + "</b></td>");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\Purchase.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDic_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
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
        private void txtDic_KeyUp(object sender, KeyEventArgs e)
        {
            decimal dis;
            decimal totalAmount;
            decimal Discount;
            if (txtDic.Text != "" || txtDic.Text == ".")
            {
                dis = Convert.ToDecimal(txtDic.Text);
            }
            else
            {
                dis = 0;
            }
            totalAmount = Convert.ToDecimal(txt_TotalAmount.Text);
            Discount = Convert.ToDecimal((dis * totalAmount) / 100);
            txt_Discount.Text = Discount.ToString("##.00");
        }

        private void txtDic_Leave(object sender, EventArgs e)
        {
            if (txtDic.Text == "")
            {
                txtDic.Text = "0.0";
            }
        }

        private void txtDic_Click(object sender, EventArgs e)
        {
            if (txtDic.Text == "0.0")
            {
                txtDic.Text = "";
            }
        }

        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalamount = 0;
                decimal dic = 0;
                decimal grandtotal = 0;
                if (txt_Discount.Text == "" || txt_Discount.Text == ".")
                {
                    dic = 0;
                }
                else
                {
                    dic = Convert.ToDecimal(txt_Discount.Text);
                }
                totalamount = Convert.ToDecimal(txt_TotalAmount.Text);
                if (txt_Discount.Text != "0.00")
                {
                    grandtotal = totalamount - dic;
                    txtGrandTotal.Text = grandtotal.ToString("##.00");
                }
                else if (txt_Discount.Text == "0.00")
                {
                    txtGrandTotal.Text = txt_TotalAmount.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_TotalAmount_TextChanged(object sender, EventArgs e)
        {
            decimal total = Convert.ToDecimal(txt_TotalAmount.Text);
            decimal dic = Convert.ToDecimal(txtDic.Text);
            txt_Discount.Text = (total * dic / 100).ToString("##.00");
            decimal discount = Convert.ToDecimal(txt_Discount.Text);
            txtGrandTotal.Text = (total - discount).ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string message1 = "Do you want Print?";
            string caption1 = "Verification";
            MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
            DialogResult result1;
            result1 = MessageBox.Show(message1, caption1, buttons1);
            if (result1 == System.Windows.Forms.DialogResult.Yes)
            {
                print();
            }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            try
            {
                dgvItemData.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvItemData.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                if (purchOrder_flag == true)
                {
                    if (Pur_order_no1 > 0)
                    {
                        decimal total = 0;
                        decimal total1 = 0;
                        DataTable dt = this.cntrl.load_purchase_order_details(Pur_order_no1);
                        txtSupplierName.Text = dt.Rows[0]["Supplier_Name"].ToString();
                        txt_SupplierId.Text = dt.Rows[0]["Suppleir_id"].ToString();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dgvItemData.Rows.Add();
                            dgvItemData.Rows[i].Cells["id"].Value = dt.Rows[i]["id"].ToString();
                            dgvItemData.Rows[i].Cells["itemid"].Value = dt.Rows[i]["Item_code"].ToString();
                            dgvItemData.Rows[i].Cells["description"].Value = dt.Rows[i]["Description"].ToString();
                            dgvItemData.Rows[i].Cells["col_qty"].Value =dt.Rows[i]["Qty"].ToString();
                            dgvItemData.Rows[i].Cells["gst"].Value = "0";
                            dgvItemData.Rows[i].Cells["igst"].Value = "0";
                            dgvItemData.Rows[i].Cells["free"].Value = "0";
                            dgvItemData.Rows[i].Cells["Unit_Cost"].Value = dt.Rows[i]["UnitCost"].ToString();
                            dgvItemData.Rows[i].Cells["Amount"].Value = "0.00";
                            dgvItemData.Rows[i].Cells["amt"].Value = dt.Rows[i]["Amount"].ToString();
                            total = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                            total1 = total1 + total;
                        }
                        txtTotal_item.Text = dgvItemData.Rows.Count.ToString();
                        txtTotalCost.Text = total1.ToString();
                    }
                }
                if (Pur_List_flag == true)
                {
                    flagSup = true;
                    dtpPurchDate.Enabled = false;
                    Btn_itemCode.Enabled = false;
                    txtDescription.Enabled = false;
                    txtPacking.Enabled = false;
                    cmbUnit.Enabled = false;
                    txt_qty.Enabled = false;
                    txt_free.Enabled = false;
                    txtUnitCost.Enabled = false;
                    txtSupplierName.Enabled = false;
                    txt_SupplierId.Enabled = false;
                    txtDic.Enabled = false;
                    btn_Save.Enabled = false;
                    Btn_Add.Enabled = false;
                    btnPrint.Visible = true;
                    BtnCancel.Enabled = false;
                    dgvItemData.Enabled = false;
                    btnClear.Enabled = false;
                    decimal gstcal = 0;
                    decimal gstcal1 = 0;
                    decimal igstcal = 0;
                    decimal igstcal1 = 0;
                    if (data_from_Pur_Master1.Rows.Count > 0)
                    {
                        txtPurchInvNumber.Text = data_from_Pur_Master1.Rows[0]["PurchNumber"].ToString();
                        dtpPurchDate.Text = data_from_Pur_Master1.Rows[0]["PurchDate"].ToString();
                        txt_SupplierId.Text = data_from_Pur_Master1.Rows[0]["Sup_Code"].ToString();
                        string supplier = this.cntrl.get_suppliercode(txt_SupplierId.Text);
                        txtSupplierName.Text = supplier;
                        txtTotalCost.Text = data_from_Pur_Master1.Rows[0]["TotalCost"].ToString();
                        txt_TotalAmount.Text = data_from_Pur_Master1.Rows[0]["TotalAmount"].ToString();
                        txtDic.Text = data_from_Pur_Master1.Rows[0]["DiscPercent"].ToString();
                        txt_Discount.Text = data_from_Pur_Master1.Rows[0]["DiscAmount"].ToString();
                        string pur_type = data_from_Pur_Master1.Rows[0]["PurchType"].ToString();
                    }
                    flagSup = false;
                    if (data_from_purchase1.Rows.Count > 0)
                    {
                        int totalitem = 0;
                        for (int i = 0; i < data_from_purchase1.Rows.Count; i++)
                        {
                            dgvItemData.Rows.Add();
                            dgvItemData.Rows[i].Cells["id"].Value = data_from_purchase1.Rows[i]["id"].ToString();
                            dgvItemData.Rows[i].Cells["itemid"].Value = data_from_purchase1.Rows[i]["Item_Code"].ToString();
                            dgvItemData.Rows[i].Cells["description"].Value = data_from_purchase1.Rows[i]["Desccription"].ToString();
                            dgvItemData.Rows[i].Cells["Packing"].Value = data_from_purchase1.Rows[i]["Packing"].ToString();
                            dgvItemData.Rows[i].Cells["note"].Value = data_from_purchase1.Rows[i]["Unit"].ToString();
                            dgvItemData.Rows[i].Cells["col_qty"].Value = data_from_purchase1.Rows[i]["Qty"].ToString();
                            dgvItemData.Rows[i].Cells["free"].Value = data_from_purchase1.Rows[i]["FreeQty"].ToString();
                            dgvItemData.Rows[i].Cells["Unit_Cost"].Value = data_from_purchase1.Rows[i]["Rate"].ToString();
                            dgvItemData.Rows[i].Cells["Amount"].Value = data_from_purchase1.Rows[i]["Amount"].ToString();
                            dgvItemData.Rows[i].Cells["gst"].Value = data_from_purchase1.Rows[i]["GST"].ToString();
                            dgvItemData.Rows[i].Cells["igst"].Value = data_from_purchase1.Rows[i]["IGST"].ToString();
                            totalitem = data_from_purchase1.Rows.Count;
                            gstcal = Convert.ToDecimal(data_from_purchase1.Rows[i]["GST"].ToString());
                            gstcal1 = gstcal1 + gstcal;
                            igstcal = Convert.ToDecimal(data_from_purchase1.Rows[i]["IGST"].ToString());
                            igstcal1 = igstcal1 + igstcal;
                        }
                        txtTotal_item.Text = totalitem.ToString();
                        txtCgst.Text = (gstcal1 / 2).ToString();
                        txtSgst.Text = (gstcal1 / 2).ToString();
                        txtIgstResult.Text = igstcal1.ToString();
                    }
                }
                else
                {
                    this.dgvItemData.ColumnHeadersHeight = 25;
                    DataTable dtb = this.cntrl.incrementDocnumber();
                    DocNumber_increment(dtb);
                    dtpPurchDate.Format = DateTimePickerFormat.Short;
                    dtpPurchDate.Value = DateTime.Today;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_Itemcode.Clear();
            txtDescription.Clear();
            txtPacking.Clear();
            txt_qty.Text = "0";
            txt_free.Text = "0";
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.00";
            txtGst.Text = "0.0";
            txtIgst.Text = "0.0";
            cmbUnit.Text = "";
        }  
    }
}
