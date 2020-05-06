using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Contact_controller
    {
        Contact_model mdl = new Contact_model();
        public int Save(string Contact_Name,string Mobno,string notes)
        {
            int i = mdl.Save_data(Contact_Name,Mobno,notes);
            return i;
        }
        public DataTable FillGrid()
        {
            DataTable dtb = mdl.FillGrid();
            return dtb;
        }
        public int Update(string id, string Contact_Name,string Mobno,string notes)
        {
            int i = mdl.Update_data(id, Contact_Name,Mobno,notes);
            return i;
        }
        public int Delete_data(string id)
        {
            int i = mdl.Delete_data(id);
            return i;
        }
        public DataTable search(string name)
        {
            DataTable dtb = mdl.search(name);
            return dtb;
        }
    }
}
