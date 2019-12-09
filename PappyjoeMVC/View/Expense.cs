using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Expense : Form
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime Date { get; set; }
        Expense_controller cntrl = new Expense_controller();
        public string doctor_id = "";
        public int Incom_ID = 0;
        public int rowindex = 0;
        int Check_Value1 = 0;
        int Check_Value = 0;
        public string exp_Type = "";
        string FromDate = "";
        string ToDate = "";
        string id;
        public Expense()
        {
            InitializeComponent();
        }
        private void Lnk_AddNewCrdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new New_Credit_Account();
            form2.ShowDialog();
            form2.Dispose();
        }
        public void btn_normal()
        {
            Lab_reports.ForeColor = Color.DimGray;
            Lab_reports.BackColor = Color.White;
            Lab_Debits.ForeColor = Color.DimGray;
            Lab_Debits.BackColor = Color.White;
            lab_Credits.ForeColor = Color.DimGray;
            lab_Credits.BackColor = Color.White;
        }
        private void Lab_reports_Click(object sender, EventArgs e)
        {
            btn_normal();
            panel6.Hide();
            panel1.Show();
            Lab_reports.BackColor = Color.DodgerBlue; 
            Lab_reports.ForeColor = Color.White;
        }

        private void Lab_Debits_Click(object sender, EventArgs e)
        {
            try
            {
                btn_normal();
                panel1.Hide();
                panel6.Show();
                grp_Debit.Visible = true;
                grp_Debit.Width = 1060;
                grp_Debit.Location = new Point(10, 10);
                grpb_Credit.Visible = false;
                Lab_Debits.BackColor = Color.DodgerBlue;
                Lab_Debits.ForeColor = Color.White;
                DataTable dtb = this.cntrl.fill_dgv_debit();
                fill_dgv_debit(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lab_Credits_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB"); //dd/MM/yyyy
                btn_normal();
                panel6.Show();
                grp_Debit.Visible = false;
                grpb_Credit.Visible = true;
                grpb_Credit.Width = 1060;
                grpb_Credit.Location = new Point(10, 10);
                panel1.Hide();
                lab_Credits.BackColor = Color.DodgerBlue;
                lab_Credits.ForeColor = Color.White;
                DataTable dtb = this.cntrl.Fillgrid();
                Fill_dgv_credit(dtb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddSLNO()
        {
            int val = 1;
            for (int i = 0; i < dgv_credit.Rows.Count; i++)
            {
                dgv_credit.Rows[i].Cells["ColSerialNo"].Value = val;
                val = val + 1;
            }
        }
        public void Fill_dgv_credit(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                dgv_credit.RowCount = 0;
                int row = 0;
                dgv_credit.Width = 1047;
                dgv_credit.Height = 330;
                foreach (DataRow dr in dtb.Rows)
                {
                    dgv_credit.Rows.Add();
                    dgv_credit.Rows[row].Cells["Col_id"].Value = dr["id"].ToString();
                    dgv_credit.Rows[row].Cells["col_descrptn"].Value = dr["description"].ToString();
                    dgv_credit.Rows[row].Cells["col_amount"].Value = Convert.ToDecimal(dr["amountincome"].ToString()).ToString("#0.00");
                    dgv_credit.Rows[row].Cells["col_ledger"].Value = dr["nameofperson"].ToString();
                    dgv_credit.Rows[row].Cells["col_name"].Value = dr["expense_type"].ToString();
                    dgv_credit.Rows[row].Cells["col_date"].Value = dr["date"].ToString();
                    row++;
                }
                AddSLNO();
                dgv_credit.RowsDefaultCellStyle.ForeColor = Color.DarkSlateGray;
                dgv_credit.RowsDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                dgv_credit.Columns["col_amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_credit.Columns["col_amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void comboBoxincomacc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Check_Value1 == 1)
                {
                    DataTable dtb = this.cntrl.show_ledger(comboBoxincomacc.Text);
                    if (dtb.Rows.Count > 0)
                    {
                        textBoxnameofincome.Text = dtb.Rows[0]["Group_Name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnincomesubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtamountincome.Text) && !string.IsNullOrWhiteSpace(textBoxnameofincome.Text) && !string.IsNullOrWhiteSpace(dateTimePickerincome.Value.ToString()))
                {
                    if (btnincomesubmit.Text == "Submit")
                    {
                        int i = this.cntrl.submit_credit(dateTimePickerincome.Value.ToString("yyyy-MM-dd"), comboBoxincomacc.Text, textBoxdescincome.Text, textBoxnameofincome.Text, txtamountincome.Text);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clear_Credit();
                            DataTable dtb = this.cntrl.Fillgrid();
                            Fill_dgv_credit(dtb);
                            comboBoxincomacc_SelectedIndexChanged(null, null);
                        }
                    }
                    else if (btnincomesubmit.Text == "Update")
                    {
                        this.cntrl.update_dgv_credit(Incom_ID, dateTimePickerincome.Value.ToString("yyyy-MM-dd"), comboBoxincomacc.Text, textBoxdescincome.Text, txtamountincome.Text, textBoxnameofincome.Text);
                        MessageBox.Show("Income Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear_Credit();
                        DataTable dtb = this.cntrl.Fillgrid();
                        Fill_dgv_credit(dtb);
                        btnincomesubmit.Text = "Submit";
                        comboBoxincomacc_SelectedIndexChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Should fill the mandatory field...", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtamountincome.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear_Credit()
        {
            txtamountincome.Clear();
            textBoxnameofincome.Clear();
            textBoxdescincome.Clear();
            dateTimePickerincome.Text = DateTime.Now.ToShortDateString();
        }
        private void bntclose_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void comboBoxincomacc_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtb = this.cntrl.load_accountname();
                comboBoxincomacc.DataSource = dtb;
                comboBoxincomacc.DisplayMember = "name";
                comboBoxincomacc.ValueMember = "id";
                Check_Value1 = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_credit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (dgv_credit.Rows.Count > 0)
                    {
                        Incom_ID = Convert.ToInt32(dgv_credit.CurrentRow.Cells["Col_id"].Value.ToString());
                        if (dgv_credit.CurrentCell.OwningColumn.Name == "col_edit")
                        {
                            int rw = dgv_credit.CurrentRow.Index;
                            //if (rw != null)
                            {
                                comboBoxincomacc.Text = dgv_credit.Rows[rw].Cells["col_name"].Value.ToString();
                                txtamountincome.Text = dgv_credit.Rows[rw].Cells["col_amount"].Value.ToString();
                                textBoxnameofincome.Text = dgv_credit.Rows[rw].Cells["col_ledger"].Value.ToString();
                                textBoxdescincome.Text = dgv_credit.Rows[rw].Cells["col_descrptn"].Value.ToString();
                                DateTime dt =  Convert.ToDateTime( dgv_credit.Rows[rw].Cells["col_date"].Value.ToString());
                                dateTimePickerincome.Text =dt.ToString();
                                btn_Creditcancel.Visible = true;
                                btnincomesubmit.Text = "Update";
                            }
                        }
                        else if (dgv_credit.CurrentCell.OwningColumn.Name == "col_delete")
                        {
                            int index = dgv_credit.CurrentRow.Index;
                            //if (Incom_ID != null)
                            {
                                DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.No)
                                {
                                }
                                else
                                {
                                    int j = this.cntrl.dgv_credit_delete(Incom_ID);
                                    if (j > 0)
                                    {
                                        dgv_credit.Rows.RemoveAt(index);
                                        DataTable dtb = this.cntrl.Fillgrid();
                                        Fill_dgv_credit(dtb);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lnk_AddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new New_Debit_Account();
            form2.ShowDialog();
            form2.Dispose();
        }

        private void comboaccountname_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = this.cntrl.debit_accountname();
                comboaccountname.DataSource = dt1;
                comboaccountname.DisplayMember = "name";
                comboaccountname.ValueMember = "id";
                Check_Value = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboaccountname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Check_Value == 1)
                {
                    System.Data.DataTable dtp = this.cntrl.debit_ledgerload(comboaccountname.Text);
                    if (dtp.Rows.Count > 0)
                    {
                        textperson.Text = dtp.Rows[0]["Group_Name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PutSLNO()
        {
            int val = 1;
            for (int i = 0; i < Dgv_Debit.Rows.Count; i++)
            {
                Dgv_Debit.Rows[i].Cells["colSlNo"].Value = val;
                val = val + 1;
            }
        }
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textamount.Text))
                {
                    if (btnsubmit.Text == "Submit")
                    {
                        int i = this.cntrl.submit_debit(dateTimePickerdate.Value.ToString("yyyy-MM-dd"), comboaccountname.Text, textBox_add_template.Text, textamount.Text, textperson.Text);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dateTimePickerdate.Text = DateTime.Now.ToShortDateString();
                            DataTable dtb = this.cntrl.fill_dgv_debit();
                            fill_dgv_debit(dtb);
                            clear_Debit();
                            comboaccountname_SelectedIndexChanged(null, null);
                        }
                    }
                    else if (btnsubmit.Text == "Update")
                    {
                        int i = this.cntrl.update_dgv_debit(rowindex, dateTimePickerdate.Value.ToString("yyyy-MM-dd"), comboaccountname.Text, textBox_add_template.Text, textamount.Text, textperson.Text);
                        if (i > 0)
                        {
                            MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dateTimePickerdate.Text = DateTime.Now.ToShortDateString();
                            DataTable dtb = this.cntrl.fill_dgv_debit();
                            fill_dgv_debit(dtb);
                            clear_Debit();
                            btnsubmit.Text = "Submit";
                            comboaccountname_SelectedIndexChanged(null, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear_Debit()
        {
            textBox_add_template.Clear();
            textamount.Clear();
            textBox_add_template.Clear();
            dateTimePickerdate.Text = DateTime.Now.ToShortDateString();
        }
        private void Expense_Load(object sender, EventArgs e)
        {
            panel1.Show();
            grpb_Credit.Visible = true;
            grp_Debit.Visible = true;
            panel6.Hide();
            pageloadhide();
            databindcombo();
            databindcombo2();
            calculateexpense();
            calculateincome();
            Bindcomboincome();
            dateTimePickerdate.Value = DateTime.Now;
            dateTimePickerincome.Value = DateTime.Now;
            Lab_reports.BackColor = Color.DodgerBlue;
            Lab_reports.ForeColor = Color.White;
            if (comboaccountname.Items.Count > 0)
            {
                comboaccountname.SelectedIndex = comboaccountname.Items.Count - 1;
            }
            if (comboBoxincomacc.Items.Count > 0)
            {
                comboBoxincomacc.SelectedIndex = comboBoxincomacc.Items.Count - 1;
            }
            Dgv_Debit.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Debit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Debit.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            Dgv_Debit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Dgv_Debit.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in Dgv_Debit.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_credit.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_credit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_credit.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dgv_credit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_credit.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dgv_credit.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            Grid_expense.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Grid_expense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Grid_expense.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            Grid_expense.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in Grid_expense.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            grp_Debit.Height = 636;
            grp_Debit.Width = 1070;
            grp_Debit.Location = new Point(6, 10);
            Dgv_Debit.Location = new Point(8, 265);
            grpb_Credit.Location = new Point(6, 10);
            dgv_credit.Location = new Point(8, 265);
        }
        public void pageloadhide()
        {
            errorProvider1.Clear();
        }
        public void Bindcomboincome()
        {
            try
            {
                DataTable dt1 = this.cntrl.Bindcomboincome();
                comboBoxincomacc.DataSource = dt1;
                comboBoxincomacc.DisplayMember = "name";
                comboBoxincomacc.ValueMember = "id";
                Check_Value1 = 1;
                DataTable dtb = this.cntrl.expense_search4(dateTimeEntrydate.Value.ToString("yyyy-MM-dd"), dateTimePickertodate.Value.ToString("yyyy-MM-dd"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void databindcombo()
        {
            try
            {
                DataTable dt1 = this.cntrl.databindcombo();
                comboaccountname.DataSource = dt1;
                comboaccountname.DisplayMember = "name";
                comboaccountname.ValueMember = "id";
                Check_Value = 1;
                this.cntrl.expense_search4(dateTimeEntrydate.Value.ToString("yyyy-MM-dd"), dateTimePickertodate.Value.ToString("yyyy-MM-dd"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void databindcombo2()
        {
            try
            {
                DataTable dt1 = this.cntrl.databindcombo2();
                comboSearch.DataSource = dt1;
                comboSearch.DisplayMember = "name";
                comboSearch.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fill_dgv_debit(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                Dgv_Debit.RowCount = 0;
                int row = 0;
                Dgv_Debit.Width = 1047;
                Dgv_Debit.Height = 330;
                foreach (DataRow dr in dtb.Rows)
                {
                    Dgv_Debit.Rows.Add();
                    Dgv_Debit.Rows[row].Cells["ColId"].Value = dr["id"].ToString();
                    Dgv_Debit.Rows[row].Cells["colDescrpt"].Value = dr["description"].ToString();
                    Dgv_Debit.Rows[row].Cells["colAmount"].Value = Convert.ToDecimal(dr["amount"].ToString()).ToString("#0.00");
                    Dgv_Debit.Rows[row].Cells["colLedgr"].Value = dr["nameofperson"].ToString();
                    Dgv_Debit.Rows[row].Cells["colName"].Value = dr["expense_type"].ToString();
                    Dgv_Debit.Rows[row].Cells["colDate"].Value = dr["date"].ToString();
                    row++;
                }
                PutSLNO();
            }
            if (Dgv_Debit.Rows.Count > 0)
            {
                Dgv_Debit.RowsDefaultCellStyle.ForeColor = Color.DarkSlateGray;
                Dgv_Debit.RowsDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 8, FontStyle.Regular);
                Dgv_Debit.Columns["colAmount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                Dgv_Debit.Columns["colAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void btn_Creditcancel_Click(object sender, EventArgs e)
        {
            btnincomesubmit.Text = "Submit";
            Lnk_AddNewCrdit.Visible = true;
            Clear_Incom();
            comboBoxincomacc_SelectedIndexChanged(null, null);
            btn_Creditcancel.Visible = false;
            dateTimePickerincome.Value = DateTime.Now;
        }
        public void Clear_Incom()
        {
            txtamountincome.Text = "";
            textBoxnameofincome.Text = "";
            textBoxdescincome.Text = "";
            comboBoxincomacc.Text = "";
        }
        public void Clear()
        {
            textamount.Text = "";
            textperson.Text = "";
            textBox_add_template.Text = "";
            comboaccountname.Text = "";
        }
        private void Dgv_Debit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    if (Dgv_Debit.Rows.Count > 0)
                    {
                        rowindex = Convert.ToInt32(Dgv_Debit.CurrentRow.Cells["ColId"].Value.ToString());
                        if (Dgv_Debit.CurrentCell.OwningColumn.Name == "ColEdit")
                        {
                            int rw = Dgv_Debit.CurrentRow.Index;
                            //if (rw != null)
                            {
                                Clear();
                                comboaccountname.Text = Dgv_Debit.Rows[rw].Cells["colName"].Value.ToString();
                                textamount.Text = Dgv_Debit.Rows[rw].Cells["colAmount"].Value.ToString();
                                textperson.Text = Dgv_Debit.Rows[rw].Cells["colLedgr"].Value.ToString();
                                textBox_add_template.Text = Dgv_Debit.Rows[rw].Cells["colDescrpt"].Value.ToString();
                                DateTime dt;
                                dt = Convert.ToDateTime( Dgv_Debit.Rows[rw].Cells["colDate"].Value.ToString());
                                dateTimePickerdate.Text= dt.ToString("dd/MM/yyyy");
                                btnsubmit.Text = "Update";
                                btn_DebitCancel.Visible = true;
                                Lnk_AddNew.Visible = false;
                            }
                        }
                        else if (Dgv_Debit.CurrentCell.OwningColumn.Name == "ColDel")
                        {
                            int index = Dgv_Debit.CurrentRow.Index;
                            //if (rowindex != null)
                            {
                                DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res == DialogResult.No)
                                {
                                }
                                else
                                {
                                    int j = this.cntrl.dgv_debit_delete(rowindex);
                                    if (j > 0)
                                    {
                                        Dgv_Debit.Rows.RemoveAt(index);
                                        DataTable dtb = this.cntrl.fill_dgv_debit();
                                        fill_dgv_debit(dtb);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_DebitCancel_Click(object sender, EventArgs e)
        {
            btnsubmit.Text = "Submit";
            Lnk_AddNew.Visible = true;
            Clear();
            comboaccountname_SelectedIndexChanged(null, null);
            btn_DebitCancel.Visible = false;
            dateTimePickerdate.Value = DateTime.Now;
        }

        private void check_Type_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (check_Type.Checked == true)
                {
                    radio_income.Enabled = true;
                    radio_expense.Enabled = true;
                    exp_Type = "Income";
                    if (radio_income.Checked == true)
                    {
                        DataTable dt1 = this.cntrl.check_type_creditselect();
                        comboSearch.DataSource = dt1;
                        comboSearch.DisplayMember = "name";
                        comboSearch.ValueMember = "id";
                        exp_Type = "Income";
                    }
                }
                else
                {
                    radio_income.Enabled = false;
                    radio_expense.Enabled = false;
                    DataTable dt1 = this.cntrl.check_type_exp2();
                    comboSearch.DataSource = dt1;
                    comboSearch.DisplayMember = "name";
                    comboSearch.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void check_Account_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Account.Checked == true)
            {
                comboSearch.Enabled = true;
            }
            else
            {
                comboSearch.Enabled = false;
            }
        }

        private void radio_expense_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_expense.Checked == true)
                {
                    DataTable dt1 = this.cntrl.expense_checked();
                    comboSearch.DataSource = dt1;
                    comboSearch.DisplayMember = "name";
                    comboSearch.ValueMember = "id";
                    exp_Type = "Expense";
                }
                else
                {
                    DataTable dt1 = this.cntrl.expense_checked();
                    comboSearch.DataSource = dt1;
                    comboSearch.DisplayMember = "name";
                    comboSearch.ValueMember = "id";
                    exp_Type = " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radio_income_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radio_income.Checked == true)
                {
                    DataTable dt1 = this.cntrl.check_type_creditselect();
                    comboSearch.DataSource = dt1;
                    comboSearch.DisplayMember = "name";
                    comboSearch.ValueMember = "id";
                    exp_Type = "Income";
                }
                else
                {
                    DataTable dt1 = this.cntrl.expense_checked();
                    comboSearch.DataSource = dt1;
                    comboSearch.DisplayMember = "name";
                    comboSearch.ValueMember = "id";
                    exp_Type = " ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimeEntrydate_CloseUp(object sender, EventArgs e)
        {
            var d1 = dateTimeEntrydate.Value.ToShortDateString();
            var d2 = dateTimePickertodate.Value.ToShortDateString();
            if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
            {
                MessageBox.Show("From date should be less than To date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimeEntrydate.Value = DateTime.Today;
            }
        }

        private void dateTimePickertodate_CloseUp(object sender, EventArgs e)
        {
            var d1 = dateTimeEntrydate.Value.ToShortDateString();
            var d2 = dateTimePickertodate.Value.ToShortDateString();
            if (Convert.ToDateTime(d1).Date > Convert.ToDateTime(d2).Date)
            {
                MessageBox.Show("From date should be less than To date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimePickertodate.Value = DateTime.Today;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                FromDate = dateTimeEntrydate.Value.ToString("dd/MM/yyyy");
                ToDate = dateTimePickertodate.Value.ToString("dd/MM/yyyy");
                if (check_Type.Checked && check_Account.Checked)
                {
                    if (Grid_expense.Columns.Contains("Column"))
                    {
                        Grid_expense.Columns.Remove("Column");
                    }
                    DataTable dtb = this.cntrl.expense_search(comboSearch.Text, exp_Type, dateTimeEntrydate.Value.ToString("yyyy-MM-dd"), dateTimePickertodate.Value.ToString("yyyy-MM-dd"));
                    fill_search(dtb);
                }
                if (check_Type.Checked && !check_Account.Checked)
                {
                    if (Grid_expense.Columns.Contains("Column"))
                    {
                        Grid_expense.Columns.Remove("Column");
                    }
                    DataTable dtb = this.cntrl.expense_search2(exp_Type, dateTimeEntrydate.Value.ToString("yyyy-MM-dd"), dateTimePickertodate.Value.ToString("yyyy-MM-dd"));
                    fill_search(dtb);
                }
                if (!check_Type.Checked && check_Account.Checked)
                {
                    if (Grid_expense.Columns.Contains("Column"))
                    {
                        Grid_expense.Columns.Remove("Column");
                    }
                    DataTable dtb = this.cntrl.expense_search3(comboSearch.Text, dateTimeEntrydate.Value.ToString("yyyy-MM-dd"), dateTimePickertodate.Value.ToString("yyyy-MM-dd"));
                    fill_search2(dtb);
                }
                if (!check_Type.Checked && !check_Account.Checked)
                {
                    if (Grid_expense.Columns.Contains("Column"))
                    {
                        Grid_expense.Columns.Remove("Column");
                    }
                    DataTable dtb = this.cntrl.expense_search4(dateTimeEntrydate.Value.ToString("yyyy-MM-dd"), dateTimePickertodate.Value.ToString("yyyy-MM-dd"));
                    fill_search2(dtb);
                }
            }
            catch
            {
                MessageBox.Show("Report Error..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Grid_expense_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                id = Grid_expense.Rows[r].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fill_search(DataTable dt_templates)
        {
            Grid_expense.DataSource = dt_templates;
            Grid_expense.Columns.Add("Column", "Cr/Dr");
            Grid_expense.Columns["Column"].Width = 60;
            if (Grid_expense.Rows.Count > 0)
            {
                for (int i = 0; i < Grid_expense.Rows.Count; i++)
                {
                    Grid_expense.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
            if (exp_Type == "Expense")
            {
                if (Grid_expense.Rows.Count > 0)
                {
                    for (int i = 0; i < Grid_expense.Rows.Count; i++)
                    {
                        Grid_expense.Rows[i].Cells[10].Value = "Dr";
                    }
                }
            }
            if (exp_Type == "Income")
            {
                if (Grid_expense.Rows.Count > 0)
                {
                    for (int i = 0; i < Grid_expense.Rows.Count; i++)
                    {
                        Grid_expense.Rows[i].Cells[10].Value = "Cr";
                    }
                }
            }
            calculateexpense();
            calculateincome();
        }
        public void fill_search2(DataTable dt_templates)
        {
            Grid_expense.DataSource = dt_templates;
            if (Grid_expense.Rows.Count > 0)
            {
                for (int i = 0; i < Grid_expense.Rows.Count; i++)
                {
                    Grid_expense.Rows[i].Cells[0].Value = (i + 1).ToString();
                }
            }
            calculateexpense();
            calculateincome();
        }
        public void calculateexpense()
        {
            int sum = 0;
            for (int i = 0; i < Grid_expense.Rows.Count; ++i)
            {
                if (Grid_expense.Rows[i].Cells["Column6"].Value.ToString() == "Expense")
                {
                    sum += Convert.ToInt32(Grid_expense.Rows[i].Cells[6].Value);
                }
            }
            lblcalculate.Text = sum.ToString("##.00");
        }

        public void calculateincome()
        {
            int sum = 0;
            for (int i = 0; i < Grid_expense.Rows.Count; ++i)
            {
                if (Grid_expense.Columns.Contains("Column"))
                {
                    sum += Convert.ToInt32(Grid_expense.Rows[i].Cells[9].Value);
                }
                else
                {
                    sum += Convert.ToInt32(Grid_expense.Rows[i].Cells[9].Value);
                }
            }
            labelincome.Text = sum.ToString("#.00");
        }

        private void buttoprint_Click(object sender, EventArgs e)
        {
            try
            {
                int c = 0; string strStreet = "";
                string strclinicname = "";
                string strphone = "";
                DataTable dtp = this.cntrl.print();
                if (dtp.Rows.Count > 0)
                {
                    strphone = dtp.Rows[0]["contact_no"].ToString();
                    string clinicn = "";
                    clinicn = dtp.Rows[0]["name"].ToString();
                    strclinicname = clinicn.Replace("¤", "'");
                    strStreet = dtp.Rows[0]["street_address"].ToString();
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\ExpenseReport.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("<style>");
                sWrite.WriteLine("table { border-collapse: collapse;}");
                sWrite.WriteLine("p.big {line-height: 400%;}");
                sWrite.WriteLine("</style>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<div>");
                sWrite.WriteLine("<table align=center width=100%>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<th colspan=7><center><FONT COLOR=black FACE='segoe UI' SIZE=3> EXPENSE/INCOME REPORTS </font></center></th>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=7><left><FONT COLOR=black FACE='segoe UI' SIZE=3>" + strclinicname + "</font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=7><left><FONT COLOR=black FACE='segoe UI' SIZE=1>" + strStreet + "</font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=7><left><FONT COLOR=black FACE='segoe UI' SIZE=1>" + strphone + "</font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td colspan=7><left><FONT COLOR=black FACE='segoe UI' SIZE=2> From:" + dateTimeEntrydate.Value.ToString("dd/MM/yyyy") + "</font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<td colspan=7><left><FONT COLOR=black FACE='segoe UI' SIZE=2>  To:" + dateTimePickertodate.Value.ToString("dd/MM/yyyy") + "  </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<td colspan=7><left><FONT COLOR=black FACE='segoe UI' SIZE=2>  Printed Date:" + DateTime.Now.ToString("dd/MM/yyyy") + "  </font></left></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("    <td align='center' width='4%' style='border:1px solid #000;background-color:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3 >&nbsp;Sl.</font></td>");
                sWrite.WriteLine("    <td align='center' width='5%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;Date</font></td>");
                sWrite.WriteLine("    <td align='center' width='6%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;Transaction Type</font></td>");
                sWrite.WriteLine("    <td align='center' width='24%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;Ledger</font></td>");
                sWrite.WriteLine("    <td align='center' width='23%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;Account Name</font></td>");
                sWrite.WriteLine("    <td align='center' width='17%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;Amount</font></td>");
                sWrite.WriteLine("    <td align='center' width='21%' style='border:1px solid #000;background:#999999'><FONT COLOR=black FACE='segoe UI' SIZE=3> &nbsp;Desciption</font></td>");
                sWrite.WriteLine("</tr>");
                c = 1;
                for (int i = 0; i < Grid_expense.Rows.Count; i++)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + c + "</font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + Convert.ToDateTime(Grid_expense.Rows[i].Cells["Column7"].Value.ToString()).ToString("dd/MM/yyyy") + "</font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + Grid_expense.Rows[i].Cells["Column6"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + Grid_expense.Rows[i].Cells["Column5"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + Grid_expense.Rows[i].Cells["Column4"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("    <td align='right' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + Convert.ToDouble(Grid_expense.Rows[i].Cells["Column3"].Value.ToString()).ToString("0.00") + "</font></td>");
                    sWrite.WriteLine("    <td align='left' style='border:1px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>" + Grid_expense.Rows[i].Cells["Column2"].Value.ToString() + "</font></td>");
                    sWrite.WriteLine("</tr>");
                    c = c + 1;
                }
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td align='right' style='border:0px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>Total Expense:</font></b></td>");
                sWrite.WriteLine("    <td align='right' style='border:0px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=3><b>" + lblcalculate.Text + "</b></font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td ></td>");
                sWrite.WriteLine("    <td align='right' style='border:0px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=2>Total Income:</font></b></td>");
                sWrite.WriteLine("    <td align='right' style='border:0px solid #000' ><FONT COLOR=black FACE='segoe UI' SIZE=3><b>" + labelincome.Text + "</b></font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</div>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\ExpenseReport.html");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Report Error..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void export()
        {
            //string checkStr = "0";
            string PathName = "";
            try
            {
                if (Grid_expense.Rows.Count != 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel Files (*.xml)|*.xml";
                    saveFileDialog1.FileName = "Expense Report(" + DateTime.Now.ToString("dd-MM-yy h.mm.ss tt") + ").xml";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        PathName = saveFileDialog1.FileName;
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);
                        ExcelApp.Columns.ColumnWidth = 20;
                        int count = Grid_expense.Columns.Count;
                        ExcelApp.Range[ExcelApp.Cells[1, 1], ExcelApp.Cells[1, count - 3]].Merge();
                        ExcelApp.Cells[1, 1] = "INCOME/EXPENSE REPORT";
                        ExcelApp.Cells[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
                        ExcelApp.Cells[1, 1].Font.Size = 12;
                        ExcelApp.Cells[1, 1].Interior.Color = Color.FromArgb(153, 204, 255);
                        ExcelApp.Columns.ColumnWidth = 20;
                        ExcelApp.Cells[2, 1] = "From Date";
                        ExcelApp.Cells[2, 1].Font.Size = 10;
                        ExcelApp.Cells[3, 1] = "To Date";
                        ExcelApp.Cells[3, 1].Font.Size = 10;
                        ExcelApp.Cells[2, 2] = dateTimeEntrydate.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[2, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2] = dateTimePickertodate.Value.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[3, 2].Font.Size = 10;
                        ExcelApp.Cells[3, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[4, 1] = "Running Date";
                        ExcelApp.Cells[4, 1].Font.Size = 10;
                        ExcelApp.Cells[4, 2] = DateTime.Now.ToString("dd-MM-yyyy");
                        ExcelApp.Cells[4, 2].Font.Size = 10;
                        ExcelApp.Cells[4, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        ExcelApp.Cells[2, 2].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                        bool cash = false, c = false; bool cash1 = false, cc = false; int i1 = 1, j1 = 1;
                        for (int i = 1; i < Grid_expense.Columns.Count + 1; i++)
                        {
                            i1 = i;
                            if (i == 2)
                            {
                                cash = true; c = false;
                            }
                            else if (i == 8 || i == 10)
                            {
                                cash = false; c = true;
                            }
                            else
                            {
                                if (cash == true)
                                {
                                    i1 = i1 - 1;
                                }
                                else if (c == true)
                                {
                                    i1 = i1 - 2;
                                }
                                ExcelApp.Cells[5, i1] = Grid_expense.Columns[i - 1].HeaderText;
                                ExcelApp.Cells[5, i1].ColumnWidth = 25;
                                ExcelApp.Cells[5, i1].EntireRow.Font.Bold = true;
                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);
                                ExcelApp.Cells[5, i1].Font.Size = 10;
                                ExcelApp.Cells[5, i1].Font.Name = "Segoe UI";
                                ExcelApp.Cells[5, i1].Font.Color = Color.FromArgb(255, 255, 255);
                                ExcelApp.Cells[5, i1].Interior.Color = Color.FromArgb(0, 102, 204);

                            }
                        }
                        for (int i = 0; i <= Grid_expense.Rows.Count; i++)
                        {
                            try
                            {

                                for (int j = 0; j < Grid_expense.Columns.Count; j++)
                                {
                                    j1 = j;
                                    if (j == 1)
                                    {
                                        cash1 = true; cc = false;
                                    }
                                    else if (j == 7 || j == 9)
                                    {
                                        cash1 = false; cc = true;
                                    }
                                    else
                                    {
                                        if (cash1 == true)
                                        {
                                            j1 = j1 - 1;
                                        }
                                        else if (cc == true)
                                        {
                                            j1 = j1 - 2;
                                        }
                                        ExcelApp.Cells[i + 6, j1 + 1] = Grid_expense.Rows[i].Cells[j].Value.ToString();
                                        ExcelApp.Cells[i + 6, j1 + 1].BorderAround(true);
                                        ExcelApp.Cells[i + 6, j1 + 1].Borders.Color = Color.FromArgb(0, 102, 204);
                                        ExcelApp.Cells[i + 6, j1 + 1].Font.Size = 8;
                                    }

                                }
                                cash1 = false; cc = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        ExcelApp.ActiveWorkbook.SaveAs(PathName, Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange);
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        //checkStr = "1";
                        MessageBox.Show("Successfully Exported to Excel", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                    MessageBox.Show("No records found, Please change the date and try again!..", "No Records Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntreport_Click(object sender, EventArgs e)
        {
            export();
        }

        private void textamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }
        public void onlynumwithsinglepoint(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == '.'))
            { e.Handled = true; }
            TextBox txtDecimal = sender as TextBox;
            if (e.KeyChar == '.' && txtDecimal.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtamountincome_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlynumwithsinglepoint(sender, e);
        }

        private void Grid_expense_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                id = Grid_expense.Rows[r].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class DisplayFormatAttribute : Attribute
        {
            public bool ApplyFormatInEditMode { get; set; }
            public string DataFormatString { get; set; }
        }
    }
}
