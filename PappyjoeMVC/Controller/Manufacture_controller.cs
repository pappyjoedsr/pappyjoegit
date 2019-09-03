using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
  public  class Manufacture_controller
    {
        Manufacture_model _model = new Manufacture_model();
        public DataTable Load_grid()
        {
            DataTable dtb = _model.Load_grid();
            return dtb;
        }
        public int Save(string _name, string _code, string _shrtname, string _address1, string _address2, string _address3, string _phone, string string_fax, string Cname, string _email, string _web)
        {
            int i = _model.Save( _name,  _code,  _shrtname,  _address1,  _address2,  _address3,  _phone,  string_fax,  Cname,  _email,  _web);
            return i;
        }
        public int update(string id, string _name, string _code, string _shrtname, string _address1, string _address2, string _address3, string _phone, string string_fax, string Cname, string _email, string _web)
        {
            int i = _model.update(id, _name, _code, _shrtname, _address1, _address2, _address3, _phone, string_fax, Cname, _email, _web);
            return i;
        }
        public DataTable get_manufacture(string id)
        {
            DataTable dtb = _model.get_manufacture(id);
            return dtb;
        }
        public int delete(string id)
        {
            int i = _model.delete(id);
            return i;
        }
    }
}
