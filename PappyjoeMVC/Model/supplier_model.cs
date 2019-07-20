using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
  public class supplier_model
    {
        Connection db = new Connection();
        private string _code;
        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
       
        private string _Cname;
        public string CName
        {
            get { return _Cname; }
            set { _Cname = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _web;
        public string Web
        {
            get { return _web; }
            set { _web = value; }
        }
        private string _phone2;
        public string Phone2
        {
            get { return _phone2; }
            set { _phone2 = value; }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _address1;
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        private string _address2;
        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        private string _address3;
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }
        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _balance;
        public string Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public DataTable Document_number()
        {
            DataTable supplier_Count = db.table("SELECT max(Supplier_Code) As Supplier_Code FROM tbl_Supplier");
            return supplier_Count;
        }
        public  DataTable load_grid()
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
        public int save()
        {
          int i=db.execute("insert into tbl_Supplier(Supplier_Code,Supplier_Name,Contact_Person,Phone1,Phone2,Email,Fax,Web,Address1,Address2,Address3,Current_Balance,Opeinig_Balance,EntryNo)Values('" +_code + "','" + _name + "','" + _Cname + "','" + _phone + "','" + _phone2+ "','" + _email + "','" + _fax + "','" +_web + "','" + _address1+ "','" + _address2 + "','" + _address3 + "','100','" + Convert.ToDecimal(_balance) + "','')");
            return i;
        }
        public int update(string id)
        {
          int i= db.execute("update tbl_Supplier set Supplier_Name='" + _name + "',Contact_Person='" + _Cname + "',Phone1='" +_phone + "',Phone2='" + _phone2 + "',Email='" + _email + "',Fax='" + _fax + "',Web='" + _web + "',Address1='" + _address1 + "',Address2='" + Address2 + "',Address3='" + Address3 + "',Current_Balance='100',Opeinig_Balance='" + Convert.ToDecimal(_balance) + "',EntryNo='' where Supplier_Code='" + id + "'");
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
