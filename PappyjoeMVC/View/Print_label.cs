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
namespace PappyjoeMVC.View
{
    public partial class Print_Label : Form
    {
        Patients_model _model = new Patients_model();
        public Print_Label()
        {
            InitializeComponent();
        }
        private void Print_label_Load(object sender, EventArgs e)
        {
            string sqlstr = "";
            Gridpatient.RowCount = 0;
            DataTable dt_pt = this._model.Get_all_Patients();
            Gridpatient.RowTemplate.Height = 25;
            if (dt_pt.Rows.Count > 0)
            {
                int row = 0;
                foreach (DataRow dr in dt_pt.Rows)
                {
                    Gridpatient.Rows.Add();
                    Gridpatient.Rows[row].Cells["colid"].Value = dr["Pid"].ToString();
                    Gridpatient.Rows[row].Cells["collId"].Value = dr["Id"].ToString();
                    Gridpatient.Rows[row].Cells["colName"].Value = dr["Patient Name"].ToString();
                    Gridpatient.Rows[row].Cells["colgender"].Value = dr["Gender"].ToString();
                    Gridpatient.Rows[row].Cells["colAge"].Value = dr["Age"].ToString();
                    Gridpatient.Rows[row].Cells["colMob"].Value = dr["Mobile"].ToString();
                    Gridpatient.Rows[row].Cells["colstreet"].Value = dr["Street Address"].ToString();
                    Gridpatient.Rows[row].Cells["colVisited"].Value = Convert.ToDateTime(dr["Visited"].ToString()).ToString("MM/dd/yyyy");
                    Gridpatient.Rows[row].Cells["colOP"].Value = dr["File NO"].ToString();
                    row++;
                }
            }
            Design_Datagrid();
            Gridpatient.Columns[0].Visible = false;
        }
        public void Design_Datagrid()
        {
            Gridpatient.Columns[0].Width = 0;
            Gridpatient.Columns[1].Width = 100;
            Gridpatient.Columns[2].Width = 200;
            Gridpatient.Columns[3].Width = 85;
            Gridpatient.Columns[4].Width = 55;
            Gridpatient.Columns[5].Width = 100;
            Gridpatient.Columns[6].Width = 160;
            Gridpatient.Columns[7].Width = 160;
            Gridpatient.Columns[8].Width = 100;
            Gridpatient.Columns[9].Width = 80;
            Gridpatient.EnableHeadersVisualStyles = false;
            Gridpatient.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            Gridpatient.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Gridpatient.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            Gridpatient.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            Gridpatient.ColumnHeadersVisible = true;
            Gridpatient.ScrollBars = ScrollBars.Vertical;
            foreach (DataGridViewColumn column in Gridpatient.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void Gridpatient_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Error happened " + e.Context.ToString());

            if (e.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (e.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (e.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("parsing error");
            }
            if (e.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("leave control error");
            }
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "an error";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "an error";
                e.ThrowException = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt_Return = new DataTable();
            dt_Return.Clear();
            foreach (DataGridViewColumn col in Gridpatient.Columns)
            {
                dt_Return.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in Gridpatient.Rows)
            {
                if (Convert.ToBoolean(row.Cells["colselected"].EditedFormattedValue) == true)
                {
                    DataRow dRow = dt_Return.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dRow[cell.ColumnIndex] = cell.Value;
                    }
                    dt_Return.Rows.Add(dRow);
                }
            }

            if (dt_Return.Rows.Count > 0)
            {
                Print_Label_Print objfrmPrint = new Print_Label_Print();
                objfrmPrint.dt_Load = dt_Return;
                objfrmPrint.ShowDialog();
                objfrmPrint.Dispose();
            }
            else
            {
                MessageBox.Show("Please Select Any Patient", "Patient Not Fund", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            Gridpatient.RowCount = 0;
            Gridpatient.RowTemplate.Height = 25;
            DataTable dt_pt = new DataTable();
            if (String.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                dt_pt = this._model.Get_all_Patients();
            }
            else
            {
                dt_pt = this._model.allpatient_search(TxtSearch.Text);
            }
            if (dt_pt.Rows.Count > 0)
            {
                int row = 0;
                foreach (DataRow dr in dt_pt.Rows)
                {
                    Gridpatient.Rows.Add();
                    Gridpatient.Rows[row].Cells["colid"].Value = dr["Pid"].ToString();
                    Gridpatient.Rows[row].Cells["collId"].Value = dr["Id"].ToString();
                    Gridpatient.Rows[row].Cells["colName"].Value = dr["Patient Name"].ToString();
                    Gridpatient.Rows[row].Cells["colgender"].Value = dr["Gender"].ToString();
                    Gridpatient.Rows[row].Cells["colAge"].Value = dr["Age"].ToString();
                    Gridpatient.Rows[row].Cells["colMob"].Value = dr["Mobile"].ToString();
                    Gridpatient.Rows[row].Cells["colstreet"].Value = dr["Street Address"].ToString();
                    Gridpatient.Rows[row].Cells["colVisited"].Value = Convert.ToDateTime(dr["Visited"].ToString()).ToString("MM/dd/yyyy");
                    Gridpatient.Rows[row].Cells["colOP"].Value = dr["File NO"].ToString();
                    row++;
                }
            }
            Design_Datagrid();
            Gridpatient.Columns[0].Visible = false;
        }

        private void TxtSearch_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = "";
        }
    }
}
