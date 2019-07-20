using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface LabMedical_interface
    {
        string Main_Test { get; set; }
        string Test_type { get; set; }
        string Units { get; set; }
        string TestName { get; set; }
        string txtNVmale { get; set; }
        string txtNVfemale { get; set; }
        int Cmbtesttype { get; set; }
        int CmbUnit { get; set; }
        string TempName { get; set; }
        //string id { get; set; }
        //string tempitem { get; set; }
        //string cmbmaintemp { get; set; }
        //int cmbUnit { get; set; }
        //string norm { get; set; }
        void setcontroller(LabMedical_controller controller);
        void Fill_dgvMainTest(DataTable dtb);
        void fill_TestType(DataTable dtb);
        void fill_Unit(DataTable dtb);
        void fill_Test(DataTable dtb);
        void fill_Template(DataTable dtb);
    }
}
