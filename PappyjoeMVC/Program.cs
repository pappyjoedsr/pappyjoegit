using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.View;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System.Net;

namespace PappyjoeMVC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] 
        static void Main()
                                                                                         {
            String strWindowsState = "";
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
            try
            {
                strWindowsState = (String)regKeyAppRoot.GetValue("Status");
            }
            catch
            {
                Microsoft.Win32.RegistryKey pappyjoeRegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("pappyjoe");
                pappyjoeRegistryKey.SetValue("Status", "0");
                strWindowsState = (String)regKeyAppRoot.GetValue("Status");
            }
            if (strWindowsState == null)
            { strWindowsState = "0"; }
            if (strWindowsState == "0")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Network_Computer());
            }
            else
            {
                MySqlConnection connection;
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("pappyjoe");
                string SystemName = (string)regKey.GetValue("Server");
                string connectionString;
                string server = (string)regKey.GetValue("IP");
                string uid = (string)regKey.GetValue("User");
                string database = "pappyjoedb";
                string password;
                string password_ency = (string)regKey.GetValue("Password");
                if (password_ency == "" || password_ency == null)
                { password = ""; }
                else
                {
                    password = "";// EncryptDecrypt(password_ency, 50);
                }
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                try
                {
                    connection.Open();
                    connection.Close();
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("An error occurred trying to access the server computer... ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string strComutername = ""; ;
                    strComutername = SystemName.ToString();
                    IPAddress[] addresslist = Dns.GetHostAddresses(strComutername);
                    foreach (IPAddress ip4 in addresslist.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
                    {
                        Microsoft.Win32.RegistryKey pappyjoeRegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("pappyjoe");
                        pappyjoeRegistryKey.SetValue("IP",ip4.ToString());
                    }
                }
            }
        }
    }
}
