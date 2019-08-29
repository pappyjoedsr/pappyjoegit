using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;  
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class Ledger : Form,Ledger_interface
    {
        public Ledger()
        {
            InitializeComponent();
        }
        public string patient_id = "0";
        public string doctor_id = "0";
        string logo_name = "";
        string path = "";
        public decimal balance;
        public decimal a;
        public decimal b;
        public decimal credit;
        string totalamt;
        Ledger_controller cntrl ;
        Connection db = new Connection();
        private void Ledger_Load(object sender, EventArgs e)
        {
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            string docnam = this.cntrl.Get_DoctorName(doctor_id);
            if (docnam != "")
            {
                toolStripTextDoctor.Text = "Logged In As : " + docnam;
            }
            DataTable clinicname = this.cntrl.Get_CompanyNAme();
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
                path = clinicname.Rows[0]["path"].ToString();
                if (path != "")
                {
                    if (File.Exists(db.server() + path))
                    {
                        logo_name = "";
                        logo_name = path;
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        if (!File.Exists(Apppath + "\\" + logo_name))
                        {
                            System.IO.File.Copy(db.server() + path, Apppath + "\\" + logo_name);
                        }
                    }
                    else
                    {
                        logo_name = "";
                    }
                }
            }
            DataTable dtadvance = this.cntrl.Get_Advance(patient_id);
            if (dtadvance.Rows.Count > 0)
            {
                label31.Text = "Available advance: " + string.Format("{0:C}", decimal.Parse(dtadvance.Rows[0][0].ToString()));
            }
            else
            {
                label31.Text = "Available advance: " + string.Format("{0:C}", 0);
            }
            listpatientsearch.Hide();
            System.Data.DataTable pat = this.cntrl.Get_pat_iDName(patient_id);
            linkLabel_id.Text = pat.Rows[0]["pt_id"].ToString();
            linkLabel_Name.Text = pat.Rows[0]["pt_name"].ToString();
            DataTable dt_invoice = this.cntrl.LedgerInvoice(patient_id);
            DGV_Transaction.Size = new System.Drawing.Size(1038, 500);
            DGV_Transaction.Columns.Add("abc", "DATE");
            DGV_Transaction.Columns["abc"].Width = 170;
            DGV_Transaction.Columns.Add("ac", "INVOICE NO");
            DGV_Transaction.Columns["ac"].Width = 170;
            DGV_Transaction.Columns.Add("dds", "DETAILS");
            DGV_Transaction.Columns["dds"].Width = 170;
            DGV_Transaction.Columns.Add("sdfd", "CREDIT");
            DGV_Transaction.Columns["sdfd"].Width = 100;
            DGV_Transaction.Columns["sdfd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns["sdfd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns.Add("sde", "DEBIT");
            DGV_Transaction.Columns["sde"].Width = 100;
            DGV_Transaction.Columns["sde"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns["sde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns.Add("q", "  BALANCE");
            DGV_Transaction.Columns["q"].Width = 100;
            DGV_Transaction.Columns["q"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns["q"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns["q"].Visible = false;
            DGV_Transaction.Columns.Add("q1", "BALANCE");
            DGV_Transaction.Columns["q1"].Width = 150;
            DGV_Transaction.Columns["q1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.Columns["q1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DGV_Transaction.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 10, FontStyle.Bold);
            DGV_Transaction.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            DGV_Transaction.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGV_Transaction.EnableHeadersVisualStyles = false;
            decimal totalcredit = 0;
            if (dt_invoice.Rows.Count > 0)
            {
                for (int z = 0; z < dt_invoice.Rows.Count; z++)
                {
                    string date = dt_invoice.Rows[z]["date"].ToString();
                    DateTime d = Convert.ToDateTime(date);
                    string day = d.Day.ToString();
                    string year = d.Year.ToString();
                    string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Month);
                    string sr = d.Month.ToString();
                    string invoiceno = dt_invoice.Rows[z]["invoice_no"].ToString();
                    string details = dt_invoice.Rows[z]["services"].ToString();
                    decimal cost = decimal.Parse(dt_invoice.Rows[z]["cost"].ToString());
                    decimal unit = decimal.Parse(dt_invoice.Rows[z]["unit"].ToString());
                    decimal discount = decimal.Parse(dt_invoice.Rows[z]["discountin_rs"].ToString());
                    decimal tax = decimal.Parse(dt_invoice.Rows[z]["tax_inrs"].ToString());
                    credit = (cost * unit) - (tax + discount);
                    totalcredit = totalcredit + credit;
                    DGV_Transaction.Rows.Add(day + ' ' + strMonthName + ' ' + year, invoiceno, details, String.Format("{0:C}", credit), String.Format("{0:C}", 0), String.Format("{0:C}", totalcredit));
                    DGV_Transaction.Rows[z].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[z].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[z].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[z].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[z].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[z].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[z].Cells[0].Style.ForeColor = Color.Green;
                }
            }
            DataTable dtb = this.cntrl.LedgerPay(patient_id);// s.LedgerPay();
            if (dtb.Rows.Count > 0)
            {
                for (int u = 0; u < dtb.Rows.Count; u++)
                {
                    string recpno = dtb.Rows[u]["receipt_no"].ToString();
                    string date = dtb.Rows[u]["payment_date"].ToString();
                    DateTime d = Convert.ToDateTime(date);
                    string day = d.Day.ToString();
                    string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Month);
                    string year = d.Year.ToString();
                    string invoiceno = dtb.Rows[u]["invoice_no"].ToString();
                    string[] invoice1 = new string[100];
                    invoice1 = invoiceno.Split(',');
                    decimal total = Convert.ToDecimal(dtb.Rows[u]["amount_paid"].ToString());
                    string invAmount = DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[5].Value.ToString();
                    balance = decimal.Parse(invAmount, NumberStyles.Currency);
                    decimal balance1 = balance - total;
                    DGV_Transaction.Rows.Add(day + ' ' + month + ' ' + year, recpno, invoiceno, String.Format("{0:C}", 0), String.Format("{0:C}", total), String.Format("{0:C}", balance1));
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    DGV_Transaction.Rows[dtb.Rows.Count + u].Cells[0].Style.ForeColor = Color.Blue;
                }
            }
            decimal credittot = 0;
            decimal debittot = 0;
            if (DGV_Transaction.Rows.Count > 0)
            {
                for (int j = 0; j < DGV_Transaction.Rows.Count; j++)
                {
                    decimal credit = decimal.Parse(DGV_Transaction.Rows[j].Cells[3].Value.ToString(), NumberStyles.Currency);
                    decimal debit = decimal.Parse(DGV_Transaction.Rows[j].Cells[4].Value.ToString(), NumberStyles.Currency);
                    credittot = credittot + credit;
                    debittot = debittot + debit;
                    string credittot1 = String.Format("{0:C}", credittot);
                    Lab_Due.Text = credittot1.ToString();
                    string debittot1 = String.Format("{0:C}", debittot);
                    Lab_DebitTotal.Text = debittot1.ToString();
                    decimal tot = credittot - debittot;
                    totalamt = tot.ToString();
                    string tot1 = String.Format("{0:C}", tot);
                    Lab_BalanTotal.Text = tot1;
                    string rr = DGV_Transaction.Rows[j].Cells[1].Value.ToString();
                }
            }
            decimal c = a - b;
            DGV_Transaction.Rows.Add("", "", "TOTAL", Lab_Due.Text, Lab_DebitTotal.Text, Lab_BalanTotal.Text, Lab_BalanTotal.Text);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[6].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(224, 224, 224);
            DGV_Transaction.Rows[DGV_Transaction.Rows.Count - 1].Cells[6].Style.ForeColor = Color.Red;
            DGV_Transaction.AllowUserToAddRows = false;
            if (DGV_Transaction.Rows.Count < 2)
            {
                DGV_Transaction.CurrentCell.Selected = false;
                DGV_Transaction.Visible = false;
                btnprint.Hide();
                btnpayreminder.Hide();
            }
            else
            {
                btnprint.Show();
                DGV_Transaction.CurrentCell.Selected = false;
            }
            if (DGV_Transaction.Rows.Count <= 1)
            {
                Lab_Msg.Show();
                Lab_Msg.Location = new System.Drawing.Point(350, 165);
            }
            else
            {
                Lab_Msg.Hide();
                Lab_Msg.Location = new System.Drawing.Point(350, 165);
            }
        }
        public void SetController(Ledger_controller controller)
        {
           cntrl = controller;
        }

        private void btnpayreminder_Click(object sender, EventArgs e)
        {
            try
            {
                string doctor_name = "";
               string doct = this.cntrl.Get_DoctorName(doctor_id);
                if (doct!="")
                {
                    doctor_name = doct;
                }
                System.Data.DataTable patient = this.cntrl.Get_Patient_Details(patient_id);
                string Pname = "", Gender = "", address = "", DOA = "", age = "", Mobile = "";
                if (patient.Rows.Count > 0)
                {
                    Pname = patient.Rows[0]["pt_name"].ToString();
                    Gender = patient.Rows[0]["gender"].ToString();
                    address = patient.Rows[0]["street_address"].ToString() + " , " + patient.Rows[0]["city"].ToString();
                    Mobile = patient.Rows[0]["primary_mobile_number"].ToString();
                    DOA = DateTime.Parse(patient.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                    if (patient.Rows[0]["date_of_birth"].ToString() != "")
                    {
                        age = DateTime.Parse(patient.Rows[0]["date_of_birth"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
                string contact_no = "";
                string clinic_name = "";
                System.Data.DataTable dtp = this.cntrl.get_company_details();
                if (dtp.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = dtp.Rows[0]["name"].ToString();
                    clinic_name = clinicn.Replace("¤", "'");
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                }
                string email = "", emailName = "", emailPass = "";
                System.Data.DataTable sr = this.cntrl.getpatemail(patient_id);
                if (sr.Rows.Count > 0)
                {
                    email = sr.Rows[0]["email_address"].ToString();
                    if (email != "")
                    {
                        System.Data.DataTable sms = this.cntrl.send_email();
                        if (sms.Rows.Count > 0)
                        {
                            emailName = sms.Rows[0]["emailName"].ToString();
                            emailPass = sms.Rows[0]["emailPass"].ToString();
                            try
                            {
                                string payment = "<html><body><p>Dear <b>" + Pname.ToString() + "</b>, your " + clinic_name.ToString() + " account summary is here.</p><h3><u>Account Details</u></h3><div style=border:1px solid #ededed;color:#999999;><p>" + Pname.ToString() + "</p><p>" + Gender.ToString() + "</p><p>" + address.ToString() + "</p><p>" + Mobile.ToString() + "</p></div><h3><u>Clinic Details</u></h3><div style=border:1px solid #ededed;color:#999999;><p>" + clinic_name.ToString() + "</p><p>" + doctor_name.ToString() + "</p><p>" + contact_no.ToString() + "</p><table style=color:#F0605D><tr><td width=200px><b>DUE AMOUNT :</b></td><td width=200px style=font-size:20px;><b> INR " + Lab_BalanTotal.Text + "/- </b><//td></tr></table></div><p>This letter is to formally notify you that to pay the amount due within 15 working days.If your payment has been already sent or remitted by credit card, please disregard this letter. </p><p> However,if you have not yet made payment, kindely do so immediately.Thank you for attending to this matter as soon as possible. </p><p><b>Regards,</b></p><p>" + clinic_name.ToString() + "</p></body></html>";
                                double j = Convert.ToDouble(totalamt);
                                if (j > 0)
                                {
                                    MailMessage message = new MailMessage();
                                    message.From = new MailAddress(email);
                                    message.To.Add(email);
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                    message.Subject = "Ledger";
                                    message.Body = payment;
                                    message.IsBodyHtml = true;
                                    smtp.Port = 587;
                                    smtp.Host = "smtp.gmail.com";
                                    smtp.EnableSsl = true;
                                    smtp.UseDefaultCredentials = false;
                                    smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                    smtp.Send(message);
                                    MessageBox.Show("Email is Sent To : " + email, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("There is No Dues for this patient:" + Pname.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch(Exception ex)
                            {
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invali Email Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please add  Email Id To this patient", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                printhtml();
            }
            catch
            {
                MessageBox.Show("Report error..", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void printhtml()
        {
            try
            {
                string clinicn = "";
                string Clinic = "";
                string streetaddress = "";
                string str_locality = "";
                string contact_no = "";
                string str_pincode = "";
                string str_email = "";
                string str_website = "";
                System.Data.DataTable dtp = db.table("select * from tbl_practice_details");
                if (dtp.Rows.Count > 0)
                {
                    clinicn = dtp.Rows[0]["name"].ToString();
                    Clinic = clinicn.Replace("¤", "'");
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                }
                string day = DateTime.Now.DayOfWeek.ToString();
                string date = DateTime.Now.Day.ToString();
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
                string year = DateTime.Now.Year.ToString();
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\ledger.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br>");
                if (logo_name != "")
                {
                    string Appath = System.IO.Directory.GetCurrentDirectory();
                    if (File.Exists(Appath + "\\" + logo_name))
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td width='85' height='100px' align='left' rowspan='7'><img src='" + Appath + "\\" + logo_name + "' width='79' height='110' style='width:100px;height:100px;'></td>  ");
                        sWrite.WriteLine("<td width='588' align='left' height='20px'><FONT  COLOR=black  face='Arial' SIZE=5>&nbsp;" + Clinic + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Arial' SIZE=3>&nbsp;" + streetaddress + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + str_locality + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;Pincode :" + str_pincode + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Phone No :" + contact_no + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Email :" + str_email + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Website :" + str_website + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Arial' SIZE=5>&nbsp;" + Clinic + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Arial' SIZE=3>&nbsp;&nbsp;" + streetaddress + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + str_locality + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;Pincode :" + str_pincode + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;&nbsp;Phone No :" + contact_no + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Email :" + str_email + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Website :" + str_website + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Arial' SIZE=5>&nbsp;" + Clinic + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Arial' SIZE=3>&nbsp;" + streetaddress + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + str_locality + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;Pincode :" + str_pincode + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Phone No :" + contact_no + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Email :" + str_email + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Arial' SIZE=2>&nbsp;Website :" + str_website + "</font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                int Dexist = 0;
                string sexage = "";
                string address = "";
                address = "";
                System.Data.DataTable dt1 = db.table("select * from tbl_patient where id='" + patient_id + "'");
                if (dt1.Rows.Count > 0)
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    if (dt1.Rows[0]["gender"].ToString() != "")
                    {
                        sexage = dt1.Rows[0]["gender"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["age"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            sexage = sexage + ", " + dt1.Rows[0]["age"].ToString() + " Years";
                        }
                        else
                        {
                            sexage = dt1.Rows[0]["age"].ToString() + " Years";
                        }
                    }
                    sWrite.WriteLine(" <td align='left' height=25><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>" + dt1.Rows[0]["pt_name"].ToString() + "</b><i> (" + sexage + ")</i></font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Patient Id:" + dt1.Rows[0]["pt_id"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    Dexist = 0;
                    if (dt1.Rows[0]["street_address"].ToString() != "")
                    {
                        address = dt1.Rows[0]["street_address"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["locality"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["locality"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["city"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["city"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["pincode"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["pincode"].ToString();
                        Dexist = 1;
                    }
                    if (address != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + address + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    if (dt1.Rows[0]["aadhar_id"].ToString() != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + "Aadhaar ID:" + dt1.Rows[0]["aadhar_id"].ToString() + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + dt1.Rows[0]["primary_mobile_number"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    if (dt1.Rows[0]["email_address"].ToString() != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + dt1.Rows[0]["email_address"].ToString() + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr><td colspan=2><hr></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td><FONT COLOR=black FACE='Geneva, Arial' SIZE=6>Ledger</FONT></td>");
                sWrite.WriteLine("<td width=350px></td>");
                sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Now.ToString("dd MMM yyyy") + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr style='background:#999999'>");
                sWrite.WriteLine("<td align='left' width='35px' height='30' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>Sl.</font></td>");
                sWrite.WriteLine("<td align='left' width='113px' height='30' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Date</font></td>");
                sWrite.WriteLine("<td align='left' width='87px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Invoice No. </font></td>");
                sWrite.WriteLine("<td align='left' width='195px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Details </font></td>");
                sWrite.WriteLine("<td align='right' width='72px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Credit&nbsp;</font></td>");
                sWrite.WriteLine("<td align='right' width='75px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Debit&nbsp;</font></td>");
                sWrite.WriteLine("<td align='right' width='91px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Balance&nbsp;</font></td>");
                sWrite.WriteLine("</tr>");
                for (int i = 0; i < DGV_Transaction.Rows.Count - 1; i++)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' height='30'  ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + (i + 1) + " </font></td>");
                    sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + DGV_Transaction.Rows[i].Cells[0].FormattedValue.ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + DGV_Transaction.Rows[i].Cells[1].FormattedValue.ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + DGV_Transaction.Rows[i].Cells[2].FormattedValue.ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='right'   ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + DGV_Transaction.Rows[i].Cells[3].FormattedValue.ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='right'   ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + DGV_Transaction.Rows[i].Cells[4].FormattedValue.ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='right'   ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + DGV_Transaction.Rows[i].Cells[5].FormattedValue.ToString() + " </font></td>");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr><td align='left' colspan=7><hr/></td></tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right' colspan=6 width='80px'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + " TOTAL CREDIT :" + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + this.Lab_Due.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right'    colspan=6 width='80px'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + "TOTAL DEBIT : " + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=1 width='40px'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + this.Lab_DebitTotal.Text + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<b><td align='Right'   colspan=6 width='80px' style='font:Arial;font-size:10'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + "TOTAL BALANCE : " + " </font></td></b>");
                sWrite.WriteLine("<b><td align='Right'   colspan=1 width='40px'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + this.Lab_BalanTotal.Text + " </font></td></b>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body >");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\ledger.html");
            }
            catch (Exception ex)
            {
            }
        }

        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            profile_details_controller ctr = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controllr = new Communication_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            //Reports_controller controller = new Reports_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            //expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                //doctor_controller controlr = new doctor_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            //Vital_Signs_controller controller = new Vital_Signs_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new TreatmentPlans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            treatment_controller controller = new treatment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new FinishedProcedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            finishedprocedre_controller controller = new finishedprocedre_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            invoice_controller controller = new invoice_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Receipt_controller controller = new Receipt_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Ledger_controller controller = new Ledger_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
                listpatientsearch.DataSource = dtdr;
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStrip2.Width - 352, 39);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new PracticeDetails();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                var form2 = new PracticeDetails();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new AddNewPatients();
                    form2.doctor_id = doctor_id;
                    AddNew_patient_controller controller = new AddNew_patient_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new AddNewPatients();
                form2.doctor_id = doctor_id;
                AddNew_patient_controller controller = new AddNew_patient_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new prescriptionShow();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            prescriptionshow_controller controller = new prescriptionshow_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            //Clinical_Findings_controller controller = new Clinical_Findings_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}
