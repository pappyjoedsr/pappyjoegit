using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Treatment_For_Each_Category : Form
    {
        Treatment_For_Each_Category_controller cntrl=new Treatment_For_Each_Category_controller();
        public string doctor_id = "";
        string select_dr_id = "";
        public string drctid = "";
        public string Selected_drid = "";
        public Treatment_For_Each_Category()
        {
            InitializeComponent();
        }

        private void Treatment_for_each_category_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridoncategory.RowPostPaint += new DataGridViewRowPostPaintEventHandler(gridoncategory_RowPostPaint);
                Lab_Msg.Hide();
                this.Grvtreatmenteachcat.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                charttreatmenteachcategory.Titles.Add("Treatment For Each Category");
                dateTimePickertreatmenteachcat1.MaxDate = DateTime.Now;
                dateTimePickertreatmenteachcat2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickertreatmenteachcat1.Value = date;
                string date1 = dateTimePickertreatmenteachcat1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreatmenteachcat2.Value.ToString("yyyy-MM-dd");
                comboboxcategory.Items.Add("All Category");
                comboboxcategory.ValueMember = "0";
                comboboxcategory.DisplayMember = "All Procedure";
                System.Data.DataTable dt = this.cntrl.addproset();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboboxcategory.Items.Add(dt.Rows[i]["name"].ToString());
                        comboboxcategory.ValueMember = dt.Rows[i]["id"].ToString();
                        comboboxcategory.DisplayMember = dt.Rows[i]["name"].ToString();
                    }
                }
                comboboxcategory.SelectedIndex = 0;
                select_dr_id = "0";
                gridoncategory.Hide();
                charttreatmenteachcategory.Location = new Point(45, 51);
                charttreatmenteachcategory.Size = new Size(1312, 308);
                label4.Text = 0.ToString();
                foreach (var series in charttreatmenteachcategory.Series)
                {
                    series.Points.Clear();
                }
                Grvtreatmenteachcat.DataSource = this.cntrl.TreatmenteachcatLoad(date1, date2);
                this.Grvtreatmenteachcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvtreatmenteachcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvtreatmenteachcat.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                Grvtreatmenteachcat.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvtreatmenteachcat.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvtreatmenteachcat.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                Grvtreatmenteachcat.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvtreatmenteachcat.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                gridoncategory.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                gridoncategory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gridoncategory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                gridoncategory.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in gridoncategory.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                int count = gridoncategory.Rows.Count;
                label4.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void gridoncategory_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(gridoncategory.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void Grvtreatmenteachcat_DataSourceChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < Grvtreatmenteachcat.Rows.Count; i++)
            {
                string seriesArray = Grvtreatmenteachcat.Rows[i].Cells[1].Value.ToString();
                string points = Grvtreatmenteachcat.Rows[i].Cells[0].Value.ToString();
                this.charttreatmenteachcategory.Palette = ChartColorPalette.SeaGreen;
                charttreatmenteachcategory.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                string pointss = points + " " + seriesArray;
                charttreatmenteachcategory.Series["Treatment (s)"]["PieLabelStyle"] = "Outside";
                charttreatmenteachcategory.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                charttreatmenteachcategory.Series["Treatment (s)"].Points.AddXY(pointss, seriesArray);
            }
        }
        public void bind_grid(DataTable dtb)
        {
            gridoncategory.Rows.Clear();
            int k = 1;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                gridoncategory.Rows.Add();
                gridoncategory.Rows[i].Cells[0].Value = k;
                gridoncategory.Rows[i].Cells[1].Value = dtb.Rows[i]["date"].ToString();
                gridoncategory.Rows[i].Cells[2].Value = dtb.Rows[i]["procedure_name"].ToString();
                gridoncategory.Rows[i].Cells[3].Value = dtb.Rows[i]["doctor_name"].ToString();
                k = k + 1;
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = dateTimePickertreatmenteachcat1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreatmenteachcat2.Value.ToString("yyyy-MM-dd");
                DateTime d1 = DateTime.Parse(dateTimePickertreatmenteachcat1.Value.ToString("yyyy-MM-dd"));
                DateTime d2 = DateTime.Parse(dateTimePickertreatmenteachcat2.Value.ToString("yyyy-MM-dd"));
                if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
                {
                    MessageBox.Show("From date should be less than two date");
                    dateTimePickertreatmenteachcat1.Value = DateTime.Today;
                }
                else
                {
                    if (comboboxcategory.SelectedIndex == -1)
                    { }
                    else
                    {
                        string drid = comboboxcategory.SelectedItem.ToString();
                        System.Data.DataTable dt = this.cntrl.prosetDocId(drid);
                        if (dt.Rows.Count > 0)
                        {
                            select_dr_id = dt.Rows[0]["Id"].ToString();
                        }
                    }
                    if (comboboxcategory.SelectedIndex > 0)
                    {
                        System.Data.DataTable griddailytrreatmenttable = this.cntrl.drgDailytreatmentTB(Convert.ToInt32(select_dr_id.ToString().Trim()), date1, date2);
                        bind_grid(griddailytrreatmenttable);
                        label4.Text = 0.ToString();
                        int count = gridoncategory.Rows.Count;
                        label4.Text = count.ToString();
                        foreach (var series in charttreatmenteachcategory.Series)
                        {
                            series.Points.Clear();
                        }
                        Grvtreatmenteachcat.DataSource = this.cntrl.Treatmenteachcat(date1, date2, Selected_drid);
                        this.Grvtreatmenteachcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvtreatmenteachcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvtreatmenteachcat.Rows.Count < 1)
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
                    else
                    {
                        System.Data.DataTable griddailytrreatmenttable = this.cntrl.GridDLYTTMNTtb(date1, date2);
                        bind_grid(griddailytrreatmenttable);
                        label4.Text = 0.ToString();
                        int count = gridoncategory.Rows.Count;
                        label4.Text = count.ToString();
                        foreach (var series in charttreatmenteachcategory.Series)
                        {
                            series.Points.Clear();
                        }
                        Grvtreatmenteachcat.DataSource = this.cntrl.TreatmenteachcatLoad(date1, date2);
                        this.Grvtreatmenteachcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvtreatmenteachcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvtreatmenteachcat.Rows.Count < 1)
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
                if (gridoncategory.Visible)
                {
                    gridoncategory.Show();
                    comboboxcategory.Show();
                    charttreatmenteachcategory.Hide();
                }
                else
                {
                    charttreatmenteachcategory.Show();
                    gridoncategory.Hide();
                    comboboxcategory.Show();
                    charttreatmenteachcategory.Location = new Point(45, 51);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            {
                if (gridoncategory.Rows.Count > 0)
                {
                    string drid = "";
                    if (comboboxcategory.SelectedIndex == -1)
                    { }
                    else
                    {
                        drid = comboboxcategory.SelectedItem.ToString();
                        System.Data.DataTable dt = this.cntrl.prosetDocId(drid);
                        if (dt.Rows.Count > 0)
                        {
                            select_dr_id = dt.Rows[0]["Id"].ToString();
                        }
                    }
                    DataTable tbl = gridoncategory.DataSource as DataTable;
                    DataTable tbl1 = Grvtreatmenteachcat.DataSource as DataTable;
                    string frdate = dateTimePickertreatmenteachcat1.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickertreatmenteachcat1.Value.Month);
                    string fryear = dateTimePickertreatmenteachcat1.Value.Year.ToString();
                    string todate = dateTimePickertreatmenteachcat2.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickertreatmenteachcat2.Value.Month);
                    string toyear = dateTimePickertreatmenteachcat2.Value.Year.ToString();
                    string today = DateTime.Now.ToString("M/d/yyyy");
                    string message = "Do you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string strclinicname = "";
                    string clinicn = "";
                    string strStreet = "";
                    string stremail = "";
                    string strwebsite = "";
                    string strphone = "";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Data.DataTable dtp = this.cntrl.practceDetls();
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\Category.html");
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
                    sWrite.WriteLine("<col>"); ;
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=8> <center><FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b> TREATMENT FOR EACH CATEGORY </b> </font></center></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3>  <br><b> " + strclinicname + "</b> </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>From :</b>" + " " + dateTimePickertreatmenteachcat1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>To :</b>" + "   " + dateTimePickertreatmenteachcat2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    int k = 1;
                    if (gridoncategory.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >SlNo</font></td>");
                        sWrite.WriteLine("<td align='left' width='14%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Date</font></td>");
                        sWrite.WriteLine("<td align='left' width='56%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Services</font></td>");
                        sWrite.WriteLine("<td align='left' width='56%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor</font></td>");
                        sWrite.WriteLine("</tr>");
                        for (int i = 0; i < gridoncategory.Rows.Count; i++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + k + "</font></th>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + gridoncategory.Rows[i].Cells[1].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + gridoncategory.Rows[i].Cells[2].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + gridoncategory.Rows[i].Cells[3].Value.ToString() + "</font></td>");
                            k = k + 1;
                            sWrite.WriteLine("</tr>");
                        }
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
                    System.Diagnostics.Process.Start(Apppath + "\\Category.html");
                }
                else
                {
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnviewchart_Click(object sender, EventArgs e)
        {
            try
            {
                charttreatmenteachcategory.Show();
                gridoncategory.Hide();
                charttreatmenteachcategory.Location = new Point(45, 51);
                charttreatmenteachcategory.Size = new Size(1312, 308);
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in charttreatmenteachcategory.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickertreatmenteachcat1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreatmenteachcat2.Value.ToString("yyyy-MM-dd");
                if (comboboxcategory.SelectedIndex == 0)
                {
                    Grvtreatmenteachcat.DataSource = this.cntrl.TreatmenteachcatLoad(date1, date2);
                }
                else if (comboboxcategory.SelectedIndex > 0)
                    Grvtreatmenteachcat.DataSource = this.cntrl.Treatmenteachcat(date1, date2, Selected_drid);
                this.Grvtreatmenteachcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvtreatmenteachcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvtreatmenteachcat.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                int count = gridoncategory.Rows.Count;
                label4.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngrddailytreatment_Click(object sender, EventArgs e)
        {
            try
            {
                gridoncategory.Show();
                comboboxcategory.Show();
                charttreatmenteachcategory.Hide();
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in charttreatmenteachcategory.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickertreatmenteachcat1.Value.ToString("yyyy-MM-dd ");
                string date2 = dateTimePickertreatmenteachcat2.Value.ToString("yyyy-MM-dd ");
                if (comboboxcategory.SelectedIndex == -1)
                { }
                else
                {
                    string drid = comboboxcategory.SelectedItem.ToString();
                    System.Data.DataTable dt = this.cntrl.prosetDocId(drid);
                    if (dt.Rows.Count > 0)
                    {
                        select_dr_id = dt.Rows[0]["Id"].ToString();
                    }
                }

                if (comboboxcategory.SelectedIndex == 0)
                {
                    Grvtreatmenteachcat.DataSource = this.cntrl.TreatmenteachcatLoad(date1, date2);
                }
                else if (comboboxcategory.SelectedIndex > 0)
                {
                    Grvtreatmenteachcat.DataSource = this.cntrl.Treatmenteachcat(date1, date2, select_dr_id);
                }
                this.Grvtreatmenteachcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvtreatmenteachcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvtreatmenteachcat.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                int count = gridoncategory.Rows.Count;
                label4.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboboxcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboboxcategory.SelectedIndex == -1)
                {
                }
                else
                {
                    label4.Text = "";
                    foreach (var series in charttreatmenteachcategory.Series)
                    {
                        series.Points.Clear();
                    }
                    drctid = comboboxcategory.SelectedItem.ToString();
                    gridoncategory.DataSource = null;
                    string date1 = dateTimePickertreatmenteachcat1.Value.ToString("yyyy-MM-dd");
                    string date2 = dateTimePickertreatmenteachcat2.Value.ToString("yyyy-MM-dd");
                    System.Data.DataTable dt = this.cntrl.docId(drctid);
                    if (dt.Rows.Count > 0)
                    {
                        Selected_drid = dt.Rows[0][0].ToString();
                    }
                    if (comboboxcategory.SelectedIndex == 0)
                    {
                        DataTable dt1 = this.cntrl.ProPat(date1, date2);
                        gridoncategory.AutoGenerateColumns = false;
                        bind_grid(dt1);
                        int count = dt1.Rows.Count;
                        label4.Text = count.ToString();
                        Grvtreatmenteachcat.DataSource = this.cntrl.TreatmenteachcatLoad(date1, date2);
                    }
                    else if (comboboxcategory.SelectedIndex > 0)
                    {
                        DataTable dt1 = this.cntrl.Propat2(Convert.ToInt32(Selected_drid.ToString().Trim()), date1, date2);
                        gridoncategory.AutoGenerateColumns = false;
                        bind_grid(dt1);
                        int count = dt1.Rows.Count;
                        label4.Text = count.ToString();
                        Grvtreatmenteachcat.DataSource = this.cntrl.Treatmenteachcat(date1, date2, Selected_drid);
                    }
                    this.Grvtreatmenteachcat.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvtreatmenteachcat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (Grvtreatmenteachcat.Rows.Count < 1)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (gridoncategory.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Treatment Category Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = gridoncategory.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (comboboxcategory.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "TREATMENT REPORT FOR  All CATEGORY";
                        }
                        else if (comboboxcategory.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "TREATMENT REPORT FOR " + drctid + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickertreatmenteachcat1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickertreatmenteachcat2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10; ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < gridoncategory.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = gridoncategory.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= gridoncategory.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < gridoncategory.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = gridoncategory.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch
                            { }
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
