using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class EMR_Settings : Form
    {
        EMR_controller cntrl=new EMR_controller();
        public string id_comp = ""; string id = "";
        string id_diag, id_invest, id_notes;
        public EMR_Settings()
        {
            InitializeComponent();
        }
        public void SetController(EMR_controller controller)
        {
            cntrl = controller;
        }

        private void EMR_settings_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabPage6);
            DataTable dtb = this.cntrl.Fill_grid();
            FillGrid(dtb);
            DataTable dt_obser = this.cntrl.Fill_observationGrid();
            FillObservationGrid(dt_obser);
            DataTable dt_diagnosis = this.cntrl.fill_diagnosisGrid();
            FiiDiagnosisGrid(dt_diagnosis);
            DataTable dt_invest = this.cntrl.Fill_investgation();
            FillInvsetgation(dt_invest);
            DataTable dtb_notes = this.cntrl.Fill_notegrid();
            FillNotes(dtb_notes);
            label3.Hide();
            label6.Hide();
            label9.Hide();
            label11.Hide();
            label14.Hide();
            label17.Hide();
            dataGridView_comp.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_comp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_comp.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_comp.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_comp.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView_observation.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_observation.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_observation.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_observation.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_observation.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView_diag.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_diag.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_diag.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_diag.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_diag.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView_invest.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_invest.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_invest.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_invest.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_invest.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dataGridView_notes.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            dataGridView_notes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView_notes.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
            dataGridView_notes.EnableHeadersVisualStyles = false;
            foreach (DataGridViewColumn cl in dataGridView_notes.Columns)
            {
                cl.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        //complaints
        public void FillGrid(DataTable dt2)
        {
            dataGridView_comp.Rows.Clear();
            if (dt2.Rows.Count > 0)
            {
                int i = 0;
                while (i < dt2.Rows.Count)
                {
                    try
                    {
                        dataGridView_comp.Rows.Add(dt2.Rows[i]["id"].ToString(), dt2.Rows[i]["name"].ToString());
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void button_comp_save_Click(object sender, EventArgs e)
        {
            if (text_complaints.Text != "")
            {
                if (button_comp_save.Text == "Save")
                {

                    DataTable checkdatacc = this.cntrl.Check_complaints(text_complaints.Text);
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("This Complaint " + text_complaints.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        this.cntrl.save_complaints(text_complaints.Text);
                        text_complaints.Clear();
                        DataTable dtb = this.cntrl.Fill_grid();
                        FillGrid(dtb);
                    }
                }
                else
                {
                    this.cntrl.update_complaints(id_comp, text_complaints.Text);
                    text_complaints.Clear();
                    DataTable dtb = this.cntrl.Fill_grid();
                    FillGrid(dtb);
                    button_comp_save.Text = "Save";
                }
            }
            else
            {
                errorProvider1.SetError(text_complaints, "error");
                label6.Show();
            }
        }

        private void dataGridView_comp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int r = e.RowIndex;
                    id_comp = dataGridView_comp.Rows[r].Cells[0].Value.ToString();
                    if (dataGridView_comp.CurrentCell.OwningColumn.Name == "Edit")
                    {
                        text_complaints.Text = dataGridView_comp.CurrentRow.Cells[1].Value.ToString();
                        button_comp_save.Text = "Update";
                    }
                    if (dataGridView_comp.CurrentCell.OwningColumn.Name == "Delete")
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete this ?", "Delete confirmation",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.Delete_complaints(id_comp);
                            this.cntrl.Fill_grid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_comp_refresh_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.Fill_grid();
            FillGrid(dtb);
            text_complaints.Clear();
            text_comp_search.Clear();
            button_comp_save.Text = "Save";
        }

        private void text_comp_search_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView_comp.RowHeadersVisible = false;
            dataGridView_comp.RowCount = 0;
            DataTable dt2 = this.cntrl.Search_complaints(text_comp_search.Text);
            if (dt2.Rows.Count > 0)
            {
                int i = 0;
                while (i < dt2.Rows.Count)
                {
                    try
                    {
                        dataGridView_comp.Rows.Add(dt2.Rows[i]["id"].ToString(), dt2.Rows[i]["name"].ToString());
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        public void FillObservationGrid(DataTable dt2)
        {
            dataGridView_observation.Rows.Clear();
            if (dt2.Rows.Count > 0)
            {
                int i = 0;
                while (i < dt2.Rows.Count)
                {
                    try
                    {
                        dataGridView_observation.Rows.Add(dt2.Rows[i]["id"].ToString(), dt2.Rows[i]["observations"].ToString());
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button_save_observations_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_observation.Text != "")
                {
                    if (button_save_observations.Text == "Save")
                    {
                        DataTable checkdataOB = this.cntrl.Check_observation(text_observation.Text);
                        if (checkdataOB.Rows.Count > 0)
                        {
                            MessageBox.Show("This Record " + text_observation.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            int i = this.cntrl.save_observation(text_observation.Text);
                            if (i > 0)
                            {
                                text_observation.Clear();
                                DataTable dtb = this.cntrl.Fill_observationGrid();
                                FillObservationGrid(dtb);
                            }
                        }
                    }
                    else
                    {
                        int i = this.cntrl.Update_observation(id,text_observation.Text);
                        if (i > 0)
                        {
                            text_observation.Clear();
                            button_save_observations.Text = "Save";
                            DataTable dtb = this.cntrl.Fill_observationGrid();
                            FillObservationGrid(dtb);
                        }
                    }
                }
                else
                {
                    errorProvider1.SetError(text_observation, "error");
                    label3.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_observation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = dataGridView_observation.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView_observation.CurrentCell.OwningColumn.Name == "coledit")
                {
                    try
                    {
                        text_observation.Text = dataGridView_observation.Rows[e.RowIndex].Cells[1].Value.ToString();
                        button_save_observations.Text = "Update";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (dataGridView_observation.CurrentCell.OwningColumn.Name == "coldelete")
                {
                    if (!String.IsNullOrWhiteSpace(id))
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete this ?", "Delete confirmation",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            cntrl.delete_observation(id);
                            DataTable dtb = this.cntrl.Fill_observationGrid();
                            FillObservationGrid(dtb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_observations_refresh_Click(object sender, EventArgs e)
        {
            text_observ_search.Clear();
            text_observation.Clear();
            button_save_observations.Text = "Save";
            DataTable dtb = this.cntrl.Fill_observationGrid();
            FillObservationGrid(dtb);
        }
        private void text_observ_search_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView_comp.RowHeadersVisible = false;
            dataGridView_comp.RowCount = 0;
            DataTable dtb = this.cntrl.SearchObservation(text_observ_search.Text);
            FillObservationGrid(dtb);
        }
        private void button_refresh_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.fill_diagnosisGrid();
            FiiDiagnosisGrid(dtb);
            text_diagnosis_search.Clear();
            text_diagnosis.Clear();
            button_Save.Text = "Save";
        }

        private void dataGridView_diag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_diag = dataGridView_diag.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView_diag.CurrentCell.OwningColumn.Name == "Dia_Edit")
                {
                    try
                    {
                        text_diagnosis.Text = dataGridView_diag.Rows[e.RowIndex].Cells[1].Value.ToString();
                        button_Save.Text = "Update";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (dataGridView_diag.CurrentCell.OwningColumn.Name == "Dia_Delete")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete this ?", "Delete confirmation",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        cntrl.delete(id_diag);
                        DataTable dtb = this.cntrl.fill_diagnosisGrid();
                        FiiDiagnosisGrid(dtb);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void text_diagnosis_search_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView_diag.RowHeadersVisible = false;
            dataGridView_diag.RowCount = 0;
            DataTable dtb = this.cntrl.search_diagnosis(text_diagnosis_search.Text);
            FiiDiagnosisGrid(dtb);
        }

        public void FiiDiagnosisGrid(DataTable dt2)
        {
            dataGridView_diag.Rows.Clear();
            int i = 0;
            while (i < dt2.Rows.Count)
            {
                try
                {
                    dataGridView_diag.Rows.Add(dt2.Rows[i]["id"].ToString(), dt2.Rows[i]["diagnosis"].ToString());
                    i++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button_inves_refresh_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.Fill_investgation();
            FillInvsetgation(dtb);
            text_investigation.Clear();
            text_investigation_search.Clear();
            button_inves_save.Text = "Save";
        }

        private void button_inves_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_investigation.Text == "")
                {
                    errorProvider1.SetError(text_investigation, "error");
                    label11.Show();
                }
                else
                {
                    if (button_inves_save.Text == "Save")
                    {

                        DataTable checkdataINVEST = this.cntrl.check_invest(text_investigation.Text);
                        if (checkdataINVEST.Rows.Count > 0)
                        {
                            MessageBox.Show("This Record " + text_investigation.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            this.cntrl.save_investgation(text_investigation.Text);
                            text_investigation.Clear();
                            DataTable dtb = this.cntrl.Fill_investgation();
                            FillInvsetgation(dtb);
                        }
                    }
                    else
                    {
                        this.cntrl.update_investgation(id_invest, text_investigation.Text);
                        text_investigation.Clear();
                        button_inves_save.Text = "Save";
                        DataTable dtb = this.cntrl.Fill_investgation();
                        FillInvsetgation(dtb);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_invest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_invest = dataGridView_invest.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView_invest.CurrentCell.OwningColumn.Name == "Inv_Edit")
                {
                    text_investigation.Text = dataGridView_invest.Rows[e.RowIndex].Cells[1].Value.ToString();
                    button_inves_save.Text = "Update";
                }
                if (dataGridView_invest.CurrentCell.OwningColumn.Name == "Inv_Delete")
                {
                    if (!String.IsNullOrWhiteSpace(id_invest))
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete this ?", "Delete confirmation",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.No)
                        {
                        }
                        else
                        {
                            this.cntrl.delete_investigation(id_invest);
                            DataTable dtb = this.cntrl.Fill_investgation();
                            FillInvsetgation(dtb);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void text_investigation_search_TextChanged(object sender, EventArgs e)
        {
            dataGridView_invest.RowHeadersVisible = false;
            dataGridView_invest.RowCount = 0;
            DataTable dtb = this.cntrl.search_investgation(text_investigation_search.Text);
            FillInvsetgation(dtb);
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_diagnosis.Text == "")
                {
                    errorProvider1.SetError(text_diagnosis, "error");
                    label9.Show();
                }
                else
                {
                    if (button_Save.Text == "Save")
                    {
                        DataTable checkdataDIAG = this.cntrl.check_diagnosis(text_diagnosis.Text);
                        if (checkdataDIAG.Rows.Count > 0)
                        {
                            MessageBox.Show("This Record " + text_diagnosis.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.cntrl.save_diagnosis(text_diagnosis.Text);
                            text_diagnosis.Clear();
                            DataTable dtb = this.cntrl.fill_diagnosisGrid();
                            FiiDiagnosisGrid(dtb);
                        }
                    }
                    else
                    {
                        this.cntrl.update_diagnosis(id_diag, text_diagnosis.Text);
                        text_diagnosis.Clear();
                        button_Save.Text = "Save";
                        DataTable dtb = this.cntrl.fill_diagnosisGrid();
                        FiiDiagnosisGrid(dtb);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Investigation
        private void button_notes_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (text_notes.Text == "")
                {
                    errorProvider1.SetError(text_notes, "error");
                    label14.Show();
                }
                else
                {
                    if (button_notes_save.Text == "Save")
                    {
                        DataTable checkdataNOTE = this.cntrl.check_notes(text_notes.Text);
                        if (checkdataNOTE.Rows.Count > 0)
                        {
                            MessageBox.Show("This Record " + text_notes.Text + "  already exists", "Duplication encountered ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.cntrl.save_note(text_notes.Text);
                            text_notes.Clear();
                            DataTable dtb = this.cntrl.Fill_notegrid();
                            FillNotes(dtb);
                        }
                    }
                    else
                    {
                        this.cntrl.update_note(id_notes,text_notes.Text);
                        text_notes.Clear();
                        DataTable dtb = this.cntrl.Fill_notegrid();
                        FillNotes(dtb);
                        button_notes_save.Text = "Save";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_notes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_notes = dataGridView_notes.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (dataGridView_notes.CurrentCell.OwningColumn.Name == "No_Edit")
            {
                try
                {
                    text_notes.Text = dataGridView_notes.CurrentRow.Cells[1].Value.ToString();
                    button_notes_save.Text = "Update";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (dataGridView_notes.CurrentCell.OwningColumn.Name == "No_Delete")
            {
                if (!String.IsNullOrWhiteSpace(id_notes))
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete this record?", "Delete confirmation",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.No)
                    {
                    }
                    else
                    {
                        this.cntrl.delete_note(id_notes);
                        DataTable dtb = this.cntrl.Fill_notegrid();
                        FillNotes(dtb);
                    }
                }
            }
        }

        private void button_notes_refresh_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.Fill_notegrid();
            FillNotes(dtb);
            text_notes.Clear();
            text_notes_search.Clear();
            button_notes_save.Text = "Save";
        }

        private void text_notes_search_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView_notes.RowHeadersVisible = false;
            dataGridView_notes.RowCount = 0;
            this.cntrl.search_note(text_notes_search.Text);
        }

        public void FillInvsetgation(DataTable dt2)
        {
            dataGridView_invest.Rows.Clear();
            if (dt2.Rows.Count > 0)
            {
                int i = 0;
                while (i < dt2.Rows.Count)
                {
                    try
                    {
                        dataGridView_invest.Rows.Add(dt2.Rows[i]["id"].ToString(), dt2.Rows[i]["investigation"].ToString());
                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font TabFont;
            Brush BackBrush = new SolidBrush(Color.Transparent);
            Brush ForeBrush = new SolidBrush(Color.DarkSlateGray);
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                TabFont = new Font(e.Font, FontStyle.Italic);
            }
            else
            {
                TabFont = e.Font;
            }
            string TabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);
            sf.Dispose();
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                TabFont.Dispose();
                BackBrush.Dispose();
            }
            else
            {
                BackBrush.Dispose();
                ForeBrush.Dispose();
            }
        }

        public void FillNotes(DataTable dt2)
        {
            dataGridView_notes.Rows.Clear();
            int i = 0;
            while (i < dt2.Rows.Count)
            {
                try
                {
                    dataGridView_notes.Rows.Add(dt2.Rows[i]["id"].ToString(), dt2.Rows[i]["notes"].ToString());
                    i++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
