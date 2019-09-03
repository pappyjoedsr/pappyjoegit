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
    public partial class Doctor_Wise_Invoice : Form
    {
        public Doctor_Wise_Invoice()
        {
            InitializeComponent();
        }
        int ID = 0,c = 0;
        Double sum = 0, sum1 = 0, sum2 = 0;
        public string doctor_id = "",select_dr_id="",checkStr = "0",PathName = "",strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "", clinicn = "";
        Doctor_Wise_Invoice_controller ctrlr=new Doctor_Wise_Invoice_controller();
        private void Doctor_Wise_Invoice_Load(object sender, EventArgs e)
        {
            try
            {
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
                select_dr_id = "0";
                pageload();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void pageload()
        {
            try {
                lblNoRecord.Hide();
                dgvMonthlyReports.Rows.Clear();
                sum = 0; sum1 = 0; sum2 = 0;
                dgvMonthlyReports.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvMonthlyReports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvMonthlyReports.EnableHeadersVisualStyles = false;
                dgvMonthlyReports.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMonthlyReports.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMonthlyReports.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMonthlyReports.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMonthlyReports.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvMonthlyReports.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn cl in dgvMonthlyReports.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    cl.Width =150;
                }
                if (combodoctors.SelectedIndex == -1)
                { }
                else
                {
                    string drid = combodoctors.SelectedItem.ToString();
                    select_dr_id=this.ctrlr.Get_DoctorId(drid);
                    ID = int.Parse(select_dr_id);
                }
                if (ID != 0)
                {
                    DataTable dt3=this.ctrlr.getdata3(dptMonthly_From.Text, dptMonthly_To.Text, ID);
                    getdata3(dt3);
                }
                else
                {
                    DataTable dt4=this.ctrlr.getdata4(dptMonthly_From.Text, dptMonthly_To.Text);
                    getdata4(dt4);
                }
                for (int i = 0; i < dgvMonthlyReports.Rows.Count; i++)
                {
                    double s = Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["total_payment"].Value);
                    double s1 = Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["grant_total"].Value);
                    double s13 = s1 - s;
                    sum += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["grant_total"].Value);
                    sum1 += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["total_payment"].Value);
                    sum2 += Convert.ToDouble(dgvMonthlyReports.Rows[i].Cells["due"].Value);
                }
                lbltotal1.Text = sum.ToString("0.00");
                lbltotal2.Text = sum1.ToString("0.00");
                lbltotal3.Text = sum2.ToString("0.00");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getdata3(DataTable dt1)
        {
            try
            {
                if (dt1.Rows.Count > 0)
                {
                    lblNoRecord.Hide();
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        dgvMonthlyReports.Rows.Add();
                        dgvMonthlyReports.Rows[i].Cells["Slno"].Value = i + 1;
                        dgvMonthlyReports.Rows[i].Cells["pt_name"].Value = dt1.Rows[i]["pt_name"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["doctor_name"].Value = dt1.Rows[i]["doctor_name"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["invoice_no"].Value = dt1.Rows[i]["invoice_no"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["services"].Value = dt1.Rows[i]["services"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["Invoice_date"].Value = Convert.ToDateTime(dt1.Rows[i]["date"].ToString()).ToString("dd/MM/yyy");
                        dgvMonthlyReports.Rows[i].Cells["grant_total"].Value = Convert.ToDecimal(dt1.Rows[i]["Cost"].ToString()).ToString();
                        dgvMonthlyReports.Rows[i].Cells["total_payment"].Value = Convert.ToDecimal(dt1.Rows[i]["Payment"].ToString()).ToString();
                        dgvMonthlyReports.Rows[i].Cells["due"].Value = Convert.ToDecimal(dt1.Rows[i]["due"].ToString()).ToString("0.00");
                        dgvMonthlyReports.Rows[i].Cells[6].Style.ForeColor = Color.Blue;
                        dgvMonthlyReports.Rows[i].Cells[7].Style.ForeColor = Color.ForestGreen;
                        dgvMonthlyReports.Rows[i].Cells[8].Style.ForeColor = Color.Red;
                    }
                }
                else
                { lblNoRecord.Show(); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getdata4(DataTable dt1)
        {
            try
            {
                if (dt1.Rows.Count > 0)
                {
                    lblNoRecord.Hide();
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        dgvMonthlyReports.Rows.Add();
                        dgvMonthlyReports.Rows[i].Cells["Slno"].Value = i + 1;
                        dgvMonthlyReports.Rows[i].Cells["pt_name"].Value = dt1.Rows[i]["pt_name"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["doctor_name"].Value = dt1.Rows[i]["doctor_name"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["invoice_no"].Value = dt1.Rows[i]["invoice_no"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["services"].Value = dt1.Rows[i]["services"].ToString();
                        dgvMonthlyReports.Rows[i].Cells["Invoice_date"].Value = Convert.ToDateTime(dt1.Rows[i]["date"].ToString()).ToString("dd/MM/yyy");
                        dgvMonthlyReports.Rows[i].Cells["grant_total"].Value = Convert.ToDecimal(dt1.Rows[i]["Cost"].ToString()).ToString();
                        dgvMonthlyReports.Rows[i].Cells["total_payment"].Value = Convert.ToDecimal(dt1.Rows[i]["Payment"].ToString()).ToString();
                        dgvMonthlyReports.Rows[i].Cells["due"].Value = Convert.ToDecimal(dt1.Rows[i]["due"].ToString()).ToString("0.00");
                        dgvMonthlyReports.Rows[i].Cells[6].Style.ForeColor = Color.Blue;
                        dgvMonthlyReports.Rows[i].Cells[7].Style.ForeColor = Color.ForestGreen;
                        dgvMonthlyReports.Rows[i].Cells[8].Style.ForeColor = Color.Red;
                    }
                }
                else { lblNoRecord.Show(); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btnselect_Click(object sender, EventArgs e)
        {
             pageload();
        }
        private void combodoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            pageload();
        }
        private void dgvMonthlyReports_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try {
            if (dgvMonthlyReports.Rows.Count > 0)
            {
                string message = "Did you want Header on Print?";
                string caption = "Verification";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
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
                StreamWriter sWrite = new StreamWriter(Apppath + "\\DoctorwiseInvoiceReport.html");
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
                    sWrite.WriteLine("<th colspan=9 align='center'> <FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b>DOCTOR WISE INVOICE REPORT (All Doctors)</b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                }
                if (combodoctors.SelectedIndex != 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=9 align='center'> <FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b> DOCTOR WISE INVOICE REPORT (" + combodoctors.Text + ")</b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>From: </b> " + dptMonthly_From.Value.ToString("dd/MM/yyyy") + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b>  " + dptMonthly_To.Value.ToString("dd/MM/yyyy") + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Printed Date :</b>  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                sWrite.WriteLine("</tr>");
                if (combodoctors.SelectedIndex != 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Doctor: </b> " + combodoctors.Text + " </font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (dgvMonthlyReports.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left'width='5%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;Slno.</font></td>");
                    sWrite.WriteLine("    <td align='left'  width='16%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;Patient Name</font></td>");
                    sWrite.WriteLine("    <td align='left' width='13%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Doctor</font></td>");
                    sWrite.WriteLine("    <td align='center' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Invoice</font></td>");
                    sWrite.WriteLine("    <td align='left' width='14%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Services</font></td>");
                    sWrite.WriteLine("    <td align='center' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;Date</font></td>");
                    sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Cost</font></td>");
                    sWrite.WriteLine("    <td align='right'width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Income</font></td>");
                    sWrite.WriteLine("    <td align='right' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Amount Due</font></td>");
                    sWrite.WriteLine("</tr>");
                    while (c < dgvMonthlyReports.Rows.Count)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["slno"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["pt_name"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["doctor_name"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["invoice_no"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["services"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["Invoice_date"].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["grant_total"].Value.ToString() + "&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["total_payment"].Value.ToString() + "&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvMonthlyReports.Rows[c].Cells["due"].Value.ToString() + "&nbsp;</font></td>");
                        sWrite.WriteLine("</tr>");
                        c++;
                    }
                    string cost = "", payment = "", due = "";
                    cost = lbltotal1.Text; 
                    payment = lbltotal2.Text;
                    due = lbltotal3.Text;
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>Total</font></td>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + cost + "</b>&nbsp;</font></td>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + payment + "</b>&nbsp;</font></td>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + due + "</b>&nbsp;</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\DoctorwiseInvoiceReport.html");
            }
            else
            { MessageBox.Show("Record Not Found,please change the date and try again !..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information); } 
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
                MessageBox.Show("From date should be less than to date", "From Date is greater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dptMonthly_From.Value = DateTime.Today;
            }
        }
        private void dptMonthly_To_CloseUp(object sender, EventArgs e)
        {
            var dateFrom = dptMonthly_From.Value.ToShortDateString();
            var dateTo = dptMonthly_To.Value.ToShortDateString();
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than to date", "From Date is greater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dptMonthly_To.Value = DateTime.Today;
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try {
                if (dgvMonthlyReports.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Doctor Wise Summary(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dgvMonthlyReports.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "DOCTOR WISE SUMMARY";
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
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2] = dptMonthly_To.Value.ToString("dd-MM-yyyy");
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
    }
}
