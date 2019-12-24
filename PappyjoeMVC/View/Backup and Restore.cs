using PappyjoeMVC.Model;
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
        Backup_and_Restore_controller ctrlr = new Backup_and_Restore_controller();
        private void button1_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.ctrlr.backupdb(saveFileDialog1.OpenFile().ToString());
            }
        }
    }
}
