namespace PappyjoeMVC.View
{
    partial class Monthly_New_Patients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monthly_New_Patients));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.lblNoRecord = new System.Windows.Forms.Label();
            this.dataGridmonthlypatient = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chartmonthnewpatient = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btngrid = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Grvmonthnewpatient = new System.Windows.Forms.DataGridView();
            this.BtnExport = new System.Windows.Forms.Button();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Lab_Doctorname = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.btnchart = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickermonthnewpatient1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickermonthnewpatient2 = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appoinment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nationality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passport_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridmonthlypatient)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartmonthnewpatient)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvmonthnewpatient)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNoRecord
            // 
            this.lblNoRecord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoRecord.BackColor = System.Drawing.Color.Wheat;
            this.lblNoRecord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecord.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblNoRecord.Location = new System.Drawing.Point(252, 223);
            this.lblNoRecord.Name = "lblNoRecord";
            this.lblNoRecord.Size = new System.Drawing.Size(526, 25);
            this.lblNoRecord.TabIndex = 250;
            this.lblNoRecord.Text = "No Records Found. Please change the Date and try again !..";
            this.lblNoRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridmonthlypatient
            // 
            this.dataGridmonthlypatient.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.dataGridmonthlypatient.AllowUserToAddRows = false;
            this.dataGridmonthlypatient.AllowUserToDeleteRows = false;
            this.dataGridmonthlypatient.AllowUserToResizeColumns = false;
            this.dataGridmonthlypatient.AllowUserToResizeRows = false;
            this.dataGridmonthlypatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridmonthlypatient.BackgroundColor = System.Drawing.Color.White;
            this.dataGridmonthlypatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridmonthlypatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridmonthlypatient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridmonthlypatient.ColumnHeadersHeight = 28;
            this.dataGridmonthlypatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridmonthlypatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slno,
            this.pt_id,
            this.patient,
            this.Appoinment,
            this.Mobile,
            this.emailaddress,
            this.Doctor,
            this.nationality,
            this.passport_no});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridmonthlypatient.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridmonthlypatient.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridmonthlypatient.Location = new System.Drawing.Point(4, 3);
            this.dataGridmonthlypatient.Name = "dataGridmonthlypatient";
            this.dataGridmonthlypatient.ReadOnly = true;
            this.dataGridmonthlypatient.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridmonthlypatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridmonthlypatient.RowHeadersVisible = false;
            this.dataGridmonthlypatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridmonthlypatient.Size = new System.Drawing.Size(1076, 537);
            this.dataGridmonthlypatient.TabIndex = 109;
            this.dataGridmonthlypatient.Visible = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lblNoRecord);
            this.panel4.Controls.Add(this.dataGridmonthlypatient);
            this.panel4.Controls.Add(this.chartmonthnewpatient);
            this.panel4.Location = new System.Drawing.Point(0, 147);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1083, 602);
            this.panel4.TabIndex = 226;
            // 
            // chartmonthnewpatient
            // 
            this.chartmonthnewpatient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartmonthnewpatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chartmonthnewpatient.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartmonthnewpatient.Legends.Add(legend1);
            this.chartmonthnewpatient.Location = new System.Drawing.Point(4, 3);
            this.chartmonthnewpatient.Name = "chartmonthnewpatient";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Patients";
            this.chartmonthnewpatient.Series.Add(series1);
            this.chartmonthnewpatient.Size = new System.Drawing.Size(1076, 537);
            this.chartmonthnewpatient.TabIndex = 7;
            this.chartmonthnewpatient.Text = "chart1";
            this.chartmonthnewpatient.Visible = false;
            // 
            // btngrid
            // 
            this.btngrid.BackColor = System.Drawing.Color.LimeGreen;
            this.btngrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btngrid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngrid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngrid.ForeColor = System.Drawing.Color.White;
            this.btngrid.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngrid.Location = new System.Drawing.Point(925, 44);
            this.btngrid.Name = "btngrid";
            this.btngrid.Size = new System.Drawing.Size(85, 30);
            this.btngrid.TabIndex = 107;
            this.btngrid.Text = "VIEW GRID";
            this.btngrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btngrid.UseVisualStyleBackColor = false;
            this.btngrid.Click += new System.EventHandler(this.btngrid_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.Grvmonthnewpatient);
            this.panel3.Location = new System.Drawing.Point(1083, 147);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 602);
            this.panel3.TabIndex = 225;
            // 
            // Grvmonthnewpatient
            // 
            this.Grvmonthnewpatient.AllowUserToDeleteRows = false;
            this.Grvmonthnewpatient.AllowUserToResizeColumns = false;
            this.Grvmonthnewpatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Grvmonthnewpatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grvmonthnewpatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grvmonthnewpatient.BackgroundColor = System.Drawing.Color.White;
            this.Grvmonthnewpatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvmonthnewpatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvmonthnewpatient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvmonthnewpatient.ColumnHeadersHeight = 28;
            this.Grvmonthnewpatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grvmonthnewpatient.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grvmonthnewpatient.GridColor = System.Drawing.Color.Gainsboro;
            this.Grvmonthnewpatient.Location = new System.Drawing.Point(-3, 3);
            this.Grvmonthnewpatient.Name = "Grvmonthnewpatient";
            this.Grvmonthnewpatient.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvmonthnewpatient.RowHeadersVisible = false;
            this.Grvmonthnewpatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvmonthnewpatient.Size = new System.Drawing.Size(211, 537);
            this.Grvmonthnewpatient.TabIndex = 0;
            this.Grvmonthnewpatient.DataSourceChanged += new System.EventHandler(this.Grvmonthnewpatient_DataSourceChanged);
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(1011, 44);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(111, 30);
            this.BtnExport.TabIndex = 218;
            this.BtnExport.Text = "EXPORT TO EXCEL";
            this.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(693, 18);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(146, 21);
            this.cmbDoctor.TabIndex = 109;
            this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.cmbDoctor_SelectedIndexChanged);
            this.cmbDoctor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDoctor_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 40);
            this.label6.TabIndex = 219;
            this.label6.Text = "Monthly New Patients";
            // 
            // Lab_Doctorname
            // 
            this.Lab_Doctorname.AutoSize = true;
            this.Lab_Doctorname.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctorname.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctorname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctorname.Location = new System.Drawing.Point(613, 22);
            this.Lab_Doctorname.Name = "Lab_Doctorname";
            this.Lab_Doctorname.Size = new System.Drawing.Size(74, 13);
            this.Lab_Doctorname.TabIndex = 113;
            this.Lab_Doctorname.Text = "Doctor Name";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btngrid);
            this.panel1.Controls.Add(this.BtnExport);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.btnchart);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1299, 84);
            this.panel1.TabIndex = 223;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(1123, 44);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 11;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Tomato;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.Location = new System.Drawing.Point(1209, 44);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 30);
            this.buttonClose.TabIndex = 215;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // btnchart
            // 
            this.btnchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchart.ForeColor = System.Drawing.Color.White;
            this.btnchart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnchart.Location = new System.Drawing.Point(839, 44);
            this.btnchart.Name = "btnchart";
            this.btnchart.Size = new System.Drawing.Size(85, 30);
            this.btnchart.TabIndex = 106;
            this.btnchart.Text = "VIEW CHART";
            this.btnchart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnchart.UseVisualStyleBackColor = false;
            this.btnchart.Click += new System.EventHandler(this.btnchart_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnsearch.Location = new System.Drawing.Point(518, 17);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 108;
            this.btnsearch.Text = "Search";
            this.btnsearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(859, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 105;
            this.label5.Text = "TOTAL PATIENTS :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(987, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "label4";
            // 
            // dateTimePickermonthnewpatient1
            // 
            this.dateTimePickermonthnewpatient1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickermonthnewpatient1.Location = new System.Drawing.Point(55, 17);
            this.dateTimePickermonthnewpatient1.Name = "dateTimePickermonthnewpatient1";
            this.dateTimePickermonthnewpatient1.Size = new System.Drawing.Size(195, 22);
            this.dateTimePickermonthnewpatient1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(266, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            // 
            // dateTimePickermonthnewpatient2
            // 
            this.dateTimePickermonthnewpatient2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickermonthnewpatient2.Location = new System.Drawing.Point(295, 17);
            this.dateTimePickermonthnewpatient2.Name = "dateTimePickermonthnewpatient2";
            this.dateTimePickermonthnewpatient2.Size = new System.Drawing.Size(204, 22);
            this.dateTimePickermonthnewpatient2.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.Lab_Doctorname);
            this.panel2.Controls.Add(this.cmbDoctor);
            this.panel2.Controls.Add(this.dateTimePickermonthnewpatient1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnsearch);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateTimePickermonthnewpatient2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 61);
            this.panel2.TabIndex = 224;
            // 
            // slno
            // 
            this.slno.HeaderText = "SL.";
            this.slno.Name = "slno";
            this.slno.ReadOnly = true;
            this.slno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.slno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.slno.Width = 70;
            // 
            // pt_id
            // 
            this.pt_id.HeaderText = "PATIENT ID";
            this.pt_id.Name = "pt_id";
            this.pt_id.ReadOnly = true;
            this.pt_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // patient
            // 
            this.patient.HeaderText = "PATIENT NAME";
            this.patient.Name = "patient";
            this.patient.ReadOnly = true;
            this.patient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.patient.Width = 180;
            // 
            // Appoinment
            // 
            this.Appoinment.HeaderText = "APPOINTMENT DATE";
            this.Appoinment.Name = "Appoinment";
            this.Appoinment.ReadOnly = true;
            this.Appoinment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Appoinment.Width = 150;
            // 
            // Mobile
            // 
            this.Mobile.HeaderText = "MOBILE NO";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            this.Mobile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // emailaddress
            // 
            this.emailaddress.HeaderText = "EMAIL";
            this.emailaddress.Name = "emailaddress";
            this.emailaddress.ReadOnly = true;
            this.emailaddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.emailaddress.Width = 150;
            // 
            // Doctor
            // 
            this.Doctor.HeaderText = "DOCTOR";
            this.Doctor.Name = "Doctor";
            this.Doctor.ReadOnly = true;
            this.Doctor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Doctor.Width = 140;
            // 
            // nationality
            // 
            this.nationality.HeaderText = "NATIONALITY";
            this.nationality.Name = "nationality";
            this.nationality.ReadOnly = true;
            // 
            // passport_no
            // 
            this.passport_no.HeaderText = "PASSPORT NO";
            this.passport_no.Name = "passport_no";
            this.passport_no.ReadOnly = true;
            this.passport_no.Width = 200;
            // 
            // Monthly_New_Patients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Monthly_New_Patients";
            this.Text = "Monthly New Patients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Monthly_new_patients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridmonthlypatient)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartmonthnewpatient)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grvmonthnewpatient)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label lblNoRecord;
        private System.Windows.Forms.DataGridView dataGridmonthlypatient;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartmonthnewpatient;
        private System.Windows.Forms.Button btngrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Grvmonthnewpatient;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Lab_Doctorname;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button btnchart;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickermonthnewpatient1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickermonthnewpatient2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appoinment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Doctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn nationality;
        private System.Windows.Forms.DataGridViewTextBoxColumn passport_no;
    }
}