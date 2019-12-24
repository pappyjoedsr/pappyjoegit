using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Day_Wise_Receipt_interface
    {
        void getinvdata(DataTable dt);
        void getdocname(DataTable dt);
        void practicedetails(DataTable dt);
        void setController(Day_Wise_Receipt_controller controller);
    }
}
