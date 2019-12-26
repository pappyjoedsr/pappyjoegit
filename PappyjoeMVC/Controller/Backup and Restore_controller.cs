using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Backup_and_Restore_controller
    {
        Connection db = new Connection();
        public void backupdb(string file)
        {
            //db.backupdb(file);
        }
        public void restoredb(string file)
        {
            //db.restoredb(file);
        }
    }
}
