using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Daily_Treatment_Count : Form
    {
        Daily_Treatment_Count_controller cntrl=new Daily_Treatment_Count_controller();
        public string doctor_id = "";
        public bool combo_flag = false;
        public string Selected_drid = "";
        public string drctid = "";
        public Daily_Treatment_Count()
        {
            InitializeComponent();
        }
        private void Daily_treatment_count_Load(object sender, EventArgs e)
        {
            try
            {
                this.griddailyteatment.RowPostPaint += new DataGridViewRowPostPaintEventHandler(griddailyteatment_RowPostPaint);
                griddailyteatment.Hide();
                this.Grvdailytreatment.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                this.chartdailytreatment.Titles.Add("Daily Treatments Count");
                dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
                dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                string date1 = dateTimePickerdailytreatment1.Value.ToString("MM/dd/yyyy");
                string date2 = dateTimePickerdailytreatment2.Value.ToString("MM/dd/yyyy");
                chartdailytreatment.Location = new Point(22, 50);
                chartdailytreatment.Size = new Size(1306, 378);
                foreach (var series in chartdailytreatment.Series)
                {
                    series.Points.Clear();
                }
                combo_flag = true;
                comboBoxdoctor.Items.Add("All Doctors");
                comboBoxdoctor.ValueMember = "0";
                comboBoxdoctor.DisplayMember = "All Doctors";
                System.Data.DataTable doctor_rs = this.cntrl.doctor_rs();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        comboBoxdoctor.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        comboBoxdoctor.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        comboBoxdoctor.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
                comboBoxdoctor.SelectedIndex = 0;
                combo_flag = false; 
                fill_grid();
                this.Grvdailytreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvdailytreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvdailytreatment.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                Grvdailytreatment.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvdailytreatment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvdailytreatment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                Grvdailytreatment.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvdailytreatment.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void griddailyteatment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(griddailyteatment.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        public void fill_grid()
        {
            try
            {
                string date1 = dateTimePickerdailytreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickerdailytreatment2.Value.ToString("yyyy-MM-dd");
                DataTable griddailytrreatmenttable = new DataTable();
                if (Chk_Cost.Checked)
                {
                    if (comboBoxdoctor.SelectedIndex == 0)
                    {
                        griddailytrreatmenttable = this.cntrl.grdDailytrtmnt(date1, date2);
                        Grvdailytreatment.DataSource = this.cntrl.DailytreatmentLoad(date1, date2);
                    }
                    else if (comboBoxdoctor.SelectedIndex > 0)
                    {
                        griddailytrreatmenttable = this.cntrl.grddlytrtment(date1, date2, Selected_drid);
                        Grvdailytreatment.DataSource = this.cntrl.Dailytreatment(date1, date2, Selected_drid);
                    }
                }
                else
                {
                    if (comboBoxdoctor.SelectedIndex == 0)
                    {
                        griddailytrreatmenttable = this.cntrl.gridtreatment1(date1, date2);
                        Grvdailytreatment.DataSource = this.cntrl.DailytreatmentLoad(date1, date2);
                    }
                    else if (comboBoxdoctor.SelectedIndex > 0)
                    {
                        griddailytrreatmenttable = this.cntrl.Gridtrtment2(date1, date2, Selected_drid);
                        Grvdailytreatment.DataSource = this.cntrl.Dailytreatment(date1, date2, Selected_drid);
                    }
                }
                btnviewchart.Visible = true;
                griddailyteatment.Rows.Clear();
                int k = 1;
                for (int i = 0; i < griddailytrreatmenttable.Rows.Count; i++)
                {
                    griddailyteatment.Rows.Add();
                    griddailyteatment.Rows[i].Cells[0].Value = k;
                    griddailyteatment.Rows[i].Cells[1].Value = griddailytrreatmenttable.Rows[i]["pt_id"].ToString();
                    griddailyteatment.Rows[i].Cells[2].Value = griddailytrreatmenttable.Rows[i]["pt_name"].ToString();
                    griddailyteatment.Rows[i].Cells[3].Value = griddailytrreatmenttable.Rows[i]["date"].ToString();
                    griddailyteatment.Rows[i].Cells[4].Value = griddailytrreatmenttable.Rows[i]["procedure_name"].ToString();
                    griddailyteatment.Rows[i].Cells[5].Value = griddailytrreatmenttable.Rows[i]["doctor_name"].ToString();
                    if (Chk_Cost.Checked)
                    {
                        griddailyteatment.Rows[i].Cells[6].Value = griddailytrreatmenttable.Rows[i]["COST"].ToString();
                    }
                    k = k + 1;
                }
                if (Chk_Cost.Checked)
                {
                    this.griddailyteatment.Columns[6].Visible = true;
                    for (int g = 0; g < griddailytrreatmenttable.Rows.Count; g++)
                    {
                        griddailyteatment.Rows[g].Cells[6].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        griddailyteatment.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    this.griddailyteatment.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    this.griddailyteatment.Columns[6].Visible = false;
                    this.griddailyteatment.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                int count = griddailytrreatmenttable.Rows.Count;
                label2.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Grvdailytreatment_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < Grvdailytreatment.Rows.Count; i++)
            {
                int count = int.Parse(Grvdailytreatment.Rows[i].Cells[1].Value.ToString());
                total = total + count;
                string seriesArray = Grvdailytreatment.Rows[i].Cells[1].Value.ToString();
                string points = Grvdailytreatment.Rows[i].Cells[0].Value.ToString();
                this.chartdailytreatment.Palette = ChartColorPalette.BrightPastel;
                chartdailytreatment.Series["Treatment Count"]["PixelPointWidth"] = "55";
                string pointss = points + seriesArray;
                chartdailytreatment.Series["Treatment Count"].Points.AddXY(points, seriesArray);
            }
            if (total == 0)
            {
                label2.Text = 0.ToString();
            }
            label2.Text = total.ToString();
        }

        public void GridStyle()
        {
            griddailyteatment.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            griddailyteatment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            griddailyteatment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
            griddailyteatment.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in griddailyteatment.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnviewchart_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            foreach (var series in chartdailytreatment.Series)
            {
                series.Points.Clear();
            }
            fill_grid();
            this.Grvdailytreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Grvdailytreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (Grvdailytreatment.Rows.Count < 1)
            {
                int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            griddailyteatment.Hide();
            chartdailytreatment.Show();
            btngrddailytreatment.Visible = true;
            chartdailytreatment.Location = new Point(22, 50);
            chartdailytreatment.Size = new Size(1306, 378);
            this.Grvdailytreatment.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dateTimePickerdailytreatment1.MaxDate = DateTime.Now;
            dateTimePickerdailytreatment2.MaxDate = DateTime.Now;
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(now.Year, now.Month, 1);
            int row = griddailyteatment.Rows.Count;
            label2.Text = row.ToString();
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
            Lab_Msg.Hide();
            foreach (var series in chartdailytreatment.Series)
            {
                series.Points.Clear();
            }
            fill_grid();
            this.Grvdailytreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Grvdailytreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (griddailyteatment.Visible)
            {
                int row = griddailyteatment.Rows.Count;
                label2.Text = row.ToString();
                griddailyteatment.Show();
                chartdailytreatment.Hide();
                btngrddailytreatment.Visible = true;
            }
            else
            {
                griddailyteatment.Hide();
                chartdailytreatment.Show();
                btngrddailytreatment.Visible = true;
                chartdailytreatment.Location = new Point(22, 50);
                int row = griddailyteatment.Rows.Count;
                label2.Text = row.ToString();
            }
        }

        private void btngrddailytreatment_Click(object sender, EventArgs e)
        {
            var d1 = dateTimePickerdailytreatment1.Value.ToShortDateString();
            var d2 = dateTimePickerdailytreatment2.Value.ToShortDateString();
            if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
            {
                MessageBox.Show("From date should be less than two date");
                dateTimePickerdailytreatment1.Value = DateTime.Today;
                return;
            }
            Lab_Msg.Hide();
            combo_flag = true;
            foreach (var series in chartdailytreatment.Series)
            {
                series.Points.Clear();
            }
            fill_grid();
            this.Grvdailytreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Grvdailytreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GridStyle();
            int row = griddailyteatment.Rows.Count;
            label2.Text = row.ToString();
            griddailyteatment.Show();
            chartdailytreatment.Hide();
            btngrddailytreatment.Visible = true;
            chartdailytreatment.Location = new Point(22, 50);
            chartdailytreatment.Size = new Size(1306, 378);
            if (Grvdailytreatment.Rows.Count < 1)
            {
                int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            combo_flag = false;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (griddailyteatment.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Daily Treatment Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, 3]].Merge();
                        if (Chk_Cost.Checked)
                        {
                            if (comboBoxdoctor.SelectedIndex == 0)
                            {
                                ExcelApp.Cells[1, 1] = "DAILY TREATMENT REPORT (INCLUDING THE  COST OF  All DOCTORS)";
                            }
                            else if (comboBoxdoctor.SelectedIndex > 0)
                            {
                                ExcelApp.Cells[1, 1] = "DAILY TREATMENT REPORT (INCLUDING THE COST OF " + drctid + ")";
                            }
                        }
                        else
                        {
                            if (comboBoxdoctor.SelectedIndex == 0)
                            {
                                ExcelApp.Cells[1, 1] = "DAILY TREATMENT REPORT (EXCLUDING THE COST OF All DOCTORS)";
                            }
                            else if (comboBoxdoctor.SelectedIndex > 0)
                            {
                                ExcelApp.Cells[1, 1] = "DAILY TREATMENT REPORT (EXCLUDING THE COST OF " + drctid + ")";
                            }
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
                        if(Chk_Cost.Checked==true)
                        {
                            for (int i = 1; i < griddailyteatment.Columns.Count + 1; i++)
                            {
                                ExcelApp.Cells[5, i] = griddailyteatment.Columns[i - 1].HeaderText;
                                ExcelApp.Cells[5, i].ColumnWidth = 25;
                                ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                                ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[5, i].Font.Size = 10;
                                ExcelApp.Cells[5, i].Font.Name = "Arial";
                                ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                                ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            }
                        }
                        else
                        {
                            for (int i = 1; i < griddailyteatment.Columns.Count ; i++)
                            {
                                ExcelApp.Cells[5, i] = griddailyteatment.Columns[i - 1].HeaderText;
                                ExcelApp.Cells[5, i].ColumnWidth = 25;
                                ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                                ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[5, i].Font.Size = 10;
                                ExcelApp.Cells[5, i].Font.Name = "Arial";
                                ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                                ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            }
                        }
                        
                        for (int i = 0; i <= griddailyteatment.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < griddailyteatment.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = griddailyteatment.Rows[i].Cells[j].Value.ToString();
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
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (griddailyteatment.Rows.Count > 0)
                {
                    string today = DateTime.Now.ToString("d/M/yyyy");
                    string message = "Do you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
                    string strclinicname = "";
                    string clinicn = "";
                    string strStreet = "";
                    string stremail = "";
                    string strwebsite = "";
                    string strphone = "",logo_name="";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Data.DataTable dtp = this.cntrl.Get_practiceDlNumber();
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\DailyTreatment.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> DAILY TREATMENT REPORT </font></center></b></td>");
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
                    if (griddailyteatment.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='8%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Slno.</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Patient Id</b> </font></td>");
                        sWrite.WriteLine("<td align='left' width='23%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;<b>Patient Name</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Date</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='24%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Services</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='19%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;<b>Doctor</b></font></td>");
                        if (Chk_Cost.Checked)
                        {
                            sWrite.WriteLine("    <td align='right' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'SIZE=3>&nbsp;<b>Cost</b></font></td>");
                        }
                        sWrite.WriteLine("</tr>");
                        for (int i = 0; i < griddailyteatment.Rows.Count; i++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + griddailyteatment.Rows[i].Cells[0].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'SIZE=2>&nbsp;" + griddailyteatment.Rows[i].Cells[1].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + griddailyteatment.Rows[i].Cells[2].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + griddailyteatment.Rows[i].Cells[3].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + griddailyteatment.Rows[i].Cells[4].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + griddailyteatment.Rows[i].Cells[5].Value.ToString() + "</font></td>");
                            if (Chk_Cost.Checked)
                            {
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + griddailyteatment.Rows[i].Cells[6].Value.ToString() + "</font></td>");
                            }
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
                        System.Diagnostics.Process.Start(Apppath + "\\DailyTreatment.html");
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
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxdoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxdoctor.SelectedIndex == -1)
                {
                }
                else
                {
                    foreach (var series in chartdailytreatment.Series)
                    {
                        series.Points.Clear();
                    }
                    drctid = comboBoxdoctor.SelectedItem.ToString();
                    Lab_Msg.Hide();
                    string dt = this.cntrl.Get_DoctorId(drctid);
                    if (dt!="")
                    {
                        Selected_drid = dt.ToString();
                    }
                    if (combo_flag == false)
                    {
                        label2.Text = "";
                        fill_grid();
                        GridStyle();
                        this.Grvdailytreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvdailytreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvdailytreatment.Rows.Count < 1)
                        {
                            int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                            Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                            Lab_Msg.Show();
                        }
                        else
                        {
                            Lab_Msg.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}