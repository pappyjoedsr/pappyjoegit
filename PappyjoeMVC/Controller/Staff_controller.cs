using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Staff_controller
    {
        Staff_model _selectedvalue = new Staff_model();
        public DataTable Fill_StaffGrid()
        {
            DataTable dtb_staff = _selectedvalue.dtb_staff();
            return dtb_staff;
        }
        public DataTable Get_DctrDetails()
        {
            DataTable dtb = _selectedvalue.Get_DctrDetails();
            return dtb;
        }
        public DataTable GetDctr_notificationvalue()
        {
            DataTable dtb = _selectedvalue.Get_NotificationValue();
            return dtb;
        }
        public DataTable Doctr_id()
        {
            DataTable dtb = _selectedvalue.Get_DctrDetails();
            return dtb;
        }
        public DataTable Get_Doctor_notification(string idd)
        {
            DataTable dtb = _selectedvalue.Get_Dctr_Notification(idd);
            return dtb;
        }
        public DataTable ifexsists_dctrnotification(string idd)
        {
            DataTable dtb = _selectedvalue.dtb_ifexists_dctrnotification(idd);
            return dtb;

        }
        public void Update_notification(DataTable dtb, string idd)
        {
            _selectedvalue.Update_Notification(dtb, idd);
        }
        public void Save_Notification(string idd)
        {
            _selectedvalue.Save_Notification(idd);
        }
        public void update_confirm_sms(DataTable dtb, string idd)
        {
            _selectedvalue.update_confirm_sms(dtb,idd);
        }
        public void update_shedule_sms1(DataTable dtb, string idd)
        {
            _selectedvalue.update_shedule_sms1(dtb,idd);
        }
        public void save_shedule_sms(string idd)
        {
            _selectedvalue.save_shedule_sms(idd);
        }
        public void update_shedule_sms0(DataTable dtb, string idd)
        {
            _selectedvalue.update_shedule_sms0(dtb,idd);
        }
        public void update_confirm_email1(DataTable dtb, string idd)
        {
            _selectedvalue.update_confirm_email1(dtb,idd);
        }
        public void save_confirm_email(string idd)
        {
            _selectedvalue.save_confirm_email(idd);
        }
        public void update_confirmemail0(DataTable dtb, string idd)
        {
            _selectedvalue.update_confirmemail0(dtb, idd);
        }
        public void update_shedule_email1(DataTable dtb, string idd)
        {
            _selectedvalue.update_shedule_email1(dtb, idd);
        }
        public void save_shedule_email(string idd)
        {
            _selectedvalue.save_shedule_email(idd);
        }
        public void update_shedule_email0(DataTable dtb, string idd)
        {
            _selectedvalue.update_shedule_email0(dtb, idd);
        }

        public DataTable Get_DoctorId(string idd)
        {
            DataTable dtb = _selectedvalue.Get_DoctorId(idd);
            return dtb;
        }

        public DataTable User_privillage()
        {
            DataTable dtb = _selectedvalue.User_privillage();
            return dtb;
        }
        public void delete_userprivillage(string userid)
        {
            _selectedvalue.delete_userprivillage(userid);
        }
        public void save_userprivillage(string strvalue1)
        {
            _selectedvalue.save_userprivillage(strvalue1);
        }
        public DataTable Get_userPrivillageData(string userid)
        {
            DataTable dtb = _selectedvalue.get_userprivillageData(userid);
            return dtb;
        }
        public string GetMailId(string email)
        {
            string dtb = _selectedvalue.get_mailId(email);
            return dtb;
        }
        public void save_staff(string _sname, string _mobile, string _email, string _registratn, string _color, string _status, string _stafftype,  string _confirmpswd)
        {
            //GetSatffData(_selectedvalue);
            int i = _selectedvalue.Save_Staff( _sname,  _mobile,  _email,  _registratn,  _color,  _status,  _stafftype,    _confirmpswd);
        }
        //public void GetSatffData(Staff_model mdl)
        //{
        //    mdl.SName = intr.SName;
        //    mdl.Staff_type = intr.Type;
        //    mdl.Mobile = intr.MobileNumber;
        //    mdl.Email = intr.EmailId;
        //    mdl.ConfirmPassword = intr.ConfirmPassword;
        //    mdl.CColor = intr.CalendrColor;
        //    mdl.Registration = intr.Registration;
        //    mdl.ActiveLogin = intr.ActivateLogin;
        //}
        public void Update_Login(string id)
        {
            _selectedvalue.update_loginstatus(id);
        }
        public void update_loginstatus_Yes(string id)
        {
            _selectedvalue.update_loginstatus_Yes(id);
        }
    }
}
