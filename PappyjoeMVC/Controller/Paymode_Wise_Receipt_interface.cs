using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Paymode_Wise_Receipt_interface
    {
        void getdocname(DataTable dt);
        void getinvdata(DataTable dt);
        void practicedetails(DataTable dt);
        void setController(Paymode_Wise_Receipt_controller controller);
    }
}
