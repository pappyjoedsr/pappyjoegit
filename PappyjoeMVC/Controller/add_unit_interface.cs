using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface add_unit_interface
    {
        string Units { get; set; }
        void SetController(Add_Unit_controller controller);
        void LoadData(DataTable dtb);
    }
}
