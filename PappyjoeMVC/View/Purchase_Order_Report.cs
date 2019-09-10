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
    public partial class Purchase_Order_Report : Form
    {
        public Purchase_Order_Report()
        {
            InitializeComponent();
        }
        int c = 0;
        public static int pur_id = 0;
        public static DateTime from, to;
        Purchase_Order_Report_controller ctrlr=new Purchase_Order_Report_controller();
        public string strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "", clinicn = "", fdate="", tdate="",checkStr = "0",PathName = "";
        private void Purchase_Order_Report_Load(object sender, EventArgs e)
        {
            load();
            dgvPurchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgvPurchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPurchase.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dgvPurchase.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvPurchase.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchase.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn cl in dgvPurchase.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0){
                int rowindex = dgvPurchase.CurrentRow.Index;
                from = dptMonthly_From.Value;
                to = dptMonthly_To.Value;
                pur_id = Convert.ToInt32(dgvPurchase.Rows[rowindex].Cells["PUCHASEORDERNO"].Value.ToString());
                var form = new PappyjoeMVC.View.PurchaseOrderItemReport(pur_id, from, to);
                form.ShowDialog();
            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            try{
                if (dgvPurchase.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Purchase Order Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                        ExcelApp.Cells[1, 1] = "PURCHASE ORDER REPORT";
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
                            try{
                                for (int j = 0; j < dgvPurchase.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 5, j + 1] = dgvPurchase.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 5, j + 1].Font.Size = 8;
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
        private void BTNClose_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Purchase_Order_Report();
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\PurchaseOrderReport.html");
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
                    sWrite.WriteLine("<table align=center width=700>");
                    sWrite.WriteLine("<col width=500>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b> PURCHASE ORDER REPORT </b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>  <b> " + strclinicname + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>From :</b> " + dptMonthly_From.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> To :</b> " + dptMonthly_To.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Printed Date : </b>" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dgvPurchase.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align=center width=700>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Sl</font></th>");
                        sWrite.WriteLine("<td align='left' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Purchase Order No</font></th>");
                        sWrite.WriteLine("<td align='center' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Purchase Order Date</font></th>");
                        sWrite.WriteLine("<td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Supplier Name</font></th>");
                        sWrite.WriteLine("</tr>");
                        while (c < dgvPurchase.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["SLNO"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["PUCHASEORDERNO"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("<td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["PURCHASEORDER_DATE"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvPurchase.Rows[c].Cells["SUPPLIER_NAME"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            c++;
                        }
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<table align=center width=700>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='right'width=19000><FONT COLOR=black FACE='Segoe UI' SIZE=2>   TOTAL ITEM </font></right></td><td>:&nbsp;&nbsp;</td><td SIZE=3><b>" + txtTotalItem.Text + "</b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\PurchaseOrderReport.html");
                }
                else
                {
                    MessageBox.Show("No records found, please change the date and try again!..", "No Records found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void purchorder(DataTable dt)
        {
            if (dt.Rows.Count > 0) {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Lab_Msg.Visible = false;
                    dgvPurchase.Rows.Add();
                    dgvPurchase.Rows[i].Cells["SLNO"].Value = i + 1;
                    dgvPurchase.Rows[i].Cells["PUCHASEORDERNO"].Value = dt.Rows[i]["Pur_order_no"].ToString();
                    dgvPurchase.Rows[i].Cells["PURCHASEORDER_DATE"].Value = Convert.ToDateTime(dt.Rows[i]["Purch_order_date"].ToString()).ToString("dd-MM-yyyy");
                    dgvPurchase.Rows[i].Cells["SUPPLIER_NAME"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                }
                txtTotalItem.Text = dgvPurchase.Rows.Count.ToString();
            }
            else{
                txtTotalItem.Text = "0.00";
                dgvPurchase.Rows.Clear();
                Lab_Msg.Visible = true;
            }
        }
        public void load()
        {
            fdate = dptMonthly_From.Value.ToString("yyyy-MM-dd");
            tdate = dptMonthly_To.Value.ToString("yyyy-MM-dd");
            Lab_Msg.Visible = false;
            dgvPurchase.Rows.Clear();
            DataTable dt=this.ctrlr.purchorder(fdate,tdate);
            purchorder(dt);
        }
    }
}
