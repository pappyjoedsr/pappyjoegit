using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Sales_Return_Report : Form
    {
        public Sales_Return_Report()
        {
            InitializeComponent();
        }
        Sales_Return_Report_controller ctrlr=new Sales_Return_Report_controller();
        public string dateFrom="", dateTo="",checkStr = "0",PathName = "",strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
        private void dgv_Return_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int Inv_num = Convert.ToInt32(dgv_Return.CurrentRow.Cells["InvNumber"].Value.ToString());
                int Doc_num = Convert.ToInt32(dgv_Return.CurrentRow.Cells["RetNumber"].Value.ToString());
                var form2 = new SalesReturnItemsReport(Doc_num, Inv_num, dptMonthly_From.Value.ToString("yyyy-MM-dd"), dptMonthly_To.Value.ToString("yyyy-MM-dd"));
                form2.ShowDialog();
            }
        }
        private void BTNClose_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Sales_Return_Report();
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void Sales_Return_Report_Load(object sender, EventArgs e)
        {
            dateFrom = dptMonthly_From.Value.ToString("yyyy-MM-dd");
            dateTo = dptMonthly_To.Value.ToString("yyyy-MM-dd");
            DataTable dt=this.ctrlr.salesreturn(dateFrom,dateTo);
            salesreturn(dt);
            dgv_Return.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_Return.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_Return.EnableHeadersVisualStyles = false;
            dgv_Return.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dgv_Return.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_Return.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_Return.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_Return.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_Return.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn cl in dgv_Return.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                cl.Width = 110;
            }
        }
        public void salesreturn(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    dgv_Return.Rows.Clear();
                    Lab_Msg.Visible = false;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        dgv_Return.Rows.Add();
                        dgv_Return.Rows[i].Cells["SLNO"].Value = i + 1;
                        dgv_Return.Rows[i].Cells["RetNumber"].Value = dtb.Rows[i]["RetNumber"].ToString();
                        dgv_Return.Rows[i].Cells["ReturnDate"].Value = Convert.ToDateTime(dtb.Rows[i]["ReturnDate"].ToString()).ToString("dd-MM-yyyy");
                        dgv_Return.Rows[i].Cells["InvNumber"].Value = dtb.Rows[i]["InvNumber"].ToString();
                        dgv_Return.Rows[i].Cells["InvDate"].Value = Convert.ToDateTime(dtb.Rows[i]["InvDate"].ToString()).ToString("dd-MM-yyyy");
                        dgv_Return.Rows[i].Cells["cust_number"].Value = dtb.Rows[i]["cust_number"].ToString();
                        dgv_Return.Rows[i].Cells["cust_name"].Value = dtb.Rows[i]["cust_name"].ToString();
                        dgv_Return.Rows[i].Cells["GST"].Value = dtb.Rows[i]["GST"].ToString();
                        dgv_Return.Rows[i].Cells["IGST"].Value = dtb.Rows[i]["IGST"].ToString();
                        dgv_Return.Rows[i].Cells["Paid"].Value = Convert.ToDecimal(dtb.Rows[i]["Paid"].ToString()).ToString("##.00");
                        dgv_Return.Rows[i].Cells["TotalAmount"].Value = Convert.ToDecimal(dtb.Rows[i]["TotalAmount"].ToString()).ToString("##.00");
                    }
                    int count = dgv_Return.Rows.Count;
                    Txt_totalInvoice.Text = count.ToString();
                    decimal total_disc = 0;
                    decimal Total_Amount = 0;
                    if (dgv_Return.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow dr in dgv_Return.Rows)
                        {
                            total_disc = total_disc + Convert.ToDecimal(dr.Cells["Paid"].Value.ToString());
                            Total_Amount = Total_Amount + Convert.ToDecimal(dr.Cells["TotalAmount"].Value.ToString());
                        }
                        int total_inv = dgv_Return.Rows.Count;
                        TxttotalPaid.Text = total_disc.ToString("##.00");
                        Txtgrandtotal.Text = Total_Amount.ToString("##.00");
                        Txt_totalInvoice.Text = total_inv.ToString();
                    }
                }
                else
                {
                    Lab_Msg.Visible = true;
                    Lab_Msg.Location = new Point(272, 246);
                    dgv_Return.Rows.Clear();
                    Txt_totalInvoice.Text = "0.00";
                    TxttotalPaid.Text = "0.00";
                    Txtgrandtotal.Text = "0.00";
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
                return;
            }
            DataTable dt=this.ctrlr.salesreturn(dateFrom, dateTo);
            salesreturn(dt);
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Return.Rows.Count > 0)
                {
                    string today = DateTime.Now.ToString("d/M/yyyy");
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
                    System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\SalesReturnReport.html");
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
                    sWrite.WriteLine("<td colspan=9 align=center><FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b>SALES RETURN REPORT</b> </font></td");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=9><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From:</b>" + dptMonthly_From.Value.ToString("d/MM/yyyy") + " </font></td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=9><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>To:</b>" + dptMonthly_From.Value.ToString("d/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=9><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dgv_Return.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Sl.</font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Customer Id</font></td>");
                        sWrite.WriteLine("    <td align='center' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Name</font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Return No</font></td>");
                        sWrite.WriteLine("    <td align='center' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Return Date </font></td>");
                        sWrite.WriteLine("    <td align='center' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Invoice No </font></td>");
                        sWrite.WriteLine("    <td align='center' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Invoice Date</font></td>");
                        sWrite.WriteLine("    <td align='center' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Paid</font></td>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Total Amount</font></td>");
                        sWrite.WriteLine("</tr>");
                        for (int c = 0; c < dgv_Return.Rows.Count; c++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["SLNO"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["cust_number"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["cust_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["RetNumber"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'SIZE=2>" + dgv_Return.Rows[c].Cells["ReturnDate"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["InvNumber"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["InvDate"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_Return.Rows[c].Cells["Paid"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'' SIZE=2>" + dgv_Return.Rows[c].Cells["TotalAmount"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("</tr >");
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Items :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + Txt_totalInvoice.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=8><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Paid :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=9><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + TxttotalPaid.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=8><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Amount :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=9><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + Txtgrandtotal.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\SalesReturnReport.html");
                    }
                }
                else
                {
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Return.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Sales Return Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dgv_Return.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "SALES RETURN REPORT";
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
                        for (int i = 1; i < dgv_Return.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgv_Return.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgv_Return.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgv_Return.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgv_Return.Rows[i].Cells[j].Value.ToString();
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
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
