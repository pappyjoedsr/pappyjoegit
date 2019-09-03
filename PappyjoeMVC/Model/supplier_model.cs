using System;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class Supplier_model
    {
        Connection db = new Connection();
        public string Document_number()
        {
            string supplier_Count = db.scalar("SELECT max(Supplier_Code) As Supplier_Code FROM tbl_Supplier");
            return supplier_Count;
        }
        public DataTable load_grid()
        {
            DataTable dt = db.table("Select Supplier_Code,Supplier_Name from tbl_Supplier order by Supplier_Code");
            return dt;
        }
        public DataTable get_suppliername(string name)
        {
            DataTable suppler_Name = db.table("SELECT * from tbl_Supplier where Supplier_Name='" + name + "'");
            return suppler_Name;
        }
        public DataTable get_suplier_phone(string phone)
        {
            DataTable Supplier_No = db.table("SELECT * from tbl_Supplier where Phone1='" + phone + "'");
            return Supplier_No;
        }
        public int save(string _code, string _name, string _Cname, string _phone, string _phone2, string _email, string _fax, string _web, string _address1, string _address2, string _address3, string _balance)
        {
            int i = db.execute("insert into tbl_Supplier(Supplier_Code,Supplier_Name,Contact_Person,Phone1,Phone2,Email,Fax,Web,Address1,Address2,Address3,Current_Balance,Opeinig_Balance,EntryNo)Values('" + _code + "','" + _name + "','" + _Cname + "','" + _phone + "','" + _phone2 + "','" + _email + "','" + _fax + "','" + _web + "','" + _address1 + "','" + _address2 + "','" + _address3 + "','100','" + Convert.ToDecimal(_balance) + "','')");
            return i;
        }
        public int update(string id, string _code, string _name, string _Cname, string _phone, string _phone2, string _email, string _fax, string _web, string _address1, string _address2, string _address3, string _balance)
        {
            int i = db.execute("update tbl_Supplier set Supplier_Name='" + _name + "',Contact_Person='" + _Cname + "',Phone1='" + _phone + "',Phone2='" + _phone2 + "',Email='" + _email + "',Fax='" + _fax + "',Web='" + _web + "',Address1='" + _address1 + "',Address2='" + _address2 + "',Address3='" + _address3 + "',Current_Balance='100',Opeinig_Balance='" + Convert.ToDecimal(_balance) + "',EntryNo='' where Supplier_Code='" + id + "'");
            return i;
        }
        public DataTable Get_suplierDetails(string id)
        {
            DataTable dt = db.table("Select Supplier_Code,Supplier_Name,Contact_Person,Phone1,Phone2,Email,Fax,Web,Address1,Address2,Address3,Opeinig_Balance from tbl_Supplier where Supplier_Code='" + id + "'");
            return dt;
        }
        public int delete(string id)
        {
            int d = db.execute("delete from tbl_Supplier where Supplier_Code='" + id + "'");
            return d;
        }
    }
}
