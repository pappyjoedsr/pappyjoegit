﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;

namespace PappyjoeMVC.View
{
    public partial class Procedure_catalog : Form,procedure_catalog_interface
    {
        procedure_catalog_controller cntrl;
        string idd = null;
        int refresh;
        public Procedure_catalog()
        {
            InitializeComponent();
        }
        public string ProcedureName
        {
            get { return this.txt_procedurename.Text; }
            set { txt_procedurename.Text = value; }
        }
        public string ProcedCost
        {
            get { return this.txt_procedurecost.Text; }
            set { txt_procedurecost.Text = value; }
        }
        public string Notes
        {
            get { return this.richnotes.Text; }
            set { richnotes.Text = value; }
        }
        public string ComboCategory
        {
            get { return this.comboaddunder.Text; }
            set { comboaddunder.Text = value; }
        }
        public string TextCategory
        {
            get { return this.txt_AddCategory.Text; }
            set { txt_AddCategory.Text = value; }
        }
        public void SetController(procedure_catalog_controller controller)
        {
            cntrl = controller;
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
            this.cntrl.FormLoad();
            Dgv_Procedure.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            Dgv_Procedure.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_Procedure.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 11, FontStyle.Bold);
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
                //string abc = id + "," + taxname;
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
                this.cntrl.get_procedure_category_value();
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
            if(dt.Rows.Count>0)
            {
                comboaddunder.DataSource = dt;
                comboaddunder.DisplayMember = "name";
                comboaddunder.ValueMember = "id";
                comboaddunder.SelectedIndex = -1;
            }
        }

        private void comboaddunder_Click(object sender, EventArgs e)
        {
            this.cntrl.get_procedure_category_value();
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
                DataTable dt =this.cntrl. Get_category_name();   //db.table("select * from tbl_procedure_category where name='" + txt_AddCategory.Text + "'");
                if (dt.Rows.Count <= 0)
                {
                    this.cntrl.save();
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
                    this.cntrl.get_procedureName();
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
                    int i = this.cntrl.save_addprocedure();
                    DataTable dtb = this.cntrl.get_procedureid();
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
                    //checkadditionaltax.Checked = false;
                    chk_igst.Checked = false;
                    chk_gst.Checked = false;
                    //checkvat.Checked = false;
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}