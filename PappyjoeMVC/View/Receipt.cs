using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class Receipt : Form
    {
        public string doctor_id = "";
        public string patient_id = "0", staff_id="";
        string logo_name = "";
        string combo_topmargin = "";
        string combo_leftmargin = "";
        string combo_bottommargin = "";
        string combo_rightmargin = "";
        string combo_paper_size = "";
        string combo_footer_topmargin = "";
        string rich_fullwidth = "";
        string rich_leftsign = "";
        string rich_rightsign = "";
        string patient_details = "";
        string med = "";
        string patient = "";
        string address = "";
        string phone = "";
        string blood = "";
        string gender = "";
        string orientation = "";
        string includeheader = "0";
        string includelogo = "0";
        string printall = "NO"; string payment_date = "", receipt = "";
        System.Drawing.Image logo = null;
        Receipt_controller cntrl=new Receipt_controller();
        Connection db = new Connection();
        string path = "";
        public Receipt()
        {
            InitializeComponent();
        }
        public void SetController(Receipt_controller Controller )
        {
            cntrl = Controller;
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = this.cntrl.check_add_privillege(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='PMT' and Permission='A'");
                    if (int.Parse(id) > 0)
                    {
                        btn_Add.Visible = false;
                    }
                    else
                    {
                        btn_Add.Visible = true;
                    }
                }
                //Privilege ends
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                System.Data.DataTable clinicname = this.cntrl.Get_CompanyNAme();// db.table("select name,path from tbl_practice_details");
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                    string docnam = this.cntrl.Get_DoctorName(doctor_id);
                    if (docnam != "")
                    {
                        toolStriptextdoctor.Text = "Logged In As : " + docnam;
                    }
                    try
                    {
                        path = clinicname.Rows[0]["path"].ToString();
                        //logo = System.Drawing.Image.FromFile(db.server() + path);
                        if (path != "")
                        {
                            if (File.Exists(db.server() + path))
                            {
                                logo_name = "";
                                logo_name = path;//.Substring(8, path.Length - 8);
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
                    catch (Exception ex)
                    {

                    }
                }
                Dgv_payment.Location = new System.Drawing.Point(10, 10);
                Dgv_payment.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                listpatientsearch.Hide();
                System.Data.DataTable pay = this.cntrl.get_total_payment(patient_id);// db.table("select total_payment from tbl_invoices where pt_id='" + patient_id + "'");
                if (pay.Rows.Count > 0)
                {
                    Lab_Due.Text = pay.Rows[0]["total_payment"].ToString() + " due";
                }
                Dgv_payment.Rows.Clear();
                //try
                //{
                //    pictureBox1.Image = Pappyjoe.Properties.Resources.nophoto;
                //}
                //catch { }
                System.Data.DataTable pat = this.cntrl.Get_pat_iDName(patient_id);// db.table("select pt_name,pt_id from tbl_patient where id='" + patient_id + "'");
                linkLabel_id.Text = pat.Rows[0]["pt_id"].ToString();
                linkLabel_Name.Text = pat.Rows[0]["pt_name"].ToString();
                Dgv_payment.ColumnCount = 6;
                Dgv_payment.RowCount = 0;
                Dgv_payment.ColumnHeadersVisible = false;
                Dgv_payment.RowHeadersVisible = false;
                Dgv_payment.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                Dgv_payment.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dgv_payment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dgv_payment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dgv_payment.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                Dgv_payment.Columns[0].Width = 150;
                Dgv_payment.Columns[1].Width = 150;
                Dgv_payment.Columns[2].Width = 250;
                Dgv_payment.Columns[3].Width = 250;
                Dgv_payment.Columns[5].Width = 20;
                int j = 0;
                System.Data.DataTable Payment = this.cntrl.get_paymentDate(patient_id);// db.table("select  distinct(payment_date) from tbl_payment where pt_id='" + patient_id + "'AND payment_date!='' order by payment_date desc");
                for (int i = 0; i < Payment.Rows.Count; i++)
                {
                    int l = 0;
                    Dgv_payment.Rows.Add(String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(Payment.Rows[i]["payment_date"].ToString())), "", "", "", "0", "");
                    Dgv_payment.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                    Dgv_payment.Rows[j].Cells[0].Style.ForeColor = Color.DarkGreen;
                    Dgv_payment.Rows[j].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                    j = j + 1;
                    Dgv_payment.Rows.Add("RECEIPT NUMBER", "INVOICES", "TREATMENTS", "AMOUNT PAID", "", "");
                    Dgv_payment.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    Dgv_payment.Rows[j].Cells[0].Style.ForeColor = Color.White;
                    Dgv_payment.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    Dgv_payment.Rows[j].Cells[1].Style.ForeColor = Color.White;
                    Dgv_payment.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    Dgv_payment.Rows[j].Cells[2].Style.ForeColor = Color.White;
                    Dgv_payment.Rows[j].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    Dgv_payment.Rows[j].Cells[3].Style.ForeColor = Color.White;
                    Dgv_payment.Rows[j].Cells[0].Style.BackColor = Color.DarkGray;
                    Dgv_payment.Rows[j].Cells[1].Style.BackColor = Color.DarkGray;
                    Dgv_payment.Rows[j].Cells[2].Style.BackColor = Color.DarkGray;
                    Dgv_payment.Rows[j].Cells[3].Style.BackColor = Color.DarkGray;
                    Dgv_payment.Rows[j].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                    string receipt = "";
                    System.Data.DataTable Payments = this.cntrl.payment_details(Convert.ToDateTime (Payment.Rows[i]["payment_date"].ToString()).ToString("yyyy-MM-dd"), patient_id);// db.table("select receipt_no,amount_paid,invoice_no,procedure_name from tbl_payment where payment_date='" + Convert.ToDateTime(Payment.Rows[i]["payment_date"].ToString()).ToString("yyyy-MM-dd") + "' and pt_id='" + patient_id + "'");
                    for (int k = 0; k < Payments.Rows.Count; k++)
                    {
                        if (l >= 1)
                        {
                            receipt = Payments.Rows[k]["receipt_no"].ToString();
                            if (receipt == Payments.Rows[k - 1]["receipt_no"].ToString())
                            {
                                Dgv_payment.Rows.Add("", Payments.Rows[k]["invoice_no"].ToString(), Payments.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(Payments.Rows[k]["amount_paid"].ToString())), "", "");
                                j = j + 1;
                                l = l + 1;
                                Dgv_payment.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                                Dgv_payment.Rows[j].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[2].Style.ForeColor = Color.Black;
                                Dgv_payment.Rows[j].Cells[0].Style.ForeColor = Color.Red;
                                Dgv_payment.Rows[j].Cells[1].Style.ForeColor = Color.DodgerBlue;
                                Dgv_payment.Rows[j].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                            }
                            else
                            {
                                Dgv_payment.Rows.Add("", "", "", "", "", "");
                                j = j + 1;
                                Dgv_payment.Rows.Add(Payments.Rows[k]["receipt_no"].ToString(), Payments.Rows[k]["invoice_no"].ToString(), Payments.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(Payments.Rows[k]["amount_paid"].ToString())), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(Payment.Rows[i]["payment_date"].ToString())), "");
                                Dgv_payment.Rows[j].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                                j = j + 1;
                                l = l + 1;
                                Dgv_payment.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                                Dgv_payment.Rows[j].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                                Dgv_payment.Rows[j].Cells[2].Style.ForeColor = Color.Black;
                                Dgv_payment.Rows[j].Cells[0].Style.ForeColor = Color.Red;
                                Dgv_payment.Rows[j].Cells[1].Style.ForeColor = Color.DodgerBlue;
                                Dgv_payment.Rows[j].Cells[5].Value = PappyjoeMVC.Properties.Resources.Bill;
                            }
                        }
                        else
                        {
                            Dgv_payment.Rows.Add(Payments.Rows[k]["receipt_no"].ToString(), Payments.Rows[k]["invoice_no"].ToString(), Payments.Rows[k]["procedure_name"].ToString(), String.Format("{0:C}", Convert.ToDecimal(Payments.Rows[k]["amount_paid"].ToString())), String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(Payment.Rows[i]["payment_date"].ToString())), "");
                            j = j + 1;
                            l = l + 1;
                            Dgv_payment.Rows[j].Cells[3].Style.ForeColor = Color.Red;
                            Dgv_payment.Rows[j].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                            Dgv_payment.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                            Dgv_payment.Rows[j].Cells[0].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                            Dgv_payment.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                            Dgv_payment.Rows[j].Cells[2].Style.ForeColor = Color.Black;
                            Dgv_payment.Rows[j].Cells[0].Style.ForeColor = Color.Red;
                            Dgv_payment.Rows[j].Cells[1].Style.ForeColor = Color.DodgerBlue;
                            Dgv_payment.Rows[j].Cells[5].Value = PappyjoeMVC.Properties.Resources.Bill;
                        }
                    }
                    Dgv_payment.Rows.Add("", "", "", "", "", "");
                    Dgv_payment.Rows[j + 1].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                    j = j + 2;
                }

                if (Dgv_payment.Rows.Count <= 0)
                {
                    Lab_Msg.Show();
                    Lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                else
                {
                    Lab_Msg.Hide();
                    Lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                btn_Add.Show();
                Dgv_payment.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable print = this.cntrl.get_printSettings();// db.table("select * from tbl_receipt_printsettings");
                if (print.Rows.Count > 0)
                {
                    combo_topmargin = print.Rows[0][4].ToString();
                    combo_leftmargin = print.Rows[0][5].ToString();
                    combo_bottommargin = print.Rows[0][6].ToString();
                    combo_rightmargin = print.Rows[0][7].ToString();
                    combo_paper_size = print.Rows[0][1].ToString();
                    combo_footer_topmargin = print.Rows[0][22].ToString();
                    rich_fullwidth = print.Rows[0][23].ToString();
                    rich_leftsign = print.Rows[0][24].ToString();
                    rich_rightsign = print.Rows[0][25].ToString();

                    patient_details = print.Rows[0][14].ToString();
                    med = print.Rows[0][15].ToString();
                    patient = print.Rows[0][16].ToString();
                    address = print.Rows[0][17].ToString();
                    phone = print.Rows[0][18].ToString();
                    blood = print.Rows[0][20].ToString();
                    gender = print.Rows[0][21].ToString();
                    orientation = print.Rows[0][2].ToString();
                    includeheader = print.Rows[0]["include_header"].ToString();
                    includelogo = print.Rows[0]["include_logo"].ToString();
                }

                printall = "NO";
                print_html();
            }
            catch
            {
                MessageBox.Show("Printing Error..", "Print error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var form2 = new Add_Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void print_html()
        {

            try
            {

                System.Data.DataTable dtp = this.cntrl.get_company_details();// db.table("select * from tbl_practice_details");
                System.Data.DataTable dt1 = this.cntrl.Get_Patient_Details(patient_id);// db.table("select * from tbl_patient where id='" + patient_id + "'");
                string clinicn = "";
                string Clinic = "";
                clinicn = dtp.Rows[0][1].ToString();
                Clinic = clinicn.Replace("¤", "'");
                string doctorName = "";
                string streetaddress = "";
                string str_locality = "";
                string contact_no = "";
                string str_pincode = "";
                string str_email = "";
                string str_website = "";
                string doctor = this.cntrl.Get_DoctorName(doctor_id);// db.table("select doctor_name from tbl_doctor where id= '" + doctor_id.ToString() + "'");
                if (doctor!="")
                {
                    doctorName = doctor;
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                }
                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.cntrl.receipt_printSettings();// db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign from  tbl_receipt_printsettings");
                if (print.Rows.Count > 0)
                {
                    header1 = print.Rows[0]["header"].ToString();
                    header2 = print.Rows[0]["left_text"].ToString();
                    header3 = print.Rows[0]["right_text"].ToString();
                    strfooter1 = print.Rows[0]["fullwidth_context"].ToString();
                    strfooter2 = print.Rows[0]["left_sign"].ToString();
                    strfooter3 = print.Rows[0]["right_sign"].ToString();
                }



                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\p.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br>");


                if (includeheader == "1")
                {
                    if (includelogo == "1")
                    {
                        if (logo != null || logo_name != "")
                        {
                            string Appath = System.IO.Directory.GetCurrentDirectory();
                            if (File.Exists(Appath + "\\" + logo_name))
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
                                sWrite.WriteLine("<td width='588' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                                sWrite.WriteLine("</table>");
                            }
                            else
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");

                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                                sWrite.WriteLine("</table>");
                            }
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");

                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                        sWrite.WriteLine("</table>");
                    }
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5></font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                    sWrite.WriteLine("</table>");
                }

                string sexage = "";
                int Dexist = 0;
                string address = "";
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
                string strsql = "";

                if (printall == "YES")
                {
                    strsql = "select * from tbl_payment where pt_id='" + patient_id + "'";
                }
                else
                {
                    strsql = "select * from tbl_payment where payment_date='" + payment_date + "' and pt_id='" + patient_id + "' and receipt_no='" + receipt + "'";
                }
                System.Data.DataTable dt_cf = db.table(strsql);
                var dateTimeNow = DateTime.Now;
                var tdate = dateTimeNow.ToShortDateString();
                if (dt_cf.Rows.Count > 0)
                {
                    if (dt_cf.Rows[0]["payment_date"].ToString() != null)
                    { tdate = dt_cf.Rows[0]["payment_date"].ToString(); }
                    else
                        tdate = null;
                    sWrite.WriteLine("<br>");
                    sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td><FONT COLOR=black FACE='Geneva, Arial' SIZE=5>Payment</FONT></td>");
                    sWrite.WriteLine("<td width=450px></td>");
                    if (printall == "YES")
                    {
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Now.ToString("dd MMM yyyy") + "</font></td>");
                    }
                    else
                    {
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + Convert.ToDateTime(tdate).ToString("dd MMM yyyy") + "</font></td>");
                    }
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<table   align='center' style='width:700px;border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td width='36' height='30' align='center'  bgcolor='#dcdcdc'><FONT COLOR=black FACE=' Arial' SIZE=3>Sl</font></td>");
                    sWrite.WriteLine("<td width='135' align='center'  bgcolor='#dcdcdc' height='30'><FONT COLOR=black FACE=' Arial' SIZE=3>Receipt Number</font></td>");
                    sWrite.WriteLine("<td width='147' align='center' bgcolor='#dcdcdc'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>Invoice Number</font></td>");
                    sWrite.WriteLine("<td width='259' align='left' bgcolor='#dcdcdc'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>Procedure Name</font></td>");
                    sWrite.WriteLine("<td width='99' align='right' bgcolor='#dcdcdc'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>Amount Paid</font></td>");
                    sWrite.WriteLine("</tr>");
                    strsql = "";
                    if (printall == "YES")
                    {
                        strsql = "select receipt_no,amount_paid,invoice_no,procedure_name,payment_date from tbl_payment where pt_id='" + patient_id + "' order by payment_date";
                    }
                    else
                    {
                        strsql = "select receipt_no,amount_paid,invoice_no,procedure_name,payment_date from tbl_payment where payment_date='" + payment_date + "' and pt_id='" + patient_id + "' and receipt_no='" + receipt + "' order by payment_date";
                    }
                    System.Data.DataTable dt_payment = db.table(strsql);
                    decimal total = 0;
                    for (int i = 0; i < dt_payment.Rows.Count; i++)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='center'  height='30'><FONT COLOR=black FACE=' Arial' SIZE=2>" + (i + 1) + " </font></td>");
                        sWrite.WriteLine("<td align='center'   width='135'  ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + dt_payment.Rows[i]["receipt_no"].ToString() + " </font></td>");
                        sWrite.WriteLine("<td align='center'   width='147'><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + dt_payment.Rows[i]["invoice_no"].ToString() + " </font></td>");
                        sWrite.WriteLine("<td align='left'   width='259'><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + dt_payment.Rows[i]["procedure_name"].ToString() + " </font></td>");
                        sWrite.WriteLine("<td align='right'   width='99'><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(dt_payment.Rows[i]["amount_paid"].ToString())) + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        total = total + decimal.Parse(dt_payment.Rows[i]["amount_paid"].ToString());
                    }
                    sWrite.WriteLine("<tr><td align='left' colspan=5><hr/></td></tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td></td>");
                    sWrite.WriteLine("<td></td>");
                    sWrite.WriteLine("<td></td>");
                    sWrite.WriteLine("<td></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=3><b>" + String.Format("{0:C}", decimal.Parse(total.ToString())) + " </b></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr><td align='right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>(<i>" + NumWordsWrapper(double.Parse(total.ToString())) + "</i>)</fount> </td></tr>");
                    sWrite.WriteLine("</table>");
                }
                //footer
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter1 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter2 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter3 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\p.html");
            }
            catch (Exception ex)
            {

            }
        }

        private void Dgv_payment_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = Dgv_payment.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverColumn = Dgv_payment.HitTest(e.X, e.Y).ColumnIndex;
            if (currentMouseOverRow >= 0)
            {
                if (currentMouseOverColumn == 5)
                {
                    if (Dgv_payment.Rows[currentMouseOverRow].Cells[4].Value.ToString() != "" && Dgv_payment.Rows[currentMouseOverRow].Cells[4].Value.ToString() != "0")
                    {
                        payment_date = Convert.ToDateTime(Dgv_payment.Rows[currentMouseOverRow].Cells[4].Value.ToString()).ToString("yyyy-MM-dd");
                        receipt = Dgv_payment.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                        contextMenuStrip1.Show(Dgv_payment, new System.Drawing.Point(915 - 120, e.Y));
                    }
                }
            }
        }

        private void Lab_AllPatients_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id; ;
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

        private void Lab_Appointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Profile_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_VitalSigns_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            //Vital_Signs_controller controller = new Vital_Signs_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Treatment_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Finished_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Attachmnt_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Invoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Payment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
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
                    var form2 = new Practice_Details();
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
                var form2 = new Practice_Details();
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
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Ledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Clinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void Lab_Prescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Prescription_Show_controller controller = new Prescription_Show_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labl_Lab_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.LabWorks();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        static String NumWordsWrapper(double n)
        {
            string words = "";
            double intPart;
            double decPart = 0;
            if (n == 0)
                return "zero";
            try
            {
                string[] splitter = n.ToString().Split('.');
                intPart = double.Parse(splitter[0]);
                decPart = double.Parse(splitter[1]);
            }
            catch
            {
                intPart = n;
            }
            words = NumWords(intPart);
            if (decPart > 0)
            {
                if (words != "")
                    words += " and ";
                int counter = decPart.ToString().Length;
                switch (counter)
                {
                    case 1: words += NumWords(decPart) + " tenths"; break;
                    case 2: words += NumWords(decPart) + " hundredths"; break;
                    case 3: words += NumWords(decPart) + " thousandths"; break;
                    case 4: words += NumWords(decPart) + " ten-thousandths"; break;
                    case 5: words += NumWords(decPart) + " hundred-thousandths"; break;
                    case 6: words += NumWords(decPart) + " millionths"; break;
                    case 7: words += NumWords(decPart) + " ten-millionths"; break;
                }
            }
            return words;
        }

        static String NumWords(double n)
        {
            string[] numbersArr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tensArr = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
            // string[] suffixesArr = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
            string[] suffixesArr = new string[] { "lakhs", "Crore", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
            string words = "";
            bool tens = false;
            if (n < 0)
            {
                words += "negative ";
                n *= -1;
            }
            int power = (suffixesArr.Length + 1) * 3;
            while (power > 3)
            {
                double pow = Math.Pow(10, power);
                if (n >= pow)
                {
                    if (n % pow > 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1] + ", ";
                    }
                    else if (n % pow == 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1];
                    }
                    n %= pow;
                }
                power -= 3;
            }
            if (n >= 1000)
            {
                if (n % 1000 > 0) words += NumWords(Math.Floor(n / 1000)) + " thousand, ";
                else words += NumWords(Math.Floor(n / 1000)) + " thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    words += NumWords(Math.Floor(n / 100)) + " hundred";
                    n %= 100;
                }
                if ((int)n / 10 > 1)
                {
                    if (words != "")
                        words += " ";
                    words += tensArr[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }
                if (n < 20 && n > 0)
                {
                    if (words != "" && tens == false)
                        words += " ";
                    words += (tens ? "-" + numbersArr[(int)n - 1] : numbersArr[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }
            return words;
        }
    }
}
