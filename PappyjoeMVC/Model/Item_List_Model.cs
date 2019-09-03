using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Item_List_Model
    {
        Connection db = new Connection();
        public DataTable Fill_manufactureCombo()
        {
            DataTable gp_rs = db.table("SELECT id,manufacturer FROM tbl_manufacturer WHERE id IN (SELECT MAX(id) FROM tbl_manufacturer GROUP BY id)");
            return gp_rs;
        }

        public DataTable Fill_Grid()
        {
            DataTable dtItems = db.table("Select A.id, A.item_code,A.item_name,(select sum(Qty) from tbl_BatchNumber where item_code= A.item_code) 'Stock' from tbl_ITEMS A order by id");
            return dtItems;
        }
        public DataTable Get_manufacturename(string selectedValue)
        {
            DataTable dt_manu = db.table("SELECT id,manufacturer FROM tbl_manufacturer where manufacturer='" + selectedValue + "' ");
            return dt_manu;
        }
        public DataTable get_items_with_manufacture(int manufacture)
        {
            DataTable dtb = db.table("Select A.id,A.item_code,A.item_name,(select sum(Qty) 'Stock' from tbl_BatchNumber where item_code= A.item_code) 'Stock' from tbl_ITEMS A  where manufacturer='" + Convert.ToInt32(manufacture) + "'");
            return dtb;
        }
        public DataTable Search(string itemname)
        {
            DataTable dtb_items = db.table("Select A.id, A.item_code,A.item_name,(select sum(Qty) from tbl_BatchNumber where item_code= A.item_code) Stock from tbl_ITEMS A  where A.item_code like '" + itemname + "%' or A.item_name like '" + itemname + "%' order by A.id");
            return dtb_items;
        }
        public DataTable Search_wit_manufacture(string name, string manufacture)
        {
            DataTable dtb_items = db.table("Select A.id,A.item_code,A.item_name,(select sum(Qty) from tbl_BatchNumber where item_code= A.item_code) Stock from tbl_ITEMS A  where (A.item_code like '" + name + "%' or A.item_name like '" + name + "%') and A.manufacturer='" + manufacture + "'  order by A.id");
            return dtb_items;
        }
        public DataTable Get_itemDetails(string itemcode)
        {
            DataTable dtb = db.table("select * from tbl_ITEMS where id='" + itemcode + "' ");
            return dtb;
        }
        public DataTable get_stock(string itemcode)
        {
            DataTable dtb = db.table("select sum(qty) as Stock from tbl_BatchNumber where Item_Code='" + itemcode + "'");
            return dtb;
        }
        public int delete(string itemcode)
        {
            int i = db.execute("delete from tbl_ITEMS where id='" + itemcode + "' ");
            return i;
        }
    }
}
