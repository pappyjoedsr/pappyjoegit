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
        manufacture_interface intr;
        manufacture_model _model = new manufacture_model();
        public Manufacture_controller(manufacture_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public void Load_grid()
        {
            DataTable dtb = _model.Load_grid();
            intr.Fill_grid(dtb);
        }
        public int Save()
        {
            Put_datas();
            int i = _model.Save();
            return i;
        }
        public void Put_datas()
        {
            _model.Code = intr.Code;
            _model.Name = intr.Name;
            _model.Shortname = intr.Shortname;
            _model.CName = intr.CName;
            _model.Email = intr.Email;
            _model.Web = intr.Web;
            _model.Fax = intr.Fax;
            _model.Phone = intr.Phone;
            _model.Address1 = intr.Address1;
            _model.Address2 = intr.Address2;
            _model.Address3 = intr.Address3;
        }
        public int update(string id)
        {
            Put_datas();
            int i = _model.update(id);
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
