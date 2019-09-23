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
namespace PappyjoeMVC.View
{
    public partial class SimpleAppointment : Form
    {
        public event child_form Appointment_list;
        public delegate void child_form(string strappointment);
        public string doctor_id = "0", patient_id = "", patient_name = "";
        public string strApp_id = "";
        bool flag = false;
        public bool template_flag = false;
        SimpleAppointment_controller cntrl = new SimpleAppointment_controller();
        public SimpleAppointment()
        {
            InitializeComponent();
        }

        private void SimpleAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Value = DateTime.Today.AddMonths(+1);
                flag = false; template_flag = false;
                DataTable dt_treatment = new DataTable();
                dt_treatment = this.cntrl.get_All_proceure();// db.table("select id,name,cost from tbl_addproceduresettings ");
                fill_treatment(dt_treatment);
                DataTable dt_prescription = this.cntrl.get_drug_details();// db.table("select id,name, type, strength_gr, strength,inventory_id from tbl_adddrug ORDER BY id DESC");

                fill_DrugPrescrptn(dt_prescription);
                DataTable dt_doctor = this.cntrl.get_all_doctorname();// db.table("select id,doctor_name from tbl_doctor where (login_type='admin'or login_type='doctor' )and activate_login='Yes'");
                if (dt_doctor.Rows.Count > 0)
                {
                    Cmb_Doctor.DataSource = dt_doctor;
                    Cmb_Doctor.ValueMember = "id";
                    Cmb_Doctor.DisplayMember = "doctor_name";
                }
                //DateTime dtHours = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                //for (int cnt = 0; cnt < 288; cnt++)
                //{
                //    cmbStartTime.Items.Insert(cnt, dtHours.ToShortTimeString());
                //    cmbEndTime.Items.Insert(cnt, dtHours.ToShortTimeString());
                //    dtHours = dtHours.AddMinutes(5);
                //}
                //cmbStartTime.SelectedIndex = 10;
                //cmbEndTime.SelectedIndex = 11;
                DataTable dt_complaint = new DataTable();
                dt_complaint = this.cntrl.show_compl();// db.table("select id,name from tbl_complaints");
                fill_Complaints(dt_complaint);
                DataTable dt_Diaganosis = new DataTable();
                dt_Diaganosis = this.cntrl.show_diagno();// db.table("select * from tbl_diagnosis");
                fill_Diagnosis(dt_Diaganosis);
                DataTable dt_notes = new DataTable();
                dt_notes = this.cntrl.show_note();// db.table("select * from tbl_notes");
                fill_notes(dt_notes);
                disabledAllContrls();
                flag = true;
                DataTable dt = this.cntrl.Fill_unit_combo();// db.table("select * from tbl_unit");
                strengthcombo.DataSource = dt;
                strengthcombo.DisplayMember = "name";
                strengthcombo.ValueMember = "id";
                if (strengthcombo.Items.Count > 1)
                {
                    strengthcombo.SelectedIndex = 0;
                }
                if (duracombo.Items.Count > 1)
                {
                    duracombo.SelectedIndex = 0;
                }
                DataTable dt5 = this.cntrl.Fill_LoadTax();// db.table("select id,tax_name from tbl_tax");
                if (dt5.Rows.Count > 0)
                {
                    Cmb_tax.DataSource = dt5;
                    Cmb_tax.DisplayMember = "tax_name";
                    Cmb_tax.ValueMember = "id";
                    Cmb_tax.Text = "";
                }

                dgv_prescrptn.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                dgv_fillPrescription.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_filltreatment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_treatment.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                foreach (DataGridViewColumn cl in dgv_prescrptn.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn cl in dgv_treatment.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgv_treatment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Regular);
                dgv_notes.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                dgv_Complaints.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                dgv_Diagnosis.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                DataTable invNo = null;
                invNo = this.cntrl.Get_invoice_prefix();// db.table("select invoice_prefix,invoice_number from tbl_invoice_automaticid where invoive_automation='Yes' ");
                if (invNo.Rows.Count > 0)
                {
                    text_billno.Text = invNo.Rows[0]["invoice_prefix"].ToString() + invNo.Rows[0]["invoice_number"].ToString();
                }
                else
                {
                    text_billno.ReadOnly = false;
                }


