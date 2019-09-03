using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface invoice_interface
    {
        void Setcontroller(Invoice_controller controller);
        void Load_MainTable(DataTable dtb);
        void set_totalPayment(DataTable dtb);
    }
}
