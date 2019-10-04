namespace PappyjoeMVC.View
{
    partial class SalesOrderItemReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesOrderItemReport));
            this.panel4 = new System.Windows.Forms.Panel();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtgrandtotal = new System.Windows.Forms.TextBox();
            this.Txttotaldiscount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_totalInvoice = new System.Windows.Forms.TextBox();
            this.CLDocNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblinvoices = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_orderItems = new System.Windows.Forms.DataGridView();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_orderItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(2, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(948, 1);
            this.panel4.TabIndex = 185;
            // 
            // Cost
            // 
            this.Cost.HeaderText = "COST";
            this.Cost.Name = "Cost";
            this.Cost.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "QUANTITY";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Discription
            // 
            this.Discription.HeaderText = "DESCRIPTION";
            this.Discription.Name = "Discription";
            this.Discription.ReadOnly = true;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "ITEM CODE";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // DocDate
            // 
            this.DocDate.HeaderText = "DOC DATE";
            this.DocDate.Name = "DocDate";
            this.DocDate.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(732, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 171;
            this.label2.Text = "Total Amount";
            // 
            // Txtgrandtotal
            // 
            this.Txtgrandtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtgrandtotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txtgrandtotal.Location = new System.Drawing.Point(840, 50);
            this.Txtgrandtotal.Name = "Txtgrandtotal";
            this.Txtgrandtotal.ReadOnly = true;
            this.Txtgrandtotal.Size = new System.Drawing.Size(96, 25);
            this.Txtgrandtotal.TabIndex = 11;
            this.Txtgrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txttotaldiscount
            // 
            this.Txttotaldiscount.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txttotaldiscount.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txttotaldiscount.Location = new System.Drawing.Point(840, 29);
            this.Txttotaldiscount.Name = "Txttotaldiscount";
            this.Txttotaldiscount.ReadOnly = true;
            this.Txttotaldiscount.Size = new System.Drawing.Size(96, 22);
            this.Txttotaldiscount.TabIndex = 9;
            this.Txttotaldiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(755, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Cost";
            // 
            // Txt_totalInvoice
            // 
            this.Txt_totalInvoice.Font = new System.Drawing.Font("Segoe UI Light", 8.25F);
            this.Txt_totalInvoice.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txt_totalInvoice.Location = new System.Drawing.Point(840, 5);
            this.Txt_totalInvoice.Name = "Txt_totalInvoice";
            this.Txt_totalInvoice.ReadOnly = true;
            this.Txt_totalInvoice.Size = new System.Drawing.Size(96, 22);
            this.Txt_totalInvoice.TabIndex = 2;
            this.Txt_totalInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CLDocNumber
            // 
            this.CLDocNumber.HeaderText = "DOC NUMBER";
            this.CLDocNumber.Name = "CLDocNumber";
            this.CLDocNumber.ReadOnly = true;
            // 
            // SLNO
            // 
            this.SLNO.HeaderText = "SLNO";
            this.SLNO.Name = "SLNO";
            this.SLNO.ReadOnly = true;
            // 
            // lblinvoices
            // 
            this.lblinvoices.AutoSize = true;
            this.lblinvoices.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinvoices.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblinvoices.Location = new System.Drawing.Point(733, 10);
            this.lblinvoices.Name = "lblinvoices";
            this.lblinvoices.Size = new System.Drawing.Size(90, 17);
            this.lblinvoices.TabIndex = 0;
            this.lblinvoices.Text = "Total Invoices";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_orderItems);
            this.panel2.Location = new System.Drawing.Point(1, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(948, 378);
            this.panel2.TabIndex = 188;
            // 
            // dgv_orderItems
            // 
            this.dgv_orderItems.AllowUserToAddRows = false;
            this.dgv_orderItems.AllowUserToDeleteRows = false;
            this.dgv_orderItems.AllowUserToResizeColumns = false;
            this.dgv_orderItems.AllowUserToResizeRows = false;
            this.dgv_orderItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_orderItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_orderItems.BackgroundColor = System.Drawing.Color.White;
            this.dgv_orderItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_orderItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_orderItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_orderItems.ColumnHeadersHeight = 25;
            this.dgv_orderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_orderItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.CLDocNumber,
            this.DocDate,
            this.ItemCode,
            this.Discription,
            this.Qty,
            this.Cost,
            this.TotalAmount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_orderItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_orderItems.GridColor = System.Drawing.Color.DimGray;
            this.dgv_orderItems.Location = new System.Drawing.Point(0, 0);
            this.dgv_orderItems.Name = "dgv_orderItems";
            this.dgv_orderItems.ReadOnly = true;
            this.dgv_orderItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_orderItems.RowHeadersVisible = false;
            this.dgv_orderItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_orderItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_orderItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_orderItems.Size = new System.Drawing.Size(948, 375);
            this.dgv_orderItems.TabIndex = 1;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TOTAL AMOUNT";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Txtgrandtotal);
            this.panel1.Controls.Add(this.Txttotaldiscount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Txt_totalInvoice);
            this.panel1.Controls.Add(this.lblinvoices);
            this.panel1.Location = new System.Drawing.Point(1, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 82);
            this.panel1.TabIndex = 186;
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(647, 5);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(110, 30);
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
            this.label8.Location = new System.Drawing.Point(10, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 21);
            this.label8.TabIndex = 295;
            this.label8.Text = "SALES ORDER ITEMS";
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.BackColor = System.Drawing.Color.LimeGreen;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(758, 5);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(91, 31);
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
            this.BTNClose.Location = new System.Drawing.Point(850, 5);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 30);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
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
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(948, 59);
            this.panel3.TabIndex = 187;
            // 
            // SalesOrderItemReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(950, 514);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesOrderItemReport";
            this.Text = "Sales Order Item Report";
            this.Load += new System.EventHandler(this.SalesOrderItemReport_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_orderItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtgrandtotal;
        private System.Windows.Forms.TextBox Txttotaldiscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_totalInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLDocNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.Label lblinvoices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_orderItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Panel panel3;
    }
}