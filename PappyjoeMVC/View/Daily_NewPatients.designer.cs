namespace PappyjoeMVC.View
{
    partial class Daily_NewPatients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daily_NewPatients));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lab_Doctorname = new System.Windows.Forms.Label();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.combodoctors = new System.Windows.Forms.ComboBox();
            this.dateTimePickerdailynewpatient1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerdailynewpatient2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblNoRecord = new System.Windows.Forms.Label();
            this.dgvDailyNewPatient = new System.Windows.Forms.DataGridView();
            this.sl_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartDailyNewPatients = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Grvdailynewpatient = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnViewGrid = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.btnviewchart = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyNewPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyNewPatients)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvdailynewpatient)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.Lab_Doctorname);
            this.panel4.Controls.Add(this.btnsearch);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.combodoctors);
            this.panel4.Controls.Add(this.dateTimePickerdailynewpatient1);
            this.panel4.Controls.Add(this.dateTimePickerdailynewpatient2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(2, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1296, 63);
            this.panel4.TabIndex = 257;
            // 
            // Lab_Doctorname
            // 
            this.Lab_Doctorname.AutoSize = true;
            this.Lab_Doctorname.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctorname.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctorname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctorname.Location = new System.Drawing.Point(652, 28);
            this.Lab_Doctorname.Name = "Lab_Doctorname";
            this.Lab_Doctorname.Size = new System.Drawing.Size(96, 17);
            this.Lab_Doctorname.TabIndex = 112;
            this.Lab_Doctorname.Text = "Doctor Name :";
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(533, 23);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 111;
            this.btnsearch.Text = "Show";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(278, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // combodoctors
            // 
            this.combodoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combodoctors.FormattingEnabled = true;
            this.combodoctors.Location = new System.Drawing.Point(757, 28);
            this.combodoctors.Name = "combodoctors";
            this.combodoctors.Size = new System.Drawing.Size(142, 21);
            this.combodoctors.TabIndex = 8;
            this.combodoctors.SelectedValueChanged += new System.EventHandler(this.combodoctors_SelectedValueChanged);
            this.combodoctors.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combodoctors_KeyPress);
            // 
            // dateTimePickerdailynewpatient1
            // 
            this.dateTimePickerdailynewpatient1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailynewpatient1.Location = new System.Drawing.Point(51, 22);
            this.dateTimePickerdailynewpatient1.Name = "dateTimePickerdailynewpatient1";
            this.dateTimePickerdailynewpatient1.Size = new System.Drawing.Size(206, 22);
            this.dateTimePickerdailynewpatient1.TabIndex = 1;
            // 
            // dateTimePickerdailynewpatient2
            // 
            this.dateTimePickerdailynewpatient2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailynewpatient2.Location = new System.Drawing.Point(310, 23);
            this.dateTimePickerdailynewpatient2.Name = "dateTimePickerdailynewpatient2";
            this.dateTimePickerdailynewpatient2.Size = new System.Drawing.Size(211, 22);
            this.dateTimePickerdailynewpatient2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "From:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1070, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(941, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "TOTAL PATIENTS :";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.lblNoRecord);
            this.panel5.Controls.Add(this.dgvDailyNewPatient);
            this.panel5.Controls.Add(this.chartDailyNewPatients);
            this.panel5.Location = new System.Drawing.Point(4, 137);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1085, 609);
            this.panel5.TabIndex = 258;
            // 
            // lblNoRecord
            // 
            this.lblNoRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoRecord.AutoSize = true;
            this.lblNoRecord.BackColor = System.Drawing.Color.Wheat;
            this.lblNoRecord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecord.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblNoRecord.Location = new System.Drawing.Point(232, 221);
            this.lblNoRecord.Name = "lblNoRecord";
            this.lblNoRecord.Size = new System.Drawing.Size(506, 25);
            this.lblNoRecord.TabIndex = 249;
            this.lblNoRecord.Text = "No Records Found. Please change the Date and try again !..";
            this.lblNoRecord.VisibleChanged += new System.EventHandler(this.lblNoRecord_VisibleChanged);
            // 
            // dgvDailyNewPatient
            // 
            this.dgvDailyNewPatient.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.dgvDailyNewPatient.AllowUserToAddRows = false;
            this.dgvDailyNewPatient.AllowUserToDeleteRows = false;
            this.dgvDailyNewPatient.AllowUserToResizeColumns = false;
            this.dgvDailyNewPatient.AllowUserToResizeRows = false;
            this.dgvDailyNewPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDailyNewPatient.BackgroundColor = System.Drawing.Color.White;
            this.dgvDailyNewPatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDailyNewPatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDailyNewPatient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDailyNewPatient.ColumnHeadersHeight = 28;
            this.dgvDailyNewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDailyNewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sl_no,
            this.date,
            this.patient_id,
            this.patient_name,
            this.mobile,
            this.email,
            this.Doctor});
            this.dgvDailyNewPatient.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvDailyNewPatient.Location = new System.Drawing.Point(2, 4);
            this.dgvDailyNewPatient.MultiSelect = false;
            this.dgvDailyNewPatient.Name = "dgvDailyNewPatient";
            this.dgvDailyNewPatient.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDailyNewPatient.RowHeadersVisible = false;
            this.dgvDailyNewPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.dgvDailyNewPatient.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDailyNewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDailyNewPatient.Size = new System.Drawing.Size(1083, 563);
            this.dgvDailyNewPatient.TabIndex = 248;
            this.dgvDailyNewPatient.Visible = false;
            // 
            // sl_no
            // 
            this.sl_no.HeaderText = "SlNo";
            this.sl_no.Name = "sl_no";
            this.sl_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sl_no.Width = 50;
            // 
            // date
            // 
            this.date.HeaderText = "DATE";
            this.date.Name = "date";
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.Width = 70;
            // 
            // patient_id
            // 
            this.patient_id.HeaderText = "PATIENT ID";
            this.patient_id.Name = "patient_id";
            this.patient_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patient_id.Width = 160;
            // 
            // patient_name
            // 
            this.patient_name.HeaderText = "PATIENT NAME";
            this.patient_name.Name = "patient_name";
            this.patient_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patient_name.Width = 220;
            // 
            // mobile
            // 
            this.mobile.HeaderText = "MOBILE";
            this.mobile.Name = "mobile";
            this.mobile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.mobile.Width = 200;
            // 
            // email
            // 
            this.email.HeaderText = "EMAIL";
            this.email.Name = "email";
            this.email.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.email.Width = 220;
            // 
            // Doctor
            // 
            this.Doctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Doctor.HeaderText = "DOCTOR NAME";
            this.Doctor.Name = "Doctor";
            this.Doctor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // chartDailyNewPatients
            // 
            this.chartDailyNewPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDailyNewPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.Name = "ChartArea1";
            this.chartDailyNewPatients.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartDailyNewPatients.Legends.Add(legend2);
            this.chartDailyNewPatients.Location = new System.Drawing.Point(2, 1);
            this.chartDailyNewPatients.Name = "chartDailyNewPatients";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "New Patient Count";
            this.chartDailyNewPatients.Series.Add(series2);
            this.chartDailyNewPatients.Size = new System.Drawing.Size(1082, 563);
            this.chartDailyNewPatients.TabIndex = 9;
            this.chartDailyNewPatients.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Grvdailynewpatient);
            this.panel3.Location = new System.Drawing.Point(1087, 137);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 609);
            this.panel3.TabIndex = 256;
            // 
            // Grvdailynewpatient
            // 
            this.Grvdailynewpatient.AllowUserToDeleteRows = false;
            this.Grvdailynewpatient.AllowUserToResizeColumns = false;
            this.Grvdailynewpatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.Grvdailynewpatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Grvdailynewpatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grvdailynewpatient.BackgroundColor = System.Drawing.Color.White;
            this.Grvdailynewpatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvdailynewpatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvdailynewpatient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvdailynewpatient.ColumnHeadersHeight = 28;
            this.Grvdailynewpatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grvdailynewpatient.GridColor = System.Drawing.Color.White;
            this.Grvdailynewpatient.Location = new System.Drawing.Point(3, 0);
            this.Grvdailynewpatient.Name = "Grvdailynewpatient";
            this.Grvdailynewpatient.RowHeadersVisible = false;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.Grvdailynewpatient.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.Grvdailynewpatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvdailynewpatient.Size = new System.Drawing.Size(206, 563);
            this.Grvdailynewpatient.TabIndex = 0;
            this.Grvdailynewpatient.DataSourceChanged += new System.EventHandler(this.Grvdailynewpatient_DataSourceChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnViewGrid);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.btnviewchart);
            this.panel2.Controls.Add(this.btnprint);
            this.panel2.Controls.Add(this.BtnExport);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(607, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 49);
            this.panel2.TabIndex = 251;
            // 
            // btnViewGrid
            // 
            this.btnViewGrid.BackColor = System.Drawing.Color.LimeGreen;
            this.btnViewGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnViewGrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewGrid.ForeColor = System.Drawing.Color.White;
            this.btnViewGrid.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnViewGrid.Location = new System.Drawing.Point(96, 12);
            this.btnViewGrid.Name = "btnViewGrid";
            this.btnViewGrid.Size = new System.Drawing.Size(85, 30);
            this.btnViewGrid.TabIndex = 247;
            this.btnViewGrid.Text = "VIEW GRID";
            this.btnViewGrid.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnViewGrid.UseVisualStyleBackColor = false;
            this.btnViewGrid.Click += new System.EventHandler(this.btnViewGrid_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Tomato;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.Location = new System.Drawing.Point(391, 12);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 30);
            this.buttonClose.TabIndex = 249;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // btnviewchart
            // 
            this.btnviewchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnviewchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnviewchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewchart.ForeColor = System.Drawing.Color.White;
            this.btnviewchart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.Location = new System.Drawing.Point(10, 12);
            this.btnviewchart.Name = "btnviewchart";
            this.btnviewchart.Size = new System.Drawing.Size(85, 30);
            this.btnviewchart.TabIndex = 246;
            this.btnviewchart.Text = " VIEW CHART";
            this.btnviewchart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnviewchart.UseVisualStyleBackColor = false;
            this.btnviewchart.Click += new System.EventHandler(this.btnviewchart_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(182, 12);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(122, 30);
            this.BtnExport.TabIndex = 250;
            this.BtnExport.Text = "EXPORT TO EXCEL";
            this.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 40);
            this.label6.TabIndex = 1;
            this.label6.Text = "Daily New Patients";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1296, 71);
            this.panel1.TabIndex = 255;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(305, 12);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 11;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // Daily_NewPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Daily_NewPatients";
            this.Text = "Daily New Patients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Daily_NewPatients_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailyNewPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyNewPatients)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grvdailynewpatient)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lab_Doctorname;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combodoctors;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailynewpatient1;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailynewpatient2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblNoRecord;
        private System.Windows.Forms.DataGridView dgvDailyNewPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyNewPatients;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Grvdailynewpatient;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnViewGrid;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnviewchart;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
    }
}