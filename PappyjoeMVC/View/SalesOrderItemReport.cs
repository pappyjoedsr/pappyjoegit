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
    public partial class SalesOrderItemReport : Form
    {
        public static int DOCNUMBER;
        public static string Date1, date2;
        public string checkStr = "0", PathName = "";
        SalesOrderItemReport_controller ctrlr = new SalesOrderItemReport_controller();
        public SalesOrderItemReport(int Doc_num)
        {
            InitializeComponent();
            DOCNUMBER = Doc_num;
        }
        public SalesOrderItemReport(int Doc_num, string p1, string p2)
        {
            InitializeComponent();
            DOCNUMBER = Doc_num;
            Date1 = p1;
            date2 = p2;
        }
        private void SalesOrderItemReport_Load(object sender, EventArgs e)
        {
            try
            {
                if (DOCNUMBER != 0)
                {
                    DataTable dt_order = this.ctrlr.salesordritm(DOCNUMBER.ToString());
                    if (dt_order.Rows.Count > 0)
                    {
                        fill_grid(dt_order);
                        calculations();
                    }
                    dgv_orderItems.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    dgv_orderItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv_orderItems.EnableHeadersVisualStyles = false;
                    dgv_orderItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                    dgv_orderItems.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_orderItems.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv_orderItems.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_orderItems.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    foreach (DataGridViewColumn cl in dgv_orderItems.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void fill_grid(DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    dgv_orderItems.Rows.Clear();
                    int num = 1;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        dgv_orderItems.Rows.Add();
                        dgv_orderItems.Rows[i].Cells["SLNO"].Value = num;
                        dgv_orderItems.Rows[i].Cells["CLDocNumber"].Value = dtb.Rows[i]["DocNumber"].ToString();
                        dgv_orderItems.Rows[i].Cells["DocDate"].Value = Convert.ToDateTime(dtb.Rows[i]["DocDate"].ToString()).ToString("MM/dd/yyyy");
                        dgv_orderItems.Rows[i].Cells["ItemCode"].Value = dtb.Rows[i]["ItemCode"].ToString();
                        dgv_orderItems.Rows[i].Cells["Discription"].Value = dtb.Rows[i]["Discription"].ToString();
                        dgv_orderItems.Rows[i].Cells["Qty"].Value = dtb.Rows[i]["Qty"].ToString();
                        dgv_orderItems.Rows[i].Cells["Cost"].Value = Convert.ToDecimal(dtb.Rows[i]["Cost"].ToString()).ToString("##.00");
                        dgv_orderItems.Rows[i].Cells["TotalAmount"].Value = Convert.ToDecimal(dtb.Rows[i]["TotalAmount"].ToString()).ToString("##.00");
                        num = num + 1;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_orderItems.Rows.Count > 0)
                {
                    string invNo = "", invDate = "", cus_name = "", cus_id = "";
                    DataTable dt_sales = this.ctrlr.slctdocno(DOCNUMBER.ToString());
                    if (dt_sales.Rows.Count > 0)
                    {
                        invNo = dt_sales.Rows[0][0].ToString();
                        invDate = Convert.ToDateTime(dt_sales.Rows[0][1].ToString()).ToString("dd/MM/yyyy");
                        cus_name = dt_sales.Rows[0][2].ToString();
                        cus_id = dt_sales.Rows[0][3].ToString();
                    }
                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dtp = this.ctrlr.practicedetails();
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
                    System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\SalesOrderItems.html");
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
                    sWrite.WriteLine("<td colspan=6 align=center><FONT COLOR=black FACE='Geneva, Arial' SIZE=>  <br><b>SALES ORDER ITEMS REPORT</b> </font><center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> " + strclinicname + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=1>  <b> " + strStreet + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=1>  <b> " + strphone + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<td colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Customer Id:" + cus_id + "</font></left></td>");
                    sWrite.WriteLine("<td colspan=4 align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2> Invoice No:" + invNo + "</font></right></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=4 ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Customer Name:" + cus_name + " </font></left></td> ");
                    sWrite.WriteLine("<td colspan=4  align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2>Invoice Date: " + invDate + "</font></right></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=6 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + today + "</font></left></td>");
                    sWrite.WriteLine("</tr>");
                    if (dgv_orderItems.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='10%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Sl.</font></th>");
                        sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Product Name</font></th>");
                        sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Discription</font></th>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Quantity</font></th>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Cost</font></th>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Total Amount</font></th>");
                        sWrite.WriteLine("</tr>");
                        for (int c = 0; c < dgv_orderItems.Rows.Count; c++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_orderItems.Rows[c].Cells["SLNO"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_orderItems.Rows[c].Cells["ItemCode"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_orderItems.Rows[c].Cells["Discription"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_orderItems.Rows[c].Cells["Qty"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_orderItems.Rows[c].Cells["Cost"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_orderItems.Rows[c].Cells["TotalAmount"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("</tr >");
                        }

                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=5 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Items :</font><right></td>");
                        sWrite.WriteLine("<td align='right'  colspan=6 ><FONT COLOR=blackFACE='Segoe UI' SIZE=3>  " + Txt_totalInvoice.Text + " </font><right></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=5 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Cost :</font><right></td>");
                        sWrite.WriteLine("<td align='right'  colspan=6 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>  " + Txttotaldiscount.Text + " </font><right></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=5 ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Total Amount :</font><right></td>");
                        sWrite.WriteLine("<td align='right'  colspan=6 ><FONT COLOR=black FACE='Segoe UI' SIZE=3> " + Txtgrandtotal.Text + " </font><right></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\SalesOrderItems.html");
                    }
                }
                else
                {
                    MessageBox.Show("No records found, Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_orderItems.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "SalesOrderItemsReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dgv_orderItems.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "SALES ORDER ITEM REPORT";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = Date1;
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = date2;
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dgv_orderItems.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgv_orderItems.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgv_orderItems.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgv_orderItems.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgv_orderItems.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
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
                    MessageBox.Show("No records found, Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void calculations()                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        {
            try
            {
                decimal total_Cost = 0;
                decimal Total_Amount = 0;
                if (dgv_orderItems.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dgv_orderItems.Rows)
                    {
                        total_Cost = total_Cost + Convert.ToDecimal(dr.Cells["Cost"].Value.ToString());
                        Total_Amount = Total_Amount + Convert.ToDecimal(dr.Cells["TotalAmount"].Value.ToString());
                    }
                    int total_inv = dgv_orderItems.Rows.Count;
                    Txttotaldiscount.Text = total_Cost.ToString("##.00");
                    Txtgrandtotal.Text = Total_Amount.ToString("##.00");
                    Txt_totalInvoice.Text = total_inv.ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

    }
}
