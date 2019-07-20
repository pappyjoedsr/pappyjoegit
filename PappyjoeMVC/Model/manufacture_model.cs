using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
   public class manufacture_model
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
        private string _shrtname;
        public string Shortname
        {
            get { return _shrtname; }
            set { _shrtname = value; }
        }
        //private string _number;
        //public string Number
        //{
        //    get { return _number; }
        //    set { _number = value; }
        //}
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
        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
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
        public DataTable Load_grid()
        {
            DataTable dtb = db.table("select id,Code,manufacturer,ShortName from tbl_manufacturer order by id");
            return dtb;
        }
        public int Save()
        {
           int i = db.execute("insert into tbl_manufacturer (manufacturer,Code,ShortName,Address1,Address2,Address3,Phone,fax,Contact_Name,Email,Web,Current_Balance,OpeningBalance) values('" + _name + "','" + _code + "','" + _shrtname + "','" + _address1 + "','" +_address2 + "','" + _address3 + "','" + _phone+ "','" + _fax+ "','" +_Cname + "','" + _email+ "','" + _web + "','0.00','0.00')");
            return i;
        }
        public int update(string id)
        {
          int i = db.execute("update tbl_manufacturer set manufacturer='" + _name + "',Code='" + _code + "',ShortName='" + _shrtname + "',Address1='" + _address1 + "',Address2='" + _address2 + "',Address3='" + _address3 + "',Phone='" + _phone+ "',fax='" + _fax + "',Contact_Name='" + _Cname+ "',Email='" +_email + "',Web='" + _web + "' where id='" + id + "'");
          return i;
        }
        public DataTable get_manufacture(string id)
        {
            DataTable dtb = db.table("select manufacturer,Code,ShortName,Address1,Address2,Address3,Phone,fax,Contact_Name,Email,Web from tbl_manufacturer where id='" + id + "' order by id");
            return dtb;
        }
        public int delete(string id)
        {
            int i = db.execute("DELETE FROM tbl_manufacturer WHERE id='" + id + "'");
            return i;
        }
    }
}
