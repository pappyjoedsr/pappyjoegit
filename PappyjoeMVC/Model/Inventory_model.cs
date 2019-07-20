using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Inventory_model
    {
        Connection db = new Connection();
        public DataTable Get_Stock(string id)
        {
          DataTable dt3 = db.table("Select stock from tbl_inventory_item where id='" + id + "'");
          return dt3;
        }                            
        public void update_addStock_qty(decimal current_Stock, string completedid)
        {
            db.execute("update tbl_add_stock set quantity='" + current_Stock + "'where id='" + completedid + "'");
        }
        public void update_inventoryStock(decimal total_Stock,string Plan_id)
        {
            db.execute("update tbl_inventory_item set stock='" + total_Stock + "'where id='" + Plan_id + "'");
        }
    }
}
