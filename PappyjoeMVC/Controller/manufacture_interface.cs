using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface manufacture_interface
    {
        string Code { get; set; }
        string Name { get; set; }
        string Shortname { get; set; }
        //string Number { get; set; }
        string CName { get; set; }
        string Email { get; set; }
        string Web { get; set; }
        string Fax { get; set; }
        string Phone { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string Address3 { get; set; }
        void SetController(Manufacture_controller controller);
        void Fill_grid(DataTable dtb);
    }
}
