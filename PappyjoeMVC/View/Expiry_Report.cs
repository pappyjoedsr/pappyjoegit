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
    public partial class Expiry_Report : Form
    {
        public Expiry_Report()
        {
            InitializeComponent();
        }
        int c = 0;
        Expiry_Report_controller ctrlr=new Expiry_Report_controller();
        public string dateFrom = "", dateTo = "",checkStr = "0",PathName = "",strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "", clinicn = "";
        public void datewiseexpiry(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int slno = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvExpiry.Rows.Add();
                        Lab_Msg.Visible = false;
                        slno = i + 1;
                        dgvExpiry.Rows[i].Cells["col_slno"].Value = slno;
                        dgvExpiry.Rows[i].Cells["ItemCode"].Value = dt.Rows[i]["Item_Code"].ToString();
                        dgvExpiry.Rows[i].Cells["ItemName"].Value = dt.Rows[i]["item_name"].ToString();
                        dgvExpiry.Rows[i].Cells["PurchNumber"].Value = dt.Rows[i]["PurchNumber"].ToString();
                        dgvExpiry.Rows[i].Cells["PurchaseDate"].Value = Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("dd/MM/yyyy");
                        dgvExpiry.Rows[i].Cells["BatchNumber"].Value = dt.Rows[i]["BatchNumber"].ToString();
                        dgvExpiry.Rows[i].Cells["Quantity"].Value = dt.Rows[i]["Qty"].ToString();
                        dgvExpiry.Rows[i].Cells["ExpiryDate"].Value = Convert.ToDateTime(dt.Rows[i]["ExpDate"].ToString()).ToString("dd/MM/yyyy");
                        dgvExpiry.Rows[i].Cells["ColSup"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                        Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("MM/dd/yyyy");
                    }
                }
                else
                {
                    Lab_Msg.Visible = true;
                    dgvExpiry.Rows.Clear();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                dateFrom = dptFrom.Value.ToString("yyyy-MM-dd");
                dateTo = dptTo.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dptFrom.Value = DateTime.Today;
                    return;
                }
                DataTable dt = this.ctrlr.datewiseexpiry(dateFrom, dateTo);
                datewiseexpiry(dt);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpiry.Rows.Count > 0)
                {
                    DataTable dt1 = new DataTable();
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\ExpiryDatewiseReport.html");
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
                    sWrite.WriteLine("<th colspan=7 align='center'> <FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b>EXPIRY DATE WISE  REPORT </b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>From:</b>  " + dptFrom.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b>  " + dptTo.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Printed Date :</b>  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dgvExpiry.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;Sl</font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;Item code</font></td>");
                        sWrite.WriteLine("    <td align='left' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Item Name</font></td>");
                        sWrite.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Purchase No</font></td>");
                        sWrite.WriteLine("    <td align='center' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Purch Date</font></td>");
                        sWrite.WriteLine("    <td align='left' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Batch Number</font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Quantity</font></td>");
                        sWrite.WriteLine("    <td align='center' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Expiry Date</font></td>");
                        sWrite.WriteLine("    <td align='left' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Supplier Name</font></td>");

                        sWrite.WriteLine("</tr>");
                        while (c < dgvExpiry.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvExpiry.Rows[c].Cells["col_slno"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvExpiry.Rows[c].Cells["ItemCode"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvExpiry.Rows[c].Cells["ItemName"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvExpiry.Rows[c].Cells["PurchNumber"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvExpiry.Rows[c].Cells["PurchaseDate"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvExpiry.Rows[c].Cells["BatchNumber"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvExpiry.Rows[c].Cells["Quantity"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvExpiry.Rows[c].Cells["ExpiryDate"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvExpiry.Rows[c].Cells["ColSup"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("</tr>");
                            c++;
                        }
                    }
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\ExpiryDatewiseReport.html");
                }
                else
                {
                    MessageBox.Show("Record Not Found,please change the date and try again !..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvExpiry.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Expiry Date Wise Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dgvExpiry.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "Expiry Date Wise Report";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dptFrom.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2] = dptTo.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dgvExpiry.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgvExpiry.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Segoe UI";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgvExpiry.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgvExpiry.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgvExpiry.Rows[i].Cells[j].Value.ToString();
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
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            var form2 = new Expiry_Report();
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void Expiry_Report_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.ctrlr.datewiseexpiry(dateFrom, dateTo);
                datewiseexpiry(dt);
                dgvExpiry.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvExpiry.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvExpiry.EnableHeadersVisualStyles = false;
                dgvExpiry.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dgvExpiry.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvExpiry.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvExpiry.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvExpiry.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
