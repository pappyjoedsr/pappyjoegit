using PappyjoeMVC.Model;
using System.Data;

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
