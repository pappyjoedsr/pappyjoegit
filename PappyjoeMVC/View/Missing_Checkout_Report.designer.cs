namespace PappyjoeMVC.View
{
    partial class Missing_Checkout_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Missing_Checkout_Report));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgvMissingCheckout = new System.Windows.Forms.DataGridView();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booked_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBoxdoctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerdailyappointcount1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerdailyappointcount2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_excel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingCheckout)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Lab_Msg);
            this.panel3.Controls.Add(this.dgvMissingCheckout);
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1176, 357);
            this.panel3.TabIndex = 114;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(274, 182);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // dgvMissingCheckout
            // 
            this.dgvMissingCheckout.AllowUserToAddRows = false;
            this.dgvMissingCheckout.AllowUserToOrderColumns = true;
            this.dgvMissingCheckout.AllowUserToResizeColumns = false;
            this.dgvMissingCheckout.AllowUserToResizeRows = false;
            this.dgvMissingCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMissingCheckout.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMissingCheckout.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMissingCheckout.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMissingCheckout.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMissingCheckout.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMissingCheckout.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMissingCheckout.ColumnHeadersHeight = 30;
            this.dgvMissingCheckout.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMissingCheckout.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_id,
            this.pt_name,
            this.book_datetime,
            this.start_datetime,
            this.duration,
            this.booked_by});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMissingCheckout.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMissingCheckout.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvMissingCheckout.Location = new System.Drawing.Point(0, 1);
            this.dgvMissingCheckout.MultiSelect = false;
            this.dgvMissingCheckout.Name = "dgvMissingCheckout";
            this.dgvMissingCheckout.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMissingCheckout.RowHeadersVisible = false;
            this.dgvMissingCheckout.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMissingCheckout.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMissingCheckout.Size = new System.Drawing.Size(1176, 357);
            this.dgvMissingCheckout.TabIndex = 107;
            // 
            // patient_id
            // 
            this.patient_id.DataPropertyName = "patient_id";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patient_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.patient_id.FillWeight = 66.49349F;
            this.patient_id.HeaderText = "ID";
            this.patient_id.Name = "patient_id";
            // 
            // pt_name
            // 
            this.pt_name.DataPropertyName = "pt_name";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pt_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.pt_name.FillWeight = 159.0594F;
            this.pt_name.HeaderText = "PATIENT NAME";
            this.pt_name.Name = "pt_name";
            // 
            // book_datetime
            // 
            this.book_datetime.DataPropertyName = "book_datetime";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.book_datetime.DefaultCellStyle = dataGridViewCellStyle4;
            this.book_datetime.FillWeight = 91.37056F;
            this.book_datetime.HeaderText = "BOOKED DATE";
            this.book_datetime.Name = "book_datetime";
            // 
            // start_datetime
            // 
            this.start_datetime.DataPropertyName = "start_datetime";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.start_datetime.DefaultCellStyle = dataGridViewCellStyle5;
            this.start_datetime.FillWeight = 117.6935F;
            this.start_datetime.HeaderText = "APPOINTMENT DATE";
            this.start_datetime.Name = "start_datetime";
            // 
            // duration
            // 
            this.duration.DataPropertyName = "duration";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.duration.DefaultCellStyle = dataGridViewCellStyle6;
            this.duration.FillWeight = 47.68956F;
            this.duration.HeaderText = "DURATION (MINS)";
            this.duration.Name = "duration";
            // 
            // booked_by
            // 
            this.booked_by.DataPropertyName = "booked_by";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.booked_by.DefaultCellStyle = dataGridViewCellStyle7;
            this.booked_by.FillWeight = 117.6935F;
            this.booked_by.HeaderText = "BOOKED BY";
            this.booked_by.Name = "booked_by";
            // 
            // comboBoxdoctor
            // 
            this.comboBoxdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdoctor.FormattingEnabled = true;
            this.comboBoxdoctor.Location = new System.Drawing.Point(1020, 19);
            this.comboBoxdoctor.Name = "comboBoxdoctor";
            this.comboBoxdoctor.Size = new System.Drawing.Size(149, 21);
            this.comboBoxdoctor.TabIndex = 128;
            this.comboBoxdoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxdoctor_SelectedIndexChanged);
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(926, 21);
            this.Lab_Doctor.Name = "Lab_Doctor";
            this.Lab_Doctor.Size = new System.Drawing.Size(90, 17);
            this.Lab_Doctor.TabIndex = 127;
            this.Lab_Doctor.Text = "Doctor Name:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.comboBoxdoctor);
            this.panel2.Controls.Add(this.Lab_Doctor);
            this.panel2.Controls.Add(this.cmbCondition);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dateTimePickerdailyappointcount1);
            this.panel2.Controls.Add(this.dateTimePickerdailyappointcount2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnselect);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbltotal);
            this.panel2.Location = new System.Drawing.Point(1, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1175, 52);
            this.panel2.TabIndex = 113;
            // 
            // cmbCondition
            // 
            this.cmbCondition.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.cmbCondition.FormattingEnabled = true;
            this.cmbCondition.Items.AddRange(new object[] {
            "Checked Out",
            "Missing"});
            this.cmbCondition.Location = new System.Drawing.Point(11, 19);
            this.cmbCondition.Name = "cmbCondition";
            this.cmbCondition.Size = new System.Drawing.Size(149, 21);
            this.cmbCondition.TabIndex = 101;
            this.cmbCondition.Text = "Checked Out";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(170, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 97;
            this.label1.Text = "From:";
            // 
            // dateTimePickerdailyappointcount1
            // 
            this.dateTimePickerdailyappointcount1.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount1.Location = new System.Drawing.Point(215, 18);
            this.dateTimePickerdailyappointcount1.Name = "dateTimePickerdailyappointcount1";
            this.dateTimePickerdailyappointcount1.Size = new System.Drawing.Size(198, 22);
            this.dateTimePickerdailyappointcount1.TabIndex = 95;
            // 
            // dateTimePickerdailyappointcount2
            // 
            this.dateTimePickerdailyappointcount2.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount2.Location = new System.Drawing.Point(446, 18);
            this.dateTimePickerdailyappointcount2.Name = "dateTimePickerdailyappointcount2";
            this.dateTimePickerdailyappointcount2.Size = new System.Drawing.Size(196, 22);
            this.dateTimePickerdailyappointcount2.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(417, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 98;
            this.label3.Text = "To:";
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(647, 18);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 104;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(866, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 94;
            this.label2.Text = "label2";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbltotal.Location = new System.Drawing.Point(732, 21);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(126, 17);
            this.lbltotal.TabIndex = 93;
            this.lbltotal.Text = "Total Appointment : ";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1086, 50);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 111;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_excel
            // 
            this.btn_excel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.ForeColor = System.Drawing.Color.White;
            this.btn_excel.Location = new System.Drawing.Point(889, 50);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(107, 30);
            this.btn_excel.TabIndex = 109;
            this.btn_excel.Text = "EXPORT TO EXCEL";
            this.btn_excel.UseVisualStyleBackColor = false;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_excel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1175, 85);
            this.panel1.TabIndex = 112;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(8, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(458, 45);
            this.label4.TabIndex = 108;
            this.label4.Text = "Missing And Checkout Reports";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(999, 50);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 106;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // Missing_Checkout_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 501);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Missing_Checkout_Report";
            this.Text = "Missing and Checkout Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Missing_Checkout_Report_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMissingCheckout)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgvMissingCheckout;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn booked_by;
        private System.Windows.Forms.ComboBox comboBoxdoctor;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmbCondition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailyappointcount1;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailyappointcount2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}