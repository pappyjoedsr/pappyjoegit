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
    public partial class Trackingnullstatus : Form,Trackingnullstatus_interface
    {
        public Trackingnullstatus()
        {
            InitializeComponent();
        }
        Trackingnullstatus_controller ctrlr;
        public string patient_id = "", doctor_id = "";
        private void Trackingnullstatus_Load(object sender, EventArgs e)
        {
            this.ctrlr.trackngnullstatus();
        }
        public void setController(Trackingnullstatus_controller controller)
        {
            ctrlr = controller;
        }
        private void dataGridView1_treatment_paln_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == 0)
                    {
                        int k = e.RowIndex;
                        patient_id = dataGridView1_treatment_paln.Rows[k].Cells[5].Value.ToString();
                        string workid = dataGridView1_treatment_paln.Rows[k].Cells[1].Value.ToString();
                        var form = new PappyjoeMVC.View.dentalwork();
                        form.patient_id = patient_id;
                        form.doctor_id = doctor_id;
                        form.workid = workid;
                        dentalwork_controller controller = new dentalwork_controller(form);
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void trackngnullstatus(DataTable tbShade)
        {
            try
            {
                dataGridView1_treatment_paln.DataSource = tbShade;
                dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1_treatment_paln.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView1_treatment_paln.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
