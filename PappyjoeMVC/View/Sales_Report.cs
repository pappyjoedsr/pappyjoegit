using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Sales_Report : Form
    {
        public Sales_Report()
        {
            InitializeComponent();
        }
        int num = 1;
        decimal total_disc,Total_Amount;
        Sales_Report_controller ctrlr=new Sales_Report_controller();
        public string dateFrom = "", dateTo = "", strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "",checkStr = "0",PathName = "";
        private void DGV_SALES_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int inv_num = Convert.ToInt32(DGV_SALES.CurrentRow.Cells["InvNumber"].Value.ToString());
                var form2 = new PappyjoeMVC.View.SalesReport_Items(inv_num, dptMonthly_From.Value.ToString("MM/dd/yyyy"), dptMonthly_To.Value.ToString("MM/dd/yyyy"));
                form2.ShowDialog();
                form2.Dispose();
            }
        }
        private void BTNClose_Click(object sender, EventArgs e)
        {
            var form2 = new Sales_Report();
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try {
                if (DGV_SALES.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Sales Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = DGV_SALES.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "SALES REPORT";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dptMonthly_From.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dptMonthly_To.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < DGV_SALES.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = DGV_SALES.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= DGV_SALES.Rows.Count; i++)
                        {
                            try{
                                for (int j = 0; j < DGV_SALES.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = DGV_SALES.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch{}
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        checkStr = "1";
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found, Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void salesinv(DataTable dtb_inv)
        {
            if (dtb_inv.Rows.Count > 0){
                fill_grid(dtb_inv);
                Lab_Msg.Visible = false;
            }
            else {
                int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Visible = true;
                Lab_Msg.Location = new Point(272, 246);
                DGV_SALES.Rows.Clear();
                Txttotaldiscount.Text = "0.00";
                Txtgrandtotal.Text = "0.00";
                Txt_totalInvoice.Text = "0.00";
            }
        }
        private void Sales_Report_Load(object sender, EventArgs e)
        {
            try
            {
                dateFrom = dptMonthly_From.Value.ToString("yyyy-MM-dd");
                dateTo = dptMonthly_To.Value.ToString("yyyy-MM-dd");
                DataTable dt = this.ctrlr.salesinv(dateFrom, dateTo);
                salesinv(dt);
                DGV_SALES.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                DGV_SALES.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_SALES.EnableHeadersVisualStyles = false;
                DGV_SALES.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_SALES.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                DGV_SALES.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_SALES.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_SALES.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_SALES.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                foreach (DataGridViewColumn cl in DGV_SALES.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    cl.Width = 110;
                }
                dptMonthly_From.Focus();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try {
                if (DGV_SALES.Rows.Count > 0) {
                    string frdate = dptMonthly_From.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dptMonthly_From.Value.Month);
                    string fryear = dptMonthly_From.Value.Year.ToString();
                    string todate = dptMonthly_To.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dptMonthly_To.Value.Month);
                    string toyear = dptMonthly_To.Value.Year.ToString();
                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                            DataTable dtp=this.ctrlr.practicedetails();
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
                    System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\SalesReport.html");
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
                    sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=5>  <b> SALES REPORT</b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> " + strclinicname + "</b> </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strStreet + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strphone + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='8'><hr/></td></tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>From :</b>" + " " + dptMonthly_From.Value.ToString("dd/MM/yyyy") + " </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>To :</b>" + "   " + dptMonthly_To.Value.ToString("dd/MM/yyyy") + "</font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=7><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font><left></td>");
                    sWrite.WriteLine("</tr>");
                    if (DGV_SALES.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>&nbsp;Slno.</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>&nbsp;Invoice No</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;Invoice Date</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp; Customer Id</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;Customer Name</b></font></th>");
                        sWrite.WriteLine("    <td align='right' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Discount (%)&nbsp;</b></font></th>");
                        sWrite.WriteLine("    <td align='right' width='25%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Total Amount</b>&nbsp;</font></th>");
                        sWrite.WriteLine("</tr>");
                        for (int c = 0; c < DGV_SALES.Rows.Count; c++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_SALES.Rows[c].Cells["SLNO"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_SALES.Rows[c].Cells["InvNumber"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_SALES.Rows[c].Cells["InvDate"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_SALES.Rows[c].Cells["cust_number"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DGV_SALES.Rows[c].Cells["cust_name"].Value.ToString() + "</font></th>");
                            {
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_SALES.Rows[c].Cells["clDiscount"].Value.ToString() + "&nbsp</font></th>");
                            }
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DGV_SALES.Rows[c].Cells["TotalAmount"].Value.ToString() + "&nbsp;</font></th>");
                        }
                        sWrite.WriteLine("</tr >");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=6 ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Total Items :</b></font><right'></td>");
                        sWrite.WriteLine("<td align='right'  colspan=7 ><FONT COLOR=black FACE='Segoe UI' SIZE=3> " + Txt_totalInvoice.Text + " </font><right'></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=6 ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Grand Total :</b></font><right'></td>");
                        sWrite.WriteLine("<td align='right'  colspan=7 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>  " + Txtgrandtotal.Text + " </font><right'></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\SalesReport.html");
                    }
                }
                else{
                    MessageBox.Show("No records found, Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void fill_grid(DataTable dtb)
        {
            try {
                if (dtb.Rows.Count > 0){
                    DGV_SALES.Rows.Clear();
                    total_disc = 0; Total_Amount = 0;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        DGV_SALES.Rows.Add();
                        DGV_SALES.Rows[i].Cells["SLNO"].Value = num;
                        DGV_SALES.Rows[i].Cells["InvNumber"].Value = dtb.Rows[i]["InvNumber"].ToString();
                        DGV_SALES.Rows[i].Cells["InvDate"].Value = Convert.ToDateTime(dtb.Rows[i]["InvDate"].ToString()).ToString("dd-MM-yyyy");
                        DGV_SALES.Rows[i].Cells["cust_number"].Value = dtb.Rows[i]["cust_number"].ToString();
                        DGV_SALES.Rows[i].Cells["cust_name"].Value = dtb.Rows[i]["cust_name"].ToString();
                        DGV_SALES.Rows[i].Cells["clDiscount"].Value = dtb.Rows[i]["Discount"].ToString();
                        DGV_SALES.Rows[i].Cells["TotalAmount"].Value = dtb.Rows[i]["TotalAmount"].ToString();
                        num = num + 1;
                    }
                    if (DGV_SALES.Rows.Count > 0) {
                        foreach (DataGridViewRow dr in DGV_SALES.Rows)
                        {
                            total_disc = total_disc + Convert.ToDecimal(dr.Cells["clDiscount"].Value.ToString());
                            Total_Amount = Total_Amount + Convert.ToDecimal(dr.Cells["TotalAmount"].Value.ToString());
                        }
                        int total_inv = DGV_SALES.Rows.Count;
                        Txttotaldiscount.Text = total_inv.ToString("##.00");
                        Txtgrandtotal.Text = Total_Amount.ToString("##.00");
                        Txt_totalInvoice.Text = total_inv.ToString();
                    }
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Btn_Show_Click(object sender, EventArgs e)
        {
            dateFrom = dptMonthly_From.Value.ToString("yyyy-MM-dd");
            dateTo = dptMonthly_To.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dptMonthly_From.Value = DateTime.Today;
            }
            DataTable dt=this.ctrlr.salesinv(dateFrom, dateTo);
            salesinv(dt);
        }
    }
}
