namespace PappyjoeMVC.View
{
    partial class Purchase_Return_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_Return_Report));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BtnShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txttotalAmount = new System.Windows.Forms.TextBox();
            this.dptMonthly_From = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dptMonthly_To = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sup_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShow.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(273, 43);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(67, 24);
            this.BtnShow.TabIndex = 298;
            this.BtnShow.Text = "Show";
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(1172, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "Total Amount";
            // 
            // txttotalAmount
            // 
            this.txttotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txttotalAmount.Enabled = false;
            this.txttotalAmount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalAmount.Location = new System.Drawing.Point(1253, 40);
            this.txttotalAmount.Name = "txttotalAmount";
            this.txttotalAmount.ReadOnly = true;
            this.txttotalAmount.Size = new System.Drawing.Size(96, 25);
            this.txttotalAmount.TabIndex = 11;
            this.txttotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dptMonthly_From
            // 
            this.dptMonthly_From.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Location = new System.Drawing.Point(58, 11);
            this.dptMonthly_From.Name = "dptMonthly_From";
            this.dptMonthly_From.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_From.TabIndex = 167;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(14, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 169;
            this.label6.Text = "From";
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalItem.Enabled = false;
            this.txtTotalItem.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItem.Location = new System.Drawing.Point(1253, 8);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.ReadOnly = true;
            this.txtTotalItem.Size = new System.Drawing.Size(96, 22);
            this.txtTotalItem.TabIndex = 9;
            this.txtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(1181, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Item";
            // 
            // dptMonthly_To
            // 
            this.dptMonthly_To.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_To.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Location = new System.Drawing.Point(57, 43);
            this.dptMonthly_To.Name = "dptMonthly_To";
            this.dptMonthly_To.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_To.TabIndex = 168;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(26, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 17);
            this.label5.TabIndex = 170;
            this.label5.Text = "To";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(-1, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1372, 1);
            this.panel4.TabIndex = 195;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.BtnShow);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txttotalAmount);
            this.panel1.Controls.Add(this.dptMonthly_From);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTotalItem);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dptMonthly_To);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-1, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 90);
            this.panel1.TabIndex = 192;
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(1063, 11);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 30);
            this.BtnExport.TabIndex = 299;
            this.BtnExport.Text = "EXPORT TO EXCEL";
            this.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(10, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 21);
            this.label8.TabIndex = 297;
            this.label8.Text = "PURCHASE RETURN REPORT";
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
            this.btnprint.Location = new System.Drawing.Point(1184, 11);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 30);
            this.btnprint.TabIndex = 165;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // BTNClose
            // 
            this.BTNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNClose.BackColor = System.Drawing.Color.Tomato;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.ForeColor = System.Drawing.Color.White;
            this.BTNClose.Location = new System.Drawing.Point(1276, 11);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 30);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // TotalAmount
            // 
            this.TotalAmount.FillWeight = 102.6831F;
            this.TotalAmount.HeaderText = "TOTAL AMOUNT";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // Sup_name
            // 
            this.Sup_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sup_name.FillWeight = 102.6831F;
            this.Sup_name.HeaderText = "SUPPLIER NAME";
            this.Sup_name.Name = "Sup_name";
            this.Sup_name.ReadOnly = true;
            // 
            // supplierId
            // 
            this.supplierId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.supplierId.HeaderText = "SUPPLIER ID";
            this.supplierId.Name = "supplierId";
            this.supplierId.ReadOnly = true;
            // 
            // PurchaseReturnDate
            // 
            this.PurchaseReturnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchaseReturnDate.HeaderText = "RETURN DATE";
            this.PurchaseReturnDate.Name = "PurchaseReturnDate";
            this.PurchaseReturnDate.ReadOnly = true;
            // 
            // PurchDate
            // 
            this.PurchDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchDate.FillWeight = 102.6831F;
            this.PurchDate.HeaderText = "PURCHASE DATE";
            this.PurchDate.Name = "PurchDate";
            this.PurchDate.ReadOnly = true;
            // 
            // RetNumber
            // 
            this.RetNumber.HeaderText = "RETURN NO";
            this.RetNumber.Name = "RetNumber";
            this.RetNumber.ReadOnly = true;
            this.RetNumber.Width = 121;
            // 
            // PurchNumber
            // 
            this.PurchNumber.FillWeight = 102.6831F;
            this.PurchNumber.HeaderText = "PURCHASE NO";
            this.PurchNumber.Name = "PurchNumber";
            this.PurchNumber.ReadOnly = true;
            this.PurchNumber.Width = 123;
            // 
            // SL_NO
            // 
            this.SL_NO.HeaderText = "SLNO";
            this.SL_NO.Name = "SL_NO";
            this.SL_NO.ReadOnly = true;
            this.SL_NO.Width = 121;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(225, 205);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(574, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Lab_Msg.Visible = false;
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToAddRows = false;
            this.dgvPurchase.AllowUserToDeleteRows = false;
            this.dgvPurchase.AllowUserToResizeColumns = false;
            this.dgvPurchase.AllowUserToResizeRows = false;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPurchase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPurchase.ColumnHeadersHeight = 25;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SL_NO,
            this.PurchNumber,
            this.RetNumber,
            this.PurchDate,
            this.PurchaseReturnDate,
            this.supplierId,
            this.Sup_name,
            this.TotalAmount});
            this.dgvPurchase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchase.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPurchase.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.ReadOnly = true;
            this.dgvPurchase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPurchase.RowHeadersVisible = false;
            this.dgvPurchase.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPurchase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchase.Size = new System.Drawing.Size(1372, 390);
            this.dgvPurchase.TabIndex = 1;
            this.dgvPurchase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgvPurchase);
            this.panel2.Location = new System.Drawing.Point(-1, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1372, 390);
            this.panel2.TabIndex = 194;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.BtnExport);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.BTNClose);
            this.panel3.Location = new System.Drawing.Point(-1, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1372, 49);
            this.panel3.TabIndex = 193;
            // 
            // Purchase_Return_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 741);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase_Return_Report";
            this.Text = "Purchase Return";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Purchase_Return_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttotalAmount;
        private System.Windows.Forms.DateTimePicker dptMonthly_From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptMonthly_To;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sup_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SL_NO;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}