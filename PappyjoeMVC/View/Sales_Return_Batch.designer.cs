namespace PappyjoeMVC.View
{
    partial class Sales_Return_Batch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_Return_Batch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_batchSale = new System.Windows.Forms.DataGridView();
            this.colbatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oldstock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReturnQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchentry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_batchSale)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 44);
            this.panel1.TabIndex = 207;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.Color.Tomato;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(320, 7);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(73, 30);
            this.btn_Cancel.TabIndex = 203;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(248, 7);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(72, 30);
            this.btn_OK.TabIndex = 204;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_batchSale);
            this.panel2.Location = new System.Drawing.Point(-1, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 416);
            this.panel2.TabIndex = 209;
            // 
            // dgv_batchSale
            // 
            this.dgv_batchSale.AllowUserToAddRows = false;
            this.dgv_batchSale.AllowUserToDeleteRows = false;
            this.dgv_batchSale.AllowUserToOrderColumns = true;
            this.dgv_batchSale.AllowUserToResizeColumns = false;
            this.dgv_batchSale.AllowUserToResizeRows = false;
            this.dgv_batchSale.BackgroundColor = System.Drawing.Color.White;
            this.dgv_batchSale.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_batchSale.ColumnHeadersHeight = 35;
            this.dgv_batchSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_batchSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colbatchNo,
            this.oldstock,
            this.ColQty,
            this.colReturnQty,
            this.colCurrentStock,
            this.colBatchentry,
            this.colEntry});
            this.dgv_batchSale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_batchSale.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_batchSale.Location = new System.Drawing.Point(0, 0);
            this.dgv_batchSale.Name = "dgv_batchSale";
            this.dgv_batchSale.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_batchSale.RowHeadersVisible = false;
            this.dgv_batchSale.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_batchSale.Size = new System.Drawing.Size(398, 416);
            this.dgv_batchSale.TabIndex = 207;
            this.dgv_batchSale.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_batchSale_CellBeginEdit);
            this.dgv_batchSale.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_batchSale_EditingControlShowing);
            // 
            // colbatchNo
            // 
            this.colbatchNo.FillWeight = 197.9695F;
            this.colbatchNo.HeaderText = "Batch Number";
            this.colbatchNo.Name = "colbatchNo";
            this.colbatchNo.Width = 134;
            // 
            // oldstock
            // 
            this.oldstock.HeaderText = "Old Stock";
            this.oldstock.Name = "oldstock";
            this.oldstock.Visible = false;
            this.oldstock.Width = 30;
            // 
            // ColQty
            // 
            this.ColQty.FillWeight = 64.70551F;
            this.ColQty.HeaderText = "Quantity(in Nos)";
            this.ColQty.Name = "ColQty";
            this.ColQty.Width = 120;
            // 
            // colReturnQty
            // 
            this.colReturnQty.FillWeight = 37.32494F;
            this.colReturnQty.HeaderText = "Return Quantity(in Nos)";
            this.colReturnQty.Name = "colReturnQty";
            this.colReturnQty.Width = 140;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.HeaderText = "Curent Stock";
            this.colCurrentStock.Name = "colCurrentStock";
            this.colCurrentStock.Visible = false;
            this.colCurrentStock.Width = 30;
            // 
            // colBatchentry
            // 
            this.colBatchentry.HeaderText = "Batchentry";
            this.colBatchentry.Name = "colBatchentry";
            this.colBatchentry.Visible = false;
            this.colBatchentry.Width = 30;
            // 
            // colEntry
            // 
            this.colEntry.HeaderText = "EntryNo";
            this.colEntry.Name = "colEntry";
            this.colEntry.Visible = false;
            this.colEntry.Width = 25;
            // 
            // Sales_Return_Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 455);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sales_Return_Batch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Return Batch";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Sales_Return_Batch_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_batchSale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_batchSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn oldstock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchentry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEntry;
    }
}