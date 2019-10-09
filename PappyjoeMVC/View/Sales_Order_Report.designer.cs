namespace PappyjoeMVC.View
{
    partial class Sales_Order_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Order_Report));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Btn_Show = new System.Windows.Forms.Button();
            this.dptMonthly_From = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dptMonthly_To = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.Dgv_Order = new System.Windows.Forms.DataGridView();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cus_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Txt_totalInvoice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblinvoices = new System.Windows.Forms.Label();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Order)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Show
            // 
            this.Btn_Show.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Show.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Show.ForeColor = System.Drawing.Color.White;
            this.Btn_Show.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Show.Location = new System.Drawing.Point(513, 12);
            this.Btn_Show.Name = "Btn_Show";
            this.Btn_Show.Size = new System.Drawing.Size(65, 22);
            this.Btn_Show.TabIndex = 300;
            this.Btn_Show.Text = "Show";
            this.Btn_Show.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Show.UseVisualStyleBackColor = false;
            this.Btn_Show.Click += new System.EventHandler(this.Btn_Show_Click);
            // 
            // dptMonthly_From
            // 
            this.dptMonthly_From.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Location = new System.Drawing.Point(56, 12);
            this.dptMonthly_From.Name = "dptMonthly_From";
            this.dptMonthly_From.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_From.TabIndex = 167;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(11, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 169;
            this.label6.Text = "From";
            // 
            // dptMonthly_To
            // 
            this.dptMonthly_To.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_To.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Location = new System.Drawing.Point(306, 12);
            this.dptMonthly_To.Name = "dptMonthly_To";
            this.dptMonthly_To.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_To.TabIndex = 168;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.Dgv_Order);
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 421);
            this.panel2.TabIndex = 188;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(427, 239);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 281;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // Dgv_Order
            // 
            this.Dgv_Order.AllowUserToAddRows = false;
            this.Dgv_Order.AllowUserToDeleteRows = false;
            this.Dgv_Order.AllowUserToResizeColumns = false;
            this.Dgv_Order.AllowUserToResizeRows = false;
            this.Dgv_Order.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Order.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv_Order.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Dgv_Order.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Order.ColumnHeadersHeight = 25;
            this.Dgv_Order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.DocNumber,
            this.DocDate,
            this.Cus_Id,
            this.CustomerName,
            this.Phone,
            this.totalItems});
            this.Dgv_Order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Order.GridColor = System.Drawing.Color.Gainsboro;
            this.Dgv_Order.Location = new System.Drawing.Point(0, 0);
            this.Dgv_Order.Name = "Dgv_Order";
            this.Dgv_Order.ReadOnly = true;
            this.Dgv_Order.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv_Order.RowHeadersVisible = false;
            this.Dgv_Order.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Dgv_Order.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Dgv_Order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv_Order.Size = new System.Drawing.Size(1370, 421);
            this.Dgv_Order.TabIndex = 2;
            this.Dgv_Order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Order_CellClick);
            this.Dgv_Order.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Order_CellDoubleClick);
            // 
            // SLNO
            // 
            this.SLNO.FillWeight = 81.21827F;
            this.SLNO.HeaderText = "SLNO";
            this.SLNO.Name = "SLNO";
            this.SLNO.ReadOnly = true;
            this.SLNO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SLNO.Width = 95;
            // 
            // DocNumber
            // 
            this.DocNumber.FillWeight = 102.6831F;
            this.DocNumber.HeaderText = "ORDER NUMBER";
            this.DocNumber.Name = "DocNumber";
            this.DocNumber.ReadOnly = true;
            this.DocNumber.Width = 149;
            // 
            // DocDate
            // 
            this.DocDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DocDate.FillWeight = 102.6831F;
            this.DocDate.HeaderText = "ORDER DATE";
            this.DocDate.Name = "DocDate";
            this.DocDate.ReadOnly = true;
            // 
            // Cus_Id
            // 
            this.Cus_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cus_Id.FillWeight = 102.6831F;
            this.Cus_Id.HeaderText = "CUSTOMER ID";
            this.Cus_Id.Name = "Cus_Id";
            this.Cus_Id.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.FillWeight = 102.6831F;
            this.CustomerName.HeaderText = "CUSTOMER NAME";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            this.CustomerName.Width = 115;
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Phone.FillWeight = 102.6831F;
            this.Phone.HeaderText = "PHONE ";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // totalItems
            // 
            this.totalItems.FillWeight = 102.6831F;
            this.totalItems.HeaderText = "TOTAL ITEMS";
            this.totalItems.Name = "totalItems";
            this.totalItems.ReadOnly = true;
            // 
            // Txt_totalInvoice
            // 
            this.Txt_totalInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_totalInvoice.Font = new System.Drawing.Font("Segoe UI Light", 8.25F);
            this.Txt_totalInvoice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txt_totalInvoice.Location = new System.Drawing.Point(1247, 13);
            this.Txt_totalInvoice.Name = "Txt_totalInvoice";
            this.Txt_totalInvoice.ReadOnly = true;
            this.Txt_totalInvoice.Size = new System.Drawing.Size(100, 22);
            this.Txt_totalInvoice.TabIndex = 2;
            this.Txt_totalInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(277, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 15);
            this.label5.TabIndex = 170;
            this.label5.Text = "To";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(0, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1384, 1);
            this.panel4.TabIndex = 189;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.Btn_Show);
            this.panel1.Controls.Add(this.dptMonthly_From);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dptMonthly_To);
            this.panel1.Controls.Add(this.Txt_totalInvoice);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblinvoices);
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 52);
            this.panel1.TabIndex = 187;
            // 
            // lblinvoices
            // 
            this.lblinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblinvoices.AutoSize = true;
            this.lblinvoices.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinvoices.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblinvoices.Location = new System.Drawing.Point(1165, 16);
            this.lblinvoices.Name = "lblinvoices";
            this.lblinvoices.Size = new System.Drawing.Size(66, 15);
            this.lblinvoices.TabIndex = 0;
            this.lblinvoices.Text = "Total Order";
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(1060, 6);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 30);
            this.BtnExport.TabIndex = 298;
            this.BtnExport.Text = "EXPORT TO EXCEL";
            this.BtnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 25);
            this.label1.TabIndex = 178;
            this.label1.Text = "Sales Order Report";
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
            this.btnprint.Location = new System.Drawing.Point(1181, 6);
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
            this.BTNClose.Location = new System.Drawing.Point(1274, 6);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 30);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.BtnExport);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.BTNClose);
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1370, 43);
            this.panel3.TabIndex = 186;
            // 
            // Sales_Order_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 741);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales_Order_Report";
            this.Text = "Sales Order Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Sales_Order_Report_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Order)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button Btn_Show;
        private System.Windows.Forms.DateTimePicker dptMonthly_From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dptMonthly_To;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox Txt_totalInvoice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblinvoices;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView Dgv_Order;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cus_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalItems;
        private System.Windows.Forms.Label Lab_Msg;
    }
}