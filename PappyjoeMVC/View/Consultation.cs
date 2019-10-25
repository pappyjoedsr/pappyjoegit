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
namespace PappyjoeMVC.View
{
    public partial class Consultation : Form
    {
        public static bool flag = false;
        string Prescription_bill_status = "No";
        public string doctor_id = "", patient_id = "";
        string payment_date = "", receipt = "";
        string includeheader = "0";
        string includelogo = "0"; System.Drawing.Image logo = null;
        string logo_name = "";
        public static string newptid = "", ptname = "";
        Consultation_controller cntrl = new Consultation_controller();
        private string id;

        public Consultation()
        {
            InitializeComponent();
        }

        public Consultation(string text, string id)
        {
            InitializeComponent();
            ptname = text;
            newptid = id;
        }

        private void Consultation_Load(object sender, EventArgs e)
        {
            DataTable dtb_prescription = this.cntrl.Load_temlate();// db.table("select * from tbl_templates_main order by id");
            // cmb_prescription_temp.DataSource = dtb_prescription;
            //cmb_prescription_temp.ValueMember = "id";
            //cmb_prescription_temp.DisplayMember = "templates";
            //cmb_prescription_temp.Items.Insert(0, "-Select-");
            cmb_prescription_temp.DisplayMember = "Text";
            cmb_prescription_temp.ValueMember = "Value";
            cmb_prescription_temp.Items.Add(new { Text = "-Select-", Value = 0 });
            if (dtb_prescription.Rows.Count > 0)
            {
                for (int r = 0; r < dtb_prescription.Rows.Count; r++)
                {
                    int id = (int)Convert.ToInt16(dtb_prescription.Rows[r]["id"].ToString());
                    cmb_prescription_temp.Items.Add(new { Text = dtb_prescription.Rows[r]["templates"].ToString(), Value = id });
                }
            }
            cmb_prescription_temp.SelectedIndex = 0;
            DataTable dt = this.cntrl.Load_doctor();// db.table("select DISTINCT id,doctor_name from tbl_doctor  where login_type='doctor' or login_type='admin' order by doctor_name");
            if (dt.Rows.Count > 0)
            {
                cmbdoctor.DataSource = dt;
                cmbdoctor.DisplayMember = "doctor_name";
                cmbdoctor.ValueMember = "id";

                DataTable dt_doctor = this.cntrl.Load_dctrname(doctor_id);// db.table("select id,doctor_name from tbl_doctor  where id='" + doctor_id + "'");
                if (dt_doctor.Rows.Count > 0)
                {

                    int int_doctor = cmbdoctor.FindStringExact(dt_doctor.Rows[0]["doctor_name"].ToString());
                    if (int_doctor >= 0)
                    {
                        cmbdoctor.SelectedIndex = int_doctor;
                    }
                }
            }
            Consultation_load();
        }

        private void txt_Pt_search_TextChanged(object sender, EventArgs e)
        {
            if (flag == false)
            {
                if (txt_Pt_search.Text != "")
                {
                    lbPatient.Show();
                    lbPatient.Location = new Point(txt_Pt_search.Location.X, 27);
                    DataTable dtdr = this.cntrl.search_patient(txt_Pt_search.Text);// db.table("select pt_id,pt_name from tbl_patient where pt_name like '%" + txt_Pt_search.Text + "%'  ");
                    if(dtdr.Rows.Count>0)
                    {
                        lbPatient.DataSource = dtdr;
                        lbPatient.DisplayMember = "pt_name";
                        lbPatient.ValueMember = "pt_id";
                    }
                    else
                    {
                        lbPatient.Hide();
                    }
                    
                }
                else
                {
                    DataTable dtdr = this.cntrl.search_patient(txt_Pt_search.Text); //db.table("select pt_id,pt_name from tbl_patient where pt_name like '%" + txt_Pt_search.Text + "%'  ");
                    lbPatient.DataSource = dtdr;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "pt_id";
                }
            }
        }

        private void txt_Pt_search_Click(object sender, EventArgs e)
        {
            txt_Pt_search.Text = "";
        }

        private void txt_procedure_Click(object sender, EventArgs e)
        {
            txt_procedure.Text = "";
        }

