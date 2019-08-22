using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Group_wise_report_controller
    {
        Group_wise_report_interface intr;
        Patients_Report_model _model = new Patients_Report_model();
        common_model mdl = new common_model();
        public Group_wise_report_controller(Group_wise_report_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public DataTable dt_grp()
        {
            DataTable dt = _model.dt_grp();
            return dt;
        }
        public void dtb_group(string cmb, string d1, string d2)
        {
            DataTable d = _model.dtb_group(cmb,d1,d2);
            intr.Patients(d);
        }
        public void dtb_procedure(string cmb, string d1, string d2)
        {
            DataTable d = _model.dtb_procedure(cmb,d1,d2);
            intr.Procedure(d);
        }
        public void dtb_invoice(string d1, string d2, string cmb)
        {
            DataTable d = _model.dtb_invoice(d1,d2,cmb);
            intr.Invoice(d);
        }
        public void dtb_receipt(string d1, string d2, string cmb)
        {
            DataTable d = _model.dtb_receipt(d1,d2,cmb);
            intr.Receipt(d);
        }
        public DataTable dt_inv(string dtp1, string dtp2)
        {
            DataTable d = _model.dt_inv(dtp1,dtp2);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable d = mdl.Get_practiceDlNumber();
            return d;
        }
    }
}
