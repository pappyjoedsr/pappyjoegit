using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Billing_Interface
    {
        string Taxname { get; set; }
        string Tax { get; set; }

        void SetController(Billing_controller controller);
        void FillBillGrid(DataTable dtb  );
    }
}
