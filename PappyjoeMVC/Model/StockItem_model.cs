using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class StockItem_model
    {
        Connection db = new Connection();
        public DataTable LoadSupplier()
        {
            DataTable gp_rs = db.table("select Supplier_Code,Supplier_Name from tbl_Supplier order by Supplier_Code");
            return gp_rs;
        }
        public DataTable load_stock()
        {
            DataTable dt_stock = db.table("select item_code as id ,(select item_code from tbl_items where id=B.Item_Code) as item_code,(select sum( qty) from tbl_batchnumber where Item_Code=B.Item_Code) qty from tbl_batchnumber B group by item_code order by B.item_code");
            return dt_stock;
        }
        public DataTable minimumStock(string item_code)
        {
            DataTable dtb_Min = db.table(" select MinimumStock from tbl_ITEMS where id='" + item_code + "'");
            return dtb_Min;
        }
        public DataTable itemdetails(string item_code)
        {
            DataTable dtunit = db.table(" select item_name,OneUnitOnly,UnitMF,Unit1,Unit2,purch_rate,purch_rate2 from tbl_ITEMS where id='" + item_code + "'");
            return dtunit;
        }
        public DataTable search_minimum()
        {
            DataTable sqlstr = db.table("select item_code as id ,(select item_code from tbl_items where id=B.Item_Code) as item_code,(select sum( qty) from tbl_batchnumber where Item_Code=B.Item_Code) qty from tbl_batchnumber B group by item_code order by B.item_code");
            return sqlstr;
        }
        public DataTable search_minium_wit_itemname(string search)
        {
            DataTable sqlstr = db.table("select B.item_code as id, tbl_ITEMS.item_code, (select sum(qty) from tbl_batchnumber where Item_Code= B.Item_Code) qty,tbl_ITEMS.item_name from tbl_batchnumber B left join tbl_ITEMS on tbl_ITEMS.id=b.item_code where tbl_ITEMS.item_code like '" + search + "%' OR tbl_ITEMS.item_name like'" + search + "%' group by B.item_code order by B.item_code");
            return sqlstr;
        }
        public DataTable get_supcode(string sup)
        {
            DataTable dt_sup = db.table(" select Supplier_Code from tbl_Supplier where Supplier_Name='" + sup + "'");
            return dt_sup;
        }
        public DataTable Load_supplier_items(string Sup_Code)
        {
            DataTable dtb = db.table("select Item_Code as id, (select item_code from tbl_items where id=B.Item_Code) as item_code,sum(qty) qty  from tbl_BatchNumber B where Sup_Code='" + Sup_Code + "' group by B.Item_Code ");
            return dtb;
        }
        public DataTable get_company_details()
        {
           DataTable dtp = db.table("select name,contact_no,street_address,email,website from tbl_practice_details");
            return dtp;
        }
    }
}
