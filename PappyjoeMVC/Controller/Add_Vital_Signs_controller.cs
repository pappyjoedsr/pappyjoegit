using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Add_Vital_Signs_controller
    {
        Add_Vital_Signs_interface intr;
        Add_Vital_Signs_model _model = new Add_Vital_Signs_model();
        public string doctor_id = "0";
        public string staff_id = "0";
        public string patient_id = "0";
        public Add_Vital_Signs_controller(Add_Vital_Signs_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public int submit(string patient_id, string dr_id, string doctor, string temp_type, string bp_type)
        {
            _model.bp = intr.bp;
            _model.bp_dias = intr.bp_dias;
            _model.date = intr.date;
            _model.height = intr.txtheight;
            _model.resp = intr.resp;
            _model.temp = intr.temp;
            _model.txtpulse = intr.txtpulse;
            _model.weight = intr.Weight;
            int i = _model.submit(patient_id,dr_id,doctor,temp_type,bp_type);
            return i;    
        }
    }
}
