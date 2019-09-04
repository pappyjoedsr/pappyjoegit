using System.Data;
namespace PappyjoeMVC.Model
{
    public class Add_Treatmentplan_model
    {
        Connection db = new Connection();
        private string _addProcedurename = "";
        public string AddProcedureName
        {
            get { return _addProcedurename; }
            set { _addProcedurename = value; }
        }
        private string _procedurecost = "";
        public string ProcedureCost
        {
            get { return _procedurecost; }
            set { _procedurecost = value; }
        }
        private string _date = "";
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _doctor = "";
        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }
        private string _patientname = "";
        public string PatientName
        {
            get { return _patientname; }
            set { _patientname = value; }
        }
        private string _totalcost = "";
        public string TotalCost
        {
            get { return _totalcost; }
            set { _totalcost = value; }
        }
        private string _totaldiscount = "";
        public string TotalDiscount
        {
            get { return _totaldiscount; }
            set { _totaldiscount = value; }
        }
        private string _grandtotal = "";
        public string GrandTotal
        {
            get { return _grandtotal; }
            set { _grandtotal = value; }
        }
        public DataTable get_ProcedureTreatment(string id)
        {
            DataTable dtb = db.table("select name,cost from tbl_addproceduresettings where id ='" + id + "'");
            return dtb;
        }
        public DataTable check_procedurename()
        {
            DataTable checkdatacc = db.table("Select * from tbl_addproceduresettings where name ='" + _addProcedurename + "'");
            return checkdatacc;
        }
        public void save_Procedure()
        {
            db.execute("insert into tbl_addproceduresettings(name,cost) values('" + _addProcedurename + "','" + _procedurecost + "')");
        }
        public string Procedure_maxid()
        {
            string p = db.scalar("select MAX(id) from tbl_addproceduresettings");
            return p;
        }
        public DataTable Get_all_procedures()
        {
            DataTable treatment = db.table("select id,name,cost from tbl_addproceduresettings ORDER BY id DESC");
            return treatment;
        }
        public void Save_treatment(string dr_id, string patient_id)
        {
            int i = db.execute("insert into tbl_treatment_plan_main (date,dr_id,dr_name,pt_id,pt_name,total_cost,total_discount,grand_total) values('" + _date + "','" + dr_id + "','" + _doctor + "','" + patient_id + "','" + _patientname + "','" + _totalcost + "','" + _totaldiscount + "','" + _grandtotal + "')");
        }
        public DataTable get_treatmentmaxid()
        {
            DataTable dt = db.table("select MAX(id) from tbl_treatment_plan_main");
            return dt;
        }
        public void Save_treatmentgrid(int j, string procedure_id, string pt_id, string procedure_name, string quantity, string cost, string discount_type, string discount, string total, string discount_inrs, string note, string tooth)
        {
            int t_p = db.execute("insert into tbl_treatment_plan (plan_main_id,procedure_id,pt_id,procedure_name,quantity,cost,discount_type,discount,total,discount_inrs,note,status,tooth) values('" + j + "','" + procedure_id + "','" + pt_id + "','" + procedure_name + "','" + quantity + "','" + cost + "','" + discount_type + "','" + discount + "','" + total + "','" + discount_inrs + "','" + note + "','1','" + tooth + "')");
        }
    }
}