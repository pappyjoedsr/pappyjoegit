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
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class consetn : Form
    {
        public consetn()
        {
            InitializeComponent();
        }
        common_model mdl = new common_model();
        string PId = "";
        string PGender = "";
        string PAge = ""; public string patient_id { get; set; }
        public string doctor_id { get; set; }
        public void Bindpatientname()
        {
            DataTable dt3 = mdl.Get_Patient_Details(patient_id);
            comboBoxpatientname.DataSource = dt3;
            comboBoxpatientname.DisplayMember = "pt_name";
            comboBoxpatientname.ValueMember = "id";
            if (dt3.Rows.Count > 0)
            {
                PId = dt3.Rows[0]["pt_id"].ToString();
                PGender = dt3.Rows[0]["gender"].ToString();
                PAge = dt3.Rows[0]["age"].ToString();
            }
        }
        public void Binddoctorname()
        {
            DataTable dt3 = mdl.get_all_doctorname();
            comboBoxdrname.DataSource = dt3;
            comboBoxdrname.DisplayMember = "doctor_name";
            comboBoxdrname.ValueMember = "id";
        }
        public void Bindtreatmantpaln()
        {
            DataTable dt3 = mdl.get_all_procedure();
            comboBoxprocedur.DataSource = dt3;
            comboBoxprocedur.DisplayMember = "name";
            comboBoxprocedur.ValueMember = "id";
        }

        private void comboBoxdrname_SelectedIndexChanged(object sender, EventArgs e)
        {
            textdoctor.Text = comboBoxdrname.Text;
        }

        private void comboBoxprocedur_SelectedIndexChanged(object sender, EventArgs e)
        {
            textprocedure.Text = comboBoxprocedur.Text;
        }

        private void BtnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string str_name = "";
                string str_street_address = "";
                string str_locality = "";
                string str_pincode = "";
                string str_contact_no = "";
                string str_email = "";
                string str_website = "";
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
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\Consent.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("<style>");
                sWrite.WriteLine("p.big {line-height: 250%;}");
                sWrite.WriteLine("</style>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body>");
                sWrite.WriteLine("<br><br><br>");
                sWrite.WriteLine("<table align=center frame=box >");
                sWrite.WriteLine("<col width=690>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=4>");
                sWrite.WriteLine("<br><br>&nbsp;&nbsp;&nbsp;&nbsp;" + str_name.ToString() + "</font></td>");
                sWrite.WriteLine("</tr>");
                if (str_street_address.ToString() != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3>");
                    sWrite.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;" + str_street_address.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (str_locality.ToString() != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>");
                    sWrite.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;" + str_locality.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (str_pincode.ToString() != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>");
                    sWrite.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;PIN :" + str_pincode.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (str_contact_no.ToString() != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>");
                    sWrite.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;PH :" + str_contact_no.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (str_email.ToString() != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>");
                    sWrite.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;EMAIL :" + str_email.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (str_website.ToString() != "")
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2>");
                    sWrite.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;WEB:" + str_website.ToString() + "</font><hr></td>");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th align=center><br><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5>TO WHOM IT MAY CONCERN </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=justify><p style=line-height:2><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 >&nbsp;&nbsp;&nbsp; ");
                sWrite.WriteLine("I<b> " + comboBoxpatientname.Text + "</b> <i>(ID:" + PId + "," + PGender + "/" + PAge + "Yrs.) </i>hereby authorize Dr.<b>" + comboBoxdrname.Text + "</b> to perform  <b>" + comboBoxprocedur.Text + "</b> I declare that I have been informed of the nature and possible risks or effects of the procedure.");
                sWrite.WriteLine("</font> </p></td>");
                sWrite.WriteLine("</tr>");
                //second
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=justify><p style=line-height:2><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 >&nbsp;&nbsp;&nbsp;I hereby authorize to do any other procedures that may be required at the time of the procedure for which it would be impossible to obtain my consent.</font> </p></td>");
                sWrite.WriteLine("</tr>");
                //second end
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 ><i>Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of patient/authorized person&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of Witness</i></font> </td> ");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 ><i>Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of Doctor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of Witness</i></font> </td> ");
                sWrite.WriteLine("</tr>");
                //date and time
                if (checkBoxsedation.Checked)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th align=left><br>&nbsp;&nbsp;&nbsp;<FONT COLOR=black FACE='Geneva, segoe UI' SIZE=5>Consent to do Sedation</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align=justify><p style=line-height:2><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3 >&nbsp;&nbsp;&nbsp; ");
                    sWrite.WriteLine("At the time of<b> " + comboBoxprocedur.Text + "</b> I hereby give consent to a sedation being administered to me by <b>Dr." + comboBoxdrname.Text + "</b>.I declare that I have been fully informed of the nature and possible risks or effects of this sedation.");
                    sWrite.WriteLine("</font> </p></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                    sWrite.WriteLine("</tr>");
                    //date and time
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 ><i>Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of patient/authorized person&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of Witness</i></font> </td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td ><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=2 ><i>Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of Doctor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name & Signature of Witness</i></font> </td> ");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\Consent.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Printer not ready...." + ex.Message, "Printer error.. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
