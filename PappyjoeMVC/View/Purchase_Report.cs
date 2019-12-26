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
    public partial class Purchase_Report : Form,Purchase_Report_interface
    {
        Purchase_Report_controller ctrlr;
        public static int pur_id = 0;
        public static DateTime from, to;
        int total_pur = 0, slno = 0, c = 0;
        decimal cost = 0, cost1 = 0, grandtotal = 0, grandtotal1 = 0;
        public string fdate="", tdate="",strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "", checkStr = "0", PathName = "";
        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowindex = dgvPurchase.CurrentRow.Index;
                from = dptMonthly_From.Value;
                to = dptMonthly_To.Value;
                pur_id = Convert.ToInt32(dgvPurchase.Rows[rowindex].Cells["PurchNumber"].Value.ToString());
                //var form = new PappyjoeMVC.View.Purchase_Item_Report(pur_id, from, to);
                //form.ShowDialog();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string fromdate = dptMonthly_From.Value.ToString("yyyy-MM-dd");
            string todate = dptMonthly_To.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(fromdate).Date > Convert.ToDateTime(todate).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dptMonthly_From.Value = DateTime.Today;
                return;
            }
            load();
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try{
                if (dgvPurchase.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Purchase Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                        ExcelApp.Cells[1, 1] = "PURCHASE REPORT";
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
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
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
                            try{
                                for (int j = 0; j < dgvPurchase.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgvPurchase.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch(Exception ex){}
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        checkStr = "1";
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found,please change the date and try again!..", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex){ MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try {
                if (dgvPurchase.Rows.Count > 0)
                {
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\PurchaseReport.html");
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
                    sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=5>  <b> PURCHASE REPORT </b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strStreet + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strphone + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='8'><hr/></td></tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>From :  </b> " + dptMonthly_From.Value.ToString("dd-MM-yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>To : </b> " + dptMonthly_To.Value.ToString("dd-MM-yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Printed Date : </b> " + DateTime.Now.ToString("dd-MM-yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    if (dgvPurchase.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align=center width=900>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='70' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbspSlno</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp Purchase No</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='150' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp Purchase Date</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='200' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp Supplier Name</b></font></th>");
                        sWrite.WriteLine("    <td align='right' width='120' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Total Amount&nbsp</b></font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Discount&nbsp</b></font></th>");
                        sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Grand Total&nbsp</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        while (c < dgvPurchase.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + dgvPurchase.Rows[c].Cells["sl"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + dgvPurchase.Rows[c].Cells["PurchNumber"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + dgvPurchase.Rows[c].Cells["PurchDate"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + dgvPurchase.Rows[c].Cells["Sup_name"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["TotalAmount"].Value.ToString() + "&nbsp</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["DiscAmount"].Value.ToString() + "&nbsp</font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["grandtotl"].Value.ToString() + "&nbsp;</font></th>");
                            sWrite.WriteLine("</tr>");
                            c++;
                        }
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<table align=center width=900>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='right' width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>TOTAL PURCHASE</b></font></right></td><td>:&nbsp;&nbsp</td><td align='right'> " + Txt_totalPurchase.Text + "</td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>TOTAL COST</b> </font></right></td><td>:&nbsp;&nbsp;</td><td align='right'>" + Txttotalcost.Text + "</td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>GRAND TOTAL</b> </font></right></td><td> :&nbsp;</td><td align='right'>" + txtGrandTotal.Text + "</td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\PurchaseReport.html");
                }
                else
                {
                    MessageBox.Show("No records found, please chenge the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Purchase_Report_Load(object sender, EventArgs e)
        {
            load();
            dgvPurchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvPurchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPurchase.EnableHeadersVisualStyles = false;
            dgvPurchase.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dgvPurchase.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPurchase.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPurchase.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn cl in dgvPurchase.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                cl.Width = 120;
            }
        }
        private void BTNClose_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Purchase_Report();
            //Purchase_Report_controller controller = new Purchase_Report_controller(form2);
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
        }
        public Purchase_Report()
        {
            InitializeComponent();
        }
        public void setController(Purchase_Report_controller controller)
        {
            ctrlr = controller;
        }
        public void load()
        {
            fdate = dptMonthly_From.Value.ToString("yyyy-MM-dd");
            tdate = dptMonthly_To.Value.ToString("yyyy-MM-dd");
            total_pur = 0; cost1 = 0; grandtotal1 = 0;
            Lab_Msg.Visible = false;
            dgvPurchase.Rows.Clear();
            this.ctrlr.purchdtls(fdate,tdate);
        }
        public void purchdtls(DataTable dt)
        {
            try{
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        slno = i + 1; 
                        dgvPurchase.Rows.Add();
                        dgvPurchase.Rows[i].Cells["SLNO"].Value = slno.ToString();
                        dgvPurchase.Rows[i].Cells["PurchNumber"].Value = dt.Rows[i]["PurchNumber"].ToString();
                        dgvPurchase.Rows[i].Cells["PurchDate"].Value = Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("dd-MM-yyyy");
                        dgvPurchase.Rows[i].Cells["Sup_name"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                        dgvPurchase.Rows[i].Cells["TotalAmount"].Value = dt.Rows[i]["TotalAmount"].ToString();
                        dgvPurchase.Rows[i].Cells["DiscAmount"].Value = dt.Rows[i]["DiscAmount"].ToString();
                        dgvPurchase.Rows[i].Cells["GrandTotal"].Value = dt.Rows[i]["GrandTotal"].ToString();
                        cost = Convert.ToDecimal(dt.Rows[i]["TotalAmount"].ToString());
                        cost1 = cost1 + cost;
                        grandtotal = Convert.ToDecimal(dt.Rows[i]["GrandTotal"].ToString());
                        grandtotal1 = grandtotal1 + grandtotal;
                    }
                    total_pur = dgvPurchase.Rows.Count;
                    Txt_totalPurchase.Text = total_pur.ToString();
                    Txttotalcost.Text = cost1.ToString();
                    txtGrandTotal.Text = grandtotal1.ToString();
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Visible = true;
                    dgvPurchase.Rows.Clear();
                    Txt_totalPurchase.Text = "0";
                    Txttotalcost.Text = "0.00";
                    txtGrandTotal.Text = "0.00";
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void practicedetails(DataTable dtp)
        {
            if (dtp.Rows.Count > 0) {
                clinicn = dtp.Rows[0]["name"].ToString();
                strclinicname = clinicn.Replace("¤", "'");
                strphone = dtp.Rows[0]["contact_no"].ToString();
                strStreet = dtp.Rows[0]["street_address"].ToString();
                stremail = dtp.Rows[0]["email"].ToString();
                strwebsite = dtp.Rows[0]["website"].ToString();
            }
        }
    }
}
