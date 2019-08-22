using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Month_Wise_Receipt : Form,Month_Wise_Receipt_interface
    {
        public Month_Wise_Receipt()
        {
            InitializeComponent();
        }
        int c = 0;
        DataTable dtp = new DataTable();
        decimal tax = 0, discount = 0, amount = 0, paid = 0, due = 0,Totaltax = 0, Totaldiscount = 0, Totalamount = 0, Totalpaid = 0, Totaldue = 0;
        public string doctor_id = "", doc_id, ID, date1, date2, checkStr = "0", PathName = "", service, strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
        Month_Wise_Receipt_controller ctrlr;
        public void setController(Month_Wise_Receipt_controller controller)
        {
            ctrlr = controller;
        }
        public void getdocname(DataTable doctor_rs)
        {
            if (doctor_rs.Rows.Count > 0)
            {
                for (int i = 0; i < doctor_rs.Rows.Count; i++)
                {
                    combo_doctors.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                    combo_doctors.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                    combo_doctors.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                }
            }
        }
        public void Get_DoctorId(string dt)
        {
            if (dt!="")
            {
               ID = dt.ToString();
            }
        }
        public void receiptReceivedLoad()
        {
            DgvReceiptReceivedPerMonth.Rows.Clear();
            DgvReceiptReceivedPerMonth.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            DgvReceiptReceivedPerMonth.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvReceiptReceivedPerMonth.EnableHeadersVisualStyles = false;
            string doctor = combo_doctors.Text;
            if (doctor != "All Doctor")
            {
                this.ctrlr.Get_DoctorId(doctor);
                doc_id = ID;
            }
            else
            { doc_id = "0"; }
            
            date1 = dtp1ReceptReceivedPerMonth1.Value.ToString("yyyy-MM-dd");
            date2 = dtp1ReceptReceivedPerMonth2.Value.ToString("yyyy-MM-dd");
            if (doc_id == "0")
            {
                this.ctrlr.mnthrcpt(date1,date2);
            }
            else
            { this.ctrlr.mnthrcpt2(date1, date2, doc_id); }
        }
        public void mnthrcpt(DataTable dtp)
        {
            if (dtp.Rows.Count == 0)
            {
                label_empty.Show();
                label4.Text = "0";
                Lab_Discount.Text = "0.00";
                Lab_tax.Text = "0.00";
                Lab_Amount.Text = "0.00";
                Lab_Paid.Text = "0.00";
                Lab_Due.Text = "0.00";
            }
            else
            {
                label_empty.Hide();
                label4.Text = dtp.Rows.Count.ToString();
                fillDGV_Receipt(dtp, date1, date2);
            }
        }
        public void mnthrcpt2(DataTable dtp)
        {
            if (dtp.Rows.Count == 0)
            {
                label_empty.Show();
                label4.Text = "0";
                Lab_Discount.Text = "0.00";
                Lab_tax.Text = "0.00";
                Lab_Amount.Text = "0.00";
                Lab_Paid.Text = "0.00";
                Lab_Due.Text = "0.00";
            }
            else
            {
                label_empty.Hide();
                label4.Text = dtp.Rows.Count.ToString();
                fillDGV_Receipt(dtp, date1, date2);
            }
        }
        public void getinvdata(DataTable dt_inv)
        {
            for (int i = 0; i < dt_inv.Rows.Count;i++ )
            {
                DgvReceiptReceivedPerMonth.Rows[i].Cells["procedure_name"].Value = service + " (Qty:" + dt_inv.Rows[0]["unit"].ToString() + ")";
                DgvReceiptReceivedPerMonth.Rows[i].Cells["cost"].Value = dt_inv.Rows[0]["Total Cost"].ToString();
                if (dt_inv.Rows[0]["discountin_rs"].ToString() != "0")
                {
                    DgvReceiptReceivedPerMonth.Rows[i].Cells["Discount_insr"].Value = dt_inv.Rows[0]["discountin_rs"].ToString();
                    discount = decimal.Parse(dt_inv.Rows[0]["discountin_rs"].ToString());
                }
                else
                {
                    DgvReceiptReceivedPerMonth.Rows[i].Cells["Discount_insr"].Value = "";
                    discount = 0;
                }
                DgvReceiptReceivedPerMonth.Rows[i].Cells["tax_inrs"].Value = dt_inv.Rows[0]["tax_inrs"].ToString();
                DgvReceiptReceivedPerMonth.Rows[i].Cells["income"].Value = dt_inv.Rows[0]["Total Income"].ToString();
                tax = decimal.Parse(dt_inv.Rows[0]["tax_inrs"].ToString());
                amount = decimal.Parse(dt_inv.Rows[0]["Total Income"].ToString());
            }
        }
        public void fillDGV_Receipt(DataTable dtb_Receipt, string d1, string d2)
        {
            try{
                DgvReceiptReceivedPerMonth.RowCount = 0;
                if (dtb_Receipt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb_Receipt.Rows.Count; i++)
                    {
                        tax = 0; discount = 0; amount = 0; paid = 0; due = 0;
                        Totaltax = 0; Totaldiscount = 0; Totalamount = 0; Totalpaid = 0; Totaldue = 0;
                        DgvReceiptReceivedPerMonth.Rows.Add();
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["slno"].Value = i + 1;
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["Patient_name"].Value = dtb_Receipt.Rows[i]["pt_name"].ToString();
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["invoice_no"].Value = dtb_Receipt.Rows[i]["invoice_no"].ToString();
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["recept_No"].Value = dtb_Receipt.Rows[i]["receipt_no"].ToString();
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["amount_paid"].Value = Convert.ToDecimal(dtb_Receipt.Rows[i]["amount_paid"].ToString()).ToString("##.00");
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["amount_due"].Value = dtb_Receipt.Rows[i]["DUE AFTER PAYMENT"].ToString();
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["mode_of_payment"].Value = dtb_Receipt.Rows[i]["mode_of_payment"].ToString();
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["Payment_date"].Value = Convert.ToDateTime(dtb_Receipt.Rows[i]["payment_date"].ToString()).ToString("yyyy-MM-dd");
                        DgvReceiptReceivedPerMonth.Rows[i].Cells["doctor_name"].Value = dtb_Receipt.Rows[i]["doctor_name"].ToString();
                        service = dtb_Receipt.Rows[i]["procedure_name"].ToString();
                        this.ctrlr.getinvdata(dtb_Receipt.Rows[i]["invoice_no"].ToString(), service);
                        due = decimal.Parse(dtb_Receipt.Rows[i]["DUE AFTER PAYMENT"].ToString());
                        paid = decimal.Parse(dtb_Receipt.Rows[i]["amount_paid"].ToString());
                        Totaltax = Totaltax + tax;
                        Totaldiscount = Totaldiscount + discount;
                        Totalamount = Totalamount + amount;
                        Totalpaid = Totalpaid + paid;
                        Totaldue = Totaldue + due;
                    }
                    Lab_Discount.Text = Convert.ToDecimal(Totaldiscount).ToString("#0.00");
                    Lab_tax.Text = Convert.ToDecimal(Totaltax).ToString("#0.00");
                    Lab_Amount.Text = Convert.ToDecimal(Totalamount).ToString("#0.00");
                    Lab_Paid.Text = Convert.ToDecimal(Totalpaid).ToString("#0.00");
                    Lab_Due.Text = Convert.ToDecimal(Totaldue).ToString("#0.00");
                }
                else
                {
                    Lab_Discount.Text = "0.00";
                    Lab_tax.Text = "0.00";
                    Lab_Amount.Text = "0.00";
                    Lab_Paid.Text = "0.00";
                    Lab_Due.Text = "0.00";
                }
            }
            catch(Exception ex)
            { MessageBox.Show("Data Loading Error", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Month_Wise_Receipt_Load(object sender, EventArgs e)
        {
            combo_doctors.Items.Add("All Doctor");
            combo_doctors.ValueMember = "0";
            combo_doctors.DisplayMember = "All Doctor";
            this.ctrlr.getdocname();
            combo_doctors.SelectedIndex = 0;
            label_empty.Hide();
            dtp1ReceptReceivedPerMonth2.MaxDate = DateTime.Now;
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, 1);
            dtp1ReceptReceivedPerMonth1.Value = date;
            string d1 = dtp1ReceptReceivedPerMonth1.Value.ToString("yyyy-MM-dd");
            string d2 = dtp1ReceptReceivedPerMonth2.Value.ToString("yyyy-MM-dd");
            receiptReceivedLoad();
            DgvReceiptReceivedPerMonth.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerMonth.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn cl in DgvReceiptReceivedPerMonth.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                cl.Width = 100;
            }
        }
        private void Btn_Export_Click(object sender, EventArgs e)
        {
            try{
                if (DgvReceiptReceivedPerMonth.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Per Month Receipt Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = DgvReceiptReceivedPerMonth.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "Month Wise Receipt";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dtp1ReceptReceivedPerMonth1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dtp1ReceptReceivedPerMonth2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < DgvReceiptReceivedPerMonth.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = DgvReceiptReceivedPerMonth.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        int j1 = 6;
                        for (int i = 0; i <= DgvReceiptReceivedPerMonth.Rows.Count; i++)
                        {
                                for (int j = 0; j < DgvReceiptReceivedPerMonth.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = DgvReceiptReceivedPerMonth.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                                j1 = j1 + 1;
                        }
                        ExcelApp.Cells[j1, 9] = "Total";
                        ExcelApp.Cells[j1, 9].BorderAround(true);
                        ExcelApp.Cells[j1, 9].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 9].Font.Size = 10;
                        ExcelApp.Cells[j1, 10] = Lab_tax.Text;
                        ExcelApp.Cells[j1, 10].BorderAround(true);
                        ExcelApp.Cells[j1, 10].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 10].Font.Size = 10;
                        ExcelApp.Cells[j1, 11] = Lab_Discount.Text;
                        ExcelApp.Cells[j1, 11].BorderAround(true);
                        ExcelApp.Cells[j1, 11].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 11].Font.Size = 10;
                        ExcelApp.Cells[j1, 12] = Lab_Amount.Text;
                        ExcelApp.Cells[j1, 12].BorderAround(true);
                        ExcelApp.Cells[j1, 12].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 12].Font.Size = 10;
                        ExcelApp.Cells[j1, 13] = Lab_Paid.Text;
                        ExcelApp.Cells[j1, 13].BorderAround(true);
                        ExcelApp.Cells[j1, 13].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 13].Font.Size = 10;
                        ExcelApp.Cells[j1, 14] = Lab_Due.Text;
                        ExcelApp.Cells[j1, 14].BorderAround(true);
                        ExcelApp.Cells[j1, 14].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 14].Font.Size = 10;
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
            { MessageBox.Show("Data Loading Error", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void combo_doctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiptReceivedLoad();
        }
        private void combo_doctors_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            receiptReceivedLoad();
        }
        public void practicedetails(DataTable dt)
        {
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
        private void btn_print_Click(object sender, EventArgs e)
        {
            try {
                if (DgvReceiptReceivedPerMonth.Rows.Count > 0)
                {
                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);

                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.ctrlr.practicedetails();
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\ReceiptReceivedPerMonths.html");
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
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align=center ><FONT COLOR=black FACE='Segoe UI' SIZE=4> <b>MONTH WISE RECEIPT </b> </font></td");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>   " + strclinicname + "</b></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>   " + strStreet + "</b></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> " + strphone + "</b></font></td>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From: </b>" + dtp1ReceptReceivedPerMonth1.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + dtp1ReceptReceivedPerMonth2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (DgvReceiptReceivedPerMonth.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='4%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Slno.</font></td>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Patient</font></td>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Invoice</font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Receipt</font></td>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor </font></td>");
                        sWrite.WriteLine("    <td align='left' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Procedure </font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Date</font></td>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Mode of Payment</font></td>");
                        sWrite.WriteLine("    <td align='right' width='4%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Cost</font></td>");
                        sWrite.WriteLine("    <td align='right' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Tax</font></td>");
                        sWrite.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Discount</font></td>");
                        sWrite.WriteLine("    <td align='right' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Income</font></td>");
                        sWrite.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Amount Paid</font></td>");
                        sWrite.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Amount Due</font></td>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int j = 0; j < DgvReceiptReceivedPerMonth.Rows.Count; j++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + k + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["Patient_name"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["invoice_no"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["recept_No"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["doctor_name"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["procedure_name"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToDateTime(DgvReceiptReceivedPerMonth.Rows[j].Cells["Payment_date"].Value.ToString()).ToString("dd/MM/yyy") + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["mode_of_payment"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["cost"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["tax_inrs"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["Discount_insr"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE=Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["income"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["amount_paid"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerMonth.Rows[j].Cells["amount_due"].Value.ToString() + "</font></th>");
                            k = k + 1;
                            sWrite.WriteLine("</tr>");
                        }
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
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_tax.Text + "</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Discount.Text + "</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Amount.Text + "</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Paid.Text + "</b></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Due.Text + "</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\ReceiptReceivedPerMonths.html");
                    }
                }
                else
                { MessageBox.Show("No Record found,please change the date and try again!... ", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            { MessageBox.Show("Printing Error", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
