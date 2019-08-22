using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Attachments_interface
    {
        string id { get; set; }
        string patid { get; set; }
        string catgryid { get; set; }
        int attachid { get; set; }
        string catgryname { get; set; }
        void selid(string id);
        void getid(String gid);
        void getcategory(DataTable dt);
        void Get_DoctorName(string dt);
        void getpatdetails(DataTable dt);
        void getpayment(DataTable dt);
        void getattachment(DataTable dt);
        void getattachment2(DataTable dt);
        void privillage_A(DataTable dt);
        void Patient_search(DataTable dt);
        void getpath(string dt);
        void doctr_privillage_for_addnewPatient(DataTable dt);
        void setController(Attachments_controller controller);
    }
}
