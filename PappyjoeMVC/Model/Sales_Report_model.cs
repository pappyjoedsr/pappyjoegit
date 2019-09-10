using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Sales_Report_model
    {
        Connection db = new Connection();
        //Sales Report
        public DataTable salesinv(string dateFrom,string dateTo)
        {
            DataTable dt = db.table("select S.InvNumber, cast(S.InvDate as date) InvDate, S.cust_number, S.cust_name, Discount, cast(TotalAmount as decimal(18, 2)) TotalAmount from tbl_SALES S where S.InvDate between '" + dateFrom + "' and '" + dateTo + "'");
            return dt;
        }
        //Sales Report Items
        public DataTable salesrprtitms(string invno)
        {
            DataTable dt = db.table("select S.InvNumber,S.Item_Code,S.Description,Packing,UNIT2,UnitMF,Unit,GST,IGST,Qty,FreeQty,Rate,TotalAmount  from tbl_SALEIT S where S.InvNumber='" + invno + "'");
            return dt;
        }
        public DataTable slctbatchno(string invno,string itmcode)
        {
            DataTable dt = db.table("select BatchNumber from tbl_BatchSale where InvNumber='" + invno + "' and Item_Code='" + itmcode + "'");
            return dt;
        }
        public DataTable invdtls(string invno)
        {
            DataTable dt = db.table("select InvNumber,InvDate,cust_name,cust_number from tbl_SALES  where InvNumber='" + invno + "'");
            return dt;
        }
        //Sales Order Report
        public DataTable salesorder(string dateFrom, string dateTo)
        {
            DataTable dt = db.table("select distinct S.DocNumber,S.DocDate,CustomerName,Cus_Id,Phone,(select count(ItemCode) from tbl_SalesOrder where DocNumber=S.DocNumber ) as 'Total Items' from tbl_SalesOrder_Master S inner join tbl_SalesOrder O on S.DocNumber=O.DocNumber where S.DocDate between '" + dateFrom + "' and '" + dateTo + "'and S.Status='O'");
            return dt;
        }
        //Sales Return Report
        public DataTable salesreturn(string dateFrom,string dateTo)
        {
            DataTable dt = db.table("select RetNumber,ReturnDate,InvNumber,InvDate,cust_number,cust_name,GST,IGST,Paid,TotalAmount from tbl_return where ReturnDate between '" + dateFrom + "' and '" + dateTo + "'");
            return dt;
        }
    }
}
