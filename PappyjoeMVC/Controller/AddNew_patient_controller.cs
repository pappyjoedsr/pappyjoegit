using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class AddNew_patient_controller
    {
        AddNew_patient_interface intr;
        Connection db = new Connection();
        common_model mdl = new common_model();
        addnew_patient_model _model = new addnew_patient_model();
        public AddNew_patient_controller(AddNew_patient_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable Get_pnonenumber(string number)
        {
            DataTable patSearchnumber = db.table("select primary_mobile_number from tbl_patient where primary_mobile_number ='" + number+ "'  and Profile_Status !='Cancelled'");
            return patSearchnumber;
        }
        public DataTable Get_patient_details(string name)
        {
            DataTable dtb = _model.Get_patient_details(name);
            return dtb;
        }
        public DataTable get_patientid(string id)
        {
            DataTable dtb = _model.get_patientid(id);
            return dtb;
        }
        public int Save()
        {
            get_modelData();
            int i = _model.Save();
            return i;
        }
        public void get_modelData()
        {
            _model.PatientName = intr.PatientName;
            _model.PatientId = intr.Patient_Id;
            _model.Aadhaar = intr.Aadhaar;
            _model.Blood = intr.Blood;
            _model.Accompainedby = intr.Accompainedby;
            _model.Age = intr.Age;
            _model.DOB = intr.DOB;
            _model.Doctor = intr.Doctor;
            _model.FileNo = intr.FileNo;
            _model.Landline = intr.Landline;
            _model.Occupation = intr.Occupation;
            _model.ReferredBy = intr.ReferredBy;
            _model.PrimaryMob = intr.PrimaryMob;
            _model.SecondaryMob = intr.SecondaryMob;
            _model.Street = intr.Street;
            _model.DateofAdmit = intr.DateofAdmit;
            _model.Gender = intr.Gender;
            _model.Pincode = intr.Pincode;
            _model.City = intr.City;
            _model.Email = intr.Email;
            _model.Locality = intr.Locality;
        }
        public string get_maxId()
        {
            string dtb = _model.get_maxId();
            return dtb;
        }
        public void save_medical(string pat_id,string medical)
        {
            _model.save_medical(pat_id, medical);
        }
        public void save_group(string pat_id, string medical)
        {
            _model.save_group(pat_id, medical);
        }
        public DataTable automaticid()
        {
            DataTable dtb = _model.automaticid();
            return dtb;
        }
        public void update_autogenerateid(int n)
        {
            _model.update_autogenerateid(n);
        }
        public DataTable data_from_automaticid()
        {
            DataTable dtb = _model.data_from_automaticid();
            return dtb;
        }
        //public DataTable get_doctorname(string id)
        //{
        //    DataTable dtb = mdl.Get_DoctorName(id);
        //    return dtb;
        //}
        public DataTable get_all_doctorname()
        {
            DataTable dtb = mdl.get_all_doctorname();
            return dtb;
        }
        public string Load_CompanyName()
        {
            string dtb = mdl.Load_CompanyName();
            return dtb;
        }
        public DataTable load_medical()
        {
            DataTable dtb = db.table("SELECT name FROM tbl_medhistory");
            return dtb;
        }
        public DataTable load_group()
        {
            DataTable dtb = db.table("select name from tbl_group");
            return dtb;
        }
        public void check_medical(string name)
        {
            DataTable dtb = _model.check_medical(name);
            intr.insertMED(dtb);
        }
        public void insert_medical()
        {
            _model.Medical = intr.Medical;
            _model.insert_medical();
        }
        public void check_group(string name)
        {
            DataTable checkdatacc = db.table("Select * from tbl_group where name ='" + name + "'");
            intr.insertgroup(checkdatacc);
        }
        public void insert_group()
        {
            _model.Group = intr.Group;
            _model.insert_group();
        }
        public string getserver()
        {
            string ret = db.server();
            return ret;
        }
    }
}
