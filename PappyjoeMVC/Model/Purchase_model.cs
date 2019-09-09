using System.Data;
namespace PappyjoeMVC.Model
{
    public class Purchase_model
    {
        Connection db = new Connection();
        //load purchase items
        public DataTable Get_itemdetails(string itemCode)
        {
            DataTable dtitems = db.table("select item_name,Packing,Purch_Rate,Unit1,Unit2,UnitMF from tbl_ITEMS where id='" + itemCode + "'");
            return dtitems;
        }
        public DataTable get_maxpurNumber(string itemCode)
        {
            DataTable dt_PurNum = db.table("select MAX(PurchNumber)from tbl_PURCHIT where Item_Code='" + itemCode + "'");
            return dt_PurNum;
        }
        public DataTable Load_Suplier()
        {
            DataTable dt = db.table("select Supplier_Code,Supplier_Name from tbl_Supplier order by Supplier_Code ");
            return dt;
        }
        public DataTable LoadSuplier_wit_supname(string name)
        {
            DataTable dt = db.table("select Supplier_Code,Supplier_Name  from tbl_Supplier where Supplier_Name like '" + name + "%'  or Supplier_Code like '" + name + "%' or Phone1 like '" + name + "%'");
            return dt;
        }
        public DataTable check_batch(string item_code)
        {
            DataTable dt = db.table("select ISBatch,item_name from tbl_ITEMS where id='" + item_code + "'");
            return dt;
        }
        public int save_purchase(string PurchNumber, string InvNumber, string PurchDate, string Sup_Code, string TotalAmount, string GrandTotal, string DiscPercentage, string DiscAmount, string TotalCost)
        {
            int i = db.execute("insert into tbl_PURCHASE (PurchNumber,InvNumber,PurchDate,Sup_Code,TotalAmount,DiscPercent,DiscAmount,GrandTotal,PurchType,TotalCost) values('" + PurchNumber + "','" + InvNumber + "','" + PurchDate + "','" + Sup_Code + "','" + TotalAmount + "','" + DiscPercentage + "','" + DiscAmount + "','" + GrandTotal + "','cash','" + TotalCost + "')");
            return i;
        }
        public int save_batchNumber(string Item_Code, string BatchNumber, int Qty, string Unit2, string UnitMF, string PurchNumber, string PrdDate, string ExpDate, string Period, string Sup_Code, string PurchDate, string IsExpDate)
        {
            int a = db.execute("insert into tbl_BatchNumber (Item_Code,BatchNumber,Qty,Unit2,UnitMF,PurchNumber,PrdDate,ExpDate,Period,Sup_Code,PurchDate,IsExpDate) values ('" + Item_Code + "','" + BatchNumber + "','" + Qty + "','" + Unit2 + "','" + UnitMF + "','" + PurchNumber + "','" + PrdDate + "','" + ExpDate + "','" + Period + "','" + Sup_Code + "','" + PurchDate + "','" + IsExpDate + "')");
            return a;
        }
        public void save_purchaseit(string PurchNo, string Purc_Date, string Item_Code, string Desccription, string Packing, string Unit, string Qty, int FreeQty, string Rate, string Amount, string UNIT2, string UnitMF, decimal GST, decimal IGST)
        {
            db.execute("insert into tbl_PURCHIT (PurchNumber,PurchDate,Item_Code,Desccription,Packing,Unit,Qty,FreeQty,Rate,Amount,UNIT2,UnitMF,RetQty,GST,IGST) values ('" + PurchNo + "','" + Purc_Date + "','" + Item_Code + "','" + Desccription + "','" + Packing + "','" + Unit + "','" + Qty + "','" + FreeQty + "','" + Rate + "','" + Amount + "','" + UNIT2 + "','" + UnitMF + "','0','" + GST + "','" + IGST + "')");
        }
        public DataTable get_maxEntryNo()
        {
            DataTable batch_entry = db.table("select max( Entry_No) from tbl_BatchNumber order by Entry_No desc");
            return batch_entry;
        }
        public void save_batchpurchase(string PurchNo, string Purc_Date,string Sup_Code, string Item_Code, string BatchNumber, decimal Qty, string Unit2, string UnitMF, string PrdDate, string ExpDate, string IsExpDate, string BatchEntry)
        { 
            db.execute("insert into tbl_BatchPurchase (PurchNumber,PurchDate,Sup_Code,Item_Code,BatchNumber,Qty,Unit2,UnitMF,PrdDate,ExpDate,IsExpDate,BatchEntry,RetQty) values ('" + PurchNo + "','" + Purc_Date + "','" + Sup_Code + "','" + Item_Code + "','" + BatchNumber + "','" + Qty + "','" + Unit2 + "','" + UnitMF + "','" + PrdDate + "','" + ExpDate + "','" + IsExpDate + "','" + BatchEntry + "','0')");
        }

