using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface Add_invoice_interface
    {
        void SetController(Add_Invoice_controller controller);
        void Load_procedureGrid(DataTable dtb);
        void load_invoice_details(DataTable dtb);
        void Load_planed_procedure(DataTable dtb);
        void Load_searchProcedures(DataTable dtb);
        void Fill_Alltreatment_deatils(DataTable dtb);
    }
}
