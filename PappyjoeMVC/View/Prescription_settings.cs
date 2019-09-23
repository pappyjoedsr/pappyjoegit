using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Prescription_Settings : Form
    {
        Prescription_Setting_controller cntrl=new Prescription_Setting_controller();
        public string id = "";
        public Prescription_Settings()
        {
            InitializeComponent();
        }
          private void Prescription_settings_Load(object sender, EventArgs e)
        {
            DataTable dt = this.cntrl.get_drug();
            dataGridView_prescription.DataSource = dt;
            label30.Hide();
            label39.Hide();
            linkLabel3.Hide();
            linkLabel2.Hide();
            label30.Hide();
            text_unit.Hide();
            text_type.Hide();
            DataTable dtb = this.cntrl.fill_type_combo();
            FillTypeCombo(dtb);
            DataTable dtb_unit= this.cntrl.fill_unit_combo();
            FillUnitCombo(dtb_unit);
            dataGridView_prescription.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_prescription.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_prescription.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
            dataGridView_prescription.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_prescription.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView_prescription.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_prescription.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        public void FillTypeCombo(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                combotype.DataSource = dtb;
                combotype.DisplayMember = "dr_type";
                combotype.ValueMember = "id";
            }
        }
        public void FillUnitCombo(DataTable dtb)
        {
            if (dtb.Rows.Count > 0)
            {
                combo_unit.DataSource = dtb;
                combo_unit.DisplayMember = "name";
                combo_unit.ValueMember = "id";
            }
        }
   
        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                string StrUnit = "", StrType="";
                if (String.IsNullOrWhiteSpace(txtitemname.Text))
                {
                    errorProvider1.SetError(txtitemname, "error");
                    label30.Show();
                    return;
                }
                if (text_type.Visible == false)
                {
                    if (combotype.Text == "")
                    {
                        errorProvider1.SetError(combotype, "error");
                        label34.Show();
                        return;
                    }
                    StrType = combotype.Text;
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(text_type.Text))
                    {
                        errorProvider1.SetError(text_type, "error");
                        label34.Show();
                    }
                    DataTable dt_drug_type = this.cntrl.get_value_from_drugtype(text_type.Text);
                    if (dt_drug_type.Rows.Count == 0)
                    {
                        this.cntrl.SaveDrug(text_type.Text);
                        StrType = text_type.Text;
                    }
                }
                if (text_unit.Visible == false)
                {
                    StrUnit = combo_unit.Text;
                }
                else
                {
                   DataTable dt_drug_unit = this.cntrl.check_unit(StrUnit);
                    if (dt_drug_unit.Rows.Count == 0)
                    {
                        this.cntrl.save_unit(text_unit.Text);
                        StrUnit = text_unit.Text;
                    }
                }
                if (StrType != "" && StrUnit != "")
                {
                    if (button_save.Text == "Save")
                    {
                        string name = this.cntrl.check_drugname(txtitemname.Text);
                        if (name==txtitemname.Text)
                        {
                            MessageBox.Show("Drug " + txtitemname.Text + "' already existed", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            int i = this.cntrl.Save_Drug(txtitemname.Text, text_type.Text, text_unit.Text, text_strength.Text, rich_instruction.Text);
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        string dtb = this.cntrl.check_exists_drug(id);
                        if (Convert.ToInt32(dtb)>0)
                        {
                            MessageBox.Show("Cannot edit this drug, It is used in prescriptions...", "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            int i = this.cntrl.Update_drug(id,txtitemname.Text, text_type.Text, text_unit.Text, text_strength.Text, rich_instruction.Text);
                        }
                    }
                    DataTable dt = this.cntrl.get_drug();
                    dataGridView_prescription.DataSource = dt;
                    button_cancel.Visible = false;
                    txtitemname.Clear();
                    text_type.Clear();
                    combo_unit.Text = "";
                    combotype.Text = "";
                    text_unit.Clear();
                    rich_instruction.Clear();
                    text_strength.Clear();
                    button_save.Text = "Save";
                    combotype.Show();
                    button_addtype.Show();
                    text_type.Hide();
                    linkLabel2.Hide();
                    label34.Hide();
                    label39.Hide();
                    button_addunit.Show();
                    combo_unit.Show();
                    linkLabel3.Hide();
                    text_unit.Hide();
                    DataTable dtb_typr = this.cntrl.fill_type_combo();
                    FillTypeCombo(dtb_typr);
                    DataTable dtb_unit = this.cntrl.fill_unit_combo();
                    FillUnitCombo(dtb_unit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void txtitemname_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            label30.Hide();
        }

        private void combotype_SelectedIndexChanged(object sender, EventArgs e)
        {
            label39.Hide();
            label34.Hide();
            errorProvider1.Dispose();
        }
       
        private void dataGridView_prescription_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int r = e.RowIndex;
                    id = dataGridView_prescription.Rows[r].Cells["pid"].Value.ToString();
                    if (dataGridView_prescription.CurrentCell.OwningColumn.Name == "edit")
                    {
                        txtitemname.Text = dataGridView_prescription.CurrentRow.Cells["pname"].Value.ToString();
                        combotype.Text = dataGridView_prescription.CurrentRow.Cells["ptype"].Value.ToString();
                        text_strength.Text = dataGridView_prescription.CurrentRow.Cells["punit"].Value.ToString();
                        combo_unit.Text = dataGridView_prescription.CurrentRow.Cells["pstrength"].Value.ToString();
                        rich_instruction.Text = dataGridView_prescription.CurrentRow.Cells["pinstruction"].Value.ToString();
                        button_save.Text = "Update"; button_cancel.Visible = true;
                    }
                    else if (dataGridView_prescription.CurrentCell.OwningColumn.Name == "delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete this record?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {

                        }
                        else
                        {
                            string dtb = this.cntrl.check_exists_drug(id);
                            if (Convert.ToInt32(dtb)>0)
                            {
                                MessageBox.Show("Cannot edit this drug, It is used in prescriptions...", "Edit Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                int i = this.cntrl.delete_drug(id);
                                if (i > 0)
                                {
                                    DataTable dt = this.cntrl.get_drug();
                                    dataGridView_prescription.DataSource = dt;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Drug name not found..!!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_addunit_Click(object sender, EventArgs e)
        {
            button_addunit.Hide();
            combo_unit.Hide();
            linkLabel3.Show();
            text_unit.Show();
            text_unit.Focus();
        }

        private void button_addtype_Click(object sender, EventArgs e)
        {
            combotype.Hide();
            button_addtype.Hide();
            text_type.Focus();
            text_type.Show();
            linkLabel2.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            combotype.Show();
            button_addtype.Show();
            text_type.Hide();
            linkLabel2.Hide();
            label34.Hide();
            label39.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button_addunit.Show();
            combo_unit.Show();
            linkLabel3.Hide();
            text_unit.Hide();
        }

        private void text_presc_search_KeyUp(object sender, KeyEventArgs e)
        {
            DataTable dtb = this.cntrl.drug_search(text_presc_search.Text);
            dataGridView_prescription.DataSource = dtb;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            txtitemname.Clear();
            text_type.Clear();
            combo_unit.Text = "";
            combotype.Text = "";
            text_unit.Clear();
            rich_instruction.Clear();
            text_strength.Clear();
            button_save.Text = "Save";
            combotype.Show();
            button_addtype.Show();
            text_type.Hide();
            linkLabel2.Hide();
            label34.Hide();
            label39.Hide();
            button_addunit.Show();
            combo_unit.Show();
            linkLabel3.Hide();
            text_unit.Hide();
            button_cancel.Visible = false;
        }
    }
}

