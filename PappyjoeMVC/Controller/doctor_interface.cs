using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface doctor_interface
    {
        //string service { get; set; }
        string DrName { get; set; }
        string Number { get; set; }
        string About { get; set; }
        string Year { get; set; }
        string Gender { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string path { get; set; }
        //Clinic Detrails update
        string ClinicName { get; set; }
        string Website { get; set; }
        string Tagline { get; set; }
        //string Services { get; set; }
        //string Specilization { get; set; }
        string ClinicAbout { get; set; }
        string ClinicNumber { get; set; }
        string ClinicEmail { get; set; }
        void Setcontroller(doctor_controller controller);
        //void GetService(DataTable dt);
    }
}
