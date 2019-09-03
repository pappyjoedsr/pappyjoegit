using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface login_interface
    {
        string Username { get; set; }
        string Password { get; set; }

        void setcontroller(Login_controller controller);

        void Load_Login(DataTable dtb);
    }
}
