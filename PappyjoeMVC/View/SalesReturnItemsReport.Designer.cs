namespace PappyjoeMVC.View
{
    partial class SalesReturnItemsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesReturnItemsReport));
            this.panel4 = new System.Windows.Forms.Panel();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FreeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNIT2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmopunt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_ReturnItems = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtgrandtotal = new System.Windows.Forms.TextBox();
            this.Txt_TOTALCOST = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnExport = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.BTNClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReturnItems)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkGray;
            this.panel4.Location = new System.Drawing.Point(-5, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(969, 1);
            this.panel4.TabIndex = 187;
            // 
            // Rate
            // 
            this.Rate.FillWeight = 98.479F;
            this.Rate.HeaderText = "COST";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            this.Rate.Width = 110;
            // 
            // Qty
            // 
            this.Qty.FillWeight = 96.25566F;
            this.Qty.HeaderText = "QUANTITY";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // IGST
            // 
            this.IGST.HeaderText = "IGST";
            this.IGST.Name = "IGST";
            this.IGST.ReadOnly = true;
            this.IGST.Width = 85;
            // 
            // GST
            // 
            this.GST.HeaderText = "GST";
            this.GST.MinimumWidth = 85;
            this.GST.Name = "GST";
            this.GST.ReadOnly = true;
            // 
            // FreeQty
            // 
            this.FreeQty.FillWeight = 98.48137F;
            this.FreeQty.HeaderText = "FREE ";
            this.FreeQty.Name = "FreeQty";
            this.FreeQty.ReadOnly = true;
            this.FreeQty.Width = 85;
            // 
            // UNIT2
            // 
            this.UNIT2.FillWeight = 99.50178F;
            this.UNIT2.HeaderText = "UNIT2";
            this.UNIT2.Name = "UNIT2";
            this.UNIT2.ReadOnly = true;
            this.UNIT2.Width = 85;
            // 
            // Item_Code
            // 
            this.Item_Code.FillWeight = 153.0113F;
            this.Item_Code.HeaderText = "ITEM CODE";
            this.Item_Code.Name = "Item_Code";
            this.Item_Code.ReadOnly = true;
            this.Item_Code.Width = 125;
            // 
            // RetNumber
            // 
            this.RetNumber.FillWeight = 105.8152F;
            this.RetNumber.HeaderText = "RETURN No";
            this.RetNumber.Name = "RetNumber";
            this.RetNumber.ReadOnly = true;
            this.RetNumber.Width = 95;
            // 
            // SLNO
            // 
            this.SLNO.FillWeight = 48.4558F;
            this.SLNO.HeaderText = "SLNO";
            this.SLNO.Name = "SLNO";
            this.SLNO.ReadOnly = true;
            this.SLNO.Width = 55;
            // 
            // TotalAmopunt
            // 
            this.TotalAmopunt.HeaderText = "TOTAL AMOUNT";
            this.TotalAmopunt.Name = "TotalAmopunt";
            this.TotalAmopunt.ReadOnly = true;
            this.TotalAmopunt.Width = 115;
            // 
            // dgv_ReturnItems
            // 
            this.dgv_ReturnItems.AllowUserToAddRows = false;
            this.dgv_ReturnItems.AllowUserToDeleteRows = false;
            this.dgv_ReturnItems.AllowUserToResizeColumns = false;
            this.dgv_ReturnItems.AllowUserToResizeRows = false;
            this.dgv_ReturnItems.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv_ReturnItems.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ReturnItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ReturnItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_ReturnItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_ReturnItems.ColumnHeadersHeight = 25;
            this.dgv_ReturnItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_ReturnItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SLNO,
            this.RetNumber,
            this.Item_Code,
            this.UNIT2,
            this.FreeQty,
            this.GST,
            this.IGST,
            this.Qty,
            this.Rate,
            this.TotalAmopunt});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ReturnItems.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ReturnItems.GridColor = System.Drawing.Color.DimGray;
            this.dgv_ReturnItems.Location = new System.Drawing.Point(0, 3);
            this.dgv_ReturnItems.Name = "dgv_ReturnItems";
            this.dgv_ReturnItems.ReadOnly = true;
            this.dgv_ReturnItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_ReturnItems.RowHeadersVisible = false;
            this.dgv_ReturnItems.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_ReturnItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_ReturnItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ReturnItems.Size = new System.Drawing.Size(957, 409);
            this.dgv_ReturnItems.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(755, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 171;
            this.label2.Text = "Total Amount";
            // 
            // Txtgrandtotal
            // 
            this.Txtgrandtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txtgrandtotal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txtgrandtotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txtgrandtotal.Location = new System.Drawing.Point(856, 29);
            this.Txtgrandtotal.Name = "Txtgrandtotal";
            this.Txtgrandtotal.ReadOnly = true;
            this.Txtgrandtotal.Size = new System.Drawing.Size(96, 25);
            this.Txtgrandtotal.TabIndex = 11;
            this.Txtgrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_TOTALCOST
            // 
            this.Txt_TOTALCOST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_TOTALCOST.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_TOTALCOST.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Txt_TOTALCOST.Location = new System.Drawing.Point(856, 8);
            this.Txt_TOTALCOST.Name = "Txt_TOTALCOST";
            this.Txt_TOTALCOST.ReadOnly = true;
            this.Txt_TOTALCOST.Size = new System.Drawing.Size(96, 22);
            this.Txt_TOTALCOST.TabIndex = 9;
            this.Txt_TOTALCOST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(778, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Total Cost";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Txtgrandtotal);
            this.panel1.Controls.Add(this.Txt_TOTALCOST);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(959, 63);
            this.panel1.TabIndex = 189;
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.BtnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ForeColor = System.Drawing.Color.White;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExport.Location = new System.Drawing.Point(657, 5);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(114, 30);
            this.BtnExport.TabIndex = 300;
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
            this.label8.Location = new System.Drawing.Point(11, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 21);
            this.label8.TabIndex = 295;
            this.label8.Text = "SALES RETURN ITEMS";
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
            this.btnprint.Location = new System.Drawing.Point(773, 5);
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
            this.BTNClose.Location = new System.Drawing.Point(865, 5);
            this.BTNClose.Name = "BTNClose";
            this.BTNClose.Size = new System.Drawing.Size(91, 31);
            this.BTNClose.TabIndex = 177;
            this.BTNClose.Text = "CLOSE";
            this.BTNClose.UseVisualStyleBackColor = false;
            this.BTNClose.Click += new System.EventHandler(this.BTNClose_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_ReturnItems);
            this.panel2.Location = new System.Drawing.Point(-1, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(957, 409);
            this.panel2.TabIndex = 190;
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
            this.panel3.Size = new System.Drawing.Size(963, 51);
            this.panel3.TabIndex = 188;
            // 
            // SalesReturnItemsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 520);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SalesReturnItemsReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Return Items Report";
            this.Load += new System.EventHandler(this.SalesReturnItemsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReturnItems)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn GST;
        private System.Windows.Forms.DataGridViewTextBoxColumn FreeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNIT2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmopunt;
        private System.Windows.Forms.DataGridView dgv_ReturnItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtgrandtotal;
        private System.Windows.Forms.TextBox Txt_TOTALCOST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button BTNClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}