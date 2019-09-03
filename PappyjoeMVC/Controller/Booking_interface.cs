using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PappyjoeMVC.Controller
{
    public interface booking_interface
    {
        void SetController(Booking_controller controller);
        void Fill_search_patient(DataTable dtb);
        void Appointment_for_newPAtient(DataTable dtb);
    }
}
