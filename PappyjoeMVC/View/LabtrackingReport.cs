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
    public partial class LabtrackingReport : Form,LabtrackingReport_interface
    {
        public static LabtrackingReport form;
        public LabtrackingReport()
        {
            InitializeComponent();
            form = this;
        }
        LabtrackingReport_controller ctrlr;
        public string doctor_id = "", patient_id = "", chngstatus = "";
        public void setController(LabtrackingReport_controller controller)
        {
            ctrlr = controller;
        }
        private void toolStripBAttachment_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.view.frmfastTrack1();
            //form2.doctor_id = doctor_id;
            //form2.Show();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.frmMain();
            //form2.doctor_id = doctor_id;
            //form2.Show();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patients();
            form2.doctor_id = doctor_id;
            form2.Show();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Communication();
            form2.doctor_id = doctor_id;
            communication_Controller controller = new communication_Controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.FrmStockReport();
            //form2.doctor_id = doctor_id;
            //form2.Show();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.Reports();
            //form2.doctor_id = doctor_id;
            //form2.Show();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.consent();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Expense(); ;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.DOCTOR_PROFILE();
            //form2.doctor_id = doctor_id;
            //form2.Closed += (sender1, args) => this.Close();
            //form2.ShowDialog();
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.AddNewPatients(); ;
            form2.doctor_id = doctor_id;
            form2.Show();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        if (String.IsNullOrWhiteSpace(textBox2.Text))
                        {
                            this.ctrlr.txtkeypress();
                        }
                        else
                        {
                            this.ctrlr.txtkeypress2(textBox2.Text);

                        }
                    }
                }
                else
                {
                    if (textBox2.Text != "")
                    {
                        textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                        MessageBox.Show("Enter only Alphabets", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void txtkeypress(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        public void txtkeypress2(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
                {
                    if (String.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        this.ctrlr.txtkeyup();
                    }
                    else
                    {
                        this.ctrlr.txtkeyup2(textBox2.Text);
                    }
                }
                else
                {
                    if (textBox2.Text != "")
                    {
                        textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                        MessageBox.Show("Enter only Alphabets", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void txtkeyup(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        public void txtkeyup2(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.ctrlr.stactive();
        }
        public void stactive(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btnsent_Click(object sender, EventArgs e)
        {
            this.ctrlr.statsent();
        }
        public void statsent(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Inproduction_Click(object sender, EventArgs e)
        {
            this.ctrlr.statinproductn();
        }
        public void statinproductn(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        public void statintransit(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Intransit_Click(object sender, EventArgs e)
        {
            this.ctrlr.statintransit();
        }
        public void statreceived(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Recieved_Click(object sender, EventArgs e)
        {
            this.ctrlr.statreceived();
        }
        private void btn_Overdue_Click(object sender, EventArgs e)
        {
            this.ctrlr.statoverdue();
        }
        public void statoverdue(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_today_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            this.ctrlr.duedtetoday(today.ToString("yyyy-MM-dd"));
        }
        public void duedtetoday(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_tomorrow_Click(object sender, EventArgs e)
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            this.ctrlr.duedtetommarrow(tomorrow.ToString("yyyy-MM-dd"));
        }
        public void duedtetommarrow(DataTable dt_pt)
        {
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Neworder_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Trackingnullstatus();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            Trackingnullstatus_controller controller = new Trackingnullstatus_controller(form2);
            //form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.ctrlr.Patient_search(patient_id);
        }
        public void Patient_search(DataTable dtdr)
        {
            try
            {
                if (toolStripTextBox1.Text != "")
                {
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
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.patient_profile_details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Show();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ctrlr.userprivilege(doctor_id);
        }
        public void userprivilege(string doctrid)
        {
            try
            {
                if (doctor_id != "1")
                {
                    string id;
                    id = doctrid;
                    if (int.Parse(id) > 0)
                    {
                        var form2 = new PappyjoeMVC.View.PracticeDetails();
                        form2.doctor_id = doctor_id;
                        form2.Show();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.PracticeDetails();
                    form2.doctor_id = doctor_id;
                    form2.Show();
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.Login();
            //form2.Show();
            //form2.Closed += (sender1, args) => this.Close();
            //this.Hide();
        }
        private void LabtrackingReport_Load(object sender, EventArgs e)
        {
            this.ctrlr.practicedetails();
            this.ctrlr.notnullstatus();
        }
        public void practicedetails(DataTable clinicname)
        {
            toolStripButton4.Visible = true;
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            if (clinicname.Rows.Count > 0)
            {
                string clinicn = "";
                clinicn = clinicname.Rows[0][0].ToString();
                toolStripButton1.Text = clinicn.Replace("¤", "'");
            }
        }
        public void notnullstatus(DataTable dt_pt)
        {
            try
            {
                dataGridView1.DataSource = dt_pt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Sego UI", 9, FontStyle.Regular);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;
                foreach (DataGridViewColumn cl in dataGridView1.Columns)
                {
                    cl.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                if (e.ColumnIndex == 0)
                {
                    int k = e.RowIndex;
                    string jobno = dataGridView1.Rows[k].Cells[1].Value.ToString();
                    string patient = dataGridView1.Rows[k].Cells[2].Value.ToString();
                    string doctor = dataGridView1.Rows[k].Cells[3].Value.ToString();
                    string lab = dataGridView1.Rows[k].Cells[4].Value.ToString();
                    string workname = dataGridView1.Rows[k].Cells[5].Value.ToString();
                    string due = dataGridView1.Rows[k].Cells[6].Value.ToString();
                    string status = dataGridView1.Rows[k].Cells[7].Value.ToString();
                    ChangeStatus statuschange = new PappyjoeMVC.View.ChangeStatus(jobno, patient, doctor, lab, workname, due, status);
                    ChangeStatus_controller controller = new ChangeStatus_controller(statuschange);
                    statuschange.ShowDialog();
                    this.ctrlr.selectall();
                    dataGridView1.Rows[k].Cells[7].Value = chngstatus;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void selectall(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                chngstatus = dt.Rows[i][13].ToString();
            }
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.LabWorks();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            LabWorks_controller controller = new LabWorks_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
    }
}
