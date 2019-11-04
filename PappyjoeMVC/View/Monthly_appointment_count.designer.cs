namespace PappyjoeMVC.View
{
    partial class Monthly_Appointment_Count
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monthly_Appointment_Count));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Lab_Doctorname = new System.Windows.Forms.Label();
            this.Cmb_Doctor = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickermonthlyappoint1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.searchmonth = new System.Windows.Forms.Button();
            this.dateTimePickermonthlyappoint2 = new System.Windows.Forms.DateTimePicker();
            this.Lab_total = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewmonthlyappoinment = new System.Windows.Forms.DataGridView();
            this.sino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BOOKEDDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booked_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartmonthlyappointcount = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnchartview = new System.Windows.Forms.Button();
            this.btnDataview = new System.Windows.Forms.Button();
            this.Grvmonthlyappointcount = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_empty = new System.Windows.Forms.Label();
            this.label25.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewmonthlyappoinment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartmonthlyappointcount)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvmonthlyappointcount)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lab_Doctorname
            // 
            this.Lab_Doctorname.AutoSize = true;
            this.Lab_Doctorname.BackColor = System.Drawing.Color.Gainsboro;
            this.Lab_Doctorname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctorname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctorname.Location = new System.Drawing.Point(831, 18);
            this.Lab_Doctorname.Name = "Lab_Doctorname";
            this.Lab_Doctorname.Size = new System.Drawing.Size(87, 17);
            this.Lab_Doctorname.TabIndex = 109;
            this.Lab_Doctorname.Text = "Doctor Name";
            // 
            // Cmb_Doctor
            // 
            this.Cmb_Doctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Cmb_Doctor.FormattingEnabled = true;
            this.Cmb_Doctor.Location = new System.Drawing.Point(921, 16);
            this.Cmb_Doctor.Name = "Cmb_Doctor";
            this.Cmb_Doctor.Size = new System.Drawing.Size(147, 21);
            this.Cmb_Doctor.TabIndex = 108;
            this.Cmb_Doctor.SelectedIndexChanged += new System.EventHandler(this.Cmb_Doctor_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.Gainsboro;
            this.label25.Controls.Add(this.Lab_Doctorname);
            this.label25.Controls.Add(this.Cmb_Doctor);
            this.label25.Controls.Add(this.label1);
            this.label25.Controls.Add(this.dateTimePickermonthlyappoint1);
            this.label25.Controls.Add(this.label2);
            this.label25.Controls.Add(this.searchmonth);
            this.label25.Controls.Add(this.dateTimePickermonthlyappoint2);
            this.label25.Controls.Add(this.Lab_total);
            this.label25.Controls.Add(this.label3);
            this.label25.Location = new System.Drawing.Point(1, 89);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1360, 53);
            this.label25.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // dateTimePickermonthlyappoint1
            // 
            this.dateTimePickermonthlyappoint1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickermonthlyappoint1.Location = new System.Drawing.Point(62, 15);
            this.dateTimePickermonthlyappoint1.Name = "dateTimePickermonthlyappoint1";
            this.dateTimePickermonthlyappoint1.Size = new System.Drawing.Size(206, 22);
            this.dateTimePickermonthlyappoint1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(281, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // searchmonth
            // 
            this.searchmonth.BackColor = System.Drawing.Color.LimeGreen;
            this.searchmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchmonth.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchmonth.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.searchmonth.Location = new System.Drawing.Point(539, 15);
            this.searchmonth.Name = "searchmonth";
            this.searchmonth.Size = new System.Drawing.Size(75, 22);
            this.searchmonth.TabIndex = 107;
            this.searchmonth.Text = "Show";
            this.searchmonth.UseVisualStyleBackColor = false;
            this.searchmonth.Click += new System.EventHandler(this.searchmonth_Click);
            // 
            // dateTimePickermonthlyappoint2
            // 
            this.dateTimePickermonthlyappoint2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickermonthlyappoint2.Location = new System.Drawing.Point(315, 15);
            this.dateTimePickermonthlyappoint2.Name = "dateTimePickermonthlyappoint2";
            this.dateTimePickermonthlyappoint2.Size = new System.Drawing.Size(208, 22);
            this.dateTimePickermonthlyappoint2.TabIndex = 3;
            // 
            // Lab_total
            // 
            this.Lab_total.AutoSize = true;
            this.Lab_total.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_total.ForeColor = System.Drawing.Color.Red;
            this.Lab_total.Location = new System.Drawing.Point(774, 18);
            this.Lab_total.Name = "Lab_total";
            this.Lab_total.Size = new System.Drawing.Size(45, 17);
            this.Lab_total.TabIndex = 11;
            this.Lab_total.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(636, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Appointments: ";
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(272, 235);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(561, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lab_Msg.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dataGridViewmonthlyappoinment);
            this.panel2.Controls.Add(this.chartmonthlyappointcount);
            this.panel2.Location = new System.Drawing.Point(1, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 566);
            this.panel2.TabIndex = 113;
            // 
            // dataGridViewmonthlyappoinment
            // 
            this.dataGridViewmonthlyappoinment.AllowUserToAddRows = false;
            this.dataGridViewmonthlyappoinment.AllowUserToDeleteRows = false;
            this.dataGridViewmonthlyappoinment.AllowUserToResizeColumns = false;
            this.dataGridViewmonthlyappoinment.AllowUserToResizeRows = false;
            this.dataGridViewmonthlyappoinment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewmonthlyappoinment.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewmonthlyappoinment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewmonthlyappoinment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewmonthlyappoinment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewmonthlyappoinment.ColumnHeadersHeight = 28;
            this.dataGridViewmonthlyappoinment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewmonthlyappoinment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sino,
            this.ptid,
            this.pt_name,
            this.mobile_no,
            this.email_id,
            this.doctor_name,
            this.BOOKEDDATE,
            this.book_datetime,
            this.booked_by});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewmonthlyappoinment.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewmonthlyappoinment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewmonthlyappoinment.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewmonthlyappoinment.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewmonthlyappoinment.Name = "dataGridViewmonthlyappoinment";
            this.dataGridViewmonthlyappoinment.ReadOnly = true;
            this.dataGridViewmonthlyappoinment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewmonthlyappoinment.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewmonthlyappoinment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dataGridViewmonthlyappoinment.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewmonthlyappoinment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewmonthlyappoinment.Size = new System.Drawing.Size(1146, 566);
            this.dataGridViewmonthlyappoinment.TabIndex = 0;
            // 
            // sino
            // 
            this.sino.DataPropertyName = "Sino";
            this.sino.HeaderText = "SLNO";
            this.sino.Name = "sino";
            this.sino.ReadOnly = true;
            this.sino.Visible = false;
            // 
            // ptid
            // 
            this.ptid.DataPropertyName = "pt_id";
            this.ptid.HeaderText = "PATIENT ID";
            this.ptid.Name = "ptid";
            this.ptid.ReadOnly = true;
            // 
            // pt_name
            // 
            this.pt_name.DataPropertyName = "pt_name";
            this.pt_name.HeaderText = "PATIENT NAME";
            this.pt_name.Name = "pt_name";
            this.pt_name.ReadOnly = true;
            this.pt_name.Width = 200;
            // 
            // mobile_no
            // 
            this.mobile_no.DataPropertyName = "primary_mobile_number";
            this.mobile_no.HeaderText = "MOBILE";
            this.mobile_no.Name = "mobile_no";
            this.mobile_no.ReadOnly = true;
            this.mobile_no.Width = 120;
            // 
            // email_id
            // 
            this.email_id.DataPropertyName = "email_address";
            this.email_id.HeaderText = "EMAIL ID";
            this.email_id.Name = "email_id";
            this.email_id.ReadOnly = true;
            this.email_id.Width = 150;
            // 
            // doctor_name
            // 
            this.doctor_name.DataPropertyName = "doctor_name";
            this.doctor_name.HeaderText = "DOCTOR";
            this.doctor_name.Name = "doctor_name";
            this.doctor_name.ReadOnly = true;
            this.doctor_name.Width = 130;
            // 
            // BOOKEDDATE
            // 
            this.BOOKEDDATE.DataPropertyName = "book_datetime";
            this.BOOKEDDATE.HeaderText = "BOOKED DATE";
            this.BOOKEDDATE.Name = "BOOKEDDATE";
            this.BOOKEDDATE.ReadOnly = true;
            this.BOOKEDDATE.Width = 150;
            // 
            // book_datetime
            // 
            this.book_datetime.DataPropertyName = "start_datetime";
            this.book_datetime.HeaderText = "APPOINTMENT DATE";
            this.book_datetime.Name = "book_datetime";
            this.book_datetime.ReadOnly = true;
            this.book_datetime.Width = 150;
            // 
            // booked_by
            // 
            this.booked_by.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.booked_by.DataPropertyName = "booked_by";
            this.booked_by.HeaderText = "BOOKED BY";
            this.booked_by.Name = "booked_by";
            this.booked_by.ReadOnly = true;
            // 
            // chartmonthlyappointcount
            // 
            this.chartmonthlyappointcount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea3.Name = "ChartArea1";
            this.chartmonthlyappointcount.ChartAreas.Add(chartArea3);
            this.chartmonthlyappointcount.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartmonthlyappointcount.Legends.Add(legend3);
            this.chartmonthlyappointcount.Location = new System.Drawing.Point(0, 0);
            this.chartmonthlyappointcount.Name = "chartmonthlyappointcount";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Appointment (s)";
            this.chartmonthlyappointcount.Series.Add(series3);
            this.chartmonthlyappointcount.Size = new System.Drawing.Size(1146, 566);
            this.chartmonthlyappointcount.TabIndex = 7;
            this.chartmonthlyappointcount.Text = "chart1";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1057, 52);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 109;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Export.Location = new System.Drawing.Point(861, 52);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(109, 30);
            this.btn_Export.TabIndex = 108;
            this.btn_Export.Text = "EXPORT TO EXCEL";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(971, 52);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 9;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Export);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnchartview);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnDataview);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 86);
            this.panel1.TabIndex = 112;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(5, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(417, 40);
            this.label5.TabIndex = 106;
            this.label5.Text = "Monthly Appointments Reports";
            // 
            // btnchartview
            // 
            this.btnchartview.BackColor = System.Drawing.Color.LimeGreen;
            this.btnchartview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchartview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchartview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnchartview.Location = new System.Drawing.Point(689, 52);
            this.btnchartview.Name = "btnchartview";
            this.btnchartview.Size = new System.Drawing.Size(85, 30);
            this.btnchartview.TabIndex = 1;
            this.btnchartview.Text = "VIEW CHART";
            this.btnchartview.UseVisualStyleBackColor = false;
            this.btnchartview.Click += new System.EventHandler(this.btnchartview_Click);
            // 
            // btnDataview
            // 
            this.btnDataview.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDataview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDataview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDataview.Location = new System.Drawing.Point(775, 52);
            this.btnDataview.Name = "btnDataview";
            this.btnDataview.Size = new System.Drawing.Size(85, 30);
            this.btnDataview.TabIndex = 105;
            this.btnDataview.Text = "VIEWGRID";
            this.btnDataview.UseVisualStyleBackColor = false;
            this.btnDataview.Click += new System.EventHandler(this.btnDataview_Click);
            // 
            // Grvmonthlyappointcount
            // 
            this.Grvmonthlyappointcount.AllowUserToAddRows = false;
            this.Grvmonthlyappointcount.AllowUserToDeleteRows = false;
            this.Grvmonthlyappointcount.AllowUserToResizeColumns = false;
            this.Grvmonthlyappointcount.AllowUserToResizeRows = false;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            this.Grvmonthlyappointcount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle14;
            this.Grvmonthlyappointcount.BackgroundColor = System.Drawing.Color.White;
            this.Grvmonthlyappointcount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvmonthlyappointcount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvmonthlyappointcount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grvmonthlyappointcount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.Grvmonthlyappointcount.ColumnHeadersHeight = 28;
            this.Grvmonthlyappointcount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grvmonthlyappointcount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grvmonthlyappointcount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grvmonthlyappointcount.Location = new System.Drawing.Point(0, 0);
            this.Grvmonthlyappointcount.Name = "Grvmonthlyappointcount";
            this.Grvmonthlyappointcount.RowHeadersVisible = false;
            this.Grvmonthlyappointcount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvmonthlyappointcount.Size = new System.Drawing.Size(212, 566);
            this.Grvmonthlyappointcount.TabIndex = 0;
            this.Grvmonthlyappointcount.DataSourceChanged += new System.EventHandler(this.Grvmonthlyappointcount_DataSourceChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label_empty);
            this.panel3.Controls.Add(this.Grvmonthlyappointcount);
            this.panel3.Location = new System.Drawing.Point(1149, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 566);
            this.panel3.TabIndex = 115;
            // 
            // label_empty
            // 
            this.label_empty.AutoSize = true;
            this.label_empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_empty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_empty.Location = new System.Drawing.Point(319, 137);
            this.label_empty.Name = "label_empty";
            this.label_empty.Size = new System.Drawing.Size(111, 13);
            this.label_empty.TabIndex = 91;
            this.label_empty.Text = "No Records Found !";
            // 
            // Monthly_Appointment_Count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Monthly_Appointment_Count";
            this.Text = "Monthly Appointment Count";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Monthly_appointment_count_Load);
            this.label25.ResumeLayout(false);
            this.label25.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewmonthlyappoinment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartmonthlyappointcount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvmonthlyappointcount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Lab_Doctorname;
        private System.Windows.Forms.ComboBox Cmb_Doctor;
        private System.Windows.Forms.Panel label25;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickermonthlyappoint1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchmonth;
        private System.Windows.Forms.DateTimePicker dateTimePickermonthlyappoint2;
        private System.Windows.Forms.Label Lab_total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridViewmonthlyappoinment;
        private System.Windows.Forms.DataGridViewTextBoxColumn sino;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn BOOKEDDATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn booked_by;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartmonthlyappointcount;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnchartview;
        private System.Windows.Forms.Button btnDataview;
        private System.Windows.Forms.DataGridView Grvmonthlyappointcount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_empty;
    }
}