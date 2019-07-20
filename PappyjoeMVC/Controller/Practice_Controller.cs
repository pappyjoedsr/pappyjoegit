using System;
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
        Practice_interface intr;
        public Practice_Controller(Practice_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public void GetData()
        {
            DataTable dtb = Pmdl.get_data();
            intr.GetData(dtb);
        }

        public void Get_CountryNme(string id,string cmb)
        {
            DataTable dtb = Pmdl.Get_CountryName(id,cmb);
            intr.Get_CmbName(dtb,cmb);
        }
        public int Save_details()
        {
            get_PracticeVlaue(Pmdl);
            int i = Pmdl.save_details();
            return i;
        }
        public void get_PracticeVlaue(Practice_Model mdl)
        {
            mdl.PNAme = intr.Name;
            mdl.PTabg = intr.Tag;
            mdl.PSpeciali = intr.Specialization;
            mdl.Address = intr.Address;
            mdl.City = intr.City;
            mdl.Country = intr.Country;
            mdl.State = intr.State;
            mdl.Email = intr.Email;
            mdl.Phone = intr.Phone;
            mdl.PinCode = intr.PinCode;
            mdl.Locality = intr.Locality;
            mdl.Website = intr.Website;
            mdl.ImagePath = intr.Imagepath;
            mdl.DINumber1 = intr.DINumber1;
            mdl.DINumber2 = intr.DINumber2;
        }
        public void Fill_CountryCombo()
        {
          DataTable dtb= Pmdl.Fill_Country_Combo();
            intr.FillCountryCombo(dtb);
        }
        public void Fill_SpecializationCombo()
        {
            DataTable dtb = Pmdl.Fill_Specialization_Combo();
            intr.FilSpecializationCombo(dtb);
        }
        public int Update_details()
        {
            get_PracticeVlaue(Pmdl);
            int i = Pmdl.Update_details();
            return i;
        }
        public void country_selectedIndexChanged(string countryid)
        {
            DataTable dtb=Pmdl.country_selectedindex(countryid);
            intr.FillStateCombo(dtb);
        }
        public void state_selectedIndexChanged(string countryid)
        {
            DataTable dtb = Pmdl.state_selectedindex(countryid);
            intr.FillCityCombo(dtb);
        }
    }
}
