using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PappyjoeMVC.Controller;
using System.Data;
using PappyjoeMVC.Model; 
using System.IO;
using Microsoft.Win32;

namespace PappyjoeMVC.View
{
    public partial class PracticeDetails : Form,Practice_interface
    {
        public PracticeDetails()
        {
            InitializeComponent();
        }
        Practice_Controller cntrl;
        public string doctor_id = "1", staff_id = "";
        public int len;
        Connection db = new Connection();
        OpenFileDialog open = new OpenFileDialog();
        string path; Image photo;
        Billing bill = new Billing();
        Contacts contct = new Contacts();
        Practice_Staff_Setting staff = new Practice_Staff_Setting();
        EMR_settings emr = new EMR_settings();
        communication_settings communication = new communication_settings();
        Prescription_settings prescription = new Prescription_settings();
        Medical_history medical = new Medical_history();
        AutomaticId_generation atuoid = new AutomaticId_generation();
        printout print = new printout();
        Calender_Settings calender = new Calender_Settings();
        Procedure_catalog catalog = new Procedure_catalog();
        exportdata exprt = new exportdata();
        LabMedical labmedical = new LabMedical();
        LabDental dental = new LabDental();
        public void SetController(Practice_Controller controller)
        {
            cntrl = controller;
        }
        private void btnaddstate_Click(object sender, EventArgs e)
        {
            if (cmb_country.Items.Count > 0)
            {
                int selectedValue; string cmb = "State";
                bool parseOK = Int32.TryParse(cmb_country.SelectedValue.ToString(), out selectedValue);
                frmeditpracticedetails frm = new frmeditpracticedetails(selectedValue, cmb);
                frm.frameid = "3";
                editpracticedetails_controller controller = new editpracticedetails_controller(frm);
                frm.ShowDialog();
            }
        }

        private void btnaddcountry_Click(object sender, EventArgs e)
        {
            frmeditpracticedetails frm = new frmeditpracticedetails();
            frm.frameid = "2";
            editpracticedetails_controller controller = new editpracticedetails_controller(frm);
            frm.ShowDialog();
        }
        private void btnaddcity_Click(object sender, EventArgs e)
        {
            if (cmb_state.Items.Count > 0)
            {
                int selectedValue1; string cmb = "City";
                bool parseOK1 = Int32.TryParse(cmb_state.SelectedValue.ToString(), out selectedValue1);
                frmeditpracticedetails frm = new frmeditpracticedetails(selectedValue1, cmb);
                frm.frameid = "4";
                editpracticedetails_controller controller = new editpracticedetails_controller(frm);
                frm.ShowDialog();
            }
        }

        private void btnaddspecialization_Click(object sender, EventArgs e)
        {
            frmeditpracticedetails frm = new frmeditpracticedetails();
            frm.frameid = "1";
            editpracticedetails_controller controller = new editpracticedetails_controller(frm);
            frm.ShowDialog();
        }
        public string Name
        {
            get { return this.txtname.Text; }
            set { this.txtname.Text = value; }
        }
        public string Tag
        {
            get { return this.txttagline.Text; }
            set { this.txttagline.Text = value; }
        }
        public string State
        {
            get { return this.cmb_state.SelectedValue.ToString(); }
            set { this.cmb_state.Text = value; }
        }
        public string Specialization
        {
            get { return this.cmb_specialization.SelectedValue.ToString(); }
            set { this.cmb_specialization.Text = value; }
        }
        public string Address
        {
            get { return this.txtstreet.Text; }
            set { this.txtstreet.Text = value; }
        }
        public string Locality
        {
            get { return this.txtlocality.Text; }
            set { this.txtlocality.Text = value; }
        }
        public string Country
        {
            get { return this.cmb_country.SelectedValue.ToString(); }
            set { this.cmb_country.Text = value; }
        }
        public string City
        {
            get { return this.cmb_city.SelectedValue.ToString(); }
            set { this.cmb_city.Text = value; }
        }
        public string PinCode
        {
            get { return this.txtpincode.Text; }
            set { this.txtpincode.Text = value; }
        }
        public string Phone
        {
            get { return this.txtcontactnumber.Text; }
            set { this.txtcontactnumber.Text = value; }
        }
        public string Email
        {
            get { return this.txtemail.Text; }
            set { this.txtemail.Text = value; }
        }
        public string Website
        {
            get { return this.txtwebsite.Text; }
            set { this.txtwebsite.Text = value; }
        }
        public string Imagepath
        {
            get { return this.txtpath.Text; }
            set { this.txtpath.Text = value; }
        }
        public string DINumber1
        {
            get { return this.txtdruglicenseno.Text; }
            set { this.txtdruglicenseno.Text = value; }
        }
        public string DINumber2
        {
            get { return this.txttaxno.Text; }
            set { this.txttaxno.Text = value; }
        }
        private void PracticeDetails_Load(object sender, EventArgs e)
        {
            focus = true;
            label16.Hide();
            panel_main.Visible = false;
            this.cntrl.Fill_CountryCombo();
            this.cntrl.country_selectedIndexChanged(Country);
            this.cntrl.state_selectedIndexChanged(State);
            this.cntrl.Fill_SpecializationCombo();
            txtname.Text = "";
            this.cntrl.GetData();
        }

