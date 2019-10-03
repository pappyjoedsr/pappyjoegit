namespace PappyjoeMVC.View
{
    partial class Doctor_Wise_Appointment_Report
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
            System.Windows.Forms.Panel panel4;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doctor_Wise_Appointment_Report));
            this.label_empty = new System.Windows.Forms.Label();
            this.Grvappointforeachdoctor = new System.Windows.Forms.DataGridView();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dataGridVieweachdoctorappoinmt = new System.Windows.Forms.DataGridView();
            this.chartappointeachdoctor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_grid = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btn_Graph = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerappointeachdoctor1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerappointeachdoctor2 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxdoctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctorname = new System.Windows.Forms.Label();
            this.Lab_Total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookeddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Startdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waiting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Engaged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Checkout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panel4 = new System.Windows.Forms.Panel();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvappointforeachdoctor)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieweachdoctorappoinmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartappointeachdoctor)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.label25.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            panel4.Controls.Add(this.label_empty);
            panel4.Controls.Add(this.Grvappointforeachdoctor);
            panel4.Location = new System.Drawing.Point(1134, 151);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(223, 544);
            panel4.TabIndex = 106;
            // 
            // label_empty
            // 
            this.label_empty.AutoSize = true;
            this.label_empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label_empty.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_empty.Location = new System.Drawing.Point(435, 81);
            this.label_empty.Name = "label_empty";
            this.label_empty.Size = new System.Drawing.Size(111, 13);
            this.label_empty.TabIndex = 84;
            this.label_empty.Text = "No Records Found !";
            // 
            // Grvappointforeachdoctor
            // 
            this.Grvappointforeachdoctor.AllowUserToAddRows = false;
            this.Grvappointforeachdoctor.AllowUserToDeleteRows = false;
            this.Grvappointforeachdoctor.AllowUserToResizeColumns = false;
            this.Grvappointforeachdoctor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Grvappointforeachdoctor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grvappointforeachdoctor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Grvappointforeachdoctor.BackgroundColor = System.Drawing.Color.White;
            this.Grvappointforeachdoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvappointforeachdoctor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvappointforeachdoctor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvappointforeachdoctor.ColumnHeadersHeight = 28;
            this.Grvappointforeachdoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grvappointforeachdoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grvappointforeachdoctor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grvappointforeachdoctor.GridColor = System.Drawing.Color.White;
            this.Grvappointforeachdoctor.Location = new System.Drawing.Point(0, 0);
            this.Grvappointforeachdoctor.Name = "Grvappointforeachdoctor";
            this.Grvappointforeachdoctor.RowHeadersVisible = false;
            this.Grvappointforeachdoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvappointforeachdoctor.Size = new System.Drawing.Size(223, 544);
            this.Grvappointforeachdoctor.TabIndex = 0;
            this.Grvappointforeachdoctor.DataSourceChanged += new System.EventHandler(this.Grvappointforeachdoctor_DataSourceChanged);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Search.Location = new System.Drawing.Point(543, 17);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(74, 22);
            this.btn_Search.TabIndex = 96;
            this.btn_Search.Text = "Show";
            this.btn_Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(564, 45);
            this.label5.TabIndex = 97;
            this.label5.Text = "Appointment Reports Of Each Doctors";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dataGridVieweachdoctorappoinmt);
            this.panel2.Controls.Add(this.chartappointeachdoctor);
            this.panel2.Location = new System.Drawing.Point(4, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 544);
            this.panel2.TabIndex = 104;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(208, 190);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // dataGridVieweachdoctorappoinmt
            // 
            this.dataGridVieweachdoctorappoinmt.AllowUserToAddRows = false;
            this.dataGridVieweachdoctorappoinmt.AllowUserToDeleteRows = false;
            this.dataGridVieweachdoctorappoinmt.AllowUserToResizeColumns = false;
            this.dataGridVieweachdoctorappoinmt.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridVieweachdoctorappoinmt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridVieweachdoctorappoinmt.BackgroundColor = System.Drawing.Color.White;
            this.dataGridVieweachdoctorappoinmt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridVieweachdoctorappoinmt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridVieweachdoctorappoinmt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridVieweachdoctorappoinmt.ColumnHeadersHeight = 30;
            this.dataGridVieweachdoctorappoinmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridVieweachdoctorappoinmt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slno,
            this.ptid,
            this.patientname,
            this.Email,
            this.Mobile,
            this.doctor,
            this.bookeddate,
            this.Startdate,
            this.duration,
            this.Schedule,
            this.waiting,
            this.Engaged,
            this.Checkout});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridVieweachdoctorappoinmt.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridVieweachdoctorappoinmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVieweachdoctorappoinmt.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridVieweachdoctorappoinmt.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridVieweachdoctorappoinmt.Location = new System.Drawing.Point(0, 0);
            this.dataGridVieweachdoctorappoinmt.Name = "dataGridVieweachdoctorappoinmt";
            this.dataGridVieweachdoctorappoinmt.ReadOnly = true;
            this.dataGridVieweachdoctorappoinmt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridVieweachdoctorappoinmt.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridVieweachdoctorappoinmt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.dataGridVieweachdoctorappoinmt.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridVieweachdoctorappoinmt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridVieweachdoctorappoinmt.Size = new System.Drawing.Size(1129, 544);
            this.dataGridVieweachdoctorappoinmt.TabIndex = 0;
            // 
            // chartappointeachdoctor
            // 
            this.chartappointeachdoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chartappointeachdoctor.ChartAreas.Add(chartArea1);
            this.chartappointeachdoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartappointeachdoctor.Legends.Add(legend1);
            this.chartappointeachdoctor.Location = new System.Drawing.Point(0, 0);
            this.chartappointeachdoctor.Name = "chartappointeachdoctor";
            series1.ChartArea = "ChartArea1";
            series1.LabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            series1.Legend = "Legend1";
            series1.Name = "Appointment (s)";
            this.chartappointeachdoctor.Series.Add(series1);
            this.chartappointeachdoctor.Size = new System.Drawing.Size(1129, 544);
            this.chartappointeachdoctor.TabIndex = 9;
            this.chartappointeachdoctor.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(1, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1359, 96);
            this.panel5.TabIndex = 103;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.btn_Close);
            this.panel6.Controls.Add(this.btn_Export);
            this.panel6.Controls.Add(this.btn_grid);
            this.panel6.Controls.Add(this.btnprint);
            this.panel6.Controls.Add(this.btn_Graph);
            this.panel6.Location = new System.Drawing.Point(3, 54);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1353, 40);
            this.panel6.TabIndex = 10;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1046, 6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 110;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.Color.White;
            this.btn_Export.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Export.Location = new System.Drawing.Point(849, 6);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(110, 30);
            this.btn_Export.TabIndex = 92;
            this.btn_Export.Text = "EXPORT TO EXCEL";
            this.btn_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_grid
            // 
            this.btn_grid.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_grid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_grid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_grid.ForeColor = System.Drawing.Color.White;
            this.btn_grid.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_grid.Location = new System.Drawing.Point(764, 6);
            this.btn_grid.Name = "btn_grid";
            this.btn_grid.Size = new System.Drawing.Size(85, 30);
            this.btn_grid.TabIndex = 90;
            this.btn_grid.Text = "VIEW GRID";
            this.btn_grid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_grid.UseVisualStyleBackColor = false;
            this.btn_grid.Click += new System.EventHandler(this.btn_grid_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(960, 6);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 11;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btn_Graph
            // 
            this.btn_Graph.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Graph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Graph.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Graph.ForeColor = System.Drawing.Color.White;
            this.btn_Graph.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Graph.Location = new System.Drawing.Point(679, 6);
            this.btn_Graph.Name = "btn_Graph";
            this.btn_Graph.Size = new System.Drawing.Size(85, 30);
            this.btn_Graph.TabIndex = 91;
            this.btn_Graph.Text = "VIEW GRAPH";
            this.btn_Graph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Graph.UseVisualStyleBackColor = false;
            this.btn_Graph.Click += new System.EventHandler(this.btn_Graph_Click);
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.BackColor = System.Drawing.Color.Gainsboro;
            this.label25.Controls.Add(this.label3);
            this.label25.Controls.Add(this.dateTimePickerappointeachdoctor1);
            this.label25.Controls.Add(this.label4);
            this.label25.Controls.Add(this.btn_Search);
            this.label25.Controls.Add(this.dateTimePickerappointeachdoctor2);
            this.label25.Controls.Add(this.comboBoxdoctor);
            this.label25.Controls.Add(this.Lab_Doctorname);
            this.label25.Controls.Add(this.Lab_Total);
            this.label25.Controls.Add(this.label1);
            this.label25.Location = new System.Drawing.Point(2, 99);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1358, 51);
            this.label25.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // dateTimePickerappointeachdoctor1
            // 
            this.dateTimePickerappointeachdoctor1.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerappointeachdoctor1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerappointeachdoctor1.Location = new System.Drawing.Point(62, 14);
            this.dateTimePickerappointeachdoctor1.Name = "dateTimePickerappointeachdoctor1";
            this.dateTimePickerappointeachdoctor1.Size = new System.Drawing.Size(208, 22);
            this.dateTimePickerappointeachdoctor1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(283, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "To";
            // 
            // dateTimePickerappointeachdoctor2
            // 
            this.dateTimePickerappointeachdoctor2.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerappointeachdoctor2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerappointeachdoctor2.Location = new System.Drawing.Point(315, 14);
            this.dateTimePickerappointeachdoctor2.Name = "dateTimePickerappointeachdoctor2";
            this.dateTimePickerappointeachdoctor2.Size = new System.Drawing.Size(209, 22);
            this.dateTimePickerappointeachdoctor2.TabIndex = 4;
            // 
            // comboBoxdoctor
            // 
            this.comboBoxdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdoctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.comboBoxdoctor.FormattingEnabled = true;
            this.comboBoxdoctor.Location = new System.Drawing.Point(918, 19);
            this.comboBoxdoctor.Name = "comboBoxdoctor";
            this.comboBoxdoctor.Size = new System.Drawing.Size(149, 21);
            this.comboBoxdoctor.TabIndex = 95;
            this.comboBoxdoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxdoctor_SelectedIndexChanged);
            // 
            // Lab_Doctorname
            // 
            this.Lab_Doctorname.AutoSize = true;
            this.Lab_Doctorname.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctorname.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctorname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctorname.Location = new System.Drawing.Point(838, 22);
            this.Lab_Doctorname.Name = "Lab_Doctorname";
            this.Lab_Doctorname.Size = new System.Drawing.Size(74, 13);
            this.Lab_Doctorname.TabIndex = 94;
            this.Lab_Doctorname.Text = "Doctor Name";
            // 
            // Lab_Total
            // 
            this.Lab_Total.AutoSize = true;
            this.Lab_Total.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Total.ForeColor = System.Drawing.Color.Red;
            this.Lab_Total.Location = new System.Drawing.Point(784, 19);
            this.Lab_Total.Name = "Lab_Total";
            this.Lab_Total.Size = new System.Drawing.Size(45, 17);
            this.Lab_Total.TabIndex = 2;
            this.Lab_Total.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(643, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Appointments : ";
            // 
            // slno
            // 
            this.slno.DataPropertyName = "Sino";
            this.slno.HeaderText = "Sl No";
            this.slno.Name = "slno";
            this.slno.ReadOnly = true;
            this.slno.Visible = false;
            this.slno.Width = 85;
            // 
            // ptid
            // 
            this.ptid.DataPropertyName = "pt_id";
            this.ptid.HeaderText = "PATIENT ID";
            this.ptid.Name = "ptid";
            this.ptid.ReadOnly = true;
            this.ptid.Width = 60;
            // 
            // patientname
            // 
            this.patientname.DataPropertyName = "pt_name";
            this.patientname.HeaderText = "PATIENT NAME";
            this.patientname.Name = "patientname";
            this.patientname.ReadOnly = true;
            this.patientname.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "email_address";
            this.Email.HeaderText = "EMAIL ID";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // Mobile
            // 
            this.Mobile.DataPropertyName = "primary_mobile_number";
            this.Mobile.HeaderText = "MOBILE ";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            this.Mobile.Width = 80;
            // 
            // doctor
            // 
            this.doctor.DataPropertyName = "doctor_name";
            this.doctor.HeaderText = "DOCTOR NAME";
            this.doctor.Name = "doctor";
            this.doctor.ReadOnly = true;
            // 
            // bookeddate
            // 
            this.bookeddate.DataPropertyName = "book_datetime";
            this.bookeddate.HeaderText = "BOOKED DATE";
            this.bookeddate.Name = "bookeddate";
            this.bookeddate.ReadOnly = true;
            // 
            // Startdate
            // 
            this.Startdate.DataPropertyName = "start_datetime";
            this.Startdate.HeaderText = "APPOINTMENT DATE";
            this.Startdate.Name = "Startdate";
            this.Startdate.ReadOnly = true;
            this.Startdate.Width = 135;
            // 
            // duration
            // 
            this.duration.DataPropertyName = "duration";
            this.duration.HeaderText = "DURATION (MINS)";
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            // 
            // Schedule
            // 
            this.Schedule.DataPropertyName = "schedule";
            this.Schedule.HeaderText = "SHEDULE";
            this.Schedule.Name = "Schedule";
            this.Schedule.ReadOnly = true;
            // 
            // waiting
            // 
            this.waiting.DataPropertyName = "waiting";
            this.waiting.HeaderText = "WAITING";
            this.waiting.Name = "waiting";
            this.waiting.ReadOnly = true;
            // 
            // Engaged
            // 
            this.Engaged.DataPropertyName = "engaged";
            this.Engaged.HeaderText = "ENGAGED";
            this.Engaged.Name = "Engaged";
            this.Engaged.ReadOnly = true;
            // 
            // Checkout
            // 
            this.Checkout.DataPropertyName = "checkout";
            this.Checkout.HeaderText = "CHECK OUT";
            this.Checkout.Name = "Checkout";
            this.Checkout.ReadOnly = true;
            // 
            // Doctor_Wise_Appointment_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label25);
            this.Controls.Add(panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Doctor_Wise_Appointment_Report";
            this.Text = "Appointment Report of Each Doctor ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DoctorWise_appointment_report_Load);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvappointforeachdoctor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVieweachdoctorappoinmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartappointeachdoctor)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.label25.ResumeLayout(false);
            this.label25.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dataGridVieweachdoctorappoinmt;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartappointeachdoctor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_grid;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btn_Graph;
        private System.Windows.Forms.Panel label25;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerappointeachdoctor1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerappointeachdoctor2;
        private System.Windows.Forms.ComboBox comboBoxdoctor;
        private System.Windows.Forms.Label Lab_Doctorname;
        private System.Windows.Forms.Label Lab_Total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_empty;
        private System.Windows.Forms.DataGridView Grvappointforeachdoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookeddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Startdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn waiting;
        private System.Windows.Forms.DataGridViewTextBoxColumn Engaged;
        private System.Windows.Forms.DataGridViewTextBoxColumn Checkout;
    }
}