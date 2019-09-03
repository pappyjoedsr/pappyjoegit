﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using PappyjoeMVC.View;
using System.Data;
namespace PappyjoeMVC.Controller
{
  public class Practice_Controller
    {
        Practice_Model Pmdl=new Practice_Model();
        Common_model mdl = new Common_model();
        Connection db = new Connection();
        public DataTable GetData()
        {
            DataTable dtb = Pmdl.get_data();
            return dtb;
        }
        public DataTable Get_CountryNme(string id, string cmb)
        {
            DataTable dtb = Pmdl.Get_CountryName(id, cmb);
            return dtb;
        }
        public int Save_details(string _PName, string _ptag, string _address, string _locality, string _country, string _state, string _city, string _pincode, string _phone, string _email, string _website, string _Pspeci, string _DInum1, string _DInumbr2)
        {
            int i = Pmdl.save_details(_PName, _ptag, _address, _locality, _country, _state, _city, _pincode, _phone, _email, _website, _Pspeci, _DInum1, _DInumbr2);
            return i;
        }

        public DataTable Fill_CountryCombo()
        {
            DataTable dtb = Pmdl.Fill_Country_Combo();
            return dtb;
        }
        public DataTable Fill_SpecializationCombo()
        {
            DataTable dtb = Pmdl.Fill_Specialization_Combo();
            return dtb;
        }
        public int Update_details(string _PName, string _ptag, string _address, string _locality, string _country, string _state, string _city, string _pincode, string _phone, string _email, string _website, string _imgpath, string _Pspeci, string _DInum1, string _DInumbr2)
        {
            int i = Pmdl.Update_details(_PName, _ptag, _address, _locality, _country, _state, _city, _pincode, _phone, _email, _website, _imgpath, _Pspeci, _DInum1, _DInumbr2);
            return i;
        }
        public DataTable country_selectedIndexChanged(string countryid)
        {
            DataTable dtb = Pmdl.country_selectedindex(countryid);
            return dtb;
        }
        public DataTable state_selectedIndexChanged(string countryid)
        {
            DataTable dtb = Pmdl.state_selectedindex(countryid);
            return dtb;
        }
        public string getserver()
        {
            string ret = db.server();
            return ret;
        }
        public bool checkmail(string email)
        {
            bool isva = false;
            if (Connection.checkforemail(email))
                isva = true;
            else
                isva = false;
            return isva;
        }
        public string Load_CompanyName()
        {
            string dtb = mdl.Load_CompanyName();
            return dtb;
        }
    }
}
