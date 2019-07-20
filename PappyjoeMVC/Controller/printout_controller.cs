using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PappyjoeMVC.Model;
using System.Data;
namespace PappyjoeMVC.Controller
{
  public  class printout_controller
    {
        printout_interface intr;
        printout_model mdl =new printout_model();
        common_model cmdl = new common_model();
        public printout_controller(printout_interface inttr)
        {
            intr = inttr;
            intr.SetController(this);
        }
        public DataTable Get_practice_details()
        {
            DataTable dt = new DataTable();
            try
            {
                dt= mdl.Get_practice_details();
               
            }
            catch(Exception ex)
            {

            }
            return dt;
        }
        public void get_prescription_printdetails()
        {
            DataTable dt = mdl.get_prescription_printdetails();
            intr.Load_prescription_printdetails(dt);
        }
        public DataTable Get_prescription_id()
        {
            DataTable dt = mdl.get_prescription_printdetails();
            return dt;
        }
        public int save(string orientation, string color, string includeheader, string includelogo, string logotype, string patientdetails , string medhistory , string patientno , string address , string phone, string email , string bloodgroup , string genderdob, string Doctor)
        {
            mdl.PaperSize = intr.PaperSize;
            mdl.TopMargine = intr.TopMargine;
            mdl.LeftMargine = intr.LeftMargine;
            mdl.Bottommargin = intr.Bottommargin;
            mdl.RightMargin = intr.RightMargin;
            mdl.orintation = orientation;
            mdl.color = color;
            mdl.includeheader = includeheader;
            mdl.header = intr.header;
            mdl.LeftText = intr.LeftText;
            mdl.Righttext = intr.Righttext;
            mdl.includelogo = includelogo;
            mdl.logotype = logotype;
            mdl.patientdetails = patientdetails;
            mdl.medhistory = medhistory;
            mdl.patientno = patientno;
            mdl.address = address;
            mdl.phone = phone;
            mdl.email = email;
            mdl.bloodgroup = bloodgroup;
            mdl.genderdob = genderdob;
            mdl.FooterTop = intr.FooterTop;
            mdl.header_top = intr.header_top;
            mdl.LeftSign = intr.LeftSign;
            mdl.Rightsign = intr.Rightsign;
            mdl.Doctor = Doctor;
            int i = mdl.save_data();
            return i;
        }
       
     public int Update(string orientation, string color, string includeheader, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob, string Doctor)
        {
            mdl.PaperSize = intr.PaperSize;
            mdl.TopMargine = intr.TopMargine;
            mdl.LeftMargine = intr.LeftMargine;
            mdl.Bottommargin = intr.Bottommargin;
            mdl.RightMargin = intr.RightMargin;
            mdl.orintation = orientation;
            mdl.color = color;
            mdl.includeheader = includeheader;
            mdl.header = intr.header;
            mdl.LeftText = intr.LeftText;
            mdl.Righttext = intr.Righttext;
            mdl.includelogo = includelogo;
            mdl.logotype = logotype;
            mdl.patientdetails = patientdetails;
            mdl.medhistory = medhistory;
            mdl.patientno = patientno;
            mdl.address = address;
            mdl.phone = phone;
            mdl.email = email;
            mdl.bloodgroup = bloodgroup;
            mdl.genderdob = genderdob;
            mdl.FooterTop = intr.FooterTop;
            mdl.header_top = intr.header_top;
            mdl.LeftSign = intr.LeftSign;
            mdl.Rightsign = intr.Rightsign;
            mdl.Doctor = Doctor;
            int i = mdl.Update();
            return i;
        }

