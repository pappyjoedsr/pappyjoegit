namespace PappyjoeMVC.View
{
    partial class Daily_Appointment_Count
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daily_Appointment_Count));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dataGridViewDailyappoinment = new System.Windows.Forms.DataGridView();
            this.sino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booked_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartdailyappointcount = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxdoctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePickerdailyappointcount2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerdailyappointcount1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.serchdaily = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lAB_TOTAL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Grvdailyappointcount = new System.Windows.Forms.DataGridView();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_ExporttoExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnHidedatalist = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnViewdatalist = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDailyappoinment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdailyappointcount)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvdailyappointcount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Lab_Msg);
            this.panel4.Controls.Add(this.dataGridViewDailyappoinment);
            this.panel4.Controls.Add(this.chartdailyappointcount);
            this.panel4.Location = new System.Drawing.Point(2, 153);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1107, 508);
            this.panel4.TabIndex = 102;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(196, 240);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(563, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lab_Msg.Visible = false;
            // 
            // dataGridViewDailyappoinment
            // 
            this.dataGridViewDailyappoinment.AllowUserToAddRows = false;
            this.dataGridViewDailyappoinment.AllowUserToDeleteRows = false;
            this.dataGridViewDailyappoinment.AllowUserToResizeColumns = false;
            this.dataGridViewDailyappoinment.AllowUserToResizeRows = false;
            this.dataGridViewDailyappoinment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDailyappoinment.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewDailyappoinment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewDailyappoinment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewDailyappoinment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDailyappoinment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDailyappoinment.ColumnHeadersHeight = 28;
            this.dataGridViewDailyappoinment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewDailyappoinment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sino,
            this.patientid,
            this.pt_name,
            this.doctors,
            this.mobile_no,
            this.email_id,
            this.book_datetime,
            this.booked_by});
            this.dataGridViewDailyappoinment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDailyappoinment.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewDailyappoinment.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDailyappoinment.Name = "dataGridViewDailyappoinment";
            this.dataGridViewDailyappoinment.ReadOnly = true;
            this.dataGridViewDailyappoinment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewDailyappoinment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewDailyappoinment.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDailyappoinment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDailyappoinment.Size = new System.Drawing.Size(1107, 508);
            this.dataGridViewDailyappoinment.TabIndex = 0;
            // 
            // sino
            // 
            this.sino.DataPropertyName = "Sino";
            this.sino.HeaderText = "Sl No";
            this.sino.Name = "sino";
            this.sino.ReadOnly = true;
            this.sino.Visible = false;
            // 
            // patientid
            // 
            this.patientid.DataPropertyName = "pt_id";
            this.patientid.HeaderText = "PATIENT ID";
            this.patientid.Name = "patientid";
            this.patientid.ReadOnly = true;
            // 
            // pt_name
            // 
            this.pt_name.DataPropertyName = "pt_name";
            this.pt_name.HeaderText = "PATIENT NAME";
            this.pt_name.Name = "pt_name";
            this.pt_name.ReadOnly = true;
            // 
            // doctors
            // 
            this.doctors.DataPropertyName = "doctor_name";
            this.doctors.HeaderText = "DOCTOR";
            this.doctors.Name = "doctors";
            this.doctors.ReadOnly = true;
            // 
            // mobile_no
            // 
            this.mobile_no.DataPropertyName = "primary_mobile_number";
            this.mobile_no.HeaderText = "MOBILE ";
            this.mobile_no.Name = "mobile_no";
            this.mobile_no.ReadOnly = true;
            // 
            // email_id
            // 
            this.email_id.DataPropertyName = "email_address";
            this.email_id.HeaderText = "EMAIL ID";
            this.email_id.Name = "email_id";
            this.email_id.ReadOnly = true;
            // 
            // book_datetime
            // 
            this.book_datetime.DataPropertyName = "book_datetime";
            this.book_datetime.HeaderText = "APPOINTMENT DATE";
            this.book_datetime.Name = "book_datetime";
            this.book_datetime.ReadOnly = true;
            // 
            // booked_by
            // 
            this.booked_by.DataPropertyName = "booked_by";
            this.booked_by.HeaderText = "BOOKED BY";
            this.booked_by.Name = "booked_by";
            this.booked_by.ReadOnly = true;
            // 
            // chartdailyappointcount
            // 
            this.chartdailyappointcount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chartdailyappointcount.ChartAreas.Add(chartArea1);
            this.chartdailyappointcount.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartdailyappointcount.Legends.Add(legend1);
            this.chartdailyappointcount.Location = new System.Drawing.Point(0, 0);
            this.chartdailyappointcount.Name = "chartdailyappointcount";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Appointment (s)";
            this.chartdailyappointcount.Series.Add(series1);
            this.chartdailyappointcount.Size = new System.Drawing.Size(1107, 508);
            this.chartdailyappointcount.TabIndex = 9;
            this.chartdailyappointcount.Text = "chart1";
            // 
            // comboBoxdoctor
            // 
            this.comboBoxdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdoctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.comboBoxdoctor.FormattingEnabled = true;
            this.comboBoxdoctor.Location = new System.Drawing.Point(946, 17);
            this.comboBoxdoctor.Name = "comboBoxdoctor";
            this.comboBoxdoctor.Size = new System.Drawing.Size(149, 21);
            this.comboBoxdoctor.TabIndex = 97;
            this.comboBoxdoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxdoctor_SelectedIndexChanged);
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(839, 19);
            this.Lab_Doctor.Name = "Lab_Doctor";
            this.Lab_Doctor.Size = new System.Drawing.Size(92, 17);
            this.Lab_Doctor.TabIndex = 96;
            this.Lab_Doctor.Text = "Doctor Name:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.comboBoxdoctor);
            this.panel3.Controls.Add(this.Lab_Doctor);
            this.panel3.Controls.Add(this.dateTimePickerdailyappointcount2);
            this.panel3.Controls.Add(this.dateTimePickerdailyappointcount1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.serchdaily);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.lbltotal);
            this.panel3.Controls.Add(this.lAB_TOTAL);
            this.panel3.Location = new System.Drawing.Point(2, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1356, 58);
            this.panel3.TabIndex = 101;
            // 
            // dateTimePickerdailyappointcount2
            // 
            this.dateTimePickerdailyappointcount2.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount2.Location = new System.Drawing.Point(315, 16);
            this.dateTimePickerdailyappointcount2.Name = "dateTimePickerdailyappointcount2";
            this.dateTimePickerdailyappointcount2.Size = new System.Drawing.Size(197, 22);
            this.dateTimePickerdailyappointcount2.TabIndex = 4;
            // 
            // dateTimePickerdailyappointcount1
            // 
            this.dateTimePickerdailyappointcount1.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount1.Location = new System.Drawing.Point(53, 16);
            this.dateTimePickerdailyappointcount1.Name = "dateTimePickerdailyappointcount1";
            this.dateTimePickerdailyappointcount1.Size = new System.Drawing.Size(201, 22);
            this.dateTimePickerdailyappointcount1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "From:";
            // 
            // serchdaily
            // 
            this.serchdaily.BackColor = System.Drawing.Color.LimeGreen;
            this.serchdaily.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serchdaily.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serchdaily.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.serchdaily.Location = new System.Drawing.Point(530, 16);
            this.serchdaily.Name = "serchdaily";
            this.serchdaily.Size = new System.Drawing.Size(75, 23);
            this.serchdaily.TabIndex = 94;
            this.serchdaily.Text = "Show";
            this.serchdaily.UseVisualStyleBackColor = false;
            this.serchdaily.Click += new System.EventHandler(this.serchdaily_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(279, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "To:";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbltotal.Location = new System.Drawing.Point(636, 19);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(133, 17);
            this.lbltotal.TabIndex = 1;
            this.lbltotal.Text = "Total Appointment : ";
            // 
            // lAB_TOTAL
            // 
            this.lAB_TOTAL.AutoSize = true;
            this.lAB_TOTAL.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAB_TOTAL.ForeColor = System.Drawing.Color.Red;
            this.lAB_TOTAL.Location = new System.Drawing.Point(773, 19);
            this.lAB_TOTAL.Name = "lAB_TOTAL";
            this.lAB_TOTAL.Size = new System.Drawing.Size(45, 17);
            this.lAB_TOTAL.TabIndex = 2;
            this.lAB_TOTAL.Text = "label2";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Grvdailyappointcount);
            this.panel2.Location = new System.Drawing.Point(1115, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 506);
            this.panel2.TabIndex = 100;
            // 
            // Grvdailyappointcount
            // 
            this.Grvdailyappointcount.AllowUserToDeleteRows = false;
            this.Grvdailyappointcount.AllowUserToResizeColumns = false;
            this.Grvdailyappointcount.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Grvdailyappointcount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grvdailyappointcount.BackgroundColor = System.Drawing.Color.White;
            this.Grvdailyappointcount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvdailyappointcount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvdailyappointcount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grvdailyappointcount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Grvdailyappointcount.ColumnHeadersHeight = 28;
            this.Grvdailyappointcount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grvdailyappointcount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grvdailyappointcount.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grvdailyappointcount.Location = new System.Drawing.Point(0, 0);
            this.Grvdailyappointcount.Name = "Grvdailyappointcount";
            this.Grvdailyappointcount.RowHeadersVisible = false;
            this.Grvdailyappointcount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvdailyappointcount.Size = new System.Drawing.Size(246, 506);
            this.Grvdailyappointcount.TabIndex = 0;
            this.Grvdailyappointcount.DataSourceChanged += new System.EventHandler(this.Grvdailyappointcount_DataSourceChanged);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1065, 55);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 111;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_ExporttoExcel
            // 
            this.btn_ExporttoExcel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_ExporttoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ExporttoExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ExporttoExcel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ExporttoExcel.Location = new System.Drawing.Point(872, 55);
            this.btn_ExporttoExcel.Name = "btn_ExporttoExcel";
            this.btn_ExporttoExcel.Size = new System.Drawing.Size(107, 30);
            this.btn_ExporttoExcel.TabIndex = 94;
            this.btn_ExporttoExcel.Text = "EXPORT TO EXCEL";
            this.btn_ExporttoExcel.UseVisualStyleBackColor = false;
            this.btn_ExporttoExcel.Click += new System.EventHandler(this.btn_ExporttoExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_ExporttoExcel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnHidedatalist);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnViewdatalist);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 89);
            this.panel1.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(362, 40);
            this.label4.TabIndex = 93;
            this.label4.Text = "Daily Appointment Reports";
            // 
            // btnHidedatalist
            // 
            this.btnHidedatalist.BackColor = System.Drawing.Color.LimeGreen;
            this.btnHidedatalist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHidedatalist.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHidedatalist.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHidedatalist.Location = new System.Drawing.Point(702, 55);
            this.btnHidedatalist.Name = "btnHidedatalist";
            this.btnHidedatalist.Size = new System.Drawing.Size(85, 30);
            this.btnHidedatalist.TabIndex = 2;
            this.btnHidedatalist.Text = "VIEW CHART";
            this.btnHidedatalist.UseVisualStyleBackColor = false;
            this.btnHidedatalist.Click += new System.EventHandler(this.btnHidedatalist_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(979, 55);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 11;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnViewdatalist
            // 
            this.btnViewdatalist.BackColor = System.Drawing.Color.LimeGreen;
            this.btnViewdatalist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewdatalist.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewdatalist.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnViewdatalist.Location = new System.Drawing.Point(787, 55);
            this.btnViewdatalist.Name = "btnViewdatalist";
            this.btnViewdatalist.Size = new System.Drawing.Size(85, 30);
            this.btnViewdatalist.TabIndex = 1;
            this.btnViewdatalist.Text = "VIEW GRID";
            this.btnViewdatalist.UseVisualStyleBackColor = false;
            this.btnViewdatalist.Click += new System.EventHandler(this.btnViewdatalist_Click);
            // 
            // Daily_Appointment_Count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 700);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Daily_Appointment_Count";
            this.Text = "Daily Appointment Count";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Daily_appointment_count_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDailyappoinment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdailyappointcount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grvdailyappointcount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dataGridViewDailyappoinment;
        private System.Windows.Forms.DataGridViewTextBoxColumn sino;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn email_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn booked_by;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartdailyappointcount;
        private System.Windows.Forms.ComboBox comboBoxdoctor;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailyappointcount2;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailyappointcount1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button serchdaily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lAB_TOTAL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Grvdailyappointcount;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_ExporttoExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnHidedatalist;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnViewdatalist;
    }
}