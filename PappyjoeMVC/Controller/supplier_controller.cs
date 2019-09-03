using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
   public class supplier_controller
    {
        supplier_model _model = new supplier_model();
        public string Document_number()
        {
            string dtb = _model.Document_number();
            return dtb;
        }
        public DataTable load_grid()
        {
            DataTable dtb = _model.load_grid();
            return dtb;
        }
        public DataTable get_suppliername(string name)
        {
            DataTable dtb = _model.get_suppliername(name);
            return dtb;
        }
        public DataTable get_suplier_phone(string name)
        {
            DataTable dtb =_model. get_suplier_phone(name);
            return dtb;
        }
        public int Save(string _code, string _name, string _Cname, string _phone, string _phone2, string _email, string _fax, string _web, string _address1, string _address2, string _address3, string _balance)
        {
            int i = _model.save( _code,  _name,  _Cname,  _phone,  _phone2,  _email,  _fax,  _web,  _address1,  _address2,  _address3,  _balance);
            return i;
        }
        public int update(string id, string _code, string _name, string _Cname, string _phone, string _phone2, string _email, string _fax, string _web, string _address1, string _address2, string _address3, string _balance)
        {
            int i = _model.update(id,_code, _name, _Cname, _phone, _phone2, _email, _fax, _web, _address1, _address2, _address3, _balance);
            return i;
        }
        public DataTable Get_suplierDetails(string id)
        {
            DataTable dtb = _model.Get_suplierDetails(id);
            return dtb;
        }
        public int delete(string id)
        {
            int i = _model.delete(id);
            return i;
        }
    }
}
