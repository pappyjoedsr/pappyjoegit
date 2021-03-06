﻿using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Add_Receipt : Form
    {
        public string doctor_id = "";
        public string patient_id = "0";
        string admin_id = "0";
        string advanceamt = "0";
        decimal advance;
        decimal total = 0, ab;
        public int status = 0;
        string sn;
        string Doctor_Name = ""; int rows_GridView3 = 0;
        int columns_GridView3 = 0;
        bool Cmb_Check = false;
        bool Cmb_Flag = false;
        string id15; public string staff_id = "";
        public string inv, inv_number, services;
        DataGridViewLinkColumn Deletelink1 = new DataGridViewLinkColumn();
        Add_Receipt_controller cntrl = new Add_Receipt_controller();
        public string[] invoices = new string[100];
        public Add_Receipt()
        {
            InitializeComponent();
        }
        private void Add_receipt_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                string admin = cntrl.Get_adminId();
                if (admin != "")
                {
                    if (admin != doctor_id.ToString())
                    {
                        admin_id = admin;
                    }
                }
                //toolStripButton8.ToolTipTex                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                t = "Settings";
                toolStripDropDownButton1.ToolTipText = "Add New";
                toolStripButton4.Visible = false;
                txt_PayNow.Focus();
                if (doctor_id.ToString() == "0")
                {
                    toolStripButton7.Visible = false;
                }
                toolStripButton1.Text = this.cntrl.Load_CompanyName();
                listpatientsearch.Hide();
                string docnam = cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                txt_ReceiptNo.Show();
                DataTable receipt = this.cntrl.receipt_number();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                if (receipt.Rows.Count == 0)
                {
                    txt_ReceiptNo.ReadOnly = false;
                }
                else
                {
                    txt_ReceiptNo.Text = receipt.Rows[0]["receipt_prefix"].ToString() + receipt.Rows[0]["receipt_number"].ToString();
                }
                DGV_MainGrid.Hide();
                panel_advanced_payment.Visible = true;
                Lab_ThiswillAdva_MSg.Visible = true;
                Lab_CardNo.Visible = false;
                Lab_Last4Digit.Visible = false;
                txt_4Digit.Visible = false;
                txt_BankNAme.Visible = false;
                txt_Number.Visible = false;
                Bank.Visible = false;
                Lab_Numbr.Visible = false;
                Cmb_ModeOfPaymnt.SelectedIndex = 0;
                if (DGV_Invoice == null)
                {
                    panel_advanced_payment.Visible = true;
                }
                DataTable dtadvance = this.cntrl.Get_Advance(patient_id);
                if (dtadvance.Rows.Count > 0)
                {
                    label_availeble_advance.Text = string.Format("{0:C}", decimal.Parse(dtadvance.Rows[0][0].ToString()));
                    Lab_advance_Available.Text = string.Format("{0:C}", decimal.Parse(dtadvance.Rows[0][0].ToString()));
                    advanceamt = dtadvance.Rows[0][0].ToString();
                }
                else
                {
                    label_availeble_advance.Text = string.Format("{0:C}", 0);
                    Lab_advance_Available.Text = string.Format("{0:C}", 0);
                }
                decimal d = 0; 
                d = total - advance;
                lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse(d.ToString())); ;
                txt_pay_from_advance.Text = string.Format("{0:C}", 0);
                DataTable dt = cntrl.Get_patient_id_name_gender(patient_id);
                Lnk_Name.Text = dt.Rows[0][0].ToString();
                Lnk_Id.Text = dt.Rows[0][1].ToString();
                Lab_Age.Text = dt.Rows[0][3].ToString();
                Lab_Gender.Text = dt.Rows[0][2].ToString();
                if (status == 0)
                {
                    btn_PayPreService.Text = "SAVE ADVANCE";
                    Btn_payonetime.Visible = false;
                    DataTable dtb = this.cntrl.Get_invoice_details(patient_id);
                    LoadGrid_status0(dtb);
                    DGV_Invoice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DGV_Invoice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DGV_Invoice.Columns[2].Visible = false;
                    foreach (DataGridViewColumn cl in DGV_Invoice.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    foreach (DataGridViewColumn cl in DGV_MainGrid.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                else
                {
                    panel1.Show();
                    btn_PayPreService.Text = "SAVE";
                    Btn_payonetime.Visible = true;
                    int p = 0;  
                    while (p < invoices.Length && invoices[p] != null)
                    {
                        DataTable dt1 = this.cntrl.Patient_invoice(patient_id, invoices[p]);
                        if (dt1.Rows.Count > 0)
                        {
                            ab = Convert.ToDecimal(dt1.Rows[0][3].ToString());
                            Doctor_Name = dt1.Rows[0]["dr_id"].ToString();
                            try
                            {
                                panel_advanced_payment.Visible = false;
                                DataTable dt2 = this.cntrl.select_invoice(invoices[p]);
                                if (dt2.Rows.Count > 0)
                                {
                                    if (DGV_MainGrid.Rows.Count == 0)
                                    {
                                        int loop = 0;
                                        while (loop < dt2.Rows.Count)
                                        {
                                            DGV_MainGrid.Rows.Add(dt2.Rows[loop][0].ToString(), dt2.Rows[loop][1].ToString(), dt2.Rows[loop][2].ToString(), 0, dt2.Rows[loop][2].ToString(), due_after_payment, rowindex, dt2.Rows[loop][0].ToString(), dt2.Rows[loop][1].ToString(), dt2.Rows[loop][2].ToString());
                                            loop++;
                                        }
                                    }
                                    else
                                    {
                                        int l = 0;
                                        while (l < dt2.Rows.Count)
                                        {
                                            DGV_MainGrid.Rows.Add(dt2.Rows[l][0].ToString(), dt2.Rows[l][1].ToString(), dt2.Rows[l][2].ToString(), 0, dt2.Rows[l][2].ToString(), due_after_payment, rowindex, dt2.Rows[l][0].ToString(), dt2.Rows[l][1].ToString(), dt2.Rows[l][2].ToString());
                                            l++;
                                        }
                                    }
                                }
                                DGV_MainGrid.Visible = true;
                                if (DGV_MainGrid.Visible == true)
                                {
                                    decimal tot = 0;
                                    for (int m = 0; m < DGV_MainGrid.Rows.Count; m++)
                                    {
                                        tot = tot + decimal.Parse(DGV_MainGrid[2, m].Value.ToString());
                                    }
                                    lab_total_payable.Text = string.Format("{0:C}", tot);
                                    Lab_TotalPayable.Text = string.Format("{0:C}", tot) + " due";
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            try
                            {
                                DGV_MainGrid.Columns.Add(Deletelink1);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            Deletelink1.UseColumnTextForLinkValue = true;
                            Deletelink1.HeaderText = "";
                            Deletelink1.LinkBehavior = LinkBehavior.NeverUnderline;
                            Deletelink1.Text = "DEL";
                            Deletelink1.Width = 30;
                        }
                        p++;
                    }
                    DGV_Invoice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DGV_Invoice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    DGV_Invoice.Columns[2].Visible = false;
                    foreach (DataGridViewColumn cl in DGV_Invoice.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    foreach (DataGridViewColumn cl in DGV_MainGrid.Columns)
                    {
                        cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                }
                DGV_MainGrid.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_MainGrid.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_MainGrid.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_MainGrid.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch
            {
                MessageBox.Show("Check your network connection..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        int rowindex;
        decimal due_after_payment;
        private void DGV_Invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                try
                {
                    btn_PayPreService.Text = "SAVE";
                    Btn_payonetime.Visible = true;
                    panel1.Show();
                    sn = DGV_Invoice.Rows[e.RowIndex].Cells[0].Value.ToString();
                    rowindex = DGV_Invoice.SelectedRows[0].Index;
                    panel_advanced_payment.Visible = false;
                    DataTable dt2 = this.cntrl.Patient_invoice(patient_id, sn);
                    ab = Convert.ToDecimal(dt2.Rows[0]["total"].ToString());
                    DataTable dt12 = this.cntrl.Get_Advance(patient_id);
                    Doctor_Name = dt2.Rows[0]["dr_id"].ToString();
                    if (DGV_MainGrid.Rows.Count == 0)
                    {
                        int loop = 0;
                        while (loop < dt2.Rows.Count)
                        {
                            DGV_MainGrid.Rows.Add(dt2.Rows[loop]["invoice_no"].ToString(), dt2.Rows[loop]["services"].ToString(), dt2.Rows[loop]["total"].ToString(), 0, dt2.Rows[loop]["total"].ToString(), due_after_payment, rowindex, dt2.Rows[loop]["invoice_no"].ToString(), dt2.Rows[loop]["services"].ToString(), dt2.Rows[loop]["total"].ToString());
                            loop++;
                        }
                    }
                    else
                    {
                        int flag3 = 0;
                        int count = 0;
                        count = DGV_MainGrid.Rows.Count;
                        for (int j = 0; j < count; j++)
                        {
                            if (DGV_MainGrid[6, j].Value.ToString() == rowindex.ToString())
                            {
                                flag3 = 1;
                            }
                        }
                        if (flag3 == 0)
                        {
                            int l = 0;
                            while (l < dt2.Rows.Count)
                            {
                                DGV_MainGrid.Rows.Add(dt2.Rows[l][0].ToString(), dt2.Rows[l][1].ToString(), dt2.Rows[l][2].ToString(), 0, dt2.Rows[l][2].ToString(), due_after_payment, rowindex, dt2.Rows[l][0].ToString(), dt2.Rows[l][1].ToString(), dt2.Rows[l][2].ToString());
                                l++;
                            }
                        }
                    }
                    DGV_Invoice.CurrentCell = null;
                    DGV_Invoice.Rows[rowindex].Visible = false;
                    DGV_MainGrid.Visible = true;
                    if (DGV_MainGrid.Visible == true)
                    {
                        decimal tot1 = 0, advB = 0, payNow = 0;//, Advan = 0; ;
                        for (int m = 0; m < DGV_MainGrid.Rows.Count; m++)
                        {
                            tot1 = tot1 + decimal.Parse(DGV_MainGrid[2, m].Value.ToString());
                            advB = advB + decimal.Parse(DGV_MainGrid[3, m].Value.ToString());
                            payNow = payNow + decimal.Parse(DGV_MainGrid[3, m].Value.ToString());
                        }
                        lab_total_payable.Text = string.Format("{0:C}", Convert.ToDecimal(tot1.ToString()));
                        txt_pay_from_advance.Text = string.Format("{0:C}", Convert.ToDecimal(advB.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", Convert.ToDecimal(tot1 - advB));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    DGV_MainGrid.Columns.Add(Deletelink1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Deletelink1.UseColumnTextForLinkValue = true;
                Deletelink1.HeaderText = "";
                Deletelink1.LinkBehavior = LinkBehavior.NeverUnderline;
                Deletelink1.Text = "DEL";
                Deletelink1.Width = 30;
            }
        }

        private void DGV_MainGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(rows_GridView3.ToString()) >= 0)
                {
                    int ro = rows_GridView3;
                    int p = rows_GridView3;
                    id15 = DGV_MainGrid.Rows[p].Cells[6].Value.ToString();
                    if (DGV_MainGrid.Rows[ro].Cells[3].Value.ToString() != "0" && DGV_MainGrid.Rows[ro].Cells[4].Value.ToString() != "0")
                    {
                        DGV_MainGrid.Rows[ro].Cells[5].Value = Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[2].Value) - Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[4].Value) - Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[3].Value);
                        decimal sumadvance = 0, sumamountpay = 0, totalamount = 0, tot = 0;
                        int i = 0;
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            sumadvance = sumadvance + Convert.ToDecimal(DGV_MainGrid[3, i].Value);
                            sumamountpay = sumamountpay + Convert.ToDecimal(DGV_MainGrid[4, i].Value);
                            totalamount = totalamount + Convert.ToDecimal(DGV_MainGrid[5, i].Value);
                            tot = tot + Convert.ToDecimal(DGV_MainGrid[2, i].Value);
                            i++;
                        }
                        txt_pay_from_advance.Text = string.Format("{0:C}", decimal.Parse(sumadvance.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse((tot - sumadvance).ToString()));
                    }
                    else if (DGV_MainGrid.Rows[ro].Cells[3].Value.ToString() != "0" && DGV_MainGrid.Rows[ro].Cells[4].Value.ToString() == "0")
                    {
                        decimal sumadvance = 0, sumamountpay = 0, totalamount = 0, tot = 0;
                        DGV_MainGrid.Rows[ro].Cells[5].Value = Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[2].Value) - Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[3].Value);
                        int i = 0;
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            sumadvance = sumadvance + Convert.ToDecimal(DGV_MainGrid[3, i].Value);
                            sumamountpay = sumamountpay + Convert.ToDecimal(DGV_MainGrid[4, i].Value);
                            totalamount = totalamount + Convert.ToDecimal(DGV_MainGrid[5, i].Value);
                            tot = tot + Convert.ToDecimal(DGV_MainGrid[2, i].Value);
                            i++;
                        }
                        txt_pay_from_advance.Text = string.Format("{0:C}", decimal.Parse(sumadvance.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse((tot - sumadvance).ToString()));
                    }
                    else if (DGV_MainGrid.Rows[ro].Cells[3].Value.ToString() == "0" && DGV_MainGrid.Rows[ro].Cells[4].Value.ToString() != "0")
                    {
                        decimal sumadvance = 0, sumamountpay = 0, totalamount = 0, tot = 0;
                        DGV_MainGrid.Rows[ro].Cells[5].Value = Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[2].Value) - Convert.ToDecimal(DGV_MainGrid.Rows[ro].Cells[4].Value);
                        int i = 0;
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            sumadvance = sumadvance + Convert.ToDecimal(DGV_MainGrid[3, i].Value);
                            sumamountpay = sumamountpay + Convert.ToDecimal(DGV_MainGrid[4, i].Value);
                            totalamount = totalamount + Convert.ToDecimal(DGV_MainGrid[5, i].Value);
                            tot = tot + Convert.ToDecimal(DGV_MainGrid[2, i].Value);
                            i++;
                        }
                        txt_pay_from_advance.Text = string.Format("{0:C}", decimal.Parse(sumadvance.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse((tot - sumadvance).ToString()));
                    }
                    decimal tot1 = 0, advB = 0, payNow = 0;
                    for (int m = 0; m < DGV_MainGrid.Rows.Count; m++)
                    {
                        tot1 = tot1 + Convert.ToDecimal(DGV_MainGrid[2, m].Value);
                        advB = advB + Convert.ToDecimal(DGV_MainGrid[3, m].Value);
                        payNow = payNow + Convert.ToDecimal(DGV_MainGrid[4, m].Value);
                    }
                    lab_total_payable.Text = string.Format("{0:C}", Convert.ToDecimal(tot1.ToString()));
                    txt_pay_from_advance.Text = string.Format("{0:C}", Convert.ToDecimal(advB.ToString()));
                    lab_due_after_advance.Text = string.Format("{0:C}", Convert.ToDecimal(tot1 - advB));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_MainGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                decimal ad_amount = 0;
                ad_amount = Convert.ToDecimal(DGV_MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (ad_amount > Convert.ToDecimal(advanceamt))
                {
                    MessageBox.Show("Entered Amount is greater than from Advance Amount", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DGV_MainGrid.CurrentCell = DGV_MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    DGV_MainGrid.BeginEdit(true);
                    return;
                }
            }
        }

        private void DGV_MainGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DGV_MainGrid.CurrentCell.RowIndex >= 0) //Desired Column
            {
                e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
                if (DGV_MainGrid.CurrentCell.ColumnIndex == 4 || DGV_MainGrid.CurrentCell.ColumnIndex == 3) //Desired Column
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                    }
                }
            }
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void btn_PayPreService_Click(object sender, EventArgs e)
        {
            decimal adv = 0;
            try
            {
                if (panel_advanced_payment.Visible == true)
                {
                    if (txt_PayNow.Text != "")
                    {
                        DataTable cmd22 = this.cntrl.Get_Advance(patient_id);
                        decimal abcde1 = Convert.ToInt32(txt_PayNow.Text);
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
                            adv = advance + abcde1;
                            this.cntrl.update_advance(adv, patient_id);
                        }
                        else
                        {
                            adv = abcde1;
                            this.cntrl.save_advance(adv, patient_id);
                        }
                        if (cmb_advane_type.SelectedIndex == 1)
                        {
                            this.cntrl.Save_advancetable_cheque(patient_id, DateTime.Now.Date.ToString("yyyy-MM-dd"), abcde1.ToString(), cmb_advane_type.Text, txt_adv_bankname.Text, txt_adv_number.Text, "Debit", "Receipt");
                            
                        }
                        else if (cmb_advane_type.SelectedIndex == 2)
                        {
                            this.cntrl.Save_advancetable_card(patient_id, DateTime.Now.Date.ToString("yyyy-MM-dd"), abcde1.ToString(), cmb_advane_type.Text, txt_adv_bankname.Text, txt_adv_4digit.Text, "Debit", "Receipt");
                        }
                        else if(cmb_advane_type.SelectedIndex == 3)
                        {
                            this.cntrl.Save_advancetable_DD(patient_id, DateTime.Now.Date.ToString("yyyy-MM-dd"), abcde1.ToString(), cmb_advane_type.Text, txt_adv_bankname.Text, txt_adv_number.Text, "Debit", "Receipt");
                        }
                        else
                        {
                            this.cntrl.Save_advancetable(patient_id, DateTime.Now.Date.ToString("yyyy-MM-dd"), abcde1.ToString(), cmb_advane_type.Text, "Debit","Receipt");
                        }
                        if (adv > 0)
                        {
                            label_availeble_advance.Text = string.Format("{0:C}", decimal.Parse(adv.ToString()));
                            Lab_advance_Available.Text = string.Format("{0:C}", decimal.Parse(adv.ToString()));
                        }
                        txt_PayNow.Clear();
                        this.cntrl.save_log(doctor_id, "Receipt", "logged user adds new receipt", "Add");
                        DialogResult rslt = MessageBox.Show("Advance Payment Saved...! Do you want print receipt...? ", "Print As...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rslt == DialogResult.Yes)
                        {
                            Advance_paymentPrint(abcde1);
                        }
                        var form2 = new Receipt();
                        if (doctor_id == "0")
                        {
                            form2.staff_id = staff_id;
                        }
                        else
                        {
                            form2.doctor_id = doctor_id;
                        }
                        form2.patient_id = patient_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Enter advance amount...", "Amount Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_PayNow.Focus();
                    }
                }
                else if (DGV_MainGrid.Visible == true)
                {
                    int sta = 0, flag = 0;
                    if (check_AllPayments() == 1)
                    {
                        DialogResult res;
                        res = MessageBox.Show("Some Payments are not made.Are you sure you want to continue?!!", "Empty Payments made", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (res == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                        }
                    }
                    DataTable receipt = this.cntrl.Get_All_paymenttbl_details(txt_ReceiptNo.Text);
                    if (receipt.Rows.Count <= 0)
                    {
                        if (doctor_id == "0")
                        {
                            doctor_id = admin_id;
                        }
                        int iii = 0;
                        double g_Advance = 0;
                        double g_Paid = 0;
                        double g_Est = 0;
                        double Total_Advance = 0;
                        double Total_paid = 0;decimal enteramnt=0,balanceamnt=0;
                        //checking advance exists
                        DataTable cmd22 = this.cntrl.Get_Advance(patient_id);
                        if(cmd22.Rows.Count>0)
                        {
                            if (Convert.ToDecimal(cmd22.Rows[0][0].ToString()) > 0)
                            {
                                if (Convert.ToDecimal(DGV_MainGrid.Rows[0].Cells["pay_fromadvance"].Value) == 0)
                                {
                                    DialogResult res1 = MessageBox.Show("You have advance amount,Do you want to pay from advance amount?", " confirmation",
                                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (res1 == DialogResult.Yes)
                                    {

                                        for (int k = 0; k < DGV_MainGrid.Rows.Count; k++)
                                        {
                                            DGV_MainGrid.Rows[k].Cells["due_afterpaymnt"].Value = 0;
                                            DGV_MainGrid.Rows[k].Cells["ColPayNow"].Value = 0;
                                            DGV_MainGrid.Rows[k].Cells["ColPayNow"].Value = DGV_MainGrid.Rows[k].Cells["balancedue"].Value;

                                        }
                                        DGV_MainGrid.Rows[0].Cells["pay_fromadvance"].Selected = true;
                                        return;
                                    }
                                }
                            }
                        }
                        
                        while (iii < DGV_MainGrid.Rows.Count)
                        {
                            g_Advance = Convert.ToDouble(DGV_MainGrid[3, iii].Value);
                            if (g_Advance == 0)
                                g_Paid = Convert.ToDouble(DGV_MainGrid[4, iii].Value);
                            else
                                g_Paid = 0;
                            g_Est = Convert.ToDouble(DGV_MainGrid[9, iii].Value);
                            if (g_Est < (g_Advance + g_Paid))
                            {
                                DialogResult res = MessageBox.Show("Entered Amount is greater than from Treatment Amount,Do you want to keep this balance amount as advance amount ?", " confirmation",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.No)
                                {
                                    DGV_MainGrid.Rows[iii].Cells[4].Value = "";
                                    DGV_MainGrid.Rows[iii].Cells[4].Selected = true;//[4, iii]
                                    return;
                                }
                                else
                                {
                                    decimal advance1 = 0;
                                    //remainng balance due save as advance 
                                    enteramnt = Convert.ToDecimal(DGV_MainGrid[4, iii].Value);
                                    balanceamnt = enteramnt - Convert.ToDecimal(g_Est);
                                    //DataTable cmd22 = this.cntrl.Get_Advance(patient_id);
                                    //decimal abcde1 = Convert.ToInt32(txt_PayNow.Text);
                                    if (cmd22.Rows.Count > 0)
                                    {
                                        if (cmd22.Rows[0]["advance"].ToString() == null)
                                        {
                                            advance1 = 0;
                                        }
                                        else if (cmd22.Rows[0]["advance"].ToString() == "")
                                        {
                                            advance1 = 0;
                                        }
                                        else if (cmd22.Rows[0]["advance"].ToString() == "0")
                                        {
                                            advance1 = 0;
                                        }
                                        else
                                        {
                                            advance1 = decimal.Parse(cmd22.Rows[0]["advance"].ToString());
                                        }
                                        adv = advance1 + balanceamnt;
                                        this.cntrl.update_advance(adv, patient_id);
                                    }
                                    else
                                    {
                                        adv = balanceamnt;
                                        this.cntrl.save_advance(adv, patient_id);
                                    }
                                    this.cntrl.Save_advancetable(patient_id, DateTime.Now.Date.ToString("yyyy-MM-dd"), balanceamnt.ToString(), cmb_advane_type.Text, "Debit", "Add Receipt");
                                    g_Paid = g_Est;
                                    DGV_MainGrid[4, iii].Value = g_Est;
                                }
                                //MessageBox.Show("Entered Amount is greater than from Treatment Amount", "Wrong Amount ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //return;
                            }
                            if (g_Advance == 0)
                            { }
                            if (g_Paid == 0)
                            {
                                DGV_MainGrid[4, iii].Value = "0";
                            }
                            Total_Advance = Total_Advance + g_Advance;
                            Total_paid = Total_paid + g_Paid;
                            iii++;
                        }
                        if (Total_Advance > Convert.ToDouble(advanceamt))
                        {
                            MessageBox.Show("Entered Advance Amount is greater than from Advance Amount", "Wrong Amount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (Total_paid <= 0 && Total_Advance <= 0)
                        {
                            MessageBox.Show("Payment amount is missing in payment window..", "Amount Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        int status = 0;
                        decimal advance = 0;
                        int i = 0;
                        if (calc())
                        {
                            while (i < DGV_MainGrid.Rows.Count)
                            {
                                if (DGV_MainGrid[3, i].Value.ToString() != "0" || DGV_MainGrid[4, i].Value.ToString() != "0")
                                {
                                    status = 1;
                                    string asd = doctor_id;
                                    decimal totalPaid = 0;
                                    if (DGV_MainGrid[3, i].Value.ToString() != "" && DGV_MainGrid[4, i].Value.ToString() != "")
                                    {
                                        totalPaid = decimal.Parse(DGV_MainGrid[3, i].Value.ToString()) + decimal.Parse(DGV_MainGrid[4, i].Value.ToString());
                                    }
                                    else if (DGV_MainGrid[3, i].Value.ToString() != "" && DGV_MainGrid[4, i].Value.ToString() == "")
                                    {
                                        totalPaid = decimal.Parse(DGV_MainGrid[3, i].Value.ToString());
                                    }
                                    else if (DGV_MainGrid[3, i].Value.ToString() == "" && DGV_MainGrid[4, i].Value.ToString() != "")
                                    {
                                        totalPaid = decimal.Parse(DGV_MainGrid[4, i].Value.ToString());
                                    }
                                    else
                                    {
                                        totalPaid = 0;
                                    }
                                    decimal total = decimal.Parse(DGV_MainGrid[9, i].Value.ToString()) - decimal.Parse(DGV_MainGrid[3, i].Value.ToString()) - decimal.Parse(DGV_MainGrid[4, i].Value.ToString());
                                    DataTable totalinv = this.cntrl.Procedurewisw_receipt_report(DGV_MainGrid[7, i].Value.ToString(), patient_id, DGV_MainGrid[8, i].Value.ToString());
                                    Doctor_Name = totalinv.Rows[0]["dr_id"].ToString();
                                    if (Cmb_Flag)
                                    {
                                        int updateinvoice = this.cntrl.updatetotal(total, DGV_MainGrid[7, i].Value.ToString(), patient_id, DGV_MainGrid[8, i].Value.ToString());
                                        if (updateinvoice > 0)
                                        {
                                            int inv = 0;
                                            if (Cmb_ModeOfPaymnt.SelectedIndex == 1)
                                            {
                                                inv = this.cntrl.save_payment_checkwise(DGV_MainGrid[3, i].Value.ToString(), txt_ReceiptNo.Text.ToString(), totalPaid, DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString(), txt_BankNAme.Text, txt_Number.Text);//
                                            }
                                            else if (Cmb_ModeOfPaymnt.SelectedIndex == 2)
                                            {
                                                inv = this.cntrl.save_payment_cardWise(DGV_MainGrid[3, i].Value.ToString(), txt_ReceiptNo.Text.ToString(), totalPaid, DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString(), txt_BankNAme.Text, txt_4Digit.Text);
                                            }
                                            else if (Cmb_ModeOfPaymnt.SelectedIndex == 3)
                                            {
                                                inv = this.cntrl.Save_payment_DD(DGV_MainGrid[3, i].Value.ToString(), txt_ReceiptNo.Text.ToString(), totalPaid, DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString(), txt_BankNAme.Text, txt_Number.Text);
                                            }
                                            if (inv > 0)
                                            {
                                                int ii = 0;
                                                decimal invoicepaymenttotal = 1;
                                                decimal invoice_main_id = 0;
                                                invoice_main_id = decimal.Parse(totalinv.Rows[0]["invoice_main_id"].ToString());
                                                DataTable invocetotal = this.cntrl.SumofTotal(DGV_MainGrid[7, i].Value.ToString(), patient_id);
                                                if (invocetotal.Rows.Count > 0)
                                                {
                                                    invoicepaymenttotal = 0;
                                                    while (ii < invocetotal.Rows.Count)
                                                    {
                                                        invoicepaymenttotal = invoicepaymenttotal + decimal.Parse(invocetotal.Rows[0]["I_total"].ToString());
                                                        ii++;
                                                    }
                                                }
                                                if (invoicepaymenttotal == 0)
                                                {
                                                    this.cntrl.update_invoice_status0(invoice_main_id);
                                                }
                                                advance = advance + decimal.Parse(DGV_MainGrid[3, i].Value.ToString());
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Inseration Failed!....", "Failed!.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        int updateinvoice = this.cntrl.updatetotal(total, DGV_MainGrid[7, i].Value.ToString(), patient_id, DGV_MainGrid[8, i].Value.ToString());
                                        if (updateinvoice > 0)
                                        {
                                            int inv1 = this.cntrl.save_payment(adv.ToString(), txt_ReceiptNo.Text.ToString(), totalPaid, DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString());
                                            if (inv1 > 0)//DGV_MainGrid[3, i].Value.ToString(),
                                            {
                                                int ii = 0;
                                                decimal invoicepaymenttotal = 1;
                                                decimal invoice_main_id = 0;
                                                invoice_main_id = decimal.Parse(totalinv.Rows[0]["invoice_main_id"].ToString());
                                                DataTable invocetotal = this.cntrl.SumofTotal(DGV_MainGrid[7, i].Value.ToString(), patient_id);
                                                if (invocetotal.Rows.Count > 0)
                                                {
                                                    invoicepaymenttotal = 0;
                                                    while (ii < invocetotal.Rows.Count)
                                                    {
                                                        invoicepaymenttotal = invoicepaymenttotal + decimal.Parse(invocetotal.Rows[0]["I_total"].ToString());
                                                        ii++;
                                                    }
                                                }
                                                if (invoicepaymenttotal == 0)
                                                {
                                                    this.cntrl.update_invoice_status0(invoice_main_id);
                                                }
                                                advance = advance + decimal.Parse(DGV_MainGrid[3, i].Value.ToString());
                                            }
                                        }
                                    }
                                }
                                i++;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter the bank details", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (status == 1)
                        {
                            decimal a = 0;
                            if (adv > 0)
                            {

                            }
                            else
                            {
                                a = decimal.Parse(advanceamt) - advance;
                                this.cntrl.update_advance(a, patient_id);
                            }

                            string rec = this.cntrl.receipt_autoid();
                            int receip = int.Parse(rec) + 1;
                            this.cntrl.update_receiptAutoid(receip);
                            if (doctor_id == admin_id)
                            {
                                doctor_id = "0";
                            }
                            var form2 = new Receipt();
                            if (doctor_id == "0")
                            {
                                form2.staff_id = staff_id;
                            }
                            else
                            {
                                form2.doctor_id = doctor_id;
                            }
                            form2.patient_id = patient_id;
                            form2.Closed += (sender1, args) => this.Close();
                            this.Hide();
                            form2.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("This receipt number already exists..Choose another one. If Receipt number is autogenereted, you can change it from settings", "Receipt number exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This receipt number already exists..Choose another one. If Receipt number is autogenereted, you can change it from settings", "Receipt number exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadGrid_status0(DataTable dt1)
        {
            try
            {
                DGV_Invoice.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_Invoice.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_Invoice.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_Invoice.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_Invoice.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                DGV_Invoice.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Dictionary<string, int> dict = new Dictionary<string, int>();
                DGV_Invoice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                int rowNum = 0;
                decimal due = 0;
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    string invoice_no = dt1.Rows[j]["invoice"].ToString();
                    string services = dt1.Rows[j]["services"].ToString();
                    string pt_id = dt1.Rows[0]["pt_id"].ToString();
                    string pt_name = dt1.Rows[0]["pt_name"].ToString();
                    string totalcost = Convert.ToDecimal(dt1.Rows[j]["total"].ToString()).ToString("##.##");
                    string date = DateTime.Parse(dt1.Rows[0]["date"].ToString()).ToString("dd MMMM yyyy");
                    string abc = invoice_no + "," + invoice_no;
                    string abc1 = invoice_no + "," + services;
                    string abc2 = invoice_no + "," + pt_id;
                    string abc3 = invoice_no + "," + pt_name;
                    string abc4 = invoice_no + "," + totalcost;
                    string abc5 = invoice_no + "," + date;
                    string[] items = abc.Split(',');
                    string[] items1 = abc1.Split(',');
                    string[] items2 = abc2.Split(',');
                    string[] items3 = abc3.Split(',');
                    string[] items4 = abc4.Split(',');
                    string[] items5 = abc5.Split(',');
                    if (dict.ContainsKey(items[0]))
                    {
                        DGV_Invoice.Rows[dict[items[0]]].Cells[3].Value += "\r\n" + String.Format("{0:C}", Convert.ToDecimal(items4[1]));
                        DGV_Invoice.Rows[dict[items[0]]].Cells[1].Value += "\r\n" + items1[1];
                    }
                    else
                    {
                        dict.Add(items[0], rowNum);
                        DGV_Invoice.Rows.Add(items[1], items1[1], items2[1], String.Format("{0:C}", Convert.ToDecimal(items4[1])), items3[1], items5[1]);
                        rowNum++;
                    }
                    due = due + decimal.Parse(dt1.Rows[j]["total"].ToString());
                    if (due > 0)
                    {
                        Lab_TotalPayable.Text = string.Format("{0:C}", due) + " due";
                    }
                }
                DGV_Invoice.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Invoice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DGV_Invoice.Columns[2].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_MainGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                int index = -1, indexDgv3 = -1;
                int flag3 = 0;
                int a = e.RowIndex;
                inv_number = DGV_MainGrid.Rows[a].Cells[0].Value.ToString();
                services = DGV_MainGrid.Rows[a].Cells[6].Value.ToString();
                int i = 0;
                while (i < DGV_Invoice.Rows.Count)
                {
                    if (inv_number == DGV_Invoice.Rows[i].Cells[0].Value.ToString())
                    {
                        index = DGV_Invoice.Rows[i].Index;
                        indexDgv3 = DGV_MainGrid.Rows[a].Index;
                        flag3 = 1;
                        break;
                    }
                    i++;
                }
                try
                {
                    if (index != -1 && flag3 == 1)
                    {
                        if (DGV_MainGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
                        {
                            DGV_MainGrid.Rows.RemoveAt(indexDgv3);
                            DGV_Invoice.Rows[index].Visible = true;
                            DGV_Invoice.Show();
                            decimal tot = 0, advB = 0, payNow = 0;
                            for (int m = 0; m < DGV_MainGrid.Rows.Count; m++)
                            {
                                tot = tot + decimal.Parse(DGV_MainGrid[2, m].Value.ToString());
                                advB = advB + decimal.Parse(DGV_MainGrid[3, m].Value.ToString());
                                payNow = payNow + decimal.Parse(DGV_MainGrid[4, m].Value.ToString());
                            }
                            lab_total_payable.Text = string.Format("{0:C}", Convert.ToDecimal(tot.ToString()));
                            txt_pay_from_advance.Text = string.Format("{0:C}", Convert.ToDecimal(advB.ToString()));
                            lab_due_after_advance.Text = string.Format("{0:C}", Convert.ToDecimal(tot - advB));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DGV_MainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ro = e.RowIndex;
            rows_GridView3 = e.RowIndex;
            columns_GridView3 = e.ColumnIndex;
            if (DGV_MainGrid.CurrentCell.OwningColumn.Name == "ColPayNow")
            {
                var form2 = new Add_Amount();
                form2.StartPosition = FormStartPosition.CenterParent;
                form2.ShowDialog();
                form2.Dispose();
                decimal Amount = PappyjoeMVC.Model.Connection.MyGlobals.PaidAmount;
                if (Amount == 0)
                { }
                else
                {
                    DGV_MainGrid.CurrentRow.Cells["ColPayNow"].Value = Amount;
                }
                PappyjoeMVC.Model.Connection.MyGlobals.PaidAmount = 0;
                if (DGV_MainGrid.CurrentRow.Cells[3].Value == null || DGV_MainGrid.CurrentRow.Cells[3].Value.ToString() == "")
                {
                    DGV_MainGrid.CurrentRow.Cells[3].Value = "0";
                }
            }
            try
            {
                int p = e.RowIndex;
                id15 = DGV_MainGrid.Rows[p].Cells[6].Value.ToString();
                try
                {
                    if (DGV_MainGrid.Rows[ro].Cells[3].Value.ToString() != "0" && DGV_MainGrid.Rows[ro].Cells[4].Value.ToString() != "0")
                    {
                        DGV_MainGrid.Rows[ro].Cells[5].Value = decimal.Parse(DGV_MainGrid.Rows[ro].Cells[2].Value.ToString()) - decimal.Parse(DGV_MainGrid.Rows[ro].Cells[4].Value.ToString()) - decimal.Parse(DGV_MainGrid.Rows[ro].Cells[3].Value.ToString());
                        decimal sumadvance = 0, sumamountpay = 0, totalamount = 0, tot = 0;
                        int i = 0;
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            sumadvance = sumadvance + decimal.Parse(DGV_MainGrid[3, i].Value.ToString());
                            sumamountpay = sumamountpay + decimal.Parse(DGV_MainGrid[4, i].Value.ToString());
                            totalamount = totalamount + decimal.Parse(DGV_MainGrid[5, i].Value.ToString());
                            tot = tot + decimal.Parse(DGV_MainGrid[2, i].Value.ToString());
                            i++;
                        }
                        txt_pay_from_advance.Text = string.Format("{0:C}", decimal.Parse(sumadvance.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse((tot - sumadvance).ToString()));
                    }
                    else if (DGV_MainGrid.Rows[ro].Cells[3].Value.ToString() != "0" && DGV_MainGrid.Rows[ro].Cells[4].Value.ToString() == "0")
                    {
                        decimal sumadvance = 0, sumamountpay = 0, totalamount = 0, tot = 0;
                        DGV_MainGrid.Rows[ro].Cells[5].Value = decimal.Parse(DGV_MainGrid.Rows[ro].Cells[2].Value.ToString()) - decimal.Parse(DGV_MainGrid.Rows[ro].Cells[3].Value.ToString());
                        int i = 0;
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            sumadvance = sumadvance + decimal.Parse(DGV_MainGrid[3, i].Value.ToString());
                            sumamountpay = sumamountpay + decimal.Parse(DGV_MainGrid[4, i].Value.ToString());
                            totalamount = totalamount + decimal.Parse(DGV_MainGrid[5, i].Value.ToString());
                            tot = tot + decimal.Parse(DGV_MainGrid[2, i].Value.ToString());
                            i++;
                        }
                        txt_pay_from_advance.Text = string.Format("{0:C}", decimal.Parse(sumadvance.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse((tot - sumadvance).ToString()));
                    }
                    else if (DGV_MainGrid.Rows[ro].Cells[3].Value.ToString() == "0" && DGV_MainGrid.Rows[ro].Cells[4].Value.ToString() != "0")
                    {
                        decimal sumadvance = 0, sumamountpay = 0, totalamount = 0, tot = 0;
                        DGV_MainGrid.Rows[ro].Cells[5].Value = decimal.Parse(DGV_MainGrid.Rows[ro].Cells[2].Value.ToString()) - decimal.Parse(DGV_MainGrid.Rows[ro].Cells[4].Value.ToString());
                        int i = 0;
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            sumadvance = sumadvance + decimal.Parse(DGV_MainGrid[3, i].Value.ToString());
                            sumamountpay = sumamountpay + decimal.Parse(DGV_MainGrid[4, i].Value.ToString());
                            totalamount = totalamount + decimal.Parse(DGV_MainGrid[5, i].Value.ToString());
                            tot = tot + decimal.Parse(DGV_MainGrid[2, i].Value.ToString());
                            i++;
                        }
                        txt_pay_from_advance.Text = string.Format("{0:C}", decimal.Parse(sumadvance.ToString()));
                        lab_due_after_advance.Text = string.Format("{0:C}", decimal.Parse((tot - sumadvance).ToString()));
                    }
                    decimal tot1 = 0, advB = 0, payNow = 0;
                    for (int m = 0; m < DGV_MainGrid.Rows.Count; m++)
                    {
                        tot1 = tot1 + decimal.Parse(DGV_MainGrid[2, m].Value.ToString());
                        advB = advB + decimal.Parse(DGV_MainGrid[3, m].Value.ToString());
                        payNow = payNow + decimal.Parse(DGV_MainGrid[4, m].Value.ToString());
                    }
                    lab_total_payable.Text = string.Format("{0:C}", Convert.ToDecimal(tot1.ToString()));
                    txt_pay_from_advance.Text = string.Format("{0:C}", Convert.ToDecimal(advB.ToString()));
                    lab_due_after_advance.Text = string.Format("{0:C}", Convert.ToDecimal(tot1 - advB));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int check_AllPayments()
        {
            int affected = 0;
            for (int k = 0; k < DGV_MainGrid.Rows.Count; k++)
            {
                if (DGV_MainGrid[3, k].Value.ToString() != "0" || DGV_MainGrid[4, k].Value.ToString() != "0")
                {

                }
                else
                {
                    affected = 1;
                }
            }
            return affected;
        }

        public bool calc()
        {
            if (Cmb_ModeOfPaymnt.SelectedIndex == 0 || Cmb_ModeOfPaymnt.SelectedIndex > 3)
            {
                Cmb_Flag = false;
                Cmb_Check = true;
            }
            else if (Cmb_ModeOfPaymnt.SelectedIndex == 2)
            {
                if (txt_BankNAme.Text != "" && txt_4Digit.Text != "")
                {
                    Cmb_Flag = true;
                    Cmb_Check = true;
                }
                else if (txt_BankNAme.Text != "" || txt_4Digit.Text == "")
                {
                    txt_4Digit.Focus();
                    Cmb_Check = false;
                }
                else if (txt_BankNAme.Text == "" || txt_4Digit.Text != "")
                {
                    txt_BankNAme.Focus();
                    Cmb_Check = false;
                }
                else
                {
                    txt_BankNAme.Focus();
                }
            }
            else
            {
                if (txt_BankNAme.Text == "" && txt_Number.Text != "")
                {
                    txt_BankNAme.Focus();
                    Cmb_Check = false;
                }
                else if (txt_BankNAme.Text != "" && txt_Number.Text != "")
                {
                    Cmb_Flag = true;
                    Cmb_Check = true;
                }
                else if (txt_BankNAme.Text != "" && txt_Number.Text == "")
                {
                    txt_Number.Focus();
                    Cmb_Check = false;
                }
                else
                {
                    txt_BankNAme.Focus();
                }
            }
            return Cmb_Check;
        }

        private void Btn_payonetime_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable receipt = this.cntrl.Get_All_paymenttbl_details(txt_ReceiptNo.Text);
                if (receipt.Rows.Count <= 0)
                {
                    if (doctor_id == "0")
                    {
                        doctor_id = admin_id;
                    }
                    double g_Est = 0;
                    int status = 0;
                    decimal advance = 0;
                    int i = 0;
                    if (calc())
                    {
                        while (i < DGV_MainGrid.Rows.Count)
                        {
                            status = 1;
                            string asd = doctor_id;
                            double Add_est = 0;
                            double Add_advanceamt = 0;
                            if (Convert.ToDouble(advanceamt) > 0)
                            {
                                g_Est = Convert.ToDouble(DGV_MainGrid[9, i].Value);
                                if (g_Est == Convert.ToDouble(advanceamt))
                                {
                                    Add_est = g_Est;
                                    Add_advanceamt = Convert.ToDouble(advanceamt);
                                    advanceamt = "0";
                                }
                                else if (g_Est > Convert.ToDouble(advanceamt))
                                {
                                    Add_est = g_Est - Convert.ToDouble(advanceamt);
                                    Add_advanceamt = Convert.ToDouble(advanceamt);
                                    advanceamt = "0";
                                }
                                else if (g_Est < Convert.ToDouble(advanceamt))
                                {
                                    Add_est = 0;
                                    Add_advanceamt = g_Est;
                                    advanceamt = Convert.ToString(Convert.ToDouble(advanceamt) - g_Est);
                                }
                            }
                            else
                            {
                                Add_est = Convert.ToDouble(DGV_MainGrid[9, i].Value);
                                Add_advanceamt = 0;
                            }
                            decimal total = decimal.Parse(DGV_MainGrid[9, i].Value.ToString()) - Convert.ToDecimal(Add_est + Add_advanceamt);
                            DataTable totalinv = this.cntrl.Procedurewisw_receipt_report(DGV_MainGrid[7, i].Value.ToString(), patient_id, DGV_MainGrid[8, i].Value.ToString());//
                            int updateinvoice = this.cntrl.updatetotal(total, DGV_MainGrid[7, i].Value.ToString(), patient_id, DGV_MainGrid[8, i].Value.ToString());
                            if (updateinvoice > 0)
                            {
                                int inv = 0;
                                Doctor_Name = totalinv.Rows[0]["dr_id"].ToString();
                                if (Cmb_ModeOfPaymnt.SelectedIndex == 1)
                                {
                                    inv = this.cntrl.save_payment_checkwise(Add_advanceamt.ToString(), txt_ReceiptNo.Text.ToString(), Convert.ToDecimal(DGV_MainGrid[9, i].Value.ToString()), DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString(), txt_BankNAme.Text, txt_Number.Text);//
                                }
                                else if (Cmb_ModeOfPaymnt.SelectedIndex == 2)
                                {
                                    inv = this.cntrl.save_payment_cardWise(Add_advanceamt.ToString(), txt_ReceiptNo.Text.ToString(), Convert.ToDecimal(DGV_MainGrid[9, i].Value.ToString()), DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString(), txt_BankNAme.Text, txt_4Digit.Text);
                                }
                                else if (Cmb_ModeOfPaymnt.SelectedIndex == 3)
                                {
                                    inv = this.cntrl.Save_payment_DD(Add_advanceamt.ToString(), txt_ReceiptNo.Text.ToString(), Convert.ToDecimal(DGV_MainGrid[9, i].Value.ToString()), DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString(), txt_BankNAme.Text, txt_Number.Text);
                                }
                                else if (Cmb_ModeOfPaymnt.SelectedIndex == 0)
                                {
                                    inv = this.cntrl.save_payment(Add_advanceamt.ToString(), txt_ReceiptNo.Text.ToString(), Convert.ToDecimal(DGV_MainGrid[9, i].Value.ToString()), DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString());
                                }
                                else if (Cmb_ModeOfPaymnt.SelectedIndex > 3) // other payment method..
                                {
                                    inv = this.cntrl.save_payment(Add_advanceamt.ToString(), txt_ReceiptNo.Text.ToString(), Convert.ToDecimal(DGV_MainGrid[9, i].Value.ToString()), DGV_MainGrid[7, i].Value.ToString(), DGV_MainGrid[8, i].Value.ToString(), Cmb_ModeOfPaymnt.Text, patient_id, dateTimePicker1.Value.ToString("yyyy-MM-dd"), Doctor_Name, totalinv.Rows[0]["invoice_main_id"].ToString(), totalinv.Rows[0]["total"].ToString(), totalinv.Rows[0]["cost"].ToString(), totalinv.Rows[0]["pt_name"].ToString());
                                }
                                if (inv > 0)
                                {
                                    int ii = 0;
                                    decimal invoicepaymenttotal = 1;
                                    decimal invoice_main_id = 0;
                                    invoice_main_id = decimal.Parse(totalinv.Rows[0]["invoice_main_id"].ToString());
                                    DataTable invocetotal = this.cntrl.SumofTotal(DGV_MainGrid[7, i].Value.ToString(), patient_id);
                                    if (invocetotal.Rows.Count > 0)
                                    {
                                        invoicepaymenttotal = 0;
                                        while (ii < invocetotal.Rows.Count)
                                        {
                                            invoicepaymenttotal = invoicepaymenttotal + decimal.Parse(invocetotal.Rows[0]["I_total"].ToString());
                                            ii++;
                                        }
                                    }
                                    if (invoicepaymenttotal == 0)
                                    {
                                        this.cntrl.update_invoice_status0(invoice_main_id);
                                    }
                                    advance = advance + Convert.ToDecimal(Add_advanceamt);
                                }
                            }
                            i++;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter bank details", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (status == 1)
                    {
                        decimal a = 0;
                        a = Convert.ToDecimal(advanceamt);
                        this.cntrl.update_advance(a, patient_id);
                        string rec = this.cntrl.receipt_autoid();
                        if (Convert.ToInt32(rec) > 0)
                        {
                            int receip = int.Parse(rec) + 1;
                            this.cntrl.update_receiptAutoid(receip);
                        }
                        DGV_MainGrid.Enabled = true;
                        if (doctor_id == admin_id)
                        {
                            doctor_id = "0";
                        }
                        var form2 = new Receipt();
                        if (doctor_id == "0")
                        {
                            form2.staff_id = staff_id;
                        }
                        else
                        {
                            form2.doctor_id = doctor_id;
                        }
                        form2.patient_id = patient_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else
                {
                    MessageBox.Show("This receipt number already exists..Choose another one. If Receipt number is autogenereted, you can change it from settings", "Receipt number exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.patient_id = patient_id;
            if (doctor_id == "0")
            {
                form2.staff_id = staff_id;
            }
            else
            {
                form2.doctor_id = doctor_id;
            }
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void Cmb_ModeOfPaymnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbox = (ComboBox)sender;
            if (cbox.SelectedIndex == 1)
            {
                payment_show(true, true, true, true, false, false, false, false);
            }
            else if (cbox.SelectedIndex == 2)
            {
                payment_show(true, false, false, false, true, true, true, false);
            }
            else if (cbox.SelectedIndex == 0)
            {
                payment_show(false, false, false, false, false, false, false, false);
            }
            else if (cbox.SelectedIndex == 3)
            {
                payment_show(true, true, true, true, false, false, false, false);
            }
            else
            { payment_show(false, false, false, false, false, false, false, false); }
        }
        public void payment_show(Boolean BankName, Boolean Number, Boolean bank, Boolean lab_number, Boolean last4digit, Boolean cardno, Boolean t4digit, Boolean ddnumber)
        {
            if(panel_advanced_payment.Visible==true)
            {
                txt_adv_bankname.Visible = BankName;
                txt_adv_number.Visible = Number;
                lab_adv_bank.Visible = bank;
                lab_adv_number.Visible = lab_number;
                lab_adv_4digit.Visible = last4digit;
                lab_adv_cardno.Visible = cardno;
                txt_adv_4digit.Visible = t4digit;
                //lab_adv_dd.Visible = ddnumber;
            }
            else
            {
                txt_BankNAme.Visible = BankName;
                txt_Number.Visible = Number;
                Bank.Visible = bank;
                Lab_Numbr.Visible = lab_number;
                Lab_Last4Digit.Visible = last4digit;
                Lab_CardNo.Visible = cardno;
                txt_4Digit.Visible = t4digit;
                Lab_DDNumber.Visible = ddnumber;
            }
            
        }

        private void txt_4Digit_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_4Digit.Text != "")
            {
                if (Convert.ToInt32(txt_4Digit.Text.Length) > 4)
                {
                }
            }
        }

        private void txt_PayNow_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && txt_PayNow.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }

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
                listpatientsearch.Location = new Point(toolStripTextBox1.Width + 765, 32);
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
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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
                    form2.Show();
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
                form2.Show();
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
                    form2.Show();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void Lnk_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void Lnk_Id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
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
                    form2.Show();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
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

        private void lab_adv_4digit_Click(object sender, EventArgs e)
        {

        }

        private void txt_adv_4digit_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_adv_4digit.Text != "")
            {
                if (Convert.ToInt32(txt_adv_4digit.Text.Length) > 4)
                {

                }
            }
        }

        public void Advance_paymentPrint(decimal total)
        {
            try
            {
                string Logopath = "";
                string str_name = "";
                string str_street_address = "";
                string str_locality = "";
                string str_pincode = "";
                string str_contact_no = "";
                string str_email = "";
                string str_website = "";
                string patiID = "";
                string PatName = "";
                string address = "";
                DataTable dt_patent = new DataTable();
                dt_patent = this.cntrl.get_patientDetails(patient_id);
                if (dt_patent.Rows.Count > 0)
                {
                    string strage = "", strgener = "";
                    patiID = dt_patent.Rows[0]["pt_id"].ToString();
                    if (dt_patent.Rows[0]["age"].ToString() != "")
                    {
                        if (dt_patent.Rows[0]["gender"].ToString() != "")
                        {
                            strage = " (" + dt_patent.Rows[0]["age"].ToString();
                        }
                        else
                        { strage = " (" + dt_patent.Rows[0]["age"].ToString() + ")"; }
                    }
                    if (dt_patent.Rows[0]["gender"].ToString() != "")
                    {
                        if (strage != "")
                        {
                            strgener = "/" + dt_patent.Rows[0]["gender"].ToString() + ")";
                        }
                        else
                        {
                            strgener = " (" + dt_patent.Rows[0]["gender"].ToString() + ")";
                        }
                    }
                    PatName = dt_patent.Rows[0]["pt_name"].ToString() + strage + strgener;
                    address = dt_patent.Rows[0]["street_address"].ToString();
                }
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
                    Logopath = dtp.Rows[0]["path"].ToString();
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter swriter = new StreamWriter(Apppath + "\\AdvancePaymentReceipt.html");
                swriter.WriteLine("<Html>");
                swriter.WriteLine("<head>");
                swriter.WriteLine("<style>");
                swriter.WriteLine("table { border-collapse: collapse;}");
                swriter.WriteLine("p.big {line-height: 400%;}");
                swriter.WriteLine("</style>");
                swriter.WriteLine("</head>");
                swriter.WriteLine("<body>");
                if (File.Exists(Apppath + "\\" + Logopath))
                {
                    swriter.WriteLine("<table align='center' width=500px;border:1px;border-collapse:collapse;'>");
                    swriter.WriteLine("<tr>");
                    swriter.WriteLine("<td width=100px; height=85px; rowSpan=4><img src='" + Apppath + "\\" + Logopath + "' width='77' height='78' style='width:100px; hwight:100px;' ></td>");
                    swriter.WriteLine("<td align='left' width='488' height='25px';><FONT COLOR='black' FACE='segoe UI' SIZE=4><b>" + str_name + "</b></FONT></td> ");
                    swriter.WriteLine("<tr><td align='left' ><FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_street_address + "</FONT></td></tr>");
                    swriter.WriteLine("<tr><td align='left' ><FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_email + "</FONT></td>");
                    swriter.WriteLine("<tr><td align='left' ><FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_contact_no + "</FONT></td>");
                    swriter.WriteLine("<tr><td colspan='2'; align='left'><hr></td></tr>");
                    swriter.WriteLine("</table>");
                }
                else
                {
                    swriter.WriteLine("<table align='center' style='width:500px;border:1px;border-collapse:collapse;'>");
                    swriter.WriteLine("<tr>");
                    swriter.WriteLine("<td align='left'> <FONT COLOR='black' FACE='segoe UI' SIZE=4><b>" + str_name + "</b></FONT></td>");
                    swriter.WriteLine("</tr>");
                    swriter.WriteLine("<tr>");
                    swriter.WriteLine("<td align='left'> <FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_street_address + "</FONT></td>");
                    swriter.WriteLine("</tr>");
                    swriter.WriteLine("<tr>");
                    swriter.WriteLine("<td align='left'> <FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_locality + "</FONT></td>");
                    swriter.WriteLine("</tr>");
                    swriter.WriteLine("<tr>");
                    swriter.WriteLine("<td align='left'> <FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_email + "</FONT></td>");
                    swriter.WriteLine("</tr>");
                    swriter.WriteLine("<tr>");
                    swriter.WriteLine("<td align='left'> <FONT COLOR='black' FACE='segoe UI' SIZE=2>" + str_contact_no + "</FONT></td>");
                    swriter.WriteLine("</tr>");
                    swriter.WriteLine("<tr><td colspan='2'; align='left'><hr></td></tr>");
                    swriter.WriteLine("</table>");
                }
                swriter.WriteLine("<table align='center' width='500'>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td colspan=2> <center> <FONT Color=black face='Segoe UI' SIZE=3> <b>ADVANCE RECEIPT VOUCHER</b></FONT></center></td>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("</table>");
                swriter.WriteLine("<br>");
                swriter.WriteLine("<table align='center' width='500'>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td align='left'><FONT COLOR ='black' FACE='segoe UI' SIZE=2>Patient Name : <b>" + PatName + "</b></FONT></td>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td align='left'><FONT COLOR='black' FACE='segoe UI' SIZE=2>Patient Id : <b>" + patiID + "</b></FONT></td>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td align='left'><FONT COLOR='black' FACE='segoe UI' SIZE=2>Address : <b>" + address + "</b></FONT></td>");
                swriter.WriteLine("<td align='right'><FONT COLOR ='black' FACE='segoe UI' SIZE=2>Date: " + DateTime.Now.Date.ToShortDateString() + "</FONT></td>");
                swriter.WriteLine("</tr >");
                swriter.WriteLine("<tr><td colspan='2'; align='left'><hr></td></tr>");
                swriter.WriteLine("</table>");
                swriter.WriteLine("<table align='center' border='1' width='500' >");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<th width='44' ><FONT COLOR ='black' FACE='segoe UI' SIZE=3>SlNO</FONT></th>");
                swriter.WriteLine("<th width='329'><FONT COLOR ='black' FACE='segoe UI' SIZE=3>Details</FONT></th>");
                swriter.WriteLine("<th width='105'><FONT COLOR ='black' FACE='segoe UI' SIZE=3>Amount</FONT></th>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td height='200' valign='top'Halign=><FONT COLOR ='black' FACE='segoe UI' SIZE=2>  <span style='float:left'>" + 1 + "</span></FONT></td>");
                swriter.WriteLine("<td height='200'valign='top' Halign='center'><FONT COLOR ='black' FACE='segoe UI' SIZE=2> <span style='float:left'> Advance Amount</span></FONT></td>");
                swriter.WriteLine("<td height='200'valign='top' ><FONT COLOR ='black' FACE='segoe UI' SIZE=2> <span style='float:right'>Rs." + Convert.ToDecimal(total).ToString("#0.00") + "</span></FONT></td>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td colspan=2 align='right'><FONT COLOR ='black' FACE='segoe UI' SIZE=2>Total:</FONT></td>");
                swriter.WriteLine("<td colspan=1 align='right'><FONT COLOR ='black' FACE='segoe UI' SIZE=2><b>" + Convert.ToDecimal(total).ToString("#0.00") + "</b></FONT></td>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("<tr><td colspan='3'  align='right'><FONT COLOR ='black' FACE='segoe UI' SIZE=2>(" + NumWordsWrapper(double.Parse(total.ToString())) + ")</FONT></td></tr>");
                swriter.WriteLine("</table>");
                swriter.WriteLine("<br>");
                swriter.WriteLine("<table align='center'  style='width:500px; border:1px;border-collaspe:collapse;'>");
                swriter.WriteLine("<tr>");
                swriter.WriteLine("<td colspan='2'  align='right'><FONT COLOR ='black' FACE='segoe UI' SIZE=2><b>Signature</b></FONT></td>");
                swriter.WriteLine("</tr>");
                swriter.WriteLine("</table>");
                swriter.WriteLine("</body>");
                swriter.WriteLine("</Html>");
                swriter.Close();
                System.Diagnostics.Process.Start(Apppath + "\\AdvancePaymentReceipt.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured!..please try again later..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string[] suffixesArr = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
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
