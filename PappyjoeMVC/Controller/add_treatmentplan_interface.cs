﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface add_treatmentplan_interface
    {
        string AddProcedureName { get; set;}
        string ProcedureCost { get; set; }
        string Date { get; set; }
        string Doctor { get; set; }
        string PatientName { get; set; }
        string TotalCost { get; set; }
        string TotalDiscount { get; set; }
        string GrandTotal { get; set; }
        string search_patientname{ get;set;}
        void SetController(add_treatmentplan_controller controller);
        void insertTreatment(DataTable dtb);
    }
}