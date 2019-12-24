namespace PappyjoeMVC.View
{
    partial class Monthly_Expense_Report
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monthly_Expense_Report));
            this.dateTimePickerdailytreatment2 = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Dgv_ChartExpanse = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Cmb_AccountName = new System.Windows.Forms.ComboBox();
            this.Lab_Account = new System.Windows.Forms.Label();
            this.chk_Account = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.Dgv_Expense = new System.Windows.Forms.DataGridView();
            this.colSl_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLedger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoAmountCr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmountdr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart_monthlyExpense = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rad_Income = new System.Windows.Forms.RadioButton();
            this.Chk_Type = new System.Windows.Forms.CheckBox();
            this.rad_Expanse = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnviewchart = new System.Windows.Forms.Button();
            this.btngrddailytreatment = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePickerdailytreatment1 = new System.Windows.Forms.DateTimePicker();
            this.btnselect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ChartExpanse)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Expense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthlyExpense)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerdailytreatment2
            // 
            this.dateTimePickerdailytreatment2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailytreatment2.Location = new System.Drawing.Point(293, 21);
            this.dateTimePickerdailytreatment2.Name = "dateTimePickerdailytreatment2";
            this.dateTimePickerdailytreatment2.Size = new System.Drawing.Size(203, 22);
            this.dateTimePickerdailytreatment2.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.Dgv_ChartExpanse);
            this.panel4.Location = new System.Drawing.Point(1140, 147);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 570);
            this.panel4.TabIndex = 108;
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
            this.Dgv_ChartExpanse.GridColor = System.Drawing.Color.Gainsboro;
            this.Dgv_ChartExpanse.Location = new System.Drawing.Point(0, 0);
            this.Dgv_ChartExpanse.Name = "Dgv_ChartExpanse";
            this.Dgv_ChartExpanse.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Dgv_ChartExpanse.RowHeadersVisible = false;
            this.Dgv_ChartExpanse.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv_ChartExpanse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_ChartExpanse.Size = new System.Drawing.Size(226, 570);
            this.Dgv_ChartExpanse.TabIndex = 0;
            this.Dgv_ChartExpanse.DataSourceChanged += new System.EventHandler(this.Dgv_ChartExpanse_DataSourceChanged);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.Cmb_AccountName);
            this.panel6.Controls.Add(this.Lab_Account);
            this.panel6.Controls.Add(this.chk_Account);
            this.panel6.Location = new System.Drawing.Point(668, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(241, 62);
            this.panel6.TabIndex = 12;
            // 
            // Cmb_AccountName
            // 
            this.Cmb_AccountName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_AccountName.Enabled = false;
            this.Cmb_AccountName.FormattingEnabled = true;
            this.Cmb_AccountName.Location = new System.Drawing.Point(87, 35);
            this.Cmb_AccountName.Name = "Cmb_AccountName";
            this.Cmb_AccountName.Size = new System.Drawing.Size(149, 21);
            this.Cmb_AccountName.TabIndex = 130;
            this.Cmb_AccountName.SelectedIndexChanged += new System.EventHandler(this.Cmb_AccountName_SelectedIndexChanged);
            // 
            // Lab_Account
            // 
            this.Lab_Account.AutoSize = true;
            this.Lab_Account.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Account.Enabled = false;
            this.Lab_Account.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Account.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Account.Location = new System.Drawing.Point(3, 38);
            this.Lab_Account.Name = "Lab_Account";
            this.Lab_Account.Size = new System.Drawing.Size(81, 13);
            this.Lab_Account.TabIndex = 129;
            this.Lab_Account.Text = "Account Name";
            // 
            // chk_Account
            // 
            this.chk_Account.AutoSize = true;
            this.chk_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chk_Account.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Account.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chk_Account.Location = new System.Drawing.Point(5, 8);
            this.chk_Account.Name = "chk_Account";
            this.chk_Account.Size = new System.Drawing.Size(128, 17);
            this.chk_Account.TabIndex = 98;
            this.chk_Account.Text = "With Account Name";
            this.chk_Account.UseVisualStyleBackColor = false;
            this.chk_Account.CheckedChanged += new System.EventHandler(this.chk_Account_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Lab_Msg);
            this.panel3.Controls.Add(this.Dgv_Expense);
            this.panel3.Controls.Add(this.chart_monthlyExpense);
            this.panel3.Location = new System.Drawing.Point(1, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1138, 570);
            this.panel3.TabIndex = 109;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(288, 263);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(570, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lab_Msg.Visible = false;
            // 
            // Dgv_Expense
            // 
            this.Dgv_Expense.AllowUserToAddRows = false;
            this.Dgv_Expense.AllowUserToDeleteRows = false;
            this.Dgv_Expense.AllowUserToResizeColumns = false;
            this.Dgv_Expense.AllowUserToResizeRows = false;
            this.Dgv_Expense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Dgv_Expense.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Expense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Expense.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_Expense.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Expense.ColumnHeadersHeight = 28;
            this.Dgv_Expense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Expense.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSl_no,
            this.ColDate,
            this.colTransType,
            this.colLedger,
            this.ColAccountName,
            this.CoAmountCr,
            this.colAmountdr,
            this.ColDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv_Expense.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dgv_Expense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Expense.GridColor = System.Drawing.Color.Gainsboro;
            this.Dgv_Expense.Location = new System.Drawing.Point(0, 0);
            this.Dgv_Expense.Name = "Dgv_Expense";
            this.Dgv_Expense.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Expense.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv_Expense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Expense.Size = new System.Drawing.Size(1138, 570);
            this.Dgv_Expense.TabIndex = 9;
            this.Dgv_Expense.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.Dgv_Expense_RowPostPaint);
            // 
            // colSl_no
            // 
            this.colSl_no.DataPropertyName = "Sl_No";
            this.colSl_no.HeaderText = "SLNO";
            this.colSl_no.Name = "colSl_no";
            this.colSl_no.Visible = false;
            // 
            // ColDate
            // 
            this.ColDate.DataPropertyName = "date";
            this.ColDate.HeaderText = "DATE";
            this.ColDate.Name = "ColDate";
            // 
            // colTransType
            // 
            this.colTransType.DataPropertyName = "Type";
            this.colTransType.HeaderText = "TRANSACTION TYPE";
            this.colTransType.Name = "colTransType";
            // 
            // colLedger
            // 
            this.colLedger.DataPropertyName = "nameofperson";
            this.colLedger.HeaderText = "LEDGER";
            this.colLedger.Name = "colLedger";
            // 
            // ColAccountName
            // 
            this.ColAccountName.DataPropertyName = "expense_type";
            this.ColAccountName.HeaderText = "ACCOUNT NAME";
            this.ColAccountName.Name = "ColAccountName";
            // 
            // CoAmountCr
            // 
            this.CoAmountCr.DataPropertyName = "amount";
            this.CoAmountCr.HeaderText = "AMOUNT(Cr)";
            this.CoAmountCr.Name = "CoAmountCr";
            // 
            // colAmountdr
            // 
            this.colAmountdr.DataPropertyName = "amountincome";
            this.colAmountdr.HeaderText = "AMOUNT(Dr)";
            this.colAmountdr.Name = "colAmountdr";
            // 
            // ColDescription
            // 
            this.ColDescription.DataPropertyName = "description";
            this.ColDescription.HeaderText = "DESCRIPTION";
            this.ColDescription.Name = "ColDescription";
            // 
            // chart_monthlyExpense
            // 
            this.chart_monthlyExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea2.Name = "ChartArea1";
            this.chart_monthlyExpense.ChartAreas.Add(chartArea2);
            this.chart_monthlyExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart_monthlyExpense.Legends.Add(legend2);
            this.chart_monthlyExpense.Location = new System.Drawing.Point(0, 0);
            this.chart_monthlyExpense.Name = "chart_monthlyExpense";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "MonthlyExpense";
            this.chart_monthlyExpense.Series.Add(series2);
            this.chart_monthlyExpense.Size = new System.Drawing.Size(1138, 570);
            this.chart_monthlyExpense.TabIndex = 8;
            this.chart_monthlyExpense.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.rad_Income);
            this.panel5.Controls.Add(this.Chk_Type);
            this.panel5.Controls.Add(this.rad_Expanse);
            this.panel5.Location = new System.Drawing.Point(512, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(136, 59);
            this.panel5.TabIndex = 13;
            // 
            // rad_Income
            // 
            this.rad_Income.AutoSize = true;
            this.rad_Income.Enabled = false;
            this.rad_Income.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_Income.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rad_Income.Location = new System.Drawing.Point(71, 33);
            this.rad_Income.Name = "rad_Income";
            this.rad_Income.Size = new System.Drawing.Size(62, 17);
            this.rad_Income.TabIndex = 132;
            this.rad_Income.TabStop = true;
            this.rad_Income.Text = "Income";
            this.rad_Income.UseVisualStyleBackColor = true;
            // 
            // Chk_Type
            // 
            this.Chk_Type.AutoSize = true;
            this.Chk_Type.BackColor = System.Drawing.Color.Gainsboro;
            this.Chk_Type.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_Type.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Chk_Type.Location = new System.Drawing.Point(5, 8);
            this.Chk_Type.Name = "Chk_Type";
            this.Chk_Type.Size = new System.Drawing.Size(77, 17);
            this.Chk_Type.TabIndex = 97;
            this.Chk_Type.Text = "With Type";
            this.Chk_Type.UseVisualStyleBackColor = false;
            this.Chk_Type.CheckedChanged += new System.EventHandler(this.Chk_Type_CheckedChanged);
            // 
            // rad_Expanse
            // 
            this.rad_Expanse.AutoSize = true;
            this.rad_Expanse.Enabled = false;
            this.rad_Expanse.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rad_Expanse.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.rad_Expanse.Location = new System.Drawing.Point(4, 34);
            this.rad_Expanse.Name = "rad_Expanse";
            this.rad_Expanse.Size = new System.Drawing.Size(67, 17);
            this.rad_Expanse.TabIndex = 131;
            this.rad_Expanse.TabStop = true;
            this.rad_Expanse.Text = "Expense";
            this.rad_Expanse.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
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
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 77);
            this.panel1.TabIndex = 106;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1050, 43);
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
            this.btn_Export.Location = new System.Drawing.Point(847, 43);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(116, 30);
            this.btn_Export.TabIndex = 11;
            this.btn_Export.Text = "EXPORT TO EXCEL";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(358, 45);
            this.label6.TabIndex = 0;
            this.label6.Text = "Monthly Expense Count";
            // 
            // btnviewchart
            // 
            this.btnviewchart.BackColor = System.Drawing.Color.LimeGreen;
            this.btnviewchart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnviewchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewchart.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewchart.ForeColor = System.Drawing.Color.White;
            this.btnviewchart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnviewchart.Location = new System.Drawing.Point(675, 43);
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
            this.btngrddailytreatment.Location = new System.Drawing.Point(761, 43);
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
            this.btnprint.Location = new System.Drawing.Point(964, 43);
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
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.dateTimePickerdailytreatment2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimePickerdailytreatment1);
            this.panel2.Controls.Add(this.btnselect);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(2, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1365, 65);
            this.panel2.TabIndex = 107;
            // 
            // dateTimePickerdailytreatment1
            // 
            this.dateTimePickerdailytreatment1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailytreatment1.Location = new System.Drawing.Point(51, 21);
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
            this.btnselect.Location = new System.Drawing.Point(935, 21);
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
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(265, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1141, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(1037, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // Monthly_Expense_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Monthly_Expense_Report";
            this.Text = "Monthly Expense Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Monthly_Expense_Report_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ChartExpanse)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Expense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_monthlyExpense)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerdailytreatment2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView Dgv_ChartExpanse;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox Cmb_AccountName;
        private System.Windows.Forms.Label Lab_Account;
        private System.Windows.Forms.CheckBox chk_Account;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView Dgv_Expense;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSl_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLedger;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoAmountCr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmountdr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDescription;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_monthlyExpense;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rad_Income;
        private System.Windows.Forms.CheckBox Chk_Type;
        private System.Windows.Forms.RadioButton rad_Expanse;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnviewchart;
        private System.Windows.Forms.Button btngrddailytreatment;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailytreatment1;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}