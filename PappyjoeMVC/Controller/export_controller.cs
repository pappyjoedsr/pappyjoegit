using PappyjoeMVC.Model;
using System;
using System.Data;
namespace PappyjoeMVC.Controller
{
    public class Export_controller
    {

        Export_model _model = new Export_model();
        public DataTable Get_AllDoctor()
        {
            DataTable dtb = _model.Get_AllDoctor();
            return dtb;
        }
        public DataTable Get_addProcedure()
        {
            DataTable dtb = _model.Get_addProcedure();
            return dtb;
        }
        public DataTable patient_details(DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.patient_details(datefrom, dateto);
            return dtb;
        }
        public DataTable doctor_wise_appointment(string doctor, DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.doctor_wise_appointment(doctor, datefrom, dateto);
            return dtb;
        }
        public DataTable get_all_appointments(DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.get_all_appointments(datefrom, dateto);
            return dtb;
        }
        public DataTable doctor_wise_treatment(string doctor, DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.doctor_wise_treatment(doctor, datefrom, dateto);
            return dtb;
        }
        public DataTable all_tratment(DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.all_tratment(datefrom, dateto);
            return dtb;
        }
        public DataTable expense(DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.expense(datefrom, dateto);
            return dtb;
        }
        public DataTable doctor_wise_prescription(string doctor, DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.doctor_wise_prescription(doctor, datefrom, dateto);
            return dtb;
        }
        public DataTable All_prescription(DateTime datefrom, DateTime dateto)
        {
            DataTable dtb = _model.All_prescription(datefrom, dateto);
            return dtb;
        }
    }
}
