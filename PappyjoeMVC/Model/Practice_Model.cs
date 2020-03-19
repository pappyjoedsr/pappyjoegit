using System.Data;

namespace PappyjoeMVC.Model
{
    public class Practice_Model
    {
        Connection db = new Connection();
        public DataTable get_data()
        {
            DataTable dtb_details = db.table("select * from  tbl_practice_details");
            return dtb_details;
        }
        public DataTable Get_CountryName(string id, string cmb)
        {
            DataTable dtb_details = new DataTable();
            if (cmb == "Country")
            {
                dtb_details = db.table("select * from  tbl_country where id='" + id + "'");
            }
            else if (cmb == "City")
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
            int i = db.execute("insert into tbl_practice_details (name,tagline,street_address,locality,country_id,state_id,city_id,pincode,contact_no,email,website,specialization,path,Dl_Number,Dl_Number2)values('" + _PName + "','" + _ptag + "','" + _address + "','" + _locality + "','" + _country + "','" + _state + "','" + _city + "','" + _pincode + "','" + _phone + "','" + _email + "','" + _website + "','" + _Pspeci + "','','" + _DInum1 + "','" + _DInumbr2 + "')");
            return i;
        }
        public int Update_details(string _PName, string _ptag, string _address, string _locality, string _country, string _state, string _city, string _pincode, string _phone, string _email, string _website, string _imgpath, string _Pspeci, string _DInum1, string _DInumbr2)
        {
            int i = db.execute("update tbl_practice_details set name='" + _PName + "',tagline='" + _ptag + "',street_address='" + _address + "',locality='" + _locality + "',country_id='" + _country + "',state_id='" + _state + "',city_id='" + _city + "',pincode='" + _pincode + "',contact_no='" + _phone + "',email='" + _email + "',website='" + _website + "',path='" + _imgpath + "',specialization='" + _Pspeci + "',Dl_Number='" + _DInum1 + "',Dl_Number2='" + _DInumbr2 + "'");
            return i;
        }
        public DataTable Fill_Country_Combo()
        {
            DataTable dtb = db.table("select * from tbl_country order by id");
            return dtb;
        }
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
        public int presc_lang(string lang)
        {
            int i= db.execute("update tbl_practice_details set Prescription_lang='" + lang + "'");
            return i;
        }
    }
}
