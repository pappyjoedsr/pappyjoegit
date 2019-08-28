using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class LabDental_controller
    {
        LabDental_model _model = new LabDental_model();
        public int DentalWork_Save(string txtworktype, string txtworkname, string txtshade, string txtalloy)
        {
            int i = _model.DentalWork_Save(txtworktype, txtworkname, txtshade, txtalloy);
            return i;
        }
        public int DentalWork_update(string txtworktype, string txtworkname, string txtshade, string txtalloy, string txtwork)
        {
            int i = _model.DentalWork_update(txtworktype, txtworkname, txtshade, txtalloy, txtwork);
            return i;
        }
        public DataTable Show_DentalWork()
        {
            DataTable dt = _model.Show_DentalWork();
            return dt;
        }
        public int Laborat_Save(string txtLabname, string txtAddress, string txtPhone, string txtExecutive, string cmblabtype)
        {
            int i = _model.Laborat_Save(txtLabname, txtAddress, txtPhone, txtExecutive, cmblabtype);
            return i;
        }
        public int Labora_Update(string txtLabname, string txtAddress, string txtPhone, string txtExecutive, string cmblabtype, string txtlabid)
        {
            int i = _model.Labora_Update(txtLabname, txtAddress, txtPhone, txtExecutive, cmblabtype, txtlabid);
            return i;
        }
        public DataTable Laborat_Show()
        {
            DataTable dt = _model.Laborat_Show();
            return dt;
        }
        public int Del_DentalWork(string txtwork)
        {
            int i = _model.Del_DentalWork(txtwork);
            return i;
        }
        public int Del_Lab(string txtlabid)
        {
            int i = _model.Del_Lab(txtlabid);
            return i;
        }
    }
}
