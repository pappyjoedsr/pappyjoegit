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
    public partial class PurchaseItemReturnReport : Form
    {
        DateTime from1, to1;
        int pur_ret_id1 = 0, slno = 0, c = 0;
        decimal total = 0, total1 = 0, amount =0, gst, igst, qty, unitcost = 0;
        public string unit = "", strclinicname = "", checkStr = "0",PathName = "",clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
        PurchaseItemReturnReport_controller ctrlr = new PurchaseItemReturnReport_controller();
        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchase.Rows.Count > 0)
                {
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\PurchaseItem_Return_Report.html");
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
                    sWrite.WriteLine("<table align=center width=1093>");
                    sWrite.WriteLine("<col width=500>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> PURCHASE RETURN ITEM REPORT </b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=1>  <b> " + strphone + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> FROM :  " + dptMonthly_From.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> TO :  " + dptMonthly_To.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> Printed Date :  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='right'colspan=7><left><FONT COLOR=black FACE='Segoe UI' SIZE=2>   &nbsp;RETURN NO</font></right></td><td>:&nbsp</td><td SIZE=3> " + txtReturn_no.Text + " </td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    if (dgvPurchase.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align=center width=1093>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Sl</font></th>");
                        sWrite.WriteLine("    <td align='center' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> RETURN DATE</font></th>");
                        sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> ITEM CODE</font></th>");
                        sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> UNIT</font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> QUANTITY</font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> FREE</font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> UNIT COST</font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> GST</font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> IGST</font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> AMOUNT</font></th>");
                        sWrite.WriteLine("</tr>");
                        while (c < dgvPurchase.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["SLNO"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["PurchReturnDate"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["Item_id"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["UNIT"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["QTY"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["FREE"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["Unitcost"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["GST"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["IGST"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["AMOUNT"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("</tr>");
                            c++;
                        }
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<table align=center width=1093>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2>  TOTAL ITEM </font></right></td><td>:&nbsp;&nbsp;</td><td SIZE=3><b> " + txtTotalItem.Text + "</b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2>  TOTAL AMOUNT </font></right></td><td>:&nbsp;&nbsp;</td><td SIZE=3><b> " + txtTotalAmount.Text + "</b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\PurchaseItem_Return_Report.html");
                }
                else
                {
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public PurchaseItemReturnReport(int pur_ret_id, DateTime from, DateTime to)
        {
            InitializeComponent();
            pur_ret_id1 = pur_ret_id;
            from1 = from;
            to1 = to;
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchase.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "PurchaseItemReturnReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                        ExcelApp.Cells[1, 1] = "PURCHASE RETURN ITEMS REPORT";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dptMonthly_From.Value;
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dptMonthly_To.Value;
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        for (int i = 1; i < dgvPurchase.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[4, i] = dgvPurchase.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[4, i].ColumnWidth = 25;
                            ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[4, i].Font.Size = 10;
                            ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                            ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgvPurchase.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgvPurchase.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 5, j + 1] = dgvPurchase.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 5, j + 1].Font.Size = 8;
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
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void PurchaseItemReturnReport_Load(object sender, EventArgs e)
        {
            try
            {
                dptMonthly_From.Value = from1;
                dptMonthly_To.Value = to1;
                DataTable dt = this.ctrlr.purchitemreturn(pur_ret_id1.ToString()); ;
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable dtunit = this.ctrlr.slctitems(dt.Rows[i]["item_code"].ToString());
                        if (dt.Rows[i]["UNIT2"].ToString().Trim() == "No")
                        {
                            unit = dtunit.Rows[0]["Unit1"].ToString();
                        }
                        else if (dt.Rows[i]["UNIT2"].ToString().Trim() == "Yes")
                        {
                            unit = dtunit.Rows[0]["Unit2"].ToString();
                        }
                        if (dt.Rows[i]["Gst"].ToString() != "0.00")
                        {
                            qty = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                            unitcost = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                            gst = Convert.ToDecimal(dt.Rows[i]["Gst"].ToString());
                            igst = Convert.ToDecimal(dt.Rows[i]["Igst"].ToString());
                            amount = ((((unitcost * qty) * gst) / 100) + (unitcost * qty));
                        }
                        else if (dt.Rows[i]["Igst"].ToString() != "0.00")
                        {
                            qty = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                            unitcost = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                            igst = Convert.ToDecimal(dt.Rows[i]["Igst"].ToString());
                            amount = ((((unitcost * qty) * igst) / 100) + (unitcost * qty));
                        }
                        else
                        {
                            qty = Convert.ToDecimal(dt.Rows[i]["Qty"].ToString());
                            unitcost = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString());
                            amount = unitcost * qty;
                        }
                        slno = i + 1;
                        dgvPurchase.Rows.Add();
                        dgvPurchase.Rows[i].Cells["SLNO"].Value = slno.ToString();
                        dgvPurchase.Rows[i].Cells["PurchReturnDate"].Value = Convert.ToDateTime(dt.Rows[i]["ReturnDate"].ToString()).ToString("MM/dd/yyyy");
                        dgvPurchase.Rows[i].Cells["Item_id"].Value = dt.Rows[i]["item_code"].ToString();
                        dgvPurchase.Rows[i].Cells["FREE"].Value = dt.Rows[i]["FreeQty"].ToString();
                        dgvPurchase.Rows[i].Cells["UNIT"].Value = unit;
                        dgvPurchase.Rows[i].Cells["QTY"].Value = dt.Rows[i]["Qty"].ToString();
                        dgvPurchase.Rows[i].Cells["GST"].Value = dt.Rows[i]["Gst"].ToString();
                        dgvPurchase.Rows[i].Cells["IGST"].Value = dt.Rows[i]["Igst"].ToString();
                        dgvPurchase.Rows[i].Cells["Unitcost"].Value = Convert.ToDecimal(dt.Rows[i]["Rate"].ToString()).ToString("##.00");
                        dgvPurchase.Rows[i].Cells["AMOUNT"].Value = amount;
                        total = amount;
                        total1 = total1 + total;
                    }
                    txtReturn_no.Text = pur_ret_id1.ToString();
                    txtTotalItem.Text = dgvPurchase.Rows.Count.ToString();
                    txtTotalAmount.Text = total1.ToString("##.00");
                }
                dgvPurchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvPurchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvPurchase.EnableHeadersVisualStyles = false;
                dgvPurchase.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPurchase.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPurchase.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPurchase.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvPurchase.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvPurchase.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
