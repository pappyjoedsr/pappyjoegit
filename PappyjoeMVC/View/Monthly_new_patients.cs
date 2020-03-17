using PappyjoeMVC.Controller;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PappyjoeMVC.View
{
    public partial class Monthly_New_Patients : Form
    {
        Monthly_New_Patients_controller cntrl=new Monthly_New_Patients_controller();
        public string doctor_id = "";
        public int flag = 0;
        public Monthly_New_Patients()
        {
            InitializeComponent();
        }

        private void Monthly_new_patients_Load(object sender, EventArgs e)
        {
            try
            {
                label4.Visible = false;
                lblNoRecord.Hide();
                dataGridmonthlypatient.Hide();
                dateTimePickermonthnewpatient2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickermonthnewpatient1.Value = date;
                string date1 = dateTimePickermonthnewpatient1.Value.ToString("MM/dd/yyyy");
                string date2 = dateTimePickermonthnewpatient2.Value.ToString("MM/dd/yyyy");
                cmbDoctor.Items.Add("All Doctor");
                cmbDoctor.ValueMember = "0";
                cmbDoctor.DisplayMember = "All Doctor";
                System.Data.DataTable doctor_rs = this.cntrl.doctor_rs();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        cmbDoctor.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        cmbDoctor.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        cmbDoctor.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
                cmbDoctor.SelectedIndex = 0;
                chartLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void chartLoad()
        {
            try
            {
                dataGridmonthlypatient.Visible = false;
                chartmonthnewpatient.Visible = true;
                if (dataGridmonthlypatient.Visible == false && chartmonthnewpatient.Visible == true)
                {
                    flag = 1;
                }
                foreach (var series in chartmonthnewpatient.Series)
                {
                    series.Points.Clear();
                }
                label4.Visible = true;
                string doctor = cmbDoctor.Text;
                string date1 = dateTimePickermonthnewpatient1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermonthnewpatient2.Value.ToString("yyyy-MM-dd");
                Grvmonthnewpatient.DataSource = this.cntrl.MonthlyNewPatient(date1, date2, doctor);
                Grvmonthnewpatient.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvmonthnewpatient.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvmonthnewpatient.EnableHeadersVisualStyles = false;
                Grvmonthnewpatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvmonthnewpatient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                if (Grvmonthnewpatient.Rows.Count == 1)
                {
                    int x = (panel4.Size.Width - lblNoRecord.Size.Width) / 2;
                    lblNoRecord.Location = new Point(x, lblNoRecord.Location.Y);
                    lblNoRecord.Show();
                }
                else
                {
                    lblNoRecord.Hide();
                }
                foreach (DataGridViewColumn column in Grvmonthnewpatient.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Gridload()
        {
            try
            {
                cmbDoctor.Visible = true;
                lblNoRecord.Hide();
                dataGridmonthlypatient.Rows.Clear();
                dataGridmonthlypatient.Visible = true;
                chartmonthnewpatient.Visible = false;
                if (dataGridmonthlypatient.Visible == true && chartmonthnewpatient.Visible == false)
                {
                    flag = 0;
                }
                dataGridmonthlypatient.EnableHeadersVisualStyles = false;
                dataGridmonthlypatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridmonthlypatient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                string date1 = dateTimePickermonthnewpatient1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermonthnewpatient2.Value.ToString("yyyy-MM-dd");
                string doctor = cmbDoctor.Text;
                chartmonthnewpatient.Hide();
                System.Data.DataTable griddailytrreatmenttable;
                if (doctor != "All Doctor")
                {
                    griddailytrreatmenttable = this.cntrl.grdDailytrtmentTable(doctor, date1, date2);
                }
                else
                {
                    griddailytrreatmenttable = this.cntrl.grdDailyTtrtmn1TB(date1, date2);
                }
                btnchart.Visible = true;
                if (griddailytrreatmenttable.Rows.Count > 0)
                {
                    int k = 1;
                    for (int z = 0; z < griddailytrreatmenttable.Rows.Count; z++)
                    {
                        string sl_no = k.ToString();
                        string date = griddailytrreatmenttable.Rows[z]["date"].ToString();
                        string patient_id = griddailytrreatmenttable.Rows[z]["pt_id"].ToString();
                        string Patient_Name = griddailytrreatmenttable.Rows[z]["pt_name"].ToString();
                        string mobile = griddailytrreatmenttable.Rows[z]["primary_mobile_number"].ToString();
                        string email = griddailytrreatmenttable.Rows[z]["email_address"].ToString();
                        string doctor_name = griddailytrreatmenttable.Rows[z]["doctorname"].ToString();
                        string nationality = griddailytrreatmenttable.Rows[z]["nationality"].ToString();
                        string passport = griddailytrreatmenttable.Rows[z]["passport_no"].ToString();
                        dataGridmonthlypatient.Rows.Add(sl_no, patient_id, Patient_Name, date, mobile, email, doctor_name,nationality,passport);
                        k = k + 1;
                    }
                }
                else
                {
                    int x = (panel4.Size.Width - lblNoRecord.Size.Width) / 2;
                    lblNoRecord.Location = new Point(x, lblNoRecord.Location.Y);
                    lblNoRecord.Show();
                }

                label2.Visible = true;
                foreach (var series in chartmonthnewpatient.Series)
                {
                    series.Points.Clear();
                }
                Grvmonthnewpatient.DataSource = this.cntrl.MonthlyNewPatient(date1, date2, doctor);
                Grvmonthnewpatient.EnableHeadersVisualStyles = false;
                Grvmonthnewpatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                this.Grvmonthnewpatient.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvmonthnewpatient.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                label2.Visible = true;
                foreach (var series in chartmonthnewpatient.Series)
                {
                    series.Points.Clear();
                }
                foreach (DataGridViewColumn column in Grvmonthnewpatient.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grvmonthnewpatient_DataSourceChanged(object sender, EventArgs e)
        {
            Grvmonthnewpatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            int total = 0;
            for (int s = 0; s < Grvmonthnewpatient.Rows.Count - 1; s++)
            {
                int count = int.Parse(Grvmonthnewpatient.Rows[s].Cells[1].Value.ToString());
                total = total + count;
                label4.Text = total.ToString();
            }
            if (total == 0)
            {
                label4.Text = 0.ToString();
            }
            for (int i = 0; i < Grvmonthnewpatient.Rows.Count - 1; i++)
            {
                string seriesArray = Grvmonthnewpatient.Rows[i].Cells[1].Value.ToString();
                string points = Grvmonthnewpatient.Rows[i].Cells[0].Value.ToString();
                this.chartmonthnewpatient.Palette = ChartColorPalette.BrightPastel;
                chartmonthnewpatient.Series["Patients"]["PixelPointWidth"] = "55";
                string pointss = points + seriesArray;
                chartmonthnewpatient.Series["Patients"].Points.AddXY(points, seriesArray);
            }
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridmonthlypatient.Rows.Clear();
                foreach (var series in chartmonthnewpatient.Series)
                {
                    series.Points.Clear();
                }
                label4.Visible = true;
                string doctor = cmbDoctor.Text;
                if (doctor == "" || doctor == null)
                {
                    doctor = "All Doctor";
                }
                string date1 = dateTimePickermonthnewpatient1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermonthnewpatient2.Value.ToString("yyyy-MM-dd");
                Grvmonthnewpatient.DataSource = this.cntrl.MonthlyNewPatient(date1, date2, doctor);
                Grvmonthnewpatient.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvmonthnewpatient.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvmonthnewpatient.EnableHeadersVisualStyles = false;
                Grvmonthnewpatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                if (flag == 0)
                {
                    Gridload();
                }
                if (flag == 1)
                {
                    chartLoad();
                }
                foreach (DataGridViewColumn column in Grvmonthnewpatient.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnchart_Click(object sender, EventArgs e)
        {
            chartLoad();
        }

        private void btngrid_Click(object sender, EventArgs e)
        {
            Gridload();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dataGridmonthlypatient.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "MonthlyNewPatientsReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dataGridmonthlypatient.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "MONTHLY NEW PATIENTS";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickermonthnewpatient1.Value.ToString();
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickermonthnewpatient2.Value.ToString();
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < dataGridmonthlypatient.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dataGridmonthlypatient.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dataGridmonthlypatient.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dataGridmonthlypatient.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dataGridmonthlypatient.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch { }
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (flag == 1)
                {
                    Gridload();
                }
                if (dataGridmonthlypatient.Rows.Count > 0)
                {
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
                    string strclinicname = ""; string clinicn = "";
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
                            logo_name= dtp.Rows[0]["path"].ToString();
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\MonthlyNewPatientReport.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> MONTHLY NEW PATIENT  </font></center></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <b>From  : </b> " + dateTimePickermonthnewpatient1.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <b>To : </b> " + dateTimePickermonthnewpatient2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>Printed Date:</b>" + " " + DateTime.Now.ToString("dd/MM/yyyy") + "" + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (dataGridmonthlypatient.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></td>");

                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3><b> Patient Id</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='25%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3><b>Patient Name</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='23%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>&nbsp;<b> Date</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>&nbsp;<b> Mobile</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='13%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>&nbsp;<b> Email</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='19%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3><b> Doctor</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='19%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3><b> Nationality</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>&nbsp;<b>Passport</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        while (c < dataGridmonthlypatient.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[0].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[1].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[2].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[3].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[4].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[5].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[6].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[7].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dataGridmonthlypatient.Rows[c].Cells[8].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            c++;
                        }
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right colspan=7><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\MonthlyNewPatientReport.html");
                }
                else
                {
                    MessageBox.Show("Record Not Found,Please change the date and try again!..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridmonthlypatient.Rows.Clear();
                foreach (var series in chartmonthnewpatient.Series)
                {
                    series.Points.Clear();
                }
                label4.Visible = true;
                string doctor = cmbDoctor.Text;
                string date1 = dateTimePickermonthnewpatient1.Value.ToString("yyyy-MM-dd");
                string date2 = dateTimePickermonthnewpatient2.Value.ToString("yyyy-MM-dd");
                Grvmonthnewpatient.DataSource = this.cntrl.DailyNewPatient(date1, date2, doctor);
                Grvmonthnewpatient.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvmonthnewpatient.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Grvmonthnewpatient.EnableHeadersVisualStyles = false;
                Grvmonthnewpatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                if (flag == 0)
                {
                    Gridload();
                }
                if (flag == 1)
                {
                    chartLoad();
                }
                foreach (DataGridViewColumn column in Grvmonthnewpatient.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDoctor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}