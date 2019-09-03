using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Monthly_Appointment_Count : Form
    {
        Monthly_Appointment_count_controller cntrl=new Monthly_Appointment_count_controller();
        public string doctor_id = "";
        public int total = 0;
        private string select_dr_id = "0";
        private string drctid = "";
        public Monthly_Appointment_Count()
        {
            InitializeComponent();
        }

        private void Monthly_appointment_count_Load(object sender, EventArgs e)
        {
            try
            {
                label_empty.Hide();
                this.Grvmonthlyappointcount.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                dataGridViewmonthlyappoinment.Hide();
                Cmb_Doctor.Items.Add("All Doctor");
                Cmb_Doctor.ValueMember = "0";
                Cmb_Doctor.DisplayMember = "All Doctor";
                DataTable doctor_rs = this.cntrl.doctor_rs();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        Cmb_Doctor.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        Cmb_Doctor.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        Cmb_Doctor.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
                Cmb_Doctor.SelectedIndex = 0;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickermonthlyappoint1.Value = date;
                this.dataGridViewmonthlyappoinment.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridViewmonthlyappoinment_RowPostPaint);
                Lab_total.Visible = true;
                Lab_total.Text = 0.ToString();
                total = 0;
                Fillgrid();
                Grvmonthlyappointcount.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvmonthlyappointcount.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvmonthlyappointcount.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                Grvmonthlyappointcount.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvmonthlyappointcount.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridViewmonthlyappoinment.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridViewmonthlyappoinment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridViewmonthlyappoinment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridViewmonthlyappoinment.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridViewmonthlyappoinment.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                if (Grvmonthlyappointcount.Rows.Count < 1)
                {
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
        void dataGridViewmonthlyappoinment_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dataGridViewmonthlyappoinment.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void searchmonth_Click(object sender, EventArgs e)
        {
            Lab_Msg.Hide();
            Lab_total.Visible = true;
            Lab_total.Text = 0.ToString();
            total = 0;
            Fillgrid();
            if (dataGridViewmonthlyappoinment.Visible)
            {
                chartmonthlyappointcount.Hide();
                dataGridViewmonthlyappoinment.Show();
                if (dataGridViewmonthlyappoinment.Rows.Count < 1)
                {
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
            }
            else
            {
                dataGridViewmonthlyappoinment.Hide();
                chartmonthlyappointcount.Show();
                if (Grvmonthlyappointcount.Rows.Count < 1)
                {
                    Lab_Msg.Show();
                }
                else
                {
                    Lab_Msg.Hide();
                }
            }
            this.Grvmonthlyappointcount.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.Grvmonthlyappointcount.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnDataview_Click(object sender, EventArgs e)
        {
            Lab_total.Visible = true;
            Lab_total.Text = 0.ToString();
            total = 0;
            Fillgrid();
            dataGridViewmonthlyappoinment.Show();
            btnchartview.Show();
            if (dataGridViewmonthlyappoinment.Rows.Count < 1)
            {
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
        }
        public void Fillgrid()
        {
            try
            {
                var dateFrom = dateTimePickermonthlyappoint1.Value.ToShortDateString();
                var dateTo = dateTimePickermonthlyappoint2.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than to date", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickermonthlyappoint1.Value = DateTime.Today;
                    return;
                }
                foreach (var series in chartmonthlyappointcount.Series)
                {
                    series.Points.Clear();
                }
                string date1 = dateTimePickermonthlyappoint1.Value.ToString("yyyy-MM-dd") + " 00:01:00";
                string date2 = dateTimePickermonthlyappoint2.Value.ToString("yyyy-MM-dd") + " 23:59:00";
                System.Data.DataTable datatableeachdoctorappoinment;
                if (Cmb_Doctor.SelectedIndex == 0)
                {

                    datatableeachdoctorappoinment = this.cntrl.datatableeachdoctorappoinment(dateTimePickermonthlyappoint1.Value.ToString("yyyy-MM-dd"), dateTimePickermonthlyappoint2.Value.ToString("yyyy-MM-dd"));
                    Grvmonthlyappointcount.DataSource = this.cntrl.Monthlyappointcount(date1, date2);
                }
                else
                {
                    datatableeachdoctorappoinment = this.cntrl.datatableeachdoctorappoinment1(dateTimePickermonthlyappoint1.Value.ToString("yyyy-MM-dd"), dateTimePickermonthlyappoint2.Value.ToString("yyyy-MM-dd"), select_dr_id);
                    Grvmonthlyappointcount.DataSource = this.cntrl.Monthlyappointcount_DoctrWise(date1, date2, select_dr_id);
                }
                dataGridViewmonthlyappoinment.Rows.Clear();
                if (datatableeachdoctorappoinment.Rows.Count > 0)
                {
                    int k = 1;
                    for (int i = 0; i < datatableeachdoctorappoinment.Rows.Count; i++)
                    {
                        dataGridViewmonthlyappoinment.Rows.Add();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["sino"].Value = k;
                        dataGridViewmonthlyappoinment.Rows[i].Cells["ptid"].Value = datatableeachdoctorappoinment.Rows[i]["Pt_id"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["pt_name"].Value = datatableeachdoctorappoinment.Rows[i]["pt_name"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["mobile_no"].Value = datatableeachdoctorappoinment.Rows[i]["primary_mobile_number"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["email_id"].Value = datatableeachdoctorappoinment.Rows[i]["email_address"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["doctor_name"].Value = datatableeachdoctorappoinment.Rows[i]["doctor_name"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["BOOKEDDATE"].Value = datatableeachdoctorappoinment.Rows[i]["book_datetime"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["book_datetime"].Value = datatableeachdoctorappoinment.Rows[i]["start_datetime"].ToString();
                        dataGridViewmonthlyappoinment.Rows[i].Cells["booked_by"].Value = datatableeachdoctorappoinment.Rows[i]["booked_by"].ToString();
                        k = k + 1;
                    }
                }
                int row = dataGridViewmonthlyappoinment.Rows.Count;
                Lab_total.Text = row.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnchartview_Click(object sender, EventArgs e)
        {
            btnDataview.Show();
            chartmonthlyappointcount.Visible = true;
            dataGridViewmonthlyappoinment.Hide();
            if (Grvmonthlyappointcount.Rows.Count < 1)
            {
                Lab_Msg.Show();
            }
            else
            {
                Lab_Msg.Hide();
            }
        }

        private void Cmb_Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                select_dr_id = "0";
                if (Cmb_Doctor.SelectedIndex == -1)
                { }
                else
                {
                    drctid = Cmb_Doctor.SelectedItem.ToString();
                    string dt = this.cntrl.Docname_logDocAdmin(drctid);
                    if (dt!="")
                    {
                        select_dr_id = dt;
                    }
                    Fillgrid();
                    if (Grvmonthlyappointcount.Rows.Count < 1)
                    {
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dataGridViewmonthlyappoinment.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Monthly Appointment Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dataGridViewmonthlyappoinment.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (Cmb_Doctor.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "MONTHLY REPORT OF All DOCTOR";
                        }
                        else if (Cmb_Doctor.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "MONTHLY REPORT OF Dr." + drctid + "";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickermonthlyappoint1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickermonthlyappoint2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dataGridViewmonthlyappoinment.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dataGridViewmonthlyappoinment.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dataGridViewmonthlyappoinment.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dataGridViewmonthlyappoinment.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dataGridViewmonthlyappoinment.Rows[i].Cells[j].Value.ToString();
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable tbl1 = dataGridViewmonthlyappoinment.DataSource as System.Data.DataTable;
                System.Data.DataTable tbl2 = Grvmonthlyappointcount.DataSource as System.Data.DataTable;
                if (dataGridViewmonthlyappoinment.Rows.Count > 0)
                {
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\AppoinmentMonthly.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table { border-collapse: collapse;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<div>");
                    sWrite.WriteLine("<table align=center>");
                    sWrite.WriteLine("<col >");
                    sWrite.WriteLine("<tr>");
                    if (Cmb_Doctor.SelectedIndex == 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=7 align=center><FONT COLOR=black FACE='Segoe UI'  SIZE=4> <b> MONTHLY APPOINTMENT " + "  </b> </font></center></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    else if (Cmb_Doctor.SelectedIndex != 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=7 align=center><FONT COLOR=black FACE='Segoe UI'  SIZE=4> <b>MONTHLY APPOINTMENT (" + Cmb_Doctor.Text.ToUpper() + " ) </b> </font></center></td>");
                        sWrite.WriteLine("</tr>");
                    }

                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI'  SIZE=3>  <b> " + strclinicname + "</b> </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI'  SIZE=2>  <b> " + strStreet + "</b> </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI'  SIZE=2>  <b> " + strphone + "</b> </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI'  SIZE=2>  " + " <b>From :</b>" + "" + dateTimePickermonthlyappoint1.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI'  SIZE=2> " + "<b> To :</b>" + "   " + dateTimePickermonthlyappoint2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI'  SIZE=2> <b> Printed Date :</b>  " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dataGridViewmonthlyappoinment.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='23' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2> <b>Sl.</b></font></td>");
                        sWrite.WriteLine("    <td align='center' width='67' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b>Patient Id</b></font></td>");
                        sWrite.WriteLine("    <td align='center' width='231' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b> Patient </b></font></td>");
                        sWrite.WriteLine("    <td align='center' width='201' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b> Email</b> </font></td>");
                        sWrite.WriteLine("    <td align='center' width='79' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b>Mobile</b></font></td>");
                        sWrite.WriteLine("    <td align='center' width='80' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b> Appointment Date</b> </font></td>");
                        sWrite.WriteLine("    <td align='center' width='150' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI'  SIZE=2><b>Doctor</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        for (int j = 0; j < dataGridViewmonthlyappoinment.Rows.Count; j++) ///aswini full for loop
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE= 'Segoe UI' SIZE=2> " + k + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2> " + dataGridViewmonthlyappoinment.Rows[j].Cells["ptid"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2> " + dataGridViewmonthlyappoinment.Rows[j].Cells["pt_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dataGridViewmonthlyappoinment.Rows[j].Cells["email_id"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left'  style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2> " + dataGridViewmonthlyappoinment.Rows[j].Cells["mobile_no"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dataGridViewmonthlyappoinment.Rows[j].Cells["BOOKEDDATE"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'  SIZE=2>" + dataGridViewmonthlyappoinment.Rows[j].Cells["doctor_name"].Value.ToString() + "</font></td>");
                            k = k + 1;
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI'  SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\AppoinmentMonthly.html");
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

        private void Grvmonthlyappointcount_DataSourceChanged(object sender, EventArgs e)
        {
            total = 0;
            for (int i = 0; i < Grvmonthlyappointcount.Rows.Count; i++)
            {
                int appointcount = int.Parse(Grvmonthlyappointcount.Rows[i].Cells[1].Value.ToString());
                total = total + appointcount;
                string seriesArray = Grvmonthlyappointcount.Rows[i].Cells[1].Value.ToString();
                string points = Grvmonthlyappointcount.Rows[i].Cells[0].Value.ToString();
                this.chartmonthlyappointcount.Palette = ChartColorPalette.SeaGreen;
                chartmonthlyappointcount.Series["Appointment (s)"]["PixelPointWidth"] = "55";
                chartmonthlyappointcount.Series["Appointment (s)"].Points.AddXY(points, seriesArray);
            }
            Lab_total.Text = total.ToString();
        }
    }
}
