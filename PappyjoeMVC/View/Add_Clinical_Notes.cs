using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Add_Clinical_Notes : Form
    {
        Clinical_Notes_Add_controller cntrl = new Clinical_Notes_Add_controller();
        public string doctor_id = "";
        public string staff_id = "";
        public string clinic_id = "";
        string idcomp, iddiag, idobs, idinv, idnote = "";
        public string patient_id = "";
        static int rowvalue;
        public bool caledr_edit_flag = false;
        public Add_Clinical_Notes()
        {
            InitializeComponent();
        }

        private void investigationgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                idinv = investigationgrid.Rows[r].Cells[0].Value.ToString();
                DataTable dt2 = this.cntrl.investigation_cell(idinv);
                bool entryFound = false;
                if (dt2.Rows.Count > 0)
                {
                    var value = dt2.Rows[0][1].ToString().Trim();
                    foreach (DataGridViewRow row in investigationgrid1.Rows)
                    {
                        object val1 = row.Cells[0].Value;
                        object val2 = row.Cells[1].Value;
                        if (val2 != null && val2.ToString() == value)
                        {
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        investigationgrid1.Rows.Add(dt2.Rows[0][0].ToString(), dt2.Rows[0][1].ToString());
                        investigationgrid1.Rows[investigationgrid1.Rows.Count - 1].Height = 30;
                        investigationgrid1.Rows[investigationgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        del2.ImageLayout = DataGridViewImageCellLayout.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void diagnosisgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                iddiag = diagnosisgrid.Rows[r].Cells[0].Value.ToString();
                DataTable dt3 = this.cntrl.diagnose_cell(iddiag);
                bool entryFound = false;
                if (dt3.Rows.Count > 0)
                {
                    var value = dt3.Rows[0][1].ToString().Trim();
                    foreach (DataGridViewRow row in diagnosisgrid1.Rows)
                    {
                        object val1 = row.Cells[0].Value;
                        object val2 = row.Cells[1].Value;
                        if (val2 != null && val2.ToString() == value)
                        {
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        diagnosisgrid1.Rows.Add(dt3.Rows[0][0].ToString(), dt3.Rows[0][1].ToString());
                        diagnosisgrid1.Rows[diagnosisgrid1.Rows.Count - 1].Height = 30;
                        diagnosisgrid1.Rows[diagnosisgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        del3.ImageLayout = DataGridViewImageCellLayout.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void complaintgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                idcomp = complaintgrid.Rows[r].Cells[0].Value.ToString();
                DataTable dt = this.cntrl.complaint_cell(idcomp);
                bool entryFound = false;
                if (dt.Rows.Count > 0)
                {
                    var value = dt.Rows[0][1].ToString().Trim();
                    foreach (DataGridViewRow row in complaintgrid1.Rows)
                    {
                        object val1 = row.Cells[0].Value;
                        object val2 = row.Cells[1].Value;
                        if (val2 != null && val2.ToString() == value)
                        {
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        complaintgrid1.Rows.Add(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
                        complaintgrid1.Rows[complaintgrid1.Rows.Count - 1].Height = 30;
                        complaintgrid1.Rows[complaintgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        del.ImageLayout = DataGridViewImageCellLayout.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void notegrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                idnote = notegrid.Rows[r].Cells[0].Value.ToString();
                DataTable dt4 = this.cntrl.notes_cell(idnote);
                bool entryFound = false;
                if (dt4.Rows.Count > 0)
                {
                    var value = dt4.Rows[0][1].ToString().Trim();
                    foreach (DataGridViewRow row in notesgrid1.Rows)
                    {
                        object val1 = row.Cells[0].Value;
                        object val2 = row.Cells[1].Value;
                        if (val2 != null && val2.ToString() == value)
                        {
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        notesgrid1.Rows.Add(dt4.Rows[0][0].ToString(), dt4.Rows[0][1].ToString());
                        notesgrid1.Rows[notesgrid1.Rows.Count - 1].Height = 30;
                        notesgrid1.Rows[notesgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        del4.ImageLayout = DataGridViewImageCellLayout.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void observationgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = e.RowIndex;
                idobs = observationgrid.Rows[r].Cells[0].Value.ToString();
                DataTable dt1 = this.cntrl.observation_cell(idobs);
                bool entryFound = false;
                if (dt1.Rows.Count > 0)
                {
                    var value = dt1.Rows[0][1].ToString().Trim();
                    foreach (DataGridViewRow row in observationgrid1.Rows)
                    {
                        object val1 = row.Cells[0].Value;
                        object val2 = row.Cells[1].Value;
                        if (val2 != null && val2.ToString() == value)
                        {
                            this.observationgrid1.Rows[e.RowIndex].Selected = true;
                            entryFound = true;
                            break;
                        }
                    }
                    if (!entryFound)
                    {
                        observationgrid1.Rows.Add(dt1.Rows[0][0].ToString(), dt1.Rows[0][1].ToString());
                        observationgrid1.Rows[observationgrid1.Rows.Count - 1].Height = 30;
                        observationgrid1.Rows[observationgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                        del1.ImageLayout = DataGridViewImageCellLayout.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void compsearchtext_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt = this.cntrl.compsearch(compsearchtext.Text);
                complaintgrid.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void compsearchtext_MouseClick(object sender, MouseEventArgs e)
        {
            compsearchtext.Text = null;
        }

        private void notesearchtext_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt4 = this.cntrl.notesearch(notesearchtext.Text);
                notegrid.DataSource = dt4;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obsersearchtext_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt1 = this.cntrl.observsearch(obsersearchtext.Text);
                observationgrid.DataSource = dt1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notesearchtext_MouseClick(object sender, MouseEventArgs e)
        {
            notesearchtext.Text = null;
        }

        private void obsersearchtext_MouseClick(object sender, MouseEventArgs e)
        {
            obsersearchtext.Text = null;
        }
        private void diagsearchtext_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt3 = this.cntrl.diagnosetxtsearch(diagsearchtext.Text);
                diagnosisgrid.DataSource = dt3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void investsearchtext_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DataTable dt2 = this.cntrl.investsearchtxt(investsearchtext.Text);
                investigationgrid.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void investsearchtext_MouseClick(object sender, MouseEventArgs e)
        {
            investsearchtext.Text = null;
        }

        private void investsavebut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable checkdataINVEST = this.cntrl.CheckInvest(investtextbox.Text.Replace("'", ""));
                if (checkdataINVEST.Rows.Count > 0)
                {
                    MessageBox.Show("Record " + investtextbox.Text + " already exist", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (investtextbox.Text != "")
                    {
                        this.cntrl.investigation_insert(investtextbox.Text);
                        DataTable dt2 = this.cntrl.Show_investigation();
                        investigationgrid.DataSource = dt2;
                        label17.Hide();
                        investtextbox.Hide();
                        investsavebut.Hide();
                        investcancel.Hide();
                        investtextbox.Text = "";
                        lab_investSearch.Show();
                        investsearchtext.Show();
                        investadd.Show();
                        btn_imprt_investgtn.Show();
                        lab_investSearch.Location = new Point(6, 13);
                        investsearchtext.Location = new Point(62, 8);
                        investigationgrid.Location = new Point(3, 37);
                    }
                    else
                    {
                        MessageBox.Show("Enter the data..!!", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        investtextbox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void diagsavebut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable checkdataDIAG = this.cntrl.CheckdataDiag(diagtext.Text.Replace("'", ""));
                if (checkdataDIAG.Rows.Count > 0)
                {
                    MessageBox.Show("Record " + diagtext.Text + " already exist", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (diagtext.Text != "")
                    {
                        this.cntrl.Insert_diagno(diagtext.Text);
                        DataTable dt3 = this.cntrl.show_diagno();
                        diagnosisgrid.DataSource = dt3;
                        label11.Hide();
                        diagtext.Hide();
                        diagsavebut.Hide();
                        diagcancel.Hide();
                        diagtext.Text = "";
                        Lab_Diag_Search.Show();
                        diagsearchtext.Show();
                        diagadd.Show();
                        btn_imprt_diagno.Show();
                        Lab_Diag_Search.Location = new Point(6, 13);
                        diagsearchtext.Location = new Point(62, 8);
                        diagnosisgrid.Location = new Point(3, 37);
                    }
                    else
                    {
                        MessageBox.Show("Enter the data..!!", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        diagtext.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void compsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (compsave.Text == "Save")
                {
                    DataTable checkdatacc = this.cntrl.checkdataAcc(comptextbox.Text.Replace("'", ""));
                    if (checkdatacc.Rows.Count > 0)
                    {
                        MessageBox.Show("Record " + comptextbox.Text + " already exist", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (comptextbox.Text != "")
                        {
                            this.cntrl.insert_compl(comptextbox.Text);
                            DataTable dt = this.cntrl.show_compl();
                            complaintgrid.DataSource = dt;
                            lad_compAddNew.Hide();
                            comptextbox.Hide();
                            compsave.Hide();
                            compcancel.Hide();
                            lab_compSearch.Show();
                            compsearchtext.Show();
                            compadd.Show();
                            btn_imprt_complnt.Show();
                            lab_compSearch.Location = new Point(6, 13);
                            compsearchtext.Location = new Point(62, 8);
                            complaintgrid.Location = new Point(3, 37);
                        }
                        else
                        {
                            MessageBox.Show("Enter the data..!!", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            comptextbox.Focus();
                        }
                    }
                }
                else if (compsave.Text == "Update")
                {
                    if (comptextbox.Text != "")
                    {
                        int i = 0;
                        this.cntrl.Update_compl(comptextbox.Text, rowvalue);
                        if (i > 0)
                        {
                            DataTable dt = this.cntrl.show_compl();
                            complaintgrid.DataSource = dt;
                            compsave.Text = "Save";
                            compadd.Visible = true;
                            btn_imprt_complnt.Visible = true;
                            compsearchtext.Visible = true;
                            compcancel.Visible = false;
                            compsave.Visible = false;
                            comptextbox.Visible = false;
                            lab_compSearch.Location = new Point(6, 13);
                            compsearchtext.Location = new Point(62, 8);
                            complaintgrid.Location = new Point(3, 37);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notesavebut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable checkdataNOTE = this.cntrl.checkdataNote(notetextbox.Text.Replace("'", ""));
                if (checkdataNOTE.Rows.Count > 0)
                {
                    MessageBox.Show("Record " + notetextbox.Text + " already exist", "Duplication Encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (notetextbox.Text != "")
                    {
                        this.cntrl.insert_note(notetextbox.Text);
                        DataTable dt4 = this.cntrl.show_note();
                        notegrid.DataSource = dt4;
                        label14.Hide();
                        notetextbox.Hide();
                        notesavebut.Hide();
                        notecancel.Hide();
                        notetextbox.Text = "";
                        lab_NotesSearch.Show();
                        notesearchtext.Show();
                        noteadd.Show();
                        btn_imprt_notes.Show();
                        lab_NotesSearch.Location = new Point(6, 13);
                        notesearchtext.Location = new Point(62, 8);
                        notegrid.Location = new Point(3, 37);
                    }
                    else
                    {
                        MessageBox.Show("Enter the data..!!", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        notetextbox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obsersavbut_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable checkdataOB = this.cntrl.checkdataOB(obsertextbox.Text.Replace("'", ""));
                if (checkdataOB.Rows.Count > 0)
                {
                    MessageBox.Show("Record " + obsertextbox.Text + "  already exists..", "Duplication encountered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (obsertextbox.Text != "")
                    {
                        this.cntrl.insert_Observ(obsertextbox.Text);
                        DataTable dt1 = this.cntrl.show_observation();
                        observationgrid.DataSource = dt1;
                        label12.Hide();
                        obsertextbox.Hide();
                        obsersavbut.Hide();
                        obsercancel.Hide();
                        obsertextbox.Text = "";
                        lab_observeSearch.Show();
                        obsersearchtext.Show();
                        obseradd.Show();
                        btn_imprt_obsrvtn.Show();
                        lab_observeSearch.Location = new Point(6, 13);
                        obsersearchtext.Location = new Point(62, 8);
                        observationgrid.Location = new Point(3, 37);
                    }
                    else
                    {
                        MessageBox.Show("Enter the data..!!", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        obsertextbox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void complaintgrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (complaintgrid1.Rows.Count > 1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        complaintgrid1.Rows.RemoveAt(this.complaintgrid1.SelectedRows[0].Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void observationgrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (observationgrid1.Rows.Count > 1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        observationgrid1.Rows.RemoveAt(this.observationgrid1.SelectedRows[0].Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void diagnosisgrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (diagnosisgrid1.Rows.Count > 1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        diagnosisgrid1.Rows.RemoveAt(this.diagnosisgrid1.SelectedRows[0].Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void investigationgrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (investigationgrid1.Rows.Count > 1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        investigationgrid1.Rows.RemoveAt(this.investigationgrid1.SelectedRows[0].Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void notesgrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (notesgrid1.Rows.Count > 1)
                {
                    if (e.ColumnIndex == 2)
                    {
                        notesgrid1.Rows.RemoveAt(this.notesgrid1.SelectedRows[0].Index);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolStripTextBox1.Text != "")
                {
                    System.Data.DataTable dtdr = this.cntrl.patient_search(toolStripTextBox1.Text);
                    listpatientsearch.DisplayMember = "patient";
                    listpatientsearch.ValueMember = "id";
                    listpatientsearch.DataSource = dtdr;
                    if (listpatientsearch.Items.Count == 0)
                    {
                        listpatientsearch.Visible = false;
                    }
                    else
                    {
                        listpatientsearch.Visible = true;
                    }
                    listpatientsearch.Location = new Point(toolStrip1.Width - 365, 32);
                }
                else
                {
                    listpatientsearch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void compsearchtext_Click(object sender, EventArgs e)
        {
            compsearchtext.Clear();
        }

        private void obsersearchtext_Click(object sender, EventArgs e)
        {
            obsersearchtext.Clear();
        }

        private void investsearchtext_Click(object sender, EventArgs e)
        {
            investsearchtext.Clear();
        }

        private void diagsearchtext_Click(object sender, EventArgs e)
        {
            diagsearchtext.Clear();
        }

        private void notesearchtext_Click(object sender, EventArgs e)
        {
            notesearchtext.Clear();
        }

        private void notesgrid1_Click(object sender, EventArgs e)
        {
            cmb_clinicalfinding.SelectedIndex = 4;
        }

        private void diagnosisgrid1_Click(object sender, EventArgs e)
        {
            cmb_clinicalfinding.SelectedIndex = 3;
        }

        private void investigationgrid1_Click(object sender, EventArgs e)
        {
            cmb_clinicalfinding.SelectedIndex = 2;
        }

        private void observationgrid1_Click(object sender, EventArgs e)
        {
            cmb_clinicalfinding.SelectedIndex = 1;
        }

        private void complaintgrid1_Click(object sender, EventArgs e)
        {
            cmb_clinicalfinding.SelectedIndex = 0;
        }

        private void compadd_Click(object sender, EventArgs e)
        {
            lad_compAddNew.Show();
            comptextbox.Show();
            compsave.Show();
            compcancel.Show();
            comptextbox.Text = "";
            lab_compSearch.Hide();
            compsearchtext.Hide();
            compadd.Hide();
            btn_imprt_complnt.Hide();
            complaintgrid.Location = new Point(3, 65);
        }

        private void compcancel_Click(object sender, EventArgs e)
        {
            lad_compAddNew.Hide();
            comptextbox.Hide();
            compsave.Hide();
            compcancel.Hide();
            lab_compSearch.Show();
            compsearchtext.Show();
            compadd.Show();
            btn_imprt_complnt.Show();
            lab_compSearch.Location = new Point(6, 13);
            compsearchtext.Location = new Point(62, 8);
            complaintgrid.Location = new Point(3, 37);
        }

        private void obseradd_Click(object sender, EventArgs e)
        {
            label12.Show();
            obsertextbox.Show();
            obsersavbut.Show();
            obsercancel.Show();
            obsertextbox.Text = "";
            lab_observeSearch.Hide();
            obsersearchtext.Hide();
            obseradd.Hide();
            btn_imprt_obsrvtn.Hide();
            observationgrid.Location = new Point(3, 65);
        }

        private void diagadd_Click(object sender, EventArgs e)
        {
            label11.Show();
            diagtext.Show();
            diagsavebut.Show();
            diagcancel.Show();
            diagtext.Text = "";
            Lab_Diag_Search.Hide();
            diagsearchtext.Hide();
            diagadd.Hide();
            btn_imprt_diagno.Hide();
            diagnosisgrid.Location = new Point(3, 65);
        }

        private void noteadd_Click(object sender, EventArgs e)
        {
            label14.Show();
            notetextbox.Show();
            notesavebut.Show();
            notecancel.Show();
            notetextbox.Text = "";
            lab_NotesSearch.Hide();
            notesearchtext.Hide();
            noteadd.Hide();
            btn_imprt_notes.Hide();
            notegrid.Location = new Point(3, 65);
        }

        private void investadd_Click(object sender, EventArgs e)
        {
            label17.Show();
            investtextbox.Show();
            investsavebut.Show();
            investcancel.Show();
            investtextbox.Text = "";
            lab_investSearch.Hide();
            investsearchtext.Hide();
            investadd.Hide();
            btn_imprt_investgtn.Hide();
            investigationgrid.Location = new Point(3, 65);
        }

        private void obsercancel_Click(object sender, EventArgs e)
        {
            label12.Hide();
            obsertextbox.Hide();
            obsersavbut.Hide();
            obsercancel.Hide();
            obsertextbox.Text = "";
            lab_observeSearch.Show();
            obsersearchtext.Show();
            obseradd.Show();
            btn_imprt_obsrvtn.Show();
            lab_observeSearch.Location = new Point(6, 13);
            obsersearchtext.Location = new Point(62, 8);
            observationgrid.Location = new Point(3, 37);
        }

        private void investcancel_Click(object sender, EventArgs e)
        {
            label17.Hide();
            investtextbox.Hide();
            investsavebut.Hide();
            investcancel.Hide();
            investtextbox.Text = "";
            lab_investSearch.Show();
            investsearchtext.Show();
            investadd.Show();
            btn_imprt_investgtn.Show();
            lab_investSearch.Location = new Point(6, 13);
            investsearchtext.Location = new Point(62, 8);
            investigationgrid.Location = new Point(3, 37);
        }

        private void diagcancel_Click(object sender, EventArgs e)
        {
            label11.Hide();
            diagtext.Hide();
            diagsavebut.Hide();
            diagcancel.Hide();
            diagtext.Text = "";
            Lab_Diag_Search.Show();
            diagsearchtext.Show();
            diagadd.Show();
            btn_imprt_diagno.Show();
            Lab_Diag_Search.Location = new Point(6, 13);
            diagsearchtext.Location = new Point(62, 8);
            diagnosisgrid.Location = new Point(3, 37);
        }

        private void notecancel_Click(object sender, EventArgs e)
        {
            label14.Hide();
            notetextbox.Hide();
            notesavebut.Hide();
            notecancel.Hide();
            notetextbox.Text = "";
            lab_NotesSearch.Show();
            notesearchtext.Show();
            noteadd.Show();
            btn_imprt_notes.Show();
            lab_NotesSearch.Location = new Point(6, 13);
            notesearchtext.Location = new Point(62, 8);
            notegrid.Location = new Point(3, 37);
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var form2 = new Add_New_Patients();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else
                {
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id = this.cntrl.permission_for_settings(doctor_id);
                    if (int.Parse(id) > 0)
                    {
                        MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var form2 = new PappyjoeMVC.View.Practice_Details();
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new PappyjoeMVC.View.Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var dlg = new PappyjoeMVC.View.Expense();
            dlg.doctor_id = doctor_id;
            dlg.ShowDialog();
            dlg.Dispose();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.privilge_for_inventory(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void ClinicalNotesAdd_Load(object sender, EventArgs e)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string privid = this.cntrl.userPrivilege_for_ClinicalNotes_Add(doctor_id);
                    if (int.Parse(privid) > 0)
                    {
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        btnSave.Enabled = true;
                    }
                }
                toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                DataTable clinicname = this.cntrl.Get_CompanyNAme();
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    toolStripButton1.Text = clinicn.Replace("¤", "'");
                }
                string docnam = this.cntrl.Get_DoctorName(doctor_id);
                if (docnam != "")
                {
                    toolStripTextDoctor.Text = "Logged In As : " + docnam;
                }
                listpatientsearch.Hide();
                System.Data.DataTable pay = this.cntrl.get_total_payment(patient_id);
                if (pay.Rows.Count > 0)
                {
                    Lab_Nodue.Text = pay.Rows[0]["total_payment"].ToString() + " due";
                }
                DataTable dt_dr = this.cntrl.get_all_doctorname();
                Cmb_doctor.DisplayMember = "doctor_name";
                Cmb_doctor.ValueMember = "id";
                Cmb_doctor.DataSource = dt_dr;
                Cmb_doctor.SelectedIndex = 0;
                cmb_clinicalfinding.SelectedIndex = 0;
                DataTable dt = this.cntrl.Get_patient_id_name_gender(patient_id);
                if (dt.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel_Name.Text = dt.Rows[0]["pt_name"].ToString();
                }
                if (dt.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel_id.Text = dt.Rows[0]["pt_id"].ToString();
                }
                if (caledr_edit_flag == true)
                {
                    string clin_id = this.cntrl.get_clinicId(patient_id);
                    if (clin_id != "")
                    {
                        clinic_id = clin_id;
                    }
                }

                if (clinic_id != "")
                {
                    btnSave.Text = "Update";
                    DataTable dt_cf = this.cntrl.getdatafrom_clinicalFindings(clinic_id, patient_id);
                    if (dt_cf.Rows.Count > 0)
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(dt_cf.Rows[0][1].ToString());
                        int index = Cmb_doctor.FindString(Convert.ToString(dt_cf.Rows[0][2].ToString()));
                        if (index >= 0)
                        {
                            Cmb_doctor.SelectedIndex = index;
                        }
                        else
                        {
                            Cmb_doctor.SelectedIndex = 0;
                        }
                        System.Data.DataTable dt_cf_Complaints = this.cntrl.getComplaints(clinic_id);
                        if (dt_cf_Complaints.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt_cf_Complaints.Rows.Count; k++)
                            {
                                complaintgrid1.Rows.Add(dt_cf_Complaints.Rows[k]["id"].ToString(), dt_cf_Complaints.Rows[k]["complaint_id"].ToString());
                                complaintgrid1.Rows[complaintgrid1.Rows.Count - 1].Height = 30;
                                complaintgrid1.Rows[complaintgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        System.Data.DataTable dt_cf_observe = this.cntrl.get_observation(clinic_id);
                        if (dt_cf_observe.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt_cf_observe.Rows.Count; k++)
                            {
                                observationgrid1.Rows.Add(dt_cf_observe.Rows[k]["id"].ToString(), dt_cf_observe.Rows[k]["observation_id"].ToString());
                                observationgrid1.Rows[observationgrid1.Rows.Count - 1].Height = 30;
                                observationgrid1.Rows[observationgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del1.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        System.Data.DataTable dt_cf_investigation = this.cntrl.get_invest(clinic_id);
                        if (dt_cf_investigation.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt_cf_investigation.Rows.Count; k++)
                            {
                                investigationgrid1.Rows.Add(dt_cf_investigation.Rows[k]["id"].ToString(), dt_cf_investigation.Rows[k]["investigation_id"].ToString());
                                investigationgrid1.Rows[investigationgrid1.Rows.Count - 1].Height = 30;
                                investigationgrid1.Rows[investigationgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del2.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        System.Data.DataTable dt_cf_diagnosis = this.cntrl.get_diagno(clinic_id);
                        if (dt_cf_diagnosis.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt_cf_diagnosis.Rows.Count; k++)
                            {
                                diagnosisgrid1.Rows.Add(dt_cf_diagnosis.Rows[k]["id"].ToString(), dt_cf_diagnosis.Rows[k]["diagnosis_id"].ToString());
                                diagnosisgrid1.Rows[diagnosisgrid1.Rows.Count - 1].Height = 30;
                                diagnosisgrid1.Rows[diagnosisgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del3.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                        System.Data.DataTable dt_cf_note = this.cntrl.get_note(clinic_id);
                        if (dt_cf_note.Rows.Count > 0)
                        {
                            for (int k = 0; k < dt_cf_note.Rows.Count; k++)
                            {
                                notesgrid1.Rows.Add(dt_cf_note.Rows[k]["id"].ToString(), dt_cf_note.Rows[k]["note_name"].ToString());
                                notesgrid1.Rows[notesgrid1.Rows.Count - 1].Height = 30;
                                notesgrid1.Rows[notesgrid1.Rows.Count - 1].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                                del4.ImageLayout = DataGridViewImageCellLayout.Normal;
                            }
                        }
                    }
                }
                DataTable dt1 = this.cntrl.show_compl();
                complaintgrid.DataSource = dt1;
                lad_compAddNew.Hide();
                comptextbox.Hide();
                compsave.Hide();
                compcancel.Hide();
                lab_compSearch.Show();
                compsearchtext.Show();
                compadd.Show();
                btn_imprt_complnt.Show();
                lab_compSearch.Location = new Point(6, 13);
                compsearchtext.Location = new Point(62, 8);
                complaintgrid.Location = new Point(3, 37);
                complaintpanel.Height = 549;
                complaintpanel.Location = new Point(10, 34);
                complaintpanel.Visible = true;
                investigationpanel.Visible = false;
                diagnosispanel.Visible = false;
                observationpanel.Visible = false;
                notespanel.Visible = false;
                complaintgrid1.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                observationgrid1.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                investigationgrid1.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                diagnosisgrid1.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
                notesgrid1.Rows[0].Cells[2].Value = PappyjoeMVC.Properties.Resources.deleteicon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_clinicalfinding_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                investigationpanel.Hide();
                observationpanel.Hide();
                diagnosispanel.Hide();
                notespanel.Hide();

                complaintpanel.Visible = false;
                if (cmb_clinicalfinding.Text == "Investigations")
                {
                    investigationpanel.Visible = true;
                    DataTable dt2 = this.cntrl.Show_investigation();
                    investigationgrid.DataSource = dt2;
                    label17.Hide();
                    investtextbox.Hide();
                    investsavebut.Hide();
                    investcancel.Hide();
                    investtextbox.Text = "";
                    lab_investSearch.Show();
                    investsearchtext.Show();
                    investadd.Show();
                    btn_imprt_investgtn.Show();
                    lab_investSearch.Location = new Point(6, 13);
                    investsearchtext.Location = new Point(62, 8);
                    investigationgrid.Location = new Point(3, 37);
                    investigationpanel.Location = new Point(10, 34);
                    investigationpanel.Height = 549;
                }
                else if (cmb_clinicalfinding.Text == "Observations")
                {
                    observationpanel.Visible = true;
                    label12.Hide();
                    obsertextbox.Hide();
                    obsersavbut.Hide();
                    obsercancel.Hide();
                    obsertextbox.Text = "";
                    lab_observeSearch.Show();
                    obsersearchtext.Show();
                    obseradd.Show();
                    btn_imprt_obsrvtn.Show();
                    lab_observeSearch.Location = new Point(6, 13);
                    obsersearchtext.Location = new Point(62, 8);
                    observationgrid.Location = new Point(3, 37);
                    observationpanel.Location = new Point(10, 34);
                    observationpanel.Height = 549;
                    DataTable dt1 = this.cntrl.show_observation();
                    observationgrid.DataSource = dt1;
                }
                else if (cmb_clinicalfinding.Text == "Diagnosis")
                {
                    diagnosispanel.Visible = true;
                    DataTable dt3 = this.cntrl.show_diagno();
                    diagnosisgrid.DataSource = dt3;
                    label11.Hide();
                    diagtext.Hide();
                    diagsavebut.Hide();
                    diagcancel.Hide();
                    diagtext.Text = "";
                    Lab_Diag_Search.Show();
                    diagsearchtext.Show();
                    diagadd.Show();
                    btn_imprt_diagno.Show();
                    Lab_Diag_Search.Location = new Point(6, 13);
                    diagsearchtext.Location = new Point(62, 8);
                    diagnosisgrid.Location = new Point(3, 37);
                    diagnosispanel.Location = new Point(10, 34);
                    diagnosispanel.Height = 549;
                }
                else if (cmb_clinicalfinding.Text == "Complaints")
                {
                    complaintpanel.Visible = true;
                    compsave.Visible = true;
                    DataTable dt = this.cntrl.show_compl();
                    complaintgrid.DataSource = dt;
                    lad_compAddNew.Hide();
                    comptextbox.Hide();
                    compsave.Hide();
                    compcancel.Hide();
                    lab_compSearch.Show();
                    compsearchtext.Show();
                    compadd.Show();
                    btn_imprt_complnt.Show();
                    lab_compSearch.Location = new Point(6, 13);
                    compsearchtext.Location = new Point(62, 8);
                    complaintgrid.Location = new Point(3, 37);
                    complaintpanel.Location = new Point(10, 34);
                    complaintpanel.Height = 549;
                }
                else if (cmb_clinicalfinding.Text == "Notes")
                {
                    notespanel.Visible = true;
                    DataTable dt4 = this.cntrl.show_note();
                    notegrid.DataSource = dt4;
                    label14.Hide();
                    notetextbox.Hide();
                    notesavebut.Hide();
                    notecancel.Hide();
                    notetextbox.Text = "";
                    lab_NotesSearch.Show();
                    notesearchtext.Show();
                    noteadd.Show();
                    btn_imprt_notes.Show();
                    lab_NotesSearch.Location = new Point(6, 13);
                    notesearchtext.Location = new Point(62, 8);
                    notegrid.Location = new Point(3, 37);
                    notespanel.Location = new Point(10, 34);
                    notespanel.Height = 549;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        string FileName;
        private void btn_imprt_complnt_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel File to Import";
                ofd.FileName = "";
                ofd.Filter = "Excel File|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;
                    if (FileName.Trim() != "")
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(FileName);
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                        int iRow;
                        if (xlWorkSheet.Cells[1, 1].value == "Complaints")
                        {
                            for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
                            {
                                if (xlWorkSheet.Cells[iRow, 1].value == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string complaints = "";
                                    complaints = xlWorkSheet.Cells[iRow, 1].value;
                                    DataTable checkdatacc = this.cntrl.checkdataAcc(complaints);
                                    if (checkdatacc.Rows.Count == 0)
                                    {
                                        this.cntrl.insert_compl(complaints);
                                    }
                                }
                            }
                            DataTable dt = this.cntrl.show_compl();
                            complaintgrid.DataSource = dt;
                            xlWorkBook.Close();
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                            MessageBox.Show("Successfully Imported !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Excel sheet data is not in the standard format", "Format mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprt_obsrvtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel File to Import";
                ofd.FileName = "";
                ofd.Filter = "Excel File|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;
                    if (FileName.Trim() != "")
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(FileName);
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                        int iRow;
                        if (xlWorkSheet.Cells[1, 1].value == "Observations")
                        {
                            for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
                            {
                                if (xlWorkSheet.Cells[iRow, 1].value == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string obser = "";
                                    obser = xlWorkSheet.Cells[iRow, 1].value;
                                    DataTable checkdataOB = this.cntrl.checkdataOB(obser);
                                    if (checkdataOB.Rows.Count == 0)
                                    {
                                        this.cntrl.insert_Observ(obser);
                                    }
                                }
                            }
                            DataTable dt1 = this.cntrl.show_observation();
                            observationgrid.DataSource = dt1;
                            xlWorkBook.Close();
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                            MessageBox.Show("Successfully Imported !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Excel sheet data is not in the standard format", "Format mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprt_investgtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel File to Import";
                ofd.FileName = "";
                ofd.Filter = "Excel File|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;
                    if (FileName.Trim() != "")
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(FileName);
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                        int iRow;
                        if (xlWorkSheet.Cells[1, 1].value == "Investigations")
                        {
                            for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
                            {
                                if (xlWorkSheet.Cells[iRow, 1].value == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string invest = "";
                                    invest = xlWorkSheet.Cells[iRow, 1].value;
                                    DataTable checkdataINVEST = this.cntrl.CheckInvest(invest);
                                    if (checkdataINVEST.Rows.Count == 0)
                                    {
                                        this.cntrl.investigation_insert(invest);
                                    }
                                }
                            }
                            DataTable dt2 = this.cntrl.Show_investigation();
                            investigationgrid.DataSource = dt2;
                            xlWorkBook.Close();
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                            MessageBox.Show("Successfully Imported !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Excel sheet data is not in the standard format", "Format mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprt_diagno_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel File to Import";
                ofd.FileName = "";
                ofd.Filter = "Excel File|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;
                    if (FileName.Trim() != "")
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(FileName);
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                        int iRow;
                        if (xlWorkSheet.Cells[1, 1].value == "Diagnosis")
                        {
                            for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
                            {
                                if (xlWorkSheet.Cells[iRow, 1].value == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string diag = "";
                                    diag = xlWorkSheet.Cells[iRow, 1].value;
                                    DataTable checkdataDIAG = this.cntrl.CheckdataDiag(diag);
                                    if (checkdataDIAG.Rows.Count == 0)
                                    {
                                        this.cntrl.Insert_diagno(diag);
                                    }
                                }
                            }
                            DataTable dt3 = this.cntrl.show_diagno();
                            diagnosisgrid.DataSource = dt3;
                            xlWorkBook.Close();
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                            MessageBox.Show("Successfully Imported !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Excel sheet data is not in the standard format", "Format mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_imprt_notes_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel File to Import";
                ofd.FileName = "";
                ofd.Filter = "Excel File|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;
                    if (FileName.Trim() != "")
                    {
                        xlApp = new Microsoft.Office.Interop.Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(FileName);
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];
                        int iRow;
                        if (xlWorkSheet.Cells[1, 1].value == "Notes")
                        {
                            for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
                            {
                                if (xlWorkSheet.Cells[iRow, 1].value == null)
                                {
                                    break;
                                }
                                else
                                {
                                    string note = "";
                                    note = xlWorkSheet.Cells[iRow, 1].value;
                                    DataTable checkdataNOTE = this.cntrl.checkdataNote(note);
                                    if (checkdataNOTE.Rows.Count == 0)
                                    {
                                        this.cntrl.insert_note(note);
                                    }
                                }
                            }
                            DataTable dt4 = this.cntrl.show_note();
                            notegrid.DataSource = dt4;
                            xlWorkBook.Close();
                            xlApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
                            MessageBox.Show("Successfully Imported !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("The Excel sheet data is not in the standard format", "Format mismatch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "SAVE CLINICAL FINDINGS")
                {
                    if (investigationgrid1.Rows[0].Cells[1].Value != null && investigationgrid1.Rows[0].Cells[1].Value.ToString() != "" || diagnosisgrid1.Rows[0].Cells[1].Value != null && diagnosisgrid1.Rows[0].Cells[1].Value.ToString() != "" ||
                        notesgrid1.Rows[0].Cells[1].Value != null && notesgrid1.Rows[0].Cells[1].Value.ToString() != "" || observationgrid1.Rows[0].Cells[1].Value != null && observationgrid1.Rows[0].Cells[1].Value.ToString() != ""
                         || complaintgrid1.Rows[0].Cells[1].Value != null && complaintgrid1.Rows[0].Cells[1].Value.ToString() != "")
                    {
                        int treat = 0;
                        string dt = this.cntrl.Get_DoctorId(Cmb_doctor.Text);
                        if (dt != "")
                        {
                            this.cntrl.insertInto_clinical_findings(patient_id, dt.ToString(), dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                            string treatment = this.cntrl.MaxId_clinic_findings();
                            if (Convert.ToInt32(treatment) > 0)
                            {
                                treat = int.Parse(treatment);
                            }
                            else
                            {
                                treat = 1;
                            }
                            try
                            {
                                if (investigationgrid1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < investigationgrid1.Rows.Count; i++)
                                    {
                                        if (investigationgrid1[1, i].Value != null)
                                        {
                                            string one = investigationgrid1[1, i].Value.ToString();
                                            this.cntrl.insrtto_investi(treat, one);
                                        }
                                    }
                                }
                                if (diagnosisgrid1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < diagnosisgrid1.Rows.Count; i++)
                                    {
                                        if (diagnosisgrid1[1, i].Value != null)
                                        {
                                            string one = diagnosisgrid1[1, i].Value.ToString();
                                            this.cntrl.insrtto_diagno(treat, one);

                                        }
                                    }
                                }
                                if (notesgrid1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < notesgrid1.Rows.Count; i++)
                                    {
                                        if (notesgrid1[1, i].Value != null)
                                        {
                                            string one = notesgrid1[1, i].Value.ToString();
                                            this.cntrl.insrtto_note(treat, one);
                                        }
                                    }
                                }
                                if (observationgrid1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < observationgrid1.Rows.Count; i++)
                                    {
                                        if (observationgrid1[1, i].Value != null)
                                        {
                                            string one = observationgrid1[1, i].Value.ToString();
                                            this.cntrl.insrtto_obser(treat, one);
                                        }
                                    }
                                }
                                if (complaintgrid1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < complaintgrid1.Rows.Count; i++)
                                    {
                                        if (complaintgrid1[1, i].Value != null)
                                        {
                                            string one = complaintgrid1[1, i].Value.ToString();
                                            this.cntrl.insrtto_chief_comp(treat, one);
                                        }
                                    }
                                }
                                var form2 = new PappyjoeMVC.View.Clinical_Findings();
                                form2.doctor_id = doctor_id;
                                form2.patient_id = patient_id;
                                form2.Closed += (sender1, args) => this.Close();
                                this.Hide();
                                form2.Show();
                            }
                            catch { }
                        }
                        else
                        {
                            MessageBox.Show("Choose a doctor first", "Doctor missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Click Some Clinical Notes From Right First And Then try again...", "Add Clinical Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (investigationgrid1.Rows[0].Cells[1].Value != null && investigationgrid1.Rows[0].Cells[1].Value.ToString() != "" || diagnosisgrid1.Rows[0].Cells[1].Value != null && diagnosisgrid1.Rows[0].Cells[1].Value.ToString() != "" ||
                        notesgrid1.Rows[0].Cells[1].Value != null && notesgrid1.Rows[0].Cells[1].Value.ToString() != "" || observationgrid1.Rows[0].Cells[1].Value != null && observationgrid1.Rows[0].Cells[1].Value.ToString() != ""
                         || complaintgrid1.Rows[0].Cells[1].Value != null && complaintgrid1.Rows[0].Cells[1].Value.ToString() != "")
                    {
                        string dt = this.cntrl.Get_DoctorId(Cmb_doctor.Text);
                        if (dt != "")
                        {
                            this.cntrl.Update_clinical_findings(patient_id, dt.ToString(), clinic_id);
                        }
                        else
                        {
                            MessageBox.Show("Choose a doctor first", "Doctor missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        this.cntrl.Update_date_of_clinical(dateTimePicker1.Value.ToString("yyyy-MM-dd"), patient_id, clinic_id);
                        this.cntrl.del_investi(clinic_id);
                        this.cntrl.del_diagno(clinic_id);
                        this.cntrl.del_note(clinic_id);
                        this.cntrl.del_obser(clinic_id);
                        this.cntrl.del_chiefComp(clinic_id);

                        for (int i = 0; i < investigationgrid1.Rows.Count; i++)
                        {
                            if (investigationgrid1[1, i].Value != null)
                            {
                                this.cntrl.Add_investi(clinic_id, investigationgrid1[1, i].Value.ToString());
                            }
                        }
                        for (int i = 0; i < diagnosisgrid1.Rows.Count; i++)
                        {

                            if (diagnosisgrid1[1, i].Value != null)
                            {
                                this.cntrl.Add_diagno(clinic_id, diagnosisgrid1[1, i].Value.ToString());
                            }
                        }
                        for (int i = 0; i < notesgrid1.Rows.Count; i++)
                        {
                            if (notesgrid1[1, i].Value != null)
                            {
                                this.cntrl.Add_note(clinic_id, notesgrid1[1, i].Value.ToString());
                            }
                        }
                        for (int i = 0; i < observationgrid1.Rows.Count; i++)
                        {
                            if (observationgrid1[1, i].Value != null)
                            {
                                this.cntrl.Add_observ(clinic_id, observationgrid1[1, i].Value.ToString());
                            }
                        }
                        for (int i = 0; i < complaintgrid1.Rows.Count; i++)
                        {
                            if (complaintgrid1[1, i].Value != null)
                            {
                                this.cntrl.Add_cheifComp(clinic_id, complaintgrid1[1, i].Value.ToString());
                            }
                        }

                        var form2 = new PappyjoeMVC.View.Clinical_Findings();
                        form2.patient_id = patient_id;
                        form2.doctor_id = doctor_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Select Clinical Notes From Right Side....", "Clinical Notes Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void complaintgrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                complaintgrid.ClearSelection();
                var relativeMousePosition = complaintgrid.PointToClient(Cursor.Position);
                this.ConMSp_gridDelete_.Show(complaintgrid, relativeMousePosition);
                complaintgrid.Rows[e.RowIndex].Selected = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (complaintgrid.Rows.Count > 0)
                {
                    int i = 0;
                    int row = Convert.ToInt32(complaintgrid.Rows[complaintgrid.CurrentRow.Index].Cells["Column1"].Value);
                    int rowindex = complaintgrid.SelectedCells[0].RowIndex;
                    if (row != null && rowindex >= 0)
                    {
                        complaintgrid.Rows.RemoveAt(rowindex);
                        i = this.cntrl.Del_Complaints(row);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (complaintgrid.Rows.Count > 0)
                {
                    rowvalue = Convert.ToInt32(complaintgrid.Rows[complaintgrid.CurrentRow.Index].Cells["Column1"].Value);
                    int rowindex = complaintgrid.SelectedCells[0].RowIndex;
                    DataTable dtb = new DataTable();
                    if (rowvalue != null && rowindex >= 0)
                    {
                        dtb = this.cntrl.COMP(rowvalue);
                        if (dtb.Rows.Count > 0)
                        {
                            compsave.Visible = true;
                            compcancel.Visible = true;
                            comptextbox.Visible = true;
                            compadd.Visible = false;
                            btn_imprt_complnt.Visible = false;
                            compsearchtext.Visible = false;
                            lab_compSearch.Visible = false;
                            compsave.Text = "Update";
                            comptextbox.Text = dtb.Rows[0]["name"].ToString();
                            complaintgrid.Location = new Point(3, 65);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
