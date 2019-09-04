using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Doctor_Wise_Receipt_interface
    {
        void getdocid(string e);
        void mnthrcpt(DataTable dt);
        void mnthrcpt2(DataTable dt);
        void getdocname(DataTable dt);
        void getinvdata(DataTable dt);
        void practicedetails(DataTable dt);



        void setController(Doctor_Wise_Receipt_controller controller);
    }
}
