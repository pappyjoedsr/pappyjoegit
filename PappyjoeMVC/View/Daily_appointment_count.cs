using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Daily_Appointment_Count : Form
    {
        Daily_Appointment_Count_controller cntrl=new Daily_Appointment_Count_controller();
        string drctid = "";
        public string select_dr_id = "0";
        public string doctor_id = "";

        public Daily_Appointment_Count()
        {
            InitializeComponent();
        }

        private void Daily_appointment_count_Load(object sender, EventArgs e)
        {
            try
            {
                lAB_TOTAL.Visible = false;
                this.Grvdailyappointcount.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                DateTime now = DateTime.Now;
                btnHidedatalist.Show();
                comboBoxdoctor.Items.Add("All Doctor");
                comboBoxdoctor.ValueMember = "0";
                comboBoxdoctor.DisplayMember = "All Doctor";
                DataTable doctor_rs = this.cntrl.doctor_rs();
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
                dataGridViewDailyappoinment.Hide();
                this.dataGridViewDailyappoinment.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridViewDailyappoinment_RowPostPaint);
                lAB_TOTAL.Visible = true;
                lAB_TOTAL.Text = 0.ToString();
                fillgrid();
                if (dataGridViewDailyappoinment.Rows.Count < 1)
                {
                    Lab_Msg.Show();
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                   
                }
                else
                {
                    Lab_Msg.Hide();
                }
                Grvdailyappointcount.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvdailyappointcount.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvdailyappointcount.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                Grvdailyappointcount.EnableHeadersVisualStyles = false;
                Grvdailyappointcount.Location = new System.Drawing.Point(5, 5);
                foreach (DataGridViewColumn cl in Grvdailyappointcount.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridViewDailyappoinment.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridViewDailyappoinment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridViewDailyappoinment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridViewDailyappoinment.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridViewDailyappoinment.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void dataGridViewDailyappoinment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridViewDailyappoinment.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void Grvdailyappointcount_DataSourceChanged(object sender, EventArgs e)
        {
            int total = 0;
            for (int i = 0; i < Grvdailyappointcount.Rows.Count - 1; i++)
            {
                int appointcount = int.Parse(Grvdailyappointcount.Rows[i].Cells[1].Value.ToString());
                total = total + appointcount;
                string seriesArray = Grvdailyappointcount.Rows[i].Cells[1].Value.ToString();
                string points = Convert.ToDateTime(Grvdailyappointcount.Rows[i].Cells[0].Value.ToString()).ToString("MM/dd/yyyy");
                this.chartdailyappointcount.Palette = ChartColorPalette.SeaGreen;
                chartdailyappointcount.Series["Appointment (s)"]["PixelPointWidth"] = "55";
                chartdailyappointcount.Series["Appointment (s)"].Points.AddXY(points, seriesArray);
            }
            lAB_TOTAL.Text = total.ToString();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable tbl1 = dataGridViewDailyappoinment.DataSource as System.Data.DataTable;
                System.Data.DataTable tbl2 = Grvdailyappointcount.DataSource as System.Data.DataTable;
                if (dataGridViewDailyappoinment.Rows.Count > 0)
                {
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string strclinicname = ""; string clinicn = "";
                    string strStreet = "";
                    string stremail = "";
                    string strwebsite = "";
                    string strphone = "",logo_name="";
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\AppoinmentDaily.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> DAILY APPOINTMENT DETAILS " + "  </font></center></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b> From : </b>" + dateTimePickerdailyappointcount1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + "<b> To :</b> " + dateTimePickerdailyappointcount2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=8><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>Printed Date:</b> " + DateTime.Now.ToString("dd/MM/yyyy") + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dataGridViewDailyappoinment.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='50' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Slno.</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='120' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Patient Id</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='200' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Patient Name</b> </font></td>");
                        sWrite.WriteLine("    <td align='left' width='129' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp; <b>Doctor</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='62' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Mobile</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='186' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Email Id</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='140' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Appointment Date </b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='104' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Booked By</b> </font></td>");
                        sWrite.WriteLine("</tr>");
                        for (int j = 0; j < dataGridViewDailyappoinment.Rows.Count; j++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dataGridViewDailyappoinment.Rows[j].Cells["sino"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dataGridViewDailyappoinment.Rows[j].Cells["patientid"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + dataGridViewDailyappoinment.Rows[j].Cells["pt_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + dataGridViewDailyappoinment.Rows[j].Cells["doctors"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left'  style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dataGridViewDailyappoinment.Rows[j].Cells["mobile_no"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dataGridViewDailyappoinment.Rows[j].Cells["email_id"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dataGridViewDailyappoinment.Rows[j].Cells["book_datetime"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left'  style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dataGridViewDailyappoinment.Rows[j].Cells["booked_by"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='segoe UI' SIZE=2 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\AppoinmentDaily.html");
                    }
                }
                else
                {
                    MessageBox.Show("No records found,please Click the View Grid button  and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHidedatalist_Click(object sender, EventArgs e)
        {
            fillgrid();
            chartdailyappointcount.Show();
            dataGridViewDailyappoinment.Hide();
        }
        public void fillgrid()
        {
            try
            {
                foreach (var series in chartdailyappointcount.Series)
                {
                    series.Points.Clear();
                }
                var dateFrom = dateTimePickerdailyappointcount1.Value.ToShortDateString();
                var dateTo = dateTimePickerdailyappointcount2.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than to date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dateTimePickerdailyappointcount1.Value = DateTime.Today;
                    return;
                }
                System.Data.DataTable gridviewtabledailyappoiment;
                string date1 = dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd") + " 00:01:00";
                string date2 = dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd") + " 23:59:00";
                if (comboBoxdoctor.SelectedIndex > 0)
                {
                    gridviewtabledailyappoiment = this.cntrl.gridviewtabledailyappoiment(date1, date2, select_dr_id);
                    Grvdailyappointcount.DataSource = this.cntrl.Dailyappointcount_dOCTORwISE(date1, date2, select_dr_id);
                }
                else
                {
                    gridviewtabledailyappoiment = this.cntrl.gridviewtabledailyappoiment1(date1, date2);
                    Grvdailyappointcount.DataSource = this.cntrl.Dailyappointcount(date1, date2);
                }
                dataGridViewDailyappoinment.Rows.Clear();
                if (gridviewtabledailyappoiment.Rows.Count > 0)
                {
                    int k = 1;
                    for (int i = 0; i < gridviewtabledailyappoiment.Rows.Count; i++)
                    {
                        dataGridViewDailyappoinment.Rows.Add();
                        dataGridViewDailyappoinment.Rows[i].Cells["sino"].Value = k;
                        dataGridViewDailyappoinment.Rows[i].Cells["patientid"].Value = gridviewtabledailyappoiment.Rows[i]["pt_id"].ToString();
                        dataGridViewDailyappoinment.Rows[i].Cells["pt_name"].Value = gridviewtabledailyappoiment.Rows[i]["pt_name"].ToString();
                        dataGridViewDailyappoinment.Rows[i].Cells["mobile_no"].Value = gridviewtabledailyappoiment.Rows[i]["primary_mobile_number"].ToString();
                        dataGridViewDailyappoinment.Rows[i].Cells["email_id"].Value = gridviewtabledailyappoiment.Rows[i]["email_address"].ToString();
                        dataGridViewDailyappoinment.Rows[i].Cells["doctors"].Value = gridviewtabledailyappoiment.Rows[i]["doctor_name"].ToString();
                        dataGridViewDailyappoinment.Rows[i].Cells["book_datetime"].Value = Convert.ToDateTime(gridviewtabledailyappoiment.Rows[i]["start_datetime"].ToString()).ToString("dd-MM-yyyy hh:mm tt");
                        dataGridViewDailyappoinment.Rows[i].Cells["booked_by"].Value = gridviewtabledailyappoiment.Rows[i]["booked_by"].ToString();
                        k = k + 1;
                    }
                }
                this.Grvdailyappointcount.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvdailyappointcount.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void serchdaily_Click(object sender, EventArgs e)
        {
            lAB_TOTAL.Visible = true;
            lAB_TOTAL.Text = 0.ToString();
            fillgrid();
            if (dataGridViewDailyappoinment.Visible)
            {
                int row = dataGridViewDailyappoinment.Rows.Count;
                lAB_TOTAL.Text = row.ToString();
                if (dataGridViewDailyappoinment.Rows.Count < 1)
                {
                    Lab_Msg.Show();
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                   
                }
                else
                {
                    Lab_Msg.Hide();
                }
            }
            else
            {
                chartdailyappointcount.Show();
                if (Grvdailyappointcount.Rows.Count < 1)
                {
                    Lab_Msg.Show();
                    int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                   
                }
                else
                {
                    Lab_Msg.Hide();
                }
            }
        }

        private void btn_ExporttoExcel_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dataGridViewDailyappoinment.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Daily Appointment Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dataGridViewDailyappoinment.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (comboBoxdoctor.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "DAILY APPOINTMENT REPORT OF All DOCTOR";
                        }
                        else if (comboBoxdoctor.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "DAILY APPOINTMENT REPORT OF Dr." + drctid + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerdailyappointcount1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerdailyappointcount2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dataGridViewDailyappoinment.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dataGridViewDailyappoinment.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dataGridViewDailyappoinment.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dataGridViewDailyappoinment.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dataGridViewDailyappoinment.Rows[i].Cells[j].Value.ToString();
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
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewdatalist_Click(object sender, EventArgs e)
        {
            btnHidedatalist.Show();
            dataGridViewDailyappoinment.Show();
            fillgrid();
            lAB_TOTAL.Visible = true;
            if (dataGridViewDailyappoinment.Rows.Count < 1)
            {
                int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
            int row = dataGridViewDailyappoinment.Rows.Count;
            lAB_TOTAL.Text = row.ToString();
        }

        private void comboBoxdoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxdoctor.SelectedIndex == -1)
                { }
                else
                {
                    drctid = comboBoxdoctor.SelectedItem.ToString();
                    string dt = this.cntrl.Get_DoctorId(drctid);
                    if (dt!="")
                    {
                        select_dr_id = dt.ToString();
                    }
                    fillgrid();
                    if (dataGridViewDailyappoinment.Rows.Count < 1)
                    {
                        int x = (panel4.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Show();
                    }
                    else
                    {
                        Lab_Msg.Hide();
                    }
                    int row = dataGridViewDailyappoinment.Rows.Count;
                    lAB_TOTAL.Text = row.ToString();
                }
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
    }
}