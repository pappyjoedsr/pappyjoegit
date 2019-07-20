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
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class frmAddItems : Form, AddItemInterface
    {
        Additem_model mdl = new Additem_model();
        AddItem_controller cntrl;
        public bool editFlag = false;
        public bool cal_flag = false;
        DataTable dt_ForEditItems = new DataTable();
        public string doctor_id = "";
        string isbatch = "", isTax = "", isOneUnitOnly = "", unit2 = "";
        //int Open_Stock = 0, Current_Stock = 0, FreeStock = 0, PurchRateType = 0, ReorderQty = 0, MinimumStock = 0,; //UnitMF = 0;
        decimal Open_Cost = 0;// CostBase = 0, Sales_Rate = 0, Sales_Rate_min = 0, Sales_Rate_Max = 0, LOWEST_COST = 0, Purch_Rate = 0, Purch_Rate2 = 0, Sales_Rate2 = 0, Sales_Rate_min2 = 0, Sales_Rate_Max2 = 0;
        public static int Item_Id;
        private DataTable dtb;

        public frmAddItems()
        {
            InitializeComponent();
        }

        public frmAddItems(DataTable dtb)
        {
            InitializeComponent();
            dt_ForEditItems = dtb;
            editFlag = true;
        }

        public void SetController(AddItem_controller controller)
        {
            cntrl = controller;
        }
        private void frmAddItems_Load(object sender, EventArgs e)
        {
            try
            {
                BTnClose.Visible = false;
                txt_ItemCode.Enabled = true;
                Fill_combo();
                if (editFlag == true)
                {
                    decimal Unit2_Avg = 0;
                    DataTable dt = this.cntrl.Get_Item_unitmf(dt_ForEditItems.Rows[0]["id"].ToString());//db.table("select id,UnitMF from tbl_ITEMS where item_code='" + dt_ForEditItems.Rows[0]["item_code"].ToString() + "' ");
                    DataTable bt_purNo = this.cntrl.get_PurchNumber(dt_ForEditItems.Rows[0]["id"].ToString());//   db.table("select MAX(PurchNumber)from tbl_PURCHIT where Item_Code='" + dt_ForEditItems.Rows[0]["item_code"].ToString() + "'");
                    DataTable dt_purch = this.cntrl.get_tbl_PURCHIT_details(bt_purNo.Rows[0][0].ToString());//   db.table("select Rate,Unit,UNIT2 from tbl_PURCHIT where PurchNumber='" + bt_purNo.Rows[0][0].ToString() + "'");
                    DataTable dtb_Avg = this.cntrl.Get_PURCHIT_wit_itemid(dt_ForEditItems.Rows[0]["id"].ToString());// db.table("select Qty,Rate,Unit,UNIT2,UnitMF from tbl_PURCHIT where Item_Code='" + dt_ForEditItems.Rows[0]["item_code"].ToString() + "'");
                    Item_Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    if (dt_ForEditItems.Rows.Count > 0)
                    {
                        txt_ItemCode.Enabled = false;
                        txt_ItemName.Text = dt_ForEditItems.Rows[0]["item_name"].ToString();
                        txt_ItemCode.Text = dt_ForEditItems.Rows[0]["item_code"].ToString();
                        Cmb_Manufacture.SelectedValue = Convert.ToInt32(dt_ForEditItems.Rows[0]["manufacturer"].ToString());
                        if (dt_ForEditItems.Rows[0]["Cat_Number"].ToString() != "")
                            Cmb_Category.SelectedValue = Convert.ToInt32(dt_ForEditItems.Rows[0]["Cat_Number"].ToString());
                        txt_Location.Text = dt_ForEditItems.Rows[0]["Location"].ToString();
                        txt_Packing.Text = dt_ForEditItems.Rows[0]["Packing"].ToString();
                        cmb_Unit1.Text = dt_ForEditItems.Rows[0]["Unit1"].ToString();
                        if (dt_ForEditItems.Rows[0]["OneUnitOnly"].ToString() == "True")
                        {
                            chk_OneUnitOnly.Checked = true;
                            inVisible_Controls();
                        }
                        else
                        {
                            chk_OneUnitOnly.Checked = false;
                            Visible_Controls();
                            cmb_unit2.Text = dt_ForEditItems.Rows[0]["Unit2"].ToString();
                        }
                        if (dt_ForEditItems.Rows[0]["ISBatch"].ToString() == "True")
                        {
                            Chk_HavebatchNo.Checked = true;
                        }
                        else
                        {
                            Chk_HavebatchNo.Checked = false;
                        }
                        if (dt_ForEditItems.Rows[0]["Taxable"].ToString() == "True")
                        {
                            Chk_Taxable.Checked = true;
                        }
                        else
                        {
                            Chk_Taxable.Checked = false;
                        }
                        txt_reorderStockQty.Text = dt_ForEditItems.Rows[0]["ReorderQty"].ToString();
                        txt_minimumStockforSale.Text = dt_ForEditItems.Rows[0]["MinimumStock"].ToString();
                        txt_PurchaseRate.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Purch_Rate"].ToString()).ToString("##.00");
                        txt_PurchRate2.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Purch_Rate2"].ToString()).ToString("##.00");
                        txt_SalesRate2.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Sales_Rate2"].ToString()).ToString("##.00");
                        txt_SalesRateMin2.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Sales_Rate_min2"].ToString()).ToString("##.00");
                        txt_SalesRateMax2.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Sales_Rate_Max2"].ToString()).ToString("##.00");
                        txt_UnitMF.Text = Convert.ToInt32(dt_ForEditItems.Rows[0]["UnitMF"].ToString()).ToString();
                        txt_CostBase.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["CostBase"].ToString()).ToString("##.00");
                        txt_SalesRate.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Sales_Rate"].ToString()).ToString("##.00");
                        txt_SalesRateMin.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Sales_Rate_min"].ToString()).ToString("##.00");
                        txt_SalesRateMax.Text = Convert.ToDecimal(dt_ForEditItems.Rows[0]["Sales_Rate_Max"].ToString()).ToString("##.00");
                        if (Convert.ToDecimal(dt_ForEditItems.Rows[0]["UnitMF"].ToString()) > 0)
                        {
                            Unit2_Avg = Convert.ToDecimal(txt_CostBase.Text) * Convert.ToDecimal(dt_ForEditItems.Rows[0]["UnitMF"].ToString());
                            txt_unit2Avg_PurchRate.Text = Unit2_Avg.ToString("#.0");
                        }
                        save.Text = "UPDATE";
                        BTnClose.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Fill_combo()
        {
            Cmb_Category.DataSource = null;
            cmb_Unit1.DataSource = null;
            cmb_unit2.DataSource = null;
            Cmb_Manufacture.DataSource = null;
            DataTable dt_Category = this.cntrl.fill_category();
            if (dt_Category.Rows.Count > 0)
            {
                Cmb_Category.DataSource = dt_Category;
                Cmb_Category.DisplayMember = "Name";
                Cmb_Category.ValueMember = "id";
                Cmb_Category.SelectedIndex = 0;
            }
            DataTable dt_Manufacture = this.cntrl.fill_manufacture();
            if (dt_Manufacture.Rows.Count > 0)
            {
                Cmb_Manufacture.DataSource = dt_Manufacture;
                Cmb_Manufacture.DisplayMember = "manufacturer";
                Cmb_Manufacture.ValueMember = "id";
                Cmb_Manufacture.SelectedIndex = 0;
            }
            DataTable dt_Units = this.cntrl.fill_unit();
            if (dt_Units.Rows.Count > 0)
            {
                cmb_Unit1.DataSource = dt_Units;
                cmb_Unit1.DisplayMember = "Name";
                cmb_Unit1.ValueMember = "id";
                cmb_Unit1.SelectedIndex = 0;
            }
            DataTable dt_Units2 = this.cntrl.fill_unit();
            if (dt_Units2.Rows.Count > 0)
            {
                cmb_unit2.DataSource = dt_Units2;
                cmb_unit2.DisplayMember = "Name";
                cmb_unit2.ValueMember = "id";
                cmb_unit2.SelectedIndex = 0;
            }
           
        }
        public void clear()
        {
            txt_ItemName.Text = "";
            txt_ItemCode.Text = "";
            Cmb_Manufacture.Text = "";
            Cmb_Category.Text = "";
            txt_Location.Text = "";
            txt_Packing.Text = "";
            chk_OneUnitOnly.Checked = true;
            Chk_HavebatchNo.Checked = true;
            Chk_Taxable.Checked = false;
            txt_reorderStockQty.Text = "";
            txt_minimumStockforSale.Text = "";
            txt_CostBase.Text = "";
            txt_SalesRate.Text = "";
            txt_SalesRateMin.Text = "";
            txt_SalesRateMax.Text = "";
            txt_PurchaseRate.Text = "";
            txt_SalesRate2.Text = "";
            txt_SalesRateMin2.Text = "";
            txt_SalesRateMax2.Text = "";
            txt_UnitMF.Text = "";
            txt_PurchRate2.Text = "";
            txt_Unit1Dealer2.Text = "";
            txt_unit1Retailmin2.Text = "";
            txt_unit1Retailmax2.Text = "";
            txt_Unit2Dealer2.Text = "";
            txt_unit2Retailmin2.Text = "";
            txt_unit2Retailmax2.Text = "";
            txt_unit2Avg_PurchRate.Text = "";
        }
        public void Visible_Controls()
        {
            Lab_Unit2.Visible = true;
            cmb_unit2.Visible = true;
            Lab_whereunit2.Visible = true;
            txt_UnitMF.Visible = true;
            Lab_isunit1.Visible = true;
            Lab_Unit2_1.Visible = true;
            Lab_Unit2LastPurch.Visible = true;
            LabAvg.Visible = true;
            txt_unit2Avg_PurchRate.Visible = true;
            txt_PurchRate2.Visible = true;
            txt_SalesRate2.Visible = true;
            txt_Unit2Dealer2.Visible = true;
            txt_SalesRateMin2.Visible = true;
            txt_unit2Retailmin2.Visible = true;
            txt_SalesRateMax2.Visible = true;
            txt_unit2Retailmax2.Visible = true;
        }
        public void inVisible_Controls()
        {
            Lab_Unit2.Visible = false;
            cmb_unit2.Visible = false;
            Lab_whereunit2.Visible = false;
            txt_UnitMF.Visible = false;
            Lab_isunit1.Visible = false;
            Lab_Unit2_1.Visible = false;
            Lab_Unit2LastPurch.Visible = false;
            LabAvg.Visible = false;
            txt_unit2Avg_PurchRate.Visible = false;
            txt_PurchRate2.Visible = false;
            txt_SalesRate2.Visible = false;
            txt_Unit2Dealer2.Visible = false;
            txt_SalesRateMin2.Visible = false;
            txt_unit2Retailmin2.Visible = false;
            txt_SalesRateMax2.Visible = false;
            txt_unit2Retailmax2.Visible = false;
        }
        public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
                { e.Handled = true; }
                TextBox txtDecimal = sender as TextBox;
                if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_CostBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_SalesRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_SalesRateMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_SalesRateMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_PurchaseRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_Unit1Dealer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_unit1Retailmin2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_unit1Retailmax2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_unit2Avg_PurchRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_SalesRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_SalesRateMin2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_SalesRateMax2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_PurchRate2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_Unit2Dealer2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_unit2Retailmin2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_unit2Retailmax2_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void txt_PurchRate2_TextChanged(object sender, EventArgs e)
        {
            if (txt_PurchRate2.Text == "")
            {
                txt_SalesRate2.Text = "";
                txt_SalesRateMin2.Text = "";
                txt_SalesRateMax2.Text = "";
                txt_Unit2Dealer2.Text = "";
                txt_unit2Retailmin2.Text = "";
                txt_unit2Retailmax2.Text = "";
            }
        }

        private void txt_SalesRate2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value1 = 0, value2 = 0;
                if (!string.IsNullOrWhiteSpace(txt_PurchRate2.Text) && !string.IsNullOrWhiteSpace(txt_SalesRate2.Text))
                {
                    if (Convert.ToDecimal(txt_PurchRate2.Text) > 0 && Convert.ToDecimal(txt_SalesRate2.Text) > 0)
                    {
                        value1 = Convert.ToDecimal(txt_SalesRate2.Text) - Convert.ToDecimal(txt_PurchRate2.Text);
                        value2 = (value1 / Convert.ToDecimal(txt_PurchRate2.Text)) * 100;
                        txt_Unit2Dealer2.Text = value2.ToString("##.00");
                    }
                }
                else
                {
                    txt_Unit2Dealer2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_SalesRateMin2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value1 = 0, value2 = 0;
                if (!string.IsNullOrWhiteSpace(txt_PurchRate2.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMin2.Text))
                {
                    if (Convert.ToDecimal(txt_PurchRate2.Text) > 0 && Convert.ToDecimal(txt_SalesRateMin2.Text) > 0)
                    {
                        value1 = Convert.ToDecimal(txt_SalesRateMin2.Text) - Convert.ToDecimal(txt_PurchRate2.Text);
                        value2 = (value1 / Convert.ToDecimal(txt_PurchRate2.Text)) * 100;
                        txt_unit2Retailmin2.Text = value2.ToString("##.00");
                    }
                }
                else
                {
                    txt_unit2Retailmin2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_SalesRateMax2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal value1 = 0; decimal value2 = 0;
                if (!string.IsNullOrWhiteSpace(txt_PurchRate2.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMax2.Text))
                {
                    if (Convert.ToDecimal(txt_PurchRate2.Text) > 0 && Convert.ToDecimal(txt_SalesRateMax2.Text) > 0)
                    {
                        value1 = Convert.ToDecimal(txt_SalesRateMax2.Text) - Convert.ToDecimal(txt_PurchRate2.Text);
                        value2 = (value1 / Convert.ToDecimal(txt_PurchRate2.Text)) * 100;
                        txt_unit2Retailmax2.Text = value2.ToString("##.00");
                    }
                }
                else
                {
                    txt_unit2Retailmax2.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void txt_PurchaseRate_TextChanged(object sender, EventArgs e)
        {
            if (txt_PurchaseRate.Text == "")
            {
                txt_CostBase.Text = "";
                txt_SalesRate.Text = "";
                txt_SalesRateMin.Text = "";
                txt_SalesRateMax.Text = "";
                txt_Unit1Dealer2.Text = "";
                txt_unit1Retailmin2.Text = "";
                txt_unit1Retailmax2.Text = "";
            }
        }

        private void txt_SalesRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_SalesRate.Text != ".")
                {
                    decimal value1 = 0, value2 = 0;
                    if (cal_flag == true)
                    {
                        if (txt_CostBase.Text != "")
                        {
                            value1 = Convert.ToDecimal(txt_CostBase.Text);
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(txt_PurchaseRate.Text) && !string.IsNullOrWhiteSpace(txt_SalesRate.Text))
                    {
                        value1 = Convert.ToDecimal(txt_SalesRate.Text) - Convert.ToDecimal(txt_PurchaseRate.Text);
                        value2 = (value1 / Convert.ToDecimal(txt_PurchaseRate.Text)) * 100;
                        txt_Unit1Dealer2.Text = value2.ToString("##.00");
                    }
                    else
                    {
                        txt_Unit1Dealer2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_SalesRateMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txt_SalesRateMin.Text != ".")
                {
                    decimal value1 = 0, value2 = 0;
                    if (!string.IsNullOrWhiteSpace(txt_PurchaseRate.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMin.Text))
                    {
                        value1 = Convert.ToDecimal(txt_SalesRateMin.Text) - Convert.ToDecimal(txt_PurchaseRate.Text);
                        value2 = (value1 / Convert.ToDecimal(txt_PurchaseRate.Text)) * 100;
                        txt_unit1Retailmin2.Text = value2.ToString("##.00");
                    }
                    else
                    {
                        txt_unit1Retailmin2.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void txt_SalesRateMax_TextChanged(object sender, EventArgs e)
        {
            if (txt_SalesRateMax.Text != ".")
            {
                decimal value1 = 0, value2 = 0;
                if (!string.IsNullOrWhiteSpace(txt_PurchaseRate.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMax.Text))
                {
                    value1 = Convert.ToDecimal(txt_SalesRateMax.Text) - Convert.ToDecimal(txt_PurchaseRate.Text);
                    value2 = (value1 / Convert.ToDecimal(txt_PurchaseRate.Text)) * 100;
                    txt_unit1Retailmax2.Text = value2.ToString("##.00");
                }
                else
                {
                    txt_unit1Retailmax2.Text = "";
                }
            }
        }

        private void chk_OneUnitOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_OneUnitOnly.Checked == true)
            {
                label32.Visible = false;
                Lab_Unit2.Visible = false;
                cmb_unit2.Visible = false;
                Lab_whereunit2.Visible = false;
                txt_UnitMF.Visible = false;
                Lab_isunit1.Visible = false;
                Lab_Unit2_1.Visible = false;
                Lab_Unit2LastPurch.Visible = false;
                LabAvg.Visible = false;
                txt_unit2Avg_PurchRate.Visible = false;
                txt_PurchRate2.Visible = false;
                txt_SalesRate2.Visible = false;
                txt_Unit2Dealer2.Visible = false;
                txt_SalesRateMin2.Visible = false;
                txt_unit2Retailmin2.Visible = false;
                txt_SalesRateMax2.Visible = false;
                txt_unit2Retailmax2.Visible = false;
                btn_Addunit1.Visible = false;
                textBox6.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false; 

                groupBox1.Size = new Size(795, 134);
                groupBox2.Size = new Size(792, 127);
                groupBox2.Location = new Point(6, 140);
                pnlbottom.Location = new Point(9, 269);
                this.Height = 518;
            }
            else
            {
                groupBox1.Size = new Size(795, 167);
                groupBox2.Size = new Size(792, 195);
                groupBox2.Location = new Point(6, 178);
                pnlbottom.Location = new Point(9, 375);
                this.Height = 606;

                label32.Visible = true;
                Lab_Unit2.Visible = true;
                cmb_unit2.Visible = true;
                Lab_whereunit2.Visible = true;
                txt_UnitMF.Visible = true;
                Lab_isunit1.Visible = true;
                Lab_Unit2_1.Visible = true;
                Lab_Unit2LastPurch.Visible = true;
                LabAvg.Visible = true;
                txt_unit2Avg_PurchRate.Visible = true;
                txt_PurchRate2.Visible = true;
                txt_SalesRate2.Visible = true;
                txt_Unit2Dealer2.Visible = true;
                txt_SalesRateMin2.Visible = true;
                txt_unit2Retailmin2.Visible = true;
                txt_SalesRateMax2.Visible = true;
                txt_unit2Retailmax2.Visible = true;
                btn_Addunit1.Visible = true;
                textBox6.Visible = true;
                textBox9.Visible = true;
                textBox10.Visible = true;
            }
        }

        private void txt_minimumStockforSale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_reorderStockQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_UnitMF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public string ItemCode
        {
            get { return this.txt_ItemCode.Text; }
            set { this.txt_ItemCode.Text = value; }
        }
        public string ItemName
        {
            get { return this.txt_ItemName.Text; }
            set { this.txt_ItemName.Text = value; }
        }
        public string Packing
        {
            get { return this.txt_Packing.Text; }
            set { this.txt_Packing.Text = value; }
        }
        public string Location
        {
            get { return this.txt_Location.Text; }
            set { this.txt_Location.Text = value; }
        }
        public string Category
        {
            get { return this.Cmb_Category.SelectedValue.ToString(); }
            set { this.Cmb_Category.SelectedValue = value; }
        }
        public string Manufacture
        {
            get { return Cmb_Manufacture.SelectedValue.ToString(); }
            set { this.Cmb_Manufacture.SelectedValue = value; }
        }
        public string PUnit
        {
            get { return this.cmb_Unit1.Text; }
            set { this.cmb_Unit1.Text = value; }
        }
        public string SUnit
        {
            get {
                if(chk_OneUnitOnly.Checked==true)
                {
                    return "null";
                }
                else
                {
                    return this.cmb_unit2.Text;
                }
                }
            set {
                if (chk_OneUnitOnly.Checked == true)
                {
                    cmb_unit2.Text = "";
                }
                else
                {
                    this.cmb_unit2.Text = value;
                }
                 }
        }
        public int UnitMF
        {
            get { return Convert.ToInt32( this.txt_UnitMF.Text); }
            set { this.txt_UnitMF.Text = value.ToString(); }
        }
        public decimal Sales_Rate
        {
            get { return Convert.ToDecimal(txt_SalesRate.Text); }
            set { this.txt_SalesRate.Text = value.ToString(); }
        }
        public decimal Sales_Rate_min
        {
            get { return Convert.ToDecimal(txt_SalesRateMin.Text); }
            set { this.txt_SalesRateMin.Text = value.ToString(); }
        }
        public decimal Sales_Rate_Max
        {
            get { return Convert.ToDecimal(txt_SalesRateMax.Text); }
            set { this.txt_SalesRateMax.Text = value.ToString(); }
        }
        public decimal Sales_Rate2
        {
            get { return Convert.ToDecimal(txt_SalesRate2.Text); }
            set { this.txt_SalesRate2.Text = value.ToString(); }
        }
        public decimal Sales_Rate_min2
        {
            get { return Convert.ToDecimal(txt_SalesRateMin2.Text); }
            set { this.txt_SalesRateMin2.Text = value.ToString(); }
        }
        public decimal Sales_Rate_Max2
        {
            get { return Convert.ToDecimal(txt_SalesRateMax2.Text); }
            set { this.txt_SalesRateMax2.Text = value.ToString(); }
        }
        public decimal CostBase
        {
            get { return Convert.ToDecimal(txt_CostBase.Text); }
            set { this.txt_CostBase.Text = value.ToString(); }
        }
        public decimal Purch_Rate2
        {
            get { return Convert.ToDecimal(txt_PurchRate2.Text); }
            set { this.txt_PurchRate2.Text = value.ToString(); }
        }
        public decimal Purch_Rate
        {
            get { return Convert.ToDecimal(txt_PurchaseRate.Text); }
            set { this.txt_PurchaseRate.Text = value.ToString(); }
        }
        public int ReorderQty
        {
            get { return Convert.ToInt32(txt_reorderStockQty.Text); }
            set { this.txt_reorderStockQty.Text = value.ToString(); }
        }
        public int MinimumStock
        {
            get { return Convert.ToInt32(txt_minimumStockforSale.Text); }
            set { this.txt_minimumStockforSale.Text = value.ToString(); }
        }
        public bool ISBatch
        {
            get
            {
                if (Chk_HavebatchNo.Checked == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if(value==true)
                {
                    Chk_HavebatchNo.Checked = true;
                }
                else
                {
                    Chk_HavebatchNo.Checked = false;
                }
            }
        }
        public bool ISTax
        {
            get
            {
                if (Chk_Taxable.Checked == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                if (value == true)
                {
                    Chk_Taxable.Checked = true;
                }
                else
                {
                    Chk_Taxable.Checked = false;
                }
            }
        }
        public string type
        {
            get { return this.cmbdrugtype.Text; }
            set { this.cmbdrugtype.Text = value; }
        }
        public string strength
        {
            get { return this.txtstrength.Text; }
            set { this.txtstrength.Text = value; }
        }
        public string strength_gr
        {
            get { return this.cmbstrength.Text; }
            set { this.cmbstrength.Text = value; }
        }
        public string instructions
        {
            get { return this.txtinstructions.Text; }
            set { this.txtinstructions.Text = value; }
        }
        private void txt_UnitMF_Click(object sender, EventArgs e)
        {
            if (txt_UnitMF.Text == "0")
            {
                txt_UnitMF.Text = "";
            }
        }

        private void txt_UnitMF_Leave(object sender, EventArgs e)
        {
            if (txt_UnitMF.Text == "")
            {
                txt_UnitMF.Text = "0";
            }
        }

        private void txt_SalesRate_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_PurchaseRate.Text) && !string.IsNullOrWhiteSpace(txt_SalesRate.Text))
            {
                if (Convert.ToDecimal(txt_SalesRate.Text) >= Convert.ToDecimal(txt_PurchaseRate.Text))
                {
                }
                else
                {
                    MessageBox.Show("Please enter dealer rate  grater than the purchase rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_SalesRate.Text = "";
                    txt_SalesRate.Focus();
                }
            }
        }

        private void txt_SalesRateMin_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_PurchaseRate.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMin.Text))
            {
                if (Convert.ToDecimal(txt_SalesRateMin.Text) >= Convert.ToDecimal(txt_PurchaseRate.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please enter Minimum sales rate  grater than the purchase rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_SalesRateMin.Text = "";
                    txt_SalesRateMin.Focus();
                }
            }
        }

        private void txt_SalesRateMax_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_PurchaseRate.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMax.Text))
            {
                if (Convert.ToDecimal(txt_SalesRateMax.Text) >= Convert.ToDecimal(txt_PurchaseRate.Text))
                {

                }
                else
                {
                    MessageBox.Show("Please enter maximum sales rate  grater than the purchase rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_SalesRateMax.Text = "";
                    txt_SalesRateMax.Focus();
                }
            }
        }

        private void txt_SalesRate2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_PurchRate2.Text) && !string.IsNullOrWhiteSpace(txt_SalesRate2.Text))
            {
                if (Convert.ToDecimal(txt_PurchRate2.Text) > 0 && Convert.ToDecimal(txt_SalesRate2.Text) > 0)
                {
                    if (Convert.ToDecimal(txt_SalesRate2.Text) >= Convert.ToDecimal(txt_PurchRate2.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please enter dealer rate  grater than the purchase rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_SalesRate2.Text = "";
                        txt_SalesRate2.Focus();
                    }
                }
            }
        }

        private void txt_SalesRateMin2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_PurchRate2.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMin2.Text))
            {
                if (Convert.ToDecimal(txt_PurchRate2.Text) > 0 && Convert.ToDecimal(txt_SalesRateMin2.Text) > 0)
                {
                    if (Convert.ToDecimal(txt_SalesRateMin2.Text) >= Convert.ToDecimal(txt_PurchRate2.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please enter minimum sales rate  grater than the purchase rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_SalesRateMin2.Text = "";
                        txt_SalesRateMin2.Focus();
                    }
                }
            }
        }

        private void txt_SalesRateMax2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_PurchRate2.Text) && !string.IsNullOrWhiteSpace(txt_SalesRateMax2.Text))
            {
                if (Convert.ToDecimal(txt_PurchRate2.Text) > 0 && Convert.ToDecimal(txt_SalesRateMax2.Text) > 0)
                {
                    if (Convert.ToDecimal(txt_SalesRateMax2.Text) >= Convert.ToDecimal(txt_PurchRate2.Text))
                    {

                    }
                    else
                    {
                        MessageBox.Show("Please enter maximum sales rate  grater than the purchase rate ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_SalesRateMax2.Text = "";
                        txt_SalesRateMax2.Focus();
                    }
                }
            }
        }

        private void BTnClose_Click(object sender, EventArgs e)
        {
            clear();
            save.Text = "SAVE";
            txt_ItemCode.Enabled = true;
            BTnClose.Visible = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            var form2 = new FrmItemList();
            ItemList_Controller cntrl = new ItemList_Controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddCategeory fr = new frmAddCategeory();
            add_category_controller cntrl = new add_category_controller(fr);
            fr.ShowDialog();
            DataTable dt_Category = this.cntrl.fill_category();
            if (dt_Category.Rows.Count > 0)
            {
                Cmb_Category.DataSource = dt_Category;
                Cmb_Category.DisplayMember = "Name";
                Cmb_Category.ValueMember = "id";
                Cmb_Category.SelectedIndex = 0;
            }
        }

        private void btn_Addunit_Click(object sender, EventArgs e)
        {
            frmAddUnits frm = new frmAddUnits();
            add_unit_controller cntrl = new add_unit_controller(frm);
            frm.ShowDialog();
            DataTable dtb = this.cntrl.fill_unit();
            if (dtb.Rows.Count > 0)
            {
                cmb_Unit1.DataSource = dtb;
                cmb_Unit1.SelectedIndex = 0;
            }
        }

        private void btn_Addunit1_Click(object sender, EventArgs e)
        {
            frmAddUnits frm = new frmAddUnits();
            add_unit_controller cntrl = new add_unit_controller(frm);
            frm.ShowDialog();
            DataTable dtb = this.cntrl.fill_unit();
            if (dtb.Rows.Count > 0)
            {
                cmb_Unit1.DataSource = dtb;
                cmb_Unit1.SelectedIndex = 0;
            }
        }

        private void chkprescription_CheckedChanged(object sender, EventArgs e)
        {

            if (chkprescription.Checked == true)
            {
                pnlprescription.Enabled = true;
            }
            else
            {
                pnlprescription.Enabled = false;
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                checkNull();
                if (txt_ItemCode.Text != "" && txt_ItemName.Text != "")
                {
                    if (txt_PurchaseRate.Text == "" || txt_SalesRate.Text == "" || txt_SalesRateMin.Text == "" || txt_SalesRateMax.Text == "")
                    {
                        MessageBox.Show("Must add Purchase units", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (chk_OneUnitOnly.Checked == true)
                    {
                        isOneUnitOnly = "True";
                        UnitMF = 0;
                    }
                    else
                    {
                        isOneUnitOnly = "False";
                        if (Convert.ToInt32(txt_UnitMF.Text) == 0)
                        {
                            MessageBox.Show("Must add sales units", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_UnitMF.Focus();
                            return;
                        }
                        else
                            UnitMF = Convert.ToInt32(txt_UnitMF.Text);
                        if (txt_PurchRate2.Text == "" || txt_SalesRate2.Text == "" || txt_SalesRateMin2.Text == "" || txt_SalesRateMax2.Text == "")
                        {
                            MessageBox.Show("Must add Sales units", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    if (save.Text == "SAVE")
                    {
                        if (itemcheck() == 1)
                        {
                            MessageBox.Show("The item code already existed !..", "Duplication encountded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        int i = this.cntrl.Save_data(isOneUnitOnly);
                        if (i > 0)
                        {
                            if (chkprescription.Checked == true)
                            {
                                string rs_item = this.cntrl.get_max_itemid();// db.table("SELECT MAX(id) FROM tbl_ITEMS order by id");
                                string itemid = rs_item;// rs_item.Rows[0][0].ToString();
                                this.cntrl.savedrugtable(itemid);
                            }
                            MessageBox.Show("Item added sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                        }
                    }
                    else
                    {
                        int i = this.cntrl.update_data(isOneUnitOnly,Item_Id);
                        if (i > 0)
                        {
                            if (chkprescription.Checked == true)
                            {
                                DataTable rs_item = this.cntrl.get_drugid(Item_Id.ToString());// db.table("SELECT id FROM tbl_adddrug where inventory_id='" + Item_Id + "'");
                                if (rs_item.Rows.Count > 0)
                                {
                                    this.cntrl.update_drug(Item_Id.ToString());//  db.execute("update tbl_adddrug set name='" + txt_ItemName.Text + "',type='" + cmbdrugtype.Text + "',strength='" + cmbstrength.Text + "',strength_gr='" + txtstrength.Text + "',instructions='" + txtinstructions.Text + "' where inventory_id='" + Item_Id + "'");
                                }
                                else
                                {
                                    DataTable rs_additem = this.cntrl.select_id_drug();// db.table("SELECT id FROM tbl_adddrug where name='" + txt_ItemName.Text + "' and type='" + cmbdrugtype.Text + "' and strength='" + cmbstrength.Text + "' and strength_gr='" + txtstrength.Text + "'");
                                    if (rs_additem.Rows.Count > 0)
                                    {
                                        this.cntrl.update(Item_Id.ToString(), rs_additem.Rows[0]["id"].ToString());// db.execute("update tbl_adddrug set name='" + txt_ItemName.Text + "',type='" + cmbdrugtype.Text + "',strength='" + cmbstrength.Text + "',strength_gr='" + txtstrength.Text + "',instructions='" + txtinstructions.Text + "', inventory_id='" + Item_Id + "'  where id='" + rs_additem.Rows[0]["id"].ToString() + "'");
                                    }
                                    else
                                    {
                                        this.cntrl.savedrugtable(Item_Id.ToString());//  db.execute("insert into tbl_adddrug(name,type,strength,strength_gr,instructions,display_status,inventory_id) values('" + txt_ItemName.Text + "','" + cmbdrugtype.Text + "','" + cmbstrength.Text + "','" + txtstrength.Text + "','" + txtinstructions.Text + "','Yes','" + Item_Id + "')");
                                    }
                                }
                            }
                            else
                            {
                                this.cntrl.update_inventryid(Item_Id.ToString());// db.execute("update tbl_adddrug set inventory_id='0' where inventory_id='" + Item_Id + "'");
                            }
                            MessageBox.Show("Item updated sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear();
                            save.Text = "SAVE";
                            BTnClose.Visible = false;
                            Chk_HavebatchNo.Checked = true;
                        }
                    }
                    Fill_combo();
                }
                else
                {
                    MessageBox.Show("Enter the Item Code and Item Name !", "Empty field occured", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        public void checkNull()
        {
            if (string.IsNullOrWhiteSpace(txt_reorderStockQty.Text))
            {
                txt_reorderStockQty.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_minimumStockforSale.Text))
            {
                txt_minimumStockforSale.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_CostBase.Text))
            {
                txt_CostBase.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_SalesRateMin2.Text))
            {
                txt_SalesRateMin2.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_SalesRate2.Text))
            {
                txt_SalesRate2.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_SalesRateMax2.Text))
            {
                txt_SalesRateMax2.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_UnitMF.Text))
            {
                txt_UnitMF.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txt_PurchRate2.Text))
            {
                txt_PurchRate2.Text = "0";
            }
        }

        public int itemcheck()
        {
            int affected = 0; 
            DataTable dtb = this.cntrl.load_itemcode();
            if (dtb.Rows.Count > 0)
            {
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    for (int j = 0; j < dtb.Columns.Count; j++)
                    {
                        if (dtb.Rows[i][j].ToString() != null && txt_ItemCode.Text == dtb.Rows[i][j].ToString())
                        {
                            affected = 1;
                        }
                    }
                }
            }
            return affected;
        }

       





    }
}
