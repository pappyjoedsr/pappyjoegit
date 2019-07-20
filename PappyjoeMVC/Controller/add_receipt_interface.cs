using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface add_receipt_interface
    {
        void SetController(add_receipt_controller controller);
        void LoadGrid_status0(DataTable dtb);
        //void Load_DGV_MainGrid(DataTable dtb);
    }
}
