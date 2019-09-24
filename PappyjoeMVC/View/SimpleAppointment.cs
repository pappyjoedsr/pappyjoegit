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
    public partial class SimpleAppointment : Form
    {
        public event child_form Appointment_list;
        public delegate void child_form(string strappointment);
        public string doctor_id = "0", patient_id = "", patient_name = "";
        public string strApp_id = "";
        bool flag = false;
        string strstatus = "1";
        public bool template_flag = false;
        string EHR_status = "NO", EHR_Clinical = "", EHR_treat = "", EHR_Pre = "", EHR_invoice = "", str_chief = "no";
        string smsName = "", smsPass = "", clinic = "", contact_no = "";
        string Prescription_bill_status = "No";
        string idcomp, iddiag, idnote, idtret, idpres; 
        Decimal discounttotal = 0;
        Decimal taxrstotal = 0;
        Decimal P_tax = 0;
        SimpleAppointment_controller cntrl = new SimpleAppointment_controller();

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            string pt_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            DataTable dtb = this.cntrl.get_pt_details(pt_id);
            if (dtb.Rows.Count > 0)
            {
                txtPatientID.Text = dtb.Rows[0]["pt_id"].ToString();
                patient_id = dtb.Rows[0]["id"].ToString();
                txt_Ptname.Text = dtb.Rows[0]["pt_name"].ToString();
                txt_mob.Text = dtb.Rows[0]["primary_mobile_number"].ToString();
                txt_Loca.Text = dtb.Rows[0]["locality"].ToString();
                txt_City.Text = dtb.Rows[0]["city"].ToString();
                txtAge.Text = dtb.Rows[0]["age"].ToString();
                if (dtb.Rows[0]["gender"].ToString().Trim() == "Male")
                {
                    radMale.Checked = true;
                    radFemale.Checked = false;
                }
                if (dtb.Rows[0]["gender"].ToString().Trim() == "Female")
                {
                    radFemale.Checked = true;
                    radMale.Checked = false;
                }
                EnabledAllContrls();
                txt_search.Text = "Search by  Patient Id, Name";
            }
        }

        private void txt_search_Click(object sender, EventArgs e)//search btn
        {
            if (txt_search.Text == "Search by  Patient Id, Name" || txt_search.Text == "")
            {
                txt_search.Text = "";
            }
        }
        private void dgv_Complaints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_Complaints.CurrentCell.OwningColumn.Name == "coldel")
                {
                    if (dgv_Complaints.CurrentRow.Cells["colcmplaint"].Value != null)
                    {
                        int index = dgv_Complaints.CurrentRow.Index;
                        dgv_Complaints.Rows.RemoveAt(index);
                    }
                }
            }
        }

        private void dgv_Diagnosis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_Diagnosis.CurrentCell.OwningColumn.Name == "del")
                {
                    if (dgv_Diagnosis.CurrentRow.Cells[1].Value != null)
                    {
                        int index = dgv_Diagnosis.CurrentRow.Index;
                        dgv_Diagnosis.Rows.RemoveAt(index);
                    }
                }
            }
        }

        private void dgv_treatment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            decimal grandTotal = 0, Grand_Discount = 0, Total_tax = 0;
            if (e.RowIndex >= 0)
            {
                if (dgv_treatment.CurrentCell.OwningColumn.Name == "col_del")
                {
                    DialogResult yesno = MessageBox.Show("Are you sure, do you want delete..??", "Delete", MessageBoxButtons.YesNo);
                    if (yesno == DialogResult.Yes)
                    {

                        int index = dgv_treatment.CurrentRow.Index;
                        dgv_treatment.Rows.RemoveAt(index);
                        for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                        {
                            grandTotal = grandTotal + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString());
                            Grand_Discount = Grand_Discount + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString());
                            Total_tax = Total_tax + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString());
                        }
                        Lab_GrandTotal.Text = String.Format("{0:C0}", grandTotal);//.ToString("#0.00");
                        Lab_DisInrs.Text = String.Format("{0:C0}", Grand_Discount);
                        Lab_TotalTax.Text = String.Format("{0:C0}", Total_tax);
                    }
                }
            }
        }

        private void dgv_prescrptn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt_forDelete = new DataTable();
            if (e.RowIndex >= 0)
            {
                if (dgv_prescrptn.CurrentCell.OwningColumn.Name == "colDelete")
                {
                    if (dgv_prescrptn.CurrentRow.Cells[1].Value != null)
                    {
                        int index = dgv_prescrptn.CurrentRow.Index;
                        for (int i = 0; i < dataGridView_drugnewTemp.Rows.Count; i++)
                        {
                            if (dataGridView_drugnewTemp.Rows[i].Cells["drugid"].Value.ToString() != dgv_prescrptn.Rows[i].Cells["id"].Value.ToString())
                            {
                                dt_forDelete.Rows.Add(dataGridView_drugnewTemp.Rows[i].Cells["dgrugname"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["srength"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["cmbStrenth"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["duration"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["period"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["morning"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["noon"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["night"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["ColFood"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["instruction"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["drugid"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["drugtype"].Value.ToString(), dataGridView_drugnewTemp.Rows[i].Cells["status"].Value.ToString());
                            }
                        }
                        dgv_prescrptn.Rows.RemoveAt(index);
                        if (dt_forDelete.Rows.Count > 0)
                        {
                            dataGridView_drugnewTemp.Rows.Clear();
                            for (int i = 0; i < dt_forDelete.Rows.Count; i++)
                            {
                                dataGridView_drugnewTemp.Rows.Add(dt_forDelete.Rows[i]["dgrugname"].ToString(), dt_forDelete.Rows[i]["srength"].ToString(), dt_forDelete.Rows[i]["cmbStrenth"].ToString(), dt_forDelete.Rows[i]["duration"].ToString(), dt_forDelete.Rows[i]["period"].ToString(), dt_forDelete.Rows[i]["morning"].ToString(), dt_forDelete.Rows[i]["noon"].ToString(), dt_forDelete.Rows[i]["night"].ToString(), dt_forDelete.Rows[i]["ColFood"].ToString(), dt_forDelete.Rows[i]["instruction"].ToString(), dt_forDelete.Rows[i]["drugid"].ToString(), dt_forDelete.Rows[i]["drugtype"].ToString(), dt_forDelete.Rows[i]["status"].ToString());
                            }
                        }
                        else
                        {
                            dataGridView_drugnewTemp.Rows.Clear();
                        }
                        dt_forDelete.Rows.Clear();
                    }
                }
            }
        }

        private void dgv_notes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgv_notes.CurrentCell.OwningColumn.Name == "colDele_Nots")
                {
                    if (dgv_notes.CurrentRow.Cells[1].Value != null)
                    {
                        int index = dgv_notes.CurrentRow.Index;
                        dgv_notes.Rows.RemoveAt(index);
                    }
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int presid = 0;
            int treat = 0;
            DataTable dt_ptiantId = new DataTable();
            dt_ptiantId = this.cntrl.get_patient_name(patient_id);/
            if (dgv_Diagnosis.Rows.Count > 0)
            {
                if (dgv_Diagnosis[1, 0].Value != null)
                { str_chief = "yes"; }
            }
            if (dgv_notes.Rows.Count > 0)
            {
                if (dgv_notes[1, 0].Value != null)
                { str_chief = "yes"; }
            }
            if (dgv_Complaints.Rows.Count > 0)
            {
                if (dgv_Complaints[1, 0].Value != null)
                { str_chief = "yes"; }
            }
            // Chief Complaint
            if (str_chief == "yes") // Checking 
            {
                EHR_status = "YES";
                int drid = Convert.ToInt32(Cmb_Doctor.SelectedValue);
                this.cntrl.insertInto_clinical_findings(dt_ptiantId.Rows[0][0].ToString(), drid.ToString(), dpStartTimeDate.Value.ToString("yyyy-MM-dd"));
                string treatment = this.cntrl.MaxId_clinic_findings();
                treat = 1;
                if (Convert.ToInt32(treatment) > 0)
                {
                        treat = int.Parse(treatment);
                }

                EHR_Clinical = treat.ToString();
                //Diagnosis
                if (dgv_Diagnosis.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv_Diagnosis.Rows.Count; i++)
                    {
                        if (dgv_Diagnosis[1, i].Value != null)
                        {
                            string one = dgv_Diagnosis[1, i].Value.ToString();
                             this.cntrl.insrtto_diagno(treat, one.Replace("'", " "));
                        }
                    }
                }

                // Note
                if (dgv_notes.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv_notes.Rows.Count; i++)
                    {
                        if (dgv_notes[1, i].Value != null)
                        {
                            string one = dgv_notes[1, i].Value.ToString();
                            this.cntrl.insrtto_note(treat, one.Replace("'", " "));
                        }
                    }
                }
                // Complaint
                if (dgv_Complaints.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv_Complaints.Rows.Count; i++)
                    {
                        if (dgv_Complaints[1, i].Value != null)
                        {
                            string one = dgv_Complaints[1, i].Value.ToString();
                            this.cntrl.insrtto_chief_comp(treat, one.Replace("'", " "));
                        }
                    }
                }
            }// Checking Cheif Complaints
             //Prescription
            string strPriscription = "";
            if (dgv_prescrptn.Rows.Count > 0)
            {

                prescription_check();// Check Inventory Item
                int d_id = Convert.ToInt32(Cmb_Doctor.SelectedValue);
                this.cntrl.save_prescriptionmain(patient_id, d_id.ToString(), dpStartTimeDate.Value.ToString("yyyy-MM-dd"), Prescription_bill_status,"");
                string dt = this.cntrl.Maxid();
                if (Convert.ToInt32(dt)> 0)
                {
                    presid = Int32.Parse(dt);
                }
                else
                {
                    presid = 1;
                }


                EHR_status = "YES";
                EHR_Pre = presid.ToString(); // Appointment 
                for (int i = 0; i < dgv_prescrptn.Rows.Count; i++)
                {
                    DataTable dt_drugid = new DataTable();
                    this.cntrl.save_prescription(presid , patient_id , Cmb_Doctor.Text , d_id.ToString() , dpStartTimeDate.Value.ToString("yyyy-MM-dd") , dgv_prescrptn.Rows[i].Cells["Prescription"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["Unit"].Value.ToString(), dgv_prescrptn.Rows[i].Cells["Strength"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["Duration_"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["_Period"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["Mornin"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["_Noon"].Value.ToString(), dgv_prescrptn.Rows[i].Cells["_Night"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["_Food"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["_Instruction"].Value.ToString() , dgv_prescrptn.Rows[i].Cells["_Drugtype"].Value.ToString() , strstatus , dgv_prescrptn.Rows[i].Cells["id"].Value.ToString());

                    strPriscription = strPriscription + "(" + (i + 1) + ")" + dgv_prescrptn.Rows[i].Cells["_Drugtype"].Value.ToString() + " " + dgv_prescrptn.Rows[i].Cells["Prescription"].Value.ToString() + dgv_prescrptn.Rows[i].Cells["Strength"].Value.ToString() + dgv_prescrptn.Rows[i].Cells["Unit"].Value.ToString() + "/" + dgv_prescrptn.Rows[i].Cells["Mornin"].Value.ToString() + "-" + dgv_prescrptn.Rows[i].Cells["_Noon"].Value.ToString() + "-" + dgv_prescrptn.Rows[i].Cells["_Night"].Value.ToString() + "/" + dgv_prescrptn.Rows[i].Cells["Duration_"].Value.ToString() + dgv_prescrptn.Rows[i].Cells["_Period"].Value.ToString() + dgv_prescrptn.Rows[i].Cells["_Instruction"].Value.ToString() + ".  ";
                }

                //SMS
                if (txt_mob.Text != "" && smsName != "" && smsPass != "")
                {
                    SMS_model a = new SMS_model();
                    string text = "Dear " + txt_Ptname.Text + ", Prescription. Drug Name:" + strPriscription + "Regards With " + clinic + "," + contact_no;
                    string number = "91" + txt_mob.Text;
                    a.SendSMS(smsName, smsPass, number, text);
                    this.cntrl.inssms(patient_id, text);
                }

            }

            if (dgv_treatment.Rows.Count > 0)
            {
                decimal totalcost2 = 0;
                decimal totalcost1 = 0;
                //int t_p = 0;
                int  j1;
                string dr_id = Cmb_Doctor.SelectedValue.ToString();
                for (int k = 0; k < dgv_treatment.Rows.Count; k++)
                {
                    if (dgv_treatment.Rows[k].Cells["Coltotalcost"].Value != null && dgv_treatment.Rows[k].Cells["Coltotalcost"].Value.ToString() != "")
                    {
                        totalcost2 = Convert.ToDecimal(dgv_treatment.Rows[k].Cells["_Cost"].Value.ToString());
                        totalcost1 = totalcost1 + totalcost2;
                    }
                }
               this.cntrl.save_completed_id(dpStartTimeDate.Value.ToString("yyyy-MM-dd"), patient_id);
                string dt_CMain = this.cntrl.get_completedMaxid();
                int completed_id;
                try
                {
                    if (Int32.Parse(dt_CMain) == 0)
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

                EHR_status = "YES";
                EHR_treat = completed_id.ToString(); // Appointment 

                j1 = completed_id;
                for (int ii = 0; ii < dgv_treatment.Rows.Count; ii++)
                {
                    this.cntrl.Save_tbl_completed_procedures(j1 , patient_id ,dgv_treatment.Rows[ii].Cells["treatmentid"].Value.ToString() , dgv_treatment.Rows[ii].Cells["treatement"].Value.ToString() , dgv_treatment.Rows[ii].Cells["_Unit"].Value.ToString(), dgv_treatment.Rows[ii].Cells["_Cost"].Value.ToString() , dgv_treatment.Rows[ii].Cells["dis_type"].Value.ToString() , dgv_treatment.Rows[ii].Cells["_Dis"].Value.ToString() , dgv_treatment.Rows[ii].Cells["Coltotalcost"].Value.ToString(), dgv_treatment.Rows[ii].Cells["_Dis_inrs"].Value.ToString() ,"",dr_id ,"0","");
                }
                //ReviewDate
                if (checkBoxReview.Checked == true)
                {
                    this.cntrl.update_review(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"), j1 );
                    DataTable dt_review = this.cntrl.get_reviewId(patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));
                    if (dt_review.Rows.Count == 0)
                    {
                        this.cntrl.save_review(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"), patient_id);
                        this.cntrl.save_appointment(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"), patient_id, txt_Ptname.Text, Cmb_Doctor.SelectedValue.ToString(), txt_mob.Text, Cmb_Doctor.Text.ToString());
                    }
                }
                else
                {
                    this.cntrl.update_review_No(dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"),j1);
                }
            }

            if (dgv_treatment.Rows.Count > 0)
            {
                this.cntrl.save_invoice_main(patient_id, dt_ptiantId.Rows[0]["pt_name"].ToString(), text_billno.Text);
                string dt1 = this.cntrl.get_invoiceMain_maxid();
                for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                {
                    EHR_invoice = dt1;
                    this.cntrl.save_invoice(text_billno.Text , txt_Ptname.Text , patient_id , dgv_treatment.Rows[i].Cells["treatmentid"].Value.ToString() , dgv_treatment.Rows[i].Cells["treatement"].Value.ToString() , dgv_treatment.Rows[i].Cells["_Unit"].Value.ToString() , dgv_treatment.Rows[i].Cells["_Cost"].Value.ToString() , dgv_treatment.Rows[i].Cells["_Dis"].Value.ToString() , dgv_treatment.Rows[i].Cells["dis_type"].Value.ToString() , dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString() ,dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString() ,Cmb_Doctor.SelectedValue.ToString() , dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString() , dt1,  dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString() , dgv_treatment.Rows[i].Cells["_Tax"].Value.ToString() , dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString());
                }
                string invoauto = this.cntrl.get_invoicenumber();
                int invoautoup = int.Parse(invoauto) + 1;
                this.cntrl.update_invnumber(invoauto);
                DataTable receipt = this.cntrl.receipt_number();
                string receiptNo = receipt.Rows[0]["receipt_prefix"].ToString() + receipt.Rows[0]["receipt_number"].ToString();
                for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                {
                    this.cntrl.save_receipt(receiptNo, dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString() , text_billno.Text , dgv_treatment.Rows[i].Cells["treatement"].Value.ToString() , patient_id , Cmb_Doctor.SelectedValue.ToString(), dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString() , dgv_treatment.Rows[i].Cells["_Cost"].Value.ToString(), dt_ptiantId.Rows[0]["pt_name"].ToString());
                }
                string rec = this.cntrl.receipt_autoid();
                int receip = int.Parse(rec) + 1;
                this.cntrl.update_receiptAutoid(receip);
            }
            if (EHR_status == "YES")
            {
                if (strApp_id != "")
                {
                    this.cntrl.save_appointmnt(EHR_Clinical.ToString(), EHR_treat.ToString(), EHR_Pre.ToString(), EHR_invoice.ToString(), strApp_id);
                }
            }
            string message1 = "Data saved successfully, Do you want Print?";
            string caption1 = "Verification";
            MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
            DialogResult result1;
            result1 = MessageBox.Show(message1, caption1, buttons1);
            if (result1 == System.Windows.Forms.DialogResult.Yes)
            {
                mprintosave();
            }
            clear();
            txt_Ptname.ReadOnly = false;
            txt_mob.ReadOnly = false;
            txtAge.ReadOnly = false;
            txt_City.ReadOnly = false;
            txt_Loca.ReadOnly = false;
            template_flag = false;
            Lab_GrandTotal.Text = "0";
            checkBoxReview.Checked = false;
            disabledAllContrls();
            dgv_notes.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
            dgv_Complaints.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
            dgv_Diagnosis.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;

            if (EHR_status == "YES")
            {
                if (this.Appointment_list != null)
                {
                    this.Appointment_list("true");
                }
                this.Close();
            }
        }

        public SimpleAppointment()
        {
            InitializeComponent();
        }

        private void btnAddNewPatient_Click(object sender, EventArgs e)
        {
            int p = 0;
            string datevisited;
            datevisited = DateTime.Now.Date.ToString("MM/dd/yyyy");
            if (txtPatientID.Text == "" && txt_Ptname.Text != "" && txt_mob.Text != "")
            {
                string gender = "", pid="";

                DataTable auto = this.cntrl.data_from_automaticid();
                if (auto.Rows.Count > 0)
                {
                    if (auto.Rows[0]["patient_automation"].ToString() == "Yes")
                    {
                        p = Convert.ToInt32(auto.Rows[0]["patient_number"].ToString()) + 1;
                        pid = auto.Rows[0]["patient_prefix"].ToString() + auto.Rows[0]["patient_number"].ToString();
                        txtPatientID.Text = pid;
                    }
                }

                if (radMale.Checked == true)
                {
                    gender = "Male";
                }
                if (radFemale.Checked == true)
                {
                    gender = "Female";
                }
                this.cntrl.save_patient(txt_Ptname.Text, pid, txt_mob.Text, gender, txtAge.Text, txt_Loca.Text, txt_City.Text, datevisited, Cmb_Doctor.Text);
                this.cntrl.update_autogenerateid(p);
                btnAddNewPatient.Visible = false;
                EnabledAllContrls();
            }
            else
            {
                MessageBox.Show(" mandatory fields should not be empty", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void prescription_check()
        {
            try
            {
                if (dgv_prescrptn.Rows.Count > 0)
                {
                    int count = dgv_prescrptn.Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataTable dt4 = this.cntrl.get_inventoryid(dgv_prescrptn[0, i].Value.ToString());
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

        private void txtPatientID_TextChanged(object sender, EventArgs e)
        {
            if (txtPatientID.Text != "")
            {
                btnAddNewPatient.Visible = false;
                txt_Ptname.ReadOnly = true;
                txt_mob.ReadOnly = true;
                txtAge.ReadOnly = true;
                txt_City.ReadOnly = true;
                txt_Loca.ReadOnly = true;
                radFemale.Enabled = false;
                radMale.Enabled = false;
            }
        }

        private void linkLab_template_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flag = false;
            Lnk_AddTemplate.Visible = true;
            DataTable dt = this.cntrl.load_template();
            if (dt.Rows.Count > 0)
            {
                fill_dgvTemplate(dt);
                template_flag = true;
                flag = true;
                dgv_fillPrescription.Visible = false;
                Dgv_filltemplate.Visible = true;
                Dgv_filltemplate.Location = new Point(10, 60);
                Dgv_filltemplate.Height = 51;
                Dgv_filltemplate.Width = 323;
            }
        }
        public void fill_dgvTemplate(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                Dgv_filltemplate.Rows.Clear();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    Dgv_filltemplate.Rows.Add();
                    Dgv_filltemplate.Rows[i].Cells["_P_id"].Value = dtb.Rows[i][0].ToString();
                    Dgv_filltemplate.Rows[i].Cells["_Drug"].Value = dtb.Rows[i][1].ToString();
                    Dgv_filltemplate.Columns["_P_id"].Visible = false;
                }
            }
        }

        private void Lnk_AddTemplate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt_ptiantId = new DataTable();
            dt_ptiantId = this.cntrl.patient_id(txtPatientID.Text);
            int patient_id;
            patient_id = Convert.ToInt32(dt_ptiantId.Rows[0]["id"].ToString());
            if (patient_id != 0)
            {
                var form2 = new SimpleAppointment_Template(patient_id);
                form2.ShowDialog();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            flag = false;
            Lnk_AddTemplate.Visible = false;
            DataTable dt_prescription =  dt_prescription = this.cntrl.get_drug_details();
            if (dt_prescription.Rows.Count > 0)
            {
                fill_DrugPrescrptn(dt_prescription);
                flag = true;
                template_flag = false;
                dgv_fillPrescription.Visible = true;
                Dgv_filltemplate.Visible = false;
            }
        }

        private void txt_DiaSearch_Click(object sender, EventArgs e)
        {
            txt_DiaSearch.Text = "";
        }

        private void txt_DiaSearch_TextChanged(object sender, EventArgs e)
        {
            if (txt_DiaSearch.Text != "")
            {
                DataTable dtb = this.cntrl.diagnosetxtsearch(txt_DiaSearch.Text);
                if (dtb.Rows.Count > 0)
                {
                    fill_Diagnosis(dtb);
                }
                else
                {
                    dhv_fillDiagnosis.Rows.Clear();
                }
            }
            else
            {
                DataTable dtb1 = this.cntrl.show_diagno();
                fill_Diagnosis(dtb1);
            }
        }

        private void dhv_fillDiagnosis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtPatientID.Text != "" && txt_Ptname.Text != "")
            {
                try
                {
                    int r = e.RowIndex;
                    iddiag = dhv_fillDiagnosis.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.cntrl.diagnose_cell(iddiag);
                    bool entryFound = false;
                    if (dt.Rows.Count > 0)
                    {
                        var value = dt.Rows[0][1].ToString().Trim();
                        foreach (DataGridViewRow row in dgv_Diagnosis.Rows)
                        {
                            object val1 = row.Cells[0].Value;
                            object val2 = row.Cells[1].Value;
                            if (val2 != null && val2.ToString() == value)
                            {
                                entryFound = true;
                                break;
                            }
                        }
                        if (!entryFound)
                        {
                            dgv_Diagnosis.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());

                            dgv_Diagnosis.Rows[dgv_Complaints.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            del.ImageLayout = DataGridViewImageCellLayout.Normal;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Choose the Patient", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_Notes_Click(object sender, EventArgs e)
        {
            txt_Notes.Text = "";
        }

        private void txt_Notes_TextChanged(object sender, EventArgs e)
        {
            if (txt_Notes.Text != "")
            {
                DataTable dtb = this.cntrl.notesearch(txt_Notes.Text);
                if (dtb.Rows.Count > 0)
                {
                    dgv_fillNotes.Rows.Clear();
                    fill_notes(dtb);
                }
                else
                {
                    dgv_fillNotes.Rows.Clear();
                }
            }
            else
            {
                DataTable dtb1 = this.cntrl.show_note();
                fill_notes(dtb1);
            }
        }

        private void dgv_fillNotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtPatientID.Text != "" && txt_Ptname.Text != "")
            {
                int r = e.RowIndex;
                idnote = dgv_fillNotes.Rows[r].Cells[0].Value.ToString();
                DataTable dt = this.cntrl.notes_cell(idnote);
                bool entryFound = false;
                if (dt.Rows.Count > 0)
                {
                    var value = dt.Rows[0][1].ToString().Trim();
                    foreach (DataGridViewRow row in dgv_notes.Rows)
                    {
                        object val1 = row.Cells[0].Value;
                        object val2 = row.Cells[1].Value;
                        if (val2 != null && val2.ToString() == value)
                        {
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        dgv_notes.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), PappyjoeMVC.Properties.Resources.deleteicon);
                        del.ImageLayout = DataGridViewImageCellLayout.Normal;
                    }
                }
            }
            else
            {
                MessageBox.Show("Choose the Patient", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_treatment_Click(object sender, EventArgs e)
        {
            txt_treatment.Text = "";
        }

        private void txt_treatment_TextChanged(object sender, EventArgs e)
        {
            if (txt_treatment.Text != "")
            {
                DataTable dtb = this.cntrl.search_procedures(txt_treatment.Text);
                if (dtb.Rows.Count > 0)
                {
                    fill_treatment(dtb);
                }
                else
                {
                    dgv_filltreatment.Rows.Clear();
                }
            }
            else
            {
                DataTable dtb1 = this.cntrl.load_proceduresgrid();
                fill_treatment(dtb1);
            }
        }

        private void dgv_filltreatment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtPatientID.Text != "" && txt_Ptname.Text != "")
            {
                try
                {
                    int r = e.RowIndex;
                    DataTable invNo = null;
                    invNo = this.cntrl.Get_invoice_prefix();
                    if (invNo.Rows.Count > 0)
                    {
                        text_billno.Text = invNo.Rows[0]["invoice_prefix"].ToString() + invNo.Rows[0]["invoice_number"].ToString();
                    }
                    else
                    {
                        text_billno.ReadOnly = false;
                    }
                    idtret = dgv_filltreatment.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.cntrl.get_procedure_Name(idtret);
                    bool entryFound = false;
                    if (dt.Rows.Count > 0)
                    {
                        var value = dt.Rows[0][1].ToString().Trim();
                        foreach (DataGridViewRow row in dgv_treatment.Rows)
                        {
                            object val1 = row.Cells[0].Value;
                            object val2 = row.Cells[1].Value;
                            if (val2 != null && val2.ToString() == value)
                            {
                                entryFound = true;
                                break;
                            }
                        }
                        if (!entryFound)
                        {
                            taxrstotal = 0;
                            panl_Treatment.Visible = true;
                            Lab_TreatId.Text = dt.Rows[0][0].ToString();
                            procedure_item.Text = dt.Rows[0]["name"].ToString();
                            Lab_Cost.Text = dt.Rows[0]["cost"].ToString();
                            lab_Total.Text = dt.Rows[0]["cost"].ToString();

                            txt_Discount.Hide();
                            CMB_Discount.Hide();
                            Cmb_tax.Hide();
                            lab_AddDiscount.Show();
                            lab_AddTax.Show();
                            NMUP_Unit.Text = "1";
                            CMB_Discount.Text = "INR";
                            txt_Discount.Text = "0";
                            Cmb_tax.Text = "NA";
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Choose the Patient", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_Prescrptn_Click(object sender, EventArgs e)
        {
            txt_Prescrptn.Text = "";
        }

        private void txt_Prescrptn_TextChanged(object sender, EventArgs e)
        {
            if (template_flag == true)
            {
                if (txt_Prescrptn.Text != "")
                {
                    DataTable dtb = this.cntrl.search_template(txt_Prescrptn.Text);
                    if (dtb.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        dgv_fillPrescription.Rows.Clear();
                    }
                }
                else
                {
                    DataTable dtb1 = this.cntrl.load_template();
                }
            }
            else
            {
                if (txt_Prescrptn.Text != "")
                {
                    DataTable dtb = this.cntrl.drug_search(txt_Prescrptn.Text);
                    if (dtb.Rows.Count > 0)
                    {
                        fill_DrugPrescrptn(dtb);
                    }
                    else
                    {
                        dgv_fillPrescription.Rows.Clear();
                    }
                }
                else
                {
                    DataTable dtb1 = this.cntrl.get_drug_details();
                    fill_DrugPrescrptn(dtb1);
                }
            }
        }

        private void dgv_fillPrescription_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtPatientID.Text != "" && txt_Ptname.Text != "")
            {
                try
                {
                    int r = e.RowIndex;
                    idpres = dgv_fillPrescription.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = new DataTable();
                    DataTable dt_template = new DataTable();
                    dt = this.cntrl.get_drug_strength(idpres);
                    bool entryFound = false;
                    if (dt.Rows.Count > 0)
                    {
                        var value = dt.Rows[0][1].ToString().Trim();
                        foreach (DataGridViewRow row in dgv_prescrptn.Rows)
                        {
                            object val1 = row.Cells[0].Value;
                            object val2 = row.Cells[1].Value;
                            if (val2 != null && val2.ToString() == value)
                            {
                                entryFound = true;
                                break;
                            }
                        }
                        if (!entryFound)
                        {
                            Panl_Prescrption.Visible = true;
                            Panl_Prescrption.Location = new Point(2, 571);
                            drugnametext.Text = dt.Rows[0][1].ToString();
                            Lab_DrugId.Text = dt.Rows[0][0].ToString();
                            strengthno.Text = dt.Rows[0]["strength_gr"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Choose the Patient", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_prescriptionadd_Click(object sender, EventArgs e)
        {
            string dt = this.cntrl.drug_type(Lab_DrugId.Text);
            string before = "", type="";
            if (dt != "0")
            {
                type = dt;
            }
            else
                type = "";
            if (radB4Food.Checked == true)
            {
                before = radB4Food.Text;
            }
            else if (AftrFood.Checked == true)
            {
                before = AftrFood.Text;
            }
            dgv_prescrptn.Rows.Add(Lab_DrugId.Text, drugnametext.Text, strengthno.Text, strengthcombo.Text, numericUpDown2.Value.ToString(), duracombo.Text, numericUpDown4.Value.ToString(), numericUpDown5.Value.ToString(), numericUpDown3.Value.ToString(), before, rich_inctrn.Text, type, PappyjoeMVC.Properties.Resources.deleteicon);
            Panl_Prescrption.Visible = false;
            Lab_DrugId.Text = "";
            drugnametext.Text = "";
            strengthno.Text = "";
            rich_inctrn.Visible = false;
            radB4Food.Checked = false;
            AftrFood.Checked = false;
        }

        private void btn_PresCancel_Click(object sender, EventArgs e)
        {
            Panl_Prescrption.Visible = false;
        }

        private void addinsbut_Click(object sender, EventArgs e)
        {
            rich_inctrn.Text = "";
            rich_inctrn.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panl_Treatment.Visible = false;
        }

        private void lab_AddDiscount_Click(object sender, EventArgs e)
        {
            txt_Discount.Visible = true;
            CMB_Discount.Visible = true;
            lab_AddDiscount.Hide();
        }

        private void lab_AddTax_Click(object sender, EventArgs e)
        {
            Cmb_tax.Visible = true;
            lab_AddTax.Visible = false;
            Cmb_tax.Text = "NA";
        }

        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            decimal qty = 0;
            decimal cost = 0;
            decimal discount = 0;
            if (NMUP_Unit.Text != "")
            {
                qty = Convert.ToDecimal(NMUP_Unit.Text);
            }
            if (Lab_Cost.Text != "")
            {
                cost = Convert.ToDecimal(Lab_Cost.Text);
            }
            if (txt_Discount.Text != "")
            {
                if (CMB_Discount.Text == "INR")
                {
                    discount = Convert.ToDecimal(txt_Discount.Text);
                }
                else
                {
                    discount = ((qty * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                }
            }
            lab_Total.Text = Convert.ToString((qty * cost) - discount);
            discounttotal = discount;
            taxrstotal = 0;
            if (P_tax > 0)
            {
                lab_Total.Text = Convert.ToString(Convert.ToDecimal(lab_Total.Text) + ((qty * cost) * P_tax / 100));
                taxrstotal = (qty * cost) * P_tax / 100;
            }
        }

        private void txt_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void CMB_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal qty = 0;
            decimal cost = 0;
            decimal discount = 0;
            if (NMUP_Unit.Text != "")
            {
                qty = Convert.ToDecimal(NMUP_Unit.Text);
            }
            if (Lab_Cost.Text != "")
            {
                cost = Convert.ToDecimal(Lab_Cost.Text);
            }
            if (txt_Discount.Text != "")
            {
                if (CMB_Discount.Text == "INR")
                {
                    discount = Convert.ToDecimal(txt_Discount.Text);
                }
                else
                {
                    discount = ((qty * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                }
            }
            lab_Total.Text = Convert.ToString((qty * cost) - discount);
            discounttotal = discount;
            taxrstotal = 0;
            if (P_tax > 0)
            {
                lab_Total.Text = Convert.ToString(Convert.ToDecimal(lab_Total.Text) - ((qty * cost) * P_tax / 100));
                taxrstotal = (qty * cost) * P_tax / 100;
            }
        }

        private void NMUP_Unit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty1 = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (!String.IsNullOrWhiteSpace(NMUP_Unit.Text))
                {
                    qty1 = Convert.ToDecimal(NMUP_Unit.Text);
                }
                if (!String.IsNullOrWhiteSpace(Lab_Cost.Text))
                {
                    cost = Convert.ToDecimal(Lab_Cost.Text);
                }
                if (!String.IsNullOrWhiteSpace(txt_Discount.Text))
                {
                    if (CMB_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(txt_Discount.Text);
                    }
                    else
                    {
                        discount = ((qty1 * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                    }
                }
                lab_Total.Text = Convert.ToString((qty1 * cost) - discount);
                discounttotal = discount;
                taxrstotal = 0;
                if (P_tax > 0)
                {
                    lab_Total.Text = Convert.ToString(Convert.ToDecimal(lab_Total.Text) + ((qty1 * cost) * P_tax / 100));
                    taxrstotal = (qty1 * cost) * P_tax / 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not a valid number. Please try again.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cmb_tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (NMUP_Unit.Text != "")
                {
                    qty = Convert.ToDecimal(NMUP_Unit.Text);
                }
                if (Lab_Cost.Text != "")
                {
                    cost = Convert.ToDecimal(Lab_Cost.Text);
                }
                if (txt_Discount.Text != "")
                {
                    if (CMB_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(txt_Discount.Text);
                    }
                    else
                    {
                        discount = ((qty * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                    }
                }
                lab_Total.Text = Convert.ToString((qty * cost) - discount);
                discounttotal = discount;
                taxrstotal = 0;
                if (P_tax > 0)
                {
                    lab_Total.Text = Convert.ToString(Convert.ToDecimal(lab_Total.Text) + ((qty * cost) * P_tax / 100));
                    taxrstotal = (qty * cost) * P_tax / 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not a valid number. Please try again.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Cmb_tax_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string ctax = Cmb_tax.SelectedText.ToString();
            if (Cmb_tax.SelectedIndex == 4)
            {
                P_tax = 0;
            }
            else
            {
                string dt = this.cntrl.select_taxValue(Cmb_tax.SelectedValue.ToString());
                if (Convert.ToInt32(dt) > 0)
                {
                    P_tax = Convert.ToDecimal(dt);
                }
                else
                {
                    P_tax = 0;
                }
            }

        }

        private void Cmb_tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Cmb_tax.SelectionStart = 0;
            Cmb_tax.SelectionLength = Cmb_tax.Text.Length;
            if (e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btn_TreatmentAdd_Click(object sender, EventArgs e)
        {
            decimal grandTotal = 0, Grand_Discount = 0, Total_tax = 0;
            if (String.IsNullOrWhiteSpace(NMUP_Unit.Text) || String.IsNullOrWhiteSpace(procedure_item.Text) || procedure_item.Text == "PRODUCTS AND SERVICES" || String.IsNullOrWhiteSpace(Lab_Cost.Text))
            {
                MessageBox.Show("Please enter the Quantity and Cost...");
            }
            else
            {

                if (Convert.ToDouble(lab_Total.Text.Trim()) >= 0)
                {
                    dgv_treatment.Rows.Add(Lab_TreatId.Text, procedure_item.Text, NMUP_Unit.Text, Lab_Cost.Text, txt_Discount.Text, CMB_Discount.Text, discounttotal, Cmb_tax.Text, taxrstotal, lab_Total.Text, PappyjoeMVC.Properties.Resources.deleteicon);
                    for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                    {
                        grandTotal = grandTotal + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString());
                        Grand_Discount = Grand_Discount + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString());
                        Total_tax = Total_tax + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString());
                    }
                    Lab_GrandTotal.Text = String.Format("{0:C0}", grandTotal);//.ToString("#0.00");
                    Lab_DisInrs.Text = String.Format("{0:C0}", Grand_Discount);
                    Lab_TotalTax.Text = String.Format("{0:C0}", Total_tax);
                    panl_Treatment.Visible = false;

                    txt_Discount.Clear();
                    CMB_Discount.Text = "";
                    Cmb_tax.Text = "";
                    txt_Discount.Hide();
                    CMB_Discount.Hide();
                    Cmb_tax.Hide();

                    lab_AddDiscount.Show();
                    lab_AddTax.Show();
                    NMUP_Unit.Text = "1";
                    CMB_Discount.Text = "INR";
                    txt_Discount.Text = "0";
                    Cmb_tax.Text = "NA";

                }
                else
                {
                    MessageBox.Show("Total cost is less than Zero... Please Enter the correct values (Cost, Discount, Tax).....", "Incorrect Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Dgv_filltemplate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtPatientID.Text != "" && txt_Ptname.Text != "")
            {
                try
                {
                    int r = e.RowIndex;
                    idpres = Dgv_filltemplate.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = new DataTable();
                    DataTable dt_template = new DataTable();
                    dt = this.cntrl.template_main(idpres);
                    dt_template = this.cntrl.template_details(idpres);
                    bool entryFound = false;
                    if (dt.Rows.Count > 0)
                    {
                        var value = dt.Rows[0][1].ToString().Trim();
                        foreach (DataGridViewRow row in dgv_prescrptn.Rows)
                        {
                            object val1 = row.Cells[0].Value;
                            object val2 = row.Cells[1].Value;
                            if (val2 != null && val2.ToString() == value)
                            {
                                entryFound = true;
                                break;
                            }
                        }
                        if (!entryFound)
                        {

                            {
                                for (int i = 0; i < dt_template.Rows.Count; i++)
                                {
                                    dgv_prescrptn.Rows.Add(dt_template.Rows[i]["drug_id"].ToString(), dt_template.Rows[i]["drug_name"].ToString(), dt_template.Rows[i]["strength"].ToString(), dt_template.Rows[i]["strength_gr"].ToString(), dt_template.Rows[i]["duration"].ToString(), dt_template.Rows[i]["duration_period"].ToString(), dt_template.Rows[i]["morning"].ToString(), dt_template.Rows[i]["noon"].ToString(), dt_template.Rows[i]["night"].ToString(), dt_template.Rows[i]["food"].ToString(), dt_template.Rows[i]["add_instruction"].ToString(), dt_template.Rows[i]["drug_type"].ToString(), PappyjoeMVC.Properties.Resources.deleteicon);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Choose the Patient", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            mprintosave();
        }

        private void NMUP_Unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Lab_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void Lab_Cost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty1 = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (!String.IsNullOrWhiteSpace(NMUP_Unit.Text))
                {
                    qty1 = Convert.ToDecimal(NMUP_Unit.Text);
                }
                if (!String.IsNullOrWhiteSpace(Lab_Cost.Text))
                {
                    cost = Convert.ToDecimal(Lab_Cost.Text);
                }
                if (!String.IsNullOrWhiteSpace(txt_Discount.Text))
                {
                    if (CMB_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(txt_Discount.Text);
                    }
                    else
                    {
                        discount = ((qty1 * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                    }
                }
                lab_Total.Text = Convert.ToString((qty1 * cost) - discount);
                discounttotal = discount;
                taxrstotal = 0;
                if (P_tax > 0)
                {
                    lab_Total.Text = Convert.ToString(Convert.ToDecimal(lab_Total.Text) + ((qty1 * cost) * P_tax / 100));
                    taxrstotal = (qty1 * cost) * P_tax / 100;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not a valid number. Please try again.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ClearAll_Click(object sender, EventArgs e)
        {
            btnAddNewPatient.Visible = false;
            txt_Ptname.ReadOnly = false;
            txt_mob.ReadOnly = false;
            txtAge.ReadOnly = false;
            txt_Loca.ReadOnly = false;
            txt_City.ReadOnly = false;
            radFemale.Enabled = true;
            radMale.Enabled = true;
            dgv_Complaints.Rows.Clear();
            dgv_treatment.Rows.Clear();
            dgv_Diagnosis.Rows.Clear();
            dgv_notes.Rows.Clear();
            dgv_prescrptn.Rows.Clear();
            txt_Ptname.Text = "";
            txt_mob.Text = "";
            txtAge.Text = "";
            txt_Loca.Text = "";
            txtPatientID.Text = "";
            Lab_GrandTotal.Text = "0";
            disabledAllContrls();
            txt_Ptname.Focus();
            dgv_notes.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
            dgv_Complaints.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
            dgv_Diagnosis.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
        }

        private void txt_cmpltsSearch_Click(object sender, EventArgs e)
        {
            txt_cmpltsSearch.Text = "";
        }

        private void txt_cmpltsSearch_TextChanged(object sender, EventArgs e)
        {
            if (txt_cmpltsSearch.Text != "")
            {
                DataTable dtb = this.cntrl.compsearch(txt_cmpltsSearch.Text);
                if (dtb.Rows.Count > 0)
                {
                    fill_Complaints(dtb);
                }
                else
                {
                    dgv_fillComplaints.Rows.Clear();
                }
            }
            else
            {
                DataTable dtb1 = this.cntrl.show_compl();
                fill_Complaints(dtb1);
            }
        }

        private void dgv_fillComplaints_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtPatientID.Text != "" && txt_Ptname.Text != "")
            {
                try
                {
                    int r = e.RowIndex;
                    idcomp = dgv_fillComplaints.Rows[r].Cells[0].Value.ToString();
                    DataTable dt = this.cntrl.complaint_cell(idcomp);
                    bool entryFound = false;
                    if (dt.Rows.Count > 0)
                    {
                        var value = dt.Rows[0][1].ToString().Trim();
                        foreach (DataGridViewRow row in dgv_Complaints.Rows)
                        {
                            object val1 = row.Cells[0].Value;
                            object val2 = row.Cells[1].Value;
                            if (val2 != null && val2.ToString() == value)
                            {
                                entryFound = true;
                                break;
                            }
                        }
                        if (!entryFound)
                        {
                            dgv_Complaints.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                            dgv_Complaints.Rows[dgv_Complaints.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            del.ImageLayout = DataGridViewImageCellLayout.Normal;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Choose the Patient", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SimpleAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                dateTimePicker1.Value = DateTime.Today.AddMonths(+1);
                flag = false; template_flag = false;
                DataTable dt_treatment = new DataTable();
                dt_treatment = this.cntrl.get_All_proceure();
                fill_treatment(dt_treatment);
                DataTable dt_prescription = this.cntrl.get_drug_details();
                fill_DrugPrescrptn(dt_prescription);
                DataTable dt_doctor = this.cntrl.get_all_doctorname();
                if (dt_doctor.Rows.Count > 0)
                {
                    Cmb_Doctor.DataSource = dt_doctor;
                    Cmb_Doctor.ValueMember = "id";
                    Cmb_Doctor.DisplayMember = "doctor_name";
                }
                DataTable dt_complaint = new DataTable();
                dt_complaint = this.cntrl.show_compl();
                fill_Complaints(dt_complaint);
                DataTable dt_Diaganosis = new DataTable();
                dt_Diaganosis = this.cntrl.show_diagno();
                fill_Diagnosis(dt_Diaganosis);
                DataTable dt_notes = new DataTable();
                dt_notes = this.cntrl.show_note();
                fill_notes(dt_notes);
                disabledAllContrls();
                flag = true;
                DataTable dt = this.cntrl.Fill_unit_combo();
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
                DataTable dt5 = this.cntrl.Fill_LoadTax();
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
                invNo = this.cntrl.Get_invoice_prefix();
                if (invNo.Rows.Count > 0)
                {
                    text_billno.Text = invNo.Rows[0]["invoice_prefix"].ToString() + invNo.Rows[0]["invoice_number"].ToString();
                }
                else
                {
                    text_billno.ReadOnly = false;
                }


                DataTable dtb = this.cntrl.get_pt_details(patient_id);
                if (dtb.Rows.Count > 0)
                {
                    txtPatientID.Text = dtb.Rows[0]["pt_id"].ToString();
                    patient_id = dtb.Rows[0]["id"].ToString();
                    txt_Ptname.Text = dtb.Rows[0]["pt_name"].ToString();
                    txt_mob.Text = dtb.Rows[0]["primary_mobile_number"].ToString();
                    txt_Loca.Text = dtb.Rows[0]["locality"].ToString();
                    txt_City.Text = dtb.Rows[0]["city"].ToString();
                    txtAge.Text = dtb.Rows[0]["age"].ToString();
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


                DataTable App_dtb = this.cntrl.get_EHR_details(strApp_id);
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
                        DataTable Dt_Complaint = this.cntrl.getComplaints(App_dtb.Rows[0]["EHR_clinicalfindings"].ToString());
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
                        DataTable Dt_diagnosis = this.cntrl.get_diagno(App_dtb.Rows[0]["EHR_clinicalfindings"].ToString());
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
                        DataTable Dt_Note = this.cntrl.get_note(App_dtb.Rows[0]["EHR_clinicalfindings"].ToString());
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
                    if (App_dtb.Rows[0]["EHR_treatment"].ToString() != "")
                    {
                        EHR_treat = App_dtb.Rows[0]["EHR_treatment"].ToString();
                        decimal grandTotal = 0, Grand_Discount = 0, Total_tax = 0;
                        DataTable Dt_Treatment = this.cntrl.get_treatment_details(App_dtb.Rows[0]["EHR_treatment"].ToString());
                        if (Dt_Treatment.Rows.Count > 0)
                        {
                            dgv_treatment.Columns[10].Visible = false;
                            for (int i = 0; i < Dt_Treatment.Rows.Count; i++)
                            {
                                dgv_treatment.Rows.Add(Dt_Treatment.Rows[i]["procedure_id"], Dt_Treatment.Rows[i]["procedure_name"], Dt_Treatment.Rows[i]["quantity"], Dt_Treatment.Rows[i]["cost"], Dt_Treatment.Rows[i]["discount_type"], Dt_Treatment.Rows[i]["discount"], Dt_Treatment.Rows[i]["discount_inrs"], 0, 0, Dt_Treatment.Rows[i]["total"], PappyjoeMVC.Properties.Resources.deleteicon);

                            }
                        }
                        for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                        {
                            grandTotal = grandTotal + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString());
                            Grand_Discount = Grand_Discount + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString());
                            Total_tax = Total_tax + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString());
                        }
                        Lab_GrandTotal.Text = String.Format("{0:C0}", grandTotal);//.ToString("#0.00");
                        Lab_DisInrs.Text = String.Format("{0:C0}", Grand_Discount);
                        Lab_TotalTax.Text = String.Format("{0:C0}", Total_tax);

                        string Dt_Review = this.cntrl.get_review_date(App_dtb.Rows[0]["EHR_treatment"].ToString());
                        if (Dt_Review!="0")
                        {
                            checkBoxReview.Checked = true;
                            dateTimePicker1.Value = Convert.ToDateTime(Dt_Review);
                        }
                    } // Treatment End

                    if (App_dtb.Rows[0]["EHR_invoice"].ToString() != "")
                    {
                        EHR_invoice = App_dtb.Rows[0]["EHR_invoice"].ToString();
                    }


                    if (App_dtb.Rows[0]["EHR_prescription"].ToString() != "")
                    {
                        EHR_Pre = App_dtb.Rows[0]["EHR_prescription"].ToString();
                        DataTable Dt_Prescription = this.cntrl.get_allprescription(App_dtb.Rows[0]["EHR_prescription"].ToString());
                        if (dt_prescription.Rows.Count > 0)
                        {
                            dgv_prescrptn.Columns[12].Visible = false;
                            for (int i = 0; i < Dt_Prescription.Rows.Count; i++)
                            {
                                dgv_prescrptn.Rows.Add(Dt_Prescription.Rows[i]["drug_id"], Dt_Prescription.Rows[i]["drug_name"], Dt_Prescription.Rows[i]["strength_gr"] + "" + Dt_Prescription.Rows[i]["strength"], Dt_Prescription.Rows[i]["strength_gr"], Dt_Prescription.Rows[i]["duration_unit"] + "" + Dt_Prescription.Rows[i]["duration_period"], Dt_Prescription.Rows[i]["duration_period"], Dt_Prescription.Rows[i]["morning"], Dt_Prescription.Rows[i]["noon"], Dt_Prescription.Rows[i]["night"], Dt_Prescription.Rows[i]["food"], Dt_Prescription.Rows[i]["add_instruction"], Dt_Prescription.Rows[i]["drug_type"], PappyjoeMVC.Properties.Resources.deleteicon);
                            }
                        }

                    }


                }
                else
                {
                    decimal grandTotal = 0, Grand_Discount = 0, Total_tax = 0;
                    DataTable dt_Procedure = this.cntrl.get_proceduresettings();
                    if (dt_Procedure.Rows.Count > 0)
                    {

                        dgv_treatment.Rows.Add(dt_Procedure.Rows[0]["id"].ToString(), dt_Procedure.Rows[0]["name"].ToString(), "1", dt_Procedure.Rows[0]["cost"].ToString(), "0", "INR", "0", "NA", "0", dt_Procedure.Rows[0]["cost"].ToString(), PappyjoeMVC.Properties.Resources.deleteicon);
                        for (int i = 0; i < dgv_treatment.Rows.Count; i++)
                        {
                            grandTotal = grandTotal + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Coltotalcost"].Value.ToString());
                            Grand_Discount = Grand_Discount + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["_Dis_inrs"].Value.ToString());
                            Total_tax = Total_tax + Convert.ToDecimal(dgv_treatment.Rows[i].Cells["Total_tax"].Value.ToString());
                        }
                        Lab_GrandTotal.Text = String.Format("{0:C0}", grandTotal);//.ToString("#0.00");
                        Lab_DisInrs.Text = String.Format("{0:C0}", Grand_Discount);
                        Lab_TotalTax.Text = String.Format("{0:C0}", Total_tax);
                    }
                }
                string App_dtb1 = this.cntrl.get_doctorname(strApp_id);
                if (App_dtb1!="0")
                {
                    int index = Cmb_Doctor.FindString(Convert.ToString(App_dtb1));
                    if (index >= 0)
                    {
                        Cmb_Doctor.SelectedIndex = index;
                    }
                    else
                    {
                        Cmb_Doctor.SelectedIndex = 0;
                    }
                }
                System.Data.DataTable clinicname = this.cntrl.practicedetails();
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    clinic = clinicn.Replace("'", "¤");
                    contact_no = clinicname.Rows[0][2].ToString();
                }

                System.Data.DataTable sms = this.cntrl.smsdetails();
                if (sms.Rows.Count > 0)
                {
                    smsName = sms.Rows[0]["smsName"].ToString();
                    smsPass = sms.Rows[0]["smsPass"].ToString();
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
        public void clear()
        {
            txt_search.Text = "Search by  Patient Id, Name";
            txtPatientID.Text = "";
            txt_Ptname.Text = "";
            txtAge.Text = "";
            txt_City.Text = "";
            txt_Loca.Text = "";
            txt_mob.Text = "";
            dgv_treatment.Rows.Clear();
            dgv_Complaints.Rows.Clear();
            dgv_Diagnosis.Rows.Clear();
            dgv_notes.Rows.Clear();
            dgv_prescrptn.Rows.Clear();
            DGV_treatmentTemp.Rows.Clear();
            dataGridView_drugnewTemp.Rows.Clear();
        }
        public void mprintosave()
        {
            //try
            //{
            int c = 0, o = 0, inves = 0, d = 0, k = 0, p = 0, pa = 0, patientnotes = 0;
            string startDateTime = dpStartTimeDate.Value.ToString("dd/MM/yyyy");
            string startDateTime1 = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            string doct = this.cntrl.Get_DoctorName(doctor_id);
            string doctor_name = "";
            if (doct !="0")
            {
                doctor_name = doct;
            }
            DataTable dt_ptiantId = new DataTable();
            dt_ptiantId = this.cntrl.patient_id(txtPatientID.Text);
            int patientid;
            patientid = Convert.ToInt32(dt_ptiantId.Rows[0]["id"].ToString());
            System.Data.DataTable patient = this.cntrl.Get_Patient_Details(patientid.ToString());
            string Pname = "", Gender = "", address = "", city = "", age = "", Mobile = "";
            string str_p_as = "";
            string P_id = "";
            if (patient.Rows.Count > 0)
            {
                Pname = txt_Ptname.Text;
                if (radMale.Checked == true)
                {
                    Gender = radMale.Text;
                    str_p_as = "/" + Gender;
                }
                else if (radFemale.Checked == true)
                {
                    Gender = radFemale.Text;
                    str_p_as = "/" + Gender;
                }

                address = txt_Loca.Text;
                city = txt_City.Text;
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

                Mobile = txt_mob.Text;
                P_id = txtPatientID.Text;
                if (txtAge.Text != "")
                {
                    age = txtAge.Text;
                    if (str_p_as != "")
                    {
                        str_p_as = str_p_as + "/" + age + "Yrs";
                    }
                    else
                    { str_p_as = "/" + age + "Yrs"; }
                }
            }
            string str_name = "";
            string str_street_address = "";
            string str_locality = "";
            string str_pincode = "";
            string str_contact_no = "";
            string str_email = "";
            string str_website = "";
            string sqlstring = "";
            int datecheck = 0;
            System.Data.DataTable dtp = this.cntrl.get_company_details();
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
            StreamWriter sWrite = new StreamWriter(Apppath + "\\SimpleAppointment.html");
            c = 0; o = 0; inves = 0; d = 0; k = 0; p = 0; pa = 0; patientnotes = 0;
            sWrite.WriteLine("<html>");
            sWrite.WriteLine("<head>");
            sWrite.WriteLine("</head>");
            sWrite.WriteLine("<body >");
            sWrite.WriteLine("<br><br><br>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='segoe UI' SIZE=5>" + str_name.ToString() + "</font></th></tr>");
            if (str_street_address.ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='segoe UI' SIZE=3>");
                sWrite.WriteLine("&nbsp;" + str_street_address.ToString() + "</font></td>");
                sWrite.WriteLine("</tr>");
            }
            if (str_locality.ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='segoe UI' SIZE=2>");
                sWrite.WriteLine("&nbsp;" + str_locality.ToString() + "</font></td>");
                sWrite.WriteLine("</tr>");
            }
            if (str_pincode.ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='segoe UI' SIZE=2>");
                sWrite.WriteLine("&nbsp;" + str_pincode.ToString() + "</font></td>");
                sWrite.WriteLine("</tr>");
            }
            if (str_contact_no.ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='segoe UI' SIZE=2>");
                sWrite.WriteLine("&nbsp;" + str_contact_no.ToString() + "</font></td>");
                sWrite.WriteLine("</tr>");
            }
            if (str_email.ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='segoe UI' SIZE=2>");
                sWrite.WriteLine("&nbsp;" + str_email.ToString() + "</font></td>");
                sWrite.WriteLine("</tr>");
            }
            if (str_website.ToString() != "")
            {
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align=left><FONT COLOR=black FACE='segoe UI' SIZE=2>");
                sWrite.WriteLine("&nbsp;" + str_website.ToString() + "</font><hr></td>");
                sWrite.WriteLine("</tr>");
            }
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr><th align='center'><FONT COLOR=black FACE='segoe UI' SIZE=5>Case Sheet</font></th></tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<br>");
            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
            sWrite.WriteLine("<tr height='40px'>");
            sWrite.WriteLine("<td align='left' width='500px'><FONT COLOR=black FACE='segoe UI' SIZE=2>Consulted by : " + Cmb_Doctor.Text + " </font></td>");
            sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='segoe UI' SIZE=2></font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='segoe UI' SIZE=2>Name :<b>" + Pname.ToString() + "</b> (<i>" + P_id + str_p_as + "</i>) </font></td>");
            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='segoe UI' SIZE=2>Appointment Date  :" + startDateTime + "  </font></td>");
            sWrite.WriteLine("</tr>");
            sWrite.WriteLine("<tr>");
            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='segoe UI' SIZE=2>Address : " + address.ToString() + "</font></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine(" <tr>");
            sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='segoe UI' SIZE=2>Mobile No: " + Mobile.ToString() + "</font></td>");
            sWrite.WriteLine(" </tr>");
            sWrite.WriteLine("</table>");
            sWrite.WriteLine("<br>");
            ////ChiefComplaints
            string ChiefComplaints = "";
            string sentence = "";
            if (dgv_Complaints.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_Complaints.Rows.Count; i++)
                {
                    if (dgv_Complaints.Rows[i].Cells[1].Value != null && dgv_Complaints.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        ChiefComplaints = ChiefComplaints + dgv_Complaints.Rows[i].Cells[1].Value.ToString() + ",";
                    }
                }
                if (ChiefComplaints != "")
                    sentence = ChiefComplaints.Remove(ChiefComplaints.Length - 1);
                if (sentence.ToString() != "")
                {
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;CHIEF COMPLAINTS</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='justify' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + sentence.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='segoe UI' SIZE=3></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
            }
            ///Diagnosis
            string Diagnosis = "";
            string sentence1 = "";
            if (dgv_Diagnosis.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_Diagnosis.Rows.Count; i++)
                {
                    if (dgv_Diagnosis.Rows[i].Cells[1].Value != null && dgv_Diagnosis.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        Diagnosis = Diagnosis + dgv_Diagnosis.Rows[i].Cells[1].Value.ToString() + ",";
                    }
                }
                if (Diagnosis != "")
                    sentence1 = Diagnosis.Remove(Diagnosis.Length - 1);
                if (sentence1.ToString() != "")
                {
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;DIAGNOSIS</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='justify' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + sentence1.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='segoe UI' SIZE=3></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
            }
            ///Notes
            string Notes = "";
            string sentence2 = "";
            if (dgv_notes.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_notes.Rows.Count; i++)
                {
                    if (dgv_notes.Rows[i].Cells[1].Value != null && dgv_notes.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        Notes = Notes + dgv_notes.Rows[i].Cells[1].Value.ToString() + ",";
                    }
                }
                if (Notes != "")
                    sentence2 = Notes.Remove(Notes.Length - 1);
                if (sentence2.ToString() != "")
                {
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;NOTES</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='justify' ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + sentence2.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='segoe UI' SIZE=3></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
            }
            //Treatment
            if (dgv_treatment.Rows.Count > 0 && EHR_invoice != "")
            {
                System.Data.DataTable dt_Treat_Plan = this.cntrl.get_invoiceDetails(EHR_invoice);
                string discount_string = "";
                if (dt_Treat_Plan.Rows.Count > 0)
                {
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999' colspan='6'><FONT COLOR=black FACE='Geneva, segoe UI' SIZE=3> &nbsp;TREATMENT PLAN</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr height='30px' >");
                    sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>TREATMENT</b></font></td>");
                    sWrite.WriteLine("<td align='right' width='50px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>QUANTITY</b></font></td>");
                    sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>COST</b></font></td>");
                    sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>DISCOUNT</b></font></td>");
                    sWrite.WriteLine("<td align='right' width='100px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>TAX</b></font></td>");
                    sWrite.WriteLine("<td align='right'width='150px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>TOTAL AMOUNT</b></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("</tr>");
                    while (k < dt_Treat_Plan.Rows.Count)
                    {
                        if (dt_Treat_Plan.Rows[k]["discount_type"].ToString() == "INR")
                        {
                            discount_string = " ";
                        }
                        else
                        {
                            discount_string = "(" + dt_Treat_Plan.Rows[k]["discount"].ToString() + "%)";
                        }

                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left'  ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + dt_Treat_Plan.Rows[k]["services"].ToString() + "</font></td>");
                        Decimal qty = Convert.ToDecimal(dt_Treat_Plan.Rows[k]["unit"].ToString());
                        string str_qty = "";
                        if (qty > 1)
                        {
                            str_qty = dt_Treat_Plan.Rows[k]["unit"].ToString();
                        }
                        sWrite.WriteLine("<td align='right'  ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp" + str_qty + "</font></td>");
                        sWrite.WriteLine("<td align='right'  ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + Convert.ToDecimal(dt_Treat_Plan.Rows[k]["cost"].ToString()).ToString("##0.00") + "</font></td>");
                        sWrite.WriteLine("<td align='right'  ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp" + Convert.ToDecimal(dt_Treat_Plan.Rows[k]["discountin_rs"].ToString()).ToString("##0.00") + discount_string + "</font></td>");
                        sWrite.WriteLine("<td align='right'  ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp" + Convert.ToDecimal(dt_Treat_Plan.Rows[k]["tax_inrs"].ToString()).ToString("##0.00") + "</font></td>");
                        sWrite.WriteLine("<td align='right'  ><FONT COLOR=black FACE='segoe UI' SIZE=2>&nbsp;" + Convert.ToDecimal(dt_Treat_Plan.Rows[k]["total_cost"].ToString()).ToString("##0.00") + "</font></td>");
                        sWrite.WriteLine("</tr>");
                        k++;
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='right' colspan=5 ><FONT COLOR=black FACE='segoe UI' SIZE=2><b>  Grand Total :</b> </font></td>");
                    sWrite.WriteLine("<td align='right' colspan=6  ><FONT COLOR=black FACE='segoe UI' SIZE=2><b> " + Lab_GrandTotal.Text + " </b> </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='segoe UI' SIZE=3></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
            }
            //Prescription
            if (dgv_prescrptn.Rows.Count > 0 && EHR_Pre != "")
            {
                sqlstring = "SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,date FROM tbl_prescription where pt_id='" + patient_id + "' and pres_id ='" + EHR_Pre + "' ORDER BY id";
                System.Data.DataTable dt_prescription = this.cntrl.get_pres_details_wit_ptid(patient_id, EHR_Pre);
                if (dt_prescription.Rows.Count > 0)
                {
                    sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='700px' bgcolor='#999999' colspan='5'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;PRESCRIPTION</font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr height='30px'>");
                    sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>DRUG NAME</b></font></td>");
                    sWrite.WriteLine("<td align='center' width='100px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>STRENGTH</b></font></td>");
                    sWrite.WriteLine("<td align='center' width='100px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>FREQUENCY</b></font></td>");
                    sWrite.WriteLine("<td align='left' width='200px'><FONT COLOR=black FACE='segoe UI' SIZE=2><b>INSTRUCTIONS</b></font></td>");
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
                        sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + dt_prescription.Rows[p]["drug_name"].ToString() + "</font></td>");
                        sWrite.WriteLine("<td align='center' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + dt_prescription.Rows[p]["strength_gr"].ToString() + "" + dt_prescription.Rows[p]["strength"].ToString() + "</font></td>");
                        sWrite.WriteLine("<td align='center' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + morning + "-" + noon + "-" + night + "</font></th>");
                        sWrite.WriteLine("<td align='left'   ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + dt_prescription.Rows[p]["duration_unit"].ToString() + " " + dt_prescription.Rows[p]["duration_period"].ToString() + " " + dt_prescription.Rows[p]["add_instruction"].ToString() + "</font></td>");
                        sWrite.WriteLine("</tr>");
                        p++;
                    }
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='left' height='20'><FONT COLOR=black FACE='segoe UI' SIZE=3></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
            }
            if (checkBoxReview.Checked == true)
            {
                sWrite.WriteLine("<table align='center'style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' width:'100px' bgcolor='#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3>&nbsp;NEXT REVIEW </font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='left' width:'100px' ><FONT COLOR=black FACE='segoe UI' SIZE=2> &nbsp;" + startDateTime1 + "</font></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
            }
            sWrite.WriteLine("<script>window.print();</script>");
            sWrite.WriteLine("</body>");
            sWrite.WriteLine("</html>");
            sWrite.Close();
            System.Diagnostics.Process.Start(Apppath + "\\SimpleAppointment.html");
        }
    }
}
