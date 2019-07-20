using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class doctor_controller
    {
        doctor_interface intr;
        Connection db = new Connection();
        doctor_model _model = new doctor_model();
        doctorpractice_model mdl = new doctorpractice_model();
        common_model cmdl = new common_model();
        public doctor_controller(doctor_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public DataTable load_city()
        {
            DataTable dt11 = db.table("select * from tbl_city order by id");
            return dt11;
        }
        public DataTable Get_DoctorName(string dridd)
        {
            DataTable dt = cmdl.Get_DoctorName(dridd);
           return dt;
        }
        public DataTable  get_companyName()
        {
            DataTable dtb = cmdl.Get_CompanyNAme();
           return dtb;
        }
        public string get_servicecount(string doctor_id)
        {
            string c = _model.get_servicecount(doctor_id);
            return c;
        }
        public string getserviceid(string name)
        {
            string c = _model.getserviceid(name);
            return c;
        }
        public void save_drservice(string drid, string name)
        {
            _model.save_drservice(drid, name);
        }
        public DataTable load_servicegrid(string doctor_id)
        {
            DataTable dtb = _model.load_servicegrid(doctor_id);
            return dtb;
        }
        public DataTable load_serviceCombo()
        {
            DataTable dtb = mdl.load_services();
            return dtb;
        }
        public void delete_dr_service(int rowindex, string drid)
        {
            _model.delete_dr_service(rowindex, drid);
        }
        //specilization
        public string get_specilizationid(string name)
        {
            string c = _model.get_specilizationid(name);
            return c;
        }
        public void dr_savespecilization(string doctor_id, string ser_id)
        {
            _model.dr_savespecilization(doctor_id, ser_id);
        }
        public DataTable load_dr_specilizaion(string doctor_id)
        {
            DataTable dtb = _model.load_dr_specilizaion(doctor_id);
            return dtb;
        }
        public DataTable load_cmbspecilization()
        {
            DataTable dtb = mdl.load_specilization();
            return dtb;
        }
        public void delete_dr_specilization(int rowindex, string drid)
        {
            _model.delete_dr_specilization(rowindex, drid);
        }
        //degree
        public string check_degreeexists(string degree, string doctor_id)
        {
            string dtb = _model.check_degreeexists(degree, doctor_id);
            return dtb;
        }
        public DataTable get_degreeid(string degree)
        {
            DataTable dtb = mdl.ifexists_degree(degree);
            return dtb;
        }
        public DataTable get_collegeid(string college)
        {
            DataTable dtb = mdl.ifexists_college(college);
            return dtb;
        }
        public void save_dr_education(string doctor_id, string degId, string colgId, string year)
        {
            _model.save_dr_education(doctor_id, degId, colgId, year);
        }
        public DataTable load_educationgrid(string doctor_id)
        {
            DataTable dtb = _model.load_educationgrid(doctor_id);
            return dtb;
        }
        public void delete_education(string drid, string degid, string colgid)
        {
            _model.delete_education(drid, degid, colgid);
        }
        public DataTable load_degreecombo()
        {
            DataTable dtb = mdl.load_degree();
            return dtb;
        }
        public DataTable load_collegecombo()
        {
            DataTable dtb = mdl.load_college();
            return dtb;
        }
        public string check_yearexists(string year, string doctor_id)
        {
            string c = _model.check_yearexists(year, doctor_id);
            return c;
        }
        public void save_dr_experiences(string doctor_id, string from, string to, string role, string company, string city)
        {
            _model.save_dr_experiences(doctor_id, from, to, role, company, city);
        }
        public DataTable load_experiecncegrid(string doctor_id)
        {
            DataTable dtb = _model.load_experiecncegrid(doctor_id);
            return dtb;
        }
        public void delete_experience(string expid, string expcompany)
        {
            _model.delete_experience(expid, expcompany);
        }
        //awards
        public void save_awards(string doctor_id, string award, string year)
        {
            _model.save_awards(doctor_id, award, year);
        }
        public DataTable load_awards(string doctor_id)
        {
            DataTable dtb = _model.load_awards(doctor_id);
            return dtb;
        }
        public void delete_awards(string dr_id, string awardname, string stryear)
        {
            _model.delete_awards(dr_id, awardname, stryear);
        }
        public string check_membership(string member)
        {
            string c = _model.check_membership(member);
            return c;
        }
        public void save_member(string doctor_id, string mem_id)
        {
            _model.save_member(doctor_id, mem_id);
        }
        public DataTable load_member(string doctor_id)
        {
            DataTable dtb = _model.load_member(doctor_id);
            return dtb;
        }
        public void delete_member(string doctor_id, string memberid)
        {
            _model.delete_member(doctor_id, memberid);
        }
        public DataTable load_membercombo()
        {
            DataTable dtb = mdl.load_member();
            return dtb;
        }
        //council
        public string check_council(string regCouncil)
        {
            string c = _model.check_council(regCouncil);
            return c;
        }
        public void save_council(string doctor_id, string regnumber, string year, string mem_id)
        {
            _model.save_council(doctor_id, regnumber, year, mem_id);
        }
        public DataTable load_council(string doctor_id)
        {
            DataTable dtb = _model.load_council(doctor_id);
            return dtb;
        }
        public void delete_council(string doctor_id, string regid)
        {
            _model.delete_council(doctor_id, regid);
        }
        public DataTable get_doctor_deteils(string doctor_id)
        {
            DataTable dtb = _model.get_doctor_deteils(doctor_id);
            return dtb;
        }
        public DataTable load_councilcombo()
        {
            DataTable dtb = mdl.load_regcouncil();
            return dtb;
        }
        //
        public int update_doctor(string doctor_id)
        {
            _model.DrName = intr.DrName;
            _model.Gender = intr.Gender;
            _model.Number = intr.Number;
            _model.Year = intr.Year;
            _model.About = intr.About;
            _model.Email = intr.Email;
            _model.Password = intr.Password;
            int i = _model.update_doctor(doctor_id);
            return i;
        }
        public int update_dremail(string doctor_id)
        {
            int i = _model.update_dremail(doctor_id);
            return i;
        }
        public DataTable get_dr_password(string doctor_id)
        {
            DataTable dtb = _model.get_dr_password(doctor_id);
            return dtb;
        }
        public void update_logintable(string doctor, string paswd)
        {
            _model.update_logintable(doctor, paswd);
        }
        public DataTable get_doctor_details(string doctor_id)
        {
            DataTable dtb = _model.get_doctor_details(doctor_id);
            return dtb;
        }
        //clinical details
        public DataTable  practice_id()
        {
            DataTable dtb = cmdl.Get_CompanyNAme();
            return dtb;
        }
        public void save_clinic_service(string clinicid, string ser_id)
        {
            _model.save_clinic_service(clinicid, ser_id);
        }
         public DataTable load_clinic_services(string clinicid)
        {
            DataTable dtb = _model.load_clinic_services(clinicid);
            return dtb;
        }
        public DataTable get_companydetails()
         {
             DataTable dtb = cmdl.get_company_details();
             return dtb;
         }
         public DataTable clinic_service(string clinicid)
        {
            DataTable dtb = _model.clinic_service(clinicid);
            return dtb;
        }
        public void delete_clinic_service(string clinicservice, string clinicid)
         {
             _model.delete_clinic_service(clinicservice, clinicid);
         }
         public DataTable cinic_specilization(string clinicid)
         {
             DataTable dtb = _model.cinic_specilization(clinicid);
             return dtb;
         }
         public void save_clinic_specilization(string clinicid, string spc_id)
         {
             _model.save_clinic_specilization(clinicid, spc_id);
         }
         public void delete_clinicspecilization(string clinicspecial,string clinicid)
         {
             _model.delete_clinicspecilization(clinicspecial, clinicid);
         }
         public void update_clinicdetails()
         {
             _model.ClinicName = intr.ClinicName;
             _model.Tagline = intr.Tagline;
             _model.ClinicNumber = intr.ClinicNumber;
             _model.ClinicEmail = intr.ClinicEmail;
             _model.Website = intr.Website;
             _model.About = intr.About;
             _model.update_clinicdetails();
         }
    }
}
