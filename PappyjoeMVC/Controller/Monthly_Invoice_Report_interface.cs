using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Monthly_Invoice_Report_interface
    {
        void getdocname(DataTable dt);
        void Get_DoctorId(string dt);
        void getdata(DataTable dt);
        void getdata2(DataTable dt);
        void practicedetails(DataTable dt);
        void setController(Monthly_Invoice_Report_controller controller);
    }
}
