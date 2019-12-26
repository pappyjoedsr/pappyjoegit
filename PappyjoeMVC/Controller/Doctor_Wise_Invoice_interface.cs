using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Doctor_Wise_Invoice_interface
    {
        void getdocname(DataTable dt);
        void Get_DoctorId(string dt);
        void getdata3(DataTable dt);
        void getdata4(DataTable dt);
        void practicedetails(DataTable dt);
        void setController(Doctor_Wise_Invoice_controller controller);
    }
}
