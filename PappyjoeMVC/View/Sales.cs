using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Sales : Form
    {
        sales_controller cntrl=new sales_controller();
        string FormName = "";
        GeneralFunctions GF = new GeneralFunctions(); public static string Stock_From_List = "";
        public static string ItemCode_From_List = "";
        public static string ItemName_From_List = "";
        public bool salesOrder_flag = false;
        public static string itemId = "";
        bool flagSup = false;
        public decimal TotalStock;
        public int rowindex;
        public bool sales_Edit = false;
        decimal GST = 0, Cgst = 0, Sgst = 0;
        public static int invnum_Edit;
        string Payment_method = ""; private string p1;
        public static DataTable dtFor_CurrentStockUpdate_Bill = new DataTable();
        public static DataTable dtFor_CurrentStockUpdate;
        DataTable FrmBatchsale_edit = new DataTable();
        public static bool batch_flag = false; public string doctor_id = "0";
        public static string invnum_order; string path = ""; string logo_name = "";
        public Sales()
        {
            InitializeComponent();
        }
        public Sales(int invnum)
        {
            InitializeComponent();
            invnum_Edit = invnum;
            sales_Edit = true;
        }
        public Sales(string invNumOrder, string p1)
        {
            InitializeComponent();
            invnum_order = invNumOrder;
            this.p1 = p1;
            salesOrder_flag = true;
        }
        public Sales(string item_code, string item_Name, string stock, string itemID)
        {
            InitializeComponent();
            ItemCode_From_List = item_code;
            ItemName_From_List = item_Name;
            Stock_From_List = stock;
            itemId = itemID;
        }
        public Sales(DataTable dtb_Sales)
        {
            InitializeComponent();
            dtFor_CurrentStockUpdate = dtb_Sales;
            batch_flag = true;
        }
        private void btn_item_Choose_Click(object sender, EventArgs e)
        {
            FormName = "Sales";
            cmb_Unit.Items.Clear();
            if (txt_ItemCode.Text != "")
            {
                var form2 = new ItemListForSales(FormName, txt_ItemCode.Text);
                form2.ShowDialog();
                form2.Dispose();
                if (ItemCode_From_List != "")
                {
                    if (btn_AddtoGrid.Text == "Add")
                    {
                        txt_ItemCode.Text = ItemCode_From_List;
                        if (itemcheck() == 0)
                        {
                            txt_Discription.Text = ItemName_From_List;
                           DataTable dtb= this.cntrl.get_itemdetails(itemId);
                            Load_itemdetails(dtb);
                        }
                        else
                        {
                            txt_ItemCode.Text = "";
                            txt_ItemCode.Focus();
                        }
                    }
                }
            }
            else
            {
                var form2 = new ItemListForSales(FormName);
                form2.ShowDialog();
                form2.Dispose();
                if (ItemCode_From_List != "")
                {
                    if (btn_AddtoGrid.Text == "Add")
                    {
                        txt_ItemCode.Text = ItemCode_From_List;
                        if (itemcheck() == 0)
                        {
                            txt_Discription.Text = ItemName_From_List;
                            DataTable dtb=this.cntrl.get_itemdetails(itemId);
                            Load_itemdetails(dtb);
                        }
                        else
                        {
                            txt_ItemCode.Text = "";
                            txt_ItemCode.Focus();
                        }
                    }
                }
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
                        MessageBox.Show("The value already existed ", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        affected = 1;
                    }
                }
            }
            return affected;
        }
        public void Load_itemdetails(DataTable dtb)
        {
            string unit1 = "", unit2 = "";
            if (dtb.Rows.Count > 0)
            {
                txt_UnitCost.Text = Convert.ToDecimal(dtb.Rows[0][0].ToString()).ToString("##.00");
                txt_Packing.Text = dtb.Rows[0][1].ToString();
                unit1 = dtb.Rows[0]["Unit1"].ToString();
                txt_GST.Text = dtb.Rows[0]["GST"].ToString();
                txt_IGST.Text = dtb.Rows[0]["IGST"].ToString();
                if (unit1 != "")
                {
                    cmb_Unit.Items.Add(unit1);
                }
                if (dtb.Rows[0]["Unit2"].ToString() != "null" && dtb.Rows[0]["Unit2"].ToString() != "")
                {
                    unit2 = dtb.Rows[0]["Unit2"].ToString();
                    cmb_Unit.Items.Add(unit2);
                }
                cmb_Unit.SelectedIndex = 0;
            }
            else
                txt_UnitCost.Text = "0.00";
        }
        private void txtBdoctor_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtBdoctor.Text != "")
            {
                DataTable dtdr = this.cntrl.GetDoctorName(txtBdoctor.Text);
                lbIdoctor.DisplayMember = "doctor_name";
                lbIdoctor.ValueMember = "id";
                lbIdoctor.DataSource = dtdr;
                if (e.KeyCode == Keys.Enter && lbIdoctor.Items.Count > 0)
                {
                    var value = lbIdoctor.GetItemText(lbIdoctor.SelectedValue);
                    System.Data.DataTable supplier = this.cntrl.get_doctorname_by_id(value);
                    if (supplier.Rows.Count > 0)
                    {
                        txtBdoctor.Text = supplier.Rows[0]["doctor_name"].ToString();
                    }
                    lbIdoctor.Visible = false;
                    txtBdoctor.Focus();
                }
                else if (e.KeyCode == Keys.Down && lbIdoctor.Items.Count > 0)
                {
                    lbIdoctor.Focus();
                }
                else if (lbIdoctor.Items.Count > 0)
                {
                    lbIdoctor.Location = new Point(138, 100);
                    lbIdoctor.Visible = true;
                }
                else
                {
                    lbIdoctor.Visible = false;
                }
            }
            else
            {
                lbIdoctor.Visible = false;
            }
        }
        private void lbIdoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lbIdoctor.SelectedItems.Count > 0)
                {
                    var value = lbIdoctor.SelectedValue.ToString();
                    System.Data.DataTable doctor = this.cntrl.get_doctorname_by_id(value);
                    if (doctor.Rows.Count > 0)
                    {
                        txtBdoctor.Text = doctor.Rows[0]["doctor_name"].ToString();
                        lbIdoctor.Visible = false;
                    }
                }
            }
        }
        private void lbIdoctor_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbIdoctor.SelectedItems.Count > 0)
            {
                var value = lbIdoctor.SelectedValue.ToString(); 
                System.Data.DataTable doctor = this.cntrl.get_doctorname_by_id(value);
                if (doctor.Rows.Count > 0)
                {
                    txtBdoctor.Text = doctor.Rows[0]["doctor_name"].ToString();
                    lbIdoctor.Visible = false;
                }
            }
        }
        private void txtPatient_KeyUp(object sender, KeyEventArgs e)
        {
            if (flagSup == false)
            {
               DataTable dtb= this.cntrl.patient_keydown(txtPatient.Text);
                Fill_litbox(dtb);
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
            flagSup = false;
        }
        private void lbPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flagSup = true;
                string value = lbPatient.SelectedValue.ToString();
               DataTable dtb= this.cntrl.patients(value);
                fill_patientdetails(dtb);
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
        public void Fill_litbox(DataTable dtdr)
        {
            if (dtdr.Rows.Count > 0)
            {
                lbPatient.Show();
                lbPatient.Location = new Point(txtPatient.Location.X, 27);
                lbPatient.DisplayMember = "pt_name";
                lbPatient.ValueMember = "pt_id";
                lbPatient.DataSource = dtdr;
            }
            else
            {
                txtPatient.Text = "";
                txtPatientID.Text = "";
                txt_Street.Text = "";
                txt_Locality.Text = "";
                txt_City.Text = "";
                txt_PhoneNo.Text = "";
                lbPatient.Hide();
            }
        }
        public void fill_patientdetails(DataTable dtdr)
        {
            if (dtdr.Rows.Count > 0)
            {
                txtPatient.Text = dtdr.Rows[0]["pt_name"].ToString();
                txtPatientID.Text = dtdr.Rows[0]["pt_id"].ToString();
                txt_Street.Text = dtdr.Rows[0]["street_address"].ToString();
                txt_Locality.Text = dtdr.Rows[0]["locality"].ToString();
                txt_City.Text = dtdr.Rows[0]["city"].ToString();
                txt_PhoneNo.Text = dtdr.Rows[0]["primary_mobile_number"].ToString();
                lbPatient.Hide();
            }
            else
            {
                txtPatient.Text = "";
                txtPatientID.Text = "";
                txt_Street.Text = "";
                txt_Locality.Text = "";
                txt_City.Text = "";
                txt_PhoneNo.Text = "";
                lbPatient.Hide();
            }
        }
        private void lbPatient_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbPatient.SelectedItems.Count > 0)
            {
                string value = lbPatient.SelectedValue.ToString();
                DataTable dtb= this.cntrl.patients(value);
                fill_patientdetails(dtb);
                lbPatient.Visible = false;
            }
        }
        private void txt_ItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string item = txt_ItemCode.Text;
                if (item != "")
                {
                    FormName = "Sales";
                    var form2 = new ItemListForSales(FormName, txt_ItemCode.Text);
                    form2.ShowDialog();
                    form2.Dispose();
                    if (ItemCode_From_List != "")
                    {
                      DataTable dtb=this.cntrl.get_itemdetails(itemId);
                        Load_itemdetails(dtb);
                    }
                }
            }
        }
        private void cmb_Unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void cmb_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Unit.SelectedIndex >= 0)
            {
                if (btn_AddtoGrid.Text == "Update" && salesOrder_flag == false)
                {
                    txt_Qty.Focus();
                }
                TotalAmount_Calculation();
            }
        }
        public void TotalAmount_Calculation()
        {
            Decimal gst = 0, gst_Amount = 0, igst_Amount = 0, igst = 0, qty = 0, unitMf = 0, unitcost = 0, Amount = 0,TotalAmount = 0;
            decimal d;
            DataTable dtb = this.cntrl.itemdetails(itemId);
            if (dtb.Rows.Count > 0)
            {
                unitMf = Convert.ToDecimal(dtb.Rows[0]["UnitMF"].ToString());
                if (cmb_Unit.Text == dtb.Rows[0]["Unit2"].ToString())
                {
                    {
                        unitcost = Convert.ToDecimal(dtb.Rows[0]["Sales_Rate_Max"].ToString()) / unitMf;
                        txt_UnitCost.Text = unitcost.ToString("##.00");
                    }
                }
                else
                {
                    txt_UnitCost.Text = dtb.Rows[0]["Sales_Rate_Max"].ToString();
                    if (decimal.TryParse(txt_UnitCost.Text, out d))
                    {
                        unitcost = Convert.ToDecimal(txt_UnitCost.Text);
                    }
                }
            }
            if (decimal.TryParse(txt_GST.Text, out d))
            {
                gst = Convert.ToDecimal(txt_GST.Text);
            }
            if (decimal.TryParse(txt_IGST.Text, out d))
            {
                igst = Convert.ToDecimal(txt_IGST.Text);
            }
            if (decimal.TryParse(txt_Qty.Text, out d))
            {
                qty = Convert.ToDecimal(txt_Qty.Text);
            }
            if (Convert.ToDecimal(txt_GST.Text) > 0)
            {
                Amount = qty * unitcost;
                gst_Amount = (Amount * gst) / 100;
                TotalAmount = Amount + gst_Amount;
                txt_Amount.Text = TotalAmount.ToString("##.00");
            }
            else if (Convert.ToDecimal(txt_IGST.Text) > 0)
            {
                Amount = qty * unitcost;
                igst_Amount = (Amount * igst) / 100;
                TotalAmount = Amount + igst_Amount;
                txt_Amount.Text = TotalAmount.ToString("##.00");
            }
            else
            {
                TotalAmount = (qty * unitcost);
                txt_Amount.Text = TotalAmount.ToString("##.00");
            }
        }
        private void txt_GST_Click(object sender, EventArgs e)
        {
            if (txt_GST.Text == "0")
            {
                txt_GST.Text = "";
            }
        }
        private void txt_GST_Leave(object sender, EventArgs e)
        {
            if (txt_GST.Text == "")
            {
                txt_GST.Text = "0";
            }
            else if (Convert.ToDecimal(txt_GST.Text) > 0)
            {
                txt_IGST.Text = "0";
            }
        }
        private void txt_GST_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
            string a = txt_GST.Text;
            string b = a.TrimStart('0');
            txt_GST.Text = b;
        }
        private void txt_GST_KeyUp(object sender, KeyEventArgs e)
        {
            decimal d;
            if (decimal.TryParse(txt_GST.Text, out d))
            {
                TotalAmount_Calculation();
            }
            else
            {
                txt_GST.Text = "0";
                TotalAmount_Calculation();
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
        private void txt_GST_TextChanged(object sender, EventArgs e)
        {
            if (txt_GST.Text != "" && txt_GST.Text != ".")
            {
                if (Convert.ToDecimal(txt_GST.Text) > 0)
                {
                    txt_IGST.Text = "0";
                }
                else
                {
                    txt_GST.Text = "0";
                    TotalAmount_Calculation();
                }
            }
        }
        private void txt_IGST_Click(object sender, EventArgs e)
        {
            if (txt_IGST.Text == "0")
            {
                txt_IGST.Text = "";
            }
        }
        private void txt_IGST_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
            string a = txt_IGST.Text;
            string b = a.TrimStart('0');
            txt_IGST.Text = b;
        }
        private void txt_IGST_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_IGST.Text))
            {
                TotalAmount_Calculation();
            }
        }
        private void txt_IGST_Leave(object sender, EventArgs e)
        {
            if (txt_IGST.Text == "")
            {
                txt_IGST.Text = "0";
            }
            else if (Convert.ToDecimal(txt_IGST.Text) > 0)
            {
                txt_GST.Text = "0";
            }
        }
        private void txt_IGST_TextChanged(object sender, EventArgs e)
        {
            if (txt_IGST.Text != "" && txt_IGST.Text != ".")
            {
                if (Convert.ToDecimal(txt_IGST.Text) > 0)
                {
                    txt_GST.Text = "0";
                }
                else
                {
                    txt_IGST.Text = "0";
                    TotalAmount_Calculation();
                }
            }
        }
        private void txt_Qty_Click(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "0")
            {
                txt_Qty.Text = "";
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
                DataTable dtb_qty = this.cntrl.Get_stock(itemId);
                if (dtb_qty.Rows[0][0].ToString() != "")
                {
                    if (Convert.ToDecimal(dtb_qty.Rows[0][0].ToString()) < Convert.ToDecimal(txt_Qty.Text))
                    {
                        MessageBox.Show("low Quantity...only have limited stock. Available Stock = " + dtb_qty.Rows[0][0].ToString(), "limited Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_Qty.Clear();
                    }
                }
            }
            if (txt_UnitCost.Text != "")
            {
                TotalAmount_Calculation();
            }
        }
        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            string a = txt_Qty.Text;
            string b = a.TrimStart('0');
            txt_Qty.Text = b;
        }
        private void txt_Free_Click(object sender, EventArgs e)
        {
            if (txt_Free.Text == "0")
            {
                txt_Free.Text = "";
            }
        }
        private void txt_Free_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            string a = txt_Free.Text;
            string b = a.TrimStart('0');
            txt_Free.Text = b;
        }
        private void txt_Free_Leave(object sender, EventArgs e)
        {
            if (txt_Free.Text == "")
            {
                txt_Free.Text = "0";
            }
            else
            {
                string a = txt_Free.Text;
                string b = a.TrimStart('0');
                txt_Free.Text = b;
            }
        }
        private void txt_UnitCost_Click(object sender, EventArgs e)
        {
            if (txt_UnitCost.Text == "0.00")
            {
                txt_UnitCost.Text = "";
            }
        }
        private void txt_UnitCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }
        private void txt_UnitCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_UnitCost.Text))
            {
                TotalAmount_Calculation();
            }
        }
        private void txt_UnitCost_Leave(object sender, EventArgs e)
        {
            if (txt_UnitCost.Text == "")
            {
                txt_UnitCost.Text = "0.00"; 
            }
        }
        private void txt_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }
        private void btn_AddtoGrid_Click(object sender, EventArgs e)
        {
            try
            {
                Decimal TotalGst = 0;
                Decimal Total_Igst = 0; decimal Stock = 0;
                int Totalqty = 0; decimal qty = 0;
                Decimal TotalAmount = 0;
                Decimal TotalCost = 0; decimal gstAmount = 0; decimal igstAmount = 0;
                if (!string.IsNullOrWhiteSpace(txt_ItemCode.Text) && !string.IsNullOrWhiteSpace(txt_Discription.Text) && !string.IsNullOrWhiteSpace(txt_Qty.Text))
                {
                    if (Convert.ToDecimal(txt_Qty.Text) > 0 && Convert.ToDecimal(txt_UnitCost.Text) > 0)
                    {
                        string item_Code = itemId;
                        if (txt_Free.Text == "") { txt_Free.Text = "0"; }
                        if (Convert.ToInt32(txt_Free.Text) > 0)
                        {
                            qty = Convert.ToDecimal(txt_Qty.Text) + Convert.ToDecimal(txt_Free.Text);
                        }
                        else
                            qty = Convert.ToDecimal(txt_Qty.Text);
                        string unit = cmb_Unit.Text;
                        DataTable dt_unit1 = this.cntrl.get_item_unitmf(itemId);
                        DataTable Dt_updateStock = this.cntrl.Get_stock(itemId);
                        if (Dt_updateStock.Rows[0][0].ToString() != "")
                        {
                            TotalStock = Convert.ToDecimal(Dt_updateStock.Rows[0][0].ToString());
                        }
                        if (dt_unit1.Rows.Count > 0)
                        {
                            decimal unitmf = Convert.ToDecimal(dt_unit1.Rows[0]["UnitMF"].ToString());
                            if(unitmf>0)
                            {
                                if (dt_unit1.Rows[0]["Unit1"].ToString() == unit)
                                {
                                    Stock = qty * unitmf;
                                }
                                else
                                {
                                    Stock = qty;
                                }
                            }
                            else
                            {
                                Stock = qty;
                            }
                        }
                        if (btn_AddtoGrid.Text == "Add")
                        {
                            if (Stock <= TotalStock)
                            {
                                var form2 = new Batch_Sale(item_Code, qty, unit);
                                form2.ShowDialog();
                                if (dtFor_CurrentStockUpdate != null)
                                {
                                    Fiil_BatchSale_Grid();
                                    dgv_SalesItem.Rows.Add(itemId, txt_ItemCode.Text, txt_Discription.Text, txt_Packing.Text, dt_unit1.Rows[0]["HSN_Number"].ToString(), cmb_Unit.Text, txt_GST.Text, txt_IGST.Text, txt_Qty.Text, txt_Free.Text, txt_UnitCost.Text, txt_Amount.Text, PappyjoeMVC.Properties.Resources.editicon, PappyjoeMVC.Properties.Resources.deleteicon);
                                    clear_itemdetails();
                                }
                                else
                                {
                                    MessageBox.Show("Does not add batch!..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Quantity is greater than the stock", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            if (salesOrder_flag == true)
                            {
                                if (itemcheck_Batchgrid() == 0)
                                {
                                    if (Stock <= TotalStock)
                                    {
                                        var form2 = new Batch_Sale(item_Code, qty, unit);
                                        form2.ShowDialog();
                                        form2.Dispose();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Quantity is greater than the stock", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                else
                                {
                                    FrmBatchsale_edit.Rows.Clear();
                                    FrmBatchsale_edit.Columns.Clear();
                                    createTempTable();
                                    if (FrmBatchsale_edit.Rows.Count > 0)
                                    {
                                        if (Stock <= TotalStock)
                                        {
                                            var form2 = new Batch_Sale(item_Code, qty, FrmBatchsale_edit, unit);
                                            form2.ShowDialog();
                                            form2.Dispose();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Quantity is greater than the stock", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                                dgv_SalesItem.Rows[rowindex].Cells["colItemCode"].Value = txt_ItemCode.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["colDiscription"].Value = txt_Discription.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["ColPacking"].Value = txt_Packing.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["ColUnit"].Value = cmb_Unit.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["ColGST"].Value = txt_GST.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["colIGST"].Value = txt_IGST.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["ColQty"].Value = txt_Qty.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["ColFree"].Value = txt_Free.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["colUnitcost"].Value = txt_UnitCost.Text;
                                dgv_SalesItem.Rows[rowindex].Cells["colAmount"].Value = txt_Amount.Text;
                                if (itemcheck_Batchgrid() == 0)
                                {
                                    if (dtFor_CurrentStockUpdate != null)
                                    {
                                        Fiil_BatchSale_Grid();
                                        clear_itemdetails();
                                        dtFor_CurrentStockUpdate = null;
                                        batch_flag = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Does not add batch!..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    if (dtFor_CurrentStockUpdate != null)
                                    {
                                        if (dgv_SalesItem.Rows.Count == 1)
                                        {
                                            dgv_BatchSale.Rows.Clear();
                                        }
                                        else
                                            update_Grid();
                                        fill_Updategrid();
                                        dtFor_CurrentStockUpdate = null; txt_ItemCode.Enabled = true;
                                        batch_flag = false;
                                    }
                                    clear_itemdetails();
                                }

                                btn_AddtoGrid.Text = "Add"; btn_cancel.Visible = false;
                            }
                            else
                            { 
                                FrmBatchsale_edit.Rows.Clear();
                                FrmBatchsale_edit.Columns.Clear();
                                createTempTable();
                                if (FrmBatchsale_edit.Rows.Count > 0)
                                {
                                    if (Stock <= TotalStock)
                                    {
                                        var form2 = new Batch_Sale(item_Code, qty, FrmBatchsale_edit, unit);
                                        form2.ShowDialog();
                                        form2.Dispose();
                                        if (rowindex > 0)
                                        {
                                            dgv_SalesItem.Rows[rowindex].Cells["colItemCode"].Value = txt_ItemCode.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["colDiscription"].Value = txt_Discription.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["ColPacking"].Value = txt_Packing.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["ColUnit"].Value = cmb_Unit.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["ColGST"].Value = txt_GST.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["colIGST"].Value = txt_IGST.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["ColQty"].Value = txt_Qty.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["ColFree"].Value = txt_Free.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["colUnitcost"].Value = txt_UnitCost.Text;
                                            dgv_SalesItem.Rows[rowindex].Cells["colAmount"].Value = txt_Amount.Text;
                                            if (dtFor_CurrentStockUpdate != null)
                                            {
                                                if (dgv_SalesItem.Rows.Count == 1)
                                                {
                                                    dgv_BatchSale.Rows.Clear();
                                                }
                                                else
                                                    update_Grid();
                                                fill_Updategrid();
                                                clear_itemdetails(); txt_ItemCode.Enabled = true;
                                                btn_AddtoGrid.Text = "Add"; btn_cancel.Visible = false;
                                                dtFor_CurrentStockUpdate = null;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Does not add batch!..", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Quantity is greater than the stock", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                            }
                        }
                        foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                        {
                            if (dr.Cells["ColGST"].Value != null && dr.Cells["ColGST"].Value.ToString() != "")
                            {
                                gstAmount = ((Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString())) * Convert.ToDecimal(dr.Cells["ColGST"].Value.ToString())) / 100;
                                TotalGst = TotalGst + gstAmount;
                            }
                            if (dr.Cells["colIGST"].Value != null && dr.Cells["colIGST"].Value.ToString() != "")
                            {
                                igstAmount = ((Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString())) * Convert.ToDecimal(dr.Cells["colIGST"].Value.ToString())) / 100;
                                Total_Igst = Total_Igst + igstAmount;
                            }
                            if (dr.Cells["colAmount"].Value != null && dr.Cells["colAmount"].Value.ToString() != "")
                            {
                                TotalAmount = TotalAmount + Convert.ToDecimal(dr.Cells["colAmount"].Value.ToString());
                            }
                            if (dr.Cells["colUnitcost"].Value != null && dr.Cells["colUnitcost"].Value.ToString() != "")
                            {
                                TotalCost = TotalCost + (Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString()));
                            }
                        }
                        Totalqty = dgv_SalesItem.Rows.Count;
                        if (Totalqty > 0)
                        {
                            txt_totalItems.Text = Totalqty.ToString();
                        }
                        if (TotalGst > 0)
                        {
                            decimal cgst = TotalGst / 2;
                            txt_SGST.Text = Convert.ToDecimal(cgst).ToString("##0.00");
                            txt_CGST.Text = Convert.ToDecimal(cgst).ToString("##0.00");
                        }
                        if (Total_Igst > 0)
                        {
                            Txt_TotalIGST.Text = Convert.ToDecimal(Total_Igst).ToString("##0.00");
                        }
                        if (TotalAmount > 0)
                        {
                            Txt_TotalAmount.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
                            txt_GrandTotal.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
                        }
                        if (TotalCost > 0)
                        {
                            txt_TotalCost.Text = Convert.ToDecimal(TotalCost).ToString("##0.00");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mandatory fields should not be empty.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_ItemCode.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mandatory fields should not be empty.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int itemcheck_Batchgrid()
        {
            int affected = 0;
            for (int i = 0; i < dgv_BatchSale.Rows.Count; i++)
            {
                if (dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value != null && txt_ItemCode.Text == dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString())
                {
                    affected = 1;
                }
            }
            return affected;
        }
        public void createTempTable()
        {
            foreach (DataGridViewColumn col in dgv_BatchSale.Columns)
            {
                FrmBatchsale_edit.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dgv_BatchSale.Rows)
            {
                DataRow dRow = FrmBatchsale_edit.NewRow();
                if (row.Cells["coiltem_code"].Value.ToString() == itemId)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    FrmBatchsale_edit.Rows.Add(dRow);
                }
            }
        }
        public void fill_Updategrid()
        {
            int rowindex = dgv_BatchSale.Rows.Count;
            for (int j = 0; j < dtFor_CurrentStockUpdate.Rows.Count; j++)
            {
                if (dtFor_CurrentStockUpdate.Rows[j]["ColQty"].ToString() != "")
                {
                    dgv_BatchSale.Rows.Add();
                    dgv_BatchSale.Rows[rowindex].Cells["ColinvNum"].Value = txtDocumentNumber.Text;
                    dgv_BatchSale.Rows[rowindex].Cells["ColInvDate"].Value = dtpDocumentDate.Value.ToShortDateString();
                    dgv_BatchSale.Rows[rowindex].Cells["coiltem_code"].Value = txt_ItemCode.Text;
                    dgv_BatchSale.Rows[rowindex].Cells["colQuantity"].Value = dtFor_CurrentStockUpdate.Rows[j]["ColQty"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["colBatchnumber"].Value = dtFor_CurrentStockUpdate.Rows[j]["colbatchNo"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["colBatchEntry"].Value = dtFor_CurrentStockUpdate.Rows[j]["colentryNo"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["colStock"].Value = dtFor_CurrentStockUpdate.Rows[j]["ColStock"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["colIsExp"].Value = txt_Qty.Text;
                    dgv_BatchSale.Rows[rowindex].Cells["prddate"].Value = dtFor_CurrentStockUpdate.Rows[j]["ColPrd_Date"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["expdate"].Value = dtFor_CurrentStockUpdate.Rows[j]["colExpDate"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["colQuantity"].Value = dtFor_CurrentStockUpdate.Rows[j]["ColQty"].ToString();
                    dgv_BatchSale.Rows[rowindex].Cells["unit"].Value = dtFor_CurrentStockUpdate.Rows[j]["clUnit"].ToString();
                    if (dtFor_CurrentStockUpdate.Rows[j]["colCurrentStock"].ToString() != "")
                    {
                        dgv_BatchSale.Rows[rowindex].Cells["currentStock"].Value = dtFor_CurrentStockUpdate.Rows[j]["colCurrentStock"].ToString();
                    }
                    else
                        dgv_BatchSale.Rows[rowindex].Cells["currentStock"].Value = dtFor_CurrentStockUpdate.Rows[j]["ColStock"].ToString();
                }
                rowindex++;
            }
        }
        public void update_Grid()
        {
            DataTable dt_Update = new DataTable();
            dt_Update.Columns.Clear();
            dt_Update.Rows.Clear();
            dt_Update.Columns.Add("invNo");
            dt_Update.Columns.Add("invDate");
            dt_Update.Columns.Add("ItemCode");
            dt_Update.Columns.Add("Batchno");
            dt_Update.Columns.Add("qty");
            dt_Update.Columns.Add("Stock");
            dt_Update.Columns.Add("CurrentStock");
            dt_Update.Columns.Add("IsexpDate");
            dt_Update.Columns.Add("BatchEntry");
            dt_Update.Columns.Add("Prd.date");
            dt_Update.Columns.Add("Exp.date");
            dt_Update.Columns.Add("unit");
            if (dt_Update.Columns.Count > 0)
            {
                for (int i = 0; i < dgv_BatchSale.Rows.Count; i++)
                {
                    if (dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString() != txt_ItemCode.Text)
                    {
                        dt_Update.Rows.Add(dgv_BatchSale.Rows[i].Cells["ColinvNum"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["ColInvDate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colBatchnumber"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colQuantity"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colStock"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["currentStock"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colIsExp"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colBatchEntry"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["prddate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["expdate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["unit"].Value.ToString());
                    }
                }
            }
            if (dt_Update.Rows.Count > 0)
            {
                dgv_BatchSale.Rows.Clear();
                foreach (DataRow dr in dt_Update.Rows)
                {
                    dgv_BatchSale.Rows.Add(dr["invNo"].ToString(), dr["invDate"].ToString(), dr["ItemCode"].ToString(), dr["Batchno"].ToString(), dr["qty"].ToString(), dr["Stock"].ToString(), dr["CurrentStock"].ToString(), dr["IsexpDate"].ToString(), dr["BatchEntry"].ToString(), dr["Prd.date"].ToString(), dr["Exp.date"].ToString(), dr["unit"].ToString());
                }
            }
        }
        public void Fiil_BatchSale_Grid()
        {
            int row = dgv_BatchSale.Rows.Count;
            if (dtFor_CurrentStockUpdate.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFor_CurrentStockUpdate.Rows)
                {
                    if (dr["ColQty"].ToString() != "")
                    {
                        dgv_BatchSale.Rows.Add();
                        dgv_BatchSale.Rows[row].Cells["ColinvNum"].Value = txtDocumentNumber.Text;
                        dgv_BatchSale.Rows[row].Cells["ColInvDate"].Value = dtpDocumentDate.Value.ToShortDateString();
                        dgv_BatchSale.Rows[row].Cells["coiltem_code"].Value = itemId;
                        dgv_BatchSale.Rows[row].Cells["colBatchnumber"].Value = dr["colbatchNo"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colQuantity"].Value = dr["ColQty"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colStock"].Value = dr["ColStock"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colBatchEntry"].Value = dr["colentryNo"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colIsExp"].Value = txt_Qty.Text;
                        dgv_BatchSale.Rows[row].Cells["prddate"].Value = dr["ColPrd_Date"].ToString();
                        dgv_BatchSale.Rows[row].Cells["expdate"].Value = dr["colExpDate"].ToString();
                        dgv_BatchSale.Rows[row].Cells["unit"].Value = dr["clUnit"].ToString();
                        if (dr["colCurrentStock"].ToString() != "")
                        {
                            dgv_BatchSale.Rows[row].Cells["currentStock"].Value = dr["colCurrentStock"].ToString();
                        }
                        else
                            dgv_BatchSale.Rows[row].Cells["currentStock"].Value = dr["ColStock"].ToString();
                    }
                    row++;
                }
            }
        }
        public void clear_itemdetails()
        {
            txt_ItemCode.Text = "";
            txt_Discription.Text = "";
            txt_Packing.Text = "";
            txt_GST.Text = "0";
            txt_IGST.Text = "0";
            txt_Qty.Text = "0";
            txt_Free.Text = "0";
            txt_UnitCost.Text = "0.00";
            txt_Amount.Text = "0.00";
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            clear_itemdetails();
            btn_AddtoGrid.Text = "Add";
            btn_cancel.Visible = false;
        }
        private void dgv_SalesItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_SalesItem.Rows.Count > 0 && e.RowIndex >= 0)
                {
                    Decimal Qty = 0, IGST = 0, GST = 0, Cost = 0, TotalItems = 0, TotalCost = 0, TotalGst = 0, TotalAmount = 0, igstAmount = 0, gstAmount = 0, DiscAmount = 0;
                    string itmCode = "", quantity = ""; txt_ItemCode.Enabled = true;
                    if (dgv_SalesItem.CurrentCell.OwningColumn.Name == "colEdit")
                    {
                        rowindex = dgv_SalesItem.CurrentRow.Index;
                        txt_ItemCode.Text = dgv_SalesItem.Rows[rowindex].Cells["colItemCode"].Value.ToString();
                        txt_Discription.Text = dgv_SalesItem.Rows[rowindex].Cells["colDiscription"].Value.ToString();
                        cmb_Unit.Text = dgv_SalesItem.Rows[rowindex].Cells["ColUnit"].Value.ToString();
                        txt_GST.Text = dgv_SalesItem.Rows[rowindex].Cells["ColGST"].Value.ToString();
                        txt_IGST.Text = dgv_SalesItem.Rows[rowindex].Cells["colIGST"].Value.ToString();
                        txt_Qty.Text = dgv_SalesItem.Rows[rowindex].Cells["ColQty"].Value.ToString();
                        txt_Free.Text = dgv_SalesItem.Rows[rowindex].Cells["ColFree"].Value.ToString();
                        itemId = dgv_SalesItem.Rows[rowindex].Cells["id"].Value.ToString();
                        if (salesOrder_flag == true)
                        {
                            cmb_Unit.Items.Clear();
                            DataTable dtb = this.cntrl.get_salesrate_unit(itemId);
                            update_itemload(dtb);
                        }
                        else
                        {
                            txt_Packing.Text = dgv_SalesItem.Rows[rowindex].Cells["ColPacking"].Value.ToString();
                            txt_UnitCost.Text = Convert.ToDecimal(dgv_SalesItem.Rows[rowindex].Cells["colUnitcost"].Value.ToString()).ToString("##.00");
                            txt_Amount.Text = Convert.ToDecimal(dgv_SalesItem.Rows[rowindex].Cells["colAmount"].Value.ToString()).ToString("##.00");
                        }
                        btn_AddtoGrid.Text = "Update"; btn_cancel.Visible = true;
                        txt_ItemCode.Enabled = false;
                    }
                    if (dgv_SalesItem.CurrentCell.OwningColumn.Name == "colDelete")
                    {
                        int index = dgv_SalesItem.CurrentRow.Index;
                        itmCode = dgv_SalesItem.CurrentRow.Cells["colItemCode"].Value.ToString();
                        quantity = dgv_SalesItem.CurrentRow.Cells["ColQty"].Value.ToString();
                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            Qty = Convert.ToDecimal(dgv_SalesItem.Rows[index].Cells["ColQty"].Value.ToString());
                            if (Txt_TotalIGST.Text != "")
                            {
                                if (dgv_SalesItem.CurrentRow.Cells["colIGST"].Value != null && dgv_SalesItem.Rows[index].Cells["colIGST"].Value.ToString() != "")
                                {
                                    igstAmount = ((Convert.ToDecimal(dgv_SalesItem.CurrentRow.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dgv_SalesItem.CurrentRow.Cells["colUnitcost"].Value.ToString())) * Convert.ToDecimal(dgv_SalesItem.CurrentRow.Cells["colIGST"].Value.ToString())) / 100;
                                    IGST = Convert.ToDecimal(Txt_TotalIGST.Text) - igstAmount;
                                    Txt_TotalIGST.Text = Convert.ToDecimal(IGST).ToString("##0.00");
                                }
                            }
                            if (txt_TotalCost.Text != "")
                            {
                                Cost = (Qty * Convert.ToDecimal(dgv_SalesItem.Rows[index].Cells["colUnitcost"].Value.ToString()));
                                TotalCost = Convert.ToDecimal(txt_TotalCost.Text) - Cost;
                                txt_TotalCost.Text = Convert.ToDecimal(TotalCost).ToString("##0.00");
                            }
                            if (txt_totalItems.Text != "")
                            {
                                TotalItems = Convert.ToDecimal(txt_totalItems.Text) - 1;
                                txt_totalItems.Text = Convert.ToDecimal(TotalItems).ToString();
                            }
                            if (Txt_TotalAmount.Text != "")
                            {
                                TotalAmount = Convert.ToDecimal(Txt_TotalAmount.Text) - Convert.ToDecimal(dgv_SalesItem.Rows[index].Cells["colAmount"].Value.ToString());
                                Txt_TotalAmount.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
                            }
                            if (txt_CGST.Text != "" && txt_SGST.Text != "")
                            {
                                if (dgv_SalesItem.CurrentRow.Cells["ColGST"].Value != null && dgv_SalesItem.Rows[index].Cells["ColGST"].Value.ToString() != "")
                                {
                                    TotalGst = Convert.ToDecimal(txt_CGST.Text) + Convert.ToDecimal(txt_SGST.Text);
                                    gstAmount = ((Convert.ToDecimal(dgv_SalesItem.CurrentRow.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dgv_SalesItem.CurrentRow.Cells["colUnitcost"].Value.ToString())) * Convert.ToDecimal(dgv_SalesItem.CurrentRow.Cells["ColGST"].Value.ToString())) / 100;
                                    GST = TotalGst - gstAmount;
                                    decimal gst_ = GST / 2;
                                    txt_CGST.Text = Convert.ToDecimal(gst_).ToString("##0.00");
                                    txt_SGST.Text = Convert.ToDecimal(gst_).ToString("##0.00");
                                }
                            }
                            if (txt_DiscAmount.Text != "0.00")
                            {
                                DiscAmount = ((Convert.ToDecimal(Txt_TotalAmount.Text) * Convert.ToDecimal(txt_Discount.Text)) / 100);
                                txt_DiscAmount.Text = Convert.ToDecimal(DiscAmount).ToString("##0.00");
                                txt_GrandTotal.Text = Convert.ToDecimal(Convert.ToDecimal(Txt_TotalAmount.Text) - Convert.ToDecimal(txt_DiscAmount.Text)).ToString("##.00");
                            }
                            else
                            {
                                txt_GrandTotal.Text = Convert.ToDecimal(Txt_TotalAmount.Text).ToString("##0.00");
                            }
                            dgv_SalesItem.Rows.RemoveAt(index);
                            fill_Batch_delete(itmCode,quantity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void update_itemload(DataTable dt_cost)
        {
            string unit1 = "", unit2 = ""; decimal Amount = 0, gst_Amount = 0, Total_Amount = 0, gst = 0, igst_Amount = 0, igst = 0;
            unit1 = dt_cost.Rows[0]["Unit1"].ToString();
            if (unit1 != "")
            {
                cmb_Unit.Items.Add(unit1);
            }
            if (dt_cost.Rows[0]["Unit2"].ToString() != "null" && dt_cost.Rows[0]["Unit2"].ToString() != "")
            {
                unit2 = dt_cost.Rows[0]["Unit2"].ToString();
                cmb_Unit.Items.Add(unit2);
            }
            cmb_Unit.SelectedIndex = 0;
            if (dt_cost.Rows.Count > 0)
            {
                txt_Packing.Text = dt_cost.Rows[0][0].ToString();
            }
            else
                txt_Packing.Text = "";
            txt_UnitCost.Text = dt_cost.Rows[0][1].ToString();
            if (Convert.ToDecimal(txt_GST.Text) > 0)
            {
                Amount = Convert.ToDecimal(txt_Qty.Text) * Convert.ToDecimal(txt_UnitCost.Text);
                gst_Amount = (Amount * Convert.ToDecimal(txt_GST.Text)) / 100;
                Total_Amount = Amount + gst_Amount;
                txt_Amount.Text = Total_Amount.ToString("##.00");
            }
            else if (Convert.ToDecimal(txt_IGST.Text) > 0)
            {
                Amount = Convert.ToDecimal(txt_Qty.Text) * Convert.ToDecimal(txt_UnitCost.Text);
                igst_Amount = (Amount * igst) / 100;
                Total_Amount = Amount + igst_Amount;
                txt_Amount.Text = Total_Amount.ToString("##.00");
            }
            else
            {
                txt_Amount.Text = Convert.ToDecimal(Convert.ToDecimal(txt_Qty.Text) * Convert.ToDecimal(dt_cost.Rows[0][1].ToString())).ToString();
            }
        }
        public void fill_Batch_delete(string itemcode, string quantity)
        {
            DataTable dtrow = new DataTable();
            dtrow.Columns.Clear();
            dtrow.Rows.Clear();
            dtrow.Columns.Add("invNo");
            dtrow.Columns.Add("invDate");
            dtrow.Columns.Add("ItemCode");
            dtrow.Columns.Add("Batchno");
            dtrow.Columns.Add("qty");
            dtrow.Columns.Add("Stock");
            dtrow.Columns.Add("CurrentStock");
            dtrow.Columns.Add("IsexpDate");
            dtrow.Columns.Add("BatchEntry");
            dtrow.Columns.Add("Prd.date");
            dtrow.Columns.Add("Exp.date");
            dtrow.Columns.Add("unit");
            if (dtrow.Columns.Count > 0)
            {
                for (int i = 0; i < dgv_BatchSale.Rows.Count; i++)
                {
                    if (dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString() != itemcode)
                    {
                        dtrow.Rows.Add(dgv_BatchSale.Rows[i].Cells["ColinvNum"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["ColInvDate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colBatchnumber"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colQuantity"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colStock"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["currentStock"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colIsExp"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colBatchEntry"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["prddate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["expdate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["unit"].Value.ToString());
                    }
                }
            }
            if (dtrow.Rows.Count > 0)
            {
                dgv_BatchSale.Rows.Clear();
                for (int i = 0; i < dtrow.Rows.Count; i++)
                {
                    dgv_BatchSale.Rows.Add(dtrow.Rows[i][0].ToString(), dtrow.Rows[i][1].ToString(), dtrow.Rows[i][2].ToString(), dtrow.Rows[i][3].ToString(), dtrow.Rows[i][4].ToString(), dtrow.Rows[i][5].ToString(), dtrow.Rows[i][6].ToString(), dtrow.Rows[i][7].ToString(), dtrow.Rows[i][8].ToString(), dtrow.Rows[i][9].ToString(), dtrow.Rows[i][10].ToString(), dtrow.Rows[i][11].ToString());
                }
            }
            else
            {
                dgv_BatchSale.Rows.Clear();
            }
        }
        private void frmSales_Load(object sender, EventArgs e)
        {
            try
            {
                dgv_SalesItem.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_SalesItem.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_SalesItem.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_SalesItem.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_SalesItem.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_SalesItem.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                lbIdoctor.Location = new Point(131, 103);
                lbIdoctor.Visible = false;
                btnReport.Visible = false;
                lbPatient.Visible = false;
                if (sales_Edit == true)
                {
                    clear_All_Data();
                    //DisabledAllControlls();
                    btnReport.Visible = true;
                    if (invnum_Edit > 0)
                    {
                        DataTable dtb = this.cntrl.sales_details(invnum_Edit);
                        Load_masterdetails(dtb);
                        //this.cntrl.sales_items_details(invnum_Edit);
                    }
                }
                else
                {
                    load_prescription();
                    EnabledAllControlls();
                    btnReport.Visible = false;
                    DataTable Document_Number = this.cntrl.docnumber();
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
                    if (salesOrder_flag == true)
                    {
                        if (invnum_order != "")
                        {
                            DataTable dtb = this.cntrl.salesOrder_master(Convert.ToInt32(invnum_order));
                            Load_order_master(dtb);
                            DataTable dtb1 = this.cntrl.order_itemsDtails(Convert.ToInt32(invnum_order));
                            Load_orderitems(dtb1);
                        }
                    }
                    System.Data.DataTable tb_doctor = this.cntrl.get_doctor(doctor_id);
                    if (tb_doctor.Rows.Count > 0)
                    {
                        txtBdoctor.Text = tb_doctor.Rows[0]["doctor_name"].ToString();
                    }
                }
                System.Data.DataTable clinicname = this.cntrl.Get_CompanyNAme();
                if (path != "")
                {
                    string curFile = this.cntrl.server() + "\\Pappyjoe_utilities\\Logo\\" + path;

                    if (File.Exists(curFile))
                    {
                        logo_name = "";
                        logo_name = path;
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        if (!File.Exists(Apppath + "\\" + logo_name))
                        {
                            System.IO.File.Copy(curFile, Apppath + "\\" + logo_name);
                        }
                    }
                    else
                    {
                        logo_name = "";
                    }
                }
            }   
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear_All_Data()
        {
            dtpDocumentDate.Text = DateTime.Now.ToString();
            txtBdoctor.Text = "";
            lbIdoctor.Visible = false;
            lbPatient.Visible = false;
            txt_LRNO.Text = "";
            DTP_LRDate.Text = DateTime.Now.ToString();
            txt_OrderNo.Text = "";
            DTP_OrderDate.Text = DateTime.Now.ToString();
            txt_Through.Text = "";
            txtPatient.Text = "";
            txtPatientID.Text = "";
            txt_Street.Text = "";
            txt_Locality.Text = "";
            txt_City.Text = "";
            txt_PhoneNo.Text = "";
            txt_totalItems.Text = "0";
            Txt_TotalAmount.Text = "0.00";
            txt_DiscAmount.Text = "0.00";
            txt_Discount.Text = "0";
            txt_GrandTotal.Text = "00.00";
            txt_GrandTotal.ForeColor = Color.Red;
            txt_TotalCost.Text = "0.00";
            Txt_TotalIGST.Text = "0";
            txt_SGST.Text = "0";
            txt_CGST.Text = "0";
            txt_4Digit.Text = "";
            txt_BankNAme.Text = "";
            txt_Number.Text = "";
            dgv_SalesItem.Rows.Clear();
            dgv_BatchSale.Rows.Clear();
        }
        public void DisabledAllControlls()
        {
            dtpDocumentDate.Enabled = false;
            txtSales.Enabled = false;
            txtBdoctor.Enabled = false;
            lbIdoctor.Visible = false;
            lbPatient.Visible = false;
            DTP_LRDate.Enabled = false;
            txt_OrderNo.Enabled = false;
            DTP_OrderDate.Enabled = false;
            txt_Through.Enabled = false;
            txtPatient.Enabled = false;
            txtPatientID.Enabled = false;
            txt_Street.Enabled = false;
            txt_Locality.Enabled = false;
            txt_City.Enabled = false;
            txt_PhoneNo.Enabled = false;
            txt_totalItems.Enabled = false;
            Txt_TotalAmount.Enabled = false;
            txt_DiscAmount.Enabled = false;
            txt_Discount.Enabled = false;
            txt_GrandTotal.Enabled = false;
            txt_GrandTotal.ForeColor = Color.Red;
            txt_TotalCost.Enabled = false;
            Txt_TotalIGST.Enabled = false;
            txt_SGST.Enabled = false;
            txt_CGST.Enabled = false;
            txt_ItemCode.Enabled = false;
            txt_Discription.Enabled = false;
            txt_Packing.Enabled = false;
            cmb_Unit.Enabled = false;
            txt_GST.Enabled = false;
            txt_IGST.Enabled = false;
            txt_Qty.Enabled = false;
            txt_Free.Enabled = false;
            txt_UnitCost.Enabled = false;
            btn_AddtoGrid.Enabled = false;
            btnSave.Enabled = false;
            dgv_SalesItem.Enabled = false;
            txt_LRNO.Enabled = false;
            BTN_CLEAR.Enabled = false;
        }
        public void Load_masterdetails(DataTable dtb_master)
        {
            try
            {
                if (dtb_master.Rows.Count > 0)
                {
                    txtDocumentNumber.Text = dtb_master.Rows[0]["InvNumber"].ToString();
                    dtpDocumentDate.Text = dtb_master.Rows[0]["InvDate"].ToString();
                    txtSales.Text = dtb_master.Rows[0]["SalesmanCode"].ToString();
                    txtBdoctor.Text = dtb_master.Rows[0]["Prescribedby"].ToString();
                    DTP_LRDate.Text = dtb_master.Rows[0]["LRDate"].ToString();
                    txt_OrderNo.Text = dtb_master.Rows[0]["OrderNumber"].ToString();
                    DTP_OrderDate.Text = dtb_master.Rows[0]["Orderdate"].ToString();
                    txt_Through.Text = dtb_master.Rows[0]["Through"].ToString();
                    txtPatient.Text = dtb_master.Rows[0]["cust_name"].ToString();
                    txtPatientID.Text = dtb_master.Rows[0]["cust_number"].ToString();
                    txt_Street.Text = dtb_master.Rows[0]["adr1"].ToString();
                    txt_Locality.Text = dtb_master.Rows[0]["adr2"].ToString();
                    txt_City.Text = dtb_master.Rows[0]["adr3"].ToString();
                    txt_PhoneNo.Text = dtb_master.Rows[0]["phone1"].ToString();
                }
                DataTable dtb_sales = this.cntrl.sales_items_details(invnum_Edit);
                decimal gstAmount = 0, igstAmount = 0;
                decimal TotalAmount = 0, DisAmount = 0, TotalCost = 0, ToatalGST = 0, TotalIGST = 0;
                int qty = 0;
                for (int i = 0; i < dtb_sales.Rows.Count; i++)
                {
                    dgv_SalesItem.Rows.Add();
                    dgv_SalesItem.Rows[i].Cells["id"].Value = dtb_sales.Rows[i]["InvNumber"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colItemCode"].Value = dtb_sales.Rows[i]["Item_Code"].ToString();
                    DataTable dtb_hsn = this.cntrl.get_hsn(dtb_sales.Rows[i]["Item_Code"].ToString());
                    dgv_SalesItem.Rows[i].Cells["colItemCode"].Value = dtb_hsn.Rows[0]["Item_Code"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colDiscription"].Value = dtb_sales.Rows[i]["Description"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColPacking"].Value = dtb_sales.Rows[i]["Packing"].ToString();
                    dgv_SalesItem.Rows[i].Cells["hsn"].Value = dtb_hsn.Rows[0]["HSN_Number"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColUnit"].Value = dtb_sales.Rows[i]["Unit"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColQty"].Value = dtb_sales.Rows[i]["Qty"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColFree"].Value = dtb_sales.Rows[i]["FreeQty"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value = Convert.ToDecimal(dtb_sales.Rows[i]["Rate"].ToString()).ToString("##.00"); 
                    //dgv_SalesItem.Rows[i].Cells["hsn"].Value = Convert.ToDecimal(dtb_sales.Rows[i]["Rate"].ToString()).ToString("##.00");
                   
                    if (Convert.ToInt32(dtb_sales.Rows[i]["GST"].ToString()) > 0)
                    {
                        
                        dgv_SalesItem.Rows[i].Cells["ColGST"].Value = dtb_sales.Rows[i]["GST"].ToString();
                        gstAmount = ((Convert.ToDecimal(dtb_sales.Rows[i]["Qty"].ToString()) * Convert.ToDecimal(dtb_sales.Rows[i]["Rate"].ToString())) * Convert.ToDecimal(dtb_sales.Rows[i]["GST"].ToString())) / 100;
                        ToatalGST = ToatalGST + gstAmount;
                    }
                    else
                        dgv_SalesItem.Rows[i].Cells["ColGST"].Value = "0";
                    if (Convert.ToInt32(dtb_sales.Rows[i]["IGST"].ToString()) > 0) 
                    {
                        dgv_SalesItem.Rows[i].Cells["colIGST"].Value = dtb_sales.Rows[i]["IGST"].ToString();
                        igstAmount = ((Convert.ToDecimal(dtb_sales.Rows[i]["Qty"].ToString()) * Convert.ToDecimal(dtb_sales.Rows[i]["Rate"].ToString())) * Convert.ToDecimal(dtb_sales.Rows[i]["GST"].ToString())) / 100;
                        TotalIGST = TotalIGST + igstAmount;
                    }
                    else
                        dgv_SalesItem.Rows[i].Cells["colIGST"].Value = "0";

                   
                    dgv_SalesItem.Rows[i].Cells["colAmount"].Value = dtb_sales.Rows[i]["TotalAmount"].ToString();
                    TotalAmount = TotalAmount + Convert.ToDecimal(dtb_sales.Rows[i]["TotalAmount"].ToString());
                    TotalCost = TotalCost + (Convert.ToInt32(dtb_sales.Rows[i]["Qty"].ToString()) * Convert.ToDecimal(dtb_sales.Rows[i]["Rate"].ToString()));
                    dgv_SalesItem.Rows[i].Cells["colEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgv_SalesItem.Rows[i].Cells["colDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                }
                qty = dtb_sales.Rows.Count;
                txt_totalItems.Text = qty.ToString();
                Txt_TotalAmount.Text = TotalAmount.ToString("##.00");
                if (Convert.ToInt32(dtb_master.Rows[0]["Discount"].ToString()) > 0)
                {
                    txt_Discount.Text = dtb_master.Rows[0]["Discount"].ToString();
                }
                else
                {
                    txt_Discount.Text = "0";
                }
                if (Convert.ToInt32(txt_Discount.Text) > 0)
                {
                    DisAmount = Convert.ToDecimal((TotalAmount * Convert.ToDecimal(txt_Discount.Text)) / 100);
                    txt_DiscAmount.Text = DisAmount.ToString("##.00"); ;
                    txt_GrandTotal.Text = Convert.ToDecimal(Convert.ToDecimal(TotalAmount) - Convert.ToDecimal(DisAmount)).ToString("##.00");
                }
                else
                {
                    txt_DiscAmount.Text = "0.00";
                    txt_GrandTotal.Text = TotalAmount.ToString("##.00"); ;
                }
                txt_GrandTotal.ForeColor = Color.Red;
                if (ToatalGST > 0)
                {
                    decimal sgst = ToatalGST / 2;
                    txt_SGST.Text = sgst.ToString();
                    txt_CGST.Text = sgst.ToString();
                }
                else
                {
                    txt_SGST.Text = "0";
                    txt_CGST.Text = "0";
                }
                if (TotalIGST > 0)
                {
                    Txt_TotalIGST.Text = TotalIGST.ToString();
                }
                else
                    Txt_TotalIGST.Text = "0";
                txt_TotalCost.Text = TotalCost.ToString();
                DataTable dtb_BatchSale = this.cntrl.get_batchsale(invnum_Edit);
                if (dtb_BatchSale.Rows.Count > 0)
                {
                    dgv_BatchSale.Rows.Clear();
                    for (int i = 0; i < dtb_BatchSale.Rows.Count; i++)
                    {
                        dgv_BatchSale.Rows.Add(dtb_BatchSale.Rows[i]["InvNumber"].ToString(), dtb_BatchSale.Rows[i]["InvDate"].ToString(), dtb_BatchSale.Rows[i]["Item_Code"].ToString(), dtb_BatchSale.Rows[i]["BatchNumber"].ToString(), dtb_BatchSale.Rows[i]["Qty"].ToString(),"","", dtb_BatchSale.Rows[i]["IsExpDate"].ToString(), dtb_BatchSale.Rows[i]["BatchEntry"].ToString(), dtb_BatchSale.Rows[i]["prddate"].ToString(),dtb_BatchSale.Rows[i]["expdate"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void load_prescription()
        {
            System.Data.DataTable dt_pre_main = this.cntrl.load_prescription();
            int i = 0;
            for (int j = 0; j < dt_pre_main.Rows.Count; j++)
            {
                presgrid.Rows.Add(dt_pre_main.Rows[j]["id"].ToString(), dt_pre_main.Rows[j]["pt_name"].ToString() + " (" + dt_pre_main.Rows[j]["pt_id"].ToString() + ")", String.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dt_pre_main.Rows[j]["date"].ToString())));
                i = i + 1;
            }
        }
        public void EnabledAllControlls()
        {
            dtpDocumentDate.Enabled = true;
            txtSales.Enabled = true;
            txtBdoctor.Enabled = true;
            lbIdoctor.Visible = false;
            lbPatient.Visible = false;
            DTP_LRDate.Enabled = true;
            txt_OrderNo.Enabled = true;
            DTP_OrderDate.Enabled = true;
            txt_LRNO.Enabled = true;
            txt_Through.Enabled = true;
            txtPatient.Enabled = true;
            txt_totalItems.Enabled = true;
            Txt_TotalAmount.Enabled = true;
            txt_DiscAmount.Enabled = true;
            txt_Discount.Enabled = true;
            txt_GrandTotal.Enabled = true;
            txt_GrandTotal.ForeColor = Color.Red;
            txt_TotalCost.Enabled = true;
            Txt_TotalIGST.Enabled = true;
            txt_SGST.Enabled = true;
            txt_CGST.Enabled = true;
            txt_ItemCode.Enabled = true;
            txt_Discription.Enabled = true;
            txt_Packing.Enabled = true;
            cmb_Unit.Enabled = true;
            txt_GST.Enabled = true;
            txt_IGST.Enabled = true;
            txt_Qty.Enabled = true;
            txt_Free.Enabled = true;
            txt_UnitCost.Enabled = true;
            btn_AddtoGrid.Enabled = true;
            btnSave.Enabled = true;
            BTN_CLEAR.Enabled = true;
            dgv_SalesItem.Enabled = true;
        }
        public void Load_order_master(DataTable dtb_orderMaster)
        {
            if (dtb_orderMaster.Rows.Count > 0)
            {
                txt_OrderNo.Text = dtb_orderMaster.Rows[0]["OrderNo"].ToString();
                DTP_OrderDate.Text = dtb_orderMaster.Rows[0]["OrderDate"].ToString();
                txtPatient.Text = dtb_orderMaster.Rows[0]["CustomerName"].ToString();
                txtPatientID.Text = dtb_orderMaster.Rows[0]["Cus_Id"].ToString();
                txt_Street.Text = dtb_orderMaster.Rows[0]["Address1"].ToString();
                txt_Locality.Text = dtb_orderMaster.Rows[0]["adr2"].ToString();
                txt_City.Text = dtb_orderMaster.Rows[0]["adr3"].ToString();
                txt_PhoneNo.Text = dtb_orderMaster.Rows[0]["Phone"].ToString();
            }
        }
        public void Load_orderitems(DataTable dtb_order)
        {
            if (dtb_order.Rows.Count > 0)
            {
                for (int i = 0; i < dtb_order.Rows.Count; i++)
                {  
                    dgv_SalesItem.Rows.Add();
                    //DataTable dtb_hsn = this.cntrl.get_hsn(dtb_order.Rows[i]["Item_Code"].ToString());
                    dgv_SalesItem.Rows[i].Cells["id"].Value = dtb_order.Rows[i]["id"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colItemCode"].Value = dtb_order.Rows[i]["item_code"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colDiscription"].Value = dtb_order.Rows[i]["Discription"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColQty"].Value = dtb_order.Rows[i]["Qty"].ToString();
                    dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value = dtb_order.Rows[i]["Cost"].ToString();
                    dgv_SalesItem.Rows[i].Cells["hsn"].Value = dtb_order.Rows[i]["HSN_Number"].ToString();
                    dgv_SalesItem.Rows[i].Cells["ColPacking"].Value = "";
                    dgv_SalesItem.Rows[i].Cells["ColUnit"].Value = "";
                    dgv_SalesItem.Rows[i].Cells["ColGST"].Value = "0";
                    dgv_SalesItem.Rows[i].Cells["colIGST"].Value = "0";
                    dgv_SalesItem.Rows[i].Cells["ColFree"].Value = "0";
                    dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value = "0.00";
                    dgv_SalesItem.Rows[i].Cells["colAmount"].Value = "0.00";
                    dgv_SalesItem.Rows[i].Cells["colEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    dgv_SalesItem.Rows[i].Cells["colDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (rad_CashSale.Checked == true)
                {
                    Payment_method = "Cash Sale";
                }
                else if (rad_CreditSale.Checked == true)
                {

                    Payment_method = Cmb_ModeOfPaymnt.Text;
                }
                if (string.IsNullOrWhiteSpace(txtPatient.Text))
                {
                    MessageBox.Show("Customer could not be found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPatient.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtBdoctor.Text))
                {
                    MessageBox.Show("Doctor name could not be found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBdoctor.Focus();
                    return;
                }
                if (dgv_SalesItem.Rows.Count == 0)
                {
                    MessageBox.Show("Products not found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_ItemCode.Focus();
                    return;
                }
                if (salesOrder_flag == true)
                {
                    if (Check_OrderItems() != 0)
                    {
                        MessageBox.Show("Products not found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_ItemCode.Focus();
                        return;
                    }
                }
                Cgst = Convert.ToDecimal(txt_CGST.Text);
                Sgst = Convert.ToDecimal(txt_SGST.Text);
                GST = Convert.ToDecimal(Cgst + Sgst);
                int i = 0, j = 0;
                if(Cmb_ModeOfPaymnt.SelectedIndex==0)
                {
                    i = this.cntrl.Save_salesMaster_cheque(Convert.ToInt32(txtDocumentNumber.Text), dtpDocumentDate.Value.ToString("yyyy-MM-dd"), txtSales.Text, txt_OrderNo.Text, DTP_OrderDate.Value.ToString("yyyy-MM-dd"), txtBdoctor.Text, txt_LRNO.Text, DTP_LRDate.Value.ToString("yyyy-MM-dd"), txt_Through.Text, txtPatientID.Text, txtPatient.Text, txt_Street.Text, txt_Locality.Text, txt_City.Text, txt_PhoneNo.Text, Payment_method, txt_BankNAme.Text, txt_Number.Text, Convert.ToDecimal(Txt_TotalAmount.Text), Convert.ToDecimal(txt_Discount.Text), GST, Convert.ToDecimal(Txt_TotalIGST.Text), Convert.ToDecimal(txt_GrandTotal.Text));
                }
                else if(Cmb_ModeOfPaymnt.SelectedIndex==1)
                {
                    i = this.cntrl.Save_salesMaster_card(Convert.ToInt32(txtDocumentNumber.Text), dtpDocumentDate.Value.ToString("yyyy-MM-dd"), txtSales.Text, txt_OrderNo.Text, DTP_OrderDate.Value.ToString("yyyy-MM-dd"), txtBdoctor.Text, txt_LRNO.Text, DTP_LRDate.Value.ToString("yyyy-MM-dd"), txt_Through.Text, txtPatientID.Text, txtPatient.Text, txt_Street.Text, txt_Locality.Text, txt_City.Text, txt_PhoneNo.Text, Payment_method, txt_BankNAme.Text,txt_4Digit.Text, Convert.ToDecimal(Txt_TotalAmount.Text), Convert.ToDecimal(txt_Discount.Text), GST, Convert.ToDecimal(Txt_TotalIGST.Text), Convert.ToDecimal(txt_GrandTotal.Text));
                }
                else if(Cmb_ModeOfPaymnt.SelectedIndex==2)
                {
                    i = this.cntrl.Save_salesMaster_DD(Convert.ToInt32(txtDocumentNumber.Text), dtpDocumentDate.Value.ToString("yyyy-MM-dd"), txtSales.Text, txt_OrderNo.Text, DTP_OrderDate.Value.ToString("yyyy-MM-dd"), txtBdoctor.Text, txt_LRNO.Text, DTP_LRDate.Value.ToString("yyyy-MM-dd"), txt_Through.Text, txtPatientID.Text, txtPatient.Text, txt_Street.Text, txt_Locality.Text, txt_City.Text, txt_PhoneNo.Text, Payment_method, txt_BankNAme.Text, txt_Number.Text,Convert.ToDecimal(Txt_TotalAmount.Text), Convert.ToDecimal(txt_Discount.Text), GST, Convert.ToDecimal(Txt_TotalIGST.Text), Convert.ToDecimal(txt_GrandTotal.Text));
                }
                else
                {
                    i = this.cntrl.Save_salesMaster(Convert.ToInt32(txtDocumentNumber.Text), dtpDocumentDate.Value.ToString("yyyy-MM-dd"), txtSales.Text, txt_OrderNo.Text, DTP_OrderDate.Value.ToString("yyyy-MM-dd"), txtBdoctor.Text, txt_LRNO.Text, DTP_LRDate.Value.ToString("yyyy-MM-dd"), txt_Through.Text, txtPatientID.Text, txtPatient.Text, txt_Street.Text, txt_Locality.Text, txt_City.Text, txt_PhoneNo.Text, Payment_method, Convert.ToDecimal(Txt_TotalAmount.Text), Convert.ToDecimal(txt_Discount.Text), GST, Convert.ToDecimal(Txt_TotalIGST.Text), Convert.ToDecimal(txt_GrandTotal.Text));
                }
                if (i > 0)
                {
                    string unit2;
                    decimal unitMf;
                    if (dgv_SalesItem.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                        {
                            DataTable dt_Unit2 = this.cntrl.get_costbase(dr.Cells["colItemCode"].Value.ToString());
                            if (dt_Unit2.Rows[0]["Unit2"].ToString() != "")
                            {
                                unit2 = "Yes";
                                unitMf = Convert.ToDecimal(dt_Unit2.Rows[0]["UnitMF"].ToString());
                            }
                            else
                            {
                                unit2 = "No";
                                unitMf = 0;
                            }
                            j = this.cntrl.Save_itemdetails(Convert.ToInt32(txtDocumentNumber.Text), dtpDocumentDate.Value.ToString("yyyy-MM-dd"), dr.Cells["id"].Value.ToString(), dr.Cells["colDiscription"].Value.ToString(), dr.Cells["ColPacking"].Value.ToString(), dr.Cells["ColUnit"].Value.ToString(), Convert.ToDecimal(dr.Cells["ColGST"].Value.ToString()), Convert.ToDecimal(dr.Cells["colIGST"].Value.ToString()), Convert.ToInt32(dr.Cells["ColQty"].Value.ToString()), Convert.ToInt32(dr.Cells["ColFree"].Value.ToString()), Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString()), Convert.ToDecimal(dr.Cells["colAmount"].Value.ToString()), unit2, unitMf, Convert.ToDecimal(dt_Unit2.Rows[0]["CostBase"].ToString()));
                        }
                    }
                    if (j > 0)
                    {
                        if (dgv_BatchSale.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow dr in dgv_BatchSale.Rows)
                            {
                                this.cntrl.update_batchnumber(Convert.ToDecimal(dr.Cells["currentStock"].Value.ToString()),
                                    dr.Cells["colBatchEntry"].Value.ToString());
                                this.cntrl.save_batchsale(Convert.ToInt32(dr.Cells["ColinvNum"].Value.ToString()), Convert.ToDateTime(dr.Cells["ColInvDate"].Value.ToString()).ToString("yyyy-MM-dd"), dr.Cells["coiltem_code"].Value.ToString(), dr.Cells["colBatchnumber"].Value.ToString(), Convert.ToDecimal(dr.Cells["colQuantity"].Value.ToString()), dr.Cells["colBatchEntry"].Value.ToString());
                            }
                            if (salesOrder_flag == true)
                            {
                                this.cntrl.update_salesorder(invnum_order);
                            }
                            DialogResult res = MessageBox.Show("Data saved Successfully, Do you want to print...?", "Success",
                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (res == DialogResult.Yes)
                            {
                                printhtml();
                            }
                            else
                            {
                            }
                            clear_All_Data();
                            clear_itemdetails();
                            DocNumber_increment();
                            panl_mode_payment.Visible = false;
                            rad_CreditSale.Checked = false;
                            rad_CashSale.Checked = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insertion failed !....", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Insertion failed !....", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int Check_OrderItems()
        {
            int affect = 0;
            for (int i = 0; i < dgv_SalesItem.Rows.Count; i++)
            {
                for (int j = 0; j < dgv_BatchSale.Rows.Count; j++)
                {
                    if (dgv_SalesItem.Rows[i].Cells["id"].Value.ToString() == dgv_BatchSale.Rows[j].Cells["coiltem_code"].Value.ToString())
                    {
                        affect = 0;
                    }
                    else
                    {
                        affect = 1;
                    }
                }
            }
            return affect;
        }
        private void presgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (presgrid.Rows.Count > 0)
                {
                    clear_itemdetails();
                    string PrescritionMain_id = "0";
                    int r = e.RowIndex; dgrid_prescription.Rows.Clear();
                    PrescritionMain_id = presgrid.Rows[r].Cells[0].Value.ToString();
                    System.Data.DataTable dt_prescriptionDetails = this.cntrl.prescription_main(PrescritionMain_id);
                    if (dt_prescriptionDetails.Rows.Count > 0)
                    {
                        txtBdoctor.Text = dt_prescriptionDetails.Rows[0]["doctor_name"].ToString();
                        txtPatient.Text = dt_prescriptionDetails.Rows[0]["pt_name"].ToString();
                        txtPatientID.Text = dt_prescriptionDetails.Rows[0]["pt_id"].ToString();
                        System.Data.DataTable dt_drugDetails = this.cntrl.prescription_dteails(PrescritionMain_id);
                        if (dt_drugDetails.Rows.Count > 0)
                        {
                            int i = 0; dgrid_prescription.Rows.Clear();
                            pnlprescription.Visible = true;
                            for (int j = 0; j < dt_drugDetails.Rows.Count; j++)
                            {
                                dgrid_prescription.Rows.Add(dt_drugDetails.Rows[j]["drug_name"].ToString() + " " + dt_drugDetails.Rows[j]["strength"].ToString(), dt_drugDetails.Rows[j]["duration_unit"].ToString() + " " + dt_drugDetails.Rows[j]["duration_period"].ToString(), dt_drugDetails.Rows[j]["morning"].ToString() + "-" + dt_drugDetails.Rows[j]["noon"].ToString() + "-" + dt_drugDetails.Rows[j]["night"].ToString(), dt_drugDetails.Rows[j]["add_instruction"].ToString());
                                decimal duration_unit = 0;
                                decimal duration = 0;
                                decimal drug_qty = 0;
                                int drug_qty1 = 0;
                                duration_unit = Convert.ToDecimal(dt_drugDetails.Rows[j]["duration_unit"].ToString());
                                drug_qty = Convert.ToDecimal(dt_drugDetails.Rows[j]["morning"].ToString()) + Convert.ToDecimal(dt_drugDetails.Rows[j]["noon"].ToString()) + Convert.ToDecimal(dt_drugDetails.Rows[j]["night"].ToString());
                                if (duration_unit > 0 && drug_qty > 0)
                                { 
                                    if (dt_drugDetails.Rows[j]["duration_period"].ToString() == "year(s)")
                                    { duration = duration_unit * 365; }
                                    else if (dt_drugDetails.Rows[j]["duration_period"].ToString() == "month(s)")
                                    { duration = duration_unit * 30; }
                                    else if (dt_drugDetails.Rows[j]["duration_period"].ToString() == "week(s)")
                                    { duration = duration_unit * 7; }
                                    else
                                    { duration = duration_unit; }
                                    drug_qty1 = Convert.ToInt16(drug_qty);
                                    txt_Qty.Text = Convert.ToString(duration * drug_qty1).ToString();
                                    double Org_Qty = Convert.ToDouble(duration * drug_qty1);
                                    double decPart = Convert.ToDouble(Org_Qty) - Math.Truncate(Org_Qty);
                                    if (decPart > 0)
                                    {
                                        Org_Qty = Org_Qty + .5;
                                        txt_Qty.Text = Convert.ToString(Org_Qty).ToString();
                                    }
                                    System.Data.DataTable dt_drug_inv_Details = this.cntrl.get_inventoryid(dt_drugDetails.Rows[j]["drug_id"].ToString());
                                    if (dt_drug_inv_Details.Rows.Count > 0)
                                    {
                                        DataTable dtb = this.cntrl.Get_itemdetails(dt_drug_inv_Details.Rows[0]["inventory_id"].ToString());
                                        if (dtb.Rows.Count > 0)
                                        {
                                            itemId = dt_drug_inv_Details.Rows[0]["inventory_id"].ToString();
                                            txt_ItemCode.Text = dtb.Rows[0]["id"].ToString();
                                            txt_Discription.Text = dtb.Rows[0]["item_name"].ToString();
                                            txt_UnitCost.Text = dtb.Rows[0]["Sales_Rate_Max"].ToString();
                                            txt_GST.Text = dtb.Rows[0]["GST"].ToString();
                                            txt_IGST.Text = dtb.Rows[0]["IGST"].ToString();
                                            cmb_Unit.Items.Clear();
                                            if (dtb.Rows[0]["OneUnitOnly"].ToString() == "True")
                                            {
                                                cmb_Unit.Items.Add(dtb.Rows[0]["Unit1"].ToString());
                                            }
                                            else
                                            {
                                                cmb_Unit.Items.Add(dtb.Rows[0]["Unit2"].ToString());
                                                cmb_Unit.Items.Add(dtb.Rows[0]["Unit1"].ToString());
                                            }
                                            cmb_Unit.SelectedIndex = 0;
                                            decimal qty = 0;
                                            qty = Convert.ToDecimal(txt_Qty.Text);
                                            string unit = cmb_Unit.Text;
                                            call_Item_Batch(dtb.Rows[0]["id"].ToString(), qty, unit);
                                            if (dtFor_CurrentStockUpdate_Bill != null)
                                            {
                                                Fiil_BatchSale_Grid_Prescription_bill();
                                                TotalAmount_Calculation();
                                                dgv_SalesItem.Rows.Add(txt_ItemCode.Text, dtb.Rows[0]["item_code"].ToString(), txt_Discription.Text, txt_Packing.Text, cmb_Unit.Text, txt_GST.Text, txt_IGST.Text, txt_Qty.Text, txt_Free.Text, txt_UnitCost.Text, txt_Amount.Text, PappyjoeMVC.Properties.Resources.editicon, PappyjoeMVC.Properties.Resources.deleteicon);
                                                clear_itemdetails();
                                                Decimal TotalGst = 0;
                                                Decimal Total_Igst = 0; 
                                                int Totalqty = 0;
                                                Decimal TotalAmount = 0;
                                                Decimal TotalCost = 0; decimal gstAmount = 0; decimal igstAmount = 0;
                                                foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                                                {
                                                    if (dr.Cells["ColGST"].Value != null && dr.Cells["ColGST"].Value.ToString() != "")
                                                    {
                                                        gstAmount = ((Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString())) * Convert.ToDecimal(dr.Cells["ColGST"].Value.ToString())) / 100;
                                                        TotalGst = TotalGst + gstAmount;
                                                    }
                                                    if (dr.Cells["colIGST"].Value != null && dr.Cells["colIGST"].Value.ToString() != "")
                                                    {
                                                        igstAmount = ((Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString())) * Convert.ToDecimal(dr.Cells["colIGST"].Value.ToString())) / 100;
                                                        Total_Igst = Total_Igst + igstAmount;
                                                    }
                                                    if (dr.Cells["colAmount"].Value != null && dr.Cells["colAmount"].Value.ToString() != "")
                                                    {
                                                        TotalAmount = TotalAmount + Convert.ToDecimal(dr.Cells["colAmount"].Value.ToString());
                                                    }
                                                    if (dr.Cells["colUnitcost"].Value != null && dr.Cells["colUnitcost"].Value.ToString() != "")
                                                    {
                                                        TotalCost = TotalCost + (Convert.ToDecimal(dr.Cells["ColQty"].Value.ToString()) * Convert.ToDecimal(dr.Cells["colUnitcost"].Value.ToString()));
                                                    }
                                                }
                                                Totalqty = dgv_SalesItem.Rows.Count;
                                                if (Totalqty >0)
                                                {
                                                    txt_totalItems.Text = Totalqty.ToString();
                                                }
                                                if (TotalGst >0)
                                                {
                                                    decimal cgst = TotalGst / 2;
                                                    txt_SGST.Text = Convert.ToDecimal(cgst).ToString("##0.00");
                                                    txt_CGST.Text = Convert.ToDecimal(cgst).ToString("##0.00");
                                                }
                                                if (Total_Igst >0)
                                                {
                                                    Txt_TotalIGST.Text = Convert.ToDecimal(Total_Igst).ToString("##0.00");
                                                }
                                                if (TotalAmount >0)
                                                {
                                                    Txt_TotalAmount.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
                                                    txt_GrandTotal.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
                                                }
                                                if (TotalCost >0)
                                                {
                                                    txt_TotalCost.Text = Convert.ToDecimal(TotalCost).ToString("##0.00");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You can't add Duplicate Entry (" + ex.Message + ")", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DocNumber_increment()
        {
            DataTable Document_Number = this.cntrl.docnumber();
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
        public void printhtml()
        {
            try
            {
                string strclinicname = "", strphone = "", DlNumber = "", DlNumber2 = "", website = "";
                decimal totalamount = 0;
                string str_druglicenseno = "";
                string str_taxno = "";
                System.Data.DataTable dtp = this.cntrl.Get_companydetails();
                if (dtp.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = dtp.Rows[0]["name"].ToString();
                    strclinicname = clinicn.Replace("¤", "'");
                    strphone = dtp.Rows[0]["contact_no"].ToString();
                    DlNumber = dtp.Rows[0]["street_address"].ToString();
                    DlNumber2 = dtp.Rows[0]["email"].ToString();
                    website = dtp.Rows[0]["website"].ToString();
                    str_druglicenseno = dtp.Rows[0]["Dl_Number"].ToString();
                    str_taxno = dtp.Rows[0]["Dl_Number2"].ToString();
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\salesbill.html");
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
                sWrite.WriteLine("<th colspan=9><center><br><br><FONT COLOR=black FACE='Segoe UI'  SIZE=5> SALES INVOICE </font></center></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI'  SIZE=4>  <b> " + strclinicname + "</b> </font></left></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + strphone + " </b> </font></left></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + DlNumber + "</b> </font></left></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b>" + DlNumber2 + "</b> </font></left></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI'   SIZE=2><b>" + website + " </b> </font></left></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine("<tr><td colspan=9 align='left'><hr/></td></tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=8 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>Drug License:" + str_druglicenseno + "</font></left></td>");
                sWrite.WriteLine("<td colspan=8 align='right'>  <FONT COLOR=black FACE='Segoe UI'   SIZE=2>Tax No:&nbsp;" + str_taxno + " &nbsp;</font></right></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=8 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> Sold To : &nbsp" + txtPatient.Text + "</font></left></td>");
                sWrite.WriteLine("<td colspan=8 align='right'><FONT COLOR=black FACE='Segoe UI'   SIZE=2>Invoice No:&nbsp;" + txtDocumentNumber.Text + "&nbsp; </font></right></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=8 align='left'><FONT COLOR=black FACE='Segoe UI'   SIZE=2> Prescribed by : &nbspDr." + txtBdoctor.Text + "</font></left></td>");
                sWrite.WriteLine("<td colspan=8 align='right'><FONT COLOR=black FACE='Segoe UI'   SIZE=2> Date :&nbsp; " + DateTime.Now.ToString("MM-dd-yyyy") + "&nbsp; </font></right></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr><td colspan=9><hr/></td></tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'  width='62'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Sl.</b></font></td>");
                sWrite.WriteLine("<td align='left'  width='128'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Item Code</b></font></td>");
                sWrite.WriteLine("<td align='left'  width='190'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Description</b></font></td>");
                sWrite.WriteLine("<td align='left'  width='153'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Batch/Expiry</b></font></td>");
                sWrite.WriteLine("<td align='right'  width='61' ><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>HSN Number</b></font></td>");
                sWrite.WriteLine("<td align='right'  width='61' ><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Unit</b></font></td>");
                sWrite.WriteLine("<td align='right'  width='70'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Quantity</b></font></td>");
                sWrite.WriteLine("<td align='right'  width='93'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Cost</b></font></td>");
                sWrite.WriteLine("<td align='right'  width='107'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Total Amount</b></font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr><td align='left' colspan=9><hr/></td></tr>");
                string removecomma = "";
                int k = 1;
                for (int i = 0; i < dgv_SalesItem.Rows.Count; i++)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + k + "</font></td>");
                    sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["colItemCode"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["colDiscription"].Value.ToString() + "</font></td>");
                    string strBatch = "";
                    for (int ii = 0; ii < dgv_BatchSale.Rows.Count; ii++)
                    {
                        if (dgv_BatchSale.Rows[ii].Cells["coiltem_code"].Value.ToString() == dgv_SalesItem.Rows[i].Cells["colItemCode"].Value.ToString())
                        {
                            if (dgv_BatchSale.Rows[ii].Cells["expdate"].Value != null && dgv_BatchSale.Rows[ii].Cells["expdate"].Value.ToString() != "")
                            {
                                strBatch = strBatch + dgv_BatchSale.Rows[ii].Cells["colBatchnumber"].Value.ToString() + "/" + dgv_BatchSale.Rows[ii].Cells["expdate"].Value.ToString() + ",";
                            }
                            else
                            {
                                strBatch = strBatch + dgv_BatchSale.Rows[ii].Cells["colBatchnumber"].Value.ToString() + ",";
                            }
                        }
                    }
                    if (strBatch != "")
                        removecomma = strBatch.Remove(strBatch.Length - 1);
                    sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + removecomma + "</font></td>");
                    sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["hsn"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["ColUnit"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["ColQty"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value.ToString()).ToString("##0.00") + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colAmount"].Value.ToString()).ToString("##0.00") + "</font></td>");
                    totalamount = totalamount + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colAmount"].Value.ToString());
                    k = k + 1;
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr><td align='left'  colspan=9><hr/></td></tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Items :</font></td>");
                sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp " + txt_totalItems.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
                if (txt_CGST.Text != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> CGST :</font></td>");
                    sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp" + txt_CGST.Text + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> SGST :  </font></td>");
                    sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp " + txt_SGST.Text + " </font></td>");
                    sWrite.WriteLine("</tr>");
                }
                else if (Txt_TotalIGST.Text != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total IGST :</font></td>");
                    sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Txt_TotalIGST.Text + " </font></td>");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=5 rowspan=3><FONT COLOR=black FACE='Segoe UI' SIZE=2> ");
                if (txt_CGST.Text != "")
                {
                    sWrite.WriteLine("   <table align=right width=307 border=1>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=2><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1><b> CGST </b></font></center></td>");
                    sWrite.WriteLine("<td  colspan=2><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1><b> SGST</b> </font></center></td>");
                    sWrite.WriteLine("<td  colspan=2><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1><b> IGST </b></font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr> <b>");
                    sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> Rate% </font></center></td>");
                    sWrite.WriteLine("	<td  ><center> <FONT COLOR=black FACE='Segoe UI'  SIZE=1> Amt </font></center></td>");
                    sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> Rate% </font></center></td>");
                    sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> Amt </font></center></td>");
                    sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> Rate% </font></center></td>");
                    sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> Amt </font></center></td>");
                    sWrite.WriteLine("	</b>");
                    sWrite.WriteLine("</tr>");
                    double gstRatetotal = 0;
                    double gesttotal = 0;
                    for (int ii = 0; ii < dgv_SalesItem.Rows.Count; ii++)
                    {
                        if (Convert.ToDouble(dgv_SalesItem.Rows[ii].Cells["ColGST"].Value.ToString()) > 0)
                        {
                            gstRatetotal = Convert.ToDouble(dgv_SalesItem.Rows[ii].Cells["colUnitcost"].Value.ToString()) * Convert.ToDouble(dgv_SalesItem.Rows[ii].Cells["ColQty"].Value.ToString());
                            gesttotal = ((Convert.ToDouble(gstRatetotal) * Convert.ToDouble(dgv_SalesItem.Rows[ii].Cells["ColGST"].Value.ToString())) / 100) / 2;
                            sWrite.WriteLine("<tr> <b>");
                            sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1>" + Convert.ToDouble(dgv_SalesItem.Rows[ii].Cells["ColGST"].Value.ToString()) / 2 + "</font></center></td>");
                            sWrite.WriteLine("	<td  ><center> <FONT COLOR=black FACE='Segoe UI'  SIZE=1>" + gesttotal + " </font></center></td>");
                            sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> " + Convert.ToDouble(dgv_SalesItem.Rows[ii].Cells["ColGST"].Value.ToString()) / 2 + " </font></center></td>");
                            sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1>" + gesttotal + " </font></center></td>");
                            sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> </font></center></td>");
                            sWrite.WriteLine("	<td  ><center><FONT COLOR=black FACE='Segoe UI'  SIZE=1> </font></center></td>");
                            sWrite.WriteLine("	</b>");
                            sWrite.WriteLine("</tr>");
                        }
                    }
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("</td>");
                sWrite.WriteLine("<td align='right'  colspan=2 ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Total Amount :  </font></td>");
                sWrite.WriteLine("<td align='right'   ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + String.Format("{0:C}", decimal.Parse(Txt_TotalAmount.Text)) + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=2 ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Discount :</font></td>");
                sWrite.WriteLine("<td align='right'   ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + txt_Discount.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=2 ><FONT COLOR=black FACE='Segoe UI' 2><b>Grand Total :</b> </font></td>");
                sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>&nbsp " + String.Format("{0:C}", decimal.Parse(txt_GrandTotal.Text)) + "</b> </font></td>");
                sWrite.WriteLine(" <div class='footer'>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr><td align='left' colspan=9 > <FONT COLOR=black FACE='Segoe UI' SIZE=2>Pharmacist Signature</font></td></tr>");
                sWrite.WriteLine("<tr><td align='left'  colspan=9><hr/></td></tr>");
                sWrite.WriteLine("<tr><td align='left' colspan=9 > <FONT COLOR=black FACE='Segoe UI' SIZE=1><i>Goods once sold cannot be taken back or exchanged</i></font></td></tr>");
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<tr><td align='left' colspan=9 > <FONT COLOR=black FACE='Segoe UI' SIZE=2>E&OE</font></td></tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body >");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\salesbill.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printer not ready...." + ex.Message, "Printer error.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if (txtPatient.Text != "")
            {
                string id = txtPatientID.Text;
             DataTable dtb= this.cntrl.patients(id);
                fill_patientdetails(dtb);
            }
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to print?", "Question ?",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                printhtml();
            }
        }
        private void BTN_CLEAR_Click(object sender, EventArgs e)
        {
            clear_itemdetails();
            clear_All_Data();
        }
        private void txt_Discount_TextAlignChanged(object sender, EventArgs e)
        {
        }
        private void txt_Discount_Leave(object sender, EventArgs e)
        {
            if (txt_Discount.Text == "")
            {
                txt_Discount.Text = "0";
            }
        }
        private void txt_Discount_Click(object sender, EventArgs e)
        {
            if (txt_Discount.Text == "0")
            {
                txt_Discount.Text = "";
            }
        }
        private void txt_Discount_KeyUp(object sender, KeyEventArgs e)
        {
            decimal totaldis = 0, totalamount = 0, totaldisper = 0;
            decimal d;
            if (decimal.TryParse(txt_DiscAmount.Text, out d))
            {
                if (decimal.TryParse(txt_Discount.Text, out d))
                {
                    totalamount = Convert.ToDecimal(Txt_TotalAmount.Text);
                    totaldisper = Convert.ToDecimal(txt_Discount.Text);
                    totaldis = Convert.ToDecimal((totalamount * totaldisper) / 100);
                    txt_DiscAmount.Text = Convert.ToDecimal(totaldis).ToString("##.00");
                    txt_GrandTotal.Text = Convert.ToDecimal(Convert.ToDecimal(Txt_TotalAmount.Text) - Convert.ToDecimal(totaldis)).ToString("##.00");
                }
                else
                {
                    txt_DiscAmount.Text = "00.00";
                    txt_GrandTotal.Text = Txt_TotalAmount.Text;
                }
            }
        }

        private void rad_CashSale_CheckedChanged(object sender, EventArgs e)
        {
            if(rad_CashSale.Checked==true)
            {
                rad_CreditSale.Checked = false;
                panl_mode_payment.Visible = false;
            }
           
        }

        private void rad_CreditSale_CheckedChanged(object sender, EventArgs e)
        {
            //rad_CreditSale.Checked = true;
            if(rad_CreditSale.Checked==true)
            {
                rad_CashSale.Checked = false;
                panl_mode_payment.Visible = true;
            }
        }

        private void Cmb_ModeOfPaymnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_ModeOfPaymnt.SelectedIndex == 0)
            {
                payment_show(true, true, true, true, false, false, false);
            }
            else if (Cmb_ModeOfPaymnt.SelectedIndex == 1)
            {
                payment_show(true, false, false, false, true, true, true);
            }
            else if (Cmb_ModeOfPaymnt.SelectedIndex == 2)
            {
                payment_show(true, true, true, true, false, false, false);
            }
            else
            { payment_show(false, false, false, false, false, false, false); }
        }
        public void payment_show(Boolean BankName, Boolean Number, Boolean bank, Boolean lab_number, Boolean last4digit, Boolean cardno, Boolean t4digit)
        {
                txt_BankNAme.Visible = BankName;
                txt_Number.Visible = Number;
                Bank.Visible = bank;
                Lab_Numbr.Visible = lab_number;
                Lab_Last4Digit.Visible = last4digit;
                Lab_CardNo.Visible = cardno;
                txt_4Digit.Visible = t4digit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_4Digit.Text = "";
            txt_BankNAme.Text = "";
            txt_Number.Text = "";
            panl_mode_payment.Visible = false;
            rad_CreditSale.Checked = false;
            rad_CashSale.Checked = true;
        }

        public void call_Item_Batch(string item_Code, decimal qty, string unit)
        {
            dtFor_CurrentStockUpdate_Bill.Columns.Clear();
            dtFor_CurrentStockUpdate_Bill.Rows.Clear();
            decimal Stock = 0;
            decimal curent_Stock = 0;
            TotalStock = 0;
            DataTable Dt_updateStock = this.cntrl.Get_stock(item_Code);
            if (Dt_updateStock.Rows[0][0].ToString() != "")
            {
                TotalStock = Convert.ToDecimal(Dt_updateStock.Rows[0][0].ToString());
            }
            Stock = qty;
            decimal Remaning_qty = 0;
            decimal stk_value = 0;
            Remaning_qty = qty;
            if (Stock <= TotalStock)
            {
                DataTable dtb = this.cntrl.get_batchdetails(item_Code);
                if (dtb.Rows.Count > 0)
                {
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("colentryNo");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("colbatchNo");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("ColStock");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("ColPrd_Date");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("colExpDate");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("clUnit");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("ColQty");
                    dtFor_CurrentStockUpdate_Bill.Columns.Add("colCurrentStock");
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        if (Remaning_qty <= Convert.ToDecimal(dtb.Rows[i]["Qty"].ToString()))
                        {
                            DataRow dRow = dtFor_CurrentStockUpdate_Bill.NewRow();
                            dRow[0] = dtb.Rows[i]["Entry_No"].ToString();
                            dRow[1] = dtb.Rows[i]["BatchNumber"].ToString();
                            dRow[2] = dtb.Rows[i]["Qty"].ToString();
                            dRow[3] = dtb.Rows[i]["PrdDate"].ToString();
                            dRow[4] = dtb.Rows[i]["ExpDate"].ToString();
                            dRow[5] = unit;
                            dRow[6] = Remaning_qty.ToString(); 
                            curent_Stock = Convert.ToDecimal(dtb.Rows[i]["Qty"].ToString()) - Convert.ToDecimal(Remaning_qty);
                            dRow[7] = curent_Stock.ToString();
                            dtFor_CurrentStockUpdate_Bill.Rows.Add(dRow);
                            break;
                        }
                        else
                        {
                            stk_value = Convert.ToDecimal(dtb.Rows[i]["Qty"].ToString());
                            DataRow dRow = dtFor_CurrentStockUpdate_Bill.NewRow();
                            dRow[0] = dtb.Rows[i]["Entry_No"].ToString();
                            dRow[1] = dtb.Rows[i]["BatchNumber"].ToString();
                            dRow[2] = dtb.Rows[i]["Qty"].ToString();
                            dRow[3] = dtb.Rows[i]["PrdDate"].ToString();
                            dRow[4] = dtb.Rows[i]["ExpDate"].ToString();
                            dRow[5] = unit;
                            dRow[6] = stk_value;
                            curent_Stock = Convert.ToDecimal(dtb.Rows[i]["Qty"].ToString()) - Convert.ToDecimal(stk_value);
                            dRow[7] = curent_Stock.ToString();
                            Remaning_qty = Remaning_qty - stk_value;
                        }
                    }
                }
            }
        }
        public void Fiil_BatchSale_Grid_Prescription_bill()
        {
            int row = dgv_BatchSale.Rows.Count;
            if (dtFor_CurrentStockUpdate_Bill.Rows.Count > 0)
            {
                foreach (DataRow dr in dtFor_CurrentStockUpdate_Bill.Rows)
                {
                    if (dr["ColQty"].ToString() != "")
                    {
                        dgv_BatchSale.Rows.Add();
                        dgv_BatchSale.Rows[row].Cells["ColinvNum"].Value = txtDocumentNumber.Text;
                        dgv_BatchSale.Rows[row].Cells["ColInvDate"].Value = dtpDocumentDate.Value.ToShortDateString();
                        dgv_BatchSale.Rows[row].Cells["coiltem_code"].Value = txt_ItemCode.Text;
                        dgv_BatchSale.Rows[row].Cells["colBatchnumber"].Value = dr["colbatchNo"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colQuantity"].Value = dr["ColQty"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colStock"].Value = dr["ColStock"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colBatchEntry"].Value = dr["colentryNo"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colIsExp"].Value = txt_Qty.Text;
                        dgv_BatchSale.Rows[row].Cells["prddate"].Value = dr["ColPrd_Date"].ToString();
                        dgv_BatchSale.Rows[row].Cells["expdate"].Value = dr["colExpDate"].ToString();
                        dgv_BatchSale.Rows[row].Cells["unit"].Value = dr["clUnit"].ToString();
                        if (dr["colCurrentStock"].ToString() != "")
                        {
                            dgv_BatchSale.Rows[row].Cells["currentStock"].Value = dr["colCurrentStock"].ToString();
                        }
                        else
                            dgv_BatchSale.Rows[row].Cells["currentStock"].Value = dr["ColStock"].ToString();
                    }
                    row++;
                }
            }
        }
    }
}
