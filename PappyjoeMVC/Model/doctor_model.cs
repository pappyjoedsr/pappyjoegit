using System.Data;
namespace PappyjoeMVC.Model
{
    public class Doctor_model
    {
        Connection db = new Connection();
        public string get_servicecount(string doctor_id)
        {
            string c = db.scalar("select count(service_id) from tbl_dr_service where dr_id='" + doctor_id + "'");
            return c;
        }
        public string getserviceid(string name)
        {
            string ser_id = db.scalar("select id from tbl_services where service='" + name + "'");
            return ser_id;
        }
        public void save_drservice(string doctor_id, string ser_id)
        {
            db.execute("insert into tbl_dr_service (dr_id,service_id) values('" + doctor_id + "','" + ser_id + "')");
        }
        public DataTable load_servicegrid(string doctor_id)
        {
            DataTable service1 = db.table("SELECT tbl_dr_service.dr_id,tbl_dr_service.service_id,tbl_services.service FROM tbl_dr_service INNER JOIN tbl_services ON tbl_dr_service.service_id = tbl_services.id where dr_id='" + doctor_id + "'");
            return service1;
        }
        public void delete_dr_service(int rowindex, string drid)
        {
            db.execute("delete from tbl_dr_service where service_id='" + rowindex + "' and dr_id='" + drid + "'");
        }
        //specilization
        public string get_specilizationid(string name)
        {
            string ser_id = db.scalar("select id from tbl_specialization where name='" + name + "'");
            return ser_id;
        }
        public void dr_savespecilization(string doctor_id, string ser_id)
        {
            db.execute("insert into tbl_dr_specialization (dr_id,special_id) values('" + doctor_id + "','" + ser_id + "')");
        }
        public DataTable load_dr_specilizaion(string doctor_id)
        {
            DataTable special = db.table("SELECT tbl_dr_specialization.dr_id,tbl_dr_specialization.special_id,tbl_specialization.name FROM tbl_dr_specialization INNER JOIN tbl_specialization ON tbl_dr_specialization.special_id = tbl_specialization.id where dr_id='" + doctor_id + "'");
            return special;
        }
        public void delete_dr_specilization(int rowindex, string drid)
        {
            db.execute("delete from tbl_dr_specialization where special_id='" + rowindex + "' and dr_id='" + drid + "'");
        }
        //education
        public string check_degreeexists(string degree, string doctor_id)
        {
            string c = db.scalar("select degree_id from tbl_dr_education where degree_id='" + degree + "' and dr_id='" + doctor_id + "'");
            return c;
        }
        public string check_yearexists(string year, string doctor_id)
        {
            string c = db.scalar("select year from tbl_dr_education where year='" + year + "' and dr_id='" + doctor_id + "'");
            return c;
        }
        public void save_dr_education(string doctor_id, string degId, string colgId, string year)
        {
            db.execute("insert into tbl_dr_education(dr_id,degree_id,college_id,year) values('" + doctor_id + "','" + degId + "','" + colgId + "','" + year + "')");
        }
        public DataTable load_educationgrid(string doctor_id)
        {
            DataTable education1 = db.table("SELECT tbl_dr_education.dr_id,tbl_dr_education.degree_id,tbl_dr_education.college_id,tbl_college.college, tbl_degree.degree, tbl_dr_education.year FROM tbl_dr_education INNER JOIN tbl_degree ON tbl_dr_education.degree_id = tbl_degree.id INNER JOIN tbl_college ON tbl_dr_education.college_id = tbl_college.id where dr_id='" + doctor_id + "'");
            return education1;
        }
        public void delete_education(string drid, string degid, string colgid)
        {
            int edu = db.execute("delete from tbl_dr_education where dr_id='" + drid + "' and degree_id='" + degid + "' and college_id='" + colgid + "'");
        }
        //experience
        public void save_dr_experiences(string doctor_id, string from, string to, string role, string company, string city)
        {
            db.execute("insert into tbl_dr_experience (dr_id,from_year,to_year,role,company,city_name) values('" + doctor_id + "','" + from + "','" + to + "','" + role + "','" + company + "','" + city + "')");
        }
        public DataTable load_experiecncegrid(string doctor_id)
        {
            DataTable experience1 = db.table("select dr_id,from_year,to_year,role,company,city_name from tbl_dr_experience where dr_id='" + doctor_id + "'");
            return experience1;
        }
        public void delete_experience(string expid, string expcompany)
        {
            db.execute("delete from tbl_dr_experience where dr_id='" + expid + "' and company='" + expcompany + "'");
        }
        public DataTable load_city()
        {
            DataTable dt11 = db.table("select * from tbl_city order by id");
            return dt11;
        }
        //awards
        public void save_awards(string doctor_id, string award, string year)
        {
            db.execute("insert into  tbl_dr_awards (dr_id,name,year) values('" + doctor_id + "','" + award + "','" + year + "')");
        }
        public DataTable load_awards(string doctor_id)
        {
            DataTable awards1 = db.table("select dr_id,name,year from tbl_dr_awards where dr_id='" + doctor_id + "'");
            return awards1;
        }
        public void delete_awards(string dr_id, string awardname, string stryear)
        {
            db.execute("delete from tbl_dr_awards where dr_id='" + dr_id + "' and name='" + awardname + "' and year='" + stryear + "'");
        }
        public string check_membership(string member)
        {
            string mem_id = db.scalar("select id from tbl_memberships where name='" + member + "' ");
            return mem_id;
        }
        public void save_member(string doctor_id, string mem_id)
        {
            db.execute("insert into  tbl_dr_membership (dr_id,membership_id) values('" + doctor_id + "','" + mem_id + "')");
        }
        public DataTable load_member(string doctor_id)
        {
            DataTable member1 = db.table("SELECT tbl_dr_membership.membership_id,tbl_memberships.name FROM tbl_dr_membership INNER JOIN tbl_memberships ON tbl_dr_membership.membership_id = tbl_memberships.id where dr_id='" + doctor_id + "'");
            return member1;
        }
        public void delete_member(string doctor_id, string memberid)
        {
            db.execute("delete from tbl_dr_membership where dr_id='" + doctor_id + "' and membership_id='" + memberid + "'");
        }
        //registration
        public string check_council(string regCouncil)
        {
            string mem_id = db.scalar("select id from tbl_reg_council where name='" + regCouncil + "'");
            return mem_id;
        }
        public void save_council(string doctor_id, string regnumber, string year, string mem_id)
        {
            db.execute("insert into  tbl_dr_registration (dr_id,reg_no,year,reg_council_id) values('" + doctor_id + "','" + regnumber + "','" + year + "','" + mem_id + "')");
        }
        public DataTable load_council(string doctor_id)
        {
            DataTable register = db.table("SELECT tbl_dr_registration.reg_council_id, tbl_reg_council.name,tbl_dr_registration.year,tbl_dr_registration.reg_no FROM tbl_dr_registration INNER JOIN  tbl_reg_council ON tbl_dr_registration.reg_council_id = tbl_reg_council.id where tbl_dr_registration.dr_id='" + doctor_id + "'");
            return register;
        }
        public void delete_council(string doctor_id, string regid)
        {
            db.execute("delete from tbl_dr_registration where dr_id='" + doctor_id + "' and reg_no='" + regid + "'");
        }
        public DataTable get_doctor_deteils(string doctor_id)
        {
            DataTable dt = db.table("select email_id,registration_number,calendar_color,activate_login,login_type from tbl_doctor where id='" + doctor_id + "'");
            return dt;
        }
     
