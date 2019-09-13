using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Expiry_Report_controller
    {
        Connection db = new Connection();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable datewiseexpiry(string dateFrom,string dateTo)
        {
            DataTable dt = db.table("select b.Item_Code,i.item_name,b.PurchNumber,b.PurchDate,b.BatchNumber,b.Qty,b.ExpDate,(select s.Supplier_Name from tbl_Supplier S where S.Supplier_Code=b.Sup_Code) Supplier_Name  from tbl_batchNumber b left join tbl_items i on i.item_code=b.Item_Code  where b.IsExpDate='Yes' and b.ExpDate between '" + dateFrom + "' and '" + dateTo + "'");
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
