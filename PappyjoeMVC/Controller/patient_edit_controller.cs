using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Patient_Edit_controller
    {
        patient_edit_interface intr;
        Patient_Edit_model _model = new Patient_Edit_model();
        Connection db = new Connection();
        public Patient_Edit_controller(patient_edit_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public void get_medicalId(string pt_id)
        {
            DataTable dtb = _model.get_medicalId(pt_id);
            intr.Fill_modeical(dtb);
        }
        public DataTable Get_medicalname()
        {
            DataTable dtb = _model.Get_medicalname();
            return dtb;
        }
        public DataTable patient_medical(string idd, string medid)
        {
            DataTable dtb = _model.patient_medical(idd, medid);
            return dtb;
        }
        public void get_groupid(string idd)
        {
            DataTable dtb = _model.get_groupid(idd);
            intr.Fill_Group(dtb);
        }
        public DataTable groupname()
        {
            DataTable dtb = _model.groupname();
            return dtb;
        }
        public DataTable patient_group(string idd, string grpid)
        {
            DataTable dtb = _model.patient_group(idd, grpid);
            return dtb;
        }

        public int update(string pt_id)
        {
            _model.patname = intr.Ptname;
            _model.patId = intr.patId;
            _model.aadhar = intr.aadhar;
            _model.Gender = intr.Gender;
            _model.age = intr.age;
            _model.Dob = intr.Dob;
            _model.blood = intr.blood;
            _model.family = intr.family;
            _model.Pmob = intr.Pmob;
            _model.Smob = intr.Smob;
            _model.Landline = intr.Landline;
            _model.email = intr.email;
            _model.street = intr.street;
            _model.locality = intr.locality;
            _model.city = intr.city;
            _model.pin = intr.pin;
            //_model.groupid = intr.groupid;
            _model.refferedby = intr.refferedby;
            _model.opticket = intr.opticket;
            _model.Visited = intr.Visited;
            _model.occupation = intr.occupation;
            _model.doctername = intr.doctername;
            int i = _model.update(pt_id);
            return i;
        }
        public int delete_patient(string pt_id)
        {
            int i = _model.delete_patient(pt_id);
            return i;
        }
        public void save(string medical)
        {
            _model.save(medical);
        }
        public void save_group(string group)
        {
            _model.save_group(group);
        }
        public void delete_pt_medhistory(string patient_id)
        {
            _model.delete_pt_medhistory(patient_id);
        }
        public string getserver()//connection
        {
            string ret = db.server();
            return ret;
        }
        public void insert_pt_medhistory(string patient_id, string medical)
        {
            _model.insert_pt_medhistory(patient_id, medical);
        }
        public void delete_pt_group(string patient_id)
        {
            _model.delete_pt_group(patient_id);
        }
        public void insert_pt_group(string patient_id, string group)
        {
            _model.insert_pt_group(patient_id, group);
        }
    }
}
