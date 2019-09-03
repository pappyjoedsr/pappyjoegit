using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface addfinsed_treatment_interface
    {
       string Procedure { get; set; }
        decimal Procedure_cost { get; set; }
        string Search { get; set; }
        void SetController(Addfinsed_Treatment_controller controller);
        void Load_finishedtreatments(DataTable dtb);
        void load_proceduresgrid(DataTable dtb);
        void Load_TreatmentPlans(DataTable dtb);
    }
}
