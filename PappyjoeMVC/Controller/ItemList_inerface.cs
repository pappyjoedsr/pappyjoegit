using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface ItemList_inerface
    {
        void Setcontroller(ItemList_Controller controller);
        void Fill_ManufactureCombo(DataTable dtb);
        void Fill_Grid(DataTable dtb);
        void Get_manufacturename(DataTable dtb);
        //void Search(DataTable dtb);

    }
}
