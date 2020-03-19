using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public  class sales_order_model
    {
        Connection db = new Connection();
        public DataTable order_master(int invnum_Edit)
        {
            DataTable dtb_SalesOrder_Master = db.table("select * from tbl_SalesOrder_Master where DocNumber='" + invnum_Edit + "'");
            return dtb_SalesOrder_Master;
        }
        public DataTable order_details(int invnum_Edit)
        {
            DataTable dtb_SalesOrder = db.table("select * from tbl_SalesOrder where DocNumber='" + invnum_Edit + "'");
            return dtb_SalesOrder;
        }
        public DataTable doc_number()
        {
            DataTable Document_Number = db.table("SELECT max(cast(DocNumber as UNSIGNED)) As 'InvNumber' FROM tbl_SalesOrder_Master");
            return Document_Number;
        }
        public DataTable get_salesrate(string itemid)
        {
            DataTable dtb = db.table(" select Sales_Rate_Max from tbl_ITEMS where id='" + itemid + "'");
            return dtb;
        }
        public DataTable get_ptid(string value)
        {
            DataTable patient = db.table("select pt_name,pt_id from tbl_patient where pt_id='" + value + "'");
            return patient;
        }
        public DataTable get_item(string itemid)
        {
            DataTable dt = db.table("select item_code,item_name,Sales_Rate_Max from tbl_items where Item_Code='" + itemid + "'");
            return dt;
        }
        public int save_master(string doc,string docdate, string order, string orderdate, string name, string cusid, string address1, string adr2, string adr3, string phone)
        {
          int  i = db.execute("insert into tbl_SalesOrder_Master(DocNumber,DocDate,OrderNo,OrderDate,CustomerName,Cus_Id,Address1,adr2,adr3,Phone,Status)values('" + Convert.ToInt32(doc) + "','" + Convert.ToDateTime(docdate).ToString("yyyy-MM-dd") + "','" + order + "','" +Convert.ToDateTime(orderdate).ToString("yyyy-MM-dd") + "','" + name + "','" + cusid + "','" + address1 + "','" + adr2 + "','" + adr3 + "','" + phone + "','O')");
            return i;
        }
        public int save_items(string DocNumber, string DocDate, string ItemCode, string Discription, string Qty, string Cost, string TotalAmount)
        {
          int  j = db.execute("insert into tbl_SalesOrder(DocNumber,DocDate,ItemCode,Discription,Qty,Cost,TotalAmount)values('" + Convert.ToInt32(DocNumber) + "','" + DocDate + "','" + ItemCode + "','" + Discription + "','" + Qty + "','" + Cost + "','" + TotalAmount + "')");
            return j;
        }
        public void delete_order(int invnum_Edit)
        {
            db.execute("delete from tbl_SalesOrder_Master where DocNumber='" + invnum_Edit + "'");
            db.execute("delete from tbl_SalesOrder where DocNumber='" + invnum_Edit + "'");
        }
        public DataTable companydetails()
        {
            DataTable dtp = db.table("select name,contact_no,street_address,email,website,path  from tbl_practice_details");
            return dtp;
        }
        //sales order list
        public DataTable SalesOrderdetls(string date_From, string date_To)
        {
            DataTable dt = db.table("select distinct M.DocNumber,M.DocDate,M.Cus_Id,(select count(ItemCode) from tbl_SalesOrder where DocNumber=M.DocNumber) 'qty',(select sum(Qty*Cost) from tbl_SalesOrder where DocNumber=M.DocNumber) 'amount',M.Cus_Id,M.CustomerName,M.Phone from tbl_SalesOrder_Master M inner join tbl_SalesOrder S on S.DocNumber=M.DocNumber where M.DocDate between '" + Convert.ToDateTime(date_From).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(date_To).ToString("yyyy-MM-dd") + "' and  Status <>'S' and  Status <>'D'");
            return dt;
        }
        public DataTable getSales(string date)
        {
            DataTable dtb = db.table("select distinct M.DocNumber,M.DocDate,M.Cus_Id,(select count(ItemCode) from tbl_SalesOrder where DocNumber=M.DocNumber) 'qty',(select sum(Qty*Cost) from tbl_SalesOrder where DocNumber=M.DocNumber) 'amount',M.Cus_Id,M.CustomerName,M.Phone from tbl_SalesOrder_Master M inner join tbl_SalesOrder S on S.DocNumber=M.DocNumber  where M.DocDate='" + date + "' and  Status <>'S' and  Status <>'D'");
            return dtb;
        }
        public int update_salesOrder(int invnum)
        {
            int i = db.execute("update tbl_SalesOrder_Master set Status='D'where DocNumber='" + invnum + "' ");
            return i;
        }
        public DataTable get_dataRefresh(string date)
        {
            DataTable dtb = db.table("select distinct M.DocNumber,M.DocDate,M.Cus_Id,(select count(ItemCode) from tbl_SalesOrder where DocNumber=M.DocNumber) 'qty',(select sum(Qty*Cost) from tbl_SalesOrder where DocNumber=M.DocNumber) amount,M.Cus_Id,M.CustomerName,M.Phone from tbl_SalesOrder_Master M inner join tbl_SalesOrder S on S.DocNumber=M.DocNumber  where M.DocDate='" + date + "' and  Status <>'S' and  Status <>'D'");
            return dtb;
        }
        public DataTable showdata(string from, string to)
        {
            DataTable dt = db.table("select distinct M.DocNumber,M.DocDate,M.Cus_Id,(select count(ItemCode) from tbl_SalesOrder where DocNumber=M.DocNumber) 'qty',(select sum(Qty*Cost) from tbl_SalesOrder where DocNumber=M.DocNumber) 'amount',M.Cus_Id,M.CustomerName,M.Phone from tbl_SalesOrder_Master M inner join tbl_SalesOrder S on S.DocNumber=M.DocNumber where M.DocDate between '" + from + "' and '" + to + "' and  Status <>'S' and  Status <>'D'");
            return dt;
        }
    }
}
