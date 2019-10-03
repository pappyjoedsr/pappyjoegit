using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Purchase_Report_model
    {
        Connection db = new Connection();
        //purchase report
        public DataTable purchdtls(string frmdte,string todte)
        {
            DataTable dt = db.table("select tbl_purchase.PurchNumber,tbl_purchase.PurchDate,tbl_Supplier.Supplier_Name,tbl_purchase.TotalAmount,tbl_purchase.DiscAmount,tbl_purchase.GrandTotal from tbl_purchase inner join tbl_Supplier on tbl_Supplier.Supplier_Code=tbl_purchase.Sup_Code where tbl_purchase.PurchDate between '" +  frmdte + "' and '" + todte + "'");
            return dt;
        }
        //purchase item report
        public DataTable purchitem(string purchno)
        {
            DataTable dt = db.table("select PurchDate, Item_Code, Desccription, Packing, Unit, Qty, FreeQty, Rate, GST, IGST, Amount from tbl_PURCHIT where PurchNumber = '" + purchno + "'");
            return dt;
        }
        //purchase order report
        public DataTable purchorder(string frmdte, string todte)
        {
            DataTable dt = db.table("select M.Pur_order_no, M.Purch_order_date,S.Supplier_Name from tbl_Purchase_order_master M inner join tbl_Supplier S on  S.Supplier_Code= M.Suppleir_id where Purch_order_date between '" + frmdte + "' and '" + todte+ "'");
            return dt;
        }
        //purchase order item report
        public DataTable purchorderitem(string purchordrno)
        {
            DataTable dt = db.table("select Item_code,Description,Qty,UnitCost,Amount from tbl_PurchaseOrder where Pur_order_no='" + purchordrno + "'");
            return dt;
        }
        //purchase return report
        public DataTable purchreturn(string frmdte,string todte)
        {
            DataTable dt = db.table("select P.PurchNumber,P.RetNumber,P.PurchDate,P.ReturnDate,P.Sup_Code,S.Supplier_Name,P.TotalAmount from tbl_preturn P inner join tbl_Supplier S on S.Supplier_Code=P.Sup_Code where ReturnDate  between '" + frmdte + "' and '" + todte + "'");
            return dt;
        }
        //purchase item return 
        public DataTable purchitemreturn(string purchretrnno)
        {
            DataTable dt = db.table("select P.ReturnDate,I.item_code,I.Gst,I.Igst,I.Qty,I.Rate,I.UNIT2,I.FreeQty from tbl_PRETIT I inner join tbl_PRETURN P on P.RetNumber=I.RetNumber where I.RetNumber='" + purchretrnno + "'");
            return dt;
        }
        public DataTable slctitems(string itmcode)
        {
            DataTable dt = db.table("select Unit1,Unit2 from tbl_ITEMS where item_code='" + itmcode + "' ");
            return dt;
        }
    }
}
