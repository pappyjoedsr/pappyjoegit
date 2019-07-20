using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface Reports_interface
    {
        void setcontroller(Reports_controller controller);
        void Load_invoiceReport(DataTable dtb);
        void Load_recieptReport(DataTable dtb);
        void Load_appointmentReport(DataTable dtb);
        void Load_patientReport(DataTable invMain);
        void Load_EMRReport(DataTable invMain);
        void Load_expenseReport(DataTable dt_pt);
        void Load_inventoryReport(DataTable dt_stock);
    }
}
