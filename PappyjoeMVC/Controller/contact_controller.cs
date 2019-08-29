using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using PappyjoeMVC.View;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public  class contact_controller
    {
        contact_model mdl = new contact_model();
        public int Save(string Contact_Name)
        {
            int i = mdl.Save_data(Contact_Name);
            return i;
        }
        public DataTable FillGrid()
        {
            DataTable dtb = mdl.FillGrid();
            return dtb;
        }
        public int Update(string id, string Contact_Name)
        {
            int i = mdl.Update_data(id, Contact_Name);
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
