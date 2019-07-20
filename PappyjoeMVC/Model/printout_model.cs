using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Controller;
using System.Data;
namespace PappyjoeMVC.Model
{
   public class printout_model
    {
        Connection db = new Connection();

        private string _size="";
        public string PaperSize
        {
            get { return _size;}
            set { _size = value; }
        }
        private string _topmargine = "";
        public string TopMargine
        {
            get { return _topmargine; }
            set { _topmargine = value; }
        }
        private string _left_margine = "";
        public string LeftMargine
        {
            get { return _left_margine; }
            set { _left_margine = value; }
        }
        private string _bottommargin = "";
        public string Bottommargin
        {
            get { return _bottommargin; }
            set { _bottommargin = value; }
        }
        private string _rightmargin = "";
        public string RightMargin
        {
            get { return _rightmargin; }
            set { _rightmargin = value; }
        }
        private string _orintation = "";
        public string orintation
        {
            get { return _orintation; }
            set { _orintation = value; }
        }
        private string _color = "";
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }
        private string _includeheader = "";
        public string includeheader
        {
            get { return _includeheader; }
            set { _includeheader = value; }
        }
        private string _header = "";
        public string header
        {
            get { return _header; }
            set { _header = value; }
        }
        private string _lefttext = "";
        public string LeftText
        {
            get { return _lefttext; }
            set { _lefttext = value; }
        }
        private string _righttext = "";
        public string Righttext
        {
            get { return _righttext; }
            set { _righttext = value; }
        }
        private string _includelogo = "";
        public string includelogo
        {
            get { return _includelogo; }
            set { _includelogo = value; }
        }
        private string _logotype = "";
        public string logotype
        {
            get { return _logotype; }
            set { _logotype = value; }
        }