        //invoice
        public void invoice_printdetails()
        {
            DataTable dtb = mdl.invoice_printdetails();
            intr.load_invoicePrint_details(dtb);
        }
        public string  get_invoiceprintCount()
        {
            string c = mdl.get_invoiceprintCount();
            return c;
        }
       public int save_invoice(string orientation, string color, string includeheader, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob,string Doctor)
        {
            mdl.PaperSize1 = intr.PaperSize1;
            mdl.TopMargine1 = intr.TopMargine1;
            mdl.LeftMargine1 = intr.LeftMargine1;
            mdl.Bottommargin1 = intr.Bottommargin1;
            mdl.RightMargin1 = intr.RightMargin1;
            mdl.orintation1 = orientation;
            mdl.color1 = color;
            mdl.includeheader1 = includeheader;
            mdl.header1 = intr.header1;
            mdl.LeftText1 = intr.LeftText1;
            mdl.Righttext1 = intr.Righttext1;
            mdl.includelogo1 = includelogo;
            mdl.logotype1 = logotype;
            mdl.patientdetails1 = patientdetails;
            mdl.medhistory1 = medhistory;
            mdl.patientno1 = patientno;
            mdl.address1 = address;
            mdl.phone1 = phone; 
            mdl.email1 = email;
            mdl.bloodgroup1 = bloodgroup;
            mdl.genderdob1 = genderdob;
            mdl.FooterTop1 = intr.FooterTop1;
            mdl.header_top1 = intr.header_top1;
            mdl.LeftSign1 = intr.LeftSign1;
            mdl.Rightsign1 = intr.Rightsign1;
            mdl.Doctor1 = Doctor;
            int i = mdl.save_invoice();
            return i;
        }
        public int update_invoicePrint(string orientation, string color, string includeheader, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob,string Doctor)
        {
            mdl.PaperSize1 = intr.PaperSize1;
            mdl.TopMargine1 = intr.TopMargine1;
            mdl.LeftMargine1 = intr.LeftMargine1;
            mdl.Bottommargin1 = intr.Bottommargin1;
            mdl.RightMargin1 = intr.RightMargin1;
            mdl.orintation1 = orientation;
            mdl.color1 = color;
            mdl.includeheader1 = includeheader;
            mdl.header1 = intr.header1;
            mdl.LeftText1 = intr.LeftText1;
            mdl.Righttext1 = intr.Righttext1;
            mdl.includelogo1 = includelogo;
            mdl.logotype1 = logotype;
            mdl.patientdetails1 = patientdetails;
            mdl.medhistory1 = medhistory;
            mdl.patientno1 = patientno;
            mdl.address1 = address;
            mdl.phone1 = phone;
            mdl.email1 = email;
            mdl.bloodgroup1 = bloodgroup;
            mdl.genderdob1 = genderdob;
            mdl.FooterTop1 = intr.FooterTop1;
            mdl.header_top1 = intr.header_top1;
            mdl.LeftSign1 = intr.LeftSign1;
            mdl.Rightsign1 = intr.Rightsign1;
            mdl.Doctor1 = Doctor;
            int i = mdl.update_invoicePrint();
            return i;
        }
        public DataTable Get_companydetails()
        {
            DataTable dtb = cmdl.get_company_details();
            return dtb;
        }
        //receipt
        public void load_receipt_print()
        {
            DataTable dtb = mdl.load_receipt_print();
            intr.Load_ReceiptPrint(dtb);
        }
        public string get_receiptprintCount()
        {
            string c = mdl.get_receiptprintCount();
            return c;
        }
        public void save_receipt(string orientation, string color, string includeheader, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob,string Doctor)
        {
            mdl.PaperSize2 = intr.PaperSize2;
            mdl.TopMargine2 = intr.TopMargine2;
            mdl.LeftMargine2 = intr.LeftMargine2;
            mdl.Bottommargin2 = intr.Bottommargin2;
            mdl.RightMargin2 = intr.RightMargin2;
            mdl.orintation2 = orientation;
            mdl.color2 = color;
            mdl.includeheader2 = includeheader;
            mdl.header2 = intr.header2;
            mdl.LeftText2 = intr.LeftText2;
            mdl.Righttext2 = intr.Righttext2;
            mdl.includelogo2 = includelogo;
            mdl.logotype2 = logotype;
            mdl.patientdetails2 = patientdetails;
            mdl.medhistory2 = medhistory;
            mdl.patientno2 = patientno;
            mdl.address2 = address;
            mdl.phone2 = phone;
            mdl.email2 = email;
            mdl.bloodgroup2 = bloodgroup;
            mdl.genderdob2 = genderdob;
            mdl.FooterTop2 = intr.FooterTop2;
            mdl.header_top2 = intr.header_top2;
            mdl.LeftSign2 = intr.LeftSign2;
            mdl.Rightsign2 = intr.Rightsign2;
            mdl.Doctor2 = Doctor;
            mdl.save_receipt();
        }
        public void update_receipt(string orientation, string color, string includeheader, string includelogo, string logotype, string patientdetails, string medhistory, string patientno, string address, string phone, string email, string bloodgroup, string genderdob,string Doctor)
        {
            mdl.PaperSize2 = intr.PaperSize2;
            mdl.TopMargine2 = intr.TopMargine2;
            mdl.LeftMargine2 = intr.LeftMargine2;
            mdl.Bottommargin2 = intr.Bottommargin2;
            mdl.RightMargin2 = intr.RightMargin2;
            mdl.orintation2 = orientation;
            mdl.color2 = color;
            mdl.includeheader2 = includeheader;
            mdl.header2 = intr.header2;
            mdl.LeftText2 = intr.LeftText2;
            mdl.Righttext2 = intr.Righttext2;
            mdl.includelogo2 = includelogo;
            mdl.logotype2 = logotype;
            mdl.patientdetails2 = patientdetails;
            mdl.medhistory2 = medhistory;
            mdl.patientno2 = patientno;
            mdl.address2 = address;
            mdl.phone2 = phone;
            mdl.email2 = email;
            mdl.bloodgroup2 = bloodgroup;
            mdl.genderdob2 = genderdob;
            mdl.FooterTop2 = intr.FooterTop2;
            mdl.header_top2 = intr.header_top2;
            mdl.LeftSign2 = intr.LeftSign2;
            mdl.Rightsign2 = intr.Rightsign2;
            mdl.Doctor2 = Doctor;
            mdl.update_receipt();
        }
    }
}
