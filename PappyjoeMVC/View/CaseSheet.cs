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
    public partial class CaseSheet : Form
    {
        public string patient_id = "";
        public string doctor_id = "0"; String val = null;
        int c = 0, o = 0, inves = 0, d = 0, k = 0, p = 0, pa = 0, patientnotes = 0;
        Common_model mdl = new Common_model(); Casesheet_model model = new Casesheet_model();
        string path = "";
        string logo_name = "";
        public CaseSheet()
        {
            InitializeComponent();
            btnback.Visible = false;
            Chkbcheifcomp.Checked = true;
            chkbdiagnosis.Checked = true;
            chkBinvestigation.Checked = true;
            chkbobservation.Checked = true;
            chkbcompleted.Checked = true;
            chkprescription.Checked = true;
            chkamount.Checked = true;
            chkBnote.Checked = true;
            checkBoxcasesheet.Checked = true;
            checkBoxclinicname.Checked = true;
            checkBoxdocname.Checked = true;
            checkBoxpatientdetails.Checked = true;
        }
        public void checkboxbind()
        {
            System.Data.DataTable dt2 = mdl.get_all_doctorname();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                checkedListBoxdoc.Items.Add(dt2.Rows[i]["doctor_name"].ToString());
            }
        }

        private void lnkladdmore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelprintpreview.Visible = false;
            btnback.Visible = true;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            panelprintpreview.Visible = true;
            btnback.Visible = false;
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            mprintosave();
        }

        private void fromdate()
        {
            System.Data.DataTable dt7 = mdl.get_patient_date(patient_id);
            string aa = dt7.Rows[0]["date"].ToString();
            if (dt7.Rows[0]["date"].ToString() != "")
            {
                dtpfrom.Show();
                dtpfrom.Value = DateTime.Parse(DateTime.Parse(dt7.Rows[0]["date"].ToString()).ToString());
            }
        }

        private void CaseSheet_Load(object sender, EventArgs e)
        {
            fromdate();
            checkboxbind();
        }

        private void Ckbemail_CheckStateChanged(object sender, EventArgs e)
        {
            if (Ckbemail.Checked)
            {
                BtnPrintPreview.Text = "SENT MAIL";
            }
            else
            {
                BtnPrintPreview.Text = "PRINT PREVIEW";
            }
        }

        private void checkBoxreview_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxreview.Checked == true)
            {
                DtpReview.Enabled = true;
                txtTime.Enabled = true;
            }
            else
            {
                DtpReview.Enabled = false;
                txtTime.Enabled = false;
            }
        }

        private void ChkDate_MouseClick(object sender, MouseEventArgs e)//
        {
            if (ChkDate.Checked == true)
            {
                dtpfrom.Enabled = false;
                dTPToDate.Enabled = false;
                label17.Enabled = false;
                label18.Enabled = false;
            }
            else
            { 
                dtpfrom.Enabled = true;
                dTPToDate.Enabled = true;
                label17.Enabled = true;
                label18.Enabled = true;
            }
        }
        public void mprintosave()
        {
            try
            {
                doctor();
                string startDateTime = dtpfrom.Value.ToString("yyyy-MM-dd HH:mm");
                string startDateTime1 = dTPToDate.Value.ToString("yyyy-MM-dd HH:mm");
                string date2d = dTPToDate.Value.ToString("MM/dd/yyyy");
               string doct = mdl.Get_DoctorName(doctor_id);
                string doctor_name = "";
                if (doct!="")
                {
                    doctor_name = doct;
                }
                System.Data.DataTable patient = mdl.Get_Patient_Details(patient_id);
                string Pname = "", Gender = "", address = "", city = "", DOA = "", age = "", Mobile = "";
                string P_id = "";
                if (patient.Rows.Count > 0)
                {
                    Pname = patient.Rows[0]["pt_name"].ToString();
                    Gender = patient.Rows[0]["gender"].ToString();
                    address = patient.Rows[0]["street_address"].ToString();
                    city = patient.Rows[0]["city"].ToString();
                    if (address != "")
                    {
                        if (city != "")
                        {
                            address = address + " , " + patient.Rows[0]["city"].ToString();
                        }
                    }
                    else
                    {
                        address = patient.Rows[0]["city"].ToString();
                    }

                    Mobile = patient.Rows[0]["primary_mobile_number"].ToString();
                    DOA = DateTime.Parse(patient.Rows[0]["Visited"].ToString()).ToString("dd/MM/yyyy");
                    P_id = patient.Rows[0]["pt_id"].ToString();
                    if (patient.Rows[0]["Age"].ToString() != "")
                    {
                        age = "/" + patient.Rows[0]["Age"].ToString() + " Yrs";
                    }
                }
                string str_name = "";
                string str_street_address = "";
                string str_locality = "";
                string str_pincode = "";
                string str_contact_no = "";
                string str_email = "";
                string str_website = "";
                //string sqlstring = "";
                int datecheck = 0;
                System.Data.DataTable dtp = mdl.get_company_details();
                if (dtp.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = dtp.Rows[0]["name"].ToString();
                    str_name = clinicn.Replace("¤", "'");
                    str_street_address = dtp.Rows[0]["street_address"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    str_contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                    path = dtp.Rows[0]["path"].ToString();
                    logo_name = "";
                    logo_name = path;
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\Casesheet.html");
                c = 0; o = 0; inves = 0; d = 0; k = 0; p = 0; pa = 0; patientnotes = 0;
                if (ChkDate.Checked == true)
                {
                    datecheck = 0;
                }
                else
                {
                    datecheck = 1;
                }
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br><br><br>");// style='width:100px;height:100px;'
                if (checkBoxclinicname.Checked)
                {
                    if (logo_name != "")
                    {
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "' style='width:100px;height:100px;></td>  ");
                        sWrite.WriteLine("<td width='200' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5><b>&nbsp;" + str_name.ToString() + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;&nbsp;" + str_street_address.ToString() + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;&nbsp;" + str_contact_no.ToString() + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5><b>&nbsp;" + str_name.ToString() + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;" + str_street_address.ToString() + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2><b>&nbsp;" + str_contact_no.ToString() + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>"); 
                        sWrite.WriteLine("</table>");
                    }
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=4></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th></tr>");
                    sWrite.WriteLine("</table>");
                }
                if (checkBoxcasesheet.Checked)
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr><th align='center'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5>CASE SHEET </font></th></tr>");
                    sWrite.WriteLine("</table>");
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                if (checkBoxdocname.Checked)
                {
                    sWrite.WriteLine("<tr height='40px'>");
                    sWrite.WriteLine("<td align='left' width='500px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>Consulted by :  " + doctor_name.ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("</tr>");
                }
                else
                {
                    sWrite.WriteLine("<tr height='40px'>");
                    sWrite.WriteLine("<td align='left' width='400px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("<td align='left' width='400px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                    sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5></font></th></tr>");
                }
                if (checkBoxpatientdetails.Checked)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>Name :<b>" + Pname.ToString() + " </b>(<i>" + P_id + "/" + Gender.ToString() + age.ToString() + "</i>) </font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>DOA  : " + DOA + "  </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>Address : " + address.ToString() + "</font></td>");
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>Discharge Date : " + DtpDischargeDate.Value.ToString("dd/MM/yyyy") + "</font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine(" <tr>");
                    sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>Mobile No: " + Mobile.ToString() + "</font></td>");
                    sWrite.WriteLine(" </tr>");
                }
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td></td></tr>");
                sWrite.WriteLine("</table>");
                if (chkbvitalsign.Checked)
                {
                    System.Data.DataTable vital = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        vital = model.vitalSign_btwn_date(patient_id, startDateTime, startDateTime1);
                    }
                    else
                    {
                        vital = model.vitalSign(patient_id);
                    }
                    if (vital.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;' >");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999' colspan='3'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3>&nbsp;VITAL SIGNS</font></td>");
                        sWrite.WriteLine("</tr>");
                        int i = 0;
                        for (int j = 0; j < vital.Rows.Count; j++)
                        {
                            sWrite.WriteLine("<tr >");
                            sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(vital.Rows[j]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            if (vital.Rows[j]["pulse"].ToString() != "")
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;PULSE</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + vital.Rows[j]["pulse"].ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                            if (vital.Rows[j]["temp"].ToString() != "")
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;TEMPERATURE</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + vital.Rows[j]["temp"].ToString() + " ( " + vital.Rows[j]["temp_type"].ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                            if (vital.Rows[j]["bp_syst"].ToString() != "")
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;BLOOD PRESSURE ( SYSTOLIC ) </font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + vital.Rows[j]["bp_syst"].ToString() + " ( " + vital.Rows[j]["bp_type"].ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                            if (vital.Rows[j]["bp_dia"].ToString() != "")
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;BLOOD PRESSURE ( DIASTOLIC ) : </font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + vital.Rows[j]["bp_dia"].ToString() + " ( " + vital.Rows[j]["bp_type"].ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                            if (vital.Rows[j]["weight"].ToString() != "")
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;WEIGHT </font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + vital.Rows[j]["weight"].ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                            if (vital.Rows[j]["resp"].ToString() != "")
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;RESPIRATORY RATE</font></td>");
                                sWrite.WriteLine("<td style='vertical-align: top;'  align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + vital.Rows[j]["resp"].ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                //chief_compaints
                if (Chkbcheifcomp.Checked)
                {
                    System.Data.DataTable dt_cf_Complaints = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_cf_Complaints=model.complaints_btwn_date(patient_id, startDateTime, startDateTime1);
                    }
                    else
                    {
                        dt_cf_Complaints = model.complaints(patient_id);
                    }
                    if (dt_cf_Complaints.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;' >");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='100px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;DATE</font></td>");
                        sWrite.WriteLine("<td align='left' width='5px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("<td align='left' width='595px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;COMPLAINTS</font></td>");
                        sWrite.WriteLine("</tr>");
                        string ch_date = Convert.ToString("03/30/2009");
                        while (c < dt_cf_Complaints.Rows.Count)
                        {
                            sWrite.WriteLine("<tr height='30px'>");
                            if (ch_date == Convert.ToString(DateTime.Parse(dt_cf_Complaints.Rows[c]["date"].ToString()).ToString("dd/MM/yyyy")))
                            {
                                sWrite.WriteLine("<td style='vertical-align: top;'align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;</font></th>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td style='vertical-align: top;'align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(dt_cf_Complaints.Rows[c]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></th>");
                            }
                            sWrite.WriteLine("<td style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>●</font></th>");
                            sWrite.WriteLine("<td style='vertical-align: top;' align='justify'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_cf_Complaints.Rows[c]["complaint_id"].ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            ch_date = Convert.ToString(DateTime.Parse(dt_cf_Complaints.Rows[c]["date"].ToString()).ToString("dd/MM/yyyy"));
                            c++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3></font></th>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                //OBSERVATIONS
                if (chkbobservation.Checked)
                {
                    System.Data.DataTable dt_cf_observe = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_cf_observe=model. observation_btwn_date(patient_id, startDateTime, startDateTime1);
                    }
                    else
                    {
                        dt_cf_observe = model.observation(patient_id);
                    }
                    if (dt_cf_observe.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;' >");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='100px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;DATE</font></td>");
                        sWrite.WriteLine("<td align='left' width='5px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("<td align='left' width='595px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;OBSERVATIONS</font></td>");
                        sWrite.WriteLine("</tr>");
                        string ch_date = Convert.ToString("03/30/2009");
                        while (o < dt_cf_observe.Rows.Count)
                        {
                            sWrite.WriteLine("<tr height='30px'>");
                            if (ch_date == Convert.ToString(DateTime.Parse(dt_cf_observe.Rows[o]["date"].ToString()).ToString("dd/MM/yyyy")))
                            {
                                sWrite.WriteLine("<td style='vertical-align: top;' align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></th>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td style='vertical-align: top;' align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(dt_cf_observe.Rows[o]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></th>");
                            }
                            sWrite.WriteLine("<td style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>●</font></th>");
                            sWrite.WriteLine("<td style='vertical-align: top;' align='left'  ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + dt_cf_observe.Rows[o]["observation_id"].ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            ch_date = Convert.ToString(DateTime.Parse(dt_cf_observe.Rows[o]["date"].ToString()).ToString("dd/MM/yyyy"));
                            o++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                //investigation 
                if (chkBinvestigation.Checked)
                {
                    System.Data.DataTable dt_cf_investigation = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_cf_investigation=model.investgstion_btwn_date(patient_id, startDateTime, startDateTime1);
                    }
                    else
                    {
                        dt_cf_investigation=model. investgation(patient_id); 
                    }
                   
                    if (dt_cf_investigation.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='100px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;DATE</font></td>");
                        sWrite.WriteLine("<td align='left' width='5px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> </font></td>");
                        sWrite.WriteLine("<td align='left' width='595px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;INVESTIGATIONS</font></td>");
                        sWrite.WriteLine("</tr>");
                        string ch_date = Convert.ToString("03/30/2009");
                        while (inves < dt_cf_investigation.Rows.Count)
                        {
                            sWrite.WriteLine("<tr  height='30px'>");
                            if (ch_date == Convert.ToString(DateTime.Parse(dt_cf_investigation.Rows[inves]["date"].ToString()).ToString("dd/MM/yyyy")))
                            {
                                sWrite.WriteLine("<td align='left'  style='vertical-align: top;' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></td>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td align='left'  style='vertical-align: top;' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(dt_cf_investigation.Rows[inves]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                            }
                            sWrite.WriteLine("<td style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>●</font></th>");
                            sWrite.WriteLine("<td align='left'  style='vertical-align: top;' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_cf_investigation.Rows[inves]["investigation_id"].ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            ch_date = Convert.ToString(DateTime.Parse(dt_cf_investigation.Rows[inves]["date"].ToString()).ToString("dd/MM/yyyy"));
                            inves++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                // diagnosis
                if (chkbdiagnosis.Checked)
                {
                    System.Data.DataTable dt_cf_diagnosis = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_cf_diagnosis = model.diagnosis_btwn_date(patient_id, startDateTime, startDateTime1);
                    }
                    else
                    {
                        dt_cf_diagnosis=model.diagnosis(patient_id);
                    }
                    if (dt_cf_diagnosis.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;' >");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='100px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;DATE</font></td>");
                        sWrite.WriteLine("<td align='left' width='5px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("<td align='left' width='595px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;DIAGNOSIS</font></td>");
                        sWrite.WriteLine("</tr>");
                        string ch_date = Convert.ToString("03/30/2009");
                        while (d < dt_cf_diagnosis.Rows.Count)
                        {
                            sWrite.WriteLine("<tr  height='30px'>");
                            if (ch_date == Convert.ToString(DateTime.Parse(dt_cf_diagnosis.Rows[d]["date"].ToString()).ToString("dd/MM/yyyy")))
                            {
                                sWrite.WriteLine("<td align='left'  style='vertical-align: top;' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></td>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td align='left'  style='vertical-align: top;' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(dt_cf_diagnosis.Rows[d]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                            }
                            sWrite.WriteLine("<td style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>●</font></td>");
                            sWrite.WriteLine("<td align='left'  style='vertical-align: top;' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_cf_diagnosis.Rows[d]["diagnosis_id"].ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            ch_date = Convert.ToString(DateTime.Parse(dt_cf_diagnosis.Rows[d]["date"].ToString()).ToString("dd/MM/yyyy"));
                            d++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                //Notes 
                if (chkBnote.Checked)
                {
                    System.Data.DataTable dt_cf_notes = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_cf_notes = model.notes_btwn_date(patient_id, startDateTime, startDateTime1);
                    }
                    else
                    {
                        dt_cf_notes = model.notes(patient_id);
                    }
                    if (dt_cf_notes.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='100px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;DATE</font></td>");
                        sWrite.WriteLine("<td align='left' width='5px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> </font></td>");
                        sWrite.WriteLine("<td align='left' width='595px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;NOTES</font></td>");
                        sWrite.WriteLine("</tr>");
                        string ch_date = Convert.ToString("03/30/2009");
                        while (patientnotes < dt_cf_notes.Rows.Count)
                        {
                            sWrite.WriteLine("<tr  height='30px'>");
                            if (ch_date == Convert.ToString(DateTime.Parse(dt_cf_notes.Rows[patientnotes]["date"].ToString()).ToString("dd/MM/yyyy")))
                            {
                                sWrite.WriteLine("<td align='left' style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2></font></td>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td align='left' style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(dt_cf_notes.Rows[patientnotes]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></th>");
                            }
                            sWrite.WriteLine("<td style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>●</font></th>");
                            sWrite.WriteLine("<td align='left' style='vertical-align: top;'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_cf_notes.Rows[patientnotes]["note_name"].ToString() + "</font></th>");
                            sWrite.WriteLine("</tr>");
                            ch_date = Convert.ToString(DateTime.Parse(dt_cf_notes.Rows[patientnotes]["date"].ToString()).ToString("dd/MM/yyyy"));
                            patientnotes++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                //Treatment
                if (chkbcompleted.Checked)
                {
                    System.Data.DataTable dt_Treat_Plan = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_Treat_Plan = model.treatment_btewn_date( patient_id,startDateTime,startDateTime1);
                    }
                    else
                    {
                        dt_Treat_Plan = model.treatment(patient_id);
                    }
                    if (dt_Treat_Plan.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999' colspan='3'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;TREATMENT PLAN</font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>DATE</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='300px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>TREATMENT</b></font></td>");
                        sWrite.WriteLine("<td align='left'width='300px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>NOTES</b> </font></td>");
                        sWrite.WriteLine("</tr>");
                        while (k < dt_Treat_Plan.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + DateTime.Parse(dt_Treat_Plan.Rows[k]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                            sWrite.WriteLine("<td align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp" + dt_Treat_Plan.Rows[k]["procedure_name"].ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[k]["note"].ToString() + "  " + dt_Treat_Plan.Rows[k]["tooth"].ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            k++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                // Prescription..............................................
                if (chkprescription.Checked)
                {
                    System.Data.DataTable dt_prescription = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_prescription= model.prescription_btwn_date(patient_id,startDateTime,startDateTime1);
                    }
                    else
                    {
                        dt_prescription = model.prescription(patient_id);
                    }
                    if (dt_prescription.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999' colspan='5'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3> &nbsp;PRESCRIPTION</font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr height='30px'>");
                        sWrite.WriteLine("<td align='left' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>DATE</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>DRUGNAME</b></font></td>");
                        sWrite.WriteLine("<td align='center' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>STRENGTH</b></font></td>");
                        sWrite.WriteLine("<td align='center' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>FREEQUENCY</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>INSTRUCTIONS</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        while (p < dt_prescription.Rows.Count)
                        {
                            string morning = "";
                            string noon = "";
                            string night = "";
                            string a1 = dt_prescription.Rows[p]["morning"].ToString();
                            string[] b1 = a1.Split('.');
                            int right1 = int.Parse(b1[1]);
                            morning = Convert.ToString(int.Parse(b1[0]));
                            if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                            string a2 = dt_prescription.Rows[p]["noon"].ToString();
                            string[] b2 = a2.Split('.');
                            int right2 = int.Parse(b2[1]);
                            noon = Convert.ToString(int.Parse(b2[0]));
                            if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                            string a3 = dt_prescription.Rows[p]["night"].ToString();
                            string[] b3 = a3.Split('.');
                            int right3 = int.Parse(b3[1]);
                            night = Convert.ToString(int.Parse(b3[0]));
                            if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + DateTime.Parse(dt_prescription.Rows[p]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                            sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_prescription.Rows[p]["drug_name"].ToString() + "</font><i></font><FONT COLOR=black FACE='Geneva, Arial' SIZE=1>&nbsp;[" + dt_prescription.Rows[p]["drug_type"].ToString() + "]</font></i></td>");
                            sWrite.WriteLine("<td align='center' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_prescription.Rows[p]["strength"].ToString() + "" + dt_prescription.Rows[p]["strength_gr"].ToString() + "</font></td>");
                            sWrite.WriteLine("<td align='center' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + morning + "-" + noon + "-" + night + "</font></th>");
                            sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_prescription.Rows[p]["duration_unit"].ToString() + " " + dt_prescription.Rows[p]["duration_period"].ToString() + " " + dt_prescription.Rows[p]["add_instruction"].ToString() + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            p++;
                        }
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                // payment
                if (chkamount.Checked)
                {
                    System.Data.DataTable dt_prescription1 = new System.Data.DataTable();
                    if (datecheck == 1)
                    {
                        dt_prescription1 = model.payment_betwn_date(patient_id, startDateTime, startDateTime1); 
                    }
                    else
                    {
                        dt_prescription1 = model.payment(patient_id);
                    }
                    decimal total = 0;
                    if (dt_prescription1.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;' >");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999' colspan='5'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;LEDGER</font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr height='30px'>");
                        sWrite.WriteLine("<td align='left'  width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>DATE</b></font></td>");
                        sWrite.WriteLine("<td align='left'  width='250px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>PROCEDURE NAME</b></font></td>");
                        sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>INVOICE</b></font></td>");
                        sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>PAID</b></font></td>");
                        sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2><b>DUE</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        decimal cost = 0; int qty = 0; decimal paid = 0;
                        decimal discount = 0;
                        decimal totCost = 0;
                        decimal totalkk = 0;
                        decimal totalsubst = 0;
                        decimal totalpaid = 0;
                        string strdis = "";
                        while (pa < dt_prescription1.Rows.Count)
                        {
                            cost = decimal.Parse(dt_prescription1.Rows[pa]["cost"].ToString());
                            qty = int.Parse(dt_prescription1.Rows[pa]["unit"].ToString());
                            paid = decimal.Parse(dt_prescription1.Rows[pa]["total"].ToString());
                            discount = decimal.Parse(dt_prescription1.Rows[pa]["discountin_rs"].ToString());
                            totCost = cost * qty;
                            totalsubst = totCost - (paid + discount);
                            totalkk = totalkk + totCost;
                            totalpaid = totalpaid + totalsubst;
                            total = total + paid;
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + DateTime.Parse(dt_prescription1.Rows[pa]["date"].ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                            sWrite.WriteLine("<td align='left'  ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + dt_prescription1.Rows[pa]["services"].ToString() + "</font></td>");
                            if (discount == 0)
                            {
                                strdis = "";
                            }
                            else
                            {
                                strdis = "(-" + String.Format("{0:0.00}", discount) + ") ";
                            }
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + strdis + String.Format("{0:0.00}", totCost) + "</font></td>");
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + String.Format("{0:0.00}", totalsubst) + "</font></td>");
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>" + String.Format("{0:0.00}", decimal.Parse(dt_prescription1.Rows[pa]["total"].ToString())) + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            pa++;
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 colspan='2'></font><b>TOTAL&nbsp;&nbsp;</b></th>");
                        sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3><b></b></font></th>");
                        sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3><b>" + String.Format("{0:0.00}", totalkk) + "</b></font></th>");
                        sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3><b>" + String.Format("{0:0.00}", totalpaid) + "</b></font></th>");
                        sWrite.WriteLine("<td align='right'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3><b>" + String.Format("{0:0.00}", decimal.Parse(total.ToString())) + "</b></font></th>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                if (!String.IsNullOrWhiteSpace(richTxt_PresentIllness.Text))
                {
                    string sentence = richTxt_PresentIllness.Text;
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;H/O PRESENT ILLNESS</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='justify' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + sentence.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                //LabInvestigations
                if (!String.IsNullOrWhiteSpace(richTxt_LabInvestigations.Text))
                {
                    string sentence = richTxt_LabInvestigations.Text;
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'  width='700px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;LAB INVESTIGATIONS</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='justify' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + sentence.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("    <td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                //SurgicalNotes
                if (!String.IsNullOrWhiteSpace(richTxt_SurgicalNotes.Text))
                {
                    string sentence = richTxt_SurgicalNotes.Text;
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'  width='700px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;SURGICAL NOTES</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='justify' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + sentence.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }

                if (!String.IsNullOrWhiteSpace(richTxt_ConditionDischarge.Text))
                {
                    string sentence = richTxt_ConditionDischarge.Text;
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3>&nbsp;CONDITION AT DISCHARGE</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='justify' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + sentence.ToString() + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("    <td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                if (!String.IsNullOrWhiteSpace(richTxt_AdviceDischarge.Text))
                {
                    string sentence = richTxt_AdviceDischarge.Text;
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'  bgcolor='#999999' width='700px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;ADVICE AT DISCHARGE</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='justify'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>&nbsp;" + sentence.ToString() + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                if (richTxt_PresentIllness.Text == "" && richTxt_LabInvestigations.Text == "" && richTxt_SurgicalNotes.Text == "" && richTxt_ConditionDischarge.Text == "" && richTxt_AdviceDischarge.Text != "")
                {
                    model.insert(richTxt_PresentIllness.Text, richTxt_LabInvestigations.Text,  richTxt_SurgicalNotes.Text, richTxt_ConditionDischarge.Text, richTxt_AdviceDischarge.Text, DtpReview.Value.ToString("MM/dd/yyyy"),  txtTime.Text, dTPToDate.Value.ToString("MM/dd/yyyy"),patient_id);//
                }
                sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                //sWrite.WriteLine("<tr>");
                //if (checkBoxreview.Checked == true)
                //{
                //    sWrite.WriteLine("<td align='left'  width='700px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3><b> &nbsp;NEXT REVIEW </b></font></th>");
                //    sWrite.WriteLine("<td align='left' width:'400px' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;" + DtpReview.Value.ToString("dd/MM/yyyy") + " " + txtTime.Text + "</font></th>");
                //}
                //else
                //{
                //    sWrite.WriteLine("<td align='left'  width='700px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                //    sWrite.WriteLine("<td align='left' width:'400px' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;</font></th>");
                //}
                //sWrite.WriteLine("</tr>");

                if (checkBoxreview.Checked == true)
                {
                    //sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'  width='700px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3><b> &nbsp;NEXT REVIEW </b></font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width:'400px' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;" + DtpReview.Value.ToString("dd/MM/yyyy") + " " + txtTime.Text + "</font></th>");
                    sWrite.WriteLine("</tr>");
                }
                else
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left'  width='700px'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3></font></th>");
                    sWrite.WriteLine("<td align='left' width:'400px' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;</font></th>");
                    sWrite.WriteLine("</tr>");
                }



                //    sWrite.WriteLine("<tr>");


                //sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp; </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp; </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                if (!String.IsNullOrWhiteSpace(txtDoctorSearch.Text))
                {
                    string doctorname = txtDoctorSearch.Text;
                    string dr = "Dr.";
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' height='40' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;Doctor Signature </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp; </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp; </font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    if (doctorname != "0")
                    {
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp; " + dr + "" + doctorname.ToString() + " </font></th>");
                    }
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                if (Ckbemail.Checked)
                {
                    string email = "", emailName = "", emailPass = "";
                    System.Data.DataTable sr = mdl.Get_Patient_Details(patient_id);
                    if (sr.Rows.Count > 0)
                    {
                        email = sr.Rows[0]["email_address"].ToString();
                        if (email != "")
                        {
                            System.Data.DataTable sms = mdl.send_email();
                            if (sms.Rows.Count > 0)
                            {
                                emailName = sms.Rows[0]["emailName"].ToString();
                                emailPass = sms.Rows[0]["emailPass"].ToString();
                                try
                                {
                                    StreamReader reader = new StreamReader(Apppath + "\\Casesheet.html");
                                    string readFile = reader.ReadToEnd();
                                    string StrContent = "";
                                    StrContent = readFile;
                                    MailMessage message = new MailMessage();
                                    message.From = new MailAddress(email);
                                    message.To.Add(email);
                                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                    message.Subject = sr.Rows[0]["email_address"].ToString() + "'s Case Sheet";
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
                                    MessageBox.Show("Email is Sent To : " + email);
                                    reader.Close();
                                }
                                catch
                                { MessageBox.Show("Mail Send Error.....!!", "Data Error"); }

                            } //Clinic email and password Check
                        }// Patient Email check
                        else
                        {
                            MessageBox.Show("Email is not Correct..", "Email Error");
                        }
                    }
                }// Mail check
                else
                {
                    System.Diagnostics.Process.Start(Apppath + "\\Casesheet.html");
                }
            }
            catch
            {
                MessageBox.Show("Data Required.....!!", "Data Error");
            }
        }
        public void doctor()
        {
            txtDoctorSearch.Text = "";
            for (int i = 0; i < checkedListBoxdoc.Items.Count; i++)
            {
                if (checkedListBoxdoc.GetItemChecked(i))
                {
                    val = checkedListBoxdoc.Items[i].ToString();
                    txtDoctorSearch.Text += val + ",";
                }
            }
            string s = txtDoctorSearch.Text;
            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "0";
            }
            txtDoctorSearch.Text = s;
        }
    }
}
