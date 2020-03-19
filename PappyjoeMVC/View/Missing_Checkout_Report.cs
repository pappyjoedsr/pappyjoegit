using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Missing_Checkout_Report : Form
    {
        Missing_Checkout_Report_controller cntrl = new Missing_Checkout_Report_controller();
        public string drctid = "";
        public string Selected_drid = "";
        public Missing_Checkout_Report()
        {
            InitializeComponent();
        }

        private void Missing_Checkout_Report_Load(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "0";
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
                dgvMissingCheckout.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvMissingCheckout.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvMissingCheckout.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dgvMissingCheckout.EnableHeadersVisualStyles = false;
                dgvMissingCheckout.Location = new System.Drawing.Point(5, 5);
                dgvMissingCheckout.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn cl in dgvMissingCheckout.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCondition.Text == "Checked Out")
                {
                    DataTable dt1 = this.cntrl.btn_shwClick(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"), cmbCondition.Text);
                    dgvMissingCheckout.AutoGenerateColumns = false;
                    dgvMissingCheckout.DataSource = dt1;
                    if (dt1.Rows.Count > 0)
                    {
                        int count = dt1.Rows.Count;
                        label2.Text = count.ToString();
                        Lab_Msg.Hide();
                    }
                    else
                    {
                        label2.Text = "0";
                        int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Show();
                    }
                }
                else
                {
                    DataTable dt1 = this.cntrl.showMissing(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"));                  dgvMissingCheckout.AutoGenerateColumns = false;
                    dgvMissingCheckout.DataSource = dt1;
                    if (dt1.Rows.Count > 0)
                    {
                        int count = dt1.Rows.Count;
                        label2.Text = count.ToString();
                        Lab_Msg.Hide();
                    }
                    else
                    {
                        label2.Text = "0";
                        int x = (panel3.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Show();
                    }
                }
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
                if (dgvMissingCheckout.Rows.Count > 0)
                {
                    string fromdate = dateTimePickerdailyappointcount1.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerdailyappointcount1.Value.Month);
                    string fryear = dateTimePickerdailyappointcount1.Value.Year.ToString();
                    string todate = dateTimePickerdailyappointcount2.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerdailyappointcount2.Value.Month);
                    string toyear = dateTimePickerdailyappointcount2.Value.Year.ToString();
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
                    string clinicn = "", strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "",logo_name="";
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\MissingCheckoutReport.html");
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
                    if (cmbCondition.Text == "Checked Out")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PATIENT CHECK OUT REPORT" + "  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    else
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PATIENT CHECK OUT REPORT " + "  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b> From:</b>" + dateTimePickerdailyappointcount1.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + "<b> To:</b>" + dateTimePickerdailyappointcount1.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>Printed Date:</b> " + DateTime.Now.ToString("dd/MM/yyyy") + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    int k = 1;
                    if (dgvMissingCheckout.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='55' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>Slno.</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='137'style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Patient Id</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='150'style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Patient Name</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='118'style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Booked Date</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='150'style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Appointment Date</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='140'style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Duration</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='140'style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Booked By</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        while (c < dgvMissingCheckout.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + k + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvMissingCheckout.Rows[c].Cells["patient_id"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgvMissingCheckout.Rows[c].Cells["pt_name"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + dgvMissingCheckout.Rows[c].Cells["book_datetime"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + dgvMissingCheckout.Rows[c].Cells["start_datetime"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + dgvMissingCheckout.Rows[c].Cells["duration"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + dgvMissingCheckout.Rows[c].Cells["booked_by"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            k = k + 1;
                            c++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("    <td align='left' colspan=6 height='20'><FONT COLOR=black FACE='Segoe UI' SIZE=3></font></th>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;</font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\MissingCheckoutReport.html");
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

        private void btn_excel_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dgvMissingCheckout.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Check out Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = dgvMissingCheckout.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (cmbCondition.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "CHECKED OUT REPORT";
                        }
                        else if (cmbCondition.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "MISSING REPORT REPORT";
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
                        for (int i = 1; i < dgvMissingCheckout.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgvMissingCheckout.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgvMissingCheckout.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgvMissingCheckout.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgvMissingCheckout.Rows[i].Cells[j].Value.ToString();
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

        private void comboBoxdoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxdoctor.SelectedIndex == -1)
                {
                }
                else
                {
                    label2.Text = "";
                    drctid = comboBoxdoctor.SelectedItem.ToString();
                    string dt = this.cntrl.Get_DoctorId(drctid);
                    if (dt!="")
                    {
                        Selected_drid = dt.ToString();
                    }
                    if (cmbCondition.Text == "Checked Out")
                    {
                        if (comboBoxdoctor.SelectedIndex == 0)
                        {
                            DataTable dt1 = this.cntrl.DocComb(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"));
                            dgvMissingCheckout.AutoGenerateColumns = false;
                            dgvMissingCheckout.DataSource = dt1;
                            int count = dt1.Rows.Count;
                            label2.Text = count.ToString();
                        }
                        else if (comboBoxdoctor.SelectedIndex > 0)
                        {
                            DataTable dt1 = this.cntrl.DocComb1(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"), Selected_drid);
                            dgvMissingCheckout.AutoGenerateColumns = false;
                            dgvMissingCheckout.DataSource = dt1;
                            int count = dt1.Rows.Count;
                            label2.Text = count.ToString();
                        }
                    }
                    else
                    {
                        if (comboBoxdoctor.SelectedIndex == 0)
                        {
                            DataTable dt1 = this.cntrl.DocComb2(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"));
                            dgvMissingCheckout.AutoGenerateColumns = false;
                            dgvMissingCheckout.DataSource = dt1;
                            int count = dt1.Rows.Count;
                            label2.Text = count.ToString();
                        }
                        else if (comboBoxdoctor.SelectedIndex > 0)
                        {
                            DataTable dt1 = this.cntrl.DocComb3(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"), Selected_drid);
                            dgvMissingCheckout.AutoGenerateColumns = false;
                            dgvMissingCheckout.DataSource = dt1;
                            int count = dt1.Rows.Count;
                            label2.Text = count.ToString();
                        }
                    }
                    if (dgvMissingCheckout.Rows.Count < 1)
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