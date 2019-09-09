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
        //sales batch load
        public DataTable Load_batch(string ItemCode)
        {
            DataTable dtb = db.table("select BatchNumber,Qty,CONVERT(ExpDate , date) 'ExpDate' ,CONVERT(PrdDate ,date) 'PrdDate',PurchNumber,CONVERT(PurchDate,date)'PurchDate' ,Sup_Code from tbl_BatchNumber where Item_Code='" + ItemCode + "'and Qty>0 and ExpDate>=(SELECT CONVERT(CURDATE(), date))");
            return dtb;
        }
        public string get_itemid(string Item_Code)
        {
            string str = db.scalar("select id from tbl_ITEMS where item_code='" + Item_Code + "'");
            return str;
        }
        public string check_batch(string item_code)
        {
            string dt = db.scalar("select ISBatch from tbl_ITEMS where id='" + item_code + "'");
            return dt;
        }
        public DataTable Get_unites(string Item_Id)
        {
            DataTable dtitems = db.table("select Unit1,Unit2,UnitMF from tbl_ITEMS where id='" + Item_Id + "'");
            return dtitems;
        }
        public DataTable Get_itemdetails_from_purchaseit(string Itemid)
        {
            DataTable dtb_Avg = db.table("select Qty,Rate,Unit,UNIT2,UnitMF from tbl_PURCHIT where Item_Code='" + Itemid + "'");
            return dtb_Avg;
        }
        public DataTable get_companydetails()
        {
            System.Data.DataTable dtp = db.table("select name,contact_no,street_address,email,website  from tbl_practice_details");
            return dtp;
        }
        public DataTable get_item_unitmf(string Itemid)
        {
            DataTable dt_unit1 = db.table("select Unit2,Unit1,UnitMF,OneUnitOnly from tbl_ITEMS where id='" + Itemid + "'");
            return dt_unit1;
        }
        //sales item list
        public DataTable Load_items_wit_itemcode(string Item_Code)
        {
            DataTable dt = db.table("select t.id,t.item_code,item_name,c.Name,(select SUM(qty) from tbl_BatchNumber where item_code=t.id) as 'Current_Stock',(CONVERT( Sales_Rate_Max,  CHAR(50))+'/'+Unit1) as 'Cost (Unit1)', (CONVERT(Sales_Rate_Max2, CHAR(50))+'/'+t.Unit2) as 'Cost (Unit2)' from tbl_ITEMS t inner join tbl_Category C on C.id=t.Cat_Number  left join tbl_BatchNumber B on b.Item_Code=t.id where B.Qty <> -1 and B.Qty <> 0 and t.id='" + Item_Code + "' group by t.item_code,t.item_name,c.Name,Sales_Rate_Max,Unit1,Sales_Rate_Max2,t.Unit2");
            return dt;
        }
        public DataTable Load_items()
        {
            DataTable dt = db.table("select  t.id, t.item_code,item_name,c.Name,(select SUM(qty) from tbl_BatchNumber where item_code=t.id) as 'Current_Stock',(CONVERT( Sales_Rate_Max, CHAR(50))+'/'+Unit1) as 'Cost (Unit1)', (CONVERT(Sales_Rate_Max2 ,CHAR(50))+'/'+t.Unit2) as 'Cost (Unit2)' from tbl_ITEMS t inner join tbl_Category C on C.id=t.Cat_Number  left join tbl_BatchNumber B on b.Item_Code=t.id where B.Qty <> -1 and B.Qty <> 0  group by t.item_code,t.item_name,c.Name,Sales_Rate_Max,Unit1,Sales_Rate_Max2,t.Unit2 ");
            return dt;
        }
        public DataTable search_wit_itemcode(string name)
        {
            DataTable dtb = db.table("select t.id,t.item_code,item_name,c.Name,(select SUM(qty) from tbl_BatchNumber where item_code=t.id) as 'Current_Stock',(CONVERT( Sales_Rate_Max, CHAR(50))+'/'+Unit1) as 'Cost (Unit1)', (CONVERT(Sales_Rate_Max2 ,CHAR(50))+'/'+t.Unit2) as 'Cost (Unit2)' from tbl_ITEMS t inner join tbl_Category C on C.id=t.Cat_Number  left join tbl_BatchNumber B on b.Item_Code=t.id where (t.item_code Like '" + name + "%' or item_name like '" + name + "%' or c.Name like '" + name + "%') and B.Qty <> -1 and B.Qty <> 0  group by t.item_code,t.item_name,c.Name,Sales_Rate_Max,Unit1,Sales_Rate_Max2,t.Unit2 ");
            return dtb;
        }
        //batch sale
        public DataTable get_batchdetails(string ItemCode)
        {
            DataTable dtb = db.table("select Entry_No,BatchNumber,Qty,cast(PrdDate as date) PrdDate,cast(ExpDate as date) ExpDate, Unit2,UnitMF from tbl_BatchNumber where Item_Code='" + ItemCode + "'and Qty>0  order by ExpDate");
             return dtb;
        }
        //purchase itemist
        public DataTable  LoadItems()
        {
            DataTable dt = db.table("select t.id,t.item_code,t.item_name,m.manufacturer,(select sum(Qty) from tbl_BatchNumber where Item_Code=t.id) as 'Current_Stock',(CONVERT(Purch_Rate,CHAR(50))+'/'+t.Unit1) as 'Cost(Unit1)',(CONVERT(Purch_Rate2,CHAR(50))+'/'+t.Unit2) as 'Cost(Unit2)' from tbl_ITEMS t inner  join  tbl_manufacturer m on m.id=t.manufacturer left join tbl_BatchNumber b on b.Item_Code=t.id group by t.item_code,t.item_name,m.manufacturer,t.Purch_Rate,t.Unit1,t.Purch_Rate2,t.Unit2,b.Item_Code Order by t.item_name");
            return dt;
        }
        public DataTable Load_itemcode_details(string item_)
        {
            DataTable dt = db.table("select t.id,t.item_code,t.item_name,m.manufacturer,(select sum(Qty) from tbl_BatchNumber where Item_Code=t.id) as 'Current_Stock',(CONVERT(Purch_Rate,CHAR(50))+'/'+t.Unit1) as 'Cost(Unit1)',(CONVERT(Purch_Rate2,CHAR(50))+'/'+t.Unit2) as 'Cost(Unit2)' from tbl_ITEMS t inner  join  tbl_manufacturer m on m.id=t.manufacturer left join tbl_BatchNumber b on b.Item_Code=t.id where t.id='" + item_ + "'  group by t.item_code,t.item_name,m.manufacturer,t.Purch_Rate,t.Unit1,t.Purch_Rate2,t.Unit2,b.Item_Code Order by t.item_name");
            return dt;
        }
        public DataTable Search(string item)
        {
            DataTable dtb = db.table("select t.id,t.item_code,t.item_name,m.manufacturer,(select sum(Qty) from tbl_BatchNumber where Item_Code=t.id) as 'Current_Stock',(CONVERT(Purch_Rate,CHAR(50))+'/'+t.Unit1) as 'Cost(Unit1)',(CONVERT(Purch_Rate2,CHAR(50))+'/'+t.Unit2) as 'Cost(Unit2)' from tbl_ITEMS t inner  join  tbl_manufacturer m on m.id=t.manufacturer left join tbl_BatchNumber b on b.Item_Code=t.id where t.item_code like'" + item + "%' or t.item_name like '" + item + "%' or m.manufacturer like '" + item + "%'   group by t.item_code,t.item_name,m.manufacturer,t.Purch_Rate,t.Unit1,t.Purch_Rate2,t.Unit2,b.Item_Code");
            return dtb;
        }
        //sales+_return_batch
        public DataTable dtb_load(string InvNum,string ItemCode)
        {
            DataTable dt_batchSale = db.table("select S.BatchNumber,S.Entry_No,S.Qty,BatchEntry,S.RetQty,S.BatchEntry,N.Qty Stock from tbl_BatchSale S inner join  tbl_BatchNumber N on N.Entry_No=S.BatchEntry where InvNumber='" + Convert.ToInt32(InvNum) + "' and S.Item_Code='" + ItemCode + "' ");
            return dt_batchSale;
        }
    }
}
