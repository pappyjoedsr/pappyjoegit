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
using System.Windows.Forms.DataVisualization.Charting;
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.View
{
    public partial class Expense_Category_Wise_Report : Form
    {
        public bool comboflag = false;
        Expense_Category_Controller cntrl = new Expense_Category_Controller();
        public Expense_Category_Wise_Report()
        {
            InitializeComponent();
        }

        private void Expense_Category_Wise_Report_Load(object sender, EventArgs e)
        {
            this.Dgv_Expanse.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Dgv_Expanse_RowPostPaint);
            Dgv_Expanse.Hide();
            comboflag = true;
            this.Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //AddStaff.Select s = new AddStaff.Select();
            this.chart_EXpanse.Titles.Add("Category Wise Expense Count");
            dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
            dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, 1);
            dateTimePickerdailytreatment1.Value = date;
            //string date1 = dateTimePickerdailytreatment1.Value.ToString("MM/dd/yyyy");
            //string date2 = dateTimePickerdailytreatment2.Value.ToString("MM/dd/yyyy");
            chart_EXpanse.Location = new Point(22, 50);
            chart_EXpanse.Size = new Size(1306, 378);
            foreach (var series in chart_EXpanse.Series)
            {
                series.Points.Clear();
            }
            Cmb_AccountName.Items.Add("All Accounts");
            Cmb_AccountName.ValueMember = "0";
            Cmb_AccountName.DisplayMember = "All Accounts";
            System.Data.DataTable doctor_rs = this.cntrl.load_type();// db.table("select distinct id,name from tbl_expense_type");
            if (doctor_rs.Rows.Count > 0)
            {
                for (int i = 0; i < doctor_rs.Rows.Count; i++)
                {
                    Cmb_AccountName.Items.Add(doctor_rs.Rows[i]["name"].ToString());
                    Cmb_AccountName.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                    Cmb_AccountName.DisplayMember = doctor_rs.Rows[i]["name"].ToString();
                }
            }
            Cmb_AccountName.SelectedIndex = 0;
            Cmb_Ledger.Items.Add("All Ledger");
            Cmb_Ledger.ValueMember = "0";
            Cmb_Ledger.DisplayMember = "All Ledger";
            System.Data.DataTable Ledger = this.cntrl.load_ledger();
            if (doctor_rs.Rows.Count > 0)
            {
                for (int i = 0; i < Ledger.Rows.Count; i++)
                {
                    Cmb_Ledger.Items.Add(Ledger.Rows[i]["Group_Name"].ToString());
                    Cmb_Ledger.ValueMember = Ledger.Rows[i]["id"].ToString();
                    Cmb_Ledger.DisplayMember = Ledger.Rows[i]["Group_Name"].ToString();
                }
            }
            Cmb_Ledger.SelectedIndex = 0;
            if (Dgv_ChartExpanse.Rows.Count < 1)
            {
                int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
            Dgv_ChartExpanse.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in Dgv_ChartExpanse.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            comboflag = false;
        }

        private void Dgv_Expanse_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(Dgv_Expanse.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        public void fill_grid()
        {
            string LedgerName = "", AccountName = "";
            if (Cmb_AccountName.SelectedIndex == -1)
            {
            }
            else
            {
                AccountName = Cmb_AccountName.SelectedItem.ToString();
            }
            if (Cmb_Ledger.SelectedIndex == -1)
            {
            }
            else
            {
                LedgerName = Cmb_Ledger.SelectedItem.ToString();
            }
            foreach (var series in chart_EXpanse.Series)
            {
                series.Points.Clear();
            }
            //AddStaff.Select s = new AddStaff.Select();
            string date1 = dateTimePickerdailytreatment1.Value.ToString("yyyy-MM-dd");
            string date2 = dateTimePickerdailytreatment2.Value.ToString("yyyy-MM-dd");
            if (chk_Account.Checked)
            {
                if (Cmb_AccountName.SelectedIndex > 0 && Cmb_Ledger.SelectedIndex > 0)
                {
                    DataTable dtb = this.cntrl.Load_details_wit_all(AccountName, LedgerName, date1, date2);// db.table("select   date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where expense_type='" + AccountName + "' and nameofperson='" + LedgerName + "' and date between '" + date1 + "' and '" + date2 + "' ");
                    Fill_MainGrid(dtb);
                    Dgv_ChartExpanse.DataSource = this.cntrl. ExpanseCategory_Ledger_Account(date1, date2, AccountName, LedgerName);
                }
                else if (Cmb_AccountName.SelectedIndex == 0 && Cmb_Ledger.SelectedIndex == 0)
                {
                    DataTable dtb = this.cntrl.load_category_wit_date(date1, date2);// db.table("select  date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where  date between '" + date1 + "' and '" + date2 + "' ");
                    Fill_MainGrid(dtb);
                    Dgv_ChartExpanse.DataSource = this.cntrl.ExpanseCategoryLoad(date1, date2);
                }
                else if (Cmb_AccountName.SelectedIndex > 0 && Cmb_Ledger.SelectedIndex == 0)
                {
                    DataTable dtb = this.cntrl.load_category_wit_account_date(AccountName, date1, date2 );// db.table("select  date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where expense_type='" + AccountName + "' and  date between '" + date1 + "' and '" + date2 + "' ");
                    Fill_MainGrid(dtb);
                    Dgv_ChartExpanse.DataSource = this.cntrl.ExpanseCategory_Account(date1, date2, AccountName);
                }
                else if (Cmb_AccountName.SelectedIndex == 0 && Cmb_Ledger.SelectedIndex > 0)
                {
                    DataTable dtb = this.cntrl.expensecategory_ledger_date(date1, date2, LedgerName);// db.table("select date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where nameofperson='" + LedgerName + "'  and  date between '" + date1 + "' and '" + date2 + "' ");
                    Fill_MainGrid(dtb);
                    Dgv_ChartExpanse.DataSource = this.cntrl. ExpanseCategory_Ledger(date1, date2, LedgerName);
                }
            }
            else if (Cmb_Ledger.SelectedIndex > 0)
            {
                DataTable dtb = this.cntrl.expensecategory_ledger_date(date1, date2, LedgerName);// db.table("select date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where nameofperson='" + LedgerName + "'  and  date between '" + date1 + "' and '" + date2 + "' ");
                Fill_MainGrid(dtb);
                Dgv_ChartExpanse.DataSource = this.cntrl. ExpanseCategory_Ledger(date1, date2, LedgerName);
            }
            else
            {
                DataTable dtb = this.cntrl.load_category_wit_date(date1, date2);// db.table("select date ,Type,nameofperson,expense_type,cast(amount as decimal(17,2))amount ,cast(amountincome as decimal(17,2))amountincome,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' ");
                Fill_MainGrid(dtb);
                Dgv_ChartExpanse.DataSource = this.cntrl.ExpanseCategoryLoad(date1, date2);
            }
            this.Dgv_ChartExpanse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Dgv_ChartExpanse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        public void Fill_MainGrid(DataTable dtb)
        {
            Dgv_Expanse.ColumnCount = 0;
            Dgv_Expanse.RowCount = 0;
            Dgv_Expanse.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Expanse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Expanse.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
            Dgv_Expanse.EnableHeadersVisualStyles = false;
            if (dtb.Rows.Count > 0)
            {
                Dgv_Expanse.ColumnCount = 7;
                Dgv_Expanse.Columns[0].HeaderText = "SLNO";
                Dgv_Expanse.Columns[0].Visible = true;
                Dgv_Expanse.Columns[1].HeaderText = "DATE";
                Dgv_Expanse.Columns[1].Width = 150;
                Dgv_Expanse.Columns[2].HeaderText = "TRANSACTION TYPE";
                Dgv_Expanse.Columns[2].Width = 145;
                Dgv_Expanse.Columns[3].HeaderText = "LEDGER";
                Dgv_Expanse.Columns[3].Width = 164;
                Dgv_Expanse.Columns[4].HeaderText = "ACCOUNT NAME";
                Dgv_Expanse.Columns[4].Width = 150;
                Dgv_Expanse.Columns[5].HeaderText = "AMOUNT";
                Dgv_Expanse.Columns[5].Width = 110;
                Dgv_Expanse.Columns[6].HeaderText = "DESCRIPTION";
                Dgv_Expanse.Columns[6].Width = 225;
                this.Dgv_Expanse.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                int k = 1;
                if (dtb.Rows[0]["Type"].ToString() == "Income")
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        Dgv_Expanse.Rows.Add(k, Convert.ToDateTime(dtb.Rows[i]["date"].ToString()).ToString("dd/MM/yyyy"), dtb.Rows[i]["Type"].ToString(), dtb.Rows[i]["nameofperson"].ToString(), dtb.Rows[i]["expense_type"].ToString(), dtb.Rows[i]["amountincome"].ToString(), dtb.Rows[i]["description"].ToString());
                        k++;
                    }
                }
                else if (dtb.Rows[0]["Type"].ToString() == "Expense")
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        Dgv_Expanse.Rows.Add(k, Convert.ToDateTime(dtb.Rows[i]["date"].ToString()).ToString("dd/MM/yyyy"), dtb.Rows[i]["Type"].ToString(), dtb.Rows[i]["nameofperson"].ToString(), dtb.Rows[i]["expense_type"].ToString(), dtb.Rows[i]["amount"].ToString(), dtb.Rows[i]["description"].ToString());
                        k++;
                    }
                }
                this.Dgv_Expanse.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Dgv_Expanse.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Dgv_Expanse.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dgv_Expanse.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dgv_Expanse.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dgv_Expanse.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            foreach (DataGridViewColumn cl in Dgv_Expanse.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnviewchart_Click(object sender, EventArgs e)
        {
            Lab_Total.Visible = true;
            fill_grid();
            if (Dgv_ChartExpanse.Rows.Count < 1)
            {
                int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            Dgv_Expanse.Hide();
            chart_EXpanse.Show();
            btngrddailytreatment.Visible = true;
            chart_EXpanse.Location = new Point(22, 50);
            chart_EXpanse.Size = new Size(1306, 378);
            this.Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
            dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, 1);
            int row = Dgv_Expanse.Rows.Count;
            Lab_Total.Text = row.ToString();
        }

        private void btngrddailytreatment_Click(object sender, EventArgs e)
        {
            Dgv_Expanse.Show();
            chart_EXpanse.Hide();
            Dgv_Expanse.Location = new Point(45, 51);
            Dgv_Expanse.Size = new Size(1312, 308);
            fill_grid();
            if (Dgv_ChartExpanse.Rows.Count < 1)
            {
                int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            int count = Dgv_Expanse.Rows.Count;
            Lab_Total.Text = count.ToString();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            var d1 = dateTimePickerdailytreatment1.Value.ToShortDateString();
            var d2 = dateTimePickerdailytreatment2.Value.ToShortDateString();
            if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
            {
                MessageBox.Show("From date should be less than to date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePickerdailytreatment1.Value = DateTime.Today;
                return;
            }
            fill_grid();
            if (Dgv_Expanse.Visible)
            {
                if (Dgv_ChartExpanse.Rows.Count < 1)
                {
                    int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }

                int row = Dgv_Expanse.Rows.Count;
                Lab_Total.Text = row.ToString();
                Dgv_Expanse.Show();
                chart_EXpanse.Hide();
                btngrddailytreatment.Visible = true;
                chart_EXpanse.Location = new Point(22, 50);
                chart_EXpanse.Size = new Size(1306, 378);
            }
            else
            {
                Dgv_Expanse.Hide();
                chart_EXpanse.Show();
                btngrddailytreatment.Visible = true;
                chart_EXpanse.Location = new Point(22, 50);
                chart_EXpanse.Size = new Size(1306, 378);
                this.Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
                dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                int row = Dgv_Expanse.Rows.Count;
                Lab_Total.Text = row.ToString();
                if (Dgv_ChartExpanse.Rows.Count < 1)
                {
                    int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string checkStr = "0", PathName = "", type = ""; ;
            try
            {
                if (Dgv_Expanse.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Expense Category Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = Dgv_Expanse.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (Cmb_Ledger.SelectedIndex > 0)
                        {
                            type = Cmb_Ledger.Text;
                            ExcelApp.Cells[1, 1] = "EXPENSE CATEGORY WISE REPORT( " + type + ")";
                        }
                        else
                        {
                            ExcelApp.Cells[1, 1] = "EXPENSE All CATEGORY REPORT ";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerdailytreatment1.Value.ToString();
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerdailytreatment2.Value.ToString();
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < Dgv_Expanse.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = Dgv_Expanse.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= Dgv_Expanse.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < Dgv_Expanse.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = Dgv_Expanse.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch
                            {
                            }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        checkStr = "1";
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (Dgv_Expanse.Rows.Count > 0)
            {
                DataTable tbl = Dgv_Expanse.DataSource as DataTable;
                DataTable tbl1 = Dgv_ChartExpanse.DataSource as DataTable;
                string frdate = dateTimePickerdailytreatment1.Value.Day.ToString();
                string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerdailytreatment1.Value.Month);
                string fryear = dateTimePickerdailytreatment1.Value.Year.ToString();
                string todate = dateTimePickerdailytreatment2.Value.Day.ToString();
                string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerdailytreatment2.Value.Month);
                string toyear = dateTimePickerdailytreatment2.Value.Year.ToString();
                string today = DateTime.Now.ToString("M/d/yyyy");
                string message = "Did you want Header on Print?";
                string caption = "Verification";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                int c = 0;
                string strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "",logo_name="";
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Data.DataTable dtp = this.cntrl.load_practicedetails();// db.table("select name,contact_no,street_address,email,website from tbl_practice_details");
                    if (dtp.Rows.Count > 0)
                    {
                        clinicn = dtp.Rows[0]["name"].ToString();
                        strclinicname = clinicn.Replace("¤", "'");
                        strphone = dtp.Rows[0]["contact_no"].ToString();
                        strStreet = dtp.Rows[0]["street_address"].ToString();
                        stremail = dtp.Rows[0]["email"].ToString();
                        strwebsite = dtp.Rows[0]["website"].ToString();
                        logo_name = dtp.Rows[0]["path"].ToString();
                    }
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\ExpenseCategory.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("<style>");
                sWrite.WriteLine("table { border-collapse: collapse;}");
                sWrite.WriteLine("p.big {line-height: 400%;}");
                sWrite.WriteLine("</style>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<div>");
                sWrite.WriteLine("<table align=center  width=900>");
                sWrite.WriteLine("<col >");
                sWrite.WriteLine("<br>");
                string Appath = System.IO.Directory.GetCurrentDirectory();
                if (File.Exists(Appath + "\\" + logo_name))
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                    sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> CATEGORY WISE EXPENSE REPORT </font></center></b></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>From :</b>" + " " + dateTimePickerdailytreatment1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>To :</b>" + "   " + dateTimePickerdailytreatment2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                sWrite.WriteLine("</tr>");
                if (Dgv_Expanse.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>&nbspSlno.</b></font></td>");
                    sWrite.WriteLine("    <td align='left' width='30%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Date</b></font></td>");
                    sWrite.WriteLine("    <td align='left' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Transaction Type</b></font></td>");
                    sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Ledger</b></font></td>");
                    sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'SIZE=3><b>Account Name</b></font></td>");
                    sWrite.WriteLine("    <td align='right' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Amount</b></font></td>");
                    sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Description</b></font></td>");
                    sWrite.WriteLine("</tr>");
                    int k = 1;
                    for (int j = 0; j < Dgv_Expanse.Rows.Count; j++)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + k + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Dgv_Expanse.Rows[j].Cells[1].Value.ToString() + "&nbsp</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp " + Dgv_Expanse.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> &nbsp" + Dgv_Expanse.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp " + Dgv_Expanse.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                        if (Dgv_Expanse.Rows[j].Cells[2].Value.ToString() == "Expense")
                        {
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + Dgv_Expanse.Rows[j].Cells[5].Value.ToString() + "&nbsp</font></td>");

                        }
                        else
                        {
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + Dgv_Expanse.Rows[j].Cells[5].Value.ToString() + "&nbsp</font></td>");
                        }
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> &nbsp" + Dgv_Expanse.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                        k = k + 1;
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("</td>");
                    sWrite.WriteLine("</tr >");
                    sWrite.WriteLine("</font> </p></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\ExpenseCategory.html");
                }
            }
            else
            {
                MessageBox.Show("No records found, please chenge the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Dgv_ChartExpanse_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < Dgv_ChartExpanse.Rows.Count; i++)
            {
                int seriesArray = Convert.ToInt32(Dgv_ChartExpanse.Rows[i].Cells[1].Value.ToString());
                total = total + seriesArray;
                string points = Dgv_ChartExpanse.Rows[i].Cells[0].Value.ToString();
                this.chart_EXpanse.Palette = ChartColorPalette.SeaGreen;
                chart_EXpanse.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                string pointss = points + " " + seriesArray;
                chart_EXpanse.Series["Expense Count"]["PieLabelStyle"] = "Outside";
                chart_EXpanse.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chart_EXpanse.Series["Expense Count"].Points.AddXY(pointss, seriesArray);
            }
            if (total == 0)
            {
                Lab_Total.Text = 0.ToString();
            }
            else
                Lab_Total.Text = total.ToString();
        }

        private void chk_Account_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Account.Checked)
            {
                Cmb_AccountName.Enabled = true;
                Lab_Account.Enabled = true;
            }
            else
            {
                Cmb_AccountName.Enabled = false;
                Lab_Account.Enabled = false;
            }
        }

        private void Cmb_Ledger_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid();
            if (Dgv_ChartExpanse.Rows.Count < 1)
            {
                int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            int count = Dgv_Expanse.Rows.Count;
            Lab_Total.Text = count.ToString();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmb_AccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_grid();
            if (Dgv_ChartExpanse.Rows.Count < 1)
            {
                int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            int count = Dgv_Expanse.Rows.Count;
            Lab_Total.Text = count.ToString();
        }
    }
}
