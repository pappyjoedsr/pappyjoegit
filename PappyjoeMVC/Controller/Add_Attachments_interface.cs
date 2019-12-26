using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface Add_Attachments_interface
    {
        string id { get; set; }
        string name { get; set; }
        string docname { get; set; }
        string category { get; set; }
        string catgryname { get; set; }
        string path { get; set; }
        string image { get; set; }
        string patid { get; set; }
        string payment { get; set;}
        string mobileno { get; set; }
        void selid(DataTable dt);
        void setController(Add_Attachments_controller controller);
        void getcategory(DataTable dt);
        void getpatdetails(DataTable dt);
        void getpayment(DataTable dt);
        void Patient_search(DataTable dt);
        void Get_CompanyNAme(DataTable dt);
        void Get_DoctorName(string dt);
    }
}
