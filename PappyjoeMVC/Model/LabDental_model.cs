using System.Data;

namespace PappyjoeMVC.Model
{
    public class LabDental_model
    {
        Connection db = new Connection();
        public int DentalWork_Save(string txtworktype, string txtworkname, string txtshade, string txtalloy)
        {
            int i = db.execute("INSERT INTO tbl_Dentallab(tooth_number,work_type,work_name,shade,aloytype)VALUES('11','" + txtworktype + "','" + txtworkname + "','" + txtshade + "','" + txtalloy + "')");
            return i;
        }
        public int DentalWork_update(string txtworktype, string txtworkname, string txtshade, string txtalloy, string txtwork)
        {
            int i = db.execute("update tbl_Dentallab set tooth_number ='11',work_type='" + txtworktype + "',work_name='" + txtworkname + "',shade='" + txtshade + "',aloytype='" + txtalloy + "' WHERE ID='" + txtwork + "'");
            return i;
        }
        public DataTable Show_DentalWork()
        {
            DataTable dentalwork = db.table("select id, Work_name,Work_type,Shade,Aloytype from tbl_Dentallab ");
            return dentalwork;
        }
        public int Laborat_Save(string txtLabname, string txtAddress, string txtPhone, string txtExecutive, string cmblabtype)
        {
            int i = db.execute("INSERT INTO tbl_Laboratory(labname,address1,phone,executivename,labtype)Values('" + txtLabname + "','" + txtAddress + "','" + txtPhone + "','" + txtExecutive + "','" + cmblabtype + "') ");
            return i;
        }
        public int Labora_Update(string txtLabname, string txtAddress, string txtPhone, string txtExecutive, string cmblabtype, string txtlabid)
        {
            int i = db.execute("update tbl_Laboratory set labname ='" + txtLabname + "',address1='" + txtAddress + "',phone='" + txtPhone + "',executivename='" + txtExecutive + "',labtype='" + cmblabtype + "' WHERE ID='" + txtlabid + "'");
            return i;
        }
        public DataTable Laborat_Show()
        {
            DataTable dentalwork = db.table("select ID,labname,labtype,address1,phone,executivename from tbl_Laboratory ");
            return dentalwork;
        }
        public int Del_DentalWork(string txtwork)
        {
            int d = db.execute("delete from tbl_Dentallab where id='" + txtwork + "'");
            return d;
        }
        public int Del_Lab(string txtlabid)
        {
            int d = db.execute("delete from tbl_Laboratory where id='" + txtlabid + "'");
            return d;
        }
    }
}
