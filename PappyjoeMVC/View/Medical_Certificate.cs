using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class Medical_Certificate : Form
    {
        public string patient_id = "0";
        Common_model mdl = new Common_model();
        Connection db = new Connection();
        public Medical_Certificate()
        {
            InitializeComponent();
        }

        private void MedicalCertificate_Load(object sender, EventArgs e)
        {
            DataTable rs_patients = mdl.Get_Patient_Details(patient_id);
            if (rs_patients.Rows[0]["pt_name"].ToString() != "")
            {
                txtname.Text = rs_patients.Rows[0]["pt_name"].ToString();
                if (rs_patients.Rows[0]["gender"].ToString() == "Female")
                {
                    txt_he.Text = "She";
                    txt_she.Text = "She";
                }
                else
                {
                    txt_he.Text = "He";
                    txt_she.Text = "He";
                }
            }
            comboBox2.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            System.Data.DataTable dtdr = mdl.get_all_doctorname();// db.table("select DISTINCT id,doctor_name from tbl_doctor where login_type='doctor' or login_type ='admin' and activate_login='yes' order by doctor_name");
            cmbDoctor.DisplayMember = "doctor_name";
            cmbDoctor.ValueMember = "id";
            cmbDoctor.DataSource = dtdr;
            panel8.Width = this.Width;
            dateTimePickerTo.Value = DateTime.Today;
            fromdate();
        }

        private void fromdate()
        {
            System.Data.DataTable dt7 = mdl.get_patient_date(patient_id);
            string aa = dt7.Rows[0]["date"].ToString();
            if (dt7.Rows[0]["date"].ToString() != "")
            {
                dateTimePickefrom.Show();
                dateTimePickefrom.Value = DateTime.Parse(DateTime.Parse(dt7.Rows[0]["date"].ToString()).ToString());
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (BtnPrint.Text == "Print Priview")
            {
                print();
            }
            else
            {
                Email();
            }
        }
        public void print()
        {
            try
            {
                DateTime SelDateFrom = dateTimePickefrom.Value;
                DateTime SelDateTo = dateTimePickerTo.Value;
                if (SelDateTo >= SelDateFrom)
                {
                    string strclinicname = "";
                    string strphone = "";
                    string logo_name = "";
                    string string_address = "";
                    string string_contact = "";
                    System.Data.DataTable dtp = mdl.Get_Practice_details();// db.table("select name,contact_no,path,street_address,contact_no from tbl_practice_details");
                    if (dtp.Rows.Count > 0)
                    {
                        string clinicn = "";
                        clinicn = dtp.Rows[0]["Name"].ToString();
                        strclinicname = clinicn.Replace("¤", "'");
                        string path = dtp.Rows[0]["path"].ToString();
                        if (path != "")
                        {
                            if (File.Exists(db.server() + path))
                            {
                                logo_name = "";
                                logo_name = path;
                                string Appath = System.IO.Directory.GetCurrentDirectory();
                                if (!File.Exists(Appath + "\\" + logo_name))
                                {
                                    System.IO.File.Copy(db.server() + path, Appath + "\\" + logo_name);
                                }
                            }
                            else
                            {
                                logo_name = "";
                            }
                        }
                        string_address = dtp.Rows[0]["street_address"].ToString();
                        string_contact = dtp.Rows[0]["contact_no"].ToString();
                    }

                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\MedicalHistory.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table, th, td {border: 2px ;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
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
                            sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
                            sWrite.WriteLine("<td width='588' align='left' height='25px'><FONT  color=black  face='Segoe UI' SIZE=5>" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>" + string_address + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + string_contact + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='25px'><FONT  color=black  face='Segoe UI' SIZE=5>" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>" + string_address + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + string_contact + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='25px'><FONT  color=black  face='Segoe UI' SIZE=5>" + strclinicname + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>" + string_address + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + string_contact + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }

                    sWrite.WriteLine("<table align=center>");
                    sWrite.WriteLine("<col width=500>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th align=center><br><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5>Medical Certificate </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 > <br><b>Date:</b>&nbsp;&nbsp;  </font> <FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 > " + datePick.Value.ToString("dd-MMM-yyyy") + "</th></tr> " + "</font>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=justify><p style=line-height:3><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=4 >&nbsp;&nbsp;&nbsp; ");
                    sWrite.WriteLine("<b>" + comboBox1.Text + " " + txtname.Text + "</b> " + comboBox2.Text + " under my treatment for <b> " + txtfor.Text + "  </b>from <b>" + dateTimePickefrom.Value.ToString("dd/MM/yyyy") + "</b> to <b>" + dateTimePickerTo.Value.ToString("dd/MM/yyyy") + "</b>. " + txt_he.Text + " " + comboBox5.Text + " advised complete rest for this period. " + txt_she.Text + " " + comboBox7.Text + " medically fit to resume duty from <b> " + dateTimePickerfrmlast.Value.ToString("dd/MM/yyyy") + " " + txtMore.Text + "</b>");
                    sWrite.WriteLine("</font> </p></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 ><br><br><b>Doctor's Name & Signature</b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 ><br><br><b> " + cmbDoctor.Text + "</b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\MedicalHistory.html");
                }
                else
                {
                    MessageBox.Show("From date has to be lesser than To date. Please Check and try again..", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Email()
        {

            try
            {
                DateTime SelDateFrom = dateTimePickefrom.Value;
                DateTime SelDateTo = dateTimePickerTo.Value;
                if (SelDateTo >= SelDateFrom)
                {
                    string strclinicname = "";
                    string strphone = "";
                    System.Data.DataTable dtp = mdl.Get_Practice_details();// db.table("select name,contact_no from tbl_practice_details");
                    if (dtp.Rows.Count > 0)
                    {
                        strclinicname = dtp.Rows[0]["name"].ToString();
                        strphone = dtp.Rows[0]["contact_no"].ToString();
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\MedicalHistory.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table, th, td {border: 2px ;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<br><br><br>");
                    sWrite.WriteLine("<table align=center>");
                    sWrite.WriteLine("<col width=500>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=4>");
                    sWrite.WriteLine("" + strclinicname.ToString() + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3>");
                    sWrite.WriteLine("" + strphone.ToString() + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th align=center><br><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5>Medical Certificate </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 > <br><b>Date:</b>&nbsp;&nbsp;  </font> <FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 > " + datePick.Value.ToString("dd-MMM-yyyy") + "</th></tr> " + "</font>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=justify><p style=line-height:3><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=4 >&nbsp; ");
                    sWrite.WriteLine("<b>" + comboBox1.Text + " " + txtname.Text + "</b> " + comboBox2.Text + " under my treatment for <b> " + txtfor.Text + "  </b>from <b>" + dateTimePickefrom.Value.ToString("dd/MM/yyyy") + "</b> to <b>" + dateTimePickerTo.Value.ToString("dd/MM/yyyy") + "</b>. " + txt_he.Text + " " + comboBox5.Text + " advised complete rest for this period. " + txt_she.Text + " " + comboBox7.Text + " medically fit to resume duty from <b> " + dateTimePickerfrmlast.Value.ToString("dd/MM/yyyy") + " " + txtMore.Text + "</b>");
                    sWrite.WriteLine("</font> </p></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 ><br><br><b>Doctor's Name & Signature</b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=right><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 ><br><br><b> " + cmbDoctor.Text + "</b>&nbsp;&nbsp;  </font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.Close();
                    // mail senting...
                    if (Ckbemail.Checked)
                    {
                        string email = "", emailName = "", emailPass = "";
                       // string query = "select email_address,pt_name from tbl_patient where id='" + patient_id + "'";
                        System.Data.DataTable sr = mdl.Get_Patient_Details(patient_id);// db.table(query);
                        if (sr.Rows.Count > 0)
                        {
                            email = sr.Rows[0]["email_address"].ToString();
                            if (email != "")
                            {
                                System.Data.DataTable sms = mdl.send_email();// db.table("select emailName,emailPass from tbl_SmsEmailConfig");
                                if (sms.Rows.Count > 0)
                                {
                                    emailName = sms.Rows[0]["emailName"].ToString();
                                    emailPass = sms.Rows[0]["emailPass"].ToString();
                                    try
                                    {
                                        StreamReader reader = new StreamReader(Apppath + "\\MedicalHistory.html");
                                        string readFile = reader.ReadToEnd();
                                        string StrContent = "";
                                        StrContent = readFile;
                                        MailMessage message = new MailMessage();
                                        message.From = new MailAddress(email);
                                        message.To.Add(email);
                                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                        message.Subject = "Medical Certificate";
                                        message.Body = StrContent.ToString();
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
                                        reader.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email is not Correct", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("From date has to be lesser than to date. Please Check and try again..", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "is")
            {
                comboBox2.SelectedIndex = 0;
                comboBox5.SelectedIndex = 0;
                comboBox7.SelectedIndex = 0;
            }
            else
            {
                comboBox2.SelectedIndex = 1;
                comboBox5.SelectedIndex = 1;
                comboBox7.SelectedIndex = 1;
            }
        }

        private void Ckbemail_CheckedChanged(object sender, EventArgs e)
        {
            if (Ckbemail.Checked)
            {
                BtnPrint.Text = "Send Mail";
            }
            else
            {
                BtnPrint.Text = "Print Priview";
            }
        }
    }
}
