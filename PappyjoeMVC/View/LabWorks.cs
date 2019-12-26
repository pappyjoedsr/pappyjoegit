using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class LabWorks : Form
    {
        public LabWorks()
        {
            InitializeComponent();
        }
        StreamWriter sWrite;
        public int k, Dexist = 0;
        string logo_name = "";
        string path = "";
        string includeheader = "0";
        string includelogo = "0";
        string paperSize_print = "";
        string prescription_id = "0";
        int topmargin1 = 0;
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
        PaperSize paperSize; System.Drawing.Image logo = null;
        Connection db = new Connection();
        LabWorks_controller ctrlr = new LabWorks_controller();
        public static string strphone = "";
        public string name = "", result = "", units = "", text = "", smsName = "", smsPass = "";
        public string addr = "", loc = "", gen = "", patient_id = "", age = "", sexage = "", Apppath = "", doctor_id = "", typ = "", n = "", workiddental = "", workname = "", strPatientName = "", mob_number = "",  contact_no = "",  clinicn = "", strclinicname = "", strStreet = "", stremail = "", strwebsite = "";
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }
        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelattachment_Click(object sender, EventArgs e)
        {

            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var frmAddlabwork = new LabtrackingReport();
            frmAddlabwork.doctor_id = doctor_id;
            frmAddlabwork.patient_id = patient_id;
            frmAddlabwork.Closed += (sender1, args) => this.Close();
            this.Hide();
            frmAddlabwork.Show();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Practice_Details();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void logOuntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtdr = this.ctrlr.Patient_search(toolStripTextBox1.Text);
                if (toolStripTextBox1.Text != "")
                {
                    listpatientsearch.DisplayMember = "patient";
                    listpatientsearch.ValueMember = "id";
                    listpatientsearch.DataSource = dtdr;
                    if (listpatientsearch.Items.Count == 0)
                    {
                        listpatientsearch.Visible = false;
                    }
                    else
                    {
                        listpatientsearch.Visible = true;
                    }
                    listpatientsearch.Location = new Point(toolStrip1.Width - 365, 32);
                }
                else
                {
                    listpatientsearch.Visible = false;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
        }
        private void labl_Lab_Click(object sender, EventArgs e)
        {
            var form2 = new LabWorks();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.Show();
        }
        public void practicedetails(DataTable dtp)
        {
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
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DataTable dtp = this.ctrlr.practicedetails();
            practicedetails(dtp);
           
            DataTable print = this.ctrlr.printsettings_details();
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
                printdetails();
            }
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var form = new PappyjoeMVC.View.Dentalwork();
            form.patient_id = patient_id;
            form.doctor_id = doctor_id;
            form.workid = workiddental;
            form.Show();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DataTable sm = this.ctrlr.smsinfo();
            smsinfo(sm);     
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            var form = new PappyjoeMVC.View.LabResultEntry();
            form.patient_id = patient_id;
            form.doctor_id = doctor_id;
            form.workid = workiddental;
            form.Show();
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string doctrid = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
                if (doctor_id != "1")
                {
                    if (int.Parse(doctrid) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var form2 = new PappyjoeMVC.View.Add_New_Patients();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void tbmain(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataTable tbshade = this.ctrlr.tbshade(patient_id, dt.Rows[i][0].ToString(), workiddental);
                        text = text + " [" + dt.Rows[i][1].ToString() + "]  TEST --  RESULT/ UNITS --  NV --";
                        for (int j = 0; j < tbshade.Rows.Count; j++)
                        {

                            if (dt.Rows[i][1].ToString() == tbshade.Rows[j][0].ToString())
                            {

                                text = text + " (" + (j + 1) + ")" + tbshade.Rows[j][1].ToString() + " :" + tbshade.Rows[j][2].ToString() + " " + tbshade.Rows[j][5].ToString();
                            }
                            DataTable dtp = this.ctrlr.practicedetails();
                            practicedetails(dtp);
                            string res = this.ctrlr.SendSMS(smsName, smsPass, mob_number, "Dear " + strPatientName + ",  Your Lab Test Result : " + text + "--- Regards " + toolStripButton1.Text + "," + strphone);
                            if (res == "SMS message(s) sent")
                            { MessageBox.Show("Laboratory Result  send successfully", "success", MessageBoxButtons.OK, MessageBoxIcon.None); }
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void smsinfo(DataTable sms)
        {
            try
            {
                if (sms.Rows.Count > 0)
                {
                    smsName = sms.Rows[0]["smsName"].ToString();
                    smsPass = sms.Rows[0]["smsPass"].ToString();
                }
                if (smsName != "" && smsPass != "")
                {
                    DataTable dt = this.ctrlr.tbmain(patient_id, workiddental);
                    tbmain(dt);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.ctrlr.getprev(doctor_id);
                if (doctor_id != "1")
                {
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var form2 = new StockReport();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else
                {
                    var form2 = new StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        public void seltype(string type)
        {
            try
            {
                contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                if (type == "Dental")
                {
                    printtoolStripMenuItem2.Visible = false;
                    toolStripMenuItem1.Visible = false;
                    addLabOrderToolStripMenuItem.Visible = true;
                    sendSMSToolStripMenuItem.Visible = false;
                    workiddental = dataGridView1_treatment_paln.Rows[k].Cells[2].Value.ToString();
                }
                else
                {
                    printtoolStripMenuItem2.Visible = true;
                    toolStripMenuItem1.Visible = true;
                    sendSMSToolStripMenuItem.Visible = true;
                    workiddental = dataGridView1_treatment_paln.Rows[k].Cells[2].Value.ToString();
                    addLabOrderToolStripMenuItem.Visible = false;
                }
                contextMenuStrip1.Tag = k;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dataGridView1_treatment_paln_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    if (dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[5].Value.ToString() == "Medical")
                    {
                        var form2 = new LabResultEntry();
                        form2.patient_id = patient_id;
                        form2.doctor_id = doctor_id;
                        form2.Text = "Result View";
                        form2.label41.Text = " RESULT VIEW";
                        string workid = dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[2].Value.ToString();
                        form2.workid = workid;
                        form2.flag = "1";
                        form2.Show();
                    }
                    else if (dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[5].Value.ToString() == "Dental")
                    {
                        workiddental = dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[2].Value.ToString();
                        if (workiddental != "")
                        {
                            var form2 = new PappyjoeMVC.View.Dentalwork();
                            form2.patient_id = patient_id;
                            form2.doctor_id = doctor_id;
                            string workid = dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[2].Value.ToString();
                            form2.workid = workid;
                            form2.flag = "1";
                            form2.Show();
                        }
                        else
                        {
                            MessageBox.Show("Details of dental lab work is avialable in lab tracking", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    k = e.RowIndex;
                    //label1.Text = dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string type = this.ctrlr.seltype(patient_id, dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[2].Value.ToString());
                    seltype(type);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Add_Labwork();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        public void printdetails()
        {
            try
            {
                string clinicn = "";
                string Clinic = "";
                string streetaddress = "";
                string contact_no = "";
                string str_locality = "";
                string str_pincode = "";
                string str_email = "";
                string str_website = "";
                System.Data.DataTable dtp = this.ctrlr.Get_practiceDlNumber();
                if (dtp.Rows.Count > 0)
                {
                    clinicn = dtp.Rows[0]["name"].ToString();
                    Clinic = clinicn.Replace("¤", "'");
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                }
                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.ctrlr.printsettings();
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
                System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\RESULT.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body>");
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
                                sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'  style='width:70px;height:70px;'></td>  ");
                                sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + header1 + " </font><br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + header2 + "<br>&nbsp;" + header3 + "  </b></font></td>");
                                //sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;" + header2 + "</b></font></td></tr>");
                                //sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2><b>&nbsp;" + header3 + "</b></font></td></tr>");
                                sWrite.WriteLine("</tr>");
                                sWrite.WriteLine("</table>");
                            }
                            else
                            {
                                sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5><b>&nbsp;" + header1 + "</b></font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;" + header2 + "</b></font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2><b>&nbsp;" + header3 + "</b></font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                                sWrite.WriteLine("</table>");
                            }
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5><b>&nbsp;" + header1 + "</b></font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;" + header2 + "</b></font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2><b>&nbsp;" + header3 + "</b></font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5><b>&nbsp;" + header1 + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>&nbsp;" + header2 + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2><b>&nbsp;" + header3 + "</b></font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5></font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                sWrite.WriteLine("</table>");
                int Dexist = 0;
                string sexage = "";
                string address = "";
                address = "";
                string strNote = "";
                string strreview = "NO";
                string strreview_date = "";
                System.Data.DataTable dt1 = this.ctrlr.patient_details(patient_id);
                if (dt1.Rows.Count > 0)
                {
                    sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
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
                    sWrite.WriteLine(" <td align='left' height=25><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>" + dt1.Rows[0]["pt_name"].ToString() + "</b><i> (" + sexage + ")</i></font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Patient Id:" + dt1.Rows[0]["pt_id"].ToString() + " </font></td>");
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
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + address + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt1.Rows[0]["primary_mobile_number"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    if (dt1.Rows[0]["email_address"].ToString() != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt1.Rows[0]["email_address"].ToString() + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr><td colspan=2><hr></td></tr>");
                    string doctorname = "";
                    doctorname= Convert.ToString(dt1.Rows[0]["doctorname"].ToString());
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='400px' height='30px'><FONT FACE='Geneva, Segoe UI' SIZE=2><FONT COLOR=black >By</FONT> :Dr. <b>" + doctorname + " </b></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<table align='center'   style='width:900px;border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>R</font><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>x&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>Lab</FONT></td>");
                    sWrite.WriteLine("<td width=250px></td>");
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Now.ToString("dd MMM yyyy") + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }//
                DataTable tbmain = this.ctrlr.tbmain(patient_id, workiddental);
                    for (int i = 0; i < tbmain.Rows.Count; i++)
                    {
                    DataTable tbshade = this.ctrlr.tbshade(patient_id, tbmain.Rows[i][0].ToString(), workiddental);
                    sWrite.WriteLine("<table  align='center' width=900px>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan='4' ><b><Font COLOR=black FACE='Segoe UI' SIZE=4><u>" + tbmain.Rows[i][1].ToString() + "</u></font></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<table align='center'style='width:900px;border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr >");
                        sWrite.WriteLine("<td align='left' width='200px' height='30'><FONT COLOR=black FACE=' Segoe UI' SIZE=3><b>&nbsp;TEST</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='200px' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3><b>&nbsp;RESULT</b></font></td>");
                        sWrite.WriteLine("<td align='left' width='200px' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3><b>&nbsp;UNITS</b> </font></td>");
                        sWrite.WriteLine("<td align='left' width='300px' colspan='3' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3><b>&nbsp;NORMAL VALUE</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;' >");
                    for (int j = 0; j < tbshade.Rows.Count; j++)
                    {
                        sWrite.WriteLine("<tr>");
                        if (tbmain.Rows[i][1].ToString() == tbshade.Rows[j][0].ToString())
                        {
                            sWrite.WriteLine("<td align='left' width='200px' height='30'><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + tbshade.Rows[j][1].ToString() + " </font></b></td>");
                            sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + tbshade.Rows[j][2].ToString() + " </font></b></td>");
                            sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + tbshade.Rows[j][5].ToString() + " </font></b></td>");
                            if (tbshade.Rows[j][3].ToString() != "")
                            {
                                sWrite.WriteLine("<td align='left' width='300px' colspan='3' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; [NV: M(" + tbshade.Rows[j][3].ToString() + ") F('" + tbshade.Rows[j][4].ToString() + "')]</font></b></td>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td align='left' valign='top'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> </font></b></td>");
                            }
                        }
                    }
                }
                sWrite.WriteLine("<tr><td align='left' colspan=8><hr/></td></tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align='center'   style='width:900px;border: 1px ;border-collapse: collapse;' >");
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
                sWrite.WriteLine("</body >");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\RESULT.html");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void LabWorks_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable rs_patients = this.ctrlr.Get_Patient_Details(patient_id);
                Get_Patient_Details(rs_patients);
                DataTable clinicname = this.ctrlr.Get_Practice_details();
                toolStripButton4.Visible = true;
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                    path = clinicname.Rows[0]["path"].ToString();
                    contact_no = clinicname.Rows[0][2].ToString();
                    string dr = this.ctrlr.Get_DoctorName(doctor_id);
                    Get_DoctorName(dr);
                }
                DataTable dt = this.ctrlr.Getdata(patient_id);
                Getdata(dt);
                dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 10, FontStyle.Regular);
                dataGridView1_treatment_paln.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1_treatment_paln.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView1_treatment_paln.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dataGridView1_treatment_paln.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1_treatment_paln.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dataGridView1_treatment_paln.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1_treatment_paln.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn cl in dataGridView1_treatment_paln.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void Get_Patient_Details(DataTable rs_patients)
        {
            try
            {
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                    strPatientName = rs_patients.Rows[0]["pt_name"].ToString();
                    mob_number = rs_patients.Rows[0]["primary_mobile_number"].ToString();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                gen = rs_patients.Rows[0]["gender"].ToString();
                age = rs_patients.Rows[0]["age"].ToString();
                addr = rs_patients.Rows[0]["street_address"].ToString();
                loc = rs_patients.Rows[0]["locality"].ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void Get_DoctorName(string docnam)
        {
            try
            {
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                if (path != "")
                {
                    string curFile = this.ctrlr.server() + "\\Pappyjoe_utilities\\Logo\\" + path;
                    if (File.Exists(curFile))
                    {
                        logo_name = "";
                        logo_name = path;
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        if (!File.Exists(Apppath + "\\" + logo_name))
                        {
                            System.IO.File.Copy(curFile, Apppath + "\\" + logo_name);
                        }
                    }
                    else
                    {
                        logo_name = "";
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void Getdata(DataTable tbShade)
        {
            try
            {
                dataGridView1_treatment_paln.DataSource = tbShade;
                if (dataGridView1_treatment_paln.Rows.Count <= 0)
                {
                    int x = (panel4.Size.Width - label1.Size.Width) / 2;
                    label1.Location = new Point(x, label1.Location.Y);
                    label1.Show();
                    //label1.Location = new System.Drawing.Point(350, 350);
                }
                else
                {
                    label1.Hide();
                    //label1.Location = new System.Drawing.Point(350, 350);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
