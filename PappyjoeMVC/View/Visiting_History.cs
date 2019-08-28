using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Visiting_History : Form
    {
        Visiting_History_controller cntrl=new Visiting_History_controller();
        public string drctid = "";
        public string Selected_drid = "";
        public Visiting_History()
        {
            InitializeComponent();
        }

        private void Visiting_History_Load(object sender, EventArgs e)
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
                dgvVisitingHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvVisitingHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvVisitingHistory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dgvVisitingHistory.EnableHeadersVisualStyles = false;
                dgvVisitingHistory.Location = new System.Drawing.Point(5, 5);
                dgvVisitingHistory.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvVisitingHistory.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn cl in dgvVisitingHistory.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                Lab_Msg.Hide(); label2.Text = "";
                DataTable dt1 = this.cntrl.search(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"));
                dgvVisitingHistory.AutoGenerateColumns = false;
                dgvVisitingHistory.DataSource = dt1;
                if (dt1.Rows.Count > 0)
                {
                    int count = dt1.Rows.Count;
                    label2.Text = count.ToString();
                    Lab_Msg.Hide();
                }
                else
                {
                    dgvVisitingHistory.DataSource = null;
                    label2.Text = "0";
                    Lab_Msg.Show();
                }
                var dateFrom = dateTimePickerdailyappointcount1.Value.ToShortDateString();
                var dateTo = dateTimePickerdailyappointcount2.Value.ToShortDateString();
                if (Convert.ToDateTime(dateFrom).Date > Convert.ToDateTime(dateTo).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerdailyappointcount1.Value = DateTime.Today;
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
                    label2.Text = ""; Lab_Msg.Hide();
                    drctid = comboBoxdoctor.SelectedItem.ToString();
                    string dt = this.cntrl.Get_DoctorId(drctid);
                    if (dt!="")
                    {
                        Selected_drid = dt.ToString();
                    }
                    if (comboBoxdoctor.SelectedIndex == 0)
                    {
                        DataTable dt1 = this.cntrl.vishistCombo(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"));
                        dgvVisitingHistory.AutoGenerateColumns = false;
                        if (dt1.Rows.Count > 0)
                        {
                            dgvVisitingHistory.DataSource = dt1;
                            int count = dt1.Rows.Count;
                            label2.Text = count.ToString();
                            Lab_Msg.Hide();
                        }
                        else
                        {
                            dgvVisitingHistory.DataSource = null;
                            Lab_Msg.Show();
                            label2.Text = "0";
                        }
                    }
                    else if (comboBoxdoctor.SelectedIndex > 0)
                    {
                        DataTable dt1 = this.cntrl.vishistCombo1(dateTimePickerdailyappointcount1.Value.ToString("yyyy-MM-dd"), dateTimePickerdailyappointcount2.Value.ToString("yyyy-MM-dd"), Selected_drid);
                        dgvVisitingHistory.AutoGenerateColumns = false;
                        if (dt1.Rows.Count > 0)
                        {
                            dgvVisitingHistory.DataSource = dt1;
                            int count = dt1.Rows.Count;
                            label2.Text = count.ToString();
                            Lab_Msg.Hide();
                        }
                        else
                        {
                            dgvVisitingHistory.DataSource = null;
                            Lab_Msg.Show();
                            label2.Text = "0";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVisitingHistory.Rows.Count > 0)
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\VisitingHistory.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table { border-collapse: collapse;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<div>");
                    sWrite.WriteLine("<table align=center width=900> ");
                    sWrite.WriteLine("<col >");
                    if (comboBoxdoctor.SelectedIndex > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=10 align=center><FONT COLOR=black FACE='Segoe UI' SIZE=4 > <b> VISITING HISTORY OF Dr." + comboBoxdoctor.Text + "" + "  </b> </font></center></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    else
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=10 align=center><FONT COLOR=black FACE='Segoe UI' SIZE=4 > <b> VISITING HISTORY OF ALL DOCTOR " + "  </b> </font></center></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=10><left><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> " + strclinicname + "</b> </font></left></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strStreet + "</b> </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b> " + strphone + "</b> </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=10 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + " <b>From : </b>" + " " + dateTimePickerdailyappointcount1.Value.ToString("dd/MM/yyy") + " </font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=10 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + " <b>To : </b>" + "   " + dateTimePickerdailyappointcount2.Value.ToString("dd/MM/yyy") + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan=10><FONT COLOR=black FACE='Segoe UI' SIZE=2>   <b>Printed Date: </b> " + DateTime.Now.ToString("dd/MM/yyyy") + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    if (dgvVisitingHistory.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='center' width='52' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 > <b>Sl.</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='69' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>Patient Id</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='184' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Patient Name</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='76' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Booked On </b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='128' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Appointment Date</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='124' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Booked By</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='59' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Duration (Mins)</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='65' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Schedule</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='48' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Waiting</b></font></th>");
                        sWrite.WriteLine("    <td align='center' width='51' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Checkout</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        while (c < dgvVisitingHistory.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + k + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvVisitingHistory.Rows[c].Cells["patient_id"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvVisitingHistory.Rows[c].Cells["pt_name"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvVisitingHistory.Rows[c].Cells["book_datetime"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgvVisitingHistory.Rows[c].Cells["start_datetime"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dgvVisitingHistory.Rows[c].Cells["booked_by"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dgvVisitingHistory.Rows[c].Cells["duration"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dgvVisitingHistory.Rows[c].Cells["schedule"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dgvVisitingHistory.Rows[c].Cells["waiting"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + dgvVisitingHistory.Rows[c].Cells["checkout"].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            k = k + 1;
                            c++;
                        }
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right colspan=11><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</div>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\VisitingHistory.html");
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

        private void btnExporttoExcel_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (dgvVisitingHistory.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Visiting History Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20; ;
                        int count = dgvVisitingHistory.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (comboBoxdoctor.SelectedIndex == 0)
                        {
                            ExcelApp.Cells[1, 1] = "VISITING HISTORY REPORT OF All DOCTOR";
                        }
                        else if (comboBoxdoctor.SelectedIndex > 0)
                        {
                            ExcelApp.Cells[1, 1] = "VISITING HISTORY REPORT OF Dr." + drctid + "";
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
                        for (int i = 1; i < dgvVisitingHistory.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dgvVisitingHistory.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= dgvVisitingHistory.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < dgvVisitingHistory.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = dgvVisitingHistory.Rows[i].Cells[j].Value.ToString();
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
                    MessageBox.Show("No records found, Please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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