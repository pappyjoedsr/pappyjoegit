using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Treatment_For_Each_Doctor_controller
    {
        Treatment_Report_model model = new Treatment_Report_model();
        public DataTable doctor_rs()
        {
            DataTable d = model.doctor_rs();
            return d;
        }
        public DataTable ProPat(string date1, string date2)
        {
            DataTable d = model.ProPat(date1, date2);
            return d;
        }
        public DataTable DoctoreachtreatmentLoad(string d11, string d12)
        {
            DataTable d = model.DoctoreachtreatmentLoad(d11, d12);
            return d;
        }
        public DataTable grdDailytreatmntTble(int select_dr_id, string date1, string date2)
        {
            DataTable d = model.grdDailytreatmntTble(select_dr_id, date1, date2);
            return d;
        }
        public DataTable Dr_ID_logn(string drid)
        {
            DataTable d = model.Dr_ID_logn(drid);
            return d;
        }
        public DataTable Doctoreachtreatment(string d11, string d12, string dr_id)
        {
            DataTable d = model.Doctoreachtreatment(d11, d12, dr_id);
            return d;
        }
        public DataTable practceDetls()
        {
            DataTable d = model.practceDetls();
            return d;
        }
        public DataTable DocId_frm_DocTbl(string drctid)
        {
            DataTable f = model.DocId_frm_DocTbl(drctid);
            return f;
        }
        public DataTable GridDLYTTMNTtb(string date1, string date2)
        {
            DataTable d = model.GridDLYTTMNTtb(date1, date2);
            return d;
        }
    }
}
