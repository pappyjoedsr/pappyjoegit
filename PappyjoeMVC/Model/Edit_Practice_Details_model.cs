using System.Data;

namespace PappyjoeMVC.Model
{
    public class Edit_Practice_Details_model
    {
        Connection db = new Connection();

        //specialization
        public void save_country(string Country)
        {
            db.execute("insert into tbl_country(country,country_code) values('" + Country + "','0')");
        }
        public DataTable Load_All_Country()
        {
            DataTable dtb = db.table("select * from tbl_country order by Id");
            return dtb;
        }
        public void upate_country(string Id, string Country)
        {
            db.execute("update tbl_country set country='" + Country + "' where Id='" + Id + "'");
        }

        public DataTable Get_States_Of_Country(string country)
        {
            DataTable dt_country = db.table("select * from tbl_state where country_id ='" + country + "'");
            return dt_country;
        }
        public void Save_state(string CountryID, string State)
        {
            int i = db.execute("insert into tbl_state(country_id,state)values('" + CountryID + "','" + State + "')");
        }
        public void update_state(string Id, string State, string Country_Id)
        {
            db.execute("update tbl_state set state='" + State + "',country_id='" + Country_Id + "' where Id='" + Id + "'");
        }
        public DataTable Load_allState()
        {
            DataTable dtb_country = db.table("select * from tbl_state order by Id");
            return dtb_country;
        }
        public void Save_city(string City, string State_Id)
        {
            db.execute("insert into tbl_city(state_id,city)values('" + State_Id + "','" + City + "')");
        }
        public void City_update(string Id, string City, string State_Id)
        {
            int i = db.execute("update tbl_city set city='" + City + "',state_id='" + State_Id + "' where Id='" + Id + "'");
        }
        public DataTable Get_state_Name(string country_id)
        {
            DataTable dtb = db.table("select * from tbl_state where Id='" + country_id + "'");
            return dtb;
        }
        public DataTable Use_City(string cityid)
        {
            DataTable dt_state = db.table("select * from tbl_practice_details where city_id='" + cityid + "' order by id");
            return dt_state;
        }
        public int Delete_City(string city)
        {
            int i = db.execute("delete  from tbl_city where id='" + city + "'");
            return i;
        }
        public DataTable Load_cityOf_State(string SateId)
        {
            DataTable dtb = db.table("select * from tbl_city where state_id='" + SateId + "'  order by Id");
            return dtb;
        }
        public string check_city(string country)
        {
            string dt_country = db.scalar("Select * from tbl_city where city ='" + country + "'");
            return dt_country;
        }
        public string check_country(string country)
        {
            string dt_country = db.scalar("Select country from tbl_country where country ='" + country + "'");
            return dt_country;
        }
        public int Delete_Country(string country)
        {
            int i = db.execute("delete from tbl_country where id='" + country + "'");
            return i;
        }
        public string check_state(string state)
        {
            string dt_country = db.scalar("Select state from tbl_state where state ='" + state + "'");
            return dt_country;
        }
        public DataTable Get_Country_Name(string country_id)
        {
            DataTable dtb = db.table("select * from tbl_country where Id='" + country_id + "'");
            return dtb;
        }
        public int Delete_State(string state)
        {
            int i = db.execute("delete  from tbl_state where id='" + state + "'");
            return i;
        }
        public DataTable Fill_Specilization_Grid()
        {
            DataTable dtb = db.table("select * from tbl_specialization order by Id");
            return dtb;
        }
        public void Save_Specialization(string Specialization)
        {
            db.execute("insert into tbl_specialization(name)values('" + Specialization + "')");
        }
        public void Specialization_update(string Id, string Specialization)
        {
            db.execute("update tbl_specialization set name='" + Specialization + "' where id='" + Id + "'");
        }
        public string check_specialization(string speci)
        {
            string dt_country = db.scalar("Select name from tbl_specialization where name ='" + speci + "'");
            return dt_country;
        }
        public int Delete_Specialization(string city)
        {
            int i = db.execute("delete  from tbl_specialization where id='" + city + "'");
            return i;
        }
    }

}
