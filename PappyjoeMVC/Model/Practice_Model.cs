using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class Practice_Model
    {
        Connection db = new Connection();

        //private string _PName = "";

        //public string PNAme
        //{
        //    get { return _PName; }
        //    set { _PName = value; }
        //}

        //private string _ptag = "";

        //public string PTabg
        //{
        //    get { return _ptag; }
        //    set { _ptag = value; }
        //}
        //private string _Pspeci = "";

        //public string PSpeciali
        //{
        //    get { return _Pspeci; }
        //    set { _Pspeci = value; }
        //}
        //private string _address = "";

        //public string Address
        //{
        //    get { return _address; }
        //    set { _address = value; }
        //}
        //private string _locality = "";

        //public string Locality
        //{
        //    get { return _locality; }
        //    set { _locality = value; }
        //}
        //private string _country = "";

        //public string Country
        //{
        //    get { return _country; }
        //    set { _country = value; }
        //}
        //private string _state;
        //public string State
        //{
        //    get { return _state; }
        //    set { _state = value; }
        //}
        //private string _city;
        //public string City
        //{
        //    get { return _city; }
        //    set { _city = value; }
        //}

        //private string _pincode;
        //public string PinCode
        //{
        //    get { return _pincode; }
        //    set { _pincode = value; }
        //}
        //private string _phone;
        //public string Phone
        //{
        //    get { return _phone; }
        //    set { _phone = value; }
        //}
        //private string _email;
        //public string Email
        //{
        //    get { return _email; }
        //    set { _email = value; }
        //}
        //private string _website;
        //public string Website
        //{
        //    get { return _website; }
        //    set { _website = value; }
        //}
        //private string _imgpath;
        //public string ImagePath
        //{
        //    get { return _imgpath; }
        //    set { _imgpath = value; }
        //}
        //private string _DInum1;
        //public string DINumber1
        //{
        //    get { return _DInum1; }
        //    set { _DInum1 = value; }
        //}

        //private string _DInumbr2;
        //public string DINumber2
        //{
        //    get { return _DInumbr2; }
        //    set { _DInumbr2 = value; }
        //}

        public DataTable get_data()
        {
            DataTable dtb_details = db.table("select * from  tbl_practice_details");
            return dtb_details;
        }
        public DataTable Get_CountryName(string id,string cmb)
        {
            DataTable dtb_details = new DataTable();
            if (cmb== "Country")
            {
              dtb_details = db.table("select * from  tbl_country where id='" + id + "'");
               
            }
            else if(cmb== "City")
            {
                dtb_details = db.table("select * from  tbl_city where id='" + id + "'");
            }
            else if (cmb == "State")
            {
                dtb_details = db.table("select * from  tbl_state where id='" + id + "'");
            }
            else if (cmb == "Specialization")
            {
                dtb_details = db.table("select * from  tbl_specialization where id='" + id + "'");
            }
            return dtb_details;
        }
        public int save_details(string _PName, string _ptag, string _address, string _locality, string _country, string _state, string _city, string _pincode, string _phone, string _email, string _website, string _Pspeci, string _DInum1, string _DInumbr2)
        {
          int i=  db.execute("insert into tbl_practice_details (name,tagline,street_address,locality,country_id,state_id,city_id,pincode,contact_no,email,website,specialization,path,Dl_Number,Dl_Number2)values('" + _PName + "','" + _ptag + "','" + _address + "','" + _locality + "','" + _country+ "','" + _state + "','" + _city + "','" +_pincode + "','" +_phone + "','" + _email + "','" + _website + "','" + _Pspeci + "','','" + _DInum1 + "','" + _DInumbr2 + "')");
            return i;
        }
        public int Update_details(string _PName, string _ptag, string _address, string _locality, string _country, string _state, string _city, string _pincode, string _phone, string _email, string _website, string _imgpath, string _Pspeci, string _DInum1, string _DInumbr2)
        {
            int i = db.execute("update tbl_practice_details set name='" + _PName + "',tagline='" + _ptag + "',street_address='" + _address + "',locality='" + _locality + "',country_id='" + _country + "',state_id='" + _state + "',city_id='" + _city + "',pincode='" + _pincode + "',contact_no='" + _phone + "',email='" + _email + "',website='" + _website + "',path='" + _imgpath + "',specialization='" + _Pspeci + "',Dl_Number='"+_DInum1+ "',Dl_Number2='"+_DInumbr2+"'");
            return i;
        }
        public DataTable Fill_Country_Combo()
        {
            DataTable dtb = db.table("select * from tbl_country order by id");
            return dtb;
        }
        //public DataTable Fill_City_Combo()
        //{
        //    DataTable dtb = db.table("select * from tbl_city where order by id");
        //    return dtb;
        //}
        //public DataTable Fill_State_Combo(string country)
        //{
        //    DataTable dtb = db.table("select * from tbl_state where country_id ='" + country + "'  order by id");
        //    return dtb;
        //}
        public DataTable Fill_Specialization_Combo()
        {
            DataTable dtb = db.table("select * from tbl_specialization order by id");
            return dtb;
        }
        public DataTable country_selectedindex(string id)
        {
            DataTable dtb = db.table("select * from tbl_state where country_id='" + id + "' order by id");
            return dtb;
        }
        public DataTable state_selectedindex(string id)
        {
            DataTable dtb = db.table("select * from tbl_city where state_id='" + id + "' order by id");
            return dtb;
        }
    }
}
