using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class Sales_Return_List_Controller
    {
        Sales_Return_Model model = new Sales_Return_Model();
        public DataTable Load_grid(string date)
        {
            DataTable dtb = model.Load_grid(date);
            return dtb;
        }
        public DataTable Load_return_detail(string date)
        {
            DataTable dtb = model.Load_return_detail(date);
            return dtb;
        }
        public DataTable load_details_wit_date(string from, string to)
        {
            DataTable dtb = model.load_details_wit_date(from,to);
            return dtb;
        }
    }
}
