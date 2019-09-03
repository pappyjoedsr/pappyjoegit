using PappyjoeMVC.Controller;
using System;
using System.Data;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Calender_Settings : Form
    {
        Calender_controller cntrl=new Calender_controller();
        string  slot;
        public Calender_Settings()
        {
            InitializeComponent();
        }
        private void combo_slot_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Hide();
            errorProvider1.Dispose();
        }

        private void Calender_Settings_Load(object sender, EventArgs e)
        {
            combo_slot.SelectedIndex = 4;
            if (combo_slot.Text != "")
            {
                errorProvider1.Dispose();
                label2.Hide();
            }
            DataTable dtb = this.cntrl.get_practicetimingvalues();
            FormLoad(dtb);
        }
        public void FormLoad(DataTable visit)
        {
            if (visit.Rows.Count > 0)
            {
                string slot = visit.Rows[0][2].ToString() + "minutes";
                combo_slot.Text = slot;
            }
        }

        private void button_savetimings_Click(object sender, EventArgs e)
        {
            if (combo_slot.Text == "")
            {
                errorProvider1.SetError(combo_slot, "error");
                label2.Show();
            }
            else
            {
                errorProvider1.Dispose();
                label2.Hide();
                slot = combo_slot.Text.Substring(0, combo_slot.Text.IndexOf("m")).ToString();
                int i = this.cntrl.update(slot);
                if (i > 0)
                {
                    MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
