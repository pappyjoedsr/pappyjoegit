using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Purchase_Return : Form
    {
        purchase_return_controller cntrl = new purchase_return_controller();
        bool flagpurchRet = false; DataTable dt_pur_NO = new DataTable();
        public static int sup_id = 0, pur_no = 0, purchRetNo1 = 0;
        public static string unit, Pur_date, sup_name;
        public static int pur_no2 = 0;
        public static string Pur_date2;
        public static string sup_name2;
        public static int sup_id2 = 0;
        public static bool flag = false;
        public static string itemid = "";
        bool flagadd = false;
        public static string itemcd1 = "";
        DataTable dtitems = new DataTable();
        DataTable dt_unit = new DataTable();
        public static DataTable batch1;
        public static decimal retqty11;
        public static bool flagBatch = false;
        private void txt_pur_no_Click(object sender, EventArgs e)
        {
            list_Pur_no.Hide();
        }

        private void txt_pur_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_pur_no_TextChanged(object sender, EventArgs e)
        {
            if (flagpurchRet == false)
            {
                clear();
                dtpPurchDate.Value = Convert.ToDateTime(DateTime.Now.ToString());
                txtTotal_item.Text = "0";
                txtTotalCost.Text = "0.0";
                dgvGridData.Rows.Clear();
                dgvItemData.Rows.Clear();
                dt_pur_NO = this.cntrl.load_purchaenum(txt_pur_no.Text);
                if (dt_pur_NO.Rows.Count > 0)
                {
                    list_Pur_no.DataSource = dt_pur_NO;
                    list_Pur_no.ValueMember = "PurchNumber";
                    list_Pur_no.DisplayMember = "PurchNumber";
                    list_Pur_no.Show();
                }
                if (txt_pur_no.Text == "")
                {
                    clear();
                    txt_SupplierId.Text = "";
                    txtSupplierName.Text = "";
                    dtpPurchDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                }
            }
        }

        private void Btn_itemCode_Click(object sender, EventArgs e)
        {
            decimal qty = 0, retqty = 0, newqty = 0;
            if (txt_pur_no.Text != "")
            {
                var form = new Purchase_Return_ItemList(Convert.ToInt32(txt_pur_no.Text), dtpPurchDate.Value.ToString(), txtSupplierName.Text, Convert.ToInt32(txt_SupplierId.Text));
                form.ShowDialog();
                txt_Itemcode.Text = itemcd1;
                if (flag == true)
                {
                    if (check() == 0)
                    {
                        dtitems = this.cntrl.get_Loaditems_details(itemcd1, txt_pur_no.Text);
                        dt_unit = this.cntrl.get_unit_details(dtitems.Rows[0]["id"].ToString());
                        itemid = dtitems.Rows[0]["id"].ToString();
                        txt_Itemcode.Text = dtitems.Rows[0]["Item_Code"].ToString();
                        txtDescription.Text = dtitems.Rows[0]["Desccription"].ToString();
                        txtPacking.Text = dtitems.Rows[0]["Packing"].ToString();
                        txt_free.Text = dtitems.Rows[0]["FreeQty"].ToString();
                        if (dtitems.Rows[0]["UNIT2"].ToString().Trim() == "No")
                        {
                            if (Convert.ToDecimal(dt_unit.Rows[0]["UnitMF"].ToString()) != 0)
                            {
                                qty = Convert.ToDecimal(dtitems.Rows[0]["Qty"].ToString());
                                retqty = Convert.ToDecimal(dtitems.Rows[0]["RetQty"].ToString());
                                retqty = retqty / Convert.ToDecimal(dt_unit.Rows[0]["UnitMF"].ToString());
                                newqty = qty - retqty;
                            }
                            else
                            {
                                qty = Convert.ToDecimal(dtitems.Rows[0]["Qty"].ToString());
                                retqty = Convert.ToDecimal(dtitems.Rows[0]["RetQty"].ToString());
                                newqty = qty - retqty;
                            }
                        }
                        else if (dtitems.Rows[0]["UNIT2"].ToString().Trim() == "Yes")
                        {
                            qty = Convert.ToDecimal(dtitems.Rows[0]["Qty"].ToString());
                            retqty = Convert.ToDecimal(dtitems.Rows[0]["RetQty"].ToString());
                            newqty = qty - retqty;
                        }
                        txt_qty.Text = newqty.ToString();
                        txtGst.Text = dtitems.Rows[0]["GST"].ToString();
                        txtIgst.Text = dtitems.Rows[0]["IGST"].ToString();
                        if (dtitems.Rows[0]["Unit1"].ToString() != null && dtitems.Rows[0]["Unit2"].ToString() != null)
                        {
                            unitLoad(dtitems, dt_unit);
                        }
                        if (dtitems.Rows[0]["FreeQty"].ToString() == "")
                        {
                            txt_free.Text = "0";
                        }
                        txt_free.Text = dtitems.Rows[0]["FreeQty"].ToString();
                        txtUnitCost.Text = dtitems.Rows[0]["Rate"].ToString();
                        txtAmount.Text = dtitems.Rows[0]["Amount"].ToString();
                        list_Pur_no.Hide();
                        txtTotal_item.Text = dgvItemData.Rows.Count.ToString();
                        txt_qty.Focus();
                        this.ActiveControl = txt_qty;
                    }
                }
            }
            else
            {
                MessageBox.Show(" Please select purchase number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public int check()
        {
            int affected = 0;
            if (dgvItemData.Rows.Count > 0)
            {
                for (int i = 0; i < dgvItemData.Rows.Count; i++)
                {
                    if (itemcd1 == dgvItemData.Rows[i].Cells["Item_Id"].Value.ToString())
                    {
                        MessageBox.Show("Item already existed..", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        affected = 1;
                    }
                }
            }
            return affected;
        }
        public Purchase_Return()
        {
            InitializeComponent();
        }

        public Purchase_Return(int purchRetNo)
        {
            InitializeComponent();
            purchRetNo1 = purchRetNo;
            flagpurchRet = true;
        }
        public Purchase_Return(string itemcd, int pur_no1, string pur_date1, string sup_name1, int sup_id1)
        {
            InitializeComponent();
            flag = true;
            itemcd1 = itemcd;
            pur_no2 = pur_no1;
            Pur_date2 = pur_date1;
            sup_name2 = sup_name1;
            sup_id2 = sup_id1; flag = true;
        }

        public Purchase_Return(DataTable batch, decimal retqty1)
        {
            InitializeComponent();

            batch1 = batch;
            retqty11 = retqty1;
            flagBatch = true;
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            bool flagchk = false; decimal Qtty;
            if (txt_pur_no.Text != "" && txt_Itemcode.Text != "")
            {
                if (txt_qty.Text == "")
                {
                    Qtty = 0;
                }
                else
                {
                    Qtty = Convert.ToDecimal(txt_qty.Text);
                }
                flagadd = true;
                var form = new Purchase_return_Batch(cmbUnit.Text, itemid, Convert.ToInt32(txt_pur_no.Text), Qtty);
                form.ShowDialog();
                txt_qty.Text = retqty11.ToString();
                if (txt_Itemcode.Text != "" && txtDescription.Text != "" && txt_qty.Text != "0" && txtUnitCost.Text != "0.0")
                {
                    if (flagBatch == true)
                    {
                        if (dgvItemData.Rows.Count > 0)
                        {
                            for (int j = 0; j < dgvItemData.Rows.Count; j++)
                            {
                                if (dgvItemData.Rows.Count > 0)
                                {
                                    if (txt_Itemcode.Text == dgvItemData.Rows[j].Cells["Item_Id"].Value.ToString())
                                    {
                                        MessageBox.Show("Item already existed..", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    {
                                        flagchk = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            flagchk = true;
                        }
                        if (flagchk == true)
                        {
                            if (batch1 != null)
                            {

                                if (txt_free.Text == "")
                                {
                                    txt_free.Text = "0";
                                }
                                dgvItemData.Rows.Add(itemid, txt_Itemcode.Text, txtDescription.Text, txtPacking.Text, cmbUnit.Text, txtGst.Text, txtIgst.Text, txt_qty.Text, txt_free.Text, txtUnitCost.Text, txtAmount.Text);
                                int qty = 0;
                                if (batch1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < batch1.Rows.Count; i++)
                                    {
                                        if (batch1.Rows[i][0].ToString() != "")
                                        {
                                            DataTable dt = new DataTable();
                                            dt = this.cntrl.get_batchentry_qty(txt_pur_no.Text, batch1.Rows[i]["Branch_No"].ToString());
                                            decimal qtyfrom_batchnumber = 0;
                                            if (batch1.Rows[i]["Return_Qty"].ToString() != "")
                                            {
                                                retqty11 = Convert.ToDecimal(batch1.Rows[i]["Return_Qty"].ToString());
                                            }
                                            else
                                            {
                                                retqty11 = 0;
                                            }
                                            decimal updateQty = 0;
                                            qtyfrom_batchnumber = Convert.ToDecimal(dt.Rows[0]["Qty"].ToString());
                                            int count = 0;
                                            count = dgvGridData.Rows.Count;
                                            dgvGridData.Rows.Add();
                                            dgvGridData.Rows[count].Cells["tempItem_code"].Value = itemid;
                                            dgvGridData.Rows[count].Cells["Branch_No"].Value = batch1.Rows[i]["Branch_No"].ToString();
                                            dgvGridData.Rows[count].Cells["col_temp_qty"].Value = batch1.Rows[i]["Quantity"].ToString();
                                            if (batch1.Rows[i]["Return_Qty"].ToString() == "")
                                            {
                                                batch1.Rows[i]["Return_Qty"] = "0";
                                            }
                                            dgvGridData.Rows[count].Cells["Return_Qty"].Value = batch1.Rows[i]["Return_Qty"].ToString();
                                            dgvGridData.Rows[count].Cells["Batch_Entry"].Value = dt.Rows[0]["Entry_No"].ToString();
                                            dgvGridData.Rows[count].Cells["Col_Unit"].Value = batch1.Rows[i]["col_unit"].ToString();
                                            dgvGridData.Rows[count].Cells["Prd_Date"].Value = batch1.Rows[i]["Prd_Date"].ToString();
                                            dgvGridData.Rows[count].Cells["Exp_Date"].Value = batch1.Rows[i]["Exp_Date"].ToString();
                                            if (batch1.Rows[i]["Return_Qty"].ToString() != "0")
                                            {
                                                decimal tempqty = Convert.ToDecimal(batch1.Rows[i]["Quantity"].ToString());
                                                updateQty = tempqty - retqty11;
                                            }
                                            else
                                            {
                                                updateQty = Convert.ToDecimal(batch1.Rows[i]["Quantity"].ToString());
                                            }
                                            dgvGridData.Rows[count].Cells["UpdateQty"].Value = updateQty.ToString();
                                            qty = dgvItemData.Rows.Count;
                                            txtTotal_item.Text = qty.ToString();
                                            decimal ttlamount = 0, ttlamount1 = 0, igstcal = 0, igstcal1 = 0, cgstcal = 0, cgstcal1 = 0, amtcal = 0, amtcal1 = 0;
                                            foreach (DataGridViewRow row1 in dgvItemData.Rows)
                                            {
                                                if (row1.Cells["Amount"].Value != null && row1.Cells["Amount"].Value.ToString() != "")
                                                {
                                                    decimal retqty = Convert.ToDecimal(row1.Cells["col_qty"].Value.ToString());
                                                    decimal unitcost = Convert.ToDecimal(row1.Cells["Unit_Cost"].Value.ToString());
                                                    ttlamount = Convert.ToDecimal(row1.Cells["Amount"].Value.ToString());
                                                    cgstcal = Convert.ToDecimal(row1.Cells["gst"].Value.ToString());
                                                    igstcal = Convert.ToDecimal(row1.Cells["igst"].Value.ToString());
                                                    ttlamount1 = ttlamount + ttlamount1;
                                                    igstcal1 = igstcal1 + igstcal;
                                                    cgstcal1 = cgstcal1 + cgstcal;
                                                    amtcal = retqty * unitcost;
                                                    amtcal1 = amtcal1 + amtcal;
                                                }
                                            }
                                            txtTotalCost.Text = amtcal1.ToString("##.00");
                                            txt_TotalAmount.Text = ttlamount1.ToString("##.00");
                                            txtCgst.Text = (cgstcal1 / 2).ToString();
                                            txtIgstResult.Text = igstcal1.ToString();
                                            txtSgst.Text = (cgstcal1 / 2).ToString();
                                        }
                                    }
                                    batch1.Columns.Clear();
                                    batch1.Rows.Clear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select batch number", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clear();
                batch1 = null;
            }
            else
            {
                MessageBox.Show("Please select item", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable(); string unit2Is = "";
            this.cntrl.save_purReturn(DateTime.Now.ToString("yyyy-MM-dd"), txt_pur_no.Text, dtpPurchDate.Value.ToString("yyyy-MM-dd"), txt_SupplierId.Text, txt_TotalAmount.Text, txtTotalCost.Text);
            string max_retno = this.cntrl.get_maxReturnNo();
            foreach (DataGridViewRow row in dgvItemData.Rows)
            {
                string unit2 = this.cntrl.get_unit2(row.Cells["Item_Id"].Value.ToString());
                if (unit2 != "null")
                {
                    string test = row.Cells["note"].Value.ToString();
                    if (row.Cells["note"].Value.ToString() == unit2)
                    {
                        unit2Is = "Yes";
                    }
                    else
                    {
                        unit2Is = "No";
                    }
                }

                this.cntrl.save_returnItems(max_retno, row.Cells["Item_Id"].Value.ToString(), row.Cells["col_qty"].Value.ToString(), row.Cells["Unit_Cost"].Value.ToString(), unit2Is, row.Cells["free"].Value.ToString(), row.Cells["gst"].Value.ToString(), row.Cells["igst"].Value.ToString());
            }
            DataTable dtunit = new DataTable();
            foreach (DataGridViewRow rw in dgvGridData.Rows)
            {
                dtunit = this.cntrl.Get_unites(rw.Cells["tempItem_code"].Value.ToString());
                decimal QTY = 0;
                if (cmbUnit.Text == dtunit.Rows[0]["Unit1"].ToString() && dtunit.Rows[0]["UnitMF"].ToString() != "0")
                {
                    decimal QTY1 = 0;
                    int mf = Convert.ToInt32(dtunit.Rows[0]["UnitMF"].ToString());
                    QTY1 = Convert.ToDecimal(rw.Cells["UpdateQty"].Value.ToString());
                    QTY = QTY1 * mf;
                }
                else
                {
                    QTY = Convert.ToDecimal(rw.Cells["UpdateQty"].Value.ToString());
                }
                if (rw.Cells["Return_Qty"].Value.ToString() != "0")
                {
                    decimal retnew = 0, retBatch = 0, retqty = 0, batchQty = 0, batchNewQty = 0;
                    retqty = Convert.ToDecimal(rw.Cells["Return_Qty"].Value.ToString());
                    int entry = Convert.ToInt32(rw.Cells["Batch_Entry"].Value);
                    this.cntrl.upadte_batchnumber(QTY, rw.Cells["tempItem_code"].Value.ToString(), rw.Cells["Branch_No"].Value.ToString());
                    string dtretqty = this.cntrl.get_returnqty(txt_pur_no.Text, rw.Cells["tempItem_code"].Value.ToString());
                    decimal ret = 0;
                    ret = Convert.ToDecimal(dtretqty);
                    if (rw.Cells["Col_Unit"].Value.ToString() == dtunit.Rows[0]["Unit1"].ToString())
                    {
                        if (Convert.ToDecimal(dtunit.Rows[0]["UnitMF"].ToString()) != 0)
                        {
                            retqty = retqty * Convert.ToDecimal(dtunit.Rows[0]["UnitMF"].ToString());
                        }
                    }
                    if (ret > 0)
                    {
                        retnew = ret + retqty;
                    }
                    else
                    {
                        retnew = retqty;
                    }
                    retBatch = retqty;
                    this.cntrl.update_purchit(retnew, txt_pur_no.Text, rw.Cells["tempItem_code"].Value.ToString());
                    string dtBatch = this.cntrl.get_dte(txt_pur_no.Text, rw.Cells["tempItem_code"].Value.ToString(), rw.Cells["Branch_No"].Value.ToString());
                    batchQty = Convert.ToDecimal(dtBatch);
                    batchNewQty = batchQty + retBatch;
                    this.cntrl.update_batchpurchase(batchNewQty, txt_pur_no.Text, rw.Cells["tempItem_code"].Value.ToString(), rw.Cells["Branch_No"].Value.ToString());
                }
            }
            DialogResult res = MessageBox.Show("Data inserted Successfully,Do you want to print ?", "Success",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                print();
            }
            else
            {
            }
            clear();
            txtTotal_item.Text = "0";
            txtTotalCost.Text = "0.0";
            txt_TotalAmount.Text = "0.0";
            txtIgstResult.Text = "0.0";
            txtCgst.Text = "0.0";
            txtSgst.Text = "0.0";
            dtpPurchDate.Value = Convert.ToDateTime(DateTime.Now.Date);
            txt_SupplierId.Text = "";
            txtSupplierName.Text = "";
            txt_pur_no.Text = "";
            dgvGridData.Rows.Clear();
            dgvItemData.Rows.Clear();
        }

        private void list_Pur_no_MouseClick(object sender, MouseEventArgs e)
        {
            DataTable dt = new DataTable();
            txt_pur_no.Text = list_Pur_no.SelectedValue.ToString();
            dt = this.cntrl.Load_pur_details(txt_pur_no.Text);
            txtSupplierName.Text = dt.Rows[0]["Supplier_Name"].ToString();
            dtpPurchDate.Value = Convert.ToDateTime(dt.Rows[0]["PurchDate"].ToString());
            txt_SupplierId.Text = dt.Rows[0]["Sup_Code"].ToString();
            list_Pur_no.Hide();
        }

        private void txt_qty_KeyUp(object sender, KeyEventArgs e)
        {
            calculatonsss();
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            if (txt_qty.Text != "" && txtUnitCost.Text != "")
            {
                decimal qty = decimal.Parse(txt_qty.Text);
                decimal unitcost = Convert.ToDecimal(txtUnitCost.Text);
                decimal amt = 0;
                decimal gst = Convert.ToDecimal(txtGst.Text);
                decimal igst = Convert.ToDecimal(txtIgst.Text);
                if (txtGst.Text != "0.00")
                {
                    amt = (((qty * unitcost) * gst) / 100) + (qty * unitcost);
                }
                if (txtIgst.Text != "0.00")
                {
                    amt = (((qty * unitcost) * igst) / 100) + (qty * unitcost);
                }
                if (txtGst.Text == "0.00" && txtIgst.Text == "0.00")
                {
                    amt = qty * unitcost;
                }
                txtAmount.Text = amt.ToString("##.00");
            }
        }
        public void calculatonsss()
        {
            if (txt_qty.Text != "" && txtUnitCost.Text != "")
            {
                decimal gstamt = 0, igstamt = 0, unitcost = 0, igst = 0, gst = 0, qty = 0;
                unitcost = Convert.ToDecimal(txtUnitCost.Text);
                qty = Convert.ToDecimal(txt_qty.Text);
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
            }
        }
        private void FrmPurchase_Return_Load(object sender, EventArgs e)
        {
            if (flagpurchRet == true)
            {
                dgvItemData.Enabled = false;
                btn_Save.Enabled = false;
                txt_pur_no.Enabled = false;
                txtClear.Enabled = false;
                Btn_Add.Enabled = false;
                txt_SupplierId.Enabled = false;
                txtSupplierName.Enabled = false;
                btnPrint.Visible = true;
                DataTable dt = this.cntrl.load_return_details(purchRetNo1);
                if(dt.Rows.Count>0)
                {
                    txt_pur_no.Text = Convert.ToInt32(dt.Rows[0]["PurchNumber"]).ToString();
                    dtpPurchDate.Value = Convert.ToDateTime(dt.Rows[0]["PurchDate"].ToString());
                    txtSupplierName.Text = dt.Rows[0]["Supplier_Name"].ToString();
                    txt_SupplierId.Text = dt.Rows[0]["Sup_Code"].ToString();
                    txtTotalCost.Text = dt.Rows[0]["TotalCost"].ToString();
                    txt_TotalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                    txtTotal_item.Text = dt.Rows.Count.ToString();
                }
                decimal rate = 0, gst = 0, igst = 0, amount = 0, qty = 0, gstTotal = 0, igstTotal = 0, gstTotal1 = 0, igstTotal1 = 0;
                DataTable dt_unit = new DataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string dt_Packing = this.cntrl.get_packing(dt.Rows[i]["item_code"].ToString(), dt.Rows[i]["PurchNumber"].ToString());
                    rate = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                    gst = Convert.ToDecimal(dt.Rows[i]["Gst"].ToString());
                    igst = Convert.ToDecimal(dt.Rows[i]["Igst"].ToString());
                    qty = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                    dgvItemData.Rows.Add();
                    dgvItemData.Rows[i].Cells["Item_Id"].Value = dt.Rows[i]["item_code"].ToString();
                    dgvItemData.Rows[i].Cells["description"].Value = dt.Rows[i]["item_name"].ToString();
                    dgvItemData.Rows[i].Cells["Packing"].Value = dt_Packing;
                    dt_unit = this.cntrl.Get_unites(dt.Rows[i]["item_code"].ToString());
                    if (dt.Rows[i]["UNIT2"].ToString().Trim() == "Yes")
                    {
                        dgvItemData.Rows[i].Cells["note"].Value = dt_unit.Rows[0]["Unit2"].ToString();
                    }
                    else if (dt.Rows[i]["UNIT2"].ToString().Trim() == "No")
                    {
                        dgvItemData.Rows[i].Cells["note"].Value = dt_unit.Rows[0]["Unit1"].ToString();
                    }
                    dgvItemData.Rows[i].Cells["gst"].Value = dt.Rows[i]["Gst"].ToString();
                    dgvItemData.Rows[i].Cells["igst"].Value = dt.Rows[i]["Igst"].ToString();
                    dgvItemData.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["Qty"].ToString();
                    dgvItemData.Rows[i].Cells["free"].Value = dt.Rows[i]["FreeQty"].ToString();
                    dgvItemData.Rows[i].Cells["Unit_Cost"].Value = dt.Rows[i]["Rate"].ToString();
                    if (gst > 0)
                    {
                        amount = ((((rate * qty) * gst) / 100) + (rate * qty));
                    }
                    else if (igst > 0)
                    {
                        amount = ((((rate * qty) * igst) / 100) + (rate * qty));
                    }
                    else
                    {
                        amount = (rate * qty);
                    }
                    dgvItemData.Rows[i].Cells["Amount"].Value = amount.ToString();
                    if (Convert.ToDecimal(dgvItemData.Rows[i].Cells["gst"].Value.ToString()) > 0)
                    {
                        gstTotal = Convert.ToDecimal(dgvItemData.Rows[i].Cells["gst"].Value.ToString());
                        gstTotal1 = gstTotal1 + gstTotal;
                        txtCgst.Text = (gstTotal1 / 2).ToString();
                        txtSgst.Text = (gstTotal1 / 2).ToString();
                    }
                    else
                    {
                        gstTotal1 = 0;
                    }
                    if (Convert.ToDecimal(dgvItemData.Rows[i].Cells["igst"].Value.ToString()) > 0)
                    {
                        igstTotal = Convert.ToDecimal(dgvItemData.Rows[i].Cells["igst"].Value.ToString());
                        igstTotal1 = igstTotal1 + igstTotal;
                    }
                    else
                    {
                        igstTotal1 = 0;
                    }
                    txtIgstResult.Text = igstTotal1.ToString();
                }
            }
        }

        private void cmbUnit_TextChanged(object sender, EventArgs e)
        {
            calculation();
        }

        private void dgvItemData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvItemData.Rows.Count > 0)
            {
                int Rowindex = dgvItemData.CurrentRow.Index;
                if (dgvItemData.CurrentCell.OwningColumn.Name == "Del")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        DataTable dt_for_delete = new DataTable();
                        dt_for_delete.Columns.Clear();
                        dt_for_delete.Rows.Clear();
                        dt_for_delete.Columns.Add("tempItem_code");
                        dt_for_delete.Columns.Add("Branch_No");
                        dt_for_delete.Columns.Add("col_temp_qty");
                        dt_for_delete.Columns.Add("Return_Qty");
                        dt_for_delete.Columns.Add("Batch_Entry");
                        dt_for_delete.Columns.Add("Prd_Date");
                        dt_for_delete.Columns.Add("Exp_Date");
                        dt_for_delete.Columns.Add("UpdateQty");
                        string itemcode = dgvItemData.CurrentRow.Cells["Item_Id"].Value.ToString();
                        decimal amount = Convert.ToDecimal(dgvItemData.CurrentRow.Cells["Amount"].Value.ToString());
                        decimal totalamount = Convert.ToDecimal(txtTotalCost.Text);
                        decimal total = (totalamount - amount);
                        txtTotalCost.Text = total.ToString();
                        foreach (DataGridViewRow row in dgvGridData.Rows)
                        {
                            if (row.Cells["tempItem_code"].Value.ToString() != itemcode)
                            {
                                dt_for_delete.Rows.Add(row.Cells["tempItem_code"].Value, row.Cells["Branch_No"].Value, row.Cells["col_temp_qty"].Value, row.Cells["Return_Qty"].Value, row.Cells["Batch_Entry"].Value, row.Cells["Prd_Date"].Value, row.Cells["Exp_Date"].Value, row.Cells["UpdateQty"].Value);
                            }
                        }
                        dgvItemData.Rows.RemoveAt(Rowindex);
                        txtTotal_item.Text = dgvItemData.Rows.Count.ToString();
                        if (dt_for_delete.Rows.Count > 0)
                        {
                            dgvGridData.Rows.Clear();
                            for (int i = 0; i < dt_for_delete.Rows.Count; i++)
                            {
                                dgvGridData.Rows.Add();
                                dgvGridData.Rows[i].Cells[0].Value = dt_for_delete.Rows[i]["tempItem_code"].ToString();
                                dgvGridData.Rows[i].Cells[1].Value = dt_for_delete.Rows[i]["Branch_No"].ToString();
                                dgvGridData.Rows[i].Cells[2].Value = dt_for_delete.Rows[i]["col_temp_qty"].ToString();
                                dgvGridData.Rows[i].Cells[3].Value = dt_for_delete.Rows[i]["Return_Qty"].ToString();
                                dgvGridData.Rows[i].Cells[4].Value = dt_for_delete.Rows[i]["Batch_Entry"].ToString();
                                dgvGridData.Rows[i].Cells[5].Value = dt_for_delete.Rows[i]["Prd_Date"].ToString();
                                dgvGridData.Rows[i].Cells[6].Value = dt_for_delete.Rows[i]["Exp_Date"].ToString();
                                dgvGridData.Rows[i].Cells[7].Value = dt_for_delete.Rows[i]["UpdateQty"].ToString();
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

        private void txtClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_free_TextChanged(object sender, EventArgs e)
        {
            if (txt_free.Text == "null")
            {
                txt_free.Text = "0";
            }
        }

        private void cmbUnit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Data inserted Successfully,Do you want to print ?", "Success",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                print();
            }
            else
            {
            }
        }
        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        { }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void clear()
        {
            cmbUnit.Items.Clear();
            txt_Itemcode.Text = "";
            txtDescription.Text = "";
            txtPacking.Text = "0";
            txt_qty.Text = "0";
            txt_free.Text = "0";
            txtGst.Text = "0.0";
            txtIgst.Text = "0.0";
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.0";
        }
        public void unitLoad(DataTable dtitems, DataTable dt_unit)
        {
            cmbUnit.Items.Clear();
            if (dtitems.Rows.Count > 0)
            {
                string unit1 = dt_unit.Rows[0]["Unit1"].ToString();
                string unit2 = dt_unit.Rows[0]["Unit2"].ToString();
                if (unit1 != "null" && unit2 != "null")
                {
                    if (dtitems.Rows[0]["Unit"].ToString() == unit1)
                    {
                        cmbUnit.Items.Add(unit1);
                        cmbUnit.Items.Add(unit2);
                        cmbUnit.SelectedIndex = 0;
                    }
                    if (dtitems.Rows[0]["Unit"].ToString() == unit2)
                    {
                        cmbUnit.Items.Add(unit2);
                        cmbUnit.Items.Add(unit1);
                        cmbUnit.SelectedIndex = 0;
                    }
                }
                else if (unit1 == "null" && unit2 != "null")
                {
                    cmbUnit.Items.Add(unit2);
                    cmbUnit.SelectedIndex = 0;
                }
                else if (unit1 != "null" && unit2 == "null")
                {
                    cmbUnit.Items.Add(unit1);
                    cmbUnit.SelectedIndex = 0;
                }
            }
        }
        private void print()
        {
            if (dgvItemData.Rows.Count > 0)
            {
                string message = "Did you want Header on Print?";
                string caption = "Verification";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                int c = 0;
                string strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Data.DataTable dtp = this.cntrl.get_companydetails();
                    if (dtp.Rows.Count > 0)
                    {
                        strclinicname = dtp.Rows[0]["name"].ToString();
                        strphone = dtp.Rows[0]["contact_no"].ToString();
                        strStreet = dtp.Rows[0]["street_address"].ToString();
                        stremail = dtp.Rows[0]["email"].ToString();
                        strwebsite = dtp.Rows[0]["website"].ToString();
                    }
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\PurcahseReturn.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("<style>");
                sWrite.WriteLine("table { border-collapse: collapse;}");
                sWrite.WriteLine("p.big {line-height: 400%;}");
                sWrite.WriteLine("</style>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br><br><br>");
                sWrite.WriteLine("<div>");
                sWrite.WriteLine("<table align=center width=1093>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=8><left><br><br><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=4> PURCHASE RETURN </font></center></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=4>  <br><b> " + strclinicname + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>  <b> " + strStreet + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>  <b> " + strphone + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>  <b> " + stremail + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3> <b> " + strwebsite + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <b>Printed Date : </b> " + DateTime.Now.ToString("MM/dd/yyyy") + " </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align=center width=1093>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right' width=19000><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Purchase No </font></right></td><td width=192>:&nbsp;&nbsp;</td><td align ='right'SIZE=3>" + txt_pur_no.Text + "</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Supplier Name </font></right></td><td width=192>:&nbsp;&nbsp;</td><td align ='right'SIZE=2>" + txtSupplierName.Text + "</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align=center width=1093>");
                if (dgvItemData.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Item Code</font></td>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Description</font></td>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Unit</font></td>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>GST</font></td>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>IGST</font></td>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Return Quantity</font></td>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Free</font></td>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Unit Cost</font></td>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>Amount</font></td>");
                    sWrite.WriteLine("</tr>");
                    while (c < dgvItemData.Rows.Count)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["Item_ID"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["description"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["note"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["gst"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["igst"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["col_qty"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["free"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["Unit_Cost"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["Amount"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("</tr>");
                        c++;
                    }
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<table align=center width=1093>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='right' width=19000><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>   Total Item </font></right></td><td width=192>:&nbsp;&nbsp;</td><td align ='right'SIZE=3>" + txtTotal_item.Text + "</td>");
                    sWrite.WriteLine("</tr >");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='right' width=19000><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>   Total Cost </font></right></td><td width=192>:&nbsp;&nbsp;</td><td align ='right'SIZE=3>" + txt_TotalAmount.Text + "</td>");
                    sWrite.WriteLine("</tr >");
                }
                sWrite.WriteLine("</td>");
                sWrite.WriteLine("</tr >");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\PurcahseReturn.html");
            }
            else
            {
                MessageBox.Show("No Record Found", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void calculation()
        {
            decimal amt = 0;
            decimal gstamt = 0;
            decimal gst = Convert.ToDecimal(txtGst.Text);
            decimal igst = Convert.ToDecimal(txtIgst.Text);
            string unit2 = dt_unit.Rows[0]["Unit2"].ToString();
            string unit1 = dt_unit.Rows[0]["Unit1"].ToString();
            string unit;
            int UnitMf = Convert.ToInt32(dtitems.Rows[0]["UnitMF"].ToString());
            if (txt_qty.Text != "" && txtUnitCost.Text != "")
            {
                unit = cmbUnit.Text;
                if (unit == unit2)
                {
                    unit = cmbUnit.Text;
                    decimal qty = decimal.Parse(txt_qty.Text);
                    decimal unitcost = Convert.ToDecimal(txtUnitCost.Text) / UnitMf;
                    if (gst != 0)
                    {
                        gstamt = (((unitcost * qty) * gst) / 100) + (unitcost * qty);
                        txtAmount.Text = gstamt.ToString("##.00");
                        txtUnitCost.Text = unitcost.ToString();

                    }
                    else if (igst != 0)
                    {
                        gstamt = (((unitcost * qty) * igst) / 100) + (unitcost * qty);
                        txtAmount.Text = gstamt.ToString("##.00");
                        txtUnitCost.Text = unitcost.ToString();
                    }
                    else if (gst == 0 && igst == 0)
                    {
                        txtUnitCost.Text = unitcost.ToString();
                        amt = unitcost * qty;
                        txtAmount.Text = amt.ToString("##.00");
                        txtUnitCost.Text = unitcost.ToString();
                    }
                    txt_qty.Text = qty.ToString();
                }
                if (unit == unit1)
                {
                    unit = cmbUnit.Text;
                    decimal qty = decimal.Parse(txt_qty.Text);
                    decimal unitcost = Convert.ToDecimal(txtUnitCost.Text) * UnitMf;
                    if (gst != 0)
                    {
                        gstamt = (((unitcost * qty) * gst) / 100) + (unitcost * qty);
                        txtAmount.Text = gstamt.ToString("##.00");
                        txtUnitCost.Text = unitcost.ToString();
                    }
                    else if (igst != 0)
                    {
                        gstamt = (((unitcost * qty) * igst) / 100) + (unitcost * qty);
                        txtAmount.Text = gstamt.ToString("##.00");
                        txtUnitCost.Text = unitcost.ToString();
                    }
                    else if (gst == 0 && igst == 0)
                    {
                        txtUnitCost.Text = unitcost.ToString();
                        amt = unitcost * qty;
                        txtAmount.Text = amt.ToString("##.00");
                        txtUnitCost.Text = unitcost.ToString();
                    }
                    txt_qty.Text = qty.ToString();
                }
            }
        }
    }
}
