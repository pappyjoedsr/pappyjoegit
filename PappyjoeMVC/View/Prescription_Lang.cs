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
    public partial class Prescription_Lang : Form
    {
        Practice_Controller cntrl = new Practice_Controller();
        public Prescription_Lang()
        {
            InitializeComponent();
        }

        private void Prescription_Lang_Load(object sender, EventArgs e)
        {
            DataTable language = this.cntrl.Get_CompanyNAme();
            if (language.Rows.Count>0)
            {
                cmbLanguage.Text = language.Rows[0]["Prescription_lang"].ToString();
            }
            foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
            {
                cmbLanguage.Items.Add(lng.Culture.DisplayName);
            }
        }
        public string lang;
        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (InputLanguage lng in InputLanguage.InstalledInputLanguages)
            {
                if (lng.Culture.DisplayName == cmbLanguage.Text)
                {
                    lang = lng.Culture.ToString();
                }
            }
        }

        private void btnSaveLang_Click(object sender, EventArgs e)
        {
            if(cmbLanguage.Text!="")
            {
                this.cntrl.presc_lang(lang);
                MessageBox.Show("Language changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a language", "Language not selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
