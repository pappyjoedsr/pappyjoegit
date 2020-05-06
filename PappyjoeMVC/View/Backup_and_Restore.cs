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
    public partial class Backup_and_Restore : Form
    {
        public Backup_and_Restore()
        {
            InitializeComponent();
        }
        public static string filepath = "";
        Backup_and_Restore_controller ctrlr = new Backup_and_Restore_controller();
        private void btnbackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filepath = saveFileDialog1.FileName + ".sql";
                    this.ctrlr.backupdb(filepath);
                    MessageBox.Show("backup complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnrestore_Click(object sender, EventArgs e)
        {
            try
            {
                if(openFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    filepath = openFileDialog1.FileName;
                    this.ctrlr.restoredb(filepath);
                    MessageBox.Show("restore complete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
