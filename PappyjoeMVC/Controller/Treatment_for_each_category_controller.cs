using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Treatment_For_Each_Category_controller
    {
        Treatment_Report_model model = new Treatment_Report_model();
        public DataTable addproset()
        {
            DataTable d = model.addproset();
            return d;
        }
        public DataTable TreatmenteachcatLoad(string d7, string k7)
        {
            DataTable d = model.TreatmenteachcatLoad(d7, k7);
            return d;
        }
        public DataTable prosetDocId(string drid)
        {
            DataTable d = model.prosetDocId(drid);
            return d;
        }
        public DataTable drgDailytreatmentTB(int select_dr_id, string date1, string date2)
        {
            DataTable d = model.drgDailytreatmentTB(select_dr_id, date1, date2);
            return d;
        }
        public DataTable Treatmenteachcat(string d7, string k7, string dr_id)
        {
            DataTable d = model.Treatmenteachcat(d7, k7, dr_id);
            return d;
        }
        public DataTable GridDLYTTMNTtb(string date1, string date2)
        {
            DataTable d = model.GridDLYTTMNTtb(date1, date2);
            return d;
        }
        public DataTable practceDetls()
        {
            DataTable d = model.practceDetls();
            return d;
        }
        public DataTable docId(string drctid)
        {
            DataTable d = model.docId(drctid);
            return d;
        }
        public DataTable ProPat(string date1, string date2)
        {
            DataTable d = model.ProPat(date1, date2);
            return d;
        }
        public DataTable Propat2(int Selected_drid, string date1, string date2)
        {
            DataTable d = model.Propat2(Selected_drid, date1, date2);
            return d;
        }
    }
}
