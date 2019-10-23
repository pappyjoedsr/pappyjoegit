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
    public partial class Consultation : Form
    {
        public static bool flag = false;
        public string doctor_id = "", patient_id = "";
        Consultation_controller cntrl = new Consultation_controller();
        public Consultation()
        {
            InitializeComponent();
        }

        private void Consultation_Load(object sender, EventArgs e)
        {

        }

        private void txt_Pt_search_TextChanged(object sender, EventArgs e)
        {
            if (flag == false)
            {
                if (txt_Pt_search.Text != "")
                {
                    lbPatient.Show();
                    lbPatient.Location = new Point(txt_Pt_search.Location.X, 27);
                    DataTable dtdr = this.cntrl.search_patient(txt_Pt_search.Text);// db.table("select pt_id,pt_name from tbl_patient where pt_name like '%" + txt_Pt_search.Text + "%'  ");
                    lbPatient.DataSource = dtdr;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "pt_id";
                }
                else
                {
                    DataTable dtdr = this.cntrl.search_patient(txt_Pt_search.Text); //db.table("select pt_id,pt_name from tbl_patient where pt_name like '%" + txt_Pt_search.Text + "%'  ");
                    lbPatient.DataSource = dtdr;
                    lbPatient.DisplayMember = "pt_name";
                    lbPatient.ValueMember = "pt_id";
                }
            }
        }

        private void txt_Pt_search_Click(object sender, EventArgs e)
        {
            txt_Pt_search.Text = "";
        }

        private void txt_procedure_Click(object sender, EventArgs e)
        {
            txt_procedure.Text = "";
        }

        private void txt_procedure_TextChanged(object sender, EventArgs e)
        {
            if (txt_procedure.Text != "")
            {
                lst_procedure.Show();
                lst_procedure.Location = new Point(txt_procedure.Location.X, 100);
                DataTable dtdr = this.cntrl.search_procedure(txt_procedure.Text);// db.table("select id,name from tbl_addproceduresettings where name like '%" + txt_procedure.Text + "%'  ");
                lst_procedure.DataSource = dtdr;
                lst_procedure.DisplayMember = "name";
                lst_procedure.ValueMember = "id";
            }
            else
            {
                DataTable dtdr = this.cntrl.search_procedure(txt_procedure.Text);// db.table("select id,name from tbl_addproceduresettings where name like '%" + txt_procedure.Text + "%'  ");
                lst_procedure.DataSource = dtdr;
                lst_procedure.DisplayMember = "name";
                lst_procedure.ValueMember = "id";
            }
        }

        private void lbPatient_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbPatient.SelectedItems.Count > 0)
            {
                string value = lbPatient.SelectedValue.ToString();
                DataTable patient = new DataTable();
                patient = this.cntrl.patient_details(value);// db.table("select id, pt_name,pt_id from tbl_patient where pt_id='" + value + "'");
                if (patient.Rows.Count > 0)
                {
                    txt_Pt_search.Text = patient.Rows[0]["pt_name"].ToString();
                    txtPatientID.Text = patient.Rows[0]["pt_id"].ToString();
                    patient_id = patient.Rows[0]["id"].ToString();
                    lbPatient.Visible = false;
                }
                else
                {
                    MessageBox.Show("Please choose  Correct patient....", "Data Not Found..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
