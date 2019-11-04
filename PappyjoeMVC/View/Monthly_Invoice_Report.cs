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
    public partial class Monthly_Invoice_Report : Form
    {
        public Monthly_Invoice_Report()
        {
            InitializeComponent();
        }
        int ID = 0,slno = 0;
        Double sum = 0, sum1 = 0, sum2 = 0, sum3 = 0;
        public string doctor_id = "",select_dr_id = "0",strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "",clinicn = "",PathName = "";
        Monthly_Invoice_Report_controller ctrlr=new Monthly_Invoice_Report_controller();
        private void Monthly_Invoice_Report_Load(object sender, EventArgs e)
        {
            try
            {
                dgvMonthlyReports.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvMonthlyReports.EnableHeadersVisualStyles = false;
                this.dgvMonthlyReports.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dgvMonthlyReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                foreach (DataGridViewColumn cl in dgvMonthlyReports.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                combodoctors.Items.Add("All Doctor");
                combodoctors.ValueMember = "0";
                combodoctors.DisplayMember = "All Doctor";
                DataTable doctor_rs = this.ctrlr.getdocname();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        combodoctors.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        combodoctors.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        combodoctors.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
                combodoctors.SelectedIndex = 0;
                dptMonthly_From.Value = DateTime.Now.AddMonths(-1).Date;
                dptMonthly_To.Value = DateTime.Now.Date;
                gridload();
                dgvMonthlyReports.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMonthlyReports.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                foreach (DataGridViewColumn cl in dgvMonthlyReports.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    cl.Width = 100;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getdata(DataTable dt1)
        {
            try{
                if (dt1.Rows.Count > 0)
                {
                    for (int z = 0; z < dt1.Rows.Count; z++)
                    {
                        slno = z + 1;
                        string pt_id = dt1.Rows[z]["pt_id"].ToString();
                        string name = dt1.Rows[z]["pt_name"].ToString();
                        string invoice_no = dt1.Rows[z]["invoice_no"].ToString();
                        string service = dt1.Rows[z]["services"].ToString() + " (Qty:" + dt1.Rows[z]["unit"].ToString() + ")";
                        string date = Convert.ToDateTime(dt1.Rows[z]["date"].ToString()).ToString("dd/MM/yyyy");
                        string doctor = dt1.Rows[z]["doctor_name"].ToString();
                        string type = dt1.Rows[z]["discount_type"].ToString();
                        decimal discount = decimal.Parse(dt1.Rows[z]["total_discount"].ToString());
                        decimal cost = decimal.Parse(dt1.Rows[z]["Cost"].ToString());
                        decimal total_cost = decimal.Parse(dt1.Rows[z]["Total_Cost"].ToString());
                        decimal total_payment = decimal.Parse(dt1.Rows[z]["Payment"].ToString());
                        decimal due = decimal.Parse(dt1.Rows[z]["Cost"].ToString()) - decimal.Parse(dt1.Rows[z]["Payment"].ToString());
                        if (decimal.Parse(dt1.Rows[z]["total_discount"].ToString()) != 0)
                        {
                            dgvMonthlyReports.Rows.Add(slno, name, invoice_no, service, date, doctor, total_cost, discount, cost, total_payment, due);
                        }
                        else
                        {  dgvMonthlyReports.Rows.Add(slno, name, invoice_no, service, date, doctor, total_cost, "", cost, total_payment, due); }
                        dgvMonthlyReports.Columns["due"].DefaultCellStyle.ForeColor = Color.Red;
                        dgvMonthlyReports.Columns["total_payment"].DefaultCellStyle.ForeColor = Color.ForestGreen;
                        dgvMonthlyReports.Columns["grant_total"].DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
                else
                {  lblNoRecord.Show(); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getdata2(DataTable dt1)
        {
            try{
                if (dt1.Rows.Count > 0)
                {
                    for (int z = 0; z < dt1.Rows.Count; z++)
                    {
                        slno = z + 1;
                        string pt_id = dt1.Rows[z]["pt_id"].ToString();
                        string name = dt1.Rows[z]["pt_name"].ToString();
                        string invoice_no = dt1.Rows[z]["invoice_no"].ToString();
                        string service = dt1.Rows[z]["services"].ToString() + " (Qty:" + dt1.Rows[z]["unit"].ToString() + ")";
                        string date = Convert.ToDateTime(dt1.Rows[z]["date"].ToString()).ToString("dd/MM/yyyy");
                        string doctor = dt1.Rows[z]["doctor_name"].ToString();
                        string type = dt1.Rows[z]["discount_type"].ToString();
                        decimal discount = decimal.Parse(dt1.Rows[z]["total_discount"].ToString());
                        decimal cost = decimal.Parse(dt1.Rows[z]["Cost"].ToString());
                        decimal total_cost = decimal.Parse(dt1.Rows[z]["Total_Cost"].ToString());
                        decimal total_payment = decimal.Parse(dt1.Rows[z]["Payment"].ToString());
                        decimal due = decimal.Parse(dt1.Rows[z]["Cost"].ToString()) - decimal.Parse(dt1.Rows[z]["Payment"].ToString());
                        if (decimal.Parse(dt1.Rows[z]["total_discount"].ToString()) != 0)
                        {
                            dgvMonthlyReports.Rows.Add(slno, name, invoice_no, service, date, doctor, total_cost, discount, cost, total_payment, due);
                        }
                        else
                        {dgvMonthlyReports.Rows.Add(slno, name, invoice_no, service, date, doctor, total_cost, "", cost, total_payment, due); }
                        dgvMonthlyReports.Columns["due"].DefaultCellStyle.ForeColor = Color.Red;
                        dgvMonthlyReports.Columns["total_payment"].DefaultCellStyle.ForeColor = Color.ForestGreen;
                        dgvMonthlyReports.Columns["grant_total"].DefaultCellStyle.ForeColor = Color.Blue;
                    }
                }
                else
                {
                    int x = (panel3.Size.Width - lblNoRecord.Size.Width) / 2;
                    lblNoRecord.Location = new Point(x, lblNoRecord.Location.Y);
                    lblNoRecord.Show(); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void gridload()
        {
            try
            {
                lblNoRecord.Hide();
                DataTable dt1 = new DataTable();
                dgvMonthlyReports.Rows.Clear();
                sum = 0; sum1 = 0; sum2 = 0; sum3 = 0;
                if (combodoctors.SelectedIndex == -1) { }
                else
                {
                    string drid = combodoctors.SelectedItem.ToString();
                    select_dr_id = this.ctrlr.Get_DoctorId(drid);
                    ID = int.Parse(select_dr_id);
                }
                if (ID != 0)
                {
                    DataTable data = this.ctrlr.getdata(dptMonthly_From.Text, dptMonthly_To.Text, ID);
                    getdata(data);
                }
                else
                {
                    DataTable data2 = this.ctrlr.getdata2(dptMonthly_From.Text, dptMonthly_To.Text);
                    getdata2(data2);
                }

                for (int i = 0; i < dgvMonthlyReports.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["grant_total"].Value);
                    sum1 += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["total_payment"].Value);
                    sum2 += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["due"].Value);
                    sum3 += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["AMOUNT"].Value);
                }
                lbltotal1.Text = sum.ToString("0.00");
                LabTotal3.Text = sum3.ToString("0.00");
                lbltotal2.Text = sum1.ToString("0.00");
                lbltotal3.Text = sum2.ToString("0.00");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void buttonClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMonthlyReports.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xml)|*.xml";
                    saveFileDialog1.FileName = "Monthly Summary(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xml";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        int count = dgvMonthlyReports.Columns.Count;
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "MONTHLY SUMMARY";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dptMonthly_From.Value;
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dptMonthly_To.Value;
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dgvMonthlyReports.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgvMonthlyReports.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Segoe UI";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgvMonthlyReports.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgvMonthlyReports.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgvMonthlyReports.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch { }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try{
                if (dgvMonthlyReports.Rows.Count > 0)
                {
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
                    int sl = 0;
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dt=this.ctrlr.practicedetails();
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
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\MonthlyInvoiceReport.html");
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
                    if (combodoctors.SelectedIndex == 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=10 align='center'> <FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b>MONTHLY INVOICE REPORT (All Doctors)</b> </font></center></th>");
                        sWrite.WriteLine("</tr>");
                    }
                    if (combodoctors.SelectedIndex != 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=10 align='center'> <FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> MONTHLY INVOICE REPORT (" + combodoctors.Text + ")</b> </font></center></th>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=8 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>From:</b>  " + dptMonthly_From.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To: </b> " + dptMonthly_To.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Printed Date:</b>  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (combodoctors.SelectedIndex != 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=10 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Doctor: </b> " + combodoctors.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    if (dgvMonthlyReports.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Slno. </font></td>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Patient Name </font></td>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Invoice</font></td>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Services</font></td>");
                        sWrite.WriteLine("    <td align='center' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Invoice Date</font></td>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Doctor</font></td>");
                        sWrite.WriteLine("    <td align='right' width='25%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Treatment Cost</font></td>");
                        sWrite.WriteLine("    <td align='right' width='13%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Discount</font></td>");
                        sWrite.WriteLine("    <td align='right' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Amount</font></td>");
                        sWrite.WriteLine("    <td align='right' width='25%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Total Payment</font></td>");
                        sWrite.WriteLine("    <td align='right' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Amount Due</font></td>");
                        sWrite.WriteLine("</tr>");
                        while (c < dgvMonthlyReports.Rows.Count)
                        {
                            sl = c + 1;
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + sl + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["pt_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["invoice_no"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["services"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["Invoice_date"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["doctor"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Convert.ToDecimal(dgvMonthlyReports.Rows[c].Cells["grant_total"].Value.ToString()).ToString("#0.00") + "&nbsp;</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["DICOUNT"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["AMOUNT"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["total_payment"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["due"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("</tr>");
                            c++;
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></th>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Total&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + lbltotal1.Text + "</b></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + LabTotal3.Text + "</b></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + lbltotal2.Text + "</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + lbltotal3.Text + "</b>&nbsp;</font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\MonthlyInvoiceReport.html");
                }
                else
                {MessageBox.Show("No Record Found,please change the date and try again !..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);}
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dptMonthly_From_CloseUp(object sender, EventArgs e)
        {
            var dateFrom = dptMonthly_From.Value.ToShortDateString();
            var dateTo = dptMonthly_To.Value.ToShortDateString();
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than to date");
                dptMonthly_From.Value = DateTime.Today;
            }
        }
        private void dptMonthly_To_CloseUp(object sender, EventArgs e)
        {
            var dateFrom = dptMonthly_From.Value.ToShortDateString();
            var dateTo = dptMonthly_To.Value.ToShortDateString();
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than to date");
                dptMonthly_To.Value = DateTime.Today;
            }
        }
        private void btnselect_Click(object sender, EventArgs e)
        {
            gridload();
        }
        private void combodoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            gridload();
        }
    }
}
