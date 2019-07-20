using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface Staff_Interface
    {
        //string State { get; set; }
        void SetController(Staff_controller controller);
        void FillStaffGrid(DataTable dtb);
        void GetDctrDetails(DataTable dtb);
        void GetNotificationData(DataTable dtb);
        //staff
        //staff
        string SName { get; set; }
        string Type { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string MobileNumber { get; set; }
        string EmailId { get; set; }
        string Registration { get; set; }
        string CalendrColor { get; set; }
        string ActivateLogin { get; set; }

    }
}
