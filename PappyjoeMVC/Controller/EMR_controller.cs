using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public  class EMR_controller
    {
        EMR_model _selectedvalue = new EMR_model();
        public DataTable Fill_grid()
        {
            DataTable dtb = _selectedvalue.Fii_ComplaintsGrid();
            return dtb;
        }
        public DataTable Check_complaints(string complaints)
        {
            DataTable dtb = _selectedvalue.Check_complaints(complaints);
            return dtb;
        }
        public void save_complaints(string Complaints)
        {
            _selectedvalue.save_complaints(Complaints);
        }
        public void update_complaints(string id, string Complaints)
        {
            _selectedvalue.update_complaints(id, Complaints);
        }
        public void Delete_complaints(string id)
        {
           _selectedvalue. Delete_complaints(id);
        }
        public DataTable Search_complaints(string text)
        {
            DataTable dtb= _selectedvalue.search_complaints(text);
            return dtb;
        }
        public DataTable Fill_observationGrid()
        {
            DataTable dtb = _selectedvalue.Fill_observationGrid();
            return dtb;
        }
        public DataTable Check_observation(string name)
        {
            DataTable dtb = _selectedvalue.Check_observation(name);
            return dtb;
        }
        public int save_observation(string Observation)
        {
            int i = _selectedvalue.save_observation(Observation);
            return i;
        }
        public void delete_observation(string id)
        {
            _selectedvalue.delete_observation(id);
        }
        public int Update_observation(string id, string Observation)
        {
            int i = _selectedvalue.Update_observation(id,Observation);
            return i;
        }
        public DataTable SearchObservation(string name)
        {
            DataTable dtb=_selectedvalue.search_observation(name);
            return dtb; 
        }
        //Diagnosis
        public DataTable fill_diagnosisGrid()
        {
            DataTable dtb = _selectedvalue.fill_diagnosisGrid();
            return dtb;
        }
        public DataTable check_diagnosis(string name)
        {
            DataTable dtb = _selectedvalue.check_diagnosis(name);
            return dtb;
        }
        public void save_diagnosis(string Diagnosis)
        {
            _selectedvalue.save_diagnosis( Diagnosis);
        }
        public void update_diagnosis(string name,string Diagnosis)
        {
            _selectedvalue.update_diagnosis(name, Diagnosis);
        }
        public void delete(string id)
        {
            _selectedvalue.delete(id);
        }
        public DataTable search_diagnosis(string name)
        {
            DataTable dtb = _selectedvalue.search_diagnosis(name);
            return dtb;
        }
        public DataTable Fill_investgation()
        {
            DataTable dtb = _selectedvalue.Fill_investgation();
            return dtb;
        }
        public DataTable check_invest(string name)
        {
            DataTable dtb = _selectedvalue.check_invest(name);
            return dtb;
        }
        public void save_investgation(string Investgation)
        {
            _selectedvalue.save_investgation(Investgation);
        }
        public void update_investgation(string id,string Investgation)
        {
            _selectedvalue.update_investgation(id,Investgation);
        }
        public void delete_investigation(string id)
        {
            _selectedvalue.delete_investigation(id);
        }
        public DataTable search_investgation(string name)
        {
            DataTable dtb = _selectedvalue.search_investgation(name);
            return dtb;
        }
        //note
        public DataTable Fill_notegrid()
        {
            DataTable dtb = _selectedvalue. Fill_notegrid();
            return dtb;
        }
        public DataTable check_notes(string note)
        {
            DataTable dtb = _selectedvalue.check_notes(note);
            return dtb;
        }
        public void save_note(string Note)
        {
            _selectedvalue.save_note(Note);
        }
        public void update_note(string id,string Note)
        {
            _selectedvalue.update_note(id, Note);
        }
        public void delete_note(string id)
        {
            _selectedvalue.delete_note(id);
        }
        public DataTable search_note(string note)
        {
            DataTable dtb = _selectedvalue.search_note(note);
            return dtb;
        }
    }
}
