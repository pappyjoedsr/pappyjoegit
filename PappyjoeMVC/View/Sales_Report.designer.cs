﻿namespace PappyjoeMVC.View
{
    partial class Sales_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Report));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTNClose = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.DGV_SALES = new System.Windows.Forms.DataGridView();
            this.Btn_Show = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Txtgrandtotal = new System.Windows.Forms.TextBox();
            this.dptMonthly_From = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txttotaldiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dptMonthly_To = new System.Windows.Forms.DateTimePicker();
            this.Txt_totalInvoice = new System.Windows.Forms.TextBox();
            this.lblinvoices = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cust_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeofpayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SALES)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Edit";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Visible = false;
            this.dataGridViewImageColumn2.Width = 33;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Print";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 38;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1370, 1);
            this.panel4.TabIndex = 182;
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(1059, 5);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 30);
            this.BtnExport.TabIndex = 298;
            this.BtnExport.Text = "EXPORT TO EXCEL";
            this.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 178;
            this.label3.Text = "SALES REPORT";
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(1180, 5);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 30);
            this.btnprint.TabIndex = 165;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.BtnExport);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.BTNClose);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1370, 49);
            this.panel3.TabIndex = 185;
            // 
            // BTNClose
            // 
            this.BTNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNClose.BackColor = System.Drawing.Color.Tomato;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.ForeColor = System.Drawing.Color.White;
            this.BTNClose.Location = new System.Drawing.Point(1272, 5);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 30);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // DGV_SALES
            // 
            this.DGV_SALES.AllowUserToAddRows = false;
            this.DGV_SALES.AllowUserToDeleteRows = false;
            this.DGV_SALES.AllowUserToResizeColumns = false;
            this.DGV_SALES.AllowUserToResizeRows = false;
            this.DGV_SALES.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SALES.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_SALES.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGV_SALES.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_SALES.ColumnHeadersHeight = 25;
            this.DGV_SALES.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_SALES.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.cust_number,
            this.cust_name,
            this.InvNumber,
            this.InvDate,
            this.modeofpayment,
            this.clDiscount,
            this.TotalAmount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_SALES.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_SALES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_SALES.GridColor = System.Drawing.Color.DimGray;
            this.DGV_SALES.Location = new System.Drawing.Point(0, 0);
            this.DGV_SALES.Name = "DGV_SALES";
            this.DGV_SALES.ReadOnly = true;
            this.DGV_SALES.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_SALES.RowHeadersVisible = false;
            this.DGV_SALES.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_SALES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_SALES.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_SALES.Size = new System.Drawing.Size(1370, 393);
            this.DGV_SALES.TabIndex = 0;
            this.DGV_SALES.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SALES_CellDoubleClick);
            // 
            // Btn_Show
            // 
            this.Btn_Show.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Show.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Show.ForeColor = System.Drawing.Color.White;
            this.Btn_Show.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Show.Location = new System.Drawing.Point(278, 43);
            this.Btn_Show.Name = "Btn_Show";
            this.Btn_Show.Size = new System.Drawing.Size(65, 22);
            this.Btn_Show.TabIndex = 299;
            this.Btn_Show.Text = "Show";
            this.Btn_Show.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Show.UseVisualStyleBackColor = false;
            this.Btn_Show.Click += new System.EventHandler(this.Btn_Show_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Txtgrandtotal
            // 
            this.Txtgrandtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtgrandtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtgrandtotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txtgrandtotal.Location = new System.Drawing.Point(1253, 51);
            this.Txtgrandtotal.Name = "Txtgrandtotal";
            this.Txtgrandtotal.ReadOnly = true;
            this.Txtgrandtotal.Size = new System.Drawing.Size(96, 25);
            this.Txtgrandtotal.TabIndex = 11;
            this.Txtgrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dptMonthly_From
            // 
            this.dptMonthly_From.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.dptMonthly_From.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_From.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.dptMonthly_From.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateGray;
            this.dptMonthly_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Location = new System.Drawing.Point(58, 10);
            this.dptMonthly_From.Name = "dptMonthly_From";
            this.dptMonthly_From.Size = new System.Drawing.Size(214, 22);
            this.dptMonthly_From.TabIndex = 167;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1179, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Grand Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(14, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 169;
            this.label6.Text = "From";
            // 
            // Txttotaldiscount
            // 
            this.Txttotaldiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txttotaldiscount.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotaldiscount.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txttotaldiscount.Location = new System.Drawing.Point(1253, 28);
            this.Txttotaldiscount.Name = "Txttotaldiscount";
            this.Txttotaldiscount.ReadOnly = true;
            this.Txttotaldiscount.Size = new System.Drawing.Size(96, 22);
            this.Txttotaldiscount.TabIndex = 9;
            this.Txttotaldiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Txttotaldiscount.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(1187, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Cost";
            this.label1.Visible = false;
            // 
            // dptMonthly_To
            // 
            this.dptMonthly_To.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.dptMonthly_To.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_To.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.dptMonthly_To.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateGray;
            this.dptMonthly_To.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Location = new System.Drawing.Point(58, 43);
            this.dptMonthly_To.Name = "dptMonthly_To";
            this.dptMonthly_To.Size = new System.Drawing.Size(214, 22);
            this.dptMonthly_To.TabIndex = 168;
            // 
            // Txt_totalInvoice
            // 
            this.Txt_totalInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_totalInvoice.Font = new System.Drawing.Font("Segoe UI Light", 8.25F);
            this.Txt_totalInvoice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txt_totalInvoice.Location = new System.Drawing.Point(1253, 5);
            this.Txt_totalInvoice.Name = "Txt_totalInvoice";
            this.Txt_totalInvoice.ReadOnly = true;
            this.Txt_totalInvoice.Size = new System.Drawing.Size(96, 22);
            this.Txt_totalInvoice.TabIndex = 2;
            this.Txt_totalInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblinvoices
            // 
            this.lblinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblinvoices.AutoSize = true;
            this.lblinvoices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinvoices.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblinvoices.Location = new System.Drawing.Point(1166, 10);
            this.lblinvoices.Name = "lblinvoices";
            this.lblinvoices.Size = new System.Drawing.Size(78, 15);
            this.lblinvoices.TabIndex = 0;
            this.lblinvoices.Text = "Total Invoices";
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "DEL";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Width = 30;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.Btn_Show);
            this.panel1.Controls.Add(this.Txtgrandtotal);
            this.panel1.Controls.Add(this.dptMonthly_From);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Txttotaldiscount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dptMonthly_To);
            this.panel1.Controls.Add(this.Txt_totalInvoice);
            this.panel1.Controls.Add(this.lblinvoices);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 82);
            this.panel1.TabIndex = 183;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(29, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 15);
            this.label5.TabIndex = 170;
            this.label5.Text = "To";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.DGV_SALES);
            this.panel2.Location = new System.Drawing.Point(0, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 393);
            this.panel2.TabIndex = 184;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(355, 183);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(563, 25);
            this.Lab_Msg.TabIndex = 281;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lab_Msg.Visible = false;
            // 
            // SLNO
            // 
            this.SLNO.HeaderText = "SLNO";
            this.SLNO.Name = "SLNO";
            this.SLNO.ReadOnly = true;
            this.SLNO.Width = 118;
            // 
            // cust_number
            // 
            this.cust_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cust_number.HeaderText = "CUSTOMER ID";
            this.cust_number.Name = "cust_number";
            this.cust_number.ReadOnly = true;
            // 
            // cust_name
            // 
            this.cust_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cust_name.HeaderText = "NAME";
            this.cust_name.Name = "cust_name";
            this.cust_name.ReadOnly = true;
            // 
            // InvNumber
            // 
            this.InvNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvNumber.HeaderText = "INVOICE NO";
            this.InvNumber.Name = "InvNumber";
            this.InvNumber.ReadOnly = true;
            // 
            // InvDate
            // 
            this.InvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvDate.HeaderText = "INVOICE DATE";
            this.InvDate.Name = "InvDate";
            this.InvDate.ReadOnly = true;
            // 
            // modeofpayment
            // 
            this.modeofpayment.HeaderText = "MODE OF PAYMENT";
            this.modeofpayment.Name = "modeofpayment";
            this.modeofpayment.ReadOnly = true;
            this.modeofpayment.Width = 150;
            // 
            // clDiscount
            // 
            this.clDiscount.HeaderText = "DISCOUNT (%)";
            this.clDiscount.Name = "clDiscount";
            this.clDiscount.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TOTAL  AMOUNT";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 118;
            // 
            // Sales_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 741);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales_Report";
            this.Text = "Sales Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sales_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SALES)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTNClose;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.DataGridView DGV_SALES;
        private System.Windows.Forms.Button Btn_Show;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TextBox Txtgrandtotal;
        private System.Windows.Forms.DateTimePicker dptMonthly_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txttotaldiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptMonthly_To;
        private System.Windows.Forms.TextBox Txt_totalInvoice;
        private System.Windows.Forms.Label lblinvoices;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn cust_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeofpayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
    }
}