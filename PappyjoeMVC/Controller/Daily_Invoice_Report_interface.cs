using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Daily_Invoice_Report_interface
    {
        string invoice { get; set; }
        string dr_id { get; set; }
        void getdocname(DataTable dt);
        void Get_DoctorId(string dt);
        void getinvoice(DataTable dt);
        void getinvoice2(DataTable dt);
        void getpay(DataTable dt);
        void getpay2(DataTable dt);
        void practicedetails(DataTable dt);
        void setController(Daily_Invoice_Report_controller controller);
    }
}
