using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Medical_History_controller
    {
        Medical_history_model _model = new Medical_history_model();
        public DataTable Check_medical(string name)
        {
            DataTable dtb = _model.Check_medical(name);
            return dtb;
        }
        public int save_medical(string medical)
        {
            int i = _model.save_medical(medical);
            return i;
        }
        public DataTable load_medical()
        {
            DataTable dtb = _model.load_medical();
            return dtb;
        }
        public void update_medical(string id, string medical)
        {
            _model.update_medical(id, medical);
        }
        public void delete_medical(string id)
        {
            _model.delete_medical(id);
        }
        public DataTable seaerh_medical(string name)
        {
            DataTable dtb = _model.seaerh_medical(name);
            return dtb;
        }
        //group
        public DataTable Load_Group()
        {
            DataTable dtb = _model.Load_Group();
            return dtb;
        }
        public DataTable check_groupname(string name)
        {
            DataTable dt = _model.check_groupname(name);
            return dt;
        }
        public int save_group(string group)
        {
            int i = _model.save_group(group);
            return i;
        }
        public int update_group(string id, string group)
        {
            int i = _model.update_group(id, group);
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
