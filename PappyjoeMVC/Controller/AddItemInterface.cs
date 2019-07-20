using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace PappyjoeMVC.Controller
{
   public interface AddItemInterface
    {
        string ItemCode { get; set; }
        string ItemName { get; set; }
        string Packing { get; set; }
        string Location { get; set; }
        string Category { get; set; }
        string Manufacture { get; set; }
        string PUnit { get; set; }
        string SUnit { get; set; }
        int UnitMF { get; set; }
        decimal Sales_Rate { get; set; }
        decimal Sales_Rate_min { get; set; }
        decimal Sales_Rate_Max { get; set; }
        decimal Sales_Rate2 { get; set; }
        decimal Sales_Rate_min2 { get; set; }
        decimal Sales_Rate_Max2 { get; set; }
        int ReorderQty { get; set; }
        int MinimumStock { get; set; }
        decimal CostBase { get; set; }
        decimal Purch_Rate2 { get; set; }
        decimal Purch_Rate { get; set; }
        bool ISBatch { get; set; }
        bool ISTax { get; set; }
        string type { get; set; }
        string strength { get; set; }
        string strength_gr { get; set; }
        string instructions { get; set; }

        void SetController(AddItem_controller controller);
    }
}
