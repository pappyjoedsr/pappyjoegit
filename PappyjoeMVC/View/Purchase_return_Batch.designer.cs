namespace PappyjoeMVC.View
{
    partial class Purchase_return_Batch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchase_return_Batch));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPurchaseBatch = new System.Windows.Forms.DataGridView();
            this.Branch_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Return_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prd_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exp_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.dtpExp = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseBatch)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.dgvPurchaseBatch);
            this.panel1.Controls.Add(this.dtp);
            this.panel1.Controls.Add(this.dtpExp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 391);
            this.panel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(709, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(618, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "OK";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPurchaseBatch
            // 
            this.dgvPurchaseBatch.AllowUserToAddRows = false;
            this.dgvPurchaseBatch.AllowUserToResizeColumns = false;
            this.dgvPurchaseBatch.AllowUserToResizeRows = false;
            this.dgvPurchaseBatch.BackgroundColor = System.Drawing.Color.White;
            this.dgvPurchaseBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseBatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Branch_No,
            this.col_unit,
            this.Quantity,
            this.Return_Qty,
            this.Prd_Date,
            this.Exp_Date});
            this.dgvPurchaseBatch.Location = new System.Drawing.Point(3, 45);
            this.dgvPurchaseBatch.Name = "dgvPurchaseBatch";
            this.dgvPurchaseBatch.RowHeadersVisible = false;
            this.dgvPurchaseBatch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPurchaseBatch.Size = new System.Drawing.Size(797, 344);
            this.dgvPurchaseBatch.TabIndex = 0;
            this.dgvPurchaseBatch.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPurchaseBatch_EditingControlShowing);
            this.dgvPurchaseBatch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPurchaseBatch_KeyPress);
            // 
            // Branch_No
            // 
            this.Branch_No.DataPropertyName = "BatchNumber";
            this.Branch_No.HeaderText = "Batch_No";
            this.Branch_No.Name = "Branch_No";
            this.Branch_No.ReadOnly = true;
            this.Branch_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_unit
            // 
            this.col_unit.HeaderText = "Unit";
            this.col_unit.Name = "col_unit";
            this.col_unit.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Qty";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Return_Qty
            // 
            this.Return_Qty.HeaderText = "Return Qty";
            this.Return_Qty.Name = "Return_Qty";
            // 
            // Prd_Date
            // 
            this.Prd_Date.DataPropertyName = "PrdDate";
            this.Prd_Date.HeaderText = "Prd_Date";
            this.Prd_Date.Name = "Prd_Date";
            this.Prd_Date.ReadOnly = true;
            this.Prd_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Prd_Date.Width = 200;
            // 
            // Exp_Date
            // 
            this.Exp_Date.DataPropertyName = "ExpDate";
            this.Exp_Date.HeaderText = "Exp_Date";
            this.Exp_Date.Name = "Exp_Date";
            this.Exp_Date.ReadOnly = true;
            this.Exp_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Exp_Date.Width = 200;
            // 
            // dtp
            // 
            this.dtp.Location = new System.Drawing.Point(96, 50);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(200, 20);
            this.dtp.TabIndex = 6;
            // 
            // dtpExp
            // 
            this.dtpExp.Location = new System.Drawing.Point(322, 50);
            this.dtpExp.Name = "dtpExp";
            this.dtpExp.Size = new System.Drawing.Size(200, 20);
            this.dtpExp.TabIndex = 7;
            // 
            // Purchase_return_Batch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(802, 391);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Purchase_return_Batch";
            this.Text = "Items Batch";
            this.Load += new System.EventHandler(this.Purchase_return_Batch_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseBatch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPurchaseBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Branch_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Return_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prd_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exp_Date;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.DateTimePicker dtpExp;
    }
}