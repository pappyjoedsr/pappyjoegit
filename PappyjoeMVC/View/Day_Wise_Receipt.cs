using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Day_Wise_Receipt : Form
    {
        public Day_Wise_Receipt()
        {
            InitializeComponent();
        }
        public bool cmb_flag = false;
        DataTable dtb_Receipt = new DataTable();
        decimal tax = 0,cost=0, discount = 0, amount = 0, paid = 0, due = 0,Totaltax = 0, Totaldiscount = 0, Totalamount = 0, Totalpaid = 0, Totaldue = 0;
        public string doctor_id = "",service="", qty = "", DrctName = "", checkStr = "0", PathName = "", strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
        Day_Wise_Receipt_controller ctrlr=new Day_Wise_Receipt_controller();
        private void Day_Wise_Receipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(0, 0);
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                cmb_flag = true;
                cmb_doctor.Items.Add("All Doctor");
                cmb_doctor.ValueMember = "0";
                cmb_doctor.DisplayMember = "All Doctor";
                DataTable doctor_rs = this.ctrlr.getdocname();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        cmb_doctor.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        cmb_doctor.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        cmb_doctor.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
                cmb_doctor.SelectedIndex = 0;
                string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
                string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
                DataTable dtb = this.ctrlr.ReceiptReceivedPerDay(date1, date2);
                fillDGV_Receipt(dtb, date1, date2);
                DGV_Receipt.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                DGV_Receipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_Receipt.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                DGV_Receipt.EnableHeadersVisualStyles = false;
                DGV_Receipt.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Receipt.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Receipt.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                foreach (DataGridViewColumn cl in DGV_Receipt.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    //cl.Width = 100;
                }
                cmb_flag = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getinvdata(DataTable dt_inv)
        {
            try
            {
                for (int i = 0; i < dt_inv.Rows.Count; i++)
                {

                    DGV_Receipt.Rows[i].Cells["ColTotao_Cost"].Value = dt_inv.Rows[0]["Total Cost"].ToString();
                    cost = Convert.ToDecimal(dt_inv.Rows[0]["Total Cost"].ToString());
                    if (dt_inv.Rows[0]["discountin_rs"].ToString() != "0")
                    {
                        DGV_Receipt.Rows[i].Cells["COlDIS"].Value = dt_inv.Rows[0]["discountin_rs"].ToString();
                        discount = decimal.Parse(dt_inv.Rows[0]["discountin_rs"].ToString());
                    }
                    else
                    {
                        DGV_Receipt.Rows[i].Cells["COlDIS"].Value = 0;
                        discount = 0;
                    }
                    DGV_Receipt.Rows[i].Cells["ColTax"].Value = dt_inv.Rows[0]["tax_inrs"].ToString();
                    DGV_Receipt.Rows[i].Cells["ColTotalIncome"].Value = dt_inv.Rows[0]["Total Income"].ToString();
                    qty = dt_inv.Rows[i]["unit"].ToString();
                    tax = decimal.Parse(dt_inv.Rows[0]["tax_inrs"].ToString());
                    amount = decimal.Parse(dt_inv.Rows[0]["Total Income"].ToString());
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void fillDGV_Receipt(DataTable dtb_Receipt, string d1, string d2)
        {
            try
            {
                DGV_Receipt.RowCount = 0;
                if (dtb_Receipt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb_Receipt.Rows.Count; i++)
                    {
                        tax = 0; discount = 0; amount = 0; paid = 0; due = 0;
                        Totaltax = 0; Totaldiscount = 0; Totalamount = 0; Totalpaid = 0; Totaldue = 0;
                        DGV_Receipt.Rows.Add();
                        DGV_Receipt.Rows[i].Cells["ColSLNo"].Value = i + 1;
                        DGV_Receipt.Rows[i].Cells["ColPtName"].Value = dtb_Receipt.Rows[i]["pt_name"].ToString();
                        DGV_Receipt.Rows[i].Cells["ColInv"].Value = dtb_Receipt.Rows[i]["invoice_no"].ToString();
                        DGV_Receipt.Rows[i].Cells["ColReceipt"].Value = dtb_Receipt.Rows[i]["receipt_no"].ToString();
                        DGV_Receipt.Rows[i].Cells["ColAmountPaid"].Value = dtb_Receipt.Rows[i]["amount_paid"].ToString();
                        DGV_Receipt.Rows[i].Cells["ColTotalDue"].Value = dtb_Receipt.Rows[i]["Total Amount Due"].ToString();
                        DGV_Receipt.Rows[i].Cells["ColModeofpayment"].Value = dtb_Receipt.Rows[i]["mode_of_payment"].ToString();
                        DGV_Receipt.Rows[i].Cells["DATE"].Value = Convert.ToDateTime(dtb_Receipt.Rows[i]["payment_date"].ToString()).ToString("dd-MM-yyyy");
                        DGV_Receipt.Rows[i].Cells["ColDrName"].Value = dtb_Receipt.Rows[i]["doctor_name"].ToString();
                        DataTable inv=this.ctrlr.getinvdata(dtb_Receipt.Rows[i]["invoice_no"].ToString(), dtb_Receipt.Rows[i]["procedure_name"].ToString());
                        getinvdata(inv);
                        service = dtb_Receipt.Rows[i]["procedure_name"].ToString();
                        DGV_Receipt.Rows[i].Cells["ColProcedure"].Value = service + " (Qty:" + qty + ")";
                        DGV_Receipt.Rows[i].Cells["ColTax"].Value = tax;
                        DGV_Receipt.Rows[i].Cells["ColTotalIncome"].Value = amount;
                        DGV_Receipt.Rows[i].Cells["COlDIS"].Value = discount;
                        DGV_Receipt.Rows[i].Cells["ColTotao_Cost"].Value = cost;
                        due = decimal.Parse(dtb_Receipt.Rows[i]["Total Amount Due"].ToString());
                        paid = decimal.Parse(dtb_Receipt.Rows[i]["amount_paid"].ToString());
                        
                    }
                    int count = DGV_Receipt.Rows.Count;
                    Lab_Total.Text = count.ToString();
                    for (int j = 0; j < count; j++)
                    {
                        Totaltax = Totaltax +Convert.ToDecimal(DGV_Receipt.Rows[j].Cells["ColTax"].Value);
                        Totaldiscount = Totaldiscount +Convert.ToDecimal(DGV_Receipt.Rows[j].Cells["COlDIS"].Value);
                        Totalamount = Totalamount +Convert.ToDecimal(DGV_Receipt.Rows[j].Cells["ColTotalIncome"].Value);
                        Totalpaid = Totalpaid +Convert.ToDecimal(DGV_Receipt.Rows[j].Cells["ColAmountPaid"].Value);
                        Totaldue = Totaldue +Convert.ToDecimal(DGV_Receipt.Rows[j].Cells["ColTotalDue"].Value);
                    }
                    Lab_Discount.Text = Convert.ToDecimal(Totaldiscount).ToString("#0.00");
                    Lab_tax.Text = Convert.ToDecimal(Totaltax).ToString("#0.00");
                    Lab_Amount.Text = Convert.ToDecimal(Totalamount).ToString("#0.00");
                    Lab_Paid.Text = Convert.ToDecimal(Totalpaid).ToString("#0.00");
                    Lab_Due.Text = Convert.ToDecimal(Totaldue).ToString("#0.00");
                    DGV_Receipt.Columns["ColTotalDue"].Visible = true;
                    Lab_Msg.Hide();
                }
                else
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                    Lab_Total.Text = "0";
                    Lab_Discount.Text = "0.00";
                    Lab_tax.Text = "0.00";
                    Lab_Amount.Text = "0.00";
                    Lab_Paid.Text = "0.00";
                    Lab_Due.Text = "0.00";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Show_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
                string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
                if (cmb_doctor.SelectedIndex == 0)
                {
                    DataTable dtb = this.ctrlr.ReceiptReceivedPerDay(date1, date2);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else if (cmb_doctor.SelectedIndex > 0)
                {
                    string doctor = cmb_doctor.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr.ReceiptReceivedPerDay_DoctrWise(date1, date2, doctor);
                    fillDGV_Receipt(dtb, date1, date2);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void cmb_doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
                string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
                if (cmb_flag == false)
                {
                    if (cmb_doctor.SelectedIndex == 0)
                    {
                        DataTable dtb = this.ctrlr.ReceiptReceivedPerDay(date1, date2);
                        fillDGV_Receipt(dtb, date1, date2);
                    }
                    else if (cmb_doctor.SelectedIndex > 0)
                    {
                        DrctName = cmb_doctor.SelectedItem.ToString();
                        DataTable dtb = this.ctrlr.ReceiptReceivedPerDay_DoctrWise(date1, date2, DrctName);
                        fillDGV_Receipt(dtb, date1, date2);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Chk_RemoveAmountDue_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_RemoveAmountDue.Checked)
            {
                DGV_Receipt.Columns["ColTotalDue"].Visible = false;
                DGV_Receipt.Columns["ColAmountPaid"].Width =190;
                DGV_Receipt.Columns["ColTotalIncome"].Width = 130;
            }
            else
            { DGV_Receipt.Columns["ColTotalDue"].Visible = true;
                DGV_Receipt.Columns["ColAmountPaid"].Width = 120;
                DGV_Receipt.Columns["ColTotalIncome"].Width = 100;
            }
        }
       
        private void btnprint_Click(object sender, EventArgs e)
        {
            try {
                if (DGV_Receipt.Rows.Count > 0)
                {
                    DataTable tbl = DGV_Receipt.DataSource as DataTable;
                    string frdate = DTP_From.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DTP_From.Value.Month);
                    string fryear = DTP_From.Value.Year.ToString();
                    string todate = Dtp_ReceiptTO.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Dtp_ReceiptTO.Value.Month);
                    string toyear = Dtp_ReceiptTO.Value.Year.ToString();
                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dt=this.ctrlr.practicedetails();
                            if (dt.Rows.Count > 0)
                            {
                                clinicn = dt.Rows[0]["name"].ToString();
                                strclinicname = clinicn.Replace("¤", "'");
                                strphone = dt.Rows[0]["contact_no"].ToString();
                                strStreet = dt.Rows[0]["street_address"].ToString();
                                stremail = dt.Rows[0]["email"].ToString();
                                strwebsite = dt.Rows[0]["website"].ToString();
                            }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\ReceiptReceivedPerDay.html");
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
                    sWrite.WriteLine("<th colspan=13 align='center'> <FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b> DAY WISE RECEIPT</b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=13 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<th colspan=13 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=13 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>From:</b>  " + DTP_From.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b>  " + Dtp_ReceiptTO.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date :</b>  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (DGV_Receipt.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='4%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Slno.</font></td>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Patient</font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Invoice</font></td>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Receipt</font></td>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor</font></td>");
                        sWrite.WriteLine("    <td align='left' width='13%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Procedure</font></td>");
                        sWrite.WriteLine("    <td align='Center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Date</font></td>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Mode of Payment</font></td>");
                        sWrite.WriteLine("    <td align='right' width='4%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Cost</font></td>");
                        sWrite.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Discount</font></td>");
                        sWrite.WriteLine("    <td align='right' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Tax</font></td>");
                        sWrite.WriteLine("    <td align='right' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Total Amount</font></td>");
                        sWrite.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Amount Paid</font></td>");
                        if (Chk_RemoveAmountDue.Checked)
                        { }
                        else
                        {
                            sWrite.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Amount Due</font></td>");
                        }
                        sWrite.WriteLine("</tr>");
                        try
                        {
                            for (int j = 0; j < DGV_Receipt.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColSLNo"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColPtName"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColInv"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColReceipt"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColDrName"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColProcedure"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["DATE"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColModeofpayment"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColTotao_Cost"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["COlDIS"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColTax"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColTotalIncome"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToInt32(DGV_Receipt.Rows[j].Cells["ColAmountPaid"].Value.ToString()).ToString("#0.00") + "</font></td>");
                                if (Chk_RemoveAmountDue.Checked)
                                { }
                                else
                                {
                                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Sego UI' SIZE=2>" + DGV_Receipt.Rows[j].Cells["ColTotalDue"].Value.ToString() + "</font></td>");
                                }
                                sWrite.WriteLine("</tr>");
                            }
                        }
                        catch { }
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Total</b></font></td>");
                            sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Discount.Text + "</b></font></td>");
                            sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_tax.Text + "</b></font></td>");
                            sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Amount.Text + "</b></font></td>");
                            sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Paid.Text + "</b></font></td>");
                            if (Chk_RemoveAmountDue.Checked)
                            { }
                            else
                            {
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Due.Text + "</b></font></td>");
                            }
                            sWrite.WriteLine("</tr>");                                                                                                                          
                        }
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\ReceiptReceivedPerDay.html");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            try {
                if (DGV_Receipt.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Day Wise Receipt Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        if (Chk_RemoveAmountDue.Checked == true)
                        {
                            int count = 13;
                            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        }
                        else if (Chk_RemoveAmountDue.Checked == false)
                        {
                            int count = 14;
                            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        }
                        if (cmb_doctor.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "DAY WISE RECEIPT (All DOCTOR)";
                        }
                        else if (cmb_doctor.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = " DAY WISE RECEIPT OF DR." + DrctName + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = DTP_From.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = Dtp_ReceiptTO.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < DGV_Receipt.Columns.Count + 1; i++)
                        {
                                if (i == 14)
                                {
                                    if (Chk_RemoveAmountDue.Checked == false)
                                    {
                                        ExcelApp.Cells[5, i] = DGV_Receipt.Columns[i - 1].HeaderText;
                                        ExcelApp.Cells[5, i].ColumnWidth = 25;
                                        ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                                        ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                        ExcelApp.Cells[5, i].Font.Size = 10;
                                        ExcelApp.Cells[5, i].Font.Name = "Arial";
                                        ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                                        ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                    }
                                }
                                else
                                {
                                    ExcelApp.Cells[5, i] = DGV_Receipt.Columns[i - 1].HeaderText;
                                    ExcelApp.Cells[5, i].ColumnWidth = 25;
                                    ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                                    ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[5, i].Font.Size = 10;
                                    ExcelApp.Cells[5, i].Font.Name = "Arial";
                                    ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                                    ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                }
                            }
                        int j1 = 5;
                        for (int i = 0; i <= DGV_Receipt.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < DGV_Receipt.Columns.Count; j++)
                                {
                                    if (j == 13)
                                    {
                                        if (Chk_RemoveAmountDue.Checked == false)
                                        {
                                            ExcelApp.Cells[i + 6, j + 1] = DGV_Receipt.Rows[i].Cells[j].Value.ToString();
                                            ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                            ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                            ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                        }
                                    }
                                    else
                                    {
                                        ExcelApp.Cells[i + 6, j + 1] = DGV_Receipt.Rows[i].Cells[j].Value.ToString();
                                        ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                        ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                        ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                    }
                                }
                                j1 = j1 + 1;
                            }
                            catch { }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        checkStr = "1";
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       