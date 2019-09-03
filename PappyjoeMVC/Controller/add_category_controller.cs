using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
  public class Add_Category_controller
    {
        add_category_interface intr;
        add_category_model _model = new add_category_model();
        public Add_Category_controller(add_category_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        } 
        public void Load_data()
        {
            DataTable dtb = _model.Load_data();
            intr.Load_Data(dtb);
        }
        public DataTable get_details(string id)
        {
            DataTable dtb = _model.get_details(id);
            return dtb;
        }
        public int delete(string id)
        {
           int i=_model.delete(id);
            return i;
        }
        public DataTable Get_catdetails(string name,string number)
        {
            DataTable dtb = _model.Get_catdetails(name,number);
            return dtb;
        }
        public void save()
        {
            _model.Name = intr.Name;
            _model.Number = intr.Number;
            _model.Description = intr.Decsription;
            _model.save();
        }
        public void update(string id)
        {
            _model.Name = intr.Name;
            _model.Number = intr.Number;
            _model.Description = intr.Decsription;
            _model.update(id);
        }
    }
}
