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
        Connection db = new Connection();
        contact_model mdl = new contact_model();
        contact_interface intr;
        public contact_controller(contact_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
       
        public int Save()
        {
            mdl.ContactName = intr.Contact_Name;
            int i = mdl.Save_data();
            return i;
        }
        public void FillGrid()
        {
            DataTable dtb = mdl.FillGrid();
            intr.Fill_ContactGrid(dtb);
        }
        public int Update(string id)
        {
            mdl.ContactName = intr.Contact_Name;
            int i = mdl.Update_data(id);
            return i;
        }
        public int Delete_data(string id)
        {
            int i = mdl.Delete_data(id);
            return i;
        }
        public void search(string name)
        {
            DataTable dtb = mdl.search(name);
            intr.Fill_ContactGrid(dtb);
        }
    }
}
