using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Model
{
    class Add_Vital_Signs_model
    {
        Connection db = new Connection();
        private string pulse;
        public string txtpulse
        {
            get { return pulse; }
            set { pulse = value; }
        }
        private string txttemp;
        public string temp
        {
            get { return txttemp; }
            set { txttemp = value; }
        }
        private string text_Bp_Syst;
        public string bp
        {
            get { return text_Bp_Syst; }
            set { text_Bp_Syst = value; }
        }
        private string text_Bp_Dias;
        public string bp_dias
        {
            get { return text_Bp_Dias; }
            set { text_Bp_Dias = value; }
        }
        private string text_Weight;
        public string weight
        {
            get { return text_Weight; }
            set { text_Weight = value; }
        }
        private string text_Resp;
        public string resp
        {
            get { return text_Resp; }
            set { text_Resp = value; }
        }
        private string dtp_date;
        public string date
        {
            get { return dtp_date; }
            set { dtp_date = value; }
        }
        private string Txtheight;
        public string height
        {
            get { return Txtheight; }
            set { Txtheight = value; }
        }
        public int submit(string patient_id,string dr_id,string doctor,string temp_type,string bp_type)
        {
            int i = db.execute("insert into tbl_Vital_Signs (pt_id,dr_id,dr_name,pulse,temp,temp_type,bp_syst,bp_dia,bp_type,weight,resp,date,Height) values ('" + patient_id + "','" + dr_id + "','" + doctor + "','" + pulse + "','" + txttemp + "','" + temp_type + "','" + text_Bp_Syst + "','" + text_Bp_Dias + "','" + bp_type + "','" + text_Weight + "','" + text_Resp + "','" + Convert.ToDateTime(dtp_date).ToString("yyyy/MM/dd") + "','" + Txtheight + "')");
            return i;
        }
    }
}
