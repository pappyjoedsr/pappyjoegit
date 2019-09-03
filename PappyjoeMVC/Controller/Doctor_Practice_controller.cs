using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Doctor_Practice_controller
    {
        Doctor_Practice_model _model = new Doctor_Practice_model();
        public DataTable load_services()
        {
            DataTable dt_maintest = _model.load_services();
            return dt_maintest;
        }
        public DataTable ifexists_services(string text)
        {
            DataTable checkdatacc = _model.ifexists_services(text);
            return checkdatacc;
        }
        public void save_service(string text)
        {
            _model.save_service(text);
        }
        public string max_serviceId()
        {
            string dt = _model.max_serviceId();
            return dt;
        }
        public void update_service(string text, string serviceid)
        {
            _model.update_service(text, serviceid);
        }
        public int delete_service(string serviceid)
        {
            int i = _model.delete_service(serviceid);
            return i;
        }
        //degree
        public void save_degree(string text)
        {
            _model.save_degree(text);
        }
        public string max_degreeid()
        {
            string dt = _model.max_degreeid();
            return dt;
        }
        public void update_degree(string text, string degreeid)
        {
            _model.update_degree(text, degreeid);
        }
        public DataTable ifexists_degree(string text)
        {
            DataTable checkdatacc = _model.ifexists_degree(text);
            return checkdatacc;
        }
        public void delete_degree(string degreeid)
        {
            _model.delete_degree(degreeid);
        }
        public DataTable load_degree()
        {
            DataTable dt_degree = _model.load_degree();
            return dt_degree;
        }
        //council
        public DataTable load_regcouncil()
        {
            DataTable dt_council = _model.load_regcouncil();
            return dt_council;
        }
        public void delete_registration(string councilid)
        {
            _model.delete_registration(councilid);
        }
        public void update_council(string council, string councilid)
        {
            _model.update_council(council, councilid);
        }
        public DataTable ifexists_council(string name)
        {
            DataTable checkdatacc = _model.ifexists_council(name);
            return checkdatacc;
        }
        public void save_council(string name)
        {
            _model.save_council(name);
        }
        public string max_councilid()
        {
            string dt = _model.max_councilid();
            return dt;
        }
        //member
        public DataTable load_member()
        {
            DataTable dt_membership = _model.load_member();
            return dt_membership;
        }
        public DataTable ifexists_member(string name)
        {
            DataTable checkdatacc = _model.ifexists_member(name);
            return checkdatacc;
        }
        public void save_member(string name)
        {
            _model.save_member(name);
        }
        public string max_memberid()
        {
            string dt = _model.max_memberid();
            return dt;
        }
        public void update_member(string name, string membershipid)
        {
            _model.update_member(name, membershipid);
        }
        public void delete_member(string membershipid)
        {
            _model.delete_member(membershipid);
        }
        //college
        public void delete_college(string collegeid)
        {
            _model.delete_college(collegeid);
        }
        public DataTable load_college()
        {
            DataTable dt_college = _model.load_college();
            return dt_college;
        }
        public DataTable ifexists_college(string name)
        {
            DataTable checkdatacc = _model.ifexists_college(name);
            return checkdatacc;
        }
        public void save_college(string name)
        {
            _model.save_college(name);
        }
        public string max_collegeid()
        {
            string dt = _model.max_collegeid();
            return dt;
        }
        public void update_college(string name, string collegeid)
        {
            _model.update_college(name, collegeid);
        }
        //specilization
        public DataTable ifexists_specilization(string name)
        {
            DataTable checkdatacc = this._model.ifexists_specilization(name);
            return checkdatacc;
        }
        public void save_specilization(string name)
        {
            this._model.save_specilization(name);
        }
        public string max_specilizationid()
        {
            string dt = this._model.max_specilizationid();
            return dt;
        }
        public void update_sspecilization(string name, string Specializationid)
        {
            this._model.update_sspecilization(name, Specializationid);
        }
        public void delete_specilization(string Specializationid)
        {
            _model.delete_specilization(Specializationid);
        }
        public DataTable load_specilization()
        {
            DataTable dt_maintest = _model.load_specilization();
            return dt_maintest;
        }
    }
}
