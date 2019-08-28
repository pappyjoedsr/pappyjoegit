using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public partial class Invoice : Form,invoice_interface
    {
        public string doctor_id = "0";
        public string staff_id = "";
        public string patient_id = "";
        string logo_name = "";
        string path = "";
        string invoice_plan_id = "0";
        int button_value = 0;
        int k = 0;
        System.Drawing.Image logo = null;
        invoice_controller cntrl;
        common_model cmodel = new common_model();
        Inventory_model inv_model = new Inventory_model();
        Connection db = new Connection();
        string combo_topmargin = "";
        string combo_leftmargin = "";
        string combo_bottommargin = "";
        string combo_rightmargin = "";
        string combo_paper_size = "";
        string combo_footer_topmargin = "";
        string rich_fullwidth = "";
        string rich_leftsign = "";
        string rich_rightsign = "";
        string patient_details = "";
        string med = "";
        string patient = "";
        string address = "";
        string phone = "";
        string blood = "";
        string gender = "";
        string orientation = "";
        string includeheader = "0";
        string includelogo = "0";
        public Invoice()
        {
            InitializeComponent();
        }
        private void Invoice_Load(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    // add
                    string privid;
                    privid = this.cntrl.check_addprivillege(doctor_id);
                    if (int.Parse(privid) > 0)
                    {
                        btn_ADD.Enabled = false;
                    }
                    else
                    {
                        btn_ADD.Enabled = true;
                    }
                    //Delete
                    privid = this.cntrl.check_delete_privillege(doctor_id);
                    if (int.Parse(privid) > 0)
                    {
                        deleteToolStripMenuItem1.Enabled = false;
                    }
                    else
                    {
                        deleteToolStripMenuItem1.Enabled = true;
                    }
                    privid = this.cntrl.addpayment_privillege(doctor_id);
                    if (int.Parse(privid) > 0)
                    {
                        btn_paySelectedInvoice.Visible = false;
                    }
                    else
                    {
                        btn_paySelectedInvoice.Visible = true;
                    }
                }
                System.Data.DataTable clinicname = cmodel.Get_CompanyNAme();
                toolStripButton4.Visible = true;
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0]["name"].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                    path = clinicname.Rows[0]["path"].ToString();
                    string docnam = cmodel.Get_DoctorName(doctor_id);
                    if (docnam != "")
                    {
                        toolStripTextDoctor.Text = "Logged In As : " + docnam;
                    }
                    if (path != "")
                    {
                        if (File.Exists(db.server() + path))
                        {
                            logo_name = "";
                            logo_name = path;
                            string Apppath = System.IO.Directory.GetCurrentDirectory();
                            if (!File.Exists(Apppath + "\\" + logo_name))
                            {
                                System.IO.File.Copy(db.server() + path, Apppath + "\\" + logo_name);
                            }
                        }
                        else
                        {
                            logo_name = "";
                        }
                    }
                }
                System.Data.DataTable pat = cmodel.Get_Patient_id_NAme(patient_id);
                if (pat.Rows.Count > 0)
                {
                    linkLabel_id.Text = pat.Rows[0]["pt_id"].ToString();
                    linkLabel_Name.Text = pat.Rows[0]["pt_name"].ToString();
                }
                this.cntrl.get_total_payment(patient_id);
                this.cntrl.Get_invoice_mainDetails(patient_id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void set_totalPayment(DataTable pay)
        {
            if (pay.Rows.Count > 0)
            {
                label8.Text = pay.Rows[0]["total_payment"].ToString() + " due";
            }
            dgv_invoice.Show();
            dgv_invoice.ColumnCount = 10;
            dgv_invoice.RowCount = 0;
            dgv_invoice.ColumnHeadersVisible = false;
            dgv_invoice.RowHeadersVisible = false;
            dgv_invoice.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_invoice.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        public void Setcontroller(invoice_controller controller)
        {
            cntrl = controller;
        }
        public void Load_MainTable(DataTable dt_invoice_main)
        {
            int i = 0;
            if (dt_invoice_main.Rows.Count > 0)
            {
                for (int j = 0; j < dt_invoice_main.Rows.Count; j++)
                {
                    dgv_invoice.Rows.Add("0", "", String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_invoice_main.Rows[j]["date"].ToString())), "", "", "", "", "", "0", "");
                    dgv_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DarkGreen;
                    dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                    dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                    i = i + 1;
                    dgv_invoice.Rows.Add(dt_invoice_main.Rows[j]["id"].ToString(), "", "INVOICE NUMBER", "TREATMENT & PRODUCTS", "COST", "DISCOUNT", "TAX", "AMOUNT DUE", dt_invoice_main.Rows[j]["status"].ToString(), "");
                    dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.gry;
                    dgv_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[3].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[4].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[4].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[5].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[5].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[6].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[6].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[7].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[7].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[8].Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                    dgv_invoice.Rows[i].Cells[8].Style.ForeColor = Color.White;
                    dgv_invoice.Rows[i].Cells[1].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[2].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[3].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[4].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[5].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[6].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[7].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[8].Style.BackColor = Color.DarkGray;
                    dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.Bill;
                    if (dt_invoice_main.Rows[j]["status"].ToString() != "0")
                    {
                        dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.Borderblank;
                    }
                    else
                    {
                        dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.billed;
                    }
                    System.Data.DataTable dt_pt_sub=this.cntrl.get_invoiceDetails(dt_invoice_main.Rows[j]["id"].ToString());
                    Double totalEst = 0;
                    Decimal total_cost = 0;
                    Decimal total_discount = 0;
                    Decimal total_tax = 0;
                    int row_no = 0;
                    string discount_string = "";
                    string Dr_name = "";
                    for (int k = 0; k < dt_pt_sub.Rows.Count; k++)
                    {
                        System.Data.DataTable dt_dr = db.table("SELECT doctor_name FROM tbl_doctor where id='" + dt_pt_sub.Rows[k]["dr_id"].ToString() + "' ORDER BY id");
                        if (dt_dr.Rows.Count > 0)
                        {
                            Dr_name = dt_dr.Rows[0]["doctor_name"].ToString();
                        }
                        if (dt_pt_sub.Rows[k]["discount_type"].ToString() == "INR")
                        {
                            discount_string = "";
                        }
                        else
                        {
                            discount_string = "(" + dt_pt_sub.Rows[k]["discount"].ToString() + "%)";
                        }
                        Decimal totalcost = Convert.ToDecimal(dt_pt_sub.Rows[k]["cost"].ToString()) * Convert.ToDecimal(dt_pt_sub.Rows[k]["unit"].ToString());
                        total_cost = total_cost + Convert.ToDecimal(totalcost);
                        total_discount = total_discount + Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString());
                        total_tax = total_tax + Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString());
                        if (k == 0 || k > 2)
                        {
                            i = i + 1;
                            if (k == 0)
                            {
                                dgv_invoice.Rows.Add(dt_pt_sub.Rows[k]["id"].ToString(), "", dt_invoice_main.Rows[j]["invoice"].ToString(), dt_pt_sub.Rows[k]["services"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString())), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), "");
                                dgv_invoice.Rows[i].Height = 25;
                                dgv_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DodgerBlue;
                                dgv_invoice.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                dgv_invoice.Rows[i].Cells[3].Style.ForeColor = Color.DodgerBlue;
                                dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                                dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            }
                            else
                            {
                                dgv_invoice.Rows.Add(dt_pt_sub.Rows[k]["id"].ToString(), "", "", dt_pt_sub.Rows[k]["services"].ToString(), String.Format("{0:C}", Convert.ToDecimal(totalcost)), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string, String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString())), String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())), "");
                                dgv_invoice.Rows[i].Height = 25;
                                dgv_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DodgerBlue;
                                dgv_invoice.Rows[i].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                                dgv_invoice.Rows[i].Cells[3].Style.ForeColor = Color.DodgerBlue;
                                dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                                dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                                i = i + 1;
                                dgv_invoice.Rows.Add("0", "", "", "Completed by " + Dr_name, "", "", "", "", "", "");
                                dgv_invoice.Rows[i].Height = 25;
                                dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                                dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                                dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            }
                        }
                        if (k == 0)
                        {
                            i = i + 1;
                            dgv_invoice.Rows.Add("0", "", "Balance", "Completed by " + Dr_name, "", "", "", "", "", "");
                            dgv_invoice.Rows[i].Height = 20;
                            dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                            dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            row_no = i;
                            dgv_invoice.Rows.Add("0", "", "0000.00", "", "", "", "", "", "", "");
                            dgv_invoice.Rows[i].Height = 20;
                            dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.Red;
                            dgv_invoice.Rows[i].Cells[2].Style.Alignment = DataGridViewContentAlignment.TopLeft;
                            dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                            i = i + 1;
                            dgv_invoice.Rows.Add("0", "", "", "", "", "", "", "", "", "");
                            dgv_invoice.Rows[i].Height = 20;
                            dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                            dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            dgv_invoice.Rows.Add("0", "", "Total                   Paid", "", "", "", "", "", "", "");
                            dgv_invoice.Rows[i].Height = 20;
                            dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                            dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            dgv_invoice.Rows.Add("0", "", "0000.00        0000.00", "", "", "", "", "", "", "");
                            dgv_invoice.Rows[i].Height = 15;
                            dgv_invoice.Rows[i].Cells[2].Style.ForeColor = Color.DimGray;
                            dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[2].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                        }
                        if (k == 1)
                        {
                            dgv_invoice.Rows[i - 3].Cells[0].Value = dt_pt_sub.Rows[k]["id"].ToString();
                            dgv_invoice.Rows[i - 3].Cells[3].Value = dt_pt_sub.Rows[k]["services"].ToString();
                            dgv_invoice.Rows[i - 3].Cells[4].Value = String.Format("{0:C}", Convert.ToDecimal(totalcost));
                            dgv_invoice.Rows[i - 3].Cells[5].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string;
                            dgv_invoice.Rows[i - 3].Cells[6].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString()));
                            dgv_invoice.Rows[i - 3].Cells[7].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString()));
                            dgv_invoice.Rows[i - 3].Cells[8].Value = "";
                            dgv_invoice.Rows[i - 3].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                            dgv_invoice.Rows[i - 3].Cells[3].Style.ForeColor = Color.DodgerBlue;
                            dgv_invoice.Rows[i - 3].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i - 3].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i - 2].Cells[3].Value = "Completed by " + Dr_name;
                        }
                        else if (k == 2)
                        {
                            dgv_invoice.Rows[i - 1].Cells[0].Value = dt_pt_sub.Rows[k]["id"].ToString();
                            dgv_invoice.Rows[i - 1].Cells[3].Value = dt_pt_sub.Rows[k]["services"].ToString();
                            dgv_invoice.Rows[i - 1].Cells[4].Value = String.Format("{0:C}", Convert.ToDecimal(totalcost));
                            dgv_invoice.Rows[i - 1].Cells[5].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string;
                            dgv_invoice.Rows[i - 1].Cells[6].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString()));
                            dgv_invoice.Rows[i - 1].Cells[7].Value = String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString()));
                            dgv_invoice.Rows[i - 1].Cells[8].Value = "";
                            dgv_invoice.Rows[i - 1].Cells[3].Style.Font = new System.Drawing.Font("Segoe UI", 11, FontStyle.Regular);
                            dgv_invoice.Rows[i - 1].Cells[3].Style.ForeColor = Color.DodgerBlue;
                            dgv_invoice.Rows[i - 1].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i - 1].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                            dgv_invoice.Rows[i].Cells[3].Value = "Completed by " + Dr_name;
                        }
                        dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                        totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());//Balance
                        dgv_invoice.Rows[i].Cells[8].Value = PappyjoeMVC.Properties.Resources.blank;
                    }
                    i = i + 1;
                    dgv_invoice.Rows.Add("0", "", "", "", "", "", "", "", "", "");
                    dgv_invoice.Rows[i].Cells[1].Value = PappyjoeMVC.Properties.Resources.blank;
                    dgv_invoice.Rows[i].Cells[9].Value = PappyjoeMVC.Properties.Resources.blank;
                    i = i + 1;
                    Double gtotal = 0, paid = 0;
                    gtotal = Convert.ToDouble(total_cost) - (Convert.ToDouble(total_discount) + Convert.ToDouble(total_tax));
                    paid = gtotal - totalEst;
                    dgv_invoice.Rows[row_no].Cells[2].Value = totalEst.ToString("F");
                    dgv_invoice.Rows[row_no + 3].Cells[2].Value = gtotal.ToString("F") + "                  " + paid.ToString("F");
                }
                if (dgv_invoice.Rows.Count <= 0)
                {
                    Lab_Msg.Show();
                    Lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                else
                {
                    Lab_Msg.Hide();
                    Lab_Msg.Location = new System.Drawing.Point(165, 165);
                }
                btn_ADD.Show();
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category=' EMRI' and Permission='D'");
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Delete Invoice", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        dlt_privilage();
                    }
                }
                else
                {
                    dlt_privilage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void dlt_privilage()
        {
            try
            {
                if (invoice_plan_id != "0")
                {
                    DialogResult res  = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        System.Data.DataTable invoice_type = this.cntrl.Get_type(invoice_plan_id);
                        if (invoice_type.Rows.Count > 0)
                        {
                            if (invoice_type.Rows[0]["type"].ToString() == "drug")
                            {
                                System.Data.DataTable dt_in_main = this.cntrl.InvoiceDetails(invoice_plan_id);
                                if (dt_in_main.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt_in_main.Rows.Count; j++)
                                    {
                                        decimal total_Stock = 0; decimal current_Stock = 0;
                                        System.Data.DataTable dt3 = inv_model.Get_Stock(dt_in_main.Rows[j]["Plan_id"].ToString());
                                        if (dt3.Rows.Count > 0)
                                        {
                                            total_Stock = decimal.Parse(dt3.Rows[0][0].ToString());
                                        }
                                        total_Stock = total_Stock + decimal.Parse(dt_in_main.Rows[j]["unit"].ToString());
                                        System.Data.DataTable dt33 = this.cntrl.geGet_quantiry_fromStockt(dt_in_main.Rows[j]["completed_id"].ToString());
                                        if (dt33.Rows.Count > 0)
                                        { 
                                            current_Stock = decimal.Parse(dt33.Rows[0][0].ToString());
                                        }
                                        current_Stock = current_Stock + decimal.Parse(dt_in_main.Rows[j]["unit"].ToString());
                                        this.cntrl.update_addStock_qty(current_Stock, dt_in_main.Rows[j]["completed_id"].ToString());
                                        this.cntrl.update_inventoryStock(total_Stock, dt_in_main.Rows[j]["Plan_id"].ToString());
                                    }
                                }
                            }
                            else if (Convert.ToString(invoice_type.Rows[0]["type"].ToString()) == "service")
                            {
                                System.Data.DataTable dt_in_main = this.cntrl.InvoiceDetails(invoice_plan_id);
                                if (dt_in_main.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt_in_main.Rows.Count; j++)
                                    {
                                        this.cntrl.set_completeProcedure_status1(dt_in_main.Rows[j]["completed_id"].ToString());
                                    }
                                }
                            }
                            this.cntrl.delete_invoice(invoice_plan_id);
                        }
                        this.cntrl.get_total_payment(patient_id);
                        this.cntrl.Get_invoice_mainDetails(patient_id);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void emailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mprintosave();
        }
        public void mprintosave()
        {
            try
            {
               string doct = cmodel.Get_DoctorName(doctor_id);
                string doctor_name = "";
                if (doct!="")
                {
                    doctor_name = doct;
                }
                System.Data.DataTable patient = cmodel.Get_Patient_Details(patient_id);
                string Pname = "", Gender = "", address = "", age = "", Mobile = "";
                if (patient.Rows.Count > 0) 
                {
                    Pname = patient.Rows[0]["pt_name"].ToString();
                    Gender = patient.Rows[0]["gender"].ToString();
                    address = patient.Rows[0]["street_address"].ToString() + " , " + patient.Rows[0]["city"].ToString();
                    Mobile = patient.Rows[0]["primary_mobile_number"].ToString();
                    if (patient.Rows[0]["age"].ToString() != "")
                    {
                        age = patient.Rows[0]["age"].ToString();
                    }
                }
                string contact_no = "";
                string clinic_name = "";
                System.Data.DataTable dtp = cmodel.Get_Practice_details();
                if (dtp.Rows.Count > 0)
                {
                    clinic_name = dtp.Rows[0]["name"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                }
                System.Data.DataTable dt_pt_sub = this.cntrl.get_invoiceDetails(invoice_plan_id);
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\InvoicenPrint.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br><br><br>");
                sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, Arial' SIZE=4>" + clinic_name.ToString() + "</font></th></tr>");
                sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>" + contact_no.ToString() + "</font></th></tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, Arial' SIZE=5>INVOICE </font></th></tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center' style='width:900px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Name :<b>" + Pname.ToString() + " </b></font></td>");
                sWrite.WriteLine("	<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Age : <b> " + age.ToString() + " </b></font></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine(" <tr>");
                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Address :<b> " + address.ToString() + "</b></font></td>");
                sWrite.WriteLine("	<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Gender : <b>" + Gender.ToString() + " </b></font></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine(" <tr>");
                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Mobile No:<b> " + Mobile.ToString() + "</b></font></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine(" <tr>");
                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Invoice No:<b> " + dt_pt_sub.Rows[0]["invoice_no"].ToString() + "</b></font></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<hr>");
                sWrite.WriteLine("<table align='center'  style='border: 1px ;border-collapse: collapse;' >");
                System.Data.DataTable dt_invoice_main = this.cntrl.Load_invoice_mainDetails(patient_id);
                if (dt_invoice_main.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan='2' >");
                    sWrite.WriteLine("<table align='center'  style='border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<th align='left' width='350px' bgcolor=gray><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>&nbsp;TREATMENT & PRODUCTS</b> </font></th>");
                    sWrite.WriteLine("<th align='right' width='100px' bgcolor=gray><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;COST</b> </font></th>");
                    sWrite.WriteLine("<th align='right' width='150px' bgcolor=gray><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>&nbsp;DISCOUND</b> </font></th>");
                    sWrite.WriteLine("<th align='right' width='150px' bgcolor=gray><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>&nbsp;&nbsp;TAX</b> </font></th>");
                    sWrite.WriteLine("<th align='right' width='200px' bgcolor=gray><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>&nbsp;&nbsp;AMOUNT DUE</b> </font></th>");
                    sWrite.WriteLine("</tr>");
                    Double totalEst = 0;
                    Decimal total_cost = 0;
                    Decimal total_discount = 0;
                    Decimal total_tax = 0;
                    decimal due = 0;
                    string discount_string = "";
                    if (dt_pt_sub.Rows.Count > 0)
                    {
                        for (int k = 0; k < dt_pt_sub.Rows.Count; k++)
                        {
                            if (dt_pt_sub.Rows[k]["discount_type"].ToString() == "INR")
                            {
                                discount_string = "";
                            }
                            else
                            {
                                discount_string = "(" + dt_pt_sub.Rows[k]["discount"].ToString() + "%)";
                            }
                            Decimal totalcost = Convert.ToDecimal(dt_pt_sub.Rows[k]["cost"].ToString()) * Convert.ToDecimal(dt_pt_sub.Rows[k]["unit"].ToString());
                            total_cost = total_cost + Convert.ToDecimal(totalcost);
                            total_discount = total_discount + Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString());
                            total_tax = total_tax + Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString());
                            totalEst = totalEst + Convert.ToDouble(dt_pt_sub.Rows[k]["total"].ToString());
                            due = Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString());
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("    <td align='left' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt_pt_sub.Rows[k]["services"].ToString() + "</font></th>");
                            sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["cost"].ToString())) + "</font></th>");
                            sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["discountin_rs"].ToString())) + discount_string + " </font></th>");
                            sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;&nbsp; " + String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["tax_inrs"].ToString())) + "</font></th>");
                            sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;&nbsp;" + String.Format("{0:C}", Convert.ToDecimal(dt_pt_sub.Rows[k]["total"].ToString())) + "</font></th>");
                            sWrite.WriteLine("</tr>");
                        }
                    }
                    Double gtotal = 0, paid = 0;
                    gtotal = Convert.ToDouble(total_cost) - (Convert.ToDouble(total_discount) + Convert.ToDouble(total_tax));
                    paid = gtotal - totalEst;
                    sWrite.WriteLine(" </table>");
                    sWrite.WriteLine(" </td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("    <td align='left' height='20'><FONT COLOR=black FACE='Geneva, Arial' SIZE=3></font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("<table align='center' style='width:900px;border: 1px;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;Total :" + String.Format("{0:C}", Convert.ToDecimal(gtotal)) + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table >");
                    sWrite.WriteLine("<table align='center' style='width:900px;border: 1px;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;Paid :" + String.Format("{0:C}", Convert.ToDecimal(paid)) + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table >");
                    sWrite.WriteLine("<table align='center' style='width:900px;border: 1px;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='right' width='230px' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;&nbsp;Balance :" + String.Format("{0:C}", Convert.ToDecimal(totalEst)) + "</font></th>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                string email = "", emailName = "", emailPass = "";
                System.Data.DataTable sr = cmodel.getpatemail(patient_id);
                if (sr.Rows.Count > 0)
                {
                    email = sr.Rows[0]["email_address"].ToString();
                    if (email != "")
                    {
                        System.Data.DataTable sms = cmodel.send_email();
                        if (sms.Rows.Count > 0)
                        {
                            emailName = sms.Rows[0]["emailName"].ToString();
                            emailPass = sms.Rows[0]["emailPass"].ToString();
                            try
                            {
                                StreamReader reader = new StreamReader(Apppath + "\\InvoicenPrint.html");
                                string readFile = reader.ReadToEnd();
                                string StrContent = "";
                                StrContent = readFile;
                                MailMessage message = new MailMessage();
                                message.From = new MailAddress(email);
                                message.To.Add(email);
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                message.Subject = "Pappyjoe Invoice";
                                message.Body = StrContent.ToString();
                                message.IsBodyHtml = true;
                                smtp.Port = 587;
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                smtp.Send(message);
                                MessageBox.Show("Email is Sent To : " + email);
                                reader.Close();
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Activate Email Configuration", "Configuration Required", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Add EmailId for Selected patient", "Email Required", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_invoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_invoice.Rows.Count > 0 && (dgv_invoice.Rows[e.RowIndex].Cells[8].Value.ToString() == "1" || dgv_invoice.Rows[e.RowIndex].Cells[8].Value.ToString() == "2") && dgv_invoice.Rows[e.RowIndex].Cells[2].Value.ToString() == "INVOICE NUMBER")
            {
                if (e.ColumnIndex == 1)
                {
                    if (dgv_invoice.Rows[e.RowIndex].Cells[8].Value.ToString() == "1")
                    {
                        button_value = button_value + 1;
                        dgv_invoice.Rows[e.RowIndex].Cells[8].Value = "2";
                        dgv_invoice.Rows[e.RowIndex].Cells[1].Value = PappyjoeMVC.Properties.Resources.Bordertick;
                    }
                    else if (dgv_invoice.Rows[e.RowIndex].Cells[8].Value.ToString() == "2")
                    {
                        button_value = button_value - 1;
                        dgv_invoice.Rows[e.RowIndex].Cells[8].Value = "1";
                        dgv_invoice.Rows[e.RowIndex].Cells[1].Value = PappyjoeMVC.Properties.Resources.Borderblank;
                    }
                    if (button_value > 0)
                    { btn_paySelectedInvoice.Enabled = true; }
                    else
                    { btn_paySelectedInvoice.Enabled = false; }
                }
            }
        }

        private void dgv_invoice_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentMouseOverRow = dgv_invoice.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dgv_invoice.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 9)
                    {
                        if (dgv_invoice.Rows[currentMouseOverRow].Cells[8].Value.ToString() == "0" && dgv_invoice.Rows[currentMouseOverRow].Cells[2].Value.ToString() == "INVOICE NUMBER")
                        {
                            invoice_plan_id = dgv_invoice.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                            deleteToolStripMenuItem1.Enabled = false;
                            contextMenuStrip1.Show(dgv_invoice, new System.Drawing.Point(915 - 120, e.Y));
                        }
                        else if (dgv_invoice.Rows[currentMouseOverRow].Cells[0].Value.ToString() != "0" && dgv_invoice.Rows[currentMouseOverRow].Cells[2].Value.ToString() == "INVOICE NUMBER")
                        {
                            invoice_plan_id = dgv_invoice.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                            System.Data.DataTable dt_pay = this.cntrl.Get_paymentid(dgv_invoice.Rows[currentMouseOverRow + 1].Cells[2].Value.ToString());
                            if (dt_pay.Rows.Count > 0)
                            {
                                deleteToolStripMenuItem1.Enabled = false;
                            }
                            else
                            {
                                deleteToolStripMenuItem1.Enabled = true;
                            }
                            contextMenuStrip1.Show(dgv_invoice, new System.Drawing.Point(915 - 120, e.Y));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error Data...!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Data.DataTable print = this.cntrl.Get_invoicePrintsettings();
            if (print.Rows.Count > 0)
            {
                combo_topmargin = print.Rows[0][4].ToString();
                combo_leftmargin = print.Rows[0][5].ToString();
                combo_bottommargin = print.Rows[0][6].ToString();
                combo_rightmargin = print.Rows[0][7].ToString();
                combo_paper_size = print.Rows[0][1].ToString();
                combo_footer_topmargin = print.Rows[0][22].ToString();
                rich_fullwidth = print.Rows[0][23].ToString();
                rich_leftsign = print.Rows[0][24].ToString();
                rich_rightsign = print.Rows[0][25].ToString();
                patient_details = print.Rows[0][14].ToString();
                med = print.Rows[0][15].ToString();
                patient = print.Rows[0][16].ToString();
                address = print.Rows[0][17].ToString();
                phone = print.Rows[0][18].ToString();
                blood = print.Rows[0][20].ToString();
                gender = print.Rows[0][21].ToString();
                orientation = print.Rows[0][2].ToString();
                includeheader = print.Rows[0]["include_header"].ToString();
                includelogo = print.Rows[0]["include_logo"].ToString();
            }
            printhtml();
        }
        public void printhtml()
        {
            try
            {
                string clinicn = "";
                string Clinic = "";
                string streetaddress = "";
                string contact_no = "";
                string str_locality = "";
                string str_pincode = "";
                string str_email = "";
                string str_website = "";
                string str_druglicenseno = "";
                string str_taxno = "";
                System.Data.DataTable dtp = cmodel.Get_practiceDlNumber();
                if (dtp.Rows.Count > 0)
                {
                    clinicn = dtp.Rows[0][0].ToString();
                    Clinic = clinicn.Replace("¤", "'");
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                    str_druglicenseno = dtp.Rows[0]["Dl_Number"].ToString();
                    str_taxno = dtp.Rows[0]["Dl_Number2"].ToString();
                }
                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.cntrl.Get_invoicePrintsettings();
                if (print.Rows.Count > 0)
                {
                    header1 = print.Rows[0]["header"].ToString();
                    header2 = print.Rows[0]["left_text"].ToString();
                    header3 = print.Rows[0]["right_text"].ToString();
                    strfooter1 = print.Rows[0]["fullwidth_context"].ToString();
                    strfooter2 = print.Rows[0]["left_sign"].ToString();
                    strfooter3 = print.Rows[0]["right_sign"].ToString();
                }
                string doctorname = ""; 
                string strinvoice = "";
                string strdate = "";
                System.Data.DataTable dt_cf = this.cntrl.get_invoice_doctorname(patient_id);
                if (dt_cf.Rows.Count > 0)
                {
                    doctorname = Convert.ToString(dt_cf.Rows[0]["doctor_name"].ToString());
                }
                System.Data.DataTable dt_invo = this.cntrl.Get_date(invoice_plan_id);
                if (dt_invo.Rows.Count > 0)
                {
                    strinvoice = Convert.ToString(dt_invo.Rows[0]["invoice"].ToString());
                    strdate = Convert.ToString(dt_invo.Rows[0]["date"].ToString());
                } 
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\invoice.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr><th align='center'><br><FONT COLOR=black FACE='Geneva, Arial' SIZE=5>INVOICE </font></th></tr>");
                sWrite.WriteLine("</table>");
                if (includeheader == "1")
                {
                    if (includelogo == "1")
                    {
                        if (logo != null || logo_name != "")
                        {
                            string Appath = System.IO.Directory.GetCurrentDirectory();
                            if (File.Exists(Appath + "\\" + logo_name))
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='4'><img src='" + Appath + "\\" + logo_name + "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
                                sWrite.WriteLine("<td width='588' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + str_druglicenseno + "&nbsp;&nbsp; " + str_taxno + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Invoice No: </FONT>" + strinvoice + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(strdate).ToString("dd MMM yyyy") + "</font></td></tr>");
                                sWrite.WriteLine("</table>");
                            }
                            else
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + str_druglicenseno + "&nbsp;&nbsp; " + str_taxno + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Invoice No: </FONT>" + strinvoice + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(strdate).ToString("dd MMM yyyy") + "</font></td></tr>");
                                sWrite.WriteLine("</table>");
                            }
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + str_druglicenseno + "&nbsp;&nbsp; " + str_taxno + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Invoice No: </FONT>" + strinvoice + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(strdate).ToString("dd MMM yyyy") + "</font></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + str_druglicenseno + "&nbsp;&nbsp; " + str_taxno + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Invoice No: </FONT>" + strinvoice + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=1> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(strdate).ToString("dd MMM yyyy") + "</font></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5></font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='20px' valign='top' > <FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Invoice No: </FONT>" + strinvoice + "</font> </td> <td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(strdate).ToString("dd MMM yyyy") + "</font></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                int Dexist = 0;
                string sexage = "";
                string address = "";
                address = "";
                System.Data.DataTable dt1 = cmodel.Get_Patient_Details(patient_id);
                if (dt1.Rows.Count > 0)
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    if (dt1.Rows[0]["gender"].ToString() != "")
                    {
                        sexage = dt1.Rows[0]["gender"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["age"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            sexage = sexage + ", " + dt1.Rows[0]["age"].ToString() + " Years";
                        }
                        else
                        {
                            sexage = dt1.Rows[0]["age"].ToString() + " Years";
                        }
                    }
                    sWrite.WriteLine(" <td align='left' height=25><FONT COLOR=black FACE='Geneva, Arial' SIZE=2><b>" + dt1.Rows[0]["pt_name"].ToString() + "</b><i> (" + sexage + ")</i></font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>Patient Id:" + dt1.Rows[0]["pt_id"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    Dexist = 0;
                    if (dt1.Rows[0]["street_address"].ToString() != "")
                    {
                        address = dt1.Rows[0]["street_address"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["locality"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["locality"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["city"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["city"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["pincode"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["pincode"].ToString();
                        Dexist = 1;
                    }
                    if (address != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + address + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + dt1.Rows[0]["primary_mobile_number"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    if (dt1.Rows[0]["email_address"].ToString() != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>" + dt1.Rows[0]["email_address"].ToString() + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr><td colspan=2><hr></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                // Discount and Tax Check
                string discount_check = "";
                string tax_check = "";
                System.Data.DataTable dt_invoice_check = db.table("SELECT invoice_no,services,cost,discountin_rs,total_tax,total,unit,notes FROM tbl_invoices WHERE invoice_main_id ='" + invoice_plan_id + "'");
                if (dt_invoice_check.Rows.Count > 0)
                {
                    k = 0;
                    while (k < dt_invoice_check.Rows.Count)
                    {
                        if (decimal.Parse(dt_invoice_check.Rows[k]["discountin_rs"].ToString()) > 0 && discount_check == "")
                        {
                            discount_check = "Discount";
                        }
                        if (decimal.Parse(dt_invoice_check.Rows[k]["total_tax"].ToString()) > 0 && tax_check == "")
                        {
                            tax_check = "Tax";
                        }
                        k = k + 1;
                    }
                }
                // Close
                sWrite.WriteLine("<table align='center'  style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr style='background:#999999'>");
                sWrite.WriteLine("<td align='left' width='35px' height='30' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Sl.</font></td>");
                sWrite.WriteLine("<td align='left' width='316px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Services</font></td>");
                sWrite.WriteLine("<td align='right' width='93px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Cost </font></td>");
                sWrite.WriteLine("<td align='right' width='78px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;" + discount_check + "&nbsp;</font></td>");
                sWrite.WriteLine("<td align='right' width='52px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;" + tax_check + "&nbsp;</font></td>");
                sWrite.WriteLine("<td align='right' width='91px' bgcolor='#CCCCCC'><FONT COLOR=black FACE=' Arial' SIZE=3>&nbsp;Total&nbsp;</font></td>");
                sWrite.WriteLine("</tr>");
                decimal cost = 0, tax = 0, discount = 0, total = 0, totalPaid = 0;
                System.Data.DataTable dt_prescription = this.cntrl.get_invoiceDetails(invoice_plan_id);
                Decimal ValBalance1 = 0;
                if (dt_prescription.Rows.Count > 0)
                {
                    k = 0;
                    while (k < dt_prescription.Rows.Count)
                    {
                        Decimal totalcost = Convert.ToDecimal(dt_prescription.Rows[k]["cost"].ToString()) * Convert.ToDecimal(dt_prescription.Rows[k]["unit"].ToString());
                        ValBalance1 = ValBalance1 + totalcost;
                        Decimal subtotalcost = Convert.ToDecimal(totalcost.ToString()) - (Convert.ToDecimal(dt_prescription.Rows[k]["discountin_rs"].ToString()) + Convert.ToDecimal(dt_prescription.Rows[k]["total_tax"].ToString()));
                        Decimal qty = Convert.ToDecimal(dt_prescription.Rows[k]["unit"].ToString());
                        string str_qty = "";
                        if (qty > 1)
                        {
                            str_qty = " [Qty:" + Convert.ToDecimal(dt_prescription.Rows[k]["unit"].ToString()) + "]";
                        }
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' height='30'  ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + Convert.ToString(k + 1) + " </font></td>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + dt_prescription.Rows[k]["services"].ToString() + str_qty + " </font></td>");
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(totalcost.ToString())) + " </font></td>");
                        if (discount_check == "Discount")
                        {
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(dt_prescription.Rows[k]["discountin_rs"].ToString())) + " </font></td>");
                        }
                        else
                        {
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp; </font></td>");
                        }
                        if (tax_check == "Tax")
                        {
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(dt_prescription.Rows[k]["total_tax"].ToString())) + " </font></td>");
                        }
                        else
                        {
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp; </font></td>");
                        }
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(subtotalcost.ToString())) + " </font></td>");
                        sWrite.WriteLine("</tr>");
                        if (dt_prescription.Rows[k]["notes"].ToString() != "")
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' height='10'  ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;</font></td>");
                            sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=1><i>&nbsp;(" + dt_prescription.Rows[k]["notes"].ToString() + ")</i> </font></td>");
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2> </font></td>");
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2></font></td>");
                            sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Arial' SIZE=2></font></td>");
                            sWrite.WriteLine("</tr>");
                        }
                        cost = cost + decimal.Parse(totalcost.ToString());
                        tax = tax + decimal.Parse(dt_prescription.Rows[k]["total_tax"].ToString());
                        discount = discount + decimal.Parse(dt_prescription.Rows[k]["discountin_rs"].ToString());
                        total = total + decimal.Parse(subtotalcost.ToString());
                        k++;
                    }
                }
                string num = this.cntrl.Get_TotalSum(invoice_plan_id);
                int numValBalance = Int32.Parse(num.ToString());
                totalPaid = ValBalance1 - (numValBalance + discount);
                sWrite.WriteLine("<tr><td align='left' colspan=6><hr/></td></tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + " Total Cost :" + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(cost.ToString())) + " </font></td>");
                sWrite.WriteLine("</tr>");
                if (decimal.Parse(tax.ToString()) > 0)
                {
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='Right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + " Total Tax :" + " </font></td>");
                    sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(tax.ToString())) + " </font></td>");
                    sWrite.WriteLine("</tr>");
                }
                if (decimal.Parse(discount.ToString()) > 0)
                {
                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("<td align='Right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + "Total Discount :" + " </font></td>");
                    sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(discount.ToString())) + " </font></td>");
                    sWrite.WriteLine("</tr>");
                }
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>&nbsp;" + "Grand Total :" + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>&nbsp;<b>" + String.Format("{0:C}", decimal.Parse(total.ToString())) + " </b></font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + "Total Paid :" + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=2>&nbsp;" + String.Format("{0:C}", decimal.Parse(totalPaid.ToString())) + " </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='Right' colspan=5><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>&nbsp;" + "Balance :" + " </font></td>");
                sWrite.WriteLine("<td align='Right'   colspan=1><FONT COLOR=black FACE='Geneva, Arial' SIZE=3>&nbsp;<b>" + String.Format("{0:C}", decimal.Parse(numValBalance.ToString())) + "</b> </font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                //footer
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr><td align='left' ><hr/></td></tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter1 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter2 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter3 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body >");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\invoice.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            profile_details_controller ctr = new profile_details_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void btn_paySelectedInvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Add_receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.status = 1;
            add_receipt_controller controller = new add_receipt_controller(form2);
            int i = 0; int j = 0;
            while (i < dgv_invoice.Rows.Count)
            {
                try
                {
                    if (dgv_invoice.Rows[i].Cells[8].Value.ToString() == "2")
                    {
                        form2.invoices[j] = dgv_invoice.Rows[i + 1].Cells[2].Value.ToString();
                        j++;
                    }
                }
                catch
                {
                }
                i++;
            }
            if (form2.invoices == null)
            {
                MessageBox.Show("Choose an INVOICE first...", "Invalid Selection", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void btn_ADD_Click(object sender, EventArgs e)
        {
            var form2 = new Add__invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Add_invoice_controller controller = new Add_invoice_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelallpatient_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controllr = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            expense_controller controller = new expense_controller(form2);
            form2.ShowDialog();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
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

        private void labelappointment_Click(object sender, EventArgs e)
        {

            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Show_Appointment_controller controller = new Show_Appointment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void label44_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Vital_Signs_controller controller = new Vital_Signs_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new TreatmentPlans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            treatment_controller controller = new treatment_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new FinishedProcedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            finishedprocedre_controller controller = new finishedprocedre_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            invoice_controller controller = new invoice_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Receipt_controller controller = new Receipt_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
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
                listpatientsearch.Location = new Point(toolStripTextBox1.Width - 352, 39);
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

        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Ledger_controller controller = new Ledger_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            Clinical_Findings_controller controller = new Clinical_Findings_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new prescriptionShow();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            prescriptionshow_controller controller = new prescriptionshow_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}
