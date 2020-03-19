using PappyjoeMVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class LabResultEntry : Form
    {
        public LabResultEntry()
        {
            InitializeComponent();
        }
        int j;
        LabResultEntry_controller ctrlr=new LabResultEntry_controller();
        public string patient_id = "", doctor_id = "", workid = "",flag="",flagup="";

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[8].Value="";
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    j = this.ctrlr.rsltupdate(dataGridView1.Rows[i].Cells[8].Value.ToString(), dataGridView1.Rows[i].Cells[11].Value.ToString(), dataGridView1.Rows[i].Cells[12].Value.ToString(), dataGridView1.Rows[i].Cells[13].Value.ToString());
                }
                if (j > 0)
                {
                    MessageBox.Show("Updated Sucessfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void LabResultEntry_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (flagup == "1")
                {
                    DataTable dt = this.ctrlr.LoadResult(patient_id, workid);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Enabled = false;
                    btnsave.Visible = false;
                }
                if (flag == "1")
                {
                    DataTable dt = this.ctrlr.LoadResult(patient_id, workid);
                    dataGridView1.DataSource = dt;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                           
                            this.dataGridView1.Columns[11].Visible = false;
                            this.dataGridView1.Columns[12].Visible = false;
                            this.dataGridView1.Columns[13].Visible = false;
                            dataGridView1.Rows[i].Cells[8].Value = "Enter Result";
                        }
                    }
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular);
                dataGridView1.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView1.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