        public void GetData(DataTable dtb_details)
        {
            try
            {
                btn_Save.Text = "Save";
                if (dtb_details.Rows.Count > 0)
                {
                    this.cntrl.Get_CountryNme(dtb_details.Rows[0]["country_id"].ToString(), "Country");
                    this.cntrl.Get_CountryNme(dtb_details.Rows[0]["city_id"].ToString(), "City");
                    this.cntrl.Get_CountryNme(dtb_details.Rows[0]["state_id"].ToString(), "State");
                    this.cntrl.Get_CountryNme(dtb_details.Rows[0]["specialization"].ToString(), "Specialization");
                    string clini_name = dtb_details.Rows[0]["name"].ToString();
                    txtname.Text = clini_name.Replace("¤", "'");
                    txttagline.Text = dtb_details.Rows[0]["tagline"].ToString();
                    cmb_state.Text = dtb_details.Rows[0]["name"].ToString();
                    cmb_specialization.Text = dtb_details.Rows[0]["name"].ToString();
                    txtstreet.Text = dtb_details.Rows[0]["street_address"].ToString();
                    txtlocality.Text = dtb_details.Rows[0]["locality"].ToString();
                    txtpincode.Text = dtb_details.Rows[0]["pincode"].ToString();
                    txtcontactnumber.Text = dtb_details.Rows[0]["contact_no"].ToString();
                    txtemail.Text = dtb_details.Rows[0]["email"].ToString();
                    txtwebsite.Text = dtb_details.Rows[0]["website"].ToString();
                    txtdruglicenseno.Text = dtb_details.Rows[0]["Dl_Number"].ToString();
                    txttaxno.Text = dtb_details.Rows[0]["Dl_Number2"].ToString();
                    path = dtb_details.Rows[0]["path"].ToString();
                    if (path != "")
                    {
                        pictureBox1.Image = Image.FromFile(db.server() + path);
                    }
                    btn_Save.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Get_CmbName(DataTable dtb,string cmd)
        {
            if(dtb.Rows.Count>0)
            {
                if(cmd== "Country")
                {
                    cmb_country.Text = dtb.Rows[0]["country"].ToString();
                }
                else if(cmd=="City")
                {
                    cmb_city.Text = dtb.Rows[0]["city"].ToString();
                }
                else if (cmd == "State")
                {
                    cmb_state.Text = dtb.Rows[0]["state"].ToString();
                }
                else if(cmd == "Specialization")
                {
                    cmb_specialization.Text = dtb.Rows[0]["name"].ToString();
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(txtname.Text))
                {
                    string clinicname = "";
                    clinicname = txtname.Text;
                    Name = clinicname.Replace("'", "¤");
                    string tagname = "";
                    tagname = txttagline.Text;
                    Tag = tagname.Replace("'", " ");
                    if (btn_Save.Text == "Update")
                    {
                        RegistryKey regKeyAppRoot = Registry.CurrentUser.CreateSubKey("Pappyjoe");
                        string strWindowsState = (string)regKeyAppRoot.GetValue("Server");
                        pathlength();
                        string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - len);
                        string realfile = System.IO.Path.GetFileName(open.FileName);
                        try
                        {
                            if (File.Exists(@"\\" + strWindowsState + "\\Pappyjoe_utilities\\Logo\\" + realfile))
                            {
                            }
                            else
                            {
                                System.IO.File.Copy(open.FileName, @"\\" + strWindowsState + "\\Pappyjoe_utilities\\Logo\\" + realfile);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (realfile == "")
                        {
                            Imagepath = path.Replace("\\", "\\\\");
                        }
                        else
                        {
                            Imagepath = "\\" + "\\Pappyjoe_utilities" + "\\" + "\\Logo\\" + "\\" + realfile;
                        }
                        int i = cntrl.Update_details();
                        if (i > 0)
                            MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int i = cntrl.Save_details();
                        btn_Save.Text = "Update";
                        if (i > 0)
                            MessageBox.Show("Successfully Saved !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    txtname.Focus();
                    MessageBox.Show("Practice Name not found...!!", "Data Required..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void pathlength()
        {
            string fullpath = Application.StartupPath.Substring(0, Application.StartupPath.Length);
            if (fullpath.Substring((Application.StartupPath.Length) - 1) == "e")
            {
                len = 11;
            }
            else if (fullpath.Substring((Application.StartupPath.Length - 1)) == "g")
            {
                len = 10;
            }
        }
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            label14.Hide();
            if (txtname.Text.Length > 3)
            {
                errorProvider1.Dispose();
            }
        }

        private void txtcontactnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch != 8 && !char.IsDigit(ch))
            {
                e.Handled = true;
                errorProvider1.SetError(txtcontactnumber, "only digits allowed");
            }
            else
            {
                e.Handled = false;
                errorProvider1.Dispose();
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (txtemail.Text != "" && !Connection.checkforemail(txtemail.Text.ToString()))
            {
                errorProvider1.SetError(txtemail, "Incorrect e-mail");
                label16.Show();
            }
            else
            { 
                label16.Hide();
                errorProvider1.Dispose();
            }
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            open.ShowDialog();
            string ext = Path.GetExtension(open.FileName);
            if (ext.ToLower() == ".jpeg" || ext.ToLower() == ".jpg" || ext.ToLower() == ".gif" || ext.ToLower() == ".png")
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                path = open.FileName;
                photo = pictureBox1.Image;
                txtpath.Text = System.IO.Path.GetFileName(open.FileName);
            }
        }
        
        public void FillCountryCombo(DataTable dtb)
        {
            cmb_country.DataSource = null;
            if (dtb.Rows.Count>0)
            {
                cmb_country.DataSource = dtb;
                cmb_country.DisplayMember = "country";
                cmb_country.ValueMember = "id";
            }
        }
        public void FillCityCombo(DataTable dtb)
        {
            cmb_city.DataSource = null;
            if (dtb.Rows.Count > 0)
            {
                cmb_city.DataSource = dtb;
                cmb_city.DisplayMember = "city";
                cmb_city.ValueMember = "id";
            }
        }
        public void FillStateCombo(DataTable dtb)
        {
            cmb_state.DataSource = null;
            if (dtb.Rows.Count > 0)
            {
                cmb_state.DataSource = dtb;
                cmb_state.DisplayMember = "state";
                cmb_state.ValueMember = "id";
            }
        }
        public void FilSpecializationCombo(DataTable dtb)
        {
            cmb_specialization.DataSource = null;
            if (dtb.Rows.Count > 0)
            {
                cmb_specialization.DataSource = dtb;
                cmb_specialization.DisplayMember = "name";
                cmb_specialization.ValueMember = "id";
            }
        }

        private void cmb_country_Click(object sender, EventArgs e)
        {
            this.cntrl.Fill_CountryCombo();
        }

        private void cmb_state_Click(object sender, EventArgs e)
        {
            this.cntrl.country_selectedIndexChanged(Country);
        }

        private void cmb_city_Click(object sender, EventArgs e)
        {
            this.cntrl.state_selectedIndexChanged(State);
        }

        private void cmb_specialization_Click(object sender, EventArgs e)
        {
            this.cntrl.Fill_SpecializationCombo();
        }

        private void cmb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_country.DataSource != null)
            {
                string countryId = cmb_country.SelectedValue.ToString();
                this.cntrl.country_selectedIndexChanged(countryId);
            }
        }

        private void cmb_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_state.DataSource != null)
            {
                string stateId = cmb_state.SelectedValue.ToString();
                this.cntrl.state_selectedIndexChanged(stateId);
            }
            else
            {
                cmb_city.DataSource = null;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void button_billing_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_billing.BackColor = Color.SteelBlue;
            form_hide();
            bill.TopLevel = false;
            panel_main.Controls.Add(bill);
            bill.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Billing_controller controller = new Billing_controller(bill);
            bill.Show();
        }
        public void backColor_change()
        {
            button_practice.BackColor = Color.DodgerBlue;
            button_calendar.BackColor = Color.DodgerBlue;
            button_communication.BackColor = Color.DodgerBlue;
            button_practicestaff.BackColor = Color.DodgerBlue;
            button_procedurecatalog.BackColor = Color.DodgerBlue;
            button_billing.BackColor = Color.DodgerBlue;
            button_contacts.BackColor = Color.DodgerBlue;
            button_emr.BackColor = Color.DodgerBlue;
            button_medicalhistory.BackColor = Color.DodgerBlue;
            button_importexport.BackColor = Color.DodgerBlue;
            button_idgenerator.BackColor = Color.DodgerBlue;
            button_printout.BackColor = Color.DodgerBlue;
            button_prescription.BackColor = Color.DodgerBlue;
            btnLab.BackColor = Color.DodgerBlue;
            btnLab_dental.BackColor = Color.DodgerBlue;
        }
        public void form_hide()
        {
            calender.Hide(); 
            communication.Hide();
            catalog.Hide();
            bill.Hide();
            contct.Hide();
            emr.Hide();
            prescription.Hide();
            medical.Hide();
            exprt.Hide();
            atuoid.Hide();
            print.Hide();
            staff.Hide();
            labmedical.Hide();
            dental.Hide();
            panel_main.Show(); 
        }

        private void button_practice_Click(object sender, EventArgs e)
        {
            panel_main.Hide();
            backColor_change();
            button_practice.BackColor = Color.SteelBlue;
        }

        private void button_contacts_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_billing.BackColor = Color.SteelBlue;
            form_hide();
            contct.TopLevel = false;
            panel_main.Controls.Add(contct);
            contct.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            contact_controller controller = new contact_controller(contct);
            contct.Show();
        }

        private void button_practicestaff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_billing.BackColor = Color.SteelBlue;
            form_hide();
            staff.TopLevel = false;
            panel_main.Controls.Add(staff);
            staff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Staff_controller controller = new Staff_controller(staff);
            staff.Show();
        }

        private void button_emr_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_emr.BackColor = Color.SteelBlue;
            form_hide();
            emr.TopLevel = false;
            panel_main.Controls.Add(emr);
            emr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            EMR_controller controller = new EMR_controller(emr);
            emr.Show();
        }

        private void button_communication_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_communication.BackColor = Color.SteelBlue;
            form_hide();
            communication.TopLevel = false;
            panel_main.Controls.Add(communication);
            communication.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            communication_setting_controller controller = new communication_setting_controller(communication);
            communication.Show();
        }

