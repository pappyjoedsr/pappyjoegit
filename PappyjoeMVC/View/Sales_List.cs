using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;

namespace PappyjoeMVC.View
{
    public partial class Sales_List : Form
    {
        public string dateTo;
        public string dateFrom;
        bool flag_fromInventory = false;
        Sales_List_controller cntrl=new Sales_List_controller();
        public Sales_List()
        {
            InitializeComponent();
        }
        public Sales_List(string date1, string date2)
        {
            InitializeComponent();
            dateTo = date1;
            dateFrom = date2;
            flag_fromInventory = true;
        }

        private void Sales_List_Load(object sender, EventArgs e)
        {
            try
            {
                Lab_Msg.Visible = false;
                if (flag_fromInventory == true)
                {
                    DTP_From.Value = Convert.ToDateTime(dateTo);
                    DTP_To.Value = Convert.ToDateTime(dateFrom);
                    DataTable dt = this.cntrl.get_salesDetails(Convert.ToDateTime(dateTo).ToString("yyyy-MM-dd"), Convert.ToDateTime(dateFrom).ToString("yyyy-MM-dd"));
                    Fill_dgvSale(dt);
                }
                else
                {
                    DataTable dtb = this.cntrl.invDetailsbyDate(DateTime.Now.ToString("yyyy-MM-dd"));
                    Fill_dgvSale(dtb);
                }

                dgv_sales.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_sales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_sales.EnableHeadersVisualStyles = false;
                dgv_sales.ColumnHeadersDefaultCellStyle.Font = new Font("Sego UI", 9, FontStyle.Regular);
                dgv_sales.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_sales.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_sales.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_sales.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn cl in dgv_sales.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Fill_dgvSale(DataTable dtb)
        {
            dgv_sales.Rows.Clear(); Lab_Msg.Visible = false;
            if (dtb.Rows.Count > 0)
            {
                int num = 1;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_sales.Rows.Add();
                    dgv_sales.Rows[i].Cells["colslNo"].Value = num;
                    dgv_sales.Rows[i].Cells["colInvNum"].Value = dtb.Rows[i]["InvNumber"].ToString();
                    dgv_sales.Rows[i].Cells["colinvDate"].Value = Convert.ToDateTime(dtb.Rows[i]["InvDate"].ToString()).ToString("MM/dd/yyyy");
                    dgv_sales.Rows[i].Cells["colcustNo"].Value = dtb.Rows[i]["cust_number"].ToString();
                    dgv_sales.Rows[i].Cells["colName"].Value = dtb.Rows[i]["cust_name"].ToString();
                    dgv_sales.Rows[i].Cells["colPhone"].Value = dtb.Rows[i]["phone1"].ToString();
                    dgv_sales.Rows[i].Cells["colTotalAmount"].Value = Convert.ToInt32(dtb.Rows[i]["TotalAmount"].ToString()).ToString("##.00");
                    dgv_sales.Rows[i].Cells["colPayment"].Value = dtb.Rows[i]["PayMethod"].ToString();
                    num = num + 1;
                }
            }
            else
            {
                int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Visible = true;
            }
        }

        private void rad_Cash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rad_Cash.Checked)
                {
                    rad_Credit.Checked = false;
                    DataTable dt = this.cntrl.invDetailsbyDateBtwn(DTP_From.Value.ToString("yyyy-MM-dd"), DTP_To.Value.ToString("yyyy-MM-dd"));
                    Fill_dgvSale(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rad_Credit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rad_Credit.Checked)
                {
                    rad_Cash.Checked = false;
                    Lab_Msg.Visible = false;
                    DataTable dt = this.cntrl.InvDetailsBtwnDates(DTP_From.Value.ToString("yyyy-MM-dd"), DTP_To.Value.ToString("yyyy-MM-dd"));
                    Fill_dgvSale(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_sales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
                int invnum = Convert.ToInt32(dgv_sales.CurrentRow.Cells["colInvNum"].Value.ToString());
                int rowindex = dgv_sales.CurrentRow.Index;
                if (dgv_sales.CurrentCell.OwningColumn.Name == "colInvNum")
                {
                    var form2 = new Sales(invnum);
                    form2.ShowDialog();
                }
                else if (dgv_sales.CurrentCell.OwningColumn.Name == "colmore")
                {
                    var form2 = new Sales(invnum);
                    form2.ShowDialog();
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                string from = DTP_From.Value.ToString("yyyy-MM-dd");
                string to = DTP_To.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(from).Date > Convert.ToDateTime(to).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DTP_From.Value = DateTime.Today;
                }
                else
                {
                    DataTable dt = this.cntrl.get_salesDetails(DTP_From.Value.ToString("yyyy-MM-dd"), DTP_To.Value.ToString("yyyy-MM-dd"));
                    Fill_dgvSale(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            try
            {
                string PathName = "";
                string from = DTP_From.Value.ToString("yyyy-MM-dd");
                string to = DTP_To.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
                string[] strarray;
                strarray = new string[] { "Sl.No", "Date", "Customer Name", "Voucher Type", "Vch No.", "Gross Total" };
                int[] intarray;
                intarray = new int[] { 10, 10, 25, 14, 10, 10 };
                double total_amount = 0;
                double total_gst = 0;
                double total_igst = 0;
                double total_net = 0;
                if (Convert.ToDateTime(from).Date > Convert.ToDateTime(to).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DTP_From.Value = DateTime.Today;
                }
                else
                {
                    DataTable dt = this.cntrl.get_salesDetails(from,to);
                    if (dt.Rows.Count > 0)
                    {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                        saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                        saveFileDialog1.FileName = "Sales Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            PathName = saveFileDialog1.FileName;
                            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                            ExcelApp.Application.Workbooks.Add(Type.Missing);
                            ExcelApp.Columns.ColumnWidth = 20;
                            int count = dt.Columns.Count;
                            ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 13]].Merge();
                            ExcelApp.Cells[1, 1] = "Sales Register";
                            ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                            ExcelApp.Cells[1, 1].Font.Size = 12;
                            ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                            ExcelApp.Columns.ColumnWidth = 20;
                            ExcelApp.Cells[2, 1] = "From Date";
                            ExcelApp.Cells[2, 1].Font.Size = 10;
                            ExcelApp.Cells[3, 1] = "To Date";
                            ExcelApp.Cells[3, 1].Font.Size = 10;
                            ExcelApp.Cells[2, 2] = DTP_From.Value.ToString("dd-MM-yyyy");
                            ExcelApp.Cells[2, 2].Font.Size = 10;
                            ExcelApp.Cells[3, 2] = DTP_To.Value.ToString("dd-MM-yyyy");
                            ExcelApp.Cells[3, 2].Font.Size = 10;
                            ExcelApp.Cells[4, 1] = "Running Date";
                            ExcelApp.Cells[4, 1].Font.Size = 10;
                            ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                            ExcelApp.Cells[4, 2].Font.Size = 10;
                            ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                            for (int i = 0; i < strarray.Length; i++)
                            {
                                ExcelApp.Range[ExcelApp.Cells[5, i + 1], ExcelApp.Cells[6, i + 1]].Merge();
                                ExcelApp.Cells[5, i + 1] = strarray[i];
                                ExcelApp.Cells[5, i + 1].ColumnWidth = intarray[i];
                                ExcelApp.Cells[5, i + 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                ExcelApp.Cells[5, i + 1].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                ExcelApp.Cells[5, i + 1].EntireRow.Font.Bold = true;
                                ExcelApp.Cells[5, i + 1].Interior.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[5, i + 1].Font.Size = 10;
                                ExcelApp.Cells[5, i + 1].Font.Name = "Arial";
                                ExcelApp.Cells[5, i + 1].Font.Color = Color.FromArgb(255, 255, 255);
                                ExcelApp.Cells[5, i + 1].Interior.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Range[ExcelApp.Cells[5, i + 1], ExcelApp.Cells[6, i + 1]].BorderAround(true);
                                ExcelApp.Range[ExcelApp.Cells[5, i + 1], ExcelApp.Cells[6, i + 1]].Borders.Color = Color.FromArgb(0, 0, 0);
                            }
                            ExcelApp.Range[ExcelApp.Cells[5, 7], ExcelApp.Cells[5, 8]].Merge();
                            ExcelApp.Cells[5, 7] = "CGST";
                            ExcelApp.Cells[5, 7].ColumnWidth = 18;
                            ExcelApp.Cells[5, 7].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, 7].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, 7].Font.Size = 10;
                            ExcelApp.Cells[5, 7].Font.Name = "Arial";
                            ExcelApp.Cells[5, 7].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, 7].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Range[ExcelApp.Cells[5, 7], ExcelApp.Cells[5, 8]].BorderAround(true);
                            ExcelApp.Range[ExcelApp.Cells[5, 7], ExcelApp.Cells[5, 8]].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[5, 7].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[5, 7].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Cells[6, 7] = "Rate%";
                            ExcelApp.Cells[6, 7].ColumnWidth = 8;
                            ExcelApp.Cells[6, 7].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[6, 7].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 7].Font.Size = 8;
                            ExcelApp.Cells[6, 7].Font.Name = "Arial";
                            ExcelApp.Cells[6, 7].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[6, 7].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 7].BorderAround(true);
                            ExcelApp.Cells[6, 7].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 7].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 7].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Cells[6, 8] = "Amount";
                            ExcelApp.Cells[6, 8].ColumnWidth = 10;
                            ExcelApp.Cells[6, 8].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[6, 8].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 8].Font.Size = 8;
                            ExcelApp.Cells[6, 8].Font.Name = "Arial";
                            ExcelApp.Cells[6, 8].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[6, 8].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 8].BorderAround(true);
                            ExcelApp.Cells[6, 8].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 8].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 8].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Range[ExcelApp.Cells[5, 9], ExcelApp.Cells[5, 10]].Merge();
                            ExcelApp.Cells[5, 9] = "SGST";
                            ExcelApp.Cells[5, 9].ColumnWidth = 18;
                            ExcelApp.Cells[5, 9].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, 9].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, 9].Font.Size = 10;
                            ExcelApp.Cells[5, 9].Font.Name = "Arial";
                            ExcelApp.Cells[5, 9].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, 9].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Range[ExcelApp.Cells[5, 9], ExcelApp.Cells[5, 10]].BorderAround(true);
                            ExcelApp.Range[ExcelApp.Cells[5, 9], ExcelApp.Cells[5, 10]].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[5, 9].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[5, 9].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Cells[6, 9] = "Rate%";
                            ExcelApp.Cells[6, 9].ColumnWidth = 8;
                            ExcelApp.Cells[6, 9].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[6, 9].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 9].Font.Size = 8;
                            ExcelApp.Cells[6, 9].Font.Name = "Arial";
                            ExcelApp.Cells[6, 9].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[6, 9].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 9].BorderAround(true);
                            ExcelApp.Cells[6, 9].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 9].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 9].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Cells[6, 10] = "Amount";
                            ExcelApp.Cells[6, 10].ColumnWidth = 10;
                            ExcelApp.Cells[6, 10].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[6, 10].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 10].Font.Size = 8;
                            ExcelApp.Cells[6, 10].Font.Name = "Arial";
                            ExcelApp.Cells[6, 10].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[6, 10].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 10].BorderAround(true);
                            ExcelApp.Cells[6, 10].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 10].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Range[ExcelApp.Cells[5, 11], ExcelApp.Cells[5, 12]].Merge();
                            ExcelApp.Cells[5, 11] = "IGST";
                            ExcelApp.Cells[5, 11].ColumnWidth = 18;
                            ExcelApp.Cells[5, 11].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, 11].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, 11].Font.Size = 10;
                            ExcelApp.Cells[5, 11].Font.Name = "Arial";
                            ExcelApp.Cells[5, 11].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, 11].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Range[ExcelApp.Cells[5, 11], ExcelApp.Cells[5, 12]].BorderAround(true);
                            ExcelApp.Range[ExcelApp.Cells[5, 11], ExcelApp.Cells[5, 12]].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[5, 11].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[5, 11].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Cells[6, 11] = "Rate%";
                            ExcelApp.Cells[6, 11].ColumnWidth = 8;
                            ExcelApp.Cells[6, 11].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[6, 11].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 11].Font.Size = 8;
                            ExcelApp.Cells[6, 11].Font.Name = "Arial";
                            ExcelApp.Cells[6, 11].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[6, 11].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 11].BorderAround(true);
                            ExcelApp.Cells[6, 11].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 11].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 11].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Cells[6, 12] = "Amount";
                            ExcelApp.Cells[6, 12].ColumnWidth = 10;
                            ExcelApp.Cells[6, 12].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[6, 12].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 12].Font.Size = 8;
                            ExcelApp.Cells[6, 12].Font.Name = "Arial";
                            ExcelApp.Cells[6, 12].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[6, 12].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 12].BorderAround(true);
                            ExcelApp.Cells[6, 12].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 12].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 12].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            ExcelApp.Range[ExcelApp.Cells[5, 13], ExcelApp.Cells[6, 13]].Merge();
                            ExcelApp.Cells[5, 13] = "Net Amount";
                            ExcelApp.Cells[5, 13].ColumnWidth = 18;
                            ExcelApp.Cells[5, 13].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, 13].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, 13].Font.Size = 10;
                            ExcelApp.Cells[5, 13].Font.Name = "Arial";
                            ExcelApp.Cells[5, 13].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, 13].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 13].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[6, 13].BorderAround(true);
                            ExcelApp.Cells[6, 13].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[6, 13].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            ExcelApp.Cells[6, 13].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                            int num = 1;
                            int row = 7;
                            int gstrow = 0;
                            int igstrow = 0;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                ExcelApp.Cells[row, 1] = num;
                                ExcelApp.Cells[row, 1].BorderAround(true);
                                ExcelApp.Cells[row, 1].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 1].Font.Size = 9;
                                ExcelApp.Cells[row, 2] = Convert.ToDateTime(dt.Rows[i]["InvDate"].ToString()).ToString("dd/MM/yyy");
                                ExcelApp.Cells[row, 2].BorderAround(true);
                                ExcelApp.Cells[row, 2].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 2].Font.Size = 9;
                                ExcelApp.Cells[row, 3] = dt.Rows[i]["cust_name"].ToString();
                                ExcelApp.Cells[row, 3].BorderAround(true);
                                ExcelApp.Cells[row, 3].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 3].Font.Size = 9;
                                ExcelApp.Cells[row, 4] = "Sales";
                                ExcelApp.Cells[row, 4].BorderAround(true);
                                ExcelApp.Cells[row, 4].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 4].Font.Size = 9;
                                ExcelApp.Cells[row, 5] = dt.Rows[i]["InvNumber"].ToString();
                                ExcelApp.Cells[row, 5].BorderAround(true);
                                ExcelApp.Cells[row, 5].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 5].Font.Size = 9;
                                ExcelApp.Cells[row, 6] = 0;
                                ExcelApp.Cells[row, 6].BorderAround(true);
                                ExcelApp.Cells[row, 6].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 6].Font.Size = 9;
                                ExcelApp.Cells[row, 13] = Convert.ToDouble(dt.Rows[i]["TotalAmount"].ToString());
                                ExcelApp.Cells[row, 13].BorderAround(true);
                                ExcelApp.Cells[row, 13].Borders.Color = Color.FromArgb(0, 0, 0);
                                ExcelApp.Cells[row, 13].Font.Size = 9;
                                total_net = total_net + Convert.ToDouble(dt.Rows[i]["TotalAmount"].ToString());
                                DataTable data_from_sales = this.cntrl.data_from_sales(dt.Rows[i]["InvNumber"].ToString());
                                gstrow = row;
                                igstrow = row;
                                double grossAmount = 0;
                                if (data_from_sales.Rows.Count > 0)
                                {
                                    double gstRatetotal = 0;
                                    double gesttotal = 0;
                                    for (int j = 0; data_from_sales.Rows.Count > j; j++)
                                    {
                                        gstRatetotal = 0; gesttotal = 0;
                                        if (Convert.ToDouble(data_from_sales.Rows[j]["GST"].ToString()) > 0)
                                        {
                                            gstRatetotal = Convert.ToDouble(data_from_sales.Rows[j]["GST"].ToString()) / 2;
                                            gesttotal = ((Convert.ToDouble(data_from_sales.Rows[j]["total"].ToString()) * Convert.ToDouble(data_from_sales.Rows[j]["GST"].ToString())) / 100) / 2;
                                            ExcelApp.Cells[gstrow, 7] = gstRatetotal;
                                            ExcelApp.Cells[gstrow, 7].BorderAround(true);
                                            ExcelApp.Cells[gstrow, 7].Borders.Color = Color.FromArgb(0, 0, 0);
                                            ExcelApp.Cells[gstrow, 7].Font.Size = 9;
                                            ExcelApp.Cells[gstrow, 8] = gesttotal;
                                            ExcelApp.Cells[gstrow, 8].BorderAround(true);
                                            ExcelApp.Cells[gstrow, 8].Borders.Color = Color.FromArgb(0, 0, 0);
                                            ExcelApp.Cells[gstrow, 8].Font.Size = 9;
                                            ExcelApp.Cells[gstrow, 9] = gstRatetotal;
                                            ExcelApp.Cells[gstrow, 9].BorderAround(true);
                                            ExcelApp.Cells[gstrow, 9].Borders.Color = Color.FromArgb(0, 0, 0);
                                            ExcelApp.Cells[gstrow, 9].Font.Size = 9;
                                            ExcelApp.Cells[gstrow, 10] = gesttotal;
                                            ExcelApp.Cells[gstrow, 10].BorderAround(true);
                                            ExcelApp.Cells[gstrow, 10].Borders.Color = Color.FromArgb(0, 0, 0);
                                            ExcelApp.Cells[gstrow, 10].Font.Size = 9;
                                            gstrow = gstrow + 1;
                                            total_gst = total_gst + gesttotal;
                                        }
                                        grossAmount = grossAmount + Convert.ToDouble(data_from_sales.Rows[j]["total"].ToString());
                                    }
                                    total_amount = total_amount + grossAmount;
                                    ExcelApp.Cells[row, 6] = grossAmount;
                                    gstrow = gstrow - 1;
                                }
                                DataTable data_from_sales_igst = this.cntrl.data_from_sales_igst(dt.Rows[i]["InvNumber"].ToString());
                                if (data_from_sales_igst.Rows.Count > 0)
                                {
                                    double gesttotal = 0;
                                    for (int j = 0; data_from_sales_igst.Rows.Count > j; j++)
                                    {
                                        gesttotal = 0;
                                        if (Convert.ToDouble(data_from_sales_igst.Rows[j]["IGST"].ToString()) > 0)
                                        {
                                            gesttotal = (Convert.ToDouble(data_from_sales_igst.Rows[j]["total"].ToString()) * Convert.ToDouble(data_from_sales_igst.Rows[j]["IGST"].ToString())) / 100;
                                            ExcelApp.Cells[igstrow, 11] = data_from_sales_igst.Rows[j]["IGST"].ToString();
                                            ExcelApp.Cells[igstrow, 11].BorderAround(true);
                                            ExcelApp.Cells[igstrow, 11].Borders.Color = Color.FromArgb(0, 0, 0);
                                            ExcelApp.Cells[igstrow, 11].Font.Size = 9;
                                            ExcelApp.Cells[igstrow, 12] = gesttotal;
                                            ExcelApp.Cells[igstrow, 12].BorderAround(true);
                                            ExcelApp.Cells[igstrow, 12].Borders.Color = Color.FromArgb(0, 0, 0);
                                            ExcelApp.Cells[igstrow, 12].Font.Size = 9;
                                            igstrow = igstrow + 1;
                                            total_igst = total_igst + gesttotal;
                                        }
                                    }
                                    igstrow = igstrow - 1;
                                }
                                if (gstrow > igstrow)
                                {
                                    row = gstrow;
                                }
                                else
                                { row = igstrow; }
                                data_from_sales_igst.Clear();
                                data_from_sales.Clear();
                                row = row + 1;
                                num = num + 1;
                            }
                            ExcelApp.Range[ExcelApp.Cells[5, 1], ExcelApp.Cells[row, 13]].BorderAround(true);
                            ExcelApp.Range[ExcelApp.Cells[5, 1], ExcelApp.Cells[row, 13]].Borders.Color = Color.FromArgb(0, 0, 0);
                            ExcelApp.Cells[row, 6].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[row, 6].Font.Size = 10;
                            ExcelApp.Cells[row, 8].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[row, 8].Font.Size = 10;
                            ExcelApp.Cells[row, 10].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[row, 10].Font.Size = 10;
                            ExcelApp.Cells[row, 12].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[row, 12].Font.Size = 10;
                            ExcelApp.Cells[row, 13].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[row, 13].Font.Size = 10;
                            ExcelApp.Cells[row, 6] = total_amount;
                            ExcelApp.Cells[row, 8] = total_gst;
                            ExcelApp.Cells[row, 10] = total_gst;
                            ExcelApp.Cells[row, 12] = total_igst;
                            ExcelApp.Cells[row, 13] = total_net;    

                            Lab_Msg.Visible = false;
                            ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                            ExcelApp.ActiveWorkbook.Saved = true;
                            ExcelApp.Quit();
                            MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }// if record found
                    else
                    {
                        Lab_Msg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
