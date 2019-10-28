using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class PurchaseList_controller
    {
        //PurchaseList_interface intr;
        Purchase_model _model = new Purchase_model();
        //public PurchaseList_controller(PurchaseList_interface intr)
        //{
        //    intr.setcontroller(this);
        //}
        public DataTable getPurchase_btwndates(string fromdate, string todate)
        {
            DataTable dt = _model.getPurchase_btwndates(fromdate,todate);
            return dt;
        }
        public DataTable data_from_Pur_Master(object dgv_Purchase)
        {
            DataTable d = _model.data_from_Pur_Master(dgv_Purchase);
            return d;
        }
        public DataTable data_from_purchase(object dgv_Purchase)
        {
            DataTable d = _model.data_from_purchase(dgv_Purchase);
            return d;
        }
        public DataTable dt(string fromdate, string todate)
        {
            DataTable d = _model.dt(fromdate,todate);
            return d;
        }
       
    }
}
