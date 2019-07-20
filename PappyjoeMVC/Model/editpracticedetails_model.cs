using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
     public class editpracticedetails_model
    {
        Connection db = new Connection();
        private string _country="";

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public editpracticedetails_model(int id, int slno, string country)
        {
            Country = country;
        }
      
        //state
        private string _state;
        private string _countryId;
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string CountryID
        {
            get { return _countryId; }
            set { _countryId = value; }
        }

        //city
        private string _city;
        private string _state_id;
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string SateId
        {
            get { return _state_id; }
            set { _state_id = value; }
        }

        //specialization
        private string _speciaization;
        public string Specialization
        {
            get { return _speciaization; }
            set { _speciaization = value; }
        }
        public void save_country()
        {
           db.execute("insert into tbl_country(country,country_code) values('" +Country + "','0')");
        }
        public DataTable Load_All_Country()
        {
          DataTable dtb = db.table("select * from tbl_country order by Id");
            return dtb;
        }
        public void upate_country(string Id)
        {
           db.execute("update tbl_country set country='" +Country + "' where Id='" + Id + "'");
        }

        public DataTable Get_States_Of_Country(string country)
        {
            DataTable dt_country = db.table("select * from tbl_state where country_id ='" + country + "'");
            return dt_country;
        }
        public void Save_state()
        {
            int i = db.execute("insert into tbl_state(country_id,state)values('" +CountryID + "','" +State + "')");
        }
        public void  update_state(string Id)
        {
           db.execute("update tbl_state set state='" + State + "',country_id='" + CountryID + "' where Id='" + Id + "'");

        }
        public DataTable Load_allState()
        {
            DataTable dtb_country = db.table("select * from tbl_state order by Id");
            return dtb_country;
        }
        public void Save_city()
        {
           db.execute("insert into tbl_city(state_id,city)values('" + SateId + "','" + City + "')");
        }
        public DataTable Load_cityOf_State(string SateId)
        {
            DataTable dtb = db.table("select * from tbl_city where state_id='"+ SateId + "'  order by Id");
            return dtb;
        }
    }
  
}