        public DataTable get_itemdetails(string Itemid)
        {
            DataTable dtb_cost = db.table("select * from tbl_ITEMS where id='" + Itemid + "'");
            return dtb_cost;
        }
      
        public void update_itemtable(decimal unitcost, decimal Sales1_, decimal SalesMin_, decimal SalesMax_, decimal costbase1, decimal purchaserate2, decimal Sales2_, decimal SalesMin1_, decimal SalesMax1_, string Item_Id)
        {
            db.execute("update tbl_ITEMS set Purch_Rate='" + unitcost + "', Sales_Rate='" + Sales1_ + "',Sales_Rate_min='" + SalesMin_ + "',Sales_Rate_Max='" + SalesMax_ + "',CostBase='" + costbase1 + "',Purch_Rate2='" + purchaserate2 + "',Sales_Rate2='" + Sales2_ + "',Sales_Rate_min2='" + SalesMin1_ + "',Sales_Rate_Max2='" + SalesMax1_ + "' where item_code='" + Item_Id + "'");
        }
        public void update_purchaseorder(int Pur_order_no1)
        {
            db.execute("Update tbl_Purchase_order_master set status='P' where Pur_order_no= '" + Pur_order_no1 + "'");
        }
        public DataTable incrementDocnumber()
        {
            DataTable Document_Number = db.table("SELECT max(cast(PurchNumber as UNSIGNED))AS 'Doc_Number' FROM tbl_PURCHASE");
            return Document_Number;
        }
        public DataTable load_purchase_order_details(int Pur_order_no1)
        {
            DataTable dt = db.table("select M.Suppleir_id,S.Supplier_Name,P.Item_code,P.Description,P.Qty,P.UnitCost,P.Amount from tbl_PurchaseOrder P inner join tbl_Purchase_order_master M on M.Pur_order_no=P.Pur_order_no inner join tbl_Supplier S on S.Supplier_Code=M.Suppleir_id where P.Pur_order_no='" + Pur_order_no1 + "'");
            return dt;
        }
        public string get_suppliercode(string sup_id)
        {
            string supplier = db.scalar("select Supplier_Name from tbl_Supplier where Supplier_Code='" + sup_id + "'");
            return supplier;
        }
        //purchase list
        public DataTable getPurchase_btwndates(string fromdate, string todate)
        {
            DataTable dt = db.table("select p.PurchNumber,p.PurchDate,p.Sup_Code,s.Supplier_Name,p.GrandTotal,p.PurchType from tbl_PURCHASE as p inner join tbl_Supplier as s on p.Sup_Code = s.Supplier_Code  where  PurchDate between '" + fromdate + "' and '" + todate + "'");
            return dt;
        }
        public DataTable data_from_Pur_Master(object dgv_Purchase)
        {
            DataTable data_from_Pur_Master = db.table("select PurchNumber,PurchDate,Sup_Code,TotalAmount,DiscPercent,DiscAmount,GrandTotal,PurchType,TotalCost from tbl_PURCHASE where PurchNumber = '" + dgv_Purchase + "'");
            return data_from_Pur_Master;
        }
        public DataTable data_from_purchase(object dgv_Purchase)
        {
            DataTable data_from_purchase = db.table("select p.PurchDate,p.Item_Code as id,s.Item_Code,p.Desccription,p.Packing,p.Unit,p.Qty,p.FreeQty,p.Rate,p.Amount,p.GST,p.IGST from tbl_PURCHIT p inner join tbl_ITEMS s on s.id= p.Item_Code where PurchNumber='" + dgv_Purchase + "'");
            return data_from_purchase;
        }
        public DataTable dt(string fromdate, string todate)
        {
            DataTable dt = db.table("select p.PurchNumber,p.PurchDate,p.Sup_Code,s.Supplier_Name,p.GrandTotal,p.PurchType,s.Address1 from tbl_PURCHASE as p inner join tbl_Supplier as s on p.Sup_Code = s.Supplier_Code  where  PurchDate between '" + fromdate + "' and '" + todate + "'");
            return dt;
        }
    }
}
