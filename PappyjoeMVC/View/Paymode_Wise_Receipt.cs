using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Paymode_Wise_Receipt : Form,Paymode_Wise_Receipt_interface
    {
        public Paymode_Wise_Receipt()
        {
            InitializeComponent();
        }
        public bool cmb_flag = false;
        Paymode_Wise_Receipt_controller ctrlr;
        //PappyjoeMVC.Model.select s = new PappyjoeMVC.Model.select();
        decimal amount = 0, paid = 0, due = 0,Totalamount = 0, Totalpaid = 0, Totaldue = 0;
        public string doctor_id = "", service, doctr, mode, checkStr = "0", PathName = "", strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
        public void setController(Paymode_Wise_Receipt_controller controller)
        {
            ctrlr = controller;
        }
        public void getdocname(DataTable doctor_rs)
        {
            if (doctor_rs.Rows.Count > 0)
            {
                for (int i = 0; i < doctor_rs.Rows.Count; i++)
                {
                    cmb_doctor.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                    cmb_doctor.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                    cmb_doctor.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                }
            }
        }
        private void Paymode_Wise_Receipt_Load(object sender, EventArgs e)
        {
            cmb_flag = true;
            cmb_doctor.Items.Add("All Doctor");
            cmb_doctor.ValueMember = "0";
            cmb_doctor.DisplayMember = "All Doctor";
            this.ctrlr.getdocname();
            cmb_doctor.SelectedIndex = 0;
            Cmb_Modeofpayment.SelectedIndex = 0;
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, 1);
            DTP_From.Value = date;
            string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
            string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
            DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment(date1, date2);
            fillDGV_Receipt(dtb, date1, date2);
            Dgv_Receipt.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Receipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Receipt.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
            Dgv_Receipt.EnableHeadersVisualStyles = false;
            Dgv_Receipt.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Receipt.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn cl in Dgv_Receipt.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                cl.Width = 80;
            }
            cmb_flag = false;
        }
        public void getinvdata(DataTable dt_inv)
        {
            for (int i = 0; i < dt_inv.Rows.Count;i++)
            {
                Dgv_Receipt.Rows[i].Cells["ColProcedure"].Value = service + " (Qty:" + dt_inv.Rows[0]["unit"].ToString() + ")";
                Dgv_Receipt.Rows[i].Cells["ColTotalCost"].Value = dt_inv.Rows[0]["Total Cost"].ToString();
                Dgv_Receipt.Rows[i].Cells["ColTAmount"].Value = dt_inv.Rows[0]["Total Income"].ToString();
                amount = decimal.Parse(dt_inv.Rows[0]["Total Income"].ToString());
            }
        }
        public void fillDGV_Receipt(DataTable dtb_Receipt, string d1, string d2)
        {
            try { 
            Dgv_Receipt.RowCount = 0;
            Lab_Msg.Hide();
            if (dtb_Receipt.Rows.Count > 0)
            {
                for (int i = 0; i < dtb_Receipt.Rows.Count; i++)
                {
                    amount = 0; paid = 0; due = 0;
                    Totalamount = 0; Totalpaid = 0; Totaldue = 0;
                    Dgv_Receipt.Rows.Add();
                    Dgv_Receipt.Rows[i].Cells["ColSLNo"].Value = i + 1;
                    Dgv_Receipt.Rows[i].Cells["ColPt_Name"].Value = dtb_Receipt.Rows[i]["pt_name"].ToString();
                    Dgv_Receipt.Rows[i].Cells["Colinvo"].Value = dtb_Receipt.Rows[i]["invoice_no"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColReceipt"].Value = dtb_Receipt.Rows[i]["receipt_no"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColamountPaid"].Value = dtb_Receipt.Rows[i]["amount_paid"].ToString();
                    Dgv_Receipt.Rows[i].Cells["colTAmountDue"].Value = dtb_Receipt.Rows[i]["Total Amount Due"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColModeOfPayment"].Value = dtb_Receipt.Rows[i]["mode_of_payment"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColDate"].Value = Convert.ToDateTime(dtb_Receipt.Rows[i]["payment_date"].ToString()).ToString("dd-MM-yyyy");
                    Dgv_Receipt.Rows[i].Cells["ColDoctor"].Value = dtb_Receipt.Rows[i]["doctor_name"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColBank"].Value = dtb_Receipt.Rows[i]["BankName"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColNumber"].Value = dtb_Receipt.Rows[i]["Number"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColCardNo"].Value = dtb_Receipt.Rows[i]["CardNo"].ToString();
                    Dgv_Receipt.Rows[i].Cells["COl4Digit"].Value = dtb_Receipt.Rows[i]["fourDigitNo"].ToString();
                    Dgv_Receipt.Rows[i].Cells["ColDD"].Value = dtb_Receipt.Rows[i]["DDNumber"].ToString();
                    service=dtb_Receipt.Rows[i]["procedure_name"].ToString();
                    this.ctrlr.getinvdata(dtb_Receipt.Rows[i]["invoice_no"].ToString(), dtb_Receipt.Rows[i]["procedure_name"].ToString());
                    due = decimal.Parse(dtb_Receipt.Rows[i]["Total Amount Due"].ToString());
                    paid = decimal.Parse(dtb_Receipt.Rows[i]["amount_paid"].ToString());
                    Totalamount = Totalamount + amount;
                    Totalpaid = Totalpaid + paid;
                    Totaldue = Totaldue + due;
                }
                int count = Dgv_Receipt.Rows.Count;
                Lab_Total.Text = count.ToString();
                Lab_Amount.Text = Convert.ToDecimal(Totalamount).ToString("#0.00");
                Lab_Paid.Text = Convert.ToDecimal(Totalpaid).ToString("#0.00");
                Lab_Due.Text = Convert.ToDecimal(Totaldue).ToString("#0.00");
            }
            else
            {
                Lab_Msg.Show();
                Lab_Total.Text = "0";
                Lab_Amount.Text = "0.00";
                Lab_Paid.Text = "0.00";
                Lab_Due.Text = "0.00";
            }
            }
            catch(Exception ex)
            { MessageBox.Show("Data Loading Error", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_Show_Click(object sender, EventArgs e)
        {
            string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
            string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
            if (cmb_doctor.SelectedIndex > 0 && Cmb_Modeofpayment.SelectedIndex > 0)
            {
                doctr = cmb_doctor.SelectedItem.ToString();
                mode = Cmb_Modeofpayment.SelectedItem.ToString();
                DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Both(date1, date2, doctr, mode);
                fillDGV_Receipt(dtb, date1, date2);
            }
            else if (cmb_doctor.SelectedIndex == 0 && Cmb_Modeofpayment.SelectedIndex > 0)
            {
                mode = Cmb_Modeofpayment.SelectedItem.ToString();
                DataTable dtb =this.ctrlr.ReceiptReceivedModeofPayment_Mode(date1, date2, mode);
                fillDGV_Receipt(dtb, date1, date2);
            }
            else if (Cmb_Modeofpayment.SelectedIndex == 0 && cmb_doctor.SelectedIndex > 0)
            {
                doctr = cmb_doctor.SelectedItem.ToString();
                DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Doctor(date1, date2, doctr);
                fillDGV_Receipt(dtb, date1, date2);
            }
            else{
                DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment(date1, date2);
                fillDGV_Receipt(dtb, date1, date2);
            }
        }
        private void cmb_doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
            string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
            if (cmb_flag == false) {
                if (cmb_doctor.SelectedIndex > 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                {
                    doctr = cmb_doctor.SelectedItem.ToString();
                    mode = Cmb_Modeofpayment.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Both(date1, date2, doctr, mode);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else if (cmb_doctor.SelectedIndex == 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                {
                    mode = Cmb_Modeofpayment.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Mode(date1, date2, mode);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else if (Cmb_Modeofpayment.SelectedIndex == 0 && cmb_doctor.SelectedIndex > 0)
                {
                    doctr = cmb_doctor.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Doctor(date1, date2, doctr);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else {
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment(date1, date2);
                    fillDGV_Receipt(dtb, date1, date2);
                }
            }
        }
        public void CmbSelectionChange()
        {
            if (Cmb_Modeofpayment.SelectedIndex == 1)
            {
                Dgv_Receipt.Columns["ColBank"].Visible = false;
                Dgv_Receipt.Columns["ColNumber"].Visible = false;
                Dgv_Receipt.Columns["ColCardNo"].Visible = false;
                Dgv_Receipt.Columns["COl4Digit"].Visible = false;
                Dgv_Receipt.Columns["ColDD"].Visible = false;
                this.Dgv_Receipt.Columns["ColPt_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (Cmb_Modeofpayment.SelectedIndex == 2)
            {
                Dgv_Receipt.Columns["ColBank"].Visible = true;
                Dgv_Receipt.Columns["ColNumber"].Visible = true;
                Dgv_Receipt.Columns["ColCardNo"].Visible = false;
                Dgv_Receipt.Columns["COl4Digit"].Visible = false;
                Dgv_Receipt.Columns["ColDD"].Visible = false;
                this.Dgv_Receipt.Columns["ColPt_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (Cmb_Modeofpayment.SelectedIndex == 3)
            {
                Dgv_Receipt.Columns["ColCardNo"].Visible = true;
                Dgv_Receipt.Columns["COl4Digit"].Visible = true;
                Dgv_Receipt.Columns["ColBank"].Visible = false;
                Dgv_Receipt.Columns["ColNumber"].Visible = false;
                Dgv_Receipt.Columns["ColDD"].Visible = false;
                this.Dgv_Receipt.Columns["ColPt_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if (Cmb_Modeofpayment.SelectedIndex == 4)
            {
                Dgv_Receipt.Columns["ColBank"].Visible = true;
                Dgv_Receipt.Columns["ColDD"].Visible = true;
                Dgv_Receipt.Columns["ColCardNo"].Visible = false;
                Dgv_Receipt.Columns["ColNumber"].Visible = false;
                Dgv_Receipt.Columns["COl4Digit"].Visible = false;
                this.Dgv_Receipt.Columns["ColPt_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else {
                Dgv_Receipt.Columns["ColBank"].Visible = true;
                Dgv_Receipt.Columns["ColNumber"].Visible = true;
                Dgv_Receipt.Columns["ColCardNo"].Visible = true;
                Dgv_Receipt.Columns["COl4Digit"].Visible = true;
                Dgv_Receipt.Columns["ColDD"].Visible = true;
                this.Dgv_Receipt.Columns["ColPt_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void Cmb_Modeofpayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date1 = DTP_From.Value.ToString("yyyy-MM-dd");
            string date2 = Dtp_ReceiptTO.Value.ToString("yyyy-MM-dd");
            if (cmb_flag == false)
            {
                if (cmb_doctor.SelectedIndex > 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                {
                    doctr = cmb_doctor.SelectedItem.ToString();
                    mode= Cmb_Modeofpayment.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Both(date1, date2, doctr, mode);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else if (cmb_doctor.SelectedIndex == 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                {
                    mode = Cmb_Modeofpayment.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr. ReceiptReceivedModeofPayment_Mode(date1, date2, mode);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else if (Cmb_Modeofpayment.SelectedIndex == 0 && cmb_doctor.SelectedIndex > 0)
                {
                    doctr = cmb_doctor.SelectedItem.ToString();
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment_Doctor(date1, date2, doctr);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                else {
                    DataTable dtb = this.ctrlr.ReceiptReceivedModeofPayment(date1, date2);
                    fillDGV_Receipt(dtb, date1, date2);
                }
                CmbSelectionChange();
            }
        }
        private void Chk_RemoveAmountDue_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_RemoveAmountDue.Checked)
            {
                Dgv_Receipt.Columns["colTAmountDue"].Visible = false;
            }
            else
            { Dgv_Receipt.Columns["colTAmountDue"].Visible = true; }
        }
        private void btn_Export_Click(object sender, EventArgs e)
        {
            try {
                if (Dgv_Receipt.Rows.Count != 0){
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "ModeOfPayment Wise Receipt Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK){
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        if (Cmb_Modeofpayment.Text == "Cash"){
                            if (Chk_RemoveAmountDue.Checked == false)
                            {
                                int count = 12;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                            else{
                                int count = 11;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                        }
                        else if (Cmb_Modeofpayment.Text == "Cheque") {
                            if (Chk_RemoveAmountDue.Checked == false)
                            {
                                int count = 14;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                            else{
                                int count = 13;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                        }
                        else if (Cmb_Modeofpayment.Text == "Card") {
                            if (Chk_RemoveAmountDue.Checked == false)
                            {
                                int count = 14;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                            else {
                                int count = 13;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                        }
                        else if (Cmb_Modeofpayment.Text == "Demand Draft") {
                            if (Chk_RemoveAmountDue.Checked == false)
                            {
                                int count = 14;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                            else {
                                int count = 13;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                        }
                        else {
                            if (Chk_RemoveAmountDue.Checked == false)
                            {
                                int count = 17;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                            else {
                                int count = 16;
                                ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                            }
                        }
                        if (cmb_doctor.SelectedIndex > 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "" + mode + " WISE RECEIPT RECEIVED  OF DR." + doctr + "";
                        }
                        else if (cmb_doctor.SelectedIndex == 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                        { ExcelApp.Cells[1, 1] = "" + mode+ " WISE RECEIPT RECEIVED OF ALL DOCTOR"; }
                        else if (cmb_doctor.SelectedIndex == 0 && Cmb_Modeofpayment.SelectedIndex > 0)
                        { ExcelApp.Cells[1, 1] = " MODE OF PAYMENT WISE RECEIPT RECEIVED REPORT OF DR." + doctr + ""; }
                        else
                        { ExcelApp.Cells[1, 1] = "MODE OF PAYMENT WISE RECEIPT RECEIVED REPORT OF ALL DOCTOR"; }
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
                        ExcelApp.Cells[3, 2] = Dtp_ReceiptTO.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        int i1 = 1; bool cash = false; bool Cheque = false; bool card = false; bool dd = false;
                        for (int i = 1; i < Dgv_Receipt.Columns.Count + 1; i++)
                        {
                            if (Cmb_Modeofpayment.SelectedIndex > 0){
                                i1 = i;
                                if (Cmb_Modeofpayment.Text == "Cash")
                                {
                                    if (i == 9 || i == 10 || i == 11 || i == 12 || i == 13)
                                    {
                                        cash = true;
                                    }
                                    else {
                                        if (cash == true)
                                        {
                                            i1 = i1 - 5;
                                            if (i == 17)
                                            {
                                                if (Chk_RemoveAmountDue.Checked == false)
                                                {
                                                    ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                    ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                    ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[5, i1].Font.Size = 10;
                                                    ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                    ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                }
                                            }
                                            else {
                                                ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                ExcelApp.Cells[5, i1].Font.Size = 10;
                                                ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            }
                                        }
                                        else {
                                            ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                            ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                            ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            ExcelApp.Cells[5, i1].Font.Size = 10;
                                            ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                            ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                        }
                                    }
                                }
                                else if (Cmb_Modeofpayment.Text == "Cheque"){
                                    if (i == 11 || i == 12 || i == 13)
                                    {
                                        Cheque = true;
                                    }
                                    else{
                                        if (Cheque == true)
                                        {
                                            i1 = i1 - 3;
                                            if (i == 17)
                                            {
                                                if (Chk_RemoveAmountDue.Checked == false)
                                                {
                                                    ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                    ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                    ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[5, i1].Font.Size = 10;
                                                    ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                    ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                }
                                            }
                                            else{
                                                ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                ExcelApp.Cells[5, i1].Font.Size = 10;
                                                ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            }
                                        }
                                        else {
                                            ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                            ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                            ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            ExcelApp.Cells[5, i1].Font.Size = 10;
                                            ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                            ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                        }
                                    }
                                }
                                else if (Cmb_Modeofpayment.Text == "Card") {
                                    if (i == 9 || i == 10 || i == 13)
                                    {
                                        card = true;
                                    }
                                    else {
                                        if (card == true)
                                        {
                                            if (i1 == 14 || i1 == 15 || i1 == 16 || i1 == 17)
                                                i1 = i1 - 3;
                                            else
                                                i1 = i1 - 2;
                                            if (i == 17)
                                            {
                                                if (Chk_RemoveAmountDue.Checked == false)
                                                {
                                                    ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                    ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                    ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[5, i1].Font.Size = 10;
                                                    ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                    ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                }
                                            }
                                            else{
                                                ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                ExcelApp.Cells[5, i1].Font.Size = 10;
                                                ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            }
                                        }
                                        else {
                                            ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                            ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                            ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            ExcelApp.Cells[5, i1].Font.Size = 10;
                                            ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                            ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                        }
                                    }
                                }
                                else if (Cmb_Modeofpayment.Text == "Demand Draft"){
                                    if (i == 10 || i == 11 || i == 12)
                                    {
                                        dd = true;
                                    }
                                    else{
                                        if (dd == true)
                                        {
                                            i1 = i1 - 3;
                                            if (i == 17)
                                            {
                                                if (Chk_RemoveAmountDue.Checked == false)
                                                {
                                                    ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                    ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                    ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[5, i1].Font.Size = 10;
                                                    ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                    ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                    ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                }
                                            }
                                            else {
                                                ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                                ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                                ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                                ExcelApp.Cells[5, i1].Font.Size = 10;
                                                ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                                ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            }
                                        }
                                        else{
                                            ExcelApp.Cells[5, i1] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                            ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                            ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                            ExcelApp.Cells[5, i1].Font.Size = 10;
                                            ExcelApp.Cells[5, i1].Font.Name = "Arial";
                                            ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                            ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                        }
                                    }
                                }
                            }
                            else {
                                if (i == 17)
                                {
                                    if (Chk_RemoveAmountDue.Checked == false)
                                    {
                                        ExcelApp.Cells[5, i] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                        ExcelApp.Cells[5, i].ColumnWidth = 25;
                                        ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                                        ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                        ExcelApp.Cells[5, i].Font.Size = 10;
                                        ExcelApp.Cells[5, i].Font.Name = "Arial";
                                        ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                                        ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                    }
                                }
                                else{
                                    ExcelApp.Cells[5, i] = Dgv_Receipt.Columns[i - 1].HeaderText;
                                    ExcelApp.Cells[5, i].ColumnWidth = 25;
                                    ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                                    ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[5, i].Font.Size = 10;
                                    ExcelApp.Cells[5, i].Font.Name = "Arial";
                                    ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                                    ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                }
                            }
                        }
                        bool cash1 = false; bool Cheque1 = false; bool card1 = false; bool dd1 = false;/////Rows Adding
                        int j1 = 1;
                        for (int i = 0; i <= Dgv_Receipt.Rows.Count; i++)
                        {
                            try{
                                for (int j = 0; j < Dgv_Receipt.Columns.Count; j++)
                                {
                                    if (Cmb_Modeofpayment.SelectedIndex > 0)
                                    {
                                        j1 = j;
                                        if (Cmb_Modeofpayment.Text == "Cash")
                                        {
                                            if (j == 8 || j == 9 || j == 10 || j == 11 || j == 12)
                                            {
                                                cash1 = true;
                                            }
                                            else {
                                                if (cash1 == true)
                                                {
                                                    j1 = j1 - 5;
                                                    if (j == 16)
                                                    {
                                                        if (Chk_RemoveAmountDue.Checked == false)
                                                        {
                                                            ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                            ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                        }
                                                    }
                                                    else{
                                                        ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                        ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                    }
                                                }
                                                else {
                                                    ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                    ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                }
                                            }
                                        }
                                        else if (Cmb_Modeofpayment.Text == "Cheque")
                                        {
                                            if (j == 10 || j == 11 || j == 12)
                                            {
                                                Cheque1 = true;
                                            }
                                            else{
                                                if (Cheque1 == true)
                                                {
                                                    j1 = j1 - 3;
                                                    if (j == 16)
                                                    {
                                                        if (Chk_RemoveAmountDue.Checked == false)
                                                        {
                                                            ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                            ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                        }
                                                    }
                                                    else{
                                                        ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                        ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                    }
                                                }
                                                else{
                                                    ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                    ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                }
                                            }
                                        }
                                        else if (Cmb_Modeofpayment.Text == "Card")
                                        {
                                            if (j == 8 || j == 9 || j == 12)
                                            {
                                                card1 = true;
                                            }
                                            else{
                                                if (card1 == true)
                                                {
                                                    if (j1 == 13 || j1 == 14 || j1 == 15 || j1 == 16)
                                                        j1 = j1 - 3;
                                                    else
                                                        j1 = j1 - 2;
                                                    if (j == 16)
                                                    {
                                                        if (Chk_RemoveAmountDue.Checked == false)
                                                        {
                                                            ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                            ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                        }
                                                    }
                                                    else{
                                                        ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                        ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                    }
                                                }
                                                else {
                                                    ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                    ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                }
                                            }
                                        }
                                        else if (Cmb_Modeofpayment.Text == "Demand Draft")
                                        {
                                            if (j == 9 || j == 10 || j == 11)
                                            {
                                                dd1 = true;
                                            }
                                            else{
                                                if (dd1 == true)
                                                {
                                                    j1 = j1 - 3;
                                                    if (j == 16)
                                                    {
                                                        if (Chk_RemoveAmountDue.Checked == false)
                                                        {
                                                            ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                            ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                            ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                        }
                                                    }
                                                    else {
                                                        ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                        ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                        ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                    }
                                                }
                                                else{
                                                    ExcelApp.Cells[i + 6, j1 + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                    ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                    ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                                }
                                            }
                                        }
                                    }
                                    else{
                                        if (j == 16)
                                        {
                                            if (Chk_RemoveAmountDue.Checked == false)
                                            {
                                                ExcelApp.Cells[i + 6, j + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                                ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                                ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                                ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                            }
                                        }
                                        else{
                                            ExcelApp.Cells[i + 6, j + 1] = Dgv_Receipt.Rows[i].Cells[j].Value.ToString();
                                            ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                            ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                            ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                        }
                                    }
                                }
                                cash1 = false;
                                Cheque1 = false;
                                card1 = false;
                                dd1 = false;
                            }
                            catch (Exception ex){}
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
            { MessageBox.Show("Data Loading Error", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void practicedetails(DataTable dtp)
        {
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
        private void btnprint_Click(object sender, EventArgs e)
        {
            try{
                if (Dgv_Receipt.Rows.Count > 0)
                {
                    DataTable tbl = Dgv_Receipt.DataSource as DataTable;
                    string frdate = DTP_From.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DTP_From.Value.Month);
                    string fryear = DTP_From.Value.Year.ToString();
                    string todate = Dtp_ReceiptTO.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Dtp_ReceiptTO.Value.Month);
                    string toyear = Dtp_ReceiptTO.Value.Year.ToString();
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\ReceiptReceivedModeofPaymentWise.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table { border-collapse: collapse;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<div>");
                    sWrite.WriteLine("<table align=center width =900>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='center'><FONT COLOR=black FACE='Segoe UI' SIZE=4><b>PAY-MODE WISE  RECEIPT</b> </font></td");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='left' ><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>From:</b> " + DTP_From.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + Dtp_ReceiptTO.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=16 align='left'><FONT COLOR=black  FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    if (Dgv_Receipt.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='2%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3 >Slno.</font></td>");
                        sWrite.WriteLine("    <td align='center' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Patient</font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>  Invoice</font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>  Receipt</font></td>");
                        sWrite.WriteLine("    <td align='center' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Date</font></td>");
                        sWrite.WriteLine("    <td align='center' width='14%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Procedure</font></td>");
                        sWrite.WriteLine("    <td align='center' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Doctor</font></td>");
                        sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Mode of Payment</font></td>");
                        if (Cmb_Modeofpayment.SelectedIndex == 2)
                        {
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Bank Name</font></td>");
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Account Number</font></td>");
                        }
                        else if (Cmb_Modeofpayment.SelectedIndex == 3)
                        {
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Card Number</font></td>");
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Last 4-Digit</font></td>");
                        }
                        else if (Cmb_Modeofpayment.SelectedIndex == 4)
                        {
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Bank Name</font></td>");
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> DD-Number</font></td>");
                        }
                        else if (Cmb_Modeofpayment.SelectedIndex == 1) { }
                        else
                        {
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Bank Name</font></td>");
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Account Number</font></td>");
                            sWrite.WriteLine("    <td align='center' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Card Number</font></td>");
                            sWrite.WriteLine("    <td align='center' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Last 4-Digit</font></td>");
                            sWrite.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> DD-Number</font></td>");
                        }
                        sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Cost</font></td>");
                        sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> Amount</font></td>");
                        sWrite.WriteLine("    <td align='right' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>Amount Paid</font></td>");
                        if (Chk_RemoveAmountDue.Checked) { }
                        else
                        { sWrite.WriteLine("    <td align='left' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>Amount Due</font></td>"); }
                        sWrite.WriteLine("</tr>");
                        for (int j = 0; j < Dgv_Receipt.Rows.Count; j++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColSLNo"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColPt_Name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["Colinvo"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColReceipt"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColDate"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColProcedure"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColDoctor"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColModeOfPayment"].Value.ToString() + "</font></td>");
                            if (Cmb_Modeofpayment.SelectedIndex == 2)
                            {
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColBank"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColNumber"].Value.ToString() + "</font></td>");
                            }
                            else if (Cmb_Modeofpayment.SelectedIndex == 3)
                            {
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2> " + Dgv_Receipt.Rows[j].Cells["ColCardNo"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["COl4Digit"].Value.ToString() + "</font></td>");
                            }
                            else if (Cmb_Modeofpayment.SelectedIndex == 4)
                            {
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColBank"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColDD"].Value.ToString() + "</font></td>");
                            }
                            else if (Cmb_Modeofpayment.SelectedIndex == 1) { }
                            else
                            {
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColBank"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColNumber"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColCardNo"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["COl4Digit"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColDD"].Value.ToString() + "</font></td>");
                            }
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColTotalCost"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColTAmount"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["ColamountPaid"].Value.ToString() + "</font></td>");
                            if (Chk_RemoveAmountDue.Checked) { }
                            else
                            { sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2>" + Dgv_Receipt.Rows[j].Cells["colTAmountDue"].Value.ToString() + "</font></td>"); }
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></th>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                        if (Cmb_Modeofpayment.SelectedIndex == 2)
                        {
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                        }
                        else if (Cmb_Modeofpayment.SelectedIndex == 3)
                        {
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                        }
                        else if (Cmb_Modeofpayment.SelectedIndex == 4)
                        {
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                        }
                        else if (Cmb_Modeofpayment.SelectedIndex == 1) { }
                        else
                        {
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2></font></td>");
                        }
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2><b>Total</font></b></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2><b>" + Lab_Amount.Text + "</b></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2><b>" + Lab_Paid.Text + "</b></font></td>");
                        if (Chk_RemoveAmountDue.Checked) { }
                        else
                        { sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI'SIZE=2><b>" + Lab_Due.Text + "</b></font></td>"); }
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</font> </p></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black  FACE=Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\ReceiptReceivedModeofPaymentWise.html");
                    }
                }
                else
                { MessageBox.Show("No Record found,please change the date and try again!... ", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch(Exception ex)
            { MessageBox.Show("Printing Error","Failed",MessageBoxButtons.OK,MessageBoxIcon.Information); }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
