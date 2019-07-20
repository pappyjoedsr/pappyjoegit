using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
  public interface patient_edit_interface
    {
        string Ptname { get; set; }
        string patId { get; set; }
        string aadhar { get; set; }
        string age { get; set; }
        string blood { get; set; }
        string family { get; set; }
        string Pmob { get; set; }
        string Smob { get; set; }
        string Landline { get; set; }
        string street { get; set; }
        string email { get; set; }
        string locality { get; set; }
        string city { get; set; }
        string pin { get; set; }
        //string groupid { get; set; }
        string refferedby { get; set; }
        string opticket { get; set; }
        string doctername { get; set; }
        string occupation { get; set; }
        string AdmitDate { get; set; }
        string Visited { get; set; }
        string Dob { get; set; }
        string Gender { get; set; }
        void Setcontroller(patient_edit_controller controller);
        void Fill_modeical(DataTable dtb);
        void Fill_Group(DataTable dtb);

         
    }
}
