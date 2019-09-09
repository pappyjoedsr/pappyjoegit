  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class purchase_controller
    {
        //purchase_interface intr;
        Purchase_model _model = new Purchase_model();
        Inventory_model inv_model = new Inventory_model();
        //public purchase_controller()
        //{
        //    //intr = inttr;
        //    //intr.setcontroller(this);
        //}
        public DataTable Get_itemdetails(string itemCode)
        {
            DataTable dtb = _model.Get_itemdetails(itemCode);
            return dtb;
            //intr.Load_item_in_textbox(dtb);
        }
        public DataTable  Get_item_units(string itemCode)
        {
            DataTable dtb = _model.Get_itemdetails(itemCode);
            return dtb;
        }
        public DataTable get_maxpurNumber(string itemCode)
        {
            DataTable dtb = _model.get_maxpurNumber(itemCode);
            return dtb;
        }
        public DataTable Load_Suplier()
        {
            DataTable dtb = _model.Load_Suplier();
            return dtb;
            //intr.Load_Suplier(dtb);
        }
        public DataTable LoadSuplier_wit_supname(string name)
        {
            DataTable dtb = _model.LoadSuplier_wit_supname(name);
            return dtb;
           //intr./*Load_Suplier*/(dtb);
        }
        public DataTable check_batch(string item_code)
        {
            DataTable dtb = _model.check_batch(item_code);
            return dtb;
        }
        public DataTable Get_unites(string Item_Id)
        {
            DataTable dtb = inv_model.Get_unites(Item_Id);
            return dtb;
        }
        public int save_purchase(string PurchNumber, string InvNumber, string PurchDate, string Sup_Code, string TotalAmount, string GrandTotal, string DiscPercentage, string DiscAmount, string TotalCost)
        {
            int i = _model.save_purchase(PurchNumber, InvNumber, PurchDate, Sup_Code, TotalAmount, GrandTotal, DiscPercentage, DiscAmount, TotalCost);
            return i;
        }
        public int save_batchNumber(string Item_Code, string BatchNumber, int Qty, string Unit2, string UnitMF, string PurchNumber, string PrdDate, string ExpDate, string Period, string Sup_Code, string PurchDate, string IsExpDate)
        {
            int i = _model.save_batchNumber(Item_Code, BatchNumber, Qty, Unit2, UnitMF, PurchNumber, PrdDate, ExpDate, Period, Sup_Code, PurchDate, IsExpDate);
            return i;
        }
        public void save_purchaseit(string purno,string date, string Item_Code, string Desccription,string Packing,string Unit, string Qty, int FreeQty, string Rate, string Amount, string UNIT2, string UnitMF, decimal GST, decimal IGST)
        {
            _model.save_purchaseit(purno, date ,Item_Code , Desccription, Packing ,Unit , Qty,FreeQty , Rate , Amount , UNIT2 , UnitMF, GST ,IGST);
        }
        public DataTable get_maxEntryNo()
        {
            DataTable dtb = _model.get_maxEntryNo();
            return dtb;
        }
        public void save_batchpurchase(string PurchNo, string Purc_Date, string Sup_Code, string Item_Code, string BatchNumber, decimal Qty, string Unit2, string UnitMF, string PrdDate, string ExpDate, string IsExpDate, string BatchEntry)
        {
            _model.save_batchpurchase(PurchNo, Purc_Date, Sup_Code,Item_Code, BatchNumber, Qty, Unit2, UnitMF, PrdDate, ExpDate, IsExpDate, BatchEntry);
        }
        public DataTable get_itemdetails(string Itemid)
        {
            DataTable dtb = _model.get_itemdetails(Itemid);
            return dtb;
        }
        public DataTable Get_itemdetails_from_purchaseit(string Itemid)
        {
            DataTable dtb = inv_model.Get_itemdetails_from_purchaseit(Itemid);
            return dtb;
        }
        public void update_itemtable(decimal unitcost, decimal Sales1_, decimal SalesMin_, decimal SalesMax_, decimal costbase1, decimal purchaserate2, decimal Sales2_, decimal SalesMin1_, decimal SalesMax1_, string Item_Id)
        {
            _model.update_itemtable(unitcost, Sales1_, SalesMin_, SalesMax_, costbase1, purchaserate2, Sales2_, SalesMin1_, SalesMax1_, Item_Id);
        }
        public void update_purchaseorder(int Pur_order_no1) 
        {
            _model.update_purchaseorder(Pur_order_no1);
        }
        public DataTable incrementDocnumber()
        {
            DataTable dtb = _model.incrementDocnumber();
            return dtb;
            //intr.DocNumber_increment(dtb);
        }
        public DataTable get_companydetails()
        {
            DataTable dtb = inv_model.get_companydetails();
            return dtb;
        }
        public DataTable load_purchase_order_details(int Pur_order_no1)
        {
            DataTable dtb = _model.load_purchase_order_details(Pur_order_no1);
            return dtb;
        }
        public string get_suppliercode(string sup_id)
        {
            string supplier = _model.get_suppliercode(sup_id);
            return supplier;
        }
    }
}
