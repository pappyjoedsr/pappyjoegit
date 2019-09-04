using System;

namespace PappyjoeMVC.Model
{
    public class Add_Vital_Signs_model
    {
        Connection db = new Connection();
        public int submit(string patient_id, string dr_id, string doctor, string temp_type, string bp_type, string pulse, string txttemp, string text_Bp_Syst, string text_Bp_Dias, string text_Weight, string text_Resp, string dtp_date, string Txtheight)
        {
            int i = db.execute("insert into tbl_Vital_Signs (pt_id,dr_id,dr_name,pulse,temp,temp_type,bp_syst,bp_dia,bp_type,weight,resp,date,Height) values ('" + patient_id + "','" + dr_id + "','" + doctor + "','" + pulse + "','" + txttemp + "','" + temp_type + "','" + text_Bp_Syst + "','" + text_Bp_Dias + "','" + bp_type + "','" + text_Weight + "','" + text_Resp + "','" + Convert.ToDateTime(dtp_date).ToString("yyyy/MM/dd") + "','" + Txtheight + "')");
            return i;
        }
    }
}
