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
    public partial class Treatment_For_Each_Doctor : Form
    {
        Treatment_For_Each_Doctor_controller cntrl=new Treatment_For_Each_Doctor_controller();
        public string doctor_id = "";
        string select_dr_id = "";
        public string drctid = "";
        public string Selected_drid = "";
        public Treatment_For_Each_Doctor()
        {
            InitializeComponent();
        }

        private void Treatment_for_each_doctor_Load(object sender, EventArgs e)
        {
            try
            {
                this.gridtreatmentondoctors.RowPostPaint += new DataGridViewRowPostPaintEventHandler(gridtreatmentondoctors_RowPostPaint);
                Lab_Msg.Hide();
                dateTimePickertreateachdoctor1.MaxDate = DateTime.Now;
                dateTimePickertreateachdoctor2.MaxDate = DateTime.Now;
                charttreateachdoctor.Titles.Add("Treatments for each Doctor");
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickertreateachdoctor1.Value = date;
                string date1 = dateTimePickertreateachdoctor1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreateachdoctor2.Value.ToString("yyyy-MM-dd");
                combodoctors.Items.Add("All Doctor");
                combodoctors.ValueMember = "0";
                combodoctors.DisplayMember = "All Doctor";
                System.Data.DataTable dt = this.cntrl.doctor_rs();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        combodoctors.Items.Add(dt.Rows[i]["doctor_name"].ToString());
                        combodoctors.ValueMember = dt.Rows[i]["id"].ToString();
                        combodoctors.DisplayMember = dt.Rows[i]["doctor_name"].ToString();
                    }
                }
                combodoctors.SelectedIndex = 0;
                select_dr_id = "0";
                gridtreatmentondoctors.Hide();
                charttreateachdoctor.Location = new Point(6, 50);
                charttreateachdoctor.Size = new Size(1346, 336);
                System.Data.DataTable griddailytrreatmenttable;
                griddailytrreatmenttable = this.cntrl.ProPat(date1, date2);
                bind_grid(griddailytrreatmenttable);
                label4.Text = 0.ToString();
                foreach (var series in charttreateachdoctor.Series)
                {
                    series.Points.Clear();
                }
                Grvtreatmenteachdoctor.DataSource = this.cntrl.DoctoreachtreatmentLoad(date1, date2);
                this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvtreatmenteachdoctor.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                Grvtreatmenteachdoctor.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvtreatmenteachdoctor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvtreatmenteachdoctor.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                Grvtreatmenteachdoctor.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvtreatmenteachdoctor.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                gridtreatmentondoctors.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                gridtreatmentondoctors.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                gridtreatmentondoctors.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                gridtreatmentondoctors.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in gridtreatmentondoctors.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                int count = gridtreatmentondoctors.Rows.Count;
                label4.Text = count.ToString();
                combodoctors.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void gridtreatmentondoctors_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(gridtreatmentondoctors.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        public void bind_grid(DataTable dtb)
        {
            gridtreatmentondoctors.Rows.Clear();
            int k = 1;
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                gridtreatmentondoctors.Rows.Add();
                gridtreatmentondoctors.Rows[i].Cells[0].Value = k;
                gridtreatmentondoctors.Rows[i].Cells[1].Value = dtb.Rows[i]["date"].ToString();
                gridtreatmentondoctors.Rows[i].Cells[2].Value = dtb.Rows[i]["procedure_name"].ToString();
                gridtreatmentondoctors.Rows[i].Cells[3].Value = dtb.Rows[i]["doctor_name"].ToString();
                k = k + 1;
            }
        }

        private void Grvtreatmenteachdoctor_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < Grvtreatmenteachdoctor.Rows.Count; i++)
            {
                int count = int.Parse(Grvtreatmenteachdoctor.Rows[i].Cells[1].Value.ToString());
                total = total + count;
                label4.Text = total.ToString();
                string seriesArray = Grvtreatmenteachdoctor.Rows[i].Cells[1].Value.ToString();
                string points = Grvtreatmenteachdoctor.Rows[i].Cells[0].Value.ToString();
                this.charttreateachdoctor.Palette = ChartColorPalette.SeaGreen;
                charttreateachdoctor.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                string pointss = points + " " + seriesArray;
                charttreateachdoctor.Series["Treatment (s)"]["PieLabelStyle"] = "Outside";
                charttreateachdoctor.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                charttreateachdoctor.Series["Treatment (s)"].Points.AddXY(pointss, seriesArray);
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                string date1 = dateTimePickertreateachdoctor1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreateachdoctor2.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(date1).Date > Convert.ToDateTime(date2).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is Grater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickertreateachdoctor1.Value = DateTime.Today;
                    return;
                }
                if (combodoctors.SelectedIndex == -1)
                { }
                else
                {
                    string drid = combodoctors.SelectedItem.ToString();
                    System.Data.DataTable dt = this.cntrl.Dr_ID_logn(drid);
                    
                    if (dt.Rows.Count > 0)
                    {
                        select_dr_id = dt.Rows[0]["Id"].ToString();
                    }
                }
                if (combodoctors.SelectedIndex > 0)
                {
                    System.Data.DataTable griddailytrreatmenttable;
                    griddailytrreatmenttable = this.cntrl.grdDailytreatmntTble(Convert.ToInt32(select_dr_id.ToString()), date1, date2);
                    bind_grid(griddailytrreatmenttable);
                    if (gridtreatmentondoctors.Visible)
                    {
                        label4.Text = 0.ToString();
                        label4.Visible = true;
                        foreach (var series in charttreateachdoctor.Series)
                        {
                            series.Points.Clear();
                        }
                        Grvtreatmenteachdoctor.DataSource = this.cntrl.Doctoreachtreatment(date1, date2, select_dr_id.ToString());
                        this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvtreatmenteachdoctor.Rows.Count < 1)
                        {
                            int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                            Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                            Lab_Msg.Show();
                        }
                        else
                        {
                            Lab_Msg.Hide();
                        }
                        gridtreatmentondoctors.Show();
                        charttreateachdoctor.Hide();
                        gridtreatmentondoctors.Location = new Point(6, 50);
                        gridtreatmentondoctors.Size = new Size(1346, 336);
                        combodoctors.Show();
                    }
                    else
                    {
                        label4.Text = 0.ToString();
                        label4.Visible = true;
                        foreach (var series in charttreateachdoctor.Series)
                        {
                            series.Points.Clear();
                        }
                        Grvtreatmenteachdoctor.DataSource = this.cntrl.Doctoreachtreatment(date1, date2, select_dr_id.ToString());
                        this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvtreatmenteachdoctor.Rows.Count < 1)
                        {
                            int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                            Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                            Lab_Msg.Show();
                        }
                        else
                        {
                            Lab_Msg.Hide();
                        }
                        gridtreatmentondoctors.Hide();
                        charttreateachdoctor.Show();
                        charttreateachdoctor.Location = new Point(6, 50);
                        charttreateachdoctor.Size = new Size(1346, 338);
                    }
                }
                else
                {
                    System.Data.DataTable griddailytrreatmenttable;
                    griddailytrreatmenttable = this.cntrl.ProPat(date1, date2);
                    bind_grid(griddailytrreatmenttable);
                    if (gridtreatmentondoctors.Visible)
                    {
                        label4.Text = 0.ToString();
                        label4.Visible = true;
                        foreach (var series in charttreateachdoctor.Series)
                        {
                            series.Points.Clear();
                        }
                        Grvtreatmenteachdoctor.DataSource = this.cntrl.DoctoreachtreatmentLoad(date1, date2);
                        this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvtreatmenteachdoctor.Rows.Count < 1)
                        {
                            int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                            Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                            Lab_Msg.Show();
                        }
                        else
                        {
                            Lab_Msg.Hide();
                        }
                        gridtreatmentondoctors.Show();
                        charttreateachdoctor.Hide();
                        gridtreatmentondoctors.Location = new Point(6, 50);
                        gridtreatmentondoctors.Size = new Size(1346, 336);
                        combodoctors.Show();
                    }
                    else
                    {
                        label4.Text = 0.ToString();
                        label4.Visible = true;
                        foreach (var series in charttreateachdoctor.Series)
                        {
                            series.Points.Clear();
                        }
                        Grvtreatmenteachdoctor.DataSource = this.cntrl.DoctoreachtreatmentLoad(date1, date2);
                        this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (Grvtreatmenteachdoctor.Rows.Count < 1)
                        {
                            int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                            Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                            Lab_Msg.Show();
                        }
                        else
                        {
                            Lab_Msg.Hide();
                        }
                        gridtreatmentondoctors.Hide();
                        charttreateachdoctor.Show();
                        charttreateachdoctor.Location = new Point(6, 50);
                        charttreateachdoctor.Size = new Size(1346, 338);
                    }
                }
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
                if (gridtreatmentondoctors.Rows.Count > 0)
                {
                    string drid = "";
                    if (combodoctors.SelectedIndex == -1)
                    { }
                    else
                    {
                        drid = combodoctors.SelectedItem.ToString();
                        System.Data.DataTable dt = this.cntrl.Dr_ID_logn(drid);
                        if (dt.Rows.Count > 0)
                        {
                            select_dr_id = dt.Rows[0]["Id"].ToString();
                        }
                    }
                    DataTable tbl = gridtreatmentondoctors.DataSource as DataTable;
                    DataTable tbl1 = Grvtreatmenteachdoctor.DataSource as DataTable;
                    string frdate = dateTimePickertreateachdoctor1.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickertreateachdoctor1.Value.Month);
                    string fryear = dateTimePickertreateachdoctor1.Value.Year.ToString();
                    string todate = dateTimePickertreateachdoctor2.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickertreateachdoctor2.Value.Month);
                    string toyear = dateTimePickertreateachdoctor2.Value.Year.ToString();
                    string today = DateTime.Now.ToString("M/d/yyyy");
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
                            logo_name= dtp.Rows[0]["path"].ToString();
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\FilterBasedOnDoctor.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> TREATMENT FOR EACH DOCTOR  </font></center></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>From :</b>" + " " + dateTimePickertreateachdoctor1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>To :</b>" + "   " + dateTimePickertreateachdoctor2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (gridtreatmentondoctors.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3>&nbsp;<b>Date</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='56%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3>&nbsp;<b>Services</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='56%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3>&nbsp;<b>Doctor</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int i = 0; i < gridtreatmentondoctors.Rows.Count; i++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + k + "</font></th>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + gridtreatmentondoctors.Rows[i].Cells[1].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + gridtreatmentondoctors.Rows[i].Cells[2].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + gridtreatmentondoctors.Rows[i].Cells[3].Value.ToString() + "</font></td>");
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
                    }
                    System.Diagnostics.Process.Start(Apppath + "\\FilterBasedOnDoctor.html");
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

        private void combodoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combodoctors.SelectedIndex == -1)
                {
                }
                else
                {
                    label4.Text = "";
                    foreach (var series in charttreateachdoctor.Series)
                    {
                        series.Points.Clear();
                    }
                    drctid = combodoctors.SelectedItem.ToString();
                    string query = "SELECT id from tbl_doctor where doctor_name='" + drctid + "'";
                    string date1 = dateTimePickertreateachdoctor1.Value.ToString("yyyy-MM-dd");
                    string date2 = dateTimePickertreateachdoctor2.Value.ToString("yyyy-MM-dd");
                    System.Data.DataTable dt = this.cntrl.DocId_frm_DocTbl(drctid);
                    if (dt.Rows.Count > 0)
                    {
                        Selected_drid = dt.Rows[0][0].ToString();
                    }
                    if (combodoctors.SelectedIndex > 0)
                    {
                        DataTable dt1 = this.cntrl.grdDailytreatmntTble(Convert.ToInt32(Selected_drid.ToString()), date1, date2);
                        gridtreatmentondoctors.AutoGenerateColumns = false;
                        bind_grid(dt1);
                        int count = dt1.Rows.Count;
                        label4.Text = count.ToString();
                        Grvtreatmenteachdoctor.DataSource = this.cntrl.Doctoreachtreatment(date1, date2, Selected_drid.ToString());
                    }
                    else if (combodoctors.SelectedIndex == 0)
                    {
                        DataTable dt1 = this.cntrl.GridDLYTTMNTtb(date1, date2);
                        gridtreatmentondoctors.AutoGenerateColumns = false;
                        bind_grid(dt1);
                        int count = dt1.Rows.Count;
                        label4.Text = count.ToString();
                        Grvtreatmenteachdoctor.DataSource = this.cntrl.DoctoreachtreatmentLoad(date1, date2);
                    }
                    this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (Grvtreatmenteachdoctor.Rows.Count < 1)
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

        private void btnviewchart_Click(object sender, EventArgs e)
        {
            try
            {
                gridtreatmentondoctors.Hide();
                charttreateachdoctor.Show();
                charttreateachdoctor.Location = new Point(6, 50);
                charttreateachdoctor.Size = new Size(1346, 338);
                combodoctors.Show();
                select_dr_id = "";
                label4.Text = 0.ToString();
                label4.Visible = true;
                foreach (var series in charttreateachdoctor.Series)
                {
                    series.Points.Clear();
                }
                if (combodoctors.SelectedIndex == -1)
                { }
                else
                {
                    string drid = combodoctors.SelectedItem.ToString();
                    System.Data.DataTable dt = this.cntrl.Dr_ID_logn(drid);
                    if (dt.Rows.Count > 0)
                    {
                        select_dr_id = dt.Rows[0]["Id"].ToString();
                    }
                }
                string date1 = dateTimePickertreateachdoctor1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreateachdoctor2.Value.ToString("yyyy-MM-dd");
                if (combodoctors.SelectedIndex > 0)
                    Grvtreatmenteachdoctor.DataSource = this.cntrl.Doctoreachtreatment(date1, date2, select_dr_id);
                else if (combodoctors.SelectedIndex == 0)
                    Grvtreatmenteachdoctor.DataSource = this.cntrl.DoctoreachtreatmentLoad(date1, date2);
                this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvtreatmenteachdoctor.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                int count = gridtreatmentondoctors.Rows.Count;
                label4.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ViewGrid_Click(object sender, EventArgs e)
        {
            try
            {
                gridtreatmentondoctors.Show();
                charttreateachdoctor.Hide();
                gridtreatmentondoctors.Location = new Point(6, 50);
                gridtreatmentondoctors.Size = new Size(1346, 336);
                label4.Text = 0.ToString();
                label4.Visible = true;
                combodoctors.Show();
                foreach (var series in charttreateachdoctor.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickertreateachdoctor1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickertreateachdoctor2.Value.ToString("yyyy-MM-dd");
                if (combodoctors.SelectedIndex == -1)
                { }
                else
                {
                    string drid = combodoctors.SelectedItem.ToString();
                    string query = "SELECT id from tbl_doctor where doctor_name='" + drid + "' and login_type='doctor'";
                    System.Data.DataTable dt = this.cntrl.Dr_ID_logn(drid);

                    if (dt.Rows.Count > 0)
                    {
                        select_dr_id = dt.Rows[0]["Id"].ToString();
                    }
                }
                if (combodoctors.SelectedIndex > 0)
                {
                    System.Data.DataTable griddailytrreatmenttable;
                    griddailytrreatmenttable = this.cntrl.grdDailytreatmntTble(Convert.ToInt32(Selected_drid.ToString()), date1, date2);
                    bind_grid(griddailytrreatmenttable);
                    Grvtreatmenteachdoctor.DataSource = this.cntrl.Doctoreachtreatment(date1, date2, select_dr_id.ToString());
                }
                else
                {
                    System.Data.DataTable griddailytrreatmenttable;
                    griddailytrreatmenttable = this.cntrl.ProPat(date1, date2);
                    bind_grid(griddailytrreatmenttable);
                    Grvtreatmenteachdoctor.DataSource = this.cntrl.DoctoreachtreatmentLoad(date1, date2);
                }
                this.Grvtreatmenteachdoctor.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvtreatmenteachdoctor.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvtreatmenteachdoctor.Rows.Count < 1)
                {
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                int count = gridtreatmentondoctors.Rows.Count;
                label4.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (gridtreatmentondoctors.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Doctors Treatment Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = gridtreatmentondoctors.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (combodoctors.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "TREATMENT REPORT FOR  All Doctor";
                        }
                        else if (combodoctors.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "TREATMENT REPORT FOR  Dr." + drctid + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickertreateachdoctor1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickertreateachdoctor2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < gridtreatmentondoctors.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = gridtreatmentondoctors.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= gridtreatmentondoctors.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < gridtreatmentondoctors.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = gridtreatmentondoctors.Rows[i].Cells[j].Value.ToString();
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
                    MessageBox.Show("No records found,Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
