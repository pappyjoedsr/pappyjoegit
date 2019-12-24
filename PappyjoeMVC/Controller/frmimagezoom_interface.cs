using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public interface frmimagezoom_interface
    {
        int attachid { get; set; }
        void attach(DataTable dt);
        void setController(frmimagezoom_controller controller);
    }
}
