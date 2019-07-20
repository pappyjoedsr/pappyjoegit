using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.Controller
{
    public class login_controller
    {
        login_interface intr;
        login_model _model = new login_model();
        Connection db = new Connection();
        public login_controller(login_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public void GetActivation()
        {
            DataTable dtb = _model.GetActivation();
            intr.Load_Login(dtb);
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
        public DataTable Get_userdetails()
        {
            _model.Username = intr.Username;
            _model.Password = intr.Password;
            DataTable dttb = _model.Get_userdetails();
            return dttb;
        }
        public DataTable Get_Doctor_Activation()
        {
            _model.Username = intr.Username;
            _model.Password = intr.Password;
            DataTable dtb = _model.Get_Doctor_Activation();
            return dtb;
        }
        public DataTable Get_smsconfig()
        {
            DataTable dtb = _model.Get_smsconfig();
            return dtb;
        }
        public void delete_activation()
        {
           db.execute("DELETE from tbl_activation");
        }
        public void save_activation(string listgetcode,string listactcode,string lblhexcode)
        {
            int medi = db.execute("insert into tbl_activation(getcode,actcode,registrationdate,hexacode ) values('" + listgetcode + "','" + listactcode + "','" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "','" + lblhexcode+ "')");
        }
        public void Save_activation_Null()
        {
            db.execute("insert into tbl_activation (getcode,actcode,registrationdate,hexacode) values('10','10',NULL,NULL)");
        }
    }
}
