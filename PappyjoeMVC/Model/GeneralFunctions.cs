using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Model
{
    class GeneralFunctions
    {
        Connection db = new Connection();

        public void ResetAll_Panel(Panel pnl)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = (TextBox)ctrl;
                    textBox.Text = null;
                }
                if (ctrl is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)ctrl;
                    comboBox.SelectedIndex = -1;
                }
                if (ctrl is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)ctrl;
                    checkBox.Checked = false;
                }
                if (ctrl is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)ctrl;
                    radioButton.Checked = false;
                }
                if (ctrl is ListBox)
                {
                    ListBox listBox = (ListBox)ctrl;
                    listBox.ClearSelected();
                }
                if (ctrl is DataGridView)
                {
                    DataGridView dataGridView = (DataGridView)ctrl;
                    dataGridView.DataSource = null;
                    dataGridView.Rows.Clear();


                }
            }
        }

        public void ResetAll_GroupBox(GroupBox gb)
        {
            foreach (Control ctrl in gb.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = (TextBox)ctrl;
                    textBox.Text = null;
                }
                if (ctrl is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)ctrl;
                    comboBox.SelectedIndex = -1;
                }
                if (ctrl is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)ctrl;
                    checkBox.Checked = false;
                }
                if (ctrl is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)ctrl;
                    radioButton.Checked = false;
                }
                if (ctrl is ListBox)
                {
                    ListBox listBox = (ListBox)ctrl;
                    listBox.ClearSelected();
                }
                if (ctrl is DataGridView)
                {
                    DataGridView dataGridView = (DataGridView)ctrl;
                    dataGridView.DataSource = null;
                    dataGridView.Rows.Clear();


                }
            }
        }
        public Boolean controlValidation(Panel pnl)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox textBox = (TextBox)ctrl;

                    if (String.IsNullOrWhiteSpace(textBox.Text) && textBox.Tag != null)
                    {
                        textBox.Focus();
                        MessageBox.Show(textBox.Tag.ToString(), "Mandatory Fields");
                        return true;
                    }

                }
                else if (ctrl is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)ctrl;

                    if (String.IsNullOrWhiteSpace(comboBox.Text) && comboBox.Tag != null)
                    {
                        comboBox.Focus();
                        MessageBox.Show(comboBox.Tag.ToString(), "Mandatory Fields");
                        return true;
                    }

                }
            }
            return false;
        }
        public Boolean checkNormal(string chkVal)
        {
            double num;
            if (double.TryParse(chkVal, out num))
            {
                // It's a number!
                return true;
            }
            else
            {
                return false;
            }
        }
        public void showMessage(String msgCode)
        {
            DataTable dt = db.table("select * from tbl_message where message_Id = '" + msgCode + "'");
            String Msg = (from DataRow dr in dt.Rows select (String)dr["vc_Message"]).FirstOrDefault();
            String msgHead = (from DataRow dr in dt.Rows select (String)dr["vc_Message_Head"]).FirstOrDefault();
            MessageBox.Show(Msg, msgHead);
        }

    }
}
