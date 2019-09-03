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
using PappyjoeMVC.Model;

namespace PappyjoeMVC.View
{
    public partial class Add_Finished_Procedure : Form,addfinsed_treatment_interface
    {
        public string doctor_id = "";
        public string patient_id = "";
        public string treatment_plan = "";
        string Patient_mobile = "9999999999";
        Decimal discounttotal = 0;
        public string[] tooth = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public string id;
        public string plan_p_id = "0";
        Addfinsed_Treatment_controller cntrl;
        //common_model cmodel = new common_model();
        public void SetController(Addfinsed_Treatment_controller controller)
        {
            cntrl = controller;
        }
        public Add_Finished_Procedure()
        {
            InitializeComponent();
        }

        private void AddFinishedprocedure_Load(object sender, EventArgs e)
        {
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            DataTable clinicname =  this.cntrl.Get_CompanyNAme();
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0]["name"].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
            string docnam = this.cntrl.Get_DoctorName(doctor_id);
            if (docnam!="")
            {
                toolStripTextDoctor.Text = "Logged In As : " + docnam;
            }
            DataTable dt = this.cntrl.get_all_doctorname();
            Cmb_Doctor.DataSource = dt;
             Cmb_Doctor.DisplayMember = "doctor_name";
            Cmb_Doctor.ValueMember = "id";
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
            lab_teethValues.Text = "";
            txt_Discount.Visible = false;
            Cmb_Discount.Hide();
            proceduretreatgrid1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            proceduretreatgrid1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            proceduretreatgrid1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            proceduretreatgrid1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            proceduretreatgrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.cntrl.Load_finishedtreatments(patient_id);
            this.cntrl.load_proceduresgrid();
            if (treatment_plan != "")
            {
                string value = treatment_plan;
                string[] parts = value.Split(new string[] { "," }, StringSplitOptions.None);
                for (int i = 0; i < parts.Length; i++)
                {
                    this.cntrl.Load_treatmentPlans(parts[i]);
                }
                Decimal totalcost = 0;
                Decimal totaldiscount = 0;
                Decimal totalgrand = 0;
                for (int i = 0; i < proceduretreatgrid1.Rows.Count; i++)
                {
                    totalcost = totalcost + (Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[2].Value.ToString()));
                    totaldiscount = totaldiscount + Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[7].Value.ToString());
                    totalgrand = totalgrand + Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[6].Value.ToString());
                }
                lab_TCostINR.Text = String.Format("{0:C0}", totalcost);
                Lab_DiscountTotalINR.Text = String.Format("{0:C0}", totaldiscount);
                lab_GTotalINR.Text = String.Format("{0:C0}", totalgrand);
            }
            System.Data.DataTable rs_patients = this.cntrl.Get_Patient_Details(patient_id);
            if (rs_patients.Rows.Count > 0)
            {
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                if (rs_patients.Rows[0]["primary_mobile_number"].ToString() != "")
                {
                    Patient_mobile = rs_patients.Rows[0]["pt_id"].ToString();
                }
            }
            foreach (DataGridViewColumn column in proceduretreatgrid1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in proceduretreatgrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btn_ShowAddProcedure_Click(object sender, EventArgs e)
        {
            label15.Show();
            label19.Show();
            txtProcedure.Show();
            txtcost.Show();
            saveadd.Show();
            btn_ProcedureClose.Show();
            btn_ShowAddProcedure.Hide();
        }
        public void Load_finishedtreatments(DataTable dt_tp)
        {
            if(dt_tp.Rows.Count>0)
            {
                for (int j = 0; j < dt_tp.Rows.Count; j++)
                {
                    proceduretreatgrid.Rows.Add(dt_tp.Rows[j]["procedure_id"].ToString(), dt_tp.Rows[j]["procedure_name"].ToString() + "        (Planned)", Convert.ToDecimal(dt_tp.Rows[j]["cost"].ToString()).ToString("##.##"), dt_tp.Rows[j]["id"].ToString());
                    proceduretreatgrid.Rows[j].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    proceduretreatgrid.Rows[j].Cells[1].Style.ForeColor = Color.DarkGreen;
                    proceduretreatgrid.Rows[j].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                    proceduretreatgrid.Rows[j].Cells[2].Style.ForeColor = Color.DarkGreen;
                    proceduretreatgrid.Rows[j].Height = 20;
                }
            }
        }
        public void load_proceduresgrid(DataTable dt_pt)
        {
            if(dt_pt.Rows.Count>0)
            {
                if (dt_pt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt_pt.Rows.Count; j++)
                    {
                        proceduretreatgrid.Rows.Add(dt_pt.Rows[j]["id"].ToString(), dt_pt.Rows[j]["name"].ToString(), Convert.ToDecimal(dt_pt.Rows[j]["cost"].ToString()).ToString("##.##"), "0");
                    }
                }
            }
        }
        public void Load_TreatmentPlans(DataTable rs_plan)
        {
            if (rs_plan.Rows.Count > 0)
            {
                  proceduretreatgrid1.Rows.Add(rs_plan.Rows[0]["procedure_id"].ToString(), rs_plan.Rows[0]["procedure_name"].ToString(), rs_plan.Rows[0]["quantity"].ToString(), rs_plan.Rows[0]["cost"].ToString(), rs_plan.Rows[0]["discount"].ToString(), rs_plan.Rows[0]["discount_type"].ToString(), rs_plan.Rows[0]["total"].ToString(), rs_plan.Rows[0]["discount_inrs"].ToString(), "", rs_plan.Rows[0]["dr_id"].ToString(), "discount", rs_plan.Rows[0]["note"].ToString(), "DEL", rs_plan.Rows[0]["tooth"].ToString(), rs_plan.Rows[0]["id"].ToString(), rs_plan.Rows[0]["date"].ToString());
            }
            panel2.Show();
            Cmb_Doctor.SelectedValue = Convert.ToInt32(rs_plan.Rows[0]["dr_id"].ToString());
        }

        private void saveadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProcedure.Text != "" && txtcost.Text != "")
                {
                    proceduretreatgrid.RowCount = 0;
                    this.cntrl.save_procedure_plans();
                    string p = this.cntrl.Get_max_procedureid();
                    int pid = int.Parse(p);
                    txtProcedure.Text = "";
                    txtcost.Text = "";
                    this.cntrl.Load_finishedtreatments(patient_id);
                    this.cntrl.load_proceduresgrid();
                }
                else
                {
                    MessageBox.Show("Please Enter the Procedure Cost", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Procedure
        {
            get { return txtProcedure.Text; }
            set { txtProcedure.Text = value; }
        }
        public decimal Procedure_cost
        {
            get { return Convert.ToDecimal(txtcost.Text); }
            set { txtcost.Text = value.ToString(); }
        }

        private void btn_ProcedureClose_Click(object sender, EventArgs e)
        {
            label15.Hide();
            label19.Hide();
            txtProcedure.Hide();
            txtcost.Hide();
            saveadd.Hide();
            btn_ProcedureClose.Hide();
            btn_ShowAddProcedure.Show();
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
        }

        private void txt_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {    
                proceduretreatgrid.Rows.Clear();
                DataTable dtb = new DataTable();
                this.cntrl.Search_procedure();
                this.cntrl.Load_finishedtreatments(patient_id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Search
        {
            get { return txt_Search.Text; }
            set { txt_Search.Text = value; }
        }

        private void proceduretreatgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                panl_TeethImages.Hide();
                if (e.RowIndex >= 0)
                {
                    int r = e.RowIndex;
                    id = proceduretreatgrid.Rows[r].Cells["ColId"].Value.ToString();
                    plan_p_id = proceduretreatgrid.Rows[r].Cells["planid"].Value.ToString();
                    int idd = Int32.Parse(id);
                    panel2.Show();
                    Panl_Serviceadd.Show();
                    DataTable dt = this.cntrl.get_procedure_Name(id);
                    if (dt.Rows.Count > 0)
                    {
                        servicetext.Text = dt.Rows[0]["name"].ToString();
                        txt_qty.Text = "1";
                        txt_Discount.Text = "0";
                        Cmb_Discount.Text = "INR";
                        RTB_Addnotes.Text = "";
                        RTB_Addnotes.Width = 450;
                        txt_Cost.Text = dt.Rows[0]["cost"].ToString();
                        Lab_ToatlValue.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt.Rows[0][1].ToString()), 2, MidpointRounding.AwayFromZero));
                    }
                    lab_teethValues.Text = "";
                    lab_teeth.Text = "Teeth";
                    DataTable dt_treatment = this.cntrl.Get_treatment_details(plan_p_id);
                    if (dt_treatment.Rows.Count > 0)
                    {
                        servicetext.Text = dt_treatment.Rows[0]["procedure_name"].ToString();
                        txt_qty.Text = dt_treatment.Rows[0]["quantity"].ToString();
                        txt_Discount.Text = dt_treatment.Rows[0]["discount"].ToString();
                        Cmb_Discount.Text = dt_treatment.Rows[0]["discount_type"].ToString();
                        RTB_Addnotes.Text = dt_treatment.Rows[0]["note"].ToString();
                        RTB_Addnotes.Width = 450;
                        txt_Cost.Text = dt_treatment.Rows[0]["cost"].ToString();
                        Lab_ToatlValue.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt_treatment.Rows[0]["total"].ToString()), 2, MidpointRounding.AwayFromZero));
                        lab_teethValues.Text = dt_treatment.Rows[0]["tooth"].ToString(); 
                    }
                    Chk_MultiplyCost.Checked = false;
                    Chk_FullMouth.Checked = false;
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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            calculation();
        }
        public void calculation()
        {
            try
            {
                decimal qty = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (txt_qty.Text != "")
                {
                    qty = Convert.ToDecimal(txt_qty.Text);
                }
                if (txt_Cost.Text != "")
                {
                    cost = Convert.ToDecimal(txt_Cost.Text);
                }
                if (txt_Discount.Text != "")
                {
                    if (Cmb_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(txt_Discount.Text);
                    }
                    else
                    {
                        discount = ((qty * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                    }
                }
                discounttotal = discount;
                Lab_ToatlValue.Text = Convert.ToString((qty * cost) - discount);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txt_Cost_TextChanged(object sender, EventArgs e)
        {
            calculation();
        }

        private void lab_addDiscount_Click(object sender, EventArgs e)
        {
            lab_addDiscount.Visible = false;
            txt_Discount.Visible = true;
            Cmb_Discount.Show();
        }

        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (txt_qty.Text != "")
                {
                    qty = Convert.ToDecimal(txt_qty.Text);
                }
                if (txt_Cost.Text != "")
                {
                    cost = Convert.ToDecimal(txt_Cost.Text);
                }
                if (txt_Discount.Text != "")
                {
                    if (Cmb_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(txt_Discount.Text);
                    }
                    else
                    {
                        discount = ((qty * cost) * Convert.ToDecimal(txt_Discount.Text)) / 100;
                    }
                }
                discounttotal = discount;
                Lab_ToatlValue.Text = Convert.ToString((qty * cost) - discount);
                decimal dis1 = Convert.ToDecimal(txt_Cost.Text);
                decimal dis2 = discounttotal;
                if (dis1 < dis2)
                {
                    MessageBox.Show("Discount Cost is greater than Actual Cost", "Grater Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_Discount.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cmb_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculation();
        }

        private void Btn_Addservices_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_qty.Text == "" || txt_Cost.Text == "")
                {
                    MessageBox.Show("Please enter the Quantity and Cost", "No Data To add !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int check_planid = 0;
                    if (plan_p_id != "0")
                    {
                        for (int i = 0; i < proceduretreatgrid1.Rows.Count; i++)
                        {
                            if (plan_p_id == proceduretreatgrid1.Rows[i].Cells[14].Value.ToString())
                            {
                                check_planid = check_planid + 1;
                            }
                        }
                    }
                    if (check_planid == 0)
                    {
                        string dr_id = Cmb_Doctor.SelectedValue.ToString();
                        Decimal dis = 0;
                        if (txt_Discount.Text == "")
                        {
                            dis = 0;
                        }
                        else
                        {
                            dis = Convert.ToDecimal(txt_Discount.Text);
                        }
                        proceduretreatgrid1.Rows.Add(id, servicetext.Text, txt_qty.Text, txt_Cost.Text, dis, Cmb_Discount.Text, Lab_ToatlValue.Text, discounttotal, "", dr_id, Cmb_Discount.Text, RTB_Addnotes.Text, "DEL", lab_teethValues.Text, plan_p_id, DTP_Date.Value.ToString("MM/dd/yyyy"));
                        Decimal totalcost = 0;
                        Decimal totaldiscount = 0;
                        Decimal totalgrand = 0;
                        for (int i = 0; i < proceduretreatgrid1.Rows.Count; i++)
                        {
                            totalcost = totalcost + (Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[2].Value.ToString()));
                            totaldiscount = totaldiscount + Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[7].Value.ToString());
                            totalgrand = totalgrand + Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[6].Value.ToString());
                        }
                        lab_TCostINR.Text = String.Format("{0:C0}", totalcost);
                        Lab_DiscountTotalINR.Text = String.Format("{0:C0}", totaldiscount);
                        lab_GTotalINR.Text = String.Format("{0:C0}", totalgrand);
                        panl_TeethImages.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("This treatment plan already exist. Please select another treatment and try again...", "Treatment plan exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lab_teeth_Click(object sender, EventArgs e)
        {
            panl_TeethImages.Visible = true;
            panel4.Visible = false;
        }

        private void Chk_MultiplyCost_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_MultiplyCost.Checked == true)
            {
                if (txt_qty.Text != "")
                {
                    decimal q = Convert.ToDecimal(txt_qty.Text.ToString());
                    txt_qty.Text = Convert.ToString(q);
                }
            }
        }

        private void Chk_FullMouth_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_FullMouth.Checked)
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
                lab_teethValues.Text = "Full Mouth";
            }
            else
            {

                lab_teethValues.Text = "";
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
            }
        }

        private void chk18_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk18.Checked) { tooth[0] = "18"; } else { tooth[0] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk17_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk17.Checked) { tooth[1] = "17"; } else { tooth[1] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk15_CheckStateChanged(object sender, EventArgs e)
        {
             if (chk15.Checked) { tooth[3] = "15"; } else { tooth[3] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk16_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk16.Checked) { tooth[2] = "16"; } else { tooth[2] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk14_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk14.Checked) { tooth[4] = "14"; } else { tooth[4] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk13_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk13.Checked) { tooth[5] = "13"; } else { tooth[5] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk12_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk12.Checked) { tooth[6] = "12"; } else { tooth[6] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk11_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk11.Checked) { tooth[7] = "11"; } else { tooth[7] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk21_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk21.Checked) { tooth[8] = "21"; } else { tooth[8] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk22_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk22.Checked) { tooth[9] = "22"; } else { tooth[9] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk23_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk23.Checked) { tooth[10] = "23"; } else { tooth[10] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk24_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk24.Checked) { tooth[11] = "24"; } else { tooth[11] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk25_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk25.Checked) { tooth[12] = "25"; } else { tooth[12] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk26_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk26.Checked) { tooth[13] = "26"; } else { tooth[13] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk27_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk27.Checked) { tooth[14] = "27"; } else { tooth[14] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk28_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk28.Checked) { tooth[15] = "28"; } else { tooth[15] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk48_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk48.Checked) { tooth[31] = "48"; } else { tooth[31] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk47_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk47.Checked) { tooth[30] = "47"; } else { tooth[30] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk46_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk46.Checked) { tooth[29] = "46"; } else { tooth[29] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk45_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk45.Checked) { tooth[28] = "45"; } else { tooth[28] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk44_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk44.Checked) { tooth[27] = "44"; } else { tooth[27] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk43_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk43.Checked) { tooth[26] = "43"; } else { tooth[26] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk42_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk42.Checked) { tooth[25] = "42"; } else { tooth[25] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk41_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk41.Checked) { tooth[24] = "41"; } else { tooth[24] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk31_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk31.Checked) { tooth[23] = "31"; } else { tooth[23] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk32_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk32.Checked) { tooth[22] = "32"; } else { tooth[22] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk33_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk33.Checked) { tooth[21] = "33"; } else { tooth[21] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk34_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk34.Checked) { tooth[20] = "34"; } else { tooth[20] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk35_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk35.Checked) { tooth[19] = "35"; } else { tooth[19] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk36_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk36.Checked) { tooth[18] = "36"; } else { tooth[18] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk37_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk37.Checked) { tooth[17] = "37"; } else { tooth[17] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk38_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk38.Checked) { tooth[16] = "38"; } else { tooth[16] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk55_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk55.Checked) { tooth[32] = "55"; } else { tooth[32] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk54_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk54.Checked) { tooth[33] = "54"; } else { tooth[33] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk53_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk53.Checked) { tooth[34] = "53"; } else { tooth[34] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk52_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk52.Checked) { tooth[35] = "52"; } else { tooth[35] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk51_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk51.Checked) { tooth[36] = "51"; } else { tooth[36] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk61_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk61.Checked) { tooth[37] = "61"; } else { tooth[37] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk62_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk62.Checked) { tooth[38] = "62"; } else { tooth[38] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk63_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk63.Checked) { tooth[39] = "63"; } else { tooth[39] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk64_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk64.Checked) { tooth[40] = "64"; } else { tooth[40] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk65_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk65.Checked) { tooth[41] = "65"; } else { tooth[41] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk85_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk85.Checked) { tooth[51] = "85"; } else { tooth[51] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk84_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk84.Checked) { tooth[50] = "84"; } else { tooth[50] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk83_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk83.Checked) { tooth[49] = "83"; } else { tooth[49] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk82_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk82.Checked) { tooth[48] = "82"; } else { tooth[48] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk81_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk81.Checked) { tooth[47] = "81"; } else { tooth[47] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk71_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk71.Checked) { tooth[46] = "71"; } else { tooth[46] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk72_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk72.Checked) { tooth[45] = "72"; } else { tooth[45] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk73_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk73.Checked) { tooth[44] = "73"; } else { tooth[44] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk74_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk74.Checked) { tooth[43] = "74"; } else { tooth[43] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void chk75_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk75.Checked) { tooth[42] = "75"; } else { tooth[42] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (Chk_MultiplyCost.Checked) { txt_qty.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_teethValues.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_teethValues.Text = ""; }
        }

        private void lab_AddNotes_Click(object sender, EventArgs e)
        {
            RTB_Addnotes.Visible = true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            lab_teethValues.Text = "";
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
            panl_TeethImages.Hide();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            panl_TeethImages.Hide();
        }

        private void proceduretreatgrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12 && e.RowIndex > -1)
                {
                    if (MessageBox.Show("Delete this Treatment.. Confirm?", "Remove Treatment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int r = e.RowIndex;
                        this.proceduretreatgrid1.Rows.RemoveAt(e.RowIndex);
                        Decimal totalcost = 0;
                        Decimal totaldiscount = 0;
                        Decimal totalgrand = 0;
                        for (int i = 0; i < proceduretreatgrid1.Rows.Count; i++)
                        {
                            totalcost = totalcost + (Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[2].Value.ToString()));
                            totaldiscount = totaldiscount + Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[7].Value.ToString());
                            totalgrand = totalgrand + Convert.ToDecimal(proceduretreatgrid1.Rows[i].Cells[6].Value.ToString());
                        }
                        lab_TCostINR.Text = String.Format("{0:C0}", totalcost);
                        Lab_DiscountTotalINR.Text = String.Format("{0:C0}", totaldiscount);
                        lab_GTotalINR.Text = String.Format("{0:C0}", totalgrand);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void savebut_Click(object sender, EventArgs e)
        {
            try
            {
                int j_Review = 1;
                if (proceduretreatgrid1.Rows.Count > 0)
                {
                    for (int ii = 0; ii < proceduretreatgrid1.Rows.Count; ii++)
                    {
                        int j = 1;
                        DataTable dt_pt = this.cntrl.get_completed_id(patient_id, DTP_Date.Value.ToString("yyyy-MM-dd"));
                        if (dt_pt.Rows.Count == 0)
                        {
                            this.cntrl.save_completed_id(Convert.ToDateTime(proceduretreatgrid1[15, ii].Value.ToString()).ToString("yyyy-MM-dd"), patient_id);
                            DataTable dt = this.cntrl.get_completedMaxid();
                            int completed_id;
                            try
                            {
                                if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
                                {
                                    j = 1;
                                    completed_id = 0;
                                }
                                else
                                {
                                    completed_id = Int32.Parse(dt.Rows[0][0].ToString());
                                }
                            }
                            catch
                            {
                                j = 1;
                                completed_id = 0;
                            }

                            j = completed_id;

                        }
                        else
                        {
                            j = Int32.Parse(dt_pt.Rows[0][0].ToString());
                        }
                        j_Review = j;
                        this.cntrl.save_completed_items(j, patient_id, proceduretreatgrid1[0, ii].Value.ToString(),proceduretreatgrid1[1, ii].Value.ToString() ,proceduretreatgrid1[2, ii].Value.ToString(),proceduretreatgrid1[3, ii].Value.ToString(),proceduretreatgrid1[5, ii].Value.ToString(),proceduretreatgrid1[4, ii].Value.ToString() ,proceduretreatgrid1[6, ii].Value.ToString(),proceduretreatgrid1[7, ii].Value.ToString() ,proceduretreatgrid1[11, ii].Value.ToString() , Convert.ToDateTime(proceduretreatgrid1[15, ii].Value.ToString()).ToString("yyyy-MM-dd") ,proceduretreatgrid1[9, ii].Value.ToString() , proceduretreatgrid1[14, ii].Value.ToString() , proceduretreatgrid1[13, ii].Value.ToString() );
                       this.cntrl.update_treatment_status(proceduretreatgrid1[14, ii].Value.ToString());
                    }
                    if (checkBoxReview.Checked == true)
                    {
                        this.cntrl.update_review(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), j_Review);
                        DataTable dt_review = this.cntrl.get_reviewid(patient_id, DateTime.Now.ToString("yyyy-MM-dd"), dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"));
                        if (dt_review.Rows.Count == 0)
                        {
                            this.cntrl.save_review(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), patient_id);
                            this.cntrl.save_appointment(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), patient_id ,linkLabel_Name.Text , Cmb_Doctor.SelectedValue.ToString() ,Patient_mobile, Cmb_Doctor.Text.ToString());
                        }
                    }
                    else
                    {
                        this.cntrl.update_review_No(dateTimeReview.Value.ToString("yyyy-MM-dd HH:mm"), j_Review);
                    }
                    var form2 = new Finished_Procedure();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    Finished_Procedre_controller controller = new Finished_Procedre_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please Click 'Add' Button (Below SAVE FINISHED PROCEDURES Button).. and try again..", "No Data To add !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Btn_Addservices.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Patient_Profile_Edit a = new Patient_Profile_Edit();
            a.patient_id = linkLabel_id.Text.ToString();
            Patient_Edit_controller controller = new Patient_Edit_controller(a);
            a.ShowDialog();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Patient_Profile_Edit a = new Patient_Profile_Edit();
            a.patient_id = linkLabel_id.Text.ToString();
            Patient_Edit_controller controller = new Patient_Edit_controller(a);
            a.ShowDialog();
        }

        private void btn_FormCancel_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Finished_Procedre_controller controller = new Finished_Procedre_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                System.Data.DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 317, 40);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
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
                    Add_New_patient_controller controller = new Add_New_patient_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                Add_New_patient_controller controller = new Add_New_patient_controller(form2);
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            Patients_controller controllr = new Patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
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

        private void label28_Click(object sender, EventArgs e)
        {
            if (label19.Text == "Show ChildTeeth")
            {
                panel4.Show();
                label19.Text = "Hide ChildTeeth";
                //childteethview();
            }
            else
            {
                panel4.Hide();
                label19.Text = "Show ChildTeeth";
                // childteethHide();
            }
        }

        private void chkfullch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfullch.Checked)
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
    }
}
