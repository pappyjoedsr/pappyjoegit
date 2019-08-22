﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;

namespace PappyjoeMVC.Controller
{
    public class Monthly_new_patients_controller
    {
        Patients_Report_model _model = new Patients_Report_model();
        common_model mdl = new common_model();
        public Monthly_new_patients_controller(Monthly_new_patients_interface intr)
        {
            intr.setcontroller(this);
        }
        public DataTable doctor_rs()
        {
            DataTable d = _model.doctor_rs();
            return d;
        }
        public DataTable MonthlyNewPatient(string d11, string d22, string doctor_id)
        {
            DataTable d = _model.MonthlyNewPatient(d11,d22,doctor_id);
            return d;
        }
        public DataTable grdDailytrtmentTable(string doctor, string date1, string date2)
        {
            DataTable d = _model.grdDailytrtmentTable(doctor,date1,date2);
            return d;
        }
        public DataTable grdDailyTtrtmn1TB(string date1, string date2)
        {
            DataTable d = _model.grdDailyTtrtmn1TB(date1,date2);
            return d;
        }
        public DataTable Get_practiceDlNumber()
        {
            DataTable m = mdl.Get_practiceDlNumber();
            return m;
        }
        public DataTable DailyNewPatient(string d1, string d2, string doctor)
        {
            DataTable c = _model.DailyNewPatient(d1,d2,doctor);
            return c;
        }
    }
}