        private void txt_procedure_TextChanged(object sender, EventArgs e)
        {
            if (txt_procedure.Text != "")
            {
                lst_procedure.Show();
                lst_procedure.Location = new Point(txt_procedure.Location.X, 100);
                DataTable dtdr = this.cntrl.search_procedure(txt_procedure.Text);// db.table("select id,name from tbl_addproceduresettings where name like '%" + txt_procedure.Text + "%'  ");
                lst_procedure.DataSource = dtdr;
                lst_procedure.DisplayMember = "name";
                lst_procedure.ValueMember = "id";
            }
            else
            {
                DataTable dtdr = this.cntrl.search_procedure(txt_procedure.Text);// db.table("select id,name from tbl_addproceduresettings where name like '%" + txt_procedure.Text + "%'  ");
                lst_procedure.DataSource = dtdr;
                lst_procedure.DisplayMember = "name";
                lst_procedure.ValueMember = "id";
            }
        }

        private void lst_procedure_MouseClick(object sender, MouseEventArgs e)
        {
            if (lst_procedure.SelectedItems.Count > 0)
            {
                string value = lst_procedure.SelectedValue.ToString();
                DataTable procedure = new DataTable();
                procedure = this.cntrl.procedure_details(value);// db.table("select id,name,cost from tbl_addproceduresettings where  id='" + value + "'");
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

        private void lbPatient_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbPatient.SelectedItems.Count > 0)
            {
                string value = lbPatient.SelectedValue.ToString();
                DataTable patient = new DataTable();
                patient = this.cntrl.patient_details(value);// db.table("select id, pt_name,pt_id from tbl_patient where pt_id='" + value + "'");
                if (patient.Rows.Count > 0)
                {
                    txt_Pt_search.Text = patient.Rows[0]["pt_name"].ToString();
                    txtPatientID.Text = patient.Rows[0]["pt_id"].ToString();
                    patient_id = patient.Rows[0]["id"].ToString();
                    lbPatient.Visible = false;
                }
                else
                {
                    MessageBox.Show("Please choose  Correct patient....", "Data Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPatientID.Text != "" && txt_procedure.Text != "")
                {
                    int presid = 0;
                    //prescription
                    //prescription_check();
                    int d_id = Convert.ToInt32(cmbdoctor.SelectedValue.ToString());
                    string pres_id = cmb_prescription_temp.SelectedItem.GetType().GetProperty("Value").GetValue(cmb_prescription_temp.SelectedItem, null).ToString();
                    DataTable dtb_prescription = this.cntrl.get_tempid(pres_id);// db.table("select * from tbl_templates_main where id='" + pres_id + "'");
                    if (dtb_prescription.Rows.Count > 0)
                    {
                        DataTable dt_prs = this.cntrl.get_templateid(dtb_prescription.Rows[0]["id"].ToString());// db.table("select * from tbl_template where temp_id='" + dtb_prescription.Rows[0]["id"].ToString() + "'");
                        prescription_check(dt_prs);
                        this.cntrl.save_prescriptionMain(patient_id , d_id , Prescription_bill_status , txt_remarks.Text);// db.execute("insert into tbl_prescription_main (pt_id,dr_id,date,pay_status,notes) values('" + patient_id + "','" + d_id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + Prescription_bill_status + "','" + txt_remarks.Text + "')");
                        string dt = this.cntrl.max_presid();// db.table("select MAX(id) from tbl_prescription_main");
                        if (Convert.ToInt32( dt)  > 0)
                        {
                            presid = Int32.Parse(dt);
                        }
                        else
                        {
                            presid = 1;
                        }


                        for (int i = 0; i < dt_prs.Rows.Count; i++)
                        {
                            //if (dataGridView_drugnew[13, i].Value.ToString() != "")
                            //{ strstatus = dataGridView_drugnew[13, i].Value.ToString(); }
                            this.cntrl.save_prescription(presid , patient_id , cmbdoctor.Text ,d_id.ToString(), dt_prs.Rows[i]["drug_name"].ToString(), dt_prs.Rows[i]["strength"].ToString() , dt_prs.Rows[i]["strength_gr"].ToString(),dt_prs.Rows[i]["duration_period"].ToString() , dt_prs.Rows[i]["morning"].ToString(), dt_prs.Rows[i]["noon"].ToString(), dt_prs.Rows[i]["night"].ToString() , dt_prs.Rows[i]["food"].ToString() , dt_prs.Rows[i]["add_instruction"].ToString() , dt_prs.Rows[i]["drug_type"].ToString(), dt_prs.Rows[i]["status"].ToString(), dt_prs.Rows[i]["drug_id"].ToString());//
                          //  db.table("insert into tbl_prescription (pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id) values('" + presid + "','" + patient_id + "','" + cmbdoctor.Text + "','" + d_id + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + dt_prs.Rows[i]["drug_name"].ToString() + "','" + dt_prs.Rows[i]["strength"].ToString() + "','" + dt_prs.Rows[i]["strength_gr"].ToString() + "','','" + dt_prs.Rows[i]["duration_period"].ToString() + "','" + dt_prs.Rows[i]["morning"].ToString() + "','" + dt_prs.Rows[i]["noon"].ToString() + "','" + dt_prs.Rows[i]["night"].ToString() + "','" + dt_prs.Rows[i]["food"].ToString() + "','" + dt_prs.Rows[i]["add_instruction"].ToString() + "','" + dt_prs.Rows[i]["drug_type"].ToString() + "'," + dt_prs.Rows[i]["status"].ToString() + ",'" + dt_prs.Rows[i]["drug_id"].ToString() + "')");
                        }
                    }


                    //completed id
                     this.cntrl.save_completedid(patient_id);// db.execute("insert into tbl_completed_id (completed_date,patient_id,review) values('" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + patient_id + "','NO')");
                    string  dt_CMain = this.cntrl.max_completedid();// db.table("select MAX(id) from tbl_completed_id");
                    int completed_id, j1 = 0;
                    try
                    {
                        if (Int32.Parse(dt_CMain)== 0)
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
                     this.cntrl.save_completed_details(j1 , patient_id , lst_procedure.SelectedValue.ToString(), txt_procedure.Text, txt_cost.Text , txt_cost.Text , txt_instruction.Text , cmbdoctor.SelectedValue.ToString());//  db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth) values('" + j1 + "','" + patient_id + "','" + lst_procedure.SelectedValue.ToString() + "','" + txt_procedure.Text + "','1','" + txt_cost.Text + "','INR','0','" + txt_cost.Text + "','0','" + txt_instruction.Text + "','0','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + cmbdoctor.SelectedValue.ToString() + "','0','')");

                    string dt_Compl_proce = this.cntrl.max_completeProcedure();// db.table("select MAX(id) from tbl_completed_procedures");
                    long completed_procedures_id = 0;
                    try
                    {
                        if (Int32.Parse(dt_Compl_proce) == 0)
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
                         this.cntrl.update_review(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"), j1);// db.execute("UPDATE tbl_completed_id SET review='YES',Review_date='" + dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") + "' WHERE id='" + j1 + "'");

                         this.cntrl.update_prescription_review(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"), presid);// db.execute("UPDATE tbl_prescription_main SET review='YES',Review_date='" + dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") + "' WHERE id='" + presid + "'");

                        DataTable dt_review = this.cntrl.get_reviewId(patient_id,dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"));// db.table("SELECT id FROM tbl_review where  pt_id='" + patient_id + "' and fix_datetime='" + DateTime.Now.ToString("yyyy-MM-dd") + "' and review_datetime='" + dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") + "' ORDER BY id");
                        if (dt_review.Rows.Count == 0)
                        {
                            this.cntrl.save_review(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"), patient_id);//  db.execute("insert into  tbl_review(fix_datetime,review_datetime,pt_id,status) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") + "','" + patient_id + "','YES')");
                        }
                    }
                    else
                    {
                         this.cntrl.update_review_No(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"), j1);// db.execute("UPDATE tbl_completed_id SET review='NO' ,Review_date='" + dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") + "'  WHERE id='" + j1 + "'");

                        this.cntrl.update_prescription_review_NO(dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm"), presid);// db.execute("UPDATE tbl_prescription_main SET review='NO',Review_date='" + dtp_nextreview.Value.ToString("yyyy-MM-dd HH:mm") + "'  WHERE id='" + presid + "'");
                    }
                    string invoice = "";
                    DataTable invNo = null;
                    invNo = this.cntrl.Get_invoice_prefix();// db.table("select invoice_prefix,invoice_number from tbl_invoice_automaticid where invoive_automation='Yes' ");
                    if (invNo.Rows.Count > 0)
                    {
                        invoice = invNo.Rows[0]["invoice_prefix"].ToString() + invNo.Rows[0]["invoice_number"].ToString();
                    }

                    decimal totalcost = 0;
                    totalcost = Convert.ToDecimal(txt_cost.Text) * 1;
                    this.cntrl.save_invoice_main(patient_id, txt_Pt_search.Text, invoice);// db.execute("insert into tbl_invoices_main (date,pt_id,pt_name,invoice,status,type) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + patient_id + "','" + txt_Pt_search.Text + "','" + invoice + "','0','service')");
                    string dt1 = this.cntrl.get_invoiceMain_maxid();// db.table("select MAX(id) from tbl_invoices_main");
                    long Invoice_main_id = 0;
                    try
                    {
                        if (Int32.Parse(dt1)==0)
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

                    this.cntrl.save_invoice_details(invoice , txt_Pt_search.Text , patient_id ,lst_procedure.SelectedValue.ToString(), txt_procedure.Text, txt_cost.Text , txt_cost.Text , cmbdoctor.SelectedValue.ToString(), Invoice_main_id,completed_procedures_id);// db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,total,date,total_cost,total_discount,dr_id,discountin_rs,total_payment,invoice_main_id,tax_inrs,tax,total_tax,grant_total,plan_id,completed_id,notes) values('" + invoice + "','" + txt_Pt_search.Text + "','" + patient_id + "','" + lst_procedure.SelectedValue.ToString() + "','" + txt_procedure.Text + "','1','" + txt_cost.Text + "','0','INR','" + txt_cost.Text + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','100','','" + cmbdoctor.SelectedValue.ToString() + "','','100','" + Invoice_main_id + "','0','NA','0','100','0','" + completed_procedures_id + "','')");

                    string invoauto =this.cntrl. get_invoicenumber();// db.table("select invoice_number from tbl_invoice_automaticid");
                    int invoautoup = int.Parse(invoauto) + 1;
                    this.cntrl.update_invnumber(invoautoup);//  db.execute("update tbl_invoice_automaticid set invoice_number='" + invoautoup + "'");
                    //payment
                    DataTable rec_receipt = this.cntrl.receipt_number();// db.table("select receipt_number,receipt_prefix from tbl_receipt_automationid where receipt_automation='Yes'");
                    receipt = rec_receipt.Rows[0]["receipt_prefix"].ToString() + rec_receipt.Rows[0]["receipt_number"].ToString();


                    DataTable cmd22 = this.cntrl.Get_Advance(patient_id);// db.table("select advance from tbl_payment where pt_id='" + patient_id + "'");
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
                    this.cntrl.save_receipt(receipt , advance , txt_cost.Text , invoice , txt_procedure.Text , patient_id , cmbdoctor.SelectedValue.ToString(), txt_cost.Text , txt_Pt_search.Text, Invoice_main_id);//  db.execute("insert into tbl_payment(receipt_no,advance,amount_paid,invoice_no,procedure_name,pt_id,payment_date,dr_id,total,cost,pt_name,mode_of_payment,payment_due)values('" + receipt + "','" + advance + "','" + txt_cost.Text + "','" + invoice + "','" + txt_procedure.Text + "','" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + cmbdoctor.SelectedValue.ToString() + "','" + txt_cost.Text + "','" + txt_cost.Text + "','" + txt_Pt_search.Text + "','Cash','" + Invoice_main_id + "')");
                    //}
                    string rec = this.cntrl.receipt_autoid();// db.table("select receipt_number from tbl_receipt_automationid");
                    int receip = int.Parse(rec) + 1;
                    this.cntrl.update_receiptAutoid(receip);// db.execute("update tbl_receipt_automationid set receipt_number='" + receip + "'");
                    DialogResult print_yesno = System.Windows.Forms.DialogResult.No;
                    print_yesno = MessageBox.Show("Data saved successfully... Do you want a print..??", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (print_yesno == System.Windows.Forms.DialogResult.Yes)
                    {
                        printhtml();
                    }
                    txt_Pt_search.Text = "";
                    txt_procedure.Text = "";
                    txt_remarks.Text = "";
                    txtPatientID.Text = "";
                    txt_cost.Text = "";
                    txt_instruction.Text = "";
                    Consultation_load();
                }
                else
                {
                    if (txtPatientID.Text == "")
                    {
                        MessageBox.Show("Patient Details Not Found", "Patient Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPatientID.Focus();
                    }
                    else if (txt_procedure.Text == "")
                    {
                        MessageBox.Show("Procedure Details Not Found", "Procedure Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_procedure.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Consultation_load()
        {
            DataTable procedure = new DataTable();
            procedure = this.cntrl.get_procedure();// db.table("select id,name,cost from tbl_addproceduresettings where  LOWER(name)='consultation'");
            if (procedure.Rows.Count > 0)
            {
                txt_procedure.Text = procedure.Rows[0]["name"].ToString();
                txt_cost.Text = procedure.Rows[0]["cost"].ToString();
                lst_procedure.Visible = false;
            }
        }

        private void lnk_view_template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string pres_id = cmb_prescription_temp.SelectedItem.GetType().GetProperty("Value").GetValue(cmb_prescription_temp.SelectedItem, null).ToString();
            if (pres_id == "0")
            {
                MessageBox.Show("No selected Prescription Template..", "Template Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var form2 = new PappyjoeMVC.View.consultation_prescription_template();
                form2.pres_id = pres_id;
                form2.ShowDialog();
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            //label5.Font = new Font(label5.Font.Name, 10, FontStyle.Underline);
            //label5.Font = new Font(label5.Font.Name, 10, FontStyle.Bold | FontStyle.Underline);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font.Name, 10, FontStyle.Underline);
            label5.Font = new Font(label5.Font.Name, 10, FontStyle.Bold | FontStyle.Underline);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.Font = new Font(label5.Font.Name, 10);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.consultation_new_patient();
            form2.ShowDialog();
            if (newptid != "")
            {
                flag = true;
                DataTable dtb = this.cntrl.get_patient_details(newptid);// db.table("select id,pt_id,pt_name from tbl_patient where id='" + newptid + "'");
                txtPatientID.Text = dtb.Rows[0]["pt_id"].ToString();
                txt_Pt_search.Text = dtb.Rows[0]["pt_name"].ToString();
                patient_id = dtb.Rows[0]["id"].ToString();
            }
            //form2.Closed += (sender1, args) => this.Close();
            flag = false;
        }

        public void prescription_check(DataTable dtb)//aswini
        {
            try
            {
                if (dtb.Rows.Count > 0)
                {
                    int count = dtb.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataTable dt4 = this.cntrl.get_invid(dtb.Rows[i]["drug_id"].ToString());// db.table("select id,inventory_id from tbl_adddrug where id='" + dtb.Rows[i]["drug_id"].ToString() + "' and inventory_id<>0 ORDER BY id DESC");
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
        public void printhtml()
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
                string str_website = ""; string doctor = "";
                 doctor = this.cntrl.Get_DoctorName(doctor_id.ToString());// db.table("select doctor_name from tbl_doctor where id= '" + doctor_id.ToString() + "'");
                //if (doctor.Rows.Count > 0)
                //{
                    doctorName = doctor;
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                    logo_name = dtp.Rows[0]["path"].ToString();
                //}
                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.cntrl.get_receipt_print_setting();// db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign,include_header,include_logo from  tbl_receipt_printsettings");
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
                            string curFile = this.cntrl.server() + "\\Pappyjoe_utilities\\Logo\\" + logo_name;

                            if (System.IO.File.Exists(curFile))// if (File.Exists(Appath + "\\" + logo_name))
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + curFile + "\\" + logo_name + "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
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
                strsql = "select * from tbl_payment where payment_date='" + payment_date + "' and pt_id='" + patient_id + "' and receipt_no='" + receipt + "'";
                System.Data.DataTable dt_cf = this.cntrl.get_payment_details(payment_date, patient_id, receipt);// db.table(strsql);
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
                    strsql = "";
                    strsql = "select receipt_no,amount_paid,invoice_no,procedure_name,payment_date from tbl_payment where payment_date='" + payment_date + "' and pt_id='" + patient_id + "' and receipt_no='" + receipt + "' order by payment_date";

                    System.Data.DataTable dt_payment = this.cntrl.get_receipt_details(payment_date, patient_id, receipt);// db.table(strsql);
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
    }
}
