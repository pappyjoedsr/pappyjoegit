namespace PappyjoeMVC.View
{
    partial class Monthly_Treatment_Count
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monthly_Treatment_Count));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.gridmonthlytreatment = new System.Windows.Forms.DataGridView();
            this.Sl_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartmonthtreatment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePickermontreatment2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickermontreatment1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.Grvmonthtreatment = new System.Windows.Forms.DataGridView();
            this.comboBoxdoctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnviewchart = new System.Windows.Forms.Button();
            this.btngrddailytreatment = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmonthlytreatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartmonthtreatment)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvmonthtreatment)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Lab_Msg);
            this.panel4.Controls.Add(this.gridmonthlytreatment);
            this.panel4.Controls.Add(this.chartmonthtreatment);
            this.panel4.Location = new System.Drawing.Point(3, 154);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1065, 556);
            this.panel4.TabIndex = 133;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(274, 188);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 279;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // gridmonthlytreatment
            // 
            this.gridmonthlytreatment.AllowUserToAddRows = false;
            this.gridmonthlytreatment.AllowUserToDeleteRows = false;
            this.gridmonthlytreatment.AllowUserToResizeColumns = false;
            this.gridmonthlytreatment.AllowUserToResizeRows = false;
            this.gridmonthlytreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridmonthlytreatment.BackgroundColor = System.Drawing.Color.White;
            this.gridmonthlytreatment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridmonthlytreatment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridmonthlytreatment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridmonthlytreatment.ColumnHeadersHeight = 28;
            this.gridmonthlytreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridmonthlytreatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sl_no,
            this.Date,
            this.Services,
            this.Doctor});
            this.gridmonthlytreatment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridmonthlytreatment.Location = new System.Drawing.Point(0, 0);
            this.gridmonthlytreatment.Name = "gridmonthlytreatment";
            this.gridmonthlytreatment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.gridmonthlytreatment.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridmonthlytreatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridmonthlytreatment.Size = new System.Drawing.Size(1065, 556);
            this.gridmonthlytreatment.TabIndex = 0;
            // 
            // Sl_no
            // 
            this.Sl_no.DataPropertyName = "Sl_No";
            this.Sl_no.HeaderText = "SL.";
            this.Sl_no.Name = "Sl_no";
            this.Sl_no.Visible = false;
            this.Sl_no.Width = 156;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.DataPropertyName = "date";
            this.Date.HeaderText = "DATE";
            this.Date.Name = "Date";
            // 
            // Services
            // 
            this.Services.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Services.DataPropertyName = "procedure_name";
            this.Services.HeaderText = "SERVICES";
            this.Services.Name = "Services";
            // 
            // Doctor
            // 
            this.Doctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Doctor.DataPropertyName = "doctor_name";
            this.Doctor.HeaderText = "DOCTOR";
            this.Doctor.Name = "Doctor";
            // 
            // chartmonthtreatment
            // 
            this.chartmonthtreatment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chartmonthtreatment.ChartAreas.Add(chartArea1);
            this.chartmonthtreatment.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartmonthtreatment.Legends.Add(legend1);
            this.chartmonthtreatment.Location = new System.Drawing.Point(0, 0);
            this.chartmonthtreatment.Name = "chartmonthtreatment";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Treatment Count";
            this.chartmonthtreatment.Series.Add(series1);
            this.chartmonthtreatment.Size = new System.Drawing.Size(1065, 556);
            this.chartmonthtreatment.TabIndex = 7;
            this.chartmonthtreatment.Text = "chart1";
            // 
            // dateTimePickermontreatment2
            // 
            this.dateTimePickermontreatment2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickermontreatment2.Location = new System.Drawing.Point(322, 23);
            this.dateTimePickermontreatment2.Name = "dateTimePickermontreatment2";
            this.dateTimePickermontreatment2.Size = new System.Drawing.Size(205, 22);
            this.dateTimePickermontreatment2.TabIndex = 3;
            // 
            // dateTimePickermontreatment1
            // 
            this.dateTimePickermontreatment1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickermontreatment1.Location = new System.Drawing.Point(59, 23);
            this.dateTimePickermontreatment1.Name = "dateTimePickermontreatment1";
            this.dateTimePickermontreatment1.Size = new System.Drawing.Size(205, 22);
            this.dateTimePickermontreatment1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "From";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.Grvmonthtreatment);
            this.panel3.Location = new System.Drawing.Point(1071, 154);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 558);
            this.panel3.TabIndex = 132;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(-1002, 223);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(849, 59);
            this.label25.TabIndex = 79;
            // 
            // Grvmonthtreatment
            // 
            this.Grvmonthtreatment.AllowUserToAddRows = false;
            this.Grvmonthtreatment.AllowUserToDeleteRows = false;
            this.Grvmonthtreatment.AllowUserToResizeColumns = false;
            this.Grvmonthtreatment.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grvmonthtreatment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.Grvmonthtreatment.BackgroundColor = System.Drawing.Color.White;
            this.Grvmonthtreatment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvmonthtreatment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvmonthtreatment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvmonthtreatment.ColumnHeadersHeight = 28;
            this.Grvmonthtreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grvmonthtreatment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grvmonthtreatment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grvmonthtreatment.Location = new System.Drawing.Point(0, 0);
            this.Grvmonthtreatment.Name = "Grvmonthtreatment";
            this.Grvmonthtreatment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvmonthtreatment.RowHeadersVisible = false;
            this.Grvmonthtreatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvmonthtreatment.Size = new System.Drawing.Size(251, 558);
            this.Grvmonthtreatment.TabIndex = 0;
            this.Grvmonthtreatment.DataSourceChanged += new System.EventHandler(this.Grvmonthtreatment_DataSourceChanged);
            // 
            // comboBoxdoctor
            // 
            this.comboBoxdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdoctor.FormattingEnabled = true;
            this.comboBoxdoctor.Location = new System.Drawing.Point(714, 26);
            this.comboBoxdoctor.Name = "comboBoxdoctor";
            this.comboBoxdoctor.Size = new System.Drawing.Size(149, 21);
            this.comboBoxdoctor.TabIndex = 127;
            this.comboBoxdoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxdoctor_SelectedIndexChanged);
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(634, 29);
            this.Lab_Doctor.Name = "Lab_Doctor";
            this.Lab_Doctor.Size = new System.Drawing.Size(74, 13);
            this.Lab_Doctor.TabIndex = 126;
            this.Lab_Doctor.Text = "Doctor Name";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.comboBoxdoctor);
            this.panel2.Controls.Add(this.Lab_Doctor);
            this.panel2.Controls.Add(this.dateTimePickermontreatment2);
            this.panel2.Controls.Add(this.dateTimePickermontreatment1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnselect);
            this.panel2.Location = new System.Drawing.Point(1, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1321, 71);
            this.panel2.TabIndex = 131;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1025, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 125;
            this.label4.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(291, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(920, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 107;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(545, 23);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 1;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(981, 43);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 131;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.Color.White;
            this.btn_Export.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Export.Location = new System.Drawing.Point(781, 43);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(112, 30);
            this.btn_Export.TabIndex = 124;
            this.btn_Export.Text = "EXPORT TO EXCEL";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(352, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Monthly Treatment Report";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Export);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnviewchart);
            this.panel1.Controls.Add(this.btngrddailytreatment);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 78);
            this.panel1.TabIndex = 130;
            // 
            // btnviewchart
            // 
            this.btnviewchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnviewchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnviewchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewchart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewchart.ForeColor = System.Drawing.Color.White;
            this.btnviewchart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.Location = new System.Drawing.Point(609, 43);
            this.btnviewchart.Name = "btnviewchart";
            this.btnviewchart.Size = new System.Drawing.Size(85, 30);
            this.btnviewchart.TabIndex = 122;
            this.btnviewchart.Text = "VIEW CHART";
            this.btnviewchart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.UseVisualStyleBackColor = false;
            this.btnviewchart.Click += new System.EventHandler(this.btnviewchart_Click);
            // 
            // btngrddailytreatment
            // 
            this.btngrddailytreatment.BackColor = System.Drawing.Color.LimeGreen;
            this.btngrddailytreatment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btngrddailytreatment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngrddailytreatment.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngrddailytreatment.ForeColor = System.Drawing.Color.White;
            this.btngrddailytreatment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngrddailytreatment.Location = new System.Drawing.Point(695, 43);
            this.btngrddailytreatment.Name = "btngrddailytreatment";
            this.btngrddailytreatment.Size = new System.Drawing.Size(85, 30);
            this.btngrddailytreatment.TabIndex = 123;
            this.btngrddailytreatment.Text = "VIEW GRID";
            this.btngrddailytreatment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngrddailytreatment.UseVisualStyleBackColor = false;
            this.btngrddailytreatment.Click += new System.EventHandler(this.btngrddailytreatment_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(894, 43);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // Monthly_Treatment_Count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Monthly_Treatment_Count";
            this.Text = "Monthly Treatment Count";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Monthly_treatment_count_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridmonthlytreatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartmonthtreatment)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grvmonthtreatment)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView gridmonthlytreatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sl_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Services;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartmonthtreatment;
        private System.Windows.Forms.DateTimePicker dateTimePickermontreatment2;
        private System.Windows.Forms.DateTimePicker dateTimePickermontreatment1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridView Grvmonthtreatment;
        private System.Windows.Forms.ComboBox comboBoxdoctor;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnviewchart;
        private System.Windows.Forms.Button btngrddailytreatment;
    }
}