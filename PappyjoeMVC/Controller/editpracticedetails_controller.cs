using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
using System.Collections;
namespace PappyjoeMVC.Controller
{
    public class editpracticedetails_controller
    {
        Setting_interface intr;
        editpracticedetails_model _selectedvalue=new editpracticedetails_model(0,0,"");
        Connection db = new Connection();
        public editpracticedetails_controller(Setting_interface intrr )
        {
            intr = intrr;
            intrr.SetController(this);
        }
        private void getuservalues(editpracticedetails_model us)
        {
            us.Country = intr.Country;
        }
        public void  save()
        {
            _selectedvalue.Country = intr.Country; 
            _selectedvalue.save_country();
            Load_Country();
        }
        public void Country_update(string Id)
        {
            _selectedvalue.Country = intr.Country; 
            _selectedvalue.upate_country(Id);
            Load_Country();
        }
        public void check_country(string country)
        {
            DataTable dt_country = db.table("Select * from tbl_country where country ='" + country + "'");
            intr.checkValue(dt_country);
        }
        public void Load_Country()
        {
            DataTable dtb = _selectedvalue.Load_All_Country();
            intr.AddUsertoGrid(dtb);
        }

        public void Use_country(string country)//lll
        {
            DataTable dt_country = _selectedvalue.Get_States_Of_Country(country);
            intr.check_Country_use(dt_country);
        }
        public int  Delete_Country(string country)
        {
          int i=  db.execute("delete from tbl_country where id='" + country + "'");
            return i;
        }
        public void LoadState_wit_Country(string country)
        {
            DataTable dtb = _selectedvalue.Get_States_Of_Country(country);
            intr.AddStatetoGrid(dtb);
        }
        public void Save_State()
        {
            _selectedvalue.State = intr.State;
            _selectedvalue.CountryID = intr.Country_Id;
            _selectedvalue.Save_state(); Fill_State_Grid();
        }
        public void check_state(string state)
        {
            DataTable dt_country = db.table("Select * from tbl_state where state ='" + state + "'");
            intr.check_StateValue(dt_country);
        }
        public void FillCountryCombo()//no usewww
        {
            DataTable dtb_country = _selectedvalue.Load_All_Country();
            intr.Country_ComboFill(dtb_country);
        }
        public void Get_Country_Name(string country_id)
        {
            DataTable dtb = db.table("select * from tbl_country where Id='" + country_id + "'");
            intr.GetCountryName(dtb);
        }
        public void Use_State(string stateid)
        {
            DataTable dt_state = db.table("select * from tbl_city where state_id='" + stateid + "' order by id");
            intr.CheckStateUse(dt_state);
        }  
        public int Delete_State(string state)
        {
           int i= db.execute("delete  from tbl_state where id='" + state + "'");
            Fill_State_Grid();
            return i;
        }
        public void State_update(string Id)
        {
            _selectedvalue.State = intr.State;
            _selectedvalue.CountryID = intr.Country_Id;
            _selectedvalue.update_state(Id);
            Fill_State_Grid();

        }
        public void Fill_State_Grid()
        {
            DataTable dtb_state = _selectedvalue.Get_States_Of_Country(_selectedvalue.CountryID);
            intr.AddStatetoGrid(dtb_state);
        }

        //city
        public void FillStateCombo()
        {
            DataTable dtb_country = _selectedvalue.Load_allState();
            intr.State_ComboFill(dtb_country);
        }
        public void Fill_City_Grid(string stateId)
        {
            DataTable dtb = _selectedvalue.Load_cityOf_State(stateId);
            intr.AddCitytoGrid(dtb);
        }
        public void check_city(string country)
        {
            DataTable dt_country = db.table("Select * from tbl_city where city ='" + country + "'");
            intr.checkValueCity(dt_country);
        }
        public void Save_City()
        {
            get_cityVlaue(_selectedvalue);
            _selectedvalue.Save_city();
        }
        public void get_cityVlaue(editpracticedetails_model mdl)
        {
            mdl.City = intr.City;
            mdl.SateId = intr.State_Id;
        }
        public void City_update(string Id)
        {
            get_cityVlaue(_selectedvalue);
            int i = db.execute("update tbl_city set city='" + _selectedvalue.City + "',state_id='"+_selectedvalue.SateId+"' where Id='" + Id + "'");
        }
        public void Get_state_Name(string country_id)
        {
            DataTable dtb = db.table("select * from tbl_state where Id='" + country_id + "'");
            intr.GetStateName(dtb);
        }
        public void Use_City(string cityid)
        {
            DataTable dt_state = db.table("select * from tbl_practice_details where city_id='" + cityid + "' order by id");
            intr.CheckCityUse(dt_state);
        }
        public int Delete_City(string city)
        {
            int i = db.execute("delete  from tbl_city where id='" + city + "'");
            return i;
        }

        //spcilization
        public void Fill_Specilization_Grid()
        {
            DataTable dtb = db.table("select * from tbl_specialization order by Id");
            intr.AddSpecilizationtoGrid(dtb);
        }
        public void check_specialization(string speci)
        {
            DataTable dt_country = db.table("Select * from tbl_specialization where name ='" + speci + "'");
            intr.checkValueSpecialization(dt_country);
        }
        public void Save_Specialization()
        {
            get_SpeciVlaue(_selectedvalue);
            int i = db.execute("insert into tbl_specialization(name)values('" + _selectedvalue.Specialization + "')");
            Fill_Specilization_Grid();
        }
        public void get_SpeciVlaue(editpracticedetails_model mdl)
        {
            mdl.Specialization = intr.Specialization;
        }
        public void Specialization_update(string Id)
        {
            get_SpeciVlaue(_selectedvalue);
            int i = db.execute("update tbl_specialization set name='" + _selectedvalue.Specialization + "' where id='" + Id + "'");
            Fill_Specilization_Grid();
        }
        public int Delete_Specialization(string city)
        {
            int i = db.execute("delete  from tbl_specialization where id='" + city + "'");
            return i;
        }
    }
}
