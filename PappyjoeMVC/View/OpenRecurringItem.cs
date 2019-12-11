using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PappyjoeMVC
{
	/// <summary>
	/// Summary description for OpenRecurringItem.
	/// </summary>
	public class OpenRecurringItem : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.Label lblInformation;
		private System.Windows.Forms.RadioButton optOpenThisOccurrence;
		private System.Windows.Forms.RadioButton optOpenTheSeries;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		static public OpenRecurringItem Instance;
		public int OpenRecurringItemAnswer = -1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OpenRecurringItem()
		{
			//
			// Required for Windows Form Designer support
			//
			Instance = this;
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		public void SetInformationLabel(String Subject)
		{
			if (Subject == "") 
			{
				lblInformation.Text =  @""" is a recurring appointment.  Do you want to open this occurrence or the series?";
			}
			else
			{
				lblInformation.Text =  "\"" + Subject + "\" is a recurring appointment.  Do you want to open this occurrence or the series?";
			}
		}

		public void SetForDelete(String Subject)
		{
			SetInformationLabel(Subject);

			lblInformation.Text = lblInformation.Text.Replace("open", "delete");
			lblInformation.Text = lblInformation.Text.Replace("Open", "Delete");

			optOpenThisOccurrence.Text = optOpenThisOccurrence.Text.Replace("open", "delete");
			optOpenThisOccurrence.Text = optOpenThisOccurrence.Text.Replace("Open", "Delete");

			optOpenTheSeries.Text = optOpenTheSeries.Text.Replace("open", "delete");
			optOpenTheSeries.Text = optOpenTheSeries.Text.Replace("Open", "Delete");
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInformation = new System.Windows.Forms.Label();
            this.optOpenThisOccurrence = new System.Windows.Forms.RadioButton();
            this.optOpenTheSeries = new System.Windows.Forms.RadioButton();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblInformation
            // 
            this.lblInformation.Location = new System.Drawing.Point(56, 8);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(224, 80);
            this.lblInformation.TabIndex = 1;
            this.lblInformation.Text = "\"\" is a recurring appointment.  Do you want to open this occurrence or the series" +
    "?";
            // 
            // optOpenThisOccurrence
            // 
            this.optOpenThisOccurrence.Checked = true;
            this.optOpenThisOccurrence.Location = new System.Drawing.Point(88, 96);
            this.optOpenThisOccurrence.Name = "optOpenThisOccurrence";
            this.optOpenThisOccurrence.Size = new System.Drawing.Size(168, 24);
            this.optOpenThisOccurrence.TabIndex = 2;
            this.optOpenThisOccurrence.TabStop = true;
            this.optOpenThisOccurrence.Text = "Open this occurrence.";
            // 
            // optOpenTheSeries
            // 
            this.optOpenTheSeries.Location = new System.Drawing.Point(88, 120);
            this.optOpenTheSeries.Name = "optOpenTheSeries";
            this.optOpenTheSeries.Size = new System.Drawing.Size(168, 24);
            this.optOpenTheSeries.TabIndex = 3;
            this.optOpenTheSeries.Text = "Open the series.";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(56, 168);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(152, 168);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // OpenRecurringItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 207);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.optOpenTheSeries);
            this.Controls.Add(this.optOpenThisOccurrence);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenRecurringItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Recurring Item";
            this.Load += new System.EventHandler(this.OpenRecurringItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			OpenRecurringItemAnswer = (optOpenThisOccurrence.Checked ? 1 : 2);
			this.Close();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			OpenRecurringItemAnswer = -1;
			this.Close();
		}

        private void OpenRecurringItem_Load(object sender, EventArgs e)
        {

        }
    }
}
