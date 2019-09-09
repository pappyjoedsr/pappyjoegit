using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace PappyjoeMVC.View
{
    public partial class Purchase_Batch : Form
    {
        purchasebatch_controller cntrl = new purchasebatch_controller();
        public bool Addflag = false;
        public bool editflag = false;
        public string unit1;
        public int qtyE;
        int Count;
        string itemid1;
        DataTable editgrid1 = new DataTable(); public static DataTable gridData = new DataTable();
        private string form_name;
        bool ermsg = false, flagbatchError = false, flagdateError = false;
        int flag = 0;
        private string text1;
        private string text2;
        private DataTable editgrid;
        private int qty;
        string Itemcode = "", purNo = "";
        private string item_id;

        public Purchase_Batch()
        {
            InitializeComponent();
        }
        public Purchase_Batch(string text1, string text2, string item_id, DataTable editgrid, int qty, string form_name, string text)
        {
            InitializeComponent();
            unit1 = text1;
            Itemcode = text2;
            itemid1 = item_id;
            editgrid1 = editgrid;
            qtyE = qty;
            this.form_name = form_name;
            purNo = text;
            editflag = true;
        }

        public Purchase_Batch(string text1, int qty, string text2, string item_id, string text)
        {
            InitializeComponent();
            unit1 = text1;
            qtyE = qty;
            Itemcode = text2;
            itemid1 = item_id;
            purNo = text;
            Addflag = true;
        }
        private void frmpurchaseBatch_Load(object sender, EventArgs e)
        {
            try
            {
                DataGridViewComboBoxColumn cmb_Period = new DataGridViewComboBoxColumn();
                cmb_Period.HeaderText = "Period";
                cmb_Period.Name = "prd";
                dgvPurchaseBatch.Columns.Insert(5, cmb_Period);
                cmb_Period.Items.Add("Day");
                cmb_Period.Items.Add("Week");
                cmb_Period.Items.Add("Month");
                cmb_Period.Items.Add("Year");
                DataTable dtb = this.cntrl.check_batch(itemid1);
                if (Addflag == true)
                {
                    dgvPurchaseBatch.Rows.Clear();
                    dgvPurchaseBatch.Rows[0].Cells["col_Unit"].Value = unit1.ToString();
                    dgvPurchaseBatch.Rows[0].Cells["Quantity"].Value = qtyE.ToString();
                }
                else if (editflag == true)
                {
                    dgvPurchaseBatch.Rows.Clear();
                    for (int i = 0; i < editgrid1.Rows.Count; i++)
                    {
                        dgvPurchaseBatch.Rows.Add();
                        dgvPurchaseBatch.Rows[i].Cells["Branch_No"].Value = editgrid1.Rows[i]["Branch_No"].ToString();
                        dgvPurchaseBatch.Rows[i].Cells["Quantity"].Value = editgrid1.Rows[i]["col_temp_qty"].ToString();
                        dgvPurchaseBatch.Rows[i].Cells["Prd_Date"].Value = editgrid1.Rows[i]["Prd_Date"].ToString();
                        dgvPurchaseBatch.Rows[i].Cells["Exp_Date"].Value = editgrid1.Rows[i]["Exp_Date"].ToString();
                        dgvPurchaseBatch.Rows[i].Cells["col_Unit"].Value = unit1.ToString();
                        if (editgrid1.Rows[i]["period"].ToString() != "")
                        {
                            dgvPurchaseBatch.Rows[i].Cells["prd"].Value = editgrid1.Rows[i]["period"].ToString();
                        }
                    }
                }
                if (dtb.Rows[0]["ISBatch"].ToString() != "True")
                {
                    dgvPurchaseBatch.Rows[0].Cells["Branch_No"].Value = purNo + "_" + Itemcode;
                    dgvPurchaseBatch.Columns[0].ReadOnly = true;

                }
                else
                {
                    dgvPurchaseBatch.Columns[0].ReadOnly = false;
                }
                dgvPurchaseBatch.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvPurchaseBatch.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvPurchaseBatch.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dgvPurchaseBatch.EnableHeadersVisualStyles = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPurchaseBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvPurchaseBatch_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(dgvPurchaseBatch_KeyPress);
            if (dgvPurchaseBatch.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(dgvPurchaseBatch_KeyPress);
                }
            }
        }

        private void dtpExp_CloseUp(object sender, EventArgs e)
        {
            dtpExp.Visible = false;
        }

        private void dtpExp_ValueChanged(object sender, EventArgs e)
        {
            dgvPurchaseBatch.CurrentRow.Cells["Exp_Date"].Value = dtpExp.Text.ToString();
        }

        private void dgvPurchaseBatch_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPurchaseBatch.CurrentRow.Cells["col_Unit"].Value = unit1;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvPurchaseBatch.Rows.Count > 0)
            {
                this.Close();
            }
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            dgvPurchaseBatch.CurrentRow.Cells["Prd_Date"].Value = dtp.Text.ToString();
        }

        private void dgvPurchaseBatch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                dtp = new DateTimePicker();
                dgvPurchaseBatch.Controls.Add(dtp);
                dtp.Format = DateTimePickerFormat.Short;
                dtp.MaxDate = DateTime.Today.Date;
                Rectangle oRectangle = dgvPurchaseBatch.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtp.Size = new Size(oRectangle.Width, oRectangle.Height);
                dtp.Location = new Point(oRectangle.X, oRectangle.Y);
                dtp.CloseUp += new EventHandler(dtp_CloseUp);
                dtp.TextChanged += new EventHandler(dtp_ValueChanged);
                dtp.Visible = true;

            }
            if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                dtpExp = new DateTimePicker();
                dgvPurchaseBatch.Controls.Add(dtpExp);
                dtpExp.Format = DateTimePickerFormat.Short;
                dtpExp.MinDate = DateTime.Today.Date;
                Rectangle oRectangle = dgvPurchaseBatch.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                dtpExp.Size = new Size(oRectangle.Width, oRectangle.Height);
                dtpExp.Location = new Point(oRectangle.X, oRectangle.Y);
                dtpExp.CloseUp += new EventHandler(dtpExp_CloseUp);
                dtpExp.TextChanged += new EventHandler(dtpExp_ValueChanged);
                dtpExp.Visible = true;
            }
        }

        private void dtp_CloseUp(object sender, EventArgs e)
        {
            dtp.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPurchaseBatch.Rows.Count > 1)
                {
                    Count = dgvPurchaseBatch.Rows.Count - 1;
                }
                else
                {
                    Count = dgvPurchaseBatch.Rows.Count;
                }
                for (int i = 0; i < Count; i++)
                {
                    if (dgvPurchaseBatch.Rows[i].Cells["Branch_No"].Value == null || dgvPurchaseBatch.Rows[i].Cells["Branch_No"].Value.ToString().Trim() == "")
                    {
                        flagbatchError = true;
                    }
                    else
                    {
                        flagbatchError = false;
                    }
                    if (dgvPurchaseBatch.Rows[i].Cells["Prd_Date"].Value == null)
                    {
                        flagdateError = true;
                    }
                    else
                    {
                        flagdateError = false;
                    }
                }
                int sum = 0;
                if (editflag == true)
                {
                    if (flagbatchError != true && flagdateError != true)
                    {
                        foreach (DataGridViewRow r in dgvPurchaseBatch.Rows)
                        {
                            if (r.Cells["Branch_No"].Value != null && r.Cells["Branch_No"].Value.ToString().Trim() != "" && r.Cells["Prd_Date"].Value != null && r.Cells["Prd_Date"].Value.ToString() != "")
                            {
                                sum += Convert.ToInt32(r.Cells["Quantity"].Value);
                            }
                        }
                        if (qtyE == sum)
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                            ermsg = true;
                        }
                        if (flag == 1)
                        {
                            gridData.Columns.Clear();
                            gridData.Rows.Clear();
                            foreach (DataGridViewColumn col in dgvPurchaseBatch.Columns)
                            {
                                gridData.Columns.Add(col.Name);
                            }
                            foreach (DataGridViewRow row in dgvPurchaseBatch.Rows)
                            {
                                DataRow dRow = gridData.NewRow();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    dRow[cell.ColumnIndex] = cell.Value;
                                }
                                gridData.Rows.Add(dRow);
                            }
                            if (gridData.Rows.Count > 0)
                            {
                                var frm = new Purchase(gridData);
                                frm.Closed += (sender1, args) => this.Close();
                                this.Close();
                            }
                        }
                        else if (flag == 0)
                        {
                            if (ermsg == true)
                            {
                                MessageBox.Show("the entered quantity is mismatch!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            ermsg = false;
                        }
                    }
                    else if (flagbatchError == true && flagdateError == true)
                    {
                        MessageBox.Show("Enter the Batch Number and Manufacture Date!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (flagbatchError == true)
                    {
                        MessageBox.Show("Enter the Batch number!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (flagdateError == true)
                    {
                        MessageBox.Show("Enter the Manufacture Date!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (editflag == false)
                {
                    if (flagbatchError != true && flagdateError != true)
                    {
                        foreach (DataGridViewRow r in dgvPurchaseBatch.Rows)
                        {
                            if (r.Cells["Branch_No"].Value != null && r.Cells["Branch_No"].Value.ToString().Trim() != "")
                                if (r.Cells["Prd_Date"].Value != null && r.Cells["Prd_Date"].Value.ToString() != "")
                                {
                                    sum += Convert.ToInt32(r.Cells["Quantity"].Value);
                                }
                        }
                        if (qtyE == sum)
                        {
                            flag = 1;
                        }
                        else
                            flag = 0;
                        ermsg = true;
                        if (flag == 1)
                        {
                            gridData.Columns.Clear();
                            gridData.Rows.Clear();
                            foreach (DataGridViewColumn col in dgvPurchaseBatch.Columns)
                            {
                                gridData.Columns.Add(col.Name);
                            }
                            foreach (DataGridViewRow row in dgvPurchaseBatch.Rows)
                            {
                                DataRow dRow = gridData.NewRow();
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    dRow[cell.ColumnIndex] = cell.Value;
                                }
                                gridData.Rows.Add(dRow);
                            }
                            if (gridData.Rows.Count > 0)
                            {
                                var frm = new Purchase(gridData);
                                frm.Closed += (sender1, args) => this.Close();
                                this.Close();
                            }
                        }
                        else if (flag == 0)
                        {
                            if (ermsg == true)
                            {
                                MessageBox.Show("the entered quantity is mismatch!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            ermsg = false;
                        }
                    }
                    else if (flagbatchError == true && flagdateError == true)
                    {
                        MessageBox.Show("Enter the Batch Number and Manufacturing Date!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (flagbatchError == true)
                    {
                        MessageBox.Show("Enter the Batch number!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (flagdateError == true)
                    {
                        MessageBox.Show("Enter the Manufacture Date!.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
