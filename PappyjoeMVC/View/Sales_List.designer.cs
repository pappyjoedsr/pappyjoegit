namespace PappyjoeMVC.View
{
    partial class Sales_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_List));
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnexport = new System.Windows.Forms.Button();
            this.BtnShow = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rad_Credit = new System.Windows.Forms.RadioButton();
            this.rad_Cash = new System.Windows.Forms.RadioButton();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcustNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colinvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTP_To = new System.Windows.Forms.DateTimePicker();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgv_sales = new System.Windows.Forms.DataGridView();
            this.colslNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DTP_From = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colPayment
            // 
            this.colPayment.HeaderText = "Payment Method";
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            this.colPayment.Visible = false;
            this.colPayment.Width = 110;
            // 
            // btnexport
            // 
            this.btnexport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexport.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnexport.ForeColor = System.Drawing.Color.White;
            this.btnexport.Location = new System.Drawing.Point(656, 49);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(74, 30);
            this.btnexport.TabIndex = 302;
            this.btnexport.Text = "Export";
            this.btnexport.UseVisualStyleBackColor = false;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShow.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(580, 49);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(74, 30);
            this.BtnShow.TabIndex = 297;
            this.BtnShow.Text = "Show";
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(804, 48);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(74, 30);
            this.btn_Refresh.TabIndex = 296;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(13, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 292;
            this.label8.Text = "Date from";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(306, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 291;
            this.label2.Text = "Date To";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label41.Location = new System.Drawing.Point(7, 7);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(90, 21);
            this.label41.TabIndex = 290;
            this.label41.Text = "SALES LIST";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(-2, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(900, 1);
            this.panel3.TabIndex = 210;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(804, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 30);
            this.btnCancel.TabIndex = 207;
            this.btnCancel.Text = "CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rad_Credit
            // 
            this.rad_Credit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rad_Credit.AutoSize = true;
            this.rad_Credit.Location = new System.Drawing.Point(722, 15);
            this.rad_Credit.Name = "rad_Credit";
            this.rad_Credit.Size = new System.Drawing.Size(76, 17);
            this.rad_Credit.TabIndex = 205;
            this.rad_Credit.TabStop = true;
            this.rad_Credit.Text = "Credit Sale";
            this.rad_Credit.UseVisualStyleBackColor = true;
            this.rad_Credit.Visible = false;
            this.rad_Credit.CheckedChanged += new System.EventHandler(this.rad_Credit_CheckedChanged);
            // 
            // rad_Cash
            // 
            this.rad_Cash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rad_Cash.AutoSize = true;
            this.rad_Cash.Location = new System.Drawing.Point(643, 15);
            this.rad_Cash.Name = "rad_Cash";
            this.rad_Cash.Size = new System.Drawing.Size(73, 17);
            this.rad_Cash.TabIndex = 204;
            this.rad_Cash.TabStop = true;
            this.rad_Cash.Text = "Cash Sale";
            this.rad_Cash.UseVisualStyleBackColor = true;
            this.rad_Cash.Visible = false;
            this.rad_Cash.CheckedChanged += new System.EventHandler(this.rad_Cash_CheckedChanged);
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPhone.HeaderText = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.HeaderText = "Customer Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colcustNo
            // 
            this.colcustNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colcustNo.HeaderText = "Customer Id";
            this.colcustNo.Name = "colcustNo";
            this.colcustNo.ReadOnly = true;
            // 
            // colinvDate
            // 
            this.colinvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colinvDate.HeaderText = "Invoice Date";
            this.colinvDate.Name = "colinvDate";
            this.colinvDate.ReadOnly = true;
            // 
            // colInvNum
            // 
            this.colInvNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colInvNum.HeaderText = "Invoice Number";
            this.colInvNum.Name = "colInvNum";
            this.colInvNum.ReadOnly = true;
            // 
            // DTP_To
            // 
            this.DTP_To.Location = new System.Drawing.Point(368, 54);
            this.DTP_To.Name = "DTP_To";
            this.DTP_To.Size = new System.Drawing.Size(200, 20);
            this.DTP_To.TabIndex = 3;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(142, 212);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 278;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // dgv_sales
            // 
            this.dgv_sales.AllowUserToAddRows = false;
            this.dgv_sales.AllowUserToDeleteRows = false;
            this.dgv_sales.AllowUserToResizeColumns = false;
            this.dgv_sales.AllowUserToResizeRows = false;
            this.dgv_sales.BackgroundColor = System.Drawing.Color.White;
            this.dgv_sales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_sales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_sales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_sales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_sales.ColumnHeadersHeight = 25;
            this.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_sales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colslNo,
            this.colInvNum,
            this.colinvDate,
            this.colcustNo,
            this.colName,
            this.colPhone,
            this.colTotalAmount,
            this.colPayment});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_sales.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sales.GridColor = System.Drawing.Color.LightGray;
            this.dgv_sales.Location = new System.Drawing.Point(0, 0);
            this.dgv_sales.Name = "dgv_sales";
            this.dgv_sales.ReadOnly = true;
            this.dgv_sales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_sales.RowHeadersVisible = false;
            this.dgv_sales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_sales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sales.Size = new System.Drawing.Size(875, 468);
            this.dgv_sales.TabIndex = 0;
            this.dgv_sales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sales_CellClick);
            // 
            // colslNo
            // 
            this.colslNo.HeaderText = "SlNo";
            this.colslNo.Name = "colslNo";
            this.colslNo.ReadOnly = true;
            this.colslNo.Width = 75;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgv_sales);
            this.panel2.Location = new System.Drawing.Point(3, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 468);
            this.panel2.TabIndex = 3;
            // 
            // DTP_From
            // 
            this.DTP_From.Location = new System.Drawing.Point(86, 54);
            this.DTP_From.Name = "DTP_From";
            this.DTP_From.Size = new System.Drawing.Size(200, 20);
            this.DTP_From.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnexport);
            this.panel1.Controls.Add(this.BtnShow);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.rad_Credit);
            this.panel1.Controls.Add(this.rad_Cash);
            this.panel1.Controls.Add(this.DTP_To);
            this.panel1.Controls.Add(this.DTP_From);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 90);
            this.panel1.TabIndex = 2;
            // 
            // Sales_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 564);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales_List";
            this.Text = "Sales List";
            this.Load += new System.EventHandler(this.Sales_List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rad_Credit;
        private System.Windows.Forms.RadioButton rad_Cash;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcustNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colinvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvNum;
        private System.Windows.Forms.DateTimePicker DTP_To;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgv_sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colslNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker DTP_From;
        private System.Windows.Forms.Panel panel1;
    }
}