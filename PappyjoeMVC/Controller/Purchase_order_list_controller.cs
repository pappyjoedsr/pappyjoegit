using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Purchase_order_list_controller
    {
        purchase_order_model _model = new purchase_order_model();
        public DataTable PurchaseDataBydate(string dateFrom, string dateTo)
        {
            DataTable dt = _model.PurchaseDataBydate(dateFrom, dateTo);
            return dt;
        }
        public DataTable Purchase(string dtpFrom, string dtpTo)
        {
            DataTable dt = _model.Purchase(dtpFrom, dtpTo);
            return dt;
        }
        public int Get_PrchseData(int purodno)
        {
            int i = _model.Get_PrchseData(purodno);
            return i;
        }
    }
}
