﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class Add__invoice : Form,Add_invoice_interface
    {
        public string doctor_id = "0"; public string staff_id = "";
        public string patient_id = "";
        string  admin_id = "0";
        public string complete_proce_id = "";
        string id;
        string P_Plan_id = "0";
        string P_Completed_id = "0";
        Decimal discounttotal = 0;
        Decimal taxrstotal = 0;
        int status = 0;
        string invoicetype = "service";
        Decimal P_tax = 0;
        string stock_id = "0";
        public string[] teeth = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        Add_invoice_controller cntrl;
        common_model cmodel = new common_model();
        public string invoiceid = "";
        addfinsed_treatment_model fmodel = new addfinsed_treatment_model();
        public Add__invoice()
        {
            InitializeComponent();
        }

        private void Add__invoice_Load(object sender, EventArgs e)
        {
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            DataTable admin = this.cntrl.get_adminid();//  db.table("select id from tbl_doctor where login_type='admin'");
            if (admin.Rows.Count > 0)
            {
                if (admin.Rows[0]["id"].ToString() != doctor_id)
                {
                    admin_id = admin.Rows[0]["id"].ToString();
                }
            }
            DataTable clinicname = cmodel.Get_CompanyNAme();// db.table("select name from tbl_practice_details");
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0]["name"].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
            DataTable docnam = cmodel.Get_DoctorName(doctor_id);// db.table("select doctor_name from tbl_doctor Where id='" + doctor_id + "'");
            if (docnam.Rows.Count > 0)
            {
                toolStripTextDoctor.Text = "Logged In As : " + docnam.Rows[0][0].ToString();
            }
            panel3.Hide();
            panel6.Hide();
            DGV_Invoice.Hide();
            //patient_id = ptid;
            label14.Hide();
            //listpatientsearch.Hide();
            Cmb_batch.Hide();
            foreach (DataGridViewColumn column in DGV_Invoice.Columns) 
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in DGV_Procedure.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DataTable dt = cmodel.get_all_doctorname();// db.table("select DISTINCT id,doctor_name from tbl_doctor  where login_type='doctor' or login_type='admin' and activate_login='yes'  order by doctor_name");
            if (dt.Rows.Count > 0)
            {
                Cmb_Doctor.DataSource = dt;
                Cmb_Doctor.DisplayMember = "doctor_name";
                Cmb_Doctor.ValueMember = "id";
                Cmb_Doctor.SelectedIndex = 0;
            }
            if (doctor_id != "0")
            {
                int dr_index = 0;
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (dt.Rows[j]["id"].ToString() == doctor_id)
                        {
                            dr_index = j;
                        }
                    }
                    Cmb_Doctor.SelectedIndex = dr_index;
                }
            }
            DataTable patient = cmodel.Get_Patient_id_NAme(patient_id);// db.table("select pt_name,pt_id from tbl_patient where id='" + ptid + "'");
            if (patient.Rows.Count > 0)
            {
                linkL_Name.Text = patient.Rows[0]["pt_name"].ToString();
                //patientid = patient.Rows[0]["pt_id"].ToString();
                linkLabel_id.Text = patient.Rows[0]["pt_id"].ToString();
            }
            System.Data.DataTable pay = cmodel.get_total_payment(patient_id);// db.table("select total_payment from tbl_invoices where pt_id='" + ptid + "'");
            if (pay.Rows.Count > 0)
            {
                lab_due.Text = pay.Rows[0]["total_payment"].ToString() + "due";
            }
            DataTable invno = null;
            invno = this.cntrl.Get_invoice_prefix();// db.table("select invoice_prefix,invoice_number from tbl_invoice_automaticid where invoive_automation='Yes'");
            if (invno.Rows.Count == 0)
            {
                text_billno.ReadOnly = false;
            }
            else
            {
                text_billno.Text = invno.Rows[0]["invoice_prefix"].ToString() + invno.Rows[0]["invoice_number"].ToString();
            }
            Cmb_tax.Hide();
            txt_Discount.Hide();
            CMB_Discount.Hide();
            txt_SearchProcedure.Visible = true;
            DataTable dt5 = this.cntrl.load_tax();// db.table("select id,tax_name from tbl_tax");
            if (dt5.Rows.Count > 0)
            {
                Cmb_tax.DataSource = dt5;
                Cmb_tax.DisplayMember = "tax_name";
                Cmb_tax.ValueMember = "id";
                Cmb_tax.Text = "";
            }
            this.cntrl.get_completed_procedure_details(patient_id);// DataTable dt_tp1 = db.table("SELECT id, procedure_name,procedure_id,cost from tbl_completed_procedures where pt_id='" + patient_id + "' and status='1'");
            this.cntrl.get_planed_procedure(patient_id);
            this.cntrl.load_AllProcedures();
            //fmodel.load_proceduresgrid();
            //DataTable dt_tp = db.table("SELECT id, plan_main_id,procedure_name,procedure_id,cost from tbl_treatment_plan where pt_id='" + patient_id + "' and status='1'");
            if (invoiceid != "")
            {
                btn_SaveInvoice.Text = "Update";
                text_billno.Text = invoiceid;
               this.cntrl.Get_invoice_deatils(patient_id, invoiceid);// db.table("select * from tbl_invoices where pt_id='" + ptid + "' and invoice_no='" + invoiceid + "'");
            }
            if (complete_proce_id != "")
            {
                Decimal totalcost = 0;
                Decimal discounttotal = 0;
                Decimal taxtotalamount = 0;
                Decimal totalgrant = 0;
                DGV_Invoice.Show();
                string value = complete_proce_id;
                string[] parts = value.Split(new string[] { "," }, StringSplitOptions.None);
                for (int i = 0; i < parts.Length; i++)
                {
                    System.Data.DataTable rs_plan = this.cntrl.load_completed_procedure(parts[i]);//  db.table("select A.procedure_id," +
                    //"A.procedure_name,A.quantity,A.cost," +
                    //"A.discount_type,A.discount,A.total," +
                    //"A.discount_inrs,A.note,A.date," +
                    //"A.dr_id,A.tooth,B.doctor_name,A.completed_id from tbl_completed_procedures as A join tbl_doctor as B on B.id=A.dr_id where A.id='" + parts[i] + "'");
                    if (rs_plan.Rows.Count > 0)
                    {
                        DGV_Invoice.Rows.Add(rs_plan.Rows[0]["procedure_id"].ToString(), rs_plan.Rows[0]["procedure_name"].ToString(), rs_plan.Rows[0]["cost"].ToString(), rs_plan.Rows[0]["quantity"].ToString(), rs_plan.Rows[0]["discount"].ToString(), rs_plan.Rows[0]["discount_type"].ToString(), "NA", rs_plan.Rows[0]["total"].ToString(), rs_plan.Rows[0]["discount_inrs"].ToString(), "0", rs_plan.Rows[0]["dr_id"].ToString(), rs_plan.Rows[0]["doctor_name"].ToString(), rs_plan.Rows[0]["note"].ToString(), rs_plan.Rows[0]["tooth"].ToString(), "0", parts[i], rs_plan.Rows[0]["date"].ToString(), "");
                        DGV_Invoice.Rows[DGV_Invoice.Rows.Count - 1].Cells[17].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        img.ImageLayout = DataGridViewImageCellLayout.Normal;
                        totalcost = totalcost + (decimal.Parse(rs_plan.Rows[0]["cost"].ToString()) * decimal.Parse(rs_plan.Rows[0]["quantity"].ToString()));
                        discounttotal = discounttotal + decimal.Parse(rs_plan.Rows[0]["discount_inrs"].ToString());
                        totalgrant = totalgrant + decimal.Parse(rs_plan.Rows[0]["total"].ToString());
                    }
                }
                taxtotalamount = 0;
                txt_TotalCost.Text = totalcost.ToString("F");
                txt_TotalDiscount.Text = discounttotal.ToString("F");
                txt_TotalTax.Text = taxtotalamount.ToString("F");
                txt_GrantTotal.Text = totalgrant.ToString("F"); 
                panel2.Show();
                panel3.Show();
                panel6.Show();
            }

        }
        public void SetController(Add_invoice_controller controller)
        {
            cntrl = controller;
        }
        public void Load_procedureGrid(DataTable dt_tp1)
        {
            if (dt_tp1.Rows.Count > 0)
            {
                for (int j = 0; j < dt_tp1.Rows.Count; j++)
                {
                    Double gtotal = 0;
                    gtotal = Convert.ToDouble(dt_tp1.Rows[j]["cost"].ToString());
                    DGV_Procedure.Rows.Add(dt_tp1.Rows[j]["procedure_id"].ToString(), dt_tp1.Rows[j]["procedure_name"].ToString(), "(Completed)", gtotal.ToString("F"), "0", dt_tp1.Rows[j]["id"].ToString());
                    DGV_Procedure.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                    DGV_Procedure.Rows[j].Cells[2].Style.ForeColor = Color.DarkGreen;
                }
            }
        }
        public void Load_planed_procedure(DataTable dt_tp)
        {
            if (dt_tp.Rows.Count > 0)
            {
                for (int j = 0; j < dt_tp.Rows.Count; j++)
                {
                    Double gtotal1 = 0;
                    gtotal1 = Convert.ToDouble(dt_tp.Rows[j]["cost"].ToString());
                    DGV_Procedure.Rows.Add(dt_tp.Rows[j]["procedure_id"].ToString(), dt_tp.Rows[j]["procedure_name"].ToString(), "(Planned)", gtotal1.ToString("F"), dt_tp.Rows[j]["id"].ToString(), "0");
                    DGV_Procedure.Rows[DGV_Procedure.Rows.Count - 1].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                    DGV_Procedure.Rows[DGV_Procedure.Rows.Count - 1].Cells[2].Style.ForeColor = Color.Blue;

                }
            }
        }
        public void Load_searchProcedures(DataTable dt_pt)
        {
            if (dt_pt.Rows.Count > 0)
            {
                for (int j = 0; j < dt_pt.Rows.Count; j++)
                {
                    Double gtotal2 = 0;
                    gtotal2 = Convert.ToDouble(dt_pt.Rows[j]["cost"].ToString());
                    DGV_Procedure.Rows.Add(dt_pt.Rows[j]["id"].ToString(), dt_pt.Rows[j]["name"].ToString(), "", gtotal2.ToString("F"), "0", "0");
                }
            }
        }
        public void load_invoice_details(DataTable dt2)
        {
            int i = 0;
            if (dt2.Rows.Count > 0)
            {
                while (i < dt2.Rows.Count)
                {
                    string drid = dt2.Rows[i]["dr_id"].ToString();
                    try
                    {
                        DataTable  dr_Name = cmodel.Get_DoctorName(drid);//  db.scalar("select doctor_name from tbl_doctor where id='" + drid + "'");
                        DGV_Invoice.Rows.Add(dt2.Rows[i][4].ToString(), dt2.Rows[i][5].ToString(), dt2.Rows[i][6].ToString(), dt2.Rows[i][7].ToString(), dt2.Rows[i][8].ToString(), dt2.Rows[i][9].ToString(), dt2.Rows[i][10].ToString(), dt2.Rows[i][18].ToString(), dt2.Rows[i][19].ToString(), dt2.Rows[i][17].ToString(), dr_Name.Rows[0]["doctor_name"].ToString(), "0");
                        i++;
                        DGV_Invoice.Rows[DGV_Invoice.Rows.Count - 1].Cells[17].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        img.ImageLayout = DataGridViewImageCellLayout.Normal;
                        Cmb_Doctor.Text = dr_Name.Rows[0]["doctor_name"].ToString();
                        DTP_Date.Value = Convert.ToDateTime(dt2.Rows[0][11].ToString());
                        RTB_Notes.Text = dt2.Rows[0][12].ToString();
                        txt_TotalCost.Text = dt2.Rows[0][13].ToString();
                        txt_TotalDiscount.Text = dt2.Rows[0][14].ToString();
                        txt_TotalTax.Text = dt2.Rows[0][15].ToString();
                        txt_GrantTotal.Text = dt2.Rows[0][16].ToString();
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void txt_SearchProcedure_KeyUp(object sender, KeyEventArgs e)
        {
            DGV_Procedure.RowCount = 0;
            this.cntrl.search_procedure_completed(patient_id, txt_SearchProcedure.Text);
            this.cntrl.Search_procedure_planed(patient_id, txt_SearchProcedure.Text);
            this.cntrl.search_procedures(txt_SearchProcedure.Text);
        }

        private void txt_SearchProcedure_Click(object sender, EventArgs e)
        {
            txt_SearchProcedure.Text = "";
        }

        private void DGV_Procedure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Show();
            panel6.Show();
            DGV_Invoice.Show();
            //label18.Hide();
            panel1.Hide();
            txt_Discount.Hide();
            CMB_Discount.Hide();
            Cmb_tax.Hide();
            lab_AddDiscount.Show();
            lab_AddTax.Show();
            if (e.RowIndex >= 0)
            {
                int r = e.RowIndex;
                id = DGV_Procedure.Rows[r].Cells[0].Value.ToString();
                P_Plan_id = DGV_Procedure.Rows[r].Cells[4].Value.ToString();
                P_Completed_id = DGV_Procedure.Rows[r].Cells[5].Value.ToString();
                //P_tax = 0;
                string idd = id;
                panel2.Show();
                DataTable dt = this.cntrl.get_procedure_Name(id);// db.table("select name,cost from tbl_addproceduresettings where id ='" + id + "'");
                if (dt.Rows.Count > 0)
                {
                    procedure_item.Text = dt.Rows[0]["name"].ToString();
                    NMUP_Unit.Text = "1";
                    txt_Discount.Text = "0";
                    CMB_Discount.Text = "INR";
                    Cmb_tax.Text = "NA";
                    RTB_Notes.Text = "";
                    RTB_Notes.Width = 500;
                    Lab_Cost.Text = dt.Rows[0]["cost"].ToString();
                    lab_Total.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt.Rows[0]["cost"].ToString()), 2, MidpointRounding.AwayFromZero));
                }
                label33.Text = "";
                Lab_teeth.Text = "Teeth";
                if (P_Plan_id != "0")
                {
                    this.cntrl.Get_treatment_details(P_Plan_id);
                    //DataTable dt_treatment = db.table("select procedure_name,quantity,cost,discount_type,discount,discount_inrs,note,tooth,total from tbl_treatment_plan where id ='" + P_Plan_id + "'");
                    //if (dt_treatment.Rows.Count > 0)
                    //{
                    //    procedure_item.Text = dt_treatment.Rows[0]["procedure_name"].ToString();
                    //    NMUP_Unit.Text = dt_treatment.Rows[0]["quantity"].ToString();
                    //    txt_Discount.Text = dt_treatment.Rows[0]["discount"].ToString();
                    //    CMB_Discount.Text = dt_treatment.Rows[0]["discount_type"].ToString();
                    //    RTB_Notes.Text = dt_treatment.Rows[0]["note"].ToString();
                    //    RTB_Notes.Width = 500;
                    //    Lab_Cost.Text = dt_treatment.Rows[0]["cost"].ToString();
                    //    lab_Total.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt_treatment.Rows[0]["total"].ToString()), 2, MidpointRounding.AwayFromZero));
                    //    label33.Text = dt_treatment.Rows[0]["tooth"].ToString();
                    //    if (txt_Discount.Text != "" && txt_Discount.Text != "0")
                    //    {
                    //        lab_AddDiscount.Hide();
                    //        txt_Discount.Show();
                    //        CMB_Discount.Show();
                    //    }
                    //}
                }
                if (P_Completed_id != "0")
                {
                    this.cntrl.Get_completed_table_details(P_Completed_id);
                    //DataTable dt_treatment = db.table("select procedure_name,quantity,cost,discount_type,discount,discount_inrs,note,tooth,total from tbl_completed_procedures where id ='" + P_Completed_id + "'");
                    //if (dt_treatment.Rows.Count > 0)
                    //{
                    //    procedure_item.Text = dt_treatment.Rows[0]["procedure_name"].ToString();
                    //    NMUP_Unit.Text = dt_treatment.Rows[0]["quantity"].ToString();
                    //    txt_Discount.Text = dt_treatment.Rows[0]["discount"].ToString();
                    //    CMB_Discount.Text = dt_treatment.Rows[0]["discount_type"].ToString();
                    //    RTB_Notes.Text = dt_treatment.Rows[0]["note"].ToString();
                    //    RTB_Notes.Width = 500;
                    //    Lab_Cost.Text = dt_treatment.Rows[0]["cost"].ToString();
                    //    lab_Total.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt_treatment.Rows[0]["total"].ToString()), 2, MidpointRounding.AwayFromZero));
                    //    label33.Text = dt_treatment.Rows[0]["tooth"].ToString();
                    //    if (txt_Discount.Text != "" && txt_Discount.Text != "0")
                    //    {
                    //        lab_AddDiscount.Hide();
                    //        txt_Discount.Show();
                    //        CMB_Discount.Show();
                    //    }
                    //}
                }
                Chk_MultiplyCost.Checked = false;
                CHk_FullMouth.Checked = false;
                chk11.Checked = false; chk12.Checked = false;
                chk13.Checked = false; chk14.Checked = false;
                chk15.Checked = false; chk16.Checked = false;
                chk17.Checked = false; chk18.Checked = false;

                chk21.Checked = false; chk22.Checked = false;
                chk23.Checked = false; chk24.Checked = false;
                chk25.Checked = false; chk26.Checked = false;
                chk27.Checked = false; chk28.Checked = false;

                chk31.Checked = false; chk32.Checked = false;
                chk33.Checked = false; chk34.Checked = false;
                chk35.Checked = false; chk36.Checked = false;
                chk37.Checked = false; chk38.Checked = false;

                chk41.Checked = false; chk42.Checked = false;
                chk43.Checked = false; chk44.Checked = false;
                chk45.Checked = false; chk46.Checked = false;
                chk47.Checked = false; chk48.Checked = false;

                chk51.Checked = false; chk52.Checked = false;
                chk53.Checked = false; chk54.Checked = false;
                chk55.Checked = false; chk61.Checked = false;
                chk62.Checked = false; chk63.Checked = false;
                chk64.Checked = false; chk65.Checked = false;

                chk71.Checked = false; chk72.Checked = false;
                chk73.Checked = false; chk74.Checked = false;
                chk75.Checked = false; chk81.Checked = false;
                chk82.Checked = false; chk83.Checked = false;
                chk84.Checked = false; chk85.Checked = false;
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
        }

        public void Fill_Alltreatment_deatils(DataTable dt_treatment)
        {
            if (dt_treatment.Rows.Count > 0)
            {
                procedure_item.Text = dt_treatment.Rows[0]["procedure_name"].ToString();
                NMUP_Unit.Text = dt_treatment.Rows[0]["quantity"].ToString();
                txt_Discount.Text = dt_treatment.Rows[0]["discount"].ToString();
                CMB_Discount.Text = dt_treatment.Rows[0]["discount_type"].ToString();
                RTB_Notes.Text = dt_treatment.Rows[0]["note"].ToString();
                RTB_Notes.Width = 500;
                Lab_Cost.Text = dt_treatment.Rows[0]["cost"].ToString();
                lab_Total.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt_treatment.Rows[0]["total"].ToString()), 2, MidpointRounding.AwayFromZero));
                label33.Text = dt_treatment.Rows[0]["tooth"].ToString();
                if (txt_Discount.Text != "" && txt_Discount.Text != "0")
                {
                    lab_AddDiscount.Hide();
                    txt_Discount.Show();
                    CMB_Discount.Show();
                }
            }
        }

        private void NMUP_Unit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NMUP_Unit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (invoicetype == "drug")
                {
                    if (status == 1)
                    {
                        if (!String.IsNullOrWhiteSpace(NMUP_Unit.Text))
                        {
                            int qty = 0;
                            DataTable testQty = this.cntrl.Get_quantiry_fromStock(stock_id);// db.table("select quantity from tbl_add_stock where id='" + stock_id + "'");
                            if (testQty.Rows.Count > 0)
                            {
                                qty = int.Parse(testQty.Rows[0][0].ToString());
                            }
                            if (int.Parse(NMUP_Unit.Text) > qty || int.Parse(NMUP_Unit.Text) == 0)
                            {
                                lab_Msg.Show();
                            }
                            else
                            {
                                lab_Msg.Hide();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Choose an Item From Left By Just clicking on an Item..", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                calculations();
            }
            catch(Exception ex)
            {

            }
        }

        public void calculations()
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
            ///

        }

        private void lab_AddDiscount_Click(object sender, EventArgs e)
        {
            txt_Discount.Visible = true;
            CMB_Discount.Visible = true;
            lab_AddDiscount.Hide();
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

        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            calculations();
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

        private void lab_AddTax_Click(object sender, EventArgs e)
        {
            Cmb_tax.Show();
            //temptotal = lab_Total.Text.ToString();
            lab_AddTax.Hide();
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

        private void Cmb_tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculations();
        }

        private void Lab_teeth_Click(object sender, EventArgs e)
        {
            if (procedure_item.Text != "PRODUCTS AND SERVICES")
            {
                panel1.Visible = true;
                panel4.Visible = false;
            }
            else
            {
                MessageBox.Show("Services not found..!!");
            }
        }

        private void Chk_MultiplyCost_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_MultiplyCost.Checked == true)
            {
                decimal q = Convert.ToDecimal(NMUP_Unit.Text.ToString());
                NMUP_Unit.Text = Convert.ToString(q);
            }
        }

        private void CHk_FullMouth_CheckedChanged(object sender, EventArgs e)
        {
            if (CHk_FullMouth.Checked)
            {
                chk11.Checked = true; chk12.Checked = true;
                chk13.Checked = true; chk14.Checked = true;
                chk15.Checked = true; chk16.Checked = true;
                chk17.Checked = true; chk18.Checked = true;

                chk21.Checked = true; chk22.Checked = true;
                chk23.Checked = true; chk24.Checked = true;
                chk25.Checked = true; chk26.Checked = true;
                chk27.Checked = true; chk28.Checked = true;

                chk31.Checked = true; chk32.Checked = true;
                chk33.Checked = true; chk34.Checked = true;
                chk35.Checked = true; chk36.Checked = true;
                chk37.Checked = true; chk38.Checked = true;

                chk41.Checked = true; chk42.Checked = true;
                chk43.Checked = true; chk44.Checked = true;
                chk45.Checked = true; chk46.Checked = true;
                chk47.Checked = true; chk48.Checked = true;
                label33.Text = "Full Mouth";
            }
            else
            {

                label33.Text = "";
                checkBox_control();
            }
        }

        public void checkBox_control()
        {
            chk11.Enabled = true; chk12.Enabled = true;
            chk13.Enabled = true; chk14.Enabled = true;
            chk15.Enabled = true; chk16.Enabled = true;
            chk17.Enabled = true; chk18.Enabled = true;

            chk21.Enabled = true; chk22.Enabled = true;
            chk23.Enabled = true; chk24.Enabled = true;
            chk25.Enabled = true; chk26.Enabled = true;
            chk27.Enabled = true; chk28.Enabled = true;

            chk31.Enabled = true; chk32.Enabled = true;
            chk33.Enabled = true; chk34.Enabled = true;
            chk35.Enabled = true; chk36.Enabled = true;
            chk37.Enabled = true; chk38.Enabled = true;

            chk41.Enabled = true; chk42.Enabled = true;
            chk43.Enabled = true; chk44.Enabled = true;
            chk45.Enabled = true; chk46.Enabled = true;
            chk47.Enabled = true; chk48.Enabled = true;

            chk51.Enabled = true; chk52.Enabled = true;
            chk53.Enabled = true; chk54.Enabled = true;
            chk55.Enabled = true; chk61.Enabled = true;
            chk62.Enabled = true; chk63.Enabled = true;
            chk64.Enabled = true; chk65.Enabled = true;

            chk71.Enabled = true; chk72.Enabled = true;
            chk73.Enabled = true; chk74.Enabled = true;
            chk75.Enabled = true; chk81.Enabled = true;
            chk82.Enabled = true; chk83.Enabled = true;
            chk84.Enabled = true; chk85.Enabled = true;

            chk11.Checked = false; chk12.Checked = false;
            chk13.Checked = false; chk14.Checked = false;
            chk15.Checked = false; chk16.Checked = false;
            chk17.Checked = false; chk18.Checked = false;

            chk21.Checked = false; chk22.Checked = false;
            chk23.Checked = false; chk24.Checked = false;
            chk25.Checked = false; chk26.Checked = false;
            chk27.Checked = false; chk28.Checked = false;

            chk31.Checked = false; chk32.Checked = false;
            chk33.Checked = false; chk34.Checked = false;
            chk35.Checked = false; chk36.Checked = false;
            chk37.Checked = false; chk38.Checked = false;

            chk41.Checked = false; chk42.Checked = false;
            chk43.Checked = false; chk44.Checked = false;
            chk45.Checked = false; chk46.Checked = false;
            chk47.Checked = false; chk48.Checked = false;

            chk51.Checked = false; chk52.Checked = false;
            chk53.Checked = false; chk54.Checked = false;
            chk55.Checked = false; chk61.Checked = false;
            chk62.Checked = false; chk63.Checked = false;
            chk64.Checked = false; chk65.Checked = false;

            chk71.Checked = false; chk72.Checked = false;
            chk73.Checked = false; chk74.Checked = false;
            chk75.Checked = false; chk81.Checked = false;
            chk82.Checked = false; chk83.Checked = false;
            chk84.Checked = false; chk85.Checked = false;
        }
        private void chk18_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk18.Checked) { teeth[0] = "18"; } else { teeth[0] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk17_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk17.Checked) { teeth[1] = "17"; } else { teeth[1] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk16_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk16.Checked) { teeth[2] = "16"; } else { teeth[2] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk15_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk15.Checked) { teeth[3] = "15"; } else { teeth[3] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk14_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk14.Checked) { teeth[4] = "14"; } else { teeth[4] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk13_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk13.Checked) { teeth[5] = "13"; } else { teeth[5] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk12_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk12.Checked) { teeth[6] = "12"; } else { teeth[6] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk11_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk11.Checked) { teeth[7] = "11"; } else { teeth[7] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk21_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk21.Checked) { teeth[8] = "21"; } else { teeth[8] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk22_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk22.Checked) { teeth[9] = "22"; } else { teeth[9] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk23_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk23.Checked) { teeth[10] = "23"; } else { teeth[10] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk24_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk24.Checked) { teeth[11] = "24"; } else { teeth[11] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk25_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk25.Checked) { teeth[12] = "25"; } else { teeth[12] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk26_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk26.Checked) { teeth[13] = "26"; } else { teeth[13] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk27_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk27.Checked) { teeth[14] = "27"; } else { teeth[14] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk28_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk28.Checked) { teeth[15] = "28"; } else { teeth[15] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk48_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk48.Checked) { teeth[31] = "48"; } else { teeth[31] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk47_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk47.Checked) { teeth[30] = "47"; } else { teeth[30] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk46_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk46.Checked) { teeth[29] = "46"; } else { teeth[29] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk45_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk45.Checked) { teeth[28] = "45"; } else { teeth[28] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk44_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk44.Checked) { teeth[27] = "44"; } else { teeth[27] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk43_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk43.Checked) { teeth[26] = "43"; } else { teeth[26] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk42_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk42.Checked) { teeth[25] = "42"; } else { teeth[25] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk41_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk41.Checked) { teeth[24] = "41"; } else { teeth[24] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk31_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk31.Checked) { teeth[23] = "31"; } else { teeth[23] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk32_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk32.Checked) { teeth[22] = "32"; } else { teeth[22] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk33_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk33.Checked) { teeth[21] = "33"; } else { teeth[21] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk34_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk34.Checked) { teeth[20] = "34"; } else { teeth[20] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk35_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk35.Checked) { teeth[19] = "35"; } else { teeth[19] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk36_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk36.Checked) { teeth[18] = "36"; } else { teeth[18] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk37_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk37.Checked) { teeth[17] = "37"; } else { teeth[17] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk38_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk38.Checked) { teeth[16] = "38"; } else { teeth[16] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk55_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk55.Checked) { teeth[32] = "55"; } else { teeth[32] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk54_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk54.Checked) { teeth[33] = "54"; } else { teeth[33] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk53_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk53.Checked) { teeth[34] = "53"; } else { teeth[34] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk52_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk52.Checked) { teeth[35] = "52"; } else { teeth[35] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk51_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk51.Checked) { teeth[36] = "51"; } else { teeth[36] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk61_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk61.Checked) { teeth[37] = "61"; } else { teeth[37] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk62_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk62.Checked) { teeth[38] = "62"; } else { teeth[38] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk63_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk63.Checked) { teeth[39] = "63"; } else { teeth[39] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk64_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk64.Checked) { teeth[40] = "64"; } else { teeth[40] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk65_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk65.Checked) { teeth[41] = "65"; } else { teeth[41] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk85_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk85.Checked) { teeth[51] = "85"; } else { teeth[51] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk84_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk84.Checked) { teeth[50] = "84"; } else { teeth[50] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk83_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk83.Checked) { teeth[49] = "83"; } else { teeth[49] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk82_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk82.Checked) { teeth[48] = "82"; } else { teeth[48] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk81_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk81.Checked) { teeth[47] = "81"; } else { teeth[47] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk71_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk71.Checked) { teeth[46] = "71"; } else { teeth[46] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk72_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk72.Checked) { teeth[45] = "72"; } else { teeth[45] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk73_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk73.Checked) { teeth[44] = "73"; } else { teeth[44] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk74_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk74.Checked) { teeth[43] = "74"; } else { teeth[43] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void chk75_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk75.Checked) { teeth[42] = "75"; } else { teeth[42] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked)
            {
                if (qty.ToString() == "0")
                {
                    NMUP_Unit.Text = "1";
                }
                else
                {
                    NMUP_Unit.Text = qty.ToString();
                }
            }
            if (toothno.Length > 2) { label33.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label33.Text = ""; }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            label33.Text = "";
           checkBox_control();
            panel1.Hide();
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void chk_fulmac_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_fulmac.Checked)
            {
                chk51.Checked = true; chk52.Checked = true;
                chk53.Checked = true; chk54.Checked = true;
                chk55.Checked = true; chk61.Checked = true;
                chk62.Checked = true; chk63.Checked = true;
                chk64.Checked = true; chk65.Checked = true;

                chk71.Checked = true; chk72.Checked = true;
                chk73.Checked = true; chk74.Checked = true;
                chk75.Checked = true; chk81.Checked = true;
                chk82.Checked = true; chk83.Checked = true;
                chk84.Checked = true; chk85.Checked = true;
            }
            else
            {
                chk51.Checked = false; chk52.Checked = false;
                chk53.Checked = false; chk54.Checked = false;
                chk55.Checked = false; chk61.Checked = false;
                chk62.Checked = false; chk63.Checked = false;
                chk64.Checked = false; chk65.Checked = false;

                chk71.Checked = false; chk72.Checked = false;
                chk73.Checked = false; chk74.Checked = false;
                chk75.Checked = false; chk81.Checked = false;
                chk82.Checked = false; chk83.Checked = false;
                chk84.Checked = false; chk85.Checked = false;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(NMUP_Unit.Text) || String.IsNullOrWhiteSpace(procedure_item.Text) || procedure_item.Text == "PRODUCTS AND SERVICES")
                {
                    MessageBox.Show("Please enter the Quantity and Cost...","Data not found",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    if (invoicetype == "drug")
                    {
                        if (lab_Msg.Visible == false)
                        {

                            DGV_Invoice.Rows.Add(id, procedure_item.Text, Lab_Cost.Text, NMUP_Unit.Text, txt_Discount.Text, CMB_Discount.Text, Cmb_tax.Text, lab_Total.Text, discounttotal, taxrstotal, Cmb_Doctor.SelectedValue.ToString(), Cmb_Doctor.Text, RTB_Notes.Text.Replace("'", " "), label33.Text, id, stock_id, DTP_Date.Value.ToString("MM/dd/yyyy"), "");
                            DGV_Invoice.Rows[DGV_Invoice.Rows.Count - 1].Cells[17].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            img.ImageLayout = DataGridViewImageCellLayout.Normal;
                            decimal totcost = 0;
                            decimal discount1 = 0, tax1 = 0;
                            for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            {
                                totcost = totcost + (decimal.Parse(DGV_Invoice.Rows[i].Cells[2].Value.ToString()) * decimal.Parse(DGV_Invoice.Rows[i].Cells[3].Value.ToString()));
                                discount1 = discount1 + decimal.Parse(DGV_Invoice.Rows[i].Cells[8].Value.ToString());
                                tax1 = tax1 + decimal.Parse(DGV_Invoice.Rows[i].Cells[9].Value.ToString());
                            }
                            txt_TotalCost.Text = totcost.ToString("F");
                            txt_TotalDiscount.Text = discount1.ToString("F");
                            txt_TotalTax.Text = tax1.ToString("F");
                            txt_GrantTotal.Text = Convert.ToString((totcost + tax1) - discount1);
                        }
                    }
                    else if (invoicetype == "service")
                    {
                        int check_planid = 0;
                        if (P_Plan_id != "0")
                        {
                            for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            {
                                if (P_Plan_id == DGV_Invoice.Rows[i].Cells[14].Value.ToString())
                                {
                                    check_planid = check_planid + 1;
                                }
                            }
                        }
                        if (P_Completed_id != "0")
                        {
                            for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            {
                                if (P_Completed_id == DGV_Invoice.Rows[i].Cells[15].Value.ToString())
                                {
                                    check_planid = check_planid + 1;
                                }
                            }
                        }
                        if (check_planid == 0)
                        {
                            DGV_Invoice.Rows.Add(id, procedure_item.Text, Lab_Cost.Text, NMUP_Unit.Text, txt_Discount.Text, CMB_Discount.Text, Cmb_tax.Text, lab_Total.Text, discounttotal, taxrstotal, Cmb_Doctor.SelectedValue.ToString(), Cmb_Doctor.Text, RTB_Notes.Text.Replace("'", " "), label33.Text, P_Plan_id, P_Completed_id, DTP_Date.Value.ToString("MM/dd/yyyy"), "");
                            DGV_Invoice.Rows[DGV_Invoice.Rows.Count - 1].Cells[17].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                            img.ImageLayout = DataGridViewImageCellLayout.Normal;
                            decimal totcost = 0;
                            decimal discount1 = 0, tax1 = 0;
                            for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            {
                                totcost = totcost + (decimal.Parse(DGV_Invoice.Rows[i].Cells[2].Value.ToString()) * decimal.Parse(DGV_Invoice.Rows[i].Cells[3].Value.ToString()));
                                discount1 = discount1 + decimal.Parse(DGV_Invoice.Rows[i].Cells[8].Value.ToString());
                                tax1 = tax1 + decimal.Parse(DGV_Invoice.Rows[i].Cells[9].Value.ToString());
                            }
                            txt_TotalCost.Text = totcost.ToString("F");
                            txt_TotalDiscount.Text = discount1.ToString("F");
                            txt_TotalTax.Text = tax1.ToString("F");
                            txt_GrantTotal.Text = Convert.ToString((totcost + tax1) - discount1);
                        }
                        else
                        {
                            MessageBox.Show("This Plan/Completed treatment already exist. Please select another treatment and try again...");
                            return;
                        }
                        txt_Discount.Clear();
                        CMB_Discount.Text = "";
                        Cmb_tax.Text = "";
                        txt_Discount.Hide();
                        CMB_Discount.Hide();
                        Cmb_tax.Hide();
                        lab_AddDiscount.Show();
                        lab_AddTax.Show();
                        CMB_Discount.Text = "INR";
                        txt_Discount.Text = "0";
                        Cmb_tax.Text = "NA";
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void DGV_Invoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 17 && e.RowIndex > -1)
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        DGV_Invoice.Rows.RemoveAt(this.DGV_Invoice.SelectedRows[0].Index);
                        if (DGV_Invoice.Rows.Count == 0)
                        {
                            txt_TotalCost.Text = "Total cost";
                            txt_TotalDiscount.Text = "Total Discount";
                            txt_TotalTax.Text = "Total Tax";
                            txt_GrantTotal.Text = "Grant Total";
                        }
                        if (CMB_Discount.SelectedIndex == 0)
                        {
                            delete_gridrow_calculation();
                            //decimal totcost = 0, total2 = 0;
                            //float discount1, dicount2 = 0, tax1 = 0;
                            //for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            //{
                            //    decimal unitcost = decimal.Parse(DGV_Invoice.Rows[i].Cells[2].Value.ToString());
                            //    decimal quantity = decimal.Parse(DGV_Invoice.Rows[i].Cells[3].Value.ToString());
                            //    decimal totalcost = unitcost * quantity;
                            //    totcost = totcost + totalcost;
                            //    txt_TotalCost.Text = totcost.ToString();
                            //    decimal total1 = Convert.ToDecimal(DGV_Invoice.Rows[i].Cells[7].Value.ToString());
                            //    total2 = total2 + total1;
                            //    txt_GrantTotal.Text = total2.ToString();
                            //    float dicount = float.Parse(DGV_Invoice.Rows[i].Cells[8].Value.ToString());
                            //    discount1 = float.Parse(totalcost.ToString()) * (dicount / 100);
                            //    dicount2 = dicount2 + dicount;
                            //    txt_TotalDiscount.Text = dicount2.ToString();
                            //    float tax = float.Parse(DGV_Invoice.Rows[i].Cells[9].Value.ToString());
                            //    tax1 = tax1 + tax;
                            //    txt_TotalTax.Text = tax1.ToString();
                            //}
                        }
                        else if (CMB_Discount.SelectedIndex == 1)
                        {
                            delete_gridrow_calculation();
                            //decimal totcost = 0, total2 = 0;
                            //float discount1, dicount2 = 0, tax1 = 0;
                            //for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            //{
                            //    decimal unitcost = decimal.Parse(DGV_Invoice.Rows[i].Cells[2].Value.ToString());
                            //    decimal quantity = decimal.Parse(DGV_Invoice.Rows[i].Cells[3].Value.ToString());
                            //    decimal totalcost = unitcost * quantity;
                            //    totcost = totcost + totalcost;
                            //    txt_TotalCost.Text = totcost.ToString();
                            //    decimal total1 = Convert.ToDecimal(DGV_Invoice.Rows[i].Cells[7].Value.ToString());
                            //    total2 = total2 + total1;
                            //    txt_GrantTotal.Text = total2.ToString();
                            //    float dicount = float.Parse(DGV_Invoice.Rows[i].Cells[8].Value.ToString());
                            //    discount1 = float.Parse(totalcost.ToString()) * (dicount / 100);
                            //    dicount2 = dicount2 + dicount;
                            //    txt_TotalDiscount.Text = dicount2.ToString();
                            //    float tax = float.Parse(DGV_Invoice.Rows[i].Cells[9].Value.ToString());
                            //    tax1 = tax1 + tax;
                            //    txt_TotalTax.Text = tax1.ToString();
                            //}
                        }
                        txt_Discount.Hide();
                        CMB_Discount.Hide();
                        Cmb_tax.Hide();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void delete_gridrow_calculation()
        {
            decimal totcost = 0, total2 = 0;
            float discount1, dicount2 = 0, tax1 = 0;
            for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
            {
                decimal unitcost = decimal.Parse(DGV_Invoice.Rows[i].Cells[2].Value.ToString());
                decimal quantity = decimal.Parse(DGV_Invoice.Rows[i].Cells[3].Value.ToString());
                decimal totalcost = unitcost * quantity;
                totcost = totcost + totalcost;
                txt_TotalCost.Text = totcost.ToString();
                decimal total1 = Convert.ToDecimal(DGV_Invoice.Rows[i].Cells[7].Value.ToString());
                total2 = total2 + total1;
                txt_GrantTotal.Text = total2.ToString();
                float dicount = float.Parse(DGV_Invoice.Rows[i].Cells[8].Value.ToString());
                discount1 = float.Parse(totalcost.ToString()) * (dicount / 100);
                dicount2 = dicount2 + dicount;
                txt_TotalDiscount.Text = dicount2.ToString();
                float tax = float.Parse(DGV_Invoice.Rows[i].Cells[9].Value.ToString());
                tax1 = tax1 + tax;
                txt_TotalTax.Text = tax1.ToString();
            }
        }

        private void btn_SaveInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_SaveInvoice.Text == "SAVE INVOICE")
                {
                    DataTable receipt = this.cntrl.select_All_invoicedata(text_billno.Text);// db.table("select * from tbl_invoices_main where invoice='" + text_billno.Text + "'");
                    if (receipt.Rows.Count <= 0)
                    {
                        if (doctor_id == "0")
                        {
                            doctor_id = admin_id;
                        }
                        if (DGV_Invoice.RowCount > 0)
                        {
                            int j = 1;
                            this.cntrl.save_invoice_main(patient_id,linkL_Name.Text.ToString(), text_billno.Text.ToString());// int ii = db.execute("insert into tbl_invoices_main (date,pt_id,pt_name,invoice,status,type) values('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + patient_id + "','" + linkL_Name.Text.ToString() + "','" + text_billno.Text.ToString() + "','1','service')");
                            DataTable dt1 = this.cntrl.get_invoiceMain_maxid();// db.table("select MAX(id) from tbl_invoices_main");
                            int invoice_main_id = 0;
                            try
                            {
                                if (Int32.Parse(dt1.Rows[0][0].ToString()) == 0)
                                {
                                    j = 1;
                                    invoice_main_id = 0;
                                }
                                else
                                {
                                    invoice_main_id = Int32.Parse(dt1.Rows[0][0].ToString());
                                }
                            }
                            catch
                            {
                                j = 1;
                                invoice_main_id = 0;
                            }
                            j = invoice_main_id;
                            int jj = 0;
                            for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                            {
                                if (DGV_Invoice[14, i].Value.ToString() == "0" && DGV_Invoice[15, i].Value.ToString() == "0")
                                {
                                    if (jj == 0)
                                    {
                                        DataTable dt_pt = fmodel.get_completed_id(patient_id, DTP_Date.Value.ToString("yyyy-MM-dd"));// db.table("SELECT id FROM tbl_completed_id where patient_id='" + patient_id + "' and completed_date='" + DTP_Date.Value.ToString("yyyy-MM-dd") + "' ORDER BY id");
                                        if (dt_pt.Rows.Count == 0)
                                        {
                                            this.cntrl.save_completedid(DTP_Date.Value.ToString("yyyy-MM-dd"), patient_id);// db.execute("insert into tbl_completed_id (completed_date,patient_id) values('" + DTP_Date.Value.ToString("yyyy-MM-dd") + "','" + patient_id + "')");
                                            DataTable dt = fmodel.get_completedMaxid();// db.table("select MAX(id) from tbl_completed_id");
                                            int completed_id;
                                            try
                                            {
                                                if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
                                                {
                                                    jj = 1;
                                                    completed_id = 0;
                                                }
                                                else
                                                {
                                                    completed_id = Int32.Parse(dt.Rows[0][0].ToString());
                                                }
                                            }
                                            catch
                                            {
                                                jj = 1;
                                                completed_id = 0;
                                            }

                                            jj = completed_id;
                                        }
                                        else
                                        {
                                            jj = Int32.Parse(dt_pt.Rows[0][0].ToString());
                                        }
                                    }
                                    this.cntrl.Save_tbl_completed_procedures(jj, patient_id, DGV_Invoice[0, i].Value.ToString(), DGV_Invoice[1, i].Value.ToString(), DGV_Invoice[3, i].Value.ToString(), DGV_Invoice[2, i].Value.ToString(), DGV_Invoice[5, i].Value.ToString(), DGV_Invoice[4, i].Value.ToString(), DGV_Invoice[7, i].Value.ToString(), DGV_Invoice[8, i].Value.ToString(), DGV_Invoice[12, i].Value.ToString(), DGV_Invoice[10, i].Value.ToString(),"0", DGV_Invoice[13, i].Value.ToString());
                                    // int t_p = db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth) values ('" + jj + "','" + patient_id + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + DGV_Invoice[3, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[5, i].Value.ToString() + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[12, i].Value.ToString() + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DGV_Invoice[10, i].Value.ToString() + "','0','" + DGV_Invoice[13, i].Value.ToString() + "')");
                                    DataTable dt_procedure = this.cntrl.get_completed_procedure_maxid();// db.table("select MAX(id) from tbl_completed_procedures");
                                    int completed_max_id;
                                    if (Int32.Parse(dt_procedure.Rows[0][0].ToString()) == 0)
                                    {
                                        completed_max_id = 0;
                                    }
                                    else
                                    {
                                        completed_max_id = Int32.Parse(dt_procedure.Rows[0][0].ToString());
                                    }
                                    this.cntrl.save_invoice_details(text_billno.Text.ToString(),linkL_Name.Text.ToString() ,patient_id,DGV_Invoice[0, i].Value.ToString(), DGV_Invoice[1, i].Value.ToString(), DGV_Invoice[3, i].Value.ToString() , DGV_Invoice[2, i].Value.ToString() , DGV_Invoice[4, i].Value.ToString(),DGV_Invoice[5, i].Value.ToString() , DGV_Invoice[6, i].Value.ToString(), DGV_Invoice[7, i].Value.ToString() , DGV_Invoice[12, i].Value.ToString() , DGV_Invoice[8, i].Value.ToString() , DGV_Invoice[9, i].Value.ToString() ,DGV_Invoice[10, i].Value.ToString() , DGV_Invoice[8, i].Value.ToString() ,DGV_Invoice[9, i].Value.ToString(), j ,completed_max_id );//db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + text_billno.Text.ToString() + "','" + linkL_Name.Text.ToString() + "','" + patient_id + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + DGV_Invoice[3, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + DGV_Invoice[5, i].Value.ToString() + "','" + DGV_Invoice[6, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DGV_Invoice[12, i].Value.ToString() + "','100','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + DGV_Invoice[10, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + j + "','0','" + completed_max_id + "')");
                                }                               //(string invoice_no,string pt_name, string patient_id,string service_id,string services,string unit,string cost,string discount,string discount_type,string tax,string total, string notes, string total_discount,string total_tax,string dr_id,string discountin_rs,string tax_inrs,string invoice_main_id, string completed_id)
                                if (DGV_Invoice[14, i].Value.ToString() != "0")
                                {
                                    if (jj == 0)
                                    {
                                        DataTable dt_pt = fmodel.get_completed_id(patient_id, DTP_Date.Value.ToString("yyyy-MM-dd"));// db.table("SELECT id FROM tbl_completed_id where patient_id='" + patient_id + "' and completed_date='" + DTP_Date.Value.ToString("yyyy-MM-dd") + "' ORDER BY id");
                                        if (dt_pt.Rows.Count == 0)
                                        {
                                            this.cntrl.save_completedid(DTP_Date.Value.ToString("yyyy-MM-dd"), patient_id);// int iii = db.execute("insert into tbl_completed_id (completed_date,patient_id) values('" + DTP_Date.Value.ToString("yyyy-MM-dd") + "','" + patient_id + "')");
                                            DataTable dt = fmodel.get_completedMaxid();// db.table("select MAX(id) from tbl_completed_id");
                                            int completed_id;
                                            try
                                            {
                                                if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
                                                {
                                                    jj = 1;
                                                    completed_id = 0;
                                                }
                                                else
                                                {
                                                    completed_id = Int32.Parse(dt.Rows[0][0].ToString());
                                                }
                                            }
                                            catch
                                            {
                                                jj = 1;
                                                completed_id = 0;
                                            }

                                            jj = completed_id;
                                        }
                                        else
                                        {
                                            jj = Int32.Parse(dt_pt.Rows[0][0].ToString());
                                        }
                                    }
                                    this.cntrl.Save_tbl_completed_procedures(jj, patient_id, DGV_Invoice[0, i].Value.ToString(), DGV_Invoice[1, i].Value.ToString(), DGV_Invoice[3, i].Value.ToString(), DGV_Invoice[2, i].Value.ToString(), DGV_Invoice[5, i].Value.ToString(), DGV_Invoice[4, i].Value.ToString(), DGV_Invoice[7, i].Value.ToString(), DGV_Invoice[8, i].Value.ToString(), DGV_Invoice[12, i].Value.ToString(), DGV_Invoice[10, i].Value.ToString(), DGV_Invoice[14, i].Value.ToString(), DGV_Invoice[13, i].Value.ToString());

                                    //int t_p = db.execute("insert into tbl_completed_procedures (plan_main_id,pt_id,procedure_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,date,dr_id,completed_id,tooth) values ('" + jj + "','" + patient_id + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + DGV_Invoice[3, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[5, i].Value.ToString() + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[12, i].Value.ToString() + "','0','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DGV_Invoice[10, i].Value.ToString() + "','" + DGV_Invoice[14, i].Value.ToString() + "','" + DGV_Invoice[13, i].Value.ToString() + "')");
                                    DataTable dt_procedure = this.cntrl.get_completed_procedure_maxid();// db.table("select MAX(id) from tbl_completed_procedures");
                                    int completed_max_id;
                                    if (Int32.Parse(dt_procedure.Rows[0][0].ToString()) == 0)
                                    {
                                        completed_max_id = 0;
                                    }
                                    else
                                    {
                                        completed_max_id = Int32.Parse(dt_procedure.Rows[0][0].ToString());
                                    }
                                    fmodel.update_treatment_status(DGV_Invoice[14, i].Value.ToString());// db.execute("update  tbl_treatment_plan set status='0' where id= '" + DGV_Invoice[14, i].Value.ToString() + "'");
                                    this.cntrl.save_invoice_items(text_billno.Text.ToString(), linkL_Name.Text.ToString(),patient_id ,DGV_Invoice[0, i].Value.ToString() , DGV_Invoice[1, i].Value.ToString() ,DGV_Invoice[3, i].Value.ToString(), DGV_Invoice[2, i].Value.ToString() , DGV_Invoice[4, i].Value.ToString(),DGV_Invoice[5, i].Value.ToString(),DGV_Invoice[6, i].Value.ToString(), DGV_Invoice[7, i].Value.ToString(),DGV_Invoice[12, i].Value.ToString() , DGV_Invoice[8, i].Value.ToString() , DGV_Invoice[9, i].Value.ToString(), DGV_Invoice[10, i].Value.ToString() ,DGV_Invoice[8, i].Value.ToString(),DGV_Invoice[9, i].Value.ToString(), j , DGV_Invoice[14, i].Value.ToString(),completed_max_id );//  db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + text_billno.Text.ToString() + "','" + linkL_Name.Text.ToString() + "','" + patient_id + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + DGV_Invoice[3, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + DGV_Invoice[5, i].Value.ToString() + "','" + DGV_Invoice[6, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DGV_Invoice[12, i].Value.ToString() + "','100','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + DGV_Invoice[10, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + j + "','" + DGV_Invoice[14, i].Value.ToString() + "','" + completed_max_id + "')");
                                }
                                if (DGV_Invoice[15, i].Value.ToString() != "0")
                                {
                                    this.cntrl.save_invoice_items(text_billno.Text.ToString(), linkL_Name.Text.ToString(), patient_id, DGV_Invoice[0, i].Value.ToString(), DGV_Invoice[1, i].Value.ToString(), DGV_Invoice[3, i].Value.ToString(), DGV_Invoice[2, i].Value.ToString(), DGV_Invoice[4, i].Value.ToString(), DGV_Invoice[5, i].Value.ToString(), DGV_Invoice[6, i].Value.ToString(), DGV_Invoice[7, i].Value.ToString(), DGV_Invoice[12, i].Value.ToString(), DGV_Invoice[8, i].Value.ToString(), DGV_Invoice[9, i].Value.ToString(), DGV_Invoice[10, i].Value.ToString(), DGV_Invoice[8, i].Value.ToString(), DGV_Invoice[9, i].Value.ToString(), j, DGV_Invoice[14, i].Value.ToString(),Convert.ToInt32( DGV_Invoice[15, i].Value.ToString()));//  db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + text_billno.Text.ToString() + "','" + linkL_Name.Text.ToString() + "','" + patient_id + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + DGV_Invoice[3, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + DGV_Invoice[5, i].Value.ToString() + "','" + DGV_Invoice[6, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DGV_Invoice[12, i].Value.ToString() + "','100','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + DGV_Invoice[10, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + j + "','" + DGV_Invoice[14, i].Value.ToString() + "','" + completed_max_id + "')");

                                    //db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,service_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment,invoice_main_id,plan_id,completed_id) values('" + text_billno.Text.ToString() + "','" + linkL_Name.Text.ToString() + "','" + patient_id + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + DGV_Invoice[3, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + DGV_Invoice[5, i].Value.ToString() + "','" + DGV_Invoice[6, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DGV_Invoice[12, i].Value.ToString() + "','100','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + DGV_Invoice[10, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','100','" + j + "','" + DGV_Invoice[14, i].Value.ToString() + "','" + DGV_Invoice[15, i].Value.ToString() + "')");
                                    this.cntrl.Set_completed_status0(DGV_Invoice[15, i].Value.ToString());//  int completed_p = db.execute("update  tbl_completed_procedures set status='0' where id= '" + DGV_Invoice[15, i].Value.ToString() + "'");
                                }
                            }
                            DataTable invo = this.cntrl.Get_invoice_prefix();// db.table("select * from tbl_invoice_automaticid");
                            int a = int.Parse(invo.Rows[0]["invoice_number"].ToString());
                            a = a + 1;
                            this.cntrl.update_invoice_autoid(a);// db.execute("update tbl_invoice_automaticid set invoice_number='" + a + "'");
                            if (doctor_id == admin_id)
                            {
                                doctor_id = "0";
                            }
                            var form2 = new Invoice();
                            form2.doctor_id = doctor_id;
                            form2.patient_id = patient_id;
                            invoice_controller controller = new invoice_controller(form2);
                            form2.Closed += (sender1, args) => this.Close();
                            this.Hide();
                            form2.ShowDialog();
                        }
                        else
                        {
                            if (panel3.Visible == true)
                            {
                                MessageBox.Show("Please Click 'Add' Button (Below SAVE INVOICE Button).. and try again..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btn_Add.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Select a Treatment and Click on 'Add' Button...", "Data Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    DateTime? date = null;
                    DataTable dt0 = this.cntrl.Get_invoiceDate(text_billno.Text.ToString());// db.table("Select date from tbl_invoices where invoice_no='" + text_billno.Text.ToString() + "'");
                    if (dt0.Rows.Count > 0)
                    {
                        date = Convert.ToDateTime(dt0.Rows[0][0].ToString());
                    }
                    this.cntrl.delete_invoice(text_billno.Text.ToString());// db.execute("delete from tbl_invoices where invoice_no='" + text_billno.Text.ToString() + "'");
                    for (int i = 0; i < DGV_Invoice.Rows.Count; i++)
                    {
                        this.cntrl.get_taxValue(DGV_Invoice[5, i].Value.ToString());// DataTable dt = db.table("select tax_value from tbl_tax where tax_name ='" + DGV_Invoice[5, i].Value.ToString() + "'");
                        string tax = DGV_Invoice[5, i].Value.ToString();
                        string discount = DGV_Invoice[3, i].Value.ToString();
                        this.cntrl.save_incove_items(text_billno.Text.ToString(),linkL_Name.Text.ToString(),patient_id,DGV_Invoice[0, i].Value.ToString(), DGV_Invoice[2, i].Value.ToString() , DGV_Invoice[1, i].Value.ToString() ,discount,DGV_Invoice[4, i].Value.ToString() , tax ,  DGV_Invoice[6, i].Value.ToString() , date.ToString() , RTB_Notes.Text.ToString() , txt_TotalCost.Text.ToString(), txt_TotalDiscount.Text.ToString() , txt_TotalTax.Text.ToString(), txt_GrantTotal.Text.ToString(), DGV_Invoice[9, i].Value.ToString() , DGV_Invoice[7, i].Value.ToString(), DGV_Invoice[8, i].Value.ToString(),  DGV_Invoice[6, i].Value.ToString() );// db.execute("insert into tbl_invoices(invoice_no,pt_name,pt_id,services,unit,cost,discount,discount_type,tax,total,date,notes,total_cost,total_discount,total_tax,grant_total,dr_id,discountin_rs,tax_inrs,total_payment) values('" + text_billno.Text.ToString() + "','" + linkL_Name.Text.ToString() + "','" + ptid + "','" + DGV_Invoice[0, i].Value.ToString() + "','" + DGV_Invoice[2, i].Value.ToString() + "','" + DGV_Invoice[1, i].Value.ToString() + "','" + discount + "','" + DGV_Invoice[4, i].Value.ToString() + "','" + tax + "','" + DGV_Invoice[6, i].Value.ToString() + "','" + date + "','" + RTB_Notes.Text.ToString() + "','" + txt_TotalCost.Text.ToString() + "','" + txt_TotalDiscount.Text.ToString() + "','" + txt_TotalTax.Text.ToString() + "','" + txt_GrantTotal.Text.ToString() + "','" + DGV_Invoice[9, i].Value.ToString() + "','" + DGV_Invoice[7, i].Value.ToString() + "','" + DGV_Invoice[8, i].Value.ToString() + "','" + DGV_Invoice[6, i].Value.ToString() + "')");
                        if (DGV_Invoice[11, i].Value.ToString() != "0")
                        {
                            this.cntrl.Set_completed_status0(DGV_Invoice[11, i].Value.ToString());// int plan_p = db.execute("update  tbl_completed_procedures set status='0' where id= '" + DGV_Invoice[11, i].Value.ToString() + "'");
                        }
                        
                    }
                    btn_SaveInvoice.Text = "SAVE";
                    var form2 = new Invoice();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    invoice_controller controller = new invoice_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            catch (Exception ex)
            {

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
                DataTable dt = this.cntrl.select_taxValue(Cmb_tax.SelectedValue.ToString());// db.table("select tax_value from tbl_tax where id ='" + Cmb_tax.SelectedValue.ToString() + "'");
                if (dt.Rows.Count > 0)
                {
                    P_tax = Convert.ToDecimal(dt.Rows[0][0].ToString());
                }
                else
                {
                    P_tax = 0;
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controllr = new Communication_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            Reports_controller controller = new Reports_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                doctor_controller controlr = new doctor_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void TTP_SearchText_Click(object sender, EventArgs e)
        {
            TTP_SearchText.Clear();
        }

        private void TTP_SearchText_TextChanged(object sender, EventArgs e)
        {
            if (TTP_SearchText.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(TTP_SearchText.Text);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 352, 39);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
               var form2 = new patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            profile_details_controller controller = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new PracticeDetails();
                    form2.doctor_id = doctor_id;
                    Practice_Controller controller = new Practice_Controller(form2);
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
                var form2 = new PracticeDetails();
                form2.doctor_id = doctor_id;
                Practice_Controller controller = new Practice_Controller(form2);
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
                    var form2 = new AddNewPatients();
                    form2.doctor_id = doctor_id;
                    AddNew_patient_controller controller = new AddNew_patient_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new AddNewPatients();
                form2.doctor_id = doctor_id;
                AddNew_patient_controller controller = new AddNew_patient_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void linkL_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btn_MainCancel_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            invoice_controller controller = new invoice_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}