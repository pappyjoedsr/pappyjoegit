using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Login_controller
    {
        Login_model _model = new Login_model();
        Connection db = new Connection();
        public DataTable GetActivation()
        {
            DataTable dtb = _model.GetActivation();
            return dtb;
        }
        public void update_activation()
        {
            _model.update_activation();
        }
        public DataTable Activation_Details()
        {
            DataTable dtb = _model.GetActivation();
            return dtb;
        }
        public DataTable Get_userdetails(string Username,string Password)
        {
            DataTable dttb = _model.Get_userdetails(Username, Password);
            return dttb;
        }
        public DataTable Get_Doctor_Activation(string Username,string Password)
        {
            DataTable dtb = _model.Get_Doctor_Activation(Username, Password);
            return dtb;
        }
        public DataTable Get_smsconfig()
        {
            DataTable dtb = _model.Get_smsconfig();
            return dtb;
        }
        public void delete_activation()
        {
            _model.delete_activation();
        }
        public void save_activation(string listgetcode, string listactcode, string lblhexcode)
        {
            _model.save_activation( listgetcode,  listactcode,  lblhexcode);
        }
        public void Save_activation_Null()
        {
            _model.Save_activation_Null();
        }
    }
}
