namespace PappyjoeMVC.View
{
    partial class Batch_Sale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Batch_Sale));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_batchSale = new System.Windows.Forms.DataGridView();
            this.colentryNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrd_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 44);
            this.panel1.TabIndex = 206;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.Color.Tomato;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(529, 5);
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
            this.btn_OK.Location = new System.Drawing.Point(457, 5);
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
            this.panel2.Location = new System.Drawing.Point(2, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 415);
            this.panel2.TabIndex = 207;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_batchSale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_batchSale.ColumnHeadersHeight = 25;
            this.dgv_batchSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_batchSale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colentryNo,
            this.colbatchNo,
            this.ColStock,
            this.ColPrd_Date,
            this.colExpDate,
            this.clUnit,
            this.ColQty,
            this.colCurrentStock});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_batchSale.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_batchSale.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgv_batchSale.Location = new System.Drawing.Point(3, 3);
            this.dgv_batchSale.Name = "dgv_batchSale";
            this.dgv_batchSale.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_batchSale.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_batchSale.RowHeadersVisible = false;
            this.dgv_batchSale.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_batchSale.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_batchSale.Size = new System.Drawing.Size(602, 409);
            this.dgv_batchSale.TabIndex = 0;
            this.dgv_batchSale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_batchSale_KeyPress);
            // 
            // colentryNo
            // 
            this.colentryNo.HeaderText = "Entry No";
            this.colentryNo.Name = "colentryNo";
            this.colentryNo.Visible = false;
            // 
            // colbatchNo
            // 
            this.colbatchNo.HeaderText = "Batch Number";
            this.colbatchNo.Name = "colbatchNo";
            // 
            // ColStock
            // 
            this.ColStock.HeaderText = "Stock";
            this.ColStock.Name = "ColStock";
            // 
            // ColPrd_Date
            // 
            this.ColPrd_Date.HeaderText = "Product Date";
            this.ColPrd_Date.Name = "ColPrd_Date";
            this.ColPrd_Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colExpDate
            // 
            this.colExpDate.HeaderText = "Exp.Date";
            this.colExpDate.Name = "colExpDate";
            // 
            // clUnit
            // 
            this.clUnit.HeaderText = "Unit";
            this.clUnit.Name = "clUnit";
            // 
            // ColQty
            // 
            this.ColQty.HeaderText = "Quantity";
            this.ColQty.Name = "ColQty";
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.HeaderText = "Curent Stock";
            this.colCurrentStock.Name = "colCurrentStock";
            // 
            // Batch_Sale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(612, 463);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Batch_Sale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Sale";
            this.Load += new System.EventHandler(this.frmbatchSale_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colentryNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrd_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurrentStock;
    }
}