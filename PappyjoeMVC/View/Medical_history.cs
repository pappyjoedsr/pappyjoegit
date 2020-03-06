using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Model;
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.View
{
    public partial class Medical_History : Form
    {
        public Medical_History()
        {
            InitializeComponent();
        }
        Medical_History_controller cntrl=new Medical_History_controller();
        public string id = "";
        string groupid = "0";
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void text_medhist_TextChanged(object sender, EventArgs e)
        {
            label3.Hide();
            errorProvider1.Dispose();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_medhist.Text == "")
                {
                    errorProvider1.SetError(text_medhist, "error");
                    label3.Show();
                }
                else
                {
                    if (button_add.Text != "Add")
                    {
                        this.cntrl.update_medical(id, text_medhist.Text);
                        button_add.Text = "Add";
                        MessageBox.Show("Saved Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DataTable dtb = this.cntrl.Check_medical(text_medhist.Text);
                        if (dtb.Rows.Count > 0)
                        {
                            MessageBox.Show("Medical History " + text_medhist.Text + " already existed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            int i = this.cntrl.save_medical(text_medhist.Text);
                            if (i > 0)
                            {
                                MessageBox.Show("Saved Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    text_medhist.Clear();
                    DataTable dt= this.cntrl.load_medical();
                    LoadMedical(dt);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadMedical(DataTable dtb)
        {
            Dgv_medhist.Rows.Clear();
            if (dtb.Rows.Count>0)
            {
                for(int i=0;i<dtb.Rows.Count;i++)
                {
                    Dgv_medhist.Rows.Add();
                    Dgv_medhist.Rows[i].Cells["mid"].Value = dtb.Rows[i][0].ToString();
                    Dgv_medhist.Rows[i].Cells["medicl"].Value = dtb.Rows[i][1].ToString();
                }
            }
        }

        private void Medical_history_Load(object sender, EventArgs e)
        {
            DataTable dtv = this.cntrl.load_medical();
            LoadMedical(dtv);
            Dgv_medhist.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            Dgv_medhist.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Dgv_medhist.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            Dgv_medhist.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in Dgv_medhist.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
           DataTable td_grp= this.cntrl.Load_Group();
            LoadGroup(td_grp );
            dataGridView_group.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_group.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_group.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_group.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_group.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Dgv_medhist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex>=0)
                {
                    int r = e.RowIndex;
                    id = Dgv_medhist.Rows[r].Cells["mid"].Value.ToString();
                    if (Dgv_medhist.CurrentCell.OwningColumn.Name=="edit")
                    {
                        text_medhist.Text = Dgv_medhist.CurrentRow.Cells["medicl"].Value.ToString();
                        button_add.Text = "Save";
                        btn_Cancel.Visible = true;
                    }
                    else if (Dgv_medhist.CurrentCell.OwningColumn.Name == "delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete this row?", "Delete confirmation",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_medical(id);
                           DataTable dtb= this.cntrl.load_medical();
                            LoadMedical(dtb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            button_add.Text = "Add";
            btn_Cancel.Visible = false;
            text_medhist.Text = "";
        }

        private void text_search_KeyUp(object sender, KeyEventArgs e)
        {
           DataTable dtb= this.cntrl.seaerh_medical(text_search.Text);
            LoadMedical(dtb);
        }
        public void LoadGroup(DataTable dt_maintest)
        {
            dataGridView_group.Rows.Clear();
            if (dt_maintest.Rows.Count>0)
            {
                int i = 0;
                while (i < dt_maintest.Rows.Count)
                {
                    try
                    {
                        dataGridView_group.Rows.Add(dt_maintest.Rows[i]["id"].ToString(), i, dt_maintest.Rows[i]["name"].ToString());
                        i++;
                        dataGridView_group.Rows[dataGridView_group.Rows.Count - 1].Cells[1].Value = i;
                        dataGridView_group.Rows[i - 1].Height = 25;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_group_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox_group.Text))
            {
                if (button_group.Text == "Save")
                {
                    DataTable dtb = this.cntrl.check_groupname(textBox_group.Text);
                    if(dtb.Rows.Count>0)
                    {
                        MessageBox.Show("Group  " + textBox_group.Text + " already existed", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        int i = this.cntrl.save_group(textBox_group.Text);
                        if(i>0)
                        {
                            MessageBox.Show("Saved Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    int i = this.cntrl.update_group(groupid, textBox_group.Text);
                    if (i > 0)
                    {
                        MessageBox.Show("Updated Successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                textBox_group.Text = "";
              DataTable dt=this.cntrl.Load_Group();
                LoadGroup(dt);
                button_group.Text = "Save";
                groupid = "0";
            }
            else
            {
                MessageBox.Show("Please enter Group Name..!", "Data not found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_group_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                groupid = dataGridView_group.CurrentRow.Cells["gid"].Value.ToString();
                if (dataGridView_group.CurrentCell.OwningColumn.Name=="gedit")
                {
                    DataTable dtb = this.cntrl.exsists_ptgroup(dataGridView_group.CurrentRow.Cells["Medgroup"].Value.ToString());
                    if(dtb.Rows.Count>0)
                    {
                        MessageBox.Show("Can't Edit group Name ..!,This Group is Already used by patient details.!! ", "Can't Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        textBox_group.Text = dataGridView_group.CurrentRow.Cells["Medgroup"].Value.ToString();
                        btn_Cancelgroup.Visible = true;
                        button_group.Text = "Update";
                    }
                }
                else if (dataGridView_group.CurrentCell.OwningColumn.Name == "gdelete")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        DataTable dtb = this.cntrl.exsists_ptgroup(dataGridView_group.CurrentRow.Cells["Medgroup"].Value.ToString());
                        if (dtb.Rows.Count > 0)
                        {
                            MessageBox.Show("You have already patients in this Group.. Can't delete... ", "Can't delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            this.cntrl.delete_group(groupid);
                           DataTable dt= this.cntrl.Load_Group();
                            LoadGroup(dt);
                        }
                    }
                }
            }
        }

        private void btn_Cancelgroup_Click(object sender, EventArgs e)
        {
            button_group.Text = "Save";
            btn_Cancelgroup.Visible = false;
            textBox_group.Text = "";
        }
    }
}
