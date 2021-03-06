﻿using PappyjoeMVC.Controller;
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
    public partial class Doctor_Wise_Receipt : Form
    {
        public Doctor_Wise_Receipt()
        {
            InitializeComponent();
        }
        public static string qty = "";
        Doctor_Wise_Receipt_controller ctrlr=new Doctor_Wise_Receipt_controller();
        decimal tax = 0, discount = 0,totlcost=0, amount = 0, paid = 0, due = 0,Totaltax = 0, Totaldiscount = 0, Totalamount = 0, Totalpaid = 0, Totaldue = 0;
        public string doctor_id = "",doc_id, service, date1, date2, checkStr = "0", PathName = "", strclinicname = "", clinicn = "", strStreet = "", stremail = "", strwebsite = "", strphone = "",logo_name="";
        private void Doctor_Wise_Receipt_Load(object sender, EventArgs e)
        {
            combo_doctors.Items.Add("All Doctor");
            combo_doctors.ValueMember = "0";
            combo_doctors.DisplayMember = "All Doctor";
            DataTable doctor_rs=this.ctrlr.getdocname();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        combo_doctors.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        combo_doctors.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        combo_doctors.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
            combo_doctors.SelectedIndex = 0;
            label_empty.Hide();
            dtp1ReceptReceivedPerDoctor1.MaxDate = DateTime.Now;
            dtp1ReceptReceivedPerDoctor2.MaxDate = DateTime.Now;
            DateTime now = DateTime.Now;
            string d1 = dtp1ReceptReceivedPerDoctor1.Value.ToString("yyyy-MM-dd");
            string d2 = dtp1ReceptReceivedPerDoctor2.Value.ToString("yyyy-MM-dd");
            receiptReceivedLoad();
            DgvReceiptReceivedPerDoctor.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvReceiptReceivedPerDoctor.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgvReceiptReceivedPerDoctor.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            foreach (DataGridViewColumn cl in DgvReceiptReceivedPerDoctor.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                //cl.Width = 100;
            }
        }
        public void receiptReceivedLoad()
        {
            DgvReceiptReceivedPerDoctor.Rows.Clear();
            DgvReceiptReceivedPerDoctor.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            DgvReceiptReceivedPerDoctor.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DgvReceiptReceivedPerDoctor.EnableHeadersVisualStyles = false;
            string doctor = combo_doctors.Text;
            if (doctor != "All Doctor")
            {
                doc_id =this.ctrlr.getdocid(doctor);
            }
            else
            { doc_id = "0"; }
            DataTable dtp = new DataTable();
            date1 = dtp1ReceptReceivedPerDoctor1.Value.ToString("yyyy-MM-dd");
            date2 = dtp1ReceptReceivedPerDoctor2.Value.ToString("yyyy-MM-dd");
            if (doc_id == "0")
            {
               DataTable dt1= this.ctrlr.mnthrcpt(date1,date2);
               mnthrcpt(dt1);
            }
            else
            {
                DataTable dt2=this.ctrlr.mnthrcpt2(date1,date2,doc_id);
                mnthrcpt(dt2);
            }
        }
        public void mnthrcpt(DataTable dtp)
        {
            if (dtp.Rows.Count == 0)
            {
                label4.Text = "0";
                Lab_Discount.Text = "0.00";
                Lab_tax.Text = "0.00";
                Lab_Amount.Text = "0.00";
                Lab_Paid.Text = "0.00";
                Lab_Due.Text = "0.00";
                int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                label_empty.Location = new Point(x, label_empty.Location.Y);
                label_empty.Show();
            }
            else
            {
                label4.Text = dtp.Rows.Count.ToString();
                label_empty.Hide();
                fillDGV_Receipt(dtp, date1, date2);
            }
        }
        public void fillDGV_Receipt(DataTable dtb_Receipt, string d1, string d2)
        {
            try {
                DgvReceiptReceivedPerDoctor.RowCount = 0;
                if (dtb_Receipt.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb_Receipt.Rows.Count; i++)
                    {
                        tax = 0; discount = 0; amount = 0; paid = 0; due = 0;
                        Totaltax = 0; Totaldiscount = 0; Totalamount = 0; Totalpaid = 0; Totaldue = 0;
                        DgvReceiptReceivedPerDoctor.Rows.Add();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["slno"].Value = i + 1;
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["Patient_name"].Value = dtb_Receipt.Rows[i]["pt_name"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["invoice_no"].Value = dtb_Receipt.Rows[i]["invoice_no"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["recept_No"].Value = dtb_Receipt.Rows[i]["receipt_no"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["amount_paid"].Value = dtb_Receipt.Rows[i]["amount_paid"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["amount_due"].Value = dtb_Receipt.Rows[i]["DUE AFTER PAYMENT"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["mode_of_payment"].Value = dtb_Receipt.Rows[i]["mode_of_payment"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["Payment_date"].Value = Convert.ToDateTime(dtb_Receipt.Rows[i]["payment_date"].ToString()).ToString("dd/MM/yyyy");
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["doctor_name"].Value = dtb_Receipt.Rows[i]["doctor_name"].ToString();
                        DataTable dtb=this.ctrlr.getinvdata(dtb_Receipt.Rows[i]["invoice_no"].ToString(), dtb_Receipt.Rows[i]["procedure_name"].ToString());
                        getinvdata(dtb);
                        service = dtb_Receipt.Rows[i]["procedure_name"].ToString();
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["procedure_name"].Value = service + " (Qty:" + qty + ")";
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["cost"].Value = totlcost;
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["Discount_insr"].Value = discount;
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["tax_inrs"].Value = tax;
                        DgvReceiptReceivedPerDoctor.Rows[i].Cells["income"].Value = amount;
                        due = decimal.Parse(dtb_Receipt.Rows[i]["DUE AFTER PAYMENT"].ToString());
                        paid = decimal.Parse(dtb_Receipt.Rows[i]["amount_paid"].ToString());
                    }
                    for (int j = 0; j < DgvReceiptReceivedPerDoctor.Rows.Count; j++)
                    {
                        Totaltax = Totaltax + Convert.ToDecimal(DgvReceiptReceivedPerDoctor.Rows[j].Cells["tax_inrs"].Value);
                        Totaldiscount = Totaldiscount + Convert.ToDecimal(DgvReceiptReceivedPerDoctor.Rows[j].Cells["Discount_insr"].Value);
                        Totalamount = Totalamount + Convert.ToDecimal(DgvReceiptReceivedPerDoctor.Rows[j].Cells["income"].Value);
                        Totalpaid = Totalpaid + Convert.ToDecimal(DgvReceiptReceivedPerDoctor.Rows[j].Cells["amount_paid"].Value);
                        Totaldue = Totaldue + Convert.ToDecimal(DgvReceiptReceivedPerDoctor.Rows[j].Cells["amount_due"].Value);
                    }
                    Lab_Discount.Text = Convert.ToDecimal(Totaldiscount).ToString("#0.00");
                    Lab_tax.Text = Convert.ToDecimal(Totaltax).ToString("#0.00");
                    Lab_Amount.Text = Convert.ToDecimal(Totalamount).ToString("#0.00");
                    Lab_Paid.Text = Convert.ToDecimal(Totalpaid).ToString("#0.00");
                    Lab_Due.Text = Convert.ToDecimal(Totaldue).ToString("#0.00");
                }
                else
                {
                    Lab_Discount.Text = "0.00";
                    Lab_tax.Text = "0.00";
                    Lab_Amount.Text = "0.00";
                    Lab_Paid.Text = "0.00";
                    Lab_Due.Text = "0.00";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getinvdata(DataTable dt_inv)
        {
            for (int i = 0; i < dt_inv.Rows.Count;i++ )
            {
                qty = dt_inv.Rows[0]["unit"].ToString();
                totlcost=Convert.ToDecimal(dt_inv.Rows[i]["Total Cost"].ToString());
                DgvReceiptReceivedPerDoctor.Rows[i].Cells["cost"].Value = dt_inv.Rows[i]["Total Cost"].ToString();
                if (dt_inv.Rows[i]["discountin_rs"].ToString() != "0")
                {
                    DgvReceiptReceivedPerDoctor.Rows[i].Cells["Discount_insr"].Value = dt_inv.Rows[i]["discountin_rs"].ToString();
                    discount = decimal.Parse(dt_inv.Rows[i]["discountin_rs"].ToString());
                }
                else
                {
                    DgvReceiptReceivedPerDoctor.Rows[i].Cells["Discount_insr"].Value = 0;
                    discount = 0;
                }
                DgvReceiptReceivedPerDoctor.Rows[i].Cells["tax_inrs"].Value = dt_inv.Rows[i]["tax_inrs"].ToString();
                DgvReceiptReceivedPerDoctor.Rows[i].Cells["income"].Value = dt_inv.Rows[i]["Total Income"].ToString();
                tax = decimal.Parse(dt_inv.Rows[i]["tax_inrs"].ToString());
                amount = decimal.Parse(dt_inv.Rows[i]["Total Income"].ToString());
            }
        }
        private void combo_doctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiptReceivedLoad();
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            receiptReceivedLoad();
        }
        private void combo_doctors_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            try { 
            if (DgvReceiptReceivedPerDoctor.Rows.Count > 0)
            {
                string today = DateTime.Now.ToString("dd/MM/yyyy");
                string message = "Did you want Header on Print?";
                string caption = "Verification";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    DataTable dtp=this.ctrlr.practicedetails();
                    if (dtp.Rows.Count > 0)
                    {
                       clinicn = dtp.Rows[0]["name"].ToString();
                       strclinicname = clinicn.Replace("¤", "'");
                       strphone = dtp.Rows[0]["contact_no"].ToString();
                       strStreet = dtp.Rows[0]["street_address"].ToString();
                       stremail = dtp.Rows[0]["email"].ToString();
                       strwebsite = dtp.Rows[0]["website"].ToString();
                       logo_name = dtp.Rows[0]["path"].ToString();
                        }
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\ReceiptReceivedPerDoctor.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("<style>");
                sWrite.WriteLine("table { border-collapse: collapse;}");
                sWrite.WriteLine("p.big {line-height: 400%;}");
                sWrite.WriteLine("</style>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<div>");
                sWrite.WriteLine("<table align=center width =900>");
                    sWrite.WriteLine("<col >");
                    sWrite.WriteLine("<br>");
                    string Appath = System.IO.Directory.GetCurrentDirectory();
                    if (File.Exists(Appath + "\\" + logo_name))
                    {
                        sWrite.WriteLine("<table align='center' style='width:800px;border: 1px ;border-collapse: collapse;'>");
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
                    sWrite.WriteLine("<table align='center' style='width:800px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> DOCTOR WISE RECEIPT  </font></center></b></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From:</b> " + dtp1ReceptReceivedPerDoctor1.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + dtp1ReceptReceivedPerDoctor2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></center></td>");
                    sWrite.WriteLine("</tr>");
                    if (DgvReceiptReceivedPerDoctor.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='4%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>&nbsp;Slno.</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Patient</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Invoice</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Receipt</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Doctor</b> </font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Procedure</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Date</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Mode of payment</b></font></td>");
                        sWrite.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Cost</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Tax</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Discount</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Income</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount Paid</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount Due</b>&nbsp;</font></td>");
                        sWrite.WriteLine("</tr>");
                        int k = 1;
                        try
                        {
                            for (int j = 0; j < DgvReceiptReceivedPerDoctor.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + k + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["Patient_name"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["invoice_no"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["recept_No"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["doctor_name"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["procedure_name"].Value.ToString() + qty + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["Payment_date"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["mode_of_payment"].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["cost"].Value.ToString() + "&nbsp;</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["tax_inrs"].Value.ToString() + "&nbsp;</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["Discount_insr"].Value.ToString() + "&nbsp;</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["income"].Value.ToString() + "&nbsp;</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["amount_paid"].Value.ToString() + "&nbsp;</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + DgvReceiptReceivedPerDoctor.Rows[j].Cells["amount_due"].Value.ToString() + "&nbsp;</font></td>");
                                k = k + 1;
                                sWrite.WriteLine("</tr>");
                            }
                        }
                        catch { }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Total</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_tax.Text + "</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Discount.Text + "</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Amount.Text + "</b></font></td>");
                        sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Paid.Text + "</b></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Due.Text + "</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\ReceiptReceivedPerDoctor.html");
                    }
            }
            else
            { MessageBox.Show("No Record found,please change the date and try again!... ", "No data found", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Btn_Export_Click(object sender, EventArgs e)
        {
            try {
                if (DgvReceiptReceivedPerDoctor.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xls)|*.xls";
                    saveFileDialog1.FileName = "Doctor Wise Receipt Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xls";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = DgvReceiptReceivedPerDoctor.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "Doctor Wise Receipt ";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dtp1ReceptReceivedPerDoctor1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dtp1ReceptReceivedPerDoctor2.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        int j1 = 5;
                        for (int i = 1; i < DgvReceiptReceivedPerDoctor.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = DgvReceiptReceivedPerDoctor.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[5, i].ColumnWidth = 25;
                            ExcelApp.Cells[5, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[5, i].Font.Size = 10;
                            ExcelApp.Cells[5, i].Font.Name = "Arial";
                            ExcelApp.Cells[5, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[5, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= DgvReceiptReceivedPerDoctor.Rows.Count; i++)
                        {
                            try{
                                for (int j = 0; j < DgvReceiptReceivedPerDoctor.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 6, j + 1] = DgvReceiptReceivedPerDoctor.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 6, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 6, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 6, j + 1].Font.Size = 8;
                                }
                            }catch { }
                            j1 = j1 + 1;
                        }
                        ExcelApp.Cells[j1, 9] = "Total";
                        ExcelApp.Cells[j1, 9].BorderAround(true);
                        ExcelApp.Cells[j1, 9].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 9].Font.Size = 10;
                        ExcelApp.Cells[j1, 10] = Lab_tax.Text;
                        ExcelApp.Cells[j1, 10].BorderAround(true);
                        ExcelApp.Cells[j1, 10].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 10].Font.Size = 10;
                        ExcelApp.Cells[j1, 11] = Lab_Discount.Text;
                        ExcelApp.Cells[j1, 11].BorderAround(true);
                        ExcelApp.Cells[j1, 11].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 11].Font.Size = 10;
                        ExcelApp.Cells[j1, 12] = Lab_Amount.Text;
                        ExcelApp.Cells[j1, 12].BorderAround(true);
                        ExcelApp.Cells[j1, 12].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 12].Font.Size = 10;
                        ExcelApp.Cells[j1, 13] = Lab_Paid.Text;
                        ExcelApp.Cells[j1, 13].BorderAround(true);
                        ExcelApp.Cells[j1, 13].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 13].Font.Size = 10;
                        ExcelApp.Cells[j1, 14] = Lab_Due.Text;
                        ExcelApp.Cells[j1, 14].BorderAround(true);
                        ExcelApp.Cells[j1, 14].Borders.Color = Color.FromArgb(0, 102, 204);
                        ExcelApp.Cells[j1, 14].Font.Size = 10;
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        checkStr = "1";
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found ,Please change the date and try again!..", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
