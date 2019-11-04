namespace PappyjoeMVC.View
{
    partial class Paymode_Wise_Receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paymode_Wise_Receipt));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Lab_Amount = new System.Windows.Forms.Label();
            this.Lab_totalExpense = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Lab_TotalIncome = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Cmb_Modeofpayment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Chk_RemoveAmountDue = new System.Windows.Forms.CheckBox();
            this.cmb_doctor = new System.Windows.Forms.ComboBox();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.Lab_Total = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.btn_Show = new System.Windows.Forms.Button();
            this.Dtp_ReceiptTO = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DTP_From = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.Dgv_Receipt = new System.Windows.Forms.DataGridView();
            this.ColSLNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPt_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colinvo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReceipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProcedure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModeOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COl4Digit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColamountPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTAmountDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_Paid = new System.Windows.Forms.Label();
            this.Lab_Due = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Receipt)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // Lab_Amount
            // 
            this.Lab_Amount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Amount.AutoSize = true;
            this.Lab_Amount.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Amount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Amount.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Amount.Location = new System.Drawing.Point(247, 33);
            this.Lab_Amount.Name = "Lab_Amount";
            this.Lab_Amount.Size = new System.Drawing.Size(33, 17);
            this.Lab_Amount.TabIndex = 298;
            this.Lab_Amount.Text = "0.00";
            // 
            // Lab_totalExpense
            // 
            this.Lab_totalExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_totalExpense.AutoSize = true;
            this.Lab_totalExpense.BackColor = System.Drawing.Color.Transparent;
            this.Lab_totalExpense.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_totalExpense.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_totalExpense.Location = new System.Drawing.Point(425, 7);
            this.Lab_totalExpense.Name = "Lab_totalExpense";
            this.Lab_totalExpense.Size = new System.Drawing.Size(65, 17);
            this.Lab_totalExpense.TabIndex = 297;
            this.Lab_totalExpense.Text = "Total Due";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(201, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 299;
            this.label2.Text = "Total Amount";
            // 
            // Lab_TotalIncome
            // 
            this.Lab_TotalIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_TotalIncome.AutoSize = true;
            this.Lab_TotalIncome.BackColor = System.Drawing.Color.Transparent;
            this.Lab_TotalIncome.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_TotalIncome.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_TotalIncome.Location = new System.Drawing.Point(319, 7);
            this.Lab_TotalIncome.Name = "Lab_TotalIncome";
            this.Lab_TotalIncome.Size = new System.Drawing.Size(67, 17);
            this.Lab_TotalIncome.TabIndex = 296;
            this.Lab_TotalIncome.Text = "Total Paid";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.Cmb_Modeofpayment);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Chk_RemoveAmountDue);
            this.panel2.Controls.Add(this.cmb_doctor);
            this.panel2.Controls.Add(this.Lab_Doctor);
            this.panel2.Controls.Add(this.Lab_Total);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(0, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1369, 47);
            this.panel2.TabIndex = 105;
            // 
            // Cmb_Modeofpayment
            // 
            this.Cmb_Modeofpayment.BackColor = System.Drawing.Color.LightGray;
            this.Cmb_Modeofpayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Modeofpayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmb_Modeofpayment.FormattingEnabled = true;
            this.Cmb_Modeofpayment.Items.AddRange(new object[] {
            "All",
            "Cash",
            "Cheque",
            "Card",
            "Demand Draft"});
            this.Cmb_Modeofpayment.Location = new System.Drawing.Point(1206, 20);
            this.Cmb_Modeofpayment.Name = "Cmb_Modeofpayment";
            this.Cmb_Modeofpayment.Size = new System.Drawing.Size(149, 21);
            this.Cmb_Modeofpayment.TabIndex = 133;
            this.Cmb_Modeofpayment.SelectedIndexChanged += new System.EventHandler(this.Cmb_Modeofpayment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(1204, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 132;
            this.label1.Text = "Mode of Payment";
            // 
            // Chk_RemoveAmountDue
            // 
            this.Chk_RemoveAmountDue.AutoSize = true;
            this.Chk_RemoveAmountDue.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_RemoveAmountDue.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Chk_RemoveAmountDue.Location = new System.Drawing.Point(1028, 13);
            this.Chk_RemoveAmountDue.Name = "Chk_RemoveAmountDue";
            this.Chk_RemoveAmountDue.Size = new System.Drawing.Size(172, 17);
            this.Chk_RemoveAmountDue.TabIndex = 131;
            this.Chk_RemoveAmountDue.Text = "Remove patient amount due";
            this.Chk_RemoveAmountDue.UseVisualStyleBackColor = true;
            this.Chk_RemoveAmountDue.CheckedChanged += new System.EventHandler(this.Chk_RemoveAmountDue_CheckedChanged);
            // 
            // cmb_doctor
            // 
            this.cmb_doctor.BackColor = System.Drawing.Color.LightGray;
            this.cmb_doctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_doctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_doctor.FormattingEnabled = true;
            this.cmb_doctor.Location = new System.Drawing.Point(843, 11);
            this.cmb_doctor.Name = "cmb_doctor";
            this.cmb_doctor.Size = new System.Drawing.Size(149, 21);
            this.cmb_doctor.TabIndex = 130;
            this.cmb_doctor.SelectedIndexChanged += new System.EventHandler(this.cmb_doctor_SelectedIndexChanged);
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(765, 15);
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
            this.Lab_Total.Location = new System.Drawing.Point(675, 13);
            this.Lab_Total.Name = "Lab_Total";
            this.Lab_Total.Size = new System.Drawing.Size(45, 17);
            this.Lab_Total.TabIndex = 2;
            this.Lab_Total.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(574, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "TOTAL COUNT:";
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(815, 53);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 32);
            this.btn_Close.TabIndex = 130;
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
            this.btn_Export.Location = new System.Drawing.Point(715, 53);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(100, 32);
            this.btn_Export.TabIndex = 11;
            this.btn_Export.Text = "Export To Excel";
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(318, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pay-Mode Wise Receipt";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(615, 53);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(100, 32);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btn_Show
            // 
            this.btn_Show.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Show.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btn_Show.ForeColor = System.Drawing.Color.White;
            this.btn_Show.Location = new System.Drawing.Point(515, 53);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(100, 32);
            this.btn_Show.TabIndex = 7;
            this.btn_Show.Text = "Show";
            this.btn_Show.UseVisualStyleBackColor = false;
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // Dtp_ReceiptTO
            // 
            this.Dtp_ReceiptTO.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dtp_ReceiptTO.Location = new System.Drawing.Point(306, 60);
            this.Dtp_ReceiptTO.Name = "Dtp_ReceiptTO";
            this.Dtp_ReceiptTO.Size = new System.Drawing.Size(203, 22);
            this.Dtp_ReceiptTO.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(17, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(277, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "To";
            // 
            // DTP_From
            // 
            this.DTP_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTP_From.Location = new System.Drawing.Point(64, 63);
            this.DTP_From.Name = "DTP_From";
            this.DTP_From.Size = new System.Drawing.Size(207, 22);
            this.DTP_From.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.Lab_Msg);
            this.panel3.Controls.Add(this.Dgv_Receipt);
            this.panel3.Location = new System.Drawing.Point(0, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1369, 489);
            this.panel3.TabIndex = 106;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(311, 202);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(555, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lab_Msg.Visible = false;
            // 
            // Dgv_Receipt
            // 
            this.Dgv_Receipt.AllowUserToAddRows = false;
            this.Dgv_Receipt.AllowUserToDeleteRows = false;
            this.Dgv_Receipt.AllowUserToResizeColumns = false;
            this.Dgv_Receipt.AllowUserToResizeRows = false;
            this.Dgv_Receipt.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Receipt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Receipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_Receipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Receipt.ColumnHeadersHeight = 28;
            this.Dgv_Receipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Receipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColSLNo,
            this.ColPt_Name,
            this.Colinvo,
            this.ColReceipt,
            this.ColDate,
            this.ColProcedure,
            this.ColDoctor,
            this.ColModeOfPayment,
            this.ColBank,
            this.ColNumber,
            this.ColCardNo,
            this.COl4Digit,
            this.ColDD,
            this.ColTotalCost,
            this.ColTAmount,
            this.ColamountPaid,
            this.colTAmountDue});
            this.Dgv_Receipt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Receipt.Location = new System.Drawing.Point(0, 0);
            this.Dgv_Receipt.Name = "Dgv_Receipt";
            this.Dgv_Receipt.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Receipt.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Dgv_Receipt.RowHeadersVisible = false;
            this.Dgv_Receipt.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv_Receipt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Dgv_Receipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Receipt.Size = new System.Drawing.Size(1369, 489);
            this.Dgv_Receipt.TabIndex = 0;
            // 
            // ColSLNo
            // 
            this.ColSLNo.FillWeight = 0.0963385F;
            this.ColSLNo.HeaderText = "SLNO";
            this.ColSLNo.Name = "ColSLNo";
            this.ColSLNo.Width = 40;
            // 
            // ColPt_Name
            // 
            this.ColPt_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColPt_Name.FillWeight = 0.6593446F;
            this.ColPt_Name.HeaderText = "PATIENT";
            this.ColPt_Name.Name = "ColPt_Name";
            // 
            // Colinvo
            // 
            this.Colinvo.FillWeight = 0.5988837F;
            this.Colinvo.HeaderText = "INVOICE";
            this.Colinvo.Name = "Colinvo";
            this.Colinvo.Width = 70;
            // 
            // ColReceipt
            // 
            this.ColReceipt.FillWeight = 0.9159511F;
            this.ColReceipt.HeaderText = "RECEIPT";
            this.ColReceipt.Name = "ColReceipt";
            this.ColReceipt.Width = 70;
            // 
            // ColDate
            // 
            this.ColDate.FillWeight = 1.40778F;
            this.ColDate.HeaderText = "DATE";
            this.ColDate.Name = "ColDate";
            this.ColDate.Width = 70;
            // 
            // ColProcedure
            // 
            this.ColProcedure.FillWeight = 5.759707F;
            this.ColProcedure.HeaderText = "PROCEDURE";
            this.ColProcedure.Name = "ColProcedure";
            this.ColProcedure.Width = 150;
            // 
            // ColDoctor
            // 
            this.ColDoctor.FillWeight = 14.14872F;
            this.ColDoctor.HeaderText = "DOCTOR";
            this.ColDoctor.Name = "ColDoctor";
            this.ColDoctor.Width = 110;
            // 
            // ColModeOfPayment
            // 
            this.ColModeOfPayment.FillWeight = 16.2731F;
            this.ColModeOfPayment.HeaderText = "MODE OF PAYMENT";
            this.ColModeOfPayment.Name = "ColModeOfPayment";
            this.ColModeOfPayment.Width = 80;
            // 
            // ColBank
            // 
            this.ColBank.FillWeight = 27.38385F;
            this.ColBank.HeaderText = "BANK NAME";
            this.ColBank.Name = "ColBank";
            // 
            // ColNumber
            // 
            this.ColNumber.FillWeight = 46.0917F;
            this.ColNumber.HeaderText = "NUMBER";
            this.ColNumber.Name = "ColNumber";
            this.ColNumber.Width = 55;
            // 
            // ColCardNo
            // 
            this.ColCardNo.FillWeight = 38.59768F;
            this.ColCardNo.HeaderText = "CARD NO";
            this.ColCardNo.Name = "ColCardNo";
            this.ColCardNo.Width = 50;
            // 
            // COl4Digit
            // 
            this.COl4Digit.FillWeight = 27.31458F;
            this.COl4Digit.HeaderText = "4-DIGIT NO";
            this.COl4Digit.Name = "COl4Digit";
            this.COl4Digit.Width = 50;
            // 
            // ColDD
            // 
            this.ColDD.FillWeight = 32.21716F;
            this.ColDD.HeaderText = "DD-NUMBER";
            this.ColDD.Name = "ColDD";
            this.ColDD.Width = 50;
            // 
            // ColTotalCost
            // 
            this.ColTotalCost.FillWeight = 144.6398F;
            this.ColTotalCost.HeaderText = "COST";
            this.ColTotalCost.Name = "ColTotalCost";
            this.ColTotalCost.Width = 80;
            // 
            // ColTAmount
            // 
            this.ColTAmount.FillWeight = 243.5226F;
            this.ColTAmount.HeaderText = "AMOUNT";
            this.ColTAmount.Name = "ColTAmount";
            this.ColTAmount.Width = 80;
            // 
            // ColamountPaid
            // 
            this.ColamountPaid.FillWeight = 410.0176F;
            this.ColamountPaid.HeaderText = "AMOUNT RECEIVED";
            this.ColamountPaid.Name = "ColamountPaid";
            // 
            // colTAmountDue
            // 
            this.colTAmountDue.FillWeight = 690.3554F;
            this.colTAmountDue.HeaderText = "AMOUNT DUE";
            this.colTAmountDue.Name = "colTAmountDue";
            this.colTAmountDue.Width = 80;
            // 
            // Lab_Paid
            // 
            this.Lab_Paid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Paid.AutoSize = true;
            this.Lab_Paid.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Paid.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Paid.ForeColor = System.Drawing.Color.ForestGreen;
            this.Lab_Paid.Location = new System.Drawing.Point(340, 33);
            this.Lab_Paid.Name = "Lab_Paid";
            this.Lab_Paid.Size = new System.Drawing.Size(33, 17);
            this.Lab_Paid.TabIndex = 294;
            this.Lab_Paid.Text = "0.00";
            // 
            // Lab_Due
            // 
            this.Lab_Due.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Lab_Due.AutoSize = true;
            this.Lab_Due.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Due.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Due.ForeColor = System.Drawing.Color.Red;
            this.Lab_Due.Location = new System.Drawing.Point(444, 33);
            this.Lab_Due.Name = "Lab_Due";
            this.Lab_Due.Size = new System.Drawing.Size(33, 17);
            this.Lab_Due.TabIndex = 295;
            this.Lab_Due.Text = "0.00";
            this.Lab_Due.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Export);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btn_Show);
            this.panel1.Controls.Add(this.Dtp_ReceiptTO);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.DTP_From);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1369, 121);
            this.panel1.TabIndex = 104;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(1, 650);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1368, 97);
            this.panel4.TabIndex = 278;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.Lab_totalExpense);
            this.panel5.Controls.Add(this.Lab_Due);
            this.panel5.Controls.Add(this.Lab_Amount);
            this.panel5.Controls.Add(this.Lab_Paid);
            this.panel5.Controls.Add(this.Lab_TotalIncome);
            this.panel5.Location = new System.Drawing.Point(870, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(496, 58);
            this.panel5.TabIndex = 119;
            // 
            // Paymode_Wise_Receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Paymode_Wise_Receipt";
            this.Text = "Paymode Wise Receipt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Paymode_Wise_Receipt_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Receipt)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Lab_Amount;
        private System.Windows.Forms.Label Lab_totalExpense;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label Lab_TotalIncome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox Cmb_Modeofpayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox Chk_RemoveAmountDue;
        private System.Windows.Forms.ComboBox cmb_doctor;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.Label Lab_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btn_Show;
        private System.Windows.Forms.DateTimePicker Dtp_ReceiptTO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DTP_From;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_Paid;
        private System.Windows.Forms.Label Lab_Due;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView Dgv_Receipt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSLNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPt_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colinvo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReceipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProcedure;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModeOfPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn COl4Digit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColamountPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTAmountDue;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}