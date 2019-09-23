using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System.Drawing.Printing;


namespace PappyjoeMVC.View
{
    public partial class Printout : Form
    {
        Printout_controller cntrl=new Printout_controller();
        string orientation="", color="";
        string includeheader="",header, lefttext, righttext, includelogo, logotype;
        string patientdetails="", medhistory="", patientno, address, phone, email, bloodgroup, genderdob, Doctor;
        int topmargin1 = 0;
        PaperSize paperSize;
        public bool prescription_flag = false;
        public bool invoice_flag = false;
        public bool receipr_flag = false;
        Connection db = new Connection();
        public Printout()
        {
            InitializeComponent();
        }
        private void button_prescription_preview_Click(object sender, EventArgs e)
        {
            try
            {
                string top = combo_topmargin.Text;
                int topmargin = int.Parse(top.Substring(0, top.IndexOf("m")));
                topmargin1 = topmargin;
                string bottom = combo_bottommargin.Text;
                int bottommargin = int.Parse(bottom.Substring(0, bottom.IndexOf("m")));
                string left = combo_leftmargin.Text;
                int leftmargin = int.Parse(left.Substring(0, left.IndexOf("m")));
                string right = combo_rightmargin.Text;
                int rightmargin = int.Parse(right.Substring(0, right.IndexOf("m")));
                printDocument1.DefaultPageSettings.Margins.Top = topmargin;
                printDocument1.DefaultPageSettings.Margins.Left = leftmargin + 20;
                printDocument1.DefaultPageSettings.Margins.Bottom = bottommargin;
                printDocument1.DefaultPageSettings.Margins.Right = rightmargin;
                if (combo_paper_size.SelectedIndex != -1)
                {
                    switch (combo_paper_size.SelectedItem.ToString())
                    {
                        //constructor "name", inch, inch
                        case "A3":
                            paperSize = new PaperSize("A3", 1170, 1650);
                            break;
                        case "A4":
                            paperSize = new PaperSize("A4", 830, 1170);
                            break;
                        case "A5":
                            paperSize = new PaperSize("A5", 580, 830);
                            break;
                        case "B4":
                            paperSize = new PaperSize("B4", 980, 1390);
                            break;
                        case "B5":
                            paperSize = new PaperSize("B5", 690, 980);
                            break;
                        case "LEGAL":
                            paperSize = new PaperSize("LEGAL", 215, 355);
                            break;
                        case "TABLOID":
                            paperSize = new PaperSize("TABLOID", 279, 431);
                            break;
                        case "FOLIO":
                            paperSize = new PaperSize("FOLIO", 210, 330);
                            break;
                        case "LETTER":
                            paperSize = new PaperSize("LETTER", 215, 279);
                            break;
                        case "EXECUTIVE":
                            paperSize = new PaperSize("EXECUTIVE", 184, 266);
                            break;
                        case "STATEMENT":
                            paperSize = new PaperSize("STATEMENT", 139, 215);
                            break;
                        default:
                            paperSize = new PaperSize("A4", 830, 1170);
                            break;
                    }
                    if (radio_landscape.Checked == true)
                    {
                        printDocument1.DefaultPageSettings.Landscape = true;
                    }
                    else
                    {
                        printDocument1.DefaultPageSettings.Landscape = false;
                    }
                    paperSize.RawKind = (int)PaperKind.Custom;
                    printDocument1.DefaultPageSettings.PaperSize = paperSize;
                    printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                    printDocument1.OriginAtMargins = true;
                }
                printPreviewControl6.Document = printDocument1;
                printPreviewControl6.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tabControl2_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font TabFont;
            Brush BackBrush = new SolidBrush(Color.Transparent); //Set background color
            Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);//Set foreground color
            if (e.Index == this.tabControl2.SelectedIndex)
            {
                TabFont = new Font(e.Font, FontStyle.Italic);
            }
            else
            {
                TabFont = e.Font;
            }
            string TabName = this.tabControl2.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
            //Dispose objects
            sf.Dispose();
            if (e.Index == this.tabControl2.SelectedIndex)
            {
                TabFont.Dispose();
                BackBrush.Dispose();
            }
            else
            {
                BackBrush.Dispose();
                ForeBrush.Dispose();
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush BackBrush = new SolidBrush(Color.Transparent);
            Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);
            TabPage page = tabControl1.TabPages[e.Index];
            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int xx = 30;
                int yy = 185;
                   if (radio_headeryes.Checked == true)
                {
                    if (radio_logo_yes.Checked == true)
                    {
                        string pathimage = System.IO.Directory.GetCurrentDirectory();
                        System.Data.DataTable dtp = this.cntrl.Get_practice_details();
                        System.Drawing.Image logo = null;
                        try
                        {
                            if (dtp.Rows.Count > 0)
                            {
                                string path = dtp.Rows[0]["path"].ToString();
                                string curFile = this.cntrl.getserver() + "\\Pappyjoe_utilities\\Logo\\" + path;
                                if (System.IO.File.Exists(curFile))
                                {
                                    logo = System.Drawing.Image.FromFile(curFile);
                                    e.Graphics.DrawImage(logo, 30, 50, 100, 100);
                                    xx = 150;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 16.0f))
                    {
                        e.Graphics.DrawString(text_header.Text, printFont, Brushes.Gray, xx, 70);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 12.0f))
                    {
                        e.Graphics.DrawString(text_left_text.Text, printFont, Brushes.Gray, xx, 100);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 10.0f))
                    {
                        e.Graphics.DrawString(text_right_text.Text, printFont, Brushes.Gray, xx, 120);
                    }
                }//header
                if (combo_paper_size.Text == "A5")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(500, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Mr. Arun C Mathew", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient.Checked == true)
                            {
                                if (check_gender.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;

                        if (check_show_patient.Checked == true)
                        {
                            if (check_patient_number.Checked == true)
                            {
                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient.Checked == true)
                        {
                            if (check_address.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 300, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient.Checked == true)
                        {
                            if (check_phone.Checked == true)
                            {
                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;

                        if (check_show_patient.Checked == true)
                        {
                            if (check_medicalhistory.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(500, yy));
                        yy = yy + 30;
                        if (chkdoctor.Checked == true)
                        {
                            e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                            {
                                e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                            }
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Date: ", printFont, Brushes.Gray, 400, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            DateTime tdate = Convert.ToDateTime(DateTime.Today);
                            e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 430, yy);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("P", printFont1, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 12.0f))
                            {
                                e.Graphics.DrawString("x", printFont2, Brushes.Gray, 26, yy + 5);
                            }
                            e.Graphics.DrawString("Prescriptions", printFont1, Brushes.Gray, 51, yy);
                        }
                        yy = yy + 30;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 480, 25);

                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Drug Name", printFont2, Brushes.Black, 51, yy - 17);
                            e.Graphics.DrawString("Strength", printFont2, Brushes.Black, 200, yy - 17);
                            e.Graphics.DrawString("Frequency", printFont2, Brushes.Black, 300, yy - 17);
                            e.Graphics.DrawString("Instructions", printFont2, Brushes.Black, 400, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("1.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Capsule  Metoprolol", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("100 mg ", printFont, Brushes.Black, 200, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 275, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 305, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 335, yy);
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 260, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 290, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 325, yy - 10);
                            e.Graphics.DrawString("5 day(s)", printFont2, Brushes.Black, 400, yy - 10);
                            e.Graphics.DrawString("Before Food", printFont2, Brushes.Black, 400, yy);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("2.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Pill  Omeprazole", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("25 mg ", printFont, Brushes.Black, 200, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 275, yy);
                        e.Graphics.DrawString("", printFont, Brushes.Black, 305, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 335, yy);
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 260, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 290, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 325, yy - 10);
                            e.Graphics.DrawString("4 day(s)", printFont2, Brushes.Black, 400, yy - 10);
                            e.Graphics.DrawString("Before Food", printFont2, Brushes.Black, 400, yy);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("3.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Powder  Simvastatin", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("80 mg ", printFont, Brushes.Black, 200, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 275, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 305, yy);
                        e.Graphics.DrawString("", printFont, Brushes.Black, 335, yy);
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 260, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 290, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 325, yy - 10);
                            e.Graphics.DrawString("1 day(s)", printFont2, Brushes.Black, 400, yy - 10);
                            e.Graphics.DrawString("After Food", printFont2, Brushes.Black, 400, yy);
                        }
                        yy = yy + 20;
                        e.Graphics.DrawString("Review date on 23/10/2015", printFont, Brushes.Black, 45, 745 - topmargin1);
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 760 - topmargin1), new System.Drawing.Point(500, 760 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth.Text, printFont, Brushes.Gray, 280 - (txtDataWidth1 / 2), 765 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign.Text, printFont, Brushes.Gray, 280 - (txtDataWidth2 / 2), 785 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign.Text, printFont, Brushes.Gray, 280 - (txtDataWidth3 / 2), 800 - topmargin1);
                    }
                }
                else if (combo_paper_size.Text == "A4")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(800, 175));

                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {

                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Mr. Arun C Mathew", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient.Checked == true)
                            {
                                if (check_gender.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient.Checked == true)
                        {
                            if (check_patient_number.Checked == true)
                            {

                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                        }

                        if (check_show_patient.Checked == true)
                        {
                            if (check_address.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 600, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient.Checked == true)
                        {
                            if (check_phone.Checked == true)
                            {

                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;

                        if (check_show_patient.Checked == true)
                        {
                            if (check_medicalhistory.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(800, yy));
                        yy = yy + 30;

                        e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Date: ", printFont, Brushes.Gray, 700, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            DateTime tdate = Convert.ToDateTime(DateTime.Today);
                            e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 730, yy);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("P", printFont1, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 12.0f))
                            {
                                e.Graphics.DrawString("x", printFont2, Brushes.Gray, 26, yy + 5);
                            }
                            e.Graphics.DrawString("Prescriptions", printFont1, Brushes.Gray, 51, yy);
                        }
                        yy = yy + 30;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 780, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Drug Name", printFont2, Brushes.Black, 51, yy - 17);
                            e.Graphics.DrawString("Strength", printFont2, Brushes.Black, 300, yy - 17);
                            e.Graphics.DrawString("Frequency", printFont2, Brushes.Black, 420, yy - 17);
                            e.Graphics.DrawString("Instructions", printFont2, Brushes.Black, 600, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("1.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Capsule  Metoprolol", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("100 mg ", printFont, Brushes.Black, 300, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 460, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 490, yy);

                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                            e.Graphics.DrawString("5 day(s)", printFont2, Brushes.Black, 600, yy - 10);
                            e.Graphics.DrawString("Before Food", printFont2, Brushes.Black, 600, yy);
                        }

                        yy = yy + 30;
                        e.Graphics.DrawString("2.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Pill  Omeprazole", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("25 mg ", printFont, Brushes.Black, 300, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("", printFont, Brushes.Black, 460, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 490, yy);

                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                            e.Graphics.DrawString("4 day(s)", printFont2, Brushes.Black, 600, yy - 10);
                            e.Graphics.DrawString("Before Food", printFont2, Brushes.Black, 600, yy);
                        }

                        yy = yy + 30;
                        e.Graphics.DrawString("3.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Powder  Simvastatin", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("80 mg ", printFont, Brushes.Black, 300, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 460, yy);
                        e.Graphics.DrawString("", printFont, Brushes.Black, 490, yy);

                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                            e.Graphics.DrawString("1 day(s)", printFont2, Brushes.Black, 600, yy - 10);
                            e.Graphics.DrawString("After Food", printFont2, Brushes.Black, 600, yy);
                        }

                        yy = yy + 20;
                        e.Graphics.DrawString("Review date on 23/10/2015", printFont, Brushes.Black, 45, 1045 - topmargin1);
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 1060 - topmargin1), new System.Drawing.Point(800, 1060 - topmargin1));

                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign.Text, printFt).Width;

                        e.Graphics.DrawString(rich_fullwidth.Text, printFont, Brushes.Gray, 400 - (txtDataWidth1 / 2), 1065 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign.Text, printFont, Brushes.Gray, 400 - (txtDataWidth2 / 2), 1085 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign.Text, printFont, Brushes.Gray, 400 - (txtDataWidth3 / 2), 1100 - topmargin1);
                    }

                }
                else if (combo_paper_size.Text == "A3")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(1150, 175));

                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {

                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Mr. Arun C Mathew", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient.Checked == true)
                            {
                                if (check_gender.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient.Checked == true)
                        {
                            if (check_patient_number.Checked == true)
                            {
                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                        }

                        if (check_show_patient.Checked == true)
                        {
                            if (check_address.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 600, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient.Checked == true)
                        {
                            if (check_phone.Checked == true)
                            {
                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient.Checked == true)
                        {
                            if (check_medicalhistory.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(1150, yy));
                        yy = yy + 30;

                        e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Date: ", printFont, Brushes.Gray, 1050, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            DateTime tdate = Convert.ToDateTime(DateTime.Today);
                            e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 1080, yy);
                        }

                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("P", printFont1, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 12.0f))
                            {
                                e.Graphics.DrawString("x", printFont2, Brushes.Gray, 26, yy + 5);
                            }
                            e.Graphics.DrawString("Prescriptions", printFont1, Brushes.Gray, 51, yy);
                        }
                        yy = yy + 30;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 1120, 25);

                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Drug Name", printFont2, Brushes.Black, 51, yy - 17);
                            e.Graphics.DrawString("Strength", printFont2, Brushes.Black, 300, yy - 17);
                            e.Graphics.DrawString("Frequency", printFont2, Brushes.Black, 420, yy - 17);
                            e.Graphics.DrawString("Instructions", printFont2, Brushes.Black, 600, yy - 17);
                        }

                        yy = yy + 30;
                        e.Graphics.DrawString("1.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Capsule  Metoprolol", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("100 mg ", printFont, Brushes.Black, 300, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 460, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 490, yy);

                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                            e.Graphics.DrawString("5 day(s)", printFont2, Brushes.Black, 600, yy - 10);
                            e.Graphics.DrawString("Before Food", printFont2, Brushes.Black, 600, yy);
                        }

                        yy = yy + 30;
                        e.Graphics.DrawString("2.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Pill  Omeprazole", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("25 mg ", printFont, Brushes.Black, 300, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("", printFont, Brushes.Black, 460, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 490, yy);

                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                            e.Graphics.DrawString("4 day(s)", printFont2, Brushes.Black, 600, yy - 10);
                            e.Graphics.DrawString("Before Food", printFont2, Brushes.Black, 600, yy);
                        }

                        yy = yy + 30;
                        e.Graphics.DrawString("3.", printFont, Brushes.Gray, 20, yy);
                        e.Graphics.DrawString("Powder  Simvastatin", printFont, Brushes.Black, 51, yy);
                        e.Graphics.DrawString("80 mg ", printFont, Brushes.Black, 300, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("1", printFont, Brushes.Black, 460, yy);
                        e.Graphics.DrawString("", printFont, Brushes.Black, 490, yy);

                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 6.0f))
                        {
                            e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                            e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                            e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                            e.Graphics.DrawString("1 day(s)", printFont2, Brushes.Black, 600, yy - 10);
                            e.Graphics.DrawString("After Food", printFont2, Brushes.Black, 600, yy);
                        }
                        yy = yy + 20;
                        e.Graphics.DrawString("Review date on 23/10/2015", printFont, Brushes.Black, 45, 1520 - topmargin1);
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 1540 - topmargin1), new System.Drawing.Point(1150, 1540 - topmargin1));

                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth.Text, printFont, Brushes.Gray, 550 - (txtDataWidth1 / 2), 1560 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign.Text, printFont, Brushes.Gray, 550 - (txtDataWidth2 / 2), 1580 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign.Text, printFont, Brushes.Gray, 550 - (txtDataWidth3 / 2), 1600 - topmargin1);
                    }
                }
            }
            catch
            {
            }
        }
     
        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.TabIndex==0)
            {
                prescription_flag = true;
                invoice_flag = false;
                receipr_flag = false;
            }
            else if (tabControl1.TabIndex == 2)
            {
                prescription_flag = false;
                invoice_flag = true;
                receipr_flag = false;
            }
            else if (tabControl1.TabIndex == 3)
            {
                prescription_flag = false;
                invoice_flag = false;
                receipr_flag = true;
            }
        }

        private void btn_saveinvoice_Click(object sender, EventArgs e)
        {
           try
            {
                orientation = "";
                color = "";
                if (radio_headeryes1.Checked == true)
                {
                    includeheader = "1";
                    header = text_header1.Text;
                    lefttext = text_left_text1.Text;
                    righttext = text_right_text1.Text;
                    if (radio_logo_yes1.Checked == true)
                    {
                        includelogo = "1";
                        logotype = "";
                    }
                    else
                    {
                        includelogo = "0";
                        logotype = "";
                    }
                }
                else
                {
                    includeheader = "0";
                    header = "";
                    lefttext = "";
                    righttext = "";
                    logotype = "";
                    includelogo = "0";
                }
                if (check_show_patient1.Checked == true)
                {
                    patientdetails = "0";
                    if (check_medicalhistory1.Checked == true)
                    {
                        medhistory = "0";
                    }
                    else
                    {
                        medhistory = "1";
                    }
                    if (check_patient_number1.Checked == true)
                    {
                        patientno = "0";
                    }
                    else
                    {
                        patientno = "1";
                    }
                    if (check_address1.Checked == true)
                    {
                        address = "0";  
                    }
                    else
                    {
                        address = "1";
                    }
                    if (check_phone1.Checked == true)
                    {
                        phone = "0";
                    }
                    else
                    {
                        phone = "1";
                    }
                    if (check_blood1.Checked == true)
                    {
                        bloodgroup = "0";
                    }
                    else
                    {
                        bloodgroup = "1";
                    }
                    if (chkdoctor.Checked == true)
                    {
                        Doctor = "0";
                    }
                    else
                    {
                        Doctor = "1";
                    }
                }
                else
                {
                    patientdetails = "1";
                    medhistory = "1";
                    patientno = "1";
                    address = "1";
                    phone = "1";
                    email = "1";
                    bloodgroup = "1";
                    Doctor = "1";
                }
                if (check_gender1.Checked == true)
                {
                    genderdob = "0";
                }
                else
                {
                    genderdob = "1";
                }
                string c = this.cntrl.get_invoiceprintCount();
                int count = Convert.ToInt32(c);
                if (count == 0)
                {
                    int insert = this.cntrl.save_invoice(combo_paper_size1.Text, orientation, color, combo_topmargin1.Text, combo_leftmargin1.Text, combo_bottommargin1.Text, combo_rightmargin1.Text, includeheader, header, lefttext, righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, combo_footer_topmargin1.Text, rich_fullwidth1.Text, rich_leftsign1.Text, rich_rightsign1.Text, Doctor);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int update = this.cntrl.update_invoicePrint(combo_paper_size1.Text, orientation, color, combo_topmargin1.Text, combo_leftmargin1.Text, combo_bottommargin1.Text, combo_rightmargin1.Text, includeheader, header, lefttext, righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, combo_footer_topmargin1.Text, rich_fullwidth1.Text, rich_leftsign1.Text, rich_rightsign1.Text, Doctor);
                    MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_invoicepreview_Click(object sender, EventArgs e)
        {
            try
            {
                string top = combo_topmargin1.Text;
                int topmargin = int.Parse(top.Substring(0, top.IndexOf("m")));
                string bottom = combo_bottommargin1.Text;
                int bottommargin = int.Parse(bottom.Substring(0, bottom.IndexOf("m")));
                string left = combo_leftmargin1.Text;
                int leftmargin = int.Parse(left.Substring(0, left.IndexOf("m")));
                string right = combo_rightmargin1.Text;
                int rightmargin = int.Parse(right.Substring(0, right.IndexOf("m")));
                printDocument_invoice.DefaultPageSettings.Margins.Top = topmargin;
                printDocument_invoice.DefaultPageSettings.Margins.Left = leftmargin;
                printDocument_invoice.DefaultPageSettings.Margins.Bottom = bottommargin;
                printDocument_invoice.DefaultPageSettings.Margins.Right = rightmargin;
                printDocument_invoice.OriginAtMargins = true;

                if (combo_paper_size1.SelectedIndex != -1)
                {
                    switch (combo_paper_size1.SelectedItem.ToString())
                    {
                        //constructor "name", inch, inch
                        case "A3":
                            paperSize = new PaperSize("A3", 1170, 1650);
                            break;
                        case "A4":
                            paperSize = new PaperSize("A4", 830, 1170);
                            break;
                        case "A5":
                            paperSize = new PaperSize("A5", 580, 830);
                            break;
                        case "B4":
                            paperSize = new PaperSize("B4", 980, 1390);
                            break;
                        case "B5":
                            paperSize = new PaperSize("B5", 690, 980);
                            break;
                        case "LEGAL":
                            paperSize = new PaperSize("LEGAL", 215, 355);
                            break;
                        case "TABLOID":
                            paperSize = new PaperSize("TABLOID", 279, 431);
                            break;
                        case "FOLIO":
                            paperSize = new PaperSize("FOLIO", 210, 330);
                            break;
                        case "LETTER":
                            paperSize = new PaperSize("LETTER", 215, 279);
                            break;
                        case "EXECUTIVE":
                            paperSize = new PaperSize("EXECUTIVE", 184, 266);
                            break;
                        case "STATEMENT":
                            paperSize = new PaperSize("STATEMENT", 139, 215);
                            break;
                        default:
                            paperSize = new PaperSize("A4", 830, 1170);
                            break;

                    }
                    paperSize.RawKind = (int)PaperKind.Custom;
                    printDocument_invoice.DefaultPageSettings.PaperSize = paperSize;
                    printDocument_invoice.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
                }
                printPreviewControl3.Document = printDocument_invoice;
                printPreviewControl3.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument_invoice_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int xx = 30;
                int yy = 185;

                if (radio_headeryes1.Checked == true)
                { 
                    if (radio_logo_yes1.Checked == true)
                    {
                        string pathimage = System.IO.Directory.GetCurrentDirectory();
                        System.Data.DataTable dtp = this.cntrl.Get_companydetails();
                        System.Drawing.Image logo = null;
                        try
                        {
                            if (dtp.Rows.Count > 0)
                            {
                                string path = dtp.Rows[0]["path"].ToString();
                                string curFile = this.cntrl.getserver() + "\\Pappyjoe_utilities\\Logo\\" + path;
                                if (System.IO.File.Exists(curFile))
                                {
                                    logo = System.Drawing.Image.FromFile(curFile);
                                    e.Graphics.DrawImage(logo, 30, 50, 100, 100);
                                    xx = 150;
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 16.0f))
                    {
                        e.Graphics.DrawString(text_header1.Text, printFont, Brushes.Gray, xx, 70);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 12.0f))
                    {
                        e.Graphics.DrawString(text_left_text1.Text, printFont, Brushes.Gray, xx, 100);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 10.0f))
                    {
                        e.Graphics.DrawString(text_right_text1.Text, printFont, Brushes.Gray, xx, 120);
                    }

                }
                if (combo_paper_size1.Text == "A5")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(500, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Patient Name: RAHUL", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient.Checked == true)
                            {
                                if (check_gender.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                               
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_patient_number1.Checked == true)
                            {
                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                            e.Graphics.DrawString("Age : 35", printFont, Brushes.Black, 300, yy);
                        }
                        yy = yy + 20;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_phone1.Checked == true)
                            {
                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_address1.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 300, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_medicalhistory1.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(500, yy));
                        yy = yy + 30;
                        if (chkdoctor1.Checked == true)
                        {
                            e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                            {
                                e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                            }
                        }
                        yy = yy + 20;
                        e.Graphics.DrawString("Date: ", printFont, Brushes.Gray, 400, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            DateTime tdate = Convert.ToDateTime(DateTime.Today);
                            e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 430, yy);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("Invoice Number:INV006", printFont, Brushes.Black, 20, yy);
                            e.Graphics.DrawString("Invoice", printFont1, Brushes.Gray, 25, yy+10);
                        }
                        yy = yy + 40;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 480, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Products & Services", printFont, Brushes.Black, 30, yy - 17);
                            e.Graphics.DrawString("Unit Cost INR", printFont, Brushes.Black, 170, yy - 17);
                            e.Graphics.DrawString("Qty", printFont, Brushes.Black, 255, yy - 17);
                            e.Graphics.DrawString("Discount INR", printFont, Brushes.Black, 280, yy - 17);
                            e.Graphics.DrawString("Tax INR", printFont, Brushes.Black, 360, yy - 17);
                            e.Graphics.DrawString("Total Cost INR", printFont, Brushes.Black, 410, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("200.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("2", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("80.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("55.94", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("375.94", printFont, Brushes.Black, 430, yy);
                        yy = yy + 20;
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("Notes: Treatment Plan Note", printFont, Brushes.Black, 20, yy+20);
                        yy = yy + 50;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("500.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("4", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("1,000.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("123.60", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("1,123.60", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy + 20);
                        e.Graphics.DrawString("Notes: ABC", printFont, Brushes.Black, 20, yy + 40);
                        e.Graphics.DrawString("Total Cost: 2,400.00 INR", printFont, Brushes.Black, 350, yy+60);
                        e.Graphics.DrawString("Total Discount: 1,080.00 INR", printFont, Brushes.Black, 350, yy+80);
                        e.Graphics.DrawString("Total Tax: 179.54 INR", printFont, Brushes.Black, 350, yy+100);
                        e.Graphics.DrawString("Grand Total: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 120);// yy;
                        e.Graphics.DrawString("Amount Received: 0.00 INR", printFont, Brushes.Black, 350, yy + 140);
                        e.Graphics.DrawString("Balance Amount: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 160);
                        yy = yy + 20;
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 760 - topmargin1), new System.Drawing.Point(500, 760 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth1.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign1.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign1.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth1.Text, printFont, Brushes.Gray, 280 - (txtDataWidth1 / 2), 765 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign1.Text, printFont, Brushes.Gray, 280 - (txtDataWidth2 / 2), 785 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign1.Text, printFont, Brushes.Gray, 280 - (txtDataWidth3 / 2), 800 - topmargin1);
                    }
                }
                else if (combo_paper_size1.Text == "A4")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(800, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Patient Name: RAHUL", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient1.Checked == true)
                            {
                                if (check_gender1.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_patient_number1.Checked == true)
                            {

                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                            e.Graphics.DrawString("Age : 35", printFont, Brushes.Black, 300, yy);
                        }
                        yy = yy + 20;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_phone1.Checked == true)
                            {

                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_address1.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 300, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_medicalhistory1.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(800, yy));
                        yy = yy + 30;
                        e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Date: ", printFont, Brushes.Gray, 700, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            DateTime tdate = Convert.ToDateTime(DateTime.Today);
                            e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 730, yy);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("Invoice Number:INV006", printFont, Brushes.Black, 20, yy);
                            e.Graphics.DrawString("Invoice", printFont1, Brushes.Gray, 25, yy+10);
                        }
                        yy = yy + 40;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 780, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Products & Services", printFont, Brushes.Black, 30, yy - 17);
                            e.Graphics.DrawString("Unit Cost INR", printFont, Brushes.Black, 170, yy - 17);
                            e.Graphics.DrawString("Qty", printFont, Brushes.Black, 255, yy - 17);
                            e.Graphics.DrawString("Discount INR", printFont, Brushes.Black, 280, yy - 17);
                            e.Graphics.DrawString("Tax INR", printFont, Brushes.Black, 360, yy - 17);
                            e.Graphics.DrawString("Total Cost INR", printFont, Brushes.Black, 410, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("200.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("2", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("80.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("55.94", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("375.94", printFont, Brushes.Black, 430, yy);
                        yy = yy + 20;
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("Notes: Treatment Plan Note", printFont, Brushes.Black, 20, yy + 20);
                        yy = yy + 50;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("500.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("4", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("1,000.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("123.60", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("1,123.60", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy + 20);
                        e.Graphics.DrawString("Notes: ABC", printFont, Brushes.Black, 20, yy + 40);
                        e.Graphics.DrawString("Total Cost: 2,400.00 INR", printFont, Brushes.Black, 350, yy + 60);
                        e.Graphics.DrawString("Total Discount: 1,080.00 INR", printFont, Brushes.Black, 350, yy + 80);
                        e.Graphics.DrawString("Total Tax: 179.54 INR", printFont, Brushes.Black, 350, yy + 100);
                        e.Graphics.DrawString("Grand Total: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 120);
                        e.Graphics.DrawString("Amount Received: 0.00 INR", printFont, Brushes.Black, 350, yy + 140);
                        e.Graphics.DrawString("Balance Amount: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 160);
                        yy = yy + 20;
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 1060 - topmargin1), new System.Drawing.Point(800, 1060 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth1.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign1.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign1.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth1.Text, printFont, Brushes.Gray, 400 - (txtDataWidth1 / 2), 1065 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign1.Text, printFont, Brushes.Gray, 400 - (txtDataWidth2 / 2), 1085 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign1.Text, printFont, Brushes.Gray, 400 - (txtDataWidth3 / 2), 1100 - topmargin1);
                    }
                }
                else if (combo_paper_size1.Text == "A3")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(1150, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Patient Name: RAHUL", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient1.Checked == true)
                            {
                                if (check_gender1.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_patient_number1.Checked == true)
                            {
                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                            e.Graphics.DrawString("Age : 35", printFont, Brushes.Black, 300, yy);
                        }
                        yy = yy + 20;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_phone1.Checked == true)
                            {
                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_address1.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 600, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient1.Checked == true)
                        {
                            if (check_medicalhistory1.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(1150, yy));
                        yy = yy + 30;
                        e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Date: ", printFont, Brushes.Gray, 1050, yy);
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            DateTime tdate = Convert.ToDateTime(DateTime.Today);
                            e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 1080, yy);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("Invoice Number:INV006", printFont, Brushes.Black, 20, yy);
                            e.Graphics.DrawString("Invoice", printFont1, Brushes.Gray, 25, yy+10);
                        }
                        yy = yy + 40;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 1120, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Products & Services", printFont, Brushes.Black, 30, yy - 17);
                            e.Graphics.DrawString("Unit Cost INR", printFont, Brushes.Black, 170, yy - 17);
                            e.Graphics.DrawString("Qty", printFont, Brushes.Black, 255, yy - 17);
                            e.Graphics.DrawString("Discount INR", printFont, Brushes.Black, 280, yy - 17);
                            e.Graphics.DrawString("Tax INR", printFont, Brushes.Black, 360, yy - 17);
                            e.Graphics.DrawString("Total Cost INR", printFont, Brushes.Black, 410, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("200.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("2", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("80.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("55.94", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("375.94", printFont, Brushes.Black, 430, yy);
                        yy = yy + 20;
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("Notes: Treatment Plan Note", printFont, Brushes.Black, 20, yy + 20);
                        yy = yy + 50;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("500.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("4", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("1,000.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("123.60", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("1,123.60", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy + 20);
                        e.Graphics.DrawString("Notes: ABC", printFont, Brushes.Black, 20, yy + 40);
                        e.Graphics.DrawString("Total Cost: 2,400.00 INR", printFont, Brushes.Black, 350, yy + 60);
                        e.Graphics.DrawString("Total Discount: 1,080.00 INR", printFont, Brushes.Black, 350, yy + 80);
                        e.Graphics.DrawString("Total Tax: 179.54 INR", printFont, Brushes.Black, 350, yy + 100);
                        e.Graphics.DrawString("Grand Total: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 120);// yy;
                        e.Graphics.DrawString("Amount Received: 0.00 INR", printFont, Brushes.Black, 350, yy + 140);
                        e.Graphics.DrawString("Balance Amount: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 160);
                        yy = yy + 20;
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 1540 - topmargin1), new System.Drawing.Point(1150, 1540 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth1.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign1.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign1.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth1.Text, printFont, Brushes.Gray, 550 - (txtDataWidth1 / 2), 1560 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign1.Text, printFont, Brushes.Gray, 550 - (txtDataWidth2 / 2), 1580 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign1.Text, printFont, Brushes.Gray, 550 - (txtDataWidth3 / 2), 1600 - topmargin1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_receiptprint_Click(object sender, EventArgs e)
        {
            try
            {
                orientation = "";
                color = "";
                if (radio_headeryes2.Checked == true)
                {
                    includeheader = "1";
                    header = text_header2.Text;
                    lefttext = text_left_text2.Text;
                    righttext = text_right_text2.Text;
                    if (radio_logo_yes2.Checked == true)
                    {
                        includelogo = "1";
                        logotype = "";
                    }
                    else
                    {
                        includelogo = "0";
                        logotype = "";
                    }
                }
                else
                {
                    includeheader = "0";
                    header = "";
                    lefttext = "";
                    righttext = "";
                    logotype = "";
                    includelogo = "0";
                }
                if (check_show_patient2.Checked == true)
                {
                    patientdetails = "0";
                    if (check_medicalhistory2.Checked == true)
                    {
                        medhistory = "0";
                    }
                    else
                    {
                        medhistory = "1";
                    }
                    if (check_patient_number2.Checked == true)
                    {
                        patientno = "0";
                    }
                    else
                    {
                        patientno = "1";
                    }
                    if (check_address2.Checked == true)
                    {
                        address = "0";
                    }
                    else
                    {
                        address = "1";
                    }
                    if (check_phone2.Checked == true)
                    {
                        phone = "0";
                    }
                    else
                    {
                        phone = "1";
                    }
                    if (check_email2.Checked == true)
                    {
                        email = "0";
                    }
                    else
                    {
                        email = "1";
                    }
                    if (check_blood2.Checked == true)
                    {
                        bloodgroup = "0";
                    }
                    else
                    {
                        bloodgroup = "1";
                    }
                    if (chkdoctor2.Checked == true)
                    {
                        Doctor = "0";
                    }
                    else
                    {
                        Doctor = "1";
                    }
                }
                else
                {
                    patientdetails = "1";
                    medhistory = "1";
                    patientno = "1";
                    address = "1";
                    phone = "1";
                    email = "1";
                    bloodgroup = "1";
                    Doctor = "1";
                }
                if (check_gender2.Checked == true)
                {
                    genderdob = "0";
                }
                else
                {
                    genderdob = "1";
                }
                string c = this.cntrl.get_receiptprintCount();
                int count = Convert.ToInt32(c);
                if (count == 0)
                {
                   this.cntrl.save_receipt(combo_paper_size2.Text, orientation, color, combo_topmargin2.Text, combo_leftmargin2.Text, combo_bottommargin2.Text, combo_rightmargin2.Text, includeheader, header, lefttext, righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, combo_footer_topmargin2.Text, rich_fullwidth2.Text, rich_leftsign2.Text, rich_rightsign2.Text, Doctor);
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                  this.cntrl.update_receipt(combo_paper_size2.Text, orientation, color, combo_topmargin2.Text, combo_leftmargin2.Text, combo_bottommargin2.Text, combo_rightmargin2.Text, includeheader, header, lefttext, righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, combo_footer_topmargin2.Text, rich_fullwidth2.Text, rich_leftsign2.Text, rich_rightsign2.Text, Doctor);
                    MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void printout_Load(object sender, EventArgs e)
        {
            try
            {
                prescription_flag = true;
                tabControl2.TabPages.Remove(tabPage5);
                tabControl3.TabPages.Remove(tabPage13);
                tabControl4.TabPages.Remove(tabPage17);
                tabControl5.TabPages.Remove(tabPage21);

                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage9);
                tabControl1.TabPages.Remove(tabPage10);
                DataTable clinic = this.cntrl.Get_practice_details();
                if (clinic.Rows.Count > 0)
                {
                    dataGridView1.DataSource = clinic;
                }
                radio_potrait.Checked = true;
                radio_black.Checked = true;
                radio_square_logo.Checked = true;
                radio_logo_yes.Checked = true;
                radio_headeryes.Checked = true;
                check_show_patient.Checked = true;
                chkdoctor.Checked = true;
                DataTable dtb= this.cntrl.get_prescription_printdetails();
                Load_prescription_printdetails(dtb);
                combo_footer_topmargin.SelectedIndex = 1;
                //invoice
                radio_potrait1.Checked = true;
                radio_black1.Checked = true;
                radio_square_logo1.Checked = true;
                radio_logo_yes1.Checked = true;
                radio_headeryes1.Checked = true;
                check_show_patient1.Checked = true;
                chkdoctor1.Checked = true;
              DataTable dtb_invoice=this.cntrl.invoice_printdetails();
                load_invoicePrint_details(dtb);
                //receipt
              DataTable dtb_receipt=  this.cntrl.load_receipt_print();
                Load_ReceiptPrint(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string top = combo_topmargin2.Text;
            int topmargin = int.Parse(top.Substring(0, top.IndexOf("m")));
            string bottom = combo_bottommargin2.Text;
            int bottommargin = int.Parse(bottom.Substring(0, bottom.IndexOf("m")));
            string left = combo_leftmargin2.Text;
            int leftmargin = int.Parse(left.Substring(0, left.IndexOf("m")));
            string right = combo_rightmargin2.Text;
            int rightmargin = int.Parse(right.Substring(0, right.IndexOf("m")));
            printDocument_receipt.DefaultPageSettings.Margins.Top = topmargin;
            printDocument_receipt.DefaultPageSettings.Margins.Left = leftmargin;
            printDocument_receipt.DefaultPageSettings.Margins.Bottom = bottommargin;
            printDocument_receipt.DefaultPageSettings.Margins.Right = rightmargin;
            printDocument_receipt.OriginAtMargins = true;
            if (combo_paper_size2.SelectedIndex != -1)
            {
                switch (combo_paper_size2.SelectedItem.ToString())
                {
                    //constructor "name", inch, inch
                    case "A3":
                        paperSize = new PaperSize("A3", 1170, 1650);
                        break;
                    case "A4":
                        paperSize = new PaperSize("A4", 830, 1170);
                        break;
                    case "A5":
                        paperSize = new PaperSize("A5", 580, 830);
                        break;
                    case "B4":
                        paperSize = new PaperSize("B4", 980, 1390);
                        break;
                    case "B5":
                        paperSize = new PaperSize("B5", 690, 980);
                        break;
                    case "LEGAL":
                        paperSize = new PaperSize("LEGAL", 215, 355);
                        break;
                    case "TABLOID":
                        paperSize = new PaperSize("TABLOID", 279, 431);
                        break;
                    case "FOLIO":
                        paperSize = new PaperSize("FOLIO", 210, 330);
                        break;
                    case "LETTER":
                        paperSize = new PaperSize("LETTER", 215, 279);
                        break;
                    case "EXECUTIVE":
                        paperSize = new PaperSize("EXECUTIVE", 184, 266);
                        break;
                    case "STATEMENT":
                        paperSize = new PaperSize("STATEMENT", 139, 215);
                        break;
                    default:
                        paperSize = new PaperSize("A4", 830, 1170);
                        break;

                }
                paperSize.RawKind = (int)PaperKind.Custom;
                printDocument_receipt.DefaultPageSettings.PaperSize = paperSize;
                printDocument_receipt.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            }
            printPreviewControl4.Document = printDocument_receipt;
            printPreviewControl4.Show();
        }
        private void printDocument_receipt_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                int xx = 30;
                int yy = 185;

                if (radio_headeryes2.Checked == true)
                {
                    if (radio_logo_yes2.Checked == true)
                    {
                        string pathimage = System.IO.Directory.GetCurrentDirectory();
                        System.Data.DataTable dtp = this.cntrl.Get_companydetails();
                        System.Drawing.Image logo = null;
                        try
                        {
                            if (dtp.Rows.Count > 0)
                            {
                                string path = dtp.Rows[0]["path"].ToString();
                                string curFile = this.cntrl.getserver() + "\\Pappyjoe_utilities\\Logo\\" + path;
                                if (System.IO.File.Exists(curFile))
                                {
                                    logo = System.Drawing.Image.FromFile(curFile);
                                    e.Graphics.DrawImage(logo, 30, 50, 100, 100);
                                    xx = 150;
                                }

                                
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 16.0f))
                    {
                        e.Graphics.DrawString(text_header2.Text, printFont, Brushes.Gray, xx, 70);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 12.0f))
                    {
                        e.Graphics.DrawString(text_left_text2.Text, printFont, Brushes.Gray, xx, 100);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 10.0f))
                    {
                        e.Graphics.DrawString(text_right_text2.Text, printFont, Brushes.Gray, xx, 120);
                    }
                }
                if (combo_paper_size2.Text == "A5")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(500, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Patient Name: RAHUL", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient2.Checked == true)
                            {
                                if (check_gender2.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }

                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_patient_number2.Checked == true)
                            {
                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                            e.Graphics.DrawString("Age : 35", printFont, Brushes.Black, 300, yy);
                        }
                        yy = yy + 20;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_phone2.Checked == true)
                            {
                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_address2.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 300, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_medicalhistory2.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(500, yy));
                        if (chkdoctor2.Checked == true)
                        {
                            yy = yy + 20;
                            e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                            {
                                e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                            }
                        }
                        yy = yy + 20;
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Date : 29/11/2014", printFont, Brushes.Black, 20, yy);
                            e.Graphics.DrawString("Invoice Number:INV006", printFont, Brushes.Black, 20, yy+20);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("Date : 29/11/2014", printFont, Brushes.Black, 300, yy);
                            e.Graphics.DrawString("Receipt Number : REC001", printFont, Brushes.Black, 300, yy+20);
                            g.DrawLine(pen, new System.Drawing.Point(20, yy + 39), new System.Drawing.Point(500, yy + 39));
                            e.Graphics.DrawString("Receipt", printFont1, Brushes.Gray, 20, yy + 50);
                            e.Graphics.DrawString("Received with thanks, amount of 1,300.00 INR towards the following :", printFont, Brushes.Black, 20, yy+80);
                        }
                        yy = yy +110;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 480, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Products & Services", printFont, Brushes.Black, 30, yy - 17);
                            e.Graphics.DrawString("Unit Cost INR", printFont, Brushes.Black, 170, yy - 17);
                            e.Graphics.DrawString("Qty", printFont, Brushes.Black, 255, yy - 17);
                            e.Graphics.DrawString("Discount INR", printFont, Brushes.Black, 280, yy - 17);
                            e.Graphics.DrawString("Tax INR", printFont, Brushes.Black, 360, yy - 17);
                            e.Graphics.DrawString("Total Cost INR", printFont, Brushes.Black, 410, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("200.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("2", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("80.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("55.94", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("375.94", printFont, Brushes.Black, 430, yy);
                        yy = yy + 20;
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("Notes: Treatment Plan Note", printFont, Brushes.Black, 20, yy + 20);
                        yy = yy + 50;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("500.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("4", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("1,000.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("123.60", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("1,123.60", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy + 20);
                        e.Graphics.DrawString("Notes: ABC", printFont, Brushes.Black, 20, yy + 40);
                        e.Graphics.DrawString("Total Cost: 2,400.00 INR", printFont, Brushes.Black, 300, yy + 60);
                        e.Graphics.DrawString("Total Discount: 1,080.00 INR", printFont, Brushes.Black, 300, yy + 80);
                        e.Graphics.DrawString("Total Tax: 179.54 INR", printFont, Brushes.Black, 300, yy + 100);
                        e.Graphics.DrawString("Grand Total: 1,499.54 INR", printFont, Brushes.Black, 300, yy + 120);// yy;
                        e.Graphics.DrawString("Amount Received: 0.00 INR", printFont, Brushes.Black, 300, yy + 140);
                        e.Graphics.DrawString("Balance Amount: 1,499.54 INR", printFont, Brushes.Black, 300, yy + 160);
                        yy = yy + 20;
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 770 - topmargin1), new System.Drawing.Point(500,770 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth2.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign2.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign2.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth2.Text, printFont, Brushes.Gray, 280 - (txtDataWidth1 / 2), 775 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign2.Text, printFont, Brushes.Gray, 280 - (txtDataWidth2 / 2), 785 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign2.Text, printFont, Brushes.Gray, 280 - (txtDataWidth3 / 2), 800 - topmargin1);
                    }
                }
                else if (combo_paper_size2.Text == "A4")
                { 
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(800, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Patient Name: RAHUL", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient2.Checked == true)
                            {
                                if (check_gender2.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_patient_number2.Checked == true)
                            {

                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                            e.Graphics.DrawString("Age : 35", printFont, Brushes.Black, 300, yy);
                        }
                        yy = yy + 20;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_phone2.Checked == true)
                            {

                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_address2.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 300, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_medicalhistory2.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(800, yy));
                        if (chkdoctor2.Checked == true)
                        {
                            yy = yy + 20;
                            e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                            {
                                e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                            }
                        }
                        yy = yy + 20;
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Date : 29/11/2014", printFont, Brushes.Black, 20, yy);
                            e.Graphics.DrawString("Invoice Number:INV006", printFont, Brushes.Black, 20, yy + 20);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("Date : 29/11/2014", printFont, Brushes.Black, 300, yy);
                            e.Graphics.DrawString("Receipt Number : REC001", printFont, Brushes.Black, 300, yy + 20);
                            g.DrawLine(pen, new System.Drawing.Point(20, yy + 39), new System.Drawing.Point(500, yy + 39));
                            e.Graphics.DrawString("Receipt", printFont1, Brushes.Gray, 20, yy + 50);
                            e.Graphics.DrawString("Received with thanks, amount of 1,300.00 INR towards the following :", printFont, Brushes.Black, 20, yy + 80);
                        }
                        yy = yy + 110;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 780, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Products & Services", printFont, Brushes.Black, 30, yy - 17);
                            e.Graphics.DrawString("Unit Cost INR", printFont, Brushes.Black, 170, yy - 17);
                            e.Graphics.DrawString("Qty", printFont, Brushes.Black, 255, yy - 17);
                            e.Graphics.DrawString("Discount INR", printFont, Brushes.Black, 280, yy - 17);
                            e.Graphics.DrawString("Tax INR", printFont, Brushes.Black, 360, yy - 17);
                            e.Graphics.DrawString("Total Cost INR", printFont, Brushes.Black, 410, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("200.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("2", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("80.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("55.94", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("375.94", printFont, Brushes.Black, 430, yy);
                        yy = yy + 20;
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("Notes: Treatment Plan Note", printFont, Brushes.Black, 20, yy + 20);
                        yy = yy + 50;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("500.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("4", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("1,000.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("123.60", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("1,123.60", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy + 20);
                        e.Graphics.DrawString("Notes: ABC", printFont, Brushes.Black, 20, yy + 40);
                        e.Graphics.DrawString("Total Cost: 2,400.00 INR", printFont, Brushes.Black, 350, yy + 60);
                        e.Graphics.DrawString("Total Discount: 1,080.00 INR", printFont, Brushes.Black, 350, yy + 80);
                        e.Graphics.DrawString("Total Tax: 179.54 INR", printFont, Brushes.Black, 350, yy + 100);
                        e.Graphics.DrawString("Grand Total: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 120);
                        e.Graphics.DrawString("Amount Received: 0.00 INR", printFont, Brushes.Black, 350, yy + 140);
                        e.Graphics.DrawString("Balance Amount: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 160);
                        yy = yy + 20;
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 1060 - topmargin1), new System.Drawing.Point(800, 1060 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth2.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign2.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign2.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth2.Text, printFont, Brushes.Gray, 400 - (txtDataWidth1 / 2), 1065 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign2.Text, printFont, Brushes.Gray, 400 - (txtDataWidth2 / 2), 1085 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign2.Text, printFont, Brushes.Gray, 400 - (txtDataWidth3 / 2), 1100 - topmargin1);
                    }
                }
                else if (combo_paper_size2.Text == "A3")
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(1150, 175));
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Arial", 9.0f))
                    {
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                        {
                            e.Graphics.DrawString("Patient Name: RAHUL", printFont1, Brushes.Black, 20, yy);
                            if (check_show_patient2.Checked == true)
                            {
                                if (check_gender2.Checked == true)
                                {
                                    e.Graphics.DrawString("Male", printFont1, Brushes.Black, 300, yy);
                                }
                            }
                        }
                        yy = yy + 22;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_patient_number2.Checked == true)
                            {
                                e.Graphics.DrawString("Patient id: PAT125", printFont, Brushes.Gray, 20, yy);
                            }
                            e.Graphics.DrawString("Age : 35", printFont, Brushes.Black, 300, yy);
                        }
                        yy = yy + 20;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_phone2.Checked == true)
                            {
                                e.Graphics.DrawString("+919447100905", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_address2.Checked == true)
                            {
                                e.Graphics.DrawString("2nd Floor, Premier Building, Calicut", printFont, Brushes.Gray, 600, yy);
                            }
                        }
                        yy = yy + 20;
                        if (check_show_patient2.Checked == true)
                        {
                            if (check_medicalhistory2.Checked == true)
                            {
                                e.Graphics.DrawString("Medical History: Illnesses", printFont, Brushes.Gray, 20, yy);
                            }
                        }
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(1150, yy));
                        if (chkdoctor2.Checked == true)
                        {
                            yy = yy + 20;
                            e.Graphics.DrawString("By:", printFont, Brushes.Gray, 20, yy);
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 10.0f))
                            {
                                e.Graphics.DrawString("Dr.Sunil Kumar MBBS", printFont1, Brushes.Black, 45, yy);
                            }
                        }
                        yy = yy + 20;
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Date : 29/11/2014", printFont, Brushes.Black, 20, yy);
                            e.Graphics.DrawString("Invoice Number:INV006", printFont, Brushes.Black, 20, yy + 20);
                        }
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Arial", 14.0f))
                        {
                            e.Graphics.DrawString("Date : 29/11/2014", printFont, Brushes.Black, 300, yy);
                            e.Graphics.DrawString("Receipt Number : REC001", printFont, Brushes.Black, 300, yy + 20);
                            g.DrawLine(pen, new System.Drawing.Point(20, yy + 39), new System.Drawing.Point(500, yy + 39));
                            e.Graphics.DrawString("Receipt", printFont1, Brushes.Gray, 20, yy + 50);
                            e.Graphics.DrawString("Received with thanks, amount of 1,300.00 INR towards the following :", printFont, Brushes.Black, 20, yy + 80);
                        }
                        yy = yy + 110;
                        Graphics g3 = e.Graphics;
                        g3.FillRectangle(Brushes.LightGray, 20, yy, 1120, 25);
                        yy = yy + 20;
                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Arial", 11.0f))
                        {
                            e.Graphics.DrawString("Products & Services", printFont, Brushes.Black, 30, yy - 17);
                            e.Graphics.DrawString("Unit Cost INR", printFont, Brushes.Black, 170, yy - 17);
                            e.Graphics.DrawString("Qty", printFont, Brushes.Black, 255, yy - 17);
                            e.Graphics.DrawString("Discount INR", printFont, Brushes.Black, 280, yy - 17);
                            e.Graphics.DrawString("Tax INR", printFont, Brushes.Black, 360, yy - 17);
                            e.Graphics.DrawString("Total Cost INR", printFont, Brushes.Black, 410, yy - 17);
                        }
                        yy = yy + 30;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("200.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("2", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("80.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("55.94", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("375.94", printFont, Brushes.Black, 430, yy);
                        yy = yy + 20;
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("Notes: Treatment Plan Note", printFont, Brushes.Black, 20, yy + 20);
                        yy = yy + 50;
                        e.Graphics.DrawString("Treatment Category Example", printFont, Brushes.Black, 20, yy);
                        e.Graphics.DrawString("500.00", printFont, Brushes.Black, 190, yy);
                        e.Graphics.DrawString("4", printFont, Brushes.Black, 265, yy);
                        e.Graphics.DrawString("1,000.00", printFont, Brushes.Black, 299, yy);
                        e.Graphics.DrawString("123.60", printFont, Brushes.Black, 380, yy);
                        e.Graphics.DrawString("1,123.60", printFont, Brushes.Black, 430, yy);
                        e.Graphics.DrawString("Date  29 Nov, 2014", printFont, Brushes.Black, 20, yy + 20);
                        e.Graphics.DrawString("Notes: ABC", printFont, Brushes.Black, 20, yy + 40);
                        e.Graphics.DrawString("Total Cost: 2,400.00 INR", printFont, Brushes.Black, 350, yy + 60);
                        e.Graphics.DrawString("Total Discount: 1,080.00 INR", printFont, Brushes.Black, 350, yy + 80);
                        e.Graphics.DrawString("Total Tax: 179.54 INR", printFont, Brushes.Black, 350, yy + 100);
                        e.Graphics.DrawString("Grand Total: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 120);// yy;
                        e.Graphics.DrawString("Amount Received: 0.00 INR", printFont, Brushes.Black, 350, yy + 140);
                        e.Graphics.DrawString("Balance Amount: 1,499.54 INR", printFont, Brushes.Black, 350, yy + 160);
                        yy = yy + 20;
                        yy = yy + 20;
                        g.DrawLine(pen, new System.Drawing.Point(20, 1540 - topmargin1), new System.Drawing.Point(1150, 1540 - topmargin1));
                        System.Drawing.Font printFt = new System.Drawing.Font("Arial", 9.0f);
                        var txtDataWidth1 = e.Graphics.MeasureString(rich_fullwidth2.Text, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(rich_leftsign2.Text, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(rich_rightsign2.Text, printFt).Width;
                        e.Graphics.DrawString(rich_fullwidth2.Text, printFont, Brushes.Gray, 550 - (txtDataWidth1 / 2), 1560 - topmargin1);
                        e.Graphics.DrawString(rich_leftsign2.Text, printFont, Brushes.Gray, 550 - (txtDataWidth2 / 2), 1580 - topmargin1);
                        e.Graphics.DrawString(rich_rightsign2.Text, printFont, Brushes.Gray, 550 - (txtDataWidth3 / 2), 1600 - topmargin1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SetController(Printout_controller controller)
        {
            cntrl = controller;
        }

        public void Load_prescription_printdetails(DataTable print)
        {
            if (print.Rows.Count > 0)
            {
                combo_topmargin.Text = print.Rows[0]["top_margin"].ToString();
                combo_leftmargin.Text = print.Rows[0]["left_margin"].ToString();
                combo_bottommargin.Text = print.Rows[0]["bottom_margin"].ToString();
                combo_rightmargin.Text = print.Rows[0]["right_margin"].ToString();
                combo_paper_size.Text = print.Rows[0]["size"].ToString();
                rich_fullwidth.Text = print.Rows[0]["fullwidth_context"].ToString();
                rich_leftsign.Text = print.Rows[0]["left_sign"].ToString();
                rich_rightsign.Text = print.Rows[0]["right_sign"].ToString();
                text_header.Text = print.Rows[0]["header"].ToString();
                text_left_text.Text = print.Rows[0]["left_text"].ToString();
                text_right_text.Text = print.Rows[0]["right_text"].ToString();
                string med = print.Rows[0]["medical_history"].ToString();
                if (med == "0")
                {
                    check_medicalhistory.Checked = true;
                }
                else
                {
                    check_medicalhistory.Checked = false;
                }
                string patient = print.Rows[0]["patient"].ToString();
                if (patient == "0")
                {
                    check_patient_number.Checked = true;
                }
                else
                {
                    check_patient_number.Checked = false;
                }
                string address = print.Rows[0]["address"].ToString();
                if (address == "0")
                {
                    check_address.Checked = true;
                }
                else
                {
                    check_address.Checked = false;
                }
                string phone = print.Rows[0]["phone"].ToString();
                if (phone == "0")
                {
                    check_phone.Checked = true;
                }
                else
                {
                    check_phone.Checked = false;
                }
                string blood = print.Rows[0]["blood_group"].ToString();
                if (blood == "0")
                {
                    check_blood.Checked = true;
                }
                else
                {
                    check_blood.Checked = false;
                }
                string gender = print.Rows[0]["gender_dob"].ToString();
                if (gender == "0")
                {
                    check_gender.Checked = true;
                }
                else
                {
                    check_gender.Checked = false;
                }
                string Doctor = print.Rows[0]["Doctor"].ToString();
                if (Doctor == "0")
                {
                    chkdoctor.Checked = true;
                }
                else
                {
                    chkdoctor.Checked = false;
                }
                string includeheader = print.Rows[0]["include_header"].ToString();
                if (includeheader == "1")
                {
                    radio_headeryes.Checked = true;
                    text_header.Text = print.Rows[0]["header"].ToString();
                    text_left_text.Text = print.Rows[0]["left_text"].ToString();
                    text_right_text.Text = print.Rows[0]["right_text"].ToString();
                    string includelogo = print.Rows[0]["include_logo"].ToString();
                    if (includelogo == "1")
                    {
                        radio_logo_yes.Checked = true;
                    }
                    else
                    {
                        radio_logo_no.Checked = true;
                    }
                }
                else
                {
                    radio_headerno.Checked = true;
                }
                button_prescription_preview_Click(this, new System.EventArgs());
            }
        }

        private void button_prescription_save_Click(object sender, EventArgs e)//compl
        {
            try
            {
                orientation = "";
                color = "";
                if (radio_headeryes.Checked == true)
                {
                    includeheader = "1";
                    header = text_header.Text;
                    lefttext = text_left_text.Text;
                    righttext = text_right_text.Text;
                    if (radio_logo_yes.Checked == true)
                    { 
                        includelogo = "1";
                    }
                    else
                    {
                        includelogo = "0";
                        logotype = "";
                    }
                }
                else
                {
                    includeheader = "0";
                    header = "";
                    lefttext = "";
                    righttext = "";
                    logotype = "";
                    includelogo = "0";
                }
                if (check_show_patient.Checked == true)
                {
                    patientdetails = "1";
                    if (check_medicalhistory.Checked == true)
                    {
                        medhistory = "0";
                    }
                    else
                    {
                        medhistory = "1";
                    }
                    if (check_patient_number.Checked == true)
                    {
                        patientno = "0";
                    }
                    else
                    {
                        patientno = "1";
                    }
                    if (check_address.Checked == true)
                    {
                        address = "0";
                    }
                    else
                    {
                        address = "1";
                    }
                    if (check_phone.Checked == true)
                    {
                        phone = "0";
                    }
                    else
                    {
                        phone = "1";
                    }
                    if (check_blood.Checked == true)
                    {
                        bloodgroup = "0";
                    }
                    else
                    {
                        bloodgroup = "1";
                    }
                    if (check_email.Checked == true)
                    {
                        email = "0";
                    }
                    else
                    {
                        email = "1";
                    }
                    if (chkdoctor.Checked == true)
                    {
                        Doctor = "0";
                    }
                    else
                    {
                        Doctor = "1";
                    }
                }
                else
                {
                    patientdetails = "0";
                    medhistory = "1";
                    patientno = "1";
                    address = "1";
                    phone = "1";
                    email = "1";
                    bloodgroup = "1";
                    Doctor = "1";
                }
                if (check_gender.Checked == true)
                {
                    genderdob = "0";
                }
                else
                {
                    genderdob = "1";
                }
                DataTable dtb = this.cntrl.Get_prescription_id();
                if (dtb.Rows.Count > 0)
                {
                    int i = this.cntrl.Update(combo_paper_size.Text, orientation, color, combo_topmargin.Text, combo_leftmargin.Text, combo_bottommargin.Text, combo_rightmargin.Text, includeheader, header, lefttext, righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, combo_footer_topmargin.Text, rich_fullwidth.Text, rich_leftsign.Text, rich_rightsign.Text, Doctor);
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    int i = this.cntrl.save(combo_paper_size.Text, orientation, color, combo_topmargin.Text, combo_leftmargin.Text, combo_bottommargin.Text, combo_rightmargin.Text, includeheader, header, lefttext, righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, combo_footer_topmargin.Text, rich_fullwidth.Text, rich_leftsign.Text, rich_rightsign.Text, Doctor);
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                button_prescription_preview_Click(this, new System.EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void load_invoicePrint_details(DataTable invoice_print)
        {
            if (invoice_print.Rows.Count > 0)
            {
                combo_topmargin1.Text = invoice_print.Rows[0]["top_margin"].ToString();
                combo_leftmargin1.Text = invoice_print.Rows[0]["left_margin"].ToString();
                combo_bottommargin1.Text = invoice_print.Rows[0]["bottom_margin"].ToString();
                combo_rightmargin1.Text = invoice_print.Rows[0]["right_margin"].ToString();
                combo_paper_size1.Text = invoice_print.Rows[0]["size"].ToString();
                rich_fullwidth1.Text = invoice_print.Rows[0]["header_top"].ToString();
                rich_leftsign1.Text = invoice_print.Rows[0]["left_sign"].ToString();
                rich_rightsign1.Text = invoice_print.Rows[0]["right_sign"].ToString();
                text_header1.Text = invoice_print.Rows[0]["header"].ToString();
                text_left_text1.Text = invoice_print.Rows[0]["left_text"].ToString();
                text_right_text1.Text = invoice_print.Rows[0]["right_text"].ToString();
                string med = invoice_print.Rows[0]["medical_history"].ToString();
                if (med == "0")
                {
                    check_medicalhistory1.Checked = true;
                }
                else
                {
                    check_medicalhistory1.Checked = false;
                }
                string patient = invoice_print.Rows[0]["patient"].ToString();
                if (patient == "0")
                {
                    check_patient_number1.Checked = true;
                }
                else
                {
                    check_patient_number1.Checked = false;
                }
                string address = invoice_print.Rows[0]["address"].ToString();
                if (address == "0")
                {
                    check_address1.Checked = true;
                }
                else
                {
                    check_address1.Checked = false;
                }
                string phone = invoice_print.Rows[0]["phone"].ToString();
                if (phone == "0")
                {
                    check_phone1.Checked = true;
                }
                else
                {
                    check_phone1.Checked = false;
                }
                string blood = invoice_print.Rows[0]["blood_group"].ToString();
                if (blood == "0")
                {
                    check_blood1.Checked = true;
                }
                else
                {
                    check_blood1.Checked = false;
                }
                string gender = invoice_print.Rows[0]["gender_dob"].ToString();
                if (gender == "0")
                {
                    check_gender1.Checked = true;
                }
                else
                {
                    check_gender1.Checked = false;
                }
                string includeheader = invoice_print.Rows[0]["include_header"].ToString();
                if (includeheader == "1")
                {
                    radio_headeryes1.Checked = true;
                    text_header1.Text = invoice_print.Rows[0]["header"].ToString();
                    text_left_text1.Text = invoice_print.Rows[0]["left_text"].ToString();
                    text_right_text1.Text = invoice_print.Rows[0]["right_text"].ToString();
                    string includelogo = invoice_print.Rows[0]["include_logo"].ToString();
                    if (includelogo == "1")
                    {
                        radio_logo_yes1.Checked = true;
                    }
                    else
                    {
                        radio_logo_no1.Checked = true;
                    }
                }
                else
                {
                    radio_headerno1.Checked = true;
                }
            }
        }
        //Receipt   check_show_patient2
        public void Load_ReceiptPrint(DataTable Receipt_print)
        {
            if(Receipt_print.Rows.Count>0)
            {
                combo_topmargin2.Text = Receipt_print.Rows[0]["top_margin"].ToString();
                combo_leftmargin2.Text = Receipt_print.Rows[0]["left_margin"].ToString();
                combo_bottommargin2.Text = Receipt_print.Rows[0]["bottom_margin"].ToString();
                combo_rightmargin2.Text = Receipt_print.Rows[0]["right_margin"].ToString();
                combo_paper_size2.Text = Receipt_print.Rows[0]["size"].ToString();
                rich_fullwidth2.Text = Receipt_print.Rows[0]["header_top"].ToString();
                rich_leftsign2.Text = Receipt_print.Rows[0]["fullwidth_context"].ToString();
                rich_rightsign2.Text = Receipt_print.Rows[0]["left_sign"].ToString();
                text_header2.Text = Receipt_print.Rows[0]["header"].ToString();
                text_left_text2.Text = Receipt_print.Rows[0]["left_text"].ToString();
                text_right_text2.Text = Receipt_print.Rows[0]["right_text"].ToString();
                string patiebtdetails = Receipt_print.Rows[0]["patient_details"].ToString();
                if(patiebtdetails =="0")
                {
                    check_show_patient2.Checked = true;
                }
                else
                {
                    check_show_patient2.Checked = false;
                }
                string med = Receipt_print.Rows[0]["medical_history"].ToString();
                if (med == "0")
                {
                    check_medicalhistory2.Checked = true;
                }
                else
                {
                    check_medicalhistory2.Checked = false;
                }
                string patient = Receipt_print.Rows[0]["patient"].ToString();
                if (patient == "0")
                {
                    check_patient_number2.Checked = true;
                }
                else
                {
                    check_patient_number2.Checked = false;
                }
                string address = Receipt_print.Rows[0]["address"].ToString();
                if (address == "0")
                {
                    check_address2.Checked = true;
                }
                else
                {
                    check_address2.Checked = false;
                }
                string phone = Receipt_print.Rows[0]["phone"].ToString();
                if (phone == "0")
                {
                    check_phone2.Checked = true;
                }
                else
                {
                    check_phone2.Checked = false;
                }
                string blood = Receipt_print.Rows[0]["blood_group"].ToString();
                if (blood == "0")
                {
                    check_blood2.Checked = true;
                }
                else
                {
                    check_blood2.Checked = false;
                }
                string gender = Receipt_print.Rows[0]["gender_dob"].ToString();
                if (gender == "0")
                {
                    check_gender2.Checked = true;
                }
                else
                {
                    check_gender2.Checked = false;
                }
                string doctor= Receipt_print.Rows[0]["Doctor"].ToString();
                if(doctor=="0")
                {
                    chkdoctor2.Checked = true;
                }
                else
                {
                    chkdoctor2.Checked = false;
                }
                string patNo = Receipt_print.Rows[0]["patient"].ToString();
                if (patNo == "0")
                {
                    check_patient_number2.Checked = true;
                }
                else
                {
                    check_patient_number2.Checked = false;
                }
                string includeheader = Receipt_print.Rows[0]["include_header"].ToString();
                if (includeheader == "1")
                {
                    radio_headeryes2.Checked = true;
                    text_header2.Text = Receipt_print.Rows[0]["header"].ToString();
                    text_left_text2.Text = Receipt_print.Rows[0]["left_text"].ToString();
                    text_right_text2.Text = Receipt_print.Rows[0]["right_text"].ToString();
                    string includelogo = Receipt_print.Rows[0]["include_logo"].ToString();
                    if (includelogo == "1")
                    {
                        radio_logo_yes2.Checked = true;
                    }
                    else
                    {
                        radio_logo_no2.Checked = true;
                    }
                }
                else
                {
                    radio_headerno2.Checked = true;
                }
            }
        }
    }
}
