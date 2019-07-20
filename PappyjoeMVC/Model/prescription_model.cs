﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Model
{
    public class prescription_model
    {
        Connection db = new Connection();
        public DataTable getPrescriptionMain(string prescription_id,string ptid)
        {
            DataTable dt_prescription_main = db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and pt_id='" + ptid + "'");
            return dt_prescription_main;
        }
        public DataTable get_prescription_Data(string prescription_id, string ptid)
        {
            DataTable dt1 = db.table("select * from tbl_prescription where pres_id='" + prescription_id + "' and pt_id='" + ptid + "'");
            return dt1;
        }
        public DataTable drug_load()
        {
            DataTable dt4 = db.table("select id,CONCAT(name,' ', type ) as name, CONCAT(strength_gr ,' ' , strength ) as type,inventory_id from tbl_adddrug ORDER BY id DESC");
            return dt4;
        }
        public DataTable drug_instock(string id)
        {
            DataTable dtstock = db.table("Select A.item_code,A.item_name,(select sum(Qty) from tbl_BatchNumber where item_code= A.item_code) 'Stock' from tbl_ITEMS A WHERE A.ID='" + id + "' order by item_name");
            return dtstock;
        }
        public DataTable load_template()
        {
            DataTable dt2 = db.table("select id,templates from tbl_templates_main ORDER BY id DESC");
            return dt2;
        }
        public DataTable drug_search(string search)
        {
            DataTable dt4 = db.table("select id,CONCAT(name,' ', type ) as name, CONCAT(strength_gr, ' ', strength ) as type,inventory_id from tbl_adddrug where name like'" + search + "%' ORDER BY id DESC");
            return dt4;
        }
        public DataTable search_template(string searchtext2)
        {
            DataTable dt2 = db.table("select id,templates from tbl_templates_main where templates like'%" + searchtext2+ "%'");
            return dt2;
        }
        public DataTable ge_drug(string id1)
        {
            DataTable dt = db.table("select name,strength,strength_gr,type,instructions from tbl_adddrug where id ='" + id1 + "'");
            return dt;
        }
        public DataTable get_template(string idtemp)
        {
            DataTable dt = db.table("select drug_name,strength,strength_gr,duration,duration_period,morning,noon,night,add_instruction,food,drug_id,drug_type,status from tbl_template where temp_id ='" + idtemp + "'");
            return dt;
        }
        public DataTable get_inventoryid(string id)
        {
            DataTable dt4 = db.table("select id,inventory_id from tbl_adddrug where id='" + id + "' and inventory_id<>0 ORDER BY id DESC");
            return dt4;
        }
        public void save_prescriptionmain(string ptid,string d_id,string date,string prescription_bill_status,string note)
        {
            db.table("insert into tbl_prescription_main (pt_id,dr_id,date,pay_status,notes) values('" + ptid + "','" + d_id + "','" + date + "','" + prescription_bill_status + "','" + note + "')");
        } 
        public DataTable Maxid()
        {
            DataTable dt = db.table("select MAX(id) from tbl_prescription_main");
            return dt;
        }
        public void save_prescription(int pres_id, string pt_id, string dr_name, string dr_id, string date, string drug_name, string strength, string strength_gr, string duration_unit, string duration_period, string morning, string noon, string night, string food, string add_instruction, string drug_type, string status, string drug_id)
        {
            db.table("insert into tbl_prescription (pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id) values('" + pres_id + "','" + pt_id + "','" + dr_name + "','" + dr_id + "','" + date + "','" + drug_name + "','" + strength + "','" + strength_gr + "','" + duration_unit + "','" + duration_period + "','" + morning + "','" + noon + "','" + night + "','" + food + "','" + add_instruction + "','" + drug_type + "'," + status + ",'" + drug_id + "')");
        }
        public void update_prescription_review(string date,int presid)
        {
           db.execute("UPDATE tbl_prescription_main SET review='YES',Review_date='" + date + "' WHERE id='" + presid + "'");
        }

        public void update_prescription_review_NO(string date,int presid)
        {
            db.execute("UPDATE tbl_prescription_main SET review='NO',Review_date='" + date + "'  WHERE id='" + presid + "'");
        }
        public void update_prescription_main(string note,string Prescription_bill_status, string prescription_id)
        {
            db.execute("update tbl_prescription_main set notes='" + note + "',pay_status='" + Prescription_bill_status + "' where id='" + prescription_id + "'");
        }
        public void delete_prescription(string prescription_id)
        {
            db.execute("delete from tbl_prescription where pres_id='" + prescription_id + "'");
        }
        public void save_template(string template)
        {
            db.execute("insert into tbl_templates_main(templates) values('" + template + "')");
        }
        public string  get_templateid(string tempnametext)
        {
            string dt = db.scalar("select id from tbl_templates_main where templates='" + tempnametext+ "'");
            return dt;
        }
        public void save_template(string temp_id, string pt_id, string pt_name, string dr_id, string dr_name, string date, string drug_name, string strength, string strength_gr, string duration, string morning, string noon, string night, string food, string add_instruction, string drug_type, string drug_id, string pres_id, string duration_period, string status)
        {
            db.execute("insert into tbl_template (temp_id,pt_id,pt_name,dr_id,dr_name,date,drug_name,strength,strength_gr,duration,morning,noon,night,food,add_instruction,drug_type,drug_id,pres_id,duration_period,status) values('" + temp_id + "','" + pt_id + "','" + pt_name + "','" + dr_id + "','" + dr_name + "','" + date + "','" + drug_name + "','" + strength + "','" + strength_gr + "','" + duration + "','" + morning + "','" + noon + "','" + night + "','" + food + "','" + add_instruction + "','" + drug_type + "','" + drug_id + "','" + pres_id + "','" + duration_period + "','" + status + "')");
        }


    }
}
