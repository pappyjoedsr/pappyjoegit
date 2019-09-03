using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Group_wise_report : Form
    {
        Group_Wise_Report_controller cntrl=new Group_Wise_Report_controller();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public Group_wise_report()
        {
            InitializeComponent();
        }

        private void Group_wise_report_Load(object sender, EventArgs e)
        {
            fillCombo();
            cmb_type.SelectedIndex = 0;
            Fill_Grid();
            dgv_group.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_group.EnableHeadersVisualStyles = false;
            this.dgv_group.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgv_group.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn cl in dgv_group.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void fillCombo()
        {
            try
            {
                DataTable dtb = this.cntrl.dt_grp();
                if (dtb.Rows.Count > 0)
                {
                    cmb_group.DataSource = dtb;
                    cmb_group.ValueMember = "id";
                    cmb_group.DisplayMember = "name";
                    cmb_group.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public decimal balance;
        public decimal balance1;
        decimal totalpayment = 0; decimal totalcredit = 0;
        public decimal credit;
        decimal totalinvoice = 0;
        public void Fill_Grid()
        {
            try
            {
                if (cmb_group.Text != "")
                {
                    Lab_Discount.Visible = false; label4.Visible = false; Lab_cost.Visible = false;
                    Lab_tax.Visible = false;
                    Lab_Amount.Visible = false;
                    Lab_Paid.Visible = false;
                    Lab_Due.Visible = false; label9.Visible = false; label7.Visible = false;
                    label8.Visible = false; Lab_TotalIncome.Visible = false; Lab_totalExpense.Visible = false;
                    dgv_group.Rows.Clear();
                    dgv_group.ColumnCount = 0;
                    string date1 = dtp1GroupReport.Value.ToString("yyyy-MM-dd");
                    string date2 = dtp1groupreport2.Value.ToString("yyyy-MM-dd");
                    label_empty.Visible = false;
                    if (cmb_type.Text == "Patients")
                    {
                        DataTable d= this.cntrl.dtb_group(cmb_group.Text, date1, date2);
                        Patients(d);
                    }
                    else if (cmb_type.Text == "Procedure")
                    {
                        DataTable d= this.cntrl.dtb_procedure(cmb_group.Text, date1, date2);
                        Procedure(d);
                    }
                    else if (cmb_type.Text == "Invoice")
                    {
                        Lab_Discount.Visible = true;
                        Lab_tax.Visible = true;
                        Lab_Amount.Visible = true;
                        Lab_Paid.Visible = true;
                        Lab_Due.Visible = true;
                        label9.Visible = true;
                        label7.Visible = true;
                        label8.Visible = true;
                        label9.Text = "Total Cost";
                        Lab_TotalIncome.Visible = true;
                        Lab_totalExpense.Visible = true;
                        dgv_group.ColumnCount = 12;
                        dgv_group.Columns[0].HeaderText = "SLNO";
                        dgv_group.Columns[1].HeaderText = "PATIENT NAME";
                        dgv_group.Columns[2].HeaderText = "INVOICE";
                        dgv_group.Columns[3].HeaderText = "PROCEDURE";
                        dgv_group.Columns[4].HeaderText = "INVOICE DATE";
                        dgv_group.Columns[5].HeaderText = "DOCTOR";
                        dgv_group.Columns[6].HeaderText = "GROUP";
                        dgv_group.Columns[7].HeaderText = "COST";
                        dgv_group.Columns[8].HeaderText = "DISCOUNT";
                        dgv_group.Columns[9].HeaderText = "AMOUNT";
                        dgv_group.Columns[10].HeaderText = "TOTAL PAYMENT";
                        dgv_group.Columns[11].HeaderText = "TOTAL AMOUNT DUE";
                        dgv_group.Columns[0].Width = 40;
                        dgv_group.Columns[1].Width = 120;
                        dgv_group.Columns[2].Width = 60;
                        dgv_group.Columns[3].Width = 150;
                        dgv_group.Columns[4].Width = 80;
                        dgv_group.Columns[5].Width = 100;
                        dgv_group.Columns[6].Width = 120;
                        dgv_group.Columns[7].Width = 85;
                        dgv_group.Columns[8].Width = 80;
                        dgv_group.Columns[9].Width = 110;
                        dgv_group.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv_group.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv_group.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv_group.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv_group.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        dgv_group.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgv_group.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        DataTable d= this.cntrl.dtb_invoice(date1, date2, cmb_group.Text);
                        Invoice(d);
                    }
                    else if (cmb_type.Text == "Receipt")
                    {
                        Lab_Discount.Visible = true;
                        Lab_tax.Visible = true;
                        Lab_Amount.Visible = true;
                        Lab_Paid.Visible = true;
                        label9.Text = "Total Tax";
                        Lab_Due.Visible = true;
                        label9.Visible = true;
                        label7.Visible = true;
                        label8.Visible = true;
                        Lab_TotalIncome.Visible = true;
                        Lab_totalExpense.Visible = true;
                        label4.Visible = true;
                        Lab_cost.Visible = true;
                        DataTable d= this.cntrl.dtb_receipt(date1, date2, cmb_group.Text);
                        Receipt(d);
                    }
                }
                else
                {
                    Lab_cost.Text = "0.00";
                    Lab_Discount.Text = "0.00";
                    Lab_tax.Text = "0.00";
                    Lab_Amount.Text = "0.00";
                    Lab_Paid.Text = "0.00";
                    Lab_Due.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Patients(DataTable dtb_group)
        {
            if (dtb_group.Rows.Count > 0)
            {
                dgv_group.ColumnCount = 8;
                dgv_group.Columns[0].HeaderText = "SLNO";
                dgv_group.Columns[1].HeaderText = "DATE";
                dgv_group.Columns[2].HeaderText = "PATIENT ID";
                dgv_group.Columns[3].HeaderText = "PATIENT NAME";
                dgv_group.Columns[4].HeaderText = "MOBILE NO";
                dgv_group.Columns[5].HeaderText = "EMAIL";
                dgv_group.Columns[6].HeaderText = "DOCTOR";
                dgv_group.Columns[7].HeaderText = "GROUP";
                dgv_group.Columns[0].Width = 60;
                dgv_group.Columns[1].Width = 105;
                dgv_group.Columns[2].Width = 130;
                dgv_group.Columns[3].Width = 169;
                dgv_group.Columns[4].Width = 130;
                dgv_group.Columns[5].Width = 130;
                dgv_group.Columns[6].Width = 110;
                dgv_group.Columns[7].Width = 125;
                dgv_group.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_group.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_group.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_group.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_group.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgv_group.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                for (int z = 0; z < dtb_group.Rows.Count; z++)
                {
                    int sl_no = z + 1;
                    string date = Convert.ToDateTime(dtb_group.Rows[z]["date"].ToString()).ToString("yyyy-MM-dd");
                    string patient_id = dtb_group.Rows[z]["pt_id"].ToString();
                    string Patient_Name = dtb_group.Rows[z]["pt_name"].ToString();
                    string mobile = dtb_group.Rows[z]["primary_mobile_number"].ToString();
                    string email = dtb_group.Rows[z]["email_address"].ToString();
                    string doctor_name = dtb_group.Rows[z]["doctorname"].ToString();
                    string group = dtb_group.Rows[z]["group_id"].ToString();
                    dgv_group.Rows.Add(sl_no, date, patient_id, Patient_Name, mobile, email, doctor_name, group);
                }
                dgv_group.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                label_empty.Visible = true;
            }
        }
        public void Procedure(DataTable dtb_procedure)
        {
            if (dtb_procedure.Rows.Count > 0)
            {
                dgv_group.ColumnCount = 5;
                dgv_group.Columns[0].HeaderText = "SLNO";
                dgv_group.Columns[1].HeaderText = "DATE";
                dgv_group.Columns[2].HeaderText = "PROCEDURE NAME";
                dgv_group.Columns[3].HeaderText = "DOCTOR NAME";
                dgv_group.Columns[4].HeaderText = "GROUP";
                dgv_group.Columns[0].Width = 60;
                dgv_group.Columns[1].Width = 105;
                dgv_group.Columns[2].Width = 200;
                dgv_group.Columns[3].Width = 190;
                dgv_group.Columns[4].Width = 150;
                for (int z = 0; z < dtb_procedure.Rows.Count; z++)
                {
                    int sl_no = z + 1;
                    dgv_group.Rows.Add(sl_no, Convert.ToDateTime(dtb_procedure.Rows[z]["date"].ToString()).ToString("yyyy-MM-dd"), dtb_procedure.Rows[z]["procedure_name"].ToString(), dtb_procedure.Rows[z]["doctor_name"].ToString(), dtb_procedure.Rows[z]["group_id"].ToString());
                }
                dgv_group.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                label_empty.Visible = true;
            }
        }
        public void Invoice(DataTable dt1)
        {
            if (dt1.Rows.Count > 0)
            {
                for (int z = 0; z < dt1.Rows.Count; z++)
                {
                    int slno = z + 1;
                    string pt_id = dt1.Rows[z]["pt_id"].ToString();
                    string name = dt1.Rows[z]["pt_name"].ToString();
                    string invoice_no = dt1.Rows[z]["invoice_no"].ToString();
                    string service = dt1.Rows[z]["services"].ToString() + " (Qty:" + dt1.Rows[z]["unit"].ToString() + ")";
                    string date = Convert.ToDateTime(dt1.Rows[z]["date"].ToString()).ToString("dd/MM/yyyy");
                    string doctor = dt1.Rows[z]["doctor_name"].ToString();
                    string type = dt1.Rows[z]["discount_type"].ToString();
                    string groupid = dt1.Rows[z]["group_id"].ToString();
                    decimal discount = 0;
                    if (dt1.Rows[z]["total_discount"].ToString() != "")
                    {
                        discount = decimal.Parse(dt1.Rows[z]["total_discount"].ToString());
                    }
                    else
                        discount = 0;
                    decimal cost = decimal.Parse(dt1.Rows[z]["Cost"].ToString());
                    decimal total_cost = decimal.Parse(dt1.Rows[z]["Total_Cost"].ToString());
                    decimal total_payment = decimal.Parse(dt1.Rows[z]["Payment"].ToString());
                    decimal due = decimal.Parse(dt1.Rows[z]["Cost"].ToString()) - decimal.Parse(dt1.Rows[z]["Payment"].ToString());
                    dgv_group.Rows.Add(slno, name, invoice_no, service, date, doctor, groupid, total_cost, discount, cost, total_payment, due);
                    dgv_group.Columns[11].DefaultCellStyle.ForeColor = Color.Red;
                    dgv_group.Columns[9].DefaultCellStyle.ForeColor = Color.ForestGreen;
                    dgv_group.Columns[10].DefaultCellStyle.ForeColor = Color.Blue;
                }
                Double sum = 0, sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0; ;
                for (int i = 0; i < dgv_group.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dgv_group.Rows[i].Cells[8].Value);
                    sum1 += Convert.ToDouble(dgv_group.Rows[i].Cells[10].Value);
                    sum2 += Convert.ToDouble(dgv_group.Rows[i].Cells[11].Value);
                    sum3 += Convert.ToDouble(dgv_group.Rows[i].Cells[9].Value);
                    sum4 += Convert.ToDouble(dgv_group.Rows[i].Cells[7].Value);
                }
                dgv_group.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Lab_Discount.Text = sum.ToString("0.00");
                Lab_Amount.Text = sum3.ToString("0.00");
                Lab_Paid.Text = sum1.ToString("0.00");
                Lab_Due.Text = sum2.ToString("0.00");
                Lab_tax.Text = sum4.ToString("0.00");
            }
            else
            {
                label_empty.Visible = true;
            }
        }
        public void Receipt(DataTable dtp)
        {
            if (dtp.Rows.Count > 0)
            {
                dgv_group.ColumnCount = 15;
                dgv_group.Columns[0].HeaderText = "SLNO";
                dgv_group.Columns[1].HeaderText = "PATIENT";
                dgv_group.Columns[2].HeaderText = "INVOICE";
                dgv_group.Columns[3].HeaderText = "RECEIPT";
                dgv_group.Columns[4].HeaderText = "PROCEDURE";
                dgv_group.Columns[5].HeaderText = "DOCTOR";
                dgv_group.Columns[6].HeaderText = "GROUP";
                dgv_group.Columns[7].HeaderText = "DATE";
                dgv_group.Columns[8].HeaderText = "MODE OF PAYMENT";
                dgv_group.Columns[9].HeaderText = "COST";
                dgv_group.Columns[10].HeaderText = "TAX";
                dgv_group.Columns[11].HeaderText = "DISCOUNT";
                dgv_group.Columns[12].HeaderText = "TOTAL AMOUNT";
                dgv_group.Columns[13].HeaderText = "AMOUNT PAID";
                dgv_group.Columns[14].HeaderText = "AMOUNT DUE";

                dgv_group.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_group.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_group.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                decimal tax = 0, discount = 0, amount = 0, paid = 0, due = 0;
                decimal Totaltax = 0, Totaldiscount = 0, Totalamount = 0, Totalpaid = 0, Totaldue = 0, totaocost = 0;
                for (int z = 0; z < dtp.Rows.Count; z++)
                {
                    int sl_no = z + 1;
                    dgv_group.Rows.Add(sl_no, dtp.Rows[z]["pt_name"].ToString(), dtp.Rows[z]["invoice_no"].ToString(), dtp.Rows[z]["receipt_no"].ToString(), dtp.Rows[z]["procedure_name"].ToString(), dtp.Rows[z]["doctor_name"].ToString(), dtp.Rows[z]["group_id"].ToString(), Convert.ToDateTime(dtp.Rows[z]["payment_date"].ToString()).ToString("yyyy-MM-dd"), dtp.Rows[z]["mode_of_payment"].ToString(), "0.00", "0.00", "0.00", "0.00", dtp.Rows[z]["amount_paid"].ToString(), dtp.Rows[z]["DUE AFTER PAYMENT"].ToString());
                    DataTable dt_inv = this.cntrl.dt_inv(dtp.Rows[z]["invoice_no"].ToString(), dtp.Rows[z]["procedure_name"].ToString());
                    if (dt_inv.Rows.Count > 0)
                    {
                        dgv_group.Rows[z].Cells[4].Value = dtp.Rows[z]["procedure_name"].ToString() + " (Qty:" + dt_inv.Rows[0]["unit"].ToString() + ")";
                        dgv_group.Rows[z].Cells[9].Value = dt_inv.Rows[0]["Total Cost"].ToString();
                        totaocost += Convert.ToDecimal(dt_inv.Rows[0]["Total Cost"].ToString());
                        if (dt_inv.Rows[0]["discountin_rs"].ToString() != "0")
                        {
                            dgv_group.Rows[z].Cells[11].Value = dt_inv.Rows[0]["discountin_rs"].ToString();
                            discount = decimal.Parse(dt_inv.Rows[0]["discountin_rs"].ToString());
                        }
                        else
                        {
                            dgv_group.Rows[z].Cells[11].Value = "";
                            discount = 0;
                        }
                        dgv_group.Rows[z].Cells[10].Value = dt_inv.Rows[0]["tax_inrs"].ToString();
                        dgv_group.Rows[z].Cells[12].Value = dt_inv.Rows[0]["Total Income"].ToString();
                        tax = decimal.Parse(dt_inv.Rows[0]["tax_inrs"].ToString());
                        amount = decimal.Parse(dt_inv.Rows[0]["Total Income"].ToString());
                    }
                    due = decimal.Parse(dtp.Rows[z]["DUE AFTER PAYMENT"].ToString());
                    paid = decimal.Parse(dtp.Rows[z]["amount_paid"].ToString());

                    Totaltax = Totaltax + tax;
                    Totaldiscount = Totaldiscount + discount;
                    Totalamount = Totalamount + amount;
                    Totalpaid = Totalpaid + paid;
                    Totaldue = Totaldue + due;
                }
                Lab_cost.Text = Convert.ToDecimal(totaocost).ToString("#0.00");
                dgv_group.Columns[14].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Lab_Discount.Text = Convert.ToDecimal(Totaldiscount).ToString("#0.00");
                Lab_tax.Text = Convert.ToDecimal(Totaltax).ToString("#0.00");
                Lab_Amount.Text = Convert.ToDecimal(Totalamount).ToString("#0.00");
                Lab_Paid.Text = Convert.ToDecimal(Totalpaid).ToString("#0.00");
                Lab_Due.Text = Convert.ToDecimal(Totaldue).ToString("#0.00");
            }
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Grid();
        }
        public int len;
        public void pathlength()
        {
            string fullpath = Application.StartupPath.Substring(0, Application.StartupPath.Length);
            if (fullpath.Substring((Application.StartupPath.Length) - 1) == "e")
            {
                len = 11;
            }
            else if (fullpath.Substring((Application.StartupPath.Length - 1)) == "g")
            {
                len = 10;
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_group.Rows.Count > 0)
                {
                    string today = DateTime.Now.ToString("dd/MM/yyyy");
                    string message = "Did you want Header on Print?";
                    string caption = "Verification";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    string strclinicname = ""; string clinicn = "";
                    string strStreet = "";
                    string stremail = "";
                    string strwebsite = "";
                    string strphone = "";
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Data.DataTable dtp = this.cntrl.Get_practiceDlNumber();
                        if (dtp.Rows.Count > 0)
                        {
                            clinicn = dtp.Rows[0]["name"].ToString();
                            strclinicname = clinicn.Replace("¤", "'");
                            strphone = dtp.Rows[0]["contact_no"].ToString();
                            strStreet = dtp.Rows[0]["street_address"].ToString();
                            stremail = dtp.Rows[0]["email"].ToString();
                            strwebsite = dtp.Rows[0]["website"].ToString();
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    pathlength();
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - len);
                    paths = Apppath;
                    if (cmb_type.Text == "Patients")
                    {
                        StreamWriter sWrite2 = new StreamWriter(paths + "\\Reports\\GroupwisePatientReport.html");
                        sWrite2.WriteLine("<html>");
                        sWrite2.WriteLine("<head>");
                        sWrite2.WriteLine("<style>");
                        sWrite2.WriteLine("table { border-collapse: collapse;}");
                        sWrite2.WriteLine("p.big {line-height: 400%;}");
                        sWrite2.WriteLine("</style>");
                        sWrite2.WriteLine("</head>");
                        sWrite2.WriteLine("<body >");
                        sWrite2.WriteLine("<div>");
                        sWrite2.WriteLine("<table align=center width =900>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='center'><FONT COLOR=black FACE='Segoe UI' SIZE=4><b>GROUP WISE PATIENTS REPORT </b> </font></td");
                        sWrite2.WriteLine("</tr>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                        sWrite2.WriteLine("</tr>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='left' ><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
                        sWrite2.WriteLine("</tr>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From:</b> " + dtp1GroupReport.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                        sWrite2.WriteLine("</tr>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + dtp1groupreport2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                        sWrite2.WriteLine("</tr>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></center></td>");
                        sWrite2.WriteLine("</tr>");
                        if (dgv_group.Rows.Count > 0)
                        {
                            sWrite2.WriteLine("<tr>");
                            sWrite2.WriteLine("    <td align='left' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Sl.</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Date</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Patient Id</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Patient Name</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Mobile No</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Email</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor</font></td>");
                            sWrite2.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Group</font></td>");
                            sWrite2.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite2.WriteLine("<tr>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[5].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[7].Value.ToString() + "</font></td>");
                                k = k + 1;
                                sWrite2.WriteLine("</tr>");
                            }
                            sWrite2.WriteLine("<tr>");
                            sWrite2.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                            sWrite2.WriteLine("</tr>");
                            sWrite2.WriteLine("</table>");
                            sWrite2.WriteLine("</div>");
                            sWrite2.WriteLine("<script>window.print();</script>");
                            sWrite2.WriteLine("</body>");
                            sWrite2.WriteLine("</html>");
                            sWrite2.Close();
                            System.Diagnostics.Process.Start(paths + "\\Reports\\GroupwisePatientReport.html");
                        }
                    }
                    else if (cmb_type.Text == "Procedure")
                    {
                        StreamWriter sWrite1 = new StreamWriter(paths + "\\Reports\\GroupwiseProcedureReport.html");
                        sWrite1.WriteLine("<html>");
                        sWrite1.WriteLine("<head>");
                        sWrite1.WriteLine("<style>");
                        sWrite1.WriteLine("table { border-collapse: collapse;}");
                        sWrite1.WriteLine("p.big {line-height: 400%;}");
                        sWrite1.WriteLine("</style>");
                        sWrite1.WriteLine("</head>");
                        sWrite1.WriteLine("<body >");
                        sWrite1.WriteLine("<div>");
                        sWrite1.WriteLine("<table align=center width =900>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='center'><FONT COLOR=black FACE='Segoe UI' SIZE=4><b>GROUP WISE PROCEDURE REPORT </b> </font></td");
                        sWrite1.WriteLine("</tr>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                        sWrite1.WriteLine("</tr>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='left' ><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
                        sWrite1.WriteLine("</tr>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From:</b> " + dtp1GroupReport.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                        sWrite1.WriteLine("</tr>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + dtp1groupreport2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                        sWrite1.WriteLine("</tr>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></center></td>");
                        sWrite1.WriteLine("</tr>");
                        if (dgv_group.Rows.Count > 0)
                        {
                            sWrite1.WriteLine("<tr>");
                            sWrite1.WriteLine("    <td align='center' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Sl.</font></td>");
                            sWrite1.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Date</font></td>");
                            sWrite1.WriteLine("    <td align='center' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Procedure Name</font></td>");
                            sWrite1.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor Name</font></td>");
                            sWrite1.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Group</font></td>");
                            sWrite1.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite1.WriteLine("<tr>");
                                sWrite1.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite1.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite1.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite1.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite1.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                k = k + 1;
                                sWrite1.WriteLine("</tr>");
                            }
                            sWrite1.WriteLine("<tr>");
                            sWrite1.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                            sWrite1.WriteLine("</tr>");
                            sWrite1.WriteLine("</table>");
                            sWrite1.WriteLine("</div>");
                            sWrite1.WriteLine("<script>window.print();</script>");
                            sWrite1.WriteLine("</body>");
                            sWrite1.WriteLine("</html>");
                            sWrite1.Close();
                            System.Diagnostics.Process.Start(paths + "\\Reports\\GroupwiseProcedureReport.html");
                        }
                    }
                    else if (cmb_type.Text == "Invoice")
                    {
                        StreamWriter sWrite3 = new StreamWriter(paths + "\\Reports\\GroupwiseInvoiceReport.html");
                        sWrite3.WriteLine("<html>");
                        sWrite3.WriteLine("<head>");
                        sWrite3.WriteLine("<style>");
                        sWrite3.WriteLine("table { border-collapse: collapse;}");
                        sWrite3.WriteLine("p.big {line-height: 400%;}");
                        sWrite3.WriteLine("</style>");
                        sWrite3.WriteLine("</head>");
                        sWrite3.WriteLine("<body >");
                        sWrite3.WriteLine("<div>");
                        sWrite3.WriteLine("<table align=center width =900>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='center'><FONT COLOR=black FACE='Segoe UI' SIZE=4><b>GROUP WISE INVOICE REPORT </b> </font></td");
                        sWrite3.WriteLine("</tr>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                        sWrite3.WriteLine("</tr>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='left' ><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
                        sWrite3.WriteLine("</tr>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From:</b> " + dtp1GroupReport.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                        sWrite3.WriteLine("</tr>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + dtp1groupreport2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                        sWrite3.WriteLine("</tr>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></center></td>");
                        sWrite3.WriteLine("</tr>");
                        if (dgv_group.Rows.Count > 0)
                        {
                            sWrite3.WriteLine("<tr>");
                            sWrite3.WriteLine("    <td align='center' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Sl.</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Patient Name</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Invoice</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Procedure</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Invoice Date</font></td>");
                            sWrite3.WriteLine("    <td align='center' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor </font></td>");
                            sWrite3.WriteLine("    <td align='center' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Group</font></td>");
                            sWrite3.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Cost</font></td>");
                            sWrite3.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Discount</font></td>");
                            sWrite3.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Amount</font></td>");
                            sWrite3.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Total Payment</font></td>");
                            sWrite3.WriteLine("    <td align='right' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Total Amount Due</font></td>");
                            sWrite3.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite3.WriteLine("<tr>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[5].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[7].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[8].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[9].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[10].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[11].Value.ToString() + "</font></td>");
                                k = k + 1;
                                sWrite3.WriteLine("</tr>");
                            }
                            sWrite3.WriteLine("<tr>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font>Total</td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Lab_tax.Text + "</font></td>");
                            sWrite3.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + Lab_Discount.Text + "</font></td>");
                            sWrite3.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Amount.Text + "</b></font></td>");
                            sWrite3.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Paid.Text + "</b></font></td>");
                            sWrite3.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_Due.Text + "</b></font></td>");
                            sWrite3.WriteLine("</tr>");
                            sWrite3.WriteLine("<tr>");
                            sWrite3.WriteLine("<td align=right colspan=6><FONT COLOR=black FACE='Segoe UI' SIZE=3 ><br><br><b> </b>&nbsp;&nbsp;  </font> </td> ");
                            sWrite3.WriteLine("</tr>");
                            sWrite3.WriteLine("</table>");
                            sWrite3.WriteLine("</div>");
                            sWrite3.WriteLine("<script>window.print();</script>");
                            sWrite3.WriteLine("</body>");
                            sWrite3.WriteLine("</html>");
                            sWrite3.Close();
                            System.Diagnostics.Process.Start(paths + "\\Reports\\GroupwiseInvoiceReport.html");
                        }
                    }
                    else if (cmb_type.Text == "Receipt")
                    {
                        StreamWriter sWrite = new StreamWriter(paths + "\\Reports\\GroupwiseReceiptReport.html");
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
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='center'><FONT COLOR=black FACE='Segoe UI' SIZE=4><b>GROUP WISE RECEIPT </b> </font></td");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=3>   " + strclinicname + "</font></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='left' ><b><FONT COLOR=black FACE='Segoe UI' SIZE=2>   " + strStreet + "</font></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='left'><b><FONT COLOR=black FACE='Segoe UI' SIZE=2> " + strphone + "</font></b></td>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b> From:</b> " + dtp1GroupReport.Value.ToString("dd/MM/yyyy") + " </font></td> ");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>To:</b> " + dtp1groupreport2.Value.ToString("dd/MM/yyyy") + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td colspan=14 align='left'><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>Printed Date:</b>" + " " + today + "" + "</font></center></td>");
                        sWrite.WriteLine("</tr>");
                        if (dgv_group.Rows.Count > 0)
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='center' width='20' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >Sl.</font></td>");
                            sWrite.WriteLine("    <td align='left' width='90' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Patient</font></td>");
                            sWrite.WriteLine("    <td align='left' width='60' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Invoice</font></td>");
                            sWrite.WriteLine("    <td align='left' width='60' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>Receipt</font></td>");
                            sWrite.WriteLine("    <td align='left' width='60' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Procedure</font></td>");
                            sWrite.WriteLine("    <td align='left' width='40' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Doctor </font></td>");
                            sWrite.WriteLine("    <td align='center' width='40' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Group</font></td>");
                            sWrite.WriteLine("    <td align='center' width='50' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Date</font></td>");
                            sWrite.WriteLine("    <td align='center' width='90' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Mode of payment</font></td>");
                            sWrite.WriteLine("    <td align='right' width='50' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Cost</font></td>");
                            sWrite.WriteLine("    <td align='right' width='20' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Tax</font></td>");
                            sWrite.WriteLine("    <td align='right' width='50' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Discount</font></td>");
                            sWrite.WriteLine("    <td align='right' width='80' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Income</font></td>");
                            sWrite.WriteLine("    <td align='right' width='90' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Amount Paid</font></td>");
                            sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> Amount Due</font></td>");
                            sWrite.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[5].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[7].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[8].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[9].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[10].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[11].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[12].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[13].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>" + dgv_group.Rows[j].Cells[14].Value.ToString() + "</font></td>");
                                k = k + 1;
                                sWrite.WriteLine("</tr>");
                            }
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2></font>Total</td>");
                            sWrite.WriteLine("<td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2><b>" + Lab_cost.Text + "</b></font></td>");
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
                            System.Diagnostics.Process.Start(paths + "\\Reports\\GroupwiseReceiptReport.html");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fill_Grid();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Fill_Grid();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_group_Click(object sender, EventArgs e)
        {
            fillCombo();
        }
    }
}
