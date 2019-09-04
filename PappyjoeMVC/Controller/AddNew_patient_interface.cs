using System.Data;
namespace PappyjoeMVC.Controller
{
    public interface AddNew_patient_interface
    {
        string PatientName { get; set; }
        string Patient_Id { get; set; }
        string Aadhaar { get; set; }
        string Gender { get; set; }
        string DOB { get; set; }
        string ReferredBy { get; set; }
        string Blood { get; set; }
        string Accompainedby { get; set; }
        string FileNo { get; set; }
        string Age { get; set; }
        string DateofAdmit { get; set; }
        string Occupation { get; set; }
        string Doctor { get; set; }
        string PrimaryMob { get; set; }
        string SecondaryMob { get; set; }
        string Landline { get; set; }
        string Email { get; set; }
        string Street { get; set; }
        string Locality { get; set; }
        string City { get; set; }
        string Pincode { get; set; }
        string Medical { get; set; }
        string Group { get; set; }
        void SetController(Add_New_patient_controller controller);
        void insertMED(DataTable dtb);
        void insertgroup(DataTable dtb);
    }
}
