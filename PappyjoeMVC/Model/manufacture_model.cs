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
        public DataTable Load_grid()
        {
            DataTable dtb = db.table("select id,Code,manufacturer,ShortName from tbl_manufacturer order by id");
            return dtb;
        }
        public int Save(string _name , string _code , string _shrtname , string _address1 , string _address2 , string _address3 , string _phone, string _fax, string _Cname , string _email, string _web )
        {
           int i = db.execute("insert into tbl_manufacturer (manufacturer,Code,ShortName,Address1,Address2,Address3,Phone,fax,Contact_Name,Email,Web,Current_Balance,OpeningBalance) values('" + _name + "','" + _code + "','" + _shrtname + "','" + _address1 + "','" +_address2 + "','" + _address3 + "','" + _phone+ "','" + _fax+ "','" +_Cname + "','" + _email+ "','" + _web + "','0.00','0.00')");
            return i;
        }
        public int update(string id, string _name, string _code, string _shrtname, string _address1, string _address2, string _address3, string _phone, string _fax, string _Cname, string _email, string _web)
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
