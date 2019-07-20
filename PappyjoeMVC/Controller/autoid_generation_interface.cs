using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface autoid_generation_interface
    {
        string PtNumber { get; set; }
        string ptPrefix { get; set; }
        string InvNumber { get; set; }
        string InvPrefix { get; set; }
        string ReciptNumber { get; set; }
        string ReciptPrefix { get; set; }
        void SetController(autoid_generation_controller controller);
        void LoadPatientId(DataTable dtb);
        void LoadInvoiceId(DataTable dtb);
        void LoadReceiptId(DataTable dtb);
    }
}
