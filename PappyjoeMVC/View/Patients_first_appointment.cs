using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Patients_First_Appointment : Form
    {
        Patients_First_Appointment_controller cntrl=new Patients_First_Appointment_controller();
        public string names, ptids;
        public string doctor_id = "";
        public Patients_First_Appointment()
        {
            InitializeComponent();
        }

        private void Patients_first_appointment_Load(object sender, EventArgs e)
        {
            try
            {
                Grvpatientfirstappoint.Rows.Clear();
                Grvpatientfirstappoint.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvpatientfirstappoint.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvpatientfirstappoint.EnableHeadersVisualStyles = false;
                cmbDoctor.Items.Add("All Doctor");
                cmbDoctor.ValueMember = "0";
                cmbDoctor.DisplayMember = "All Doctor";
                DataTable doctor_rs = this.cntrl.doctor_rs();
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
                label_empty.Hide();
                this.Grvpatientfirstappoint.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                if (label2.Text != "")
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                }
                dateTimePickerfirstappoint1.MaxDate = DateTime.Now;
                dateTimePickerfirstappoint2.MaxDate = DateTime.Now;
                DateTime now = DateTime.Now;
                DateTime date = new DateTime(now.Year, now.Month, 1);
                dateTimePickerfirstappoint1.Value = date;
                string d1 = dateTimePickerfirstappoint1.Value.ToString("yyyy-MM-dd");
                string d2 = dateTimePickerfirstappoint2.Value.ToString("yyyy-MM-dd");
                Grvpatientfirstappoint.DataSource = this.cntrl.FirstAppointment(doctor_id, d1, d2);
                this.Grvpatientfirstappoint.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvpatientfirstappoint.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvpatientfirstappoint.Rows.Count == 0)
                {
                    int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                    label_empty.Location = new Point(x, label_empty.Location.Y);
                    label_empty.Show();
                }
                else
                {
                    label_empty.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grvpatientfirstappoint_DataSourceChanged(object sender, EventArgs e)
        {
            int total = Grvpatientfirstappoint.Rows.Count;
            label2.Text = total.ToString();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grvpatientfirstappoint.Rows.Count > 0)
                {
                    string frdate = dateTimePickerfirstappoint1.Value.Day.ToString();
                    string frmonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerfirstappoint1.Value.Month);
                    string fryear = dateTimePickerfirstappoint1.Value.Year.ToString();
                    string todate = dateTimePickerfirstappoint2.Value.Day.ToString();
                    string tomonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateTimePickerfirstappoint2.Value.Month);
                    string toyear = dateTimePickerfirstappoint2.Value.Year.ToString();
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
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
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\PatientFirstAppointment.html");
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
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PATIENT FIRST APPOINMENT </font></center></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=3><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From :</b> " + dateTimePickerfirstappoint1.Value.ToString("dd-MM-yyyy") + " </font></td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=3><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To : </b>" + dateTimePickerfirstappoint2.Value.ToString("dd-MM-yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=3><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + DateTime.Now.ToString("dd-MM-yyyy") + "" + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (Grvpatientfirstappoint.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=2 >&nbsp;<b>Slno.</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='60%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=2 >&nbsp;<b>Patient Name</b></font></th>");
                        sWrite.WriteLine("    <td align='left' width='30%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=2> &nbsp;<b>Booking Date</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        for (int j = 0; j < Grvpatientfirstappoint.Rows.Count; j++)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + (j + 1) + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + Grvpatientfirstappoint.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Convert.ToDateTime(Grvpatientfirstappoint.Rows[j].Cells[1].Value.ToString()).ToString("dd-MM-yyyy") + "</font></th>");
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\PatientFirstAppointment.html");
                    }
                }
                else
                {
                    MessageBox.Show("No Record found, Please change the date and try again!..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label_empty_VisibleChanged(object sender, EventArgs e)
        {
            if (label_empty.Visible == true)
            {
                label2.Text = "0";
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                var d1 = dateTimePickerfirstappoint1.Value.ToString("yyyy-MM-dd");
                var d2 = dateTimePickerfirstappoint2.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
                {
                    MessageBox.Show("From date should be less than To date", "From Date is grater ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dateTimePickerfirstappoint1.Value = DateTime.Today;
                    return;
                }
                label2.Visible = true;
                Grvpatientfirstappoint.DataSource = this.cntrl.FirstAppointment(doctor_id, d1, d2);
                this.Grvpatientfirstappoint.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.Grvpatientfirstappoint.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (Grvpatientfirstappoint.Rows.Count == 0)
                {
                    int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                    label_empty.Location = new Point(x, label_empty.Location.Y);
                    label_empty.Show();
                }
                else
                {
                    label_empty.Hide();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            string checkStr = "0"; string PathName = "";
            try
            {
                if (Grvpatientfirstappoint.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "PatientFirstAppointmentReport(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = Grvpatientfirstappoint.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "PATIENTS FIRST APPOINMENT";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerfirstappoint1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerfirstappoint2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < Grvpatientfirstappoint.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = Grvpatientfirstappoint.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= Grvpatientfirstappoint.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < Grvpatientfirstappoint.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = Grvpatientfirstappoint.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setcontroller(Patients_First_Appointment_controller controller)
        {
            cntrl = controller;
        }
    }
}