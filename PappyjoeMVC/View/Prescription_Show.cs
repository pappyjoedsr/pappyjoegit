using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace PappyjoeMVC.View
{
    public partial class Prescription_Show : Form
    {

        public Prescription_Show()
        {
            InitializeComponent();
        }
        public string doctor_id = "", staff_id = "", patient_id = "";
        string logo_name = "";
        string path = "";
        string includeheader = "0";
        string includelogo = "0";
        string paperSize_print = "";
        string prescription_id = "0";
        int topmargin1 = 0;
        string combo_topmargin = "";
        string combo_leftmargin = "";
        string combo_bottommargin = "";
        string combo_rightmargin = "";
        string combo_paper_size = "";
        string combo_footer_topmargin = "";
        string rich_fullwidth = "";
        string rich_leftsign = "";
        string rich_rightsign = "";
        string patient_details = "";
        string med = "";
        string patient = "";
        string address = "";
        string phone = "";
        string blood = "";
        string gender = "";
        string orientation = "";
        //string includeheader = "0";
        //string includelogo = "0";
        PaperSize paperSize; System.Drawing.Image logo = null;
        Connection db = new Connection();
        Prescription_Show_controller cntrl=new Prescription_Show_controller();
        private void prescriptionShow_Load(object sender, EventArgs e)
        {
            try
            {
                this.Size = Screen.PrimaryScreen.WorkingArea.Size;//to set to the screen size
                //Rasmi privilege checking
                if (doctor_id != "1")
                {
                    // add
                    string privid;
                    privid = this.cntrl.add_privillege(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='A'");
                    if (int.Parse(privid) > 0)
                    {
                        BtnAdd.Enabled = false;
                    }
                    else
                    {
                        BtnAdd.Enabled = true;
                    }
                    //edit
                    privid = this.cntrl.edit_privillege(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='E'");
                    if (int.Parse(privid) > 0)
                    {
                        editToolStripMenuItem1.Enabled = false;
                    }
                    else
                    {
                        editToolStripMenuItem1.Enabled = true;
                    }
                    //Delete
                    privid = this.cntrl.delete_privillege(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='D'");
                    if (int.Parse(privid) > 0)
                    {
                        deleteToolStripMenuItem1.Enabled = false;
                    }
                    else
                    {
                        deleteToolStripMenuItem1.Enabled = true;
                    }
                }
                //Privilege set ends
                toolStripButton18.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
                dataGridView1.Size = new System.Drawing.Size(this.Width - 312, 617);
                System.Data.DataTable clinicname = this.cntrl.Get_CompanyNAme();// db.table("select name,path from tbl_practice_details");
                if (clinicname.Rows.Count > 0)
                {
                    string clinicn = "";
                    clinicn = clinicname.Rows[0][0].ToString();
                    toolStripButton10.Text = clinicn.Replace("¤", "'");
                    path = clinicname.Rows[0]["path"].ToString();
                    string docnam = this.cntrl.Get_DoctorName(doctor_id);
                    if (docnam != "")
                    {
                        toolStripTextDoctor.Text = "Logged In As : " + docnam;
                    }
                    if (path != "")
                    {
                        if (File.Exists(db.server() + path))
                        {
                            logo_name = "";
                            logo_name = path;//.Substring(8, path.Length - 8);
                            string Apppath = System.IO.Directory.GetCurrentDirectory();
                            if (!File.Exists(Apppath + "\\" + logo_name))
                            {
                                System.IO.File.Copy(db.server() + path, Apppath + "\\" + logo_name);
                            }
                        }
                        else
                        {
                            logo_name = "";
                        }
                    }
                }
                //dataGridView1.Location = new System.Drawing.Point(206, 129);
                //panel7.Location = new System.Drawing.Point(206, 88);
                //pictureBox1.Image = Pappyjoe.Properties.Resources.nophoto;
                listpatientsearch.Hide();
                // panel_sendemail.Hide();
                System.Data.DataTable pat = this.cntrl.Get_pat_iDName(patient_id);// db.table("select pt_name,pt_id from tbl_patient where id='" + patient_id + "'");
                if (pat.Rows.Count != 0)
                {
                    linkLabel_id.Text = pat.Rows[0]["pt_id"].ToString();
                    linkLabel_Name.Text = pat.Rows[0]["pt_name"].ToString();
                }
                dataGridView1.ColumnCount = 6;
                dataGridView1.RowCount = 0;
                dataGridView1.ColumnHeadersVisible = false;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DataTable dt_pre_main = this.cntrl.Get_maindtails(patient_id);
                Load_MainGrid(dt_pre_main);
            }
            catch (Exception ex)
            {

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.cntrl.printsettings();// db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign from tbl_presciption_printsettings");
                if (print.Rows.Count > 0)
                {
                    header1 = print.Rows[0]["header"].ToString();
                    header2 = print.Rows[0]["left_text"].ToString();
                    header3 = print.Rows[0]["right_text"].ToString();
                    strfooter1 = print.Rows[0]["fullwidth_context"].ToString();
                    strfooter2 = print.Rows[0]["left_sign"].ToString();
                    strfooter3 = print.Rows[0]["right_sign"].ToString();
                }
                int xx = 30;
                int yy = 185;
                if (includeheader == "1")
                {
                    if (includelogo == "1")
                    {
                        string pathimage = db.server();
                        System.Data.DataTable dtp = this.cntrl.clinicpath();// db.table("select path from tbl_practice_details");
                        System.Drawing.Image logo = null;
                        try
                        {
                            if (dtp.Rows.Count > 0)
                            {
                                string path = dtp.Rows[0]["path"].ToString();
                                logo = System.Drawing.Image.FromFile(pathimage + path);
                                e.Graphics.DrawImage(logo, 30, 60, 75, 75);
                                xx = 120;
                            }
                        }
                        catch { }
                    } //logo
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Segoe UI", 16))
                    {
                        e.Graphics.DrawString(header1, printFont, Brushes.Black, xx, 70);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Segoe UI", 12))
                    {
                        e.Graphics.DrawString(header2, printFont, Brushes.Black, xx, 100);
                    }
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Segoe UI", 10))
                    {
                        e.Graphics.DrawString(header3, printFont, Brushes.Black, xx, 120);
                    }
                }//header
                yy = 185;
                System.Data.DataTable dt1 = this.cntrl.patient_details(patient_id);// db.table("select pt_id,pt_name,gender,age,street_address,city,primary_mobile_number from tbl_patient where id='" + patient_id + "'");
                if (dt1.Rows.Count > 0)
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(Color.Gray);
                    if (paperSize_print == "A5")
                    {
                        g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(500, 175));
                    }
                    else if (paperSize_print == "A4")
                    {
                        g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(800, 175));
                    }
                    else if (paperSize_print == "A3")
                    {
                        g.DrawLine(pen, new System.Drawing.Point(20, 175), new System.Drawing.Point(1150, 175));
                    }
                    string sexage = ""; int Dexist = 0; string address = "";
                    using (System.Drawing.Font printFont = new System.Drawing.Font("Segoe UI", 9))
                    {
                        string doctor_name = "";
                        using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 10))
                        {
                            e.Graphics.DrawString(dt1.Rows[0]["pt_name"].ToString(), printFont1, Brushes.Black, 20, yy);
                            if (dt1.Rows[0]["gender"].ToString() != "")
                            {
                                sexage = dt1.Rows[0]["gender"].ToString();
                                Dexist = 1;
                            }
                            if (dt1.Rows[0]["age"].ToString() != "")
                            {
                                if (Dexist == 1)
                                {
                                    sexage = sexage + ", " + dt1.Rows[0]["age"].ToString() + " Years";
                                }
                                else
                                {
                                    sexage = dt1.Rows[0]["age"].ToString() + " Years";
                                }
                            }
                            e.Graphics.DrawString(sexage, printFont1, Brushes.Black, 300, yy);
                        }
                        yy = yy + 22;
                        e.Graphics.DrawString("Patient id:" + dt1.Rows[0]["pt_id"].ToString(), printFont, Brushes.Black, 20, yy);
                        Dexist = 0;
                        if (dt1.Rows[0]["street_address"].ToString() != "")
                        {
                            address = dt1.Rows[0]["street_address"].ToString();
                            Dexist = 1;
                        }

                        if (dt1.Rows[0]["city"].ToString() != "")
                        {
                            if (Dexist == 1)
                            {
                                address = address + ",";
                            }
                            address = address + dt1.Rows[0]["city"].ToString();
                            Dexist = 1;
                        }
                        e.Graphics.DrawString(address, printFont, Brushes.Black, 300, yy);
                        if (dt1.Rows[0]["primary_mobile_number"].ToString() != "")
                        {
                            yy = yy + 20;
                            e.Graphics.DrawString("Contact:" + dt1.Rows[0]["primary_mobile_number"].ToString(), printFont, Brushes.Black, 20, yy);
                        }
                        yy = yy + 20;
                        yy = yy + 20;
                        if (paperSize_print == "A5")
                        {
                            g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(500, yy));
                        }
                        else if (paperSize_print == "A4")
                        {
                            g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(800, yy));
                        }
                        else if (paperSize_print == "A3")
                        {
                            g.DrawLine(pen, new System.Drawing.Point(20, yy), new System.Drawing.Point(1150, yy));
                        }

                        yy = yy + 30;
                        Dexist = 0;
                        System.Data.DataTable dt_cf = this.cntrl.patient_prescptn(prescription_id, patient_id);// db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and tbl_prescription_main.pt_id='" + patient_id + "'");
                        if (dt_cf.Rows.Count > 0)
                        {

                            e.Graphics.DrawString("By:", printFont, Brushes.Black, 20, yy);
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 10))
                            {
                                e.Graphics.DrawString("Dr." + Convert.ToString(dt_cf.Rows[0]["doctor_name"].ToString()), printFont1, Brushes.Black, 45, yy);
                                doctor_name = Convert.ToString(dt_cf.Rows[0]["doctor_name"].ToString());
                            }
                            yy = yy + 30;
                            if (paperSize_print == "A5")
                            {
                                e.Graphics.DrawString("Date: ", printFont, Brushes.Black, 400, yy);
                                using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 10))
                                {
                                    DateTime tdate = Convert.ToDateTime(dt_cf.Rows[0]["date"].ToString());
                                    e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 430, yy);
                                }
                            }
                            else if (paperSize_print == "A4")
                            {
                                e.Graphics.DrawString("Date: ", printFont, Brushes.Black, 690, yy);
                                using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 10))
                                {
                                    DateTime tdate = Convert.ToDateTime(dt_cf.Rows[0]["date"].ToString());
                                    e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 720, yy);
                                }
                            }
                            else if (paperSize_print == "A3")
                            {
                                e.Graphics.DrawString("Date: ", printFont, Brushes.Black, 1040, yy);
                                using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 10))
                                {
                                    DateTime tdate = Convert.ToDateTime(dt_cf.Rows[0]["date"].ToString());
                                    e.Graphics.DrawString(tdate.ToString("dd MMM yyyy"), printFont1, Brushes.Black, 1070, yy);
                                }
                            }
                            using (System.Drawing.Font printFont1 = new System.Drawing.Font("Segoe UI", 14))
                            {
                                e.Graphics.DrawString("P", printFont1, Brushes.Black, 20, yy);
                                using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 12))
                                {
                                    e.Graphics.DrawString("x", printFont2, Brushes.Black, 26, yy + 5);
                                }
                                e.Graphics.DrawString("Prescriptions", printFont1, Brushes.Black, 51, yy);
                            }
                            yy = yy + 30;
                            if (paperSize_print == "A5")
                            {
                                yy = yy + 20;
                                using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 11))
                                {
                                    e.Graphics.DrawString("Drug Name", printFont2, Brushes.Black, 51, yy - 15);
                                    e.Graphics.DrawString("Strength", printFont2, Brushes.Black, 200, yy - 15);
                                    e.Graphics.DrawString("Frequency", printFont2, Brushes.Black, 300, yy - 15);
                                    e.Graphics.DrawString("Instructions", printFont2, Brushes.Black, 400, yy - 15);
                                }
                            }
                            else if (paperSize_print == "A4")
                            {
                                yy = yy + 20;
                                using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 11))
                                {
                                    e.Graphics.DrawString("Drug Name", printFont2, Brushes.Black, 51, yy - 15);
                                    e.Graphics.DrawString("Strength", printFont2, Brushes.Black, 300, yy - 15);
                                    e.Graphics.DrawString("Frequency", printFont2, Brushes.Black, 420, yy - 15);
                                    e.Graphics.DrawString("Instructions", printFont2, Brushes.Black, 600, yy - 15);
                                }
                            }
                            else if (paperSize_print == "A3")
                            {
                                yy = yy + 20;
                                using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 11))
                                {
                                    e.Graphics.DrawString("Drug Name", printFont2, Brushes.Black, 51, yy - 15);
                                    e.Graphics.DrawString("Strength", printFont2, Brushes.Black, 300, yy - 15);
                                    e.Graphics.DrawString("Frequency", printFont2, Brushes.Black, 420, yy - 15);
                                    e.Graphics.DrawString("Instructions", printFont2, Brushes.Black, 600, yy - 15);
                                }
                            }
                            yy = yy - 10;
                            System.Data.DataTable dt_prescription = this.cntrl.prescription_details(prescription_id);// db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,status FROM tbl_prescription WHERE pres_id='" + prescription_id + "' ORDER BY id");
                            if (dt_prescription.Rows.Count > 0)
                            {
                                yy = yy + 10;
                                for (int k = 0; k < dt_prescription.Rows.Count; k++)
                                {
                                    yy = yy + 40;
                                    string morning = "";
                                    string noon = "";
                                    string night = "";
                                    string a1 = dt_prescription.Rows[k]["morning"].ToString();
                                    string[] b1 = a1.Split('.');
                                    int right1 = int.Parse(b1[1]);
                                    morning = Convert.ToString(int.Parse(b1[0]));
                                    if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                                    string a2 = dt_prescription.Rows[k]["noon"].ToString();
                                    string[] b2 = a2.Split('.');
                                    int right2 = int.Parse(b2[1]);
                                    noon = Convert.ToString(int.Parse(b2[0]));
                                    if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                                    string a3 = dt_prescription.Rows[k]["night"].ToString();
                                    string[] b3 = a3.Split('.');
                                    int right3 = int.Parse(b3[1]);
                                    night = Convert.ToString(int.Parse(b3[0]));
                                    if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                                    if (paperSize_print == "A5")
                                    {
                                        e.Graphics.DrawString(Convert.ToString(k + 1), printFont, Brushes.Black, 20, yy);
                                        e.Graphics.DrawString(dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString(), printFont, Brushes.Black, 51, yy);
                                        e.Graphics.DrawString(dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString(), printFont, Brushes.Black, 200, yy);
                                        e.Graphics.DrawString(morning, printFont, Brushes.Black, 275, yy);
                                        e.Graphics.DrawString(noon, printFont, Brushes.Black, 305, yy);
                                        e.Graphics.DrawString(night, printFont, Brushes.Black, 335, yy);
                                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 6))
                                        {
                                            if (dt_prescription.Rows[k]["status"].ToString() == "1")
                                            {
                                                e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 260, yy - 10);
                                                e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 290, yy - 10);
                                                e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 325, yy - 10);
                                            }
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString(), printFont2, Brushes.Black, 400, yy - 10);
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["food"].ToString(), printFont2, Brushes.Black, 400, yy);
                                        }
                                        using (System.Drawing.Font printFon2 = new System.Drawing.Font("Segoe UI", 6))
                                        {
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["add_instruction"].ToString(), printFon2, Brushes.Black, 51, yy + 15);
                                        }
                                    }
                                    else if (paperSize_print == "A4")
                                    {
                                        e.Graphics.DrawString(Convert.ToString(k + 1), printFont, Brushes.Black, 20, yy);
                                        e.Graphics.DrawString(dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString(), printFont, Brushes.Black, 51, yy);
                                        e.Graphics.DrawString(dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString(), printFont, Brushes.Black, 300, yy);
                                        e.Graphics.DrawString(morning, printFont, Brushes.Black, 430, yy);
                                        e.Graphics.DrawString(noon, printFont, Brushes.Black, 460, yy);
                                        e.Graphics.DrawString(night, printFont, Brushes.Black, 490, yy);
                                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 6.0f))
                                        {
                                            if (dt_prescription.Rows[k]["status"].ToString() == "1")
                                            {
                                                e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                                                e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                                                e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                                            }
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString(), printFont2, Brushes.Black, 600, yy - 10);
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["food"].ToString(), printFont2, Brushes.Black, 600, yy);
                                        }

                                        using (System.Drawing.Font printFon2 = new System.Drawing.Font("Segoe UI", 6))
                                        {
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["add_instruction"].ToString(), printFon2, Brushes.Black, 51, yy + 15);
                                        }
                                    }
                                    else if (paperSize_print == "A3")
                                    {
                                        e.Graphics.DrawString(Convert.ToString(k + 1), printFont, Brushes.Black, 20, yy);
                                        e.Graphics.DrawString(dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString(), printFont, Brushes.Black, 51, yy);
                                        e.Graphics.DrawString(dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString(), printFont, Brushes.Black, 300, yy);
                                        e.Graphics.DrawString(morning, printFont, Brushes.Black, 430, yy);
                                        e.Graphics.DrawString(noon, printFont, Brushes.Black, 460, yy);
                                        e.Graphics.DrawString(night, printFont, Brushes.Black, 490, yy);
                                        using (System.Drawing.Font printFont2 = new System.Drawing.Font("Segoe UI", 6))
                                        {
                                            if (dt_prescription.Rows[k]["status"].ToString() == "1")
                                            {
                                                e.Graphics.DrawString("  Morning", printFont2, Brushes.Black, 415, yy - 10);
                                                e.Graphics.DrawString("    Noon", printFont2, Brushes.Black, 445, yy - 10);
                                                e.Graphics.DrawString("    Night", printFont2, Brushes.Black, 475, yy - 10);
                                            }
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString(), printFont2, Brushes.Black, 600, yy - 10);
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["food"].ToString(), printFont2, Brushes.Black, 600, yy);
                                        }

                                        using (System.Drawing.Font printFon2 = new System.Drawing.Font("Segoe UI", 6))
                                        {
                                            e.Graphics.DrawString(dt_prescription.Rows[k]["add_instruction"].ToString(), printFon2, Brushes.Black, 51, yy + 15);
                                        }
                                    }
                                }

                            } // Presription Sub(Drug Details) Record Count

                            if (paperSize_print == "A5")
                            {
                                e.Graphics.DrawString(Convert.ToString(dt_cf.Rows[0]["notes"].ToString()), printFont, Brushes.Black, 45, 745 - topmargin1);
                                g.DrawLine(pen, new System.Drawing.Point(20, 760 - topmargin1), new System.Drawing.Point(500, 760 - topmargin1));
                            }
                            else if (paperSize_print == "A4")
                            {
                                e.Graphics.DrawString(Convert.ToString(dt_cf.Rows[0]["notes"].ToString()), printFont, Brushes.Black, 45, 1045 - topmargin1);
                                g.DrawLine(pen, new System.Drawing.Point(20, 1060 - topmargin1), new System.Drawing.Point(800, 1060 - topmargin1));
                            }
                            else if (paperSize_print == "A3")
                            {
                                e.Graphics.DrawString(Convert.ToString(dt_cf.Rows[0]["notes"].ToString()), printFont, Brushes.Black, 45, 1520 - topmargin1);
                                g.DrawLine(pen, new System.Drawing.Point(20, 1540 - topmargin1), new System.Drawing.Point(1150, 1540 - topmargin1));
                            }
                        }// Prescription main Record Count
                        System.Drawing.Font printFt = new System.Drawing.Font("Segoe UI", 9);
                        var txtDataWidth1 = e.Graphics.MeasureString(strfooter1, printFt).Width;
                        var txtDataWidth2 = e.Graphics.MeasureString(strfooter2, printFt).Width;
                        var txtDataWidth3 = e.Graphics.MeasureString(strfooter3, printFt).Width;
                        if (paperSize_print == "A5")
                        {
                            e.Graphics.DrawString(strfooter1, printFont, Brushes.Gray, 280 - (txtDataWidth1 / 2), 765 - topmargin1);
                            e.Graphics.DrawString(strfooter2, printFont, Brushes.Gray, 280 - (txtDataWidth2 / 2), 785 - topmargin1);
                            e.Graphics.DrawString(strfooter3, printFont, Brushes.Gray, 280 - (txtDataWidth3 / 2), 800 - topmargin1);
                        }
                        else if (paperSize_print == "A4")
                        {
                            e.Graphics.DrawString(strfooter1, printFont, Brushes.Gray, 400 - (txtDataWidth1 / 2), 1065 - topmargin1);
                            e.Graphics.DrawString(strfooter2, printFont, Brushes.Gray, 400 - (txtDataWidth2 / 2), 1085 - topmargin1);
                            e.Graphics.DrawString(strfooter3, printFont, Brushes.Gray, 400 - (txtDataWidth3 / 2), 1100 - topmargin1);
                        }
                        else if (paperSize_print == "A3")
                        {
                            e.Graphics.DrawString(strfooter1, printFont, Brushes.Gray, 550 - (txtDataWidth1 / 2), 1560 - topmargin1);
                            e.Graphics.DrawString(strfooter2, printFont, Brushes.Gray, 550 - (txtDataWidth2 / 2), 1580 - topmargin1);
                            e.Graphics.DrawString(strfooter3, printFont, Brushes.Gray, 550 - (txtDataWidth3 / 2), 1600 - topmargin1);
                        }
                    } // main printFont Stop
                } // Patient Details record Count Stop

            }
            catch (Exception ex)
            {
                MessageBox.Show("Printer Error..!!! Please check printer cable connection....");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Add();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverColumn = dataGridView1.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0)
                {
                    if (currentMouseOverColumn == 5)
                    {
                        if (dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString() != "0")
                        {
                            prescription_id = dataGridView1.Rows[currentMouseOverRow].Cells[0].Value.ToString();
                            contextMenuStrip1.Show(dataGridView1, new System.Drawing.Point(890 - 120, e.Y));//925
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.edit_privillege(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='E'");
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Edit Prescription", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    if (prescription_id != "0")
                    {
                        var form2 = new Prescription_Add();
                        form2.doctor_id = doctor_id;
                        form2.prescription_id = prescription_id;
                        form2.patient_id = patient_id;
                        form2.Closed += (sender1, args) => this.Close();
                        this.Hide();
                        form2.ShowDialog();
                    }
                }
            }
            else
            {
                if (prescription_id != "0")
                {
                    var form2 = new Prescription_Add();
                    form2.doctor_id = doctor_id;
                    form2.prescription_id = prescription_id;
                    form2.patient_id = patient_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.delete_privillege(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='EMRP' and Permission='D'");
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to Edit Prescription", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    dlt_privilige();
                }
            }
            else
            {
                dlt_privilige();
            }
        }
        public void dlt_privilige()
        {
            try
            {
                if (prescription_id != "0")
                {
                    DialogResult res = MessageBox.Show("Are you sure you want to delete..?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        this.cntrl.delete_prescription(prescription_id);
                        db.execute("delete from tbl_prescription_main where id='" + prescription_id + "'");
                        db.execute("delete from tbl_prescription where pres_id='" + prescription_id + "'");
                        this.cntrl.Get_maindtails(patient_id);
                        dataGridView1.Rows.Clear();
                        dataGridView1.ColumnCount = 6;
                        dataGridView1.RowCount = 0;
                        dataGridView1.ColumnHeadersVisible = false;
                        dataGridView1.RowHeadersVisible = false;
                        dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        System.Data.DataTable dt_pre_main = this.cntrl.Get_maindta(patient_id);// db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id  where tbl_prescription_main.pt_id='" + patient_id + "' ORDER BY tbl_prescription_main.date DESC");
                        int i = 0;
                        for (int j = 0; j < dt_pre_main.Rows.Count; j++)
                        {
                            dataGridView1.Rows.Add("0", String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pre_main.Rows[j]["date"].ToString())), "", "", "");
                            dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                            dataGridView1.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                            dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                            i = i + 1;
                            dataGridView1.Rows.Add(dt_pre_main.Rows[j]["id"].ToString(), "Drug", "Frequency", "Duration", "Instruction", "");
                            dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                            dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.LightGray;
                            dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightGray;
                            dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.LightGray;
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.LightGray;
                            dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                            dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                            dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                            dataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.Black;
                            dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.Bill;
                            System.Data.DataTable dt_prescription = this.cntrl.prescription_details((dt_pre_main.Rows[j]["id"].ToString()));// db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr FROM tbl_prescription WHERE pres_id='" + dt_pre_main.Rows[j]["id"].ToString() + "' ORDER BY id");
                            if (dt_prescription.Rows.Count > 0)
                            {
                                for (int k = 0; k < dt_prescription.Rows.Count; k++)
                                {
                                    i = i + 1;
                                    string morning = "";
                                    string noon = "";
                                    string night = "";
                                    string a1 = dt_prescription.Rows[k]["morning"].ToString();
                                    string[] b1 = a1.Split('.');
                                    int right1 = int.Parse(b1[1]);
                                    morning = Convert.ToString(int.Parse(b1[0]));
                                    if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                                    string a2 = dt_prescription.Rows[k]["noon"].ToString();
                                    string[] b2 = a2.Split('.');
                                    int right2 = int.Parse(b2[1]);
                                    noon = Convert.ToString(int.Parse(b2[0]));
                                    if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                                    string a3 = dt_prescription.Rows[k]["night"].ToString();
                                    string[] b3 = a3.Split('.');
                                    int right3 = int.Parse(b3[1]);
                                    night = Convert.ToString(int.Parse(b3[0]));
                                    if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                                    dataGridView1.Rows.Add("0", dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString() + " " + dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString(), morning + " - " + noon + " - " + night, dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString(), dt_prescription.Rows[k]["add_instruction"].ToString(), "");
                                    dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                                    dataGridView1.Rows[i].Height = 30;
                                }
                            }
                            i = i + 1;
                            dataGridView1.Rows.Add("0", "Prescribed by Dr." + dt_pre_main.Rows[j]["doctor_name"].ToString(), "", "", "");
                            dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                            dataGridView1.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                            dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                            dataGridView1.Rows.Add("0", "", "", "", "");
                            dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                            i = i + 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult yesno = MessageBox.Show("Are you sure you want copy this prescription..??", "Copy...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesno == DialogResult.Yes)
            {
                int presid;
                if (prescription_id != "0")
                {
                    System.Data.DataTable td_prescription_main = this.cntrl.get_presctnMain(prescription_id);// db.table("SELECT id,pt_id,dr_id,date,notes FROM tbl_prescription_main WHERE id='" + prescription_id + "' ORDER BY id");
                    if (td_prescription_main.Rows.Count > 0)
                    {
                        this.cntrl.save_prescriptionmain(td_prescription_main.Rows[0]["pt_id"].ToString(), td_prescription_main.Rows[0]["dr_id"].ToString(), td_prescription_main.Rows[0]["notes"].ToString());// db.table("insert into tbl_prescription_main (pt_id,dr_id,date,notes) values('" + td_prescription_main.Rows[0]["pt_id"].ToString() + "','" + td_prescription_main.Rows[0]["dr_id"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + td_prescription_main.Rows[0]["notes"].ToString() + "')");
                        string  dt = this.cntrl.Maxid();// db.table("select MAX(id) from tbl_prescription_main");
                        if (Convert.ToInt32( dt)> 0)
                        {
                            presid = Int32.Parse(dt);
                        }
                        else
                        {
                            presid = 1;
                        }
                        System.Data.DataTable td_prescription_Sub = this.cntrl.get_allprescription(prescription_id);// db.table("SELECT pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id FROM tbl_prescription  WHERE pres_id= '" + prescription_id + "' ORDER BY id");
                        if (td_prescription_Sub.Rows.Count > 0)
                        {
                            for (int k = 0; k < td_prescription_Sub.Rows.Count; k++)
                            {
                                //this.cntrl.save_prescription(presid,);//  db.table("insert into tbl_prescription (pres_id,pt_id,dr_name,dr_id,date,drug_name,strength,strength_gr,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,status,drug_id) values
                                this.cntrl.save_prescription(presid, td_prescription_Sub.Rows[k]["pt_id"].ToString(), td_prescription_Sub.Rows[k]["dr_name"].ToString(), td_prescription_Sub.Rows[k]["dr_id"].ToString(), DateTime.Now.ToString("yyyy-MM-dd"), td_prescription_Sub.Rows[k]["drug_name"].ToString(), td_prescription_Sub.Rows[k]["strength"].ToString(), td_prescription_Sub.Rows[k]["strength_gr"].ToString(), td_prescription_Sub.Rows[k]["duration_unit"].ToString(), td_prescription_Sub.Rows[k]["duration_period"].ToString(), td_prescription_Sub.Rows[k]["morning"].ToString(), td_prescription_Sub.Rows[k]["noon"].ToString(), td_prescription_Sub.Rows[k]["night"].ToString(), td_prescription_Sub.Rows[k]["food"].ToString(), td_prescription_Sub.Rows[k]["add_instruction"].ToString(), td_prescription_Sub.Rows[k]["drug_type"].ToString(), td_prescription_Sub.Rows[k]["status"].ToString(), td_prescription_Sub.Rows[k]["drug_id"].ToString());
                            }
                        }
                    }
                    // List Prescriptions..
                    dataGridView1.Rows.Clear();
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.RowCount = 0;
                    dataGridView1.ColumnHeadersVisible = false;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    this.cntrl.Get_maindtails(patient_id);
                    // Show Prescription
                }
            }//end
        }

        private void emailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mprintosave();
        }
        public void mprintosave()
        {
            try
            {
                int p = 0;
                string doct = this.cntrl.Get_DoctorName(doctor_id);// db.table("select doctor_name from tbl_doctor where id='" + doctor_id + "'");
                string doctor_name = "";
                if (doct != "")
                {
                    doctor_name = doct;
                }
                System.Data.DataTable patient = this.cntrl.get_emailpatientdetails(patient_id);// db.table("select pt_name,gender,street_address,city,primary_mobile_number,date,date_of_birth from tbl_patient where id='" + patient_id + "'");
                string Pname = "", Gender = "", address = "", DOA = "", age = "", Mobile = "";
                if (patient.Rows.Count > 0)
                {
                    Pname = patient.Rows[0]["pt_name"].ToString();
                    Gender = patient.Rows[0]["gender"].ToString();
                    address = patient.Rows[0]["street_address"].ToString() + " , " + patient.Rows[0]["city"].ToString();
                    Mobile = patient.Rows[0]["primary_mobile_number"].ToString();
                    DOA = DateTime.Parse(patient.Rows[0]["date"].ToString()).ToString("dd/MM/yyyy");
                    if (patient.Rows[0]["date_of_birth"].ToString() != "")
                    {
                        age = DateTime.Parse(patient.Rows[0]["date_of_birth"].ToString()).ToString("dd/MM/yyyy");
                    }
                }
                int Dexist = 0;
                string contact_no = "";
                string clinic_name = "";
                System.Data.DataTable dtp = this.cntrl.Get_companynameNo();// db.table("select name,contact_no from tbl_practice_details");
                if (dtp.Rows.Count > 0)
                {
                    clinic_name = dtp.Rows[0]["name"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                }

                string Apppath = System.IO.Directory.GetCurrentDirectory();
                StreamWriter sWrite = new StreamWriter(Apppath + "\\PrescriptionPrint.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br><br><br>");

                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=4>" + clinic_name.ToString() + "</font></th></tr>");
                sWrite.WriteLine("<tr><th align='left'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>" + contact_no.ToString() + "</font></th></tr>");
                sWrite.WriteLine("</table>");

                sWrite.WriteLine("<br>");
                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");

                sWrite.WriteLine(" <tr height='40px'>");
                sWrite.WriteLine("    <td align='left' width='400px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Consulted by : <b> " + doctor_name.ToString() + " </b></font></td>");
                sWrite.WriteLine("	<td align='left' width='170px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2></font></td>");
                sWrite.WriteLine("	<td align='left' width='130px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2></font></td>");
                sWrite.WriteLine(" </tr>");

                sWrite.WriteLine("<tr>");

                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Name :<b>" + Pname.ToString() + " </b></font></td>");
                sWrite.WriteLine("	<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>DOB : <b> " + age.ToString() + " </b></font></td>");
                sWrite.WriteLine("	<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Gender : <b>" + Gender.ToString() + " </b></font></td>");
                sWrite.WriteLine(" </tr>");
                sWrite.WriteLine(" <tr>");
                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Address :<b> " + address.ToString() + "</b></font></td>");
                sWrite.WriteLine("	<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>DOA : <b> " + DOA + "</b></font></td>");

                sWrite.WriteLine(" </tr>");

                sWrite.WriteLine(" <tr>");
                sWrite.WriteLine("    <td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Mobile No:<b> " + Mobile.ToString() + "</b></font></td>");
                sWrite.WriteLine(" </tr>");

                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<br>");

                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px;border-collapse: collapse;'>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td>");
                sWrite.WriteLine("<hr>");
                sWrite.WriteLine("<table align='center'  style='border: 1px ;border-collapse: collapse;' >");

                // Prescription
                System.Data.DataTable dt_prescription = this.cntrl.prescription_details(prescription_id);// db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,status FROM tbl_prescription WHERE pres_id='" + prescription_id + "' ORDER BY id");
                if (dt_prescription.Rows.Count > 0)
                {
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("    <td align='left' width='230px' bgcolor=black><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> &nbsp;PRESCRIPTIONS&nbsp;&nbsp;&nbsp;</font></th>");
                    sWrite.WriteLine("    <td align='left' width='230px' bgcolor='#999999'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> &nbsp;&nbsp;</font></th>");
                    sWrite.WriteLine("	<td align='left'  width='230px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2></font></th>");
                    sWrite.WriteLine("</tr>");

                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' colspan='2' >");

                    sWrite.WriteLine("<table align='center'  style='border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='230px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;&nbsp;DRUGNAME</b> </font></td>");
                    sWrite.WriteLine("<td align='left' width='230px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;STRENGTH</b> </font></td>");
                    sWrite.WriteLine("<td align='left'width='230px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;&nbsp;&nbsp;FREEQUENCY</b> </font></td>");
                    sWrite.WriteLine("<td align='left'width='230px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>&nbsp;&nbsp;&nbsp;INSTRUCTIONS</b> </font></td>");
                    sWrite.WriteLine("</tr>");

                    while (p < dt_prescription.Rows.Count)
                    {

                        string morning = "";
                        string noon = "";
                        string night = "";
                        string a1 = dt_prescription.Rows[p]["morning"].ToString();
                        string[] b1 = a1.Split('.');
                        int right1 = int.Parse(b1[1]);
                        morning = Convert.ToString(int.Parse(b1[0]));
                        if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }

                        string a2 = dt_prescription.Rows[p]["noon"].ToString();
                        string[] b2 = a2.Split('.');
                        int right2 = int.Parse(b2[1]);
                        noon = Convert.ToString(int.Parse(b2[0]));
                        if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }

                        string a3 = dt_prescription.Rows[p]["night"].ToString();
                        string[] b3 = a3.Split('.');
                        int right3 = int.Parse(b3[1]);
                        night = Convert.ToString(int.Parse(b3[0]));
                        if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }

                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("    <td align='left' width='230px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;&nbsp;&nbsp;&nbsp;" + dt_prescription.Rows[p]["drug_type"].ToString() + "" + dt_prescription.Rows[p]["drug_name"].ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='left' width='230px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dt_prescription.Rows[p]["strength"].ToString() + "" + dt_prescription.Rows[p]["strength_gr"].ToString() + "</font></th>");
                        sWrite.WriteLine("    <td align='left' width='230px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;&nbsp;&nbsp;" + morning + "-" + noon + "-" + night + "</font></th>");
                        sWrite.WriteLine("    <td align='left' width='230px' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;&nbsp;&nbsp;" + dt_prescription.Rows[p]["duration_unit"].ToString() + " " + dt_prescription.Rows[p]["duration_period"].ToString() + "-" + dt_prescription.Rows[p]["add_instruction"].ToString() + "</font></th>");
                        sWrite.WriteLine("</tr>");
                        p++;
                    }

                    sWrite.WriteLine(" </table>");
                    sWrite.WriteLine(" </td>");
                    sWrite.WriteLine("</tr>");

                    sWrite.WriteLine("<tr >");
                    sWrite.WriteLine("    <td align='left' height='20'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3></font></th>");
                    sWrite.WriteLine("</tr>");

                }

                sWrite.WriteLine("</table>");
                sWrite.WriteLine("</td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");

                sWrite.WriteLine("</body>");
                sWrite.WriteLine("</html>");
                sWrite.Close();

                // mail senting...

                string email = "", emailName = "", emailPass = "";
                string query = "select email_address,pt_name from tbl_patient where id='" + patient_id + "'";
                System.Data.DataTable sr = db.table(query);
                if (sr.Rows.Count > 0)
                {
                    email = sr.Rows[0]["email_address"].ToString();
                    if (email != "")
                    {
                        System.Data.DataTable sms = db.table("select emailName,emailPass from tbl_SmsEmailConfig");
                        if (sms.Rows.Count > 0)
                        {
                            emailName = sms.Rows[0]["emailName"].ToString();
                            emailPass = sms.Rows[0]["emailPass"].ToString();
                            try
                            {
                                StreamReader reader = new StreamReader(Apppath + "\\PrescriptionPrint.html");
                                string readFile = reader.ReadToEnd();
                                string StrContent = "";
                                StrContent = readFile;
                                MailMessage message = new MailMessage();
                                message.From = new MailAddress(email);
                                message.To.Add(email);
                                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                                message.Subject = "Prescription";
                                message.Body = StrContent.ToString();
                                message.IsBodyHtml = true;
                                smtp.Port = 587;
                                smtp.Host = "smtp.gmail.com";
                                smtp.EnableSsl = true;
                                smtp.UseDefaultCredentials = false;
                                smtp.Credentials = new System.Net.NetworkCredential(emailName, emailPass);
                                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                                smtp.Send(message);
                                MessageBox.Show("Email is Sent To : " + email);
                                reader.Close();
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Activate Email Configuration");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Add EmailId for Selected patient");
                    }
                }

                //...end
            }
            catch (Exception ex)
            {
            }
        }

        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Data.DataTable print = this.cntrl.printsettings_details();// db.table("select * from tbl_presciption_printsettings");
            if (print.Rows.Count > 0)
            {
                combo_topmargin = print.Rows[0][4].ToString();
                combo_leftmargin = print.Rows[0][5].ToString();
                combo_bottommargin = print.Rows[0][6].ToString();
                combo_rightmargin = print.Rows[0][7].ToString();
                combo_paper_size = print.Rows[0][1].ToString();
                combo_footer_topmargin = print.Rows[0][22].ToString();
                rich_fullwidth = print.Rows[0][23].ToString();
                rich_leftsign = print.Rows[0][24].ToString();
                rich_rightsign = print.Rows[0][25].ToString();

                patient_details = print.Rows[0][14].ToString();
                med = print.Rows[0][15].ToString();
                patient = print.Rows[0][16].ToString();
                address = print.Rows[0][17].ToString();
                phone = print.Rows[0][18].ToString();
                blood = print.Rows[0][20].ToString();
                gender = print.Rows[0][21].ToString();
                orientation = print.Rows[0][2].ToString();
                includeheader = print.Rows[0]["include_header"].ToString();
                includelogo = print.Rows[0]["include_logo"].ToString();
            }
            printhtml();

        }
        private void printhtml()
        {
            try
            {
                string clinicn = "";
                string Clinic = "";
                string streetaddress = "";
                string contact_no = "";
                string str_locality = "";
                string str_pincode = "";
                string str_email = "";
                string str_website = "";

                System.Data.DataTable dtp = this.cntrl.Get_practiceDlNumber();// db.table("select name,street_address,locality,pincode,contact_no,email,website from tbl_practice_details");
                if (dtp.Rows.Count > 0)
                {
                    clinicn = dtp.Rows[0]["name"].ToString();
                    Clinic = clinicn.Replace("¤", "'");
                    streetaddress = dtp.Rows[0]["street_address"].ToString();
                    str_locality = dtp.Rows[0]["locality"].ToString();
                    str_pincode = dtp.Rows[0]["pincode"].ToString();
                    contact_no = dtp.Rows[0]["contact_no"].ToString();
                    str_email = dtp.Rows[0]["email"].ToString();
                    str_website = dtp.Rows[0]["website"].ToString();
                }

                string strfooter1 = "";
                string strfooter2 = "";
                string strfooter3 = "";
                string header1 = "";
                string header2 = "";
                string header3 = "";
                System.Data.DataTable print = this.cntrl.printsettings();// db.table("select header,left_text,right_text,fullwidth_context,left_sign,right_sign from tbl_presciption_printsettings");
                if (print.Rows.Count > 0)
                {
                    header1 = print.Rows[0]["header"].ToString();
                    header2 = print.Rows[0]["left_text"].ToString();
                    header3 = print.Rows[0]["right_text"].ToString();
                    strfooter1 = print.Rows[0]["fullwidth_context"].ToString();
                    strfooter2 = print.Rows[0]["left_sign"].ToString();
                    strfooter3 = print.Rows[0]["right_sign"].ToString();
                }
                string Apppath = System.IO.Directory.GetCurrentDirectory();
                System.IO.StreamWriter sWrite = new System.IO.StreamWriter(Apppath + "\\PrescriptionPrint.html");
                sWrite.WriteLine("<html>");
                sWrite.WriteLine("<head>");
                sWrite.WriteLine("</head>");
                sWrite.WriteLine("<body >");
                sWrite.WriteLine("<br>");
                if (includeheader == "1")
                {
                    if (includelogo == "1")
                    {
                        if (logo != null || logo_name != "")
                        {
                            string Appath = System.IO.Directory.GetCurrentDirectory();
                            if (File.Exists(Appath + "\\" + logo_name))
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td width='100' height='75px' align='left' rowspan='3'><img src='" + Appath + "\\" + logo_name + "' width='77' height='78' style='width:100px;height:100px;'></td>  ");
                                sWrite.WriteLine("<td width='588' align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                                sWrite.WriteLine("</table>");
                            }
                            else
                            {
                                sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                                sWrite.WriteLine("<tr>");
                                sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                                sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                                sWrite.WriteLine("</table>");
                            }
                        }
                        else
                        {
                            sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                            sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                            sWrite.WriteLine("</table>");
                        }
                    }
                    else
                    {
                        sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5>&nbsp;" + header1 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3>&nbsp;&nbsp;" + header2 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2>&nbsp;&nbsp;" + header3 + "</font></td></tr>");
                        sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                        sWrite.WriteLine("</table>");
                    }
                }
                else
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td  align='left' height='25px'><FONT  COLOR=black  face='Segoe UI' SIZE=5></font></td></tr>");
                    sWrite.WriteLine("<tr><td  align='left' height='25px'><FONT COLOR=black FACE='Segoe UI' SIZE=3></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' height='40' valign='top'> <FONT COLOR=black FACE='Segoe UI' SIZE=2></font></td></tr>");
                    sWrite.WriteLine("<tr><td align='left' colspan='2'><hr/></td></tr>");
                    sWrite.WriteLine("</table>");
                }
                int Dexist = 0;
                string sexage = "";
                string address = "";
                address = "";
                string strNote = "";
                string strreview = "NO";
                string strreview_date = "";
                System.Data.DataTable dt1 = this.cntrl.patient_details(patient_id);// db.table("select pt_id,pt_name,gender,age,street_address,locality,city,pincode,primary_mobile_number,email_address from tbl_patient where id='" + patient_id + "'");
                if (dt1.Rows.Count > 0)
                {
                    sWrite.WriteLine("<table align='center' style='width:700px;border: 1px ;border-collapse: collapse;'>");
                    sWrite.WriteLine("<tr>");
                    if (dt1.Rows[0]["gender"].ToString() != "")
                    {
                        sexage = dt1.Rows[0]["gender"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["age"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            sexage = sexage + ", " + dt1.Rows[0]["age"].ToString() + " Years";
                        }
                        else
                        {
                            sexage = dt1.Rows[0]["age"].ToString() + " Years";
                        }
                    }
                    sWrite.WriteLine(" <td align='left' height=25><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2><b>" + dt1.Rows[0]["pt_name"].ToString() + "</b><i> (" + sexage + ")</i></font></td>");
                    sWrite.WriteLine(" </tr>");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>Patient Id:" + dt1.Rows[0]["pt_id"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    Dexist = 0;
                    if (dt1.Rows[0]["street_address"].ToString() != "")
                    {
                        address = dt1.Rows[0]["street_address"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["locality"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["locality"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["city"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["city"].ToString();
                        Dexist = 1;
                    }
                    if (dt1.Rows[0]["pincode"].ToString() != "")
                    {
                        if (Dexist == 1)
                        {
                            address = address + ",";
                        }
                        address = address + dt1.Rows[0]["pincode"].ToString();
                        Dexist = 1;
                    }
                    if (address != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + address + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt1.Rows[0]["primary_mobile_number"].ToString() + " </font></td>");
                    sWrite.WriteLine(" </tr>");
                    if (dt1.Rows[0]["email_address"].ToString() != "")
                    {
                        sWrite.WriteLine("<tr>");
                        sWrite.WriteLine("<td align='left' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>" + dt1.Rows[0]["email_address"].ToString() + " </font></td>");
                        sWrite.WriteLine(" </tr>");
                    }
                    sWrite.WriteLine("<tr><td colspan=2><hr></td></tr>");
                    string doctorname = "";
                    System.Data.DataTable dt_cf = this.cntrl.table_details(prescription_id, patient_id);// db.table("SELECT tbl_prescription_main.id,tbl_prescription_main.date,tbl_doctor.doctor_name,tbl_prescription_main.notes,tbl_prescription_main.review,tbl_prescription_main.Review_date FROM tbl_prescription_main join tbl_doctor on tbl_prescription_main.dr_id=tbl_doctor.id where tbl_prescription_main.id='" + prescription_id + "' and tbl_prescription_main.pt_id='" + patient_id + "'");
                    if (dt_cf.Rows.Count > 0)
                    {
                        doctorname = Convert.ToString(dt_cf.Rows[0]["doctor_name"].ToString());
                        strNote = dt_cf.Rows[0]["notes"].ToString();
                        if (dt_cf.Rows[0]["review"].ToString() == "YES")
                        {
                            strreview = "YES";
                            strreview_date = Convert.ToDateTime(dt_cf.Rows[0]["Review_date"].ToString()).ToString("dd-MM-yyyy hh:mm tt");
                        }
                        else
                        {
                            strreview = "NO";
                        }
                    }
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' width='400px' height='30px'><FONT FACE='Geneva, Segoe UI' SIZE=2><FONT COLOR=black >By</FONT> :Dr. <b>" + doctorname + " </b></font></td>");
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                    sWrite.WriteLine("<br>");
                    sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>R</font><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=3>x&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</font><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=5>Prescription</FONT></td>");
                    sWrite.WriteLine("<td width=250px></td>");
                    if (dt_cf.Rows.Count > 0)
                    {
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Parse(dt_cf.Rows[0]["date"].ToString()).ToString("dd MMM yyyy") + "</font></td>");
                    }
                    else
                    {
                        sWrite.WriteLine("<td align='right' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2> <FONT COLOR=black>Date : </FONT>" + DateTime.Now.ToString("dd MMM yyyy") + "</font></td>");
                    }
                    sWrite.WriteLine("</tr>");
                    sWrite.WriteLine("</table>");
                }
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr >");
                sWrite.WriteLine("<td align='left' width='35px' height='30'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Sl.</font></td>");
                sWrite.WriteLine("<td align='left' width='221px' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Drug Name</font></td>");
                sWrite.WriteLine("<td align='center' width='105px' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Strength </font></td>");
                sWrite.WriteLine("<td align='center' width='114px' colspan='3' ><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Frequency</font></td>");
                sWrite.WriteLine("<td align='left' width='99px'><FONT COLOR=black FACE=' Segoe UI' SIZE=3>&nbsp;Instructions</font></td>");
                sWrite.WriteLine("</tr>");
                System.Data.DataTable dt_prescription = db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,status FROM tbl_prescription WHERE pres_id='" + prescription_id + "' ORDER BY id");
                if (dt_prescription.Rows.Count > 0)
                {
                    for (int k = 0; k < dt_prescription.Rows.Count; k++)
                    {
                        string morning = "";
                        string noon = "";
                        string night = "";
                        string a1 = dt_prescription.Rows[k]["morning"].ToString();
                        string[] b1 = a1.Split('.');
                        int right1 = int.Parse(b1[1]);
                        morning = Convert.ToString(int.Parse(b1[0]));
                        if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                        string a2 = dt_prescription.Rows[k]["noon"].ToString();
                        string[] b2 = a2.Split('.');
                        int right2 = int.Parse(b2[1]);
                        noon = Convert.ToString(int.Parse(b2[0]));
                        if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                        string a3 = dt_prescription.Rows[k]["night"].ToString();
                        string[] b3 = a3.Split('.');
                        int right3 = int.Parse(b3[1]);
                        night = Convert.ToString(int.Parse(b3[0]));
                        if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                        if (dt_prescription.Rows[k]["status"].ToString() == "1")
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td align='left' height='7'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1></font></td>");
                            sWrite.WriteLine("<td align='left' height='7'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1></font></td>");
                            sWrite.WriteLine("<td align='left' height='7'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1></font></td>");
                            sWrite.WriteLine("<td align='center' height='7' valign='bottom'  width='50px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;Morning </font></td>");
                            sWrite.WriteLine("<td align='center' height='7' valign='bottom' width='50px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;Noon </font></td>");
                            sWrite.WriteLine("<td align='center' height='7' valign='bottom'  width='50px'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;Night </font></td>");
                            sWrite.WriteLine("</tr>");
                        }

                        sWrite.WriteLine("<tr>");
                        if (dt_prescription.Rows[k]["add_instruction"].ToString() != "")
                        {
                            sWrite.WriteLine("<td align='left' height='20' valign='top'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + Convert.ToString(k + 1) + " </font></td>");
                        }
                        else
                        {
                            sWrite.WriteLine("<td align='left' height='30' valign='top'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + Convert.ToString(k + 1) + " </font></td>");
                        }
                        sWrite.WriteLine("<td align='left' valign='top'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString() + " </font></td>");
                        sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString() + " </font></td>");
                        sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + morning + " </font></td>");
                        sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + noon + " </font></td>");
                        sWrite.WriteLine("<td align='center' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + night + " </font></td>");
                        if (dt_prescription.Rows[k]["duration_unit"].ToString() == "0")
                        {
                            sWrite.WriteLine("<td align='left'   valign='top'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;" + dt_prescription.Rows[k]["food"].ToString() + " </font></td>");
                        }
                        else
                        {
                            sWrite.WriteLine("<td align='left' valign='top'><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1>&nbsp;" + dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString() + "</br>" + dt_prescription.Rows[k]["food"].ToString() + " </font></td>");
                        }
                        sWrite.WriteLine("</tr>");
                        if (dt_prescription.Rows[k]["add_instruction"].ToString() != "")
                        {
                            sWrite.WriteLine("<tr>");
                            sWrite.WriteLine("<td ></td>");
                            sWrite.WriteLine("<td align='left' height='20' colspan='7' valign='top' ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=1.5>&nbsp;" + dt_prescription.Rows[k]["add_instruction"].ToString() + " </font></td>");
                            sWrite.WriteLine("</tr>");
                        }

                    } // Presription Sub(Drug Details) Record Count
                    sWrite.WriteLine("<tr>");
                    sWrite.WriteLine("<td align='left' height='30' colspan='8'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strNote.ToString() + " </font></td>");
                    sWrite.WriteLine("</tr>");
                    if (strreview == "YES")
                    {
                        sWrite.WriteLine("<tr><td align='left' colspan=8 ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;Next Review Date : " + strreview_date + " </font></td></tr>");
                    }
                    sWrite.WriteLine("<tr><td align='left' colspan=8><hr/></td></tr>");
                }
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<table align='center'   style='width:700px;border: 1px ;border-collapse: collapse;' >");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter1 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter2 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("<tr>");
                sWrite.WriteLine("<td align='center' height='22'  ><FONT COLOR=black FACE='Geneva, Segoe UI' SIZE=2>&nbsp;" + strfooter3 + "</font></td>");
                sWrite.WriteLine("</tr>");
                sWrite.WriteLine("</table>");
                sWrite.WriteLine("<script>window.print();</script>");
                sWrite.WriteLine("</body >");
                sWrite.WriteLine("</html>");
                sWrite.Close();
                System.Diagnostics.Process.Start(Apppath + "\\PrescriptionPrint.html");
            }
            catch (Exception ex)
            {

            }
        }

        private void dotMatricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Data.DataTable print = this.cntrl.printsettings_details();// db.table("select * from tbl_presciption_printsettings");
            //    if (print.Rows.Count > 0)
            //    {
            //        combo_topmargin = print.Rows[0]["top_margin"].ToString();
            //        combo_leftmargin = print.Rows[0]["left_margin"].ToString();
            //        combo_bottommargin = print.Rows[0]["bottom_margin"].ToString();
            //        combo_rightmargin = print.Rows[0]["right_margin"].ToString();
            //        combo_paper_size = print.Rows[0]["size"].ToString();
            //        combo_footer_topmargin = print.Rows[0]["header_top"].ToString();
            //        rich_fullwidth = print.Rows[0]["fullwidth_context"].ToString();
            //        rich_leftsign = print.Rows[0]["left_sign"].ToString();
            //        rich_rightsign = print.Rows[0]["right_sign"].ToString();
            //        med = print.Rows[0]["medical_history"].ToString();
            //        patient = print.Rows[0]["patient"].ToString();
            //        address = print.Rows[0]["address"].ToString();
            //        phone = print.Rows[0]["phone"].ToString();
            //        blood = print.Rows[0]["blood_group"].ToString();
            //        gender = print.Rows[0]["gender_dob"].ToString();
            //        orientation = print.Rows[0]["orientation"].ToString();
            //        includeheader = print.Rows[0]["include_header"].ToString();
            //        includelogo = print.Rows[0]["include_logo"].ToString();
            //    }

            //    PrintDocument printdocument = new PrintDocument();
            //    printdocument.PrintPage += printDocument1_PrintPageDotmatrix;
            //    string top = combo_topmargin;
            //    int topmargin = int.Parse(top.Substring(0, top.IndexOf("m")));
            //    topmargin1 = topmargin;
            //    string bottom = combo_bottommargin;
            //    int bottommargin = int.Parse(bottom.Substring(0, bottom.IndexOf("m")));
            //    string left = combo_leftmargin;
            //    int leftmargin = int.Parse(left.Substring(0, left.IndexOf("m")));
            //    string right = combo_rightmargin;
            //    int rightmargin = int.Parse(right.Substring(0, right.IndexOf("m")));
            //    string foottop = combo_footer_topmargin;
            //    int footer = int.Parse(foottop.Substring(0, foottop.IndexOf("m")));
            //    paperSize_print = "A4";

            //    switch (combo_paper_size)
            //    {
            //        case "A3":
            //            paperSize_print = "A3";
            //            paperSize = new PaperSize("A3", 1170, 1650);
            //            break;
            //        case "A4":
            //            paperSize_print = "A4";
            //            paperSize = new PaperSize("A4", 830, 1170);
            //            break;
            //        case "A5":
            //            paperSize_print = "A5";
            //            paperSize = new PaperSize("A5", 484, 827);
            //            break;
            //        case "B4":
            //            paperSize = new PaperSize("B4", 980, 1390);
            //            break;
            //        case "B5":
            //            paperSize = new PaperSize("B5", 690, 980);
            //            break;
            //        case "LEGAL":
            //            paperSize = new PaperSize("LEGAL", 215, 355);
            //            break;
            //        case "TABLOID":
            //            paperSize = new PaperSize("TABLOID", 279, 431);
            //            break;
            //        case "FOLIO":
            //            paperSize = new PaperSize("FOLIO", 210, 330);
            //            break;
            //        case "LETTER":
            //            paperSize = new PaperSize("LETTER", 215, 279);
            //            break;
            //        case "EXECUTIVE":
            //            paperSize = new PaperSize("EXECUTIVE", 184, 266);
            //            break;
            //        case "STATEMENT":
            //            paperSize = new PaperSize("STATEMENT", 139, 215);
            //            break;
            //        default:
            //            paperSize = new PaperSize("A4", 830, 1170);
            //            break;
            //    }

            //    paperSize.RawKind = (int)PaperKind.Custom;
            //    printdocument.DefaultPageSettings.PaperSize = paperSize;
            //    printdocument.PrinterSettings.DefaultPageSettings.PaperSize = paperSize;
            //    printdocument.DefaultPageSettings.Margins.Top = topmargin;
            //    if (paperSize_print == "A5")
            //    {
            //        leftmargin = leftmargin + 150;
            //    }
            //    printdocument.DefaultPageSettings.Margins.Left = leftmargin;
            //    printdocument.DefaultPageSettings.Margins.Bottom = bottommargin;
            //    printdocument.DefaultPageSettings.Margins.Right = rightmargin;
            //    printdocument.DefaultPageSettings.Margins.Bottom = footer;
            //    printdocument.OriginAtMargins = true;
            //    printdocument.PrintPage += printDocument1_PrintPageDotmatrix;
            //    printdocument.Print();
            //}
            //catch (Exception ex)
            //{ }
        }

        private void sentSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int p = 0;
            string clinic = "";
            string contact_no = "";
            string text = "";
            string smsName = "", smsPass = "";
            string strPriscription = "";
            System.Data.DataTable sms = this.cntrl.sms_details();
            if (sms.Rows.Count > 0)
            {
                smsName = sms.Rows[0]["smsName"].ToString();
                smsPass = sms.Rows[0]["smsPass"].ToString();
            }
            System.Data.DataTable clinicname = this.cntrl.Get_companynameNo();
            if (clinicname.Rows.Count > 0)
            {
                clinic = clinicname.Rows[0][0].ToString();
                contact_no = clinicname.Rows[0][1].ToString();
            }
            SMS_model a = new SMS_model();
            System.Data.DataTable pat = this.cntrl.get_patientnumber(patient_id);// db.table("select pt_name,primary_mobile_number from tbl_patient where id='" + patient_id + "'");
            System.Data.DataTable smsreminder = this.cntrl.remindersms();// db.table("select * from tbl_appt_reminder_sms");
            if (pat.Rows.Count > 0)
            {
                //prescription msg
                System.Data.DataTable dt_prescription = this.cntrl.prescription_details(prescription_id);// db.table("SELECT drug_name,strength,duration_unit,duration_period,morning,noon,night,food,add_instruction,drug_type,strength_gr,status FROM tbl_prescription WHERE pres_id='" + prescription_id + "' ORDER BY id");
                if (dt_prescription.Rows.Count > 0)
                {
                    while (p < dt_prescription.Rows.Count)
                    {
                        string morning = "";
                        string noon = "";
                        string night = "";
                        string a1 = dt_prescription.Rows[p]["morning"].ToString();
                        string[] b1 = a1.Split('.');
                        int right1 = int.Parse(b1[1]);
                        morning = Convert.ToString(int.Parse(b1[0]));
                        if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                        string a2 = dt_prescription.Rows[p]["noon"].ToString();
                        string[] b2 = a2.Split('.');
                        int right2 = int.Parse(b2[1]);
                        noon = Convert.ToString(int.Parse(b2[0]));
                        if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                        string a3 = dt_prescription.Rows[p]["night"].ToString();
                        string[] b3 = a3.Split('.');
                        int right3 = int.Parse(b3[1]);
                        night = Convert.ToString(int.Parse(b3[0]));
                        if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                        strPriscription = strPriscription + " [" + dt_prescription.Rows[p]["drug_type"].ToString() + "]" + dt_prescription.Rows[p]["drug_name"].ToString() + "" + dt_prescription.Rows[p]["strength"].ToString() + " " + dt_prescription.Rows[p]["strength_gr"].ToString() + "/Duration " + morning + "-" + noon + "-" + night + "/ for " + dt_prescription.Rows[p]["duration_unit"].ToString() + " " + dt_prescription.Rows[p]["duration_period"].ToString() + "-" + dt_prescription.Rows[p]["add_instruction"].ToString() + "_____________________________";
                        p++;
                    }
                    //end prescription msg
                    text = "Dear " + pat.Rows[0]["pt_name"].ToString() + ", Prescription. Drug Name:" + strPriscription + "Regards With " + clinic + "," + contact_no;
                    string number = "91" + pat.Rows[0]["primary_mobile_number"].ToString();
                    a.SendSMS(smsName, smsPass, number, text);
                    this.cntrl.savecommunication(patient_id, text);//  db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + patient_id + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','patient','sent','" + text + "')");
                    MessageBox.Show("The Prescription Details Containing  Message Sent Successfully to " + pat.Rows[0]["pt_name"].ToString());
                }
            }
        }

        private void labelprofile_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id; ;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
        }

        private void toolStripButton17_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }
        private void labelappointment_Click(object sender, EventArgs e)
        {
            var form2 = new Show_Appointment();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void LabelVitalSigns_Click(object sender, EventArgs e)
        {
            var form2 = new Vital_Signs();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labeltreatment_Click(object sender, EventArgs e)
        {
            var form2 = new Treatment_Plans();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelfinished_Click(object sender, EventArgs e)
        {
            var form2 = new Finished_Procedure();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelattachment_Click(object sender, EventArgs e)
        {
            var form2 = new Attachments();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelinvoice_Click(object sender, EventArgs e)
        {
            var form2 = new Invoice();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelpayment_Click(object sender, EventArgs e)
        {
            var form2 = new Receipt();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelledger_Click(object sender, EventArgs e)
        {
            var form2 = new Ledger();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelprescription_Click(object sender, EventArgs e)
        {
            var form2 = new Prescription_Show();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labelclinical_Click(object sender, EventArgs e)
        {
            var form2 = new Clinical_Findings();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton19_Click(object sender, EventArgs e)
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
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new Add_New_Patients();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
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
                    form2.ShowDialog();
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
                form2.ShowDialog();
            }
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            toolStripTextBox2.Clear();
        }

        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text != "")
            {
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox2.Text);
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
                listpatientsearch.Location = new Point(toolStrip2.Width - 352, 39);
            }
            else
            {
                listpatientsearch.Visible = false;
            }
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.patient_id = patient_id;
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void labl_Lab_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.LabWorks();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_Name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void linkLabel_id_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.privilge_for_inventory(doctor_id);
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("There is No Privilege to View the Inventory", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    var form2 = new PappyjoeMVC.View.StockReport();
                    form2.doctor_id = doctor_id;
                    form2.Closed += (sender1, args) => this.Close();
                    this.Hide();
                    form2.ShowDialog();
                }
            }
            else
            {
                var form2 = new PappyjoeMVC.View.StockReport();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form2 = new PappyjoeMVC.View.Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.patient_id = patient_id;
            form2.ShowDialog();
        }

        public void SetController(Prescription_Show_controller controller)
        {
            cntrl = controller;
        }
        public void Load_MainGrid(DataTable dt_pre_main)
        {
            int i = 0;
            if (dt_pre_main.Rows.Count > 0)
            {
                for (int j = 0; j < dt_pre_main.Rows.Count; j++)
                {
                    dataGridView1.Rows.Add("0", String.Format("{0:dddd, MMMM d, yyyy}", Convert.ToDateTime(dt_pre_main.Rows[j]["date"].ToString())), "", "", "");
                    dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                    dataGridView1.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.DarkGreen;
                    i = i + 1;
                    dataGridView1.Rows.Add(dt_pre_main.Rows[j]["id"].ToString(), "Drug", "Frequency", "Duration", "Instruction", "");
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].Cells[2].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].Cells[3].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].Cells[5].Style.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                    dataGridView1.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                    dataGridView1.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                    dataGridView1.Rows[i].Cells[4].Style.ForeColor = Color.Black;
                    dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.Bill;
                    System.Data.DataTable dt_prescription = this.cntrl.prescription_details(dt_pre_main.Rows[j]["id"].ToString());
                    if (dt_prescription.Rows.Count > 0)
                    {
                        for (int k = 0; k < dt_prescription.Rows.Count; k++)
                        {
                            i = i + 1;
                            string morning = "";
                            string noon = "";
                            string night = "";
                            string a1 = dt_prescription.Rows[k]["morning"].ToString();
                            string[] b1 = a1.Split('.');
                            int right1 = int.Parse(b1[1]);
                            morning = Convert.ToString(int.Parse(b1[0]));
                            if (right1 != 0) { morning = morning + "." + Convert.ToString(int.Parse(b1[1])); }
                            string a2 = dt_prescription.Rows[k]["noon"].ToString();
                            string[] b2 = a2.Split('.');
                            int right2 = int.Parse(b2[1]);
                            noon = Convert.ToString(int.Parse(b2[0]));
                            if (right2 != 0) { noon = noon + "." + Convert.ToString(int.Parse(b2[1])); }
                            string a3 = dt_prescription.Rows[k]["night"].ToString();
                            string[] b3 = a3.Split('.');
                            int right3 = int.Parse(b3[1]);
                            night = Convert.ToString(int.Parse(b3[0]));
                            if (right3 != 0) { night = night + "." + Convert.ToString(int.Parse(b3[1])); }
                            dataGridView1.Rows.Add("0", dt_prescription.Rows[k]["drug_type"].ToString() + " " + dt_prescription.Rows[k]["drug_name"].ToString() + " " + dt_prescription.Rows[k]["strength"].ToString() + " " + dt_prescription.Rows[k]["strength_gr"].ToString(), morning + " - " + noon + " - " + night, dt_prescription.Rows[k]["duration_unit"].ToString() + " " + dt_prescription.Rows[k]["duration_period"].ToString(), dt_prescription.Rows[k]["add_instruction"].ToString(), "");
                            dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                            dataGridView1.Rows[i].Height = 30;
                        }
                    }
                    i = i + 1;
                    dataGridView1.Rows.Add("0", "Prescribed by Dr." + dt_pre_main.Rows[j]["doctor_name"].ToString(), "", "", "");
                    dataGridView1.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[i].Cells[1].Style.Font = new System.Drawing.Font("Segoe UI", 7, FontStyle.Bold);
                    dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                    i = i + 1;
                    dataGridView1.Rows.Add("0", "", "", "", "");
                    dataGridView1.Rows[i].Cells[5].Value = PappyjoeMVC.Properties.Resources.blank;
                    i = i + 1;
                }
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            if (dataGridView1.Rows.Count <= 0)
            {
                Label_NORecordFound.Show();
                dataGridView1.Hide();
            }
            else
            {
                Label_NORecordFound.Hide();
                dataGridView1.Show();
            }
        }

    }
}
