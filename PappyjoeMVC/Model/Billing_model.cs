using System.Data;

namespace PappyjoeMVC.Model
{
    public class Billing_model
    {
        Connection db = new Connection();
        public int save(string TaxName, string Tax)
        {
            int i = db.execute("insert into tbl_tax(tax_name,tax_value) values('" + TaxName + "','" + Tax + "')");
            return i;
        }
        //public DataTable Fill_BillGrid()
        //{
        //    DataTable dtb = db.table("select * from tbl_tax order by id");
        //    return dtb;
        //}
        public int update(string id, string TaxName, string Tax)
        {
            int i = db.execute("update tbl_tax set tax_name='" + TaxName + "',tax_value='" + Tax + "' where id='" + id + "'");
            //Fill_BillGrid();
            return i;
        }
        public int Delete(string id)
        {
            int l = db.execute("delete from tbl_tax where id='" + id + "'");
            return l;
        }
    }
}
