using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
  public class sales_model
    {
        Connection db = new Connection();
        public DataTable get_itemdetails(string name)
        {
            DataTable dtb = db.table(" select i.Sales_Rate_Max,i.Packing,i.Unit1,i.Unit2,i.OneUnitOnly,p.GST,p.IGST from tbl_ITEMS i inner join tbl_PURCHIT p on p.Item_Code = i.id  where i.id='" +name + "'");
            return dtb;
        }
        public DataTable GetDoctorName(string name)
        {
            DataTable dtdr = db.table("select id,doctor_name from tbl_doctor where (login_type='doctor' or login_type='admin') and activate_login='yes'and  doctor_name like '" + name + "%'");
            return dtdr;
        }
        public DataTable get_doctorname_by_id(string value)
        {
           DataTable supplier = db.table("select id,doctor_name from tbl_doctor where (login_type='doctor' or login_type='admin') and activate_login='yes'and  id='" + value + "'");
            return supplier;
        }
        public DataTable patients(string value)
        {
            DataTable dtdr = db.table("select pt_id,pt_name,street_address,locality,city,primary_mobile_number from tbl_patient where  pt_id='" + value + "' ");
            return dtdr;
        }
        public DataTable patient_keydown(string name)
        {
            DataTable supplier = db.table("select pt_name,pt_id from tbl_patient where  pt_name like '%" + name + "%' or pt_id like '" + name + "%'");
            return supplier;
        }
        public DataTable itemdetails(string itemid)
        {
            DataTable dtb = db.table("select Sales_Rate_Max,Packing,Unit1,Unit2,OneUnitOnly,UnitMF from tbl_ITEMS where id='" + itemid + "' ");
            return dtb;
        }
        public DataTable Get_stock(string itemid)
        {
            DataTable dtb_qty = db.table("select sum(qty) Stock from tbl_BatchNumber where item_code='" + itemid + "'");
            return dtb_qty;
        }
        public DataTable get_salesrate_unit(string itemid)
        {
            DataTable dt_cost = db.table("select Packing,Sales_Rate,Unit1,Unit2 from tbl_ITEMS where id='" + itemid + "'");
            return dt_cost;
        }
        public DataTable  sales_details(int invnum_Edit)
        {
            DataTable dtb_master = db.table("select InvNumber,InvDate,SalesmanCode,OrderNumber,Orderdate,Prescribedby,LRNo,LRDate,Through,cust_name,cust_number,adr1,adr2,adr3,phone1,Discount,GST,IGST,TotalAmount,PayMethod from tbl_SALES where InvNumber='" + invnum_Edit + "'");
            return dtb_master;
        }
        public DataTable sales_items_details(int invnum_Edit)
        {
            DataTable dtb_sales = db.table("select InvNumber,Item_Code,Description,Packing,Unit,GST,IGST,Qty,FreeQty,Rate,TotalAmount from tbl_SALEIT where InvNumber='" + invnum_Edit + "'");
            return dtb_sales;
        }
        public DataTable get_hsn(string id)
        {
            DataTable dtb = db.table("select id,item_name,Item_Code,HSN_Number from tbl_ITEMS where id='" + id + "'");
            return dtb;
        }
        public DataTable get_batchsale(int invnum_Edit)
        {
            DataTable dtb_BatchSale = db.table("select InvNumber,InvDate,s.Item_Code,s.BatchNumber,s.Qty,s.IsExpDate,BatchEntry,PrdDate,ExpDate from tbl_BatchSale s inner join tbl_batchnumber b on b.BatchNumber=s.BatchNumber where InvNumber='" + invnum_Edit + "'");
            return dtb_BatchSale;
        }
        public DataTable load_prescription()
        {
            System.Data.DataTable dt_pre_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_patient.pt_name,tbl_patient.pt_id FROM tbl_prescription_main join tbl_patient on tbl_prescription_main.pt_id=tbl_patient.id where pay_status='Yes' AND tbl_prescription_main.date = '" + Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd") + "' ORDER BY tbl_prescription_main.date DESC");
            return dt_pre_main;
        }
        public DataTable docnumber()
        {
            DataTable Document_Number = db.table("SELECT max(cast(InvNumber as UNSIGNED)) As 'InvNumber' FROM tbl_SALES");
            return Document_Number;
        }
        public DataTable salesOrder_master(int invnum_order)
        {
            DataTable dtb_orderMaster = db.table("select * from tbl_SalesOrder_Master where DocNumber='" + invnum_order + "'");
            return dtb_orderMaster;
        }
        public DataTable order_itemsDtails(int invnum_order)
        {
            DataTable dtb_order = db.table("select s.DocNumber,s.DocDate,s.ItemCode as id ,s.Discription,s.Qty,s.Cost,s.TotalAmount,i.item_code,i.HSN_Number from tbl_SalesOrder s inner join tbl_ITEMS i on s.ItemCode=i.id where s.DocNumber='" + invnum_order + "'");
            return dtb_order;
        }
        public int Save_salesMaster(int DocNo,string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
         int i= db.execute("insert into tbl_SALES(InvNumber,InvDate,Dep_Number,SalesmanCode,OrderNumber,Orderdate,Prescribedby,LRNo,LRDate,Through,cust_number,cust_name,adr1,adr2,adr3,phone1,PayMethod," +
                               "Paid,Discount,UserName,JournalRefNo,SaleType,GST,IGST,TotalAmount)" +
                               "values('" + DocNo + "','" + Docdate + "','1','" + sales_ + "','" + ordeNo + "','" + Date_ + "'," +
                               "'" + doctor_ + "','" + lrno + "','" + lr_date + "','" + throuhg + "','" + ptid + "','" + ptname + "','" + street__ + "'," +
                               "'" + locality + "','" + city + "','" + phone + "','" + payMethod + "','" + totalAmnt + "','" + disount + "','1','1','1','" + Convert.ToDecimal(gst) + "','" + igst + "','" + gTotal + "')");
            return i;
        }
        public int Save_salesMaster_cheque(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod,string Bank ,string Number,decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
            int i = db.execute("insert into tbl_SALES(InvNumber,InvDate,Dep_Number,SalesmanCode,OrderNumber,Orderdate,Prescribedby,LRNo,LRDate,Through,cust_number,cust_name,adr1,adr2,adr3,phone1,PayMethod,Number,Bank," +
                                  "Paid,Discount,UserName,JournalRefNo,SaleType,GST,IGST,TotalAmount)" +
                                  "values('" + DocNo + "','" + Docdate + "','1','" + sales_ + "','" + ordeNo + "','" + Date_ + "'," +
                                  "'" + doctor_ + "','" + lrno + "','" + lr_date + "','" + throuhg + "','" + ptid + "','" + ptname + "','" + street__ + "'," +
                                  "'" + locality + "','" + city + "','" + phone + "','" + payMethod + "','" + Number + "','" + Bank + "','" + totalAmnt + "','" + disount + "','1','1','1','" + Convert.ToDecimal(gst) + "','" + igst + "','" + gTotal + "')");
            return i;
        }
        public int Save_salesMaster_card(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, string cardnumber, string fourdigitnumber, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
            int i = db.execute("insert into tbl_SALES(InvNumber,InvDate,Dep_Number,SalesmanCode,OrderNumber,Orderdate,Prescribedby,LRNo,LRDate,Through,cust_number,cust_name,adr1,adr2,adr3,phone1,PayMethod,cardnumber,fourdigitnumber," +
                                  "Paid,Discount,UserName,JournalRefNo,SaleType,GST,IGST,TotalAmount)" +
                                  "values('" + DocNo + "','" + Docdate + "','1','" + sales_ + "','" + ordeNo + "','" + Date_ + "'," +
                                  "'" + doctor_ + "','" + lrno + "','" + lr_date + "','" + throuhg + "','" + ptid + "','" + ptname + "','" + street__ + "'," +
                                  "'" + locality + "','" + city + "','" + phone + "','" + payMethod + "','" + cardnumber + "','" + fourdigitnumber + "','" + totalAmnt + "','" + disount + "','1','1','1','" + Convert.ToDecimal(gst) + "','" + igst + "','" + gTotal + "')");
            return i;
        }
        public int Save_salesMaster_DD(int DocNo, string Docdate, string sales_, string ordeNo, string Date_, string doctor_, string lrno, string lr_date, string throuhg, string ptid, string ptname, string street__, string locality, string city, string phone, string payMethod, string Bank, string DDnumber, decimal totalAmnt, decimal disount, decimal gst, decimal igst, decimal gTotal)
        {
            int i = db.execute("insert into tbl_SALES(InvNumber,InvDate,Dep_Number,SalesmanCode,OrderNumber,Orderdate,Prescribedby,LRNo,LRDate,Through,cust_number,cust_name,adr1,adr2,adr3,phone1,PayMethod,Bank,DDnumber," +
                                  "Paid,Discount,UserName,JournalRefNo,SaleType,GST,IGST,TotalAmount)" +
                                  "values('" + DocNo + "','" + Docdate + "','1','" + sales_ + "','" + ordeNo + "','" + Date_ + "'," +
                                  "'" + doctor_ + "','" + lrno + "','" + lr_date + "','" + throuhg + "','" + ptid + "','" + ptname + "','" + street__ + "'," +
                                  "'" + locality + "','" + city + "','" + phone + "','" + payMethod + "','" + Bank + "','" + DDnumber + "','" + totalAmnt + "','" + disount + "','1','1','1','" + Convert.ToDecimal(gst) + "','" + igst + "','" + gTotal + "')");
            return i;
        }
        public DataTable get_costbase(string itemcode)
        {
            DataTable dt_Unit2 = db.table("select Unit2,UnitMF,CostBase from tbl_ITEMS where item_code='" + itemcode + "' ");
            return dt_Unit2;
        }
        public int  Save_itemdetails(int DocNo,  string Docdate, string Item_Code, string Description, string Packing, string Unit, decimal GST, decimal IGST, int Qty, int FreeQty,decimal Rate, decimal TotalAmount, string UNIT2, decimal UnitMF, decimal CostBase)
        {
            int j = db.execute("insert into tbl_SALEIT (InvNumber,InvDate,Item_Code,Description,Packing,Unit,GST,IGST,Qty,FreeQty,Rate,TotalAmount,UNIT2,UnitMF,CostBase,Taxable,RetQty) values('" + DocNo + "','" + Docdate + "','" + Item_Code + "','" + Description + "'," +
                             "'" + Packing + "','" + Unit + "','" + GST + "','" + IGST + "','" + Qty + "'," + "'" + FreeQty + "','" + Rate + "','" + TotalAmount + "','" + UNIT2 + "','" + UnitMF + "','" + CostBase + "','Yes','0')");
            return j;
        }
        public void update_batchnumber(decimal currentStock,string BatchEntry)
        {
            db.execute("update tbl_BatchNumber set Qty='" +currentStock + "' where  Entry_No='" + BatchEntry + "'");
        }
        public void save_batchsale(int InvNumber, string InvDate, string Item_Code, string BatchNumber, decimal Qty, string BatchEntry)
        {
            db.execute("insert into tbl_BatchSale (InvNumber,InvDate,Item_Code,BatchNumber,Qty,IsExpDate,BatchEntry,WsInv,RetQty) values('" + InvNumber + "','" + InvDate + "','" + Item_Code + "','" + BatchNumber + "','" + Qty + "','True','" + BatchEntry + "','1',0)");
        }
        public void update_salesorder(string invnum_order)
        {
            db.execute("update tbl_SalesOrder_Master set Status='S' where DocNumber='" + invnum_order + "'");
        }
        public DataTable Get_companydetails()
        {
          DataTable dtp = db.table("select name,contact_no,street_address,path,email,website,Dl_Number,Dl_Number2  from tbl_practice_details");
            return dtp;
        }
        public DataTable prescription_main(string PrescritionMain_id)
        {
            System.Data.DataTable dt_prescriptionDetails = db.table("SELECT  tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_patient.pt_name,tbl_patient.id,tbl_patient.pt_id   FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id join tbl_patient on tbl_prescription_main.pt_id=tbl_patient.id  where tbl_prescription_main.id='" + PrescritionMain_id + "' ");
            return dt_prescriptionDetails;
        }
        public DataTable prescription_dteails(string PrescritionMain_id)
        {
            System.Data.DataTable dt_drugDetails = db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,drug_id FROM tbl_prescription WHERE pres_id='" + PrescritionMain_id + "' ORDER BY id");
            return dt_drugDetails;
        }
        public DataTable get_inventoryid(string drug_id)
        {
            System.Data.DataTable dt_drug_inv_Details = db.table("SELECT id,inventory_id,name FROM tbl_adddrug WHERE id='" +drug_id + "'  and inventory_id<>'0' ORDER BY id");
            return dt_drug_inv_Details;
        }
        public DataTable Get_itemdetails(string inventory_id)
        {
            DataTable dtb = db.table(" select i.id,i.Sales_Rate_Max,i.Packing,i.Unit1,i.Unit2,i.OneUnitOnly,p.GST,p.IGST,i.item_name,i.item_code,i.OneUnitOnly,i.Unit1,i.Unit2 from tbl_ITEMS i inner join tbl_PURCHIT p on p.Item_Code = i.id where i.id='" +inventory_id + "'");
            return dtb;
        }
        public DataTable get_batchdetails(string item_Code)
        {
            DataTable dtb = db.table("select Entry_No,BatchNumber,Qty,cast(PrdDate as date) PrdDate,cast(ExpDate as date) ExpDate, Unit2,UnitMF from tbl_BatchNumber where Item_Code='" + item_Code + "'and Qty>0  order by ExpDate");
            return dtb;
        }
        //sales list
        public DataTable get_salesDetails(string dateTo, string dateFrom)
        {
            DataTable dt = db.table("select InvNumber,cast(InvDate as date) 'InvDate' ,cust_name,cust_number,phone1,Paid,TotalAmount,PayMethod from tbl_SALES where InvDate between '" + Convert.ToDateTime(dateTo).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(dateFrom).ToString("yyyy-MM-dd") + "'");
            return dt;
        }
        public DataTable invDetailsbyDate(string date)
        {
            DataTable dtb = db.table("select InvNumber,cast(InvDate as date) 'InvDate' ,cust_name,cust_number,phone1,Paid,TotalAmount,PayMethod from tbl_SALES where InvDate='" + date + "'");
            return dtb;
        }
        public DataTable invDetailsbyDateBtwn(string from, string to)
        {
            DataTable dt = db.table("select InvNumber,InvDate,cust_name,cust_number,phone1,Paid,TotalAmount,PayMethod from tbl_SALES where InvDate between '" + from + "' and '" + to + "' and PayMethod='Cash Sale'");
            return dt;
        }
        public DataTable InvDetailsBtwnDates(string from, string to)
        {
            DataTable dt = db.table("select InvNumber,InvDate,cust_name,cust_number,phone1,Paid,TotalAmount,PayMethod from tbl_SALES where InvDate between '" + from + "' and '" + to + "' and PayMethod='Credit Sale'");
            return dt;
        }
        public DataTable data_from_sales(string dt)
        {
            DataTable data_from_sales = db.table("select Invdate,  FORMAT(SUM(Qty * Rate),2) total ,GST from tbl_saleit where InvNumber='" + dt + "' GROUP BY GST order by GST");
            return data_from_sales;
        }
        public DataTable data_from_sales_igst(string dt)
        {
            DataTable data_from_sales_igst = db.table("select Invdate,  FORMAT(SUM(Qty * Rate),2) total ,igst from tbl_saleit where InvNumber='" + dt + "'and igst<>0 GROUP BY IGST order by IGST");
            return data_from_sales_igst;
        }
        public DataTable get_doctor(string doctor_id)
        {
            System.Data.DataTable tb_doctor = db.table("select id,doctor_name from tbl_doctor where (login_type='doctor' or login_type='admin') and activate_login='yes'and  id='" + doctor_id + "'");
            return tb_doctor;
        }
    } 
}
 