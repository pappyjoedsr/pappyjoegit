using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface add_category_interface
    {
         string Number { get; set; }
        string Name { get; set; }
        string Decsription { get; set; }
        void SetController(Add_Category_controller controller);
        void Load_Data(DataTable dtb);
    }
}
