﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface profile_details_interface
    {
        void Setcontroller(Profile_Details_controller cntroller);
        void patientload(DataTable dtb);
    }
}
