using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using PappyjoeMVC.Controller;
using PappyjoeMVC.View;

namespace PappyjoeMVC.View
{
    public partial class Consultation : Form
    {
        public Consultation()
        {
            InitializeComponent();
        }
        public static bool flag = false;
        public Consultation(string text, string id)
        {
            InitializeComponent();
            ptname = text;
            newptid = id;
        }
        Consultation_controller ctrlr=new Consultation_controller();
        public string doctor_id = "", patient_id = "";
        public static string newptid="",ptname="";
        string Prescription_bill_status = "No";
        private string id;
        string includeheader = "0";
        string includelogo = "0"; System.Drawing.Image logo = null;
        string logo_name = "";
        string payment_date = "", receipt = "";
        string patient_mobile = "";
        string id1, drug_type = "";
        private void txt_Pt_search_TextChanged(object sender, EventArgs e)
        {
            if(flag==false)
            {
                if (txt_Pt_search.Text != "")
                {
                   // lbPatient.Show();
                    lbPatient.Location = new Point(txt_Pt_search.Location.X,49);
                    DataTable dtdr = this.ctrlr.srch_patient(txt_Pt_search.Text, txt_Pt_search.Text);
                    lbPatient.DataSource = dtdr;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "id";
                }
                else
                {
                    DataTable dtdr = this.ctrlr.search_patient(txt_Pt_search.Text);
                    lbPatient.DataSource = dtdr;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "id";
                }
                if(lbPatient.Items.Count>0)
                {
                    lbPatient.Show();
                }
                else
                {
                    lbPatient.Hide();
                }
            }
        }

