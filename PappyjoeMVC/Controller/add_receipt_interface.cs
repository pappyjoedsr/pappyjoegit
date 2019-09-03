using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface add_receipt_interface
    {
        void SetController(Add_Receipt_controller controller);
        void LoadGrid_status0(DataTable dtb);
        //void Load_DGV_MainGrid(DataTable dtb);
    }
}
