namespace PappyjoeMVC.View
{
    partial class Treatment_For_Each_Doctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Treatment_For_Each_Doctor));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.gridtreatmentondoctors = new System.Windows.Forms.DataGridView();
            this.Sl_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.charttreateachdoctor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Lab_DoctorName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.combodoctors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickertreateachdoctor2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickertreateachdoctor1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Grvtreatmenteachdoctor = new System.Windows.Forms.DataGridView();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ViewGrid = new System.Windows.Forms.Button();
            this.btnviewchart = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridtreatmentondoctors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charttreateachdoctor)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvtreatmenteachdoctor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Lab_Msg);
            this.panel4.Controls.Add(this.gridtreatmentondoctors);
            this.panel4.Controls.Add(this.charttreateachdoctor);
            this.panel4.Location = new System.Drawing.Point(1, 148);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1113, 561);
            this.panel4.TabIndex = 133;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(301, 204);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 278;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // gridtreatmentondoctors
            // 
            this.gridtreatmentondoctors.AllowUserToAddRows = false;
            this.gridtreatmentondoctors.AllowUserToDeleteRows = false;
            this.gridtreatmentondoctors.BackgroundColor = System.Drawing.Color.White;
            this.gridtreatmentondoctors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridtreatmentondoctors.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridtreatmentondoctors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridtreatmentondoctors.ColumnHeadersHeight = 28;
            this.gridtreatmentondoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridtreatmentondoctors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sl_No,
            this.Date,
            this.Services,
            this.Doctor});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridtreatmentondoctors.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridtreatmentondoctors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridtreatmentondoctors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridtreatmentondoctors.Location = new System.Drawing.Point(0, 0);
            this.gridtreatmentondoctors.Name = "gridtreatmentondoctors";
            this.gridtreatmentondoctors.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gridtreatmentondoctors.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.gridtreatmentondoctors.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridtreatmentondoctors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridtreatmentondoctors.Size = new System.Drawing.Size(1113, 561);
            this.gridtreatmentondoctors.TabIndex = 0;
            // 
            // Sl_No
            // 
            this.Sl_No.DataPropertyName = "Sl_No";
            this.Sl_No.HeaderText = "SlNo";
            this.Sl_No.Name = "Sl_No";
            this.Sl_No.Visible = false;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "date";
            this.Date.HeaderText = "DATE";
            this.Date.Name = "Date";
            this.Date.Width = 250;
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
            // charttreateachdoctor
            // 
            this.charttreateachdoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.charttreateachdoctor.ChartAreas.Add(chartArea1);
            this.charttreateachdoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.charttreateachdoctor.Legends.Add(legend1);
            this.charttreateachdoctor.Location = new System.Drawing.Point(0, 0);
            this.charttreateachdoctor.Name = "charttreateachdoctor";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Treatment (s)";
            this.charttreateachdoctor.Series.Add(series1);
            this.charttreateachdoctor.Size = new System.Drawing.Size(1113, 561);
            this.charttreateachdoctor.TabIndex = 1;
            this.charttreateachdoctor.Text = "chart1";
            // 
            // Lab_DoctorName
            // 
            this.Lab_DoctorName.AutoSize = true;
            this.Lab_DoctorName.BackColor = System.Drawing.Color.Gainsboro;
            this.Lab_DoctorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_DoctorName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_DoctorName.Location = new System.Drawing.Point(790, 27);
            this.Lab_DoctorName.Name = "Lab_DoctorName";
            this.Lab_DoctorName.Size = new System.Drawing.Size(87, 17);
            this.Lab_DoctorName.TabIndex = 121;
            this.Lab_DoctorName.Text = "Doctor Name";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.Lab_DoctorName);
            this.panel3.Controls.Add(this.combodoctors);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.dateTimePickertreateachdoctor2);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dateTimePickertreateachdoctor1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnselect);
            this.panel3.Location = new System.Drawing.Point(3, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1358, 66);
            this.panel3.TabIndex = 132;
            // 
            // combodoctors
            // 
            this.combodoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combodoctors.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.combodoctors.FormattingEnabled = true;
            this.combodoctors.Location = new System.Drawing.Point(884, 24);
            this.combodoctors.Name = "combodoctors";
            this.combodoctors.Size = new System.Drawing.Size(165, 21);
            this.combodoctors.TabIndex = 1;
            this.combodoctors.SelectedIndexChanged += new System.EventHandler(this.combodoctors_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(618, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 120;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // dateTimePickertreateachdoctor2
            // 
            this.dateTimePickertreateachdoctor2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickertreateachdoctor2.Location = new System.Drawing.Point(304, 19);
            this.dateTimePickertreateachdoctor2.Name = "dateTimePickertreateachdoctor2";
            this.dateTimePickertreateachdoctor2.Size = new System.Drawing.Size(213, 22);
            this.dateTimePickertreateachdoctor2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(723, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // dateTimePickertreateachdoctor1
            // 
            this.dateTimePickertreateachdoctor1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickertreateachdoctor1.Location = new System.Drawing.Point(53, 20);
            this.dateTimePickertreateachdoctor1.Name = "dateTimePickertreateachdoctor1";
            this.dateTimePickertreateachdoctor1.Size = new System.Drawing.Size(209, 22);
            this.dateTimePickertreateachdoctor1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(273, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(530, 20);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 6;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Grvtreatmenteachdoctor);
            this.panel2.Location = new System.Drawing.Point(1115, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 561);
            this.panel2.TabIndex = 131;
            // 
            // Grvtreatmenteachdoctor
            // 
            this.Grvtreatmenteachdoctor.AllowUserToAddRows = false;
            this.Grvtreatmenteachdoctor.AllowUserToDeleteRows = false;
            this.Grvtreatmenteachdoctor.AllowUserToResizeColumns = false;
            this.Grvtreatmenteachdoctor.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Grvtreatmenteachdoctor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grvtreatmenteachdoctor.BackgroundColor = System.Drawing.Color.White;
            this.Grvtreatmenteachdoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvtreatmenteachdoctor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvtreatmenteachdoctor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvtreatmenteachdoctor.ColumnHeadersHeight = 28;
            this.Grvtreatmenteachdoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grvtreatmenteachdoctor.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grvtreatmenteachdoctor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grvtreatmenteachdoctor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grvtreatmenteachdoctor.Location = new System.Drawing.Point(0, 0);
            this.Grvtreatmenteachdoctor.Name = "Grvtreatmenteachdoctor";
            this.Grvtreatmenteachdoctor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvtreatmenteachdoctor.RowHeadersVisible = false;
            this.Grvtreatmenteachdoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvtreatmenteachdoctor.Size = new System.Drawing.Size(246, 561);
            this.Grvtreatmenteachdoctor.TabIndex = 0;
            this.Grvtreatmenteachdoctor.DataSourceChanged += new System.EventHandler(this.Grvtreatmenteachdoctor_DataSourceChanged);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1027, 42);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 131;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.ForeColor = System.Drawing.Color.White;
            this.btn_export.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_export.Location = new System.Drawing.Point(826, 42);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(114, 30);
            this.btn_export.TabIndex = 125;
            this.btn_export.Text = "EXPORT TO EXCEL";
            this.btn_export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(368, 40);
            this.label6.TabIndex = 124;
            this.label6.Text = "Treatments For Each Doctor";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_ViewGrid);
            this.panel1.Controls.Add(this.btnviewchart);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1359, 77);
            this.panel1.TabIndex = 130;
            // 
            // btn_ViewGrid
            // 
            this.btn_ViewGrid.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_ViewGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_ViewGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ViewGrid.ForeColor = System.Drawing.Color.White;
            this.btn_ViewGrid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_ViewGrid.Location = new System.Drawing.Point(740, 42);
            this.btn_ViewGrid.Name = "btn_ViewGrid";
            this.btn_ViewGrid.Size = new System.Drawing.Size(85, 30);
            this.btn_ViewGrid.TabIndex = 123;
            this.btn_ViewGrid.Text = "VIEW GRID";
            this.btn_ViewGrid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ViewGrid.UseVisualStyleBackColor = false;
            this.btn_ViewGrid.Click += new System.EventHandler(this.btn_ViewGrid_Click);
            // 
            // btnviewchart
            // 
            this.btnviewchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnviewchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnviewchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewchart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewchart.ForeColor = System.Drawing.Color.White;
            this.btnviewchart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.Location = new System.Drawing.Point(654, 42);
            this.btnviewchart.Name = "btnviewchart";
            this.btnviewchart.Size = new System.Drawing.Size(85, 30);
            this.btnviewchart.TabIndex = 122;
            this.btnviewchart.Text = "VIEW CHART";
            this.btnviewchart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.UseVisualStyleBackColor = false;
            this.btnviewchart.Click += new System.EventHandler(this.btnviewchart_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(941, 42);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // Treatment_for_each_doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Treatment_for_each_doctor";
            this.Text = "Treatment for Each Doctor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Treatment_for_each_doctor_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridtreatmentondoctors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charttreateachdoctor)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grvtreatmenteachdoctor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView gridtreatmentondoctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sl_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Services;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
        private System.Windows.Forms.DataVisualization.Charting.Chart charttreateachdoctor;
        private System.Windows.Forms.Label Lab_DoctorName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox combodoctors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickertreateachdoctor2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickertreateachdoctor1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView Grvtreatmenteachdoctor;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ViewGrid;
        private System.Windows.Forms.Button btnviewchart;
        private System.Windows.Forms.Button btnprint;
    }
}