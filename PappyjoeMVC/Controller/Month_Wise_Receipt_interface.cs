using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Month_Wise_Receipt_interface
    {
        void getdocname(DataTable dt);
        void Get_DoctorId(string dt);
        void mnthrcpt(DataTable dt);
        void mnthrcpt2(DataTable dt);
        void getinvdata(DataTable dt);
        void practicedetails(DataTable dt);
        void setController(Month_Wise_Receipt_controller controller);
    }
}
