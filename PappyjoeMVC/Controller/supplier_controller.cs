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
        supplier_interface intr;
        supplier_model _model = new supplier_model();
        public supplier_controller(supplier_interface inttr)
        {
            intr = inttr;
            intr.Setcontroller(this);
        }
        public void Document_number()
        {
            DataTable dtb = _model.Document_number();
            intr.DocumentNumber(dtb);
        }

        public void load_grid()
        {
            DataTable dtb = _model.load_grid();
            intr.LoadGrid(dtb);
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
        public int Save()
        {
            get_datas();
            int i = _model.save();
            return i;
        }
        public void get_datas()
        {
            _model.Code = intr.Code;
            _model.Name = intr.Name;
            _model.CName = intr.CName;
            _model.Email = intr.Email;
            _model.Phone = intr.Phone;
            _model.Phone2 = intr.Phone2;
            _model.Web = intr.Web;
            _model.Fax = intr.Fax;
            _model.Address1 = intr.Address1;
            _model.Address2 = intr.Address2;
            _model.Address3 = intr.Address3;
            _model.Balance = intr.Balance;
        }
        public int update(string id)
        {
            get_datas();
            int i = _model.update(id);
            return i;
        }
        public void Get_suplierDetails(string id)
        {
            DataTable dtb = _model.Get_suplierDetails(id);
            intr.Fill_SuplierDetails(dtb);
        }
        public int delete(string id)
        {
            int i = _model.delete(id);
            return i;
        }
    }
}
