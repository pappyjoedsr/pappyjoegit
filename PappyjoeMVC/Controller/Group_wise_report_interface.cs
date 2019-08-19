using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Group_wise_report_interface
    {
        void setcontroller(Group_wise_report_controller controller);
        void Patients(DataTable dtb);
        void Procedure(DataTable dtb);
        void Invoice(DataTable dtb);
        void Receipt(DataTable dtb);
    }
}
