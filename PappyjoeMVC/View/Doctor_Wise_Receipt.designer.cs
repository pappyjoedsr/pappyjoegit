﻿namespace PappyjoeMVC.View
{
    partial class Doctor_Wise_Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doctor_Wise_Receipt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.Lab_tax = new System.Windows.Forms.Label();
            this.Lab_Discount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Lab_Amount = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Lab_Doctorname = new System.Windows.Forms.Label();
            this.combo_doctors = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.dtp1ReceptReceivedPerDoctor1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp1ReceptReceivedPerDoctor2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Export = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_empty = new System.Windows.Forms.Label();
            this.DgvReceiptReceivedPerDoctor = new System.Windows.Forms.DataGridView();
            this.slno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patient_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recept_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procedure_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mode_of_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax_inrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount_insr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.income = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_totalExpense = new System.Windows.Forms.Label();
            this.Lab_TotalIncome = new System.Windows.Forms.Label();
            this.Lab_Paid = new System.Windows.Forms.Label();
            this.Lab_Due = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReceiptReceivedPerDoctor)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(82, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 297;
            this.label9.Text = "Total Tax";
            // 
            // Lab_tax
            // 
            this.Lab_tax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_tax.AutoSize = true;
            this.Lab_tax.BackColor = System.Drawing.Color.Transparent;
            this.Lab_tax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_tax.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_tax.Location = new System.Drawing.Point(111, 33);
            this.Lab_tax.Name = "Lab_tax";
            this.Lab_tax.Size = new System.Drawing.Size(33, 17);
            this.Lab_tax.TabIndex = 296;
            this.Lab_tax.Text = "0.00";
            // 
            // Lab_Discount
            // 
            this.Lab_Discount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Discount.AutoSize = true;
            this.Lab_Discount.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Discount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Discount.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Discount.Location = new System.Drawing.Point(226, 33);
            this.Lab_Discount.Name = "Lab_Discount";
            this.Lab_Discount.Size = new System.Drawing.Size(33, 17);
            this.Lab_Discount.TabIndex = 294;
            this.Lab_Discount.Text = "0.00";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(277, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 293;
            this.label3.Text = "Total Amount";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(165, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 295;
            this.label7.Text = "Total Discount";
            // 
            // Lab_Amount
            // 
            this.Lab_Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Amount.AutoSize = true;
            this.Lab_Amount.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Amount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Amount.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Amount.Location = new System.Drawing.Point(333, 33);
            this.Lab_Amount.Name = "Lab_Amount";
            this.Lab_Amount.Size = new System.Drawing.Size(33, 17);
            this.Lab_Amount.TabIndex = 292;
            this.Lab_Amount.Text = "0.00";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.Lab_Doctorname);
            this.panel4.Controls.Add(this.combo_doctors);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(0, 102);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1372, 40);
            this.panel4.TabIndex = 258;
            // 
            // Lab_Doctorname
            // 
            this.Lab_Doctorname.AutoSize = true;
            this.Lab_Doctorname.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctorname.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctorname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctorname.Location = new System.Drawing.Point(765, 17);
            this.Lab_Doctorname.Name = "Lab_Doctorname";
            this.Lab_Doctorname.Size = new System.Drawing.Size(75, 13);
            this.Lab_Doctorname.TabIndex = 220;
            this.Lab_Doctorname.Text = "Doctor Name";
            // 
            // combo_doctors
            // 
            this.combo_doctors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_doctors.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.combo_doctors.FormattingEnabled = true;
            this.combo_doctors.Location = new System.Drawing.Point(843, 13);
            this.combo_doctors.Name = "combo_doctors";
            this.combo_doctors.Size = new System.Drawing.Size(155, 21);
            this.combo_doctors.TabIndex = 8;
            this.combo_doctors.SelectedIndexChanged += new System.EventHandler(this.combo_doctors_SelectedIndexChanged);
            this.combo_doctors.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.combo_doctors_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(694, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(574, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "TOTAL PATIENTS :";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(815, 54);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 32);
            this.btn_Close.TabIndex = 249;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(277, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(515, 54);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(100, 32);
            this.btn_search.TabIndex = 111;
            this.btn_search.Text = "Show";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Image = ((System.Drawing.Image)(resources.GetObject("btn_print.Image")));
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.Location = new System.Drawing.Point(615, 54);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(100, 32);
            this.btn_print.TabIndex = 11;
            this.btn_print.Text = "Print";
            this.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // dtp1ReceptReceivedPerDoctor1
            // 
            this.dtp1ReceptReceivedPerDoctor1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1ReceptReceivedPerDoctor1.Location = new System.Drawing.Point(64, 60);
            this.dtp1ReceptReceivedPerDoctor1.Name = "dtp1ReceptReceivedPerDoctor1";
            this.dtp1ReceptReceivedPerDoctor1.Size = new System.Drawing.Size(206, 22);
            this.dtp1ReceptReceivedPerDoctor1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(274, 40);
            this.label6.TabIndex = 1;
            this.label6.Text = "Doctor Wise Receipt";
            // 
            // dtp1ReceptReceivedPerDoctor2
            // 
            this.dtp1ReceptReceivedPerDoctor2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp1ReceptReceivedPerDoctor2.Location = new System.Drawing.Point(306, 59);
            this.dtp1ReceptReceivedPerDoctor2.Name = "dtp1ReceptReceivedPerDoctor2";
            this.dtp1ReceptReceivedPerDoctor2.Size = new System.Drawing.Size(203, 22);
            this.dtp1ReceptReceivedPerDoctor2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(17, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // Btn_Export
            // 
            this.Btn_Export.BackColor = System.Drawing.Color.DodgerBlue;
            this.Btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Export.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Export.ForeColor = System.Drawing.Color.White;
            this.Btn_Export.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Export.Location = new System.Drawing.Point(715, 54);
            this.Btn_Export.Name = "Btn_Export";
            this.Btn_Export.Size = new System.Drawing.Size(100, 32);
            this.Btn_Export.TabIndex = 250;
            this.Btn_Export.Text = "Export To Excel";
            this.Btn_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Export.UseVisualStyleBackColor = false;
            this.Btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label_empty);
            this.panel3.Controls.Add(this.DgvReceiptReceivedPerDoctor);
            this.panel3.Location = new System.Drawing.Point(0, 141);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1369, 492);
            this.panel3.TabIndex = 259;
            // 
            // label_empty
            // 
            this.label_empty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_empty.BackColor = System.Drawing.Color.Wheat;
            this.label_empty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_empty.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_empty.Location = new System.Drawing.Point(218, 238);
            this.label_empty.Name = "label_empty";
            this.label_empty.Size = new System.Drawing.Size(521, 25);
            this.label_empty.TabIndex = 97;
            this.label_empty.Text = "No Records Found. Please change the date and try again !";
            this.label_empty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvReceiptReceivedPerDoctor
            // 
            this.DgvReceiptReceivedPerDoctor.AllowUserToAddRows = false;
            this.DgvReceiptReceivedPerDoctor.AllowUserToDeleteRows = false;
            this.DgvReceiptReceivedPerDoctor.AllowUserToResizeColumns = false;
            this.DgvReceiptReceivedPerDoctor.AllowUserToResizeRows = false;
            this.DgvReceiptReceivedPerDoctor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvReceiptReceivedPerDoctor.BackgroundColor = System.Drawing.Color.White;
            this.DgvReceiptReceivedPerDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvReceiptReceivedPerDoctor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvReceiptReceivedPerDoctor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvReceiptReceivedPerDoctor.ColumnHeadersHeight = 30;
            this.DgvReceiptReceivedPerDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvReceiptReceivedPerDoctor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slno,
            this.Patient_name,
            this.invoice_no,
            this.recept_No,
            this.doctor_name,
            this.procedure_name,
            this.Payment_date,
            this.mode_of_payment,
            this.cost,
            this.tax_inrs,
            this.Discount_insr,
            this.income,
            this.amount_paid,
            this.amount_due});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvReceiptReceivedPerDoctor.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvReceiptReceivedPerDoctor.Location = new System.Drawing.Point(2, 1);
            this.DgvReceiptReceivedPerDoctor.Name = "DgvReceiptReceivedPerDoctor";
            this.DgvReceiptReceivedPerDoctor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvReceiptReceivedPerDoctor.RowHeadersVisible = false;
            this.DgvReceiptReceivedPerDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DgvReceiptReceivedPerDoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvReceiptReceivedPerDoctor.Size = new System.Drawing.Size(1364, 503);
            this.DgvReceiptReceivedPerDoctor.TabIndex = 0;
            // 
            // slno
            // 
            this.slno.HeaderText = "SLNO";
            this.slno.Name = "slno";
            this.slno.Width = 40;
            // 
            // Patient_name
            // 
            this.Patient_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Patient_name.HeaderText = "PATIENT ";
            this.Patient_name.Name = "Patient_name";
            // 
            // invoice_no
            // 
            this.invoice_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.invoice_no.HeaderText = "INVOICE";
            this.invoice_no.Name = "invoice_no";
            // 
            // recept_No
            // 
            this.recept_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.recept_No.HeaderText = "RECEIPT";
            this.recept_No.Name = "recept_No";
            // 
            // doctor_name
            // 
            this.doctor_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.doctor_name.HeaderText = "DOCTOR ";
            this.doctor_name.Name = "doctor_name";
            // 
            // procedure_name
            // 
            this.procedure_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.procedure_name.HeaderText = "PROCEDURE ";
            this.procedure_name.Name = "procedure_name";
            // 
            // Payment_date
            // 
            this.Payment_date.HeaderText = "DATE";
            this.Payment_date.Name = "Payment_date";
            this.Payment_date.Width = 80;
            // 
            // mode_of_payment
            // 
            this.mode_of_payment.HeaderText = "MODE OF PAYMENT";
            this.mode_of_payment.Name = "mode_of_payment";
            this.mode_of_payment.Width = 124;
            // 
            // cost
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cost.DefaultCellStyle = dataGridViewCellStyle1;
            this.cost.HeaderText = "COST";
            this.cost.Name = "cost";
            this.cost.Width = 75;
            // 
            // tax_inrs
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.tax_inrs.DefaultCellStyle = dataGridViewCellStyle2;
            this.tax_inrs.HeaderText = "TAX";
            this.tax_inrs.Name = "tax_inrs";
            this.tax_inrs.Width = 50;
            // 
            // Discount_insr
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Discount_insr.DefaultCellStyle = dataGridViewCellStyle3;
            this.Discount_insr.HeaderText = "DISCOUNT";
            this.Discount_insr.Name = "Discount_insr";
            this.Discount_insr.Width = 69;
            // 
            // income
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.income.DefaultCellStyle = dataGridViewCellStyle4;
            this.income.HeaderText = "TOTAL AMOUNT";
            this.income.Name = "income";
            // 
            // amount_paid
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount_paid.DefaultCellStyle = dataGridViewCellStyle5;
            this.amount_paid.HeaderText = "AMOUNT RECEIVED";
            this.amount_paid.Name = "amount_paid";
            this.amount_paid.Width = 118;
            // 
            // amount_due
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.amount_due.DefaultCellStyle = dataGridViewCellStyle6;
            this.amount_due.HeaderText = "AMOUNT DUE";
            this.amount_due.Name = "amount_due";
            this.amount_due.Width = 105;
            // 
            // Lab_totalExpense
            // 
            this.Lab_totalExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_totalExpense.AutoSize = true;
            this.Lab_totalExpense.BackColor = System.Drawing.Color.Transparent;
            this.Lab_totalExpense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_totalExpense.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_totalExpense.Location = new System.Drawing.Point(483, 10);
            this.Lab_totalExpense.Name = "Lab_totalExpense";
            this.Lab_totalExpense.Size = new System.Drawing.Size(65, 17);
            this.Lab_totalExpense.TabIndex = 291;
            this.Lab_totalExpense.Text = "Total Due";
            // 
            // Lab_TotalIncome
            // 
            this.Lab_TotalIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_TotalIncome.AutoSize = true;
            this.Lab_TotalIncome.BackColor = System.Drawing.Color.Transparent;
            this.Lab_TotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_TotalIncome.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_TotalIncome.Location = new System.Drawing.Point(394, 10);
            this.Lab_TotalIncome.Name = "Lab_TotalIncome";
            this.Lab_TotalIncome.Size = new System.Drawing.Size(67, 17);
            this.Lab_TotalIncome.TabIndex = 290;
            this.Lab_TotalIncome.Text = "Total Paid";
            // 
            // Lab_Paid
            // 
            this.Lab_Paid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Paid.AutoSize = true;
            this.Lab_Paid.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Paid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Paid.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Paid.Location = new System.Drawing.Point(420, 33);
            this.Lab_Paid.Name = "Lab_Paid";
            this.Lab_Paid.Size = new System.Drawing.Size(33, 17);
            this.Lab_Paid.TabIndex = 288;
            this.Lab_Paid.Text = "0.00";
            // 
            // Lab_Due
            // 
            this.Lab_Due.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Due.AutoSize = true;
            this.Lab_Due.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Due.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Due.ForeColor = System.Drawing.Color.Red;
            this.Lab_Due.Location = new System.Drawing.Point(507, 33);
            this.Lab_Due.Name = "Lab_Due";
            this.Lab_Due.Size = new System.Drawing.Size(33, 17);
            this.Lab_Due.TabIndex = 289;
            this.Lab_Due.Text = "0.00";
            this.Lab_Due.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.btn_print);
            this.panel1.Controls.Add(this.dtp1ReceptReceivedPerDoctor1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtp1ReceptReceivedPerDoctor2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Btn_Export);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 102);
            this.panel1.TabIndex = 257;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Location = new System.Drawing.Point(0, 654);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1369, 94);
            this.panel2.TabIndex = 298;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.Lab_tax);
            this.panel5.Controls.Add(this.Lab_TotalIncome);
            this.panel5.Controls.Add(this.Lab_totalExpense);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.Lab_Discount);
            this.panel5.Controls.Add(this.Lab_Due);
            this.panel5.Controls.Add(this.Lab_Paid);
            this.panel5.Controls.Add(this.Lab_Amount);
            this.panel5.Location = new System.Drawing.Point(807, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(560, 55);
            this.panel5.TabIndex = 119;
            // 
            // Doctor_Wise_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Doctor_Wise_Receipt";
            this.Text = "Doctor Wise Receipt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Doctor_Wise_Receipt_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReceiptReceivedPerDoctor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Lab_tax;
        private System.Windows.Forms.Label Lab_Discount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Lab_Amount;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Lab_Doctorname;
        private System.Windows.Forms.ComboBox combo_doctors;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DateTimePicker dtp1ReceptReceivedPerDoctor1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp1ReceptReceivedPerDoctor2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btn_Export;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_totalExpense;
        private System.Windows.Forms.Label Lab_TotalIncome;
        private System.Windows.Forms.Label Lab_Paid;
        private System.Windows.Forms.Label Lab_Due;
        private System.Windows.Forms.Label label_empty;
        private System.Windows.Forms.DataGridView DgvReceiptReceivedPerDoctor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn slno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patient_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoice_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn recept_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn procedure_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn mode_of_payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax_inrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount_insr;
        private System.Windows.Forms.DataGridViewTextBoxColumn income;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_due;
    }
}