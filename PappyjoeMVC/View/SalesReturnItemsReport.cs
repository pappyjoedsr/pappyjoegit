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
    public partial class SalesReturnItemsReport : Form
    {
        public static string date1, date2;
        public static int Ret_Number, Inv_Number;
        SalesReturnItemsReport_controller ctrlr = new SalesReturnItemsReport_controller();
        public string invNo = "", invDate = "", cus_name = "", cus_id = "", ReturnNumber = "", RetDate = "", checkStr = "0", PathName = "";
        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_ReturnItems.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "SalesReturnItemsReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dgv_ReturnItems.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "SALES ORDER ITEM REPORT";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = date1;
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
                        for (int i = 1; i < dgv_ReturnItems.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgv_ReturnItems.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgv_ReturnItems.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgv_ReturnItems.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgv_ReturnItems.Rows[i].Cells[j].Value.ToString();
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
        public SalesReturnItemsReport(int Doc_num)
        {
            InitializeComponent();
            Ret_Number = Doc_num;
        }
        public SalesReturnItemsReport(int Doc_num, string p1, string p2)
        {
            InitializeComponent();
            Ret_Number = Doc_num;
            date1 = p1;
            date2 = p2;
        }
        public SalesReturnItemsReport(int Doc_num, int Inv_num, string p1, string p2)
        {
            InitializeComponent();
            Ret_Number = Doc_num;
            Inv_Number = Inv_num;
            date1 = p1;
            date2 = p2;
        }
        private void SalesReturnItemsReport_Load(object sender, EventArgs e)
        {
            try
            {
                if (Ret_Number != 0)
                {
                    DataTable dt_order = this.ctrlr.salesrtrnitms(Ret_Number.ToString());
                    if (dt_order.Rows.Count > 0)
                    {
                        fill_grid(dt_order);
                        calculations();
                    }
                    dgv_ReturnItems.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                    dgv_ReturnItems.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv_ReturnItems.EnableHeadersVisualStyles = false;
                    dgv_ReturnItems.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                    dgv_ReturnItems.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv_ReturnItems.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv_ReturnItems.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    foreach (DataGridViewColumn cl in dgv_ReturnItems.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_ReturnItems.Rows.Count > 0)
                {
                    DataTable dt_sales = this.ctrlr.retrndtls(Ret_Number.ToString());
                    if (dt_sales.Rows.Count > 0)
                    {
                        invNo = dt_sales.Rows[0]["InvNumber"].ToString();
                        invDate = Convert.ToDateTime(dt_sales.Rows[0]["InvDate"].ToString()).ToString("M/d/yyyy");
                        cus_name = dt_sales.Rows[0]["cust_name"].ToString();
                        cus_id = dt_sales.Rows[0]["cust_number"].ToString();
                        RetDate = Convert.ToDateTime(dt_sales.Rows[0]["ReturnDate"].ToString()).ToString("M/d/yyyy");
                        ReturnNumber = dt_sales.Rows[0]["RetNumber"].ToString();
                    }
                    string today = DateTime.Now.ToString("M/d/yyyy");
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
                    int rowCount = dgv_ReturnItems.Rows.Count;
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\SalesReturnItems.html");
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
                    sWrite.WriteLine("<td colspan=10 align=center><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b>SALES RETURN ITEMS REPORT</b> </font></td");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=10 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=10 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=1>   " + strStreet + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=10 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=1> " + strphone + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=10 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=1> " + strStreet + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>Customer Id :" + cus_id + "</font><left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>Customer Name :" + cus_name + " </font><left></td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9  align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>Return Date :" + today + "</font><left></td>");
                    sWrite.WriteLine("<td  colspan=9 align='right'><FONT COLOR=black FACE='Segoe UI'SIZE=2>   Invoice Number :  " + invNo + " </font></right></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan= 9 align='left'><FONT COLOR=black FACE='Segoe UI'SIZE=2> Printed Date:" + RetDate + "</font><left></td>");
                    sWrite.WriteLine("<td colspan=9 align='right'><FONT COLOR=black FACE='Segoe UI' SIZE=2>   Invoice Date:  " + invDate + " </font></right></td>");
                    sWrite.WriteLine("</tr>");
                    if (dgv_ReturnItems.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >SlNo</font></th>");
                        sWrite.WriteLine("    <td align='center' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Return No</font></th>");
                        sWrite.WriteLine("    <td align='center' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Item Code </font></th>");
                        sWrite.WriteLine("    <td align='center' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Sales Unit</font></th>");
                        sWrite.WriteLine("    <td align='center' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Free</font></th>");
                        sWrite.WriteLine("    <td align='center' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> GST</font></th>");
                        sWrite.WriteLine("    <td align='center' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> IGST</font></th>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Quantity</font></th>");
                        sWrite.WriteLine("    <td align='center' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Cost</font></th>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Total Amount</font></th>");
                        sWrite.WriteLine("</tr>");
                        for (int c = 0; c < dgv_ReturnItems.Rows.Count; c++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["SLNO"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["RetNumber"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["Item_Code"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["UNIT2"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["FreeQty"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["GST"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["IGST"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["Qty"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["Rate"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_ReturnItems.Rows[c].Cells["TotalAmopunt"].Value.ToString() + "</font></th>");
                        }
                        sWrite.WriteLine("</td>");
                        sWrite.WriteLine("</tr >");
                        sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Items :</font></right></td>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>  " + rowCount + " </font></right></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Cost :</font></right></td>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black v SIZE=3>  " + Txt_TOTALCOST.Text + " </font></right></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black FACE='Segoe UI' SIZE=2> Total Amount :</font></right></td>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Segoe UI' SIZE=3>  " + Txtgrandtotal.Text + " </font></right></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\SalesReturnItems.html");
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
        public void fill_grid(System.Data.DataTable dtb)
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    dgv_ReturnItems.Rows.Clear();
                    int num = 1;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        DataTable dtb_ax = this.ctrlr.slctgst(Inv_Number.ToString(), dtb.Rows[i]["Item_Code"].ToString());
                        DataTable dtb_unit = this.ctrlr.slctunits(dtb.Rows[i]["Item_Code"].ToString());
                        dgv_ReturnItems.Rows.Add();
                        dgv_ReturnItems.Rows[i].Cells["SLNO"].Value = num;
                        dgv_ReturnItems.Rows[i].Cells["RetNumber"].Value = dtb.Rows[i]["RetNumber"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["Item_Code"].Value = dtb.Rows[i]["Item_Code"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["GST"].Value = dtb_ax.Rows[0]["GST"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["IGST"].Value = dtb_ax.Rows[0]["IGST"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["Qty"].Value = dtb.Rows[i]["Qty"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["Rate"].Value = Convert.ToDecimal(dtb.Rows[i]["Rate"].ToString()).ToString("##.00");
                        if (dtb.Rows[i]["UNIT2"].ToString().Trim() == "Yes")
                        {
                            dgv_ReturnItems.Rows[i].Cells["UNIT2"].Value = dtb_unit.Rows[0]["Unit2"].ToString();
                        }
                        else
                            dgv_ReturnItems.Rows[i].Cells["UNIT2"].Value = dtb_unit.Rows[0]["Unit1"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["FreeQty"].Value = dtb.Rows[i]["FreeQty"].ToString();
                        dgv_ReturnItems.Rows[i].Cells["TotalAmopunt"].Value = Convert.ToDecimal(dtb.Rows[i]["TotalAmopunt"].ToString()).ToString("##.00");
                        num = num + 1;
                    }
                }
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
                if (dgv_ReturnItems.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dr in dgv_ReturnItems.Rows)
                    {
                        total_Cost = total_Cost + Convert.ToDecimal(dr.Cells["Rate"].Value.ToString());
                        Total_Amount = Total_Amount + Convert.ToDecimal(dr.Cells["TotalAmopunt"].Value.ToString());
                    }
                    Txt_TOTALCOST.Text = total_Cost.ToString("##.00");
                    Txtgrandtotal.Text = Total_Amount.ToString("##.00");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        } 
}
}
