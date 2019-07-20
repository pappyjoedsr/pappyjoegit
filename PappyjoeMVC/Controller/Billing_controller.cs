using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using PappyjoeMVC.View;
using System.Data;

namespace PappyjoeMVC.Controller
{
   public  class Billing_controller
    {
        Connection db = new Connection();
        Billing_model mdl = new Billing_model();
        Billing_Interface intr;
        public Billing_controller(Billing_Interface intrr)
        {
            intr = intrr;
            intrr.SetController(this);
        }

        public void getInputValues(Billing_model usr)
        {
            usr.TaxName = intr.Taxname;
            usr.Tax = intr.Tax;
        }
        public int save()
        {
            getInputValues(mdl);
            int i = db.execute("insert into tbl_tax(tax_name,tax_value) values('" + mdl.TaxName + "','" + mdl.Tax + "')");
            Fill_BillGrid();
            return i;
        }
        public void  Fill_BillGrid()
        {
            DataTable dtb = db.table("select * from tbl_tax order by id");
            intr.FillBillGrid(dtb);
        } 
        public int update(string id)
        {
            getInputValues(mdl);
            int i = db.execute("update tbl_tax set tax_name='" + mdl.TaxName + "',tax_value='" + mdl.Tax + "' where id='"+id+"'");
            Fill_BillGrid();
            return i;
        }
        public int Delete (string id)
        {
            int l = db.execute("delete from tbl_tax where id='"+id+"'");
            return l;
        }
    }
}
