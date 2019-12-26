using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Trackingnullstatus : Form
    {
        public Trackingnullstatus()
        {
            InitializeComponent();
        }
        public string patient_id = "", doctor_id = "";
        Trackingnullstatus_controller ctrlr = new Trackingnullstatus_controller();
        private void Trackingnullstatus_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable nullst = this.ctrlr.trackngnullstatus();
                dataGridView1_treatment_paln.DataSource = nullst;
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
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        var form = new Dentalwork();
                        form.patient_id = patient_id;
                        form.doctor_id = doctor_id;
                        form.workid = workid;
                        form.ShowDialog();
                        form.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