        private string _patientdetails = "";
        public string patientdetails
        {
            get { return _patientdetails; }
            set { _patientdetails = value; }
        }
        private string _medhistory = "";
        public string medhistory
        {
            get { return _medhistory; }
            set { _medhistory = value; }
        }
        private string _patientno = "";
        public string patientno
        {
            get { return _patientno; }
            set { _patientno = value; }
        }
        private string _address = "";
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _phone = "";
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _email = "";
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _bloodgroup = "";
        public string bloodgroup
        {
            get { return _bloodgroup; }
            set { _bloodgroup = value; }
        }
        private string _genderdob = "";
        public string genderdob
        {
            get { return _genderdob; }
            set { _genderdob = value; }
        }
        private string _footer_top = "";
        public string FooterTop
        {
            get { return _footer_top; }
            set { _footer_top = value; }
        }
        private string _fullwidth = "";
        //public string FullWidth
        //{
        //    get { return _fullwidth; }
        //    set { _fullwidth = value; }
        //}
        private string _leftsign = "";
        public string LeftSign
        {
            get { return _leftsign; }
            set { _leftsign = value; }
        }
        private string _rightsign = "";
        public string Rightsign
        {
            get { return _rightsign; }
            set { _rightsign = value; }
        }
        private string _doctor = "";
        public string Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }
        
        private string _header_top = "";
        public string header_top
        {
            get { return _header_top; }
            set { _header_top = value; }
        }
        //invoice
        private string _size1 = "";
        public string PaperSize1
        {
            get { return _size1; }
            set { _size1 = value; }
        }
        private string _topmargine1 = "";
        public string TopMargine1
        {
            get { return _topmargine1; }
            set { _topmargine1 = value; }
        }
        private string _left_margine1 = "";
        public string LeftMargine1
        {
            get { return _left_margine1; }
            set { _left_margine1 = value; }
        }
        private string _bottommargin1 = "";
        public string Bottommargin1
        {
            get { return _bottommargin1; }
            set { _bottommargin1 = value; }
        }
        private string _rightmargin1 = "";
        public string RightMargin1
        {
            get { return _rightmargin1; }
            set { _rightmargin1 = value; }
        }
        private string _orintation1 = "";
        public string orintation1
        {
            get { return _orintation1; }
            set { _orintation1 = value; }
        }
        private string _color1 = "";
        public string color1
        {
            get { return _color1; }
            set { _color1 = value; }
        }
        private string _includeheader1 = "";
        public string includeheader1
        {
            get { return _includeheader1; }
            set { _includeheader1 = value; }
        }
        private string _header1 = "";
        public string header1
        {
            get { return _header1; }
            set { _header1 = value; }
        }
        private string _lefttext1 = "";
        public string LeftText1
        {
            get { return _lefttext1; }
            set { _lefttext1 = value; }
        }
        private string _righttext1 = "";
        public string Righttext1
        {
            get { return _righttext1; }
            set { _righttext1 = value; }
        }
        private string _includelogo1 = "";
        public string includelogo1
        {
            get { return _includelogo1; }
            set { _includelogo1 = value; }
        }
        private string _logotype1 = "";
        public string logotype1
        {
            get { return _logotype1; }
            set { _logotype1 = value; }
        }

        private string _patientdetails1 = "";
        public string patientdetails1
        {
            get { return _patientdetails1; }
            set { _patientdetails1 = value; }
        }
        private string _medhistory1 = "";
        public string medhistory1
        {
            get { return _medhistory1; }
            set { _medhistory1 = value; }
        }
        private string _patientno1 = "";
        public string patientno1
        {
            get { return _patientno1; }
            set { _patientno1 = value; }
        }
        private string _address1 = "";
        public string address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        private string _phone1 = "";
        public string phone1
        {
            get { return _phone1; }
            set { _phone1 = value; }
        }
        private string _email1 = "";
        public string email1
        {
            get { return _email1; }
            set { _email1 = value; }
        }
        private string _bloodgroup1 = "";
        public string bloodgroup1
        {
            get { return _bloodgroup1; }
            set { _bloodgroup1 = value; }
        }
        private string _genderdob1 = "";
        public string genderdob1
        {
            get { return _genderdob1; }
            set { _genderdob1 = value; }
        }
        private string _footer_top1 = "";
        public string FooterTop1
        {
            get { return _footer_top1; }
            set { _footer_top1 = value; }
        }
        private string _leftsign1 = "";
        public string LeftSign1
        {
            get { return _leftsign1; }
            set { _leftsign1 = value; }
        }
        private string _rightsign1 = "";
        public string Rightsign1
        {
            get { return _rightsign1; }
            set { _rightsign1 = value; }
        }
        private string _doctor1 = "";
        public string Doctor1
        {
            get { return _doctor1; }
            set { _doctor1 = value; }
        }

        private string _header_top1 = "";
        public string header_top1
        {
            get { return _header_top1; }
            set { _header_top1 = value; }
        }

        //receipt
        private string _size2 = "";
        public string PaperSize2
        {
            get { return _size2; }
            set { _size2 = value; }
        }
        private string _topmargine2 = "";
        public string TopMargine2
        {
            get { return _topmargine2; }
            set { _topmargine2 = value; }
        }
        private string _left_margine2 = "";
        public string LeftMargine2
        {
            get { return _left_margine2; }
            set { _left_margine2 = value; }
        }
        private string _bottommargin2 = "";
        public string Bottommargin2
        {
            get { return _bottommargin2; }
            set { _bottommargin2 = value; }
        }
        private string _rightmargin2 = "";
        public string RightMargin2
        {
            get { return _rightmargin2; }
            set { _rightmargin2 = value; }
        }
        private string _orintation2 = "";
        public string orintation2
        {
            get { return _orintation2; }
            set { _orintation2 = value; }
        }
        private string _color2 = "";
        public string color2
        {
            get { return _color2; }
            set { _color2 = value; }
        }
        private string _includeheader2 = "";
        public string includeheader2
        {
            get { return _includeheader2; }
            set { _includeheader2 = value; }
        }
        private string _header2 = "";
        public string header2
        {
            get { return _header2; }
            set { _header2 = value; }
        }
        private string _lefttext2 = "";
        public string LeftText2
        {
            get { return _lefttext2; }
            set { _lefttext2 = value; }
        }
        private string _righttext2 = "";
        public string Righttext2
        {
            get { return _righttext2; }
            set { _righttext2 = value; }
        }
        private string _includelogo2 = "";
        public string includelogo2
        {
            get { return _includelogo2; }
            set { _includelogo2 = value; }
        }
        private string _logotype2 = "";
        public string logotype2
        {
            get { return _logotype2; }
            set { _logotype2 = value; }
        }

        private string _patientdetails2 = "";
        public string patientdetails2
        {
            get { return _patientdetails2; }
            set { _patientdetails2 = value; }
        }
        private string _medhistory2 = "";
        public string medhistory2
        {
            get { return _medhistory2; }
            set { _medhistory2 = value; }
        }
        private string _patientno2 = "";
        public string patientno2
        {
            get { return _patientno2; }
            set { _patientno2 = value; }
        }
        private string _address2 = "";
        public string address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        private string _phone2 = "";
        public string phone2
        {
            get { return _phone2; }
            set { _phone2 = value; }
        }
        private string _email2 = "";
        public string email2
        {
            get { return _email2; }
            set { _email2 = value; }
        }
        private string _bloodgroup2 = "";
        public string bloodgroup2
        {
            get { return _bloodgroup2; }
            set { _bloodgroup2 = value; }
        }
        private string _genderdob2 = "";
        public string genderdob2
        {
            get { return _genderdob2; }
            set { _genderdob2 = value; }
        }
        private string _footer_top2 = "";
        public string FooterTop2
        {
            get { return _footer_top2; }
            set { _footer_top2 = value; }
        }
        private string _leftsign2 = "";
        public string LeftSign2
        {
            get { return _leftsign2; }
            set { _leftsign2 = value; }
        }
       

        private string _rightsign2 = "";
        public string Rightsign2
        {
            get { return _rightsign2; }
            set { _rightsign2 = value; }
        }
        private string _doctor2 = "";
        public string Doctor2
        {
            get { return _doctor2; }
            set { _doctor2 = value; }
        }

        private string _header_top2 = "";
        public string header_top2
        {
            get { return _header_top2; }
            set { _header_top2 = value; }
        }
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
        public int save_data()
        {
            int insert = db.execute("insert into tbl_presciption_printsettings (size,orientation,printer_type,top_margin,left_margin,bottom_margin,right_margin,include_header,header,left_text,right_text,include_logo,logo_type,patient_details,medical_history,patient,address,phone,email,blood_group,gender_dob,header_top,fullwidth_context,left_sign,right_sign,Doctor) values('" + _size+ "','" + _orintation + "','" + _color + "','" +_topmargine + "','" + _left_margine+ "','" + _bottommargin+ "','" + _rightmargin + "','" + includeheader + "','" + header + "','" + _lefttext + "','" + _righttext + "','" + includelogo + "','" + logotype + "','" + patientdetails + "','" + medhistory + "','" + patientno + "','" + address + "','" + phone + "','" + email + "','" + bloodgroup + "','" + genderdob + "','" + _footer_top + "','" + _header_top + "','" + _leftsign + "','" +_rightsign+ "','" + Doctor + "')");
            return insert;
        }
        public int Update()
        {
            int update = db.execute("update tbl_presciption_printsettings set size='" + _size + "',orientation='" + _orintation + "',printer_type='" + _color + "',top_margin='" + _topmargine + "',left_margin='" + _left_margine + "',bottom_margin='" + _bottommargin + "',right_margin='" + _rightmargin + "',include_header='" + includeheader + "',header='" + header + "',left_text='" + _lefttext + "',right_text='" + _righttext + "',include_logo='" + includelogo + "',logo_type='" + logotype + "',patient_details='" + patientdetails + "',medical_history='" + medhistory + "',patient='" + patientno + "',address='" + address + "',phone='" + phone + "',email='" + email + "',blood_group='" + bloodgroup + "',gender_dob='" + genderdob + "',header_top='" + _footer_top + "',fullwidth_context='" + _header_top + "',left_sign='" + _leftsign + "',right_sign='" + _rightsign + "',Doctor='" + Doctor + "'");
            return update;
        }
        public DataTable invoice_printdetails()
        {
            DataTable invoice_print = db.table("select * from  tbl_invoice_printsettings");
            return invoice_print;
        }
        public int save_invoice()
        {
            int insert = db.execute("insert into tbl_invoice_printsettings(size,orientation,printer_type,top_margin,left_margin,bottom_margin,right_margin,include_header,header,left_text,right_text,include_logo,logo_type,patient_details,medical_history,patient,address,phone,email,blood_group,gender_dob,header_top,fullwidth_context,left_sign,right_sign,Doctor)  values('" + _size1 + "','" + _orintation1 + "','" + _color1 + "','" + _topmargine1 + "','" + _left_margine1 + "','" + _bottommargin1 + "','" + _rightmargin1 + "','" + includeheader1 + "','" + header1 + "','" + _lefttext1 + "','" + _righttext1 + "','" + includelogo1 + "','" + logotype1 + "','" + patientdetails1 + "','" + medhistory1 + "','" + patientno1 + "','" + address1 + "','" + phone1 + "','" + email1 + "','" + bloodgroup1 + "','" + genderdob1 + "','" + _footer_top1 + "','" + _header_top1 + "','" + _leftsign1 + "','" + _rightsign1 + "','"+_doctor1+"')");
            return insert;
        }
        public string get_invoiceprintCount()
        {
            string c = db.scalar("select count(id) from tbl_invoice_printsettings");
            return c;
        }
        public int update_invoicePrint()
        {
            int update = db.execute("update tbl_invoice_printsettings set size='" + _size1 + "',orientation='" + _orintation1 + "',printer_type='" + _color1 + "',top_margin='" + _topmargine1 + "',left_margin='" + _left_margine1 + "',bottom_margin='" + _bottommargin1 + "',right_margin='" + _rightmargin1 + "',include_header='" + _includeheader1 + "',header='" + _header1 + "',left_text='" + _lefttext1 + "',right_text='" + _righttext1 + "',include_logo='" + _includelogo1 + "',logo_type='" + _logotype1 + "',patient_details='" + _patientdetails1 + "',medical_history='" + _medhistory1 + "',patient='" + _patientno1 + "',address='" + _address1 + "',phone='" + _phone1 + "',email='" + _email1 + "',blood_group='" + _bloodgroup1 + "',gender_dob='" + _genderdob1 + "',header_top='" + _footer_top1 + "',fullwidth_context='" + header_top1 + "',left_sign='" + _leftsign1 + "',right_sign='" + _rightsign1 + "',Doctor='"+_doctor1+"'");
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
        public void save_receipt()
        {
            db.execute("insert into tbl_receipt_printsettings (size,orientation,printer_type,top_margin,left_margin,bottom_margin,right_margin,include_header,header,left_text,right_text,include_logo,logo_type,patient_details,medical_history,patient,address,phone,email,blood_group,gender_dob,header_top,fullwidth_context,left_sign,right_sign,Doctor) values('" + _size2 + "','" + _orintation2 + "','" + _color2 + "','" + _topmargine2 + "','" + _left_margine2 + "','" + _bottommargin2 + "','" + _rightmargin2 + "','" + _includeheader2 + "','" + _header2 + "','" + _lefttext2 + "','" + _righttext2 + "','" + _includelogo2 + "','" + _logotype2 + "','" + _patientdetails2 + "','" + _medhistory2 + "','" + _patientno2 + "','" + _address2 + "','" + _phone2 + "','" + _email2 + "','" + _bloodgroup2 + "','" + _genderdob2 + "','" + _footer_top2 + "','" + _header_top2 + "','" + _leftsign2 + "','" + _rightsign2 + "','" + _doctor2 + "')");
        }
        public void update_receipt()
        {
          db.execute("update tbl_receipt_printsettings set size='" + _size2 + "',orientation='" + _orintation2 + "',printer_type='" + _color2 + "',top_margin='" + _topmargine2 + "',left_margin='" + _left_margine2 + "',bottom_margin='" + _bottommargin2+ "',right_margin='" + _rightmargin2 + "',include_header='" + _includeheader2 + "',header='" + _header2 + "',left_text='" + _lefttext2 + "',right_text='" + _righttext2 + "',include_logo='" + _includelogo2 + "',logo_type='" + _logotype2 + "',patient_details='" + _patientdetails2 + "',medical_history='" + _medhistory2 + "',patient='" + _patientno2 + "',address='" + _address2 + "',phone='" + _phone2 + "',email='" + _email2 + "',blood_group='" + _bloodgroup2 + "',gender_dob='" + _genderdob2 + "',header_top='" + _footer_top2 + "',fullwidth_context='" + _header_top2 + "',left_sign='" + _leftsign2 + "',right_sign='" + _rightsign2 + "',Doctor='"+_doctor2+"'");
        }
    }
}
