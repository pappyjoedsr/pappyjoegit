using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Group_Wise_Report : Form
    {
        Group_Wise_Report_controller cntrl=new Group_Wise_Report_controller();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public Group_Wise_Report()
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
                    cmb_group.ValueMember = "id";
                    cmb_group.DisplayMember = "name";
                    cmb_group.DataSource = dtb;
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
                dgv_group.ColumnCount = 10;
                dgv_group.Columns[0].HeaderText = "SLNO";
                dgv_group.Columns[1].HeaderText = "DATE";
                dgv_group.Columns[2].HeaderText = "PATIENT ID";
                dgv_group.Columns[3].HeaderText = "PATIENT NAME";
                dgv_group.Columns[4].HeaderText = "MOBILE NO";
                dgv_group.Columns[5].HeaderText = "EMAIL";
                dgv_group.Columns[6].HeaderText = "DOCTOR";
                dgv_group.Columns[7].HeaderText = "NATIONALITY";
                dgv_group.Columns[8].HeaderText = "PASSPORT NO";
                dgv_group.Columns[9].HeaderText = "GROUP";
                dgv_group.Columns[0].Width = 60;
                dgv_group.Columns[1].Width = 105;
                dgv_group.Columns[2].Width = 130;
                dgv_group.Columns[3].Width = 169;
                dgv_group.Columns[4].Width = 130;
                dgv_group.Columns[5].Width = 130;
                dgv_group.Columns[6].Width = 110;
                dgv_group.Columns[7].Width = 125;
                dgv_group.Columns[8].Width = 130;
                dgv_group.Columns[9].Width = 125;
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
                    string nationality = dtb_group.Rows[z]["nationality"].ToString();
                    string passport = dtb_group.Rows[z]["passport_no"].ToString();
                    string group = dtb_group.Rows[z]["group_id"].ToString();
                    dgv_group.Rows.Add(sl_no, date, patient_id, Patient_Name, mobile, email, doctor_name,nationality,passport, group);
                }
                dgv_group.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                label_empty.Location = new Point(x, label_empty.Location.Y);
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
                int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                label_empty.Location = new Point(x, label_empty.Location.Y);
                label_empty.Visible = true;
            }
        }
        public void Invoice(DataTable dt1)
        {
            if (dt1.Rows.Count > 0)
            {
                for (int z = 0; z < dt1.Rows.Count; z++)
                {
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
                    dgv_group.Columns[4].Width = 90;
                    dgv_group.Columns[5].Width = 100;
                    dgv_group.Columns[6].Width = 120;
                    dgv_group.Columns[7].Width = 85;
                    dgv_group.Columns[8].Width = 80;
                    dgv_group.Columns[9].Width = 110;
                    dgv_group.Columns[10].Width = 130;
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
                int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                label_empty.Location = new Point(x, label_empty.Location.Y);
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

                dgv_group.Columns[0].Width = 40;
                dgv_group.Columns[1].Width = 120;
                dgv_group.Columns[2].Width = 65;
                dgv_group.Columns[3].Width = 65;
                dgv_group.Columns[4].Width = 135;
                dgv_group.Columns[5].Width = 100;
                dgv_group.Columns[6].Width = 100;
                dgv_group.Columns[7].Width = 80;

                dgv_group.Columns[8].Width = 115;
                dgv_group.Columns[9].Width = 90;
                dgv_group.Columns[10].Width = 50;
                dgv_group.Columns[11].Width = 70;
                dgv_group.Columns[12].Width = 110;
                dgv_group.Columns[13].Width = 110;
                dgv_group.Columns[14].Width = 120;

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
            else
            {
                int x = (panel3.Size.Width - label_empty.Size.Width) / 2;
                label_empty.Location = new Point(x, label_empty.Location.Y);
                label_empty.Visible = true;
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
                    string strphone = "",logo_name="";
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
                            logo_name= dtp.Rows[0]["path"].ToString();
                        }
                    }
                    string Apppath = System.IO.Directory.GetCurrentDirectory();
                    if (cmb_type.Text == "Patients")
                    {
                        StreamWriter sWrite2 = new StreamWriter(Apppath + "\\GroupwisePatientReport.html");
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
                        sWrite2.WriteLine("<col >");
                        sWrite2.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite2.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite2.WriteLine("<tr>");
                            sWrite2.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite2.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite2.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite2.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite2.WriteLine("<tr>");
                            sWrite2.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite2.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite2.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite2.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite2.WriteLine("</table>");
                        }
                        sWrite2.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite2.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite2.WriteLine("</table>");
                        sWrite2.WriteLine("<tr>");
                        sWrite2.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> GROUP WISE PATIENTS REPORT  </font></center></b></td>");
                        sWrite2.WriteLine("</tr>");
                        sWrite2.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
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
                            sWrite2.WriteLine("    <td align='left' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='23%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Date</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Patient Id</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='39%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Patient Name</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='20%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Mobile No</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Email</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Doctor</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Nationality</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Passport</b></font></td>");
                            sWrite2.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Group</b></font></td>");
                            sWrite2.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite2.WriteLine("<tr>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[5].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[7].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[8].Value.ToString() + "</font></td>");
                                sWrite2.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[9].Value.ToString() + "</font></td>");
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
                            System.Diagnostics.Process.Start(Apppath + "\\GroupwisePatientReport.html");
                        }
                    }
                    else if (cmb_type.Text == "Procedure")
                    {
                        StreamWriter sWrite1 = new StreamWriter(Apppath + "\\GroupwiseProcedureReport.html");
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
                        sWrite1.WriteLine("<col >");
                        sWrite1.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite1.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite1.WriteLine("<tr>");
                            sWrite1.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite1.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite1.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite1.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite1.WriteLine("<tr>");
                            sWrite1.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite1.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite1.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite1.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite1.WriteLine("</table>");
                        }
                        sWrite1.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite1.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite1.WriteLine("</table>");
                        sWrite1.WriteLine("<tr>");
                        sWrite1.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> GROUP WISE PROCEDURE REPORT  </font></center></b></td>");
                        sWrite1.WriteLine("</tr>");
                        sWrite1.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
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
                            sWrite1.WriteLine("    <td align='left' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno</b>.</font></td>");
                            sWrite1.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Date</b></font></td>");
                            sWrite1.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Procedure Name</b></font></td>");
                            sWrite1.WriteLine("    <td align='left' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Doctor Name</b></font></td>");
                            sWrite1.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;<b> Group</b></font></td>");
                            sWrite1.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite1.WriteLine("<tr>");
                                sWrite1.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite1.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite1.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite1.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite1.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
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
                            System.Diagnostics.Process.Start(Apppath + "\\GroupwiseProcedureReport.html");
                        }
                    }
                    else if (cmb_type.Text == "Invoice")
                    {
                        StreamWriter sWrite3 = new StreamWriter(Apppath + "\\GroupwiseInvoiceReport.html");
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
                        sWrite3.WriteLine("<col >");
                        sWrite3.WriteLine("<br>");
                        string Appath = System.IO.Directory.GetCurrentDirectory();
                        if (File.Exists(Appath + "\\" + logo_name))
                        {
                            sWrite3.WriteLine("<table align='center' style='width:800px;border: 1px ;border-collapse: collapse;'>");
                            sWrite3.WriteLine("<tr>");
                            sWrite3.WriteLine("<td width='30px' height='50px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "'style='width:70px;height:70px;' ></td>  ");
                            sWrite3.WriteLine("<td width='870px' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=4><b>&nbsp;" + strclinicname + "</font> <br><FONT  COLOR=black  face='Segoe UI' SIZE=2>&nbsp;" + strStreet + "<br>&nbsp;" + strphone + " </b></td></tr>");
                            sWrite3.WriteLine("</table>");
                        }
                        else
                        {
                            sWrite3.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite3.WriteLine("<tr>");
                            sWrite3.WriteLine("<td  align='left' height='20px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + strclinicname + "</font></td></tr>");
                            sWrite3.WriteLine("<tr><td  align='left' height='20px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;" + strStreet + "</font></td></tr>");
                            sWrite3.WriteLine("<tr><td align='left' height='20px' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + strphone + "</font></td></tr>");

                            sWrite3.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");

                            sWrite3.WriteLine("</table>");
                        }
                        sWrite3.WriteLine("<table align='center' style='width:800px;border: 1px ;border-collapse: collapse;'>");
                        sWrite3.WriteLine("<tr><td align='left'  ><hr/></td></tr>");
                        sWrite3.WriteLine("</table>");
                        sWrite3.WriteLine("<tr>");
                        sWrite3.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> GROUP WISE INVOICE REPORT  </font></center></b></td>");
                        sWrite3.WriteLine("</tr>");
                        sWrite3.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
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
                            sWrite3.WriteLine("    <td align='left' width='3%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno.</b></font></td>");
                            sWrite3.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Patient Name</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Invoice</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='11%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Procedure</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='9%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Invoice Date</font></td>");
                            sWrite3.WriteLine("    <td align='left' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Doctor </font></td>");
                            sWrite3.WriteLine("    <td align='left' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Group</font></td>");
                            sWrite3.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Cost</b></font></td>");
                            sWrite3.WriteLine("    <td align='right' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b>Discount</b></font></td>");
                            sWrite3.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount</b></font></td>");
                            sWrite3.WriteLine("    <td align='right' width='7%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Total Payment</b></font></td>");
                            sWrite3.WriteLine("    <td align='right' width='8%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Total Amount Due</b></font></td>");
                            sWrite3.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite3.WriteLine("<tr>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[5].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[7].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[8].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[9].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[10].Value.ToString() + "</font></td>");
                                sWrite3.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[11].Value.ToString() + "</font></td>");
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
                            System.Diagnostics.Process.Start(Apppath + "\\GroupwiseInvoiceReport.html");
                        }
                    }
                    else if (cmb_type.Text == "Receipt")
                    {
                        StreamWriter sWrite = new StreamWriter(Apppath + "\\GroupwiseReceiptReport.html");
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
                        sWrite.WriteLine("<th colspan=11><center><b><FONT COLOR=black FACE='Segoe UI'  SIZE=3> GROUP WISE RECEIPT  </font></center></b></td>");
                        sWrite.WriteLine("</tr>");
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
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
                            sWrite.WriteLine("    <td align='left' width='20' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3 >&nbsp;<b>Slno</b></font></td>");
                            sWrite.WriteLine("    <td align='left' width='90' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Patient</b</font></td>");
                            sWrite.WriteLine("    <td align='left' width='60' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Invoice</b</font></td>");
                            sWrite.WriteLine("    <td align='left' width='60' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b>Receipt</b</font></td>");
                            sWrite.WriteLine("    <td align='left' width='60' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Procedure</b</font></td>");
                            sWrite.WriteLine("    <td align='left' width='40' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Doctor</b </font></td>");
                            sWrite.WriteLine("    <td align='left' width='40' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Group</b</font></td>");
                            sWrite.WriteLine("    <td align='left' width='50' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Date</b</font></td>");
                            sWrite.WriteLine("    <td align='left' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Mode of payment</b</font></td>");
                            sWrite.WriteLine("    <td align='right' width='50' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Cost</b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='20' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Tax </b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='50' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Discount </b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='80' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3> <b> Income</b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='90' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount Paid </b></font></td>");
                            sWrite.WriteLine("    <td align='right' width='100' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='Segoe UI' SIZE=3><b> Amount Due </b></font></td>");
                            sWrite.WriteLine("</tr>");
                            int k = 1;
                            for (int j = 0; j < dgv_group.Rows.Count; j++)
                            {
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[0].Value.ToString() + "</font></th>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[1].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[2].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[3].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[4].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[5].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[6].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[7].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='center' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[8].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[9].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[10].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[11].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[12].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[13].Value.ToString() + "</font></td>");
                                sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;" + dgv_group.Rows[j].Cells[14].Value.ToString() + "</font></td>");
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
                            System.Diagnostics.Process.Start(Apppath + "\\GroupwiseReceiptReport.html");
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