                DataTable dtb = this.cntrl.get_pt_details(patient_id);// db.table("select id, pt_id,pt_name,primary_mobile_number,gender,age,street_address,locality,city,pincode from tbl_patient where id='" + patient_id + "'");
                if (dtb.Rows.Count > 0)
                {
                    txtPatientID.Text = dtb.Rows[0]["pt_id"].ToString();
                    patient_id = dtb.Rows[0]["id"].ToString();
                    txt_Ptname.Text = dtb.Rows[0]["pt_name"].ToString();
                    txt_mob.Text = dtb.Rows[0]["primary_mobile_number"].ToString();
                    txt_Loca.Text = dtb.Rows[0]["locality"].ToString();
                    txt_City.Text = dtb.Rows[0]["city"].ToString();
                    txtAge.Text = dtb.Rows[0]["age"].ToString();
                    //linkLabel_Name.Text = dtb.Rows[0]["pt_name"].ToString();
                    //linkLabel_id.Text = dtb.Rows[0]["pt_id"].ToString();
                    if (dtb.Rows[0]["gender"].ToString().Trim() == "Male")
                    {
                        radMale.Checked = true;
                        radFemale.Checked = false;
                    }
                    else if (dtb.Rows[0]["gender"].ToString().Trim() == "Female")
                    {
                        radFemale.Checked = true;
                        radMale.Checked = false;
                    }
                    else
                    {
                        radFemale.Checked = false;
                        radMale.Checked = false;
                    }
                    EnabledAllContrls();
                }


