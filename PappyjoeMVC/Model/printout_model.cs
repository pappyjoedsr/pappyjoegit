using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Controller;
using System.Data;
namespace PappyjoeMVC.Model
{
   public class Printout_model
    {
        Connection db = new Connection();
        public DataTable Get_practice_details()
        {
            DataTable clinic = db.table("select * from tbl_practice_details");
            return clinic;
        }

        public DataTable get_prescription_printdetails()
        {
            DataTable print = db.table("select * from tbl_presciption_printsettings");
            return print;
        }
        public int save_data(string _size, string _orintation , string _color, string _topmargine , string _left_margine, string _bottommargin, string _rightmargin, string includeheader , string header , string _lefttext , string _righttext, string includelogo , string logotype , string patientdetails , string medhistory , string patientno , string address , string phone , string email , string bloodgroup , string genderdob , string _footer_top , string _header_top , string _leftsign , string _rightsign, string Doctor)
        {
            int insert = db.execute("insert into tbl_presciption_printsettings (size,orientation,printer_type,top_margin,left_margin,bottom_margin,right_margin,include_header,header,left_text,right_text,include_logo,logo_type,patient_details,medical_history,patient,address,phone,email,blood_group,gender_dob,header_top,fullwidth_context,left_sign,right_sign,Doctor) values('" + _size+ "','" + _orintation + "','" + _color + "','" +_topmargine + "','" + _left_margine+ "','" + _bottommargin+ "','" + _rightmargin + "','" + includeheader + "','" + header + "','" + _lefttext + "','" + _righttext + "','" + includelogo + "','" + logotype + "','" + patientdetails + "','" + medhistory + "','" + patientno + "','" + address + "','" + phone + "','" + email + "','" + bloodgroup + "','" + genderdob + "','" + _footer_top + "','" + _header_top + "','" + _leftsign + "','" +_rightsign+ "','" + Doctor + "')");
            return insert;
        }
        public int Update(string _size, string _orintation, string _color, string _topmargine, string _left_margine, string _bottommargin, string _rightmargin, string includeheader, string header, string _lefttext, string _righttext, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob, string _footer_top, string _header_top, string _leftsign, string _rightsign, string Doctor)
        {
            int update = db.execute("update tbl_presciption_printsettings set size='" + _size + "',orientation='" + _orintation + "',printer_type='" + _color + "',top_margin='" + _topmargine + "',left_margin='" + _left_margine + "',bottom_margin='" + _bottommargin + "',right_margin='" + _rightmargin + "',include_header='" + includeheader + "',header='" + header + "',left_text='" + _lefttext + "',right_text='" + _righttext + "',include_logo='" + includelogo + "',logo_type='" + logotype + "',patient_details='" + patientdetails + "',medical_history='" + medhistory + "',patient='" + patientno + "',address='" + address + "',phone='" + phone + "',email='" + email + "',blood_group='" + bloodgroup + "',gender_dob='" + genderdob + "',header_top='" + _footer_top + "',fullwidth_context='" + _header_top + "',left_sign='" + _leftsign + "',right_sign='" + _rightsign + "',Doctor='" + Doctor + "'");
            return update;
        }
        public DataTable invoice_printdetails()
        {
            DataTable invoice_print = db.table("select * from  tbl_invoice_printsettings");
            return invoice_print;
        }
        public int save_invoice(string _size1 , string _orintation1 , string _color1 , string _topmargine1 , string _left_margine1 , string _bottommargin1 , string _rightmargin1 , string includeheader1 , string header1 , string _lefttext1 , string _righttext1 , string includelogo1 , string logotype1 , string patientdetails1 , string medhistory1 , string patientno1 , string address1 , string phone1 , string email1 , string bloodgroup1 , string genderdob1 , string _footer_top1, string _header_top1 , string _leftsign1 , string _rightsign1 , string _doctor1)
        {
            int insert = db.execute("insert into tbl_invoice_printsettings(size,orientation,printer_type,top_margin,left_margin,bottom_margin,right_margin,include_header,header,left_text,right_text,include_logo,logo_type,patient_details,medical_history,patient,address,phone,email,blood_group,gender_dob,header_top,fullwidth_context,left_sign,right_sign,Doctor)  values('" + _size1 + "','" + _orintation1 + "','" + _color1 + "','" + _topmargine1 + "','" + _left_margine1 + "','" + _bottommargin1 + "','" + _rightmargin1 + "','" + includeheader1 + "','" + header1 + "','" + _lefttext1 + "','" + _righttext1 + "','" + includelogo1 + "','" + logotype1 + "','" + patientdetails1 + "','" + medhistory1 + "','" + patientno1 + "','" + address1 + "','" + phone1 + "','" + email1 + "','" + bloodgroup1 + "','" + genderdob1 + "','" + _footer_top1 + "','" + _header_top1 + "','" + _leftsign1 + "','" + _rightsign1 + "','"+_doctor1+"')");
            return insert;
        }
        public string get_invoiceprintCount()
        {
            string c = db.scalar("select count(id) from tbl_invoice_printsettings");
            return c;
        }
        public int update_invoicePrint(string _size1, string _orintation1, string _color1, string _topmargine1, string _left_margine1, string _bottommargin1, string _rightmargin1, string includeheader1, string header1, string _lefttext1, string _righttext1, string includelogo1, string logotype1, string patientdetails1, string medhistory1, string patientno1, string address1, string phone1, string email1, string bloodgroup1, string genderdob1, string _footer_top1, string _header_top1, string _leftsign1, string _rightsign1, string _doctor1)
        {
            int update = db.execute("update tbl_invoice_printsettings set size='" + _size1 + "',orientation='" + _orintation1 + "',printer_type='" + _color1 + "',top_margin='" + _topmargine1 + "',left_margin='" + _left_margine1 + "',bottom_margin='" + _bottommargin1 + "',right_margin='" + _rightmargin1 + "',include_header='" + includeheader1 + "',header='" + header1 + "',left_text='" + _lefttext1 + "',right_text='" + _righttext1 + "',include_logo='" + includelogo1 + "',logo_type='" + logotype1 + "',patient_details='" + patientdetails1 + "',medical_history='" + medhistory1 + "',patient='" + patientno1 + "',address='" + address1 + "',phone='" + phone1 + "',email='" + email1 + "',blood_group='" + bloodgroup1 + "',gender_dob='" + genderdob1 + "',header_top='" + _footer_top1 + "',fullwidth_context='" + _header_top1 + "',left_sign='" + _leftsign1 + "',right_sign='" + _rightsign1 + "',Doctor='"+_doctor1+"'");
            return update;                                                                       
        }

