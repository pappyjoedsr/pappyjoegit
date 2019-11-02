using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Doctor_Wise_Appointment_Report : Form
    {
        DoctorWise_appointment_report_controller cntrl=new DoctorWise_appointment_report_controller();
        public string doctor_id = "";
        public string select_dr_id = "0";
        string drctid = "";
        public Doctor_Wise_Appointment_Report()
        {
            InitializeComponent();
        }

        private void DoctorWise_appointment_report_Load(object sender, EventArgs e)
        {
            try
            {
                label_empty.Hide();
                this.Grvappointforeachdoctor.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                comboBoxdoctor.Items.Add("All Doctor");
                comboBoxdoctor.ValueMember = "0";
                comboBoxdoctor.DisplayMember = "All Doctor";
                DataTable doctor_rs = this.cntrl.get_all_doctorname();
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
                select_dr_id = "0";
                dataGridVieweachdoctorappoinmt.Hide();
                this.dataGridVieweachdoctorappoinmt.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridVieweachdoctorappoinmt_RowPostPaint);
                this.chartappointeachdoctor.Titles.Add(" Appointment for each Doctor");
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickerappointeachdoctor1.Value = date;
                fillGrid();
                Grvappointforeachdoctor.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvappointforeachdoctor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvappointforeachdoctor.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                Grvappointforeachdoctor.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvappointforeachdoctor.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridVieweachdoctorappoinmt.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridVieweachdoctorappoinmt.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridVieweachdoctorappoinmt.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                dataGridVieweachdoctorappoinmt.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridVieweachdoctorappoinmt.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (Grvappointforeachdoctor.Rows.Count < 1)
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
        void dataGridVieweachdoctorappoinmt_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridVieweachdoctorappoinmt.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void Grvappointforeachdoctor_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < Grvappointforeachdoctor.Rows.Count; i++)
            {
                int count = Convert.ToInt32(Grvappointforeachdoctor.Rows[i].Cells[1].Value.ToString());
                total = total + count;
                string seriesArray = Grvappointforeachdoctor.Rows[i].Cells[1].Value.ToString();
                string points = Grvappointforeachdoctor.Rows[i].Cells[0].Value.ToString();
                this.chartappointeachdoctor.Palette = ChartColorPalette.SeaGreen;
                chartappointeachdoctor.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                string pointss = points + " " + seriesArray;
                chartappointeachdoctor.Series["Appointment (s)"]["PieLabelStyle"] = "Outside";
                chartappointeachdoctor.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                chartappointeachdoctor.Series["Appointment (s)"].Points.AddXY(pointss, seriesArray);
            }
        }

        private void comboBoxdoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                select_dr_id = "0";
                if (comboBoxdoctor.SelectedIndex == -1)
                { }
                else
                {
                    drctid = comboBoxdoctor.SelectedItem.ToString();
                    string dt = this.cntrl.Get_DoctorId(drctid);
                    if (dt != "")
                    {
                        select_dr_id = dt.ToString();
                    }
                    fillGrid();
                    if (dataGridVieweachdoctorappoinmt.Rows.Count < 1)
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void fillGrid()
        {
            try
            {
                var dateFrom = dateTimePickerappointeachdoctor1.Value.ToString("yyyy-MM-dd") + " 00:01:00";
                var dateTo = dateTimePickerappointeachdoctor2.Value.ToString("yyyy-MM-dd") + " 23:59:00";
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerappointeachdoctor1.Value = DateTime.Today;
                    return;
                }
                foreach (var series in chartappointeachdoctor.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickerappointeachdoctor1.Value.ToString("yyyy-MM-dd") + " 00:01:00";
                string date2 = dateTimePickerappointeachdoctor2.Value.ToString("yyyy-MM-dd") + " 23:59:00";
                System.Data.DataTable datatableeachdoctorappoinment;
                if (comboBoxdoctor.SelectedIndex == 0)
                {
                    datatableeachdoctorappoinment = this.cntrl.dt_docApt(date1, date2);
                    Grvappointforeachdoctor.DataSource = this.cntrl.Appointcountforeachdoctor(date1, date2);
                }
                else
                {
                    datatableeachdoctorappoinment = this.cntrl.dt_docApt1(date1, date2, select_dr_id);
                    Grvappointforeachdoctor.DataSource = this.cntrl.Appointcountforeachdoctor_DoctrWise(date1, date2, select_dr_id);
                }
                dataGridVieweachdoctorappoinmt.Rows.Clear();
                if (datatableeachdoctorappoinment.Rows.Count > 0)
                {
                    int k = 1;
                    for (int i = 0; i < datatableeachdoctorappoinment.Rows.Count; i++)
                    {
                        dataGridVieweachdoctorappoinmt.Rows.Add();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["slno"].Value = k;
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["ptid"].Value = datatableeachdoctorappoinment.Rows[i]["Pt_id"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["patientname"].Value = datatableeachdoctorappoinment.Rows[i]["pt_name"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["Email"].Value = datatableeachdoctorappoinment.Rows[i]["email_address"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["Mobile"].Value = datatableeachdoctorappoinment.Rows[i]["primary_mobile_number"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["doctor"].Value = datatableeachdoctorappoinment.Rows[i]["doctor_name"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["bookeddate"].Value = Convert.ToDateTime(datatableeachdoctorappoinment.Rows[i]["book_datetime"].ToString()).ToString("dd-MM-yyyy");
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["Startdate"].Value = datatableeachdoctorappoinment.Rows[i]["start_datetime"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["duration"].Value = datatableeachdoctorappoinment.Rows[i]["duration"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["Schedule"].Value = datatableeachdoctorappoinment.Rows[i]["schedule"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["waiting"].Value = datatableeachdoctorappoinment.Rows[i]["waiting"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["Engaged"].Value = datatableeachdoctorappoinment.Rows[i]["engaged"].ToString();
                        dataGridVieweachdoctorappoinmt.Rows[i].Cells["Checkout"].Value = datatableeachdoctorappoinment.Rows[i]["checkout"].ToString();
                        k = k + 1;
                    }
                }
                int row = dataGridVieweachdoctorappoinmt.Rows.Count;
                Lab_Total.Text = row.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            fillGrid();
            if (dataGridVieweachdoctorappoinmt.Visible)
            {
                chartappointeachdoctor.Hide();
                dataGridVieweachdoctorappoinmt.Show();
                if (dataGridVieweachdoctorappoinmt.Rows.Count < 1)
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
            else
            {
                dataGridVieweachdoctorappoinmt.Hide();
                chartappointeachdoctor.Show();
                if (Grvappointforeachdoctor.Rows.Count < 1)
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
            dataGridVieweachdoctorappoinmt.Location = new System.Drawing.Point(5, 5);
        }

        private void btn_Graph_Click(object sender, EventArgs e)
        {
            fillGrid();
            dataGridVieweachdoctorappoinmt.Hide();
            chartappointeachdoctor.Show();
            chartappointeachdoctor.Location = new System.Drawing.Point(1, 3);
            chartappointeachdoctor.Size = new System.Drawing.Size(1104, 570);
        }

        private void btn_grid_Click(object sender, EventArgs e)
        {
            try
            {
                string drid = comboBoxdoctor.SelectedItem.ToString();
                string dt = this.cntrl.get_docId(drid); ;
                if (dt != "")
                {
                    select_dr_id = dt;
                }
                fillGrid();
                chartappointeachdoctor.Hide();
                if (dataGridVieweachdoctorappoinmt.Rows.Count < 1)
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
                dataGridVieweachdoctorappoinmt.Location = new System.Drawing.Point(1, 3);
                dataGridVieweachdoctorappoinmt.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dataGridVieweachdoctorappoinmt.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Appointment Report Of Doctor(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dataGridVieweachdoctorappoinmt.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (comboBoxdoctor.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "APPOINTMENT REPORT OF All DOCTOR";
                        }
                        else if (comboBoxdoctor.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "APPOINTMENT REPORT OF Dr." + drctid + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerappointeachdoctor1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerappointeachdoctor2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dataGridVieweachdoctorappoinmt.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dataGridVieweachdoctorappoinmt.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dataGridVieweachdoctorappoinmt.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dataGridVieweachdoctorappoinmt.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dataGridVieweachdoctorappoinmt.Rows[i].Cells[j].Value.ToString();
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
                if (comboBoxdoctor.SelectedIndex == -1)
                { }
                else
                {
                    string drid = comboBoxdoctor.SelectedItem.ToString();
                    string dt = this.cntrl.doc_name_login(drid);
                    if (dt != "")
                    {
                        select_dr_id = dt;
                    }
                }
                if (dataGridVieweachdoctorappoinmt.Rows.Count > 0)
                {
                    System.Data.DataTable tbl1 = dataGridVieweachdoctorappoinmt.DataSource as System.Data.DataTable;
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string clinicn = "";
                    string strclinicname = "";
                    string strStreet = "";
                    string stremail = "";
                    string strwebsite = "";
                    string strphone = "";
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
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\Appoinmentdoctorwiseeach.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table { border-collapse: collapse;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<div>");
                    sWrite.WriteLine("<table align=center width=900>");
                    sWrite.WriteLine("<col >");
                    if (comboBoxdoctor.SelectedIndex == 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b>DOCTOR WISE APPOINTMENT REPORT(All Doctor)</b> </font></center></th>");
                        sWrite.WriteLine("</tr>");
                    }
                    if (comboBoxdoctor.SelectedIndex != 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=7> <center><FONT COLOR=black FACE='Segoe UI' SIZE=4>  <b>  APPOINTMENT REPORT OF DR." + comboBoxdoctor.Text.ToUpper() + "</b> </font></center></th>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> " + strclinicname + "</b> </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + strphone + "</b> </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + "<b> From :</b>" + " " + dateTimePickerappointeachdoctor1.Value.ToString("MM/dd/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + "<b> To :</b>" + "   " + dateTimePickerappointeachdoctor2.Value.ToString("MM/dd/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Printed Date</b> : " + DateTime.Now.ToString("MM/dd/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dataGridVieweachdoctorappoinmt.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>  Sl.</b> </font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Patient Id</b> </font></td>");
                        sWrite.WriteLine("    <td align='center' width='22%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI'' SIZE=3><b>Patient</b> </font></td>");
                        sWrite.WriteLine("    <td align='center' width='21%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Email </b></font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> Appointment Date </b> </font></td>");
                        sWrite.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Mobile</b></font></td>");
                        sWrite.WriteLine("    <td align='center' width='16%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>  Doctor</b> </font></td>");

                        sWrite.WriteLine("    <td align='center' width='8%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> Duration (Mins)</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int j = 0; j < dataGridVieweachdoctorappoinmt.Rows.Count; j++) //aswini full for loop
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + k + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dataGridVieweachdoctorappoinmt.Rows[j].Cells["ptid"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dataGridVieweachdoctorappoinmt.Rows[j].Cells["patientname"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dataGridVieweachdoctorappoinmt.Rows[j].Cells["Email"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + Convert.ToDateTime(dataGridVieweachdoctorappoinmt.Rows[j].Cells["Startdate"].Value.ToString()) + "</font></td>");
                            sWrite.WriteLine("    <td align='left'  style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dataGridVieweachdoctorappoinmt.Rows[j].Cells["Mobile"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dataGridVieweachdoctorappoinmt.Rows[j].Cells["doctor"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dataGridVieweachdoctorappoinmt.Rows[j].Cells["duration"].Value.ToString() + "</font></td>");
                            k = k + 1;
                            sWrite.WriteLine("</tr>");
                        }
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
                    System.Diagnostics.Process.Start(Apppath + "\\Appoinmentdoctorwiseeach.html");
                }
                else
                {
                    MessageBox.Show("No records found, Please Change the date and try again!..", "No records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
