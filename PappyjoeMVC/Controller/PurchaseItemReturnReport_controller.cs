﻿using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class PurchaseItemReturnReport_controller
    {
        Purchase_Report_model mdl = new Purchase_Report_model();
        Daily_Invoice_Report_model dm = new Daily_Invoice_Report_model();
        public DataTable purchitemreturn(string purchretrnno)
        {
            DataTable dt = mdl.purchitemreturn(purchretrnno);
            return dt;
        }
        public DataTable slctitems(string itmcode)
        {
            DataTable dt = mdl.slctitems(itmcode);
            return dt;
        }
        public DataTable practicedetails()
        {
            DataTable dt = dm.practicedetails();
            return dt;
        }
    }
}
