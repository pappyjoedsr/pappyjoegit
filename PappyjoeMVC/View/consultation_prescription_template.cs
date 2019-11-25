using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
namespace Pappyjoe
{
    public partial class consultation_prescription_template : Form
    {
        public string pres_id = "";
        Consultation_prescription_template_controller cntrl = new Consultation_prescription_template_controller();
        public consultation_prescription_template()
        {
            InitializeComponent();
        }

        private void consultation_prescription_template_Load(object sender, EventArgs e)
        {
            DataTable dtb_prescription = this.cntrl.get_tempid(pres_id);
            if(dtb_prescription.Rows.Count>0)
            {
                txt_tempName.Text = dtb_prescription.Rows[0]["templates"].ToString();
                DataTable dt = this.cntrl.get_templateid(pres_id);
                dataGridView_templatenew.Rows.Clear();
                if (dt.Rows.Count>0)
                {
                   
                    for (int i=0;i<dt.Rows.Count;i++)
                    {
                        dataGridView_templatenew.Rows.Add();
                        dataGridView_templatenew.Rows[i].Cells["drgname"].Value = dt.Rows[i]["drug_name"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["strength"].Value = dt.Rows[i]["strength"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["strengthgr"].Value = dt.Rows[i]["strength_gr"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["duration"].Value = dt.Rows[i]["duration"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["PERIOD"].Value = dt.Rows[i]["morning"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["noon"].Value = dt.Rows[i]["noon"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["neight"].Value = dt.Rows[i]["night"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["food"].Value = dt.Rows[i]["food"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["instruction"].Value = dt.Rows[i]["add_instruction"].ToString();
                        dataGridView_templatenew.Rows[i].Cells["type"].Value = dt.Rows[i]["drug_type"].ToString();
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
