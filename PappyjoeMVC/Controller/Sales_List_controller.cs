using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Sales_List_controller
    {
        sales_model _model = new sales_model();
        //public Sales_List_controller(Sales_List_interface intr)
        //{
        //    intr.setcontroller(this);tfyhtgdthyh
        //}
        public DataTable get_salesDetails(string dateTo, string dateFrom)
        {
            DataTable dt = _model.get_salesDetails(dateTo, dateFrom);
            return dt;
        }
        public DataTable invDetailsbyDate(string date)
        {
            DataTable dt = _model.invDetailsbyDate(date);
            return dt;
        }
        public DataTable invDetailsbyDateBtwn(string from, string to)
        {
            DataTable dt = _model.invDetailsbyDateBtwn(from, to);
            return dt;
        }
        public DataTable InvDetailsBtwnDates(string from, string to)
        {
            DataTable dt = _model.InvDetailsBtwnDates(from, to);
            return dt;
        }
        public DataTable data_from_sales(string dt)
        {
            DataTable dtb = _model.data_from_sales(dt);
            return dtb;
        }
        public DataTable data_from_sales_igst(string dt)
        {
            DataTable dtb = _model.data_from_sales_igst(dt);
            return dtb;
        }

    }
}
