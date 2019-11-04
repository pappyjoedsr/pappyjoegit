using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using XtremeCalendarControl;
using System.Diagnostics;
using PappyjoeMVC.Controller;
using PappyjoeMVC.Model;
namespace PappyjoeMVC.View
{
    public enum CalendarView
    {
        DayView = 1,
        WorkWeekView = 2,
        WeekView = 4,
        MonthView = 8
    };
    /// <summary>frmMain
    /// Summary description for Form1.
    /// </summary>
    public class Main_Calendar : System.Windows.Forms.Form
    {
        string value1 = "something";
        string contact_no = "";
        MainCalendar_Controller cntrl = new MainCalendar_Controller();
        //PappyjoeMVC.Model.Connection db = new PappyjoeMVC.Model.Connection();
        public CalendarEvent EditingEvent;
        private System.Windows.Forms.StatusBar sbStatusBar;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.ImageList imlToolbarIcons;
        private System.Windows.Forms.Panel OptionsPane;
        private System.Windows.Forms.GroupBox gbxCalendarWorkWeek;
        private System.Windows.Forms.GroupBox gbxDayView;
        private System.Windows.Forms.GroupBox gbxWeekView;
        private System.Windows.Forms.GroupBox gbxMonthView;
        private System.Windows.Forms.ComboBox cmbTimeScale;
        private System.Windows.Forms.Button cmdTimeZone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDayShowTimeAsClocks;
        private System.Windows.Forms.CheckBox chkDayShowEndTime;
        private System.Windows.Forms.CheckBox chkMonthShowTimeAsClocks;
        private System.Windows.Forms.CheckBox chkMonthShowEndTime;
        private System.Windows.Forms.CheckBox chkCompressWeekendDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWeeksCount;
        private System.Windows.Forms.CheckBox chkMonday;
        private System.Windows.Forms.CheckBox chkTuesday;
        private System.Windows.Forms.CheckBox chkWednesday;
        private System.Windows.Forms.CheckBox chkThursday;
        private System.Windows.Forms.CheckBox chkFriday;
        private System.Windows.Forms.CheckBox chkSaturday;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cmbFirstDayOfWeek;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStartTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbEndTime;
        private System.Windows.Forms.Panel labelPane;
        private System.Windows.Forms.Label lblCalendar;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.ToolBarButton tbrFileNew;
        private System.Windows.Forms.ToolBarButton tbrFileOpen;
        private System.Windows.Forms.ToolBarButton tbrFileSave;
        private System.Windows.Forms.ToolBarButton tbrEditUndo;
        private System.Windows.Forms.ToolBarButton tbrEditCut;
        private System.Windows.Forms.ToolBarButton tbrEditCopy;
        private System.Windows.Forms.ToolBarButton tbrEditPaste;
        private System.Windows.Forms.ToolBarButton tbrDayView;
        private System.Windows.Forms.ToolBarButton tbrWorkWeekView;
        private System.Windows.Forms.ToolBarButton tbrWeekView;
        private System.Windows.Forms.ToolBarButton tbrMonthView;
        private System.Windows.Forms.ToolBarButton tbrDatePicker;
        private System.Windows.Forms.ToolBarButton tbrOptionsPane;
        private System.Windows.Forms.ToolBarButton tbrHelpAbout;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem mnuFileNew;
        private System.Windows.Forms.MenuItem mnuFileOpen;
        private System.Windows.Forms.MenuItem mnuFileSave;
        private System.Windows.Forms.MenuItem mnuFileExit;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem mnuEditUndo;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem mnuEditCut;
        private System.Windows.Forms.MenuItem mnuEditCopy;
        private System.Windows.Forms.MenuItem mnuEditPaste;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem mnuEditAddNewEvent;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuViewToolBar;
        private System.Windows.Forms.MenuItem mnuViewStatusBar;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem mnuViewOptionsBar;
        public System.Windows.Forms.MenuItem mnuDatePicker;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem mnuCalendarDayView;
        private System.Windows.Forms.MenuItem mnuCalendarWorkWeekView;
        private System.Windows.Forms.MenuItem mnuCalendarWeekView;
        private System.Windows.Forms.MenuItem mnuCalendarMonthView;
        public System.Windows.Forms.MenuItem mnuChangeTimeScalePopup;
        private System.Windows.Forms.MenuItem mnuCalendar60Min;
        private System.Windows.Forms.MenuItem mnuCalendar30Min;
        private System.Windows.Forms.MenuItem mnuCalendar15Min;
        private System.Windows.Forms.MenuItem mnuCalendar10Min;
        private System.Windows.Forms.MenuItem mnuCalendar6Min;
        private System.Windows.Forms.MenuItem mnuCalendar5Min;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem mnuCalendarChangeTimeZone;
        private System.Windows.Forms.MenuItem menuItem11;
        private System.Windows.Forms.MenuItem mnuHelpAbout;
        private System.Windows.Forms.MenuItem mnuContextEditEvent;
        private System.Windows.Forms.MenuItem mnuContextDeleteEvent;
        private System.Windows.Forms.CheckBox chkSunday;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuItem mnuContextNewEvent;
        static public PappyjoeMVC.View.Main_Calendar Instance;
        PappyjoeMVC.View.AppointmentBooking AppointmentBooking = null;
        OpenRecurringItem frmOpenRecurringItem = null;
        //frmTimeZone frmTimeZone = null;
        public CalendarEvent ContextEvent;
        public View.DatePicker frmDatePicker = null;
        DateTime BeginSelection, EndSelection;
        Boolean AllDay;
        int nCustomIconCounter;
        private XtremeCalendarControl. CalendarDialogsClass objCalendraDialogsReminders;
        //Sting used to hold path to save xml data files.  This file will contain all of the event information displayed in
        //the calendar view.
        public String ConnectionString = @"Provider=XML;Data Source=" + System.Environment.CurrentDirectory + @"..\..\..\";//ASWINI
        private System.Windows.Forms.ToolBarButton tbrPrintPageSetup;
        private System.Windows.Forms.ToolBarButton tbrPrintPreview;
        private System.Windows.Forms.ToolBarButton tbrPrint;
        private System.Windows.Forms.ToolBarButton toolBarButton7;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem mnuFilePrint;
        private System.Windows.Forms.MenuItem mnuFilePrintPreview;
        private System.Windows.Forms.MenuItem mnuFilePrintPageSetup;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem10;
        private System.Windows.Forms.MenuItem mnuViewRemindersWindow;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem mnuEnableReminders;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem mnuThemeOffice2007;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem menuShowCustomIcons;
        public AxXtremeCalendarControl.AxCalendarControl wndCalendarControl;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private System.Windows.Forms.Label labmonth;
        private System.Windows.Forms.Label labweek;
        private System.Windows.Forms.Label labday;
        private ComboBox combodoctors;
        private DataGridView dataGridViewdoctor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Panel panel4;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Label lab_p_add;
        private GroupBox groupBox1;
        private System.Windows.Forms.Label lab_p_app_time;
        private System.Windows.Forms.Label lab_dr_name;
        private System.Windows.Forms.Label lab_p_name;
        private Button button1;
        private Button button2;
        private Button button3;
        private DataGridView dataGridViewAppointment;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripButton toolStripButton6;
        private ToolStripButton toolStripButton7;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton9;
        private ToolStripTextBox toolStripTextBox1;
        // SQL Server data handler
        //private providerSQLServer m_objSQLProvider;
        private ListBox listpatientsearch;
        private Panel panel5;
        string pat_idForEdit = "0";
        public int status = 0;
        private Button button4;
        private ToolStripButton toolStripDropDownButton1;
        private ToolStripDropDownButton toolStripButton8;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label label11;
        private ToolStripButton toolStripconsnt;
        private ToolStripButton toolstripincomeandexpence;
        private ToolStripTextBox toolStripldoc;
        private System.Windows.Forms.Label lblprocedure;
        private System.Windows.Forms.Label lblnote;
        private Button BTn_Cancel;
        private ToolStripButton toolStripBfatstrack;
        public string doctor_id = "0";
        public string clinic { get; set; }
        public string pat_id { get; set; }
        public bool APTAdd = false, APTEdit = false, dr_wise_apt = false;
        private ToolStripButton toolStripButton12;
        private ToolStripButton toolStripButton10;
        int row_Val = 0; // Appointment List
        //  Privilege check.
        public Main_Calendar()
        {
            Instance = this;
            InitializeComponent();
            InitializeControls();
        }
        public void gridbinddoctors()
        {
            dataGridViewdoctor.ColumnCount = 3;
            dataGridViewdoctor.ColumnHeadersVisible = false;
            dataGridViewdoctor.RowHeadersVisible = false;
            dataGridViewdoctor.Columns[0].Name = "";
            dataGridViewdoctor.Columns[0].Width = 5;
            dataGridViewdoctor.Columns[1].Name = "Doctor Name";
            dataGridViewdoctor.Columns[1].Width = 175;
            dataGridViewdoctor.Columns[2].Name = "";
            dataGridViewdoctor.Columns[2].Visible = false;
            dataGridViewdoctor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            if (doctor_id == "1")
            {
                //DataTable dt_dr = db.table("SELECT id,doctor_name,calendar_color FROM tbl_doctor  where login_type='doctor' and activate_login='yes' ORDER BY id");
                DataTable dt_dr = new DataTable();// string str_sql = "";
                if (dr_wise_apt == false)
                {
                    dt_dr = this.cntrl.get_doctr(doctor_id);//  str_sql = "SELECT id,doctor_name,calendar_color FROM tbl_doctor Where id = " + doctor_id + " and activate_login='yes'"; 
                }
                else
                {
                    dt_dr = this.cntrl.load_all_doctor();/// str_sql = "SELECT id,doctor_name,calendar_color FROM tbl_doctor Where (login_type='doctor' or login_type='admin') and activate_login='yes'";
                }
                //DataTable dt_dr = db.table(str_sql + " ORDER BY id");
                for (int j = 0; j < dt_dr.Rows.Count; j++)
                {
                    dataGridViewdoctor.Rows.Add("", dt_dr.Rows[j]["doctor_name"].ToString(), dt_dr.Rows[j]["id"].ToString());
                    if (dt_dr.Rows[j]["calendar_color"].ToString() == "0")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(197, 214, 236);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "1")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(236, 141, 128);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "2")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(128, 149, 215);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "3")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(162, 211, 106);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "4")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(218, 218, 203);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "5")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(238, 167, 120);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "6")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(134, 225, 232);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "7")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(200, 193, 128);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "8")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(190, 162, 232);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "9")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(159, 195, 188);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "10")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(238, 218, 120);
                    }
                }
                dataGridViewdoctor.CurrentCell.Selected = false;
            }
            else
            {
                //DataTable dt_dr = db.table("SELECT id,doctor_name,calendar_color FROM tbl_doctor Where id = " + doctor_id + " and login_type='doctor' and activate_login='yes' ORDER BY id");
                DataTable dt_dr = new DataTable();// string str_sql = "";
                if (dr_wise_apt == false)
                {
                    dt_dr = this.cntrl.get_doctr(doctor_id); //str_sql = "SELECT id,doctor_name,calendar_color FROM tbl_doctor Where id = " + doctor_id + "  and activate_login='yes'";
                }
                else
                {
                    dt_dr = this.cntrl.load_all_doctor();// str_sql = "SELECT id,doctor_name,calendar_color FROM tbl_doctor Where (login_type='doctor' or login_type='admin') and  activate_login='yes'";
                }
                //DataTable dt_dr = db.table(str_sql + " ORDER BY id");
                for (int j = 0; j < dt_dr.Rows.Count; j++)
                {
                    dataGridViewdoctor.Rows.Add("", dt_dr.Rows[j]["doctor_name"].ToString(), dt_dr.Rows[j]["id"].ToString());
                    if (dt_dr.Rows[j]["calendar_color"].ToString() == "0")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(197, 214, 236);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "1")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(236, 141, 128);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "2")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(128, 149, 215);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "3")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(162, 211, 106);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "4")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(218, 218, 203);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "5")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(238, 167, 120);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "6")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(134, 225, 232);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "7")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(200, 193, 128);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "8")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(190, 162, 232);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "9")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(159, 195, 188);
                    }
                    else if (dt_dr.Rows[j]["calendar_color"].ToString() == "10")
                    {
                        dataGridViewdoctor.Rows[j].Cells[0].Style.BackColor = Color.FromArgb(238, 218, 120);
                    }
                }
                if (dataGridViewdoctor.Rows.Count == 1)
                {
                    button3.Enabled = false;
                }
            }
        }
        private void InitializeControls()
        {
            objCalendraDialogsReminders = new XtremeCalendarControl.CalendarDialogsClass();
            cmbTimeScale.Items.Insert(0, "60 Minutes");
            cmbTimeScale.Items.Insert(1, "30 Minutes");
            cmbTimeScale.Items.Insert(2, "15 Minutes");
            cmbTimeScale.Items.Insert(3, "10 Minutes");
            cmbTimeScale.Items.Insert(4, "6 Minutes");
            cmbTimeScale.Items.Insert(5, "5 Minutes");
            cmbTimeScale.SelectedIndex = 1;
            //Min # of Weeks is 2
            //Max # of Weeks is 6
            cmbWeeksCount.Items.Insert(0, 2);
            cmbWeeksCount.Items.Insert(1, 3);
            cmbWeeksCount.Items.Insert(2, 4);
            cmbWeeksCount.Items.Insert(3, 5);
            cmbWeeksCount.Items.Insert(4, 6);
            cmbWeeksCount.SelectedIndex = 4;
            cmbFirstDayOfWeek.Items.Insert(0, WorkWeekDay.Sunday);
            cmbFirstDayOfWeek.Items.Insert(1, WorkWeekDay.Monday);
            cmbFirstDayOfWeek.Items.Insert(2, WorkWeekDay.Tuesday);
            cmbFirstDayOfWeek.Items.Insert(3, WorkWeekDay.Wednesday);
            cmbFirstDayOfWeek.Items.Insert(4, WorkWeekDay.Thursday);
            cmbFirstDayOfWeek.Items.Insert(5, WorkWeekDay.Friday);
            cmbFirstDayOfWeek.Items.Insert(6, WorkWeekDay.Saturday);
            cmbFirstDayOfWeek.SelectedIndex = 1;
            wndCalendarControl.Options.WorkWeekMask = 0;
            DateTime dtHours = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            for (int cnt = 0; cnt < 48; cnt++)
            {
                cmbStartTime.Items.Insert(cnt, dtHours.ToShortTimeString());
                cmbEndTime.Items.Insert(cnt, dtHours.ToShortTimeString());
                dtHours = dtHours.AddMinutes(30);
            }
            cmbStartTime.SelectedIndex = 16;
            cmbEndTime.SelectedIndex = 34;
            WorkWeekDayCheck_Click(this, new System.EventArgs());
            mnuCalendarWeekView_Click(this, new System.EventArgs());// mnuCalendarWorkWeekView_Click(this, new System.EventArgs());
            UpdateDateLabel();
            wndCalendarControl.DayView.ScrollToWorkDayBegin();
        }

        public enum WorkWeekDay
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7
        };

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Calendar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sbStatusBar = new System.Windows.Forms.StatusBar();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.mnuContextNewEvent = new System.Windows.Forms.MenuItem();
            this.mnuContextEditEvent = new System.Windows.Forms.MenuItem();
            this.mnuContextDeleteEvent = new System.Windows.Forms.MenuItem();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tbrFileNew = new System.Windows.Forms.ToolBarButton();
            this.tbrFileOpen = new System.Windows.Forms.ToolBarButton();
            this.tbrFileSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton7 = new System.Windows.Forms.ToolBarButton();
            this.tbrPrintPageSetup = new System.Windows.Forms.ToolBarButton();
            this.tbrPrintPreview = new System.Windows.Forms.ToolBarButton();
            this.tbrPrint = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tbrEditUndo = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tbrEditCut = new System.Windows.Forms.ToolBarButton();
            this.tbrEditCopy = new System.Windows.Forms.ToolBarButton();
            this.tbrEditPaste = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.tbrDayView = new System.Windows.Forms.ToolBarButton();
            this.tbrWorkWeekView = new System.Windows.Forms.ToolBarButton();
            this.tbrWeekView = new System.Windows.Forms.ToolBarButton();
            this.tbrMonthView = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.tbrDatePicker = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.tbrOptionsPane = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.tbrHelpAbout = new System.Windows.Forms.ToolBarButton();
            this.imlToolbarIcons = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuFileNew = new System.Windows.Forms.MenuItem();
            this.mnuFileOpen = new System.Windows.Forms.MenuItem();
            this.mnuFileSave = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.mnuFilePrint = new System.Windows.Forms.MenuItem();
            this.mnuFilePrintPreview = new System.Windows.Forms.MenuItem();
            this.mnuFilePrintPageSetup = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.mnuFileExit = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.mnuEditUndo = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.mnuEditCut = new System.Windows.Forms.MenuItem();
            this.mnuEditCopy = new System.Windows.Forms.MenuItem();
            this.mnuEditPaste = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.mnuEditAddNewEvent = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuViewToolBar = new System.Windows.Forms.MenuItem();
            this.mnuViewStatusBar = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.mnuViewOptionsBar = new System.Windows.Forms.MenuItem();
            this.mnuDatePicker = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.mnuViewRemindersWindow = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.mnuCalendarDayView = new System.Windows.Forms.MenuItem();
            this.mnuCalendarWorkWeekView = new System.Windows.Forms.MenuItem();
            this.mnuCalendarWeekView = new System.Windows.Forms.MenuItem();
            this.mnuCalendarMonthView = new System.Windows.Forms.MenuItem();
            this.mnuChangeTimeScalePopup = new System.Windows.Forms.MenuItem();
            this.mnuCalendar60Min = new System.Windows.Forms.MenuItem();
            this.mnuCalendar30Min = new System.Windows.Forms.MenuItem();
            this.mnuCalendar15Min = new System.Windows.Forms.MenuItem();
            this.mnuCalendar10Min = new System.Windows.Forms.MenuItem();
            this.mnuCalendar6Min = new System.Windows.Forms.MenuItem();
            this.mnuCalendar5Min = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.mnuCalendarChangeTimeZone = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.mnuEnableReminders = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.mnuThemeOffice2007 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuShowCustomIcons = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
            this.OptionsPane = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBfatstrack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripconsnt = new System.Windows.Forms.ToolStripButton();
            this.toolstripincomeandexpence = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripDropDownButton();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripldoc = new System.Windows.Forms.ToolStripTextBox();
            this.gbxMonthView = new System.Windows.Forms.GroupBox();
            this.cmbWeeksCount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkCompressWeekendDays = new System.Windows.Forms.CheckBox();
            this.chkMonthShowEndTime = new System.Windows.Forms.CheckBox();
            this.chkMonthShowTimeAsClocks = new System.Windows.Forms.CheckBox();
            this.gbxWeekView = new System.Windows.Forms.GroupBox();
            this.chkDayShowEndTime = new System.Windows.Forms.CheckBox();
            this.chkDayShowTimeAsClocks = new System.Windows.Forms.CheckBox();
            this.gbxDayView = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTimeZone = new System.Windows.Forms.Button();
            this.cmbTimeScale = new System.Windows.Forms.ComboBox();
            this.gbxCalendarWorkWeek = new System.Windows.Forms.GroupBox();
            this.cmbEndTime = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStartTime = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFirstDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkSaturday = new System.Windows.Forms.CheckBox();
            this.chkFriday = new System.Windows.Forms.CheckBox();
            this.chkThursday = new System.Windows.Forms.CheckBox();
            this.chkWednesday = new System.Windows.Forms.CheckBox();
            this.chkTuesday = new System.Windows.Forms.CheckBox();
            this.chkMonday = new System.Windows.Forms.CheckBox();
            this.chkSunday = new System.Windows.Forms.CheckBox();
            this.labelPane = new System.Windows.Forms.Panel();
            this.labday = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.labweek = new System.Windows.Forms.Label();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.labmonth = new System.Windows.Forms.Label();
            this.wndCalendarControl = new AxXtremeCalendarControl.AxCalendarControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewdoctor = new System.Windows.Forms.DataGridView();
            this.combodoctors = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewAppointment = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTn_Cancel = new System.Windows.Forms.Button();
            this.lblnote = new System.Windows.Forms.Label();
            this.lblprocedure = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_p_add = new System.Windows.Forms.Label();
            this.lab_p_name = new System.Windows.Forms.Label();
            this.lab_dr_name = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lab_p_app_time = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listpatientsearch = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.OptionsPane.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbxMonthView.SuspendLayout();
            this.gbxWeekView.SuspendLayout();
            this.gbxDayView.SuspendLayout();
            this.gbxCalendarWorkWeek.SuspendLayout();
            this.labelPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wndCalendarControl)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdoctor)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointment)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbStatusBar
            // 
            this.sbStatusBar.Location = new System.Drawing.Point(0, 500);
            this.sbStatusBar.Name = "sbStatusBar";
            this.sbStatusBar.Size = new System.Drawing.Size(1362, 16);
            this.sbStatusBar.TabIndex = 1;
            // 
            // contextMenu
            // 
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuContextNewEvent,
            this.mnuContextEditEvent,
            this.mnuContextDeleteEvent});
            // 
            // mnuContextNewEvent
            // 
            this.mnuContextNewEvent.Index = 0;
            this.mnuContextNewEvent.Text = "New Event";
            this.mnuContextNewEvent.Click += new System.EventHandler(this.mnuContextNewEvent_Click);
            // 
            // mnuContextEditEvent
            // 
            this.mnuContextEditEvent.Index = 1;
            this.mnuContextEditEvent.Text = "Edit Event";
            this.mnuContextEditEvent.Click += new System.EventHandler(this.mnuContextEditEvent_Click);
            // 
            // mnuContextDeleteEvent
            // 
            this.mnuContextDeleteEvent.Index = 2;
            this.mnuContextDeleteEvent.Text = "Delete Event";
            this.mnuContextDeleteEvent.Click += new System.EventHandler(this.mnuContextDeleteEvent_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tbrFileNew,
            this.tbrFileOpen,
            this.tbrFileSave,
            this.toolBarButton7,
            this.tbrPrintPageSetup,
            this.tbrPrintPreview,
            this.tbrPrint,
            this.toolBarButton1,
            this.tbrEditUndo,
            this.toolBarButton2,
            this.tbrEditCut,
            this.tbrEditCopy,
            this.tbrEditPaste,
            this.toolBarButton3,
            this.tbrDayView,
            this.tbrWorkWeekView,
            this.tbrWeekView,
            this.tbrMonthView,
            this.toolBarButton4,
            this.tbrDatePicker,
            this.toolBarButton5,
            this.tbrOptionsPane,
            this.toolBarButton6,
            this.tbrHelpAbout});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imlToolbarIcons;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(1362, 27);
            this.toolBar1.TabIndex = 2;
            this.toolBar1.Visible = false;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbrFileNew
            // 
            this.tbrFileNew.Enabled = false;
            this.tbrFileNew.ImageIndex = 0;
            this.tbrFileNew.Name = "tbrFileNew";
            this.tbrFileNew.Tag = "FileNew";
            // 
            // tbrFileOpen
            // 
            this.tbrFileOpen.ImageIndex = 1;
            this.tbrFileOpen.Name = "tbrFileOpen";
            this.tbrFileOpen.Tag = "FileOpen";
            // 
            // tbrFileSave
            // 
            this.tbrFileSave.ImageIndex = 2;
            this.tbrFileSave.Name = "tbrFileSave";
            this.tbrFileSave.Tag = "FileSave";
            // 
            // toolBarButton7
            // 
            this.toolBarButton7.Name = "toolBarButton7";
            this.toolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrPrintPageSetup
            // 
            this.tbrPrintPageSetup.ImageIndex = 14;
            this.tbrPrintPageSetup.Name = "tbrPrintPageSetup";
            this.tbrPrintPageSetup.Tag = "PrintPageSetup";
            // 
            // tbrPrintPreview
            // 
            this.tbrPrintPreview.ImageIndex = 15;
            this.tbrPrintPreview.Name = "tbrPrintPreview";
            this.tbrPrintPreview.Tag = "PrintPreview";
            // 
            // tbrPrint
            // 
            this.tbrPrint.ImageIndex = 16;
            this.tbrPrint.Name = "tbrPrint";
            this.tbrPrint.Tag = "Print";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrEditUndo
            // 
            this.tbrEditUndo.Enabled = false;
            this.tbrEditUndo.ImageIndex = 3;
            this.tbrEditUndo.Name = "tbrEditUndo";
            this.tbrEditUndo.Tag = "EditUndo";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrEditCut
            // 
            this.tbrEditCut.Enabled = false;
            this.tbrEditCut.ImageIndex = 4;
            this.tbrEditCut.Name = "tbrEditCut";
            this.tbrEditCut.Tag = "EditCut";
            // 
            // tbrEditCopy
            // 
            this.tbrEditCopy.Enabled = false;
            this.tbrEditCopy.ImageIndex = 5;
            this.tbrEditCopy.Name = "tbrEditCopy";
            this.tbrEditCopy.Tag = "EditCopy";
            // 
            // tbrEditPaste
            // 
            this.tbrEditPaste.Enabled = false;
            this.tbrEditPaste.ImageIndex = 6;
            this.tbrEditPaste.Name = "tbrEditPaste";
            this.tbrEditPaste.Tag = "EditPaste";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrDayView
            // 
            this.tbrDayView.ImageIndex = 7;
            this.tbrDayView.Name = "tbrDayView";
            this.tbrDayView.Tag = "DayView";
            // 
            // tbrWorkWeekView
            // 
            this.tbrWorkWeekView.ImageIndex = 8;
            this.tbrWorkWeekView.Name = "tbrWorkWeekView";
            this.tbrWorkWeekView.Tag = "WorkWeekView";
            // 
            // tbrWeekView
            // 
            this.tbrWeekView.ImageIndex = 9;
            this.tbrWeekView.Name = "tbrWeekView";
            this.tbrWeekView.Tag = "WeekView";
            // 
            // tbrMonthView
            // 
            this.tbrMonthView.ImageIndex = 10;
            this.tbrMonthView.Name = "tbrMonthView";
            this.tbrMonthView.Tag = "MonthView";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrDatePicker
            // 
            this.tbrDatePicker.ImageIndex = 11;
            this.tbrDatePicker.Name = "tbrDatePicker";
            this.tbrDatePicker.Tag = "DatePicker";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrOptionsPane
            // 
            this.tbrOptionsPane.ImageIndex = 12;
            this.tbrOptionsPane.Name = "tbrOptionsPane";
            this.tbrOptionsPane.Tag = "OptionsPane";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tbrHelpAbout
            // 
            this.tbrHelpAbout.ImageIndex = 13;
            this.tbrHelpAbout.Name = "tbrHelpAbout";
            this.tbrHelpAbout.Tag = "HelpAbout";
            // 
            // imlToolbarIcons
            // 
            this.imlToolbarIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlToolbarIcons.ImageStream")));
            this.imlToolbarIcons.TransparentColor = System.Drawing.Color.Silver;
            this.imlToolbarIcons.Images.SetKeyName(0, "");
            this.imlToolbarIcons.Images.SetKeyName(1, "");
            this.imlToolbarIcons.Images.SetKeyName(2, "");
            this.imlToolbarIcons.Images.SetKeyName(3, "");
            this.imlToolbarIcons.Images.SetKeyName(4, "");
            this.imlToolbarIcons.Images.SetKeyName(5, "");
            this.imlToolbarIcons.Images.SetKeyName(6, "");
            this.imlToolbarIcons.Images.SetKeyName(7, "");
            this.imlToolbarIcons.Images.SetKeyName(8, "");
            this.imlToolbarIcons.Images.SetKeyName(9, "");
            this.imlToolbarIcons.Images.SetKeyName(10, "");
            this.imlToolbarIcons.Images.SetKeyName(11, "");
            this.imlToolbarIcons.Images.SetKeyName(12, "");
            this.imlToolbarIcons.Images.SetKeyName(13, "");
            this.imlToolbarIcons.Images.SetKeyName(14, "");
            this.imlToolbarIcons.Images.SetKeyName(15, "");
            this.imlToolbarIcons.Images.SetKeyName(16, "");
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3,
            this.menuItem7,
            this.menuItem11});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.mnuFileSave,
            this.menuItem6,
            this.mnuFilePrint,
            this.mnuFilePrintPreview,
            this.mnuFilePrintPageSetup,
            this.menuItem14,
            this.mnuFileExit});
            this.menuItem1.Text = "File";
            this.menuItem1.Visible = false;
            // 
            // mnuFileNew
            // 
            this.mnuFileNew.Enabled = false;
            this.mnuFileNew.Index = 0;
            this.mnuFileNew.Text = "New";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Index = 1;
            this.mnuFileOpen.Text = "Open...";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Index = 2;
            this.mnuFileSave.Text = "Save";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 3;
            this.menuItem6.Text = "-";
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Index = 4;
            this.mnuFilePrint.Text = "Print...";
            this.mnuFilePrint.Click += new System.EventHandler(this.mnuFilePrint_Click);
            // 
            // mnuFilePrintPreview
            // 
            this.mnuFilePrintPreview.Index = 5;
            this.mnuFilePrintPreview.Text = "Print Preview";
            this.mnuFilePrintPreview.Click += new System.EventHandler(this.mnuFilePrintPreview_Click);
            // 
            // mnuFilePrintPageSetup
            // 
            this.mnuFilePrintPageSetup.Index = 6;
            this.mnuFilePrintPageSetup.Text = "Page Setup";
            this.mnuFilePrintPageSetup.Click += new System.EventHandler(this.mnuFilePrintPageSetup_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 7;
            this.menuItem14.Text = "-";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Index = 8;
            this.mnuFileExit.Text = "Exit";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuEditUndo,
            this.menuItem4,
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.menuItem9,
            this.mnuEditAddNewEvent});
            this.menuItem2.Text = "Edit";
            this.menuItem2.Visible = false;
            // 
            // mnuEditUndo
            // 
            this.mnuEditUndo.Index = 0;
            this.mnuEditUndo.Text = "Undo";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "-";
            // 
            // mnuEditCut
            // 
            this.mnuEditCut.Index = 2;
            this.mnuEditCut.Text = "Cut";
            // 
            // mnuEditCopy
            // 
            this.mnuEditCopy.Index = 3;
            this.mnuEditCopy.Text = "Copy";
            // 
            // mnuEditPaste
            // 
            this.mnuEditPaste.Index = 4;
            this.mnuEditPaste.Text = "Paste";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 5;
            this.menuItem9.Text = "-";
            // 
            // mnuEditAddNewEvent
            // 
            this.mnuEditAddNewEvent.Index = 6;
            this.mnuEditAddNewEvent.Text = "Add New Event";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuViewToolBar,
            this.mnuViewStatusBar,
            this.menuItem5,
            this.mnuViewOptionsBar,
            this.mnuDatePicker,
            this.menuItem10,
            this.mnuViewRemindersWindow});
            this.menuItem3.Text = "View";
            this.menuItem3.Visible = false;
            // 
            // mnuViewToolBar
            // 
            this.mnuViewToolBar.Checked = true;
            this.mnuViewToolBar.Index = 0;
            this.mnuViewToolBar.Text = "ToolBar";
            this.mnuViewToolBar.Click += new System.EventHandler(this.mnuViewToolBar_Click);
            // 
            // mnuViewStatusBar
            // 
            this.mnuViewStatusBar.Checked = true;
            this.mnuViewStatusBar.Index = 1;
            this.mnuViewStatusBar.Text = "StatusBar";
            this.mnuViewStatusBar.Click += new System.EventHandler(this.mnuViewStatusBar_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // mnuViewOptionsBar
            // 
            this.mnuViewOptionsBar.Checked = true;
            this.mnuViewOptionsBar.Index = 3;
            this.mnuViewOptionsBar.Text = "Options Bar";
            this.mnuViewOptionsBar.Click += new System.EventHandler(this.mnuViewOptionsBar_Click);
            // 
            // mnuDatePicker
            // 
            this.mnuDatePicker.Index = 4;
            this.mnuDatePicker.Text = "Date Picker";
            this.mnuDatePicker.Click += new System.EventHandler(this.mnuDatePicker_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 5;
            this.menuItem10.Text = "-";
            // 
            // mnuViewRemindersWindow
            // 
            this.mnuViewRemindersWindow.Index = 6;
            this.mnuViewRemindersWindow.Text = "Reminders Window";
            this.mnuViewRemindersWindow.Click += new System.EventHandler(this.mnuViewRemindersWindow_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.mnuChangeTimeScalePopup,
            this.menuItem12,
            this.mnuEnableReminders,
            this.menuItem15,
            this.mnuThemeOffice2007,
            this.menuItem13,
            this.menuShowCustomIcons});
            this.menuItem7.Text = "Calendar";
            this.menuItem7.Visible = false;
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCalendarDayView,
            this.mnuCalendarWorkWeekView,
            this.mnuCalendarWeekView,
            this.mnuCalendarMonthView});
            this.menuItem8.Text = "Change View";
            // 
            // mnuCalendarDayView
            // 
            this.mnuCalendarDayView.Index = 0;
            this.mnuCalendarDayView.Text = "Day";
            this.mnuCalendarDayView.Click += new System.EventHandler(this.mnuCalendarDayView_Click);
            // 
            // mnuCalendarWorkWeekView
            // 
            this.mnuCalendarWorkWeekView.Index = 1;
            this.mnuCalendarWorkWeekView.Text = "Work Week";
            this.mnuCalendarWorkWeekView.Click += new System.EventHandler(this.mnuCalendarWorkWeekView_Click);
            // 
            // mnuCalendarWeekView
            // 
            this.mnuCalendarWeekView.Index = 2;
            this.mnuCalendarWeekView.Text = "Week";
            this.mnuCalendarWeekView.Click += new System.EventHandler(this.mnuCalendarWeekView_Click);
            // 
            // mnuCalendarMonthView
            // 
            this.mnuCalendarMonthView.Index = 3;
            this.mnuCalendarMonthView.Text = "Month";
            this.mnuCalendarMonthView.Click += new System.EventHandler(this.mnuCalendarMonthView_Click);
            // 
            // mnuChangeTimeScalePopup
            // 
            this.mnuChangeTimeScalePopup.Index = 1;
            this.mnuChangeTimeScalePopup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuCalendar60Min,
            this.mnuCalendar30Min,
            this.mnuCalendar15Min,
            this.mnuCalendar10Min,
            this.mnuCalendar6Min,
            this.mnuCalendar5Min,
            this.menuItem17,
            this.mnuCalendarChangeTimeZone});
            this.mnuChangeTimeScalePopup.Text = "Change Time Scale";
            // 
            // mnuCalendar60Min
            // 
            this.mnuCalendar60Min.Index = 0;
            this.mnuCalendar60Min.Text = "60 Minutes";
            this.mnuCalendar60Min.Click += new System.EventHandler(this.mnuCalendar60Min_Click);
            // 
            // mnuCalendar30Min
            // 
            this.mnuCalendar30Min.Index = 1;
            this.mnuCalendar30Min.Text = "30 Minutes";
            this.mnuCalendar30Min.Click += new System.EventHandler(this.mnuCalendar30Min_Click);
            // 
            // mnuCalendar15Min
            // 
            this.mnuCalendar15Min.Index = 2;
            this.mnuCalendar15Min.Text = "15 Minutes";
            this.mnuCalendar15Min.Click += new System.EventHandler(this.mnuCalendar15Min_Click);
            // 
            // mnuCalendar10Min
            // 
            this.mnuCalendar10Min.Index = 3;
            this.mnuCalendar10Min.Text = "10 Minutes";
            this.mnuCalendar10Min.Click += new System.EventHandler(this.mnuCalendar10Min_Click);
            // 
            // mnuCalendar6Min
            // 
            this.mnuCalendar6Min.Index = 4;
            this.mnuCalendar6Min.Text = "6 Minutes";
            this.mnuCalendar6Min.Click += new System.EventHandler(this.mnuCalendar6Min_Click);
            // 
            // mnuCalendar5Min
            // 
            this.mnuCalendar5Min.Index = 5;
            this.mnuCalendar5Min.Text = "5 Minutes";
            this.mnuCalendar5Min.Click += new System.EventHandler(this.mnuCalendar5Min_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 6;
            this.menuItem17.Text = "-";
            // 
            // mnuCalendarChangeTimeZone
            // 
            this.mnuCalendarChangeTimeZone.Index = 7;
            this.mnuCalendarChangeTimeZone.Text = "Change Time Zone";
            this.mnuCalendarChangeTimeZone.Click += new System.EventHandler(this.mnuCalendarChangeTimeZone_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 2;
            this.menuItem12.Text = "-";
            // 
            // mnuEnableReminders
            // 
            this.mnuEnableReminders.Index = 3;
            this.mnuEnableReminders.Text = "Enable Reminders";
            this.mnuEnableReminders.Click += new System.EventHandler(this.mnuEnableReminders_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 4;
            this.menuItem15.Text = "-";
            // 
            // mnuThemeOffice2007
            // 
            this.mnuThemeOffice2007.Checked = true;
            this.mnuThemeOffice2007.Index = 5;
            this.mnuThemeOffice2007.Text = "Enable Office 2007 theme";
            this.mnuThemeOffice2007.Click += new System.EventHandler(this.mnuThemeOffice2007_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 6;
            this.menuItem13.Text = "-";
            // 
            // menuShowCustomIcons
            // 
            this.menuShowCustomIcons.Index = 7;
            this.menuShowCustomIcons.Text = "Office 2007 theme: Show Custom Icons Example ";
            this.menuShowCustomIcons.Click += new System.EventHandler(this.menuShowCustomIcons_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 4;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuHelpAbout});
            this.menuItem11.Text = "Help";
            this.menuItem11.Visible = false;
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Index = 0;
            this.mnuHelpAbout.Text = "About CalendarSample...";
            // 
            // OptionsPane
            // 
            this.OptionsPane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OptionsPane.Controls.Add(this.panel3);
            this.OptionsPane.Controls.Add(this.gbxMonthView);
            this.OptionsPane.Controls.Add(this.gbxWeekView);
            this.OptionsPane.Controls.Add(this.gbxDayView);
            this.OptionsPane.Controls.Add(this.gbxCalendarWorkWeek);
            this.OptionsPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.OptionsPane.Location = new System.Drawing.Point(0, 27);
            this.OptionsPane.Name = "OptionsPane";
            this.OptionsPane.Size = new System.Drawing.Size(1362, 42);
            this.OptionsPane.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1360, 40);
            this.panel3.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripBfatstrack,
            this.toolStripButton2,
            this.toolStripButton10,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton6,
            this.toolStripconsnt,
            this.toolstripincomeandexpence,
            this.toolStripButton7,
            this.toolStripButton12,
            this.toolStripButton8,
            this.toolStripSeparator2,
            this.toolStripButton9,
            this.toolStripDropDownButton1,
            this.toolStripTextBox1,
            this.toolStripldoc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1360, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.White;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(103, 37);
            this.toolStripButton1.Text = "Pappyjoe Clinic";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripBfatstrack
            // 
            this.toolStripBfatstrack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripBfatstrack.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripBfatstrack.ForeColor = System.Drawing.Color.White;
            this.toolStripBfatstrack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBfatstrack.Image")));
            this.toolStripBfatstrack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBfatstrack.Name = "toolStripBfatstrack";
            this.toolStripBfatstrack.Size = new System.Drawing.Size(72, 37);
            this.toolStripBfatstrack.Text = "Fast Track";
            this.toolStripBfatstrack.Visible = false;
            this.toolStripBfatstrack.Click += new System.EventHandler(this.toolStripBfatstrack_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.ForeColor = System.Drawing.Color.White;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 37);
            this.toolStripButton2.Text = "Calendar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton10.ForeColor = System.Drawing.Color.White;
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(89, 37);
            this.toolStripButton10.Text = "Consultation";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton3.ForeColor = System.Drawing.Color.White;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 37);
            this.toolStripButton3.Text = "Records";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton5.ForeColor = System.Drawing.Color.White;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(114, 37);
            this.toolStripButton5.Text = "Communications";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton4.ForeColor = System.Drawing.Color.White;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(72, 37);
            this.toolStripButton4.Text = "Inventory";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton6.ForeColor = System.Drawing.Color.White;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(59, 37);
            this.toolStripButton6.Text = "Reports";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripconsnt
            // 
            this.toolStripconsnt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripconsnt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripconsnt.ForeColor = System.Drawing.Color.White;
            this.toolStripconsnt.Image = ((System.Drawing.Image)(resources.GetObject("toolStripconsnt.Image")));
            this.toolStripconsnt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripconsnt.Name = "toolStripconsnt";
            this.toolStripconsnt.Size = new System.Drawing.Size(62, 37);
            this.toolStripconsnt.Text = "Consent";
            this.toolStripconsnt.Visible = false;
            // 
            // toolstripincomeandexpence
            // 
            this.toolstripincomeandexpence.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolstripincomeandexpence.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripincomeandexpence.ForeColor = System.Drawing.Color.White;
            this.toolstripincomeandexpence.Image = ((System.Drawing.Image)(resources.GetObject("toolstripincomeandexpence.Image")));
            this.toolstripincomeandexpence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripincomeandexpence.Name = "toolstripincomeandexpence";
            this.toolstripincomeandexpence.Size = new System.Drawing.Size(62, 37);
            this.toolstripincomeandexpence.Text = "Expense";
            this.toolstripincomeandexpence.Click += new System.EventHandler(this.toolstripincomeandexpence_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton7.ForeColor = System.Drawing.Color.White;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(56, 37);
            this.toolStripButton7.Text = "Profiles";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton12.ForeColor = System.Drawing.Color.White;
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(87, 37);
            this.toolStripButton12.Text = "Lab Tracking";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.toolStripButton8.Image = global::PappyjoeMVC.Properties.Resources._1435669277_gear_basic_blue_small_;
            this.toolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(33, 37);
            this.toolStripButton8.Text = "toolStripButton8";
            this.toolStripButton8.ToolTipText = "Settings";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::PappyjoeMVC.Properties.Resources._1435669277_gear_basic_blue_small_;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::PappyjoeMVC.Properties.Resources._1429953040_Log_Out;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::PappyjoeMVC.Properties.Resources._1435669279_question_balloon_basic_blue;
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(29, 37);
            this.toolStripButton9.Text = "toolStripButton9";
            this.toolStripButton9.ToolTipText = "Pappyjoe Version 16.2";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.Image = global::PappyjoeMVC.Properties.Resources.appbar_user_add__2_1;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(32, 37);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.ToolTipText = "Add new Patient";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(250, 40);
            this.toolStripTextBox1.Text = "Search by Patient Name, id, Mobile No";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripldoc
            // 
            this.toolStripldoc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripldoc.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStripldoc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripldoc.Name = "toolStripldoc";
            this.toolStripldoc.ReadOnly = true;
            this.toolStripldoc.Size = new System.Drawing.Size(250, 23);
            this.toolStripldoc.Text = "Search";
            // 
            // gbxMonthView
            // 
            this.gbxMonthView.Controls.Add(this.cmbWeeksCount);
            this.gbxMonthView.Controls.Add(this.label2);
            this.gbxMonthView.Controls.Add(this.chkCompressWeekendDays);
            this.gbxMonthView.Controls.Add(this.chkMonthShowEndTime);
            this.gbxMonthView.Controls.Add(this.chkMonthShowTimeAsClocks);
            this.gbxMonthView.Location = new System.Drawing.Point(641, 6);
            this.gbxMonthView.Name = "gbxMonthView";
            this.gbxMonthView.Size = new System.Drawing.Size(330, 60);
            this.gbxMonthView.TabIndex = 3;
            this.gbxMonthView.TabStop = false;
            this.gbxMonthView.Text = "MonthView";
            // 
            // cmbWeeksCount
            // 
            this.cmbWeeksCount.Location = new System.Drawing.Point(80, 41);
            this.cmbWeeksCount.Name = "cmbWeeksCount";
            this.cmbWeeksCount.Size = new System.Drawing.Size(56, 21);
            this.cmbWeeksCount.TabIndex = 4;
            this.cmbWeeksCount.SelectedIndexChanged += new System.EventHandler(this.cmbWeeksCount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Weeks Count:";
            // 
            // chkCompressWeekendDays
            // 
            this.chkCompressWeekendDays.Checked = true;
            this.chkCompressWeekendDays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCompressWeekendDays.Location = new System.Drawing.Point(8, 28);
            this.chkCompressWeekendDays.Name = "chkCompressWeekendDays";
            this.chkCompressWeekendDays.Size = new System.Drawing.Size(160, 16);
            this.chkCompressWeekendDays.TabIndex = 2;
            this.chkCompressWeekendDays.Text = "Compress Weekend Days";
            this.chkCompressWeekendDays.CheckedChanged += new System.EventHandler(this.chkCompressWeekendDays_CheckedChanged);
            // 
            // chkMonthShowEndTime
            // 
            this.chkMonthShowEndTime.Location = new System.Drawing.Point(166, 19);
            this.chkMonthShowEndTime.Name = "chkMonthShowEndTime";
            this.chkMonthShowEndTime.Size = new System.Drawing.Size(144, 20);
            this.chkMonthShowEndTime.TabIndex = 1;
            this.chkMonthShowEndTime.Text = "Show End Time";
            this.chkMonthShowEndTime.CheckedChanged += new System.EventHandler(this.chkMonthShowEndTime_CheckedChanged);
            // 
            // chkMonthShowTimeAsClocks
            // 
            this.chkMonthShowTimeAsClocks.Location = new System.Drawing.Point(8, 16);
            this.chkMonthShowTimeAsClocks.Name = "chkMonthShowTimeAsClocks";
            this.chkMonthShowTimeAsClocks.Size = new System.Drawing.Size(152, 16);
            this.chkMonthShowTimeAsClocks.TabIndex = 0;
            this.chkMonthShowTimeAsClocks.Text = "Show Time as Clocks";
            this.chkMonthShowTimeAsClocks.CheckedChanged += new System.EventHandler(this.chkMonthShowTimeAsClocks_CheckedChanged);
            // 
            // gbxWeekView
            // 
            this.gbxWeekView.Controls.Add(this.chkDayShowEndTime);
            this.gbxWeekView.Controls.Add(this.chkDayShowTimeAsClocks);
            this.gbxWeekView.Location = new System.Drawing.Point(473, 5);
            this.gbxWeekView.Name = "gbxWeekView";
            this.gbxWeekView.Size = new System.Drawing.Size(154, 61);
            this.gbxWeekView.TabIndex = 2;
            this.gbxWeekView.TabStop = false;
            this.gbxWeekView.Text = "Week View";
            // 
            // chkDayShowEndTime
            // 
            this.chkDayShowEndTime.Location = new System.Drawing.Point(6, 29);
            this.chkDayShowEndTime.Name = "chkDayShowEndTime";
            this.chkDayShowEndTime.Size = new System.Drawing.Size(128, 16);
            this.chkDayShowEndTime.TabIndex = 1;
            this.chkDayShowEndTime.Text = "Show End Time";
            this.chkDayShowEndTime.CheckedChanged += new System.EventHandler(this.chkDayShowEndTime_CheckedChanged);
            // 
            // chkDayShowTimeAsClocks
            // 
            this.chkDayShowTimeAsClocks.Location = new System.Drawing.Point(8, 16);
            this.chkDayShowTimeAsClocks.Name = "chkDayShowTimeAsClocks";
            this.chkDayShowTimeAsClocks.Size = new System.Drawing.Size(136, 16);
            this.chkDayShowTimeAsClocks.TabIndex = 0;
            this.chkDayShowTimeAsClocks.Text = "Show Time as Clocks";
            this.chkDayShowTimeAsClocks.CheckedChanged += new System.EventHandler(this.chkDayShowTimeAsClocks_CheckedChanged);
            // 
            // gbxDayView
            // 
            this.gbxDayView.Controls.Add(this.label1);
            this.gbxDayView.Controls.Add(this.cmdTimeZone);
            this.gbxDayView.Controls.Add(this.cmbTimeScale);
            this.gbxDayView.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbxDayView.Location = new System.Drawing.Point(291, 5);
            this.gbxDayView.Name = "gbxDayView";
            this.gbxDayView.Size = new System.Drawing.Size(177, 97);
            this.gbxDayView.TabIndex = 1;
            this.gbxDayView.TabStop = false;
            this.gbxDayView.Text = "Day View";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time Scale:";
            // 
            // cmdTimeZone
            // 
            this.cmdTimeZone.Location = new System.Drawing.Point(80, 56);
            this.cmdTimeZone.Name = "cmdTimeZone";
            this.cmdTimeZone.Size = new System.Drawing.Size(80, 24);
            this.cmdTimeZone.TabIndex = 1;
            this.cmdTimeZone.Text = "Time Zone";
            // 
            // cmbTimeScale
            // 
            this.cmbTimeScale.Location = new System.Drawing.Point(80, 34);
            this.cmbTimeScale.Name = "cmbTimeScale";
            this.cmbTimeScale.Size = new System.Drawing.Size(80, 21);
            this.cmbTimeScale.TabIndex = 0;
            this.cmbTimeScale.SelectedIndexChanged += new System.EventHandler(this.cmbTimeScale_SelectedIndexChanged);
            // 
            // gbxCalendarWorkWeek
            // 
            this.gbxCalendarWorkWeek.Controls.Add(this.cmbEndTime);
            this.gbxCalendarWorkWeek.Controls.Add(this.label5);
            this.gbxCalendarWorkWeek.Controls.Add(this.cmbStartTime);
            this.gbxCalendarWorkWeek.Controls.Add(this.label4);
            this.gbxCalendarWorkWeek.Controls.Add(this.cmbFirstDayOfWeek);
            this.gbxCalendarWorkWeek.Controls.Add(this.label3);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkSaturday);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkFriday);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkThursday);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkWednesday);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkTuesday);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkMonday);
            this.gbxCalendarWorkWeek.Controls.Add(this.chkSunday);
            this.gbxCalendarWorkWeek.Location = new System.Drawing.Point(9, 5);
            this.gbxCalendarWorkWeek.Name = "gbxCalendarWorkWeek";
            this.gbxCalendarWorkWeek.Size = new System.Drawing.Size(279, 97);
            this.gbxCalendarWorkWeek.TabIndex = 0;
            this.gbxCalendarWorkWeek.TabStop = false;
            this.gbxCalendarWorkWeek.Text = "Calendar Work Week";
            // 
            // cmbEndTime
            // 
            this.cmbEndTime.Location = new System.Drawing.Point(200, 69);
            this.cmbEndTime.Name = "cmbEndTime";
            this.cmbEndTime.Size = new System.Drawing.Size(72, 21);
            this.cmbEndTime.TabIndex = 12;
            this.cmbEndTime.SelectedIndexChanged += new System.EventHandler(this.cmbEndTime_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(144, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "End Time:";
            // 
            // cmbStartTime
            // 
            this.cmbStartTime.Location = new System.Drawing.Point(72, 69);
            this.cmbStartTime.Name = "cmbStartTime";
            this.cmbStartTime.Size = new System.Drawing.Size(72, 21);
            this.cmbStartTime.TabIndex = 10;
            this.cmbStartTime.SelectedIndexChanged += new System.EventHandler(this.cmbStartTime_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Start Time:";
            // 
            // cmbFirstDayOfWeek
            // 
            this.cmbFirstDayOfWeek.Location = new System.Drawing.Point(112, 40);
            this.cmbFirstDayOfWeek.Name = "cmbFirstDayOfWeek";
            this.cmbFirstDayOfWeek.Size = new System.Drawing.Size(120, 21);
            this.cmbFirstDayOfWeek.TabIndex = 8;
            this.cmbFirstDayOfWeek.SelectedIndexChanged += new System.EventHandler(this.cmbFirstDayOfWeek_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "First Day of Week:";
            // 
            // chkSaturday
            // 
            this.chkSaturday.Checked = true;
            this.chkSaturday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaturday.Location = new System.Drawing.Point(200, 16);
            this.chkSaturday.Name = "chkSaturday";
            this.chkSaturday.Size = new System.Drawing.Size(32, 16);
            this.chkSaturday.TabIndex = 6;
            this.chkSaturday.Text = "S";
            this.chkSaturday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // chkFriday
            // 
            this.chkFriday.Checked = true;
            this.chkFriday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFriday.Location = new System.Drawing.Point(168, 16);
            this.chkFriday.Name = "chkFriday";
            this.chkFriday.Size = new System.Drawing.Size(32, 16);
            this.chkFriday.TabIndex = 5;
            this.chkFriday.Text = "F";
            this.chkFriday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // chkThursday
            // 
            this.chkThursday.Checked = true;
            this.chkThursday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThursday.Location = new System.Drawing.Point(136, 16);
            this.chkThursday.Name = "chkThursday";
            this.chkThursday.Size = new System.Drawing.Size(32, 16);
            this.chkThursday.TabIndex = 4;
            this.chkThursday.Text = "T";
            this.chkThursday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // chkWednesday
            // 
            this.chkWednesday.Checked = true;
            this.chkWednesday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWednesday.Location = new System.Drawing.Point(104, 16);
            this.chkWednesday.Name = "chkWednesday";
            this.chkWednesday.Size = new System.Drawing.Size(32, 16);
            this.chkWednesday.TabIndex = 3;
            this.chkWednesday.Text = "W";
            this.chkWednesday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // chkTuesday
            // 
            this.chkTuesday.Checked = true;
            this.chkTuesday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTuesday.Location = new System.Drawing.Point(72, 16);
            this.chkTuesday.Name = "chkTuesday";
            this.chkTuesday.Size = new System.Drawing.Size(32, 16);
            this.chkTuesday.TabIndex = 2;
            this.chkTuesday.Text = "T";
            this.chkTuesday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // chkMonday
            // 
            this.chkMonday.Checked = true;
            this.chkMonday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonday.Location = new System.Drawing.Point(40, 16);
            this.chkMonday.Name = "chkMonday";
            this.chkMonday.Size = new System.Drawing.Size(32, 16);
            this.chkMonday.TabIndex = 1;
            this.chkMonday.Text = "M";
            this.chkMonday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // chkSunday
            // 
            this.chkSunday.Checked = true;
            this.chkSunday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSunday.Location = new System.Drawing.Point(8, 16);
            this.chkSunday.Name = "chkSunday";
            this.chkSunday.Size = new System.Drawing.Size(32, 16);
            this.chkSunday.TabIndex = 0;
            this.chkSunday.Text = "S";
            this.chkSunday.CheckedChanged += new System.EventHandler(this.WorkWeekDayCheck_Click);
            // 
            // labelPane
            // 
            this.labelPane.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelPane.Controls.Add(this.labday);
            this.labelPane.Controls.Add(this.lblDate);
            this.labelPane.Controls.Add(this.labweek);
            this.labelPane.Controls.Add(this.lblCalendar);
            this.labelPane.Controls.Add(this.labmonth);
            this.labelPane.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPane.Location = new System.Drawing.Point(0, 69);
            this.labelPane.Name = "labelPane";
            this.labelPane.Size = new System.Drawing.Size(1362, 24);
            this.labelPane.TabIndex = 4;
            // 
            // labday
            // 
            this.labday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labday.Image = ((System.Drawing.Image)(resources.GetObject("labday.Image")));
            this.labday.Location = new System.Drawing.Point(650, 4);
            this.labday.Name = "labday";
            this.labday.Size = new System.Drawing.Size(57, 17);
            this.labday.TabIndex = 11;
            this.labday.Click += new System.EventHandler(this.labday_Click);
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblDate.Location = new System.Drawing.Point(722, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(632, 16);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // labweek
            // 
            this.labweek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labweek.Image = ((System.Drawing.Image)(resources.GetObject("labweek.Image")));
            this.labweek.Location = new System.Drawing.Point(594, 4);
            this.labweek.Name = "labweek";
            this.labweek.Size = new System.Drawing.Size(57, 17);
            this.labweek.TabIndex = 10;
            this.labweek.Click += new System.EventHandler(this.labweek_Click);
            // 
            // lblCalendar
            // 
            this.lblCalendar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCalendar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblCalendar.Location = new System.Drawing.Point(199, 0);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(96, 24);
            this.lblCalendar.TabIndex = 0;
            this.lblCalendar.Text = "Calendar";
            this.lblCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labmonth
            // 
            this.labmonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labmonth.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labmonth.Image = ((System.Drawing.Image)(resources.GetObject("labmonth.Image")));
            this.labmonth.Location = new System.Drawing.Point(538, 4);
            this.labmonth.Name = "labmonth";
            this.labmonth.Size = new System.Drawing.Size(57, 17);
            this.labmonth.TabIndex = 9;
            this.labmonth.Click += new System.EventHandler(this.labmonth_Click);
            // 
            // wndCalendarControl
            // 
            this.wndCalendarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wndCalendarControl.Location = new System.Drawing.Point(196, 93);
            this.wndCalendarControl.Name = "wndCalendarControl";
            this.wndCalendarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wndCalendarControl.OcxState")));
            this.wndCalendarControl.Size = new System.Drawing.Size(908, 407);
            this.wndCalendarControl.TabIndex = 5;
            this.wndCalendarControl.DblClick += new System.EventHandler(this.wndCalendarControl_DblClick);
            this.wndCalendarControl.MouseDownEvent += new AxXtremeCalendarControl._DCalendarControlEvents_MouseDownEventHandler(this.wndCalendarControl_MouseDownEvent);
            this.wndCalendarControl.MouseMoveEvent += new AxXtremeCalendarControl._DCalendarControlEvents_MouseMoveEventHandler(this.wndCalendarControl_MouseMoveEvent);
            this.wndCalendarControl.ViewChanged += new System.EventHandler(this.wndCalendarControl_ViewChanged);
            this.wndCalendarControl.EventChanged += new AxXtremeCalendarControl._DCalendarControlEvents_EventChangedEventHandler(this.wndCalendarControl_EventChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.dataGridViewdoctor);
            this.panel1.Controls.Add(this.combodoctors);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 407);
            this.panel1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(3, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 25);
            this.button3.TabIndex = 12;
            this.button3.Text = "All Doctors";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewdoctor
            // 
            this.dataGridViewdoctor.AllowUserToAddRows = false;
            this.dataGridViewdoctor.AllowUserToDeleteRows = false;
            this.dataGridViewdoctor.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewdoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewdoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewdoctor.GridColor = System.Drawing.Color.White;
            this.dataGridViewdoctor.Location = new System.Drawing.Point(5, 50);
            this.dataGridViewdoctor.Name = "dataGridViewdoctor";
            this.dataGridViewdoctor.ReadOnly = true;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridViewdoctor.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewdoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewdoctor.Size = new System.Drawing.Size(183, 309);
            this.dataGridViewdoctor.TabIndex = 1;
            this.dataGridViewdoctor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdoctor_CellClick);
            // 
            // combodoctors
            // 
            this.combodoctors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combodoctors.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combodoctors.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combodoctors.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.combodoctors.FormattingEnabled = true;
            this.combodoctors.Items.AddRange(new object[] {
            "Category",
            "Doctors"});
            this.combodoctors.Location = new System.Drawing.Point(0, 0);
            this.combodoctors.Name = "combodoctors";
            this.combodoctors.Size = new System.Drawing.Size(194, 21);
            this.combodoctors.Sorted = true;
            this.combodoctors.TabIndex = 0;
            this.combodoctors.Text = "Doctors";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridViewAppointment);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1104, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 407);
            this.panel2.TabIndex = 7;
            // 
            // dataGridViewAppointment
            // 
            this.dataGridViewAppointment.AllowUserToAddRows = false;
            this.dataGridViewAppointment.AllowUserToDeleteRows = false;
            this.dataGridViewAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewAppointment.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAppointment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppointment.GridColor = System.Drawing.Color.White;
            this.dataGridViewAppointment.Location = new System.Drawing.Point(1, 105);
            this.dataGridViewAppointment.MultiSelect = false;
            this.dataGridViewAppointment.Name = "dataGridViewAppointment";
            this.dataGridViewAppointment.ReadOnly = true;
            this.dataGridViewAppointment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewAppointment.Size = new System.Drawing.Size(257, 337);
            this.dataGridViewAppointment.TabIndex = 14;
            this.dataGridViewAppointment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAppointment_CellClick);
            this.dataGridViewAppointment.Click += new System.EventHandler(this.dataGridViewAppointment_Click);
            // 
            // label10
            // 
            this.label10.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Image = ((System.Drawing.Image)(resources.GetObject("label10.Image")));
            this.label10.Location = new System.Drawing.Point(174, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 59);
            this.label10.TabIndex = 13;
            this.label10.Text = "8";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.ForestGreen;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(117, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 59);
            this.label9.TabIndex = 12;
            this.label9.Text = "58";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(58, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 59);
            this.label8.TabIndex = 11;
            this.label8.Text = "41";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.OrangeRed;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(1, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 59);
            this.label7.TabIndex = 10;
            this.label7.Text = "74";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(-1, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(237, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Today\'s Appointment";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.BTn_Cancel);
            this.panel4.Controls.Add(this.lblnote);
            this.panel4.Controls.Add(this.lblprocedure);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.lab_p_add);
            this.panel4.Controls.Add(this.lab_p_name);
            this.panel4.Controls.Add(this.lab_dr_name);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.lab_p_app_time);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(474, 163);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 194);
            this.panel4.TabIndex = 8;
            this.panel4.Visible = false;
            // 
            // BTn_Cancel
            // 
            this.BTn_Cancel.BackColor = System.Drawing.Color.DarkGreen;
            this.BTn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTn_Cancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTn_Cancel.ForeColor = System.Drawing.Color.White;
            this.BTn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTn_Cancel.Location = new System.Drawing.Point(178, 164);
            this.BTn_Cancel.Name = "BTn_Cancel";
            this.BTn_Cancel.Size = new System.Drawing.Size(52, 25);
            this.BTn_Cancel.TabIndex = 14;
            this.BTn_Cancel.Text = "Cancel";
            this.BTn_Cancel.UseVisualStyleBackColor = false;
            this.BTn_Cancel.Click += new System.EventHandler(this.BTn_Cancel_Click);
            // 
            // lblnote
            // 
            this.lblnote.AutoSize = true;
            this.lblnote.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnote.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblnote.Location = new System.Drawing.Point(7, 109);
            this.lblnote.Name = "lblnote";
            this.lblnote.Size = new System.Drawing.Size(35, 13);
            this.lblnote.TabIndex = 13;
            this.lblnote.Text = "Note:";
            // 
            // lblprocedure
            // 
            this.lblprocedure.AutoSize = true;
            this.lblprocedure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprocedure.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblprocedure.Location = new System.Drawing.Point(7, 93);
            this.lblprocedure.Name = "lblprocedure";
            this.lblprocedure.Size = new System.Drawing.Size(62, 13);
            this.lblprocedure.TabIndex = 12;
            this.lblprocedure.Text = "Procedure:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LimeGreen;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(124, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 24);
            this.button2.TabIndex = 11;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gray;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(5, 165);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 24);
            this.button4.TabIndex = 10;
            this.button4.Text = "Details";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Tomato;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(65, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 24);
            this.button1.TabIndex = 10;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(237, 8);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lab_p_add
            // 
            this.lab_p_add.BackColor = System.Drawing.Color.Transparent;
            this.lab_p_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_p_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lab_p_add.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_p_add.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lab_p_add.Location = new System.Drawing.Point(51, 18);
            this.lab_p_add.Name = "lab_p_add";
            this.lab_p_add.Size = new System.Drawing.Size(179, 33);
            this.lab_p_add.TabIndex = 1;
            this.lab_p_add.Text = "09293\r\n049504091113";
            this.lab_p_add.Click += new System.EventHandler(this.lab_p_add_Click);
            this.lab_p_add.MouseEnter += new System.EventHandler(this.lab_p_add_MouseEnter);
            this.lab_p_add.MouseLeave += new System.EventHandler(this.lab_p_add_MouseLeave);
            // 
            // lab_p_name
            // 
            this.lab_p_name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lab_p_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lab_p_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_p_name.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lab_p_name.Location = new System.Drawing.Point(50, 2);
            this.lab_p_name.Name = "lab_p_name";
            this.lab_p_name.Size = new System.Drawing.Size(182, 17);
            this.lab_p_name.TabIndex = 7;
            this.lab_p_name.Text = "Bije";
            this.lab_p_name.Click += new System.EventHandler(this.lab_p_name_Click);
            // 
            // lab_dr_name
            // 
            this.lab_dr_name.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lab_dr_name.BackColor = System.Drawing.Color.White;
            this.lab_dr_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lab_dr_name.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_dr_name.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lab_dr_name.Location = new System.Drawing.Point(-1, 129);
            this.lab_dr_name.Name = "lab_dr_name";
            this.lab_dr_name.Size = new System.Drawing.Size(237, 33);
            this.lab_dr_name.TabIndex = 4;
            this.lab_dr_name.Text = "With Dr. Binu Peter";
            this.lab_dr_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(7, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Booked By";
            // 
            // lab_p_app_time
            // 
            this.lab_p_app_time.AutoSize = true;
            this.lab_p_app_time.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_p_app_time.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lab_p_app_time.Location = new System.Drawing.Point(7, 60);
            this.lab_p_app_time.Name = "lab_p_app_time";
            this.lab_p_app_time.Size = new System.Drawing.Size(215, 13);
            this.lab_p_app_time.TabIndex = 3;
            this.lab_p_app_time.Text = "08:00 am on 19 December for 1 hr 0 mins";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 43);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listpatientsearch
            // 
            this.listpatientsearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listpatientsearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listpatientsearch.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.listpatientsearch.FormattingEnabled = true;
            this.listpatientsearch.ItemHeight = 20;
            this.listpatientsearch.Location = new System.Drawing.Point(3, 3);
            this.listpatientsearch.Name = "listpatientsearch";
            this.listpatientsearch.Size = new System.Drawing.Size(244, 100);
            this.listpatientsearch.TabIndex = 57;
            this.listpatientsearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listpatientsearch_MouseClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.listpatientsearch);
            this.panel5.Location = new System.Drawing.Point(743, 85);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(250, 118);
            this.panel5.TabIndex = 9;
            this.panel5.Visible = false;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // Main_Calendar
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1362, 516);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.wndCalendarControl);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPane);
            this.Controls.Add(this.sbStatusBar);
            this.Controls.Add(this.OptionsPane);
            this.Controls.Add(this.toolBar1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "Main_Calendar";
            this.Text = "Calendar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.OptionsPane.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbxMonthView.ResumeLayout(false);
            this.gbxWeekView.ResumeLayout(false);
            this.gbxDayView.ResumeLayout(false);
            this.gbxCalendarWorkWeek.ResumeLayout(false);
            this.labelPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wndCalendarControl)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdoctor)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointment)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        //static void Main() 
        //{
        //    Application.Run(new frmMain());
        //}
        private void UpdateDateLabel()
        {
            if (wndCalendarControl.ActiveView.DaysCount == 1)
            {
                DateTime DateLabel = wndCalendarControl.ActiveView[0].Date;
                lblDate.Text = DateLabel.ToLongDateString();
            }
            else if (wndCalendarControl.ActiveView.DaysCount > 1)
            {
                DateTime DateLabelFrom = wndCalendarControl.ActiveView[0].Date;
                DateTime DateLabelTo = wndCalendarControl.ActiveView[wndCalendarControl.ActiveView.DaysCount - 1].Date;
                lblDate.Text = DateLabelFrom.ToLongDateString() + " - " + DateLabelTo.ToLongDateString();
            }
        }

        private void mnuViewOptionsBar_Click(object sender, System.EventArgs e)
        {
            mnuViewOptionsBar.Checked = (mnuViewOptionsBar.Checked ? false : true);
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "FileNew":
                    break;
                case "FileOpen":
                    mnuFileOpen_Click(this, new System.EventArgs());
                    break;
                case "FileSave":
                    mnuFileSave_Click(this, new System.EventArgs());
                    break;
                case "PrintPageSetup":
                    mnuFilePrintPageSetup_Click(this, new System.EventArgs());
                    break;
                case "PrintPreview":
                    mnuFilePrintPreview_Click(this, new System.EventArgs());
                    break;
                case "Print":
                    mnuFilePrint_Click(this, new System.EventArgs());
                    break;
                case "EditUndo":
                    break;
                case "EditCut":
                    break;
                case "EditCopy":
                    break;
                case "EditPaste":
                    break;
                case "DayView":
                    mnuCalendarDayView_Click(this, new System.EventArgs());
                    break;
                case "WorkWeekView":
                    mnuCalendarWorkWeekView_Click(this, new System.EventArgs());
                    break;
                case "WeekView":
                    mnuCalendarWeekView_Click(this, new System.EventArgs());
                    break;
                case "MonthView":
                    mnuCalendarMonthView_Click(this, new System.EventArgs());
                    break;
                case "DatePicker":
                   // mnuDatePicker_Click(this, new System.EventArgs());
                    break;
                case "OptionsPane":
                    mnuViewOptionsBar_Click(this, new System.EventArgs());
                    break;
                case "HelpAbout":
                    break;
            }
        }

        private void mnuDatePicker_Click(object sender, System.EventArgs e)//vendathathkond thalkalathek ozhivakkiyath
        {
            if (mnuDatePicker.Checked == true)
            {
                if (frmDatePicker != null)
                {
                  PappyjoeMVC.View.DatePicker.Instance.Close();
                }
                mnuDatePicker.Checked = false;
            }
            else
            {
                frmDatePicker = new PappyjoeMVC.View.DatePicker();
                frmDatePicker.Owner = this;
                frmDatePicker.ShowInTaskbar = false;
                frmDatePicker.Show();
                UpdateDatePicker();
                mnuDatePicker.Checked = true;
            }
        }

        private void wndCalendarControl_PrePopulate(object sender, AxXtremeCalendarControl._DCalendarControlEvents_PrePopulateEvent e)
        {
            if (menuShowCustomIcons.Checked)
            {
                for (int i = 0; i < e.events.Count; i++)
                {
                    CalendarEvent pEvent = e.events[i];
                    System.Diagnostics.Debug.WriteLine("wndCalendarControl_PrePopulate = " + pEvent.Subject);
                    int nIconID = (i % 5) + 1;
                    pEvent.CustomIcons.AddIfNeed(nIconID);
                    nIconID = ((i + nCustomIconCounter) % 5) + 1;
                    pEvent.CustomIcons.AddIfNeed(nIconID);
                    nIconID = ((i + nCustomIconCounter * 11) % 5) + 1;
                    pEvent.CustomIcons.AddIfNeed(nIconID);
                    nCustomIconCounter++;
                }
            }
            else
            {
                for (int i = 0; i < e.events.Count; i++)
                {
                    CalendarEvent pEvent = e.events[i];
                    pEvent.CustomIcons.RemoveAll();
                }
            }
        }

        private String RemoveLastDir(String strPath)
        {
            int nNewLen = strPath.Length;
            if (nNewLen > 0 && (strPath[nNewLen - 1] == '\\' || strPath[nNewLen - 1] == '/'))
            {
                nNewLen--;
            }
            while (nNewLen > 0 && strPath[nNewLen - 1] != '\\' && strPath[nNewLen - 1] != '/')
            {
                nNewLen--;
            }
            return strPath.Substring(0, nNewLen);
        }

        private void menuShowCustomIcons_Click(object sender, System.EventArgs e)
        {
            CalendarThemeOffice2007 pTheme2007 = (CalendarThemeOffice2007)wndCalendarControl.Theme;
            if (pTheme2007 != null)
            {
                menuShowCustomIcons.Checked = !menuShowCustomIcons.Checked;
                System.Array arCustIconsIDs = System.Array.CreateInstance(typeof(Int32), 6);
                arCustIconsIDs.SetValue(1, 0); // unread mail
                arCustIconsIDs.SetValue(2, 1); // read mail
                arCustIconsIDs.SetValue(3, 2); // replyed mail
                arCustIconsIDs.SetValue(4, 3); // attachment
                arCustIconsIDs.SetValue(5, 4); // Low priority
                arCustIconsIDs.SetValue(6, 5); // HIGH priority
                pTheme2007.CustomIcons.RemoveAll();
                String strPath = Application.StartupPath;
                strPath = RemoveLastDir(strPath);
                strPath = RemoveLastDir(strPath);
                strPath += "Icons\\EventCustomIcons.bmp";
                pTheme2007.CustomIcons.LoadBitmap(strPath, arCustIconsIDs, XTPImageState.xtpImageNormal);
            }
            wndCalendarControl.Populate();
        }

        private void frmMain_Load(object sender, System.EventArgs e)//aswini
        {
            toolStripButton2.BackColor = Color.SkyBlue;
            toolStripButton9.ToolTipText = PappyjoeMVC.Model.GlobalVariables.Version;
            //string i;
            string i = this.cntrl.appoinmt_permission(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='AP'");
            if (int.Parse(i) > 0)
            {
                dr_wise_apt = false;
                listAppointment(doctor_id.ToString());
            }
            else
            {
                dr_wise_apt = true;
                listAppointment("0");
            }
            AddTestEvents(true);
            //listAppointment(doctor_id.ToString());
            //listAppointment("0");

            gridbinddoctors();
            string a = PappyjoeMVC.Model.Connection.MyGlobals.loginType;
            try
            {
                string docnam = this.cntrl.Get_DoctorName(doctor_id);// db.table("select doctor_name from tbl_doctor Where id='" + doctor_id + "'");
                if (docnam!="")
                {
                    toolStripldoc.Text = "Logged In As : " + docnam;
                }
                string clinic = this.cntrl.Load_CompanyName();
                toolStripButton1.Text = clinic;
                string contactnumber = this.cntrl.contactnumber();// DataTable clinicname = db.table("select name,contact_no from tbl_practice_details");
                if (contactnumber!="")
                {
                    //string clinicn = "";
                    //clinicn = clinicname.Rows[0][0].ToString();
                    //toolStripButton1.Text = clinicn.Replace("¤", "'");
                    contact_no = contactnumber;

                }
                mnuEnableReminders_Click(this, new System.EventArgs());
                string strslot = "";
                //DataTable tb_slot = db.table("select slot from tbl_practice_timings");
                //if (tb_slot.Rows.Count > 0)
                //{
                    strslot = this.cntrl.get_slot();// tb_slot.Rows[0][0].ToString();
                //}
                if (strslot.Trim() == "5")
                {
                    CheckTimeScaleItems(NewTimeScale.FiveMin);
                    UpdateTimeScaleCombo(NewTimeScale.FiveMin);
                    wndCalendarControl.DayView.TimeScale = 5;
                    wndCalendarControl.DayView.TimeScaleMinTime = Convert.ToDateTime("6:00");

                }
                else if (strslot.Trim() == "6")
                {
                    CheckTimeScaleItems(NewTimeScale.SixMin);
                    UpdateTimeScaleCombo(NewTimeScale.SixMin);
                    wndCalendarControl.DayView.TimeScale = 6;
                    wndCalendarControl.DayView.TimeScaleMinTime = Convert.ToDateTime("6:00");
                }
                else if (strslot.Trim() == "10")
                {
                    CheckTimeScaleItems(NewTimeScale.TenMin);
                    UpdateTimeScaleCombo(NewTimeScale.TenMin);
                    wndCalendarControl.DayView.TimeScale = 10;
                    wndCalendarControl.DayView.TimeScaleMinTime = Convert.ToDateTime("6:00");
                }
                else if (strslot.Trim() == "15")
                {
                    CheckTimeScaleItems(NewTimeScale.QuarterHour);
                    UpdateTimeScaleCombo(NewTimeScale.QuarterHour);
                    wndCalendarControl.DayView.TimeScale = 15;
                    wndCalendarControl.DayView.TimeScaleMinTime = Convert.ToDateTime("6:00");
                }
                else if (strslot.Trim() == "30")
                {
                    CheckTimeScaleItems(NewTimeScale.HalfHour);
                    UpdateTimeScaleCombo(NewTimeScale.HalfHour);
                    wndCalendarControl.DayView.TimeScale = 30;
                    wndCalendarControl.DayView.TimeScaleMinTime = Convert.ToDateTime("6:00");
                }
                else
                {
                    CheckTimeScaleItems(NewTimeScale.Hour);
                    UpdateTimeScaleCombo(NewTimeScale.Hour);
                    wndCalendarControl.DayView.TimeScale = 60;
                    wndCalendarControl.DayView.TimeScaleMinTime = Convert.ToDateTime("6:00");
                }
                //For Privilege check.
                if (doctor_id != "1")
                {
                    string id = this.cntrl.permission_for_add(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='A'");
                    if (int.Parse(id) > 0)
                    {
                        APTAdd = false;
                    }
                    else
                    {
                        APTAdd = true;
                    }
                    id = this.cntrl.permission_for_edit(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='E'");
                    if (int.Parse(id) > 0)
                    {
                        button2.Visible = false;
                        APTEdit = false;
                    }
                    else
                    {
                        button2.Visible = true;
                        APTEdit = true;
                    }
                    id = this.cntrl.permission_for_delete(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID=" + doctor_id + " and Category='APT' and Permission='D'");
                    if (int.Parse(id) > 0)
                    {
                        button1.Visible = false;
                    }
                    else
                    {
                        button1.Visible = true;
                    }
                }
                else
                {
                    APTAdd = true;
                }
            }
            catch { MessageBox.Show("System error..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void mnuFileSave_Click(object sender, System.EventArgs e)
        {
            if (wndCalendarControl.DataProvider.IsOpen)
            {
                wndCalendarControl.DataProvider.Save();
            }
        }

        private void mnuViewRemindersWindow_Click(object sender, System.EventArgs e)
        {
            objCalendraDialogsReminders.ShowRemindersWindow();
        }

        private void mnuEnableReminders_Click(object sender, System.EventArgs e)
        {
            mnuEnableReminders.Checked = !mnuEnableReminders.Checked;
            if (mnuEnableReminders.Checked)
            {
                objCalendraDialogsReminders.Calendar = (XtremeCalendarControl.CalendarControl)wndCalendarControl.GetOcx();
                objCalendraDialogsReminders.RemindersWindowShowInTaskBar = true;
                objCalendraDialogsReminders.CreateRemindersWindow();
            }
            else
            {
                objCalendraDialogsReminders.CloseRemindersWindow();
            }
            wndCalendarControl.EnableReminders(mnuEnableReminders.Checked);
            mnuViewRemindersWindow.Enabled = mnuEnableReminders.Checked;
        }

        private void mnuThemeOffice2007_Click(object sender, System.EventArgs e)
        {
            CalendarThemeOffice2007 pTheme2007;
            pTheme2007 = (CalendarThemeOffice2007)wndCalendarControl.Theme;
            if (pTheme2007 == null)
            {
                pTheme2007 = new CalendarThemeOffice2007();
                wndCalendarControl.SetTheme(pTheme2007);
                mnuThemeOffice2007.Checked = true;
            }
            else
            {
               wndCalendarControl.SetTheme(null);
               mnuThemeOffice2007.Checked = false;
            }
            wndCalendarControl.Populate();
        }

        private void mnuFilePrintPageSetup_Click(object sender, System.EventArgs e)
        {
            wndCalendarControl.ShowPrintPageSetup();
        }

        private void mnuFilePrintPreview_Click(object sender, System.EventArgs e)
        {
            wndCalendarControl.PrintPreview(true);
        }

        private void mnuFilePrint_Click(object sender, System.EventArgs e)
        {
            wndCalendarControl.PrintCalendar2(true);
        }

        private void wndCalendarControl_BeforeDrawDayViewCell(object sender, AxXtremeCalendarControl._DCalendarControlEvents_BeforeDrawDayViewCellEvent e)
        {
            if (e.cellParams.Selected)
            {
                return;
            }
            if (e.cellParams.BeginTime.Hour >= 13 && e.cellParams.BeginTime.Hour < 14 &&
                e.cellParams.BeginTime.DayOfWeek != System.DayOfWeek.Saturday &&
                e.cellParams.BeginTime.DayOfWeek != System.DayOfWeek.Sunday)
            {
                e.cellParams.BackgroundColor = (uint)System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(198, 198, 198));
            }
        }

        private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (wndCalendarControl.DataProvider.IsOpen)
            {
                wndCalendarControl.DataProvider.Save();
            }
        }

        private void mnuFileOpen_Click(object sender, System.EventArgs e)
        {
            //frmOpenDataProvider frmOpenDP = new frmOpenDataProvider();
            //System.Windows.Forms.DialogResult nDlgRes = frmOpenDP.ShowDialog(this);
            //if (nDlgRes != System.Windows.Forms.DialogResult.OK)
            //{
            //    return;
            //}
            //int eDPType = frmOpenDP.GetDataProviderType();
            //Boolean bOpened = false;
            //m_objSQLProvider = null;
            //if (eDPType == (int)DataProviderTypeCustom.dpSQLServer)
            //{
            //    bOpened = OpenSQLServerDataProvider(frmOpenDP.GetConnectionString());
            //}
            //else
            //{
            //    bOpened = OpenBuiltInDataProvider(frmOpenDP.GetConnectionString(), eDPType);
            //}
            //if (!bOpened)
            //{
            //    wndCalendarControl.SetDataProvider("");
            //    wndCalendarControl.DataProvider.Open();
            //}
            //wndCalendarControl.Populate();
            //UpdateDatePicker();
            //this.Text = " " + GetDPTitle(eDPType);
        }

        //private String GetDPTitle(int eDPType)
        //{
        //    if (eDPType == (int)DataProviderType.dpMemory)
        //    {
        //        return "[Memory Data Provider]: " + wndCalendarControl.DataProvider.DataSource;
        //    }
        //    else if (eDPType == (int)DataProviderType.dpDB)
        //    {
        //        return "[DB (Access) Data Provider]: " + wndCalendarControl.DataProvider.DataSource;
        //    }
        //    else if (eDPType == (int)DataProviderType.dpMAPI)
        //    {
        //        return "[MAPI Data Provider]. ";
        //    }
        //    else if (eDPType == (int)DataProviderTypeCustom.dpSQLServer)
        //    {
        //        return "[SQL Server custom Data Provider]: " + m_objSQLProvider.GetConnectionString();
        //    }
        //    return "";
        //}

        private Boolean OpenSQLServerDataProvider(String strConnectionString)
        {
            //try
            //{
            //    m_objSQLProvider = new providerSQLServer(wndCalendarControl);
            //    m_objSQLProvider.Open(strConnectionString);
            //    if (wndCalendarControl.DataProvider != null && wndCalendarControl.DataProvider.IsOpen)
            //    {
            //        wndCalendarControl.DataProvider.Close();
            //    }
            //    wndCalendarControl.SetDataProvider("Provider=Custom;");
            //    wndCalendarControl.DataProvider.Open();
            //    wndCalendarControl.DataProvider.CacheMode = CalendarDataProviderCacheMode.xtpCalendarDPCacheModeOnRepeat;
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show("Cannot connect to server. \n Error: \n " + ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            return false;
        }

        private Boolean OpenBuiltInDataProvider(String strConnectionString, int eDPType)
        {
            if (wndCalendarControl.DataProvider != null && wndCalendarControl.DataProvider.IsOpen)
            {
                wndCalendarControl.DataProvider.Save();
                wndCalendarControl.DataProvider.Close();
            }
            wndCalendarControl.SetDataProvider(strConnectionString);
            Boolean bOpened = wndCalendarControl.DataProvider.Open();
            if (bOpened)
            {
                return true;
            }
            //if (eDPType == (int)DataProviderType.dpMAPI)
            //{
            //    System.Windows.Forms.MessageBox.Show("Cannot open MAPI data provider.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}
            System.Windows.Forms.DialogResult nDlgRes = System.Windows.Forms.MessageBox.Show(
                "Cannot open specified data source. \nWould You like to recreate it?",
                "Calendar Control",
                System.Windows.Forms.MessageBoxButtons.YesNo);
            if (nDlgRes != System.Windows.Forms.DialogResult.Yes)
            {
                return false;
            }
            Boolean bCreated = wndCalendarControl.DataProvider.Create();
            if (!bCreated)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Cannot create specified data source:\n " + wndCalendarControl.DataProvider.DataSource);
                return false;
            }
            nDlgRes = System.Windows.Forms.MessageBox.Show(
                        "Would You like to add default test events set?",
                        "Calendar Control",
                        System.Windows.Forms.MessageBoxButtons.YesNo);
            if (nDlgRes == System.Windows.Forms.DialogResult.Yes)
            {
                AddTestEvents(false);
            }
            return true;
        }

        private void mnuViewToolBar_Click(object sender, System.EventArgs e)
        {
            mnuViewToolBar.Checked = (mnuViewToolBar.Checked ? false : true);
            toolBar1.Visible = (toolBar1.Visible ? false : true);
        }

        private void mnuViewStatusBar_Click(object sender, System.EventArgs e)
        {
            mnuViewStatusBar.Checked = (mnuViewStatusBar.Checked ? false : true);
            sbStatusBar.Visible = (sbStatusBar.Visible ? false : true);
        }

        private DateTime GetStartDayTime()
        {
            DateTime BeginSelection, EndSelection;
            Boolean AllDay;
            BeginSelection = EndSelection = DateTime.Now;
            AllDay = false;
            if (wndCalendarControl.ActiveView.GetSelection(ref BeginSelection, ref EndSelection, ref AllDay) == false)
            {
                BeginSelection = DateTime.Now;
            }
            return BeginSelection;
        }

        private DateTime GetMonday(DateTime dtDate)
        {
            int Day;
            Day = (int)dtDate.DayOfWeek;
            if (Day >= 1 & Day <= 5)
            {
                Day = Day - (int)DayOfWeek.Monday;
                dtDate = dtDate.AddDays(-Day);
            }
            else if (Day == 6)
            {
                dtDate = dtDate.AddDays(2);
            }
            else if (Day == 0)
            {
                dtDate = dtDate.AddDays(1);
            }
            return dtDate;
        }

        public void CheckViewItems()
        {
            mnuCalendarDayView.Checked = (wndCalendarControl.ViewType == CalendarViewType.xtpCalendarDayView);
            mnuCalendarWorkWeekView.Checked = (wndCalendarControl.ViewType == CalendarViewType.xtpCalendarWorkWeekView);
            mnuCalendarWeekView.Checked = (wndCalendarControl.ViewType == CalendarViewType.xtpCalendarWeekView);
            mnuCalendarMonthView.Checked = (wndCalendarControl.ViewType == CalendarViewType.xtpCalendarMonthView);
            tbrDayView.Pushed = mnuCalendarDayView.Checked;
            tbrWorkWeekView.Pushed = mnuCalendarWorkWeekView.Checked;
            tbrWeekView.Pushed = mnuCalendarWeekView.Checked;
            tbrMonthView.Pushed = mnuCalendarMonthView.Checked;
        }

        private void UpdateDatePicker()
        {
            DateTime StartRange, EndRange;
            if (frmDatePicker != null)
            {
                wndCalendarControl.ActiveView.GetSelection(ref BeginSelection, ref EndSelection, ref AllDay);
                StartRange = BeginSelection;
                EndRange = EndSelection;
                if (wndCalendarControl.ActiveView.DaysCount == 1)
                {
                    StartRange = wndCalendarControl.ActiveView[0].Date;
                    EndRange = StartRange;
                }
                else if (wndCalendarControl.ActiveView.DaysCount > 1)
                {
                    StartRange = wndCalendarControl.ActiveView[0].Date;
                    EndRange = wndCalendarControl.ActiveView[wndCalendarControl.ActiveView.DaysCount - 1].Date;
                }
              PappyjoeMVC.View.DatePicker.Instance.Date_Picker.SelectRange(StartRange, EndRange);
                PappyjoeMVC.View.DatePicker.Instance.Date_Picker.Invalidate();
                PappyjoeMVC.View.DatePicker.Instance.Date_Picker.Update();
            }
        }

        private void mnuCalendarDayView_Click(object sender, System.EventArgs e)
        {
            if (wndCalendarControl.ViewType != CalendarViewType.xtpCalendarDayView)
            {
                wndCalendarControl.ViewType = CalendarViewType.xtpCalendarDayView;
            }
            UpdateDatePicker();
        }

        private void mnuCalendarWorkWeekView_Click(object sender, System.EventArgs e)
        {
            if (wndCalendarControl.ViewType != CalendarViewType.xtpCalendarWorkWeekView)
            {
                wndCalendarControl.ViewType = CalendarViewType.xtpCalendarWorkWeekView;
            }
            UpdateDatePicker();
        }

        private void mnuCalendarWeekView_Click(object sender, System.EventArgs e)
        {
            if (wndCalendarControl.ViewType != CalendarViewType.xtpCalendarWeekView)
            {
                wndCalendarControl.ViewType = CalendarViewType.xtpCalendarWeekView;
            }
            UpdateDatePicker();
        }

        private void mnuCalendarMonthView_Click(object sender, System.EventArgs e)
        {
            if (wndCalendarControl.ViewType != CalendarViewType.xtpCalendarMonthView)
            {
                wndCalendarControl.ViewType = CalendarViewType.xtpCalendarMonthView;
            }
            UpdateDatePicker();
        }

        private void mnuCalendar60Min_Click(object sender, System.EventArgs e)
        {
            CheckTimeScaleItems(NewTimeScale.Hour);
            UpdateTimeScaleCombo(NewTimeScale.Hour);
            wndCalendarControl.DayView.TimeScale = 60;
        }

        private void mnuCalendar30Min_Click(object sender, System.EventArgs e)
        {
            CheckTimeScaleItems(NewTimeScale.HalfHour);
            UpdateTimeScaleCombo(NewTimeScale.HalfHour);
            wndCalendarControl.DayView.TimeScale = 30;
        }

        private void mnuCalendar15Min_Click(object sender, System.EventArgs e)
        {
            CheckTimeScaleItems(NewTimeScale.QuarterHour);
            UpdateTimeScaleCombo(NewTimeScale.QuarterHour);
            wndCalendarControl.DayView.TimeScale = 15;
        }

        private void mnuCalendar10Min_Click(object sender, System.EventArgs e)
        {
            CheckTimeScaleItems(NewTimeScale.TenMin);
            UpdateTimeScaleCombo(NewTimeScale.TenMin);
            wndCalendarControl.DayView.TimeScale = 10;
        }

        private void mnuCalendar6Min_Click(object sender, System.EventArgs e)
        {
            CheckTimeScaleItems(NewTimeScale.SixMin);
            UpdateTimeScaleCombo(NewTimeScale.SixMin);
            wndCalendarControl.DayView.TimeScale = 6;
        }

        private void mnuCalendar5Min_Click(object sender, System.EventArgs e)
        {
            CheckTimeScaleItems(NewTimeScale.FiveMin);
            UpdateTimeScaleCombo(NewTimeScale.FiveMin);
            wndCalendarControl.DayView.TimeScale = 5;
        }

        enum NewTimeScale
        {
            Hour = 1,
            HalfHour = 2,
            QuarterHour = 4,
            TenMin = 8,
            SixMin = 16,
            FiveMin = 32
        };

        private void CheckTimeScaleItems(NewTimeScale CurrentTimeScale)
        {
            mnuCalendar60Min.Checked = ((CurrentTimeScale & NewTimeScale.Hour) == NewTimeScale.Hour);
            mnuCalendar30Min.Checked = ((CurrentTimeScale & NewTimeScale.HalfHour) == NewTimeScale.HalfHour);
            mnuCalendar15Min.Checked = ((CurrentTimeScale & NewTimeScale.QuarterHour) == NewTimeScale.QuarterHour);
            mnuCalendar10Min.Checked = ((CurrentTimeScale & NewTimeScale.TenMin) == NewTimeScale.TenMin);
            mnuCalendar6Min.Checked = ((CurrentTimeScale & NewTimeScale.SixMin) == NewTimeScale.SixMin);
            mnuCalendar5Min.Checked = ((CurrentTimeScale & NewTimeScale.FiveMin) == NewTimeScale.FiveMin);
        }

        private void UpdateTimeScaleCombo(NewTimeScale CurrentTimeScale)
        {
            switch (CurrentTimeScale)
            {
                case NewTimeScale.Hour:
                    cmbTimeScale.SelectedIndex = 0;
                    break;
                case NewTimeScale.HalfHour:
                    cmbTimeScale.SelectedIndex = 1;
                    break;
                case NewTimeScale.QuarterHour:
                    cmbTimeScale.SelectedIndex = 2;
                    break;
                case NewTimeScale.TenMin:
                    cmbTimeScale.SelectedIndex = 3;
                    break;
                case NewTimeScale.SixMin:
                    cmbTimeScale.SelectedIndex = 4;
                    break;
                case NewTimeScale.FiveMin:
                    cmbTimeScale.SelectedIndex = 5;
                    break;
            }
        }

        private void cmbTimeScale_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (cmbTimeScale.SelectedIndex)
            {
                case 0:
                    mnuCalendar60Min_Click(this, new System.EventArgs());
                    break;
                case 1:
                    mnuCalendar30Min_Click(this, new System.EventArgs());
                    break;
                case 2:
                    mnuCalendar15Min_Click(this, new System.EventArgs());
                    break;
                case 3:
                    mnuCalendar10Min_Click(this, new System.EventArgs());
                    break;
                case 4:
                    mnuCalendar6Min_Click(this, new System.EventArgs());
                    break;
                case 5:
                    mnuCalendar5Min_Click(this, new System.EventArgs());
                    break;
            }
            wndCalendarControl.Populate();
        }

        private void chkDayShowTimeAsClocks_CheckedChanged(object sender, System.EventArgs e)
        {
            wndCalendarControl.Options.WeekViewShowTimeAsClocks = (wndCalendarControl.Options.WeekViewShowTimeAsClocks ? false : true);
            wndCalendarControl.Populate();
        }

        private void chkDayShowEndTime_CheckedChanged(object sender, System.EventArgs e)
        {
            wndCalendarControl.Options.WeekViewShowEndDate = (wndCalendarControl.Options.WeekViewShowEndDate ? false : true);
            wndCalendarControl.Populate();
        }

        private void chkMonthShowTimeAsClocks_CheckedChanged(object sender, System.EventArgs e)
        {
            wndCalendarControl.Options.MonthViewShowTimeAsClocks = (wndCalendarControl.Options.MonthViewShowTimeAsClocks ? false : true);
            wndCalendarControl.Populate();
        }

        private void chkMonthShowEndTime_CheckedChanged(object sender, System.EventArgs e)
        {
            wndCalendarControl.Options.MonthViewShowEndDate = (wndCalendarControl.Options.MonthViewShowEndDate ? false : true);
            wndCalendarControl.Populate();
        }

        private void chkCompressWeekendDays_CheckedChanged(object sender, System.EventArgs e)
        {
            wndCalendarControl.Options.MonthViewCompressWeekendDays = (wndCalendarControl.Options.MonthViewCompressWeekendDays ? false : true);
            wndCalendarControl.Populate();
        }

        private void WorkWeekDayCheck_Click(object sender, System.EventArgs e)
        {
            //CalendarWeekDay WeekMask = 0;
            //WeekMask = (chkSunday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDaySunday) : WeekMask);
            //WeekMask = (chkMonday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDayMonday) : WeekMask);
            //WeekMask = (chkTuesday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDayTuesday) : WeekMask);
            //WeekMask = (chkWednesday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDayWednesday) : WeekMask);
            //WeekMask = (chkThursday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDayThursday) : WeekMask);
            //WeekMask = (chkFriday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDayFriday) : WeekMask);
            //WeekMask = (chkSaturday.Checked ? (WeekMask | CalendarWeekDay.xtpCalendarDaySaturday) : WeekMask);
            //wndCalendarControl.Options.WorkWeekMask = WeekMask;
            //wndCalendarControl.Populate();
            //if (frmDatePicker != null)
            //{
            //    frmDatePicker.Instance.DatePicker.FirstDayOfWeek = cmbFirstDayOfWeek.SelectedIndex + 1;
            //}
        }

        private void cmbFirstDayOfWeek_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            wndCalendarControl.Options.FirstDayOfTheWeek = (int)cmbFirstDayOfWeek.SelectedItem;
            wndCalendarControl.Populate();
        }

        private void cmbWeeksCount_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (wndCalendarControl.MonthView.WeeksCount != (int)cmbWeeksCount.SelectedItem)
            {
                wndCalendarControl.MonthView.WeeksCount = (int)cmbWeeksCount.SelectedItem;
                wndCalendarControl.Populate();
            }
        }

        private void cmbStartTime_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DateTime StartTime = new DateTime(cmbStartTime.SelectedIndex * 18000000000);
            wndCalendarControl.Options.WorkDayStartTime = StartTime;
            if (cmbStartTime.SelectedIndex > cmbEndTime.SelectedIndex)
            {
                cmbEndTime.SelectedIndex = cmbStartTime.SelectedIndex;
            }
            wndCalendarControl.Populate();
        }

        private void cmbEndTime_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DateTime EndTime = new DateTime(cmbEndTime.SelectedIndex * 18000000000);
            wndCalendarControl.Options.WorkDayEndTime = EndTime;
            if (cmbEndTime.SelectedIndex < cmbStartTime.SelectedIndex)
            {
                cmbStartTime.SelectedIndex = cmbEndTime.SelectedIndex;
            }
            wndCalendarControl.Populate();
        }

        private void AddTestEvents(Boolean bCreateDefaultProvider)//ASWINI
        {
            CalendarDataProvider pCalendarData = wndCalendarControl.DataProvider;
            if (bCreateDefaultProvider)
            {
                wndCalendarControl.SetDataProvider(ConnectionString + @"\TestEvents.xml");
                pCalendarData = wndCalendarControl.DataProvider;
                if (!pCalendarData.Create())
                {
                    wndCalendarControl.SetDataProvider("");
                    wndCalendarControl.DataProvider.Open();
                }
            }
            DateTime dtNow = new DateTime(DateTime.Now.Ticks);
            // Normal Event 1
            CalendarEvent ptrEvent = pCalendarData.CreateEvent();
            int mints;
            DataTable dt = new DataTable();// db.table(strSql.ToString()); //string strSql = "";
            /////Rasmi privilege checking
            if (doctor_id == "1")
            {
               dt= this.cntrl.all_dctr_appointment();// strSql = "SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,status FROM tbl_appointment  ORDER BY id";
            }
            else
            {
                if (dr_wise_apt == false)
                {
                    dt = this.cntrl.get_dctr_wise_appointment(doctor_id);//  strSql = "SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,status FROM tbl_appointment where  dr_id=" + doctor_id + " ORDER BY id";
                }
                else
                {
                    dt = this.cntrl.all_dctr_appointment();// strSql = "SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,status FROM tbl_appointment  ORDER BY id";
                }
            }

            //DataTable dt = db.table(strSql.ToString());
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                ptrEvent.StartTime = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                dtNow = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                mints = Convert.ToInt32(dt.Rows[j]["duration"].ToString());
                ptrEvent.EndTime = dtNow.AddMinutes(mints);
                ptrEvent.Subject = dt.Rows[j]["pt_name"].ToString();
                ptrEvent.Location = dtNow.ToString("t") + "-" + dtNow.AddMinutes(mints).ToString("t");
                ptrEvent.BusyStatus = CalendarEventBusyStatus.xtpCalendarBusyStatusBusy;
                string drt = this.cntrl.get_calendar_color(dt.Rows[j]["dr_id"].ToString());// db.table("SELECT calendar_color FROM tbl_doctor where id=" + dt.Rows[j]["dr_id"].ToString() + " ORDER BY id");
                if (drt!="")
                {
                    ptrEvent.Label =  Convert.ToInt32(drt);
                }
                else
                {
                    ptrEvent.Label = 0;
                }

                if (dt.Rows[j]["status"].ToString() == "CANCELLED")
                {
                    ptrEvent.Subject = dt.Rows[j]["pt_name"].ToString() + " (CANCELLED)";
                    ptrEvent.BusyStatus = CalendarEventBusyStatus.xtpCalendarBusyStatusOutOfOffice;
                    ptrEvent.Label = 10;
                }
                ptrEvent.Body = dt.Rows[j]["id"].ToString();
                pCalendarData.AddEvent(ptrEvent);
            }
            pCalendarData.Save();
            wndCalendarControl.Populate();
        }

        private void mnuContextNewEvent_Click(object sender, System.EventArgs e)
        { //Rasmi privilege checking
            if (doctor_id != "1")
            {
                string id;
                id = this.cntrl.permission_for_add(doctor_id);// db.scalar("select id from tbl_User_Privilege where UserID = " + doctor_id + " and Category='APT' and Permission='A'");
                if (int.Parse(id) > 0)
                {
                    MessageBox.Show("You have no privilages to do this. Contact your administrator to change status", "No Privilage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AppointmentBooking = new PappyjoeMVC.View. AppointmentBooking();
                    AppointmentBooking.doctor_id = doctor_id;
                    AppointmentBooking.CreateNewEvent();
                    AppointmentBooking.ShowDialog(this);
                }
            }
            else
            {
                AppointmentBooking = new PappyjoeMVC.View.AppointmentBooking();
                AppointmentBooking.doctor_id = doctor_id;
                AppointmentBooking.CreateNewEvent();
                AppointmentBooking.ShowDialog(this);
            }
        }

        private void mnuContextEditEvent_Click(object sender, System.EventArgs e)
        {
            // AppointmentBooking = new PappyjoeMVC.View.AppointmentBooking();
           AppointmentBooking bk = new  AppointmentBooking();
            if (pat_idForEdit != "0")
            {
                if (ContextEvent.RecurrenceState != CalendarEventRecurrenceState.xtpCalendarRecurrenceNotRecurring)
                {
                    frmOpenRecurringItem = new OpenRecurringItem();
                    frmOpenRecurringItem.SetInformationLabel(ContextEvent.Subject);
                    frmOpenRecurringItem.ShowDialog(this);
                    if (frmOpenRecurringItem.OpenRecurringItemAnswer == -1)
                    {
                        AppointmentBooking = null;
                        return;
                    }
                    if (frmOpenRecurringItem.OpenRecurringItemAnswer == 2)
                    {
                        ContextEvent = ContextEvent.RecurrencePattern.MasterEvent;
                    }
                    else
                    {
                        ContextEvent = ContextEvent.CloneEvent();
                        if (ContextEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceOccurrence)
                        {
                            ContextEvent.MakeAsRException();
                        }
                    }
                }
                bk.ModifyEvent(ContextEvent);
                bk.ShowDialog(this);
            }
        } 

        private void mnuContextDeleteEvent_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Delete this appointment.. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ContextEvent == null)
                {
                    return;
                }
                Boolean bDeleted = false;
                if (ContextEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceOccurrence ||
                    ContextEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceException)
                {
                    frmOpenRecurringItem = new OpenRecurringItem();
                    frmOpenRecurringItem.SetForDelete(ContextEvent.Subject);
                    frmOpenRecurringItem.ShowDialog(this);
                    if (frmOpenRecurringItem.OpenRecurringItemAnswer == -1)
                    {
                        ContextEvent = null;
                        return;
                    }
                    if (frmOpenRecurringItem.OpenRecurringItemAnswer == 2)
                    {
                        wndCalendarControl.DataProvider.DeleteEvent(ContextEvent.RecurrencePattern.MasterEvent);
                        bDeleted = true;
                    }
                }
                if (!bDeleted)
                {
                    wndCalendarControl.DataProvider.DeleteEvent(ContextEvent);
                    this.cntrl.delete_appointment(ContextEvent.Body);// int i = db.execute("delete from tbl_appointment where id='" + ContextEvent.Body + "'");
                    // Delete 
                    //string smsName = "", smsPass = "";
                    //DataTable sms = db.table("select smsName,smsPass from tbl_SmsEmailConfig");
                    //if (sms.Rows.Count > 0)
                    //{
                    //    smsName = sms.Rows[0]["smsName"].ToString();
                    //    smsPass = sms.Rows[0]["smsPass"].ToString();

                    //    DataTable tl_appoitment = db.table("select pt_id,mobile_no,plan_new_procedure,pt_name from tbl_appointment where id='" + ContextEvent.Body + "'");
                    //    if (tl_appoitment.Rows.Count > 0)
                    //    {
                    //        SMSCAPI a = new SMSCAPI();
                    //        DataTable pat = db.table("select * from tbl_patient where id='" + tl_appoitment.Rows[0]["pt_id"].ToString() + "'");
                    //        if (pat.Rows.Count > 0)
                    //        {
                    //            string number = "91" + tl_appoitment.Rows[0]["mobile_no"].ToString();
                    //            string text = "Dear " + tl_appoitment.Rows[0]["pt_name"].ToString() + " " + ", Your appointment for " + tl_appoitment.Rows[0]["plan_new_procedure"].ToString() + " has been removed..  Regards " + toolStripButton1.Text;
                    //            a.SendSMS(smsName, smsPass, number, text);
                    //            db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + tl_appoitment.Rows[0]["pt_id"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','patient','sent',Dear " + tl_appoitment.Rows[0]["pt_name"].ToString() + " " + " Your appointment for " + tl_appoitment.Rows[0]["plan_new_procedure"].ToString() + " has been removed..  Regards " + toolStripButton1.Text + "')");
                    //        }
                    //    }
                    //}

                    listAppointment("0");
                }
                wndCalendarControl.Populate();
                wndCalendarControl.RedrawControl();
            }
        }

        private void mnuContextCancelEvent_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel this appointment.. Confirm?", "Cancellation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ContextEvent == null)
                {
                    return;
                }
                Boolean bDeleted = false;
                if (ContextEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceOccurrence ||
                    ContextEvent.RecurrenceState == CalendarEventRecurrenceState.xtpCalendarRecurrenceException)
                {
                    frmOpenRecurringItem = new OpenRecurringItem();
                    frmOpenRecurringItem.SetForDelete(ContextEvent.Subject);
                    frmOpenRecurringItem.ShowDialog(this);
                    if (frmOpenRecurringItem.OpenRecurringItemAnswer == -1)
                    {
                        ContextEvent = null;
                        return;
                    }
                    if (frmOpenRecurringItem.OpenRecurringItemAnswer == 2)
                    {
                        wndCalendarControl.DataProvider.DeleteEvent(ContextEvent.RecurrencePattern.MasterEvent);
                        bDeleted = true;
                    }
                }
                if (!bDeleted)
                {
                    wndCalendarControl.DataProvider.DeleteEvent(ContextEvent);
                    this.cntrl.update_appointment_status(ContextEvent.Body);// db.execute("update tbl_appointment set status='CANCELLED'  where id='" + ContextEvent.Body + "'");

                    string smsName = "", smsPass = "";
                    DataTable sms = this.cntrl.get_sms_details();// db.table("select smsName,smsPass from tbl_SmsEmailConfig");
                    if (sms.Rows.Count > 0)
                    {
                        smsName = sms.Rows[0]["smsName"].ToString();
                        smsPass = sms.Rows[0]["smsPass"].ToString();

                        DataTable tl_appoitment = this.cntrl.get_patient_details(ContextEvent.Body);// db.table("select pt_id,mobile_no,plan_new_procedure,pt_name from tbl_appointment where id='" + ContextEvent.Body + "'");
                        if (tl_appoitment.Rows.Count > 0)
                        {
                            SMS_model a = new SMS_model();
                            DataTable pat = this.cntrl.Get_Patient_Details(tl_appoitment.Rows[0]["pt_id"].ToString());// db.table("select * from tbl_patient where id='" + tl_appoitment.Rows[0]["pt_id"].ToString() + "'");
                            if (pat.Rows.Count > 0)
                            {
                                string number = "91" + tl_appoitment.Rows[0]["mobile_no"].ToString();
                                string text = "Dear " + tl_appoitment.Rows[0]["pt_name"].ToString() + " " + ", Your appointment for " + tl_appoitment.Rows[0]["plan_new_procedure"].ToString() + " has been cancelled..  Regards " + toolStripButton1.Text + "," + contact_no;
                                a.SendSMS(smsName, smsPass, number, text);
                                this.cntrl.insert_sms(tl_appoitment.Rows[0]["pt_id"].ToString(), tl_appoitment.Rows[0]["pt_name"].ToString(), tl_appoitment.Rows[0]["plan_new_procedure"].ToString(), toolStripButton1.Text);//  db.execute("insert into tbl_pt_sms_communication (pt_id,send_datetime,type,message_status,message) values('" + tl_appoitment.Rows[0]["pt_id"].ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd hh:mm") + "','patient','sent','Dear " + tl_appoitment.Rows[0]["pt_name"].ToString() + " " + " Your appointment for " + tl_appoitment.Rows[0]["plan_new_procedure"].ToString() + " has been cancelled..  Regards " + toolStripButton1.Text + "')"); pt_id,  message,  pt_name,  procedure, doctor);
                            }
                        }
                    }
                    listAppointment("0"); 
                }
                wndCalendarControl.Populate();
                wndCalendarControl.RedrawControl();
            }
        }

        private void mnuCalendarChangeTimeZone_Click(object sender, System.EventArgs e)
        {
            //frmTimeZone = new frmTimeZone();
            //frmTimeZone.ShowDialog(this);
        }

        private void CalendarControl_DblClick(object sender, System.EventArgs e)
        {
            CalendarHitTestInfo HitTest;
            HitTest = wndCalendarControl.ActiveView.HitTest();
            CalendarEvents Events;
            if (HitTest.HitCode != CalendarHitTestCode.xtpCalendarHitTestUnknown)
            {
                Events = wndCalendarControl.DataProvider.RetrieveDayEvents(HitTest.ViewDay.Date);
            }
            if (HitTest.ViewEvent == null)
            {
                mnuContextNewEvent_Click(this, new System.EventArgs());
            }
            else
            {
                ContextEvent = HitTest.ViewEvent.Event;
                mnuContextEditEvent_Click(this, new System.EventArgs());
            }
        }

        private void wndCalendarControl_DblClick(object sender, EventArgs e)
        {
            CalendarHitTestInfo HitTest;
            HitTest = wndCalendarControl.ActiveView.HitTest();
            try
            {
                CalendarEvents Events;
                if (HitTest.HitCode != CalendarHitTestCode.xtpCalendarHitTestUnknown)
                {
                    Events = wndCalendarControl.DataProvider.RetrieveDayEvents(HitTest.ViewDay.Date);
                }
                if (HitTest.ViewEvent == null)
                {
                    if (APTAdd == true)
                    {

                        DateTime curr_Date_Time = DateTime.Now;
                           DateTime cal_Date_Time = Convert.ToDateTime(HitTest.HitDateTime.ToString());
                        if (cal_Date_Time < curr_Date_Time)
                        {
                            MessageBox.Show("Appointment Date should be greater than Current Date...", "Appointment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            mnuContextNewEvent_Click(this, new System.EventArgs());
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is No Privilege to Add Appointment..", "Security Role", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    ContextEvent = HitTest.ViewEvent.Event;
                    mnuContextEditEvent_Click(this, new System.EventArgs());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wndCalendarControl_ViewChanged(object sender, EventArgs e)
        {
            UpdateDateLabel();
            CheckViewItems();
        }

        private void labmonth_Click(object sender, EventArgs e)
        {
            mnuCalendarMonthView_Click(this, new System.EventArgs());
        }

        private void labweek_Click(object sender, EventArgs e)
        {
            //mnuCalendarWorkWeekView_Click(this, new System.EventArgs());
            mnuCalendarWeekView_Click(this, new System.EventArgs());
        }

        private void labday_Click(object sender, EventArgs e)
        {
            mnuCalendarDayView_Click(this, new System.EventArgs());
        }

        private void lblDate_Click(object sender, EventArgs e)
        {
            mnuDatePicker_Click(this, new System.EventArgs());
        }

        private void wndCalendarControl_MouseDownEvent(object sender, AxXtremeCalendarControl._DCalendarControlEvents_MouseDownEvent e)
        {
            panel4.Visible = false;
            if (e.button == 2)
            {
                CalendarHitTestInfo HitTest;
                HitTest = wndCalendarControl.ActiveView.HitTest();
                Point MousePosition;
                MousePosition = new Point(e.x + wndCalendarControl.Left, e.y + wndCalendarControl.Top);
                if (HitTest.ViewEvent != null)
                {
                    System.Diagnostics.Debug.WriteLine("Right-Clicked On: " + HitTest.ViewEvent.Event.Subject);
                    ContextEvent = HitTest.ViewEvent.Event;
                    //contextMenu.MenuItems[0].Visible = false;
                    //contextMenu.Show(this, MousePosition);
                    //contextMenu.MenuItems[0].Visible = true;
                }
                else if (HitTest.HitCode == CalendarHitTestCode.xtpCalendarHitTestDayViewTimeScale)
                {
                    ContextMenu ContextPopup = new ContextMenu(new MenuItem[] { this.mnuChangeTimeScalePopup.CloneMenu() });
                    ContextPopup.Show(this, MousePosition);
                }
                else if (HitTest.HitCode != CalendarHitTestCode.xtpCalendarHitTestUnknown)
                {
                    //contextMenu.MenuItems[1].Visible = false;
                    //contextMenu.MenuItems[2].Visible = false;
                    //contextMenu.Show(this, MousePosition);
                    //contextMenu.MenuItems[1].Visible = true;
                    //contextMenu.MenuItems[2].Visible = true;
                }
            }
            else
            {
            }
        }
        string pati_id = "";
        private void wndCalendarControl_MouseMoveEvent(object sender, AxXtremeCalendarControl._DCalendarControlEvents_MouseMoveEvent e)
        {
            CalendarHitTestInfo HitTest;
            HitTest = wndCalendarControl.ActiveView.HitTest();
            System.Diagnostics.Debug.WriteLine("X: " + e.x + " Y: " + e.y);
            if (HitTest.ViewEvent != null)
            {
                if (panel4.Visible == false || value1 != HitTest.ViewEvent.Event.Subject)
                {
                    // start previlages
                    if (doctor_id == "1")
                    {
                        if (HitTest.ViewEvent.Event.Body == "")// Tool Tip Error
                        {
                            return;
                        }
                        panel4.Location = new Point(e.x + wndCalendarControl.Left, e.y + wndCalendarControl.Top);
                        panel4.Visible = true;
                        value1 = HitTest.ViewEvent.Event.Subject;
                        ContextEvent = HitTest.ViewEvent.Event; //Bijeesh
                        DataTable dt = this.cntrl.get_appointment_details(HitTest.ViewEvent.Event.Body);// db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,booked_by,plan_new_procedure,note FROM tbl_appointment where id=" + HitTest.ViewEvent.Event.Body + " ORDER BY id");
                        if (dt.Rows.Count > 0)
                        {
                            pat_idForEdit = dt.Rows[0][3].ToString();
                            lab_p_name.Text = dt.Rows[0][4].ToString();
                            DateTime dtstart = new DateTime(DateTime.Now.Ticks);
                            dtstart = Convert.ToDateTime(dt.Rows[0][1].ToString());
                            lab_p_app_time.Text = dtstart.ToString("t") + " On " + dtstart.ToString("dd MMMM") + " for " + dt.Rows[0][2].ToString() + " mins";
                            label11.Text = "Booked By : " + dt.Rows[0]["booked_by"].ToString();
                            if (dt.Rows[0]["plan_new_procedure"].ToString() != "")
                            {
                                lblprocedure.Text = "Procedure : " + dt.Rows[0]["plan_new_procedure"].ToString();
                            }
                            else
                            {
                                lblprocedure.Text = "";
                            }
                            if (dt.Rows[0]["note"].ToString() != "")
                            {
                                lblnote.Text = "Notes : " + dt.Rows[0]["note"].ToString();
                            }
                            else
                            {
                                lblnote.Text = "";
                            }
                            DataTable pt = this.cntrl.patient_details(dt.Rows[0][3].ToString());// db.table("SELECT pt_id,primary_mobile_number FROM tbl_patient where id=" + dt.Rows[0][3].ToString() + " ORDER BY id");
                            if (pt.Rows.Count > 0)
                            {
                                lab_p_add.Text = "Patient ID: " + pt.Rows[0][0].ToString() + "\r\nMobile  No: " + pt.Rows[0][1].ToString();
                                pati_id = dt.Rows[0][3].ToString();
                            }
                            else
                            {
                                lab_p_add.Text = "";
                            }
                            string drt = this.cntrl.Get_DoctorName(dt.Rows[0][5].ToString());// db.table("SELECT doctor_name FROM tbl_doctor where id=" + dt.Rows[0][5].ToString() + " ORDER BY id");
                            if (drt!="")
                            {
                                lab_dr_name.Text = "With Dr." + drt;
                            }
                        }
                    }
                    else
                    {
                        if (HitTest.ViewEvent.Event.Body == "")// Tool Tip Error
                        {
                            return;
                        }
                        panel4.Location = new Point(e.x + wndCalendarControl.Left, e.y + wndCalendarControl.Top);
                        panel4.Visible = true;
                        value1 = HitTest.ViewEvent.Event.Subject;
                        ContextEvent = HitTest.ViewEvent.Event; //Bijeesh
                        //DataTable dt = db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,booked_by,plan_new_procedure,note FROM tbl_appointment where id=" + HitTest.ViewEvent.Event.Body + " AND dr_id=" + doctor_id + " ORDER BY id");
                          DataTable dt = this.cntrl.get_appointment_details(HitTest.ViewEvent.Event.Body);// db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id,booked_by,plan_new_procedure,note FROM tbl_appointment where id=" + HitTest.ViewEvent.Event.Body + " ORDER BY id");

                        if (dt.Rows.Count > 0)
                        {
                            pat_idForEdit = dt.Rows[0][3].ToString();
                            lab_p_name.Text = dt.Rows[0][4].ToString();
                            DateTime dtstart = new DateTime(DateTime.Now.Ticks);
                            dtstart = Convert.ToDateTime(dt.Rows[0][1].ToString());
                            lab_p_app_time.Text = dtstart.ToString("t") + " On " + dtstart.ToString("dd MMMM") + " for " + dt.Rows[0][2].ToString() + " mins";
                            label11.Text = "Booked By : " + dt.Rows[0]["booked_by"].ToString();
                            if (dt.Rows[0]["plan_new_procedure"].ToString() != "")
                            {
                                lblprocedure.Text = "Procedure : " + dt.Rows[0]["plan_new_procedure"].ToString();
                            }
                            else
                            {
                                lblprocedure.Text = "";
                            }
                            if (dt.Rows[0]["note"].ToString() != "")
                            {
                                lblnote.Text = "Notes : " + dt.Rows[0]["note"].ToString();
                            }
                            else
                            {
                                lblnote.Text = "";
                            }
                            DataTable pt = this.cntrl.patient_details(dt.Rows[0][3].ToString());// db.table("SELECT pt_id,primary_mobile_number FROM tbl_patient where id=" + dt.Rows[0][3].ToString() + " ORDER BY id");
                            if (pt.Rows.Count > 0)
                            {
                                lab_p_add.Text = "Patient ID: " + pt.Rows[0][0].ToString() + "\r\nMobile  No: " + pt.Rows[0][1].ToString();
                                pati_id = dt.Rows[0][3].ToString();
                            }
                            else
                            {
                                lab_p_add.Text = "";
                            }
                            string drt = this.cntrl.Get_DoctorName(dt.Rows[0][5].ToString());// db.table("SELECT doctor_name FROM tbl_doctor where id=" + dt.Rows[0][5].ToString() + " ORDER BY id");
                            if (drt!="")
                            {
                                lab_dr_name.Text = "With Dr." + drt;
                            }
                        }
                    }
                }
            }
            else
            {
                panel4.Visible = false;
            }

        }

        private void lab_p_add_MouseLeave(object sender, EventArgs e)
        {
            lab_p_add.ForeColor = Color.FromArgb(0, 102, 204);
            lab_p_name.ForeColor = Color.FromArgb(0, 102, 204);
        }

        private void lab_p_add_MouseEnter(object sender, EventArgs e)
        {
            lab_p_add.ForeColor = Color.FromArgb(5, 32, 59);
            lab_p_name.ForeColor = Color.FromArgb(5, 32, 59);
        }

        private void lab_p_name_Click(object sender, EventArgs e)
        {
            if (pati_id != "")
            {
                MessageBox.Show("Please wait..... Connecting Patient Records...!", " Please Wait...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string id1 = pati_id;
                var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
                form2.doctor_id = doctor_id;
                form2.patient_id = id1.ToString();
                form2.Show();
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
            }
        }

        private void lab_p_add_Click(object sender, EventArgs e)
        {
            if (pati_id != "")
            {
                MessageBox.Show("Please wait..... Connecting Patient Records...!", "Please Wait...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string id1 = pati_id;
                var form2 = new PappyjoeMVC.View.Patient_Profile_Details();
                form2.doctor_id = doctor_id;
                form2.patient_id = id1.ToString();
                form2.Show();
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mnuContextEditEvent_Click(this, new System.EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mnuContextDeleteEvent_Click(this, new System.EventArgs());
            panel4.Hide();
        }

        private void dataGridViewdoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (doctor_id == "1")
            {

                if (dataGridViewdoctor.RowCount > 0)
                {
                    wndCalendarControl.DataProvider.RemoveAllEvents();
                    CalendarDataProvider pCalendarData = wndCalendarControl.DataProvider;
                    DateTime dtNow = new DateTime(DateTime.Now.Ticks);
                    CalendarEvent ptrEvent = pCalendarData.CreateEvent();
                    int mints;
                    listAppointment(dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    DataTable dt = this.cntrl.get_dctr_wise_appointment(dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString());// db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment where dr_id=" + dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString() + " ORDER BY id");
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ptrEvent.StartTime = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                        dtNow = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                        mints = Convert.ToInt32(dt.Rows[j]["duration"].ToString());
                        ptrEvent.EndTime = dtNow.AddMinutes(mints);
                        ptrEvent.Subject = dt.Rows[j]["pt_name"].ToString();
                        ptrEvent.Location = dtNow.ToString("t") + "-" + dtNow.AddMinutes(mints).ToString("t");
                        ptrEvent.BusyStatus = CalendarEventBusyStatus.xtpCalendarBusyStatusBusy;
                        string drt = this.cntrl.get_calendar_color(dt.Rows[j]["dr_id"].ToString());// db.table("SELECT calendar_color FROM tbl_doctor where id=" + dt.Rows[j]["dr_id"].ToString() + " ORDER BY id");
                        if (drt!="")
                        {
                            ptrEvent.Label = Convert.ToInt32(drt);
                        }
                        else
                        {
                            ptrEvent.Label = 0;
                        }
                        ptrEvent.Body = dt.Rows[j]["id"].ToString();
                        pCalendarData.AddEvent(ptrEvent);
                    }
                    pCalendarData.Save();
                    wndCalendarControl.Populate();
                }
            }
            else
            {

                if (dataGridViewdoctor.RowCount > 0)
                {
                    wndCalendarControl.DataProvider.RemoveAllEvents();
                    CalendarDataProvider pCalendarData = wndCalendarControl.DataProvider;
                    DateTime dtNow = new DateTime(DateTime.Now.Ticks);
                    CalendarEvent ptrEvent = pCalendarData.CreateEvent();
                    int mints;
                    listAppointment(dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString());
                    //DataTable dt = db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment where dr_id=" + doctor_id + " AND dr_id =" + doctor_id + " ORDER BY id");
                    DataTable dt = this.cntrl.get_dctr_wise_appointment(dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString());// db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment where dr_id=" + dataGridViewdoctor.Rows[dataGridViewdoctor.CurrentCell.RowIndex].Cells[2].Value.ToString() + " ORDER BY id");
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        ptrEvent.StartTime = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                        dtNow = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                        mints = Convert.ToInt32(dt.Rows[j]["duration"].ToString());
                        ptrEvent.EndTime = dtNow.AddMinutes(mints);
                        ptrEvent.Subject = dt.Rows[j]["pt_name"].ToString();
                        ptrEvent.Location = dtNow.ToString("t") + "-" + dtNow.AddMinutes(mints).ToString("t");
                        ptrEvent.BusyStatus = CalendarEventBusyStatus.xtpCalendarBusyStatusBusy;
                        string drt = this.cntrl.get_calendar_color(dt.Rows[j]["dr_id"].ToString());// db.table("SELECT calendar_color FROM tbl_doctor where id=" + dt.Rows[j]["dr_id"].ToString() + " ORDER BY id");
                        if (drt!="")
                        {
                            ptrEvent.Label = Convert.ToInt32(drt);
                        }
                        else
                        {
                            ptrEvent.Label = 0;
                        }
                        ptrEvent.Body = dt.Rows[j]["id"].ToString();
                        pCalendarData.AddEvent(ptrEvent);
                    }
                    pCalendarData.Save();
                    wndCalendarControl.Populate();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (doctor_id == "1")
            {

                wndCalendarControl.DataProvider.RemoveAllEvents();
                CalendarDataProvider pCalendarData = wndCalendarControl.DataProvider;
                DateTime dtNow = new DateTime(DateTime.Now.Ticks);
                CalendarEvent ptrEvent = pCalendarData.CreateEvent();
                int mints;
                listAppointment("0");
                DataTable dt = this.cntrl.all_dctr_appointment();// db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment ORDER BY id");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    ptrEvent.StartTime = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                    dtNow = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                    mints = Convert.ToInt32(dt.Rows[j]["duration"].ToString());
                    ptrEvent.EndTime = dtNow.AddMinutes(mints);
                    ptrEvent.Subject = dt.Rows[j]["pt_name"].ToString();
                    ptrEvent.Location = dtNow.ToString("t") + "-" + dtNow.AddMinutes(mints).ToString("t");
                    ptrEvent.BusyStatus = CalendarEventBusyStatus.xtpCalendarBusyStatusBusy;
                    string drt = this.cntrl.get_calendar_color(dt.Rows[j]["dr_id"].ToString());
                    if (drt!="")
                    {
                        ptrEvent.Label = Convert.ToInt32(drt);
                    }
                    else
                    {
                        ptrEvent.Label = 0;
                    }
                    ptrEvent.Body = dt.Rows[j]["id"].ToString();
                    pCalendarData.AddEvent(ptrEvent);
                }
                pCalendarData.Save();
                wndCalendarControl.Populate();
            }
            else
            {
                wndCalendarControl.DataProvider.RemoveAllEvents();
                CalendarDataProvider pCalendarData = wndCalendarControl.DataProvider;
                DateTime dtNow = new DateTime(DateTime.Now.Ticks);
                CalendarEvent ptrEvent = pCalendarData.CreateEvent();
                int mints;
                listAppointment("0");
                DataTable dt = this.cntrl.all_dctr_appointment(); //db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment ORDER BY id");
                //DataTable dt = db.table("SELECT id,start_datetime,duration,pt_id,pt_name,dr_id FROM tbl_appointment where status='scheduled' and dr_id="+doctor_id+" ORDER BY id");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    ptrEvent.StartTime = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                    dtNow = Convert.ToDateTime(dt.Rows[j]["start_datetime"].ToString());
                    mints = Convert.ToInt32(dt.Rows[j]["duration"].ToString());
                    ptrEvent.EndTime = dtNow.AddMinutes(mints);
                    ptrEvent.Subject = dt.Rows[j]["pt_name"].ToString();
                    ptrEvent.Location = dtNow.ToString("t") + "-" + dtNow.AddMinutes(mints).ToString("t");
                    ptrEvent.BusyStatus = CalendarEventBusyStatus.xtpCalendarBusyStatusBusy;
                    string drt = this.cntrl.get_calendar_color(dt.Rows[j]["dr_id"].ToString());
                    if (drt!="")
                    {
                        ptrEvent.Label = Convert.ToInt32(drt);
                    }
                    else
                    {
                        ptrEvent.Label = 0;
                    }
                    ptrEvent.Body = dt.Rows[j]["id"].ToString();
                    pCalendarData.AddEvent(ptrEvent);
                }
                pCalendarData.Save();
                wndCalendarControl.Populate();
            }
        }

        public void listAppointment(string doctor_id)//ASWINI
        {
            dataGridViewAppointment.RowCount = 0;
            dataGridViewAppointment.ColumnCount = 4;
            dataGridViewAppointment.ColumnHeadersVisible = false;
            dataGridViewAppointment.RowHeadersVisible = false;
            dataGridViewAppointment.Columns[0].Name = "";
            dataGridViewAppointment.Columns[0].Width = 0;
            dataGridViewAppointment.Columns[0].Visible = false;
            dataGridViewAppointment.Columns[1].Name = "Time";
            dataGridViewAppointment.Columns[1].Width = 40;
            dataGridViewAppointment.Columns[2].Name = "Patient Name";
            dataGridViewAppointment.Columns[2].Width = 100;
            dataGridViewAppointment.Columns[3].Name = "";
            dataGridViewAppointment.Columns[3].Width = 60;
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            dataGridViewAppointment.Columns.Add(img);
            dataGridViewAppointment.Columns[4].Width = 30;
            dataGridViewAppointment.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            DateTime dtNow = new DateTime(DateTime.Now.Ticks);
            DateTime startDateTime = Convert.ToDateTime(DateTime.Today.ToString("d") + " 00:01:00 AM");
            DateTime startDateTime1 = Convert.ToDateTime(DateTime.Today.ToString("d") + " 11:59:00 PM");
            DataTable dt_dr = new DataTable();// db.table(sqlstring); //string sqlstring = "";
            if (doctor_id.ToString() == "0")
            {
              dt_dr=  this.cntrl.admin_appointments(Convert.ToDateTime(startDateTime), Convert.ToDateTime(startDateTime1));// sqlstring = "SELECT id,pt_name,start_datetime,plan_New_procedure ,status,EHR_status FROM tbl_appointment where start_datetime between  '" + Convert.ToDateTime(startDateTime).ToString("yyyy-MM-dd HH:mm") + "' AND '" + Convert.ToDateTime(startDateTime1).ToString("yyyy-MM-dd HH:mm") + "' ORDER BY start_datetime";
            }
            else
            {
                dt_dr = this.cntrl.doctor_appointments(Convert.ToDateTime(startDateTime), Convert.ToDateTime(startDateTime1), doctor_id);// sqlstring = "SELECT id,pt_name,start_datetime,plan_New_procedure ,status,EHR_status FROM tbl_appointment where start_datetime between  '" + Convert.ToDateTime(startDateTime).ToString("yyyy-MM-dd HH:mm") + "' AND '" + Convert.ToDateTime(startDateTime1).ToString("yyyy-MM-dd HH:mm") + "' AND dr_id='" + doctor_id + "' ORDER BY start_datetime";
            }
            //DataTable dt_dr = db.table(sqlstring);
            dataGridViewAppointment.DefaultCellStyle.SelectionBackColor = Color.Empty;
            dataGridViewAppointment.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridViewAppointment.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            long long_scheduled = 0;
            long long_waiting = 0;
            long long_engage = 0;
            long long_checkout = 0;
            //MessageBox.Show(sqlstring.ToString());
            for (int j = 0; j < dt_dr.Rows.Count; j++)
            {
                dtNow = Convert.ToDateTime(dt_dr.Rows[j]["start_datetime"].ToString());
                dtNow.ToString("t");
                dataGridViewAppointment.RowTemplate.MinimumHeight = 30;
                dataGridViewAppointment.Rows.Add(dt_dr.Rows[j]["id"].ToString(), dtNow.ToString("t"), dt_dr.Rows[j]["pt_name"].ToString(), dt_dr.Rows[j]["status"].ToString());
                dataGridViewAppointment.Rows[j].Cells[3].Style.ForeColor = Color.White;
                if (dt_dr.Rows[j]["EHR_status"].ToString() == "YES")
                { dataGridViewAppointment.Rows[j].Cells[4].Value = PappyjoeMVC.Properties.Resources.appfilled; }
                else { dataGridViewAppointment.Rows[j].Cells[4].Value = PappyjoeMVC.Properties.Resources.appnotfilled; }

                if (dt_dr.Rows[j]["status"].ToString() == "scheduled")
                {
                    dataGridViewAppointment.Rows[j].Cells[3].Style.BackColor = Color.FromArgb(255, 69, 0);
                    dataGridViewAppointment.Rows[j].Cells[3].Value = "Check in";
                    long_scheduled += 1;
                }
                else if (dt_dr.Rows[j]["status"].ToString() == "Check in")
                {
                    dataGridViewAppointment.Rows[j].Cells[3].Style.BackColor = Color.FromArgb(34, 139, 34);
                    dataGridViewAppointment.Rows[j].Cells[3].Value = "Engage";
                    long_waiting += 1;
                }
                else if (dt_dr.Rows[j]["status"].ToString() == "Engage")
                {
                    dataGridViewAppointment.Rows[j].Cells[3].Style.BackColor = Color.FromArgb(0, 0, 255);
                    dataGridViewAppointment.Rows[j].Cells[3].Value = "Checked Out";
                    long_engage += 1;
                }
                else if (dt_dr.Rows[j]["status"].ToString() == "Checked Out")
                {
                    dataGridViewAppointment.Rows[j].Cells[3].Style.BackColor = Color.FromArgb(119, 119, 119); //Color.FromArgb(0, 0, 255);
                    dataGridViewAppointment.Rows[j].Cells[3].Value = " ";
                    long_checkout += 1;
                }
                else if (dt_dr.Rows[j]["status"].ToString() == "CANCELLED")
                {
                    dataGridViewAppointment.Rows[j].Cells[1].Style.ForeColor = Color.FromArgb(48, 48, 48);
                    dataGridViewAppointment.Rows[j].Cells[2].Style.ForeColor = Color.FromArgb(48, 48, 48);
                    dataGridViewAppointment.Rows[j].Cells[3].Style.BackColor = Color.FromArgb(48, 48, 48);
                    dataGridViewAppointment.Rows[j].Cells[3].Style.ForeColor = Color.FromArgb(255, 255, 255);
                    dataGridViewAppointment.Rows[j].Cells[3].Value = "Cancelled";
                    long_checkout += 1;
                }
            }
            label7.Text = long_scheduled.ToString();
            label8.Text = long_waiting.ToString();
            label9.Text = long_engage.ToString();
            label10.Text = long_checkout.ToString();
        }

        private void dataGridViewAppointment_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void wndCalendarControl_EventChanged(object sender, AxXtremeCalendarControl._DCalendarControlEvents_EventChangedEvent e)
        {
            CalendarHitTestInfo HitTest;
            HitTest = wndCalendarControl.ActiveView.HitTest();
            try
            {
                DateTime StartTime, EndTime;
                StartTime = Convert.ToDateTime(HitTest.ViewEvent.Event.StartTime.ToString("t"));
                EndTime = Convert.ToDateTime(HitTest.ViewEvent.Event.EndTime.ToString("t"));
                var diff = EndTime.Subtract(StartTime);
                var totalTime = (Convert.ToInt64(diff.Hours) * 60) + Convert.ToInt64(diff.Minutes);
                DateTime curr_Date_Time = DateTime.Now;
                DateTime cal_Date_Time = Convert.ToDateTime(HitTest.ViewEvent.Event.StartTime.ToString());
                if (cal_Date_Time < curr_Date_Time)
                {
                    AddTestEvents(true);
                }
                else
                {
                    HitTest.ViewEvent.Event.Location = Convert.ToDateTime(HitTest.ViewEvent.Event.StartTime.ToString("t")) + "-" + Convert.ToDateTime(HitTest.ViewEvent.Event.EndTime.ToString("t"));
                     this.cntrl.update_appointment_statrdatetime(HitTest.ViewEvent.Event.StartTime.ToString(), totalTime.ToString(), HitTest.ViewEvent.Event.Body);// db.execute("update tbl_appointment set start_datetime='" + Convert.ToDateTime(HitTest.ViewEvent.Event.StartTime.ToString()).ToString("yyyy-MM-dd HH:mm") + "',duration='" + totalTime + "' where id='" + HitTest.ViewEvent.Event.Body + "'");
                    listAppointment("0");
                }
                //HitTest.ViewEvent.Event.Location = Convert.ToDateTime(HitTest.ViewEvent.Event.StartTime.ToString("t")) + "-" + Convert.ToDateTime(HitTest.ViewEvent.Event.EndTime.ToString("t"));
                //int j = db.execute("update tbl_appointment set start_datetime='" + HitTest.ViewEvent.Event.StartTime.ToString() + "',duration='" + totalTime + "' where id='" + HitTest.ViewEvent.Event.Body + "'");
                //listAppointment("0");
            }
            catch { }
        }

        private void dataGridViewAppointment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            long long_sub = 0;
            long long_add = 0;
            if (dataGridViewAppointment.RowCount > 0)
            {

                if (e.ColumnIndex == 3)
                {
                    if (dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Value.ToString() == "Check in")
                    {
                        DateTime Timeonly = DateTime.Now;
                        dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.FromArgb(34, 139, 34);
                        dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Value = "Engage";
                         this.cntrl.update_appointment_status_checkin(Convert.ToString(Timeonly.ToString("hh:mm tt")), dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[0].Value.ToString());// db.execute("update tbl_appointment set status='Check in',schedule='" + Convert.ToString(Timeonly.ToString("hh:mm tt")) + "',waiting='" + Convert.ToString(Timeonly.ToString("hh:mm tt")) + "' where id='" + dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
                        combodoctors.Focus();
                        long_sub = Convert.ToInt64(label7.Text);
                        long_add = Convert.ToInt64(label8.Text);
                        label7.Text = Convert.ToString(long_sub - 1);
                        label8.Text = Convert.ToString(long_add + 1);
                    }
                    else if (dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Value.ToString() == "Engage")
                    {
                        DateTime Timeonly = DateTime.Now;
                        dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.FromArgb(0, 0, 255);
                        dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Value = "Check Out";
                        this.cntrl.update_appointment_status_engaged(Convert.ToString(Timeonly.ToString("hh:mm tt")), dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[0].Value.ToString());// int j = db.execute("update tbl_appointment set status='Engage',engaged='" + Convert.ToString(Timeonly.ToString("hh:mm tt")) + "' where id='" + dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[0].Value.ToString() + "'");
                        long_sub = Convert.ToInt64(label8.Text);
                        long_add = Convert.ToInt64(label9.Text);
                        label8.Text = Convert.ToString(long_sub - 1);
                        label9.Text = Convert.ToString(long_add + 1);
                    }
                    else if (dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Value.ToString() == "Check Out")
                    {
                        DateTime Timeonly = DateTime.Now;
                        dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Style.BackColor = Color.FromArgb(0, 0, 255);
                        dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[3].Value = " ";
                        this.cntrl.update_appointment_status_checkout(Convert.ToString(Timeonly.ToString("hh:mm tt")), dataGridViewAppointment.Rows[dataGridViewAppointment.CurrentCell.RowIndex].Cells[0].Value.ToString());
                        long_sub = Convert.ToInt64(label9.Text);
                        long_add = Convert.ToInt64(label10.Text);
                        label9.Text = Convert.ToString(long_sub - 1);
                        label10.Text = Convert.ToString(long_add + 1);
                    }
                }
                // code written by reeba start for Vital sign Image
                else if (e.ColumnIndex == 4)
                {
                    if (dataGridViewAppointment.Rows[e.RowIndex].Cells[3].Value.ToString() == "Cancelled")
                    {
                        MessageBox.Show("You can't enter anything to this cancelled appointment.... ", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        string id1 = "";
                        var form2 = new SimpleAppointment();
                        form2.doctor_id = doctor_id;
                        id1 = dataGridViewAppointment.Rows[e.RowIndex].Cells[0].Value.ToString();
                        DataTable dtdr = this.cntrl.get_pat_for_simpleappoint(id1);
                        row_Val = e.RowIndex;
                        form2.patient_id = dtdr.Rows[0]["pt_id"].ToString();
                        form2.strApp_id = id1;
                        form2.Appointment_list += childForm_VitalSignChanged; 
                        form2.ShowDialog(this);
                    }
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var form2 = new Patients();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (doctor_id != "1")
            {
                string id = this.cntrl.inventory_privillage(doctor_id);
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

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var form2 = new Reports();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var form2 = new Communication();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (PappyjoeMVC.Model.Connection.MyGlobals.loginType != "staff")
            {
                var form2 = new PappyjoeMVC.View.Doctor_Profile();
                form2.doctor_id = doctor_id;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != "")
            {
                panel5.Location = new Point(1000, 32);
                DataTable dtdr = this.cntrl.Patient_search(toolStripTextBox1.Text);
                listpatientsearch.DataSource = dtdr;
                listpatientsearch.DisplayMember = "patient";
                listpatientsearch.ValueMember = "id";
                if (listpatientsearch.Items.Count == 0)
                {
                    panel5.Visible = false;
                }
                else
                {
                    panel5.Visible = true;
                }
                panel5.Location = new Point(toolStrip1.Width - 350,32);
            }
            else
            {
                panel5.Visible = false;
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
            form2.ShowDialog();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if (pat_idForEdit != "0")
            {
                var form2 = new Add_Clinical_Notes();
                //ClinicalNotesAdd_controller cnt = new ClinicalNotesAdd_controller(form2);
                form2.doctor_id = doctor_id;
                form2.patient_id = pat_idForEdit;
                //form2.ptid = pat_idForEdit;
                //clinic_flag = true;
                form2.caledr_edit_flag = true;
                form2.Closed += (sender1, args) => this.Close();
                this.Hide();
                form2.ShowDialog();

                //var form2 = new ClinicalNotes_Add();
                //form2.doctor_id = doctor_id;
                //form2.ptid = pat_idForEdit;
                //form2.Closed += (sender1, args) => this.Close();
                //this.Hide();
                //form2.show();
            }
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

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Login();
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }
        private void toolstripincomeandexpence_Click(object sender, EventArgs e)
        {

            var form2 = new Expense();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Process.Start("http://documentation.pappyjoe.com/");
        }

        private void BTn_Cancel_Click(object sender, EventArgs e)
        {
            mnuContextCancelEvent_Click(this, new System.EventArgs());
            panel4.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Main_Calendar();
            form2.doctor_id = doctor_id;
            form2.Closed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            var form2 = new Consultation();
            form2.doctor_id = doctor_id;
            form2.ShowDialog();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripBfatstrack_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            var form2 = new LabtrackingReport();
            form2.doctor_id = doctor_id;
            form2.FormClosed += (sender1, args) => this.Close();
            this.Hide();
            form2.ShowDialog();
        }

        void childForm_VitalSignChanged(string newVitalsign)
        {
            if (newVitalsign == "true")
            {
                dataGridViewAppointment.Rows[row_Val].Cells[4].Value = PappyjoeMVC.Properties.Resources.appfilled;
            }

        }
    }
}
