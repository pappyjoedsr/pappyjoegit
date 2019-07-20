using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace PappyjoeMVC.Controller
{
   public interface printout_interface
    {
        string PaperSize { get; set; }
        string TopMargine { get; set; }
        string LeftMargine { get; set; }
        string Bottommargin { get; set; }
        string RightMargin { get; set; }
        string header { get; set; }
        string LeftText { get; set; }
        string Righttext { get; set; }
        string FooterTop { get; set; }
        string Rightsign { get; set; }
        string LeftSign { get; set; }
        string header_top { get; set; }

        //invoice
        string PaperSize1 { get; set; }
        string TopMargine1 { get; set; }
        string LeftMargine1 { get; set; }
        string Bottommargin1 { get; set; }
        string RightMargin1 { get; set; }
        string header1 { get; set; }
        string LeftText1 { get; set; }
        string Righttext1 { get; set; }
        string FooterTop1 { get; set; }
        string Rightsign1 { get; set; }
        string LeftSign1 { get; set; }
        string header_top1 { get; set; }
        //receipt
        string PaperSize2 { get; set; }
        string TopMargine2 { get; set; }
        string LeftMargine2 { get; set; }
        string Bottommargin2 { get; set; }
        string RightMargin2 { get; set; }
        string header2 { get; set; }
        string LeftText2 { get; set; }
        string Righttext2 { get; set; }
        string FooterTop2 { get; set; }
        string Rightsign2 { get; set; }
        string LeftSign2 { get; set; }
        string header_top2 { get; set; }

        void SetController(printout_controller controller);
        void Load_prescription_printdetails(DataTable dtb);
        void load_invoicePrint_details(DataTable dtb);
        void Load_ReceiptPrint(DataTable dtb);
    }
}
