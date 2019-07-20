using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
  public  class communication_setting_controller
    {
        communication_setting_interface intr;
        communication_setting_model _model = new communication_setting_model();
       
        public communication_setting_controller(communication_setting_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }

        public DataTable getsmstabledata()
        {
            DataTable sms = _model.getsmstabledata();
            return sms;
        }
        public DataTable Getsmaname()
        {
            DataTable sms = _model.Getsmaname();
            return sms;
        }
        public void update_sms()
        {
            GetModwelData(_model);
            _model.update_sms();
        }
        public void GetModwelData(communication_setting_model usr)
        {
            usr.SMSUserName = intr.SMSUName;
            usr.SMSPassword = intr.SMSPassword;
            usr.EmailUname = intr.EmailUNAme;
            usr.EmailPassword = intr.EmailPassword;
        }
        public void save_sms()
        {
            GetModwelData(_model);
            _model.save_sms();
        }
         public void update_email()
        {
            GetModwelData(_model);
            _model.update_email();
        }

        public void Save_email()
        {
            GetModwelData(_model);
            _model.Save_email();
        }
    }
}
