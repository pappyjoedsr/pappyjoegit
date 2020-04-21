using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using XtremeCalendarControl;

namespace PappyjoeMVC.View
{
	/// <summary>
	/// Summary description for frmDatePicker.
	/// </summary>
	public class DatePicker : System.Windows.Forms.Form
	{
		public AxXtremeCalendarControl.AxDatePicker Date_Picker;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		static public DatePicker Instance;

		public DatePicker()
		{
			//
			// Required for Windows Form Designer support
			//
			Instance = this;
			InitializeComponent();
			InitializeDatePicker();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
            
		private void InitializeDatePicker()
		{
			Date_Picker.FirstDayOfWeek = Main_Calendar.Instance.cmbFirstDayOfWeek.SelectedIndex + 1;
						
			XtremeCalendarControl.CalendarControl pCalendarOcx = 
				( (XtremeCalendarControl.CalendarControl)(Main_Calendar.Instance.wndCalendarControl.GetOcx()) );						
			
			Date_Picker.AttachToCalendar(pCalendarOcx);

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatePicker));
            this.Date_Picker = new AxXtremeCalendarControl.AxDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.Date_Picker)).BeginInit();
            this.SuspendLayout();
            // 
            // Date_Picker
            // 
            this.Date_Picker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date_Picker.Location = new System.Drawing.Point(0, 0);
            this.Date_Picker.Name = "Date_Picker";
            this.Date_Picker.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Date_Picker.OcxState")));
            this.Date_Picker.Size = new System.Drawing.Size(346, 322);
            this.Date_Picker.TabIndex = 0;
            // 
            // DatePicker
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(346, 322);
            this.Controls.Add(this.Date_Picker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DatePicker";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Picker";
            this.Closed += new System.EventHandler(this.frmDatePicker_Closed);
            this.Load += new System.EventHandler(this.DatePicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Date_Picker)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void frmDatePicker_Closed(object sender, System.EventArgs e)
		{
			if (Main_Calendar.Instance.mnuDatePicker.Checked == true) 
			{
                Main_Calendar.Instance.mnuDatePicker.Checked = false;
			}
            Main_Calendar.Instance.frmDatePicker = null;
		}

        private void DatePicker_Load(object sender, EventArgs e)
        {

        }
    }
}
