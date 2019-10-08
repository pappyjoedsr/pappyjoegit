namespace PappyjoeMVC.View
{
    partial class ItemBatchDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemBatchDetails));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgv_batch = new System.Windows.Forms.DataGridView();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_batch)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(803, 37);
            this.panel2.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(3, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 21);
            this.label8.TabIndex = 304;
            this.label8.Text = " BATCH DETAILS\r\n";
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.BackColor = System.Drawing.Color.Tomato;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(715, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(85, 30);
            this.btn_close.TabIndex = 302;
            this.btn_close.Text = "CLOSE";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Lab_Msg);
            this.panel1.Controls.Add(this.dgv_batch);
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 277);
            this.panel1.TabIndex = 3;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(309, 127);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(177, 20);
            this.Lab_Msg.TabIndex = 304;
            this.Lab_Msg.Text = "Item does not have batch";
            this.Lab_Msg.Visible = false;
            // 
            // dgv_batch
            // 
            this.dgv_batch.AllowUserToAddRows = false;
            this.dgv_batch.AllowUserToDeleteRows = false;
            this.dgv_batch.AllowUserToResizeColumns = false;
            this.dgv_batch.AllowUserToResizeRows = false;
            this.dgv_batch.BackgroundColor = System.Drawing.Color.White;
            this.dgv_batch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_batch.ColumnHeadersHeight = 25;
            this.dgv_batch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_batch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBatchNo,
            this.colQty,
            this.colExp,
            this.colPrddate,
            this.colPurchaseNo,
            this.colPurdate,
            this.colSupId});
            this.dgv_batch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_batch.GridColor = System.Drawing.Color.LightGray;
            this.dgv_batch.Location = new System.Drawing.Point(0, 0);
            this.dgv_batch.Name = "dgv_batch";
            this.dgv_batch.ReadOnly = true;
            this.dgv_batch.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_batch.RowHeadersVisible = false;
            this.dgv_batch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.dgv_batch.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_batch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_batch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_batch.Size = new System.Drawing.Size(804, 277);
            this.dgv_batch.TabIndex = 0;
            // 
            // colBatchNo
            // 
            this.colBatchNo.HeaderText = "Batch Number";
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.ReadOnly = true;
            this.colBatchNo.Width = 135;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Quantity";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colExp
            // 
            this.colExp.HeaderText = "Exp.Date";
            this.colExp.Name = "colExp";
            this.colExp.ReadOnly = true;
            this.colExp.Width = 120;
            // 
            // colPrddate
            // 
            this.colPrddate.HeaderText = "Prd.Date";
            this.colPrddate.Name = "colPrddate";
            this.colPrddate.ReadOnly = true;
            this.colPrddate.Width = 115;
            // 
            // colPurchaseNo
            // 
            this.colPurchaseNo.HeaderText = "Purchase No";
            this.colPurchaseNo.Name = "colPurchaseNo";
            this.colPurchaseNo.ReadOnly = true;
            this.colPurchaseNo.Width = 110;
            // 
            // colPurdate
            // 
            this.colPurdate.HeaderText = "Purchase Date";
            this.colPurdate.Name = "colPurdate";
            this.colPurdate.ReadOnly = true;
            this.colPurdate.Width = 115;
            // 
            // colSupId
            // 
            this.colSupId.HeaderText = "Supplier Id";
            this.colSupId.Name = "colSupId";
            this.colSupId.ReadOnly = true;
            this.colSupId.Width = 110;
            // 
            // ItemBatchDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemBatchDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batch Details";
            this.Load += new System.EventHandler(this.FrmItemBatchDetails_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_batch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgv_batch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrddate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSupId;
    }
}