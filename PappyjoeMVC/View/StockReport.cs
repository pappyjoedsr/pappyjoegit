using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class StockReport : Form
    {
        string combo_topmargin = "";
        string combo_leftmargin = "";
        string combo_bottommargin = "";
        string combo_rightmargin = "";
        string combo_paper_size = "";
        string combo_footer_topmargin = "";
        string rich_fullwidth = "";
        string rich_leftsign = "";
        string rich_rightsign = "";
        string patient_details = "";
        string med = "";
        string patient = "";
        string address = "";
        string phone = "";
        string blood = "";
        string gender = "";
        string logo_name = "";
        string orientation = "",path="";
        string includeheader = "0";
        string includelogo = "0";
        System.Drawing.Image logo = null;
        stock_controller cntrl = new stock_controller();
        public string doctor_id = "";
        Purchase purchase = new Purchase();
        Sales sales = new Sales();
        SalesOrder sales_order = new SalesOrder();
        PurchaseOrder pur_order = new PurchaseOrder();
        Purchase_Return pur_return = new Purchase_Return();
        Sales_Return salesreturn = new Sales_Return();
        public bool Pur_orderFlag = false, sales_orderFlag = false, Pur_ListFlag = false, sales_ListFlag = false, Pur_retnFlag = false;
        PurchaseList purchase_LIst = new PurchaseList();
        Purchase_order_list PU_orderList = new Purchase_order_list();
        Sales_List salesList = new Sales_List();
        Sales_order_list s_orderList = new Sales_order_list();
        Sales_ReturnList S_ReturnList = new Sales_ReturnList();
        Purchase_Return_List Pu_returnList = new Purchase_Return_List();
        public StockReport()
        {
            InitializeComponent();
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_purchase.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            purchase.Close();
            if (purchase == null || purchase.IsDisposed)
                purchase = new Purchase();
            purchase.TopLevel = false;
            panel_main.Controls.Add(purchase);
            purchase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            purchase.Show();
        }
        public void backColor_Change()
        {
            btn_Stock.BackColor = Color.DodgerBlue;
            btn_purchase.BackColor = Color.DodgerBlue;
            btnSales.BackColor = Color.DodgerBlue;
            btn_purOrder.BackColor = Color.DodgerBlue;
            btn_SalesOrder.BackColor = Color.DodgerBlue;
            btn_purchaReturn.BackColor = Color.DodgerBlue;
            btn_SalesReturn.BackColor = Color.DodgerBlue;
            btn_purchList.BackColor = Color.DodgerBlue;
            btn_Sales_report.BackColor = Color.DodgerBlue;
            btn_orderList.BackColor = Color.DodgerBlue;
            btn_SOrderList.BackColor = Color.DodgerBlue;
            btn_purchRetList.BackColor = Color.DodgerBlue;
            btn_SalesReturnReport.BackColor = Color.DodgerBlue;
        }
        public void FormHide()
        {
            salesList.Hide();
            purchase_LIst.Hide();
            Pu_returnList.Hide();
            s_orderList.Hide();
            PU_orderList.Hide();
            pur_order.Hide();
            pur_return.Hide();
            S_ReturnList.Hide();
            purchase.Hide();
            sales_order.Hide();
            Pur_ListFlag = false;
            Pur_retnFlag = false;
            sales_ListFlag = false;
            Pur_ListFlag = false;
            sales_ListFlag = false;
            Pur_orderFlag = false;
            sales_orderFlag = false;
            salesreturn.Hide();
            sales.Hide();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btnSales.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            sales.Close();
            if (sales == null || sales.IsDisposed)
                sales = new Sales();
            sales.TopLevel = false;
            sales.doctor_id = doctor_id;
            panel_main.Controls.Add(sales);
            sales.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sales.Show();
        }

        private void btn_SalesOrder_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_SalesOrder.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            sales_order.Close();
            if (sales_order == null || sales_order.IsDisposed)
                sales_order = new SalesOrder();
            sales_order.TopLevel = false;
            panel_main.Controls.Add(sales_order);
            sales_order.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sales_order.Show();
        }

        private void frmstockReport_Load(object sender, EventArgs e)
        {
            listpatientsearch.BringToFront();
            panel_main.Hide(); Lab_Msg.Visible = false;
            btn_Stock.BackColor = Color.SteelBlue;
            toolStripButton5.BackColor = Color.SkyBlue;
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            System.Data.DataTable clinicname = this.cntrl.Get_CompanyNAme();
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
                path = clinicname.Rows[0]["path"].ToString();
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripldoc.Text = "Logged In As : " + docnam;
                }
            }
            try
            {
                if (path != "")
                {
                    string curFile = this.cntrl.server() + "\\Pappyjoe_utilities\\Logo\\" + path;

                    if (File.Exists(curFile))
                    {
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
            }
            DataTable dt_supplier = this.cntrl.LoadSupplier();
            Load_Supplier(dt_supplier);
            DataTable dt_load = this.cntrl.load_stock();
            load_stock(dt_load);
            DGV_Stock.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            DGV_Stock.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGV_Stock.EnableHeadersVisualStyles = false;
            DGV_Stock.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            DGV_Stock.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV_Stock.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV_Stock.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            DGV_Stock.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            foreach (DataGridViewColumn cl in DGV_Stock.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void Load_Supplier(DataTable gp_rs)
        {
            if (gp_rs.Rows.Count > 0)
            {
                for (int i = 0; i < gp_rs.Rows.Count; i++)
                {
                    Cmb_Suplier.Items.Add(gp_rs.Rows[i]["Supplier_Name"].ToString());
                    Cmb_Suplier.ValueMember = gp_rs.Rows[i]["Supplier_Code"].ToString();
                    Cmb_Suplier.DisplayMember = gp_rs.Rows[i]["Supplier_Name"].ToString();
                }
                Cmb_Suplier.SelectedIndex = 0;
            }
        }
        public void load_stock(DataTable dtb)
        {
            try
            {
                Lab_Msg.Visible = false;
                string current_Stock = ""; int unitmf = 0, qty = 0, quotient = 0, Remainder = 0; decimal value = 0, stock = 0;
                int num = 1; DGV_Stock.Rows.Clear();
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        DataTable dtb_Min = this.cntrl.minimumStock(dtb.Rows[i]["id"].ToString());
                        DataTable dtunit = this.cntrl.itemdetails(dtb.Rows[i]["id"].ToString());
                        if (dtunit.Rows.Count > 0)
                        {
                            decimal item_rate1 = 0;
                            decimal item_rate2 = 0;
                            if (dtunit.Rows[0]["OneUnitOnly"].ToString() == "False")
                            {
                                unitmf = Convert.ToInt32(dtunit.Rows[0]["UnitMF"].ToString());
                                value = Convert.ToDecimal(dtb.Rows[i]["qty"].ToString());
                                qty = Convert.ToInt32(value);
                                quotient = Convert.ToInt32(qty / unitmf);
                                Remainder = Convert.ToInt32(qty % unitmf);
                                item_rate1 = quotient * Convert.ToDecimal(dtunit.Rows[0]["purch_rate"].ToString());
                                item_rate2 = quotient * Convert.ToDecimal(dtunit.Rows[0]["purch_rate2"].ToString());
                                if (quotient < Convert.ToDecimal(dtb_Min.Rows[0][0].ToString()))
                                {
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + quotient + " " + "," + " " + dtunit.Rows[0]["Unit2"].ToString() + " " + "=" + Remainder + " Value:" + (item_rate1 + item_rate2).ToString("#.##");
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["Unit1"].ToString(),current_Stock);
                                    DGV_Stock.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                }
                                else
                                {
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + quotient + " " + "," + " " + dtunit.Rows[0]["Unit2"].ToString() + " " + "=" + Remainder + " Value:" + (item_rate1 + item_rate2).ToString("#.##");
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["Unit1"].ToString(), current_Stock);
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(dtb.Rows[i]["qty"].ToString()) < Convert.ToDecimal(dtb_Min.Rows[0][0].ToString()))
                                { 
                                    stock = Convert.ToDecimal(dtb.Rows[i]["qty"].ToString());
                                    item_rate1 = stock * Convert.ToDecimal(dtunit.Rows[0]["purch_rate"].ToString());
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + Math.Floor(stock) + " Value:" + item_rate1.ToString("#.##");
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["Unit1"].ToString(),current_Stock);
                                    DGV_Stock.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                }
                                else
                                {
                                    stock = Convert.ToDecimal(dtb.Rows[i]["qty"].ToString());
                                    item_rate1 = stock * Convert.ToDecimal(dtunit.Rows[0]["purch_rate"].ToString());
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + Math.Floor(stock) + " Value:" + item_rate1.ToString("#.##");
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["Unit1"].ToString(),current_Stock);
                                }
                            }
                        }
                        num = num + 1;
                    }
                }
                else
                {
                    Lab_Msg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (Chk_Minimum.Checked)
                {
                    Lab_Msg.Visible = false;
                    DataTable dtb = new DataTable();
                    if (String.IsNullOrWhiteSpace(txt_search.Text))
                    {
                        dtb = this.cntrl.search_minimum();
                    }
                    else
                    {
                        dtb = this.cntrl.search_minium_wit_itemname(txt_search.Text);
                    }
                    Lab_Msg.Visible = false;
                    if (dtb.Rows.Count > 0)
                    {
                        Fill_Mingrid(dtb);
                    }
                    else
                    {
                        DGV_Stock.Rows.Clear();
                        Lab_Msg.Visible = true;
                    }
                }
                else
                {
                    DataTable dtb = new DataTable();
                    if (String.IsNullOrWhiteSpace(txt_search.Text))
                    {
                        dtb = this.cntrl.search_minimum();
                    }
                    else
                    {
                        dtb = this.cntrl.search_minium_wit_itemname(txt_search.Text);
                    }
                    Lab_Msg.Visible = false;
                    if (dtb.Rows.Count > 0)
                    {
                        load_stock(dtb);
                    }
                    else
                    {
                        DGV_Stock.Rows.Clear();
                        Lab_Msg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Fill_Mingrid(DataTable dtb)
        {
            try
            {
                Lab_Msg.Visible = false;
                string current_Stock = ""; int unitmf = 0; int qty = 0; int quotient = 0; int Remainder = 0; decimal value = 0, stock = 0;
                int num = 1; DGV_Stock.Rows.Clear();
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        DataTable dtb_Min = this.cntrl.minimumStock(dtb.Rows[i]["id"].ToString());
                        DataTable dtunit = this.cntrl.itemdetails(dtb.Rows[i]["id"].ToString());
                        if (dtunit.Rows.Count > 0)
                        {
                            if (dtunit.Rows[0]["OneUnitOnly"].ToString() == "False")
                            {
                                unitmf = Convert.ToInt32(dtunit.Rows[0]["UnitMF"].ToString());
                                value = Convert.ToDecimal(dtb.Rows[i]["qty"].ToString());
                                qty = Convert.ToInt32(value);
                                quotient = Convert.ToInt32(qty / unitmf);
                                Remainder = Convert.ToInt32(qty % unitmf);
                                if (quotient < Convert.ToDecimal(dtb_Min.Rows[0][0].ToString()))
                                {
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + quotient + " " + "," + " " + dtunit.Rows[0]["Unit2"].ToString() + " " + "=" + Remainder;
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["unit"].ToString(), current_Stock);
                                    DGV_Stock.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                }
                                else
                                {
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + quotient + " " + "," + " " + dtunit.Rows[0]["Unit2"].ToString() + " " + "=" + Remainder;
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["unit"].ToString(), current_Stock);
                                    DGV_Stock.Rows[i].Visible = false;
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(dtb.Rows[i]["qty"].ToString()) < Convert.ToDecimal(dtb_Min.Rows[0][0].ToString()))
                                {
                                    stock = Convert.ToDecimal(dtb.Rows[i]["qty"].ToString());
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + Math.Floor(stock);
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["unit"].ToString(), current_Stock);
                                    DGV_Stock.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                                }
                                else
                                {
                                    stock = Convert.ToDecimal(dtb.Rows[i]["qty"].ToString());
                                    current_Stock = dtunit.Rows[0]["Unit1"].ToString() + " " + "=" + " " + Math.Floor(stock);
                                    DGV_Stock.Rows.Add(num, dtb.Rows[i]["item_code"].ToString(), dtunit.Rows[0]["item_name"].ToString(), dtunit.Rows[0]["unit"].ToString(), current_Stock);
                                    DGV_Stock.Rows[i].Visible = false;
                                }
                            }
                        }
                        num = num + 1;
                    }
                }
                else
                {
                    Lab_Msg.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_search_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
        }

        private void Chk_Suplier_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Suplier.Checked)
            {
                DGV_Stock.Rows.Clear();
                Chk_Minimum.Checked = false;
                Cmb_Suplier.Visible = true;
                Lab_Suplier.Visible = true;
                txt_search.Visible = false;
                Lab_search.Visible = false;
            }
            else
            {
                DataTable dt_stock = this.cntrl.search_minimum();
                load_stock(dt_stock);
                Chk_Minimum.Checked = false;
                Cmb_Suplier.Visible = false;
                Lab_Suplier.Visible = false;
                txt_search.Visible = true;
                Lab_search.Visible = true;
            }
        }

        private void Cmb_Suplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Cmb_Suplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Suplier.Visible == true)
            {
                if (Cmb_Suplier.SelectedIndex >= 0)
                {
                    Lab_Msg.Visible = false;
                    string sup = Cmb_Suplier.SelectedItem.ToString();
                    DataTable dt_sup = this.cntrl.get_supcode(sup);
                    DataTable dtb = this.cntrl.Load_supplier_items(dt_sup.Rows[0][0].ToString());
                    if (dtb.Rows.Count > 0)
                    {
                        load_stock(dtb);
                        if (Chk_Minimum.Checked)
                        {
                            fill_Minimun();
                        }
                    }
                    else
                    {
                        DGV_Stock.Rows.Clear();
                    }
                }
            }
        }
        public void fill_Minimun()
        {
            DataTable btn_temp = new DataTable();
            foreach (DataGridViewColumn col in DGV_Stock.Columns)
            {
                btn_temp.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in DGV_Stock.Rows)
            {
                DataRow dRow = btn_temp.NewRow();
                if (row.DefaultCellStyle.ForeColor == Color.Red)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    btn_temp.Rows.Add(dRow);
                }
            }
            if (btn_temp.Rows.Count > 0)
            {
                DGV_Stock.Rows.Clear();
                int num = 1;
                for (int i = 0; i < btn_temp.Rows.Count; i++)
                {
                    DGV_Stock.Rows.Add(num, btn_temp.Rows[i][1].ToString(), btn_temp.Rows[i][2].ToString(), btn_temp.Rows[i][3].ToString(), btn_temp.Rows[i][4].ToString());
                    num++;
                    DGV_Stock.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
            }
            else
            {
                MessageBox.Show("There is no minimum stock items.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Chk_Minimum.Checked = false;
            }
        }

        private void Chk_Minimum_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Stock.Rows.Count > 0)
                {
                    if (Chk_Minimum.Checked)
                    {
                        fill_Minimun();
                    }
                    else
                    {
                        if (Chk_Suplier.Checked)
                        {
                            string sup = Cmb_Suplier.SelectedItem.ToString();
                            DataTable dt_sup = this.cntrl.get_supcode(sup);
                            DataTable dtb = this.cntrl.Load_supplier_items(dt_sup.Rows[0][0].ToString());
                            load_stock(dtb);
                        }
                        else
                        {
                            DataTable dt_stock = this.cntrl.search_minimum();
                            load_stock(dt_stock);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmstockReport_Activated(object sender, EventArgs e)
        {
            if (Connection.MyGlobals.global_Flag == true)
            {
                if (Pur_orderFlag == true)
                {
                    backColor_Change();
                    btn_orderList.BackColor = Color.SteelBlue;
                    salesList.Hide();
                    purchase_LIst.Hide();
                    Pu_returnList.Hide();
                    s_orderList.Hide();
                    pur_order.Hide();
                    pur_return.Hide();
                    S_ReturnList.Hide();
                    purchase.Hide();
                    sales_order.Hide();
                    salesreturn.Hide();
                    sales.Hide();
                    Pur_orderFlag = true;
                    sales_orderFlag = false;
                    Pur_ListFlag = false;
                    sales_ListFlag = false;
                    Pur_retnFlag = false;
                    Connection.MyGlobals.global_Flag = false;
                    string date1 = Connection.MyGlobals.Date_From;
                    string date2 = Connection.MyGlobals.Date_To;
                    panel_main.Show();
                    PU_orderList.Close();
                    if (PU_orderList.IsDisposed)
                        PU_orderList = new Purchase_order_list(date1, date2);
                    PU_orderList.TopLevel = false;
                    panel_main.Controls.Add(PU_orderList);
                    PU_orderList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    PU_orderList.Show();
                }
                else if (sales_orderFlag == true)
                {
                    backColor_Change();
                    btn_SOrderList.BackColor = Color.SteelBlue;
                    salesreturn.Hide();
                    purchase.Hide();
                    pur_return.Hide();
                    Pu_returnList.Hide();
                    sales.Hide();
                    sales_order.Hide();
                    salesList.Hide();
                    purchase_LIst.Hide();
                    S_ReturnList.Hide();
                    pur_order.Hide();
                    PU_orderList.Hide();
                    Pur_orderFlag = false;
                    Pur_ListFlag = false;
                    sales_ListFlag = false;
                    sales_orderFlag = true;
                    Pur_retnFlag = false;
                    Connection.MyGlobals.global_Flag = false;
                    string date1 = Connection.MyGlobals.Date_From;
                    string date2 = Connection.MyGlobals.Date_To;
                    panel_main.Show();
                    s_orderList.Close();
                    if (s_orderList == null || s_orderList.IsDisposed)
                        s_orderList = new Sales_order_list(date1, date2);
                    s_orderList.TopLevel = false;
                    panel_main.Controls.Add(s_orderList);
                    s_orderList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    s_orderList.Show();
                }
                else if (Pur_ListFlag == true)
                {
                    backColor_Change();
                    btn_purchList.BackColor = Color.SteelBlue;
                    salesreturn.Hide();
                    PU_orderList.Hide();
                    Pu_returnList.Hide();
                    S_ReturnList.Hide();
                    pur_return.Hide();
                    salesList.Hide();
                    s_orderList.Hide();
                    purchase.Hide();
                    pur_order.Hide();
                    sales.Hide();
                    sales_order.Hide();
                    Pur_ListFlag = true;
                    sales_ListFlag = false;
                    Pur_orderFlag = false;
                    sales_orderFlag = false;
                    Pur_retnFlag = false;
                    Connection.MyGlobals.global_Flag = false;
                    string date1 = Connection.MyGlobals.Date_From;
                    string date2 = Connection.MyGlobals.Date_To;
                    panel_main.Show();
                    purchase_LIst.Close();
                    if (purchase_LIst == null || purchase_LIst.IsDisposed)
                        purchase_LIst = new PurchaseList(date1, date2);
                    purchase_LIst.TopLevel = false;
                    panel_main.Controls.Add(purchase_LIst);
                    purchase_LIst.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    purchase_LIst.Show();
                }
                else if (sales_ListFlag == true)
                {
                    backColor_Change();
                    btn_Sales_report.BackColor = Color.SteelBlue;
                    purchase_LIst.Hide();
                    salesreturn.Hide(); PU_orderList.Hide();
                    Pu_returnList.Hide();
                    S_ReturnList.Hide();
                    pur_return.Hide();
                    s_orderList.Hide();
                    purchase.Hide(); pur_order.Hide();
                    sales.Hide(); sales_order.Hide();
                    Pur_ListFlag = false;
                    sales_ListFlag = true;
                    Pur_orderFlag = false;
                    sales_orderFlag = false;
                    Pur_retnFlag = false;
                    Connection.MyGlobals.global_Flag = false;
                    string date1 = Connection.MyGlobals.Date_From;
                    string date2 = Connection.MyGlobals.Date_To;
                    panel_main.Show();
                    salesList.Close();
                    if (salesList.IsDisposed)
                        salesList = new Sales_List(date1, date2);
                    salesList.TopLevel = false;
                    panel_main.Controls.Add(salesList);
                    salesList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    salesList.Show();
                }
                else if (Pur_retnFlag == true)
                {
                    backColor_Change();
                    btn_purchRetList.BackColor = Color.SteelBlue;
                    salesreturn.Hide();
                    salesList.Hide();
                    purchase_LIst.Hide();
                    s_orderList.Hide();
                    pur_return.Hide();
                    PU_orderList.Hide();
                    S_ReturnList.Hide();
                    sales.Hide();
                    sales_order.Hide();
                    purchase.Hide();
                    pur_order.Hide();
                    Pur_ListFlag = false;
                    Pur_retnFlag = true;
                    sales_ListFlag = false;
                    Pur_orderFlag = false;
                    sales_orderFlag = false;
                    Connection.MyGlobals.global_Flag = false;
                    string date1 = Connection.MyGlobals.Date_From;
                    string date2 = Connection.MyGlobals.Date_To;
                    panel_main.Show();
                    Pu_returnList.Close();
                    if (Pu_returnList == null || Pu_returnList.IsDisposed)
                        Pu_returnList = new Purchase_Return_List(date1, date2);
                    Pu_returnList.TopLevel = false;
                    panel_main.Controls.Add(Pu_returnList);
                    Pu_returnList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    Pu_returnList.Show();
                }
            }
        }

        private void btn_Stock_Click(object sender, EventArgs e)
        {
            FormHide();
            panel_main.Hide();
            backColor_Change();
            btn_Stock.BackColor = Color.SteelBlue;
            DataTable dt_stock = this.cntrl.search_minimum();
            load_stock(dt_stock);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new StockReport();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                listpatientsearch.DataSource = dtdr;
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStrip1.Width - 360, 37);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

       

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                var form2 = new Practice_Details();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void btn_orderList_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_orderList.BackColor = Color.SteelBlue;
            FormHide();
            Pur_orderFlag = true;
            panel_main.Show();
            PU_orderList.Close();
            if (PU_orderList.IsDisposed)
                PU_orderList = new Purchase_order_list();
            PU_orderList.TopLevel = false;
            panel_main.Controls.Add(PU_orderList);
            PU_orderList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            PU_orderList.Show();
        }

        private void btn_Sales_report_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_Sales_report.BackColor = Color.SteelBlue;
            FormHide();
            sales_ListFlag = true;
            panel_main.Show();
            salesList.Close();
            if (salesList.IsDisposed)
                salesList = new Sales_List();
            salesList.TopLevel = false;
            panel_main.Controls.Add(salesList);
            salesList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            salesList.Show();
        }

        private void btn_SOrderList_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_SOrderList.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            s_orderList.Close();
            if (s_orderList == null || s_orderList.IsDisposed)
                s_orderList = new Sales_order_list();
            s_orderList.TopLevel = false;
            panel_main.Controls.Add(s_orderList);
            s_orderList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            s_orderList.Show();
        }

        private void btn_SalesReturnReport_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_SalesReturnReport.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            S_ReturnList.Close();
            if (S_ReturnList.IsDisposed)
                S_ReturnList = new Sales_ReturnList();
            S_ReturnList.TopLevel = false;
            panel_main.Controls.Add(S_ReturnList);
            S_ReturnList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            S_ReturnList.Show();
        }

        private void btn_purchRetList_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_purchRetList.BackColor = Color.SteelBlue;
            FormHide();
            Pur_retnFlag = true;
            panel_main.Show();
            Pu_returnList.Close();
            if (Pu_returnList == null || Pu_returnList.IsDisposed)
                Pu_returnList = new Purchase_Return_List();
            Pu_returnList.TopLevel = false;
            panel_main.Controls.Add(Pu_returnList);
            Pu_returnList.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Pu_returnList.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }
        private void listpatientsearch_MouseClick_1(object sender, MouseEventArgs e)
        {
                var form2 = new Patient_Profile_Details();
                form2.doctor_id = doctor_id;
                form2.patient_id = listpatientsearch.SelectedValue.ToString();
                listpatientsearch.Visible = false;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                print_setting();
                print();
            }
            catch
            {
                MessageBox.Show("Printing Error..", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void print_setting()
        {
            System.Data.DataTable print = this.cntrl.get_printSettings();
            if (print.Rows.Count > 0)
            {
                combo_topmargin = print.Rows[0][4].ToString();
                combo_leftmargin = print.Rows[0][5].ToString();
                combo_bottommargin = print.Rows[0][6].ToString();
                combo_rightmargin = print.Rows[0][7].ToString();
                combo_paper_size = print.Rows[0][1].ToString();
                combo_footer_topmargin = print.Rows[0][22].ToString();
                rich_fullwidth = print.Rows[0][23].ToString();
                rich_leftsign = print.Rows[0][24].ToString();
                rich_rightsign = print.Rows[0][25].ToString();
                patient_details = print.Rows[0][14].ToString();
                med = print.Rows[0][15].ToString();
                patient = print.Rows[0][16].ToString();
                address = print.Rows[0][17].ToString();
                phone = print.Rows[0][18].ToString();
                blood = print.Rows[0][20].ToString();
                gender = print.Rows[0][21].ToString();
                orientation = print.Rows[0][2].ToString();
                includeheader = print.Rows[0]["include_header"].ToString();
                includelogo = print.Rows[0]["include_logo"].ToString();
            }
        }
    
        public void print()
        {
            string today = DateTime.Now.ToString("d/M/yyyy");
            string message = "Did you want Header on Print?";
            string caption = "Verification";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            string clinicn = "";
            string strclinicname = "";
            string strStreet = "";
            string stremail = "";
            string strwebsite = "";
            string strphone = "";
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                System.Data.DataTable dtp = this.cntrl.get_company_details();
                if (dtp.Rows.Count > 0)
                {
                    clinicn = dtp.Rows[0]["name"].ToString();
                    strclinicname = clinicn.Replace("¤", "'");
                    strphone = dtp.Rows[0]["contact_no"].ToString();
                    strStreet = dtp.Rows[0]["street_address"].ToString();
                    stremail = dtp.Rows[0]["email"].ToString();
                    strwebsite = dtp.Rows[0]["website"].ToString();
                }
            }
            string Apppath = System.IO.Directory.GetCurrentDirectory();
            System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\StockReport.html");
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("<style>");
            sWrite.WriteLine("table { border-collapse: collapse;}");
            sWrite.WriteLine("p.big {line-height: 400%;}");
            sWrite.WriteLine("</style>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<body >");
            sWrite.WriteLine("<div>");
            sWrite.WriteLine("<table align=center width=900 >");
            sWrite.WriteLine("<tr>");
            if (Chk_Minimum.Checked)
            {
                sWrite.WriteLine("<td colspan=5 align='center'><FONT COLOR=black FACE='Segoe UI' SIZE=5>  <b>MINIMUM STOCK REPORT</b> </font></td");
            }
            else
                sWrite.WriteLine("<td colspan=5 align='center' ><FONT COLOR=black FACE='Segoe UI' SIZE=5>  <b>STOCK REPORT</b> </font></td");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=4>   " + strclinicname + "</font></b></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr><td align='left' colspan=5><hr/></td></tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=5 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>Printed Date:" + " " + today + "" + "</font></center></td>");
            if (Chk_Suplier.Checked)
            {
                string suplier = Cmb_Suplier.Text;
                sWrite.WriteLine("<td><align=right FONT COLOR=black FACE='Segoe UI' SIZE=2>Suplier Name :" + suplier + "</font></td>");
            }
            sWrite.WriteLine("</tr>");
            if (DGV_Stock.Rows.Count > 0)
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></th>");
                sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Item Code</b></font></th>");
                sWrite.WriteLine("    <td align='left' width='35%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'SIZE=3>&nbsp;<b>Item Name</b></font></th>");
                sWrite.WriteLine("    <td align='left' width='13%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Purchase Unit</b></font></th>");
                sWrite.WriteLine("    <td align='left' width='25%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Stock</b></font></th>");
                sWrite.WriteLine("</tr>");
                for (int c = 0; c < DGV_Stock.Rows.Count; c++)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_Stock.Rows[c].Cells["SLNO"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_Stock.Rows[c].Cells["item_code"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_Stock.Rows[c].Cells["item_name"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_Stock.Rows[c].Cells["clunit"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'' SIZE=2>&nbsp;" + DGV_Stock.Rows[c].Cells["qty"].Value.ToString() + "</font></th>");
                }
                sWrite.WriteLine("</tr >");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\StockReport.html");
            }
        }
       
        private void btn_purOrder_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_purOrder.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            pur_order.Close();
            if (pur_order == null || pur_order.IsDisposed)
                pur_order = new PurchaseOrder();
            pur_order.TopLevel = false;
            panel_main.Controls.Add(pur_order);
            pur_order.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pur_order.Show();
        }

        private void btn_purchaReturn_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_purchaReturn.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            pur_return.Close();
            if (pur_return == null || pur_return.IsDisposed)
                pur_return = new Purchase_Return();
            pur_return.TopLevel = false;
            panel_main.Controls.Add(pur_return);
            pur_return.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            pur_return.Show();
        }

        private void btn_SalesReturn_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_SalesReturn.BackColor = Color.SteelBlue;
            FormHide();
            panel_main.Show();
            pur_return.Close();
            if (salesreturn == null || salesreturn.IsDisposed)
                salesreturn = new Sales_Return();
            salesreturn.TopLevel = false;
            panel_main.Controls.Add(salesreturn);
            salesreturn.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            salesreturn.Show();
        }

        private void btn_purchList_Click(object sender, EventArgs e)
        {
            backColor_Change();
            btn_purchList.BackColor = Color.SteelBlue;
            FormHide();
            Pur_ListFlag = true;
            panel_main.Show();
            purchase_LIst.Close();
            if (purchase_LIst.IsDisposed)
                purchase_LIst = new PurchaseList();
            purchase_LIst.TopLevel = false;
            panel_main.Controls.Add(purchase_LIst);
            purchase_LIst.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            purchase_LIst.Show();
        }
    }
}
