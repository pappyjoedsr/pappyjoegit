using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
  public  class Printout_controller
    {
       
        Printout_model mdl =new Printout_model();
        Common_model cmdl = new Common_model();
       
        public DataTable Get_practice_details()
        {
            DataTable dt= mdl.Get_practice_details();
            return dt;
        }
        public DataTable get_prescription_printdetails()
        {
            DataTable dt = mdl.get_prescription_printdetails();
            return dt;
        }
        public DataTable Get_prescription_id()
        {
            DataTable dt = mdl.get_prescription_printdetails();
            return dt;
        }
        public int save(string _size, string _orintation, string _color, string _topmargine, string _left_margine, string _bottommargin, string _rightmargin, string includeheader, string header, string _lefttext, string _righttext, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob, string _footer_top, string _header_top, string _leftsign, string _rightsign, string Doctor)
        {
            int i = mdl.save_data( _size,  _orintation,  _color,  _topmargine,  _left_margine,  _bottommargin,  _rightmargin,  includeheader,  header,  _lefttext,  _righttext,  includelogo,  logotype,  patientdetails,  medhistory,  patientno,  address,  phone,  email,  bloodgroup,  genderdob,  _footer_top,  _header_top,  _leftsign,  _rightsign,  Doctor);
            return i;
        }
       
     public int Update(string _size, string _orintation, string _color, string _topmargine, string _left_margine, string _bottommargin, string _rightmargin, string includeheader, string header, string _lefttext, string _righttext, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob, string _footer_top, string _header_top, string _leftsign, string _rightsign, string Doctor)
        {
            int i = mdl.Update(_size, _orintation, _color, _topmargine, _left_margine, _bottommargin, _rightmargin, includeheader, header, _lefttext, _righttext, includelogo, logotype, patientdetails, medhistory, patientno, address, phone, email, bloodgroup, genderdob, _footer_top, _header_top, _leftsign, _rightsign, Doctor);
            return i;
        }
        //invoice
        public DataTable invoice_printdetails()
        {
            DataTable dtb = mdl.invoice_printdetails();
            return dtb;
        }
        public string  get_invoiceprintCount()
        {
            string c = mdl.get_invoiceprintCount();
            return c;
        }
       public int save_invoice(string _size1, string _orintation1, string _color1, string _topmargine1, string _left_margine1, string _bottommargin1, string _rightmargin1, string includeheader1, string header1, string _lefttext1, string _righttext1, string includelogo1, string logotype1, string patientdetails1, string medhistory1, string patientno1, string address1, string phone1, string email1, string bloodgroup1, string genderdob1, string _footer_top1, string _header_top1, string _leftsign1, string _rightsign1, string _doctor1)
        {
            int i = mdl.save_invoice( _size1,  _orintation1,  _color1,  _topmargine1,  _left_margine1,  _bottommargin1,  _rightmargin1,  includeheader1,  header1,  _lefttext1,  _righttext1,  includelogo1,  logotype1,  patientdetails1,  medhistory1,  patientno1,  address1,  phone1,  email1,  bloodgroup1,  genderdob1,  _footer_top1,  _header_top1,  _leftsign1,  _rightsign1,  _doctor1);
            return i;
        }
        public int update_invoicePrint(string _size1, string _orintation1, string _color1, string _topmargine1, string _left_margine1, string _bottommargin1, string _rightmargin1, string includeheader1, string header1, string _lefttext1, string _righttext1, string includelogo1, string logotype1, string patientdetails1, string medhistory1, string patientno1, string address1, string phone1, string email1, string bloodgroup1, string genderdob1, string _footer_top1, string _header_top1, string _leftsign1, string _rightsign1, string _doctor1)
        {
            int i = mdl.update_invoicePrint(_size1, _orintation1, _color1, _topmargine1, _left_margine1, _bottommargin1, _rightmargin1, includeheader1, header1, _lefttext1, _righttext1, includelogo1, logotype1, patientdetails1, medhistory1, patientno1, address1, phone1, email1, bloodgroup1, genderdob1, _footer_top1, _header_top1, _leftsign1, _rightsign1, _doctor1);
            return i;
        }
        public DataTable Get_companydetails()
        {
            DataTable dtb = cmdl.get_company_details();
            return dtb;
        }
        //receipt
        public DataTable load_receipt_print()
        {
            DataTable dtb = mdl.load_receipt_print();
            return dtb;
        }
        public string get_receiptprintCount()
        {
            string c = mdl.get_receiptprintCount();
            return c;
        }
        public void save_receipt(string _size2, string _orintation2, string _color2, string _topmargine2, string _left_margine2, string _bottommargin2, string _rightmargin2, string _includeheader2, string _header2, string _lefttext2, string _righttext2, string _includelogo2, string _logotype2, string _patientdetails2, string _medhistory2, string _patientno2, string _address2, string _phone2, string _email2, string _bloodgroup2, string _genderdob2, string _footer_top2, string _header_top2, string _leftsign2, string _rightsign2, string _doctor2)
        {
            mdl.save_receipt( _size2,  _orintation2,  _color2,  _topmargine2,  _left_margine2,  _bottommargin2,  _rightmargin2,  _includeheader2,  _header2,  _lefttext2,  _righttext2,  _includelogo2,  _logotype2,  _patientdetails2,  _medhistory2,  _patientno2,  _address2,  _phone2,  _email2,  _bloodgroup2,  _genderdob2,  _footer_top2,  _header_top2,  _leftsign2,  _rightsign2,  _doctor2);
        }
        public void update_receipt(string _size2, string _orintation2, string _color2, string _topmargine2, string _left_margine2, string _bottommargin2, string _rightmargin2, string _includeheader2, string _header2, string _lefttext2, string _righttext2, string _includelogo2, string _logotype2, string _patientdetails2, string _medhistory2, string _patientno2, string _address2, string _phone2, string _email2, string _bloodgroup2, string _genderdob2, string _footer_top2, string _header_top2, string _leftsign2, string _rightsign2, string _doctor2)
        {
            mdl.update_receipt(_size2, _orintation2, _color2, _topmargine2, _left_margine2, _bottommargin2, _rightmargin2, _includeheader2, _header2, _lefttext2, _righttext2, _includelogo2, _logotype2, _patientdetails2, _medhistory2, _patientno2, _address2, _phone2, _email2, _bloodgroup2, _genderdob2, _footer_top2, _header_top2, _leftsign2, _rightsign2, _doctor2);
        }
    }
}