                DataTable App_dtb = this.cntrl.get_EHR_details(strApp_id);// db.table("select EHR_status,EHR_clinicalfindings,EHR_treatment,EHR_prescription,EHR_invoice from tbl_appointment where id='" + strApp_id + "' AND EHR_status='YES'");
                if (App_dtb.Rows.Count > 0)
                {
                    btn_ClearAll.Visible = false;
                    btn_Add.Visible = false;
                    this.Text = "Simplest Appointment [VIEW MODE]";
                    groupBox6.Enabled = false;
                    groupBox7.Enabled = false;
                    groupBox8.Enabled = false;

                    if (App_dtb.Rows[0]["EHR_clinicalfindings"].ToString() != "")
                    {
                        DataTable Dt_Complaint = this.cntrl.getComplaints(App_dtb.Rows[0]["EHR_clinicalfindings"].ToString());// db.table("SELECT complaint_id FROM tbl_pt_chief_compaints WHERE clinical_finding_id='" + App_dtb.Rows[0]["EHR_clinicalfindings"] + "'");
                        dgv_Complaints.Columns[2].Visible = false;
                        if (Dt_Complaint.Rows.Count > 0)
                        {
                            for (int i = 0; i < Dt_Complaint.Rows.Count; i++)
                            {
                                dgv_Complaints.Rows.Add("0", Dt_Complaint.Rows[i][0].ToString());
                                dgv_Complaints.Rows[dgv_Complaints.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Black;
                                dgv_Complaints.Rows[dgv_Complaints.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        DataTable Dt_diagnosis = this.cntrl.get_diagno(App_dtb.Rows[0]["EHR_clinicalfindings"].ToString());// db.table("SELECT diagnosis_id FROM  tbl_pt_diagnosis WHERE clinical_finding_id='" + App_dtb.Rows[0]["EHR_clinicalfindings"] + "'");
                        if (Dt_diagnosis.Rows.Count > 0)
                        {
                            dgv_Diagnosis.Columns[2].Visible = false;
                            for (int i = 0; i < Dt_diagnosis.Rows.Count; i++)
                            {
                                dgv_Diagnosis.Rows.Add("0", Dt_diagnosis.Rows[i][0].ToString());
                                dgv_Diagnosis.Rows[dgv_Diagnosis.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Black;
                                dgv_Diagnosis.Rows[dgv_Diagnosis.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        DataTable Dt_Note = this.cntrl.get_note(App_dtb.Rows[0]["EHR_clinicalfindings"].ToString());// db.table("SELECT note_name FROM tbl_pt_note WHERE clinical_findings_id='" + App_dtb.Rows[0]["EHR_clinicalfindings"] + "'");
                        if (Dt_Note.Rows.Count > 0)
                        {
                            dgv_notes.Columns[2].Visible = false;
                            for (int i = 0; i < Dt_Note.Rows.Count; i++)
                            {
                                dgv_notes.Rows.Add("0", Dt_Note.Rows[i][0].ToString());
                                dgv_notes.Rows[dgv_notes.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Black;
                                dgv_notes.Rows[dgv_notes.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        dgv_Complaints.Enabled = false;
                        dgv_Diagnosis.Enabled = false;
                        dgv_notes.Enabled = false;
                    }// Chief Complaint End

                    //if (App_dtb.Rows[0]["EHR_treatment"].ToString() != "")
                    //{
                    //    EHR_treat = App_dtb.Rows[0]["EHR_treatment"].ToString();
                    //    decimal grandTotal = 0, Grand_Discount = 0, Total_tax = 0;
                    //    DataTable Dt_Treatment = db.table("SELECT plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth FROM tbl_completed_procedures WHERE plan_main_id='" + App_dtb.Rows[0]["EHR_treatment"].ToString() + "'");

                    //    if (Dt_Treatment.Rows.Count > 0)
                    //    {
                    //        dgv_treatment.Columns[10].Visible = false;
                    //        for (int i = 0; i < Dt_Treatment.Rows.Count; i++)
                    //        {
                    //            dgv_treatment.Rows.Add(Dt_Treatment.Rows[i]["procedure_id"], Dt_Treatment.Rows[i]["procedure_name"], Dt_Treatment.Rows[i]["quantity"], Dt_Treatment.Rows[i]["cost"], Dt_Treatment.Rows[i]["discount_type"], Dt_Treatment.Rows[i]["discount"], Dt_Treatment.Rows[i]["discount_inrs"], 0, 0, Dt_Treatment.Rows[i]["total"], PappyjoeMVC.Properties.Resources.deleteicon);

                    //        }
                    //    }
                    //    for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                    //    {
                    //        grandTotal = grandTotal + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString());
                    //        Grand_Discount = Grand_Discount + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString());
                    //        Total_tax = Total_tax + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString());
                    //    }
                    //    Lab_GrandTotal.Text = String.Format("{0:C0}", grandTotal);//.ToString("#0.00");
                    //    Lab_DisInrs.Text = String.Format("{0:C0}", Grand_Discount);
                    //    Lab_TotalTax.Text = String.Format("{0:C0}", Total_tax);

                    //    DataTable Dt_Review = db.table("SELECT review,review_date  FROM tbl_completed_id WHERE id='" + App_dtb.Rows[0]["EHR_treatment"].ToString() + "' and review='YES'");
                    //    if (Dt_Review.Rows.Count > 0)
                    //    {
                    //        checkBoxReview.Checked = true;
                    //        dateTimePicker1.Value = Convert.ToDateTime(Dt_Review.Rows[0][1].ToString());

                    //    }

                    //} // Treatment End

                    //if (App_dtb.Rows[0]["EHR_invoice"].ToString() != "")
                    //{
                    //    EHR_invoice = App_dtb.Rows[0]["EHR_invoice"].ToString();
                    //}


                    //if (App_dtb.Rows[0]["EHR_prescription"].ToString() != "")
                    //{
                    //    EHR_Pre = App_dtb.Rows[0]["EHR_prescription"].ToString();
                    //    DataTable Dt_Prescription = db.table("SELECT pres_id,pt_id,dr_name,dr_id,date,drug_name, strength, strength_gr,duration_unit, duration_period,morning,noon,night,food,add_instruction, drug_type, status, drug_id  FROM tbl_prescription WHERE pres_id='" + App_dtb.Rows[0]["EHR_prescription"].ToString() + "'");
                    //    if (dt_prescription.Rows.Count > 0)
                    //    {
                    //        dgv_prescrptn.Columns[12].Visible = false;
                    //        for (int i = 0; i < Dt_Prescription.Rows.Count; i++)
                    //        {
                    //            dgv_prescrptn.Rows.Add(Dt_Prescription.Rows[i]["drug_id"], Dt_Prescription.Rows[i]["drug_name"], Dt_Prescription.Rows[i]["strength_gr"] + "" + Dt_Prescription.Rows[i]["strength"], Dt_Prescription.Rows[i]["strength_gr"], Dt_Prescription.Rows[i]["duration_unit"] + "" + Dt_Prescription.Rows[i]["duration_period"], Dt_Prescription.Rows[i]["duration_period"], Dt_Prescription.Rows[i]["morning"], Dt_Prescription.Rows[i]["noon"], Dt_Prescription.Rows[i]["night"], Dt_Prescription.Rows[i]["food"], Dt_Prescription.Rows[i]["add_instruction"], Dt_Prescription.Rows[i]["drug_type"], PappyjoeMVC.Properties.Resources.deleteicon);
                    //        }
                    //    }

                    //}


                }



            }
            catch(Exception ex)
            {

            }
        }
        public void fill_treatment(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_filltreatment.Rows.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_filltreatment.Rows.Add();
                    dgv_filltreatment.Rows[i].Cells["T_id"].Value = dtb.Rows[i]["id"].ToString();
                    dgv_filltreatment.Rows[i].Cells["Treatmnt"].Value = dtb.Rows[i]["name"].ToString();
                    dgv_filltreatment.Rows[i].Cells["Cost_Tret"].Value = dtb.Rows[i]["cost"].ToString();
                    dgv_filltreatment.Columns["T_id"].Visible = false;
                }
            }
        }
        public void fill_DrugPrescrptn(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_fillPrescription.Rows.Clear();

                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_fillPrescription.Rows.Add();

                    dgv_fillPrescription.Rows[i].Cells["P_id"].Value = dtb.Rows[i][0].ToString();
                    dgv_fillPrescription.Rows[i].Cells["Drug"].Value = dtb.Rows[i]["name"].ToString();
                    dgv_fillPrescription.Rows[i].Cells["_Strength"].Value = dtb.Rows[i]["strength_gr"].ToString() + ' ' + dtb.Rows[i]["strength"].ToString();
                    dgv_fillPrescription.Columns["P_id"].Visible = false;
                }
            }
        }
        public void fill_Complaints(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_fillComplaints.Rows.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_fillComplaints.Rows.Add();
                    dgv_fillComplaints.Rows[i].Cells["i_d"].Value = dtb.Rows[i][0].ToString();
                    dgv_fillComplaints.Rows[i].Cells["cmplants"].Value = dtb.Rows[i][1].ToString();
                    dgv_fillComplaints.Columns["i_d"].Visible = false;
                }
            }
        }
        public void fill_Diagnosis(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dhv_fillDiagnosis.Rows.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dhv_fillDiagnosis.Rows.Add();
                    dhv_fillDiagnosis.Rows[i].Cells["Did"].Value = dtb.Rows[i][0].ToString();
                    dhv_fillDiagnosis.Rows[i].Cells["Diagn"].Value = dtb.Rows[i][1].ToString();
                    dhv_fillDiagnosis.Columns["Did"].Visible = false;
                }
            }
        }
        public void fill_notes(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_fillNotes.Rows.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    dgv_fillNotes.Rows.Add();
                    dgv_fillNotes.Rows[i].Cells["N_id"].Value = dtb.Rows[i][0].ToString();
                    dgv_fillNotes.Rows[i].Cells["Notes"].Value = dtb.Rows[i][1].ToString();
                    dgv_fillNotes.Columns["N_id"].Visible = false;
                }
            }
        }
        public void disabledAllContrls()
        {
            txt_cmpltsSearch.Enabled = false;
            txt_DiaSearch.Enabled = false;
            txt_Notes.Enabled = false;
            txt_treatment.Enabled = false;
            txt_Prescrptn.Enabled = false;
            dgv_fillComplaints.Enabled = false;
            dhv_fillDiagnosis.Enabled = false;
            dgv_fillNotes.Enabled = false;
            dgv_filltreatment.Enabled = false;
            dgv_fillPrescription.Enabled = false;
            linkLabel1.Enabled = false;
            linkLab_template.Enabled = false;
        }
        public void EnabledAllContrls()
        {
            txt_cmpltsSearch.Enabled = true;
            txt_DiaSearch.Enabled = true;
            txt_Notes.Enabled = true;
            txt_treatment.Enabled = true;
            txt_Prescrptn.Enabled = true;
            dgv_fillComplaints.Enabled = true;
            dhv_fillDiagnosis.Enabled = true;
            dgv_fillNotes.Enabled = true;
            dgv_filltreatment.Enabled = true;
            dgv_fillPrescription.Enabled = true;
            linkLabel1.Enabled = true;
            linkLab_template.Enabled = true;
        }
    }
}
