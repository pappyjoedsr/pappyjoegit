using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace PappyjoeMVC.View
{
    public partial class Monthly_Treatment_Count : Form
    {
        Monthly_Treatment_Count_controller cntrl=new Monthly_Treatment_Count_controller();
        public string doctor_id = "";
        public int total = 0;
        public string select_dr_id = "0";
        string drctid = "";
        public Monthly_Treatment_Count()
        {
            InitializeComponent();
        }

        private void Monthly_treatment_count_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridmonthlytreatment.RowPostPaint += new DataGridViewRowPostPaintEventHandler(gridmonthlytreatment_RowPostPaint);
                this.Grvmonthtreatment.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                label4.Visible = false;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickermontreatment1.Value = date;
                string date1 = dateTimePickermontreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermontreatment2.Value.ToString("yyyy-MM-dd");
                comboBoxdoctor.Items.Add("All Doctor");
                comboBoxdoctor.ValueMember = "0";
                comboBoxdoctor.DisplayMember = "All Doctor";
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
                System.Data.DataTable griddailytrreatmenttable = this.cntrl.gridTable(date1, date2);
                bind_grid(griddailytrreatmenttable);
                gridmonthlytreatment.Hide();
                chartmonthtreatment.Location = new Point(53, 53);
                chartmonthtreatment.Size = new Size(1267, 336);
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in chartmonthtreatment.Series)
                {
                    series.Points.Clear();
                }
                Grvmonthtreatment.DataSource = this.cntrl.MonthtreatmentcountLoad(date1, date2);
                this.Grvmonthtreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvmonthtreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvmonthtreatment.Rows.Count == 0)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                gridmonthlytreatment.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                gridmonthlytreatment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gridmonthlytreatment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                gridmonthlytreatment.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in gridmonthlytreatment.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                Grvmonthtreatment.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvmonthtreatment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvmonthtreatment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                Grvmonthtreatment.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvmonthtreatment.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                comboBoxdoctor.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void bind_grid(DataTable dtb)
        {
            gridmonthlytreatment.Rows.Clear();
            int k = 1;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                gridmonthlytreatment.Rows.Add();
                gridmonthlytreatment.Rows[i].Cells[0].Value = k;
                gridmonthlytreatment.Rows[i].Cells[1].Value = dtb.Rows[i]["date"].ToString();
                gridmonthlytreatment.Rows[i].Cells[2].Value = dtb.Rows[i]["procedure_name"].ToString();
                gridmonthlytreatment.Rows[i].Cells[3].Value = dtb.Rows[i]["doctor_name"].ToString();
                k = k + 1;
            }
        }
        void gridmonthlytreatment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(gridmonthlytreatment.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                var d1 = dateTimePickermontreatment1.Value.ToShortDateString();
                var d2 = dateTimePickermontreatment2.Value.ToShortDateString();
                if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is Grater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickermontreatment1.Value = DateTime.Today;
                    return;
                }
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in chartmonthtreatment.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickermontreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermontreatment2.Value.ToString("yyyy-MM-dd");
                if (comboBoxdoctor.SelectedIndex == 0)
                {
                    System.Data.DataTable griddailytrreatmenttable = this.cntrl.GridDLYTTMNTtb(date1, date2);
                    bind_grid(griddailytrreatmenttable);
                    Grvmonthtreatment.DataSource = this.cntrl.MonthtreatmentcountLoad(date1, date2);
                }
                else
                {
                    System.Data.DataTable griddailytrreatmenttable=this.cntrl.DailyTablE(date1,date2,select_dr_id);
                    bind_grid(griddailytrreatmenttable);
                    Grvmonthtreatment.DataSource = this.cntrl.Monthtreatmentcount(date1, date2, select_dr_id);
                }
                this.Grvmonthtreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvmonthtreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvmonthtreatment.Rows.Count == 0)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                if (gridmonthlytreatment.Visible)
                {
                    label2.Visible = true;
                    gridmonthlytreatment.Show();
                    chartmonthtreatment.Hide();
                    //gridmonthlytreatment.Location = new Point(53, 53);
                    //gridmonthlytreatment.Size = new Size(1267, 336);
                }
                else
                {
                    //if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
                    //{
                    //    MessageBox.Show("From date should be less than To date", "From Date is Grater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    dateTimePickermontreatment1.Value = DateTime.Today;
                    //}
                    gridmonthlytreatment.Hide();
                    chartmonthtreatment.Show();
                    //chartmonthtreatment.Location = new Point(53, 53);
                    //chartmonthtreatment.Size = new Size(1267, 336);
                    label4.Visible = true;
                    int row = gridmonthlytreatment.Rows.Count;
                    label4.Text = row.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grvmonthtreatment_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < Grvmonthtreatment.Rows.Count; i++)
            {
                int count = int.Parse(Grvmonthtreatment.Rows[i].Cells[1].Value.ToString());
                total = total + count;
                string seriesArray = Grvmonthtreatment.Rows[i].Cells[1].Value.ToString();
                string points = Grvmonthtreatment.Rows[i].Cells[0].Value.ToString();
                this.chartmonthtreatment.Palette = ChartColorPalette.BrightPastel;
                chartmonthtreatment.Series["Treatment Count"]["PixelPointWidth"] = "55";
                string pointss = points + seriesArray;
                chartmonthtreatment.Series["Treatment Count"].Points.AddXY(points, seriesArray);
            }
            if (total == 0)
            {
                label4.Text = 0.ToString();
            }
            label4.Text = total.ToString();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridmonthlytreatment.Rows.Count > 0)
                {
                  
                    string today = DateTime.Now.ToString("d/M/yyyy");
                    string message = "Did you want Header on Print?";
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
                        System.Data.DataTable dtp = this.cntrl.practceDetls();
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\Monthlycount.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3>  MONTHLY TREATMENT REPORT  </font></center></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>From :</b>" + " " + dateTimePickermontreatment1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>To :</b>" + "   " + dateTimePickermontreatment2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (gridmonthlytreatment.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='14%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'' SIZE=3>&nbsp;<b>Date</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='30%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Services</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='16%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Doctor</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int i = 0; i < gridmonthlytreatment.Rows.Count; i++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + k + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + gridmonthlytreatment.Rows[i].Cells[1].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + gridmonthlytreatment.Rows[i].Cells[2].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + gridmonthlytreatment.Rows[i].Cells[3].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            k = k + 1;
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\Monthlycount.html");
                    }
                }
                else
                {
                    MessageBox.Show("No records found, Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnviewchart_Click(object sender, EventArgs e)
        {
            try
            {
                var d1 = dateTimePickermontreatment1.Value.ToShortDateString();
                var d2 = dateTimePickermontreatment2.Value.ToShortDateString();
                if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is Grater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickermontreatment1.Value = DateTime.Today;
                }
                gridmonthlytreatment.Hide();
                chartmonthtreatment.Show();
                chartmonthtreatment.Location = new Point(53, 53);
                chartmonthtreatment.Size = new Size(1267, 336);
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in chartmonthtreatment.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickermontreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermontreatment2.Value.ToString("yyyy-MM-dd");
                if (comboBoxdoctor.SelectedIndex == 0)
                {
                    System.Data.DataTable griddailytrreatmenttable = this.cntrl.GridDLYTTMNTtb(date1, date2); ;
                    bind_grid(griddailytrreatmenttable);
                    Grvmonthtreatment.DataSource = this.cntrl.MonthtreatmentcountLoad(date1, date2);
                }
                else
                {
                    System.Data.DataTable griddailytrreatmenttable = this.cntrl.DailyTablE(date1, date2, select_dr_id);
                    bind_grid(griddailytrreatmenttable);
                    Grvmonthtreatment.DataSource = this.cntrl.Monthtreatmentcount(date1, date2, select_dr_id);
                }
                this.Grvmonthtreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvmonthtreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvmonthtreatment.Rows.Count == 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btngrddailytreatment_Click(object sender, EventArgs e)
        {
            try
            {
                var d1 = dateTimePickermontreatment1.Value.ToShortDateString();
                var d2 = dateTimePickermontreatment2.Value.ToShortDateString();
                string date1 = dateTimePickermontreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermontreatment2.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is Grater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickermontreatment1.Value = DateTime.Today;
                }
                gridmonthlytreatment.Show();
                chartmonthtreatment.Hide();
                //gridmonthlytreatment.Location = new Point(53, 53);
                // gridmonthlytreatment.Size = new Size(1267, 336);
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in chartmonthtreatment.Series)
                {
                    series.Points.Clear();
                }
                if (comboBoxdoctor.SelectedIndex == 0)
                {
                    System.Data.DataTable griddailytrreatmenttable = this.cntrl.GridDLYTTMNTtb(date1, date2);
                    bind_grid(griddailytrreatmenttable);
                    Grvmonthtreatment.DataSource = this.cntrl.MonthtreatmentcountLoad(date1, date2);
                }
                else
                {
                    System.Data.DataTable griddailytrreatmenttable = this.cntrl.DailyTablE(date1, date2, select_dr_id);
                    bind_grid(griddailytrreatmenttable);
                    Grvmonthtreatment.DataSource = this.cntrl.Monthtreatmentcount(date1, date2, select_dr_id);
                }
                this.Grvmonthtreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvmonthtreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvmonthtreatment.Rows.Count == 0)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxdoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                select_dr_id = "0";
                foreach (var series in chartmonthtreatment.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickermontreatment1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermontreatment2.Value.ToString("yyyy-MM-dd");
                if (comboBoxdoctor.SelectedIndex == -1)
                { }
                else
                {
                    drctid = comboBoxdoctor.SelectedItem.ToString();
                    System.Data.DataTable dt = this.cntrl.DocId_frm_DocTbl(drctid);
                    if (dt.Rows.Count > 0)
                    {
                        select_dr_id = dt.Rows[0]["Id"].ToString();
                    }
                    if (comboBoxdoctor.SelectedIndex == 0)
                    {
                        System.Data.DataTable datatableeachdoctorappoinment = this.cntrl.ProPat(date1, date2);
                        bind_grid(datatableeachdoctorappoinment);
                        Grvmonthtreatment.DataSource = this.cntrl.MonthtreatmentcountLoad(date1, date2);
                    }
                    else
                    {
                        System.Data.DataTable datatableeachdoctorappoinment = this.cntrl.DailyTablE(date1, date2, select_dr_id);
                        bind_grid(datatableeachdoctorappoinment);
                        Grvmonthtreatment.DataSource = this.cntrl.Monthtreatmentcount(date1, date2, select_dr_id);
                    }
                    this.Grvmonthtreatment.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvmonthtreatment.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (Grvmonthtreatment.Rows.Count == 0)
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
                if (gridmonthlytreatment.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Monthly Treatment Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = gridmonthlytreatment.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (comboBoxdoctor.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "MONTHLY TREATMENT REPORT OF All DOCTOR";
                        }
                        else if (comboBoxdoctor.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "MONTHLY TREATMENT REPORT OF Dr." + drctid + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickermontreatment1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickermontreatment2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10; ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < gridmonthlytreatment.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = gridmonthlytreatment.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= gridmonthlytreatment.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < gridmonthlytreatment.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = gridmonthlytreatment.Rows[i].Cells[j].Value.ToString();
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

