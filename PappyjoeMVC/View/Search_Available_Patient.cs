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
    public partial class Search_Available_Patient : Form
    {
        private DataTable dtb;
        private string doctor_id;
        public static string drctId;
        string id = "";
        Common_model mdl = new Common_model();
        DataTable dtbForPatient = new DataTable();
        Connection db = new Connection();
        public Search_Available_Patient()
        {
            InitializeComponent();
        }

        public Search_Available_Patient(DataTable dtb, string doctor_id)
        {
            InitializeComponent();
            this.dtb = dtb;
            this.doctor_id = doctor_id;
            drctId = doctor_id;
            int rowindex = 0;
            if (dtb.Rows.Count > 0)
            {
                foreach (DataRow dr in dtb.Rows)
                {
                    dgvPatient.Rows.Add();
                    dgvPatient.Rows[rowindex].Cells["colid"].Value = dr["id"].ToString();
                    dgvPatient.Rows[rowindex].Cells["colPatID"].Value = dr["pt_id"].ToString();
                    dgvPatient.Rows[rowindex].Cells["colPatName"].Value = dr["pt_name"].ToString();
                    dgvPatient.Rows[rowindex].Cells["Colmob"].Value = dr["primary_mobile_number"].ToString();
                    dgvPatient.Rows[rowindex].Cells["coldoctName"].Value = dr["doctorname"].ToString();
                    rowindex++;
                }

            }
        }

        private void SearchAvailablePatient_Load(object sender, EventArgs e)
        {
            panel_patientDetails.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnOk.Text == "OK")
                {
                    id = dgvPatient.CurrentRow.Cells["colid"].Value.ToString();
                    string name = dgvPatient.CurrentRow.Cells["coldoctName"].Value.ToString();
                    string dtb = mdl.Get_DoctorId(name);
                    drctId = dtb.ToString();
                    if (id != "")
                    {

                        var form2 = new Patient_Profile_Details();
                        form2.patient_id = id;
                        form2.doctor_id = drctId;
                        form2.MdiParent = this.MdiParent;
                        form2.Show();
                        form2.Closed += (sender1, args) => this.Close();
                        this.Close();
                        bool SetFlag = true;
                        var form1 = new Add_New_Patients(SetFlag);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void clear()
        {
            labName.Text = "";
            labId.Text = "";
            labGender.Text = "";
            labDob.Text = "";
            labMob.Text = "";
            labStreet.Text = "";
            labLocality.Text = "";
            labCity.Text = "";
        }
        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.Rows.Count > 0)
            {
                clear();

                string id = dgvPatient.CurrentRow.Cells["colid"].Value.ToString();
                string patient_id = dgvPatient.CurrentRow.Cells["colPatID"].Value.ToString();
                if (id != "")
                {
                    dtbForPatient = mdl.Get_Patient_Details(id);
                    if (dtbForPatient.Rows.Count > 0)
                    {
                        labName.Text = dtbForPatient.Rows[0]["pt_name"].ToString();
                        labId.Text = dtbForPatient.Rows[0]["pt_id"].ToString();
                        labGender.Text = dtbForPatient.Rows[0]["gender"].ToString();
                        labDob.Text = dtbForPatient.Rows[0]["date_of_birth"].ToString();
                        labMob.Text = dtbForPatient.Rows[0]["primary_mobile_number"].ToString();
                        labEmail.Text = dtbForPatient.Rows[0]["email_address"].ToString();
                        labStreet.Text = dtbForPatient.Rows[0]["street_address"].ToString();
                        labLocality.Text = dtbForPatient.Rows[0]["locality"].ToString();
                        labCity.Text = dtbForPatient.Rows[0]["city"].ToString();
                        panel_patientDetails.Visible = true;
                    }
                    try
                    {
                        string curFile = db.server() + "\\Pappyjoe_utilities\\patient_image\\" + id;

                        if (System.IO.File.Exists(curFile))
                        {
                            pbImg.Image = Image.FromFile(curFile);
                        }
                        else
                        {
                            pbImg.Image = PappyjoeMVC.Properties.Resources.nophoto;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}
