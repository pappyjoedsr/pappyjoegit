using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Monthly_Expense_Report : Form
    {
        Monthly_Expense_controller cntrl = new Monthly_Expense_controller();
        public bool comboFlag = false;
        public Monthly_Expense_Report()
        {
            InitializeComponent();
        }

        private void Monthly_Expense_Report_Load(object sender, EventArgs e)
        {
            try
            {
                this.Dgv_Expense.RowPostPaint += new DataGridViewRowPostPaintEventHandler(Dgv_Expense_RowPostPaint);
                Dgv_Expense.Hide();
                comboFlag = true;
                this.Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                //AddStaff.Select s = new AddStaff.Select();
                this.chart_monthlyExpense.Titles.Add("Daily Expense Count");
                dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
                dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickerdailytreatment1.Value = date;
                string date1 = dateTimePickerdailytreatment1.Value.ToString("MM/dd/yyyy");
                string date2 = dateTimePickerdailytreatment2.Value.ToString("MM/dd/yyyy");
                chart_monthlyExpense.Location = new Point(22, 50);
                chart_monthlyExpense.Size = new Size(1306, 378);
                foreach (var series in chart_monthlyExpense.Series)
                {
                    series.Points.Clear();
                }
                Cmb_AccountName.Items.Add("All Accounts");
                Cmb_AccountName.ValueMember = "0";
                Cmb_AccountName.DisplayMember = "All Accounts";
                System.Data.DataTable doctor_rs = this.cntrl.Expense_type_data();
                // db.table("select distinct id,name from tbl_expense_type");
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
                Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                Dgv_ChartExpanse.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Dgv_ChartExpanse.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                Dgv_Expense.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Dgv_Expense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Dgv_Expense.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                Dgv_Expense.EnableHeadersVisualStyles = false;
               
                foreach (DataGridViewColumn cl in Dgv_Expense.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                comboFlag = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Dgv_Expense_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(Dgv_Expense.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btngrddailytreatment_Click(object sender, EventArgs e)
        {
            Dgv_Expense.Show();
            chart_monthlyExpense.Hide();
            Dgv_Expense.Location = new Point(45, 51);
            Dgv_Expense.Size = new Size(1312, 308);
            label2.Text = 0.ToString();
            label2.Visible = true;
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
            if (rad_Expanse.Checked)
            {
                Dgv_Expense.Columns["colAmountdr"].Visible = false;
                Dgv_Expense.Columns["CoAmountCr"].Visible = true;
            }
            else if (rad_Income.Checked)
            {
                Dgv_Expense.Columns["CoAmountCr"].Visible = false;
                Dgv_Expense.Columns["colAmountdr"].Visible = true;
            }
            else
            {
                Dgv_Expense.Columns["CoAmountCr"].Visible = true;  
                Dgv_Expense.Columns["colAmountdr"].Visible = true;
            }
            int count = Dgv_Expense.Rows.Count;
            label2.Text = count.ToString();
        }
        public void bind_grid(DataTable dt)
        {
            int k = 1;
            Dgv_Expense.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dgv_Expense.Rows.Add();
                Dgv_Expense.Rows[i].Cells["colSl_no"].Value = k;
                Dgv_Expense.Rows[i].Cells["ColDate"].Value = Convert.ToDateTime(dt.Rows[i]["date"].ToString()).ToString("dd/MM/yyyy");
                Dgv_Expense.Rows[i].Cells["colTransType"].Value = dt.Rows[i]["Type"].ToString();
                Dgv_Expense.Rows[i].Cells["colLedger"].Value = dt.Rows[i]["nameofperson"].ToString();
                Dgv_Expense.Rows[i].Cells["ColAccountName"].Value = dt.Rows[i]["expense_type"].ToString();
                Dgv_Expense.Rows[i].Cells["CoAmountCr"].Value = Convert.ToDecimal(dt.Rows[i]["amount"].ToString()).ToString("#00.00");
                Dgv_Expense.Rows[i].Cells["colAmountdr"].Value = Convert.ToDecimal(dt.Rows[i]["amountincome"].ToString()).ToString("#00.00");
                Dgv_Expense.Rows[i].Cells["ColDescription"].Value = dt.Rows[i]["description"].ToString();
                k++;
            }
            Dgv_Expense.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_Expense.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_Expense.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_Expense.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_Expense.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_Expense.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public void fill_grid()
        {
            try
            {
                foreach (var series in chart_monthlyExpense.Series)
                {
                    series.Points.Clear();
                }
                string Type = "";
                string AccountName = "";
                //AddStaff.Select s = new AddStaff.Select();
                string date1 = dateTimePickerdailytreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickerdailytreatment2.Value.ToString("yyyy-MM-dd");
                //  Dgv_ChartExpanse.DataSource = null;
                if (chk_Account.Checked && Chk_Type.Checked)
                {
                    if (rad_Expanse.Checked)
                    {
                        Type = rad_Expanse.Text;
                    }
                    else if (rad_Income.Checked)
                    {
                        Type = rad_Income.Text;
                    }
                    if (Cmb_AccountName.SelectedIndex > 0 && Type != "")
                    {
                        AccountName = Cmb_AccountName.SelectedItem.ToString();
                        DataTable dtb = this.cntrl.Expense_data(AccountName, Type, date1, date2);
                        //db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where expense_type='" + AccountName + "' and Type='" + Type + "' and date between '" + date1 + "' and '" + date2 + "' ");
                        bind_grid(dtb);
                        //Dgv_Expense.DataSource = dtb;
                        Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanse(date1, date2, AccountName, Type);
                    }
                    else if (Cmb_AccountName.SelectedIndex == 0 || Type != "")
                    {
                        DataTable dtb = this.cntrl.expense_by_type(Type, date1, date2);
                        // db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  Type='" + Type + "' and date between '" + date1 + "' and '" + date2 + "' ");
                        bind_grid(dtb);
                        //Dgv_Expense.DataSource = dtb;
                        Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseType(date1, date2, Type);

                    }
                    else if (Cmb_AccountName.SelectedIndex > 0 && Type == "")
                    {
                        AccountName = Cmb_AccountName.SelectedItem.ToString();
                        DataTable dtb = this.cntrl.Expense_by_Accountname(AccountName, date1, date2);
                        // db.table("select date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  expense_type='" + AccountName + "' and date between '" + date1 + "' and '" + date2 + "' ");
                        bind_grid(dtb);
                        Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseAccount(date1, date2, AccountName);
                    }
                    else
                    {
                        DataTable dtb = this.cntrl.Expense_by_date(date1, date2);
                        // db.table("select date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  date between '" + date1 + "' and '" + date2 + "' ");
                        bind_grid(dtb);
                        Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseLoad(date1, date2);
                    }
                }
                else if (Chk_Type.Checked || chk_Account.Checked)
                {
                    if (Chk_Type.Checked)
                    {
                        if (rad_Expanse.Checked)
                        {
                            Type = rad_Expanse.Text;
                        }
                        else if (rad_Income.Checked)
                        {
                            Type = rad_Income.Text;
                        }
                        if (Type != "")
                        {
                            DataTable dtb = this.cntrl.expense_by_type(Type, date1, date2);
                            // db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where  Type='" + Type + "' and date between '" + date1 + "' and '" + date2 + "' ");
                            bind_grid(dtb);
                            Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseType(date1, date2, Type);
                        }
                        else
                        {
                            DataTable dtb = this.cntrl.Expense_by_date(date1, date2);
                            // db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' ");
                            bind_grid(dtb);
                            Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseLoad(date1, date2);
                        }
                    }
                    if (chk_Account.Checked)
                    {
                        if (Cmb_AccountName.SelectedIndex > 0)
                        {
                            AccountName = Cmb_AccountName.SelectedItem.ToString();
                            DataTable dtb = this.cntrl.Expense_by_Accountname(AccountName, date1, date2);
                            //db.table("select date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where expense_type='" + AccountName + "'and  date between '" + date1 + "' and '" + date2 + "' ");
                            bind_grid(dtb);
                            Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseAccount(date1, date2, AccountName);
                        }
                        else
                        {
                            DataTable dtb = this.cntrl.Expense_by_date(date1, date2);
                            // db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' ");
                            bind_grid(dtb);
                            Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseLoad(date1, date2);
                        }
                    }
                }
                else
                {
                    DataTable dtb = this.cntrl.Expense_by_date(date1, date2);
                    // db.table("select  date,Type,nameofperson,expense_type,amount,amountincome,description from tbl_expense where date between '" + date1 + "' and '" + date2 + "' ");
                    bind_grid(dtb);
                    Dgv_ChartExpanse.DataSource = this.cntrl.MonthlyExpanseLoad(date1, date2);
                }
                this.Dgv_ChartExpanse.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Dgv_ChartExpanse.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            var d1 = dateTimePickerdailytreatment1.Value.ToShortDateString();
            var d2 = dateTimePickerdailytreatment2.Value.ToShortDateString();
            if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
            {
                MessageBox.Show("From date should be less than two date");
                dateTimePickerdailytreatment1.Value = DateTime.Today;
                return;
            }
            fill_grid();
            if (Dgv_Expense.Visible)
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
                if (rad_Expanse.Checked)
                {
                    Dgv_Expense.Columns["colAmountdr"].Visible = false;
                    Dgv_Expense.Columns["CoAmountCr"].Visible = true;
                }
                else if (rad_Income.Checked)
                {
                    Dgv_Expense.Columns["CoAmountCr"].Visible = false;
                    Dgv_Expense.Columns["colAmountdr"].Visible = true;
                }
                else
                {
                    Dgv_Expense.Columns["CoAmountCr"].Visible = true;
                    Dgv_Expense.Columns["colAmountdr"].Visible = true;
                }
                int row = Dgv_Expense.Rows.Count;
                label2.Text = row.ToString();
                Dgv_Expense.Show();
                chart_monthlyExpense.Hide();
                btngrddailytreatment.Visible = true;
                chart_monthlyExpense.Location = new Point(22, 50);
                chart_monthlyExpense.Size = new Size(1306, 378);
            }
            else
            {
                Dgv_Expense.Hide();
                chart_monthlyExpense.Show();
                btngrddailytreatment.Visible = true;
                chart_monthlyExpense.Location = new Point(22, 50);
                chart_monthlyExpense.Size = new Size(1306, 378);
                this.Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
                dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
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
            string checkStr = "0"; string PathName = "";
            try
            {
                if (Dgv_Expense.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Monthly Expense Report1(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = Dgv_Expense.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        string type = "";
                        if (Chk_Type.Checked)
                        {
                            if (rad_Expanse.Checked)
                            {
                                type = rad_Expanse.Text;
                                ExcelApp.Cells[1, 1] = "MONTHLY EXPENSE REPORT( " + type + ")";
                            }
                            else if (rad_Income.Checked)
                            {
                                type = rad_Income.Text;
                                ExcelApp.Cells[1, 1] = "MONTHLY EXPENSE REPORT (" + type + ")";
                            }
                        }
                        else
                        {
                            ExcelApp.Cells[1, 1] = "MONTHLY EXPENSE REPORT ";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerdailytreatment1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerdailytreatment2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < Dgv_Expense.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = Dgv_Expense.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= Dgv_Expense.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < Dgv_Expense.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = Dgv_Expense.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch
                            {
                            }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);//, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
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
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Dgv_Expense.Rows.Count > 0)
                {

                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
                    string strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "",logo_name="";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Data.DataTable dtp = this.cntrl.Get_practiceDlNumber();
                        // db.table("select name,contact_no,street_address,email,website from tbl_practice_details");
                        if (dtp.Rows.Count > 0)
                        {
                            clinicn = dtp.Rows[0]["name"].ToString();
                            strclinicname = clinicn.Replace("¤", "'");
                            strphone = dtp.Rows[0]["contact_no"].ToString();
                            strStreet = dtp.Rows[0]["street_address"].ToString();
                            stremail = dtp.Rows[0]["email"].ToString();
                            strwebsite = dtp.Rows[0]["website"].ToString();
                            logo_name= dtp.Rows[0]["path"].ToString();
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\MonthlyExpense.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> MONTHLY EXPENSE REPORT </font></center></b></td>");
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
                    if (Dgv_Expense.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='4%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>&nbspSlno.</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='30%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Date</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Transaction Type</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Ledger</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Account Name</b></font></th>");
                        if (Chk_Type.Checked)
                        {
                            if (rad_Expanse.Checked)
                            {
                                sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount (Cr)</b></font></th>");
                            }
                            else if (rad_Income.Checked)
                            {
                                sWrite.WriteLine("    <td align='right' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Amount(Dr)/b></font></th>");
                            }
                            else
                            {
                                sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount(Cr)</b></font></th>");
                                sWrite.WriteLine("    <td align='right' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount(Dr)</b></font></th>");
                            }
                        }
                        else
                        {
                            sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount(Cr)</b></font></th>");
                            sWrite.WriteLine("    <td align='right' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount(Dr)</b></font></th>");
                        }
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Description</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int i = 0; i < Dgv_Expense.Rows.Count; i++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + k + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Dgv_Expense.Rows[i].Cells["ColDate"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Dgv_Expense.Rows[i].Cells["colTransType"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Dgv_Expense.Rows[i].Cells["colLedger"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Dgv_Expense.Rows[i].Cells["ColAccountName"].Value.ToString() + "</font></th>");
                            if (Chk_Type.Checked)
                            {
                                if (rad_Expanse.Checked)
                                {
                                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Dgv_Expense.Rows[i].Cells["CoAmountCr"].Value.ToString() + "&nbsp</font></th>");
                                }
                                else if (rad_Income.Checked)
                                {
                                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Dgv_Expense.Rows[i].Cells["colAmountdr"].Value.ToString() + "&nbsp</font></th>");
                                }
                                else
                                {
                                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Dgv_Expense.Rows[i].Cells["CoAmountCr"].Value.ToString() + "&nbsp</font></th>");
                                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Dgv_Expense.Rows[i].Cells["colAmountdr"].Value.ToString() + "&nbsp</font></th>");
                                }
                            }
                            else
                            {
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Dgv_Expense.Rows[i].Cells["CoAmountCr"].Value.ToString() + "&nbsp</font></th>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Dgv_Expense.Rows[i].Cells["colAmountdr"].Value.ToString() + "&nbsp</font></th>");
                            }
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Dgv_Expense.Rows[i].Cells["ColDescription"].Value.ToString() + "</font></th>");
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
                        System.Diagnostics.Process.Start(Apppath + "\\MonthlyExpense.html");
                    }
                }
                else
                {
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Cmb_AccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AccountName = "";
            if (comboFlag == false)
            {
                if (Cmb_AccountName.SelectedIndex == -1)
                {
                }
                else
                {
                    AccountName = Cmb_AccountName.SelectedItem.ToString();
                }
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
                if (rad_Expanse.Checked)
                {
                    Dgv_Expense.Columns["colAmountdr"].Visible = false;
                    Dgv_Expense.Columns["CoAmountCr"].Visible = true;
                }
                else if (rad_Income.Checked)
                {
                    Dgv_Expense.Columns["CoAmountCr"].Visible = false;
                    Dgv_Expense.Columns["colAmountdr"].Visible = true;
                }
                else
                {
                    Dgv_Expense.Columns["CoAmountCr"].Visible = true;
                    Dgv_Expense.Columns["colAmountdr"].Visible = true;
                }
                int count = Dgv_Expense.Rows.Count;
                label2.Text = count.ToString();
            }
        }

        private void Chk_Type_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Type.Checked)
            {
                rad_Expanse.Enabled = true;
                rad_Income.Enabled = true;
            }
            else
            {
                rad_Expanse.Enabled = false;
                rad_Income.Enabled = false;
                rad_Expanse.Checked = false;
                rad_Income.Checked = false;
            }
        }

        private void Dgv_ChartExpanse_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            foreach (var series in chart_monthlyExpense.Series)
            {
                series.Points.Clear();
            }
            for (int i = 0; i < Dgv_ChartExpanse.Rows.Count; i++)
            {
                int count = int.Parse(Dgv_ChartExpanse.Rows[i].Cells[1].Value.ToString());
                total = total + count;
                string seriesArray = Dgv_ChartExpanse.Rows[i].Cells[1].Value.ToString();
                string points = Dgv_ChartExpanse.Rows[i].Cells[0].Value.ToString();
                this.chart_monthlyExpense.Palette = ChartColorPalette.BrightPastel;
                chart_monthlyExpense.Series["MonthlyExpense"]["PixelPointWidth"] = "55";
                string pointss = points + seriesArray;
                chart_monthlyExpense.Series["MonthlyExpense"].Points.AddXY(points, seriesArray);
            }
            if (total == 0)
            {
                label2.Text = 0.ToString();
            }
            label2.Text = total.ToString();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnviewchart_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
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
            Dgv_Expense.Hide();
            chart_monthlyExpense.Show();
            btngrddailytreatment.Visible = true;
            chart_monthlyExpense.Location = new Point(22, 50);
            chart_monthlyExpense.Size = new Size(1306, 378);
            this.Dgv_ChartExpanse.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
            dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, 1);
            int row = Dgv_Expense.Rows.Count;
            label2.Text = row.ToString();
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
    }
}
