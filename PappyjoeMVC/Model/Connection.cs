using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
namespace PappyjoeMVC.Model
{
    public class Connection
    {
        static RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
        static string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
        public static string Dbpath = System.IO.Directory.GetCurrentDirectory();
        static string machine = Environment.MachineName;
        static MySqlConnection con;
        public static MySqlConnection conSP;
        private string serve = "";
        private string database;
        private string uid;
        private string password_ency;
        private string password;

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
                Initialize();
                con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //MessageBox.Show("Cannot connect to server.  Contact administrator", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //MessageBox.Show("Invalid username/password, please try again", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("Invalid username/password, please try again");
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
        public int execute(string s)
        {
            int i = 0;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(s, con);
                i = cmd.ExecuteNonQuery();
                this.CloseConnection();
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
                r = cmd.ExecuteScalar().ToString();
                this.CloseConnection();
            }
            catch { r = "0"; }
            con.Close();
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
                //MessageBox.Show(ex.Message, "Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Console.WriteLine(ex.Message);
            }
            return dt;
        }


        //sql connection



        //static RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
        //static string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
        //static string machine = Environment.MachineName;
        //public static string Dbpath = System.IO.Directory.GetCurrentDirectory();

        //public static SqlConnection con = new SqlConnection(@"Data Source=" + machine + @";Network Library=DBMSSOCN;Initial Catalog=dental;User ID=sa;Password=a;");  //SERVER
        //public static SqlConnection conSP = new SqlConnection(@"Data Source=" + strWindowsState + @"\SQLEXPRESS;Network Library=DBMSSOCN;Initial Catalog=dental;User ID=sa;Password=a;");  //CLIENT

        //public int execute(string s)
        //{
        //    int i = 0;
        //    SqlCommand cmd = new SqlCommand(s, con);
        //    con.Open();
        //    i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return i;
        //}
        //public int ExecuteProcedure(string s)
        //{
        //    int i = 0;
        //    SqlCommand cmd = new SqlCommand(s, con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    con.Open();
        //    i = cmd.ExecuteNonQuery();
        //    con.Close();
        //    return i;
        //}

        //public string scalar(string s)
        //{
        //    string r = "";
        //    SqlCommand cmd = new SqlCommand(s, con);
        //    con.Open();
        //    try
        //    {
        //        r = cmd.ExecuteScalar().ToString();
        //    }
        //    catch { r = "0"; }
        //    con.Close();
        //    return r;
        //}
        //public DataTable table(string s)
        //{
        //    DataTable dt = new DataTable();
        //    //try
        //    //{
        //    SqlCommand cmd = new SqlCommand(s, con);
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(dt);
        //    con.Close();
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show("The Software is not connected to your server, Please check your network connection", "Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    //}
        //    return dt;
        //}

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
