using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Add_Labwork : Form
    {
        public Add_Labwork()
        {
            InitializeComponent();
        }
        bool flag;
        public static string ID = "";
        Add_Labwork_controller ctrlr = new Add_Labwork_controller();
        public string patient_id = "", doctor_id = "", checkvalue = "", ids = "", r = "", f = "";
        public string[] teeth = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Delete this Item.. Confirm?", "Remove Item", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.dataGridView3.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        public void maxid(string iddt)
        {
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                int a = i + 1;
                int k = 0;
                if (iddt != "")
                {
                    k = Convert.ToInt32(iddt);
                }
                else
                {
                    k = 1;
                }
                this.ctrlr.labresult(k.ToString(), a.ToString(), dataGridView3.Rows[i].Cells[7].Value.ToString(), dataGridView3.Rows[i].Cells[6].Value.ToString(), Convert.ToInt32(patient_id).ToString(), dataGridView3.Rows[i].Cells[4].Value.ToString(), dataGridView3.Rows[i].Cells[5].Value.ToString());
            }
        }
        //dental rb
        public void dentallab(DataTable dt)
        {
            cmbShade.DataSource = dt;
            cmbShade.DisplayMember = "shade";
            cmbShade.ValueMember = "id";
            cmbAlloytype.DataSource = dt;
            cmbAlloytype.DisplayMember = "aloytype";
            cmbAlloytype.ValueMember = "id";
            dgvdentalwork.DataSource = dt;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked == true)
                {
                    radioButton1.Checked = false;
                    pnlMedlab.Hide();
                    pnlDental.Show();
                    pnladddental.Show();
                    c.Hide();
                    DataTable dt = this.ctrlr.dentallab();
                    dentallab(dt);
                }
                else
                {
                    radioButton2.Checked = false;
                    pnlDental.Show();
                    pnlMedlab.Show();
                    pnlMedlab.Visible = true;
                    pnlMedlab.Location = new Point(5, 10);
                    c.Show();
                    c.Visible = true;
                    c.Location = new Point(1015, 141);
                    DataTable tbshade = this.ctrlr.Lab_Medi_TemplateMain();
                    dataGridView2.DataSource = tbshade;
                    checkvalue = "1";
                    DataTable tblab = this.ctrlr.getLabdata();
                    combolab.DataSource = tblab;
                    combolab.DisplayMember = "labname";
                    combolab.ValueMember = "id";
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    radioButton2.Checked = false;
                    pnlDental.Show();
                    pnlMedlab.Show();
                    pnlMedlab.Visible = true;
                    pnlMedlab.Location = new Point(5, 10);
                    c.Show();
                    c.Visible = true;
                    c.Location = new Point(1015, 141);
                    DataTable tbshade = this.ctrlr.Lab_Medi_TemplateMain();
                    dataGridView2.DataSource = tbshade;
                    checkvalue = "1";
                    DataTable tblab = this.ctrlr.getLabdata();
                    combolab.DataSource = tblab;
                    combolab.DisplayMember = "labname";
                    combolab.ValueMember = "id";
                }
                else
                {
                    radioButton1.Checked = false;
                    pnlMedlab.Hide();
                    pnlDental.Show();
                    pnladddental.Show();
                    c.Hide();
                    DataTable dt = this.ctrlr.dentallab();
                    dentallab(dt);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.LabWorks();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.ctrlr.privilge_for_inventory(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                var form2 = new Practice_Details();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void logOuntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void TTP_SearchText_Click(object sender, EventArgs e)
        {
            TTP_SearchText.Clear();
        }

        private void TTP_SearchText_TextChanged(object sender, EventArgs e)
        {
            if (TTP_SearchText.Text != "")
            {
                DataTable dtdr = this.ctrlr.Patient_search(TTP_SearchText.Text);
                listpatientsearch.DataSource = dtdr;
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStrip1.Width - 350, 32);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.ctrlr.doctr_privillage_for_addnewPatient(doctor_id);
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
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        public void listeeth()
        {
            string toothno = "";
            int qty = 0;
            for (int i = 0; i < 51; i++)
            { if (teeth[i] != "") { toothno = toothno + '|' + teeth[i]; qty++; } }
            if (toothno.Length > 2) { label15.Text = toothno.Substring(1, (toothno.Length) - 1); }
            else { label15.Text = ""; }
        }
        private void chk18_CheckedChanged(object sender, EventArgs e)
        {
            if (chk18.Checked) { teeth[0] = "18"; } else { teeth[0] = ""; }
            listeeth();
        }
        private void chk17_CheckedChanged(object sender, EventArgs e)
        {
            if (chk17.Checked) { teeth[1] = "17"; } else { teeth[1] = ""; }
            listeeth();
        }
        private void chk16_CheckedChanged(object sender, EventArgs e)
        {
            if (chk16.Checked) { teeth[2] = "16"; } else { teeth[2] = ""; }
            listeeth();
        }
        private void chk15_CheckedChanged(object sender, EventArgs e)
        {
            if (chk15.Checked) { teeth[3] = "15"; } else { teeth[3] = ""; }
            listeeth();
        }
        private void chk14_CheckedChanged(object sender, EventArgs e)
        {
            if (chk14.Checked) { teeth[4] = "14"; } else { teeth[4] = ""; }
            listeeth();
        }
        private void chk13_CheckedChanged(object sender, EventArgs e)
        {
            if (chk13.Checked) { teeth[5] = "13"; } else { teeth[5] = ""; }
            listeeth();
        }
        private void chk12_CheckedChanged(object sender, EventArgs e)
        {
            if (chk12.Checked) { teeth[6] = "12"; } else { teeth[6] = ""; }
            listeeth();
        }
        private void chk11_CheckedChanged(object sender, EventArgs e)
        {
            if (chk11.Checked) { teeth[7] = "11"; } else { teeth[7] = ""; }
            listeeth();
        }
        private void chk21_CheckedChanged(object sender, EventArgs e)
        {
            if (chk21.Checked) { teeth[8] = "21"; } else { teeth[8] = ""; }
            listeeth();
        }
        private void chk22_CheckedChanged(object sender, EventArgs e)
        {
            if (chk22.Checked) { teeth[9] = "22"; } else { teeth[9] = ""; }
            listeeth();
        }
        private void chk23_CheckedChanged(object sender, EventArgs e)
        {
            if (chk23.Checked) { teeth[10] = "23"; } else { teeth[10] = ""; }
            listeeth();
        }
        private void chk24_CheckedChanged(object sender, EventArgs e)
        {
            if (chk24.Checked) { teeth[11] = "24"; } else { teeth[11] = ""; }
            listeeth();
        }
        private void chk25_CheckedChanged(object sender, EventArgs e)
        {
            if (chk25.Checked) { teeth[12] = "25"; } else { teeth[12] = ""; }
            listeeth();
        }
        private void chk26_CheckedChanged(object sender, EventArgs e)
        {
            if (chk26.Checked) { teeth[13] = "26"; } else { teeth[13] = ""; }
            listeeth();
        }
        private void chk27_CheckedChanged(object sender, EventArgs e)
        {
            if (chk27.Checked) { teeth[14] = "27"; } else { teeth[14] = ""; }
            listeeth();
        }
        private void chk28_CheckedChanged(object sender, EventArgs e)
        {
            if (chk28.Checked) { teeth[15] = "28"; } else { teeth[15] = ""; }
            listeeth();
        }
        private void chk48_CheckedChanged(object sender, EventArgs e)
        {
            if (chk48.Checked) { teeth[31] = "48"; } else { teeth[31] = ""; }
            listeeth();
        }
        private void chk47_CheckedChanged(object sender, EventArgs e)
        {
            if (chk47.Checked) { teeth[30] = "47"; } else { teeth[30] = ""; }
            listeeth();
        }
        private void chk46_CheckedChanged(object sender, EventArgs e)
        {
            if (chk46.Checked) { teeth[29] = "46"; } else { teeth[29] = ""; }
            listeeth();
        }
        private void chk45_CheckedChanged(object sender, EventArgs e)
        {
            if (chk45.Checked) { teeth[28] = "45"; } else { teeth[28] = ""; }
            listeeth();
        }
        private void chk44_CheckedChanged(object sender, EventArgs e)
        {
            if (chk44.Checked) { teeth[27] = "44"; } else { teeth[27] = ""; }
            listeeth();
        }
        private void chk43_CheckedChanged(object sender, EventArgs e)
        {
            if (chk43.Checked) { teeth[26] = "43"; } else { teeth[26] = ""; }
            listeeth();
        }
        private void chk42_CheckedChanged(object sender, EventArgs e)
        {
            if (chk42.Checked) { teeth[25] = "42"; } else { teeth[25] = ""; }
            listeeth();
        }
        private void chk41_CheckedChanged(object sender, EventArgs e)
        {
            if (chk41.Checked) { teeth[24] = "41"; } else { teeth[24] = ""; }
            listeeth();
        }
        private void chk31_CheckedChanged(object sender, EventArgs e)
        {
            if (chk31.Checked) { teeth[23] = "31"; } else { teeth[23] = ""; }
            listeeth();
        }
        private void chk32_CheckedChanged(object sender, EventArgs e)
        {
            if (chk32.Checked) { teeth[22] = "32"; } else { teeth[22] = ""; }
            listeeth();
        }
        private void chk33_CheckedChanged(object sender, EventArgs e)
        {
            if (chk33.Checked) { teeth[21] = "33"; } else { teeth[21] = ""; }
            listeeth();
        }
        private void chk34_CheckedChanged(object sender, EventArgs e)
        {
            if (chk34.Checked) { teeth[20] = "34"; } else { teeth[20] = ""; }
            listeeth();
        }
        private void chk35_CheckedChanged(object sender, EventArgs e)
        {
            if (chk35.Checked) { teeth[19] = "35"; } else { teeth[19] = ""; }
            listeeth();
        }
        private void chk36_CheckedChanged(object sender, EventArgs e)
        {
            if (chk36.Checked) { teeth[18] = "36"; } else { teeth[18] = ""; }
            listeeth();
        }
        private void chk37_CheckedChanged(object sender, EventArgs e)
        {
            if (chk37.Checked) { teeth[17] = "37"; } else { teeth[17] = ""; }
            listeeth();
        }
        private void chk38_CheckedChanged(object sender, EventArgs e)
        {
            if (chk38.Checked) { teeth[16] = "38"; } else { teeth[16] = ""; }
            listeeth();
        }
        private void chk55_CheckedChanged(object sender, EventArgs e)
        {
            if (chk55.Checked) { teeth[32] = "55"; } else { teeth[32] = ""; }
            listeeth();
        }
        private void chk54_CheckedChanged(object sender, EventArgs e)
        {
            if (chk54.Checked) { teeth[33] = "54"; } else { teeth[33] = ""; }
            listeeth();
        }
        private void chk53_CheckedChanged(object sender, EventArgs e)
        {
            if (chk53.Checked) { teeth[34] = "53"; } else { teeth[34] = ""; }
            listeeth();
        }
        private void chk52_CheckedChanged(object sender, EventArgs e)
        {
            if (chk52.Checked) { teeth[35] = "52"; } else { teeth[35] = ""; }
            listeeth();
        }
        private void chk51_CheckedChanged(object sender, EventArgs e)
        {
            if (chk51.Checked) { teeth[36] = "51"; } else { teeth[36] = ""; }
            listeeth();
        }
        private void chk61_CheckedChanged(object sender, EventArgs e)
        {
            if (chk61.Checked) { teeth[37] = "61"; } else { teeth[37] = ""; }
            listeeth();
        }
        private void chk62_CheckedChanged(object sender, EventArgs e)
        {
            if (chk62.Checked) { teeth[38] = "62"; } else { teeth[38] = ""; }
            listeeth();
        }
        private void chk63_CheckedChanged(object sender, EventArgs e)
        {
            if (chk63.Checked) { teeth[39] = "63"; } else { teeth[39] = ""; }
            listeeth();
        }
        private void chk64_CheckedChanged(object sender, EventArgs e)
        {
            if (chk64.Checked) { teeth[40] = "64"; } else { teeth[40] = ""; }
            listeeth();
        }
        private void chk65_CheckedChanged(object sender, EventArgs e)
        {
            if (chk65.Checked) { teeth[41] = "65"; } else { teeth[41] = ""; }
            listeeth();
        }
        private void chk85_CheckedChanged(object sender, EventArgs e)
        {
            if (chk85.Checked) { teeth[51] = "85"; } else { teeth[51] = ""; }
            listeeth();
        }
        private void chk84_CheckedChanged(object sender, EventArgs e)
        {
            if (chk84.Checked) { teeth[50] = "84"; } else { teeth[50] = ""; }
            listeeth();
        }
        private void chk83_CheckedChanged(object sender, EventArgs e)
        {
            if (chk83.Checked) { teeth[49] = "83"; } else { teeth[49] = ""; }
            listeeth();
        }
        private void chk82_CheckedChanged(object sender, EventArgs e)
        {
            if (chk82.Checked) { teeth[48] = "82"; } else { teeth[48] = ""; }
            listeeth();
        }
        private void chk81_CheckedChanged(object sender, EventArgs e)
        {
            if (chk81.Checked) { teeth[47] = "81"; } else { teeth[47] = ""; }
            listeeth();
        }
        private void chk71_CheckedChanged(object sender, EventArgs e)
        {
            if (chk71.Checked) { teeth[46] = "71"; } else { teeth[46] = ""; }
            listeeth();
        }
        private void chk72_CheckedChanged(object sender, EventArgs e)
        {
            if (chk72.Checked) { teeth[45] = "72"; } else { teeth[45] = ""; }
            listeeth();
        }
        private void chk73_CheckedChanged(object sender, EventArgs e)
        {
            if (chk73.Checked) { teeth[44] = "73"; } else { teeth[44] = ""; }
            listeeth();
        }
        private void chk74_CheckedChanged(object sender, EventArgs e)
        {
            if (chk74.Checked) { teeth[43] = "74"; } else { teeth[43] = ""; }
            listeeth();
        }
        private void chk75_CheckedChanged(object sender, EventArgs e)
        {
            if (chk75.Checked) { teeth[42] = "75"; } else { teeth[42] = ""; }
            listeeth();
        }
        public void testrslt(DataTable tbshade)
        {
            try
            {
                for (int i = 0; i < tbshade.Rows.Count; i++)
                {
                    labelmaintest.Text = tbshade.Rows[i]["Test Name"].ToString();
                    labeltesttype.Text = tbshade.Rows[i]["SampleType"].ToString();
                    txtname.Text = tbshade.Rows[i]["Test Name"].ToString();
                    txttype.Text = tbshade.Rows[i]["SampleType"].ToString();
                    dataGridView3.DataSource = tbshade;
                    this.dataGridView3.Columns[6].Visible = false;
                    this.dataGridView3.Columns[7].Visible = false;
                    checkvalue = "1";
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string k = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            string p = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            string q = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            DataTable dt = this.ctrlr.testrslt(q);
            testrslt(dt);
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = this.ctrlr.grid3data(linkLabel1.Text);
            dataGridView3.DataSource = dt;
        }
        private void dgvdentalwork_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ids = dgvdentalwork.Rows[e.RowIndex].Cells[0].Value.ToString();
            r = dgvdentalwork.Rows[e.RowIndex].Cells[4].Value.ToString();
            f = dgvdentalwork.Rows[e.RowIndex].Cells[2].Value.ToString();
            DataTable workname = this.ctrlr.getwrkname(r);
            for (int i = 0; i < workname.Rows.Count; i++)
            {
                txtwork_id.Text = workname.Rows[i]["id"].ToString();
                txtWorktype.Text = workname.Rows[i]["work_type"].ToString();
                txtworkname.Text = workname.Rows[i]["work_name"].ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    if (dataGridView3.Rows.Count > 0)
                    {
                        ID = this.ctrlr.selectid(labelmaintest.Text);
                        this.ctrlr.inslabmain(patient_id, comboBox6.SelectedValue.ToString(), labelmaintest.Text, ID, Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd"), Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd"));
                        string id = this.ctrlr.maxid();
                        maxid(id);
                        var form2 = new PappyjoeMVC.View.LabWorks();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = patient_id;
                        form2.FormClosed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(" Please Add Lab Work", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (txtworkname.Text.Trim() != "" && txtwork_id.Text.Trim() != "")
                    {
                        this.ctrlr.inslabmain2(patient_id, doctor_id, txtworkname.Text, txtwork_id.Text, Convert.ToDateTime(dateTimePicker1.Text).ToString("yyyy-MM-dd"));
                        string id = this.ctrlr.maxid();
                        this.ctrlr.insdentlab(id, txtworkname.Text, txtWorktype.Text, cmbAlloytype.Text, cmbShade.Text, patient_id, label15.Text);
                        var form2 = new PappyjoeMVC.View.LabWorks();
                        form2.doctor_id = doctor_id;
                        form2.patient_id = patient_id;
                        form2.FormClosed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(" Please Add Lab Work Or select work name in left side..", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Add_Labwork_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripButton9.Text = PappyjoeMVC.Model.GlobalVariables.Version;
                radioButton2.Checked = false;
                radioButton1.Checked = false;
                pnlDental.Hide();
                pnlMedlab.Hide();
                pnladddental.Hide();
                c.Hide();
                panel13.Visible = true;
                panel13.Location = new Point(4, 600);
                DataTable rs_patients = this.ctrlr.Get_Patient_Details(patient_id);
                if (rs_patients.Rows[0]["pt_name"].ToString() != "")
                {
                    linkLabel1.Text = rs_patients.Rows[0]["pt_name"].ToString();
                }
                if (rs_patients.Rows[0]["pt_id"].ToString() != "")
                {
                    linkLabel2.Text = rs_patients.Rows[0]["pt_id"].ToString();
                }
                DataTable doctorcombo = this.ctrlr.getdoctrdetails();
                comboBox6.DisplayMember = "doctor_name";
                comboBox6.ValueMember = "id";
                comboBox6.DataSource = doctorcombo;
                label15.Text = "";
                DataTable tbshade = this.ctrlr.Lab_Medi_TemplateMain();
                dataGridView2.DataSource = tbshade;
                checkvalue = "1";
                DataTable tblab = this.ctrlr.getLabdata();
                combolab.DataSource = tblab;
                combolab.DisplayMember = "labname";
                combolab.ValueMember = "id";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
