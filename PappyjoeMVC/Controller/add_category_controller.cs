using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Add_Category_controller
    {
       
        Add_Category_model _model = new Add_Category_model();
        public DataTable Load_data()
        {
            DataTable dtb = _model.Load_data();
            return dtb;
        }
        public DataTable get_details(string id)
        {
            DataTable dtb = _model.get_details(id);
            return dtb;
        }
        public int delete(string id)
        {
            int i = _model.delete(id);
            return i;
        }
        public DataTable Get_catdetails(string name, string number)
        {
            DataTable dtb = _model.Get_catdetails(name, number);
            return dtb;
        }
        public void save(string Name, string Cat_Number, string Description)
        {
            _model.save( Name,  Cat_Number,  Description);
        }
        public void update(string Name, string Cat_Number, string Description,string id)
        {
            _model.update( Name,  Cat_Number, Description,id);
        }
    }
}
