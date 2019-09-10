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
    public partial class Purchase_Item_Report : Form
    {
        
        int pur_id1 = 0;
        DateTime from1, to1;
        public string checkStr = "0",PathName = "";
        Purchase_Item_Report_controller ctrlr = new Purchase_Item_Report_controller();
        public Purchase_Item_Report(int pur_id, DateTime from, DateTime to)
        {
            InitializeComponent();
            pur_id1 = pur_id;
            from1 = from;
            to1 = to;
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            string message = "Did you want Header on Print?";
            string caption = "Verification";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            int c = 0;
            string strclinicname = "";
            string strStreet = "";
            string stremail = "";
            string strwebsite = "";
            string strphone = "";
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                DataTable dtp = this.ctrlr.practicedetails();
                if (dtp.Rows.Count > 0)
                {
                    strclinicname = dtp.Rows[0]["name"].ToString();
                    strphone = dtp.Rows[0]["contact_no"].ToString();
                    strStreet = dtp.Rows[0]["street_address"].ToString();
                    stremail = dtp.Rows[0]["email"].ToString();
                    strwebsite = dtp.Rows[0]["website"].ToString();
                }
            }
            string Apppath = System.IO.Directory.GetCurrentDirectory();
            StreamWriter sWrite = new StreamWriter(Apppath + "\\PurchaseItemReport.html");
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
            sWrite.WriteLine("<col width=500>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> PURCHASE ITEM REPORT </b> </font></center></th>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=1>  <b> " + strphone + "</b> </font></th>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE=' Segoe UI' SIZE=2> From :  " + dptMonthly_From.Value.ToString("dd/MM/yyyy") + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> To :  " + dptMonthly_To.Value.ToString("dd/MM/yyyy") + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> Printed Date :  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("</table>");
            if (dgvPurchase.Rows.Count > 0)
            {
                sWrite.WriteLine("<table align=center width=900>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("    <td align='left' width='15' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Sl</font></th>");
                sWrite.WriteLine("    <td align='center' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Purchase Date</font></th>");
                sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Item Code</font></th>");
                sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE=' Segoe UI' SIZE=3> Description</font></th>");
                sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Packing</font></th>");
                sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Unit</font></th>");
                sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Quantity</font></th>");
                sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Free</font></th>");
                sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Unit Cost</font></th>");
                sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Gst</font></th>");
                sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Igst</font></th>");
                sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Amount</font></th>");
                sWrite.WriteLine("</tr>");
                while (c < dgvPurchase.Rows.Count)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["SL_NO"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["PurchDate"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["Item_id"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["Desccription"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["PACKING"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["UNIT"].Value.ToString() + "</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["QTY"].Value.ToString() + "&nbsp;</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["FREE"].Value.ToString() + "&nbsp;</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["UNIT_COST"].Value.ToString() + "&nbsp;</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["GST"].Value.ToString() + "&nbsp;</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["IGST"].Value.ToString() + "&nbsp;</font></th>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["AMOUNT"].Value.ToString() + "&nbsp;</font></th>");
                    sWrite.WriteLine("</tr>");
                    c++;
                }
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align=center width=900>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2>   TOTAL ITEM</font></right><td><td width=192>:&nbsp;&nbsp;</td><td align ='right'><b> " + txtTotalItem.Text + " </b></td>");
                sWrite.WriteLine("</tr >");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2>   TOTAL AMOUNT</font></right><td><td width=192>:&nbsp;&nbsp;</td><td align ='right'><b> " + txtGrandTotal.Text + " </b></td>");
                sWrite.WriteLine("</tr >");
                sWrite.WriteLine("</table>");
            }
            sWrite.WriteLine("</div>");
            sWrite.WriteLine("<script>window.print();</script>");
            sWrite.WriteLine("</body>");
            sWrite.WriteLine("</html>");
            sWrite.Close();
            System.Diagnostics.Process.Start(Apppath + "\\PurchaseItemReport.html");
        }
        private void BTNClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchase.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "PurchaseItemReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                        ExcelApp.Cells[1, 1] = "PURCHASE ITEMS REPORT";
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
                        ExcelApp.Cells[3, 2].Font.Size = 10; ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dgvPurchase.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgvPurchase.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgvPurchase.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgvPurchase.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgvPurchase.Rows[i].Cells[j].Value.ToString();
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
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Purchase_Item_Report_Load(object sender, EventArgs e)
        {
            dptMonthly_From.Value = from1;
            dptMonthly_To.Value = to1;
            txtPurch_no.Text = pur_id1.ToString();
            decimal total = 0;
            decimal total1 = 0;
            DataTable dt = this.ctrlr.purchitem(pur_id1.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvPurchase.Rows.Add();
                    dgvPurchase.Rows[i].Cells["SL_NO"].Value = i + 1;
                    dgvPurchase.Rows[i].Cells["PurchDate"].Value = Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("yyyy-MM-dd");
                    dgvPurchase.Rows[i].Cells["Item_id"].Value = dt.Rows[i]["Item_Code"].ToString();
                    dgvPurchase.Rows[i].Cells["Desccription"].Value = dt.Rows[i]["Desccription"].ToString();
                    dgvPurchase.Rows[i].Cells["PACKING"].Value = dt.Rows[i]["Packing"].ToString();
                    dgvPurchase.Rows[i].Cells["UNIT"].Value = dt.Rows[i]["Unit"].ToString();
                    dgvPurchase.Rows[i].Cells["QTY"].Value = dt.Rows[i]["Qty"].ToString();
                    dgvPurchase.Rows[i].Cells["FREE"].Value = dt.Rows[i]["FreeQty"].ToString();
                    dgvPurchase.Rows[i].Cells["UNIT_COST"].Value = dt.Rows[i]["Rate"].ToString();
                    dgvPurchase.Rows[i].Cells["GST"].Value = dt.Rows[i]["GST"].ToString();
                    dgvPurchase.Rows[i].Cells["IGST"].Value = dt.Rows[i]["IGST"].ToString();
                    dgvPurchase.Rows[i].Cells["AMOUNT"].Value = dt.Rows[i]["Amount"].ToString();
                    total = Convert.ToDecimal(dt.Rows[i]["Amount"].ToString());
                    total1 = total + total1;
                }
                txtTotalItem.Text = dgvPurchase.Rows.Count.ToString();
                txtGrandTotal.Text = total1.ToString();
            }
            dgvPurchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvPurchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPurchase.EnableHeadersVisualStyles = false;
            dgvPurchase.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPurchase.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
       
    }
}
