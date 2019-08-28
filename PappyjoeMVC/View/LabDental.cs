using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class LabDental : Form
    {
        LabDental_controller cntrl = new LabDental_controller();
        public LabDental()
        {
            InitializeComponent();
        }

        private void LabDental_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dentalwork = this.cntrl.Show_DentalWork();
                dgvdentalwork.DataSource = dentalwork;

                dgvdentalwork.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvdentalwork.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvdentalwork.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvdentalwork.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvdentalwork.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvLabs.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dgvLabs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvLabs.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dgvLabs.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dgvLabs.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtworkname.Text))
                {
                    MessageBox.Show("Enter the Work Name...", "Data not found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtworkname.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtworktype.Text))
                {
                    MessageBox.Show("Enter the Work Type...", "Data not found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtworktype.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtshade.Text))
                {
                    MessageBox.Show("Enter the Shade...", "Data not found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtshade.Focus();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(txtalloy.Text))
                {
                    MessageBox.Show("Enter the Alloy...", "Data not found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtalloy.Focus();
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtworkname.Text) && !string.IsNullOrWhiteSpace(txtworktype.Text) && !string.IsNullOrWhiteSpace(txtshade.Text) && !string.IsNullOrWhiteSpace(txtalloy.Text))
                {
                    string mystring = txtworkname.Text;
                    txtworkname.Text = mystring.Replace("'", " ");
                    mystring = txtworktype.Text;
                    txtworktype.Text = mystring.Replace("'", " ");
                    mystring = txtshade.Text;
                    txtshade.Text = mystring.Replace("'", " ");
                    mystring = txtalloy.Text;
                    txtalloy.Text = mystring.Replace("'", " ");
                    if (button1.Text == "SAVE")
                    {
                        this.cntrl.DentalWork_Save(txtworktype.Text, txtworkname.Text, txtshade.Text, txtalloy.Text);
                    }
                    else
                    {
                        if (txtwork.Text != "")
                        {
                            this.cntrl.DentalWork_update(txtworktype.Text, txtworkname.Text, txtshade.Text, txtalloy.Text, txtwork.Text);
                            button1.Text = "SAVE";
                        }
                    }
                    DataTable dentalwork = this.cntrl.Show_DentalWork();
                    dgvdentalwork.DataSource = dentalwork;
                    MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txttooth.Clear();
                    txtworktype.Clear();
                    txtworkname.Clear();
                    txtshade.Clear();
                    txtalloy.Clear();
                }
                else
                {
                    MessageBox.Show("Enter the details...", "Data not found..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtalloy.Clear();
            txtshade.Clear();
            txttooth.Clear();
            txtworkname.Clear();
            txtworktype.Clear();
            if (button1.Text == "UPDATE")
            {
                button1.Text = "SAVE";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtLabname.Text))
                {
                    string mystring = txtLabname.Text;
                    txtLabname.Text = mystring.Replace("'", " ");

                    if (button2.Text == "SAVE")
                    {
                        this.cntrl.Laborat_Save(txtLabname.Text, txtAddress.Text, txtPhone.Text, txtExecutive.Text, cmblabtype.Text);
                    }
                    else
                    {
                        if (txtlabid.Text != "")
                        {
                            this.cntrl.Labora_Update(txtLabname.Text, txtAddress.Text, txtPhone.Text, txtExecutive.Text, cmblabtype.Text, txtlabid.Text);
                            button2.Text = "SAVE";
                        }
                    }
                    DataTable dentalwork = this.cntrl.Laborat_Show();
                    dgvLabs.DataSource = dentalwork;
                    MessageBox.Show("Successfully Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAddress.Clear();
                    txtLabname.Clear();
                    txtPhone.Clear();
                    txtExecutive.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tpDenatl_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dentalwork = this.cntrl.Laborat_Show();
                dgvLabs.DataSource = dentalwork;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvdentalwork_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indexRow = e.RowIndex; // get the selected Row Index
                if (indexRow != -1)
                {
                    DataGridViewRow row = dgvdentalwork.Rows[indexRow];
                    txtwork.Text = dgvdentalwork.Rows[indexRow].Cells[3].Value.ToString();
                    if (e.ColumnIndex == 1)
                    {
                        txtworkname.Text = dgvdentalwork.Rows[indexRow].Cells[4].Value.ToString();
                        txtworktype.Text = dgvdentalwork.Rows[indexRow].Cells[5].Value.ToString();
                        txtshade.Text = dgvdentalwork.Rows[indexRow].Cells[6].Value.ToString();
                        txtalloy.Text = dgvdentalwork.Rows[indexRow].Cells[7].Value.ToString();
                        button1.Text = "UPDATE";
                    }
                    else if (e.ColumnIndex == 2)
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete...?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.Del_DentalWork(txtwork.Text);
                            DataTable dentalwork = this.cntrl.Show_DentalWork();
                            dgvdentalwork.DataSource = dentalwork;
                            txttooth.Clear();
                            txtworktype.Clear();
                            txtworkname.Clear();
                            txtshade.Clear();
                            txtalloy.Clear();
                            txtwork.Text = "";
                            button1.Text = "SAVE";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLabs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int indexRow = e.RowIndex; // get the selected Row Index
                if (indexRow != -1)
                {
                    DataGridViewRow row = dgvLabs.Rows[indexRow];
                    txtlabid.Text = dgvLabs.Rows[indexRow].Cells[2].Value.ToString();
                    if (e.ColumnIndex == 0)
                    {
                        txtLabname.Text = dgvLabs.Rows[indexRow].Cells[3].Value.ToString();
                        cmblabtype.Text = dgvLabs.Rows[indexRow].Cells[4].Value.ToString();
                        txtAddress.Text = dgvLabs.Rows[indexRow].Cells[5].Value.ToString();
                        txtPhone.Text = dgvLabs.Rows[indexRow].Cells[6].Value.ToString();
                        txtExecutive.Text = dgvLabs.Rows[indexRow].Cells[7].Value.ToString();
                        button2.Text = "UPDATE";
                    }
                    else if (e.ColumnIndex == 1)
                    {

                        DialogResult res = MessageBox.Show("Are you sure you want to delete?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.Del_Lab(txtlabid.Text);
                            DataTable dentalwork = this.cntrl.Laborat_Show();
                            dgvLabs.DataSource = dentalwork;
                            txtLabname.Clear();
                            txtAddress.Clear();
                            txtPhone.Clear();
                            txtExecutive.Clear();
                            txtlabid.Text = "";
                            button2.Text = "SAVE";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtLabname.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtExecutive.Clear();
            txtlabid.Text = "";
            if (button2.Text == "UPDATE")
            {
                button2.Text = "SAVE";
            }
        }
    }
}
