using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface calender_interface
    {
        void SetController(calender_controller controller);
        void FormLoad(DataTable dt);

    }
}
