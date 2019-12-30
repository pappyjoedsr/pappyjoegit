namespace PappyjoeMVC.View
{
    partial class Billing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Billing));
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView_Billing = new System.Windows.Forms.DataGridView();
            this.buttonclear = new System.Windows.Forms.Button();
            this.buttonsave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.text_taxvalue = new System.Windows.Forms.TextBox();
            this.text_taxname = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Billing)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(16, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 25);
            this.label19.TabIndex = 125;
            this.label19.Text = "Billing";
            // 
            // dataGridView_Billing
            // 
            this.dataGridView_Billing.AllowUserToAddRows = false;
            this.dataGridView_Billing.AllowUserToDeleteRows = false;
            this.dataGridView_Billing.AllowUserToResizeColumns = false;
            this.dataGridView_Billing.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_Billing.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Billing.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Billing.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Billing.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView_Billing.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Billing.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Billing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_Billing.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.tax,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Billing.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Billing.GridColor = System.Drawing.Color.White;
            this.dataGridView_Billing.Location = new System.Drawing.Point(99, 170);
            this.dataGridView_Billing.MultiSelect = false;
            this.dataGridView_Billing.Name = "dataGridView_Billing";
            this.dataGridView_Billing.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Billing.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Billing.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_Billing.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Billing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Billing.Size = new System.Drawing.Size(355, 235);
            this.dataGridView_Billing.TabIndex = 133;
            this.dataGridView_Billing.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Billing_CellClick);
            // 
            // buttonclear
            // 
            this.buttonclear.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonclear.ForeColor = System.Drawing.Color.White;
            this.buttonclear.Location = new System.Drawing.Point(261, 121);
            this.buttonclear.Name = "buttonclear";
            this.buttonclear.Size = new System.Drawing.Size(75, 28);
            this.buttonclear.TabIndex = 131;
            this.buttonclear.Text = "Clear";
            this.buttonclear.UseVisualStyleBackColor = false;
            this.buttonclear.Click += new System.EventHandler(this.buttonclear_Click);
            // 
            // buttonsave
            // 
            this.buttonsave.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonsave.ForeColor = System.Drawing.Color.White;
            this.buttonsave.Location = new System.Drawing.Point(180, 121);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(75, 28);
            this.buttonsave.TabIndex = 132;
            this.buttonsave.Text = "Save";
            this.buttonsave.UseVisualStyleBackColor = false;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(292, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 128;
            this.label6.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(103, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 129;
            this.label2.Text = "Tax Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(99, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 130;
            this.label1.Text = "Tax Name";
            // 
            // text_taxvalue
            // 
            this.text_taxvalue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_taxvalue.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.text_taxvalue.Location = new System.Drawing.Point(180, 90);
            this.text_taxvalue.Name = "text_taxvalue";
            this.text_taxvalue.Size = new System.Drawing.Size(109, 20);
            this.text_taxvalue.TabIndex = 127;
            // 
            // text_taxname
            // 
            this.text_taxname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_taxname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.text_taxname.Location = new System.Drawing.Point(180, 62);
            this.text_taxname.Name = "text_taxname";
            this.text_taxname.Size = new System.Drawing.Size(357, 20);
            this.text_taxname.TabIndex = 126;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 150;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "tax_name";
            this.name.HeaderText = "Tax Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // tax
            // 
            this.tax.DataPropertyName = "tax_value";
            this.tax.HeaderText = "Tax Value";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 19;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "";
            this.Delete.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Width = 19;
            // 
            // Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1005, 535);
            this.Controls.Add(this.dataGridView_Billing);
            this.Controls.Add(this.buttonclear);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_taxvalue);
            this.Controls.Add(this.text_taxname);
            this.Controls.Add(this.label19);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Billing";
            this.Text = "Billing";
            this.Load += new System.EventHandler(this.Billing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Billing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dataGridView_Billing;
        private System.Windows.Forms.Button buttonclear;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_taxvalue;
        private System.Windows.Forms.TextBox text_taxname;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}