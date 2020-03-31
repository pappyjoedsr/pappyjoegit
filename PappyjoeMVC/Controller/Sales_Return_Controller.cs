using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public class Sales_Return_Controller
    {
        Sales_Return_Model model = new Sales_Return_Model();
        Inventory_model invmodel = new Inventory_model();
        public DataTable get_all_invnumbr(string invnumbr)
        {
            DataTable dtb = model. get_all_invnumbr(invnumbr);
            return dtb; 
        }
        public DataTable get_master_sales_details(string value)
        {
            DataTable dtb = model. get_master_sales_details(value);
            return dtb;
        }
        public DataTable itemdetails_from_salesit(string InvNumber)
        {
            DataTable dtb = model.itemdetails_from_salesit(InvNumber);
            return dtb;
        }
        public DataTable itemdetails_from_items(string ItemCode_From_List)
        {
            DataTable dtb = model.itemdetails_from_items(ItemCode_From_List);
            return dtb;
        }
        public DataTable get_sales_items_details(string value, string ItemCode)
        {
            DataTable dtb = model.get_sales_items_details(value, ItemCode);
            return dtb;
        }
        public string get_maxRetnumber(string invnumbr, string itemcode)
        {
            string dtb = model.get_maxRetnumber(invnumbr, itemcode);
            return dtb;
        }
        public string get_totalqty(string InvoiceNum, string ItemCode)
        {
            string dtb = model.get_totalqty(InvoiceNum, ItemCode);
            return dtb;
        }
        public string ubit2_from_retit(string ItemCode, string retnumber)
        {
            string dtb = model.ubit2_from_retit(ItemCode, retnumber);
            return dtb;
        }
        public DataTable get_salesdetails(string InvNumber)
        {
            DataTable dtb = model.get_salesdetails(InvNumber);
            return dtb;
        }
        public int save_master(string ReturnDate, string InvNumber, string InvDate, string cust_number, string cust_name, string TotalAmount, string User_Name, string Paid, decimal GST, string IGST)
        {
            int i = model.save_master(ReturnDate,  InvNumber,  InvDate,  cust_number,  cust_name,  TotalAmount,  User_Name,  Paid,  GST,  IGST);
            return i;
        }
        public string max_retnumber()
        {
            string maxretunmber = model.max_retnumber();
            return maxretunmber;
        }
        public DataTable Get_unites(string Item_Id)
        {
            DataTable dtb = invmodel.Get_unites(Item_Id);
            return dtb;
        }
        public void save_returnitems(string RetNumber, string Item_Code, string Qty, string Rate, string UNIT2, string FreeQty)
        {
            model.save_returnitems(RetNumber,  Item_Code,  Qty,  Rate,  UNIT2,  FreeQty);
        }
        public string get_sales_retqty(string invoicenumbr, string itemcode)
        {
            string dtb = model.get_sales_retqty(invoicenumbr,itemcode);
            return dtb;
        }
        public DataTable get_sales_qty(string returnnumber, string itemcode)
        {
            DataTable dtb = model.get_sales_qty(returnnumber, itemcode);
            return dtb;
        }
        public void update_sales_retqty(decimal RetQty, string InvNumber, string itemcode)
        {
            model.update_sales_retqty(RetQty,InvNumber,itemcode);
        }
        public string retqty_from_batchsale(string entryno)
        {
            string retqty = model.retqty_from_batchsale(entryno);
            return retqty;
        }
        public void update_batchsale(decimal bat_RetQty, string Entry_No)
        {
            model.update_batchsale(bat_RetQty,Entry_No);
        }
        public int update_batchnumber(string qty, string Entry_No)
        {
            int i = model.update_batchnumber(qty,Entry_No);
            return i;
        }
        public int save_log(string log_usrid, string log_type, string log_descriptn, string log_stage)
        {
            int j = model.save_log(log_usrid, log_type, log_descriptn, log_stage);
            return j;
        }
        public DataTable get_details_from_items(string itemid)
        {
            DataTable dtb = model.get_details_from_items(itemid);
            return dtb;
        }
        public DataTable get_companydetails()
        {
            DataTable dtb = invmodel.get_companydetails();
            return dtb;
        }
        public string sum_qty_from_sales(string InvNumber, string Item_Code)
        {
            string qty = model.sum_qty_from_sales(InvNumber,Item_Code);
            return qty;
        }
        public DataTable load_return_master(int Ret_Numbr)
        {
            DataTable dtb = model.load_return_master(Ret_Numbr);
            return dtb;
        }
        public DataTable load_return_items(int Ret_Numbr)
        {
            DataTable dtb = model.load_return_items(Ret_Numbr);
            return dtb;
        }
    }
}
