namespace PappyjoeMVC.View
{
    partial class PurchaseList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseList));
            this.btnexport = new System.Windows.Forms.Button();
            this.BtnShow = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.rad_Credit = new System.Windows.Forms.RadioButton();
            this.rad_Cash = new System.Windows.Forms.RadioButton();
            this.DTP_To = new System.Windows.Forms.DateTimePicker();
            this.DTP_From = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colslNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgv_Purchase = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Purchase)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnexport
            // 
            this.btnexport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnexport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexport.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnexport.ForeColor = System.Drawing.Color.White;
            this.btnexport.Location = new System.Drawing.Point(640, 48);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(74, 30);
            this.btnexport.TabIndex = 301;
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
            this.BtnShow.Location = new System.Drawing.Point(567, 48);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(74, 30);
            this.BtnShow.TabIndex = 300;
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
            this.btn_Refresh.Location = new System.Drawing.Point(885, 46);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(74, 30);
            this.btn_Refresh.TabIndex = 299;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Visible = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(0, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(979, 1);
            this.panel3.TabIndex = 211;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label41.Location = new System.Drawing.Point(7, 7);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(125, 21);
            this.label41.TabIndex = 291;
            this.label41.Text = "PURCHASE LIST";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(828, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 207;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(737, 1);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(85, 30);
            this.btnPayment.TabIndex = 206;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Visible = false;
            // 
            // rad_Credit
            // 
            this.rad_Credit.AutoSize = true;
            this.rad_Credit.Location = new System.Drawing.Point(803, 52);
            this.rad_Credit.Name = "rad_Credit";
            this.rad_Credit.Size = new System.Drawing.Size(76, 17);
            this.rad_Credit.TabIndex = 205;
            this.rad_Credit.Text = "Credit Sale";
            this.rad_Credit.UseVisualStyleBackColor = true;
            this.rad_Credit.Visible = false;
            this.rad_Credit.CheckedChanged += new System.EventHandler(this.rad_Credit_CheckedChanged);
            // 
            // rad_Cash
            // 
            this.rad_Cash.AutoSize = true;
            this.rad_Cash.Checked = true;
            this.rad_Cash.Location = new System.Drawing.Point(727, 52);
            this.rad_Cash.Name = "rad_Cash";
            this.rad_Cash.Size = new System.Drawing.Size(73, 17);
            this.rad_Cash.TabIndex = 204;
            this.rad_Cash.TabStop = true;
            this.rad_Cash.Text = "Cash Sale";
            this.rad_Cash.UseVisualStyleBackColor = true;
            this.rad_Cash.Visible = false;
            this.rad_Cash.CheckedChanged += new System.EventHandler(this.rad_Cash_CheckedChanged);
            // 
            // DTP_To
            // 
            this.DTP_To.Location = new System.Drawing.Point(363, 53);
            this.DTP_To.Name = "DTP_To";
            this.DTP_To.Size = new System.Drawing.Size(200, 20);
            this.DTP_To.TabIndex = 3;
            // 
            // DTP_From
            // 
            this.DTP_From.Location = new System.Drawing.Point(85, 53);
            this.DTP_From.Name = "DTP_From";
            this.DTP_From.Size = new System.Drawing.Size(200, 20);
            this.DTP_From.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(304, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date To";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date From";
            // 
            // colPayment
            // 
            this.colPayment.HeaderText = "Payment Method";
            this.colPayment.Name = "colPayment";
            this.colPayment.ReadOnly = true;
            this.colPayment.Visible = false;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.HeaderText = "Total Amount";
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "Supplier Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // SupplierId
            // 
            this.SupplierId.HeaderText = "Supplier Id";
            this.SupplierId.Name = "SupplierId";
            this.SupplierId.ReadOnly = true;
            // 
            // colPurchDate
            // 
            this.colPurchDate.HeaderText = "Purchase Date";
            this.colPurchDate.Name = "colPurchDate";
            this.colPurchDate.ReadOnly = true;
            // 
            // colPurNum
            // 
            this.colPurNum.HeaderText = "Purchase Number";
            this.colPurNum.Name = "colPurNum";
            this.colPurNum.ReadOnly = true;
            // 
            // colslNo
            // 
            this.colslNo.HeaderText = "SlNo";
            this.colslNo.Name = "colslNo";
            this.colslNo.ReadOnly = true;
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
            // dgv_Purchase
            // 
            this.dgv_Purchase.AllowUserToAddRows = false;
            this.dgv_Purchase.AllowUserToDeleteRows = false;
            this.dgv_Purchase.AllowUserToResizeColumns = false;
            this.dgv_Purchase.AllowUserToResizeRows = false;
            this.dgv_Purchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Purchase.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Purchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Purchase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Purchase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_Purchase.ColumnHeadersHeight = 25;
            this.dgv_Purchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Purchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colslNo,
            this.colPurNum,
            this.colPurchDate,
            this.SupplierId,
            this.colName,
            this.colTotalAmount,
            this.colPayment});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Purchase.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Purchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Purchase.GridColor = System.Drawing.Color.LightGray;
            this.dgv_Purchase.Location = new System.Drawing.Point(0, 0);
            this.dgv_Purchase.Name = "dgv_Purchase";
            this.dgv_Purchase.ReadOnly = true;
            this.dgv_Purchase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Purchase.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Purchase.RowHeadersVisible = false;
            this.dgv_Purchase.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Purchase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Purchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Purchase.Size = new System.Drawing.Size(960, 464);
            this.dgv_Purchase.TabIndex = 0;
            this.dgv_Purchase.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_Purchase_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgv_Purchase);
            this.panel2.Location = new System.Drawing.Point(2, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 464);
            this.panel2.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnexport);
            this.panel1.Controls.Add(this.BtnShow);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnPayment);
            this.panel1.Controls.Add(this.rad_Credit);
            this.panel1.Controls.Add(this.rad_Cash);
            this.panel1.Controls.Add(this.DTP_To);
            this.panel1.Controls.Add(this.DTP_From);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 87);
            this.panel1.TabIndex = 4;
            // 
            // PurchaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 564);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PurchaseList";
            this.Text = "Purchase List";
            this.Load += new System.EventHandler(this.frmPurchaseList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Purchase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.RadioButton rad_Credit;
        private System.Windows.Forms.RadioButton rad_Cash;
        private System.Windows.Forms.DateTimePicker DTP_To;
        private System.Windows.Forms.DateTimePicker DTP_From;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colslNo;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgv_Purchase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}