using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    public class LabDental_model
    {
        Connection db = new Connection();

        private string txtworktype;
        public string WorkTypes
        {
            get { return this.txtworktype; }
            set { this.txtworktype = value; }
        }
        private string txtworkname;
        public string WorkNames
        {
            get { return this.txtworkname; }
            set { this.txtworkname=value; }
        }
        private string txtshade;
        public string Shades
        {
            get { return this.txtshade; }
            set { this.txtshade = value; }
        }
        private string txtalloy;
        public string Alloys
        {
            get { return this.txtalloy; }
            set { this.txtalloy = value; }
        }
        private string txtLabname;
        public string Labnames
        {
            get { return this.txtLabname; }
            set { this.txtLabname = value; }
        }
        private string txtAddress;
        public string Address
        {
            get { return this.txtAddress; }
            set { this.txtAddress=value; }
        }
        private string txtPhone;
        public string Phones
        {
            get { return this.txtPhone; }
            set { this.txtPhone = value; }
        }
        private string txtExecutive;
        public string Executive
        {
            get { return this.txtExecutive; }
            set { this.txtExecutive = value; }
        }
        private string cmblabtype;
        public string CmbLAB
        {
            get { return this.cmblabtype; }
            set { this.cmblabtype = value; }
        }
        public int DentalWork_Save()
        {
            int i = db.execute("INSERT INTO tbl_Dentallab(tooth_number,work_type,work_name,shade,aloytype)VALUES('11','" + txtworktype + "','" + txtworkname + "','" + txtshade + "','" + txtalloy + "')");
            return i;
        }
        public int DentalWork_update(string txtwork)
        {
            int i = db.execute("update tbl_Dentallab set tooth_number ='11',work_type='" + txtworktype + "',work_name='" + txtworkname + "',shade='" + txtshade + "',aloytype='" + txtalloy + "' WHERE ID='" + txtwork + "'");
            return i;
        }
        public DataTable Show_DentalWork()
        {
            DataTable dentalwork = db.table("select id, Work_name,Work_type,Shade,Aloytype from tbl_Dentallab ");
            return dentalwork;
        }
        public int Laborat_Save()
        {
            int i=db.execute("INSERT INTO tbl_Laboratory(labname,address1,phone,executivename,labtype)Values('" + txtLabname + "','" + txtAddress + "','" + txtPhone + "','" + txtExecutive + "','" + cmblabtype + "') ");
            return i;
        }
        public int Labora_Update(string txtlabid)
        {
            int i=db.execute("update tbl_Laboratory set labname ='" + txtLabname + "',address1='" + txtAddress + "',phone='" + txtPhone + "',executivename='" + txtExecutive + "',labtype='" + cmblabtype + "' WHERE ID='" + txtlabid + "'");
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
