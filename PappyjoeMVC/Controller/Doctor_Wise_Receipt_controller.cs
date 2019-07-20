﻿using PappyjoeMVC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PappyjoeMVC.Controller
{
    public class Doctor_Wise_Receipt_controller
    {
       Doctor_Wise_Receipt_interface intr;
       common_model cmdl = new common_model();
       Daily_Invoice_Report_model mdl=new Daily_Invoice_Report_model();
       public Doctor_Wise_Receipt_controller(Doctor_Wise_Receipt_interface inttr)
        {
            intr = inttr;
            intr.setController(this);
        }
       public void getdocname()
       {
           DataTable dt = mdl.getdocname();
           intr.getdocname(dt);
       }
       public void getdocid(string drname)
       {
           string e= mdl.getdocid(drname);
           intr.getdocid(e);
       }
       public void getinvdata(string invno, string service)
       {
           DataTable dt = mdl.getinvdata(invno,service);
           intr.getinvdata(dt);
       }
       public void mnthrcpt(string rcdte, string rcdte2)
       {
           DataTable dt = mdl.mnthrcpt(rcdte, rcdte2);
           intr.mnthrcpt(dt);
       }
       public void mnthrcpt2(string rcdte, string rcdte2, string dr_id)
       {
           DataTable dt = mdl.mnthrcpt2(rcdte, rcdte2, dr_id);
           intr.mnthrcpt2(dt);
       }
       public void practicedetails()
       {
           DataTable dt = mdl.practicedetails();
           intr.practicedetails(dt);
       }
    }
}