        //receipt
         public DataTable load_receipt_print()
        {
            DataTable Receipt_print = db.table("select * from tbl_receipt_printsettings");
            return Receipt_print;
        }
         public string get_receiptprintCount()
        {
            string c = db.scalar("select count(id) from tbl_receipt_printsettings");
            return c;
        }
        public void save_receipt(string _size2, string _orintation2, string _color2, string _topmargine2, string _left_margine2, string _bottommargin2, string _rightmargin2, string _includeheader2, string _header2, string _lefttext2, string _righttext2, string _includelogo2, string _logotype2, string _patientdetails2, string _medhistory2, string _patientno2, string _address2, string _phone2, string _email2, string _bloodgroup2, string _genderdob2, string _footer_top2, string _header_top2, string _leftsign2, string _rightsign2, string _doctor2)
        {
            db.execute("insert into tbl_receipt_printsettings (size,orientation,printer_type,top_margin,left_margin,bottom_margin,right_margin,include_header,header,left_text,right_text,include_logo,logo_type,patient_details,medical_history,patient,address,phone,email,blood_group,gender_dob,header_top,fullwidth_context,left_sign,right_sign,Doctor) values('" + _size2 + "','" + _orintation2 + "','" + _color2 + "','" + _topmargine2 + "','" + _left_margine2 + "','" + _bottommargin2 + "','" + _rightmargin2 + "','" + _includeheader2 + "','" + _header2 + "','" + _lefttext2 + "','" + _righttext2 + "','" + _includelogo2 + "','" + _logotype2 + "','" + _patientdetails2 + "','" + _medhistory2 + "','" + _patientno2 + "','" + _address2 + "','" + _phone2 + "','" + _email2 + "','" + _bloodgroup2 + "','" + _genderdob2 + "','" + _footer_top2 + "','" + _header_top2 + "','" + _leftsign2 + "','" + _rightsign2 + "','" + _doctor2 + "')");
        }
        public void update_receipt(string _size2, string _orintation2, string _color2, string _topmargine2, string _left_margine2, string _bottommargin2, string _rightmargin2, string _includeheader2, string _header2, string _lefttext2, string _righttext2, string _includelogo2, string _logotype2, string _patientdetails2, string _medhistory2, string _patientno2, string _address2, string _phone2, string _email2, string _bloodgroup2, string _genderdob2, string _footer_top2, string _header_top2, string _leftsign2, string _rightsign2, string _doctor2)
        {
          db.execute("update tbl_receipt_printsettings set size='" + _size2 + "',orientation='" + _orintation2 + "',printer_type='" + _color2 + "',top_margin='" + _topmargine2 + "',left_margin='" + _left_margine2 + "',bottom_margin='" + _bottommargin2+ "',right_margin='" + _rightmargin2 + "',include_header='" + _includeheader2 + "',header='" + _header2 + "',left_text='" + _lefttext2 + "',right_text='" + _righttext2 + "',include_logo='" + _includelogo2 + "',logo_type='" + _logotype2 + "',patient_details='" + _patientdetails2 + "',medical_history='" + _medhistory2 + "',patient='" + _patientno2 + "',address='" + _address2 + "',phone='" + _phone2 + "',email='" + _email2 + "',blood_group='" + _bloodgroup2 + "',gender_dob='" + _genderdob2 + "',header_top='" + _footer_top2 + "',fullwidth_context='" + _header_top2 + "',left_sign='" + _leftsign2 + "',right_sign='" + _rightsign2 + "',Doctor='"+_doctor2+"'");
        }
    }
}
