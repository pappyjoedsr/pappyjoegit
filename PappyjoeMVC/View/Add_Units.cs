using System;
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
    public partial class Add_Units : Form
    {
        Add_Unit_controller cntrl=new Add_Unit_controller();
        public string unitName = "";
        public string unit_id = "";
        public Add_Units()
        {
            InitializeComponent();
        }
        public void SetController(Add_Unit_controller controller)
        {
            cntrl = controller;
        }
        public string Units
        {
            get { return this.txt_Unitname.Text; }
            set { txt_Unitname.Text = value; }
        }
        private void frmAddUnits_Load(object sender, EventArgs e)
        {
            DataTable dtb= this.cntrl.Load_Data();
            LoadData(dtb);
            dgv_Units.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dgv_Units.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_Units.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dgv_Units.EnableHeadersVisualStyles = false;
        }
        public void LoadData(DataTable dtb)
        {
            dgv_Units.Rows.Clear();
            if (dtb.Rows.Count > 0)
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    dgv_Units.Rows.Add(dr["id"].ToString(), dr["name"].ToString(), PappyjoeMVC.Properties.Resources.editicon, PappyjoeMVC.Properties.Resources.deleteicon);
                }
            }
        }
        public int itemcheck(string unit)
        {
            int affected = 0;
            DataTable dtb = this.cntrl.get_units();
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                if (dtb.Rows[i][1].ToString() != "" && unit == dtb.Rows[i][1].ToString())
                {
                    affected = 1;
                }
            }
            return affected;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Unitname.Text != "")
            {
                if (btn_Add.Text == "Add")
                {
                    int i = 0;
                    if (itemcheck(txt_Unitname.Text) == 0)
                    {
                        i = this.cntrl.save(txt_Unitname.Text);
                        if (i == 0)
                        {
                            MessageBox.Show("Inseration Failed !..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            txt_Unitname.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("This Unit already existed!..", "Duplication Encountded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    int j = 0;
                    j = this.cntrl.update(unit_id, txt_Unitname.Text); 
                    if (j == 0)
                    {
                        MessageBox.Show("Updation Failed !..", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        btn_delete.Text ="Close"; 
                        btn_Add.Text = "Add";
                        txt_Unitname.Text = "";
                    }
                }
            }
            this.cntrl.Load_Data();
        }

        private void dgv_Units_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = 0;
                if (dgv_Units.CurrentCell.OwningColumn.Name == "edit")
                {
                    unit_id = dgv_Units.CurrentRow.Cells["id"].Value.ToString();
                    txt_Unitname.Text = dgv_Units.CurrentRow.Cells["units"].Value.ToString();
                    btn_Add.Text = "UPdate";
                    btn_delete.Visible = true;
                }
                if (dgv_Units.CurrentCell.OwningColumn.Name == "del")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        unit_id = dgv_Units.CurrentRow.Cells["id"].Value.ToString();
                        i = this.cntrl.delete(unit_id);
                        if (i > 0)
                        {
                            this.cntrl.Load_Data();
                        }
                    }
                    else
                    {

                    }
                       
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