        private void lbPatient_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbPatient.SelectedItems.Count > 0)
            {
                string value = lbPatient.SelectedValue.ToString();
                DataTable patient = new DataTable();
                patient = this.ctrlr.get_patient_details(value);
                if (patient.Rows.Count > 0)
                {
                    txt_Pt_search.Text = patient.Rows[0]["pt_name"].ToString();
                    txtPatientID.Text = patient.Rows[0]["pt_id"].ToString();
                    patient_id = patient.Rows[0]["id"].ToString();
                    patient_mobile = patient.Rows[0]["primary_mobile_number"].ToString(); 
                    lbPatient.Visible = false;
                }
                else
                {
                    MessageBox.Show("Please choose  Correct patient....", "Data Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_Pt_search_Click(object sender, EventArgs e)
        {
            if (txt_Pt_search.Text == "Search by Patient  and  Name")
            {
                txt_Pt_search.Text = "";
            }
            lst_procedure.Visible = false;
        }

        private void txt_procedure_Click(object sender, EventArgs e)
        {
            txt_procedure.Text = "";
            lbPatient.Visible = false;
        }

        private void txt_procedure_TextChanged(object sender, EventArgs e)
        {
            if (txt_procedure.Text != "")
            {
               
                lst_procedure.Location = new Point(txt_procedure.Location.X, 171);
                DataTable dtdr = this.ctrlr.search_procedure(txt_procedure.Text);
                lst_procedure.DataSource = dtdr;
                lst_procedure.DisplayMember = "name";
                lst_procedure.ValueMember = "id";
            }
            else
            {
                DataTable dtdr = this.ctrlr.search_procedure(txt_procedure.Text);
                lst_procedure.DataSource = dtdr;
                lst_procedure.DisplayMember = "name";
                lst_procedure.ValueMember = "id";
            }
            if(lst_procedure.Items.Count>0)
            {
                lst_procedure.Visible = true;
            }
            else
            { lst_procedure.Visible = false; }
        }

        private void lst_procedure_MouseClick(object sender, MouseEventArgs e)
        {
            if (lst_procedure.SelectedItems.Count > 0)
            {
                string value = lst_procedure.SelectedValue.ToString();
                DataTable procedure = new DataTable();
                procedure = this.ctrlr.procedure_details(value);
                if (procedure.Rows.Count > 0)
                {
                    txt_procedure.Text = procedure.Rows[0]["name"].ToString();
                    txt_cost.Text = procedure.Rows[0]["cost"].ToString();
                    lst_procedure.Visible = false;
                }
                else
                {
                    MessageBox.Show("Please choose Correct procedure....", "Data Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Consultation_Load(object sender, EventArgs e)
        {

            //DataTable dtb_prescription = db.table("select * from tbl_templates_main order by id");
            //cmb_prescription_temp.DisplayMember = "Text";
            //cmb_prescription_temp.ValueMember = "Value";
            //cmb_prescription_temp.Items.Add(new { Text = "-Select-", Value = 0 });
            //if (dtb_prescription.Rows.Count > 0)
            //{
            //    for (int r = 0; r < dtb_prescription.Rows.Count; r++)
            //    {
            //        int id = (int)Convert.ToInt16(dtb_prescription.Rows[r]["id"].ToString());
            //       cmb_prescription_temp.Items.Add(new { Text = dtb_prescription.Rows[r]["templates"].ToString(), Value = id });
            //    }
            //}
            //cmb_prescription_temp.SelectedIndex = 0;

            DataTable dt = this.ctrlr.Load_doctor();
            if (dt.Rows.Count > 0)
            {
                cmbdoctor.DataSource = dt;
                cmbdoctor.DisplayMember = "doctor_name";
                cmbdoctor.ValueMember = "id";
               
                DataTable dt_doctor = this.ctrlr.Load_dctrname(doctor_id);
                if (dt_doctor.Rows.Count > 0)
                {
                    
                    int int_doctor = cmbdoctor.FindStringExact(dt_doctor.Rows[0]["doctor_name"].ToString());
                    if (int_doctor >= 0)
                    {
                        cmbdoctor.SelectedIndex =int_doctor;
                    }
                }
            }
            Consultation_load();
            presdruggrid.Columns.Add("id", "xt");
            presdruggrid.Columns.Add("drug", "xt");
            presdruggrid.Columns.Add("stock", "xt");
            presdruggrid.Columns[0].Visible = false;
            presdruggrid.Columns[1].Width = 200;
            presdruggrid.Columns[2].Width = 150;
            presdruggrid.Columns[3].Visible = false;
            DataTable dt_prescription = new DataTable();
            dt_prescription = this.ctrlr.get_prescriptn();
            fill_DrugPrescrptn(dt_prescription);
            DataTable dt1 = this.ctrlr.get_unit();
            strengthcombo.DataSource = dt1;
            strengthcombo.DisplayMember = "name";
            strengthcombo.ValueMember = "id";
            if (strengthcombo.Items.Count > 1)
            {
                strengthcombo.SelectedIndex = 0;
            }
           
            cmbDuration.SelectedIndex = 0;

            DataTable dt2 = this.ctrlr.get_tmplates();
            dataGridView2.DataSource = dt2;
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text != "" && txt_procedure.Text != "")
                {
                    if(dataGridView_drugnew.Rows.Count==0)
                    {
                        DialogResult yesno = MessageBox.Show("You missed to Click on 'Add' button under prescription. Please click 'Add' button to proceed..Or Do you want to save without prescription..??", "Prescription Not Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (yesno == DialogResult.No)
                    { return; }
                    }
                    int presid = 0;

                    //DataTable dt = db.table("select name,cost,notes from tbl_addproceduresettings where id ='" + id + "'");
                    //servicetext.Text = dt.Rows[0][0].ToString();
                    if (lst_procedure.SelectedIndex < 0)
                    {
                        MessageBox.Show("Precedure not found.. please enter the procedure name.... ", "Procedure Not Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //prescription
                    //prescription_check();
                    int d_id = Convert.ToInt32(cmbdoctor.SelectedValue.ToString());


                    if (dataGridView_drugnew.Rows.Count > 0)
                    {
                        prescription_check();// Check Inventory Item
                        this.ctrlr.save_prescriptionMain(patient_id, d_id, Prescription_bill_status, txt_remarks.Text);
                        string dt = this.ctrlr.max_presid();
                        if (dt!="")
                        {
                            presid = Int32.Parse(dt);
                        }
                        else
                        {
                            presid = 1;
                        }
                        int count = dataGridView_drugnew.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            string strstatus = "";
                            if (dataGridView_drugnew[13, i].Value.ToString() != "")
                            { strstatus = dataGridView_drugnew[13, i].Value.ToString(); }

                            this.ctrlr.save_prescription(presid, patient_id, cmbdoctor.Text, d_id.ToString(), dataGridView_drugnew[0, i].Value.ToString(), dataGridView_drugnew[1, i].Value.ToString(), dataGridView_drugnew[2, i].Value.ToString(), dataGridView_drugnew[3, i].Value.ToString(), dataGridView_drugnew[4, i].Value.ToString(), dataGridView_drugnew[5, i].Value.ToString(), dataGridView_drugnew[6, i].Value.ToString(), dataGridView_drugnew[7, i].Value.ToString(), dataGridView_drugnew[8, i].Value.ToString(), dataGridView_drugnew[9, i].Value.ToString(), strstatus, dataGridView_drugnew[10, i].Value.ToString());
                        }

                    }

                    //string pres_id = cmb_prescription_temp.SelectedItem.GetType().GetProperty("Value").GetValue(cmb_prescription_temp.SelectedItem, null).ToString();
                    //DataTable dtb_prescription = db.table("select * from tbl_templates_main where id='" + pres_id + "'");
                    //if (dtb_prescription.Rows.Count > 0)
                    //{
                    //    DataTable dt_prs = db.table("select * from tbl_template where temp_id='" + dtb_prescription.Rows[0]["id"].ToString() + "'");
                    //    prescription_check(dt_prs);

                    //    db.execute("insert into tbl_prescription_main (pt_id,dr_id,date,pay_status,notes) values('" + patient_id + "','" + d_id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + Prescription_bill_status + "','" + txt_remarks.Text + "')");
                    //    DataTable dt = db.table("select MAX(id) from tbl_prescription_main");
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        presid = Int32.Parse(dt.Rows[0][0].ToString());
                    //    }
                    //    else
                    //    {
                    //        presid = 1;
                    //    }


                    //    for (int i = 0; i < dt_prs.Rows.Count; i++)
                    //    {
                    //        //if (dataGridView_drugnew[13, i].Value.ToString() != "")
                    //        //{ strstatus = dataGridView_drugnew[13, i].Value.ToString(); }

                    //        db.table("insert into tbl_prescription (pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id) values('" + presid + "','" + patient_id + "','" + cmbdoctor.Text + "','" + d_id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + dt_prs.Rows[i]["drug_name"].ToString() + "','" + dt_prs.Rows[i]["strength"].ToString() + "','" + dt_prs.Rows[i]["strength_gr"].ToString() + "','','" + dt_prs.Rows[i]["duration_period"].ToString() + "','" + dt_prs.Rows[i]["morning"].ToString() + "','" + dt_prs.Rows[i]["noon"].ToString() + "','" + dt_prs.Rows[i]["night"].ToString() + "','" + dt_prs.Rows[i]["food"].ToString() + "','" + dt_prs.Rows[i]["add_instruction"].ToString() + "','" + dt_prs.Rows[i]["drug_type"].ToString() + "'," + dt_prs.Rows[i]["status"].ToString() + ",'" + dt_prs.Rows[i]["drug_id"].ToString() + "')");
                    //    }
                    //}


                    //completed id
                    this.ctrlr.save_completedid(patient_id);
                    string dt_CMain = this.ctrlr.max_completedid();
                    int completed_id, j1 = 0;
                    try
                    {
                        if (dt_CMain == "")
                        {
                            j1 = 1;
                            completed_id = 0;
                        }
                        else
                        {
                            completed_id = Int32.Parse(dt_CMain);
                        }
                    }
                    catch
                    {
                        j1 = 1;
                        completed_id = 0;
                    }
                    j1 = completed_id;
                    this.ctrlr.save_completed_details(j1 ,patient_id , lst_procedure.SelectedValue.ToString() , txt_procedure.Text , txt_cost.Text,txt_cost.Text,txt_instruction.Text,cmbdoctor.SelectedValue.ToString());
                    string dt_Compl_proce = this.ctrlr.max_completeProcedure();
                    long completed_procedures_id = 0;
                    try
                    {
                        if (dt_Compl_proce =="")
                        {
                           
                            completed_procedures_id = 1;
                        }
                        else
                        {
                            completed_procedures_id = Int32.Parse(dt_Compl_proce);
                        }
                    }
                    catch
                    {
                       
                        completed_procedures_id = 1;
                    }

                    //ReviewDate
                    if (checkBoxReview.Checked == true)
                    {
                        this.ctrlr.update_review(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"),j1);

                        this.ctrlr.update_prescription_review(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"),presid);

                        DataTable dt_review =this.ctrlr.get_reviewId(patient_id,dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"));
                        if (dt_review.Rows.Count == 0)
                        {
                           this.ctrlr.save_review(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"),patient_id);
                        }
                        this.ctrlr.save_appointment(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") , patient_id ,txt_Pt_search.Text ,cmbdoctor.SelectedValue.ToString(),patient_mobile ,cmbdoctor.Text.ToString());
                    }
                    else
                    {
                        this.ctrlr.update_prescription_review_NO(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"),j1);

                        this.ctrlr.update_prescription_review_NO(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"),presid);
                    }
                    string invoice = "";
                    DataTable invNo = null;
                    invNo =this.ctrlr.get_invoice_data();
                    if (invNo.Rows.Count > 0)
                    {
                        invoice = invNo.Rows[0]["invoice_prefix"].ToString() + invNo.Rows[0]["invoice_number"].ToString();
                    }

                    decimal totalcost = 0;
                    totalcost = Convert.ToDecimal(txt_cost.Text) * 1;
                    this.ctrlr.save_invoice_main(patient_id, txt_Pt_search.Text,invoice);
                    string dt1 = this.ctrlr.get_invoiceMain_maxid(); 
                    long Invoice_main_id = 0;
                    try
                    {
                        if (dt1 =="")
                        {

                            Invoice_main_id = 1;
                        }
                        else
                        {
                            Invoice_main_id = Int32.Parse(dt1);
                        }
                    }
                    catch
                    {

                        Invoice_main_id = 1;
                    }
                    this.ctrlr.save_invoice_details(invoice,txt_Pt_search.Text,patient_id,lst_procedure.SelectedValue.ToString(),txt_procedure.Text,txt_cost.Text,txt_cost.Text, cmbdoctor.SelectedValue.ToString(),Invoice_main_id ,completed_procedures_id);

                    string invoauto = this.ctrlr.get_invoicenumber();
                    int invoautoup = int.Parse(invoauto) + 1;
                    this.ctrlr.update_invnumber(invoautoup);

                    //payment
                    DataTable rec_receipt = this.ctrlr.receipt_number(); 
                    receipt = rec_receipt.Rows[0]["receipt_prefix"].ToString() + rec_receipt.Rows[0]["receipt_number"].ToString();
                   
                    DataTable cmd22 = this.ctrlr.Get_Advance(patient_id);
                    decimal advance = 0;
                    if (cmd22.Rows.Count > 0)
                    {
                        if (cmd22.Rows[0]["advance"].ToString() == null)
                        {
                            advance = 0;
                        }
                        else if (cmd22.Rows[0]["advance"].ToString() == "")
                        {
                            advance = 0;
                        }
                        else if (cmd22.Rows[0]["advance"].ToString() == "0")
                        {
                            advance = 0;
                        }
                        else
                        {
                            advance = decimal.Parse(cmd22.Rows[0]["advance"].ToString());
                        }
                    }
                    


                    this.ctrlr.save_receipt(receipt,advance,txt_cost.Text, invoice, txt_procedure.Text , patient_id , cmbdoctor.SelectedValue.ToString() , txt_cost.Text,txt_cost.Text, txt_Pt_search.Text, Invoice_main_id);
                    //}
                    string rec = this.ctrlr.receipt_autoid();
                    int receip = int.Parse(rec) + 1;
                    this.ctrlr.update_receiptAutoid(receip);
                    DialogResult print_yesno = System.Windows.Forms.DialogResult.No;
                    print_yesno = MessageBox.Show("Data saved successfully... Do you want a print..??", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (print_yesno== System.Windows.Forms.DialogResult.Yes)
                    {
                        printhtml();
                        if (chkprescription.Checked == true && presid>0)
                        {
                            printprescriptionhtml(presid);
                        }
                    }
                    txt_Pt_search.Text = "";
                    txt_procedure.Text = "";
                    txt_remarks.Text = "";
                    txtPatientID.Text = "";
                    txt_cost.Text = "";
                    txt_instruction.Text = "";
                    patient_mobile = "";
                    Consultation_load();
                    dataGridView_drugnew.Rows.Clear();
                    tabControl1.SelectedIndex = 0;
                }
                else
                {
                    if (txtPatientID.Text == "")
                    {
                        MessageBox.Show("This Patient does not exist, Please click on NEW PATIENT button...!!", "Patient Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPatientID.Focus();
                    }
                    else if (txt_procedure.Text == "")
                    {
                        MessageBox.Show("Procedure Details Not Found...", "Procedure Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_procedure.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void printhtml()
        {
            try
            {

                System.Data.DataTable dtp = this.ctrlr.get_company_details();
                System.Data.DataTable dt1 = this.ctrlr.Get_Patient_Details(patient_id);
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
                string doctor = this.ctrlr.Get_DoctorName(doctor_id.ToString());
                if (doctor!="")
                {
                    doctorName = doctor;
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                    logo_name = dtp.Rows[0]["path"].ToString();
                }


                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.ctrlr.get_receipt_print_setting();
                if (print.Rows.Count > 0)
                {
                    header1 = print.Rows[0]["header"].ToString();
                    header2 = print.Rows[0]["left_text"].ToString();
                    header3 = print.Rows[0]["right_text"].ToString();
                    strfooter1 = print.Rows[0]["fullwidth_context"].ToString();
                    strfooter2 = print.Rows[0]["left_sign"].ToString();
                    strfooter3 = print.Rows[0]["right_sign"].ToString();
                    includeheader = print.Rows[0]["include_header"].ToString();
                    includelogo = print.Rows[0]["include_logo"].ToString();
                }

                payment_date = DateTime.Now.Date.ToString("yyyy-MM-dd");
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
                            string curFile = this.ctrlr.server() + "\\Pappyjoe_utilities\\Logo\\" + logo_name;

                            if (System.IO.File.Exists(curFile))// if (File.Exists(Appath + "\\" + logo_name))
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + curFile +  "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
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
                System.Data.DataTable dt_cf = this.ctrlr.get_payment_details(payment_date, patient_id, receipt); ;
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
                    System.Data.DataTable dt_payment = this.ctrlr.get_receipt_details(payment_date, patient_id, receipt);
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
        public void printprescriptionhtml(int Prescription_id)
        {
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
            string Prescription_address = "";
            string phone = "";
            string blood = "";
            string gender = "";
            string orientation = "";
            string includeheader = "0";
            string includelogo = "0";
            string paperSize_print = "";
            int topmargin1 = 0;
            System.Drawing.Image logo = null;
            string logo_name = "";
            string path = "";

            System.Data.DataTable printsetting = this.ctrlr.printsettings_details();
            if (printsetting.Rows.Count > 0)
            {
                combo_topmargin = printsetting.Rows[0][4].ToString();
                combo_leftmargin = printsetting.Rows[0][5].ToString();
                combo_bottommargin = printsetting.Rows[0][6].ToString();
                combo_rightmargin = printsetting.Rows[0][7].ToString();
                combo_paper_size = printsetting.Rows[0][1].ToString();
                combo_footer_topmargin = printsetting.Rows[0][22].ToString();
                rich_fullwidth = printsetting.Rows[0][23].ToString();
                rich_leftsign = printsetting.Rows[0][24].ToString();
                rich_rightsign = printsetting.Rows[0][25].ToString();
                patient_details = printsetting.Rows[0][14].ToString();
                med = printsetting.Rows[0][15].ToString();
                patient = printsetting.Rows[0][16].ToString();
                Prescription_address = printsetting.Rows[0][17].ToString();
                phone = printsetting.Rows[0][18].ToString();
                blood = printsetting.Rows[0][20].ToString();
                gender = printsetting.Rows[0][21].ToString();
                orientation = printsetting.Rows[0][2].ToString();
                includeheader = printsetting.Rows[0]["include_header"].ToString();
                includelogo = printsetting.Rows[0]["include_logo"].ToString();
            }
            string clinicn = "";
            string Clinic = "";
            string streetaddress = "";
            string contact_no = "";
            string str_locality = "";
            string str_pincode = "";
            string str_email = "";
            string str_website = "";
            System.Data.DataTable dtp = this.ctrlr.get_practicedtls();
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
            System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\PrescriptionPrint.html");
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
            int Dexist = 0;
            string sexage = "";
            string address = "";
            address = "";
            string strNote = "";
            string strreview = "NO";
            string strreview_date = "";
            System.Data.DataTable dt1 = this.ctrlr.patient_data(patient_id);
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
                System.Data.DataTable dt_cf =this.ctrlr.table_details(Prescription_id.ToString() ,patient_id );
                if (dt_cf.Rows.Count > 0)
                {
                    doctorname = Convert.ToString(dt_cf.Rows[0]["doctor_name"].ToString());
                    strNote = dt_cf.Rows[0]["notes"].ToString();
                    if (dt_cf.Rows[0]["review"].ToString() == "YES")
                    {
                        strreview = "YES";
                        strreview_date = Convert.ToDateTime(dt_cf.Rows[0]["Review_date"].ToString()).ToString("dd-MM-yyyy hh:mm tt");
                    }
                    else
                    {
                        strreview = "NO";
                    }
                }
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' width='400px' height='30px'><FONT FACE='Geneva, Segoe UI' SIZE=2><FONT COLOR=black >By</FONT> :Dr. <b>" + doctorname + " </b></font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>R</font><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>x&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>Prescription</FONT></td>");
                sWrite.WriteLine("<td width=250px></td>");
                if (dt_cf.Rows.Count > 0)
                {
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(dt_cf.Rows[0]["date"].ToString()).ToString("dd MMM yyyy") + "</font></td>");
                }
                else
                {
                    sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Now.ToString("dd MMM yyyy") + "</font></td>");
                }
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
            }

            sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
            sWrite.WriteLine("<tr >");
            sWrite.WriteLine("<td align='left' width='35px' height='30'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Sl.</font></td>");
            sWrite.WriteLine("<td align='left' width='221px' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Drug Name</font></td>");
            sWrite.WriteLine("<td align='center' width='105px' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Strength </font></td>");
            sWrite.WriteLine("<td align='center' width='114px' colspan='3' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Frequency</font></td>");
            sWrite.WriteLine("<td align='left' width='99px'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Instructions</font></td>");
            sWrite.WriteLine("</tr>");
            System.Data.DataTable dt_prescription = this.ctrlr.prescription_details(Prescription_id.ToString());
            if (dt_prescription.Rows.Count > 0)
            {
                for (int k = 0; k < dt_prescription.Rows.Count; k++)
                {
                    string morning = "";
                    string noon = "";
                    string night = "";
                    string a1 = dt_prescription.Rows[k]["morning"].ToString();
                    string[] b1 = a1.Split('.');
                    int right1 = int.Parse(b1[1]);
                    morning = Convert.ToString(int.Parse(b1[0]));
                    if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                    string a2 = dt_prescription.Rows[k]["noon"].ToString();
                    string[] b2 = a2.Split('.');
                    int right2 = int.Parse(b2[1]);
                    noon = Convert.ToString(int.Parse(b2[0]));
                    if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                    string a3 = dt_prescription.Rows[k]["night"].ToString();
                    string[] b3 = a3.Split('.');
                    int right3 = int.Parse(b3[1]);
                    night = Convert.ToString(int.Parse(b3[0]));
                    if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                    if (dt_prescription.Rows[k]["status"].ToString() == "1")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' height='7'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1></font></td>");
                        sWrite.WriteLine("<td align='left' height='7'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1></font></td>");
                        sWrite.WriteLine("<td align='left' height='7'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1></font></td>");
                        sWrite.WriteLine("<td align='center' height='7' valign='bottom'  width='50px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;Morning </font></td>");
                        sWrite.WriteLine("<td align='center' height='7'  valign='bottom' width='50px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;Noon </font></td>");
                        sWrite.WriteLine("<td align='center' height='7' valign='bottom'  width='50px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;Night </font></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    if (dt_prescription.Rows[k]["add_instruction"].ToString() != "")
                    {
                        sWrite.WriteLine("<td align='left' height='20' valign='top'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + Convert.ToString(k + 1) + " </font></td>");
                    }
                    else
                    {
                        sWrite.WriteLine("<td align='left' height='30' valign='top'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + Convert.ToString(k + 1) + " </font></td>");
                    }
                    sWrite.WriteLine("<td align='left'   valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString() + " </font></td>");
                    sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + morning + " </font></td>");
                    sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + noon + " </font></td>");
                    sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + night + " </font></td>");
                    if (dt_prescription.Rows[k]["duration_unit"].ToString() == "0")
                    {
                        sWrite.WriteLine("<td align='left'   valign='top'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;" + dt_prescription.Rows[k]["food"].ToString() + " </font></td>");
                    }
                    else
                    {
                        sWrite.WriteLine("<td align='left'   valign='top'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;" + dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString() + "</br>" + dt_prescription.Rows[k]["food"].ToString() + " </font></td>");
                    }
                    sWrite.WriteLine("</tr>");
                    if (dt_prescription.Rows[k]["add_instruction"].ToString() != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td ></td>");
                        sWrite.WriteLine("<td align='left' height='20' colspan='7' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1.5>&nbsp;" + dt_prescription.Rows[k]["add_instruction"].ToString() + " </font></td>");
                        sWrite.WriteLine("</tr>");
                    }
                } // Presription Sub(Drug Details) Record Count
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' height='30' colspan='8'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strNote.ToString() + " </font></td>");
                sWrite.WriteLine("</tr>");
                if (strreview == "YES")
                {
                    sWrite.WriteLine("<tr><td align='left' colspan=8 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;Next Review Date : " + strreview_date + " </font></td></tr>");
                }
                sWrite.WriteLine("<tr><td align='left' colspan=8><hr/></td></tr>");
            }
            sWrite.WriteLine("</table>");
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
            sWrite.WriteLine("</body >");
            sWrite.WriteLine("</html>");
            sWrite.Close();
            System.Diagnostics.Process.Start(Apppath + "\\PrescriptionPrint.html");
        }
        public void Consultation_load()
        {
            DataTable procedure = new DataTable();
            procedure = this.ctrlr.get_procedure();
            if (procedure.Rows.Count > 0)
            {
                txt_procedure.Text = procedure.Rows[0]["name"].ToString();
                txt_cost.Text = procedure.Rows[0]["cost"].ToString();
                lst_procedure.Visible = false;
            }
        }

         public void prescription_check()
        {
            try
            {
                if (dataGridView_drugnew.Rows.Count > 0)
                {
                    int count = dataGridView_drugnew.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataTable dt4 = this.ctrlr.get_invid(dataGridView_drugnew[10, i].Value.ToString());
                        if (dt4.Rows.Count > 0)
                        {
                            Prescription_bill_status = "Yes";
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void prescription_check(DataTable dtb)//aswini
        //{
        //    try
        //    {
        //        if (dtb.Rows.Count > 0)
        //        {
        //            int count = dtb.Rows.Count;
        //            for (int i = 0; i < count; i++)
        //            {
        //                DataTable dt4 = db.table("select id,inventory_id from tbl_adddrug where id='" + dtb.Rows[i]["drug_id"].ToString() + "' and inventory_id<>0 ORDER BY id DESC");
        //                if (dt4.Rows.Count > 0)
        //                {
        //                    Prescription_bill_status = "Yes";
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        private void label5_Click(object sender, EventArgs e)
        {
            lbPatient.Visible = false;
            var form2 = new consultation_new_patient();
            form2.ShowDialog();
            if(newptid!="")
            {
                flag = true;
                DataTable dtb = this.ctrlr.pt_details(newptid);
                txtPatientID.Text = dtb.Rows[0]["pt_id"].ToString();
                txt_Pt_search.Text= dtb.Rows[0]["pt_name"].ToString();
                patient_id = dtb.Rows[0]["id"].ToString();
                patient_mobile = dtb.Rows[0]["primary_mobile_number"].ToString();  
                string str_doctorname = dtb.Rows[0]["doctorname"].ToString();
                int listindex = cmbdoctor.FindStringExact(str_doctorname);
                if(listindex>0)
                {
                    cmbdoctor.SelectedIndex = listindex;
                }
            }
            //form2.Closed += (sender1, args) => this.Close();
            flag = false;
        }

        private void lnk_view_template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string pres_id = cmb_prescription_temp.SelectedItem.GetType().GetProperty("Value").GetValue(cmb_prescription_temp.SelectedItem, null).ToString();
            //if (pres_id == "0")
            //{
            //    MessageBox.Show("No selected Prescription Template..", "Template Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    var form2 = new Pappyjoe.consultation_prescription_template();
            //    form2.pres_id = pres_id;
            //    form2.ShowDialog();
            //}
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font.Name, 8, FontStyle.Underline);
            label5.Font = new Font(label5.Font.Name, 8, FontStyle.Bold | FontStyle.Underline);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font.Name, 8);
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

        private void txt_Pt_search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lbPatient.Items.Count > 0)
            {
                lbPatient.Focus();
            }
            else if (e.KeyCode == Keys.Enter && lbPatient.Items.Count > 0)
             {
                 if (lbPatient.SelectedItems.Count > 0)
                 {
                     string value = lbPatient.SelectedValue.ToString();
                     DataTable patient = new DataTable();
                     patient = this.ctrlr.get_patient_details(value);
                     if (patient.Rows.Count > 0)
                     {
                         txt_Pt_search.Text = patient.Rows[0]["pt_name"].ToString();
                         txtPatientID.Text = patient.Rows[0]["pt_id"].ToString();
                         patient_id = patient.Rows[0]["id"].ToString();
                         patient_mobile = patient.Rows[0]["primary_mobile_number"].ToString();  
                         lbPatient.Visible = false;
                         txt_Pt_search.Focus();
                     }
                 }
             }
        }

        private void lbPatient_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lbPatient.Items.Count > 0)
            {
                if (lbPatient.SelectedItems.Count > 0)
                {
                    string value = lbPatient.SelectedValue.ToString();
                    DataTable patient = new DataTable();
                    patient = this.ctrlr.get_patient_details(value);
                    if (patient.Rows.Count > 0)
                    {
                        txt_Pt_search.Text = patient.Rows[0]["pt_name"].ToString();
                        txtPatientID.Text = patient.Rows[0]["pt_id"].ToString();
                        patient_id = patient.Rows[0]["id"].ToString();
                        patient_mobile = patient.Rows[0]["primary_mobile_number"].ToString(); 
                        lbPatient.Visible = false;
                        txt_Pt_search.Focus();
                    }
                }
            }
        }

        private void txt_procedure_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && lst_procedure.Items.Count > 0)
            {
                lst_procedure.Focus();
            }
             else if (e.KeyCode == Keys.Enter && lst_procedure.Items.Count > 0)
             {

                 if (lst_procedure.SelectedItems.Count > 0)
                 {
                     string value = lst_procedure.SelectedValue.ToString();
                     DataTable procedure = new DataTable();
                     procedure = this.ctrlr.procedure_details(value);
                     if (procedure.Rows.Count > 0)
                     {
                         txt_procedure.Text = procedure.Rows[0]["name"].ToString();
                         txt_cost.Text = procedure.Rows[0]["cost"].ToString();
                         lst_procedure.Visible = false;
                     }

                 }
             }
        }

        private void lst_procedure_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lst_procedure.Items.Count > 0)
            {
                if (lst_procedure.SelectedItems.Count > 0)
                {
                    string value = lst_procedure.SelectedValue.ToString();
                    DataTable procedure = new DataTable();
                    procedure = this.ctrlr.procedure_details(value);
                    if (procedure.Rows.Count > 0)
                    {
                        txt_procedure.Text = procedure.Rows[0]["name"].ToString();
                        txt_cost.Text = procedure.Rows[0]["cost"].ToString();
                        lst_procedure.Visible = false;
                    }
                }
            }
        }

        private void cmb_prescription_temp_MouseClick(object sender, MouseEventArgs e)
        {
           
              
        }

        private void txt_remarks_MouseClick(object sender, MouseEventArgs e)
        {
            lst_procedure.Visible = false;
            lbPatient.Visible = false;
        }

        private void cmbdoctor_MouseClick(object sender, MouseEventArgs e)
        {
            lst_procedure.Visible = false;
            lbPatient.Visible = false;
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            lst_procedure.Visible = false;
            lbPatient.Visible = false;
        }
        public void fill_DrugPrescrptn(DataTable dt4)
        {
          
            string strstock = "";
            //presdruggrid.Columns.Add("id", "xt");
            //presdruggrid.Columns.Add("drug", "xt");
            //presdruggrid.Columns.Add("stock", "xt");
            //presdruggrid.Columns[0].Visible = false;
            //presdruggrid.Columns[1].Width = 200;
            //presdruggrid.Columns[2].Width = 150;
            //presdruggrid.Columns[3].Visible = false;
            for (int j = 0; j < dt4.Rows.Count; j++)
                presdruggrid.Columns[4].Visible = false;
            for (int j = 0; j < dt4.Rows.Count; j++)
            {
                if (dt4.Rows[j]["inventory_id"].ToString() == "0")
                {
                    strstock = "(Not sold)";
                }
                else
                {
                    strstock = "(Not sold)";
                   
                    DataTable dtstock = this.ctrlr.drug_instock(dt4.Rows[j]["inventory_id"].ToString());
                    if (dtstock.Rows.Count > 0)
                    {
                        string dou_stock = dtstock.Rows[0]["Stock"].ToString();
                        if (dou_stock != "")
                        {
                            strstock = "(In stock)";
                        }
                        else
                        {
                            strstock = "(Out-of-stock)";
                        }
                    }
                }
                presdruggrid.Rows.Add(dt4.Rows[j]["id"].ToString(), dt4.Rows[j]["name"].ToString(), dt4.Rows[j]["type"].ToString() + "  " + strstock);
                if (strstock == "(Not sold)")
                { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Red; }
                else if (strstock == "(Out-of-stock)")
                { presdruggrid.Rows[j].Cells[2].Style.ForeColor = Color.Blue; }
                presdruggrid.Rows[j].Cells[2].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }   
        }

        private void txt_Prescrptn_TextChanged(object sender, EventArgs e)
        {
            if (txt_Prescrptn.Text != "")
            {
                DataTable dtb =this.ctrlr.get_prescriptnwthname(txt_Prescrptn.Text);
                if (dtb.Rows.Count > 0)
                {
                    presdruggrid.Rows.Clear();
                    fill_DrugPrescrptn(dtb);
                    
                }
                else
                {
                    presdruggrid.Rows.Clear();
                }
            }
            else
            {
                DataTable dtb1 = this.ctrlr.get_prescriptn();
                presdruggrid.Rows.Clear();
                fill_DrugPrescrptn(dtb1);
            }
        }

        private void presdruggrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (presdruggrid.Rows.Count > 0 && e.RowIndex >= 0)
            {

                if (drugspanel.Visible == true)
                {
                    DialogResult yesno = MessageBox.Show("You missed to Click on 'Add' button  under prescription..., Do you want to add another drug..??", "Drug Not Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (yesno == DialogResult.Yes)
                    {
                        drugspanel.Visible = true;
                        dataGridView_drugnew.Visible = false;
                        int r = e.RowIndex;
                        id1 = presdruggrid.Rows[r].Cells[0].Value.ToString();
                        DataTable dt = this.ctrlr.drug_dtls(id1);
                        if (dt.Rows.Count > 0)
                        {
                            drugnametext.Text = dt.Rows[0]["name"].ToString();
                            txtStrengthno.Text = dt.Rows[0]["strength_gr"].ToString();
                            strengthcombo.Text = dt.Rows[0]["strength"].ToString();
                            drug_type = dt.Rows[0][3].ToString();
                            richTxtInsrtuction.Text = "";
                            richTxtInsrtuction.Text = dt.Rows[0]["instructions"].ToString();
                        }
                    }
                }
                else
                {
                    drugspanel.Visible = true;
                    dataGridView_drugnew.Visible = false;
                    int r = e.RowIndex;
                    id1 = presdruggrid.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.ctrlr.drug_dtls(id1);
                    if (dt.Rows.Count > 0)
                    {
                        drugnametext.Text = dt.Rows[0]["name"].ToString();
                        txtStrengthno.Text = dt.Rows[0]["strength_gr"].ToString();
                        strengthcombo.Text = dt.Rows[0]["strength"].ToString();
                        drug_type = dt.Rows[0][3].ToString();
                        richTxtInsrtuction.Text = "";
                        richTxtInsrtuction.Text = dt.Rows[0]["instructions"].ToString();
                    }
                }
            }
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (drugnametext.Text != "")
                {
                    string dur = "";
                    string food = "";
                    //if (numericUpDownMorning.Value > 0 && numericUpDownNoon.Value > 0 && numericUpDownNight.Value > 0 && numericUpDownDuration.Value >0)
                    //{
                    //    if (radioButtonBfrFood.Checked || radioButtonAftrFood.Checked)
                    //    {
                    food = "";
                    if (radioButtonBfrFood.Checked)
                    {
                        food = radioButtonBfrFood.Text.ToString();
                    }
                    else if (radioButtonAftrFood.Checked)
                    {
                        food = radioButtonAftrFood.Text.ToString();
                    }
                    if (cmbDuration.Text == "")
                    {
                        dur = "Period Not mentioned";
                    }
                    else
                    {
                        dur = cmbDuration.Text;
                    }
                    string strstatus = "1";
                    if (checkBoxShowTime.Checked == true)
                    {
                        strstatus = "1";
                    }
                    else
                    {
                        strstatus = "0";
                    }
                    string Note = "";
                    string NoteData = "";
                    NoteData = richTxtInsrtuction.Text;
                    Note = NoteData.Replace("'", " ");
                    dataGridView_drugnew.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_drugnew.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView_drugnew.Rows.Add(drugnametext.Text, txtStrengthno.Text, strengthcombo.Text, numericUpDownDuration.Value, dur, numericUpDownMorning.Value, numericUpDownNoon.Value, numericUpDownNight.Value, food, Note, id1, drug_type);
                    dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[12].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                    dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Height = 30;
                    img.ImageLayout = DataGridViewImageCellLayout.Normal;
                    dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[13].Value = strstatus;
                    richTxtInsrtuction.Text = "";
                    radioButtonAftrFood.Checked = false;
                    radioButtonBfrFood.Checked = false;
                    dataGridView_drugnew.Visible = true;
                    drugspanel.Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drugspanel.Visible = false;
            dataGridView_drugnew.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView2.Rows.Count>0 && e.RowIndex>=0)
            {
                try
                {
                    drugspanel.Visible = false;
                    dataGridView_drugnew.Visible = true;
                    dataGridView_drugnew.Rows.Clear();
                    int r = e.RowIndex;
                    string idtemp = dataGridView2.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.ctrlr.get_template(idtemp);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dataGridView_drugnew.Rows.Add(dt.Rows[i]["drug_name"].ToString(), dt.Rows[i]["strength"].ToString(), dt.Rows[i]["strength_gr"].ToString(), dt.Rows[i]["duration"].ToString(), dt.Rows[i]["duration_period"].ToString(), dt.Rows[i]["morning"].ToString(), dt.Rows[i]["noon"].ToString(), dt.Rows[i]["night"].ToString(), dt.Rows[i]["food"].ToString(), dt.Rows[i]["add_instruction"].ToString(), dt.Rows[i]["drug_id"].ToString(), dt.Rows[i]["drug_type"].ToString());
                        dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[12].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Height = 30;
                        img.ImageLayout = DataGridViewImageCellLayout.Normal;
                        dataGridView_drugnew.Rows[dataGridView_drugnew.Rows.Count - 1].Cells[13].Value = dt.Rows[i]["status"].ToString();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView_drugnew_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dataGridView_drugnew.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 12)
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            dataGridView_drugnew.Rows.RemoveAt(this.dataGridView_drugnew.SelectedRows[0].Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
