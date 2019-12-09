using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Practice_Details : Form
    {
        public Practice_Details()
        {
            InitializeComponent();
        }
        Practice_Controller cntrl = new Practice_Controller();
        public string doctor_id = "1", staff_id = "";
        public int len;
        Connection db = new Connection();
        OpenFileDialog open = new OpenFileDialog();
        string path; Image photo;
        Billing bill = new Billing();
        Contacts contct = new Contacts();
        Practice_Staff_Setting staff = new Practice_Staff_Setting();
        EMR_Settings emr = new EMR_Settings();
        Communication_Settings communication = new Communication_Settings();
        Prescription_Settings prescription = new Prescription_Settings();
        Medical_History medical = new Medical_History();
        AutomaticId_generation atuoid = new AutomaticId_generation();
        Printout print = new Printout();
        Calender_Settings calender = new Calender_Settings();
        Procedure_Catalog catalog = new Procedure_Catalog();
        Export_Data exprt = new Export_Data();
        LabMedical labmedical = new LabMedical();
        LabDental dental = new LabDental();
        private void btnaddstate_Click(object sender, EventArgs e)
        {
            if (cmb_country.Items.Count > 0)
            {
                int selectedValue; string cmb = "State";
                bool parseOK = Int32.TryParse(cmb_country.SelectedValue.ToString(), out selectedValue);
                Edit_Practice_Details frm = new Edit_Practice_Details(selectedValue, cmb);
                frm.frameid = "3";
                //editpracticedetails_controller controller = new editpracticedetails_controller(frm);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void btnaddcountry_Click(object sender, EventArgs e)
        {
            Edit_Practice_Details frm = new Edit_Practice_Details();
            frm.frameid = "2";
            //editpracticedetails_controller controller = new editpracticedetails_controller(frm);
            frm.ShowDialog();
            frm.Dispose();
        }
        private void btnaddcity_Click(object sender, EventArgs e)
        {
            if (cmb_state.Items.Count > 0)
            {
                int selectedValue1;
                string cmb = "City";
                bool parseOK1 = Int32.TryParse(cmb_state.SelectedValue.ToString(), out selectedValue1);
                Edit_Practice_Details frm = new Edit_Practice_Details(selectedValue1, cmb);
                frm.frameid = "4";
                //editpracticedetails_controller controller = new editpracticedetails_controller(frm);
                frm.ShowDialog();
                frm.Dispose();
            }
        }

        private void btnaddspecialization_Click(object sender, EventArgs e)
        {
            Edit_Practice_Details frm = new Edit_Practice_Details();
            frm.frameid = "1";
            //editpracticedetails_controller controller = new editpracticedetails_controller(frm);
            frm.ShowDialog();
            frm.Dispose();
        }
        private void PracticeDetails_Load(object sender, EventArgs e)
        {
            //focus = true;
            label16.Hide();
            panel_main.Visible = false;
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            string docnam = this.cntrl.Get_DoctorName(doctor_id);
            if (docnam!="")
            {
                toolStripldoc.Text = "Logged In As : " + docnam;
            }
            DataTable dt_country = this.cntrl.Fill_CountryCombo();
            FillCountryCombo(dt_country);
            if(cmb_country.SelectedIndex>=0)
            {
                DataTable dtb_state = this.cntrl.country_selectedIndexChanged(cmb_country.SelectedValue.ToString());
                FillStateCombo(dtb_state);
            }
            if(cmb_state.SelectedIndex>=0)
            {
                DataTable dtb_city = this.cntrl.state_selectedIndexChanged(cmb_state.SelectedValue.ToString());
                FillCityCombo(dtb_city);
            }
            DataTable dt_speci = this.cntrl.Fill_SpecializationCombo();
            FilSpecializationCombo(dt_speci);
            toolStripButton1.Text = this.cntrl.Load_CompanyName();
            txtname.Text = "";
            DataTable dtb = this.cntrl.GetData();
            GetData(dtb);
        }

        public void GetData(DataTable dtb_details)
        {
            try
            {
                btn_Save.Text = "Save";
                if (dtb_details.Rows.Count > 0)
                {
                    DataTable dtb = this.cntrl.Get_CountryNme(dtb_details.Rows[0]["country_id"].ToString(), "Country");
                    Get_CmbName(dtb, "Country");
                    DataTable dtb1 = this.cntrl.Get_CountryNme(dtb_details.Rows[0]["city_id"].ToString(), "City");
                    Get_CmbName(dtb1, "City");
                    DataTable dtb2 = this.cntrl.Get_CountryNme(dtb_details.Rows[0]["state_id"].ToString(), "State");
                    Get_CmbName(dtb2, "State");
                    DataTable dtb3 = this.cntrl.Get_CountryNme(dtb_details.Rows[0]["specialization"].ToString(), "Specialization");
                    Get_CmbName(dtb3, "Specialization");
                        string clini_name = dtb_details.Rows[0]["name"].ToString();
                        txtname.Text = clini_name.Replace("¤", "'");
                        toolStripButton1.Text = txtname.Text;
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
                    txtpath.Text = dtb_details.Rows[0]["path"].ToString();
                    string curFile = this.cntrl.getserver() + "\\Pappyjoe_utilities\\Logo\\" + txtpath.Text;
                    if (System.IO.File.Exists(curFile))
                    {
                        pictureBox1.Image = Image.FromFile(curFile);
                    }
                    btn_Save.Text = "Update";
                }
                else
                {
                    toolStripButton1.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !..", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Get_CmbName(DataTable dtb, string cmd)
        {
            if (dtb.Rows.Count > 0)
            {
                if (cmd == "Country")
                {
                    cmb_country.Text = dtb.Rows[0]["country"].ToString();
                }
                else if (cmd == "City")
                {
                    cmb_city.Text = dtb.Rows[0]["city"].ToString();
                }
                else if (cmd == "State")
                {
                    cmb_state.Text = dtb.Rows[0]["state"].ToString();
                }
                else if (cmd == "Specialization")
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
                    string tagn1 = "";
                    tagname = txttagline.Text;
                    tagn1 = tagname.Replace("'", " ");
                    if (btn_Save.Text == "Update")
                    {
                        string realfile = System.IO.Path.GetFileName(open.FileName);
                        int i = cntrl.Update_details(Name, tagn1, txtstreet.Text, txtlocality.Text, cmb_country.SelectedValue.ToString(), cmb_state.SelectedValue.ToString(), cmb_city.SelectedValue.ToString(), txtpincode.Text, txtcontactnumber.Text, txtemail.Text, txtwebsite.Text, txtpath.Text, cmb_specialization.SelectedValue.ToString(), txtdruglicenseno.Text, txttaxno.Text);
                        string server = this.cntrl.getserver();
                        if (realfile != "")
                        {
                            try
                            {
                                if (File.Exists(@"\\" + server + "\\Pappyjoe_utilities\\Logo\\" + realfile))
                                {
                                }
                                else
                                {
                                    System.IO.File.Copy(open.FileName, @"\\" + server + "\\Pappyjoe_utilities\\Logo\\" + realfile);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error!...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        if (i > 0)
                            MessageBox.Show("Successfully Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        int i = cntrl.Save_details(Name, tagn1, txtstreet.Text, txtlocality.Text, cmb_country.SelectedValue.ToString(), cmb_state.SelectedValue.ToString(), cmb_city.SelectedValue.ToString(), txtpincode.Text, txtcontactnumber.Text, txtemail.Text, txtwebsite.Text, cmb_specialization.SelectedValue.ToString(), txtdruglicenseno.Text, txttaxno.Text);
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
            if (dtb.Rows.Count > 0)
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
            DataTable dtb = this.cntrl.Fill_CountryCombo();
            FillCountryCombo(dtb);
        }

        private void cmb_state_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.country_selectedIndexChanged(cmb_country.SelectedValue.ToString());
            FillStateCombo(dtb);
        }

        private void cmb_city_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.state_selectedIndexChanged(cmb_state.SelectedValue.ToString());
            FillCityCombo(dtb);
        }

        private void cmb_specialization_Click(object sender, EventArgs e)
        {
            DataTable dtb = this.cntrl.Fill_SpecializationCombo();
            FilSpecializationCombo(dtb);
        }

        private void cmb_country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_country.DataSource != null)
            {
                string countryId = cmb_country.SelectedValue.ToString();
                DataTable dtb = this.cntrl.country_selectedIndexChanged(countryId);
                FillStateCombo(dtb);
            }
        }

        private void cmb_state_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_state.DataSource != null)
            {
                string stateId = cmb_state.SelectedValue.ToString();
                DataTable dtb = this.cntrl.state_selectedIndexChanged(stateId);
                FillCityCombo(dtb);
            }
            else
            {
                cmb_city.DataSource = null;
            }
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
            button_contacts.BackColor = Color.SteelBlue;
            form_hide();
            contct.TopLevel = false;
            panel_main.Controls.Add(contct);
            contct.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            contct.Show();
        }

        private void button_practicestaff_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            button_practicestaff.BackColor = Color.SteelBlue;
            form_hide();
            staff.TopLevel = false;
            panel_main.Controls.Add(staff);
            staff.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            //prescription_setting_controller controller = new prescription_setting_controller(prescription);
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
            //medical_history_controller controller = new medical_history_controller(medical);
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
            //autoid_generation_controller controller = new autoid_generation_controller(atuoid);
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
            //export_controller cntroller = new export_controller(exprt);
            exprt.Show();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.doctr_privillage_for_addnewPatient(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Add Patient", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new Add_New_Patients();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            backColor_change();
            btn_Inventory.BackColor = Color.SteelBlue;
            form_hide();
            var form2 = new Item_List();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var form2 = new Doctor_Profile();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        public string patient_id = "1";
        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new AppointmentBooking();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
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
        //bool focus = false;
        private void PracticeDetails_Paint(object sender, PaintEventArgs e)
        {
            ////if (focus)
            ////{ 
            ////    txtname.BorderStyle = BorderStyle.None;
            ////    Pen p = new Pen(Color.Gray);
            ////    Graphics g = e.Graphics;
            ////    //int variance = 3,Hight_Variance=6;
            ////    g.DrawRectangle(Pens.Gray, 0, 0, Width +12 , Height + 12);
            ////    //g.DrawRectangle(p, new Rectangle(txtname.Location.X - variance, txtname.Location.Y - Hight_Variance, txtname.Width + variance, txtname.Height + Hight_Variance));
            ////}
            ////else
            ////{
            ////    txtname.BorderStyle = BorderStyle.FixedSingle;
            ////}
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            //focus = true;
            //this.Refresh();
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            //focus = false;
            //this.Refresh();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new StockReport();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
                listpatientsearch.DataSource = dtdr;
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                if (listpatientsearch.Items.Count == 0)
                {
                    listpatientsearch.Visible = false;
                }
                else
                {
                    listpatientsearch.Visible = true;
                }
                listpatientsearch.Location = new Point(toolStripTextBox1.Width + 763, 30);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.permission_for_settings(doctor_id);
                if (int.Parse(id) > 0)
                {
                    var form2 = new Practice_Details();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("There is No Privilege to Clinic Settings", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                var form2 = new Practice_Details();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.Show();
            }
        }

        private void listpatientsearch_MouseClick(object sender, MouseEventArgs e)
        {
            var form2 = new Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = listpatientsearch.SelectedValue.ToString();
            listpatientsearch.Visible = false;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
            form2.Dispose();
        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void label3_Click(object sender, EventArgs e)
        //{

        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void label4_Click(object sender, EventArgs e)
        //{

        //}

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
            form2.Dispose();
        }
    }
}
