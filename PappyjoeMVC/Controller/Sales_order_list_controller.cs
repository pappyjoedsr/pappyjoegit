using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Sales_order_list_controller
    {
        sales_order_model _model = new sales_order_model();
        public DataTable SalesOrderdetls(string date_From, string date_To)
        {
            DataTable dt = _model.SalesOrderdetls(date_From,date_To);
            return dt;
        }
        public DataTable getSales(string date)
        {
            DataTable dt = _model.getSales(date);
            return dt;
        }
        public int update_salesOrder(int invnum)
        {
            int i = _model.update_salesOrder(invnum);
            return i;
        }
        public DataTable get_dataRefresh(string date)
        {
            DataTable dt = _model.get_dataRefresh(date);
            return dt;
        }
        public DataTable showdata(string from, string to)
        {
            DataTable dt = _model.showdata(from,to);
            return dt;
        }
    }
}
