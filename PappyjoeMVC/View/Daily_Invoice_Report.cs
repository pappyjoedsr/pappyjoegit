﻿using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Daily_Invoice_Report : Form
    {
        public Daily_Invoice_Report()
        {
            InitializeComponent();
        }
        public DateTime date;
        public int invcount, slno = 1, c = 0;
        public string drid, patient_id = "", select_dr_id = "", dte;
        string strclinicname = "", strStreet = "", stremail = "", strwebsite = "", strphone = "", clinicn = "", PathName = "", logo_name = "";
        public decimal totalcost, totalpay, totalpaid, totalinvoice = 0, credit, balance, balance1, totalcredit = 0, totalpayment = 0;
        Daily_Invoice_Report_controller ctrlr = new Daily_Invoice_Report_controller();
        public void getinvoice(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count == 0)
                {
                    int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                    label_empty.Location = new Point(x, label_empty.Location.Y);
                    label_empty.Show();
                }
                else
                {
                    label_empty.Hide();
                    for (int z = 0; z < invMain.Rows.Count; z++)
                    {
                        string Patient = invMain.Rows[z]["pt_name"].ToString();
                        string date = invMain.Rows[z]["date"].ToString();
                        DateTime d = Convert.ToDateTime(date);
                        string day = d.Day.ToString();
                        string year = d.Year.ToString();
                        string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Month);
                        string sr = d.Month.ToString();
                        string invoiceno = invMain.Rows[z]["invoice_no"].ToString();
                        string details = invMain.Rows[z]["services"].ToString() + " (Qty:" + invMain.Rows[z]["unit"].ToString() + ")";
                        decimal cost = decimal.Parse(invMain.Rows[z]["cost"].ToString());
                        decimal unit = decimal.Parse(invMain.Rows[z]["unit"].ToString());
                        decimal discount = decimal.Parse(invMain.Rows[z]["discountin_rs"].ToString());
                        decimal tax = decimal.Parse(invMain.Rows[z]["tax_inrs"].ToString());
                        string doctor = combodoctors.SelectedItem.ToString();
                        credit = (cost * unit) - (tax + discount);
                        totalcredit = totalcredit + credit;
                        totalinvoice = totalinvoice + credit;
                        Grvsummary.Rows.Add(slno, Patient, invoiceno, " ", details, doctor,"", String.Format("{0:C}", credit), "0.00", String.Format("{0:C}", totalcredit));
                        Grvsummary.Rows[z].Cells[1].Style.ForeColor = Color.Blue;
                        Grvsummary.Rows[z].Cells[7].Style.ForeColor = Color.Blue;
                        Grvsummary.Rows[z].Cells[9].Style.ForeColor = Color.Red;
                        Grvsummary.Rows[z].Cells[9].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                        slno = slno + 1;
                        invcount = invMain.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void getinvoice2(DataTable invMain)
        {
            try
            {
                if (invMain.Rows.Count == 0)
                {
                    int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                    label_empty.Location = new Point(x, label_empty.Location.Y);
                    label_empty.Show();
                }
                else
                {
                    label_empty.Hide();
                    for (int z = 0; z < invMain.Rows.Count; z++)
                    {
                        string Patient = invMain.Rows[z]["pt_name"].ToString();
                        string date = invMain.Rows[z]["date"].ToString();
                        DateTime d = Convert.ToDateTime(date);
                        string day = d.Day.ToString();
                        string year = d.Year.ToString();
                        string strMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Month);
                        string sr = d.Month.ToString();
                        string invoiceno = invMain.Rows[z]["invoice_no"].ToString();
                        string details = invMain.Rows[z]["services"].ToString() + " (Qty:" + invMain.Rows[z]["unit"].ToString() + ")";
                        decimal cost = decimal.Parse(invMain.Rows[z]["cost"].ToString());
                        decimal unit = decimal.Parse(invMain.Rows[z]["unit"].ToString());
                        decimal discount = decimal.Parse(invMain.Rows[z]["discountin_rs"].ToString());
                        decimal tax = decimal.Parse(invMain.Rows[z]["tax_inrs"].ToString());
                        string doctor = combodoctors.SelectedItem.ToString();
                        credit = (cost * unit) - (tax + discount);
                        totalcredit = totalcredit + credit;
                        totalinvoice = totalinvoice + credit;
                        Grvsummary.Rows.Add(slno, Patient, invoiceno, " ", details, doctor,"", String.Format("{0:C}", credit), "0.00", String.Format("{0:C}", totalcredit));
                        Grvsummary.Rows[z].Cells[1].Style.ForeColor = Color.Blue;
                        Grvsummary.Rows[z].Cells[7].Style.ForeColor = Color.Blue;
                        Grvsummary.Rows[z].Cells[9].Style.ForeColor = Color.Red;
                        Grvsummary.Rows[z].Cells[9].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                        slno = slno + 1;
                        invcount = invMain.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getpay(DataTable payMain)
        {
            try
            {
                decimal cash = 0, cheque = 0, card = 0, dd = 0, PayTM=0,Tez=0, UPI=0,NEFT=0,IMPS=0,Netbanking=0, Wallets=0,CCAvenue=0;
                for (int u = 0; u < payMain.Rows.Count; u++)
                {
                   
                    string Patient = payMain.Rows[u]["pt_name"].ToString();
                    string Patient_id = payMain.Rows[u]["pt_id"].ToString();
                    string recpno = payMain.Rows[u]["receipt_no"].ToString();
                    string date = payMain.Rows[u]["payment_date"].ToString();
                    string details = payMain.Rows[u]["procedure_name"].ToString();// +" (Qty:" + invMain.Rows[u]["unit"].ToString() + ")";
                    string doctor = payMain.Rows[u]["doctor_name"].ToString();
                    string mode = payMain.Rows[u]["mode_of_payment"].ToString();
                    DateTime d = Convert.ToDateTime(date);
                    string day = d.Day.ToString();
                    string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Month);
                    string year = d.Year.ToString();
                    string invoiceno = payMain.Rows[u]["invoice_no"].ToString();
                    string[] invoice1 = new string[100];
                    invoice1 = invoiceno.Split(',');
                    decimal total = Convert.ToDecimal(payMain.Rows[u]["amount_paid"].ToString());
                    totalpayment = totalpayment + total;
                    balance1 = Convert.ToDecimal(payMain.Rows[u]["total"].ToString());
                    balance = totalinvoice - totalpayment;
                    
                    Grvsummary.Rows.Add(slno, Patient, invoiceno, recpno, details, doctor, mode, "0.00", Convert.ToDecimal(total).ToString("#0.00"), Convert.ToDecimal(balance).ToString("#0.00"));
                    if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value!=null && Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString()!="")
                    {
                        if(Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString()== "Cash")
                        {
                            cash = cash + Convert.ToDecimal(total);
                        }
                        else if(Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Cheque")
                        {
                            cheque= cheque+ Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Card")
                        {
                            card = card + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "DD")
                        {
                            dd = dd + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "PayTM")
                        {
                            PayTM = PayTM + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Tez")
                        {
                            Tez = Tez + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "UPI")
                        {
                            UPI = UPI + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "NEFT/RTGS/IMPS")
                        {
                            NEFT = NEFT + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Netbanking")
                        {
                            Netbanking = Netbanking + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Wallets")
                        {
                            Wallets = Wallets + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "CCAvenue")
                        {
                            CCAvenue = CCAvenue + Convert.ToDecimal(total);
                        }
                    }
                        Grvsummary.Rows[invcount + u].Cells[9].Style.ForeColor = Color.Red;
                    Grvsummary.Rows[invcount + u].Cells[8].Style.ForeColor = Color.ForestGreen;
                    Grvsummary.Rows[invcount + u].Cells[9].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    Grvsummary.Rows[invcount + u].Cells[1].Style.ForeColor = Color.ForestGreen;
                    slno = slno + 1;
                }

                int rowcount = 0;
                //Grvsummary.Rows[rowcount-1].Cells["TOTAL_COST"].Value = "SUBTOTAL";
                Grvsummary.Rows.Add("", "", "", "", "", "", "", "SUBTOTAL", "", "");
                rowcount = Grvsummary.Rows.Count;
                Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.ForestGreen;
                Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);

                if (cash>0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Cash", Convert.ToDecimal(cash).ToString("#0.00") , "");
                    rowcount= Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (cheque>0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Cheque", Convert.ToDecimal(cheque).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (card > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Card", Convert.ToDecimal(card).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (dd > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Demand Draft", Convert.ToDecimal(dd).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (PayTM > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "PayTM", Convert.ToDecimal(PayTM).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Tez > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Tez", Convert.ToDecimal(Tez).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (NEFT > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "NEFT/RTGS/IMPS", Convert.ToDecimal(NEFT).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Netbanking > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Netbanking", Convert.ToDecimal(Netbanking).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Wallets > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Wallets", Convert.ToDecimal(Wallets).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (CCAvenue > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "CCAvenue", Convert.ToDecimal(CCAvenue).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (UPI > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "UPI", Convert.ToDecimal(UPI).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getpay2(DataTable payMain)
        {
            try
            {
                decimal cash = 0, cheque = 0, card = 0, dd = 0 , PayTM = 0,Tez = 0, UPI = 0,NEFT = 0,Netbanking = 0, Wallets = 0,CCAvenue = 0; ;
                for (int u = 0; u < payMain.Rows.Count; u++)
                {
                    string Patient = payMain.Rows[u]["pt_name"].ToString();
                    string Patient_id = payMain.Rows[u]["pt_id"].ToString();
                    string recpno = payMain.Rows[u]["receipt_no"].ToString();
                    string date = payMain.Rows[u]["payment_date"].ToString();
                    string details = payMain.Rows[u]["procedure_name"].ToString();// +" (Qty:" + invMain.Rows[u]["unit"].ToString() + ")";
                    string doctor = payMain.Rows[u]["doctor_name"].ToString();
                    string mode = payMain.Rows[u]["mode_of_payment"].ToString();
                    DateTime d = Convert.ToDateTime(date);
                    string day = d.Day.ToString();
                    string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Month);
                    string year = d.Year.ToString();
                    string invoiceno = payMain.Rows[u]["invoice_no"].ToString();
                    string[] invoice1 = new string[100];
                    invoice1 = invoiceno.Split(',');
                    decimal total = Convert.ToDecimal(payMain.Rows[u]["amount_paid"].ToString());
                    totalpayment = totalpayment + total;
                    balance1 = Convert.ToDecimal(payMain.Rows[u]["total"].ToString());
                    balance = totalinvoice - totalpayment;
                    Grvsummary.Rows.Add(slno, Patient, invoiceno, recpno, details, doctor, mode, "0.00", Convert.ToDecimal(total).ToString("#0.00"), Convert.ToDecimal(balance1).ToString("#0.00"));
                    if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value != null && Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() != "")
                    {
                        if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Cash")
                        {
                            cash = cash + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Cheque")
                        {
                            cheque = cheque + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Card")
                        {
                            card = card + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "DD")
                        {
                            dd = dd + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "PayTM")
                        {
                            PayTM = PayTM + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Tez")
                        {
                            Tez = Tez + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "UPI")
                        {
                            UPI = UPI + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "NEFT/RTGS/IMPS")
                        {
                            NEFT = NEFT + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Netbanking")
                        {
                            Netbanking = Netbanking + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "Wallets")
                        {
                            Wallets = Wallets + Convert.ToDecimal(total);
                        }
                        else if (Grvsummary.Rows[invcount + u].Cells["modeofpayment"].Value.ToString() == "CCAvenue")
                        {
                            CCAvenue = CCAvenue + Convert.ToDecimal(total);
                        }
                    }
                    Grvsummary.Rows[invcount + u].Cells[9].Style.ForeColor = Color.Red;
                    Grvsummary.Rows[invcount + u].Cells[8].Style.ForeColor = Color.ForestGreen;
                    Grvsummary.Rows[invcount + u].Cells[9].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Regular);
                    Grvsummary.Rows[invcount + u].Cells[1].Style.ForeColor = Color.ForestGreen;
                    slno = slno + 1;
                }
                int rowcount = 0;
                //Grvsummary.Rows[rowcount-1].Cells["TOTAL_COST"].Value = "SUBTOTAL";
                Grvsummary.Rows.Add("", "", "", "", "", "", "", "SUBTOTAL", "", "");
                rowcount = Grvsummary.Rows.Count;
                Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.ForestGreen;
                Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);

                if (cash > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Cash", Convert.ToDecimal(cash).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (cheque > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Cheque", Convert.ToDecimal(cheque).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (card > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Card", Convert.ToDecimal(card).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (dd > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Demand Draft", Convert.ToDecimal(dd).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (PayTM > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "PayTM", Convert.ToDecimal(PayTM).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Tez > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Tez", Convert.ToDecimal(Tez).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (NEFT > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "NEFT/RTGS/IMPS", Convert.ToDecimal(NEFT).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Netbanking > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Netbanking", Convert.ToDecimal(Netbanking).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (Wallets > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "Wallets", Convert.ToDecimal(Wallets).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (CCAvenue > 0) 
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "CCAvenue", Convert.ToDecimal(CCAvenue).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                if (UPI > 0)
                {
                    Grvsummary.Rows.Add("", "", "", "", "", "", "", "UPI", Convert.ToDecimal(UPI).ToString("#0.00"), "");
                    rowcount = Grvsummary.Rows.Count;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.ForeColor = Color.DarkSlateGray;
                    Grvsummary.Rows[rowcount - 1].Cells["TOTAL_COST"].Style.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Daily_Invoice_Report_Load(object sender, EventArgs e)
        {
            try
            {
                Grvsummary.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                Grvsummary.EnableHeadersVisualStyles = false;
                this.Grvsummary.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                Grvsummary.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                Grvsummary.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                combodoctors.Items.Add("All Doctors");
                combodoctors.ValueMember = "0";
                combodoctors.DisplayMember = "All Doctors";
                DataTable doctor_rs = this.ctrlr.getdocname();
                if (doctor_rs.Rows.Count > 0)
                {
                    for (int i = 0; i < doctor_rs.Rows.Count; i++)
                    {
                        combodoctors.Items.Add(doctor_rs.Rows[i]["doctor_name"].ToString());
                        combodoctors.ValueMember = doctor_rs.Rows[i]["id"].ToString();
                        combodoctors.DisplayMember = doctor_rs.Rows[i]["doctor_name"].ToString();
                    }
                }
                combodoctors.SelectedIndex = 0;
                select_dr_id = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void combodoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dte = dateTimePickerdaily1.Text;
                Grvsummary.Rows.Clear();
                select_dr_id = "0";
                if (combodoctors.SelectedIndex == -1) { }
                else
                {
                    drid = combodoctors.SelectedItem.ToString();
                    select_dr_id = this.ctrlr.Get_DoctorId(drid);
                }
                Grvsummary.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grvsummary.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grvsummary.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grvsummary.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grvsummary.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grvsummary.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                foreach (DataGridViewColumn cl in Grvsummary.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                    cl.Width = 140;
                }
                if (select_dr_id == "0")
                {
                    DataTable inv = this.ctrlr.getinvoice(dateTimePickerdaily1.Text);
                    getinvoice(inv);
                    DataTable pay = this.ctrlr.getpay(dateTimePickerdaily1.Text);
                    getpay(pay);
                }
                else
                {
                    DataTable inv2 = this.ctrlr.getinvoice2(dateTimePickerdaily1.Text, select_dr_id);
                    getinvoice2(inv2);
                    DataTable pay2 = this.ctrlr.getpay2(dateTimePickerdaily1.Text, select_dr_id);
                    getpay2(pay2);
                }
                if (Grvsummary.Rows.Count == 0)
                {
                    int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                    label_empty.Location = new Point(x, label_empty.Location.Y);
                    label_empty.Show();
                    lbltotal1.Text = "00.00";
                    lbltotal2.Text = "00.00";
                    lbltotal3.Text = "00.00";
                    totalpayment = 0;
                    totalcredit = 0;
                    balance = 0;
                    totalinvoice = 0;
                }
                else
                {
                    label_empty.Hide();
                    lbltotal1.Text = Convert.ToDecimal(totalinvoice).ToString("#0.00");
                    lbltotal2.Text = Convert.ToDecimal(totalpayment).ToString("#0.00");
                    lbltotal3.Text = Convert.ToDecimal(balance).ToString("#0.00");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            try
            {
                    lbltotal1.Text = "00.00";
                    lbltotal2.Text = "00.00";
                    lbltotal3.Text = "00.00";
                    combodoctors_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                lbltotal1.Text = "00.00";
                lbltotal2.Text = "00.00";
                lbltotal3.Text = "00.00";
                { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void btnEXPORT_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grvsummary.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xml)|*.xml";
                    saveFileDialog1.FileName = "Daily Summary(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xml";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = Grvsummary.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count]].Merge();
                        ExcelApp.Cells[1, 1] = "DAILY SUMMARY";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "Report Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimePickerdaily1.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "Running Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        for (int i = 1; i < Grvsummary.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[4, i] = Grvsummary.Columns[i - 1].HeaderText;
                            ExcelApp.Cells[4, i].ColumnWidth = 25;
                            ExcelApp.Cells[4, i].EntireRow.Font.Bold = true;
                            ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                            ExcelApp.Cells[4, i].Font.Size = 10;
                            ExcelApp.Cells[4, i].Font.Name = "Segoe UI";
                            ExcelApp.Cells[4, i].Font.Color = Color.FromArgb(255, 255, 255);
                            ExcelApp.Cells[4, i].Interior.Color = Color.FromArgb(0, 102, 204);
                        }
                        for (int i = 0; i <= Grvsummary.Rows.Count; i++)
                        {
                            try
                            {
                                for (int j = 0; j < Grvsummary.Columns.Count; j++)
                                {
                                    ExcelApp.Cells[i + 5, j + 1] = Grvsummary.Rows[i].Cells[j].Value.ToString();
                                    ExcelApp.Cells[i + 5, j + 1].BorderAround(true);
                                    ExcelApp.Cells[i + 5, j + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                    ExcelApp.Cells[i + 5, j + 1].Font.Size = 8;
                                }
                            }
                            catch { }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        MessageBox.Show("Successfully Exported to Excel,", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("No records found,please change the date and try again!..", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Grvsummary_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            base.OnClick(e);
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                if (Grvsummary.Rows.Count > 0)
                {
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        DataTable dt = this.ctrlr.practicedetails();
                        if (dt.Rows.Count > 0)
                        {
                            clinicn = dt.Rows[0]["name"].ToString();
                            strclinicname = clinicn.Replace("¤", "'");
                            strphone = dt.Rows[0]["contact_no"].ToString();
                            strStreet = dt.Rows[0]["street_address"].ToString();
                            stremail = dt.Rows[0]["email"].ToString();
                            strwebsite = dt.Rows[0]["website"].ToString();
                            logo_name= dt.Rows[0]["path"].ToString();
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    StreamWriter sWrite = new StreamWriter(Apppath + "\\DailyInvoiceReport.html");
                    sWrite.WriteLine("<html>");
                    sWrite.WriteLine("<head>");
                    sWrite.WriteLine("<style>");
                    sWrite.WriteLine("table { border-collapse: collapse;}");
                    sWrite.WriteLine("p.big {line-height: 400%;}");
                    sWrite.WriteLine("</style>");
                    sWrite.WriteLine("</head>");
                    sWrite.WriteLine("<body >");
                    sWrite.WriteLine("<div>");
                    sWrite.WriteLine("<table align=center width=900>");
                    sWrite.WriteLine("<col >");
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

                        //sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                        sWrite.WriteLine("</table>");
                    }
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                    if (combodoctors.SelectedIndex == 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3>DAILY INVOICE REPORT (All Doctor) </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    if (combodoctors.SelectedIndex != 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> DAILY INVOICE REPORT (" + combodoctors.Text + ")  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    sWrite.WriteLine("<br>");
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=8 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Date :</b>  " + dateTimePickerdaily1.Value.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td colspan=7 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> Printed Date :</b> " + DateTime.Now.ToString("dd/MM/yyyy") + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (combodoctors.SelectedIndex != 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=8 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2> Doctor:  " + combodoctors.Text + " </font></td>");
                        sWrite.WriteLine("</tr>");
                    }
                    DataTable invMain = new DataTable();
                    DataTable payMain = new DataTable();
                    int ROWCOUNT = 0;
                    if (Grvsummary.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>&nbsp;Slno.</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='18%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><b>Patient Name</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Invoice No</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='15%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Receipt No</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Product and Service</b></font></td>");
                        sWrite.WriteLine("    <td align='left' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Doctor</b></font></td>");
                        sWrite.WriteLine("    <td align='right' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Mode of payment</b></font></td>");
                        sWrite.WriteLine("    <td align='right' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Invoice</b></font></td>");
                        sWrite.WriteLine("    <td align='right ' width='10%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Receipt</b></font></td>");
                        sWrite.WriteLine("    <td align='right' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Amount Due</b></font></td>");
                        sWrite.WriteLine("</tr>");
                        while (c < Grvsummary.Rows.Count)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvsummary.Rows[c].Cells["SL_NO"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvsummary.Rows[c].Cells["PATIENT_NAME"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvsummary.Rows[c].Cells["INVOICE"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvsummary.Rows[c].Cells["RECEIPT"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvsummary.Rows[c].Cells["PRODUCT_AND_SERVICE"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + Grvsummary.Rows[c].Cells["Doctor_name"].Value.ToString() + "</font></td>");
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Grvsummary.Rows[c].Cells["modeofpayment"].Value.ToString() + "&nbsp;</font></td>");
                            if (Grvsummary.Rows[c].Cells["TOTALINCOME"].Value.ToString() == "")
                            {
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>" + Grvsummary.Rows[c].Cells["TOTAL_COST"].Value.ToString() + "&nbsp;</b></font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>" + Grvsummary.Rows[c].Cells["TOTALINCOME"].Value.ToString() + "&nbsp;</b></font></td>");
                            }
                            else
                            {
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Grvsummary.Rows[c].Cells["TOTAL_COST"].Value.ToString() + "&nbsp;</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Grvsummary.Rows[c].Cells["TOTALINCOME"].Value.ToString() + "&nbsp;</font></td>");
                            }
                            sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Grvsummary.Rows[c].Cells["TOTAL_AMOUT_DUE"].Value.ToString() + "&nbsp;</font></td>");
                            sWrite.WriteLine("</tr>");
                           
                            c++;
                        }
                        string cost = "";
                        string payment = "";
                        string due = "";
                        c = 0;
                        cost = lbltotal1.Text;
                        payment = lbltotal2.Text;
                        due = lbltotal3.Text;
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Total</b></font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + cost + "</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + payment + "</b>&nbsp;</font></td>");
                        sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + due + "</b>&nbsp;</font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("</table>");
                        sWrite.WriteLine("</div>");
                        sWrite.WriteLine("<script>window.print();</script>");
                        sWrite.WriteLine("</body>");
                        sWrite.WriteLine("</html>");
                        sWrite.Close();
                        System.Diagnostics.Process.Start(Apppath + "\\DailyInvoiceReport.html");
                    }
                }
                else
                { MessageBox.Show("No Record Found,Please change the date and try again !..", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Grvsummary_DataSourceChanged(object sender, EventArgs e)
        {
            int[] values = new int[this.Grvsummary.Rows.Count];
            int totals = 0;
            for (int index = 0; index < this.Grvsummary.Rows.Count - 1; index++)
            {
                values[index] = int.Parse(Grvsummary.Rows[index].Cells[1].Value.ToString());
                totals = totals + values[index];
                lbltotal2.Text = totals.ToString();
            }
        }
    }
}
