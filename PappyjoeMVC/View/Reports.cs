﻿using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Reports : Form
    {
        Reports_controller cntrl = new Reports_controller();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        Cursor standardCursor;
        Cursor differentCursor;
        decimal fullTotalCost = 0, fullTotalDue = 0, fullTotaldiscount = 0, fullTotaltax = 0;
        public decimal totalcosts;
        public int discount;
        public int tax;
        public decimal amtpaid;
        public string Id;
        public string Doctor_Name;
        public string Mobile_number;
        public string Email_id;
        public string Registration_Number;
        public string Calender_color;
        public string Activate_login;
        public string Login_type;
        public decimal totalcost;
        public string invoiceamt;
        public int totaltax;
        public decimal totalinvoiceamt;
        public int totaldiscount;
        string drid = "";
        string select_dr_id = "0";
        public Reports()
        {
            InitializeComponent();
        }
        private void Reports_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton5.BackColor = Color.SkyBlue;
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                if (doctor_id != "1")
                {
                    int i = 0;
                    comborepcategory.Items.Clear();
                    string id = this.cntrl.invoice_to_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "INVOICES");
                    }
                    id = this.cntrl.reciept_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "RECEIPT");
                    }
                    id = this.cntrl.payment_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "PAYMENTS");
                    }
                    id = this.cntrl.appoint_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "APPOINTMENTS");
                    }
                    id = this.cntrl.patient_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "PATIENTS");
                    }
                    id = this.cntrl.emr_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "EMR");
                    }
                    id = this.cntrl.inventory_combo(doctor_id);
                    if (int.Parse(id) == 0)
                    {
                        comborepcategory.Items.Insert(i++, "INVENTORY");
                    }
                }
                if (comborepcategory.Items.Count != 0)
                {
                    comborepcategory.SelectedIndex = 0;
                }
                else
                {
                    comborepcategory.Enabled = false;
                }
                if (comborepcategory.Text == "")
                {
                    paneldailysummary.Hide();
                    panelappointments.Hide();
                    panelPayment.Hide();
                    Panel_inventory.Hide();
                    paneltreatments.Hide();
                    panl_Expanse.Hide();
                    panelpatients.Hide();
                }
                DataTable clinicname = this.cntrl.Get_CompanyNAme();
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0]["name"].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                }
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextBDoctor.Text = "Logged In As : " + docnam;
                }
                listpatientsearch.Hide();
                standardCursor = Cursors.Arrow;
                differentCursor = Cursors.Hand;
                Lab_Msg.Hide();
                this.Grvreports.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                Grvreports.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvreports.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvreports.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                Grvreports.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in Grvreports.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                panl_Expanse.Visible = false;
                paneltreatments.Visible = false;
                combodoctors.Items.Add("All Doctors");
                combodoctors.ValueMember = "0";
                combodoctors.DisplayMember = "All Doctors";
                DataTable dt = this.cntrl.get_all_doctorname();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        combodoctors.Items.Add(dt.Rows[i]["doctor_name"].ToString());
                        combodoctors.ValueMember = dt.Rows[i]["id"].ToString();
                        combodoctors.DisplayMember = dt.Rows[i]["doctor_name"].ToString();
                    }
                }
                combodoctors.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                    form2.Dispose();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
                form2.Dispose();
            }
        }
        private void comborepcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                panelPayment.Hide();
                panelPayment.Visible = false; fullTotalCost = 0; fullTotalDue = 0; fullTotaldiscount = 0; fullTotaltax = 0;
                Lab_TotalCost.Text = "0.00";
                Lab_AmountPaid.Text = "0.00";
                Lab_DueAftrPaymnt.Text = "0.00";
                Grvreports.Rows.Clear();
                Grvreports.ColumnCount = 0;
                Grvreports.Show();
                paneldailysummary.Visible = false;
                panelappointments.Visible = false;
                panelpatients.Visible = false;
                Panel_inventory.Visible = false;
                paneltreatments.Visible = false;
                panl_Expanse.Visible = false;
                Chk_Type.Visible = false;
                rad_Expense.Visible = false;
                rad_income.Visible = false;
                LabAmountPaid.Visible = false;
                LabDueAftrPayment.Visible = false;
                Lab_TotalCost.Visible = false;
                Lab_TotalIncome.Visible = false;
                Lab_totalExpense.Visible = false;
                Lab_DueAftrPaymnt.Visible = false;
                Lab_AmountPaid.Visible = false;
                Lab_Msg.Hide();
                lblhide.Visible = false;
                label11.Visible = false;
                combodoctors.Visible = false;
                if (comborepcategory.Text == "INVOICES")
                {
                    paneldailysummary.Location = new System.Drawing.Point(20, 30);
                    paneldailysummary.Show();
                    paneldailysummary.Height = 891;
                    combodoctors.Visible = true;
                    DataTable dt = this.cntrl.inv_main(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    Load_invoiceReport(dt);
                }
                else if (comborepcategory.Text == "RECEIPT")
                {
                    panelPayment.Location = panelappointments.Location;
                    panelPayment.Height = 891;
                    panelPayment.Location = new System.Drawing.Point(20, 30);
                    panelPayment.Show();
                    panelPayment.Visible = true;
                    Lab_AmountPaid.Visible = true;
                    Lab_DueAftrPaymnt.Visible = true;
                    LabAmountPaid.Visible = true;
                    LabAmountPaid.Text = "Amount Received:";
                    LabDueAftrPayment.Visible = true;
                    dateTimePickerepo1.Visible = true;
                    from.Visible = true;
                    dateTimePickerrepo2.Visible = true;
                    to.Visible = true;
                    combodoctors.Visible = true;
                    to.Text = "To";
                    DataTable dt = this.cntrl.reciept(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    Load_recieptReport(dt);
                }
                else if (comborepcategory.Text == "APPOINTMENTS")
                {
                    dateTimePickerepo1.Visible = true;
                    from.Visible = true;
                    dateTimePickerrepo2.Visible = true;
                    to.Visible = true;
                    combodoctors.Visible = true;
                    to.Text = "To";
                    DataTable dt = this.cntrl.appointment_invMain(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    Load_appointmentReport(dt);
                }
                else if (comborepcategory.Text == "PATIENTS")
                {
                    dateTimePickerepo1.Visible = true;
                    from.Visible = true;
                    dateTimePickerrepo2.Visible = true;
                    to.Visible = true;
                    to.Text = "To";
                    DataTable dt = this.cntrl.Patient_invMain(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    Load_patientReport(dt);
                }
                else if (comborepcategory.Text == "EMR")
                {
                    paneltreatments.Visible = true;
                    paneltreatments.Height = 891;
                    dateTimePickerepo1.Visible = true;
                    from.Visible = true;
                    dateTimePickerrepo2.Visible = true;
                    to.Visible = true;
                    to.Text = "To";
                    DataTable dt = this.cntrl.EMR_invMain(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    Load_EMRReport(dt);
                }
                else if (comborepcategory.Text == "EXPENSE")
                {
                    panl_Expanse.Location = new System.Drawing.Point(20, 30);
                    panl_Expanse.Height = 891;
                    panl_Expanse.Show();
                    dateTimePickerepo1.Visible = true;
                    from.Visible = true;
                    dateTimePickerrepo2.Visible = true;
                    to.Visible = true;
                    to.Text = "To";
                    Chk_Type.Visible = true;
                    rad_Expense.Visible = true;
                    rad_income.Visible = true;
                    Chk_Type.Location = new System.Drawing.Point(290, 24);
                    rad_Expense.Location = new System.Drawing.Point(351, 24);
                    rad_income.Location = new System.Drawing.Point(421, 24);
                    if (Chk_Type.Checked)
                    {
                        if (rad_Expense.Checked)
                        {
                            DataTable dt = this.cntrl.expence_checked(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"), "Expense");
                            Load_expenseReport(dt);
                        }
                        else if (rad_income.Checked)
                        {
                            DataTable dt = this.cntrl.expence_checked(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"), "Income");
                            Load_expenseReport(dt);
                        }
                        else
                        {
                            DataTable dt = this.cntrl.expense_income_notChecked(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                            Load_expenseReport(dt);
                        }
                    }
                    else
                    {
                        DataTable dt = this.cntrl.expense_income_notChecked(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                        Load_expenseReport(dt);
                    }
                }
                else if (comborepcategory.Text == "INVENTORY")
                {
                    Panel_inventory.Location = new System.Drawing.Point(20, 30);
                    Panel_inventory.Height = 891;
                    Panel_inventory.Show();
                    dateTimePickerepo1.Visible = true;
                    from.Visible = true;
                    dateTimePickerrepo2.Visible = true;
                    to.Visible = true;
                    to.Text = "To";
                    DataTable dt = this.cntrl.Inventory_dt_stock();
                    Load_inventoryReport(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_invoiceReport(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count > 0)
                {
                    int j = 0;
                    int jj = 1;
                    Grvreports.ColumnCount = 6;
                    Grvreports.RowHeadersVisible = true;
                    Grvreports.Columns[0].HeaderText = "PATIENT NAME";
                    Grvreports.Columns[1].HeaderText = "DOCTOR NAME";
                    Grvreports.Columns[2].HeaderText = "INVOICE NO";
                    Grvreports.Columns[3].HeaderText = "INVOICE DATE";
                    Grvreports.Columns[4].HeaderText = "TOTAL COST";
                    Grvreports.Columns[5].HeaderText = "AMOUNT DUE";
                    Grvreports.Columns[0].Width = 200;
                    Grvreports.Columns[1].Width = 180;
                    Grvreports.Columns[2].Width = 160;
                    Grvreports.Columns[3].Width = 100;
                    Grvreports.Columns[5].Width = 100;
                    Grvreports.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[4].Width = 100;
                    Grvreports.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Grvreports.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    while (j < invMain.Rows.Count)
                    {
                        string invNo, PtName, date;
                        decimal totalDue = 0, totalCost = 0, totalDiscount = 0, totalTax = 0;
                        DataTable invoice = this.cntrl.invoice(invMain.Rows[j][0].ToString());
                        if (invoice.Rows.Count > 0)
                        {
                            if (select_dr_id != "0")
                            {
                                DataTable dr_invoice = this.cntrl.dr_invoice(invoice.Rows[0]["completed_id"].ToString(), select_dr_id.ToString());
                                if (dr_invoice.Rows.Count > 0)
                                {
                                    for (int ii = 0; ii < invoice.Rows.Count; ii++)
                                    {
                                        totalCost = totalCost + decimal.Parse(invoice.Rows[ii]["Cost"].ToString());
                                        totalDue = totalDue + decimal.Parse(invoice.Rows[ii]["total"].ToString());
                                        totalDiscount = totalDiscount + decimal.Parse(invoice.Rows[ii]["discountin_rs"].ToString());
                                        totalTax = totalTax + decimal.Parse(invoice.Rows[ii]["tax_inrs"].ToString());
                                    }
                                    invNo = invoice.Rows[0]["invoice_no"].ToString();
                                    PtName = invoice.Rows[0]["pt_name"].ToString();
                                    date = DateTime.Parse(invoice.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                                    fullTotalCost = fullTotalCost + totalCost;
                                    fullTotalDue = fullTotalDue + totalDue;
                                    fullTotaldiscount = fullTotaldiscount + totalDiscount;
                                    fullTotaltax = fullTotaltax + totalTax;
                                    Grvreports.Rows.Add(PtName, invoice.Rows[0]["doctor_name"].ToString(), invNo, date, Convert.ToDecimal(((totalCost + totalTax) - totalDiscount)).ToString("#0.00"), totalDue); 
                                    jj++;
                                }
                                else
                                {
                                    string dr_found = "0";
                                    if (invMain.Rows[j]["type"].ToString() == "drug")
                                    {
                                        for (int ii = 0; ii < invoice.Rows.Count; ii++)
                                        {
                                            if (select_dr_id.ToString() == invoice.Rows[ii]["dr_id"].ToString())
                                            {
                                                totalCost = totalCost + decimal.Parse(invoice.Rows[ii]["Cost"].ToString());
                                                totalDue = totalDue + decimal.Parse(invoice.Rows[ii]["total"].ToString());
                                                totalDiscount = totalDiscount + decimal.Parse(invoice.Rows[ii]["discountin_rs"].ToString());
                                                totalTax = totalTax + decimal.Parse(invoice.Rows[ii]["tax_inrs"].ToString());
                                                dr_found = "1";
                                            }
                                        }
                                        if (dr_found == "1")
                                        {
                                            invNo = invoice.Rows[0]["invoice_no"].ToString();
                                            PtName = invoice.Rows[0]["pt_name"].ToString();
                                            date = DateTime.Parse(invoice.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                                            fullTotalCost = fullTotalCost + totalCost;
                                            fullTotalDue = fullTotalDue + totalDue; 
                                            fullTotaldiscount = fullTotaldiscount + totalDiscount;
                                            fullTotaltax = fullTotaltax + totalTax;
                                            Grvreports.Rows.Add(PtName, invoice.Rows[0]["doctor_name"].ToString(), invNo, date, Convert.ToDecimal(((totalCost + totalTax) - totalDiscount)).ToString("#0.00"), totalDue); 
                                            jj++;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                for (int ii = 0; ii < invoice.Rows.Count; ii++)
                                {
                                    totalCost = totalCost + decimal.Parse(invoice.Rows[ii]["Cost"].ToString());
                                    totalDue = totalDue + decimal.Parse(invoice.Rows[ii]["total"].ToString());
                                    totalDiscount = totalDiscount + decimal.Parse(invoice.Rows[ii]["discountin_rs"].ToString());
                                    totalTax = totalTax + decimal.Parse(invoice.Rows[ii]["tax_inrs"].ToString());
                                }
                                invNo = invoice.Rows[0]["invoice_no"].ToString();
                                PtName = invoice.Rows[0]["pt_name"].ToString();
                                date = DateTime.Parse(invoice.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                                fullTotalCost = fullTotalCost + totalCost; 
                                fullTotalDue = fullTotalDue + totalDue; 
                                fullTotaldiscount = fullTotaldiscount + totalDiscount;
                                fullTotaltax = fullTotaltax + totalTax;
                                Grvreports.Rows.Add(PtName, invoice.Rows[0]["doctor_name"].ToString(), invNo, date, Convert.ToDecimal(((totalCost + totalTax) - totalDiscount)).ToString("#0.00"), totalDue); 
                                jj++;
                            }
                        }
                        j++;
                    }
                    Grvreports.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                Lab_TotalCost.Text = Convert.ToDecimal(fullTotalCost - (fullTotaldiscount + fullTotaltax)).ToString("#0.00");
                Lab_DueAftrPaymnt.Text = Convert.ToDecimal(fullTotalDue).ToString("#0.00");
                Lab_DueAftrPaymnt.Show();
                Lab_TotalCost.Show();
                label11.Show();
                LabDueAftrPayment.Show();
                LabAmountPaid.Hide();
                Lab_AmountPaid.Hide();
                combodoctors.Show();
                foreach (DataGridViewRow dr in Grvreports.Rows)
                {
                    dr.Cells[4].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dr.Cells[4].Style.ForeColor = Color.ForestGreen;
                    dr.Cells[5].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dr.Cells[5].Style.ForeColor = Color.Red;
                    dr.Cells[0].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[1].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[2].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[5].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                    dr.Cells[4].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_recieptReport(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count > 0)
                {
                    int j = 0;
                    while (j < invMain.Rows.Count)
                    {
                        decimal totalCost = 0, totalDiscount = 0, totalTax = 0;
                        DataTable invoice = this.cntrl.reciept_invoice(invMain.Rows[j][0].ToString());
                        for (int i = 0; i < invoice.Rows.Count; i++)
                        {
                            totalCost = totalCost + decimal.Parse(invoice.Rows[i]["Cost"].ToString());
                            totalDiscount = totalDiscount + decimal.Parse(invoice.Rows[i]["discountin_rs"].ToString());
                            totalTax = totalTax + decimal.Parse(invoice.Rows[i]["Tax_inrs"].ToString());
                        }
                        fullTotalCost = fullTotalCost + (totalCost - (totalDiscount + totalTax)); 
                        j++;
                    }
                }
                DataTable dt = this.cntrl.patient_reciept(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                decimal totaltax = 0;
                decimal totaldiscount = 0;
                if (dt.Rows.Count > 0)
                {
                    Lab_Msg.Hide();
                    Grvreports.ColumnCount = 8;
                    Grvreports.Columns[0].HeaderText = "PATIENT NAME";
                    Grvreports.Columns[1].HeaderText = "DOCTOR NAME";
                    Grvreports.Columns[2].HeaderText = "RECEIPT NO";
                    Grvreports.Columns[3].HeaderText = "INVOICE NO";
                    Grvreports.Columns[4].HeaderText = "TREATMENT";
                    Grvreports.Columns[5].HeaderText = "AMOUNT RECEIVED";
                    Grvreports.Columns[6].HeaderText = "PAYMENT DATE";
                    Grvreports.Columns[7].HeaderText = "DUE AFTER PAYMENT";
                    Grvreports.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Grvreports.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Grvreports.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[0].Width = 100;
                    Grvreports.Columns[3].Width = 135;
                    Grvreports.Columns[1].Width = 100;
                    Grvreports.Columns[2].Width = 125;
                    Grvreports.Columns[4].Width = 129;
                    Grvreports.Columns[5].Width = 150;
                    Grvreports.Columns[6].Width = 120;
                    Grvreports.Columns[7].Width = 140;
                    Grvreports.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Grvreports.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Grvreports.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (select_dr_id != "0")
                    {
                        for (int g = 0; g < dt.Rows.Count; g++)
                        {
                            if (select_dr_id == dt.Rows[g]["dr_id"].ToString())
                            {
                                Grvreports.Rows.Add(dt.Rows[g]["PATIENT NAME"].ToString(), dt.Rows[g]["doctor_name"].ToString(), dt.Rows[g]["RECEIPT NO"].ToString(), dt.Rows[g]["INVOICE NO"].ToString(), dt.Rows[g]["TREATMENT"].ToString(), dt.Rows[g]["AMOUNT PAID"].ToString(), DateTime.Parse(dt.Rows[g]["PAYMENT DATE"].ToString()).ToString("dd/MM/yyyy"), dt.Rows[g]["DUE AFTER PAYMENT"].ToString());
                                decimal amount_paid = decimal.Parse(dt.Rows[g]["AMOUNT PAID"].ToString());
                                string discount = dt.Rows[g]["DUE AFTER PAYMENT"].ToString();
                                totaltax = totaltax + amount_paid;
                                totaldiscount = totaldiscount + Convert.ToDecimal(discount);
                            }
                        }
                    }
                    else
                    {
                        for (int g = 0; g < dt.Rows.Count; g++)
                        {
                            Grvreports.Rows.Add(dt.Rows[g]["PATIENT NAME"].ToString(), dt.Rows[g]["doctor_name"].ToString(), dt.Rows[g]["RECEIPT NO"].ToString(), dt.Rows[g]["INVOICE NO"].ToString(), dt.Rows[g]["TREATMENT"].ToString(), dt.Rows[g]["AMOUNT PAID"].ToString(), DateTime.Parse(dt.Rows[g]["PAYMENT DATE"].ToString()).ToString("dd/MM/yyyy"), dt.Rows[g]["DUE AFTER PAYMENT"].ToString());
                            decimal amount_paid = decimal.Parse(dt.Rows[g]["AMOUNT PAID"].ToString());
                            string discount = dt.Rows[g]["DUE AFTER PAYMENT"].ToString();
                            totaltax = totaltax + amount_paid;
                            totaldiscount = totaldiscount + Convert.ToDecimal(discount);
                        }
                    }
                    Grvreports.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                Lab_AmountPaid.Show();
                LabAmountPaid.Show();
                Lab_TotalCost.Text = Convert.ToDecimal(fullTotalCost).ToString("#0.00");
                Lab_AmountPaid.Text = Convert.ToDecimal(totaltax).ToString("#0.00"); 
                Lab_DueAftrPaymnt.Text = Convert.ToDecimal(fullTotalCost - totaltax).ToString("#0.00"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_appointmentReport(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count > 0)
                {
                    int j = 0;
                    System.Data.DataTable dt_pt = this.cntrl.Appointment_grvShow(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));

                    if (dt_pt.Rows.Count > 0)
                    {
                        Lab_Msg.Hide();
                        Grvreports.ColumnCount = 5;
                        Grvreports.Columns[0].HeaderText = "PATIENT ID";
                        Grvreports.Columns[1].HeaderText = "PATIENT NAME";
                        Grvreports.Columns[2].HeaderText = "DOCTOR NAME";
                        Grvreports.Columns[3].HeaderText = "MOBILE";
                        Grvreports.Columns[4].HeaderText = "BOOK TIME";
                        Grvreports.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[0].Width = 190;
                        Grvreports.Columns[1].Width = 250;
                        Grvreports.Columns[2].Width = 200;
                        Grvreports.Columns[3].Width = 200;
                        Grvreports.Columns[4].Width = 150;
                        if (select_dr_id != "0")
                        {
                            for (int g = 0; g < dt_pt.Rows.Count; g++)
                            {
                                if (select_dr_id == dt_pt.Rows[g]["dr_id"].ToString())
                                {
                                    Grvreports.Rows.Add(dt_pt.Rows[g]["PATIENT ID"].ToString(), dt_pt.Rows[g]["PATIENT NAME"].ToString(), dt_pt.Rows[g]["doctor_name"].ToString(), dt_pt.Rows[g]["MOBILE"].ToString(), Convert.ToDateTime(dt_pt.Rows[g]["BOOK TIME"]).ToString("dd/MM/yyyy hh:mm tt"));
                                }
                            }
                        }
                        else
                        {
                            for (int g = 0; g < dt_pt.Rows.Count; g++)
                            {
                                Grvreports.Rows.Add(dt_pt.Rows[g]["PATIENT ID"].ToString(), dt_pt.Rows[g]["PATIENT NAME"].ToString(), dt_pt.Rows[g]["doctor_name"].ToString(), dt_pt.Rows[g]["MOBILE"].ToString(), Convert.ToDateTime(dt_pt.Rows[g]["BOOK TIME"]).ToString("dd/MM/yyyy hh:mm tt"));
                            }
                        }
                        this.Grvreports.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                panelappointments.Visible = true;
                panelappointments.Location = new System.Drawing.Point(20, 30);
                panelappointments.Show();
                panelappointments.Height = 891;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_patientReport(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count > 0)
                {
                    System.Data.DataTable dt_pt = this.cntrl.Patient_grv_Show(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    if (dt_pt.Rows.Count > 0)
                    {
                        Lab_Msg.Hide();
                        Grvreports.ColumnCount = 9;
                        Grvreports.Columns[0].HeaderText = "PATIENT ID";
                        Grvreports.Columns[1].HeaderText = "PATIENT NAME";
                        Grvreports.Columns[2].HeaderText = "GENDER";
                        Grvreports.Columns[3].HeaderText = "AGE";
                        Grvreports.Columns[4].HeaderText = "MOBILE";
                        Grvreports.Columns[5].HeaderText = "DATE";
                        Grvreports.Columns[6].HeaderText = "STREET ADDRESS";
                        Grvreports.Columns[7].HeaderText = "NATIONALITY";
                        Grvreports.Columns[8].HeaderText = "PASSPORT NO";
                        Grvreports.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[0].Width = 125;
                        Grvreports.Columns[1].Width = 200;
                        Grvreports.Columns[2].Width = 85;
                        Grvreports.Columns[3].Width = 85;
                        Grvreports.Columns[4].Width = 120;
                        Grvreports.Columns[5].Width = 140;
                        Grvreports.Columns[6].Width = 198;
                        Grvreports.Columns[7].Width = 100;
                        Grvreports.Columns[8].Width = 100;
                        for (int g = 0; g < dt_pt.Rows.Count; g++)
                        {
                            Grvreports.Rows.Add(dt_pt.Rows[g]["PATIENT ID"].ToString(), dt_pt.Rows[g]["PATIENT NAME"].ToString(), dt_pt.Rows[g]["GENDER"].ToString(), dt_pt.Rows[g]["AGE"].ToString(), dt_pt.Rows[g]["MOBILE"].ToString(), Convert.ToDateTime(dt_pt.Rows[g]["DATE"]).ToString("dd/MM/yyyy"), dt_pt.Rows[g]["street_address"].ToString(), dt_pt.Rows[g]["nationality"].ToString(), dt_pt.Rows[g]["passport_no"].ToString());
                        }
                        this.Grvreports.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    else
                    {
                        int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                        Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                        Lab_Msg.Show();
                    }
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                panelpatients.Location = new System.Drawing.Point(20, 30);
                panelpatients.Height = 891;
                panelpatients.Show();
                panelpatients.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_EMRReport(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count > 0)
                {
                    System.Data.DataTable dt_pt = this.cntrl.EMR_grvShow(dateTimePickerepo1.Value.ToString("yyyy-MM-dd"), dateTimePickerrepo2.Value.ToString("yyyy-MM-dd"));
                    if (dt_pt.Rows.Count > 0)
                    {
                        Lab_Msg.Hide();
                        Grvreports.ColumnCount = 4;
                        Grvreports.Columns[0].HeaderText = "PATIENT ID";
                        Grvreports.Columns[1].HeaderText = "PATIENT NAME";
                        Grvreports.Columns[2].HeaderText = "SERVICES";
                        Grvreports.Columns[3].HeaderText = "DATE";
                        Grvreports.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        Grvreports.Columns[0].Width = 100;
                        Grvreports.Columns[2].Width = 400;
                        Grvreports.Columns[1].Width = 200;
                        Grvreports.Columns[3].Width = 140;
                        for (int g = 0; g < dt_pt.Rows.Count; g++)
                        {
                            Grvreports.Rows.Add(dt_pt.Rows[g]["PATIENT ID"].ToString(), dt_pt.Rows[g]["PATIENT NAME"].ToString(), dt_pt.Rows[g]["SERVICES"].ToString(), Convert.ToDateTime(dt_pt.Rows[g]["DATE"]).ToString("dd/MM/yyyy"));
                        }
                        this.Grvreports.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                paneltreatments.Visible = true;
                paneltreatments.Location = new System.Drawing.Point(20, 30);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_expenseReport(DataTable dt_pt)
        {
            try
            {
                decimal totalExpense = 0;
                decimal totalIncome = 0;
                decimal expense = 0;
                decimal income = 0;
                if (dt_pt.Rows.Count > 0)
                {
                    Lab_Msg.Hide();
                    Grvreports.ColumnCount = 7;
                    Grvreports.Columns[0].HeaderText = "DATE";
                    Grvreports.Columns[1].HeaderText = "TYPE";
                    Grvreports.Columns[2].HeaderText = "LEDGER";
                    Grvreports.Columns[3].HeaderText = "ACCOUNT NAME";
                    Grvreports.Columns[4].HeaderText = "DESCRIPTION";
                    Grvreports.Columns[5].HeaderText = "AMOUNT (Cr)";
                    Grvreports.Columns[6].HeaderText = "AMOUNT (Dr) ";
                    Grvreports.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    Grvreports.Columns[0].Width = 90;
                    Grvreports.Columns[1].Width = 90;
                    Grvreports.Columns[2].Width = 150;
                    Grvreports.Columns[3].Width = 300;
                    Grvreports.Columns[4].Width = 350;
                    Grvreports.Columns[5].Width = 100;
                    Grvreports.Columns[6].Width = 100;
                    for (int g = 0; g < dt_pt.Rows.Count; g++)
                    {
                        Grvreports.Rows.Add(Convert.ToDateTime(dt_pt.Rows[g]["date"]).ToString("dd/MM/yyyy"), dt_pt.Rows[g]["Type"].ToString(), dt_pt.Rows[g]["nameofperson"].ToString(), dt_pt.Rows[g]["expense_type"].ToString(), dt_pt.Rows[g]["description"].ToString(), dt_pt.Rows[g]["amount"].ToString(), dt_pt.Rows[g]["amountincome"].ToString());
                        expense = Convert.ToDecimal(dt_pt.Rows[g]["amount"].ToString());
                        totalExpense = totalExpense + expense;
                        income = Convert.ToDecimal(dt_pt.Rows[g]["amountincome"].ToString());
                        totalIncome = totalIncome + income;
                    }
                    this.Grvreports.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
                foreach (DataGridViewRow dr in Grvreports.Rows)
                {
                    dr.Cells[0].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[1].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[2].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[5].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                    dr.Cells[6].Style.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                }
                Lab_TotalIncome.Visible = true;
                Lab_totalExpense.Visible = true;
                Lab_DueAftrPaymnt.Visible = true;
                Lab_AmountPaid.Visible = true;
                Lab_AmountPaid.Text = Convert.ToDecimal(totalIncome).ToString("#0.00");
                Lab_DueAftrPaymnt.Text = Convert.ToDecimal(totalExpense).ToString("#0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_inventoryReport(DataTable dt_stock)
        {
            try
            {
                if (dt_stock.Rows.Count > 0)
                {
                    Lab_Msg.Hide();
                    Grvreports.ColumnCount = 5;
                    Grvreports.Columns[0].HeaderText = "SLNO";
                    Grvreports.Columns[1].HeaderText = "ITEM CODE";
                    Grvreports.Columns[2].HeaderText = "ITEM NAME";
                    Grvreports.Columns[3].HeaderText = "UNIT 1";
                    Grvreports.Columns[4].HeaderText = "STOCK";
                    Grvreports.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    Grvreports.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    string current_Stock = ""; int unitmf = 0; decimal qty = 0; int quotient = 0; int Remainder = 0;
                    int num = 1;
                    foreach (DataRow dr in dt_stock.Rows)
                    {
                        System.Data.DataTable dtunit = this.cntrl.inventory_gv_Show(dr["item_code"].ToString());
                        if (dtunit.Rows.Count > 0)
                        {
                            if (dtunit.Rows[0]["OneUnitOnly"].ToString() == "False")
                            {
                                unitmf = Convert.ToInt32(dtunit.Rows[0]["UnitMF"].ToString());
                                qty = Convert.ToDecimal(dr["qty"].ToString());
                                quotient = Convert.ToInt32(qty / unitmf);
                                Remainder = Convert.ToInt32(qty % unitmf);
                                current_Stock = dtunit.Rows[0]["Unit1"].ToString() + "=" + quotient + "," + dtunit.Rows[0]["Unit2"].ToString() + "=" + Remainder;
                                Grvreports.Rows.Add(num, dr["item_code"].ToString(), dr["item_name"].ToString(), dr["unit"].ToString(), current_Stock);
                            }
                            else
                            {
                                current_Stock = dtunit.Rows[0]["Unit1"].ToString() + "=" + dr["qty"].ToString();
                                Grvreports.Rows.Add(num, dr["item_code"].ToString(), dr["item_name"].ToString(), dr["unit"].ToString(), current_Stock);
                            }
                            num = num + 1;
                        }
                    }
                    this.Grvreports.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvreports.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvreports.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvreports.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.Grvreports.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    int x = (panel2.Size.Width - Lab_Msg.Size.Width) / 2;
                    Lab_Msg.Location = new Point(x, Lab_Msg.Location.Y);
                    Lab_Msg.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Show_Click(object sender, EventArgs e)
        {
            var d1 = dateTimePickerepo1.Value.ToShortDateString();
            var d2 = dateTimePickerrepo2.Value.ToShortDateString();
            if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
            {
                MessageBox.Show("From date should be less than To date", "From date is greater", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickerepo1.Value = DateTime.Today;
            }
            else
                comborepcategory_SelectedIndexChanged(sender, e);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grvreports.Rows.Count > 0)
                {
                    if (combodoctors.SelectedIndex == -1)
                    { }
                    else
                    {
                        System.Data.DataTable dt = this.cntrl.GetDoctorId_byLogintype(combodoctors.SelectedItem.ToString());
                        if (dt.Rows.Count > 0)
                        {
                            select_dr_id = dt.Rows[0]["Id"].ToString();
                        }
                    }
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    int c = 0;
                    string strclinicname = "";
                    string strStreet = "";
                    string strphone = "",logo_name="";
                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Data.DataTable dtp = this.cntrl.Get_Practice_details();
                        if (dtp.Rows.Count > 0)
                        {
                            string clinicn = "";
                            clinicn = dtp.Rows[0]["name"].ToString();
                            strclinicname = clinicn.Replace("¤", "'");
                            strphone = dtp.Rows[0]["contact_no"].ToString();
                            strStreet = dtp.Rows[0]["street_address"].ToString();
                            logo_name= dtp.Rows[0]["path"].ToString();
                        }
                    }
                    if (comborepcategory.Text == "INVOICES")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\MonthlyInvoiceReport.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body >");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        if (combodoctors.SelectedIndex == 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> MONTHLY INVOICE REPORT (All Doctors) </font></center></b></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        else if (combodoctors.SelectedIndex != 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> MONTHLY INVOICE REPORT(" + combodoctors.Text + ")  </font></center></b></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To   :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=7 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='24%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3 >&nbsp;<b>Patient Name</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b> Doctor</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3> &nbsp;<b>Invoice No</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b>  Date</b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b> Total Cost</b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b> Amount Due</b></font></td>");
                            sWrite.WriteLine("</tr>");
                            for (c = 0; c < Grvreports.Rows.Count; c++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + (c + 1) + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[0].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[1].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[2].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[3].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[4].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[5].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("</tr >");
                            }
                            string cost = "";
                            string due = "";
                            cost = Lab_TotalCost.Text;
                            due = Lab_DueAftrPaymnt.Text;
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2><b> Total</b> </font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2><b>  " + cost + "</b> </font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2> <b> " + due + "</b> </font></td>");
                            sWrite.WriteLine("</tr >");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("</div>");
                            sWrite.WriteLine("<script>window.print();</script>");
                            sWrite.WriteLine("</body>");
                            sWrite.WriteLine("</html>");
                            sWrite.Close();
                            System.Diagnostics.Process.Start(Apppath + "\\MonthlyInvoiceReport.html");
                        }
                    }
                    if (comborepcategory.Text == "RECEIPT")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\PaymentReports.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body >");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        if (combodoctors.SelectedIndex == 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PAYMENT REPORT (All Doctors) </font></center></b></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        else if (combodoctors.SelectedIndex != 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PAYMENT REPORT (" + combodoctors.Text + ")  </font></center></b></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=9 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  " + "<b>Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='5%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='13%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Patient Name</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Doctor</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b>ReceiptNo</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b> InvoiceNo</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3>&nbsp;<b> Treatment</b></font></th>");
                            sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3><b> Amount Paid</b>&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3><b>Payment Date</b>&nbsp;</font></th>");
                            sWrite.WriteLine("    <td align='right' width='13%' style='border:1px solid #000;background:#999999'><FONT COLOR=black  FACE='Segoe UI' SIZE=3><b>Due After Payment</b>&nbsp;</font></th>");
                            sWrite.WriteLine("</tr>");
                            for (c = 0; c < Grvreports.Rows.Count; c++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp;" + (c + 1) + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[0].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[1].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[2].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[3].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[4].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2> " + Grvreports.Rows[c].Cells[5].Value.ToString() + "&nbsp;</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[6].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='Right' style='border:1px solid #000' ><FONT COLOR=black  FACE='Segoe UI' SIZE=2> " + Grvreports.Rows[c].Cells[7].Value.ToString() + "&nbsp;</font></th>");
                                sWrite.WriteLine("</td>");
                            }
                            sWrite.WriteLine("</tr >");
                            string cost = "";
                            string due = "";
                            cost = Lab_AmountPaid.Text;
                            due = Lab_DueAftrPaymnt.Text;
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black  FACE='Segoe UI' SIZE=2><b> Total Payment:</b></font></td>");
                            sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black  FACE='Segoe UI' SIZE=3> " + cost + "</font></td>");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='right'  colspan=8 ><FONT COLOR=black  FACE='Segoe UI' SIZE=2><b>  Total Due :<b/></font></td>");
                            sWrite.WriteLine("<td align='right'  colspan=9 ><FONT COLOR=black  FACE='Segoe UI' SIZE=3>  " + due + " </font></td>");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("</div>");
                            sWrite.WriteLine("<script>window.print();</script>");
                            sWrite.WriteLine("</body>");
                            sWrite.WriteLine("</html>");
                            sWrite.Close();
                            System.Diagnostics.Process.Start(Apppath + "\\PaymentReports.html");
                        }
                    }
                    if (comborepcategory.Text == "APPOINTMENTS")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        StreamWriter sWrite = new StreamWriter(Apppath + "\\MonthlyAppointment.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body >");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> APPOINTMENT REPORT  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Slno.</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Patient ID</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='25%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Patient Name</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='18%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Doctor</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Mobile</b> </font></td>");
                            sWrite.WriteLine("    <td align='left' width='18%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Appoinment Date</b> </font></td>");
                            sWrite.WriteLine("</tr>");
                            for (int j = 0; j < Grvreports.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + (j + 1) + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[0].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                            }
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("</div>");
                            sWrite.WriteLine("<script>window.print();</script>");
                            sWrite.WriteLine("</body>");
                            sWrite.WriteLine("</html>");
                            sWrite.Close();
                            System.Diagnostics.Process.Start(Apppath + "\\MonthlyAppointment.html");
                        }
                    }
                    if (comborepcategory.Text == "PATIENTS")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        StreamWriter sWrite = new StreamWriter(Apppath + "\\PatientRecordsreport.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body >");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> PATIENTS RECORD  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");

                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Slno.</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Patient Id</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='29%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Patient Name</b> </font></td>");
                            sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Gender</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='4%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Age</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Mobile</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Date</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='35%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Street Address</b></font></td>");
                            sWrite.WriteLine("</tr>");
                            while (c < Grvreports.Rows.Count)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + (c + 1) + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[0].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[1].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[2].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[3].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp; " + Grvreports.Rows[c].Cells[4].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[5].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[6].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("</tr>");
                                c++;
                            }
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\PatientRecordsreport.html");
                    }
                    if (comborepcategory.Text == "EMR")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        StreamWriter sWrite = new StreamWriter(Apppath + "\\Monthlycount.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body >");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> TREATMENT REPORT </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=6 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Slno.</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Patient Id</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='35%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Patient Name</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='35%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Services</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='18%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Date</b></font></th>");
                            sWrite.WriteLine("</tr>");
                            for (int j = 0; j < Grvreports.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + (j + 1) + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[1].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[2].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[j].Cells[3].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("</tr>");
                            }
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Geneva,  Sego UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("</div>");
                            sWrite.WriteLine("<script>window.print();</script>");
                            sWrite.WriteLine("</body>");
                            sWrite.WriteLine("</html>");
                            sWrite.Close();
                            System.Diagnostics.Process.Start(Apppath + "\\Monthlycount.html");
                        }
                    }
                    if (comborepcategory.Text == "EXPENSE")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        StreamWriter sWrite = new StreamWriter(Apppath + "\\Expensecount.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body >");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> EXPENSE REPORT </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> &nbsp;<b>Slno.</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Date</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;<b>Type</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='18%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Ledger</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='14%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Account Name</b> </font></th>");
                            sWrite.WriteLine("    <td align='left' width='19%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b>Description</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount (CR)</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount (DR)</b></font></th>");
                            sWrite.WriteLine("</tr>");
                            for (int j = 0; j < Grvreports.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + (j + 1) + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Grvreports.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Grvreports.Rows[j].Cells[1].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp " + Grvreports.Rows[j].Cells[2].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Grvreports.Rows[j].Cells[3].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp" + Grvreports.Rows[j].Cells[4].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Grvreports.Rows[j].Cells[5].Value.ToString() + "&nbsp</font></th>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + Grvreports.Rows[j].Cells[6].Value.ToString() + "&nbsp</font></th>");
                                sWrite.WriteLine("</tr>");
                            }
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=3> </font></th>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=3> </font></th>");
                            sWrite.WriteLine("    <td align='center'  style='border:1px solid #000'><FONT COLOR=black FACE=' Segoe UI' SIZE=3></font></th>");
                            sWrite.WriteLine("    <td align='center'  style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=3> </font></th>");
                            sWrite.WriteLine("    <td align='center' style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=3> </font></th>");
                            sWrite.WriteLine("    <td align='right'  style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Total</b></font></th>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=2> <b>" + Lab_DueAftrPaymnt.Text + " </b></font></th>");
                            sWrite.WriteLine("    <td align='right'  style='border:1px solid #000'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_AmountPaid.Text + "</b></font></th>");
                            sWrite.WriteLine("</tr>");
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("</div>");
                            sWrite.WriteLine("<script>window.print();</script>");
                            sWrite.WriteLine("</body>");
                            sWrite.WriteLine("</html>");
                            sWrite.Close();
                            System.Diagnostics.Process.Start(Apppath + "\\Expensecount.html");
                        }
                    }
                    if (comborepcategory.Text == "INVENTORY")
                    {
                        string Apppath = System.IO.Directory.GetCurrentDirectory();
                        System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\StockReport1.html");
                        sWrite.WriteLine("<html>");
                        sWrite.WriteLine("<head>");
                        sWrite.WriteLine("<style>");
                        sWrite.WriteLine("table { border-collapse: collapse;}");
                        sWrite.WriteLine("p.big {line-height: 400%;}");
                        sWrite.WriteLine("</style>");
                        sWrite.WriteLine("</head>");
                        sWrite.WriteLine("<body>");
                        sWrite.WriteLine("<div>");
                        sWrite.WriteLine("<table align=center  width=900>");
                        sWrite.WriteLine("<col>");
                        sWrite.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite.WriteLine("</table>");
                        }
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> STOCK REPORT </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=5 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "From :</b>" + " " + dateTimePickerepo1.Value.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=5 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "To :</b>" + "   " + dateTimePickerrepo2.Value.ToString("dd/MM/yyyy") + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=5 align=left><FONT COLOR=black FACE='Segoe UI' SIZE=2>  <b>" + "Printed Date:</b>" + "" + DateTime.Now.ToString("dd/MM/yyyy") + " </font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (Grvreports.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Sl.No</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='12%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Item Code</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='41%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Item name</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Purchase Unit</b></font></th>");
                            sWrite.WriteLine("    <td align='left' width='22%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Stock</b></font></th>");
                            sWrite.WriteLine("</tr>");
                            for (c = 0; c < Grvreports.Rows.Count; c++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI'SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[0].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[1].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[2].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[3].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvreports.Rows[c].Cells[4].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("</tr >");
                            }
                            sWrite.WriteLine("</table>");
                            sWrite.WriteLine("</div>");
                            sWrite.WriteLine("<script>window.print();</script>");
                            sWrite.WriteLine("</body>");
                            sWrite.WriteLine("</html>");
                            sWrite.Close();
                            System.Diagnostics.Process.Start(Apppath + "\\StockReport1.html");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Record Found, Please change the date and try again !..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                string PathName = "";
                if (Grvreports.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xml)|*.xml";
                    saveFileDialog1.FileName = "" + comborepcategory.Text + "(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xml";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        int count = Grvreports.Columns.Count;
                        ExcelApp.Columns.ColumnWidth = 20; ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        if (comborepcategory.SelectedIndex == 0)
                        {
                            if (combodoctors.SelectedIndex != 0)
                            {
                                ExcelApp.Cells[1, 1] = "INVOICE REPORT OF(Dr." + drid + ")";
                            }
                            else
                                ExcelApp.Cells[1, 1] = "INVOICE REPORT OF(All Doctors)";
                        }
                        else if (comborepcategory.SelectedIndex == 1)
                        {
                            if (combodoctors.SelectedIndex != 0)
                            {
                                ExcelApp.Cells[1, 1] = "PAYMENT REPORT OF(Dr." + drid + ")";
                            }
                            else
                                ExcelApp.Cells[1, 1] = "PAYMENT REPORT OF(All Doctors)";
                        }
                        else if (comborepcategory.SelectedIndex == 2)
                        {
                            if (combodoctors.SelectedIndex != 0)
                            {
                                ExcelApp.Cells[1, 1] = "APPOINMENTS REPORT OF(Dr." + drid + ")";
                            }
                            else
                                ExcelApp.Cells[1, 1] = "APPOINMENTS REPORT OF(All Doctors)";
                        }
                        else if (comborepcategory.SelectedIndex == 3)
                        {
                            ExcelApp.Cells[1, 1] = "PATIENTS REPORT OF(All Doctors)";
                        }
                        else if (comborepcategory.SelectedIndex == 4)
                        {
                            ExcelApp.Cells[1, 1] = "EMR REPORT OF(All Doctors)";
                        }
                        else if (comborepcategory.SelectedIndex == 5)
                        {
                            ExcelApp.Cells[1, 1] = "EXPENSE REPORT";
                        }
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "Report Date From";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerepo1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "Report Date To";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickerrepo2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < Grvreports.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = Grvreports.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= Grvreports.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < Grvreports.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = Grvreports.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }
                            catch
                            {
                            }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        MessageBox.Show("Successfully Exported to Exceld", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found, Please change the date and try again!..", " No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
                form2.Dispose();
            }
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
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
                listpatientsearch.Location = new Point(toolStrip1.Width - 360, 37);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }
        private void lblappointmenteachpatientgroup_Click(object sender, EventArgs e)
        {
            Appointment_for_each_patient_group d = new Appointment_for_each_patient_group();
            d.ShowDialog();
           
        }
        private void lblappointmenteachdoctor_Click(object sender, EventArgs e)
        {
            Doctor_Wise_Appointment_Report v = new Doctor_Wise_Appointment_Report();
            v.ShowDialog();
           
        }
        private void lblmonthappointmentcount_Click(object sender, EventArgs e)
        {
            Monthly_Appointment_Count c = new Monthly_Appointment_Count();
            c.ShowDialog();
           
        }
        private void lbldailyappointcount_Click(object sender, EventArgs e)
        {
            Daily_Appointment_Count d = new Daily_Appointment_Count();
            d.ShowDialog();
           
        }
        private void lblMissingCheckoutReports_Click(object sender, EventArgs e)
        {
            Missing_Checkout_Report m = new Missing_Checkout_Report();
            m.ShowDialog();
        }
        private void lblVisitingHistory_Click(object sender, EventArgs e)
        {
            Visiting_History v = new Visiting_History();
            v.ShowDialog();
        }
        private void lbldailynewpatient_Click(object sender, EventArgs e)
        {
            Daily_New_Patients d = new Daily_New_Patients();
            d.ShowDialog();
        }

        private void lblfirstappoint_Click(object sender, EventArgs e)
        {
            Patients_First_Appointment f = new Patients_First_Appointment();
            f.doctor_id = doctor_id;
            f.ShowDialog();
        }

        private void lblmonthnewpatient_Click(object sender, EventArgs e)
        {
            Monthly_New_Patients m = new Monthly_New_Patients();
            m.doctor_id = doctor_id;
            m.ShowDialog();
        }

        private void lblgroupwisereport_Click(object sender, EventArgs e)
        {
            Group_Wise_Report g = new Group_Wise_Report();
            g.patient_id = patient_id;
            g.ShowDialog();
        }

        private void lbldailytreatmentcount_Click(object sender, EventArgs e)
        {
            Daily_Treatment_Count d = new Daily_Treatment_Count();
            d.doctor_id = doctor_id;
            d.ShowDialog();
        }

        private void lbleachcategory_Click(object sender, EventArgs e)
        {
            Treatment_For_Each_Category t = new Treatment_For_Each_Category();
            t.doctor_id = doctor_id;
            t.ShowDialog();
        }

        private void lbltreatmenteachdoctor_Click(object sender, EventArgs e)
        {
            Treatment_For_Each_Doctor t = new Treatment_For_Each_Doctor();
            t.doctor_id = doctor_id;
            t.ShowDialog();
        }

        private void lblmonthtreatment_Click(object sender, EventArgs e)
        {
            Monthly_Treatment_Count m = new Monthly_Treatment_Count();
            m.doctor_id = doctor_id;
            m.ShowDialog();
        }
        private void lbldaily_Click(object sender, EventArgs e)
        {
            var form2 = new Daily_Invoice_Report();
            form2.ShowDialog();
        }
        private void lblMonthlySummary_Click(object sender, EventArgs e)
        {
            var form2 = new Monthly_Invoice_Report();
            form2.ShowDialog();
        }
        private void label14_Click(object sender, EventArgs e)
        {
            var form2 = new Doctor_Wise_Invoice();
            form2.ShowDialog();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            var form2 = new Day_Wise_Receipt();
            form2.ShowDialog();
        }
        private void Lab_Receipt_Month_Click(object sender, EventArgs e)
        {
            var form2 = new Month_Wise_Receipt();
            form2.ShowDialog();
        }
        private void Lab_Receipt_PerDoctor_Click(object sender, EventArgs e)
        {
            var form2 = new Doctor_Wise_Receipt();
            form2.ShowDialog();
        }
        private void lab_receipt_ModeOfPayment_Click(object sender, EventArgs e)
        {
            var form2 = new Paymode_Wise_Receipt();
            form2.ShowDialog();
        }
        private void label6_Click(object sender, EventArgs e)
        {
            var form2 = new Purchase_Report();
            form2.ShowDialog();
        }
        private void lab_Purch_Order_Click(object sender, EventArgs e)
        {
            var form2 = new Purchase_Order_Report();
            form2.ShowDialog();         
        }
        private void lab_purch_return_Click(object sender, EventArgs e)
        {
            var form2 = new Purchase_Return_Report();
            form2.ShowDialog();
        }
        private void Lab_Salesreport_Click(object sender, EventArgs e)
        {
            var form2 = new Sales_Report();
            form2.ShowDialog();
        }
        private void Lab_SalesOrde_Click(object sender, EventArgs e)
        {
            var form2 = new Sales_Order_Report();
            form2.ShowDialog();
        }
        private void sales_return_Click(object sender, EventArgs e)
        {
            var form2 = new Sales_Return_Report();
            form2.ShowDialog();
        }
        private void label7_Click(object sender, EventArgs e)
        {
            var form2 = new Expiry_Report();
            form2.ShowDialog();
        }
        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }
      
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.privilge_for_inventory(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                    form2.Dispose();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
                form2.Dispose();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
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
                    form2.Dispose();
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
                form2.Dispose();
            }
        }

        private void Lab_ExpanseCategory_Click(object sender, EventArgs e)
        {
            Expense_Category_Wise_Report d = new Expense_Category_Wise_Report();
            d.ShowDialog();
        }

        private void Lab_MonthlyExapanse_Click(object sender, EventArgs e)
        {
            var form2 = new Monthly_Expense_Report();
            form2.ShowDialog();
        }

        private void Lab_DailyExpanse_Click(object sender, EventArgs e)
        {
            var form2 = new Expense_Daily_Report();
            form2.ShowDialog();
        }

        private void Lab_ExpanseCategory_Click_1(object sender, EventArgs e)
        {
            var form = new Expense_Category_Wise_Report();
            form.ShowDialog();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void Chk_Type_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_Type.Checked)
            {
                rad_Expense.Enabled = true;
                rad_income.Enabled = true;
                comborepcategory_SelectedIndexChanged(sender, e);
            }
            else
            {
                rad_Expense.Enabled = false;
                rad_income.Enabled = false;
                comborepcategory_SelectedIndexChanged(sender, e);
            }
        }

        private void rad_Expense_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Expense.Checked)
            {
                comborepcategory_SelectedIndexChanged(sender, e);
            }
            else
            {
                comborepcategory_SelectedIndexChanged(sender, e);
            }
        }

        private void combodoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                select_dr_id = "0";
                if (combodoctors.SelectedIndex >= 0)
                {
                    string dt = this.cntrl.Get_DoctorId(combodoctors.SelectedItem.ToString());
                    if (dt != "")
                    {
                        select_dr_id = dt.ToString();
                    }
                }
                comborepcategory_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
