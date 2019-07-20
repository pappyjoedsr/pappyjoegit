using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface ClinicalNotesAdd_interface
    {
        string Investigation { get; set; }
        string Diagnosis { get; set; }
        string Complaints { get; set; }
        string Notes { get; set; }
        string Observation { get; set; }
        void setcontroller(ClinicalNotesAdd_controller controller);
    }
}
