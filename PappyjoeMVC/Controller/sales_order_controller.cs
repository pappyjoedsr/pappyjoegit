using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class sales_order_controller
   {
        sales_order_model _model = new sales_order_model();
        sales_model smodel = new sales_model();
        public DataTable order_master(int invnum_Edit)
        {
            DataTable dtb = _model.order_master(invnum_Edit);
            return dtb;
        }
        public DataTable order_details(int invnum_Edit)
        {
            DataTable dtb = _model.order_details(invnum_Edit);
            return dtb;
        }
        public DataTable doc_number()
        {
            DataTable dtb = _model.doc_number();
            return dtb;
        }
        public DataTable Get_stock(string itemid)
        {
            DataTable dtb = smodel.Get_stock(itemid);
            return dtb;
        }
        public DataTable get_salesrate(string itemid)
        {
            DataTable dtb = _model.get_salesrate(itemid);
            return dtb;
        }
        public DataTable patient_keydown(string name)
        {
            DataTable dtb = smodel.patient_keydown(name);
            return dtb;
        }
        public DataTable patients(string pt_id)
        {
            DataTable dtb = smodel.patients(pt_id);
            return dtb;
        }
        public DataTable get_ptid(string value)
        {
            DataTable dtb = _model.get_ptid(value);
            return dtb;
        }
        public DataTable get_item(string itemid)
        {
            DataTable dtb = _model.get_item(itemid);
            return dtb;
        }
        public int save_master(string doc, string docdate, string order, string orderdate, string name, string cusid, string address1, string adr2, string adr3, string phone)
        {
            int i= _model.save_master(doc,  docdate,  order,  orderdate,  name,  cusid,  address1,  adr2,  adr3,  phone);
            return i;
        }
        public int save_items(string DocNumber, string DocDate, string ItemCode, string Discription, string Qty, string Cost, string TotalAmount)
        {
            int i = _model.save_items(DocNumber, DocDate, ItemCode, Discription, Qty, Cost, TotalAmount);
            return i;
        }
        public void delete_order(int invnum_Edit)
        {
            _model.delete_order(invnum_Edit);
        }
        public DataTable companydetails()
        {
            DataTable dtb = _model.companydetails();
            return dtb;
        }
    }
}
 