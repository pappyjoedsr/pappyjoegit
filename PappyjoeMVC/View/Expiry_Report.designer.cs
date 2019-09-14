namespace PappyjoeMVC.View
{
    partial class Expiry_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Expiry_Report));
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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnExport = new System.Windows.Forms.Button();
            this.btnselect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dptTo = new System.Windows.Forms.DateTimePicker();
            this.dptFrom = new System.Windows.Forms.DateTimePicker();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgvExpiry = new System.Windows.Forms.DataGridView();
            this.col_slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grant_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.services = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMonthlyReports = new System.Windows.Forms.DataGridView();
            this.Dgv_ChartExpanse = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiry)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ChartExpanse)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(16, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Expiry Date Wise Stock Report";
            // 
            // BtnExport
            // 
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(9, 6);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 30);
            this.BtnExport.TabIndex = 215;
            this.BtnExport.Text = "Export to Excel";
            this.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(512, 65);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 124;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(277, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 123;
            this.label3.Text = "To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 122;
            this.label1.Text = "From";
            // 
            // dptTo
            // 
            this.dptTo.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptTo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptTo.Location = new System.Drawing.Point(309, 65);
            this.dptTo.Name = "dptTo";
            this.dptTo.Size = new System.Drawing.Size(197, 22);
            this.dptTo.TabIndex = 121;
            // 
            // dptFrom
            // 
            this.dptFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptFrom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptFrom.Location = new System.Drawing.Point(53, 65);
            this.dptFrom.Name = "dptFrom";
            this.dptFrom.Size = new System.Drawing.Size(201, 22);
            this.dptFrom.TabIndex = 120;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(130, 6);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 125;
            this.btnprint.Text = "Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgvExpiry);
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1300, 555);
            this.panel2.TabIndex = 126;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(366, 274);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 282;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // dgvExpiry
            // 
            this.dgvExpiry.AllowUserToAddRows = false;
            this.dgvExpiry.AllowUserToDeleteRows = false;
            this.dgvExpiry.AllowUserToResizeColumns = false;
            this.dgvExpiry.AllowUserToResizeRows = false;
            this.dgvExpiry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvExpiry.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExpiry.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvExpiry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExpiry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvExpiry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpiry.ColumnHeadersHeight = 28;
            this.dgvExpiry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvExpiry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_slno,
            this.ItemCode,
            this.ItemName,
            this.PurchNumber,
            this.PurchaseDate,
            this.BatchNumber,
            this.Quantity,
            this.ExpiryDate,
            this.ColSup});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExpiry.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExpiry.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvExpiry.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvExpiry.Location = new System.Drawing.Point(0, 0);
            this.dgvExpiry.MultiSelect = false;
            this.dgvExpiry.Name = "dgvExpiry";
            this.dgvExpiry.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExpiry.RowHeadersVisible = false;
            this.dgvExpiry.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvExpiry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvExpiry.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpiry.Size = new System.Drawing.Size(1300, 557);
            this.dgvExpiry.TabIndex = 118;
            // 
            // col_slno
            // 
            this.col_slno.DataPropertyName = "slno";
            this.col_slno.HeaderText = "SLNO";
            this.col_slno.Name = "col_slno";
            this.col_slno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "ITEM CODE";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "ITEM NAME";
            this.ItemName.Name = "ItemName";
            this.ItemName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PurchNumber
            // 
            this.PurchNumber.HeaderText = "PURCHASE NO";
            this.PurchNumber.Name = "PurchNumber";
            this.PurchNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.HeaderText = "PURCHASE DATE";
            this.PurchaseDate.Name = "PurchaseDate";
            this.PurchaseDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BatchNumber
            // 
            this.BatchNumber.HeaderText = "BATCH NUMBER";
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "QUANTITY";
            this.Quantity.Name = "Quantity";
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.HeaderText = "EXPIRY DATE";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSup
            // 
            this.ColSup.HeaderText = "SUPPLIER NAME";
            this.ColSup.Name = "ColSup";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Tomato;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.Location = new System.Drawing.Point(216, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 30);
            this.buttonClose.TabIndex = 214;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.BtnExport);
            this.panel4.Controls.Add(this.btnprint);
            this.panel4.Controls.Add(this.buttonClose);
            this.panel4.Location = new System.Drawing.Point(950, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(339, 42);
            this.panel4.TabIndex = 216;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnselect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dptTo);
            this.panel1.Controls.Add(this.dptFrom);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 99);
            this.panel1.TabIndex = 125;
            // 
            // due
            // 
            this.due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.due.DataPropertyName = "due";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.due.DefaultCellStyle = dataGridViewCellStyle2;
            this.due.FillWeight = 69.97183F;
            this.due.HeaderText = "AMOUNT DUE";
            this.due.Name = "due";
            this.due.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // total_payment
            // 
            this.total_payment.DataPropertyName = "Payment";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.total_payment.DefaultCellStyle = dataGridViewCellStyle3;
            this.total_payment.FillWeight = 138.7734F;
            this.total_payment.HeaderText = "TOTAL PAYMENT";
            this.total_payment.Name = "total_payment";
            this.total_payment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.total_payment.Width = 145;
            // 
            // grant_total
            // 
            this.grant_total.DataPropertyName = "Cost";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.grant_total.DefaultCellStyle = dataGridViewCellStyle4;
            this.grant_total.FillWeight = 95.35242F;
            this.grant_total.HeaderText = "TOTAL COST";
            this.grant_total.Name = "grant_total";
            this.grant_total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.grant_total.Width = 145;
            // 
            // Invoice_date
            // 
            this.Invoice_date.DataPropertyName = "date";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Invoice_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.Invoice_date.FillWeight = 89.46581F;
            this.Invoice_date.HeaderText = "INVOICE DATE";
            this.Invoice_date.Name = "Invoice_date";
            this.Invoice_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Invoice_date.Width = 125;
            // 
            // services
            // 
            this.services.DataPropertyName = "services";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.services.DefaultCellStyle = dataGridViewCellStyle6;
            this.services.HeaderText = "SERVICES";
            this.services.Name = "services";
            this.services.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.services.Width = 170;
            // 
            // invoice_no
            // 
            this.invoice_no.DataPropertyName = "invoice_no";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.invoice_no.DefaultCellStyle = dataGridViewCellStyle7;
            this.invoice_no.FillWeight = 159.3434F;
            this.invoice_no.HeaderText = "INVOICE";
            this.invoice_no.Name = "invoice_no";
            this.invoice_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.invoice_no.Width = 127;
            // 
            // doctor_name
            // 
            this.doctor_name.DataPropertyName = "doctor_name";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.doctor_name.DefaultCellStyle = dataGridViewCellStyle8;
            this.doctor_name.HeaderText = "DOCTOR";
            this.doctor_name.Name = "doctor_name";
            this.doctor_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.doctor_name.Width = 210;
            // 
            // pt_name
            // 
            this.pt_name.DataPropertyName = "pt_name";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pt_name.DefaultCellStyle = dataGridViewCellStyle9;
            this.pt_name.FillWeight = 166.1734F;
            this.pt_name.HeaderText = "PATIENT NAME";
            this.pt_name.Name = "pt_name";
            this.pt_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pt_name.Width = 210;
            // 
            // Slno
            // 
            this.Slno.DataPropertyName = "slno";
            this.Slno.HeaderText = "SLNO";
            this.Slno.Name = "Slno";
            this.Slno.Width = 70;
            // 
            // dgvMonthlyReports
            // 
            this.dgvMonthlyReports.AllowUserToAddRows = false;
            this.dgvMonthlyReports.AllowUserToDeleteRows = false;
            this.dgvMonthlyReports.AllowUserToResizeColumns = false;
            this.dgvMonthlyReports.AllowUserToResizeRows = false;
            this.dgvMonthlyReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMonthlyReports.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMonthlyReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMonthlyReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMonthlyReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMonthlyReports.ColumnHeadersHeight = 28;
            this.dgvMonthlyReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMonthlyReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Slno,
            this.pt_name,
            this.doctor_name,
            this.invoice_no,
            this.services,
            this.Invoice_date,
            this.grant_total,
            this.total_payment,
            this.due});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMonthlyReports.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMonthlyReports.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMonthlyReports.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvMonthlyReports.Location = new System.Drawing.Point(35, 216);
            this.dgvMonthlyReports.MultiSelect = false;
            this.dgvMonthlyReports.Name = "dgvMonthlyReports";
            this.dgvMonthlyReports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMonthlyReports.RowHeadersVisible = false;
            this.dgvMonthlyReports.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvMonthlyReports.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMonthlyReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMonthlyReports.Size = new System.Drawing.Size(1296, 556);
            this.dgvMonthlyReports.TabIndex = 124;
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
            this.Dgv_ChartExpanse.Size = new System.Drawing.Size(1300, 749);
            this.Dgv_ChartExpanse.TabIndex = 123;
            // 
            // Expiry_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMonthlyReports);
            this.Controls.Add(this.Dgv_ChartExpanse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Expiry_Report";
            this.Text = "Expiry_Report";
            this.Load += new System.EventHandler(this.Expiry_Report_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpiry)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonthlyReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ChartExpanse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptTo;
        private System.Windows.Forms.DateTimePicker dptFrom;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvExpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSup;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn due;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn grant_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn services;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Slno;
        private System.Windows.Forms.DataGridView dgvMonthlyReports;
        private System.Windows.Forms.DataGridView Dgv_ChartExpanse;
        private System.Windows.Forms.Label Lab_Msg;
    }
}