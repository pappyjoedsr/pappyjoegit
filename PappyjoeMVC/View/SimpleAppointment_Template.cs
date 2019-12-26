using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;

namespace PappyjoeMVC.View
{
    public partial class SimpleAppointment_Template : Form
    {
        public bool flag_Template = false;
        string  prescription_id = "",  food1 = "", drug_type1 = "", id_temp = "", drug_id = "";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_saveTemplate_Click(object sender, EventArgs e)
        {
            int count = dataGridView_templatenew.Rows.Count;
            if (txt_tempName.Text != "" && count >= 1)
            {
                string Pt_name = "";
                this.cntrl.save_template(txt_tempName.Text);
                string dt = this.cntrl.get_templateid(txt_tempName.Text);
                string dt_patient = this.cntrl.get_patientname(ptid.ToString());
                if (dt_patient!="0")
                {
                    Pt_name = dt_patient;
                }
                else
                    Pt_name = "";
                for (int i = 0; i < count; i++)
                {
                    this.cntrl.save_template(dt , ptid.ToString() , Pt_name , cmbDoctor.SelectedValue.ToString() , cmbDoctor.Text , dateTimePicker1.Value.ToString("yyyy-MM-dd") , dataGridView_templatenew[0, i].Value.ToString() , dataGridView_templatenew[1, i].Value.ToString() , dataGridView_templatenew[2, i].Value.ToString() , dataGridView_templatenew[3, i].Value.ToString() ,dataGridView_templatenew[5, i].Value.ToString() ,dataGridView_templatenew[6, i].Value.ToString(), dataGridView_templatenew[7, i].Value.ToString() ,dataGridView_templatenew[8, i].Value.ToString() , dataGridView_templatenew[9, i].Value.ToString() ,dataGridView_templatenew[11, i].Value.ToString() , dataGridView_templatenew[10, i].Value.ToString() , prescription_id , dataGridView_templatenew[4, i].Value.ToString() ,"1");
                }
                MessageBox.Show("Template added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear_template();
            }
            else
            {
                MessageBox.Show("Please Enter the Template name and Drug(s)..!", "Empty field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView_templatenew_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView_templatenew.Rows.Count > 0)
                {
                    if (e.ColumnIndex == 12)
                    {
                        DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (res == DialogResult.Yes)
                        {
                            dataGridView_templatenew.Rows.RemoveAt(this.dataGridView_templatenew.SelectedRows[0].Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (radioButtonBfrFood.Checked)
            {
                food1 = radioButtonBfrFood.Text.ToString();
            }
            else if (radioButtonAftrFood.Checked)
            {
                food1 = radioButtonAftrFood.Text.ToString();
            }
            dataGridView_templatenew.Rows.Add(cmbPriscriptionTemplate.Text, txtStrengthno.Text, strengthcombo.Text, numericUpDownDuration.Value, cmbDuration.Text, numericUpDownMorning.Value, numericUpDownNoon.Value, numericUpDownNight.Value, food1, richTxtInsrtuction.Text, drug_id, drug_type1, PappyjoeMVC.Properties.Resources.deleteicon);
        }

        SimpleAppointment_Template_controller cntrl = new SimpleAppointment_Template_controller();
        private int patient_id;
        int ptid;
        public SimpleAppointment_Template()
        {
            InitializeComponent();
        }

        public SimpleAppointment_Template(int patient_id)
        {
            InitializeComponent();
            ptid = patient_id;
        }

        private void SimpleAppointment_Template_Load(object sender, EventArgs e)
        {
            DataTable dt_prescription = dt_prescription = this.cntrl.get_drug_name();
            if (dt_prescription.Rows.Count > 0)
            {
                cmbPriscriptionTemplate.ValueMember = "id";
                cmbPriscriptionTemplate.DisplayMember = "name";
                cmbPriscriptionTemplate.DataSource = dt_prescription;
            }
            DataTable dt_doctor = this.cntrl.get_all_doctorname();
            if (dt_doctor.Rows.Count > 0)
            {
                cmbDoctor.ValueMember = "id";
                cmbDoctor.DisplayMember = "doctor_name";
                cmbDoctor.DataSource = dt_doctor;
            }
            flag_Template = true;
        }

        private void cmbPriscriptionTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag_Template == true)
            {
                if (cmbPriscriptionTemplate.SelectedIndex >= 0)
                {
                    string id_temp = cmbPriscriptionTemplate.SelectedValue.ToString();
                    if (id_temp != "")
                    {
                        DataTable dt = this.cntrl.ge_drug(id_temp);
                        if (dt.Rows.Count > 0)
                        {
                            drugnametext.Text = cmbPriscriptionTemplate.Text;
                            txtStrengthno.Text = dt.Rows[0]["strength_gr"].ToString();
                            strengthcombo.Text = dt.Rows[0]["strength"].ToString();
                            drug_type1 = dt.Rows[0][3].ToString();
                            drug_id = dt.Rows[0][5].ToString();
                            richTxtInsrtuction.Hide();
                            richTxtInsrtuction.Text = "";
                            richTxtInsrtuction.Text = dt.Rows[0]["instructions"].ToString();
                        }
                    }
                }
            }
        }
        public void clear_template()
        {
            cmbPriscriptionTemplate.SelectedIndex = 0;
            txtStrengthno.Text = "";
            strengthcombo.Text = "";
            numericUpDownDuration.Value = 0;
            cmbDuration.Text = "";
            numericUpDownMorning.Value = 0;
            numericUpDownNoon.Value = 0;
            numericUpDownNight.Value = 0;
            richTxtInsrtuction.Text = "";
            dataGridView_templatenew.Rows.Clear();
        }
    }
}
