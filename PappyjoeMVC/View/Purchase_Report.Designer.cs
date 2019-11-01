namespace PappyjoeMVC.View
{
    partial class Purchase_Report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_Report));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.dptMonthly_From = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.Txttotalcost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dptMonthly_To = new System.Windows.Forms.DateTimePicker();
            this.Txt_totalPurchase = new System.Windows.Forms.TextBox();
            this.lblinvoices = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sup_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiscAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grandtotl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(1156, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 171;
            this.label2.Text = "Total Amount";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrandTotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtGrandTotal.Location = new System.Drawing.Point(1242, 59);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(96, 22);
            this.txtGrandTotal.TabIndex = 11;
            this.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dptMonthly_From
            // 
            this.dptMonthly_From.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_From.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_From.Location = new System.Drawing.Point(58, 12);
            this.dptMonthly_From.Name = "dptMonthly_From";
            this.dptMonthly_From.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_From.TabIndex = 167;
            this.dptMonthly_From.Value = new System.DateTime(2019, 7, 19, 12, 19, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 169;
            this.label6.Text = "From";
            // 
            // Txttotalcost
            // 
            this.Txttotalcost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txttotalcost.Enabled = false;
            this.Txttotalcost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotalcost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txttotalcost.Location = new System.Drawing.Point(1242, 32);
            this.Txttotalcost.Name = "Txttotalcost";
            this.Txttotalcost.ReadOnly = true;
            this.Txttotalcost.Size = new System.Drawing.Size(96, 22);
            this.Txttotalcost.TabIndex = 9;
            this.Txttotalcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(1174, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Cost";
            // 
            // dptMonthly_To
            // 
            this.dptMonthly_To.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.CalendarMonthBackground = System.Drawing.Color.Gainsboro;
            this.dptMonthly_To.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptMonthly_To.Location = new System.Drawing.Point(57, 42);
            this.dptMonthly_To.Name = "dptMonthly_To";
            this.dptMonthly_To.Size = new System.Drawing.Size(201, 22);
            this.dptMonthly_To.TabIndex = 168;
            // 
            // Txt_totalPurchase
            // 
            this.Txt_totalPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_totalPurchase.Enabled = false;
            this.Txt_totalPurchase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_totalPurchase.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txt_totalPurchase.Location = new System.Drawing.Point(1242, 5);
            this.Txt_totalPurchase.Name = "Txt_totalPurchase";
            this.Txt_totalPurchase.ReadOnly = true;
            this.Txt_totalPurchase.Size = new System.Drawing.Size(96, 22);
            this.Txt_totalPurchase.TabIndex = 2;
            this.Txt_totalPurchase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblinvoices
            // 
            this.lblinvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblinvoices.AutoSize = true;
            this.lblinvoices.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinvoices.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblinvoices.Location = new System.Drawing.Point(1151, 10);
            this.lblinvoices.Name = "lblinvoices";
            this.lblinvoices.Size = new System.Drawing.Size(81, 13);
            this.lblinvoices.TabIndex = 0;
            this.lblinvoices.Text = "Total Purchase";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(26, 45);
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
            this.BtnExport.Location = new System.Drawing.Point(1063, 5);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(120, 30);
            this.BtnExport.TabIndex = 297;
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
            this.label8.Location = new System.Drawing.Point(8, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(152, 21);
            this.label8.TabIndex = 296;
            this.label8.Text = "PURCHASE REPORT";
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
            this.btnprint.Location = new System.Drawing.Point(1184, 5);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 31);
            this.btnprint.TabIndex = 165;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(264, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 22);
            this.button1.TabIndex = 300;
            this.button1.Text = "Show";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTNClose
            // 
            this.BTNClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNClose.BackColor = System.Drawing.Color.Tomato;
            this.BTNClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNClose.ForeColor = System.Drawing.Color.White;
            this.BTNClose.Location = new System.Drawing.Point(1276, 5);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 31);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(-2, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1374, 1);
            this.panel4.TabIndex = 196;
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
            this.panel3.Location = new System.Drawing.Point(-2, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1374, 52);
            this.panel3.TabIndex = 194;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(390, 203);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 280;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
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
            this.sl,
            this.PurchNumber,
            this.PurchDate,
            this.Sup_name,
            this.unt,
            this.TotalAmount,
            this.DiscAmount,
            this.grandtotl});
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
            this.dgvPurchase.Size = new System.Drawing.Size(1371, 604);
            this.dgvPurchase.TabIndex = 1;
            this.dgvPurchase.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellDoubleClick);
            // 
            // sl
            // 
            this.sl.FillWeight = 81.21827F;
            this.sl.HeaderText = "SL NO";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            this.sl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sl.Width = 95;
            // 
            // PurchNumber
            // 
            this.PurchNumber.FillWeight = 102.6831F;
            this.PurchNumber.HeaderText = "PURCHASE NO";
            this.PurchNumber.Name = "PurchNumber";
            this.PurchNumber.ReadOnly = true;
            this.PurchNumber.Width = 149;
            // 
            // PurchDate
            // 
            this.PurchDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchDate.FillWeight = 102.6831F;
            this.PurchDate.HeaderText = "PURCHASE DATE";
            this.PurchDate.Name = "PurchDate";
            this.PurchDate.ReadOnly = true;
            // 
            // Sup_name
            // 
            this.Sup_name.FillWeight = 102.6831F;
            this.Sup_name.HeaderText = "SUPPLIER NAME";
            this.Sup_name.Name = "Sup_name";
            this.Sup_name.ReadOnly = true;
            this.Sup_name.Width = 247;
            // 
            // unt
            // 
            this.unt.HeaderText = "UNIT";
            this.unt.Name = "unt";
            this.unt.ReadOnly = true;
            this.unt.Width = 180;
            // 
            // TotalAmount
            // 
            this.TotalAmount.FillWeight = 102.6831F;
            this.TotalAmount.HeaderText = "TOTAL AMOUNT";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            this.TotalAmount.Width = 125;
            // 
            // DiscAmount
            // 
            this.DiscAmount.FillWeight = 102.6831F;
            this.DiscAmount.HeaderText = "DISCOUNT";
            this.DiscAmount.Name = "DiscAmount";
            this.DiscAmount.ReadOnly = true;
            this.DiscAmount.Width = 200;
            // 
            // grandtotl
            // 
            this.grandtotl.FillWeight = 102.6831F;
            this.grandtotl.HeaderText = "GRAND TOTAL";
            this.grandtotl.Name = "grandtotl";
            this.grandtotl.ReadOnly = true;
            this.grandtotl.Width = 130;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgvPurchase);
            this.panel2.Location = new System.Drawing.Point(-2, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1371, 604);
            this.panel2.TabIndex = 195;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtGrandTotal);
            this.panel1.Controls.Add(this.dptMonthly_From);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Txttotalcost);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dptMonthly_To);
            this.panel1.Controls.Add(this.Txt_totalPurchase);
            this.panel1.Controls.Add(this.lblinvoices);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(-2, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1374, 88);
            this.panel1.TabIndex = 193;
            // 
            // Purchase_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 741);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase_Report";
            this.Text = "Purchase Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Purchase_Report_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.DateTimePicker dptMonthly_From;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txttotalcost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dptMonthly_To;
        private System.Windows.Forms.TextBox Txt_totalPurchase;
        private System.Windows.Forms.Label lblinvoices;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sup_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn grandtotl;
    }
}