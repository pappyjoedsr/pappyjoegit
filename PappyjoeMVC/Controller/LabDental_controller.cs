using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class LabDental_controller
    {
        LabDental_interface intr;
        LabDental_model _model = new LabDental_model();
        public LabDental_controller(LabDental_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }

        public int DentalWork_Save()
        {
            _model.WorkTypes = intr.worktypes;
            _model.WorkNames = intr.worknames;
            _model.Shades = intr.shades;
            _model.Alloys = intr.alloys;
            int i = _model.DentalWork_Save();
            return i;
        }
        public int DentalWork_update(string txtwork)
        {
            _model.WorkTypes = intr.worktypes;
            _model.WorkNames = intr.worknames;
            _model.Shades = intr.shades;
            _model.Alloys = intr.alloys;
            int i = _model.DentalWork_update(txtwork);
            return i;
        }
        public DataTable Show_DentalWork()
        {
            DataTable dt = _model.Show_DentalWork();
            return dt;
        }
        public int Laborat_Save()
        {
            _model.Labnames = intr.labnames;
            _model.Address = intr.address;
            _model.Phones = intr.phones;
            _model.Executive = intr.excecutive;
            _model.CmbLAB = intr.cmbLabtype;
            int i = _model.Laborat_Save();
            return i;
        }
        public int Labora_Update(string txtlabid)
        {
            _model.Labnames = intr.labnames;
            _model.Address = intr.address;
            _model.Phones = intr.phones;
            _model.Executive = intr.excecutive;
            _model.CmbLAB = intr.cmbLabtype;
            int i = _model.Labora_Update(txtlabid);
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
