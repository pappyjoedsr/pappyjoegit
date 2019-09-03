namespace PappyjoeMVC.View
{
    partial class Daily_Treatment_Count
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Daily_Treatment_Count));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.griddailyteatment = new System.Windows.Forms.DataGridView();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pa_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartdailytreatment = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Grvdailytreatment = new System.Windows.Forms.DataGridView();
            this.comboBoxdoctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerdailytreatment2 = new System.Windows.Forms.DateTimePicker();
            this.Chk_Cost = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerdailytreatment1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnviewchart = new System.Windows.Forms.Button();
            this.btngrddailytreatment = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddailyteatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdailytreatment)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvdailytreatment)).BeginInit();
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
            this.panel4.Controls.Add(this.griddailyteatment);
            this.panel4.Controls.Add(this.chartdailytreatment);
            this.panel4.Location = new System.Drawing.Point(1, 147);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1123, 570);
            this.panel4.TabIndex = 106;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(264, 193);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 278;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // griddailyteatment
            // 
            this.griddailyteatment.AllowUserToAddRows = false;
            this.griddailyteatment.AllowUserToResizeRows = false;
            this.griddailyteatment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.griddailyteatment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.griddailyteatment.BackgroundColor = System.Drawing.Color.White;
            this.griddailyteatment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.griddailyteatment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.griddailyteatment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.griddailyteatment.ColumnHeadersHeight = 28;
            this.griddailyteatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.griddailyteatment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sl,
            this.Pa_id,
            this.name,
            this.Date,
            this.services,
            this.doctr,
            this.cost});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.griddailyteatment.DefaultCellStyle = dataGridViewCellStyle1;
            this.griddailyteatment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.griddailyteatment.Location = new System.Drawing.Point(0, 1);
            this.griddailyteatment.Name = "griddailyteatment";
            this.griddailyteatment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.griddailyteatment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomLeft;
            this.griddailyteatment.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.griddailyteatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.griddailyteatment.Size = new System.Drawing.Size(1123, 570);
            this.griddailyteatment.TabIndex = 0;
            // 
            // sl
            // 
            this.sl.HeaderText = "SL";
            this.sl.Name = "sl";
            this.sl.Visible = false;
            // 
            // Pa_id
            // 
            this.Pa_id.HeaderText = "PATIENT ID";
            this.Pa_id.Name = "Pa_id";
            // 
            // name
            // 
            this.name.HeaderText = "PATIENT NAME";
            this.name.Name = "name";
            // 
            // Date
            // 
            this.Date.HeaderText = "DATE";
            this.Date.Name = "Date";
            // 
            // services
            // 
            this.services.HeaderText = "SERVICES";
            this.services.Name = "services";
            // 
            // doctr
            // 
            this.doctr.HeaderText = "DOCTOR";
            this.doctr.Name = "doctr";
            // 
            // cost
            // 
            this.cost.HeaderText = "COST";
            this.cost.Name = "cost";
            // 
            // chartdailytreatment
            // 
            this.chartdailytreatment.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chartdailytreatment.ChartAreas.Add(chartArea1);
            this.chartdailytreatment.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartdailytreatment.Legends.Add(legend1);
            this.chartdailytreatment.Location = new System.Drawing.Point(0, 0);
            this.chartdailytreatment.Name = "chartdailytreatment";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Treatment Count";
            this.chartdailytreatment.Series.Add(series1);
            this.chartdailytreatment.Size = new System.Drawing.Size(1123, 570);
            this.chartdailytreatment.TabIndex = 3;
            this.chartdailytreatment.Text = "chart1";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Grvdailytreatment);
            this.panel3.Location = new System.Drawing.Point(1125, 147);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 570);
            this.panel3.TabIndex = 105;
            // 
            // Grvdailytreatment
            // 
            this.Grvdailytreatment.AllowUserToAddRows = false;
            this.Grvdailytreatment.AllowUserToDeleteRows = false;
            this.Grvdailytreatment.AllowUserToResizeColumns = false;
            this.Grvdailytreatment.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.Grvdailytreatment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.Grvdailytreatment.BackgroundColor = System.Drawing.Color.White;
            this.Grvdailytreatment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvdailytreatment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvdailytreatment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvdailytreatment.ColumnHeadersHeight = 28;
            this.Grvdailytreatment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grvdailytreatment.DefaultCellStyle = dataGridViewCellStyle4;
            this.Grvdailytreatment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grvdailytreatment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.Grvdailytreatment.Location = new System.Drawing.Point(0, 0);
            this.Grvdailytreatment.Name = "Grvdailytreatment";
            this.Grvdailytreatment.RowHeadersVisible = false;
            this.Grvdailytreatment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Grvdailytreatment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvdailytreatment.Size = new System.Drawing.Size(232, 570);
            this.Grvdailytreatment.TabIndex = 0;
            this.Grvdailytreatment.DataSourceChanged += new System.EventHandler(this.Grvdailytreatment_DataSourceChanged);
            // 
            // comboBoxdoctor
            // 
            this.comboBoxdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdoctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.comboBoxdoctor.FormattingEnabled = true;
            this.comboBoxdoctor.Location = new System.Drawing.Point(783, 23);
            this.comboBoxdoctor.Name = "comboBoxdoctor";
            this.comboBoxdoctor.Size = new System.Drawing.Size(149, 21);
            this.comboBoxdoctor.TabIndex = 130;
            this.comboBoxdoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxdoctor_SelectedIndexChanged);
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(685, 24);
            this.Lab_Doctor.Name = "Lab_Doctor";
            this.Lab_Doctor.Size = new System.Drawing.Size(92, 17);
            this.Lab_Doctor.TabIndex = 129;
            this.Lab_Doctor.Text = "Doctor Name:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.comboBoxdoctor);
            this.panel2.Controls.Add(this.Lab_Doctor);
            this.panel2.Controls.Add(this.dateTimePickerdailytreatment2);
            this.panel2.Controls.Add(this.Chk_Cost);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimePickerdailytreatment1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnselect);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(1, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1351, 61);
            this.panel2.TabIndex = 104;
            // 
            // dateTimePickerdailytreatment2
            // 
            this.dateTimePickerdailytreatment2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailytreatment2.Location = new System.Drawing.Point(295, 20);
            this.dateTimePickerdailytreatment2.Name = "dateTimePickerdailytreatment2";
            this.dateTimePickerdailytreatment2.Size = new System.Drawing.Size(203, 22);
            this.dateTimePickerdailytreatment2.TabIndex = 6;
            // 
            // Chk_Cost
            // 
            this.Chk_Cost.AutoSize = true;
            this.Chk_Cost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Chk_Cost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_Cost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Chk_Cost.Location = new System.Drawing.Point(508, 24);
            this.Chk_Cost.Name = "Chk_Cost";
            this.Chk_Cost.Size = new System.Drawing.Size(77, 17);
            this.Chk_Cost.TabIndex = 97;
            this.Chk_Cost.Text = "With Cost";
            this.Chk_Cost.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "From:";
            // 
            // dateTimePickerdailytreatment1
            // 
            this.dateTimePickerdailytreatment1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailytreatment1.Location = new System.Drawing.Point(53, 21);
            this.dateTimePickerdailytreatment1.Name = "dateTimePickerdailytreatment1";
            this.dateTimePickerdailytreatment1.Size = new System.Drawing.Size(207, 22);
            this.dateTimePickerdailytreatment1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(266, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "To:";
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(592, 21);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 7;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1047, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(946, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1041, 46);
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
            this.btn_Export.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Export.Location = new System.Drawing.Point(841, 46);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(112, 30);
            this.btn_Export.TabIndex = 11;
            this.btn_Export.Text = "EXPORT TO EXCEL";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(309, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Daily Treatment Report";
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
            this.panel1.Size = new System.Drawing.Size(1351, 81);
            this.panel1.TabIndex = 103;
            // 
            // btnviewchart
            // 
            this.btnviewchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnviewchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnviewchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewchart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewchart.ForeColor = System.Drawing.Color.White;
            this.btnviewchart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.Location = new System.Drawing.Point(669, 46);
            this.btnviewchart.Name = "btnviewchart";
            this.btnviewchart.Size = new System.Drawing.Size(85, 30);
            this.btnviewchart.TabIndex = 1;
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
            this.btngrddailytreatment.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btngrddailytreatment.Location = new System.Drawing.Point(755, 46);
            this.btngrddailytreatment.Name = "btngrddailytreatment";
            this.btngrddailytreatment.Size = new System.Drawing.Size(85, 30);
            this.btngrddailytreatment.TabIndex = 10;
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
            this.btnprint.Location = new System.Drawing.Point(954, 46);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // Daily_treatment_count
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Daily_treatment_count";
            this.Text = "Daily Treatment Count";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Daily_treatment_count_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddailyteatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartdailytreatment)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grvdailytreatment)).EndInit();
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
        private System.Windows.Forms.DataGridView griddailyteatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pa_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn services;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctr;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartdailytreatment;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Grvdailytreatment;
        private System.Windows.Forms.ComboBox comboBoxdoctor;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailytreatment2;
        private System.Windows.Forms.CheckBox Chk_Cost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailytreatment1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnviewchart;
        private System.Windows.Forms.Button btngrddailytreatment;
    }
}