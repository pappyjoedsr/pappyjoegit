using PappyjoeMVC.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class NetworkBrowser_controller
    {
        NetworkBrowser_model mdl = new NetworkBrowser_model();
        public ArrayList getNetworkComputers()
        {
            ArrayList networkComputers = new ArrayList();
            networkComputers = mdl.getNetworkComputers();
            return networkComputers;
        }
    }
}
