using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface patients_interface
    {
       void Setcontroller(Patients_controller controller);
        void Create_Datagrid(DataTable dtb);
        void Load_Group(DataTable dtb);
        void Appointment_Data(DataTable dtb);
        void VitalSigns(DataTable dtb);
        void ClinicFindings(DataTable dtb);
        void TreatmentPlan(DataTable dtb);
        void FinishedProcedure(DataTable dtb);
        void Prescription(DataTable dtb);
        void Invoice(DataTable dtb);
        void Payments(DataTable dtb);
    }
}
