namespace PappyjoeMVC.View
{
    partial class Contacts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contacts));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Contact = new System.Windows.Forms.DataGridView();
            this.text_search = new System.Windows.Forms.TextBox();
            this.buttonclear = new System.Windows.Forms.Button();
            this.buttonsave = new System.Windows.Forms.Button();
            this.text_contact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Lab_InvalidNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RTB_AddNotes = new System.Windows.Forms.RichTextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Contact)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(235, 145);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 28);
            this.btn_Cancel.TabIndex = 289;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label4.Location = new System.Drawing.Point(166, -50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 287;
            this.label4.Text = "Contacts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(101, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 285;
            this.label2.Text = "Search";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(57, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 286;
            this.label1.Text = "Contact Name";
            // 
            // dgv_Contact
            // 
            this.dgv_Contact.AllowUserToAddRows = false;
            this.dgv_Contact.AllowUserToDeleteRows = false;
            this.dgv_Contact.AllowUserToResizeColumns = false;
            this.dgv_Contact.AllowUserToResizeRows = false;
            this.dgv_Contact.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Contact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Contact.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Contact.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Contact.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Contact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Contact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.edit,
            this.delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Contact.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Contact.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dgv_Contact.Location = new System.Drawing.Point(151, 218);
            this.dgv_Contact.Name = "dgv_Contact";
            this.dgv_Contact.ReadOnly = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Contact.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Contact.RowHeadersVisible = false;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgv_Contact.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Contact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Contact.Size = new System.Drawing.Size(465, 354);
            this.dgv_Contact.TabIndex = 284;
            this.dgv_Contact.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Contact_CellClick);
            // 
            // text_search
            // 
            this.text_search.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.text_search.Location = new System.Drawing.Point(154, 179);
            this.text_search.Name = "text_search";
            this.text_search.Size = new System.Drawing.Size(328, 20);
            this.text_search.TabIndex = 283;
            this.text_search.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_search_KeyUp);
            // 
            // buttonclear
            // 
            this.buttonclear.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonclear.ForeColor = System.Drawing.Color.White;
            this.buttonclear.Location = new System.Drawing.Point(488, 35);
            this.buttonclear.Name = "buttonclear";
            this.buttonclear.Size = new System.Drawing.Size(67, 22);
            this.buttonclear.TabIndex = 281;
            this.buttonclear.Text = "Clear All";
            this.buttonclear.UseVisualStyleBackColor = false;
            this.buttonclear.Click += new System.EventHandler(this.buttonclear_Click);
            // 
            // buttonsave
            // 
            this.buttonsave.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonsave.ForeColor = System.Drawing.Color.White;
            this.buttonsave.Location = new System.Drawing.Point(154, 145);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(75, 28);
            this.buttonsave.TabIndex = 282;
            this.buttonsave.Text = "Save";
            this.buttonsave.UseVisualStyleBackColor = false;
            this.buttonsave.Click += new System.EventHandler(this.buttonsave_Click);
            // 
            // text_contact
            // 
            this.text_contact.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.text_contact.Location = new System.Drawing.Point(154, 37);
            this.text_contact.Name = "text_contact";
            this.text_contact.Size = new System.Drawing.Size(328, 20);
            this.text_contact.TabIndex = 280;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(16, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 290;
            this.label3.Text = "Contacts";
            // 
            // Lab_InvalidNumber
            // 
            this.Lab_InvalidNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_InvalidNumber.ForeColor = System.Drawing.Color.Red;
            this.Lab_InvalidNumber.Location = new System.Drawing.Point(485, 67);
            this.Lab_InvalidNumber.Name = "Lab_InvalidNumber";
            this.Lab_InvalidNumber.Size = new System.Drawing.Size(103, 18);
            this.Lab_InvalidNumber.TabIndex = 293;
            this.Lab_InvalidNumber.Text = "Invalid number";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(57, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 294;
            this.label5.Text = "Mobile No";
            // 
            // txtMobNumber
            // 
            this.txtMobNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtMobNumber.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtMobNumber.Location = new System.Drawing.Point(154, 66);
            this.txtMobNumber.MaxLength = 10;
            this.txtMobNumber.Name = "txtMobNumber";
            this.txtMobNumber.Size = new System.Drawing.Size(328, 20);
            this.txtMobNumber.TabIndex = 291;
            this.txtMobNumber.Leave += new System.EventHandler(this.txtMobNumber_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(57, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 295;
            this.label6.Text = "Add Notes";
            // 
            // RTB_AddNotes
            // 
            this.RTB_AddNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTB_AddNotes.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.RTB_AddNotes.Location = new System.Drawing.Point(154, 92);
            this.RTB_AddNotes.Name = "RTB_AddNotes";
            this.RTB_AddNotes.Size = new System.Drawing.Size(328, 47);
            this.RTB_AddNotes.TabIndex = 296;
            this.RTB_AddNotes.Text = "";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.DataPropertyName = "contact";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Contact Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mobile No";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Notes";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.Image = global::PappyjoeMVC.Properties.Resources.editicon;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Width = 19;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.Image = global::PappyjoeMVC.Properties.Resources.deleteicon;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Width = 19;
            // 
            // Contacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(967, 575);
            this.Controls.Add(this.RTB_AddNotes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Lab_InvalidNumber);
            this.Controls.Add(this.txtMobNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Contact);
            this.Controls.Add(this.text_search);
            this.Controls.Add(this.buttonclear);
            this.Controls.Add(this.buttonsave);
            this.Controls.Add(this.text_contact);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Contacts";
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.Contacts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Contact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Contact;
        private System.Windows.Forms.TextBox text_search;
        private System.Windows.Forms.Button buttonclear;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.TextBox text_contact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Lab_InvalidNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMobNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox RTB_AddNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}