using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
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

namespace PappyjoeMVC.View
{
    public partial class LabWorks : Form
    {
        public LabWorks()
        {
            InitializeComponent();
        }
        StreamWriter sWrite;
        public int k, Dexist =0;
        Connection db = new Connection();
        LabWorks_controller ctrlr = new LabWorks_controller();
        public static string strphone = "";
        public string name = "", result = "", units = "", text = "", smsName = "", smsPass = "";
        public string addr = "", loc = "", gen = "", patient_id = "", age = "", address = "", sexage = "", Apppath = "", doctor_id = "", typ = "", n = "", workiddental = "", workname = "", strPatientName = "", mob_number = "", path = "", contact_no = "", logo_name = "", clinicn = "", strclinicname = "", strStreet = "", stremail = "", strwebsite = "";
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var form2 = new Doctor_Profile();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var frmAddlabwork = new LabtrackingReport();
            frmAddlabwork.doctor_id = doctor_id;
            frmAddlabwork.patient_id = patient_id;
            frmAddlabwork.Closed += (sender1, args) => this.Close();
            frmAddlabwork.ShowDialog();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Practice_Details();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void logOuntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtdr = this.ctrlr.Patient_search(toolStripTextBox1.Text);
                if (toolStripTextBox1.Text != "")
                {
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
                    listpatientsearch.Location = new Point(toolStrip1.Width - 350, 32);
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
            form2.ShowDialog();
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
                workname = label1.Text;
                DataTable dt=this.ctrlr.printdetails(patient_id, workname, workiddental);
                printdetails(dt);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var form = new PappyjoeMVC.View.Dentalwork();
            form.patient_id = patient_id;
            form.doctor_id = doctor_id;
            form.workid = workiddental;
            form.ShowDialog();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DataTable sm=this.ctrlr.smsinfo();
            smsinfo(sm);
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            var form = new PappyjoeMVC.View.LabResultEntry();
            form.patient_id = patient_id;
            form.doctor_id = doctor_id;
            form.workid = workiddental;
            form.ShowDialog();
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
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
                        form2.ShowDialog();
                    }
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    form2.ShowDialog();
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
                            DataTable dtp=this.ctrlr.practicedetails();
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
                    DataTable dt=this.ctrlr.tbmain(patient_id, workiddental);
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
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
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
                        form2.ShowDialog();
                    }
                }
                else
                {
                    var form2 = new StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    form2.ShowDialog();
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
            form2.ShowDialog();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
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
                        var form2 = new PappyjoeMVC.View.LabResultEntry();
                        form2.patient_id = patient_id;
                        form2.doctor_id = doctor_id;
                        string workid = dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[2].Value.ToString();
                        form2.workid = workid;
                        form2.flag = "1";
                        form2.ShowDialog();
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
                            form2.ShowDialog();
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
                    label1.Text = dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string type=this.ctrlr.seltype(patient_id, dataGridView1_treatment_paln.Rows[e.RowIndex].Cells[2].Value.ToString());
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
            form2.ShowDialog();
        }
        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Add_Labwork();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        public void printdetails(DataTable tbmain)
        {
            try
            {
                Apppath = System.IO.Directory.GetCurrentDirectory();
                System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\RESULT.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("<style>");
                sWrite.WriteLine("table { border-collapse: collapse;}");
                sWrite.WriteLine("p.big {line-height: 400%;}");
                sWrite.WriteLine("</style>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                if (tbmain.Rows.Count > 0)
                {
                    if (logo_name != "")
                    {
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='130' height='75px' align='left' rowspan='5'><img src='" + Appath + "\\" + logo_name + "' width='77' height='60' style='width:100px;height:100px;'></td><td width='730' align='left' height='23px'><FONT  color=black  face='Segoe UI' SIZE=4>&nbsp;&nbsp;" + strclinicname + "</font></td>  ");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + strphone + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + stremail + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + strwebsite + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>No: </FONT>" + tbmain.Rows[0]["id"].ToString() + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd MMM yyyy") + "</font></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='25px'><FONT  color=black  face='Segoe UI' SIZE=5>" + strclinicname + "</font></td> <td width='589' align='right' height='27px'><FONT  color='#DCDCDC'  face='Segoe UI' SIZE=6>&nbsp;</font></td> </tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + strphone + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + stremail + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + strwebsite + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>No: </FONT>" + tbmain.Rows[0]["id"].ToString() + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd MMM yyyy") + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='25px' colspan='2'><FONT  color=black  face='Segoe UI' SIZE=5>" + strclinicname + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px' colspan='2'><FONT COLOR=black FACE='Segoe UI' SIZE=3>" + strStreet + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' colspan='2'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + strphone + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' colspan='2'> <FONT COLOR=black FACE='Arial' SIZE=2>" + stremail + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' colspan='2'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>" + strwebsite + "</font></td> </tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>No: </FONT>" + tbmain.Rows[0]["id"].ToString() + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(DateTime.Now.ToShortDateString()).ToString("dd MMM yyyy") + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                    sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    if (gen != "")
                    {
                        sexage = gen;
                        Dexist = 1;
                    }
                    if (age != "")
                    {
                        if (Dexist == 1)
                        {
                            sexage = sexage + ", " + age + " Years";
                        }
                        else
                        {
                            sexage = age + " Years";
                        }
                    }
                    sWrite.WriteLine(" <td align='left' height=25><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>" + strPatientName + "</b><i> (" + sexage + ")</i></font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Patient Id:" + linkLabel_id.Text + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    Dexist = 0;
                    if (addr != "")
                    {
                        address = addr;
                        Dexist = 1;
                    }
                    if (loc != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + loc;
                        Dexist = 1;
                    }
                    if (address != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + address + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + mob_number + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine("<tr><td colspan=2><hr></td></tr>");
                    sWrite.WriteLine("</table>");
                    for (int i = 0; i < tbmain.Rows.Count; i++)
                    {
                        if (workname == tbmain.Rows[i]["Main_test"].ToString())
                        {
                            sWrite.WriteLine("<table  align='center' width=850px>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='center' colspan='4'><b><Font COLOR=black FACE='Segoe UI' SIZE=4><br><u>" + tbmain.Rows[i][1].ToString() + "</u><br></font></b></td>");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<table align='center' width=850 >");
                            sWrite.WriteLine("<td  width = 322px;><FONT COLOR=black FACE='Segoe UI' SIZE=2><U>TEST </U></font></td>");
                            sWrite.WriteLine("<td width = 110px><FONT COLOR=black FACE='Segoe UI' SIZE=2><U>RESULT</U> </font></td>");
                            sWrite.WriteLine("<td width = 161px;><FONT COLOR=black FACE='Segoe UI' SIZE=2><U>UNITS</U> </font></td>");
                            sWrite.WriteLine("<td width =237px;> <FONT COLOR=black FACE='Segoe UI' SIZE=2><U> NORMAL VALUE</U></font> </td>");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("<table align='center' width=850 >");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  width = 309px;  height=27px><b><FONT COLOR=black FACE='Geneva, Courier' SIZE=2>" + tbmain.Rows[i]["Main_test"].ToString() + " </font></b></td>");
                            sWrite.WriteLine("<td width = 10px;><b><FONT COLOR=black FACE='Geneva, Courier' SIZE=2>  :</font></b></td>");
                            sWrite.WriteLine("<td width = 107px><b><FONT COLOR=black FACE='Geneva, Courier' SIZE=3>" + tbmain.Rows[i]["results"].ToString() + " </font></b></td>");
                            sWrite.WriteLine("<td width = 137px;><b><FONT COLOR=black FACE='Geneva, Courier' SIZE=2>" + tbmain.Rows[i]["Units"].ToString() + " </font></b></td>");
                            if (tbmain.Rows[i]["NormalValueM"].ToString() != "")
                            {
                                sWrite.WriteLine("<td width = 263px;> <b><FONT COLOR=black FACE='Geneva, Courier' SIZE=2  width=200px> [NV: M(" + tbmain.Rows[i]["NormalValueM"].ToString() + ") F('" + tbmain.Rows[i]["NormalValueF"].ToString() + "')]</font></b></td>");
                            }
                            else
                            {
                                sWrite.WriteLine("<td width =263px;> <b><FONT COLOR=black FACE='Geneva, Courier' SIZE=2  width=200px> </font></b></td>");
                            }
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                        }
                    }
                    sWrite.WriteLine("</body>");
                    sWrite.WriteLine("</html>");
                    sWrite.WriteLine("<script>window.print();</script>");
                    sWrite.Close();
                    System.Diagnostics.Process.Start(Apppath + "\\RESULT.html");
                }
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
                dataGridView1_treatment_paln.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    cl.Width = 120;
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
                if (docnam!="")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
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
                    label1.Show();
                    label1.Location = new System.Drawing.Point(350, 350);
                }
                else
                {
                    label1.Hide();
                    label1.Location = new System.Drawing.Point(350, 350);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
