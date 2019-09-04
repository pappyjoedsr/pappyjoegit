using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Treatment_for_each_doctor_controller
    {
        Treatment_report_model model = new Treatment_report_model();
        public Treatment_for_each_doctor_controller(Treatment_for_each_doctor_interface intr)
        {
            intr.setcontroller(this);
        }
        public DataTable doctor_rs()
        {
            DataTable d = model.doctor_rs();
            return d;
        }
        public DataTable ProPat(string date1, string date2)
        {
            DataTable d = model.ProPat(date1,date2);
            return d;
        }
        public DataTable DoctoreachtreatmentLoad(string d11, string d12)
        {
            DataTable d = model.DoctoreachtreatmentLoad(d11,d12);
            return d;
        }
        public DataTable grdDailytreatmntTble(int select_dr_id, string date1, string date2)
        {
            DataTable d = model.grdDailytreatmntTble(select_dr_id,date1,date2);
            return d;
        }
        public DataTable Dr_ID_logn(string drid)
        {
            DataTable d = model.Dr_ID_logn(drid);
            return d;
        }
        public DataTable Doctoreachtreatment(string d11, string d12, string dr_id)
        {
            DataTable d = model.Doctoreachtreatment(d11,d12,dr_id);
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
            DataTable d = model.GridDLYTTMNTtb(date1,date2);
            return d;
        }
    }
}
