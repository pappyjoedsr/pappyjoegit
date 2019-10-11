using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class PurchaseOrder : Form
    {
        Purchase_order_controller cntrl=new Purchase_order_controller();
        bool flagedit = false;
        int purch_id1 = 0;
        bool flagPrint = false;
        bool flagSup = false;
        public string Purchase_Order;
        public static string itemcode;
        public static string Itemid;
        int Rowindex = 0;

        public PurchaseOrder()
        {
            InitializeComponent();
        }
        public PurchaseOrder(string item_code, string item_id)
        {
            InitializeComponent();
            itemcode = item_code;
            Itemid = item_id;
        }

        public PurchaseOrder(int purch_id)
        {
            InitializeComponent();
            purch_id1 = purch_id;
            flagedit = true;
        }

        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            if (flagedit == true)
            {
                btnPrint.Visible = true;
                DataTable dt_master = this.cntrl.master_details(purch_id1);
                Load_master_details(dt_master);
                DataTable dt_items = this.cntrl.Load_item_details(purch_id1);
                Load_item_details(dt_items);
                BtnSave.Text = "UPDATE";
            }
            else if (flagPrint == true)
            {
                BtnSave.Enabled = false;
                btn_clear.Enabled = false;
                txtSupplierName.Enabled = false;
                dtpPurchDate.Enabled = false;
                Btn_itemCode.Enabled = false;
                dgvItemData.Enabled = false;
                btnClear.Enabled = false;
                Btn_Add.Enabled = false;
                DataTable dt_master = this.cntrl.master_details(purch_id1);
                Load_master_details(dt_master);
                DataTable dt_items = this.cntrl.Load_item_details(purch_id1);
                Load_item_details(dt_items);
            }
            else
            {
                DocNumber_increment();
            }
        }
        public void Load_master_details(DataTable pur_master)
        {
            if (pur_master.Rows.Count > 0)
            {
                txtPurchOrderNo.Text = pur_master.Rows[0]["Pur_order_no"].ToString();
                dtpPurchDate.Value = Convert.ToDateTime(pur_master.Rows[0]["Purch_order_date"].ToString());
                txtSupplierName.Text = pur_master.Rows[0]["Supplier_Name"].ToString();
                txt_SupplierId.Text = pur_master.Rows[0]["Suppleir_id"].ToString();
            }
        }
        public void Load_item_details(DataTable Purchase)
        {
            decimal totalamt = 0;
            if (Purchase.Rows.Count > 0)
            {
                for (int i = 0; i < Purchase.Rows.Count; i++)
                {
                    dgvItemData.Rows.Add();
                    string temp = Purchase.Rows[i]["Item_code"].ToString();
                    dgvItemData.Rows[i].Cells["Item_Id"].Value = Purchase.Rows[i]["Item_code"].ToString();
                    dgvItemData.Rows[i].Cells["description"].Value = Purchase.Rows[i]["Description"].ToString();
                    dgvItemData.Rows[i].Cells["col_qty"].Value = Purchase.Rows[i]["Qty"].ToString();
                    dgvItemData.Rows[i].Cells["Unit_Cost"].Value = Purchase.Rows[i]["UnitCost"].ToString();
                    dgvItemData.Rows[i].Cells["Amount"].Value = Purchase.Rows[i]["Amount"].ToString();
                    totalamt = totalamt + Convert.ToDecimal(Purchase.Rows[i]["Amount"].ToString());
                }
            }
            txtTotalAmount.Text = totalamt.ToString();
            txtTotal_item.Text = Purchase.Rows.Count.ToString();
        }
        public void DocNumber_increment()
        {
            DataTable Document_Number = this.cntrl.Doc_number();
            if (String.IsNullOrWhiteSpace(Document_Number.Rows[0][0].ToString()))
            {
                txtPurchOrderNo.Text = "1";
            }
            else
            {
                int Count = Convert.ToInt32(Document_Number.Rows[0][0]);
                Count += 1;
                txtPurchOrderNo.Text = Count.ToString();
            }
        }

        private void txtSupplierName_KeyUp(object sender, KeyEventArgs e)
        {
            if (flagSup == false)
            {
                DataTable dt = this.cntrl.Load_supplier_details(txtSupplierName.Text);
                lstbox_Supplier.DataSource = dt;
                lstbox_Supplier.DisplayMember = "Supplier_Name";
                lstbox_Supplier.ValueMember = "Supplier_Code";
                lstbox_Supplier.Show();
                if (txtSupplierName.Text == "")
                {
                    lstbox_Supplier.SelectedIndex = 0;
                    lstbox_Supplier.Focus();
                }
            }
            flagSup = false;
        }

        private void txtSupplierName_Click(object sender, EventArgs e)
        {
            DataTable dt = this.cntrl.Load_all_supplier();
            lstbox_Supplier.DataSource = dt;
            lstbox_Supplier.DisplayMember = "Supplier_Name";
            lstbox_Supplier.ValueMember = "Supplier_Code";
            lstbox_Supplier.Show();
        }

        private void lstbox_Supplier_MouseClick(object sender, MouseEventArgs e)
        {
            string sup_code = lstbox_Supplier.SelectedValue.ToString();
            DataTable dt = this.cntrl.get_supplier_name(sup_code);
            txtSupplierName.Text = dt.Rows[0]["Supplier_Name"].ToString();
            txt_SupplierId.Text = dt.Rows[0]["Supplier_Code"].ToString();
            lstbox_Supplier.Hide();
        }

        private void Btn_itemCode_Click(object sender, EventArgs e)
        {
            Purchase_Order = "Purchase_order";
            var form = new PurchaseItemLIst(Purchase_Order, txt_Itemcode.Text);
            form.ShowDialog();
            txt_Itemcode.Text = itemcode;
            DataTable dtb = this.cntrl.get_itemname(Itemid);
            Load_discription(dtb);
            string dt_max = this.cntrl.max_purNo(Itemid);
            check_purchaseRate(dt_max);
        }
        private void txt_Itemcode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string item = txt_Itemcode.Text;
                if (item != "")
                {
                    Purchase_Order = "Purchase_order";
                    var form = new PurchaseItemLIst(Purchase_Order, item);
                    form.ShowDialog();
                    if (Itemid != "")
                    {
                        DataTable dtb = this.cntrl.get_itemname(Itemid);
                        Load_discription(dtb);
                       string dt_max= this.cntrl.max_purNo(Itemid);
                        check_purchaseRate(dt_max);
                    }
                }
            }
        }
        public void Load_discription(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                txtDescription.Text = dt.Rows[0]["item_name"].ToString();
                txtUnitCost.Text = dt.Rows[0]["Purch_Rate"].ToString();
            }
        }
        public void check_purchaseRate(string dt_PurNum)
        {
            if (Convert.ToInt32(dt_PurNum)>0)
            {
                string dt_Cost = this.cntrl.purchit_details(dt_PurNum, Itemid);
                if (dt_Cost != "" && dt_Cost != "0")
                {
                    if (txtUnitCost.Text == dt_Cost)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Rate is changed, Please update the item table", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
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

        private void txt_qty_Leave(object sender, EventArgs e)
        {
            if (txt_qty.Text == "")
            {
                txt_qty.Text = "0";
            }
        }

        private void txt_qty_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_qty.Text == "")
            {
                txt_qty.Text = "0";
            }
            calculation();
        }
        public void calculation()
        {
            if (txt_qty.Text != "" && txtUnitCost.Text != "")
            {
                decimal amt = 0;
                amt = int.Parse(txt_qty.Text) * decimal.Parse(txtUnitCost.Text);
                txtAmount.Text = amt.ToString();
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

        private void txtUnitCost_Leave(object sender, EventArgs e)
        {
            if (txtUnitCost.Text == "")
            {
                txtUnitCost.Text = "0.0";
            }
        }

        private void txtUnitCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_qty.Text == "")
            {
                txt_qty.Text = "0";
            }
            calculation();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Itemcode.Text != "" && txtDescription.Text != "" && txt_qty.Text != "0")
            {
                if (Btn_Add.Text == "Add")
                {
                    if (check() == 1)
                    {
                        MessageBox.Show("Item already existed..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dgvItemData.Rows.Add(txt_Itemcode.Text, txtDescription.Text, txt_qty.Text, txtUnitCost.Text, txtAmount.Text);
                    }
                }
                if (Btn_Add.Text == "Update") 
                {
                    dgvItemData.Rows[Rowindex].Cells["id"].Value = txt_Itemcode.Text;
                    dgvItemData.Rows[Rowindex].Cells["Item_Id"].Value = txt_Itemcode.Text;
                    dgvItemData.Rows[Rowindex].Cells["description"].Value = txtDescription.Text;
                    dgvItemData.Rows[Rowindex].Cells["col_qty"].Value = txt_qty.Text;
                    dgvItemData.Rows[Rowindex].Cells["Unit_Cost"].Value = txtUnitCost.Text;
                    dgvItemData.Rows[Rowindex].Cells["Amount"].Value = txtAmount.Text;
                    Btn_Add.Text = "Add";
                    btnClear.Visible = false;
                    txt_Itemcode.Enabled = true;
                    Btn_itemCode.Enabled = true;
                }
                clear();
                totalamount_totalqty();
            }
            else
            {
                MessageBox.Show("Mandatory fields should not be empty", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public int check()
        {
            int affecte = 0;
            for (int i = 0; i < dgvItemData.Rows.Count; i++)
            {
                if (dgvItemData.Rows[i].Cells["Item_Id"].Value.ToString() == txt_Itemcode.Text)
                {
                    affecte = 1;
                }
            }
            return affecte;
        }
        public void clear()
        {
            txt_Itemcode.Clear();
            txtDescription.Clear();
            txt_qty.Text = "0";
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.00";
        }
        public void totalamount_totalqty()
        {
            decimal amount = 0;
            if (dgvItemData.Rows.Count > 0)
            {
                txtTotal_item.Text = Convert.ToString(dgvItemData.Rows.Count);
            }
            decimal amount1 = 0;
            foreach (DataGridViewRow row in dgvItemData.Rows)
            {
                if (row.Cells["Amount"].Value != null && row.Cells["Amount"].Value.ToString() != "")
                {
                    amount = Convert.ToDecimal(row.Cells["Amount"].Value.ToString());
                    amount1 = amount1 + amount;
                }
            }
            txtTotalAmount.Text = amount1.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_Itemcode.Clear();
            txtDescription.Clear();
            txt_qty.Text = "0";
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.00";
            btnClear.Visible = false;
            txt_Itemcode.Enabled = true;
            Btn_itemCode.Enabled = true;
            Btn_Add.Text = "Add";
        }

        private void dgvItemData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvItemData.Rows.Count > 0)
            {
                Rowindex = dgvItemData.CurrentRow.Index;
                if (dgvItemData.CurrentCell.OwningColumn.Name == "ItemEdit")
                {
                    txt_Itemcode.Text = dgvItemData.CurrentRow.Cells["Item_Id"].Value.ToString();
                    txtDescription.Text = dgvItemData.CurrentRow.Cells["description"].Value.ToString();
                    txt_qty.Text = dgvItemData.CurrentRow.Cells["col_qty"].Value.ToString();
                    txtUnitCost.Text = dgvItemData.CurrentRow.Cells["Unit_Cost"].Value.ToString();
                    txtAmount.Text = dgvItemData.CurrentRow.Cells["Amount"].Value.ToString();
                    Btn_Add.Text = "Update";
                    btnClear.Visible = true;
                    txt_Itemcode.Enabled = false;
                    Btn_itemCode.Enabled = false;
                }
                if (dgvItemData.CurrentCell.OwningColumn.Name == "Del")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        txtTotal_item.Text = (Convert.ToInt32(txtTotal_item.Text) - 1).ToString();
                        decimal amount = 0, tempamount = 0;
                        amount = Convert.ToDecimal(txtTotalAmount.Text);
                        tempamount = Convert.ToDecimal(dgvItemData.Rows[Rowindex].Cells["Amount"].Value);
                        txtTotalAmount.Text = (amount - tempamount).ToString();
                        dgvItemData.Rows.RemoveAt(Rowindex);
                    }
                }
            }
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalAmount.Text == "0")
            {
                txtTotalAmount.Text = "0.00";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (BtnSave.Text == "SAVE")
            {
                if (txt_SupplierId.Text != "")
                {
                    if (dgvItemData.Rows.Count > 0)
                    {
                        this.cntrl.save_master(txtPurchOrderNo.Text, dtpPurchDate.Value.ToString("yyyy-MM-dd"), txt_SupplierId.Text);
                        foreach (DataGridViewRow row in dgvItemData.Rows)
                        {
                            this.cntrl.save_items(txtPurchOrderNo.Text, row.Cells["Item_Id"].Value.ToString(), row.Cells["description"].Value.ToString(), row.Cells["col_qty"].Value.ToString(), row.Cells["Unit_Cost"].Value.ToString(), row.Cells["Amount"].Value.ToString());
                        }
                        clear();
                        DialogResult res = MessageBox.Show("Data has been successfully saved, Do you want to print...?", "Success",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            print();
                        }
                        else
                        {
                        }
                        dgvItemData.Rows.Clear();
                        DocNumber_increment();
                        txtSupplierName.Text = "";
                        txt_SupplierId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Please Add Items", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select supplier", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (BtnSave.Text == "UPDATE")
            {
                if (txt_SupplierId.Text != "")
                {
                    if (dgvItemData.Rows.Count > 0)
                    {
                        this.cntrl.delete_order(txtPurchOrderNo.Text);
                        this.cntrl.save_master(txtPurchOrderNo.Text,dtpPurchDate.Value.ToString("yyyy-MM-dd"), txt_SupplierId.Text);
                        foreach (DataGridViewRow row in dgvItemData.Rows)
                        {
                            this.cntrl.save_items(txtPurchOrderNo.Text, row.Cells["Item_Id"].Value.ToString(), row.Cells["description"].Value.ToString(), row.Cells["col_qty"].Value.ToString(), row.Cells["Unit_Cost"].Value.ToString(), row.Cells["Amount"].Value.ToString());
                        }
                        clear();
                        DialogResult res = MessageBox.Show("Data updated Successfully,Do you want to print ?", "Success ",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            print();
                        }
                        else
                        {
                        }
                        dgvItemData.Rows.Clear();
                        DocNumber_increment();
                        txtSupplierName.Text = "";
                        txt_SupplierId.Text = "";
                    }
                    BtnSave.Text = "SAVE";
                }
                else
                {
                    MessageBox.Show("Please select supplier", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_Itemcode.Clear();
            txtDescription.Clear();
            txt_qty.Text = "0";
            txtUnitCost.Text = "0.0";
            txtAmount.Text = "0.00";
            txt_SupplierId.Text = "";
            txtSupplierName.Text = "";
            dgvItemData.Rows.Clear();
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
                    DataTable dtp = this.cntrl.companydetails();
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
                StreamWriter sWrite = new StreamWriter(Apppath + "\\PurcahseOrder.html");
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
                sWrite.WriteLine("<table align=center width=900>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=8><left><br><br><FONT COLOR=black FACE='Segoe UI' SIZE=4> PURCHASE ORDER </font></center></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <br><b> " + strclinicname + "</b> </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left'><left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Order Date : </b> " + dtpPurchDate.Value.ToShortDateString() + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Printed Date : </b> " + DateTime.Now.ToString("dd/MM/yyyy") + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align=center width=900>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right' width=80%><FONT COLOR=black FACE='Segoe UI' SIZE=2>   PurchaseOrder No</font></right></td><td width=2%>:&nbsp;&nbsp;</td><td align ='right'   width=18%>" + txtPurchOrderNo.Text + "</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  Supplier Name</font></right></td><td >:&nbsp;&nbsp;</td><td align ='right'>" + txtSupplierName.Text + "</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align=center width=900>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("</tr>");
                if (dgvItemData.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Item Code</font></th>");
                    sWrite.WriteLine("    <td align='left' width='230px' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Description</font></th>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Quantity</font></th>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Unit Cost</font></th>");
                    sWrite.WriteLine("    <td align='right' width='230px' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Amount</font></th>");
                    sWrite.WriteLine("</tr>");
                    while (c < dgvItemData.Rows.Count)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["Item_Id"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["description"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000'  ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["col_qty"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["Unit_Cost"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvItemData.Rows[c].Cells["Amount"].Value.ToString() + "</font></th>");
                        sWrite.WriteLine("</tr>");
                        c++;
                    }
                }
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\PurcahseOrder.html");
            }
        }
    }
}
