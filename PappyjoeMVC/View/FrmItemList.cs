using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class FrmItemList : Form
    {
        public static bool Item_flag = false;
        ItemList_Controller cntrl = new ItemList_Controller();
        frmSupplier suplier = new frmSupplier();
        FrmManufacture manufacture = new FrmManufacture();
        public string doctor_id = "";
        public FrmItemList()
        {
            InitializeComponent();
        }

        public FrmItemList(string formname)
        {
            InitializeComponent();
            this.formname = formname;
        }

        private void FrmItemList_Load(object sender, EventArgs e)
        {
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            DataTable dtb = cntrl.Get_CompanyNAme();
            if (dtb.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = dtb.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
            string dt_doctor = cntrl.Get_DoctorId(doctor_id);
            if (dt_doctor != "")
            {
                toolStripTextDoctor.Text = "Logged In As : " + dt_doctor.ToString();
            }
            btn_ItemList.BackColor = Color.SteelBlue;
            panel_main.Hide();
            Cmb_Manufacture.Items.Add("All Manufacture");
            Cmb_Manufacture.ValueMember = "0";
            Cmb_Manufacture.DisplayMember = "All Manufacture";
            DataTable dt_manu = this.cntrl.Fill_manufactureCombo();
            Fill_ManufactureCombo(dt_manu);
            string manufacture = Cmb_Manufacture.SelectedIndex.ToString();
            DataTable dt_fill = this.cntrl.Fill_Grid();
            Fill_Grid(dtb);
            Dgv_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Product.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Product.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            Dgv_Product.EnableHeadersVisualStyles = false;
        }
        public void Fill_ManufactureCombo(DataTable gp_rs)
        {
            if (gp_rs.Rows.Count > 0)
            {
                for (int i = 0; i < gp_rs.Rows.Count; i++)
                {
                    Cmb_Manufacture.Items.Add(gp_rs.Rows[i]["manufacturer"].ToString());
                    Cmb_Manufacture.ValueMember = gp_rs.Rows[i]["id"].ToString();
                    Cmb_Manufacture.DisplayMember = gp_rs.Rows[i]["manufacturer"].ToString();
                }
                Cmb_Manufacture.SelectedIndex = 0;
            }
        }

        public void Fill_Grid(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                Dgv_Product.RowCount = 0;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    Dgv_Product.Rows.Add();
                    Dgv_Product.Rows[i].Cells["id"].Value = dtb.Rows[i]["id"].ToString();
                    Dgv_Product.Rows[i].Cells["Colid"].Value = dtb.Rows[i]["item_code"].ToString();
                    Dgv_Product.Rows[i].Cells["Colname"].Value = dtb.Rows[i]["item_name"].ToString();
                    Dgv_Product.Rows[i].Cells["colStock"].Value = dtb.Rows[i]["Stock"].ToString();
                    Dgv_Product.Rows[i].Cells["ColEdit"].Value = PappyjoeMVC.Properties.Resources.editicon;
                    Dgv_Product.Rows[i].Cells["ColDelete"].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                }
            }
            else
            {
                Dgv_Product.Rows.Clear();
            }
        }

        private void btn_ItemList_Click(object sender, EventArgs e)
        {
            btn_ItemList.BackColor = Color.SteelBlue;
            btn_Manufacture.BackColor = Color.DodgerBlue;
            btnSuplier.BackColor = Color.DodgerBlue;
            manufacture.Hide();
            suplier.Hide();
            panel_main.Hide();
            DataTable dtb = this.cntrl.Fill_Grid();
            Fill_Grid(dtb);
        }

        private void Cmb_Manufacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Manufacture.SelectedIndex > 0)
            {
                string selectedValue;
                selectedValue = Cmb_Manufacture.Text;
               DataTable dtb= this.cntrl.Get_manufacturename(selectedValue);
                Get_manufacturename(dtb);
            }
            else
            {
                DataTable dtb = this.cntrl.Fill_Grid();
                Fill_Grid(dtb);
            }
        }

        public void Get_manufacturename(DataTable dt_manu)
        {
            if (dt_manu.Rows.Count > 0)
            {
                DataTable dtb = this.cntrl.get_items_with_manufacture(Convert.ToInt32(dt_manu.Rows[0][0].ToString()));
                Fill_Grid(dtb);
            }
        }
        public static bool search_flag = false;
        private string formname;

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            search_flag = true;
            if (txt_search.Text != "")
            {
                if (Cmb_Manufacture.SelectedIndex <= 0)
                {
                   DataTable dtb= this.cntrl.Search(txt_search.Text);
                    Fill_Grid(dtb);
                }
                else
                {
                    string manufactr = Cmb_Manufacture.Text;
                    if (manufactr != "")
                    {
                        DataTable dt_manu = this.cntrl.manufactureName(manufactr);
                        DataTable dtb= this.cntrl.Search_wit_manufacture(txt_search.Text, dt_manu.Rows[0][0].ToString());
                        Fill_Grid(dtb);
                    }
                }
            }
            else
            {
                if (Cmb_Manufacture.SelectedIndex <= 0)
                {
                    DataTable dtb = this.cntrl.Fill_Grid();
                    Fill_Grid(dtb);
                }
            }
        }

        private void btn_AddNewItem_Click(object sender, EventArgs e)
        {
            var form2 = new frmAddDrug();
            form2.ShowDialog();
        }

        private void btn_Manufacture_Click(object sender, EventArgs e)
        {
            btn_Manufacture.BackColor = Color.SteelBlue;
            btn_ItemList.BackColor = Color.DodgerBlue;
            btnSuplier.BackColor = Color.DodgerBlue;
            suplier.Hide();
            panel_main.Show();
            manufacture.Close();
            if (manufacture == null || manufacture.IsDisposed)
                manufacture = new FrmManufacture();
            manufacture.TopLevel = false;
            panel_main.Controls.Add(manufacture);
            manufacture.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            manufacture.Show();
        }

        private void btnSuplier_Click(object sender, EventArgs e)
        {
            btnSuplier.BackColor = Color.SteelBlue;
            btn_ItemList.BackColor = Color.DodgerBlue;
            btn_Manufacture.BackColor = Color.DodgerBlue;
            manufacture.Hide(); suplier.Hide();
            panel_main.Show();
            suplier.Close();
            if (suplier == null || suplier.IsDisposed)
                suplier = new frmSupplier();
            suplier.TopLevel = false;
            panel_main.Controls.Add(suplier);
            suplier.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            suplier.Show();
        }

        private void Dgv_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (Dgv_Product.Rows.Count > 0)
                {
                    string itemcode = Dgv_Product.CurrentRow.Cells["id"].Value.ToString();
                    if (Dgv_Product.CurrentCell.OwningColumn.Name == "ColEdit")
                    {
                        DataTable dtb = this.cntrl.Get_itemDetails(itemcode);
                        if (dtb.Rows.Count > 0)
                        {
                            var form2 = new frmAddDrug();
                            form2.ShowDialog();
                        }
                    }
                    else if (Dgv_Product.CurrentCell.OwningColumn.Name == "ColDelete")
                    {
                        int i = 0;
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            int index = Dgv_Product.CurrentRow.Index;
                            DataTable dt = this.cntrl.get_stock(itemcode);
                            if (dt.Rows[0][0].ToString() != "")
                            {
                                if (Convert.ToDecimal(dt.Rows[0][0].ToString()) > 0)
                                {
                                    MessageBox.Show("Item have stock", "Can't Delete..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else
                                {
                                }
                            }
                            else
                            {
                                i = this.cntrl.delete(itemcode);
                                if (i > 0)
                                {
                                    Dgv_Product.Rows.RemoveAt(index);
                                   DataTable dtb= this.cntrl.Fill_Grid();
                                    Fill_Grid(dtb);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void FrmItemList_Activated(object sender, EventArgs e)
        {
            if (search_flag == false)
            {
              DataTable dtb=  this.cntrl.Fill_Grid();
                Fill_Grid(dtb);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            var form2 = new PracticeDetails();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}
