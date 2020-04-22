using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    class Backup_and_Restore_controller
    {
        Connection db = new Connection();
        public void backupdb(string file)
        {
            db.backupdb(file);
        }
        public void restoredb(string file)
        {
            db.restoredb(file);
        }
    }
}
