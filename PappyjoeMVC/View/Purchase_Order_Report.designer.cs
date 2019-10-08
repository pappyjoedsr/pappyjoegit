namespace PappyjoeMVC.View
{
    partial class Purchase_Order_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_Order_Report));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.dptMonthly_From = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dptMonthly_To = new System.Windows.Forms.DateTimePicker();
            this.txtTotalItem = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTNClose = new System.Windows.Forms.Button();
            this.SUPPLIER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PURCHASEORDER_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PUCHASEORDERNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(244, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 22);
            this.button1.TabIndex = 299;
            this.button1.Text = "Show";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dptMonthly_From
            // 
            this.dptMonthly_From.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Location = new System.Drawing.Point(50, 12);
            this.dptMonthly_From.Name = "dptMonthly_From";
            this.dptMonthly_From.Size = new System.Drawing.Size(188, 22);
            this.dptMonthly_From.TabIndex = 167;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 169;
            this.label6.Text = "From";
            // 
            // dptMonthly_To
            // 
            this.dptMonthly_To.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_To.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Location = new System.Drawing.Point(49, 42);
            this.dptMonthly_To.Name = "dptMonthly_To";
            this.dptMonthly_To.Size = new System.Drawing.Size(189, 22);
            this.dptMonthly_To.TabIndex = 168;
            // 
            // txtTotalItem
            // 
            this.txtTotalItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalItem.Enabled = false;
            this.txtTotalItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalItem.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtTotalItem.Location = new System.Drawing.Point(1251, 12);
            this.txtTotalItem.Name = "txtTotalItem";
            this.txtTotalItem.ReadOnly = true;
            this.txtTotalItem.Size = new System.Drawing.Size(96, 22);
            this.txtTotalItem.TabIndex = 2;
            this.txtTotalItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label.Location = new System.Drawing.Point(1180, 21);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(57, 13);
            this.label.TabIndex = 0;
            this.label.Text = "Total Item";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 17);
            this.label5.TabIndex = 170;
            this.label5.Text = "To";
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(1062, 12);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 30);
            this.BtnExport.TabIndex = 298;
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
            this.label8.Location = new System.Drawing.Point(5, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(207, 21);
            this.label8.TabIndex = 297;
            this.label8.Text = "PURCHASE ORDER REPORT";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dptMonthly_From);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dptMonthly_To);
            this.panel1.Controls.Add(this.txtTotalItem);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1371, 68);
            this.panel1.TabIndex = 195;
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
            this.btnprint.Location = new System.Drawing.Point(1183, 12);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 30);
            this.btnprint.TabIndex = 165;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(0, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1371, 1);
            this.panel4.TabIndex = 198;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.BtnExport);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.BTNClose);
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1371, 57);
            this.panel3.TabIndex = 196;
            // 
            // BTNClose
            // 
            this.BTNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNClose.BackColor = System.Drawing.Color.Tomato;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.ForeColor = System.Drawing.Color.White;
            this.BTNClose.Location = new System.Drawing.Point(1275, 12);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 30);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // SUPPLIER_NAME
            // 
            this.SUPPLIER_NAME.HeaderText = "SUPPLIER NAME";
            this.SUPPLIER_NAME.Name = "SUPPLIER_NAME";
            this.SUPPLIER_NAME.ReadOnly = true;
            // 
            // PURCHASEORDER_DATE
            // 
            this.PURCHASEORDER_DATE.HeaderText = "PURCHASE ORDER DATE";
            this.PURCHASEORDER_DATE.Name = "PURCHASEORDER_DATE";
            this.PURCHASEORDER_DATE.ReadOnly = true;
            // 
            // PUCHASEORDERNO
            // 
            this.PUCHASEORDERNO.HeaderText = "PUCHASE ORDER NO";
            this.PUCHASEORDERNO.Name = "PUCHASEORDERNO";
            this.PUCHASEORDERNO.ReadOnly = true;
            // 
            // SLNO
            // 
            this.SLNO.FillWeight = 49.94423F;
            this.SLNO.HeaderText = "SLNO";
            this.SLNO.Name = "SLNO";
            this.SLNO.ReadOnly = true;
            this.SLNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(343, 219);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 279;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToAddRows = false;
            this.dgvPurchase.AllowUserToDeleteRows = false;
            this.dgvPurchase.AllowUserToResizeColumns = false;
            this.dgvPurchase.AllowUserToResizeRows = false;
            this.dgvPurchase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPurchase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPurchase.ColumnHeadersHeight = 25;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.PUCHASEORDERNO,
            this.PURCHASEORDER_DATE,
            this.SUPPLIER_NAME});
            this.dgvPurchase.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPurchase.Location = new System.Drawing.Point(0, 5);
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.ReadOnly = true;
            this.dgvPurchase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPurchase.RowHeadersVisible = false;
            this.dgvPurchase.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvPurchase.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchase.Size = new System.Drawing.Size(1365, 612);
            this.dgvPurchase.TabIndex = 1;
            this.dgvPurchase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgvPurchase);
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1368, 612);
            this.panel2.TabIndex = 197;
            // 
            // Purchase_Order_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 741);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase_Order_Report";
            this.Text = "Purchase Order Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Purchase_Order_Report_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dptMonthly_From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dptMonthly_To;
        private System.Windows.Forms.TextBox txtTotalItem;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUPPLIER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PURCHASEORDER_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PUCHASEORDERNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Panel panel2;
    }
}