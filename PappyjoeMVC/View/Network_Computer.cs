using MySql.Data.MySqlClient;
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
using System.Net;

namespace PappyjoeMVC.View
{
    public partial class Network_Computer : Form
    {
        NetworkBrowser_model mdl = new NetworkBrowser_model();
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn
       (
       int nLeftRect, // x-coordinate of upper-left corner
       int nTopRect, // y-coordinate of upper-left corner
       int nRightRect, // x-coordinate of lower-right corner
       int nBottomRect, // y-coordinate of lower-right corner
       int nWidthEllipse, // height of ellipse
       int nHeightEllipse // width of ellipse
      );
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);
        private MySqlConnection connection;
        public Network_Computer()
        {
            InitializeComponent();
        }
        private void Network_Computer_Load(object sender, EventArgs e)
        {
            try
            {
                pnlservername.Location = new Point(13, 63);
                txtserverusername.Text = "root@localhost";
                //NetworkBrowser nb = new NetworkBrowser();
                foreach (string pc in mdl.getNetworkComputers())
                {
                    lstBoxNetworkComputers.Items.Add(pc);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error occurred trying to access the network computers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void Network_Computer_Paint(object sender, PaintEventArgs e)
        {
            System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            this.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
        }

        private void lstBoxNetworkComputers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if ((lstBoxNetworkComputers.Items.Count > 0) && (lstBoxNetworkComputers.SelectedIndex >= 0))
                {
                    string strComutername = ""; ;
                    strComutername = lstBoxNetworkComputers.SelectedItem.ToString();
                    IPAddress[] addresslist = Dns.GetHostAddresses(strComutername);
                    foreach (IPAddress ip4 in addresslist.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        txtip.Text = ip4.ToString();
                        txtservername.Text = strComutername.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                txtip.Text = "";
                txtservername.Text = "";
                MessageBox.Show("An error occurred trying to access the network computers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (txtip.Text.Trim() == "")
            {
                MessageBox.Show("Server not found..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pnlservername.Visible = true;
            btnnext.Visible = false;
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            pnlservername.Visible = false;
            btnnext.Visible = true;
            lbltestresult.Visible = false;
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            if (txtip.Text != "" && txtservername.Text != "" && txtserverusername.Text != "")
            {
                string strPassword = "";
                string strYesNo = "NO";
                if (lbltestresult.Visible == false || lbltestresult.Text != "Success")
                {
                    DialogResult dialogResult = MessageBox.Show("Test connection failed...Anyway to continue...?", "Continue...", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    { strYesNo = "YES"; }
                    else
                    { strYesNo = "NO"; }
                }
                else
                {
                    strYesNo = "YES";
                }
                if (strYesNo == "YES")
                {
                    strPassword = EncryptDecrypt(txtserverpassword.Text, 50);
                    Microsoft.Win32.RegistryKey pappyjoeRegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("pappyjoe");
                    pappyjoeRegistryKey.SetValue("Server", txtservername.Text);
                    pappyjoeRegistryKey.SetValue("IP", txtip.Text);
                    pappyjoeRegistryKey.SetValue("User", txtserverusername.Text);
                    pappyjoeRegistryKey.SetValue("Password", strPassword.ToString());
                    pappyjoeRegistryKey.SetValue("Status", "1");
                    PappyjoeMVC.Model.Connection.MyGlobals.globalPath = txtservername.Text;
                    pappyjoeRegistryKey.Close();
                    var form2 = new Login();
                    form2.Show();
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("An error occurred trying to access the network computers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string EncryptDecrypt(string szPlainText, int szEncryptionKey)
        {
            StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
            StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
            char Textch;
            for (int iCount = 0; iCount < szPlainText.Length; iCount++)
            {
                Textch = szInputStringBuild[iCount];
                Textch = (char)(Textch ^ szEncryptionKey);
                szOutStringBuild.Append(Textch);
            }
            return szOutStringBuild.ToString();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntest_Click(object sender, EventArgs e)
        {
            lbltestresult.Text = "Wait...";
            if (txtip.Text != "" && txtservername.Text != "" && txtserverusername.Text != "")
            {
                string connectionString;
                string server;
                string database;
                string uid;
                string password;
                server = txtip.Text;
                database = "pappyjoedb";
                //  database = "test";
                uid = txtserverusername.Text;
                password = txtserverpassword.Text;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                //connectionString = "SERVER= 127.0.0.1;" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                lbltestresult.Visible = true;
                if (this.OpenConnection() == true)
                {
                    lbltestresult.Text = "Success";
                    this.CloseConnection();
                }
                else
                {
                    lbltestresult.Text = "Failed";
                }
            }
            else
            {
                lbltestresult.Visible = false;
            }
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
