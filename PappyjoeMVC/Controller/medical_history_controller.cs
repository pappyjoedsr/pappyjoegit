using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
  public class medical_history_controller
    {
        medical_history_model _model = new medical_history_model();
        medical_history_interface intr;
        public medical_history_controller(medical_history_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }

        public DataTable Check_medical(string name)
        {
            DataTable dtb = _model.Check_medical(name);
            return dtb;
        }
        public int save_medical()
        {
            _model.Medical = intr.medical;
            int i = _model.save_medical();
            return i;
        }
        public void load_medical()
        {
            DataTable dtb = _model.load_medical();
            intr.LoadMedical(dtb);
        }
        public void update_medical(string id)
        {
            _model.Medical = intr.medical;
            _model.update_medical(id);
        }
        public void delete_medical(string id)
        {
            _model.delete_medical(id);
        }
        public void seaerh_medical(string name)
        {
            DataTable dtb = _model.seaerh_medical(name);
            intr.LoadMedical(dtb);
        }
        //group
        public void Load_Group()
        {
            DataTable dtb = _model.Load_Group();
            intr.LoadGroup(dtb);
        }
        public DataTable check_groupname(string name)
        {
            DataTable dt = _model.check_groupname(name);
            return dt;
        }
        public int save_group()
        {
            _model.Group = intr.group;
            int i = _model.save_group();
            return i;
        }
        public int update_group(string id)
        {
            _model.Group = intr.group;
            int i= _model.update_group(id);
            return i;
        }
        public DataTable exsists_ptgroup(string name)
        {
            DataTable dtb = this._model.exsists_ptgroup(name);
            return dtb; 
        }
        public void delete_group(string name)
        {
            _model.delete_group(name);
        }
    }
}
