using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Purchase_return_list_controller
    {
        purchase_return_model _model = new purchase_return_model();
        public DataTable get_purchaseretnList_data(string DTP_From, string DTP_To)
        {
            DataTable dt = _model.get_purchaseretnList_data(DTP_From,DTP_To);
            return dt;
        }
    }
}
