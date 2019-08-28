using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public interface EMR_Interface
    {
        void SetController(EMR_controller controller);
        //complaints
        string Complaints { get; set; }
        void FillGrid(DataTable dtb);
        //observation
        void FillObservationGrid(DataTable dtb);
        string Observation { get; set; }
        //Diagnosis
        string Diagnosis { get; set; }
        void FiiDiagnosisGrid(DataTable dtb);
        //Investigation
        void FillInvsetgation(DataTable stb);
        string Investgation { get; set; }
        //notes
        void FillNotes(DataTable dtb);
        string Note { get; set; }
    }
}
