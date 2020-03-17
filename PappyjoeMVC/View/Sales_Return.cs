using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Sales_Return : Form
    {
        bool flagSup = false;
        Sales_Return_Controller cntrl = new Sales_Return_Controller();
        public static DataTable dtFor_QtyReturn;
        public decimal qty_ = 0; public static int Ret_Numbr;
        public bool PrintFlag = false;
        public static string ItemCode_From_List; public string doctor_id = "0"; public static bool flagset = false;
        public Sales_Return()
        {
            InitializeComponent();
        }
        public Sales_Return(int Ret_no)
        {
            InitializeComponent();
            Ret_Numbr = Ret_no;
            PrintFlag = true;
        }
        public Sales_Return(DataTable dtb)
        {
            InitializeComponent();
            dtFor_QtyReturn = dtb;
            flagset = true;
        }
        public Sales_Return(string itemcode)
        {
            ItemCode_From_List = itemcode;
        }

        private void txt_InvoiceNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (flagSup == false)
            {
                if (txt_InvoiceNum.Text != "")
                {
                    DataTable dtdr = this.cntrl.get_all_invnumbr(txt_InvoiceNum.Text);
                    lstInvNo.DisplayMember = "InvNumber";
                    lstInvNo.ValueMember = "InvNumber";
                    lstInvNo.DataSource = dtdr;
                    if (e.KeyCode == Keys.Enter && lstInvNo.Items.Count > 0)
                    {
                        var value = lstInvNo.GetItemText(lstInvNo.SelectedValue);
                        System.Data.DataTable inv = this.cntrl.get_all_invnumbr(value);
                        if (inv.Rows.Count > 0)
                        {
                            txt_InvoiceNum.Text = inv.Rows[0]["InvNumber"].ToString();
                        }
                        lstInvNo.Visible = false;
                        txt_InvoiceNum.Focus();
                    }
                    else if (e.KeyCode == Keys.Down && lstInvNo.Items.Count > 0)
                    {
                        lstInvNo.Focus();
                    }
                    else if (lstInvNo.Items.Count > 0)
                    {
                        lstInvNo.Visible = true;
                        lstInvNo.Location = new Point(137, 32);
                    }
                    else
                    {
                        lstInvNo.Visible = false;
                    }
                }
                else
                {
                    lstInvNo.Visible = false;
                }
            }
            flagSup = false;
        }
        private void lstInvNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flagSup = true;
                string value = lstInvNo.SelectedValue.ToString();
                DataTable supplier = this.cntrl.get_all_invnumbr(value);
                txt_InvoiceNum.Text = supplier.Rows[0]["InvNumber"].ToString();
                lstInvNo.Hide();
            }
            else if (e.KeyCode == Keys.Up)
            {
                lstInvNo.Focus();
                int indicee = lstInvNo.SelectedIndex;
                indicee++;
            }
            else if (e.KeyCode == Keys.Down)
            {
                lstInvNo.Focus();
                int indicee = lstInvNo.SelectedIndex;
                indicee++;
            }
        }
        private void lstInvNo_MouseClick(object sender, MouseEventArgs e)
        {
            if (lstInvNo.SelectedItems.Count > 0)
            {
                string value = lstInvNo.SelectedValue.ToString();
                if (value != "")
                {
                    txt_InvoiceNum.Text = value;
                    dgv_BatchSale.Rows.Clear();
                    dgv_SalesItem.Rows.Clear();
                    DataTable dtb_Master = this.cntrl.get_master_sales_details(value);
                    if (dtb_Master.Rows.Count > 0)
                    {
                        dtp_invDate.Text = dtb_Master.Rows[0]["InvDate"].ToString();
                        txtSales.Text = dtb_Master.Rows[0]["SalesmanCode"].ToString();
                        txtBdoctor.Text = dtb_Master.Rows[0]["Prescribedby"].ToString();
                        txt_LRNO.Text = dtb_Master.Rows[0]["LRNo"].ToString();
                        DTP_LRDate.Text = dtb_Master.Rows[0]["LRDate"].ToString();
                        txt_OrderNo.Text = dtb_Master.Rows[0]["OrderNumber"].ToString();
                        DTP_OrderDate.Text = dtb_Master.Rows[0]["Orderdate"].ToString();
                        txt_Through.Text = dtb_Master.Rows[0]["Through"].ToString();
                        txt_patient.Text = dtb_Master.Rows[0]["cust_name"].ToString();
                        txtPatientID.Text = dtb_Master.Rows[0]["cust_number"].ToString();
                        txt_Street.Text = dtb_Master.Rows[0]["adr1"].ToString();
                        txt_Locality.Text = dtb_Master.Rows[0]["adr2"].ToString();
                        txt_City.Text = dtb_Master.Rows[0]["adr3"].ToString();
                        txt_PhoneNo.Text = dtb_Master.Rows[0]["phone1"].ToString();
                    }
                    lstInvNo.Visible = false;
                }
            }
        }
        private void btn_item_Choose_Click(object sender, EventArgs e)
        {
            if (txt_InvoiceNum.Text != "")
            {
                cmb_Unit.Items.Clear(); string unit1 = "", unit2 = "";
                DataTable dtb_itemlist = this.cntrl.itemdetails_from_salesit(txt_InvoiceNum.Text);
                if (dtb_itemlist.Rows.Count > 0)
                {
                    var form2 = new Sales_Return_Itemlist(dtb_itemlist, txt_InvoiceNum.Text);
                    form2.ShowDialog();
                    form2.Dispose();
                    if (ItemCode_From_List != "")
                    {
                        DataTable dtb_units = this.cntrl.itemdetails_from_items(ItemCode_From_List);
                        txt_ItemCode.Text = dtb_units.Rows[0]["Item_Code"].ToString();
                        if (dtb_units.Rows.Count > 0)
                        {
                            unit1 = dtb_units.Rows[0]["Unit1"].ToString();
                            if (unit1 != "")
                            {
                                cmb_Unit.Items.Add(unit1);
                            }
                            if (dtb_units.Rows[0]["Unit2"].ToString() != "null" && dtb_units.Rows[0]["Unit2"].ToString() != "")
                            {
                                unit2 = dtb_units.Rows[0]["Unit2"].ToString();
                                cmb_Unit.Items.Add(unit2);
                            }
                            cmb_Unit.SelectedIndex = 0;
                        }
                        if (itemcheck() == 0)
                        {
                            DataTable dtb = this.cntrl.get_sales_items_details(txt_InvoiceNum.Text, ItemCode_From_List);
                            string dt_maxRetNum = this.cntrl.get_maxRetnumber(txt_InvoiceNum.Text, ItemCode_From_List);
                            string dtb_Return = this.cntrl.get_totalqty(txt_InvoiceNum.Text, ItemCode_From_List);
                            string dt_retUnit = "";
                            if (dt_maxRetNum != "0" && dt_maxRetNum != "")
                            {
                                dt_retUnit = this.cntrl.ubit2_from_retit(ItemCode_From_List, dt_maxRetNum);
                            }
                            if (dtb.Rows.Count > 0)
                            {
                                txt_Discription.Text = dtb.Rows[0]["Description"].ToString();
                                txt_Packing.Text = dtb.Rows[0]["Packing"].ToString();
                                cmb_Unit.Text = dtb.Rows[0]["Unit"].ToString();
                                if (dtb.Rows[0]["GST"].ToString() != "")
                                {
                                    txt_GST.Text = dtb.Rows[0]["GST"].ToString();
                                }
                                else
                                {
                                    txt_GST.Text = "0";
                                }
                                if (dtb.Rows[0]["IGST"].ToString() != "")
                                {
                                    txt_IGST.Text = dtb.Rows[0]["IGST"].ToString();
                                }
                                else
                                {
                                    txt_IGST.Text = "0";
                                }
                                if (dtb_Return != "0" && dtb_Return != "")
                                {
                                    decimal qt1 = 0, rqt1 = 0, newqty = 0;
                                    string value = ""; int quotient = 0, Remainder = 0, unitmf = 0;
                                    if (Convert.ToDecimal(dtb_Return) > 0)
                                    {
                                        if (Convert.ToDecimal(dtb.Rows[0]["UnitMF"].ToString()) != 0)
                                        {
                                            unitmf = Convert.ToInt32(dtb.Rows[0]["UnitMF"].ToString());
                                            if (dt_retUnit.Trim() == "Yes")
                                            {
                                                qt1 = Convert.ToDecimal(dtb.Rows[0]["Qty"].ToString()) * unitmf;
                                                rqt1 = qt1 - Convert.ToDecimal(dtb.Rows[0]["RetQty"].ToString());
                                                value = Convert.ToDecimal(rqt1).ToString("#00");
                                                quotient = Convert.ToInt32(Convert.ToInt32(value) / unitmf);
                                                Remainder = Convert.ToInt32(Convert.ToInt32(value) % unitmf);
                                            }
                                            else
                                            {
                                                qt1 = Convert.ToDecimal(dtb.Rows[0]["Qty"].ToString()) * Convert.ToDecimal(dtb.Rows[0]["UnitMF"].ToString());
                                                rqt1 = Convert.ToDecimal(dtb.Rows[0]["RetQty"].ToString());
                                                newqty = qt1 - rqt1;
                                                value = Convert.ToDecimal(newqty).ToString("#00");
                                                quotient = Convert.ToInt32(Convert.ToInt32(value) / unitmf);
                                                Remainder = Convert.ToInt32(Convert.ToInt32(value) % unitmf);
                                                txt_Qty.Text = quotient + "." + Remainder;
                                            }
                                        }
                                        else
                                        {
                                            txt_Qty.Text = Convert.ToInt32(Convert.ToDecimal(dtb.Rows[0]["Qty"].ToString()) - Convert.ToDecimal(dtb_Return)).ToString();
                                            qty_ = Convert.ToDecimal(txt_Qty.Text);
                                        }
                                        if (Convert.ToDecimal(txt_Qty.Text) <= 0)
                                        {
                                            clear_itemdetails();
                                            MessageBox.Show("Youn already returned complete quantity of this item  !!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    txt_Qty.Text = dtb.Rows[0]["Qty"].ToString();
                                    qty_ = Convert.ToInt32(dtb.Rows[0]["Qty"].ToString());
                                }
                                if (dtb.Rows[0]["FreeQty"].ToString() != "")
                                {
                                    txt_Free.Text = dtb.Rows[0]["FreeQty"].ToString();
                                }
                                txt_UnitCost.Text = Convert.ToDecimal(dtb.Rows[0]["Rate"].ToString()).ToString("##.00");
                                txt_Amount.Text = Convert.ToDecimal(dtb.Rows[0]["TotalAmount"].ToString()).ToString("##.00");
                            }
                        }
                        else
                        {
                            txt_ItemCode.Text = "";
                            txt_ItemCode.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalied invoice number!..", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please choose the invoice number first!..", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public int itemcheck()
        {
            int affected = 0;
            for (int i = 0; i < dgv_SalesItem.Rows.Count; i++)
            {
                if (dgv_SalesItem.Rows[i].Cells["colItemCode"].Value != null && txt_ItemCode.Text.Trim() == dgv_SalesItem.Rows[i].Cells["colItemCode"].Value.ToString().Trim())
                {
                    MessageBox.Show("The value already existed in DataGridView..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    affected = 1;
                }
            }
            return affected;
        }
        public void clear_itemdetails()
        {
            txt_ItemCode.Text = "";
            txt_Discription.Text = "";
            txt_Packing.Text = "";
            cmb_Unit.Text = "";
            txt_GST.Text = "0";
            txt_IGST.Text = "0";
            txt_Qty.Text = "0";
            txt_Free.Text = "0";
            txt_UnitCost.Text = "0.00";
            txt_Amount.Text = "0.00";
        }

        private void cmb_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Unit.SelectedIndex >= 0)
            {
                TotalAmount_Calculation();
            }
        }
        private void txt_GST_TextChanged(object sender, EventArgs e)
        {
            if (txt_GST.Text != "")
            {
                if (Convert.ToDecimal(txt_GST.Text) > 0)
                {
                    txt_IGST.Text = "0";
                }
                else
                {
                    txt_GST.Text = "0";
                }
            }
        }
        public void TotalAmount_Calculation()
        {
            Decimal gst = 0, unitMf = 0, igst = 0, gst_Amount = 0, Amount = 0, igst_Amount = 0, qty = 0, unitcost = 0, TotalAmount = 0;
            decimal d;
            DataTable dtb = this.cntrl.get_details_from_items(ItemCode_From_List);
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
        private void txt_Qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_UnitCost.Text != "")
            {
                TotalAmount_Calculation();
            }
        }
        private void txt_Qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Qty_Leave(object sender, EventArgs e)
        {
            string a = txt_Qty.Text;
            string b = a.TrimStart('0');
            txt_Qty.Text = b;
        }
        private void txt_Qty_Click(object sender, EventArgs e)
        {
            if (txt_Qty.Text == "0")
            {
                txt_Qty.Text = "";
            }
        }
        private void txt_IGST_TextChanged(object sender, EventArgs e)
        {
            if (txt_IGST.Text != "")
            {
                if (Convert.ToDecimal(txt_IGST.Text) > 0)
                {
                    txt_GST.Text = "0";
                }
                else
                {
                    txt_IGST.Text = "0";
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_SalesItem.Rows.Count > 0)
                {
                    int i = 0, j = 0;
                    decimal GST = 0;
                    DataTable dtb = this.cntrl.get_salesdetails(txt_InvoiceNum.Text);
                    GST = Convert.ToDecimal(txt_CGST.Text) + Convert.ToDecimal(txt_SGST.Text);
                    i = this.cntrl.save_master(DateTime.Now.ToString("yyyy-MM-dd"), txt_InvoiceNum.Text, dtp_invDate.Value.ToString("yyyy-MM-dd"), txtPatientID.Text, txt_patient.Text, txt_GrandTotal.Text, doctor_id.ToString(), txt_TotalCost.Text, GST, Txt_TotalIGST.Text);
                    if (i > 0)
                    {
                        string dt_retnumber = this.cntrl.max_retnumber();
                        foreach (DataGridViewRow dr in dgv_SalesItem.Rows)
                        {
                            string unit2; decimal bat_RetQty_sales = 0, Totalquantity = 0;
                            DataTable dtUnit2 = this.cntrl.Get_unites(dr.Cells["id"].Value.ToString());
                            if (dtUnit2.Rows[0][0].ToString() == dr.Cells["ColUnit"].Value.ToString())
                            {
                                unit2 = "Yes";
                            }
                            else
                                unit2 = "No";
                            this.cntrl.save_returnitems(dt_retnumber, dr.Cells["id"].Value.ToString(), dr.Cells["ColQty"].Value.ToString(), dr.Cells["colUnitcost"].Value.ToString(), unit2, dr.Cells["ColFree"].Value.ToString());
                            string dt_UpdateRetqty_sales = this.cntrl.get_sales_retqty(txt_InvoiceNum.Text, dr.Cells["id"].Value.ToString());
                            DataTable dt_salesRetqty = this.cntrl.get_sales_qty(dt_retnumber, dr.Cells["id"].Value.ToString());
                            if (Convert.ToDecimal(dt_UpdateRetqty_sales) > 0)
                            {
                                if (Convert.ToDecimal(dtUnit2.Rows[0]["UnitMF"].ToString()) > 0)
                                {
                                    if (dt_salesRetqty.Rows[0]["UNIT2"].ToString().Trim() == "No")
                                    {
                                        Totalquantity = Convert.ToDecimal(dt_salesRetqty.Rows[0]["Qty"].ToString()) * Convert.ToDecimal(dtUnit2.Rows[0]["UnitMF"].ToString());
                                        bat_RetQty_sales = Totalquantity + Convert.ToDecimal(dt_UpdateRetqty_sales);
                                    }
                                    else
                                    {
                                        Totalquantity = Convert.ToDecimal(dt_salesRetqty.Rows[0]["Qty"].ToString());
                                        bat_RetQty_sales = Totalquantity + Convert.ToDecimal(dt_UpdateRetqty_sales);
                                    }
                                }
                                else
                                {
                                    Totalquantity = Convert.ToDecimal(dt_salesRetqty.Rows[0]["Qty"].ToString());
                                    bat_RetQty_sales = Totalquantity + Convert.ToDecimal(dt_UpdateRetqty_sales);
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(dtUnit2.Rows[0]["UnitMF"].ToString()) > 0)
                                {
                                    if (dt_salesRetqty.Rows[0]["UNIT2"].ToString().Trim() == "No")
                                    {
                                        bat_RetQty_sales = Convert.ToDecimal(dt_salesRetqty.Rows[0]["Qty"].ToString()) * Convert.ToDecimal(dtUnit2.Rows[0]["UnitMF"].ToString());
                                    }
                                    else
                                    {
                                        bat_RetQty_sales = Convert.ToDecimal(dt_salesRetqty.Rows[0]["Qty"].ToString());
                                    }
                                }
                                else
                                {
                                    bat_RetQty_sales = Convert.ToDecimal(dt_salesRetqty.Rows[0]["Qty"].ToString());
                                }
                            }
                            this.cntrl.update_sales_retqty(bat_RetQty_sales, dr.Cells["id"].Value.ToString(), txt_InvoiceNum.Text);
                        }
                        int rowaffected = 0; decimal bat_RetQty = 0;
                        for (int k = 0; k < dgv_BatchSale.Rows.Count; k++)
                        {
                            string retqty = this.cntrl.retqty_from_batchsale(dgv_BatchSale.Rows[k].Cells["colentry"].Value.ToString());
                            if (Convert.ToDecimal(retqty) > 0)
                            {
                                bat_RetQty = Convert.ToDecimal(retqty) + Convert.ToDecimal(dgv_BatchSale.Rows[k].Cells["colReturnQty"].Value.ToString());
                                if (Convert.ToDecimal(dgv_BatchSale.Rows[k].Cells["colReturnQty"].Value.ToString()) > 0)
                                {
                                    this.cntrl.update_batchsale(bat_RetQty, dgv_BatchSale.Rows[k].Cells["colentry"].Value.ToString());
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(dgv_BatchSale.Rows[k].Cells["colReturnQty"].Value.ToString()) > 0)
                                {
                                    this.cntrl.update_batchsale(Convert.ToDecimal(dgv_BatchSale.Rows[k].Cells["colentry"].Value.ToString()), dgv_BatchSale.Rows[k].Cells["colReturnQty"].Value.ToString());
                                }
                            }
                            rowaffected = this.cntrl.update_batchnumber(dgv_BatchSale.Rows[k].Cells["currentStock"].Value.ToString(), dgv_BatchSale.Rows[k].Cells["colBatchentry"].Value.ToString());
                        }
                        if (rowaffected > 0)
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
                            clear_Alldetails();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void disable_AllControlls()
        {
            dtp_invDate.Enabled = false;
            txtSales.Enabled = false;
            txtBdoctor.Enabled = false;
            DTP_LRDate.Enabled = false;
            txt_OrderNo.Enabled = false;
            DTP_OrderDate.Enabled = false;
            txt_Through.Enabled = false;
            txt_patient.Enabled = false;
            txtPatientID.Enabled = false;
            txt_Street.Enabled = false;
            txt_Locality.Enabled = false;
            txt_City.Enabled = false;
            txt_PhoneNo.Enabled = false;
            txt_totalItems.Enabled = false;
            txt_GrandTotal.Enabled = false;
            txt_GrandTotal.ForeColor = Color.Red;
            txt_TotalCost.Enabled = false;
            Txt_TotalIGST.Enabled = false;
            txt_SGST.Enabled = false;
            txt_CGST.Enabled = false;
            txt_ItemCode.Enabled = false;
            txt_Discription.Enabled = false;
            txt_Packing.Enabled = false;
            txt_GST.Enabled = false;
            txt_IGST.Enabled = false;
            txt_Free.Enabled = false;
            txt_UnitCost.Enabled = false;
            txt_Amount.Enabled = false;
            txt_LRNO.Enabled = false;
        }
        public void clear_Alldetails()
        {
            txt_InvoiceNum.Text = "";
            dtp_invDate.Text = DateTime.Now.ToString();
            txtSales.Text = "";
            txtBdoctor.Text = "";
            txt_LRNO.Text = "";
            DTP_LRDate.Text = DateTime.Now.ToString();
            txt_OrderNo.Text = "";
            DTP_OrderDate.Text = DateTime.Now.ToString();
            txt_Through.Text = "";
            txt_patient.Text = "";
            txtPatientID.Text = "";
            txt_Street.Text = "";
            txt_Locality.Text = "";
            txt_City.Text = "";
            txt_PhoneNo.Text = "";
            txt_totalItems.Text = "0";
            txt_GrandTotal.Text = "00.00";
            txt_GrandTotal.ForeColor = Color.Red;
            txt_TotalCost.Text = "0.00";
            Txt_TotalIGST.Text = "0";
            txt_SGST.Text = "0";
            txt_CGST.Text = "0";
            dgv_SalesItem.Rows.Clear();
            dgv_BatchSale.Rows.Clear();
        }
        public void printhtml()
        {
            string strclinicname = "", strphone = "", DlNumber = "", DlNumber2 = "", website = "",logo_name="";
            System.Data.DataTable dtp = this.cntrl.get_companydetails();
            if (dtp.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = dtp.Rows[0]["name"].ToString();
                strclinicname = clinicn.Replace("¤", "'");
                strphone = dtp.Rows[0]["contact_no"].ToString();
                DlNumber = dtp.Rows[0]["street_address"].ToString();
                DlNumber2 = dtp.Rows[0]["email"].ToString();
                website = dtp.Rows[0]["website"].ToString();
                logo_name = dtp.Rows[0]["path"].ToString();
            }
            string Apppath = System.IO.Directory.GetCurrentDirectory();
            StreamWriter sWrite = new StreamWriter(Apppath + "\\salesReturn.html");
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<body >");
            sWrite.WriteLine("<div>");
            sWrite.WriteLine("<table align=center width=900>");
            sWrite.WriteLine("<col >");
            sWrite.WriteLine("<br>");
            string Appath = System.IO.Directory.GetCurrentDirectory();
            if (File.Exists(Appath + "\\" + logo_name))
            {
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + DlNumber + "<br>&nbsp;" + strphone + " </b></td></tr>");
                sWrite.WriteLine("</table>");
            }
            else
            {
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + DlNumber + "</font></td></tr>");
                sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");
                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                sWrite.WriteLine("</table>");
            }
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> RETURN BILL </font></center></b></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Invoice Number :&nbsp" + txt_InvoiceNum.Text + "</font></td>");
            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Return No:" + txt_InvoiceNum.Text + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Invoice Date : &nbsp;" + dtp_invDate.Text + "</font></td>");
            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Date :" + DateTime.Now.ToString("MM-dd-yyyy") + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr><td></td></tr>");
            sWrite.WriteLine("<tr><td colspan=4><hr/></td></tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left'  width='150'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Item Code</b></font></td>");
            sWrite.WriteLine("<td align='right'  width='65'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Quantity</b></font></td>");
            sWrite.WriteLine("<td align='right'  width='82'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Cost </b></font></td>");
            sWrite.WriteLine("<td align='right'  width='82'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>TotalAmount</b></font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr><td align='left' colspan=4><hr/></td></tr>");
            if (dgv_SalesItem.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_SalesItem.Rows.Count; i++)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["colItemCode"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_SalesItem.Rows[i].Cells["ColQty"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colUnitcost"].Value.ToString()).ToString("##0.00") + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToDecimal(dgv_SalesItem.Rows[i].Cells["colAmount"].Value.ToString()).ToString("##0.00") + "</font></td>");
                    sWrite.WriteLine("</tr>");
                }
            }
            sWrite.WriteLine("<tr><td align='left'  colspan=4><hr/></td></tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='right'  colspan=3 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Items :</font></td>");
            sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp " + txt_totalItems.Text + " </font></td>");
            sWrite.WriteLine("</tr>");
            if (txt_CGST.Text != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=3 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> CGST :</font></td>");
                sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp" + txt_CGST.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=3 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> SGST :  </font></td>");
                sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp " + txt_SGST.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
            }
            else if (Txt_TotalIGST.Text != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'  colspan=3 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total IGST :</font></td>");
                sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp" + Txt_TotalIGST.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
            }
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='right'  colspan=3 ><FONT COLOR=black FACE='Segoe UI' 2><b>Grand Total :</b> </font></td>");
            sWrite.WriteLine("<td align='right'  colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp<b> " + String.Format("{0:C}", decimal.Parse(txt_GrandTotal.Text)) + "</b> </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<script>window.print();</script>");
            sWrite.WriteLine("</body >");
            sWrite.WriteLine("</html>");
            sWrite.Close();
            System.Diagnostics.Process.Start(Apppath + "\\salesReturn.html");
        }

        private void btnReport_Click(object sender, EventArgs e)
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
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear_itemdetails();
            clear_Alldetails();
        }
        private void dgv_SalesItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_SalesItem.Rows.Count > 0)
            {
                Decimal Qty = 0, IGST = 0, GST = 0, Cost = 0, TotalItems = 0, TotalCost = 0, TotalGst = 0, TotalAmount = 0;
                decimal igstAmount = 0; decimal gstAmount = 0;
                string itmCode = "", quantity = "";
                if (dgv_SalesItem.CurrentCell.OwningColumn.Name == "coldelete")
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
                        if (txt_GrandTotal.Text != "")
                        {
                            TotalAmount = Convert.ToDecimal(txt_GrandTotal.Text) - Convert.ToDecimal(dgv_SalesItem.Rows[index].Cells["colAmount"].Value.ToString());
                            txt_GrandTotal.Text = Convert.ToDecimal(TotalAmount).ToString("##0.00");
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
                        dgv_SalesItem.Rows.RemoveAt(index);
                        fill_Batch_delete(itmCode, quantity);
                    }
                }
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
            dtrow.Columns.Add("BatchEntry");
            dtrow.Columns.Add("Stock");
            dtrow.Columns.Add("qty");
            dtrow.Columns.Add("ReturnQty");
            dtrow.Columns.Add("CurrentStock");
            if (dtrow.Columns.Count > 0)
            {
                for (int i = 0; i < dgv_BatchSale.Rows.Count; i++)
                {
                    if (dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString() != itemcode)
                    {
                        dtrow.Rows.Add(dgv_BatchSale.Rows[i].Cells["ColinvNum"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["ColInvDate"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["coiltem_code"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colBatchnumber"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colBatchEntry"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colStock"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colQuantity"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["colReturnQty"].Value.ToString(), dgv_BatchSale.Rows[i].Cells["currentStock"].Value.ToString());
                    }
                }
            }
            if (dtrow.Rows.Count > 0)
            {
                dgv_BatchSale.Rows.Clear();
                for (int i = 0; i < dtrow.Rows.Count; i++)
                {
                    dgv_BatchSale.Rows.Add(dtrow.Rows[i][0].ToString(), dtrow.Rows[i][1].ToString(), dtrow.Rows[i][2].ToString(), dtrow.Rows[i][3].ToString(), dtrow.Rows[i][4].ToString(), dtrow.Rows[i][5].ToString(), dtrow.Rows[i][6].ToString(), dtrow.Rows[i][7].ToString(), dtrow.Rows[i][8].ToString());
                }
            }
            else
            {
                dgv_BatchSale.Rows.Clear();
            }
        }
        private void btn_AddtoGrid_Click(object sender, EventArgs e)
        {
            Decimal TotalGst = 0; decimal gstAmount = 0; decimal igstAmount = 0;
            Decimal Total_Igst = 0;
            int Totalqty = 0; decimal qty_Check = 0;
            Decimal TotalAmount = 0;
            Decimal TotalCost = 0;
            if (string.IsNullOrWhiteSpace(txt_ItemCode.Text))
            {
                MessageBox.Show("Item Code could not be found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ItemCode.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_InvoiceNum.Text))
            {
                MessageBox.Show("Invoice Number could not be found....", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_ItemCode.Focus();
                return;
            }
            int number;
            string value;
            value = txt_Qty.Text.Trim();
            if (!Int32.TryParse(value, out number))
            {
                MessageBox.Show("Return quantity should be an integer value", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string dt = this.cntrl.sum_qty_from_sales(txt_InvoiceNum.Text, txt_ItemCode.Text);
            DataTable dt_Items = this.cntrl.Get_unites(ItemCode_From_List);
            if (Convert.ToDecimal(txt_Qty.Text) > 0)
            {
                decimal qty = 0;
                if (Convert.ToDecimal(txt_Free.Text) > 0)
                {
                    qty = Convert.ToDecimal(txt_Qty.Text) + Convert.ToDecimal(txt_Free.Text);
                }
                else
                    qty = Convert.ToDecimal(txt_Qty.Text);
                var form2 = new Sales_Return_Batch(ItemCode_From_List, qty, txt_InvoiceNum.Text, cmb_Unit.Text);
                form2.ShowDialog();
                if (dtFor_QtyReturn != null)
                {
                    if (flagset == true)
                    {
                        dgv_SalesItem.Rows.Add(ItemCode_From_List, txt_ItemCode.Text, txt_Discription.Text, txt_Packing.Text, cmb_Unit.Text, txt_GST.Text, txt_IGST.Text, txt_Qty.Text, txt_Free.Text, txt_UnitCost.Text, txt_Amount.Text, qty_Check, PappyjoeMVC.Properties.Resources.deleteicon);
                        fill_batchGrid(); dtFor_QtyReturn = null;
                        flagset = false;
                    }
                    if (dgv_SalesItem.Rows.Count > 0)
                    {
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
                        if (TotalCost > 0)
                        {
                            txt_TotalCost.Text = TotalCost.ToString("##.00");
                        }
                        if (TotalAmount > 0)
                        {
                            txt_GrandTotal.Text = Convert.ToDecimal(TotalAmount).ToString("##.00");
                            txt_GrandTotal.ForeColor = Color.Red;
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
                    }
                    clear_itemdetails();
                }
                else
                {
                    MessageBox.Show("Does not add batch!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Mandatory fileds should not be empty", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Qty.Focus();
            }
        }
        public void fill_batchGrid()
        {
            if (dtFor_QtyReturn.Rows.Count > 0)
            {
                int row = dgv_BatchSale.Rows.Count;
                foreach (DataRow dr in dtFor_QtyReturn.Rows)
                {
                    if (dr["colReturnQty"].ToString() != "")
                    {
                        dgv_BatchSale.Rows.Add();
                        dgv_BatchSale.Rows[row].Cells["ColinvNum"].Value = txt_InvoiceNum.Text;
                        dgv_BatchSale.Rows[row].Cells["colentry"].Value = dr["colEntry"].ToString();
                        dgv_BatchSale.Rows[row].Cells["ColInvDate"].Value = dtp_invDate.Text;
                        dgv_BatchSale.Rows[row].Cells["coiltem_code"].Value = txt_ItemCode.Text;
                        dgv_BatchSale.Rows[row].Cells["colBatchnumber"].Value = dr["colbatchNo"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colQuantity"].Value = dr["ColQty"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colReturnQty"].Value = dr["colReturnQty"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colBatchentry"].Value = dr["colBatchentry"].ToString();
                        dgv_BatchSale.Rows[row].Cells["colStock"].Value = dr["oldstock"].ToString();
                        dgv_BatchSale.Rows[row].Cells["currentStock"].Value = dr["colCurrentStock"].ToString();
                        row++;
                    }

                }
            }
        }
        private void Sales_Return_Load(object sender, EventArgs e)
        {
            DTP_OrderDate.Format = DateTimePickerFormat.Short;
            DTP_OrderDate.Value = DateTime.Today;
            dtp_invDate.Format = DateTimePickerFormat.Short;
            dtp_invDate.Value = DateTime.Today;
            DTP_OrderDate.Format = DateTimePickerFormat.Short;
            DTP_OrderDate.Value = DateTime.Today;
            disable_AllControlls();
            txt_InvoiceNum.Focus();
            txt_InvoiceNum.Enabled = true;
            txt_Qty.Enabled = true; btn_AddtoGrid.Enabled = true;
            btnReport.Visible = false;
            btn_save.Enabled = true;
            button3.Enabled = true;
            dgv_SalesItem.Enabled = true;
            if (PrintFlag == true)
            {
                if (Ret_Numbr > 0)
                {
                    int value; decimal TotalAmount = 0, TotalCost = 0, Amount = 0;
                    int qty = 0; decimal ToatalGST = 0, TotalIGST = 0;
                    DataTable dtb_main = this.cntrl.load_return_master(Ret_Numbr);
                    DataTable dtb_Items = this.cntrl.load_return_items(Ret_Numbr);
                    decimal gstAmount = 0, igstAmount = 0;
                    if (dtb_main.Rows.Count > 0)
                    {
                        value = Convert.ToInt32(dtb_main.Rows[0]["InvNumber"].ToString());
                        DataTable dtb = this.cntrl.get_master_sales_details(value.ToString());
                        txt_InvoiceNum.Text = Ret_Numbr.ToString();
                        txt_InvoiceNum.Enabled = false;
                        txt_Qty.Enabled = false;
                        btn_AddtoGrid.Enabled = false;
                        btnReport.Visible = true;
                        btn_save.Enabled = false;
                        button3.Enabled = false;
                        dgv_SalesItem.Enabled = false;
                        dtp_invDate.Text = dtb_main.Rows[0]["InvDate"].ToString();
                        txtSales.Text = dtb.Rows[0]["SalesmanCode"].ToString();
                        txtBdoctor.Text = dtb.Rows[0]["Prescribedby"].ToString();
                        txt_LRNO.Text = dtb.Rows[0]["LRNo"].ToString();
                        DTP_LRDate.Text = dtb.Rows[0]["LRDate"].ToString();
                        txt_OrderNo.Text = dtb.Rows[0]["OrderNumber"].ToString();
                        DTP_OrderDate.Text = dtb.Rows[0]["Orderdate"].ToString();
                        txt_Through.Text = dtb.Rows[0]["Through"].ToString();
                        txt_patient.Text = dtb_main.Rows[0]["cust_name"].ToString();
                        txtPatientID.Text = dtb_main.Rows[0]["cust_number"].ToString();
                        txt_Street.Text = dtb.Rows[0]["adr1"].ToString();
                        txt_Locality.Text = dtb.Rows[0]["adr2"].ToString();
                        txt_City.Text = dtb.Rows[0]["adr3"].ToString();
                        txt_PhoneNo.Text = dtb.Rows[0]["phone1"].ToString();
                        if (dtb_Items.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtb_Items.Rows.Count; j++)
                            {
                                DataTable dtb_Master = this.cntrl.get_sales_items_details(value.ToString(), dtb_Items.Rows[j]["Item_Code"].ToString());
                                dgv_SalesItem.Rows.Add();
                                dgv_SalesItem.Rows[j].Cells["colItemCode"].Value = dtb_Master.Rows[0]["Item_Code"].ToString();
                                dgv_SalesItem.Rows[j].Cells["colDiscription"].Value = dtb_Master.Rows[0]["Description"].ToString();
                                dgv_SalesItem.Rows[j].Cells["ColPacking"].Value = dtb_Master.Rows[0]["Packing"].ToString();
                                dgv_SalesItem.Rows[j].Cells["ColFree"].Value = dtb_Master.Rows[0]["FreeQty"].ToString();
                                dgv_SalesItem.Rows[j].Cells["colUnitcost"].Value = dtb_Items.Rows[j]["Rate"].ToString();
                                dgv_SalesItem.Rows[j].Cells["ColQty"].Value = dtb_Items.Rows[j]["Qty"].ToString();
                                Amount = Convert.ToDecimal(dtb_Items.Rows[j]["Qty"].ToString()) * Convert.ToDecimal(dtb_Items.Rows[j]["Rate"].ToString());
                                if (Convert.ToInt32(dtb_Master.Rows[0]["GST"].ToString()) > 0)
                                {
                                    dgv_SalesItem.Rows[j].Cells["ColGST"].Value = dtb_Master.Rows[0]["GST"].ToString();
                                    gstAmount = ((Convert.ToDecimal(dtb_Items.Rows[j]["Qty"].ToString()) * Convert.ToDecimal(dtb_Items.Rows[j]["Rate"].ToString())) * Convert.ToDecimal(dtb_Master.Rows[0]["GST"].ToString())) / 100;
                                    ToatalGST = ToatalGST + gstAmount;
                                    dgv_SalesItem.Rows[j].Cells["colIGST"].Value = "0";
                                    dgv_SalesItem.Rows[j].Cells["colAmount"].Value = Convert.ToDecimal(Amount + gstAmount).ToString("#0.00"); 
                                }
                                else if (Convert.ToInt32(dtb_Master.Rows[0]["IGST"].ToString()) > 0)
                                {
                                    dgv_SalesItem.Rows[j].Cells["colIGST"].Value = dtb_Master.Rows[0]["IGST"].ToString();
                                    igstAmount = ((Convert.ToDecimal(dtb_Items.Rows[j]["Qty"].ToString()) * Convert.ToDecimal(dtb_Items.Rows[j]["Rate"].ToString())) * Convert.ToDecimal(dtb_Master.Rows[0]["IGST"].ToString())) / 100;
                                    TotalIGST = TotalIGST + igstAmount;
                                    dgv_SalesItem.Rows[j].Cells["ColGST"].Value = "0";
                                    dgv_SalesItem.Rows[j].Cells["colAmount"].Value = Convert.ToDecimal(Amount + igstAmount).ToString("#0.00");
                                }
                                else
                                {
                                    dgv_SalesItem.Rows[j].Cells["colIGST"].Value = "0";
                                    dgv_SalesItem.Rows[j].Cells["colAmount"].Value = Convert.ToDecimal(dtb_Items.Rows[j]["Qty"].ToString()) * Convert.ToDecimal(dtb_Items.Rows[j]["Rate"].ToString());
                                }
                                TotalAmount = TotalAmount + Convert.ToDecimal(dgv_SalesItem.Rows[j].Cells["colAmount"].Value.ToString());
                                TotalCost = TotalCost + (Convert.ToInt32(dtb_Items.Rows[j]["Qty"].ToString()) * Convert.ToDecimal(dtb_Items.Rows[j]["Rate"].ToString()));
                                DataTable dtb_unit = this.cntrl.Get_unites(dtb_Items.Rows[j]["Item_Code"].ToString());
                                if (dtb_Items.Rows[j]["UNIT2"].ToString().Trim() == "Yes")
                                {
                                    dgv_SalesItem.Rows[j].Cells["ColUnit"].Value = dtb_unit.Rows[0]["Unit2"].ToString();
                                }
                                else
                                {
                                    dgv_SalesItem.Rows[j].Cells["ColUnit"].Value = dtb_unit.Rows[0]["Unit1"].ToString();
                                }
                                dgv_SalesItem.Rows[j].Cells["coldelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            }
                            qty = dtb_Items.Rows.Count;
                            txt_totalItems.Text = qty.ToString();
                            txt_GrandTotal.Text = TotalAmount.ToString("##.00");
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
                        }
                    }
                }
            }
        }
    }
}
