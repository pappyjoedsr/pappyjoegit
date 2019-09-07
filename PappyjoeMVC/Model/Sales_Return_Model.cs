using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Sales_Return_Model
    {
        Connection db = new Connection();
        public DataTable get_all_invnumbr(string invnumbr)
        {
            DataTable dtdr = db.table("select InvNumber from tbl_SALES where InvNumber like '" + invnumbr + "%'");
            return dtdr;
        }
        public DataTable get_master_sales_details(string value)
        {
            DataTable dtb_Master = db.table("select * from tbl_SALES where InvNumber='" + value + "'");
            return dtb_Master;
        }
        public DataTable get_sales_items_details(string value,string ItemCode)
        {
            DataTable dtb = db.table(" select * from tbl_SALEIT where InvNumber ='" + Convert.ToInt32(value) + "' and Item_Code='" + ItemCode + "'");
            return dtb;
        }
        public DataTable itemdetails_from_salesit(string InvNumber)
        {
            DataTable dtb_itemlist = db.table("select S.Item_Code,item_name,RetQty,A.id from tbl_SALEIT S inner join tbl_ITEMS A on A.id =S.Item_Code where S.InvNumber='" + Convert.ToInt32(InvNumber) + "'");
            return dtb_itemlist;
        }
        //itemlist
        public DataTable search_itemlist(string invNumber,string name)
        {
            DataTable dtb = db.table("select S.Item_Code,item_name,RetQty,A.id from tbl_SALEIT S inner join tbl_ITEMS A on A.id=S.Item_Code where S.InvNumber='" + Convert.ToInt32(invNumber) + "' and S.Item_Code like'" + name + "%' or item_name like '" + name + "%'");
            return dtb; 
        }
        public DataTable itemdetails_from_items(string ItemCode_From_List)
        {
            DataTable dtb_units = db.table(" select Unit1,Unit2,OneUnitOnly,UnitMF,Item_Code from tbl_ITEMS where id='" + ItemCode_From_List + "'");
            return dtb_units;
        }
        public string get_maxRetnumber(string invnumbr,string itemcode)
        {
            string dt_maxRetNum = db.scalar("select MAX(A.retnumber) from tbl_RETIT A inner join tbl_RETURN B on A.RetNumber=B.RetNumber where InvNumber='" + Convert.ToInt32(invnumbr) + "' and Item_Code='" + itemcode + "'");
            return dt_maxRetNum;
        }
        public string get_totalqty(string InvoiceNum,string ItemCode)
        {
            string tootalqty = db.scalar("select sum(Qty) Qty from tbl_RETIT A inner join tbl_RETURN B on A.RetNumber=B.RetNumber where InvNumber='" + Convert.ToInt32(InvoiceNum) + "' and Item_Code='" + ItemCode + "' ");
            return tootalqty;
        }
        public string ubit2_from_retit(string ItemCode,string retnumber)
        {
          string dt_retUnit = db.scalar("select UNIT2  from tbl_RETIT where Item_Code='" + ItemCode + "' and retnumber='" + Convert.ToInt32(retnumber) + "' ");
            return dt_retUnit;
        }
        public DataTable get_salesdetails(string InvNumber)
        {
            DataTable dtb = db.table("select SaleType,SalesTax,AST,Memo from tbl_SALES where InvNumber='" + Convert.ToInt32(InvNumber) + "'");
            return dtb;
        }
        public int save_master(string ReturnDate, string InvNumber, string InvDate, string cust_number, string cust_name, string TotalAmount, string User_Name, string Paid,  decimal GST, string IGST)
        {
          int i = db.execute("insert into tbl_RETURN(ReturnDate,InvNumber,InvDate,Dep_Number,cust_number,cust_name,TotalAmount,User_Name,Paid,PayMethod,Memo,SaleType,GST,IGST)values('" + ReturnDate + "','" + Convert.ToInt32(InvNumber) + "','" + InvDate + "','1','" + cust_number + "','" + cust_name + "','" + Convert.ToDecimal(TotalAmount) + "','" + User_Name + "','" + Convert.ToDecimal(Paid) + "','Cash','null','1','" + GST + "','" + Convert.ToDecimal(IGST) + "')");
            return i;
        }
        public string max_retnumber()
        {
            string dt_retnumber = db.scalar("select max(retnumber) RetNo from tbl_RETURN");
            return dt_retnumber;
        }
        public void save_returnitems(string RetNumber, string Item_Code, string Qty, string Rate, string UNIT2,string FreeQty)
        {
           db.execute("insert into tbl_RETIT (RetNumber,Item_Code,Qty,Rate,UNIT2,Taxable,FreeQty)values('" + Convert.ToInt32(RetNumber) + "','" + Item_Code + "','" + Convert.ToDecimal(Qty) + "','" + Convert.ToDecimal(Rate) + "','" + UNIT2 + "','Yes','" + Convert.ToDecimal(FreeQty) + "')");
        }
        public string get_sales_retqty(string invoicenumbr,string itemcode)
        {
            string dt_UpdateRetqty_sales = db.scalar("select RetQty from tbl_SALEIT where InvNumber='" + Convert.ToInt32(invoicenumbr) + "'  and Item_Code='" + itemcode + "' ");
            return dt_UpdateRetqty_sales;
        }
        public DataTable get_sales_qty(string returnnumber,string itemcode)
        {
            DataTable dt_salesRetqty = db.table("select Qty,UNIT2 from tbl_RETIT where RetNumber='" + returnnumber + "' and Item_Code='" + itemcode + "' ");
            return dt_salesRetqty;
        }
        public void update_sales_retqty(decimal RetQty,string InvNumber,string itemcode)
        {
            db.execute("update tbl_SALEIT set RetQty='" + RetQty + "' where Item_Code='" + itemcode + "' and InvNumber='" + Convert.ToInt32(InvNumber) + "'");
        }
        public string retqty_from_batchsale(string entryno)
        {
            string dt_UpdateRetqty = db.scalar("select RetQty from tbl_BatchSale where Entry_No='" + Convert.ToInt32(entryno) + "' ");
            return dt_UpdateRetqty;
        }
        public void update_batchsale(decimal bat_RetQty,string Entry_No)
        {
            db.execute("update tbl_BatchSale set RetQty='" + bat_RetQty + "'where Entry_No='" + Convert.ToInt32(Entry_No) + "'");
        }
        public int update_batchnumber(string qty,string Entry_No)
        {
          int  rowaffected = db.execute("update tbl_BatchNumber set qty='" + Convert.ToDecimal(qty) + "' where Entry_No='" + Convert.ToInt32(Entry_No) + "'");
            return rowaffected;
        }
        public DataTable get_details_from_items(string itemid)
        {
            DataTable dtb = db.table("select Sales_Rate_Max,Unit1,Unit2,OneUnitOnly,UnitMF from tbl_ITEMS where item_code='" + itemid + "' ");
            return dtb;
        }
        public string sum_qty_from_sales(string InvNumber, string Item_Code)
        {
            string dt =db.scalar("select sum(qty) from tbl_BatchSale where InvNumber='" + InvNumber + "' and Item_Code='" + Item_Code + "' ");
            return dt;
        }
        public DataTable load_return_master(int Ret_Numbr)
        {
            DataTable dtb_main = db.table("select * from tbl_RETURN where RetNumber='" + Ret_Numbr + "'");
            return dtb_main;
        }
        public DataTable load_return_items(int Ret_Numbr)
        {
            DataTable dtb_Items = db.table("select * from tbl_RETIT where RetNumber='" + Ret_Numbr + "'");
            return dtb_Items;
        }
        //sales return list
        public DataTable Load_grid(string date)
        {
            DataTable dtb = db.table(" select  M.RetNumber,DATE(M.ReturnDate) as ReturnDate ,M.InvNumber,DATE( M.InvDate) as InvDate,M.cust_number,(select count(Item_Code) from tbl_RETIT where RetNumber=M.RetNumber) 'items',  CAST( M.TotalAmount as decimal(18,2)) 'TotalAmount'  from tbl_RETURN M  where M.ReturnDate='" + date + "'");
            return dtb;
        }
        public DataTable Load_return_detail(string date)
        {
            DataTable dtb =  db.table(" select  M.RetNumber,M.ReturnDate,M.InvNumber,M.InvDate,M.cust_number,(select count(Item_Code) from tbl_RETIT where RetNumber=M.RetNumber) items,  CAST( M.TotalAmount as decimal(18,2)) TotalAmount  from tbl_RETURN M inner join tbl_RETIT S on S.RetNumber=M.RetNumber  where M.ReturnDate='" + date + "'");
            return dtb;
        }
        public DataTable load_details_wit_date(string from,string to)
        {
            DataTable dt = db.table(" select  M.RetNumber,DATE_FORMAT(M.ReturnDate, '%Y-%m-%d') ReturnDate ,M.InvNumber,DATE_FORMAT(M.InvDate, '%Y-%m-%d') InvDate ,M.cust_number,(select count(Item_Code) from tbl_RETIT where RetNumber=M.RetNumber) items,CAST( M.TotalAmount as decimal(18,2)) TotalAmount from tbl_RETURN M inner join tbl_RETIT S on S.RetNumber=M.RetNumber  where M.ReturnDate  between '" + from + "' and '" + to + "'");
            return dt;
        }
    }
}
