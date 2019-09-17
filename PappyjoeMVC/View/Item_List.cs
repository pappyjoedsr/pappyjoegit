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
    public partial class Item_List : Form
    {
        public static bool Item_flag = false;
        Item_List_Controller cntrl=new Item_List_Controller();
        Supplier suplier = new Supplier();
        Manufacture manufacture = new Manufacture();
        public string doctor_id = "";
        public Item_List()
        {
            InitializeComponent();
        }

        public Item_List(string formname)
        {
            InitializeComponent();
            this.formname = formname;
        }
        public void Setcontroller(Item_List_Controller controller)
        {
            cntrl = controller;
        }
        private void FrmItemList_Load(object sender, EventArgs e)
        {
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.Global_Variables.Version;
            DataTable dtb = cntrl.Get_CompanyNAme();
            if(dtb.Rows.Count>0)
            {
                string clinicn = "";
                clinicn = dtb.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
            string dt_doctor = cntrl.Get_DoctorId(doctor_id);
            if (dt_doctor!="")
            {
                toolStripTextDoctor.Text = "Logged In As : " + dt_doctor.ToString();
            }
            btn_ItemList.BackColor = Color.SteelBlue;
            panel_main.Hide();
            Cmb_Manufacture.Items.Add("All Manufacture");
            Cmb_Manufacture.ValueMember = "0";
            Cmb_Manufacture.DisplayMember = "All Manufacture";
            cntrl.Fill_manufactureCombo();
            string manufacture = Cmb_Manufacture.SelectedIndex.ToString();
            cntrl.Fill_Grid();
            Dgv_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Product.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Product.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            Dgv_Product.EnableHeadersVisualStyles = false;
        }
        public void Fill_ManufactureCombo(DataTable gp_rs)
        {
            if(gp_rs.Rows.Count>0)
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
            cntrl.Fill_Grid();
        }

        private void Cmb_Manufacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Manufacture.SelectedIndex > 0)
            {
                string selectedValue;
                selectedValue = Cmb_Manufacture.Text;
                this.cntrl.Get_manufacturename(selectedValue);
            }
            else
            {
                cntrl.Fill_Grid();
            }
        }

        public void Get_manufacturename(DataTable dt_manu)
        {
            if (dt_manu.Rows.Count > 0)
            {
                this.cntrl.get_items_with_manufacture(Convert.ToInt32(dt_manu.Rows[0][0].ToString()));
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
                    this.cntrl.Search(txt_search.Text);
                }
                else
                {
                    string manufactr = Cmb_Manufacture.Text;
                    if (manufactr != "")
                    {
                        DataTable dt_manu = this.cntrl.manufactureName(manufactr);
                        this.cntrl.Search_wit_manufacture(txt_search.Text, dt_manu.Rows[0][0].ToString());
                    }
                }
            }
            else
            {
                if (Cmb_Manufacture.SelectedIndex <= 0)
                {
                   this. cntrl.Fill_Grid();
                }
            }
        }

        private void btn_AddNewItem_Click(object sender, EventArgs e)
        {
            var form2 = new Add_Drug();
            //AddItem_controller controller = new AddItem_controller(form2);
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
                manufacture = new Manufacture();
            manufacture.TopLevel = false;
            panel_main.Controls.Add(manufacture);
            manufacture.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //Manufacture_controller cntrl = new Manufacture_controller(manufacture);
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
                suplier = new Supplier();
            suplier.TopLevel = false;
            panel_main.Controls.Add(suplier);
            suplier.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //supplier_controller cntrl = new supplier_controller(suplier);
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
                            var form2 = new Add_Drug();
                            //AddItem_controller controller = new AddItem_controller(form2);
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
                            DataTable dt =this.cntrl. get_stock(itemcode);
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
                                    this.cntrl.Fill_Grid();
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
                this.cntrl.Fill_Grid();
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            var form2 = new Practice_Details();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
           
        }
    }
}
