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
    public partial class SalesReport_Items : Form
    {
        public int invNumber;
        public static string date1, date2,checkStr = "0",PathName = "";
        SalesReport_Items_controller ctrlr = new SalesReport_Items_controller();
        public SalesReport_Items(int inv_num, string p1, string p2)
        {
            InitializeComponent();
            invNumber = inv_num;
            date1 = p1;
            date2 = p2;
        }
        private void SalesReport_Items_Load(object sender, EventArgs e)
        {
            try
            {
                if (invNumber != 0)
                {
                    DataTable dtb_inv = this.ctrlr.salesrprtitms(invNumber.ToString());
                    if (dtb_inv.Rows.Count > 0)
                    {
                        fill_grid(dtb_inv);
                        calculations();
                    }
                }
                DGV_ITEMS.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                DGV_ITEMS.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                DGV_ITEMS.EnableHeadersVisualStyles = false;
                DGV_ITEMS.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                DGV_ITEMS.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                DGV_ITEMS.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_ITEMS.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn cl in DGV_ITEMS.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    cl.Width = 100;
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
                    DGV_ITEMS.Rows.Clear();
                    int num = 1;
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        string strBatch = "", removecomma = "";
                        string dtb_batch = this.ctrlr.slctbatchno(invNumber.ToString(), dtb.Rows[i]["Item_Code"].ToString());
                        DGV_ITEMS.Rows.Add();
                        DGV_ITEMS.Rows[i].Cells["SLNO"].Value = num;
                        DGV_ITEMS.Rows[i].Cells["Item_Code"].Value = dtb.Rows[i]["Item_Code"].ToString();
                        DGV_ITEMS.Rows[i].Cells["Description"].Value = dtb.Rows[i]["Description"].ToString();
                        if(dtb_batch!="")
                        {
                            strBatch = strBatch + dtb_batch.ToString() + ",";
                        }
                        if (strBatch != "")
                        removecomma = strBatch.Remove(strBatch.Length - 1);
                        DGV_ITEMS.Rows[i].Cells["colBatch"].Value = removecomma;
                        DGV_ITEMS.Rows[i].Cells["Packing"].Value = dtb.Rows[i]["Packing"].ToString();
                        DGV_ITEMS.Rows[i].Cells["Unit"].Value = dtb.Rows[i]["Unit"].ToString();
                        DGV_ITEMS.Rows[i].Cells["GST"].Value = dtb.Rows[i]["GST"].ToString();
                        DGV_ITEMS.Rows[i].Cells["IGST"].Value = dtb.Rows[i]["IGST"].ToString();
                        DGV_ITEMS.Rows[i].Cells["Quantity"].Value = dtb.Rows[i]["Qty"].ToString();
                        DGV_ITEMS.Rows[i].Cells["Free"].Value = dtb.Rows[i]["FreeQty"].ToString();
                        DGV_ITEMS.Rows[i].Cells["Cost"].Value = Convert.ToDecimal(dtb.Rows[i]["Rate"].ToString()).ToString("##.00");
                        DGV_ITEMS.Rows[i].Cells["TotalAmount"].Value = Convert.ToDecimal(dtb.Rows[i]["TotalAmount"].ToString()).ToString("##.00");
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
                if (DGV_ITEMS.Rows.Count > 0)
                {
                    string invNo = "", invDate = "", cus_name = "", cus_id = "";
                    DataTable dt_sales = this.ctrlr.invdtls(invNumber.ToString());
                    if (dt_sales.Rows.Count > 0)
                    {
                        invNo = dt_sales.Rows[0][0].ToString();
                        invDate = Convert.ToDateTime(dt_sales.Rows[0][1].ToString()).ToString("dd-MM-yyyy");
                        cus_name = dt_sales.Rows[0][2].ToString();
                        cus_id = dt_sales.Rows[0][3].ToString();
                    }
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dtp = this.ctrlr.practicedetails();
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
                    System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\SalesItems.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table { border-collapse: collapse;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<table align=center width=900 >");
                    sWrite.WriteLine("<th colspan=11> <center><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> SALES ITEM DETAILS REPORT</b> </font></center></th>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=11><b><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=11><b><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>   " + strStreet + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=11><b><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> " + strphone + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  colspan=6 align='left' ><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>Customer Id :" + cus_id + "</font></left></td>");
                    sWrite.WriteLine("<td  colspan=6 align='right' ><b><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=2>Invoice No:" + invNo + " </font></right></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=6 align='left' ><FONT COLOR=black FACE='Sego UI' SIZE=2>Customer Name :" + cus_name + "</font></left></td>");
                    sWrite.WriteLine("<td colspan=6 align='right' ><b><FONT COLOR=black FACE='Sego UI' SIZE=2>Invoice Date:" + invDate + " </font></right></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=11 align='left' ><FONT COLOR=black FACE='Sego UI' SIZE=2> Printed Date  :<" + DateTime.Now.ToString("dd-MM-yyyy") + " </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    if (DGV_ITEMS.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2 >Sl.</font></td>");
                        sWrite.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Item Code</font></td>");
                        sWrite.WriteLine("    <td align='left' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Description</font></td>");
                        sWrite.WriteLine("    <td align='left' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Batch Number</font></td>");
                        sWrite.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Units</font></td>");
                        sWrite.WriteLine("    <td align='center' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> GST</font></td>");
                        sWrite.WriteLine("    <td align='center' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>IGST</font></td>");
                        sWrite.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Qty</font></td>");
                        sWrite.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Free</font></td>");
                        sWrite.WriteLine("    <td align='center' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Cost</font></td>");
                        sWrite.WriteLine("    <td align='center' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> Amount</font></td>");
                        sWrite.WriteLine("</tr>");
                        for (int c = 0; c < DGV_ITEMS.Rows.Count; c++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["SLNO"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["Item_Code"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["Description"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["colBatch"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["Unit"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["GST"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["IGST"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["Quantity"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["Free"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["Cost"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>" + DGV_ITEMS.Rows[c].Cells["TotalAmount"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> Total Items :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=11 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>  " + Txt_totalItems.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> Total Cost :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=11 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> " + TxttotalCost.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> Grand Total :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=11 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>  " + Txtgrandtotal.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> Total IGST :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=11 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>  " + txt_IGST.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> SGST :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=11 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> " + txt_SGST.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'  colspan=10 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1> CGST :</font></td>");
                        sWrite.WriteLine("<td align='right'  colspan=11 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>  " + txt_CGST.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\SalesItems.html");
                    }
                }
                else
                {
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_ITEMS.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "SalesItemsReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = DGV_ITEMS.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "SALES ITEMS REPORT";
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
                        for (int i = 1; i < DGV_ITEMS.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = DGV_ITEMS.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= DGV_ITEMS.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < DGV_ITEMS.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = DGV_ITEMS.Rows[i].Cells[j].Value.ToString();
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
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void calculations()
        {
            try
            {
                decimal total_disc = 0; decimal GStAmount = 0; decimal IGStAmount = 0;
                decimal Total_Amount = 0;
                decimal TotalIgst = 0;
                decimal Total_Gst = 0;
                decimal SGST = 0;
                if (DGV_ITEMS.Rows.Count > 0)
                {
                    foreach (DataGridViewRow dr in DGV_ITEMS.Rows)
                    {
                        GStAmount = ((Convert.ToDecimal(dr.Cells["Quantity"].Value.ToString()) * Convert.ToDecimal(dr.Cells["Cost"].Value.ToString())) * Convert.ToDecimal(dr.Cells["GST"].Value.ToString())) / 100;
                        Total_Gst = Total_Gst + GStAmount;
                        total_disc = total_disc + Convert.ToDecimal(dr.Cells["Cost"].Value.ToString());
                        Total_Amount = Total_Amount + Convert.ToDecimal(dr.Cells["TotalAmount"].Value.ToString());
                        IGStAmount = ((Convert.ToDecimal(dr.Cells["Quantity"].Value.ToString()) * Convert.ToDecimal(dr.Cells["Cost"].Value.ToString())) * Convert.ToDecimal(dr.Cells["IGST"].Value.ToString())) / 100;
                        TotalIgst = TotalIgst + IGStAmount;
                    }
                    int total_inv = DGV_ITEMS.Rows.Count;
                    TxttotalCost.Text = total_disc.ToString("##.00");
                    Txtgrandtotal.Text = Total_Amount.ToString("##.00");
                    Txt_totalItems.Text = total_inv.ToString();
                    if (TotalIgst > 0)
                    {
                        txt_IGST.Text = TotalIgst.ToString();
                    }
                    else
                        txt_IGST.Text = "0";
                    if (Total_Gst > 0)
                    {
                        SGST = Total_Gst / 2;
                        txt_SGST.Text = SGST.ToString();
                        txt_CGST.Text = SGST.ToString();
                    }
                    else
                    {
                        txt_SGST.Text = "0";
                        txt_CGST.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
