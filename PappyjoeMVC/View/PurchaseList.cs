using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class PurchaseList : Form
    {
        PurchaseList_controller cntrl=new PurchaseList_controller();
        public PurchaseList()
        {
            InitializeComponent();
        }
        public void setcontroller(PurchaseList_controller controller)
        {
            cntrl = controller;
        }
        public PurchaseList(string date1, string date2)
        {
            InitializeComponent();
            dateTo = date1;
            dateFrom = date2;
            flag_fromInventory = true;
        }
        string check = "cash"; bool flag_fromInventory = false;
        public string dateTo;
        public string dateFrom;
        public void load()
        {
            try
            {
                dgv_Purchase.Rows.Clear();
                string fromdate = DTP_From.Value.ToString("yyyy-MM-dd");
                string todate = DTP_To.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(fromdate).Date > Convert.ToDateTime(todate).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DTP_From.Value = DateTime.Today;
                }
                else
                {
                    int slno = 0;
                    DataTable dt = this.cntrl.getPurchase_btwndates(fromdate, todate);
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {
                            dgv_Purchase.Rows.Add();
                            slno = i + 1;
                            dgv_Purchase.Rows[i].Cells["colslNo"].Value = slno;
                            dgv_Purchase.Rows[i].Cells["colPurNum"].Value = dt.Rows[i]["PurchNumber"].ToString();
                            dgv_Purchase.Rows[i].Cells["colPurchDate"].Value = Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("MM/dd/yyyy");
                            dgv_Purchase.Rows[i].Cells["SupplierId"].Value = dt.Rows[i]["Sup_Code"].ToString();
                            dgv_Purchase.Rows[i].Cells["colName"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                            dgv_Purchase.Rows[i].Cells["colTotalAmount"].Value = dt.Rows[i]["GrandTotal"].ToString();
                            dgv_Purchase.Rows[i].Cells["colPayment"].Value = dt.Rows[i]["PurchType"].ToString();
                        }
                        Lab_Msg.Visible = false;
                    }
                    else
                    {
                        Lab_Msg.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void frmPurchaseList_Load(object sender, EventArgs e)
        {
            try
            {
                if (flag_fromInventory == true)
                {
                    DTP_From.Value = Convert.ToDateTime(dateTo);
                    DTP_To.Value = Convert.ToDateTime(dateFrom);
                    int slno = 0;
                    DataTable dt = this.cntrl.getPurchase_btwndates(Convert.ToDateTime(dateTo).ToString("yyyy-MM-dd"), Convert.ToDateTime(dateFrom).ToString("yyyy-MM-dd"));
                    if (dt.Rows.Count != 0)
                    {
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {
                            dgv_Purchase.Rows.Add();
                            slno = i + 1;
                            dgv_Purchase.Rows[i].Cells["colslNo"].Value = slno;
                            dgv_Purchase.Rows[i].Cells["colPurNum"].Value = dt.Rows[i]["PurchNumber"].ToString();
                            dgv_Purchase.Rows[i].Cells["colPurchDate"].Value = Convert.ToDateTime(dt.Rows[i]["PurchDate"].ToString()).ToString("MM/dd/yyyy");
                            dgv_Purchase.Rows[i].Cells["SupplierId"].Value = dt.Rows[i]["Sup_Code"].ToString();
                            dgv_Purchase.Rows[i].Cells["colName"].Value = dt.Rows[i]["Supplier_Name"].ToString();
                            dgv_Purchase.Rows[i].Cells["colTotalAmount"].Value = dt.Rows[i]["GrandTotal"].ToString();
                            dgv_Purchase.Rows[i].Cells["colPayment"].Value = dt.Rows[i]["PurchType"].ToString();
                        }
                        Lab_Msg.Visible = false;
                    }
                }
                else
                {
                    load();
                }
                dgv_Purchase.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgv_Purchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv_Purchase.EnableHeadersVisualStyles = false;
                dgv_Purchase.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_Purchase.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
                PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rad_Cash_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Cash.Checked == true)
            {
                rad_Credit.Checked = false;
                check = "cash";
            }
            else
            {
                rad_Credit.Checked = true;
                rad_Cash.Checked = false;
                check = "credit";
            }
            load();
        }

        private void rad_Credit_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Credit.Checked == true)
            {
                rad_Cash.Checked = false;
                check = "credit";
            }
            else
            {
                rad_Cash.Checked = true;
                rad_Credit.Checked = false;
                check = "cash";
            }
            load();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Purchase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PappyjoeMVC.Model.Connection.MyGlobals.global_Flag = true;
            DataTable data_from_Pur_Master = this.cntrl.data_from_Pur_Master(dgv_Purchase.CurrentRow.Cells["colPurNum"].Value);
            DataTable data_from_purchase = this.cntrl.data_from_purchase(dgv_Purchase.CurrentRow.Cells["colPurNum"].Value);
            var form2 = new PappyjoeMVC.View.Purchase(data_from_Pur_Master, data_from_purchase);
            form2.ShowDialog();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            load();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            PappyjoeMVC.Model.Connection.MyGlobals.Date_From = DTP_From.Value.ToString("yyyy-MM-dd");
            PappyjoeMVC.Model.Connection.MyGlobals.Date_To = DTP_To.Value.ToString("yyyy-MM-dd");
            load();
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            string PathName = "";
            string fromdate = DTP_From.Value.ToString("yyyy-MM-dd");
            string todate = DTP_To.Value.ToString("yyyy-MM-dd");
            string[] strarray;
            strarray = new string[] { "Date", "Particulars", "Supplier", "Address", "Voucher Type", "Vch No.", "Quantity", "Rate", "Gross Total" };
            int[] intarray;
            intarray = new int[] { 10, 25, 25, 25, 14, 10, 8, 8, 10 };
            if (Convert.ToDateTime(fromdate).Date > Convert.ToDateTime(todate).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DTP_From.Value = DateTime.Today;
            }
            else
            {
                DataTable dt = this.cntrl.dt(fromdate,todate);
                if (dt.Rows.Count != 0)
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
                        int count = dt.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 15]].Merge();
                        ExcelApp.Cells[1, 1] = "Purchase Register";
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
                        ExcelApp.Range[ExcelApp.Cells[5, 10], ExcelApp.Cells[5, 11]].Merge();
                        ExcelApp.Cells[5, 10] = "CGST";
                        ExcelApp.Cells[5, 10].ColumnWidth = 18;
                        ExcelApp.Cells[5, 10].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[5, 10].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[5, 10].Font.Size = 10;
                        ExcelApp.Cells[5, 10].Font.Name = "Arial";
                        ExcelApp.Cells[5, 10].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[5, 10].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Range[ExcelApp.Cells[5, 10], ExcelApp.Cells[5, 11]].BorderAround(true);
                        ExcelApp.Range[ExcelApp.Cells[5, 10], ExcelApp.Cells[5, 11]].Borders.Color = Color.FromArgb(0, 0, 0);
                        ExcelApp.Cells[5, 10].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        ExcelApp.Cells[5, 10].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        ExcelApp.Cells[6, 10] = "Rate%";
                        ExcelApp.Cells[6, 10].ColumnWidth = 8;
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

                        ExcelApp.Cells[6, 11] = "Amount";
                        ExcelApp.Cells[6, 11].ColumnWidth = 10;
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

                        ExcelApp.Range[ExcelApp.Cells[5, 12], ExcelApp.Cells[5, 13]].Merge();
                        ExcelApp.Cells[5, 12] = "SGST";
                        ExcelApp.Cells[5, 12].ColumnWidth = 18;
                        ExcelApp.Cells[5, 12].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[5, 12].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[5, 12].Font.Size = 10;
                        ExcelApp.Cells[5, 12].Font.Name = "Arial";
                        ExcelApp.Cells[5, 12].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[5, 12].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Range[ExcelApp.Cells[5, 12], ExcelApp.Cells[5, 13]].BorderAround(true);
                        ExcelApp.Range[ExcelApp.Cells[5, 12], ExcelApp.Cells[5, 13]].Borders.Color = Color.FromArgb(0, 0, 0);
                        ExcelApp.Cells[5, 12].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        ExcelApp.Cells[5, 12].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        ExcelApp.Cells[6, 12] = "Rate%";
                        ExcelApp.Cells[6, 12].ColumnWidth = 8;
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

                        ExcelApp.Cells[6, 13] = "Amount";
                        ExcelApp.Cells[6, 13].ColumnWidth = 10;
                        ExcelApp.Cells[6, 13].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[6, 13].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[6, 13].Font.Size = 8;
                        ExcelApp.Cells[6, 13].Font.Name = "Arial";
                        ExcelApp.Cells[6, 13].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[6, 13].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[6, 13].BorderAround(true);
                        ExcelApp.Cells[6, 13].Borders.Color = Color.FromArgb(0, 0, 0);
                        ExcelApp.Cells[6, 13].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        ExcelApp.Cells[6, 13].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        ExcelApp.Range[ExcelApp.Cells[5, 14], ExcelApp.Cells[5, 15]].Merge();
                        ExcelApp.Cells[5, 14] = "IGST";
                        ExcelApp.Cells[5, 14].ColumnWidth = 18;
                        ExcelApp.Cells[5, 14].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[5, 14].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[5, 14].Font.Size = 10;
                        ExcelApp.Cells[5, 14].Font.Name = "Arial";
                        ExcelApp.Cells[5, 14].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[5, 14].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Range[ExcelApp.Cells[5, 14], ExcelApp.Cells[5, 15]].BorderAround(true);
                        ExcelApp.Range[ExcelApp.Cells[5, 14], ExcelApp.Cells[5, 15]].Borders.Color = Color.FromArgb(0, 0, 0);
                        ExcelApp.Cells[5, 14].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        ExcelApp.Cells[5, 14].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        ExcelApp.Cells[6, 14] = "Rate%";
                        ExcelApp.Cells[6, 14].ColumnWidth = 8;
                        ExcelApp.Cells[6, 14].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[6, 14].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[6, 14].Font.Size = 8;
                        ExcelApp.Cells[6, 14].Font.Name = "Arial";
                        ExcelApp.Cells[6, 14].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[6, 14].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[6, 14].BorderAround(true);
                        ExcelApp.Cells[6, 14].Borders.Color = Color.FromArgb(0, 0, 0);
                        ExcelApp.Cells[6, 14].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        ExcelApp.Cells[6, 14].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        ExcelApp.Cells[6, 15] = "Amount";
                        ExcelApp.Cells[6, 15].ColumnWidth = 10;
                        ExcelApp.Cells[6, 15].EntireRow.Font.Bold = true;
                        ExcelApp.Cells[6, 15].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[6, 15].Font.Size = 8;
                        ExcelApp.Cells[6, 15].Font.Name = "Arial";
                        ExcelApp.Cells[6, 15].Font.Color = Color.FromArgb(255, 255, 255);
                        ExcelApp.Cells[6, 15].Interior.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[6, 15].BorderAround(true);
                        ExcelApp.Cells[6, 15].Borders.Color = Color.FromArgb(0, 0, 0);
                        ExcelApp.Cells[6, 15].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        ExcelApp.Cells[6, 15].VerticalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                        int row = 7;
                        double totalamount = 0;
                        double totalgst = 0;
                        double totaligst = 0;
                        double totalcgst = 0;
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {
                            DataTable data_from_purchase = this.cntrl.data_from_purchase(dt.Rows[i]["PurchNumber"].ToString());
                            if (data_from_purchase.Rows.Count > 0)
                            {
                                for (int j = 0; data_from_purchase.Rows.Count > j; j++)
                                {

                                    ExcelApp.Cells[row, 1] = Convert.ToDateTime(data_from_purchase.Rows[j]["PurchDate"].ToString()).ToString("dd/MM/yyy");
                                    ExcelApp.Cells[row, 1].BorderAround(true);
                                    ExcelApp.Cells[row, 1].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 1].Font.Size = 9;
                                    ExcelApp.Cells[row, 2] = data_from_purchase.Rows[j]["Desccription"].ToString();
                                    ExcelApp.Cells[row, 2].BorderAround(true);
                                    ExcelApp.Cells[row, 2].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 2].Font.Size = 9;
                                    ExcelApp.Cells[row, 3] = dt.Rows[i]["Supplier_Name"].ToString();
                                    ExcelApp.Cells[row, 3].BorderAround(true);
                                    ExcelApp.Cells[row, 3].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 3].Font.Size = 9;
                                    ExcelApp.Cells[row, 4] = dt.Rows[i]["Address1"].ToString();
                                    ExcelApp.Cells[row, 4].BorderAround(true);
                                    ExcelApp.Cells[row, 4].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 4].Font.Size = 9;
                                    ExcelApp.Cells[row, 5] = "Purchase";
                                    ExcelApp.Cells[row, 5].BorderAround(true);
                                    ExcelApp.Cells[row, 5].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 5].Font.Size = 9;
                                    ExcelApp.Cells[row, 6] = dt.Rows[i]["PurchNumber"].ToString();
                                    ExcelApp.Cells[row, 6].BorderAround(true);
                                    ExcelApp.Cells[row, 6].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 6].Font.Size = 9;
                                    ExcelApp.Cells[row, 7] = data_from_purchase.Rows[j]["Qty"].ToString();
                                    ExcelApp.Cells[row, 7].BorderAround(true);
                                    ExcelApp.Cells[row, 7].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 7].Font.Size = 9;
                                    ExcelApp.Cells[row, 8] = data_from_purchase.Rows[j]["Rate"].ToString();
                                    ExcelApp.Cells[row, 8].BorderAround(true);
                                    ExcelApp.Cells[row, 8].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 8].Font.Size = 9;
                                    ExcelApp.Cells[row, 9] = data_from_purchase.Rows[j]["Amount"].ToString();
                                    ExcelApp.Cells[row, 9].BorderAround(true);
                                    ExcelApp.Cells[row, 9].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 9].Font.Size = 9;
                                    ExcelApp.Cells[row, 10] = "";
                                    ExcelApp.Cells[row, 10].BorderAround(true);
                                    ExcelApp.Cells[row, 10].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 10].Font.Size = 9;
                                    ExcelApp.Cells[row, 11] = "0";
                                    ExcelApp.Cells[row, 11].BorderAround(true);
                                    ExcelApp.Cells[row, 11].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 11].Font.Size = 9;
                                    ExcelApp.Cells[row, 12].BorderAround(true);
                                    ExcelApp.Cells[row, 12].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 12].Font.Size = 9;
                                    ExcelApp.Cells[row, 13].BorderAround(true);
                                    ExcelApp.Cells[row, 13].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 13].Font.Size = 9;
                                    ExcelApp.Cells[row, 14].BorderAround(true);
                                    ExcelApp.Cells[row, 14].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 14].Font.Size = 9;
                                    ExcelApp.Cells[row, 15].BorderAround(true);
                                    ExcelApp.Cells[row, 15].Borders.Color = Color.FromArgb(0, 0, 0);
                                    ExcelApp.Cells[row, 15].Font.Size = 9;
                                    totalamount = totalamount + Convert.ToDouble(data_from_purchase.Rows[j]["Amount"].ToString());
                                    double amount = 0;
                                    amount = Convert.ToDouble(data_from_purchase.Rows[j]["Rate"].ToString()) * Convert.ToDouble(data_from_purchase.Rows[j]["Qty"].ToString());
                                    if (Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) > 0)
                                    {
                                        ExcelApp.Cells[row, 10] = Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) / 2;
                                        ExcelApp.Cells[row, 11] = amount * ((Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) / 2) / 100);
                                        ExcelApp.Cells[row, 12] = Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) / 2;
                                        ExcelApp.Cells[row, 13] = amount * ((Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) / 2) / 100);
                                        totalgst = totalgst + amount * ((Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) / 2) / 100);
                                        totalcgst = totalcgst + amount * ((Convert.ToDouble(data_from_purchase.Rows[j]["GST"].ToString()) / 2) / 100);
                                    }
                                    else if (Convert.ToDouble(data_from_purchase.Rows[j]["IGST"].ToString()) > 0)
                                    {
                                        ExcelApp.Cells[row, 14] = data_from_purchase.Rows[j]["IGST"].ToString();
                                        ExcelApp.Cells[row, 15] = amount * (Convert.ToDouble(data_from_purchase.Rows[j]["IGST"].ToString()) / 100);
                                        totaligst = totaligst + amount * (Convert.ToDouble(data_from_purchase.Rows[j]["IGST"].ToString()) / 100);
                                    }
                                    row = row + 1;
                                }
                            }
                            data_from_purchase.Clear();
                        }
                        for (int i = 1; i < 16; i++)
                        {
                            ExcelApp.Cells[row, i].BorderAround(true);
                            ExcelApp.Cells[row, i].Font.Size = 10;
                            ExcelApp.Cells[row, i].EntireRow.Font.Bold = true;
                        }
                        ExcelApp.Cells[row, 9] = totalamount;
                        ExcelApp.Cells[row, 11] = totalgst;
                        ExcelApp.Cells[row, 13] = totalgst;
                        ExcelApp.Cells[row, 15] = totaligst;

                        Lab_Msg.Visible = false;
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    Lab_Msg.Visible = true;
                }
            }
        }
    }
}
