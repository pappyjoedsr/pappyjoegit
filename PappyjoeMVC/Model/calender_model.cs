using System.Data;
namespace PappyjoeMVC.Model
{
    public class Calender_model
    {
        Connection db = new Connection();
        public DataTable get_practicetimingvalues()
        {
            DataTable visit = db.table("select * from tbl_practice_timings");
            return visit;
        }
        public int update(string slot)
        {
            int i = db.execute("update tbl_practice_timings set slot='" + slot + "'");
            return i;
        }
    }
}
