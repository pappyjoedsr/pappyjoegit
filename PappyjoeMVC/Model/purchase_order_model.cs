using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class purchase_order_model
    {
        Connection db = new Connection();
        //Form_Control_Model fmodel = new Form_Control_Model();
        //private string orderno = "";
        //public string OrerNo
        //{
        //    get { return orderno; }
        //    set { orderno = value; }
        //}
        //private string orderdate = "";
        //public string OrderDate
        //{
        //    get { return orderdate; }
        //    set { orderdate = value; }
        //}
        //private string supplierid = "";
        //public string Supplierid
        //{
        //    get { return supplierid; }
        //    set { supplierid = value; }
        //}
        public DataTable master_details(int purch_id1)
        {
            DataTable pur_master = db.table("Select m.Pur_order_no,m.Purch_order_date,m.Suppleir_id,s.Supplier_Name from tbl_Purchase_order_master m inner join tbl_Supplier s on s.Supplier_Code=m.Suppleir_id where Pur_order_no='" + purch_id1 + "'");
            return pur_master;
        }
        public DataTable Load_item_details(int purch_id1)
        {
            DataTable Purchase = db.table("select P.Pur_order_no,p.Item_code as id,P.Description,p.Qty,p.UnitCost,p.Amount,I.Item_code from tbl_PurchaseOrder p inner join tbl_ITEMS I on p.Item_code=I.id  where Pur_order_no='" + purch_id1 + "'");
            return Purchase;
        }
        public DataTable Doc_number()
        {
            DataTable Document_Number = db.table("SELECT max(cast(Pur_order_no as UNSIGNED))AS 'Pur_order_no' FROM tbl_PurchaseOrder");
            return Document_Number;
        }
        public DataTable Load_supplier_details(string name)
        {
            DataTable dt = db.table("select Supplier_Code,Supplier_Name  from tbl_Supplier where Supplier_Name like '" + name + "%'  or Supplier_Code like '" + name + "%' or Phone1 like '" + name + "%'");
            return dt;
        }
        public DataTable Load_all_supplier()
        {
            DataTable dt = db.table("select Supplier_Code,Supplier_Name  from tbl_Supplier ");
            return dt;
        }
        public DataTable get_supplier_name(string sup_code)
        {
            DataTable dt = db.table("select Supplier_Code,Supplier_Name from tbl_Supplier where Supplier_Code='" + sup_code + "' ");
            return dt;
        }
        public DataTable get_itemname(string Itemid)
        {
            DataTable dt = db.table("select item_name,Purch_Rate from tbl_ITEMS where id='" + Itemid + "'");
            return dt;
        }
        public string max_purNo(string Itemid)
        {
            string dt_PurNum = db.scalar("select MAX(PurchNumber)from tbl_PURCHIT where Item_Code='" + Itemid + "'");
            return dt_PurNum;
        }
        public string purchit_details(string itemid)
        {
            string dt_Cost = db.scalar(" select Purch_Rate from tbl_ITEMS where id='" + itemid + "'");

            //string dt_Cost = db.scalar("select Rate from tbl_PURCHIT where PurchNumber='" + Convert.ToInt32(dt_PurNum) + "' and Item_Code='"+ itemid + "' ");
            return dt_Cost;
        }
        public void save_master(string OrerNo, string OrderDate, string Supplierid)
        {
            db.execute("insert into tbl_Purchase_order_master (Pur_order_no,Purch_order_date,Supplier_id,status) values('" + OrerNo + "','" + OrderDate + "','" + Supplierid + "','O')");
        }
        public void save_items(string OrerNo, string Item_Id, string description, string col_qty, string Unit_Cost, string Amount)
        {
            db.execute("insert into tbl_PurchaseOrder (Pur_order_no,Item_code,Description,Qty,UnitCost,Amount) values('" + OrerNo + "','" + Item_Id + "','" + description + "','" + col_qty + "','" + Unit_Cost + "','" + Amount + "')");
        }
        
        public void delete_order(string orderno)
        {
            db.execute("delete from tbl_Purchase_order_master where Pur_order_no='" + orderno + "'");
            db.execute("delete from tbl_PurchaseOrder where Pur_order_no='" + orderno + "'");
        }
        //purchase order list
        public DataTable PurchaseDataBydate(string dateFrom, string dateTo)
        {
            DataTable dt = db.table("select distinct M.Pur_order_no,M.Purch_order_date,t.Supplier_Name,(select count(Item_code) from tbl_PurchaseOrder where Pur_order_no=M.Pur_order_no) 'qty', (select sum(Amount) from tbl_PurchaseOrder where Pur_order_no=M.Pur_order_no) 'amount' from tbl_Purchase_order_master M inner join tbl_PurchaseOrder S on S.Pur_order_no=M.Pur_order_no inner join tbl_Supplier t on Supplier_Code = M.Suppleir_id where Purch_order_date between '" + Convert.ToDateTime(dateFrom).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(dateTo).ToString("yyyy-MM-dd") + "' and M.status='O'");
            return dt;
        }
        public DataTable Purchase(string dtpFrom, string dtpTo)
        {
            DataTable dt = db.table("select distinct M.Pur_order_no,M.Purch_order_date,t.Supplier_Name,(select count(Item_code) from tbl_PurchaseOrder where Pur_order_no=M.Pur_order_no) qty, (select sum(Amount) from tbl_PurchaseOrder where Pur_order_no=M.Pur_order_no) amount from tbl_Purchase_order_master M inner join tbl_PurchaseOrder S on S.Pur_order_no=M.Pur_order_no inner join tbl_Supplier t on Supplier_Code = M.Suppleir_id where Purch_order_date between '" + dtpFrom + "' and '" + dtpTo + "' and M.status='O'");
            return dt;
        }
        public int Get_PrchseData(int purodno)
        {
            int i = db.execute("update tbl_Purchase_order_master set status='D' where Pur_order_no='" + purodno + "'");
            return i;
        }
    }
}
