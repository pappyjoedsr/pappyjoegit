using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
   public  interface communication_setting_interface
    {
        string SMSUName { get; set; }
        string SMSPassword { get; set; }
        string EmailUNAme { get; set; }
        string EmailPassword { get; set; }
        void SetController(communication_setting_controller controller);
    }
}