        private void button_prescription_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_prescription.BackColor = Color.SteelBlue; 
            form_hide();
            prescription.TopLevel = false;
            panel_main.Controls.Add(prescription);
            prescription.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            prescription_setting_controller controller = new prescription_setting_controller(prescription);
            prescription.Show();
        }

        private void button_medicalhistory_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_medicalhistory.BackColor = Color.SteelBlue;
            form_hide();
            medical.TopLevel = false;
            panel_main.Controls.Add(medical);
            medical.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            medical_history_controller controller = new medical_history_controller(medical);
            medical.Show();
        }

        private void button_idgenerator_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_idgenerator.BackColor = Color.SteelBlue;
            form_hide();
            atuoid.TopLevel = false;
            panel_main.Controls.Add(atuoid);
            atuoid.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            autoid_generation_controller controller = new autoid_generation_controller(atuoid);
            atuoid.Show();
        }

        private void button_printout_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_printout.BackColor = Color.SteelBlue;
            form_hide();
            print.TopLevel = false;
            panel_main.Controls.Add(print);
            print.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            printout_controller controller = new printout_controller(print);
            print.Show();
        }

        private void button_calendar_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_calendar.BackColor = Color.SteelBlue;
            form_hide();
            calender.TopLevel = false;
            panel_main.Controls.Add(calender);
            calender.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            calender_controller controller = new calender_controller(calender);
            calender.Show();
        }

        private void button_procedurecatalog_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_procedurecatalog.BackColor = Color.SteelBlue;
            form_hide();
            catalog.TopLevel = false;
            panel_main.Controls.Add(catalog);
            catalog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            procedure_catalog_controller controller = new procedure_catalog_controller(catalog);
            catalog.Show();
        }

        private void button_importexport_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_importexport.BackColor = Color.SteelBlue;
            form_hide();
            exprt.TopLevel = false;
            exprt.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel_main.Controls.Add(exprt);
            export_controller cntroller = new export_controller(exprt);
            exprt.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            var form2 = new AddNewPatients();
            form2.doctor_id = doctor_id;
            AddNew_patient_controller controller = new AddNew_patient_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new patients();
            form2.doctor_id = doctor_id;
            patients_controller controller = new patients_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            Communication_controller controller = new Communication_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            btn_Inventory.BackColor = Color.SteelBlue;
            form_hide();
            var form2 = new FrmItemList();
            form2.doctor_id = doctor_id;
            ItemList_Controller controller = new ItemList_Controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var form2 = new Doctor_Profile();
            form2.doctor_id = doctor_id;
            doctor_controller controller = new doctor_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        public string patient_id = "1";
        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new AppointmentBooking();
            booking_controller controller = new booking_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();

          
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Login();
            login_controller controller = new login_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            //Reports_controller controller = new Reports_controller(form2);
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void btnLab_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            btnLab.BackColor = Color.SteelBlue;
            form_hide();
            labmedical.TopLevel = false;
            panel_main.Controls.Add(labmedical);
            labmedical.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //LabMedical_controller controller = new LabMedical_controller(labmedical);
            labmedical.Show();
        }

        private void btnLab_dental_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            btnLab_dental.BackColor = Color.SteelBlue;
            form_hide();
            dental.TopLevel = false;
            panel_main.Controls.Add(dental);
            dental.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            dental.Show();
        }
        bool focus = false;
        private void PracticeDetails_Paint(object sender, PaintEventArgs e)
        {
            //if (focus)
            //{ 
            //    txtname.BorderStyle = BorderStyle.None;
            //    Pen p = new Pen(Color.Gray);
            //    Graphics g = e.Graphics;
            //    //int variance = 3,Hight_Variance=6;
            //    g.DrawRectangle(Pens.Gray, 0, 0, Width +12 , Height + 12);
            //    //g.DrawRectangle(p, new Rectangle(txtname.Location.X - variance, txtname.Location.Y - Hight_Variance, txtname.Width + variance, txtname.Height + Hight_Variance));
            //}
            //else
            //{
            //    txtname.BorderStyle = BorderStyle.FixedSingle;
            //}
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            //focus = true;
            //this.Refresh();
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            focus = false;
            this.Refresh();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            //expense_controller controller = new expense_controller(form2);    
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
    }
}
