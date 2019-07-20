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
        EMR_Interface intr;
        EMR_model _selectedvalue = new EMR_model();
        Connection db = new Connection();
        public EMR_controller(EMR_Interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public void Fill_grid()
        {
            DataTable dtb = _selectedvalue.Fii_ComplaintsGrid();
            intr.FillGrid(dtb);
        }
        public DataTable Check_complaints(string complaints)
        {
            DataTable dtb = _selectedvalue.Check_complaints(complaints);
            return dtb;
        }
        public void save_complaints()
        {
            Get_modelvalue(_selectedvalue);
            _selectedvalue.save_complaints();
        }
        public void Get_modelvalue(EMR_model usr)
        {
            usr.Complaints = intr.Complaints;
        }
        public void update_complaints(string id)
        {
            Get_modelvalue(_selectedvalue);
            _selectedvalue.update_complaints(id);
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
        public void Fill_observationGrid()
        {
            DataTable dtb = _selectedvalue.Fill_observationGrid();
            intr.FillObservationGrid(dtb);
        }
        public DataTable Check_observation(string name)
        {
            DataTable dtb = _selectedvalue.Check_observation(name);
            return dtb;
        }
        public int save_observation()
        {
            Get_model_observalue(_selectedvalue);
            int i = _selectedvalue.save_observation();
            return i;
        }
        public void Get_model_observalue(EMR_model usr)
        {
            usr.Observation = intr.Observation;
        }
        public void delete_observation(string id)
        {
            _selectedvalue.delete_observation(id);
        }
        public int Update_observation(string id)
        {
            Get_model_observalue(_selectedvalue);
            int i = _selectedvalue.Update_observation(id);
            return i;
        }
        public void SearchObservation(string name)
        {
            DataTable dtb=_selectedvalue.search_observation(name);
            intr.FillObservationGrid(dtb);
        }
        //Diagnosis
        public void fill_diagnosisGrid()
        {
            DataTable dtb = _selectedvalue.fill_diagnosisGrid();
            intr.FiiDiagnosisGrid(dtb);
        }
        public DataTable check_diagnosis(string name)
        {
            DataTable dtb = _selectedvalue.check_diagnosis(name);
            return dtb;
        }
        public void save_diagnosis()
        {
            Get_Diagmodelvalue(_selectedvalue);
            _selectedvalue.save_diagnosis();
        }
        public void update_diagnosis(string name)
        {
            Get_Diagmodelvalue(_selectedvalue);
            _selectedvalue.update_diagnosis(name);
        }
        public void delete(string id)
        {
            _selectedvalue.delete(id);
        }
        public void Get_Diagmodelvalue(EMR_model usr)
        {
            usr.Diagnosis = intr.Diagnosis;
        }
        public void search_diagnosis(string name)
        {
            DataTable dtb = _selectedvalue.search_diagnosis(name);
            intr.FiiDiagnosisGrid(dtb);
        }
        public void Fill_investgation()
        {
            DataTable dtb = _selectedvalue.Fill_investgation();
            intr.FillInvsetgation(dtb);
        }
        public DataTable check_invest(string name)
        {
            DataTable dtb = _selectedvalue.check_invest(name);
            return dtb;
        }
        public void save_investgation()
        {
            Get_Investdelvalue(_selectedvalue);
            _selectedvalue.save_investgation();
        }
        public void Get_Investdelvalue(EMR_model usr)
        {
            usr.Invetsgation = intr.Investgation;
        }
        public void update_investgation(string id)
        {
            Get_Investdelvalue(_selectedvalue);
            _selectedvalue.update_investgation(id);
        }
        public void delete_investigation(string id)
        {
            _selectedvalue.delete_investigation(id);
        }
        public void search_investgation(string name)
        {
            DataTable dtb = _selectedvalue.search_investgation(name);
            intr.FillInvsetgation(dtb);
        }
        //note
        public void Fill_notegrid()
        {
            DataTable dtb = _selectedvalue. Fill_notegrid();
            intr.FillNotes(dtb);
        }
        public DataTable check_notes(string note)
        {
            DataTable dtb = _selectedvalue.check_notes(note);
            return dtb;
        }
        public void save_note()
        {
            Get_notedelvalue(_selectedvalue);
            _selectedvalue.save_note();
        }
        public void Get_notedelvalue(EMR_model usr)
        {
            usr.Note = intr.Note;
        }
        public void update_note(string id)
        {
            Get_notedelvalue(_selectedvalue);
            _selectedvalue.update_note(id);
        }
        public void delete_note(string id)
        {
            _selectedvalue.delete_note(id);
        }
        public void search_note(string note)
        {
            DataTable dtb = _selectedvalue.search_note(note);
            intr.FillNotes(dtb);
        }
    }
}
