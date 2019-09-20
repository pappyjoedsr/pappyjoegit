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
    public partial class Add_Treatment_Plan : Form,add_treatmentplan_interface
    {
        Add_Treatmentplan_controller cntrl;
        public string doctor_id = ""; public string patient_id = "";
        string id;
        Decimal discounttotal = 0;
        public string[] tooth = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        public Add_Treatment_Plan()
        {
            InitializeComponent();
        }
        public void SetController(Add_Treatmentplan_controller controller)
        {
            cntrl = controller;
        }
        private void AddTreatmentPlan_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.Global_Variables.Version;
                DataTable clinicname = this.cntrl.Get_CompanyNAme();
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                }
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                Lab_msg.Top = 300;
                panl_TreatmentAdd.Hide();
                disclick.Visible = false;
                Cmb_Discount.Hide();
                DGV_Procedure.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DGV_Procedure.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Procedure.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Procedure.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                proceduretreatgrid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                System.Data.DataTable rs_patients = this.cntrl.Get_Patient_Details(patient_id);
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = rs_patients.Rows[0]["pt_name"].ToString();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                DataTable dt_pt = this.cntrl.Get_all_procedures();
                for (int j = 0; j < dt_pt.Rows.Count; j++)
                {
                    proceduretreatgrid.Rows.Add(dt_pt.Rows[j]["id"].ToString(), dt_pt.Rows[j]["name"].ToString(), Convert.ToDecimal(dt_pt.Rows[j]["cost"].ToString()).ToString("##.##"));
                }
                DataTable dtdr = this.cntrl.get_all_doctorname();
                Cmb_Doctor.DataSource = dtdr;
                Cmb_Doctor.DisplayMember = "doctor_name";
                Cmb_Doctor.ValueMember = "id";
                Cmb_Doctor.SelectedIndex = 0;
                if (doctor_id != "0")
                {
                    int dr_index = 0;
                    if (dtdr.Rows.Count > 0)
                    {
                        for (int j = 0; j < dtdr.Rows.Count; j++)
                        {
                            if (dtdr.Rows[j]["id"].ToString() == doctor_id)
                            {
                                dr_index = j;
                            }
                        }
                        Cmb_Doctor.SelectedIndex = dr_index;
                    }
                }
                foreach (DataGridViewColumn column in DGV_Procedure.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn column in proceduretreatgrid.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                txt_procedure.Visible = false;
                txt_Cost.Visible = false;
                addbut.Visible = true;
                btn_ProcedureClose.Visible = false;
                btn_SaveProcedure.Visible = false;
                disclick.Visible = false;
                Lab_Procedure.Hide();
                lab_Cost.Hide();
                panl_teeth.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_SaveProcedure_Click(object sender, EventArgs e)
        {
            this.cntrl.check_procedurename();
        }
        public void insertTreatment(DataTable checkdatacc)
        {
            try
            {
                if (checkdatacc.Rows.Count > 0)
                {
                    MessageBox.Show("Procedure " + txt_procedure.Text + " already exist");
                }
                else
                {
                    if (txt_Cost.Text != "" && txt_procedure.Text != "")
                    {
                        this.cntrl.save_Procedure();
                        string p = this.cntrl.Procedure_maxid();
                        int pid = int.Parse(p);
                        DataTable treatment = this.cntrl.Get_all_procedures();
                        proceduretreatgrid.DataSource = treatment;
                    }
                    else
                    {
                        MessageBox.Show("Please Enter the Procedure and Cost...", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    txt_Cost.Clear();
                    txt_procedure.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string AddProcedureName
        {
            get{ return txt_procedure.Text;}
            set { txt_procedure.Text = value; }
        }
        public string ProcedureCost
        {
            get { return txt_Cost.Text; }
            set { txt_Cost.Text = value; }
        }

        private void addbut_Click(object sender, EventArgs e)
        {
            txt_procedure.Visible = true;
            txt_Cost.Visible = true;
            addbut.Visible = false;
            btn_ProcedureClose.Visible = true;
            btn_SaveProcedure.Visible = true;
            Lab_Procedure.Show();
            lab_Cost.Show();
        }

        private void btn_ProcedureClose_Click(object sender, EventArgs e)
        {
            txt_procedure.Visible = false;
            txt_Cost.Visible = false;
            lab_Cost.Hide();
            Lab_Procedure.Hide();
            addbut.Visible = true;
            btn_ProcedureClose.Visible = false;
            btn_SaveProcedure.Visible = false;
            searchtextbox.Visible = true;
        }

        private void proceduretreatgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RTB_AddNotes.Visible = false;
            panl_teeth.Hide();
            Lab_msg.Hide();
            try
            {
                int r = e.RowIndex;
                id = proceduretreatgrid.Rows[r].Cells[0].Value.ToString();
                int idd = Int32.Parse(id);
                DataTable dt = this.cntrl.get_ProcedureTreatment(id);
                servicetext.Text = dt.Rows[0][0].ToString();
                qty1.Text = "1";
                Cmb_Discount.Text = "INR";
                disclick.Text = "";
                RTB_AddNotes.Text = "";
                RTB_AddNotes.Width = 500;
                costtextbox.Text = dt.Rows[0][1].ToString();
                tottext.Text = Convert.ToString(decimal.Round(Convert.ToDecimal(dt.Rows[0][1].ToString()), 2, MidpointRounding.AwayFromZero));
                lab_SelectedTeeth.Text = "";
                lab_teeth.Text = "Teeth";
                checkBox1.Checked = false;
                chk_fullmouth.Checked = false;

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
                panl_TreatmentAdd.Show();
            }
            catch
            {
            }
        }

        private void qty1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void qty1_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }
        public void Calculations()
        {
            try
            {
                decimal qty = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (qty1.Text != "")
                {
                    qty = Convert.ToDecimal(qty1.Text);
                }
                if (costtextbox.Text != "")
                {
                    cost = Convert.ToDecimal(costtextbox.Text);
                }
                if (disclick.Text != "")
                {
                    if (Cmb_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(disclick.Text);
                    }
                    else
                    {
                        discount = ((qty * cost) * Convert.ToDecimal(disclick.Text)) / 100;
                    }
                }
                discounttotal = discount;
                tottext.Text = Convert.ToString((qty * cost) - discount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not a valid number. Please try again.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void costtextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void costtextbox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(costtextbox.Text);
                int b = Convert.ToInt32(qty1.Text);
                int c = a * b;
                cqgrant.Text = c.ToString();
                totgrant.Text = c.ToString();
                tottext.Text = c.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void costtextbox_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void dislabel_Click(object sender, EventArgs e)
        {
            dislabel.Visible = false;
            disclick.Visible = true;
            Cmb_Discount.Show();
        }

        private void disclick_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal qty = 0;
                decimal cost = 0;
                decimal discount = 0;
                if (qty1.Text != "")
                {
                    qty = Convert.ToDecimal(qty1.Text);
                }
                if (costtextbox.Text != "")
                {
                    cost = Convert.ToDecimal(costtextbox.Text);
                }
                if (disclick.Text != "")
                {
                    if (Cmb_Discount.Text == "INR")
                    {
                        discount = Convert.ToDecimal(disclick.Text);
                    }
                    else
                    {
                        discount = ((qty * cost) * Convert.ToDecimal(disclick.Text)) / 100;
                    }
                }
                discounttotal = discount;
                tottext.Text = Convert.ToString((qty * cost) - discount);
                decimal dis1 = Convert.ToDecimal(qty * cost);
                decimal dis2 = discounttotal;
                if (dis1 < dis2)
                {
                    MessageBox.Show("Discount Cost is greater than Actual Cost");
                    disclick.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not a valid number. Please try again.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cmb_Discount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void btn_TreatmentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (qty1.Text == "" || servicetext.Text=="")
                {
                    MessageBox.Show("Fill the Mandatory field(s)...", "Empty field(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Decimal dis = 0;
                    if (disclick.Text == "")
                    {
                        dis = 0;
                    }
                    else
                    {
                        dis = Convert.ToDecimal(disclick.Text);
                    }
                    DGV_Procedure.Rows.Add(id, servicetext.Text, qty1.Text, costtextbox.Text, dis, Cmb_Discount.Text, tottext.Text, discounttotal, "", "dt.Rows[0][0].ToString()", Cmb_Doctor.Text, RTB_AddNotes.Text, "DEL", lab_SelectedTeeth.Text);
                    Decimal totalcost = 0;
                    Decimal totaldiscount = 0;
                    Decimal totalgrand = 0;
                    for (int i = 0; i < DGV_Procedure.Rows.Count; i++)
                    {
                        totalcost = totalcost + (Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[2].Value.ToString()));
                        totaldiscount = totaldiscount + Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[7].Value.ToString());
                        totalgrand = totalgrand + Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[6].Value.ToString());
                    }
                    cqgrant.Text = String.Format("{0:C0}", totalcost);
                    text_discounttotal.Text = String.Format("{0:C0}", totaldiscount);
                    totgrant.Text = String.Format("{0:C0}", totalgrand);
                    panl_teeth.Visible = false;
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clear()
        {
            servicetext.Text = "";
            qty1.Text = "";
            costtextbox.Text = "";
            disclick.Text = "";
            Cmb_Discount.Text = "";
            tottext.Text = "";
            Cmb_Doctor.Text = "";
            RTB_AddNotes.Text = "";
            lab_SelectedTeeth.Text = "";
        }

        private void lab_AddNotes_Click(object sender, EventArgs e)
        {
            RTB_AddNotes.Visible = true;
        }

        private void lab_teeth_Click(object sender, EventArgs e)
        {
            panl_teeth.Visible = true;
            panel4.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                decimal q = Convert.ToDecimal(qty1.Text.ToString());
                qty1.Text = Convert.ToString(q);

                int qty = 0;
                for (int i = 0; i < 51; i++)
                { if (tooth[i] != "") { qty++; } }
                if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            }
            else
            {
                qty1.Text = "1";
            }
        }

        private void chk_fullmouth_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_fullmouth.Checked)
            {
                chk11.Checked = true;
                chk12.Checked = true;
                chk13.Checked = true;
                chk14.Checked = true;
                chk15.Checked = true;
                chk16.Checked = true;
                chk17.Checked = true;
                chk18.Checked = true;
                chk21.Checked = true;
                chk22.Checked = true;
                chk23.Checked = true;
                chk24.Checked = true;
                chk25.Checked = true;
                chk26.Checked = true;
                chk27.Checked = true;
                chk28.Checked = true;
                chk31.Checked = true;
                chk32.Checked = true;
                chk33.Checked = true;
                chk34.Checked = true;
                chk35.Checked = true;
                chk36.Checked = true;
                chk37.Checked = true;
                chk38.Checked = true;
                chk41.Checked = true;
                chk42.Checked = true;
                chk43.Checked = true;
                chk44.Checked = true;
                chk45.Checked = true;
                chk46.Checked = true;
                chk47.Checked = true;
                chk48.Checked = true;
                lab_SelectedTeeth.Text = "Full Mouth";
            }
            else
            {

                lab_SelectedTeeth.Text = "";
                check_checkbox();
            }
        }

        private void chk18_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk18.Checked) { tooth[0] = "18"; } else { tooth[0] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk17_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk17.Checked) { tooth[1] = "17"; } else { tooth[1] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk16_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk16.Checked)
            {
                tooth[2] = "16";
            }
            else
            {
                tooth[2] = "";
            }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            {
                if (tooth[i] != "")
                {
                    toothno = toothno + '|' + tooth[i]; qty++;
                }
            }
            if (checkBox1.Checked)
            {
                qty1.Text = qty.ToString();
            }
            if (toothno.Length > 2)
            {
                lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1);
            }
            else
            {
                lab_SelectedTeeth.Text = "";
            }
        }

        private void chk15_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk15.Checked) { tooth[3] = "15"; } else { tooth[3] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk14_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk14.Checked) { tooth[4] = "14"; } else { tooth[4] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk13_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk13.Checked) { tooth[5] = "13"; } else { tooth[5] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk12_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk12.Checked) { tooth[6] = "12"; } else { tooth[6] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk11_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk11.Checked) { tooth[7] = "11"; } else { tooth[7] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk21_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk21.Checked) { tooth[8] = "21"; } else { tooth[8] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk22_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk22.Checked) { tooth[9] = "22"; } else { tooth[9] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk23_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk23.Checked) { tooth[10] = "23"; } else { tooth[10] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk24_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk24.Checked) { tooth[11] = "24"; } else { tooth[11] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk25_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk25.Checked) { tooth[12] = "25"; } else { tooth[12] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk26_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk26.Checked) { tooth[13] = "26"; } else { tooth[13] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk27_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk27.Checked) { tooth[14] = "27"; } else { tooth[14] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk28_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk28.Checked) { tooth[15] = "28"; } else { tooth[15] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk48_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk48.Checked) { tooth[31] = "48"; } else { tooth[31] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk47_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk47.Checked) { tooth[30] = "47"; } else { tooth[30] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk46_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk46.Checked) { tooth[29] = "46"; } else { tooth[29] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk45_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk45.Checked) { tooth[28] = "45"; } else { tooth[28] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk44_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk44.Checked) { tooth[27] = "44"; } else { tooth[27] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk43_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk43.Checked) { tooth[26] = "43"; } else { tooth[26] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk42_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk42.Checked) { tooth[25] = "42"; } else { tooth[25] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk41_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk41.Checked) { tooth[24] = "41"; } else { tooth[24] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk31_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk31.Checked) { tooth[23] = "31"; } else { tooth[23] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk32_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk32.Checked) { tooth[22] = "32"; } else { tooth[22] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk33_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk33.Checked) { tooth[21] = "33"; } else { tooth[21] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk34_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk34.Checked) { tooth[20] = "34"; } else { tooth[20] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk35_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk35.Checked) { tooth[19] = "35"; } else { tooth[19] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk36_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk36.Checked) { tooth[18] = "36"; } else { tooth[18] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk37_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk37.Checked) { tooth[17] = "37"; } else { tooth[17] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk38_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk38.Checked) { tooth[16] = "38"; } else { tooth[16] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk55_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk55.Checked) { tooth[32] = "55"; } else { tooth[32] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk54_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk54.Checked) { tooth[33] = "54"; } else { tooth[33] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk53_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk53.Checked) { tooth[34] = "53"; } else { tooth[34] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk52_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk52.Checked) { tooth[35] = "52"; } else { tooth[35] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk51_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk51.Checked) { tooth[36] = "51"; } else { tooth[36] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk61_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk61.Checked) { tooth[37] = "61"; } else { tooth[37] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk62_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk62.Checked) { tooth[38] = "62"; } else { tooth[38] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk63_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk63.Checked) { tooth[39] = "63"; } else { tooth[39] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk64_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk64.Checked) { tooth[40] = "64"; } else { tooth[40] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk65_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk65.Checked) { tooth[41] = "65"; } else { tooth[41] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk85_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk85.Checked)
            {
                tooth[51] = "85";
            }
            else
            {
                tooth[51] = "";
            }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i <= 51; i++)
            {
                if (tooth[i] != "")
                {
                    toothno = toothno + '|' + tooth[i]; qty++;
                }
            }
            if (checkBox1.Checked)
            {
                qty1.Text = qty.ToString();
            }
            if (toothno.Length > 2)
            {
                lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1);
            }
            else
            {
                lab_SelectedTeeth.Text = "";
            }
        }

        private void chk84_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk84.Checked)
            {
                tooth[50] = "84";
            }
            else
            {
                tooth[50] = "";
            }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            {
                if (tooth[i] != "")
                {
                    toothno = toothno + '|' + tooth[i]; qty++;
                }
            }
            if (checkBox1.Checked)
            {
                qty1.Text = qty.ToString();
            }
            if (toothno.Length > 2)
            {
                lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1);
            }
            else
            {
                lab_SelectedTeeth.Text = "";
            }
        }

        private void chk83_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk83.Checked) { tooth[49] = "83"; } else { tooth[49] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk82_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk82.Checked) { tooth[48] = "82"; } else { tooth[48] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk81_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk81.Checked) { tooth[47] = "81"; } else { tooth[47] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk72_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk72.Checked) { tooth[45] = "72"; } else { tooth[45] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk71_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk71.Checked) { tooth[46] = "71"; } else { tooth[46] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk73_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk73.Checked) { tooth[44] = "73"; } else { tooth[44] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk74_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk74.Checked) { tooth[43] = "74"; } else { tooth[43] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void chk75_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk75.Checked) { tooth[42] = "75"; } else { tooth[42] = ""; }
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (tooth[i] != "") { toothno = toothno + '|' + tooth[i]; qty++; } }
            if (checkBox1.Checked) { qty1.Text = qty.ToString(); }
            if (toothno.Length > 2) { lab_SelectedTeeth.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { lab_SelectedTeeth.Text = ""; }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            if (label19.Text == "Show ChildTeeth")
            {
                panel4.Show();
                label19.Text = "Hide ChildTeeth";
            }
            else
            {
                panel4.Hide();
                label19.Text = "Show ChildTeeth";
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            panl_teeth.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lab_SelectedTeeth.Text = "";
            check_checkbox();
            panl_teeth.Visible = false;
        }
        public void check_checkbox()
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

        private void chkfulch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfulch.Checked)
            {
                chk51.Checked = true;
                chk52.Checked = true;
                chk53.Checked = true;
                chk54.Checked = true;
                chk55.Checked = true;
                chk61.Checked = true;
                chk62.Checked = true;
                chk63.Checked = true;
                chk64.Checked = true;
                chk65.Checked = true;
                chk71.Checked = true;
                chk72.Checked = true;
                chk73.Checked = true;
                chk74.Checked = true;
                chk75.Checked = true;
                chk81.Checked = true;
                chk82.Checked = true;
                chk83.Checked = true;
                chk84.Checked = true;
                chk85.Checked = true;
            }
            else
            {
                chk51.Checked = false;
                chk52.Checked = false;
                chk53.Checked = false;
                chk54.Checked = false;
                chk55.Checked = false;
                chk61.Checked = false;
                chk62.Checked = false;
                chk63.Checked = false;
                chk64.Checked = false;
                chk65.Checked = false;
                chk71.Checked = false;
                chk72.Checked = false;
                chk73.Checked = false;
                chk74.Checked = false;
                chk75.Checked = false;
                chk81.Checked = false;
                chk82.Checked = false;
                chk83.Checked = false;
                chk84.Checked = false;
                chk85.Checked = false;
            }
        }

        private void DGV_Procedure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12 && e.RowIndex > -1)
                {
                    if (MessageBox.Show("Delete this Treatment.. Confirm?", "Remove Treatment", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int r = e.RowIndex;
                        this.DGV_Procedure.Rows.RemoveAt(e.RowIndex);
                        Decimal totalcost = 0;
                        Decimal totaldiscount = 0;
                        Decimal totalgrand = 0;
                        for (int i = 0; i < DGV_Procedure.Rows.Count; i++)
                        {
                            totalcost = totalcost + (Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[2].Value.ToString()));
                            totaldiscount = totaldiscount + Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[7].Value.ToString());
                            totalgrand = totalgrand + Convert.ToDecimal(DGV_Procedure.Rows[i].Cells[6].Value.ToString());
                        }
                        cqgrant.Text = String.Format("{0:C0}", totalcost);
                        text_discounttotal.Text = String.Format("{0:C0}", totaldiscount);
                        totgrant.Text = String.Format("{0:C0}", totalgrand);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void savebut_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGV_Procedure.Rows.Count > 0)
                {
                    int j;
                    string dr_id = Cmb_Doctor.SelectedValue.ToString();
                    this.cntrl.Save_treatment(dr_id, patient_id);
                    DataTable dt = this.cntrl.get_treatmentmaxid();
                    int planid;
                    try
                    {
                        if (Int32.Parse(dt.Rows[0][0].ToString()) == 0)
                        {
                            j = 1;
                            planid = 1;
                        }
                        else
                        {
                            planid = Int32.Parse(dt.Rows[0][0].ToString());
                        }
                    }
                    catch
                    {
                        j = 1;
                        planid = 1;
                    }
                    j = planid;
                    for (int ii = 0; ii < DGV_Procedure.Rows.Count; ii++)
                    {
                        this.cntrl.Save_treatmentgrid(j, DGV_Procedure[0, ii].Value.ToString(), patient_id, DGV_Procedure[1, ii].Value.ToString(), DGV_Procedure[2, ii].Value.ToString(), DGV_Procedure[3, ii].Value.ToString(), DGV_Procedure[5, ii].Value.ToString(), DGV_Procedure[4, ii].Value.ToString(), DGV_Procedure[6, ii].Value.ToString(), DGV_Procedure[7, ii].Value.ToString(), DGV_Procedure[11, ii].Value.ToString(), DGV_Procedure[13, ii].Value.ToString());//('" + j + "','" + DGV_Procedure[0, ii].Value.ToString() + "','" + patient_id + "','" + DGV_Procedure[1, ii].Value.ToString() + "','" + DGV_Procedure[2, ii].Value.ToString() + "','" + DGV_Procedure[3, ii].Value.ToString() + "','" + DGV_Procedure[5, ii].Value.ToString() + "','" + DGV_Procedure[4, ii].Value.ToString() + "','" + DGV_Procedure[6, ii].Value.ToString() + "','" + DGV_Procedure[7, ii].Value.ToString() + "','" + DGV_Procedure[11, ii].Value.ToString() + "','1','" + DGV_Procedure[13, ii].Value.ToString() + "')");
                    }
                    var form2 = new Treatment_Plans();
                    form2.doctor_id = doctor_id;
                    form2.patient_id = patient_id;
                    Treatment_controller controller = new Treatment_controller(form2);
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Select a Treatment...., Click 'Add' Button . and try again..", "Treatment Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_TreatmentAdd.Focus();
                    timer1.Start();
                    timer1.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !.....", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Date
        {
            get { return DTP_Date.Value.ToString("yyyy-MM-dd"); }
            set { DTP_Date.Value = Convert.ToDateTime(value); }
        }
        public string Doctor
        {
            get { return Cmb_Doctor.Text; }
            set { Cmb_Doctor.Text = value; }
        }
        public string PatientName
        {
            get {return linkLabel_Name.Text; }
            set { linkLabel_Name.Text = value; }
        }
        public string TotalCost
        {
            get { return cqgrant.Text; }
            set { cqgrant.Text =  value.ToString(); }
        }
        public string TotalDiscount
        {
            get {return text_discounttotal.Text; }
            set { text_discounttotal.Text = value.ToString(); }
        }
        public string GrandTotal
        {
            get { return totgrant.Text; }
            set { totgrant.Text = value.ToString(); }
        }
        public string search_patientname
        {
            get { return toolStripTextBox1.Text; }
            set { toolStripTextBox1.Text = value.ToString(); }
        }
        private void linkLabel_Name_Click(object sender, EventArgs e)
        {
            //patient_profile_Edit a = new patient_profile_Edit();
            //a.patient_id = linkLabel_id.Text.ToString();
            //patient_edit_controller controller = new patient_edit_controller(a);
            //a.ShowDialog();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Patient_Profile_Edit a = new Patient_Profile_Edit();
            a.patient_id = linkLabel_id.Text.ToString();
            Patient_Edit_controller controller = new Patient_Edit_controller(a);
            a.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                System.Data.DataTable dtdr =this.cntrl.Patient_search(toolStripTextBox1.Text);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 352, 40);  //listpatientsearch.Location = new Point(1012, 41);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            Profile_Details_controller controller = new Profile_Details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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
                id = this.cntrl. permission_for_settings(doctor_id);
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

        private void btn_TreatmentAdd_MouseEnter(object sender, EventArgs e)
        {
            btn_TreatmentAdd.BackColor = Color.LimeGreen;
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void btnaCancel_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Treatment_controller controller = new Treatment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Patient_Profile_Edit a = new Patient_Profile_Edit();
            a.patient_id = linkLabel_id.Text.ToString();
            Patient_Edit_controller controller = new Patient_Edit_controller(a);
            a.ShowDialog();
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
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            //Reports_controller controller = new Reports_controller(form2);
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}
