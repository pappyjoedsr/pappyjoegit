namespace PappyjoeMVC.View
{
    partial class Monthly_Invoice_Report
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Monthly_Invoice_Report));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnselect = new System.Windows.Forms.Button();
            this.lblNoRecord = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvMonthlyReports = new System.Windows.Forms.DataGridView();
            this.Sl_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grant_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DICOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LabTotal3 = new System.Windows.Forms.Label();
            this.lbltotal3 = new System.Windows.Forms.Label();
            this.lbltotal1 = new System.Windows.Forms.Label();
            this.lbltotal2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.combodoctors = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dptMonthly_To = new System.Windows.Forms.DateTimePicker();
            this.dptMonthly_From = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Tomato;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.Location = new System.Drawing.Point(300, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 32);
            this.buttonClose.TabIndex = 213;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Controls.Add(this.btnprint);
            this.panel4.Controls.Add(this.buttonClose);
            this.panel4.Controls.Add(this.btnselect);
            this.panel4.Location = new System.Drawing.Point(703, 52);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 36);
            this.panel4.TabIndex = 216;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(201, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 32);
            this.btnExport.TabIndex = 215;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(102, 2);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(100, 32);
            this.btnprint.TabIndex = 125;
            this.btnprint.Text = "Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(3, 2);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(100, 32);
            this.btnselect.TabIndex = 124;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // lblNoRecord
            // 
            this.lblNoRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoRecord.AutoSize = true;
            this.lblNoRecord.BackColor = System.Drawing.Color.Wheat;
            this.lblNoRecord.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecord.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblNoRecord.Location = new System.Drawing.Point(350, 203);
            this.lblNoRecord.Name = "lblNoRecord";
            this.lblNoRecord.Size = new System.Drawing.Size(506, 25);
            this.lblNoRecord.TabIndex = 251;
            this.lblNoRecord.Text = "No Records Found. Please change the Date and try again !..";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblNoRecord);
            this.panel3.Controls.Add(this.dgvMonthlyReports);
            this.panel3.Location = new System.Drawing.Point(4, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1361, 557);
            this.panel3.TabIndex = 125;
            // 
            // dgvMonthlyReports
            // 
            this.dgvMonthlyReports.AllowUserToAddRows = false;
            this.dgvMonthlyReports.AllowUserToDeleteRows = false;
            this.dgvMonthlyReports.AllowUserToResizeColumns = false;
            this.dgvMonthlyReports.AllowUserToResizeRows = false;
            this.dgvMonthlyReports.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMonthlyReports.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMonthlyReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonthlyReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMonthlyReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMonthlyReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMonthlyReports.ColumnHeadersHeight = 30;
            this.dgvMonthlyReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMonthlyReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sl_NO,
            this.pt_name,
            this.invoice_no,
            this.services,
            this.Invoice_date,
            this.doctor,
            this.grant_total,
            this.DICOUNT,
            this.AMOUNT,
            this.total_payment,
            this.due});
            this.dgvMonthlyReports.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMonthlyReports.Location = new System.Drawing.Point(-4, 0);
            this.dgvMonthlyReports.MultiSelect = false;
            this.dgvMonthlyReports.Name = "dgvMonthlyReports";
            this.dgvMonthlyReports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMonthlyReports.RowHeadersVisible = false;
            this.dgvMonthlyReports.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMonthlyReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMonthlyReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonthlyReports.Size = new System.Drawing.Size(1361, 555);
            this.dgvMonthlyReports.TabIndex = 118;
            // 
            // Sl_NO
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sl_NO.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sl_NO.FillWeight = 81.88065F;
            this.Sl_NO.HeaderText = "SLNO.";
            this.Sl_NO.Name = "Sl_NO";
            this.Sl_NO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sl_NO.Width = 60;
            // 
            // pt_name
            // 
            this.pt_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pt_name.DataPropertyName = "pt_name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pt_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.pt_name.FillWeight = 166.1734F;
            this.pt_name.HeaderText = "PATIENT NAME";
            this.pt_name.Name = "pt_name";
            this.pt_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invoice_no
            // 
            this.invoice_no.DataPropertyName = "invoice_no";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.invoice_no.DefaultCellStyle = dataGridViewCellStyle4;
            this.invoice_no.FillWeight = 159.3434F;
            this.invoice_no.HeaderText = "INVOICE";
            this.invoice_no.Name = "invoice_no";
            this.invoice_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.invoice_no.Width = 110;
            // 
            // services
            // 
            this.services.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.services.DataPropertyName = "services";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.services.DefaultCellStyle = dataGridViewCellStyle5;
            this.services.HeaderText = "SERVICES";
            this.services.Name = "services";
            this.services.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Invoice_date
            // 
            this.Invoice_date.DataPropertyName = "date";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Invoice_date.DefaultCellStyle = dataGridViewCellStyle6;
            this.Invoice_date.FillWeight = 89.46581F;
            this.Invoice_date.HeaderText = "INVOICE DATE";
            this.Invoice_date.Name = "Invoice_date";
            this.Invoice_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // doctor
            // 
            this.doctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doctor.HeaderText = "DOCTOR";
            this.doctor.Name = "doctor";
            // 
            // grant_total
            // 
            this.grant_total.DataPropertyName = "Cost";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.grant_total.DefaultCellStyle = dataGridViewCellStyle7;
            this.grant_total.FillWeight = 95.35242F;
            this.grant_total.HeaderText = "TREATMENT COST";
            this.grant_total.Name = "grant_total";
            this.grant_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DICOUNT
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DICOUNT.DefaultCellStyle = dataGridViewCellStyle8;
            this.DICOUNT.HeaderText = "DISCOUNT";
            this.DICOUNT.Name = "DICOUNT";
            // 
            // AMOUNT
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AMOUNT.DefaultCellStyle = dataGridViewCellStyle9;
            this.AMOUNT.HeaderText = "AMOUNT";
            this.AMOUNT.Name = "AMOUNT";
            // 
            // total_payment
            // 
            this.total_payment.DataPropertyName = "Payment";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.total_payment.DefaultCellStyle = dataGridViewCellStyle10;
            this.total_payment.FillWeight = 138.7734F;
            this.total_payment.HeaderText = "TOTAL PAYMENT";
            this.total_payment.Name = "total_payment";
            this.total_payment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total_payment.Width = 110;
            // 
            // due
            // 
            this.due.DataPropertyName = "due";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.due.DefaultCellStyle = dataGridViewCellStyle11;
            this.due.FillWeight = 69.97183F;
            this.due.HeaderText = "AMOUNT DUE";
            this.due.Name = "due";
            this.due.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(314, 40);
            this.label6.TabIndex = 214;
            this.label6.Text = "Monthly Invoice Report";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(0, 628);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1365, 94);
            this.panel2.TabIndex = 124;
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.LabTotal3);
            this.panel5.Controls.Add(this.lbltotal3);
            this.panel5.Controls.Add(this.lbltotal1);
            this.panel5.Controls.Add(this.lbltotal2);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(748, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(560, 55);
            this.panel5.TabIndex = 119;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(260, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 227;
            this.label2.Text = "Amount";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(469, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 224;
            this.label4.Text = "Amount Due";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(164, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 226;
            this.label5.Text = "Cost";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(355, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 17);
            this.label8.TabIndex = 225;
            this.label8.Text = "Total Payment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LabTotal3
            // 
            this.LabTotal3.AutoSize = true;
            this.LabTotal3.BackColor = System.Drawing.Color.Gainsboro;
            this.LabTotal3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabTotal3.ForeColor = System.Drawing.Color.Red;
            this.LabTotal3.Location = new System.Drawing.Point(260, 26);
            this.LabTotal3.Name = "LabTotal3";
            this.LabTotal3.Size = new System.Drawing.Size(40, 17);
            this.LabTotal3.TabIndex = 223;
            this.LabTotal3.Text = "00.00";
            this.LabTotal3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltotal3
            // 
            this.lbltotal3.AutoSize = true;
            this.lbltotal3.BackColor = System.Drawing.Color.Gainsboro;
            this.lbltotal3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal3.ForeColor = System.Drawing.Color.Red;
            this.lbltotal3.Location = new System.Drawing.Point(469, 26);
            this.lbltotal3.Name = "lbltotal3";
            this.lbltotal3.Size = new System.Drawing.Size(40, 17);
            this.lbltotal3.TabIndex = 219;
            this.lbltotal3.Text = "00.00";
            this.lbltotal3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltotal1
            // 
            this.lbltotal1.AutoSize = true;
            this.lbltotal1.BackColor = System.Drawing.Color.Gainsboro;
            this.lbltotal1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal1.ForeColor = System.Drawing.Color.Red;
            this.lbltotal1.Location = new System.Drawing.Point(164, 26);
            this.lbltotal1.Name = "lbltotal1";
            this.lbltotal1.Size = new System.Drawing.Size(40, 17);
            this.lbltotal1.TabIndex = 222;
            this.lbltotal1.Text = "00.00";
            this.lbltotal1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbltotal2
            // 
            this.lbltotal2.AutoSize = true;
            this.lbltotal2.BackColor = System.Drawing.Color.Gainsboro;
            this.lbltotal2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal2.ForeColor = System.Drawing.Color.Red;
            this.lbltotal2.Location = new System.Drawing.Point(355, 28);
            this.lbltotal2.Name = "lbltotal2";
            this.lbltotal2.Size = new System.Drawing.Size(40, 17);
            this.lbltotal2.TabIndex = 221;
            this.lbltotal2.Text = "00.00";
            this.lbltotal2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(73, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 220;
            this.label7.Text = "Total";
            // 
            // combodoctors
            // 
            this.combodoctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combodoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combodoctors.FormattingEnabled = true;
            this.combodoctors.Location = new System.Drawing.Point(36, 59);
            this.combodoctors.Name = "combodoctors";
            this.combodoctors.Size = new System.Drawing.Size(162, 21);
            this.combodoctors.TabIndex = 126;
            this.combodoctors.SelectedIndexChanged += new System.EventHandler(this.combodoctors_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(457, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 123;
            this.label3.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(201, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 122;
            this.label1.Text = "From";
            // 
            // dptMonthly_To
            // 
            this.dptMonthly_To.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Location = new System.Drawing.Point(490, 60);
            this.dptMonthly_To.Name = "dptMonthly_To";
            this.dptMonthly_To.Size = new System.Drawing.Size(197, 22);
            this.dptMonthly_To.TabIndex = 121;
            this.dptMonthly_To.CloseUp += new System.EventHandler(this.dptMonthly_To_CloseUp);
            // 
            // dptMonthly_From
            // 
            this.dptMonthly_From.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Location = new System.Drawing.Point(245, 59);
            this.dptMonthly_From.Name = "dptMonthly_From";
            this.dptMonthly_From.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_From.TabIndex = 120;
            this.dptMonthly_From.CloseUp += new System.EventHandler(this.dptMonthly_From_CloseUp);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.combodoctors);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dptMonthly_To);
            this.panel1.Controls.Add(this.dptMonthly_From);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 119);
            this.panel1.TabIndex = 123;
            // 
            // Monthly_Invoice_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Monthly_Invoice_Report";
            this.Text = "Monthly_Invoice_Report";
            this.Load += new System.EventHandler(this.Monthly_Invoice_Report_Load);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label lblNoRecord;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvMonthlyReports;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label LabTotal3;
        private System.Windows.Forms.Label lbltotal3;
        private System.Windows.Forms.Label lbltotal1;
        private System.Windows.Forms.Label lbltotal2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox combodoctors;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptMonthly_To;
        private System.Windows.Forms.DateTimePicker dptMonthly_From;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sl_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn services;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn grant_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn DICOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn due;

    }
}