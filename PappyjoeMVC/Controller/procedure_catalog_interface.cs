using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface procedure_catalog_interface
    {
        string ProcedureName { get; set; }
        string ProcedCost { get; set; }
        string Notes { get; set; }
        string ComboCategory { get; set; }
        string TextCategory { get; set; }
        void SetController(procedure_catalog_controller controller);
        void FormLoad(DataTable dtb);
        void AddCategory(DataTable dtb);
        void GetProcedureName(DataTable dt);
    }
}
