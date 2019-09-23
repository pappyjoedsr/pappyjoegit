using PappyjoeMVC.Model;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public class Billing_controller
    {
        Billing_model mdl = new Billing_model();
        Common_model cmodel = new Common_model();
        public int save(string TaxName, string Tax)
        {
            int i = mdl.save(TaxName, Tax);
            return i;
        }
        public DataTable Fill_BillGrid()
        {
            DataTable dtb = cmodel.Fill_LoadTax();
            return dtb;
        }
        public int update(string id, string TaxName, string Tax)
        {
            int i = mdl.update(id, TaxName, Tax);
            return i;
        }
        public int Delete(string id)
        {
            int l = mdl.Delete(id);
            return l;
        }
    }
}
