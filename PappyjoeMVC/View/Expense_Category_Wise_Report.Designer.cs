namespace PappyjoeMVC.View
{
    partial class Expense_Category_Wise_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expense_Category_Wise_Report));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnviewchart = new System.Windows.Forms.Button();
            this.btngrddailytreatment = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Cmb_AccountName = new System.Windows.Forms.ComboBox();
            this.Lab_Account = new System.Windows.Forms.Label();
            this.chk_Account = new System.Windows.Forms.CheckBox();
            this.Cmb_Ledger = new System.Windows.Forms.ComboBox();
            this.dateTimePickerdailytreatment2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerdailytreatment1 = new System.Windows.Forms.DateTimePicker();
            this.btnselect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Lab_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.Dgv_Expanse = new System.Windows.Forms.DataGridView();
            this.chart_EXpanse = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Dgv_ChartExpanse = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Expanse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_EXpanse)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ChartExpanse)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Export);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnviewchart);
            this.panel1.Controls.Add(this.btngrddailytreatment);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 77);
            this.panel1.TabIndex = 134;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1056, 44);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 112;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Export.ForeColor = System.Drawing.Color.White;
            this.btn_Export.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_Export.Location = new System.Drawing.Point(839, 44);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(132, 30);
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
            this.label6.Location = new System.Drawing.Point(5, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(406, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Category Wise Expense Report";
            // 
            // btnviewchart
            // 
            this.btnviewchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnviewchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnviewchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewchart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewchart.ForeColor = System.Drawing.Color.White;
            this.btnviewchart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.Location = new System.Drawing.Point(659, 44);
            this.btnviewchart.Name = "btnviewchart";
            this.btnviewchart.Size = new System.Drawing.Size(94, 30);
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
            this.btngrddailytreatment.Location = new System.Drawing.Point(754, 44);
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
            this.btnprint.BackColor = System.Drawing.Color.LimeGreen;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(971, 44);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.Cmb_Ledger);
            this.panel2.Controls.Add(this.dateTimePickerdailytreatment2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimePickerdailytreatment1);
            this.panel2.Controls.Add(this.btnselect);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Lab_Total);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(2, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1367, 66);
            this.panel2.TabIndex = 135;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(515, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 132;
            this.label1.Text = "Ledger:";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.Cmb_AccountName);
            this.panel6.Controls.Add(this.Lab_Account);
            this.panel6.Controls.Add(this.chk_Account);
            this.panel6.Location = new System.Drawing.Point(789, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(268, 60);
            this.panel6.TabIndex = 12;
            // 
            // Cmb_AccountName
            // 
            this.Cmb_AccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_AccountName.Enabled = false;
            this.Cmb_AccountName.FormattingEnabled = true;
            this.Cmb_AccountName.Location = new System.Drawing.Point(87, 26);
            this.Cmb_AccountName.Name = "Cmb_AccountName";
            this.Cmb_AccountName.Size = new System.Drawing.Size(164, 21);
            this.Cmb_AccountName.TabIndex = 130;
            this.Cmb_AccountName.SelectedIndexChanged += new System.EventHandler(this.Cmb_AccountName_SelectedIndexChanged);
            // 
            // Lab_Account
            // 
            this.Lab_Account.AutoSize = true;
            this.Lab_Account.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Account.Enabled = false;
            this.Lab_Account.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Account.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Account.Location = new System.Drawing.Point(7, 29);
            this.Lab_Account.Name = "Lab_Account";
            this.Lab_Account.Size = new System.Drawing.Size(80, 13);
            this.Lab_Account.TabIndex = 129;
            this.Lab_Account.Text = "Account Name";
            // 
            // chk_Account
            // 
            this.chk_Account.AutoSize = true;
            this.chk_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_Account.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Account.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chk_Account.Location = new System.Drawing.Point(5, 6);
            this.chk_Account.Name = "chk_Account";
            this.chk_Account.Size = new System.Drawing.Size(126, 17);
            this.chk_Account.TabIndex = 98;
            this.chk_Account.Text = "With Account Name";
            this.chk_Account.UseVisualStyleBackColor = false;
            this.chk_Account.CheckedChanged += new System.EventHandler(this.chk_Account_CheckedChanged);
            // 
            // Cmb_Ledger
            // 
            this.Cmb_Ledger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Ledger.FormattingEnabled = true;
            this.Cmb_Ledger.Location = new System.Drawing.Point(572, 23);
            this.Cmb_Ledger.Name = "Cmb_Ledger";
            this.Cmb_Ledger.Size = new System.Drawing.Size(207, 21);
            this.Cmb_Ledger.TabIndex = 131;
            this.Cmb_Ledger.SelectedIndexChanged += new System.EventHandler(this.Cmb_Ledger_SelectedIndexChanged);
            // 
            // dateTimePickerdailytreatment2
            // 
            this.dateTimePickerdailytreatment2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailytreatment2.Location = new System.Drawing.Point(303, 21);
            this.dateTimePickerdailytreatment2.Name = "dateTimePickerdailytreatment2";
            this.dateTimePickerdailytreatment2.Size = new System.Drawing.Size(207, 22);
            this.dateTimePickerdailytreatment2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(8, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "From:";
            // 
            // dateTimePickerdailytreatment1
            // 
            this.dateTimePickerdailytreatment1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailytreatment1.Location = new System.Drawing.Point(54, 22);
            this.dateTimePickerdailytreatment1.Name = "dateTimePickerdailytreatment1";
            this.dateTimePickerdailytreatment1.Size = new System.Drawing.Size(207, 22);
            this.dateTimePickerdailytreatment1.TabIndex = 5;
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(1074, 23);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 7;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(273, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "To:";
            // 
            // Lab_Total
            // 
            this.Lab_Total.AutoSize = true;
            this.Lab_Total.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Total.ForeColor = System.Drawing.Color.Red;
            this.Lab_Total.Location = new System.Drawing.Point(1287, 27);
            this.Lab_Total.Name = "Lab_Total";
            this.Lab_Total.Size = new System.Drawing.Size(45, 17);
            this.Lab_Total.TabIndex = 2;
            this.Lab_Total.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(1171, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Lab_Msg);
            this.panel3.Controls.Add(this.Dgv_Expanse);
            this.panel3.Controls.Add(this.chart_EXpanse);
            this.panel3.Location = new System.Drawing.Point(3, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1138, 536);
            this.panel3.TabIndex = 136;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(309, 219);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 278;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // Dgv_Expanse
            // 
            this.Dgv_Expanse.AllowUserToAddRows = false;
            this.Dgv_Expanse.AllowUserToDeleteRows = false;
            this.Dgv_Expanse.AllowUserToResizeColumns = false;
            this.Dgv_Expanse.AllowUserToResizeRows = false;
            this.Dgv_Expanse.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Expanse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Expanse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_Expanse.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Expanse.ColumnHeadersHeight = 28;
            this.Dgv_Expanse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Expanse.DefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Expanse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Expanse.GridColor = System.Drawing.Color.Gainsboro;
            this.Dgv_Expanse.Location = new System.Drawing.Point(0, 0);
            this.Dgv_Expanse.Name = "Dgv_Expanse";
            this.Dgv_Expanse.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Expanse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv_Expanse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Expanse.Size = new System.Drawing.Size(1138, 536);
            this.Dgv_Expanse.TabIndex = 3;
            // 
            // chart_EXpanse
            // 
            this.chart_EXpanse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chart_EXpanse.ChartAreas.Add(chartArea1);
            this.chart_EXpanse.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_EXpanse.Legends.Add(legend1);
            this.chart_EXpanse.Location = new System.Drawing.Point(0, 0);
            this.chart_EXpanse.Name = "chart_EXpanse";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Expense Count";
            this.chart_EXpanse.Series.Add(series1);
            this.chart_EXpanse.Size = new System.Drawing.Size(1138, 536);
            this.chart_EXpanse.TabIndex = 2;
            this.chart_EXpanse.Text = "chart1";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Dgv_ChartExpanse);
            this.panel4.Location = new System.Drawing.Point(1143, 148);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 507);
            this.panel4.TabIndex = 137;
            // 
            // Dgv_ChartExpanse
            // 
            this.Dgv_ChartExpanse.AllowUserToAddRows = false;
            this.Dgv_ChartExpanse.AllowUserToDeleteRows = false;
            this.Dgv_ChartExpanse.AllowUserToResizeColumns = false;
            this.Dgv_ChartExpanse.AllowUserToResizeRows = false;
            this.Dgv_ChartExpanse.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_ChartExpanse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_ChartExpanse.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_ChartExpanse.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Dgv_ChartExpanse.ColumnHeadersHeight = 28;
            this.Dgv_ChartExpanse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_ChartExpanse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_ChartExpanse.Location = new System.Drawing.Point(0, 0);
            this.Dgv_ChartExpanse.Name = "Dgv_ChartExpanse";
            this.Dgv_ChartExpanse.RowHeadersVisible = false;
            this.Dgv_ChartExpanse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv_ChartExpanse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_ChartExpanse.Size = new System.Drawing.Size(226, 507);
            this.Dgv_ChartExpanse.TabIndex = 0;
            this.Dgv_ChartExpanse.DataSourceChanged += new System.EventHandler(this.Dgv_ChartExpanse_DataSourceChanged);
            // 
            // Expense_Category_Wise_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Expense_Category_Wise_Report";
            this.Text = "Expense Category Wise Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Expense_Category_Wise_Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Expanse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_EXpanse)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ChartExpanse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnviewchart;
        private System.Windows.Forms.Button btngrddailytreatment;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox Cmb_AccountName;
        private System.Windows.Forms.Label Lab_Account;
        private System.Windows.Forms.CheckBox chk_Account;
        private System.Windows.Forms.ComboBox Cmb_Ledger;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailytreatment2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailytreatment1;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Lab_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView Dgv_Expanse;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_EXpanse;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView Dgv_ChartExpanse;
    }
}