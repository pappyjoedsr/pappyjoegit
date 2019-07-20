using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{ 
    public interface Setting_interface
    {
        void SetController(editpracticedetails_controller controller);
        //Country
        void   AddUsertoGrid(DataTable  dtb);
        void checkValue(DataTable dtb);
        void check_Country_use(DataTable dtb);
        string Country { get; set; }

        //State
        string State { get; set; }
        string Country_Id { get; set; }
        void AddStatetoGrid(DataTable dtb);
        void check_StateValue(DataTable dtb);
        void Country_ComboFill(DataTable dtb_country);
        void GetCountryName(DataTable dtb);
        void CheckStateUse(DataTable dtb);

        //city
       string City { get; set; }
        string State_Id { get; set; }
        void State_ComboFill(DataTable dtb);
        void AddCitytoGrid(DataTable dtb);
        void checkValueCity(DataTable dtb);
        void GetStateName(DataTable dtb);
        void CheckCityUse(DataTable dtb);

        //specialization\
        string  Specialization { get; set; }
        void AddSpecilizationtoGrid(DataTable dtb);
        void checkValueSpecialization(DataTable dtb);
    }
}
