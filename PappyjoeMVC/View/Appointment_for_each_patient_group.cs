using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Appointment_for_each_patient_group : Form
    {
        Appointment_for_each_patient_group_controller cntrl=new Appointment_for_each_patient_group_controller();
        Appointment_report_model _model = new Appointment_report_model();
        public string select_id = "0";
        public string gpid = " ";
        string logo_name = "";
        public Appointment_for_each_patient_group()
        {
            InitializeComponent();
        }

        private void Appointment_for_each_patient_group_Load(object sender, EventArgs e)
        {
            try
            {
                label_empty.Hide();
                this.chartappointeachpatientgroup.Titles.Add(" Appointment for each Patient Group");
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickerappointperpatientgroup1.Value = date;
                cmbptgrp.Items.Add("All Group");
                cmbptgrp.ValueMember = "0";
                cmbptgrp.DisplayMember = "All Group";
                DataTable gp_rs = this.cntrl.gp_rs();
                if (gp_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < gp_rs.Rows.Count; i++)
                    {
                        cmbptgrp.Items.Add(gp_rs.Rows[i]["group_id"].ToString());
                        cmbptgrp.ValueMember = gp_rs.Rows[i]["id"].ToString();
                        cmbptgrp.DisplayMember = gp_rs.Rows[i]["group_id"].ToString();
                    }
                }
                cmbptgrp.SelectedIndex = 0;
                select_id = "0";
                fillAll();
                this.Grvappointeachgroup.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                this.Grvappointeachgroup.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvappointeachgroup.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvappointeachgroup.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvappointeachgroup.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvappointeachgroup.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                Grvappointeachgroup.EnableHeadersVisualStyles = false;
                dataGridViewappoinmentpatientgroup.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridViewappoinmentpatientgroup.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridViewappoinmentpatientgroup.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridViewappoinmentpatientgroup.EnableHeadersVisualStyles = false;
                dataGridViewappoinmentpatientgroup.Location = new System.Drawing.Point(5, 5);
                chartappointeachpatientgroup.Show();
                dataGridViewappoinmentpatientgroup.Hide();
                foreach (DataGridViewColumn cl in Grvappointeachgroup.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn cl in dataGridViewappoinmentpatientgroup.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                this.dataGridViewappoinmentpatientgroup.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridViewappoinmentpatientgroup_RowPostPaint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void fill_chart()
        {
            int total = 0;
            for (int i = 0; i < Grvappointeachgroup.Rows.Count; i++)
            {
                int count = Convert.ToInt32(Grvappointeachgroup.Rows[i].Cells[1].Value.ToString());
                total = total + count;
                string seriesArray = Grvappointeachgroup.Rows[i].Cells[1].Value.ToString();
                string points = Grvappointeachgroup.Rows[i].Cells[0].Value.ToString();
                this.chartappointeachpatientgroup.Palette = ChartColorPalette.SeaGreen;
                chartappointeachpatientgroup.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                string pointss = points + " " + seriesArray;
                chartappointeachpatientgroup.Series["Appointment (s)"]["PieLabelStyle"] = "Outside";
                chartappointeachpatientgroup.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chartappointeachpatientgroup.Series["Appointment (s)"].Points.AddXY(pointss, seriesArray);
            }
            Lab_Total.Text = total.ToString();
        }
        void dataGridViewappoinmentpatientgroup_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridViewappoinmentpatientgroup.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        public void fillAll()
        {
            try
            {
                string date1 = dateTimePickerappointperpatientgroup1.Value.ToString("yyyy-MM-dd") + " 00:01:00";
                string date2 = dateTimePickerappointperpatientgroup2.Value.ToString("yyyy-MM-dd") + " 23:59:00";
                DataTable dtb_grid = new DataTable();
                DataTable Dt_Sidegrid = new DataTable();
                foreach (var series in chartappointeachpatientgroup.Series)
                {
                    series.Points.Clear();
                }
                if (cmbptgrp.SelectedIndex == -1)
                { }
                else
                {
                    gpid = cmbptgrp.SelectedItem.ToString();
                    string dt = this.cntrl.grp_id(gpid);
                    if (dt != "")
                    {
                        select_id = dt.ToString();
                    }
                    if (cmbptgrp.SelectedIndex == 0)
                    {

                        dtb_grid = this.cntrl.dtb_grid(date1, date2);
                        Dt_Sidegrid = this.cntrl.Appointmenteachpatientgroup(date1, date2);
                    }
                    else
                    {
                        dtb_grid = this.cntrl.dtb_grid_gpid(gpid, date1, date2);
                        Dt_Sidegrid = this.cntrl.Appointmenteachpatientgroup_DrWise(date1, date2, gpid);
                    }
                }
                Grvappointeachgroup.Rows.Clear();
                dataGridViewappoinmentpatientgroup.Rows.Clear();
                if (Dt_Sidegrid.Rows.Count > 0)
                {
                    for (int i = 0; i < Dt_Sidegrid.Rows.Count; i++)
                    {
                        Grvappointeachgroup.Rows.Add(Dt_Sidegrid.Rows[i][0].ToString(), Dt_Sidegrid.Rows[i][1].ToString());
                    }
                }
                if (dtb_grid.Rows.Count > 0)
                {
                    int count = 0, k = 1;
                    for (int i = 0; i < dtb_grid.Rows.Count; i++)
                    {
                        DataTable dt_group = this.cntrl.dt_group(dtb_grid.Rows[i]["id"].ToString());
                        dataGridViewappoinmentpatientgroup.Rows.Add();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["pt_id"].Value = dtb_grid.Rows[i]["pt_id"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["pt_name"].Value = dtb_grid.Rows[i]["pt_name"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["book_datetime"].Value = Convert.ToDateTime(dtb_grid.Rows[i]["book_datetime"].ToString()).ToString("MM/dd/yyyy");
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["primary_mobile_number"].Value = dtb_grid.Rows[i]["primary_mobile_number"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["duration"].Value = dtb_grid.Rows[i]["duration"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["start_datetime"].Value = dtb_grid.Rows[i]["start_datetime"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["booked_by"].Value = dtb_grid.Rows[i]["booked_by"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["note"].Value = dtb_grid.Rows[i]["note"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["email_address"].Value = dtb_grid.Rows[i]["email_address"].ToString();
                        dataGridViewappoinmentpatientgroup.Rows[i].Cells["doctor_name"].Value = dtb_grid.Rows[i]["doctor_name"].ToString();
                        if (dt_group.Rows.Count > 0)
                        {
                            for (int j = 0; j < dt_group.Rows.Count; j++)
                            {
                                dataGridViewappoinmentpatientgroup.Rows[i].Cells["group_id"].Value += dt_group.Rows[j]["group_id"].ToString() + ",";
                            }
                            string str = dataGridViewappoinmentpatientgroup.Rows[i].Cells["group_id"].Value.ToString();
                            string removecomma = str.Remove(str.Length - 1);
                            dataGridViewappoinmentpatientgroup.Rows[i].Cells["group_id"].Value = removecomma;
                        }
                        else
                        {
                            dataGridViewappoinmentpatientgroup.Rows[i].Cells["group_id"].Value = "No Group";
                            count = count + 1;
                        }
                        k = k + 1;
                    }
                    int index = Grvappointeachgroup.Rows.Count;
                    Grvappointeachgroup.Rows.Add();
                    Grvappointeachgroup.Rows[index].Cells[0].Value = "No Group";
                    Grvappointeachgroup.Rows[index].Cells[1].Value = count;
                    fill_chart();
                }
                int total_Count = dataGridViewappoinmentpatientgroup.Rows.Count;
                Lab_Total.Text = total_Count.ToString();
                if (dataGridViewappoinmentpatientgroup.Rows.Count < 1)
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
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
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbptgrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_id = "0";
            fillAll();
        }

        private void btn_ViewChart_Click(object sender, EventArgs e)
        {
            dataGridViewappoinmentpatientgroup.Location = new System.Drawing.Point(5, 5);
            chartappointeachpatientgroup.Show();
            dataGridViewappoinmentpatientgroup.Hide();
            var dateFrom = dateTimePickerappointperpatientgroup1.Value.ToShortDateString();
            var dateTo = dateTimePickerappointperpatientgroup2.Value.ToShortDateString();
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerappointperpatientgroup1.Value = DateTime.Today;
                return;
            }
            fillAll();
        }

        private void btn_ViewGrid_Click(object sender, EventArgs e)
        {
            var dateFrom = dateTimePickerappointperpatientgroup1.Value.ToShortDateString();
            var dateTo = dateTimePickerappointperpatientgroup2.Value.ToShortDateString();
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerappointperpatientgroup1.Value = DateTime.Today;
            }
            label6.Visible = true;
            fillAll();
            chartappointeachpatientgroup.Hide();
            dataGridViewappoinmentpatientgroup.Show();
            dataGridViewappoinmentpatientgroup.Show();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            var dateFrom = dateTimePickerappointperpatientgroup1.Value.ToShortDateString();
            var dateTo = dateTimePickerappointperpatientgroup2.Value.ToShortDateString();
            if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
            {
                MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerappointperpatientgroup1.Value = DateTime.Today;
                return;
            }
            Lab_Total.Text = "";
            fillAll();
            if (dataGridViewappoinmentpatientgroup.Visible)
            {
                chartappointeachpatientgroup.Hide();
                dataGridViewappoinmentpatientgroup.Show();
            }
            else
            {
                chartappointeachpatientgroup.Show();
            }
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dataGridViewappoinmentpatientgroup.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Appomintment Group Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dataGridViewappoinmentpatientgroup.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (cmbptgrp.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "APPOINTMENT REPORT OF All GROUP";
                        }
                        else if (cmbptgrp.SelectedIndex > 01)
                        {
                            ExcelApp.Cells[1, 1] = "APPOINTMENT REPORT OF " + gpid + " Group";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerappointperpatientgroup1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerappointperpatientgroup2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dataGridViewappoinmentpatientgroup.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dataGridViewappoinmentpatientgroup.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Segoe UI";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dataGridViewappoinmentpatientgroup.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dataGridViewappoinmentpatientgroup.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dataGridViewappoinmentpatientgroup.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewappoinmentpatientgroup.Rows.Count > 0)
                {
                    System.Data.DataTable tbl1 = dataGridViewappoinmentpatientgroup.DataSource as System.Data.DataTable;
                    string fromdate = dateTimePickerappointperpatientgroup1.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerappointperpatientgroup1.Value.Month);
                    string fryear = dateTimePickerappointperpatientgroup1.Value.Year.ToString();
                    string todate = dateTimePickerappointperpatientgroup2.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerappointperpatientgroup2.Value.Month);
                    string toyear = dateTimePickerappointperpatientgroup2.Value.Year.ToString();
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dtp = this.cntrl.Get_practiceDlNumber();
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "//Appoinmenteachpatient.html");
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
                    if (cmbptgrp.SelectedIndex > 0)
                    {
                        string comboname = cmbptgrp.SelectedItem.ToString();
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> APPOINTMENT REPORT OF " + comboname.ToUpper() + " GROUP   </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    else
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> APPOINTMENT REPORT OF EACH PATIENT GROUP  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>From :</b>" + " " + dateTimePickerappointperpatientgroup1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>To :</b>" + "   " + dateTimePickerappointperpatientgroup2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (dataGridViewappoinmentpatientgroup.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='46' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 > <b>Slno.</b> </font></td>");
                        sWrite.WriteLine("    <td align='left' width='120' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Patient Id</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='150' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp; Patient</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='115' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>&nbsp;Email </b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='112' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp; Appointment Date</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='59' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp; Mobile</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='116' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp; Group</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='117' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp; Booked By</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int j = 0; j < dataGridViewappoinmentpatientgroup.Rows.Count; j++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + k + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["pt_id"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["pt_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["email_address"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["start_datetime"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["primary_mobile_number"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["group_id"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2>&nbsp;" + dataGridViewappoinmentpatientgroup.Rows[j].Cells["doctor_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            k = k + 1;
                        }
                    }
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "//Appoinmenteachpatient.html");
                }
                else
                {
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
