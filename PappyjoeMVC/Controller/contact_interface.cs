using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;


namespace PappyjoeMVC.Controller
{
    public interface contact_interface
    {
        string Contact_Name { get; set; }
        void SetController(contact_controller controller);
        void Fill_ContactGrid(DataTable dtb);

    }
}
