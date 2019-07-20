using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public interface prescription_setting_interface
    {
        string StrType { get; set; }
        string StrUnit { get; set; }
        string DrugName { get; set; }
        string Strength_gr { get; set; }
        string Instruction { get; set; }
        //string StrUnit { get; set; }
        void SetController(prescription_setting_controller controller);
        void FillTypeCombo(DataTable dtb);
        void FillUnitCombo(DataTable dtb);
        void SaveDrugType(DataTable dtb);
        void CheckUnit(DataTable dtb);
    }
}
