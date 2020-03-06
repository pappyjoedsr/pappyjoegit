//using Microsoft.Win32;
using MySql.Data.MySqlClient;
//using System;
//using System.Data;
//using System.Text;
//using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
namespace PappyjoeMVC.Model
{
    public class Connection
    {
        static RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
        static string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
        public static string Dbpath = System.IO.Directory.GetCurrentDirectory();
        static string machine = Environment.MachineName;
        static MySqlConnection con;
        public static MySqlConnection conSP; //public static MySqlTransaction transaction;
        private string serve = "";
        private string database;
        private string uid;
        private string password_ency;
        private string password;
        public Connection()
        {
            Initialize();
        }
        private void Initialize()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("pappyjoe");
            serve = (string)regKey.GetValue("IP");
            //serve = "desktop-n2oa49j";
            PappyjoeMVC.Model.Connection.MyGlobals.globalPath = (string)regKey.GetValue("Server");
            database = "pappyjoedb";
            uid = (string)regKey.GetValue("User");
            password_ency = (string)regKey.GetValue("Password");
            if (password_ency == "" || password_ency == null)
            { password = ""; }
            else
            { password = EncryptDecrypt(password_ency, 50); }
            string connectionString;
            connectionString = "SERVER=" + serve + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(connectionString);
            conSP = new MySqlConnection(connectionString);
        }
        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                //Initialize();
                con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 1042:
                        MessageBox.Show("Cannot access to server Machine. Try again or select server machine", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RegistryKey regKey = Registry.CurrentUser.CreateSubKey("pappyjoe"); // For Select server machine window
                        regKey.SetValue("Status", "0");
                        Environment.Exit(0);
                        break;
                }
                return false;
            }
        }



        //Close connection
        private bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int execute(string s)
        {
            int i = 0;
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(s, con);
                    i = cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return i;
        }
        public string scalar(string s)
        {
            string r = "";
            MySqlCommand cmd = new MySqlCommand(s, con);
            con.Open();
            try
            {
                //r= cmd.ExecuteScalar() != null ? cmd.ExecuteScalar().ToString() : string.Empty;
                r = cmd.ExecuteScalar().ToString();
                this.CloseConnection();
            }
            catch (Exception ex) { r = "0"; con.Close(); }
            finally
            {
                con.Close();
            }
            return r;
        }
        public DataTable table(string s)
        {
            DataTable dt = new DataTable();
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(s, con);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public void backupdb(string file)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlBackup mb = new MySqlBackup(cmd);
                    cmd.Connection = con;
                    mb.ExportToFile(file);
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void restoredb(string file)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    MySqlBackup mb = new MySqlBackup(cmd);
                    cmd.Connection = con;
                    mb.ImportFromFile(file);
                    this.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static bool checkforemail(string email)
        {
            bool isvalid = false;
            Regex r = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
            if (r.IsMatch(email))
                isvalid = true;
            return isvalid;
        }
        public MySqlDataReader read(string s)
        {
            this.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(s, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            this.CloseConnection();
            return reader;
        }
        public int id(int s)
        {
            int a = 0;
            a = s;
            return a;
        }
        public string name(string name)
        {
            string a = "";
            a = name;
            return a;
        }
        public static class MyGlobals
        {
            public static string globalPath = "Null";
            public static string loginType = "";
            public static string Doctor_id = "";  
            public static string Staff_id = "";
            public static decimal PaidAmount = 0;
            public static string Date_To = "";
            public static string Date_From = "";
            public static bool global_Flag = false;
        }
        public string EncryptDecrypt(string szPlainText, int szEncryptionKey)  //Password Encrypt
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
        public string server()
        {
            RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
            string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
            return @"\\" + strWindowsState;
        }
    }
}
