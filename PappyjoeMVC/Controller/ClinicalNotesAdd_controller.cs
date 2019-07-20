﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class ClinicalNotesAdd_controller
    {
        ClinicalNotesAdd_interface intr;
        ClinicalNotesAdd_model _model = new ClinicalNotesAdd_model();
        common_model model = new common_model();
        public ClinicalNotesAdd_controller(ClinicalNotesAdd_interface inttr)
        {
            intr = inttr;
            intr.setcontroller(this);
        }
        public DataTable investigation_cell(string idinv)
        {
            DataTable dt = _model.investigation_cell(idinv);
            return dt;
        }
        public DataTable diagnose_cell(string iddiag)
        {
            DataTable dt = _model.diagnose_cell(iddiag);
            return dt;
        }
        public DataTable complaint_cell(string idcomp)
        {
            DataTable dt = _model.complaint_cell(idcomp);
            return dt;
        }
        public DataTable notes_cell(string idnote)
        {
            DataTable dt = _model.notes_cell(idnote);
            return dt;
        }
        public DataTable observation_cell(string idobs)
        {
            DataTable dt = _model.observation_cell(idobs);
            return dt;
        }
        public DataTable investsearchtxt(string investsearchtext)
        {
            DataTable dt = _model.investsearchtxt(investsearchtext);
            return dt;
        }
        public DataTable diagnosetxtsearch(string diagsearchtext)
        {
            DataTable dt = _model.diagnosetxtsearch(diagsearchtext);
            return dt;
        }
        public DataTable compsearch(string compsearchtext)
        {
            DataTable dt = _model.compsearch(compsearchtext);
            return dt;
        }
        public DataTable notesearch(string notesearchtext)
        {
            DataTable dt = _model.notesearch(notesearchtext);
            return dt;
        }
        public DataTable observsearch(string obsersearchtext)
        {
            DataTable dt = _model.observsearch(obsersearchtext);
            return dt;
        }
        public DataTable CheckInvest(string investtextbox)
        {
            DataTable dt = _model.CheckInvest(investtextbox);
            return dt;
        }
        public int investigation_insert()
        {
            _model.Investigation = intr.Investigation;
            int i = _model.investigation_insert();
            return i;
        }
        public DataTable Show_investigation()
        {
            DataTable dt = _model.Show_investigation();
            return dt;
        }
        public DataTable CheckdataDiag(string diagtext)
        {
            DataTable dt = _model.CheckdataDiag(diagtext);
            return dt;
        }
        public int Insert_diagno()
        {
            _model.Diagnosis = intr.Diagnosis;
            int i = _model.Insert_diagno();
            return i;
        }
        public DataTable show_diagno()
        {
            DataTable dt = _model.show_diagno();
            return dt;
        }
        public DataTable checkdataAcc(string comptext)
        {
            DataTable dt = _model.checkdataAcc(comptext);
            return dt;
        }
        public int insert_compl()
        {
            _model.complaint = intr.Complaints;
            int i = _model.insert_compl();
            return i;
        }
        public DataTable show_compl()
        {
            DataTable dt = _model.show_compl();
            return dt;
        }
        public int Update_compl(int rowvalue)
        {
            _model.complaint = intr.Complaints;
            int i = _model.Update_compl(rowvalue);
            return i;
        }
        public DataTable checkdataNote(string notetextbox)
        {
            DataTable dt = _model.checkdataNote(notetextbox);
            return dt;
        }
        public int insert_note()
        {
            _model.Notes = intr.Notes;
            int i = _model.insert_note();
            return i;
        }
        public DataTable show_note()
        {
            DataTable d = _model.show_note();
            return d;
        }
        public DataTable checkdataOB(string obsertextbox)
        {
            DataTable d = _model.checkdataOB(obsertextbox);
            return d;
        }
        public int insert_Observ()
        {
            _model.Observation = intr.Observation;
            int i = _model.insert_Observ();
            return i;
        }
        public DataTable show_observation()
        {
            DataTable d = _model.show_observation();
            return d;
        }
        public DataTable patient_search(string _Patientid)
        {
            DataTable dt = model.Patient_search(_Patientid);
            return dt;
        }
        public string doctr_privillage_for_addnewPatient(string doctor_id)
        {
            string s = model.doctr_privillage_for_addnewPatient(doctor_id);
            return s;
        }
        public string permission_for_settings(string doctor_id)
        {
            string s = model.permission_for_settings(doctor_id);
            return s;
        }
        public string userPrivilege_for_ClinicalNotes_Add(string doctor_id)
        {
            string s = _model.userPrivilege_for_ClinicalNotes_Add(doctor_id);
            return s;
        }
        public DataTable Get_CompanyNAme()
        {
            DataTable dt = model.Get_CompanyNAme();
            return dt;
        }
        public DataTable Get_DoctorName(string doctor_id)
        {
            DataTable dt = model.Get_DoctorName(doctor_id);
            return dt;
        }
        public DataTable get_total_payment(string ptid)
        {
            DataTable d = model.get_total_payment(ptid);
            return d;
        }
        public DataTable get_all_doctorname()
        {
            DataTable d = model.get_all_doctorname();
            return d;
        }
        public DataTable Get_patient_id_name_gender(string patient_id)
        {
            DataTable d = model.Get_patient_id_name_gender(patient_id);
            return d;
        }
        public DataTable getdatafrom_clinicalFindings(string id, string ptid)
        {
            DataTable d = _model.getdatafrom_clinicalFindings(id,ptid);
            return d;
        }
        public DataTable getComplaints(string id)
        {
            DataTable d = _model.getComplaints(id);
            return d;
        }
        public DataTable get_observation(string id)
        {
            DataTable dt = _model.get_observation(id);
            return dt;
        }
        public DataTable get_invest(string id)
        {
            DataTable dt = _model.get_invest(id);
            return dt;
        }
        public DataTable get_diagno(string id)
        {
            DataTable d = _model.get_diagno(id);
            return d;
        }
        public DataTable get_note(string id)
        {
            DataTable d = _model.get_note(id);
            return d;
        }
        public DataTable Get_DoctorId(string name)
        {
            DataTable d = model.Get_DoctorId(name);
            return d;
        }
        public int insertInto_clinical_findings(string ptid, string dt, string date)
        {
            int i = _model.insertInto_clinical_findings(ptid,dt,date);
            return i;
        }
        public DataTable MaxId_clinic_findings()
        {
            DataTable dt = _model.MaxId_clinic_findings();
            return dt;
        }
        public int insrtto_investi(int treat, string one)
        {
            int i = _model.insrtto_investi(treat,one);
            return i;
        }
        public int insrtto_diagno(int treat, string one)
        {
            int i = _model.insrtto_diagno(treat, one);
            return i;
        }
        public int insrtto_note(int treat, string one)
        {
            int i = _model.insrtto_note(treat, one);
            return i;
        }
        public int insrtto_obser(int treat, string one)
        {
            int i = _model.insrtto_obser(treat, one);
            return i;
        }
        public int insrtto_chief_comp(int treat, string one)
        {
            int i = _model.insrtto_chief_comp(treat,one);
            return i;
        }
        public int Update_clinical_findings(string ptid, string dt, string id)
        {
            int i = _model.Update_clinical_findings(ptid,dt,id);
            return i;
        }
        public int Update_date_of_clinical(string date, string ptid, string id)
        {
            int i = _model.Update_date_of_clinical(date,ptid,id);
            return i;
        }
        public int del_investi(string id)
        {
            int i = _model.del_investi(id);
            return i;
        }
        public int del_diagno(string id)
        {
            int i = _model.del_diagno(id);
            return i;
        }
        public int del_note(string id)
        {
            int i = _model.del_note(id);
            return i;
        }
        public int del_obser(string id)
        {
            int i = _model.del_obser(id);
            return i;
        }
        public int del_chiefComp(string id)
        {
            int i = _model.del_chiefComp(id);
            return i;
        }
        public int Add_investi(string id, string grid)
        {
            int i = _model.Add_investi(id,grid);
            return i;
        }
        public int Add_diagno(string id, string grid)
        {
            int i = _model.Add_diagno(id, grid);
            return i;
        }
        public int Add_note(string id, string grid)
        {
            int i = _model.Add_note(id, grid);
            return i;
        }
        public int Add_observ(string id, string grid)
        {
            int i = _model.Add_observ(id, grid);
            return i;
        }
        public int Add_cheifComp(string id, string grid)
        {
            int i = _model.Add_cheifComp(id, grid);
            return i;
        }
        public int Del_Complaints(int row)
        {
            int i = _model.Del_Complaints(row);
            return i;
        }
        public DataTable COMP(int rowvalue)
        {
            DataTable dt = _model.COMP(rowvalue);
            return dt;
        }
    }
}