using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Image_Zoom_controller
    {
        Connection db = new Connection();
        Attachments_model mdl = new Attachments_model();
        public string getserver()
        {
            string server = db.server();
            return server;
        }
        public DataTable attach(int attachid)
        {
            DataTable dt = mdl.attach(attachid);
            return dt;
        }
    }
}
