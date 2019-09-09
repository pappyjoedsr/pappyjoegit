using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Controller;
namespace PappyjoeMVC.Model
{
   public  class purchase_return_model
    {
        Connection db = new Connection();
        public DataTable load_return_details(int purchRetNo1)
        {
           DataTable  dt = db.table("select PT.item_code,I.item_name,P.PurchNumber,P.PurchDate,P.Sup_Code,S.Supplier_Name,PT.FreeQty,PT.Qty,PT.Rate,PT.Gst,PT.Igst,PT.UNIT2,P.TotalCost,P.TotalAmount from tbl_PRETURN P inner join tbl_Supplier S  on S.Supplier_Code=P.Sup_Code inner join tbl_PRETIT PT on PT.RetNumber=P.RetNumber inner join tbl_ITEMS I on I.id=PT.item_code where P.RetNumber='" + purchRetNo1 + "'");
            return dt;
        }
        public string get_packing(string item_code,string PurchNumber)
        {
            string packing=  db.scalar(" select Packing from tbl_PURCHIT where Item_Code='" + item_code + "' and  PurchNumber='" + PurchNumber + "'");
            return packing;
        }
        public DataTable load_purchaenum(string purchaseno)
        {
            DataTable dt_pur_NO = db.table("select  PurchNumber from tbl_purchase where PurchNumber like '%" + purchaseno + "%' order by PurchNumber");
            return dt_pur_NO;
        }
        public DataTable Load_pur_details(string pur_no)
        {
            DataTable dt = db.table("select M.PurchDate,M.Sup_Code,S.Supplier_Name from tbl_PURCHASE M inner join tbl_Supplier S on S.Supplier_Code=M.Sup_Code where PurchNumber='" + pur_no+ "'");
            return dt;
        }
        //itemlist
        public DataTable Load_Items(int pur_no1)
        {
            DataTable dt = db.table("select distinct P.Item_Code as id,I.item_name,I.Item_Code  from tbl_PURCHIT P inner join tbl_ITEMS I on I.id=P.Item_Code where PurchNumber='" + pur_no1 + "'");
            return dt;
        }
        public DataTable search_items(int pur_no1,string search)
        {
            DataTable dtb = db.table("select distinct P.Item_Code,I.item_name from tbl_PURCHIT P inner join tbl_ITEMS I on I.id=P.Item_Code where PurchNumber='" + pur_no1 + "' and P.Item_ID Like '" + search + "%' or I.item_name Like '" + search + "%'  ");
            return dtb;
        }
        ///
        public DataTable get_Loaditems_details(string itemcd1,string pur_no)
        {
         DataTable dtb=  db.table("select P.Item_Code as id ,P.Desccription,P.Packing,P.Unit,P.UNIT2,P.GST,P.IGST,P.Qty,P.RetQty,P.FreeQty,P.Rate,P.Amount,I.Unit1,I.Unit2,I.UnitMF,I.Item_Code from tbl_PURCHIT P inner join tbl_ITEMS I on I.id=P.Item_Code where P.Item_Code='" + itemcd1 + "' and PurchNumber='" + pur_no + "'");
            return dtb;
        }
        public DataTable get_unit_details(string dtitems)
        {
            DataTable dt_unit = db.table("select Unit2,Unit1,UnitMF from tbl_ITEMS where id='" + dtitems + "'");
            return dt_unit;
        }
        //return batch
        public string get_unti2(int Pur_no1,string itemcode1)
        {
           string dtuni2_1 = db.scalar("select UNIT2 from tbl_PURCHIT where PurchNumber='" + Pur_no1 + "' and Item_Code='" + itemcode1 + "'");
            return dtuni2_1;
        }
        public DataTable get_batch_details(int Pur_no1,string itemcode1)
        {
            DataTable dt = db.table("select BatchNumber,PrdDate,ExpDate,Qty,RetQty,IsExpDate from tbl_BatchPurchase  where PurchNumber='" + Pur_no1 + "' and Item_Code='" + itemcode1 + "'");
            return dt;
        }
        public DataTable get_batchentry_qty(string pur_no,string batch1)
        {

          DataTable dt = db.table("select Entry_No,Qty from tbl_BatchNumber where PurchNumber='" + pur_no + "' and BatchNumber='" + batch1 + "'");
            return dt; 
        }
        public void save_purReturn(string ReturnDate, string PurchNumber, string PurchDate, string Sup_Code, string TotalAmount,  string TotalCost)
        {
            db.execute("insert into tbl_PRETURN(ReturnDate,PurchNumber,PurchDate,Sup_Code,TotalAmount,PayMethod,Dep_Number,TotalCost) values('" + ReturnDate + "','" + PurchNumber + "','" + PurchDate + "','" + Sup_Code + "','" + TotalAmount + "','cash','1','" + TotalCost + "')");
        }
        public string get_maxReturnNo()
        {
            string dt = db.scalar("select max(RetNumber) from tbl_PRETURN");
            return dt;
        }
        public string get_unit2(string itemid )
        {
            string unit = db.scalar("select Unit2 from tbl_ITEMS where id='" + itemid+ "'");
            return unit;
        }
        public void save_returnItems(string RetNumber, string item_code, string Qty, string Rate, string UNIT2, string FreeQty, string Gst, string Igst)
        {
            db.execute("insert into tbl_PRETIT(RetNumber,item_code,Qty,Rate,UNIT2,FreeQty,Gst,Igst) values ('" + RetNumber + "','" + item_code + "','" + Convert.ToDecimal(Qty) + "','" + Convert.ToDecimal(Rate) + "','" + UNIT2 + "','" + FreeQty + "','" + Gst + "','" + Igst + "')");
        }
        public void upadte_batchnumber(decimal QTY,string itemcode,string batchnumbr)
        {
            db.execute("update tbl_BatchNumber set Qty= '" + QTY + "' where Item_Code='" + itemcode + "' and BatchNumber= '" + batchnumbr + "' ");
        }
        public string get_returnqty(string pur_no, string itemcode)
        {
            string dtRet = db.scalar("select RetQty from tbl_PURCHIT where PurchNumber='" + pur_no + "' and Item_Code='" + itemcode + "' ");
            return dtRet;
        }
        public void update_purchit(decimal retnew,string pur_no,string itemcode)
        {
            db.execute("update tbl_PURCHIT set RetQty='" + retnew + "'where PurchNumber='" + pur_no + "' and Item_Code='" + itemcode + "'");
        }
        public string get_dte(string PurchNumber,string Item_Code,string batch)
        {
          string dtBatch = db.scalar("select RetQty from tbl_BatchPurchase where PurchNumber='" + PurchNumber + "' and  Item_Code= '" + Item_Code + "' and  BatchNumber='" + batch + "'");
            return dtBatch;
        }
        public void update_batchpurchase(decimal batchNewQty,string PurchNumber,string Item_Code,string BatchNumber)
        {
            db.execute("update tbl_BatchPurchase set RetQty='" + batchNewQty + "' where PurchNumber='" + PurchNumber + "' and  Item_Code= '" + Item_Code + "' and  BatchNumber='" + BatchNumber + "'");
        }
        //PURCHASE return list
        public DataTable get_purchaseretnList_data(string DTP_From, string DTP_To)
        {
            DataTable dt = db.table("select P.RetNumber,P.PurchNumber,P.ReturnDate,P.Sup_Code,S.Supplier_Name,P.TotalAmount from tbl_PRETURN P inner join tbl_Supplier S on S.Supplier_Code=P.Sup_Code where ReturnDate between '" + DTP_From + "' and '" + DTP_To + "'");
            return dt;
        }
    }
}

