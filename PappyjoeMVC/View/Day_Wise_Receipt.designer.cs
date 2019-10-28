namespace PappyjoeMVC.View
{
    partial class Day_Wise_Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Day_Wise_Receipt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Lab_tax = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Lab_Discount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Dtp_ReceiptTO = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.DTP_From = new System.Windows.Forms.DateTimePicker();
            this.btn_Show = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Chk_RemoveAmountDue = new System.Windows.Forms.CheckBox();
            this.cmb_doctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.Lab_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Lab_Amount = new System.Windows.Forms.Label();
            this.Lab_totalExpense = new System.Windows.Forms.Label();
            this.Lab_TotalIncome = new System.Windows.Forms.Label();
            this.Lab_Paid = new System.Windows.Forms.Label();
            this.Lab_Due = new System.Windows.Forms.Label();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.DGV_Receipt = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ColSLNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProcedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModeofpayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotao_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COlDIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalIncome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Receipt)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lab_tax
            // 
            this.Lab_tax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_tax.AutoSize = true;
            this.Lab_tax.BackColor = System.Drawing.Color.White;
            this.Lab_tax.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_tax.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_tax.Location = new System.Drawing.Point(869, 527);
            this.Lab_tax.Name = "Lab_tax";
            this.Lab_tax.Size = new System.Drawing.Size(33, 17);
            this.Lab_tax.TabIndex = 286;
            this.Lab_tax.Text = "0.00";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(938, 508);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 285;
            this.label7.Text = "Total Discount";
            // 
            // Lab_Discount
            // 
            this.Lab_Discount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Discount.AutoSize = true;
            this.Lab_Discount.BackColor = System.Drawing.Color.White;
            this.Lab_Discount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Discount.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Discount.Location = new System.Drawing.Point(991, 527);
            this.Lab_Discount.Name = "Lab_Discount";
            this.Lab_Discount.Size = new System.Drawing.Size(33, 17);
            this.Lab_Discount.TabIndex = 284;
            this.Lab_Discount.Text = "0.00";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(849, 508);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 287;
            this.label9.Text = "Total Tax";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(1065, 508);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 283;
            this.label1.Text = "Total Amount";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Export);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Dtp_ReceiptTO);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.DTP_From);
            this.panel1.Controls.Add(this.btn_Show);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1374, 116);
            this.panel1.TabIndex = 104;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(815, 54);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 32);
            this.btn_Close.TabIndex = 111;
            this.btn_Close.Text = "Close";
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
            this.btn_Export.Location = new System.Drawing.Point(715, 54);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(100, 32);
            this.btn_Export.TabIndex = 11;
            this.btn_Export.Text = "Export To Excel";
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
            this.label6.Size = new System.Drawing.Size(236, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Day Wise Receipt";
            // 
            // Dtp_ReceiptTO
            // 
            this.Dtp_ReceiptTO.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_ReceiptTO.Location = new System.Drawing.Point(306, 59);
            this.Dtp_ReceiptTO.Name = "Dtp_ReceiptTO";
            this.Dtp_ReceiptTO.Size = new System.Drawing.Size(203, 22);
            this.Dtp_ReceiptTO.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(17, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(615, 54);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(100, 32);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // DTP_From
            // 
            this.DTP_From.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.DTP_From.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.DTP_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_From.Location = new System.Drawing.Point(64, 59);
            this.DTP_From.Name = "DTP_From";
            this.DTP_From.Size = new System.Drawing.Size(207, 22);
            this.DTP_From.TabIndex = 5;
            // 
            // btn_Show
            // 
            this.btn_Show.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_Show.ForeColor = System.Drawing.Color.White;
            this.btn_Show.Location = new System.Drawing.Point(515, 54);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(100, 32);
            this.btn_Show.TabIndex = 7;
            this.btn_Show.Text = "Show";
            this.btn_Show.UseVisualStyleBackColor = false;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(277, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "To";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.Chk_RemoveAmountDue);
            this.panel2.Controls.Add(this.cmb_doctor);
            this.panel2.Controls.Add(this.Lab_Doctor);
            this.panel2.Controls.Add(this.Lab_Total);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1377, 56);
            this.panel2.TabIndex = 105;
            // 
            // Chk_RemoveAmountDue
            // 
            this.Chk_RemoveAmountDue.AutoSize = true;
            this.Chk_RemoveAmountDue.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_RemoveAmountDue.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Chk_RemoveAmountDue.Location = new System.Drawing.Point(1028, 15);
            this.Chk_RemoveAmountDue.Name = "Chk_RemoveAmountDue";
            this.Chk_RemoveAmountDue.Size = new System.Drawing.Size(171, 17);
            this.Chk_RemoveAmountDue.TabIndex = 131;
            this.Chk_RemoveAmountDue.Text = "Remove patient amount due";
            this.Chk_RemoveAmountDue.UseVisualStyleBackColor = true;
            this.Chk_RemoveAmountDue.CheckedChanged += new System.EventHandler(this.Chk_RemoveAmountDue_CheckedChanged);
            // 
            // cmb_doctor
            // 
            this.cmb_doctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_doctor.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cmb_doctor.FormattingEnabled = true;
            this.cmb_doctor.Location = new System.Drawing.Point(843, 13);
            this.cmb_doctor.Name = "cmb_doctor";
            this.cmb_doctor.Size = new System.Drawing.Size(149, 21);
            this.cmb_doctor.TabIndex = 130;
            this.cmb_doctor.SelectedIndexChanged += new System.EventHandler(this.cmb_doctor_SelectedIndexChanged);
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(765, 17);
            this.Lab_Doctor.Name = "Lab_Doctor";
            this.Lab_Doctor.Size = new System.Drawing.Size(75, 13);
            this.Lab_Doctor.TabIndex = 129;
            this.Lab_Doctor.Text = "Doctor Name";
            // 
            // Lab_Total
            // 
            this.Lab_Total.AutoSize = true;
            this.Lab_Total.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Total.ForeColor = System.Drawing.Color.Red;
            this.Lab_Total.Location = new System.Drawing.Point(675, 15);
            this.Lab_Total.Name = "Lab_Total";
            this.Lab_Total.Size = new System.Drawing.Size(45, 17);
            this.Lab_Total.TabIndex = 2;
            this.Lab_Total.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(574, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // Lab_Amount
            // 
            this.Lab_Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Amount.AutoSize = true;
            this.Lab_Amount.BackColor = System.Drawing.Color.White;
            this.Lab_Amount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Amount.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Amount.Location = new System.Drawing.Point(1113, 527);
            this.Lab_Amount.Name = "Lab_Amount";
            this.Lab_Amount.Size = new System.Drawing.Size(33, 17);
            this.Lab_Amount.TabIndex = 282;
            this.Lab_Amount.Text = "0.00";
            // 
            // Lab_totalExpense
            // 
            this.Lab_totalExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_totalExpense.AutoSize = true;
            this.Lab_totalExpense.BackColor = System.Drawing.Color.White;
            this.Lab_totalExpense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_totalExpense.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_totalExpense.Location = new System.Drawing.Point(1291, 508);
            this.Lab_totalExpense.Name = "Lab_totalExpense";
            this.Lab_totalExpense.Size = new System.Drawing.Size(65, 17);
            this.Lab_totalExpense.TabIndex = 281;
            this.Lab_totalExpense.Text = "Total Due";
            // 
            // Lab_TotalIncome
            // 
            this.Lab_TotalIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_TotalIncome.AutoSize = true;
            this.Lab_TotalIncome.BackColor = System.Drawing.Color.White;
            this.Lab_TotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_TotalIncome.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_TotalIncome.Location = new System.Drawing.Point(1193, 508);
            this.Lab_TotalIncome.Name = "Lab_TotalIncome";
            this.Lab_TotalIncome.Size = new System.Drawing.Size(67, 17);
            this.Lab_TotalIncome.TabIndex = 280;
            this.Lab_TotalIncome.Text = "Total Paid";
            // 
            // Lab_Paid
            // 
            this.Lab_Paid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Paid.AutoSize = true;
            this.Lab_Paid.BackColor = System.Drawing.Color.White;
            this.Lab_Paid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Paid.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Paid.Location = new System.Drawing.Point(1219, 527);
            this.Lab_Paid.Name = "Lab_Paid";
            this.Lab_Paid.Size = new System.Drawing.Size(33, 17);
            this.Lab_Paid.TabIndex = 278;
            this.Lab_Paid.Text = "0.00";
            // 
            // Lab_Due
            // 
            this.Lab_Due.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Due.AutoSize = true;
            this.Lab_Due.BackColor = System.Drawing.Color.White;
            this.Lab_Due.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Due.ForeColor = System.Drawing.Color.Red;
            this.Lab_Due.Location = new System.Drawing.Point(1314, 527);
            this.Lab_Due.Name = "Lab_Due";
            this.Lab_Due.Size = new System.Drawing.Size(33, 17);
            this.Lab_Due.TabIndex = 279;
            this.Lab_Due.Text = "0.00";
            this.Lab_Due.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(289, 438);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            // 
            // DGV_Receipt
            // 
            this.DGV_Receipt.AllowUserToAddRows = false;
            this.DGV_Receipt.AllowUserToDeleteRows = false;
            this.DGV_Receipt.AllowUserToResizeColumns = false;
            this.DGV_Receipt.AllowUserToResizeRows = false;
            this.DGV_Receipt.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Receipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGV_Receipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGV_Receipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_Receipt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGV_Receipt.ColumnHeadersHeight = 28;
            this.DGV_Receipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV_Receipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSLNo,
            this.ColPtName,
            this.ColInv,
            this.ColReceipt,
            this.ColDrName,
            this.ColProcedure,
            this.DATE,
            this.ColModeofpayment,
            this.ColTotao_Cost,
            this.ColTax,
            this.COlDIS,
            this.ColTotalIncome,
            this.ColAmountPaid,
            this.ColTotalDue});
            this.DGV_Receipt.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Receipt.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGV_Receipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Receipt.GridColor = System.Drawing.Color.Gainsboro;
            this.DGV_Receipt.Location = new System.Drawing.Point(0, 0);
            this.DGV_Receipt.Name = "DGV_Receipt";
            this.DGV_Receipt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGV_Receipt.RowHeadersVisible = false;
            this.DGV_Receipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV_Receipt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_Receipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Receipt.Size = new System.Drawing.Size(1364, 578);
            this.DGV_Receipt.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.Lab_Due);
            this.panel4.Controls.Add(this.Lab_Paid);
            this.panel4.Controls.Add(this.Lab_tax);
            this.panel4.Controls.Add(this.Lab_Discount);
            this.panel4.Controls.Add(this.Lab_Amount);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.Lab_totalExpense);
            this.panel4.Controls.Add(this.Lab_TotalIncome);
            this.panel4.Controls.Add(this.Lab_Msg);
            this.panel4.Controls.Add(this.DGV_Receipt);
            this.panel4.Location = new System.Drawing.Point(0, 168);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1364, 578);
            this.panel4.TabIndex = 106;
            // 
            // ColSLNo
            // 
            this.ColSLNo.HeaderText = "SLNO";
            this.ColSLNo.Name = "ColSLNo";
            this.ColSLNo.Width = 40;
            // 
            // ColPtName
            // 
            this.ColPtName.HeaderText = "PATIENT ";
            this.ColPtName.Name = "ColPtName";
            this.ColPtName.Width = 150;
            // 
            // ColInv
            // 
            this.ColInv.HeaderText = "INVOICE ";
            this.ColInv.Name = "ColInv";
            this.ColInv.Width = 70;
            // 
            // ColReceipt
            // 
            this.ColReceipt.HeaderText = "RECEIPT ";
            this.ColReceipt.Name = "ColReceipt";
            this.ColReceipt.Width = 70;
            // 
            // ColDrName
            // 
            this.ColDrName.HeaderText = "DOCTOR ";
            this.ColDrName.Name = "ColDrName";
            this.ColDrName.Width = 125;
            // 
            // ColProcedure
            // 
            this.ColProcedure.HeaderText = "PROCEDURE";
            this.ColProcedure.Name = "ColProcedure";
            this.ColProcedure.Width = 180;
            // 
            // DATE
            // 
            this.DATE.HeaderText = " DATE";
            this.DATE.Name = "DATE";
            this.DATE.Width = 80;
            // 
            // ColModeofpayment
            // 
            this.ColModeofpayment.HeaderText = "MODE OF PAYMENT";
            this.ColModeofpayment.Name = "ColModeofpayment";
            this.ColModeofpayment.Width = 120;
            // 
            // ColTotao_Cost
            // 
            this.ColTotao_Cost.HeaderText = " COST";
            this.ColTotao_Cost.Name = "ColTotao_Cost";
            this.ColTotao_Cost.Width = 80;
            // 
            // ColTax
            // 
            this.ColTax.HeaderText = "TAX";
            this.ColTax.Name = "ColTax";
            this.ColTax.Width = 50;
            // 
            // COlDIS
            // 
            this.COlDIS.HeaderText = "DISCOUNT";
            this.COlDIS.Name = "COlDIS";
            this.COlDIS.Width = 76;
            // 
            // ColTotalIncome
            // 
            this.ColTotalIncome.HeaderText = "TOTAL AMOUNT";
            this.ColTotalIncome.Name = "ColTotalIncome";
            // 
            // ColAmountPaid
            // 
            this.ColAmountPaid.HeaderText = "AMOUNT RECEIVED";
            this.ColAmountPaid.Name = "ColAmountPaid";
            this.ColAmountPaid.Width = 120;
            // 
            // ColTotalDue
            // 
            this.ColTotalDue.HeaderText = "AMOUNT DUE";
            this.ColTotalDue.Name = "ColTotalDue";
            // 
            // Day_Wise_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Day_Wise_Receipt";
            this.Text = "Day Wise Receipt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Day_Wise_Receipt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Receipt)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lab_tax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Lab_Discount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker Dtp_ReceiptTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.DateTimePicker DTP_From;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox Chk_RemoveAmountDue;
        private System.Windows.Forms.ComboBox cmb_doctor;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.Label Lab_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Lab_Amount;
        private System.Windows.Forms.Label Lab_totalExpense;
        private System.Windows.Forms.Label Lab_TotalIncome;
        private System.Windows.Forms.Label Lab_Paid;
        private System.Windows.Forms.Label Lab_Due;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView DGV_Receipt;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSLNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProcedure;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModeofpayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotao_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn COlDIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalIncome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalDue;
    }
}