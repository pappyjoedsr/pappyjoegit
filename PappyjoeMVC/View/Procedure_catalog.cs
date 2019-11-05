using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Procedure_Catalog : Form
    {
        Procedure_Catalog_controller cntrl=new Procedure_Catalog_controller();
        int refresh;
        public Procedure_Catalog()
        {
            InitializeComponent();
        }
        private void Procedure_catalog_Load(object sender, EventArgs e)
        {
            Dgv_Procedure.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            lab_Pro_nameError.Hide();
            lab_ProCost.Hide();
            txt_AddCategory.Hide();
            buttonSaveCategory.Hide();
            buttonrefresh.Show();
            btnAddNewCategory.Hide();
            if (checkaddunder.Checked == true)
            {
                comboaddunder.Show();
            }
            else
            {
                comboaddunder.Hide();
            }
            refresh = 1;
            DataTable dtb = this.cntrl.FormLoad();
            FormLoad(dtb);
            Dgv_Procedure.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_Procedure.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Procedure.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 10, FontStyle.Regular);
            Dgv_Procedure.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Dgv_Procedure.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in Dgv_Procedure.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void FormLoad(DataTable dt)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int rowNum = 0;
            Dgv_Procedure.Rows.Clear();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string id = dt.Rows[j]["id"].ToString();
                string taxname;
                if (dt.Rows[j]["tax_name"].ToString() == "NA")
                {
                    taxname = null;
                }
                else 
                {
                    taxname = dt.Rows[j]["tax_name"].ToString();
                }
                string procedurename = dt.Rows[j]["name"].ToString();
                string cost = dt.Rows[j]["cost"].ToString();
                string category = dt.Rows[j]["category"].ToString();
                string notes = dt.Rows[j]["notes"].ToString();
                string abc;
                if (taxname == null)
                {
                    abc = id + "" + taxname;
                }
                else
                {
                    abc = id + "," + taxname;
                }
                string abc1 = id + "," + procedurename;
                string abc2 = id + "," + cost;
                string abc3 = id + "," + category;
                string abc4 = id + "," + notes;
                string[] items = abc.Split(',');
                string[] items1 = abc1.Split(',');
                string[] items2 = abc2.Split(',');
                string[] items3 = abc3.Split(',');
                string[] items4 = abc4.Split(',');
                if (dict.ContainsKey(items[0]))
                {
                    if (Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value != null)
                    {
                        Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value += "," + items[1];
                    }
                }
                else
                {
                    dict.Add(items[0], rowNum);
                    Dgv_Procedure.Rows.Add(items[0], items1[1], items2[1], items[1], items4[1], items3[1]);
                    rowNum++;
                }
                Dgv_Procedure.Rows[dict[items[0]]].Cells[2].Value += "";
                Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value += "";
                Dgv_Procedure.Rows[dict[items[0]]].Cells[4].Value += "";
                Dgv_Procedure.Rows[dict[items[0]]].Cells[5].Value += "";
            }
        }
        private void txt_procedurename_TextChanged(object sender, EventArgs e)
        {
            lab_Pro_nameError.Hide();
            errorProvider1.Dispose();
        }
        private void txt_procedurecost_TextChanged(object sender, EventArgs e)
        {
            lab_ProCost.Hide();
            errorProvider1.Dispose();
        }
        private void checkaddunder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkaddunder.Checked == true)
            {
                comboaddunder.Show();
                DataTable dtb = this.cntrl.get_procedure_category_value();
                AddCategory(dtb);
                btnAddNewCategory.Show();  
            }
            else
            {
                comboaddunder.Hide();
                btnAddNewCategory.Hide();
                txt_AddCategory.Hide();
                buttonSaveCategory.Hide();
                btnAddNewCategory.Text = "Add New";
            }
        }
        public void AddCategory(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                comboaddunder.DataSource = dt;
                comboaddunder.DisplayMember = "name";
                comboaddunder.ValueMember = "id";
                comboaddunder.SelectedIndex = -1;
            }
        }
        private void comboaddunder_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.get_procedure_category_value();
            AddCategory(dtb);
        }

        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            if (btnAddNewCategory.Text == "Add New")
            {
                txt_AddCategory.Show();
                buttonSaveCategory.Show();
                btnAddNewCategory.Text = "Close";
                buttonSaveCategory.Show();
            }
            else
            {
                txt_AddCategory.Hide();
                btnAddNewCategory.Text = "Add New";
                buttonSaveCategory.Hide();
            }
        }
        private void buttonSaveCategory_Click(object sender, EventArgs e)
        {
            if (txt_AddCategory.Text != "")
            {
                DataTable dt = this.cntrl.Get_category_name(txt_AddCategory.Text);  
                if (dt.Rows.Count <= 0)
                {
                    this.cntrl.save(txt_AddCategory.Text);
                    txt_AddCategory.Hide();
                    buttonSaveCategory.Hide();
                    btnAddNewCategory.Text = "Add New";
                    txt_AddCategory.Text = "";
                }
                else
                {
                    MessageBox.Show("A category with same name already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txt_AddCategory.Focus();
            }
        }

        private void buttonsave_Click(object sender, EventArgs e)
        {
            buttonrefresh.Show();
            if (buttonsave.Text == "Save New Procedure")
            {
                if (txt_procedurename.Text.Trim() == "" || txt_procedurecost.Text.Trim() == "")
                {
                    if (txt_procedurename.Text.Trim() == "")
                    {
                        lab_Pro_nameError.Show();
                        errorProvider1.SetError(txt_procedurename, "error");
                        return;
                    }
                    if (txt_procedurecost.Text.Trim() == "")
                    {
                        lab_ProCost.Show();
                        errorProvider1.SetError(txt_procedurecost, "error");
                        return;
                    }
                }
                else
                {
                    DataTable dtb= this.cntrl.get_procedureName(txt_procedurename.Text);
                    GetProcedureName(dtb);
                    DataTable dt = this.cntrl.FormLoad();
                }
            }
        }
        public void GetProcedureName(DataTable checkdatacc)
        {
            try
            {
                if (checkdatacc.Rows.Count > 0)
                {
                    MessageBox.Show("Procedure " + txt_procedurename.Text + " already exist...", "Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int i = this.cntrl.save_addprocedure(txt_procedurename.Text, txt_procedurecost.Text, comboaddunder.Text, richnotes.Text);
                    DataTable dtb = this.cntrl.get_procedureid(txt_procedurename.Text);
                    string p = dtb.Rows[0]["id"].ToString();
                    int pid = int.Parse(p);
                    if (chk_gst.Checked == true)
                    {
                        string s = this.cntrl.Get_GST_id();
                        int id1 = int.Parse(s);
                        this.cntrl.save_proceduretax(id1, pid);
                    }
                    if (chk_igst.Checked == true)
                    {
                        string s = this.cntrl.Get_IGST_id();
                        int id1 = int.Parse(s);
                        this.cntrl.save_proceduretax(id1, pid);
                    }
                    txt_procedurename.Clear();
                    txt_procedurecost.Clear();
                    comboaddunder.Text = null;
                    richnotes.Clear();
                    chk_igst.Checked = false;
                    chk_gst.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonclear_Click(object sender, EventArgs e)
        {
            txt_procedurename.Text = "";
            txt_procedurecost.Text = "";
            richnotes.Text = "";
            lab_Pro_nameError.Hide();
            lab_ProCost.Hide();
            errorProvider1.Dispose();
            chk_gst.Checked = false;
            chk_igst.Checked = false;
            checkaddunder.Checked = false;
            buttonsave.Text = "Save New Procedure";
        }
        private void buttonrefresh_Click(object sender, EventArgs e)
        {
            if (refresh == 0)
            {
                Dgv_Procedure.Rows.Clear();
                DataTable dt = this.cntrl.FormLoad();
                Dictionary<string, int> dict = new Dictionary<string, int>();
                int rowNum = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string id = dt.Rows[j]["id"].ToString();
                    string taxname;
                    if (dt.Rows[j]["tax_name"].ToString() == "NA")
                    {
                        taxname = null;
                    }
                    else
                    {
                        taxname = dt.Rows[j]["tax_name"].ToString();
                    }
                    string procedurename = dt.Rows[j]["name"].ToString();
                    string cost = dt.Rows[j]["cost"].ToString();
                    string category = dt.Rows[j]["category"].ToString();
                    string notes = dt.Rows[j]["notes"].ToString();
                    string abc;
                    if (taxname == null)
                    {
                        abc = id + "" + taxname;
                    }
                    else
                    {
                        abc = id + "," + taxname;
                    }
                    string abc1 = id + "," + procedurename;
                    string abc2 = id + "," + cost;
                    string abc3 = id + "," + category;
                    string abc4 = id + "," + notes;
                    string[] items = abc.Split(',');
                    string[] items1 = abc1.Split(',');
                    string[] items2 = abc2.Split(',');
                    string[] items3 = abc3.Split(',');
                    string[] items4 = abc4.Split(',');
                    if (dict.ContainsKey(items[0]))
                    {
                        if (Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value != null)
                        {
                            Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value += " , " + items[1];
                        }
                    }
                    else
                    {
                        dict.Add(items[0], rowNum);
                        Dgv_Procedure.Rows.Add(items[0], items1[1], items2[1], items[1], items4[1], items3[1]);
                        rowNum++;
                    }
                    Dgv_Procedure.Rows[dict[items[0]]].Cells[2].Value += "";
                    Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value += "";
                    Dgv_Procedure.Rows[dict[items[0]]].Cells[4].Value += "";
                    Dgv_Procedure.Rows[dict[items[0]]].Cells[5].Value += "";
                }
                refresh = 1;
            }
            else
            {
                buttonsave.Text = "Save New Procedure";
                txt_procedurename.Clear();
                txt_procedurecost.Clear();
                comboaddunder.Text = null;
                richnotes.Clear();
                chk_igst.Checked = false;
                chk_gst.Checked = false;
            }
        }
        private void textsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }
        private void textsearch_KeyUp(object sender, KeyEventArgs e)
        {
            Dgv_Procedure.Rows.Clear();
            DataTable dt = this.cntrl.srchprocedure(textsearch.Text);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int rowNum = 0;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                string id = dt.Rows[j]["id"].ToString();
                string taxname;
                if (dt.Rows[j]["tax_name"].ToString() == null)
                {
                    taxname = null;
                }
                taxname = dt.Rows[j]["tax_name"].ToString();
                string procedurename = dt.Rows[j]["name"].ToString();
                string cost = dt.Rows[j]["cost"].ToString();
                string category = dt.Rows[j]["category"].ToString();
                string notes = dt.Rows[j]["notes"].ToString();
                string abc;
                if (taxname == null)
                {
                    abc = id + "" + taxname;
                }
                else
                {
                    abc = id + "," + taxname;
                }
                string abc1 = id + "," + procedurename;
                string abc2 = id + "," + cost;
                string abc3 = id + "," + category;
                string abc4 = id + "," + notes;
                string[] items = abc.Split(',');
                string[] items1 = abc1.Split(',');
                string[] items2 = abc2.Split(',');
                string[] items3 = abc3.Split(',');
                string[] items4 = abc4.Split(',');
                if (dict.ContainsKey(items[0]))
                {
                    if (Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value != null)
                    {
                        Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value += " , " + items[1];
                    }
                }
                else
                {
                    dict.Add(items[0], rowNum);
                    Dgv_Procedure.Rows.Add(items[0], items1[1], items2[1], items[1], items4[1], items3[1]);
                    rowNum++;
                }
                Dgv_Procedure.Rows[dict[items[0]]].Cells[2].Value += "";
                Dgv_Procedure.Rows[dict[items[0]]].Cells[3].Value += "";
                Dgv_Procedure.Rows[dict[items[0]]].Cells[4].Value += "";
                Dgv_Procedure.Rows[dict[items[0]]].Cells[5].Value += "";
            }
        }
        private void Dgv_Procedure_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int procedureid = Convert.ToInt32(Dgv_Procedure.CurrentRow.Cells[0].Value.ToString());
                    if (Dgv_Procedure.CurrentCell.OwningColumn.Name == "delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            int i = this.cntrl.delproceduretax(procedureid);
                            int ii= this.cntrl.delprocdresetngs(procedureid);
                            if (i > 0 &&ii>0)
                            {
                                Dgv_Procedure.Rows.RemoveAt(Dgv_Procedure.CurrentRow.Index);
                                DataTable dt = this.cntrl.FormLoad();
                                FormLoad(dt);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }      
    }
}
