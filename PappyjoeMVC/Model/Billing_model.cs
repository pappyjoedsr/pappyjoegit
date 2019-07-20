 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Model
{
    public class Billing_model
    {
        Connection db = new Connection();

        private string _taxname;
        private string _tax;

        public string TaxName
        {
            get { return _taxname; }
            set { _taxname = value; }
        }

        public string Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }
    }
}
