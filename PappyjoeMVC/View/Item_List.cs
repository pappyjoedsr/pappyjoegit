using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Item_List : Form
    {
        public static bool Item_flag = false;
        Item_List_Controller cntrl = new Item_List_Controller();
        Supplier suplier = new Supplier();
        Manufacture manufacture = new Manufacture();
        public string doctor_id = "", pat_id = "";
        public Item_List()
        {
            InitializeComponent();
        }

        public Item_List(string formname)
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
            string dt_doctor = cntrl.Get_DoctorName(doctor_id);
            if (dt_doctor != "")
            {
                toolStripTextDoctor.Text = "Logged In As : " + dt_doctor.ToString();
            }
            btn_ItemList.BackColor = Color.SteelBlue;
            panel_main.Hide();
            //Cmb_Manufacture.Items.Add("All Manufacture");
            //Cmb_Manufacture.ValueMember = "0";
            //Cmb_Manufacture.DisplayMember = "All Manufacture";
            DataTable dt = this.cntrl.Fill_manufactureCombo();
            Fill_ManufactureCombo(dt);
            string manufacture = Cmb_Manufacture.SelectedIndex.ToString();
            DataTable dt_items = this.cntrl.Fill_Grid();
            Fill_Grid(dt_items);
            Dgv_Product.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Product.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Product.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            Dgv_Product.EnableHeadersVisualStyles = false;
        }
        public void Fill_ManufactureCombo(DataTable gp_rs)
        {
            Cmb_Manufacture.Items.Clear();
            Cmb_Manufacture.Items.Add("All Manufacture");
            Cmb_Manufacture.ValueMember = "0";
            Cmb_Manufacture.DisplayMember = "All Manufacture";
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
            DataTable dt = this.cntrl.Fill_manufactureCombo();
            Fill_ManufactureCombo(dt);
            DataTable dt_items = this.cntrl.Fill_Grid();
            Fill_Grid(dt_items);
        }

        private void Cmb_Manufacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Manufacture.SelectedIndex > 0)
            {
                string selectedValue;
                selectedValue = Cmb_Manufacture.Text;
                DataTable dtb = this.cntrl.Get_manufacturename(selectedValue);
                Get_manufacturename(dtb);
            }
            else
            {
                DataTable dt_items = this.cntrl.Fill_Grid();
                Fill_Grid(dt_items);
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
                    DataTable dtb = this.cntrl.Search(txt_search.Text);
                    Fill_Grid(dtb);
                }
                else
                {
                    string manufactr = Cmb_Manufacture.Text;
                    if (manufactr != "")
                    {
                        DataTable dt_manu = this.cntrl.manufactureName(manufactr);
                        DataTable dt = this.cntrl.Search_wit_manufacture(txt_search.Text, dt_manu.Rows[0][0].ToString());
                        Fill_Grid(dt);
                    }
                }
            }
            else
            {
                if (Cmb_Manufacture.SelectedIndex <= 0)
                {
                    DataTable dt_items = this.cntrl.Fill_Grid();
                    Fill_Grid(dt_items);
                }
            }
        }

        private void btn_AddNewItem_Click(object sender, EventArgs e)
        {
            var form2 = new Add_Drug();
            form2.ShowDialog();
            form2.Dispose();
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
                            var form2 = new Add_Drug(dtb);
                            form2.ShowDialog();
                            form2.Dispose();
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
                                    DataTable dtb = this.cntrl.Fill_Grid();
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
                DataTable dtb = this.cntrl.Fill_Grid();
                Fill_Grid(dtb);
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            var form2 = new Practice_Details();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
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
                listpatientsearch.Location = new Point(toolStripTextBox1.Width + 765, 32);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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
            form2.patient_id = pat_id;
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

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }

        //private void Cmb_Manufacture_Click(object sender, EventArgs e)
        //{
        //    //DataTable dt = this.cntrl.Fill_manufactureCombo();
        //    //Fill_ManufactureCombo(dt);
        //}

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.privilge_for_inventory(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            else
            {
                var form2 = new StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

    }
}

