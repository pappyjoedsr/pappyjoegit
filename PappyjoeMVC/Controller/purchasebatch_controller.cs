using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class purchasebatch_controller
    {
        //purchasebatch_interface intr;
        Connection db = new Connection();
        //public purchasebatch_controller(purchasebatch_interface inttr)
        //{
        //    intr = inttr;
        //    intr.setcontroller(this);
        //}
        public DataTable check_batch(string item_code)
        {
            DataTable dt = db.table("select ISBatch,item_name from tbl_ITEMS where id='" + item_code + "'");
            return dt;
        }

    }
}
