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
    public partial class LabtrackingReport : Form
    {
        public static LabtrackingReport form;
        public LabtrackingReport()
        {
            InitializeComponent();
            form = this;
        }
        public string doctor_id = "", patient_id = "", chstatus = "";
        LabtrackingReport_controller ctrlr=new LabtrackingReport_controller();
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
            var form2 = new PappyjoeMVC.View.Patients();
            form2.doctor_id = doctor_id;
            form2.Show();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Communication();
            form2.doctor_id = doctor_id;
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
            //var form2 = new PappyjoeMVC.View.consent();
            //form2.doctor_id = doctor_id;
            //form2.Closed += (sender1, args) => this.Close();
            //form2.ShowDialog();
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
            var form2 = new PappyjoeMVC.View.Doctor_Profile();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            form2.ShowDialog();
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Add_New_Patients(); ;
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
                            DataTable keyprs=this.ctrlr.txtkeypress();
                            dataGridView1.DataSource=keyprs;
                        }
                        else
                        {
                            DataTable keyprs2=this.ctrlr.txtkeypress2(textBox2.Text);
                            dataGridView1.DataSource = keyprs2;

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
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "^[a-zA-Z]+$"))
                {
                    if (String.IsNullOrWhiteSpace(textBox2.Text))
                    {
                        DataTable keyup=this.ctrlr.txtkeyup();
                        dataGridView1.DataSource = keyup;
                    }
                    else
                    {
                        DataTable keyup2=this.ctrlr.txtkeyup2(textBox2.Text);
                        dataGridView1.DataSource = keyup2;
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
        private void button6_Click(object sender, EventArgs e)
        {
            DataTable stact=this.ctrlr.stactive();
            dataGridView1.DataSource = stact;
        }
        private void btnsent_Click(object sender, EventArgs e)
        {
            DataTable stsnt=this.ctrlr.statsent();
            dataGridView1.DataSource = stsnt;
        }
        private void btn_Inproduction_Click(object sender, EventArgs e)
        {
            DataTable dt_pt=this.ctrlr.statinproductn();
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Intransit_Click(object sender, EventArgs e)
        {
            DataTable dt_pt=this.ctrlr.statintransit();
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Recieved_Click(object sender, EventArgs e)
        {
            DataTable dt_pt = this.ctrlr.statreceived();
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Overdue_Click(object sender, EventArgs e)
        {
            DataTable dt_pt = this.ctrlr.statoverdue();
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_today_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            DataTable dt_pt = this.ctrlr.duedtetoday(today.ToString("yyyy-MM-dd"));
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_tomorrow_Click(object sender, EventArgs e)
        {
            DateTime tomorrow = DateTime.Now.AddDays(1);
            DataTable dt_pt = this.ctrlr.duedtetommarrow(tomorrow.ToString("yyyy-MM-dd"));
            dataGridView1.DataSource = dt_pt;
        }
        private void btn_Neworder_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.Trackingnullstatus();
            //form2.patient_id = patient_id;
            //form2.doctor_id = doctor_id;
            //form2.Closed += (sender1, args) => this.Close();
            //form2.ShowDialog();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtdr = this.ctrlr.Patient_search(patient_id);
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
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Show();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.ctrlr.userprivilege(doctor_id);
                if (doctor_id != "1")
                {
                    if (int.Parse(id) > 0)
                    {
                        var form2 = new PappyjoeMVC.View.Practice_Details();
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
                    var form2 = new PappyjoeMVC.View.Practice_Details();
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
            try
            {
                //DataTable clinicname = this.ctrlr.practicedetails();
                //toolStripButton4.Visible = true;
                //toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                //if (clinicname.Rows.Count > 0)
                //{
                //    string clinicn = "";
                //    clinicn = clinicname.Rows[0][0].ToString();
                //    toolStripButton1.Text = clinicn.Replace("¤", "'");
                //}
                DataTable dt_pt = this.ctrlr.notnullstatus();
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
                    //ChangeStatus statuschange = new PappyjoeMVC.View.ChangeStatus(jobno, patient, doctor, lab, workname, due, status);
                    //ChangeStatus_controller controller = new ChangeStatus_controller(statuschange);
                    //statuschange.ShowDialog();
                    DataTable dt=this.ctrlr.selectall();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chstatus = dt.Rows[i][13].ToString();
                    }
                    dataGridView1.Rows[k].Cells[7].Value = chstatus;
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            //var form2 = new PappyjoeMVC.View.LabWorks();
            //form2.patient_id = patient_id;
            //form2.doctor_id = doctor_id;
            //form2.Closed += (sender1, args) => this.Close();
            //form2.ShowDialog();
        }
    }
}