        public int update_doctor(string doctor_id, string _drname, string _number, string _email, string _gender, string _year, string _about, string _path,string _logtype)
        {
            int update;
            if (_path == "")//llll
            {
                update = db.execute("update tbl_doctor set doctor_name='" + _drname + "',mobile_number='" + _number + "',email_id='" + _email + "',gender='" + _gender + "',experience='" + _year + "',about='" + _about + "',image= null,login_type='"+_logtype+"' where id='" + doctor_id + "'");
            }
            else
            {
                update = db.execute("update tbl_doctor set doctor_name='" + _drname + "',mobile_number='" + _number + "',email_id='" + _email + "',gender='" + _gender + "',experience='" + _year + "',about='" + _about + "',image='" + _path + "',login_type='" + _logtype + "' where id='" + doctor_id + "'");
            }
            return update;
        }
        public int update_dremail(string doctor_id, string _email, string _password)
        {
            int i = db.execute("update tbl_doctor set email_id='" + _email + "', password='" + _password + "' where id='" + doctor_id + "'");
            return i;
        }
        public void update_logintable(string doctor, string _email, string _password, string paswd)
        {
            db.execute("update tbl_login set username='" + _email + "',password='" + _password + "' where username='" + doctor + "' and password='" + paswd + "'");
        }
        public DataTable get_dr_password(string doctor_id)
        {
            DataTable dt = db.table("select email_id,password from tbl_doctor where id='" + doctor_id + "'");
            return dt;
        }
        public DataTable get_doctor_details(string doctor_id)
        {
            DataTable dtb = db.table("select doctor_name,gender,experience,about,mobile_number,email_id,password,path,login_type from tbl_doctor where id='" + doctor_id + "'");
            return dtb;
        }
       
