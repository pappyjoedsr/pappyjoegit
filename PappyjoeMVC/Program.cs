using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.View;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
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
            //Login details = new Login();
            //details.Visible = false;
            //login_model Pmdl;
            //login_controller controller = new login_controller(details);
            //details.ShowDialog();

            PracticeDetails details = new PracticeDetails();
            details.Visible = false;
            Practice_Model Pmdl;
            //Practice_Controller controller = new Practice_Controller(details);
            details.ShowDialog();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run( new frmeditpracticedetails());

            //dgvBilling details = new dgvBilling();
            //details.Visible = false;
            //Billing_model mdl;
            //Billing_controller controller = new Billing_controller(details);
            //details.ShowDialog();
        }
    }
}
