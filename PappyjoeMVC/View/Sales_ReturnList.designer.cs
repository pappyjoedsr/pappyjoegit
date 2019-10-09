﻿namespace PappyjoeMVC.View
{
    partial class Sales_ReturnList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sales_ReturnList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_Show = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DTP_To = new System.Windows.Forms.DateTimePicker();
            this.DTP_From = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.dgv_sales = new System.Windows.Forms.DataGridView();
            this.colslNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcustNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Btn_Show);
            this.panel1.Controls.Add(this.btn_Refresh);
            this.panel1.Controls.Add(this.label41);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.DTP_To);
            this.panel1.Controls.Add(this.DTP_From);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 87);
            this.panel1.TabIndex = 3;
            // 
            // Btn_Show
            // 
            this.Btn_Show.BackColor = System.Drawing.Color.LimeGreen;
            this.Btn_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Show.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Show.ForeColor = System.Drawing.Color.White;
            this.Btn_Show.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Btn_Show.Location = new System.Drawing.Point(594, 55);
            this.Btn_Show.Name = "Btn_Show";
            this.Btn_Show.Size = new System.Drawing.Size(65, 22);
            this.Btn_Show.TabIndex = 303;
            this.Btn_Show.Text = "Show";
            this.Btn_Show.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Btn_Show.UseVisualStyleBackColor = false;
            this.Btn_Show.Click += new System.EventHandler(this.Btn_Show_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Refresh.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(811, 51);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(71, 30);
            this.btn_Refresh.TabIndex = 290;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Visible = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label41.Location = new System.Drawing.Point(9, 12);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(154, 21);
            this.label41.TabIndex = 289;
            this.label41.Text = "SALES RETURN LIST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(318, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 288;
            this.label3.Text = "Date To";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(10, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 287;
            this.label8.Text = "Date From";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkGray;
            this.panel3.Location = new System.Drawing.Point(0, 41);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(895, 1);
            this.panel3.TabIndex = 209;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.Tomato;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(698, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 27);
            this.btnCancel.TabIndex = 207;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DTP_To
            // 
            this.DTP_To.Location = new System.Drawing.Point(379, 56);
            this.DTP_To.Name = "DTP_To";
            this.DTP_To.Size = new System.Drawing.Size(200, 20);
            this.DTP_To.TabIndex = 3;
            // 
            // DTP_From
            // 
            this.DTP_From.Location = new System.Drawing.Point(89, 56);
            this.DTP_From.Name = "DTP_From";
            this.DTP_From.Size = new System.Drawing.Size(200, 20);
            this.DTP_From.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.Lab_Msg);
            this.panel2.Controls.Add(this.dgv_sales);
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(1, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(893, 474);
            this.panel2.TabIndex = 5;
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(142, 212);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 279;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // dgv_sales
            // 
            this.dgv_sales.AllowUserToAddRows = false;
            this.dgv_sales.AllowUserToDeleteRows = false;
            this.dgv_sales.AllowUserToResizeColumns = false;
            this.dgv_sales.AllowUserToResizeRows = false;
            this.dgv_sales.BackgroundColor = System.Drawing.Color.White;
            this.dgv_sales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_sales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_sales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_sales.ColumnHeadersHeight = 25;
            this.dgv_sales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_sales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colslNo,
            this.RetNumber,
            this.ReturnDate,
            this.InvNumber,
            this.InvDate,
            this.colcustNo,
            this.colItems,
            this.ColAmount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_sales.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_sales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sales.GridColor = System.Drawing.Color.LightGray;
            this.dgv_sales.Location = new System.Drawing.Point(0, 0);
            this.dgv_sales.Name = "dgv_sales";
            this.dgv_sales.ReadOnly = true;
            this.dgv_sales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_sales.RowHeadersVisible = false;
            this.dgv_sales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_sales.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_sales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_sales.Size = new System.Drawing.Size(893, 474);
            this.dgv_sales.TabIndex = 3;
            // 
            // colslNo
            // 
            this.colslNo.DataPropertyName = "Sino";
            this.colslNo.HeaderText = "SlNo";
            this.colslNo.Name = "colslNo";
            this.colslNo.ReadOnly = true;
            this.colslNo.Width = 89;
            // 
            // RetNumber
            // 
            this.RetNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RetNumber.DataPropertyName = "RetNumber";
            this.RetNumber.HeaderText = "Return Number";
            this.RetNumber.Name = "RetNumber";
            this.RetNumber.ReadOnly = true;
            // 
            // ReturnDate
            // 
            this.ReturnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReturnDate.DataPropertyName = "ReturnDate";
            this.ReturnDate.HeaderText = "Return Date";
            this.ReturnDate.Name = "ReturnDate";
            this.ReturnDate.ReadOnly = true;
            // 
            // InvNumber
            // 
            this.InvNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvNumber.DataPropertyName = "InvNumber";
            this.InvNumber.HeaderText = "Invoice Number";
            this.InvNumber.Name = "InvNumber";
            this.InvNumber.ReadOnly = true;
            // 
            // InvDate
            // 
            this.InvDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvDate.DataPropertyName = "InvDate";
            this.InvDate.HeaderText = "Invoice Date";
            this.InvDate.Name = "InvDate";
            this.InvDate.ReadOnly = true;
            // 
            // colcustNo
            // 
            this.colcustNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colcustNo.DataPropertyName = "cust_number";
            this.colcustNo.HeaderText = "Customer Id";
            this.colcustNo.Name = "colcustNo";
            this.colcustNo.ReadOnly = true;
            // 
            // colItems
            // 
            this.colItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItems.DataPropertyName = "items";
            this.colItems.HeaderText = "Total Items";
            this.colItems.Name = "colItems";
            this.colItems.ReadOnly = true;
            // 
            // ColAmount
            // 
            this.ColAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColAmount.DataPropertyName = "TotalAmount";
            this.ColAmount.HeaderText = "Total Amount";
            this.ColAmount.Name = "ColAmount";
            this.ColAmount.ReadOnly = true;
            // 
            // Sales_ReturnList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Sales_ReturnList";
            this.ShowInTaskbar = false;
            this.Text = "Sales Return List";
            this.Load += new System.EventHandler(this.Sales_ReturnList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Show;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DateTimePicker DTP_To;
        private System.Windows.Forms.DateTimePicker DTP_From;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.DataGridView dgv_sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colslNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReturnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcustNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAmount;
    }
}