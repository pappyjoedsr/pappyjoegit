using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class sales_controller
    {
        sales_model _model = new sales_model();
        Common_model cmodel = new Common_model();
        Inventory_model inv_model = new Inventory_model();
        Connection db = new Connection();
        public DataTable get_itemdetails(string name)
        {
            DataTable dtb = _model.get_itemdetails(name);
            return dtb;
        }
        public DataTable GetDoctorName(string name)
        {
            DataTable dtb = _model.GetDoctorName(name);
            return dtb;
        }
        public DataTable get_doctorname_by_id(string value)
        {
            DataTable dtb = _model.get_doctorname_by_id(value);
            return dtb;
        }
        public DataTable patients(string name)
        {
            DataTable dtb = _model.patients(name);
            return dtb;
        }
        public DataTable patient_keydown(string value)
        {
            DataTable dtb = _model.patient_keydown(value);
            return dtb;
        }
        public DataTable itemdetails(string itemid)
        {
            DataTable dtb = _model.itemdetails(itemid);
            return dtb;
        }
        public DataTable Get_stock(string itemid)
        {
            DataTable dtb = _model.Get_stock(itemid);
            return dtb;
        }
        public DataTable get_item_unitmf(string Itemid)
        {
            DataTable dtb = inv_model.get_item_unitmf(Itemid);
            return dtb;
        }
        public DataTable get_salesrate_unit(string itemid)
        {
            DataTable dtb = _model.get_salesrate_unit(itemid);
            return dtb;
        }
        public DataTable sales_details(int invnum_Edit)
        {
            DataTable dtb = _model.sales_details(invnum_Edit);
            return dtb;
        }
        public DataTable get_hsn(string id)
        {
            DataTable dtb = _model.get_hsn(id);
            return dtb;
        }
        public DataTable sales_items_details(int invnum_Edit)
        {
            DataTable dtb = _model.sales_items_details(invnum_Edit);
            return dtb;
        }
        public DataTable get_batchsale(int invnum_Edit)
        {
            DataTable dtb = _model.get_batchsale(invnum_Edit);
            return dtb;
        }
        public DataTable load_prescription()
        {
            DataTable dtb = _model.load_prescription();
            return dtb;
        }
        public DataTable docnumber()
        {
            DataTable dtb = _model.docnumber();
            return dtb;
        }
        public DataTable salesOrder_master(int invnum_order)
        {
            DataTable dtb = _model.salesOrder_master(invnum_order);
            return dtb;
        }
        public DataTable get_doctor(string doctor_id)
        {
            DataTable dtb = _model.get_doctor(doctor_id);
            return dtb;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dtb = cmodel.Get_CompanyNAme();
            return dtb;
        }
        public string server()
        {
            string server = db.server();
            return server;
        }
        public DataTable order_itemsDtails(int invnum_order)
        {
            DataTable dtb = _model.order_itemsDtails(invnum_order);
            return dtb;
        }
        public int Save_salesMaster_cheque(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, string Bank, string Number, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
            int i = _model.Save_salesMaster_cheque(DocNo, Docdate, sales_, ordeNo, Date_, doctor_, lrno, lr_date, throuhg, ptid, ptname, street__, locality, city, phone, payMethod, Bank, Number, totalAmnt, disount, gst, igst, gTotal);
            return i;
        }
        public int Save_salesMaster_card(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, string cardnumber, string fourdigitnumber, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
            int i = _model.Save_salesMaster_card(DocNo, Docdate, sales_, ordeNo, Date_, doctor_, lrno, lr_date, throuhg, ptid, ptname, street__, locality, city, phone, payMethod, cardnumber, fourdigitnumber, totalAmnt, disount, gst, igst, gTotal);
            return i;
        }
        public int Save_salesMaster_DD(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, string Bank, string DDnumber, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
            int i = _model.Save_salesMaster_DD(DocNo, Docdate, sales_, ordeNo, Date_, doctor_, lrno, lr_date, throuhg, ptid, ptname, street__, locality, city, phone, payMethod, Bank, DDnumber, totalAmnt, disount, gst, igst, gTotal);
            return i;
        }
        public int Save_salesMaster(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
          int i=   _model.Save_salesMaster(DocNo, Docdate, sales_, ordeNo, Date_, doctor_, lrno, lr_date, throuhg, ptid, ptname, street__, locality, city, phone, payMethod, totalAmnt, disount, gst, igst, gTotal);
            return i;
        }
        public DataTable get_costbase(string itemcode)
        {
            DataTable dtb = _model.get_costbase(itemcode);
            return dtb;
        }
        public int Save_itemdetails(int DocNo, string Docdate, string Item_Code, string Description, string Packing, string Unit, decimal GST, decimal IGST, int Qty, int FreeQty, decimal Rate, decimal TotalAmount, string UNIT2, decimal UnitMF, decimal CostBase)
        {
          int i= _model.Save_itemdetails(DocNo, Docdate,Item_Code, Description, Packing, Unit, GST, IGST, Qty, FreeQty, Rate, TotalAmount, UNIT2, UnitMF, CostBase);
            return i;
        }
        public void update_batchnumber(decimal currentStock, string BatchEntry)
        {
            _model.update_batchnumber(currentStock, BatchEntry);
        }
        public void save_batchsale(int InvNumber, string InvDate, string Item_Code, string BatchNumber, decimal Qty, string BatchEntry)
        {
            _model.save_batchsale(InvNumber, InvDate, Item_Code, BatchNumber, Qty, BatchEntry);
        }
        public void update_salesorder(string invnum_order)
        {
            _model.update_salesorder(invnum_order);
        }
        public DataTable Get_companydetails()
        {
            DataTable dtb = _model.Get_companydetails();
            return dtb;
        }
        public DataTable prescription_main(string PrescritionMain_id)
        {
            DataTable dtb = _model.prescription_main(PrescritionMain_id);
            return dtb;
        }
        public DataTable prescription_dteails(string PrescritionMain_id)
        {
            DataTable dtb = _model.prescription_dteails(PrescritionMain_id);
            return dtb;
        }
        public DataTable get_inventoryid(string drug_id)
        {
            DataTable dtb = _model.get_inventoryid(drug_id);
            return dtb;
        }
        public DataTable Get_itemdetails(string inventory_id)
        {
            DataTable dtb = _model.Get_itemdetails(inventory_id);
            return dtb;
        }
        public DataTable get_batchdetails(string item_Code)
        {
            DataTable dtb = _model.get_batchdetails(item_Code);
            return dtb;
        }
      
    }
}