        public void save_clinic_service(string clinicid, string ser_id)
        {
            db.execute("insert into tbl_clinic_services (clinic_id,service_id) values('" + clinicid + "','" + ser_id + "')");

        }
        public DataTable load_clinic_services(string clinicid)
        {
            DataTable service1 = db.table("SELECT tbl_clinic_services.clinic_id,tbl_clinic_services.service_id,tbl_services.service FROM tbl_clinic_services INNER JOIN tbl_services ON tbl_clinic_services.service_id = tbl_services.id where tbl_clinic_services.clinic_id='" + clinicid + "'");
            return service1;
        }
        public DataTable clinic_service(string clinicid)
        {
            DataTable dtb = db.table("SELECT tbl_clinic_services.clinic_id,tbl_clinic_services.service_id,tbl_services.service FROM tbl_clinic_services INNER JOIN tbl_services ON tbl_clinic_services.service_id = tbl_services.id where clinic_id='" + clinicid + "'");
            return dtb;
        }
        public void delete_clinic_service(string clinicservice, string clinicid)
        {
            db.execute("delete from tbl_clinic_services where service_id='" + clinicservice + "' and clinic_id='" + clinicid + "'");
        }
        public DataTable cinic_specilization(string clinicid)
        {
            DataTable dtb = db.table("SELECT tbl_clinic_specialization.clinic_id,tbl_clinic_specialization.special_id,tbl_specialization.name FROM tbl_clinic_specialization INNER JOIN tbl_specialization ON tbl_clinic_specialization.special_id = tbl_specialization.id where clinic_id='" + clinicid + "'");
            return dtb;
        }
        public void save_clinic_specilization(string clinicid, string spc_id)
        {
            db.execute("insert into tbl_clinic_specialization (clinic_id,special_id) values('" + clinicid + "','" + spc_id + "')");
        }
        public void delete_clinicspecilization(string clinicspecial, string clinicid)
        {
            db.execute("delete from tbl_clinic_specialization where special_id='" + clinicspecial + "' and clinic_id='" + clinicid + "'");
        }
        public void update_clinicdetails(string _clinicname, string _tagline, string _clinicnumber, string _clinicemail, string _website, string _clinicAbout)
        {
            int clinic1 = db.execute("update tbl_practice_details set name='" + _clinicname + "',tagline='" + _tagline + "',contact_no='" + _clinicnumber + "',email='" + _clinicemail + "',website='" + _website + "',about='" + _clinicAbout + "'");
        }
        public int save_details(string _PName, string _ptag, string _phone, string _email, string _website, string _clinicAbout)
        {
            int i = db.execute("insert into tbl_practice_details (name,tagline,contact_no,email,website,about)values('" + _PName + "','" + _ptag + "','" + _phone + "','" + _email + "','" + _website + "','" + _clinicAbout + "')");
            return i;
        }
        public int update_login(string id,string email)
        {
            int i = db.execute("update tbl_login set username='" + email + "' where id='" + id + "'");
            return i;
        }
    }
}
