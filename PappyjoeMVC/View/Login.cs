using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace PappyjoeMVC.View
{
    public partial class Login : Form
    {
        Login_controller cntrl=new Login_controller();
        public string hexcodes1 = "";
        public string hexcodes2 = "";
        public int intAgain;
        public string regdate1 = "";
        string DOCTORID = "";

        public Login()
        {
            InitializeComponent();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);
        private void Login_Paint(object sender, PaintEventArgs e)
        {
            System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, 50, 50); // _BoarderRaduis can be adjusted to your needs, try 15 to start.
            this.Region = System.Drawing.Region.FromHrgn(ptr);
            DeleteObject(ptr);
        }
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

        private void Login_Load(object sender, EventArgs e)
        {
            Lab_InvalidLogin.Hide();
            Lab_InvaldActivation.Hide();
            DataTable dtb= this.cntrl.GetActivation();
            Load_Login(dtb);
        }

        public void Load_Login(DataTable choice)
        {
            try
            {
                RegistryKey regKey = Registry.CurrentUser.CreateSubKey("pappyjoe");
                string SystemName = (string)regKey.GetValue("Server");
                if (choice.Rows.Count > 0)
                {
                    //============= Start 365 Days Activation Validity
                    hexcodes1 = choice.Rows[0]["hexacode"].ToString();
                    if (hexcodes1 != "")
                    {
                        intAgain = int.Parse(hexcodes1, System.Globalization.NumberStyles.HexNumber);
                    }
                    regdate1 = choice.Rows[0]["registrationdate"].ToString();
                    if (regdate1 == "")
                    {
                        this.cntrl.update_activation();
                    }
                    else
                    {
                        System.DateTime firstDate = Convert.ToDateTime(regdate1);
                        System.DateTime secondDate = DateTime.Now.Date;
                        String diff2 = (secondDate - firstDate).TotalDays.ToString();
                        int number = Int32.Parse(diff2);
                        if (number > intAgain || number == intAgain)
                        {
                            DialogResult dialog = MessageBox.Show("Your system date is correct...?", "System Date", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (dialog == DialogResult.Yes)
                            {
                                this.cntrl.update_activation();
                                MessageBox.Show("PAPPYJOE RENEW ACTIVATION.\n\n Your Pappyjoe Subscription has expired. Kindly contact 0484-2597272 for renewal of subscription.", "PAPPYJOE RENEW ACTIVATION", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                Application.Exit();
                            }
                        }
                    }
                    //=========== End 365 Days Activation Validity
                    if (SystemName == Environment.MachineName)
                    {
                        if (choice.Rows[0]["getcode"].ToString() == GetMacAddress())
                        {
                            Lab_InvalidLogin.Hide();
                            Lab_InvaldActivation.Hide();
                            DataTable sd = this.cntrl.Activation_Details();
                            if (sd.Rows.Count > 0)
                            {
                                string listgetcode = GetMacAddress();
                                string listactcode = MD5Hash(GetMacAddress());
                                string actcode = sd.Rows[0]["actcode"].ToString();
                                if (actcode == listactcode)
                                {
                                    RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
                                    string strWindowsState = (string)regKeyAppRoot.GetValue("username");
                                    if (strWindowsState != null)
                                    {
                                        txt_userName.Text = strWindowsState.ToString();
                                    }
                                    panel1.Hide();
                                    panel2.Show();
                                }
                                else
                                {
                                    txt_getCode.Text = GetMacAddress();
                                    panel1.Show();
                                    panel1.Location = new System.Drawing.Point(18, 37);
                                    panel2.Hide();
                                }
                            }
                        }
                        else
                        {
                            txt_getCode.Text = GetMacAddress();
                            panel1.Show();
                            panel1.Location = new System.Drawing.Point(18, 37);
                            panel2.Hide();
                        }
                    }
                    else
                    {
                        //****************************client**********************************
                        DataTable client = this.cntrl.Activation_Details();
                        if (client.Rows.Count > 0)
                        {
                            string listgetcode = client.Rows[0]["getcode"].ToString();
                            string listactcode = MD5Hash(listgetcode);
                            string actcode = client.Rows[0]["actcode"].ToString();
                            if (actcode == listactcode)
                            {
                                RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("pappyjoe");
                                string strWindowsState = (string)regKeyAppRoot.GetValue("username");
                                if (strWindowsState != null)
                                {
                                    txt_userName.Text = strWindowsState.ToString();
                                }
                                panel1.Hide();
                                panel2.Show();
                            }
                            else
                            {
                                txt_getCode.Text = GetMacAddress();
                                panel1.Show();
                                panel1.Location = new System.Drawing.Point(18, 37);
                                panel2.Hide();
                            }
                        }
                    }
                }
                else
                {
                    this.cntrl.Save_activation_Null();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private string GetMacAddress()
        {
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            var selectedNic = nics.First();
            var macAddress = selectedNic.GetPhysicalAddress().ToString();
            return macAddress;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        private void txt_userName_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text == "UserName")
            {
                txt_userName.Clear();
            }
        }

        private void txt_userName_KeyDown(object sender, KeyEventArgs e)
        {
            Lab_InvalidLogin.Hide();
        }

        private void txt_password_Click(object sender, EventArgs e)
        {
            if (txt_password.Text == "************")
            {
                txt_password.Clear();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            Lab_InvalidLogin.Hide();
        }

        private void txt_password_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginfunction();
            }
        }

        private void btn_Activation_Click(object sender, EventArgs e)
        {
            try
            {
                Lab_InvaldActivation.Text = "";
                if (txt_activation.Text != "")
                {
                    string listgetcode = GetMacAddress();
                    string listactcode = MD5Hash(GetMacAddress());
                    string actcode = txt_activation.Text;
                    Label lblhexcode = new Label();
                    long decnum = 0;
                    int[] hexnum = new int[20];
                    int i = 0, r;
                    decnum = long.Parse(txt_daycode.Text);
                    while (decnum != 0)
                    {
                        r = (int)decnum % 16;
                        if (r < 10)
                        {
                            r = r + 48;
                        }
                        else
                        {
                            r = r + 55;
                        }
                        hexnum[i++] = r;
                        decnum = decnum / 16;
                    }
                    for (int j = i - 1; j >= 0; j--)
                    {
                        lblhexcode.Text += (char)hexnum[j];
                    }
                    if (actcode == listactcode)
                    {
                        this.cntrl.delete_activation();
                        this.cntrl.save_activation(listgetcode, listactcode, lblhexcode.Text);
                        MessageBox.Show("Activation successfully completed...", "Activated", MessageBoxButtons.OK, MessageBoxIcon.None);
                        panel1.Hide();
                        panel2.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Activation Code...", "Activation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Activation Code..", "Activation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_daycode_Click(object sender, EventArgs e)
        {
            if (txt_daycode.Text == "(Number of Days)")
            {
                txt_daycode.Clear();
            }
        }

        private void txt_daycode_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        public void loginfunction()
        {
            try
            {
                DataTable sd = this.cntrl.Get_userdetails(txt_userName.Text,txt_password.Text);
                if (sd.Rows.Count > 0)
                {
                    string name = sd.Rows[0]["username"].ToString();
                    string password = sd.Rows[0]["password"].ToString();
                    string type = sd.Rows[0]["type"].ToString();
                    DataTable doctor = this.cntrl.Get_Doctor_Activation(txt_userName.Text,txt_password.Text);
                    if (doctor.Rows.Count > 0)
                    {
                        if (doctor.Rows[0]["activate_login"].ToString() == "Yes")
                        {
                            Microsoft.Win32.RegistryKey pappyjoeRegistryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("pappyjoe");
                            pappyjoeRegistryKey.SetValue("username", name);
                            pappyjoeRegistryKey.Close();
                            DOCTORID = doctor.Rows[0][0].ToString();
                            PappyjoeMVC.Model.Connection.MyGlobals.loginType = type;
                            PappyjoeMVC.Model.Connection.MyGlobals.Doctor_id = DOCTORID;
                            
                            DataTable sms = this.cntrl.Get_smsconfig();
                            if (sms.Rows.Count > 0)
                            {
                                if (String.IsNullOrWhiteSpace(sms.Rows[0]["smsName"].ToString()) || String.IsNullOrWhiteSpace(sms.Rows[0]["smsPass"].ToString()))
                                {
                                    MessageBox.Show("SMS Service not Activated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    PappyjoeMVC.Model.GlobalVariables.smsName = "";
                                    PappyjoeMVC.Model.GlobalVariables.smsPass = "";
                                }
                                else
                                {
                                    PappyjoeMVC.Model.GlobalVariables.smsName = sms.Rows[0]["smsName"].ToString();
                                    PappyjoeMVC.Model.GlobalVariables.smsPass = sms.Rows[0]["smsPass"].ToString();
                                }
                                if (String.IsNullOrWhiteSpace(sms.Rows[0]["emailName"].ToString()) || String.IsNullOrWhiteSpace(sms.Rows[0]["emailPass"].ToString()))
                                {
                                    MessageBox.Show("Email Service not Activated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("SMS and Email Services are not Activated!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            var form2 = new PappyjoeMVC.View.Main_Calendar();
                            form2.doctor_id = DOCTORID;
                            form2.Closed += (sender1, args) => this.Close();
                            this.Hide();
                            form2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Login Not activated Yet", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    Lab_InvalidLogin.Show();
                    txt_password.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            loginfunction();
        }
    }
}
