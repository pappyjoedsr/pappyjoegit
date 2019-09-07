using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Monthly_Treatment_Count_controller
    {
        Treatment_Report_model model = new Treatment_Report_model();
        public DataTable doctor_rs()
        {
            DataTable d = model.doctor_rs();
            return d;
        }
        public DataTable gridTable(string date1, string date2)
        {
            DataTable d = model.gridTable(date1, date2);
            return d;
        }
        public DataTable MonthtreatmentcountLoad(string d9, string k9)
        {
            DataTable d = model.MonthtreatmentcountLoad(d9, k9);
            return d;
        }
        public DataTable GridDLYTTMNTtb(string date1, string date2)
        {
            DataTable d = model.GridDLYTTMNTtb(date1, date2);
            return d;
        }
        public DataTable Monthtreatmentcount(string d9, string k9, string dr_id)
        {
            DataTable d = model.Monthtreatmentcount(d9, k9, dr_id);
            return d;
        }
        public DataTable practceDetls()
        {
            DataTable d = model.practceDetls();
            return d;
        }
        public DataTable DailyTablE(string d1, string d2, string dr)
        {
            DataTable d = model.DailyTablE(d1, d2, dr);
            return d;
        }
        public DataTable DocId_frm_DocTbl(string drctid)
        {
            DataTable doc = model.DocId_frm_DocTbl(drctid);
            return doc;
        }
        public DataTable ProPat(string date1, string date2)
        {
            DataTable d = model.ProPat(date1, date2);
            return d;
        }
    }
}
