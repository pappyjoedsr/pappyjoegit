using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface supplier_interface
    {
        string Code { get; set; }
        string Name { get; set; }
        string Balance { get; set; }
        string Phone2{ get; set; }
        string CName { get; set; }
        string Email { get; set; }
        string Web { get; set; }
        string Fax { get; set; }
        string Phone { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string Address3 { get; set; }
        void Setcontroller(supplier_controller controller);
        void DocumentNumber(DataTable dtb);
        void LoadGrid(DataTable dbt);
        void Fill_SuplierDetails(DataTable dtb);
    }
}
