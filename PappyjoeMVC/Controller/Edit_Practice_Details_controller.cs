using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Edit_Practice_Details_controller
    {
        Edit_Practice_Details_model _selectedvalue = new Edit_Practice_Details_model();
        Connection db = new Connection();
        public void save(string Country)
        {
            _selectedvalue.save_country(Country);
        }
        public void Country_update(string Id, string Country)
        {
            _selectedvalue.upate_country(Id, Country);
        }
        public string check_country(string country)
        {
            string dt_country = _selectedvalue.check_country(country);
            return dt_country;
        }
        public DataTable Load_Country()
        {
            DataTable dtb = _selectedvalue.Load_All_Country();
            return dtb;
        }
        public DataTable Use_country(string country)
        {
            DataTable dt_country = _selectedvalue.Get_States_Of_Country(country);
            return dt_country;
        }
        public int Delete_Country(string country)
        {
            int i = _selectedvalue.Delete_Country(country);
            return i;
        }
        public DataTable LoadState_wit_Country(string country)
        {
            DataTable dtb = _selectedvalue.Get_States_Of_Country(country);
            return dtb;
        }
        public void Save_State(string CountryID, string State)
        {
            _selectedvalue.Save_state(CountryID, State);
        }
        public string check_state(string state)
        {
            string dt_country = _selectedvalue.check_state(state);
            return dt_country;
        }
        public DataTable FillCountryCombo()
        {
            DataTable dtb_country = _selectedvalue.Load_All_Country();
            return dtb_country;
        }
        public DataTable Get_Country_Name(string country_id)
        {
            DataTable dtb = _selectedvalue.Get_Country_Name(country_id);
            return dtb;
        }
        public int Delete_State(string state)
        {
            int i = _selectedvalue.Delete_State(state);
            return i;
        }
        public void State_update(string Id, string State, string Country_Id)
        {
            _selectedvalue.update_state(Id, State, Country_Id);
        }
        public DataTable Fill_State_Grid(string CountryID)
        {
            DataTable dtb_state = _selectedvalue.Get_States_Of_Country(CountryID);
            return dtb_state;
        }

        //city
        public DataTable FillStateCombo()
        {
            DataTable dtb_country = _selectedvalue.Load_allState();
            return dtb_country;
        }
        public DataTable Fill_City_Grid(string stateId)
        {
            DataTable dtb = _selectedvalue.Load_cityOf_State(stateId);
            return dtb;
        }
        public string check_city(string country)
        {
            string dt_country = _selectedvalue.check_city(country);
            return dt_country;
        }
        public void Save_City(string City, string State_Id)
        {
            _selectedvalue.Save_city(City, State_Id);
        }
        public void City_update(string Id, string City, string State_Id)
        {
            _selectedvalue.City_update(Id, City, State_Id);
        }
        public DataTable Get_state_Name(string country_id)
        {
            DataTable dtb = _selectedvalue.Get_state_Name(country_id);
            return dtb;
        }
        public DataTable Use_City(string cityid)
        {
            DataTable dt_state = _selectedvalue.Use_City(cityid);
            return dt_state;
        }
        public int Delete_City(string city)
        {
            int i = _selectedvalue.Delete_City(city);
            return i;
        }

        //spcilization
        public DataTable Fill_Specilization_Grid()
        {
            DataTable dtb = _selectedvalue.Fill_Specilization_Grid();
            return dtb;
        }
        public string check_specialization(string speci)
        {
            string dt_country = _selectedvalue.check_specialization(speci);
            return dt_country;
        }
        public void Save_Specialization(string Specialization)
        {
            _selectedvalue.Save_Specialization(Specialization);
        }
        public void Specialization_update(string Id, string Specialization)
        {
            _selectedvalue.Specialization_update(Id, Specialization);
        }
        public int Delete_Specialization(string city)
        {
            int i = _selectedvalue.Delete_Specialization(city);
            return i;
        }
    }
}
