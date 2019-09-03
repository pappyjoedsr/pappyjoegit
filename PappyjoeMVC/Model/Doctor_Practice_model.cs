using System.Data;
namespace PappyjoeMVC.Model
{
    public class Doctor_Practice_model
    {
        Connection db = new Connection();
        //services
        public DataTable load_services()
        {
            DataTable dt_maintest = db.table("select id,service from tbl_services order by id");
            return dt_maintest;
        }
        public DataTable ifexists_services(string text)
        {
            DataTable checkdatacc = db.table("Select * from tbl_services where service ='" + text + "'");
            return checkdatacc;
        }
        public void save_service(string text)
        {
            int i = db.execute("insert into tbl_services (service) values('" + text + "')");
        }
        public string max_serviceId()
        {
            string dt = db.scalar("select MAX(id) as id from tbl_services");
            return dt;
        }
        public void update_service(string text, string serviceid)
        {
            int update = db.execute("update tbl_services set service='" + text + "' where id='" + serviceid + "'");
        }
        public int delete_service(string serviceid)
        {
            int a = db.execute("delete from tbl_services where id='" + serviceid + "'");
            return a;
        }
        //specilization
        public DataTable ifexists_specilization(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_specialization where name ='" + name + "'");
            return checkdatacc;
        }
        public void save_specilization(string name)
        {
            int i = db.execute("insert into tbl_specialization (name) values('" + name + "')");
        }
        public string max_specilizationid()
        {
            string dt = db.scalar("select MAX(id) as id from tbl_specialization");
            return dt;
        }
        public void update_sspecilization(string name, string Specializationid)
        {
            int update = db.execute("update tbl_specialization set name='" + name + "' where id='" + Specializationid + "'");
        }
        public void delete_specilization(string Specializationid)
        {
            db.execute("delete from tbl_specialization where id='" + Specializationid + "'");
        }
        public DataTable load_specilization()
        {
            DataTable dt_maintest = db.table("select id,name from tbl_specialization order by id");
            return dt_maintest;
        }
        //college
        public void delete_college(string collegeid)
        {
            db.execute("delete from tbl_college where id='" + collegeid + "'");
        }
        public DataTable load_college()
        {
            DataTable dt_college = db.table("select id,college from tbl_college order by id");
            return dt_college;
        }
        public DataTable ifexists_college(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_college where college ='" + name + "'");
            return checkdatacc;
        }
        public void save_college(string name)
        {
            int i = db.execute("insert into tbl_college (college) values('" + name + "')");
        }
        public string max_collegeid()
        {
            string dt = db.scalar("select MAX(id) as id from tbl_college");
            return dt;
        }
        public void update_college(string name, string collegeid)
        {
            int update = db.execute("update tbl_college set college='" + name + "' where id='" + collegeid + "'");
        }
        //member
        public DataTable load_member()
        {
            DataTable dt_membership = db.table("select id,name from tbl_memberships order by id");
            return dt_membership;
        }
        public DataTable ifexists_member(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_memberships where name ='" + name + "'");
            return checkdatacc;
        }
        public void save_member(string name)
        {
            int i = db.execute("insert into tbl_memberships (name) values('" + name + "')");
        }
        public string max_memberid()
        {
            string dt = db.scalar("select MAX(id) as id from tbl_memberships");
            return dt;
        }
        public void update_member(string name, string membershipid)
        {
            int update = db.execute("update tbl_memberships set name='" + name + "' where id='" + membershipid + "'");
        }
        public void delete_member(string membershipid)
        {
            db.execute("delete from tbl_memberships where id='" + membershipid + "'");
        }
        //council
        public DataTable load_regcouncil()
        {
            DataTable dt_council = db.table("select id,name from tbl_reg_council order by id");
            return dt_council;
        }
        public void delete_registration(string councilid)
        {
            db.execute("delete from tbl_reg_council where id='" + councilid + "'");
        }
        public void update_council(string council, string councilid)
        {
            int update = db.execute("update tbl_reg_council set name='" + council + "' where id='" + councilid + "'");
        }
        public DataTable ifexists_council(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_reg_council where name ='" + name + "'");
            return checkdatacc;
        }
        public void save_council(string name)
        {
            int i = db.execute("insert into tbl_reg_council (name) values('" + name + "')");
        }
        public string max_councilid()
        {
            string dt = db.scalar("select MAX(id) as id from tbl_reg_council");
            return dt;
        }
        //degree
        public void save_degree(string text)
        {
            int i = db.execute("insert into tbl_degree (degree) values('" + text + "')");
        }
        public string max_degreeid()
        {
            string dt = db.scalar("select MAX(id) as id from tbl_degree");
            return dt;
        }
        public void update_degree(string text, string degreeid)
        {
            int update = db.execute("update tbl_degree set degree='" + text + "' where id='" + degreeid + "'");
        }
        public DataTable ifexists_degree(string text)
        {
            DataTable checkdatacc = db.table("Select * from tbl_degree where degree ='" + text + "'");
            return checkdatacc;
        }
        public void delete_degree(string degreeid)
        {
            db.execute("delete from tbl_degree where id='" + degreeid + "'");
        }
        public DataTable load_degree()
        {
            DataTable dt_degree = db.table("select id,degree from tbl_degree order by id");
            return dt_degree;
        }
    }
}
