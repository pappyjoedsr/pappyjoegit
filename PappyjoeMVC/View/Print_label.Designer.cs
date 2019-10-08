namespace PappyjoeMVC.View
{
    partial class Print_Label
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Label));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Gridpatient = new System.Windows.Forms.DataGridView();
            this.colid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colgender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVisited = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colselected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gridpatient)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.TxtSearch);
            this.panel1.Controls.Add(this.lblsearch);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 75);
            this.panel1.TabIndex = 8;
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TxtSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtSearch.Location = new System.Drawing.Point(118, 28);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(300, 20);
            this.TxtSearch.TabIndex = 3;
            this.TxtSearch.Text = "Search Patient Here";
            this.TxtSearch.Click += new System.EventHandler(this.TxtSearch_Click);
            this.TxtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyUp);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblsearch.Location = new System.Drawing.Point(11, 29);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(95, 17);
            this.lblsearch.TabIndex = 2;
            this.lblsearch.Text = "Search Patient";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.LimeGreen;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(911, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 27);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print Preview";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.Gridpatient);
            this.panel2.Location = new System.Drawing.Point(3, 80);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1052, 534);
            this.panel2.TabIndex = 65;
            // 
            // Gridpatient
            // 
            this.Gridpatient.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Gridpatient.AllowUserToAddRows = false;
            this.Gridpatient.AllowUserToDeleteRows = false;
            this.Gridpatient.AllowUserToResizeColumns = false;
            this.Gridpatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Gridpatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Gridpatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Gridpatient.BackgroundColor = System.Drawing.Color.White;
            this.Gridpatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Gridpatient.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Gridpatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Gridpatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colid,
            this.collId,
            this.colName,
            this.colgender,
            this.colAge,
            this.colMob,
            this.colstreet,
            this.colVisited,
            this.colOP,
            this.colselected});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Gridpatient.DefaultCellStyle = dataGridViewCellStyle2;
            this.Gridpatient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gridpatient.GridColor = System.Drawing.Color.White;
            this.Gridpatient.Location = new System.Drawing.Point(0, 0);
            this.Gridpatient.Name = "Gridpatient";
            this.Gridpatient.RowHeadersVisible = false;
            this.Gridpatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.Gridpatient.Size = new System.Drawing.Size(1052, 534);
            this.Gridpatient.TabIndex = 62;
            this.Gridpatient.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Gridpatient_DataError);
            // 
            // colid
            // 
            this.colid.HeaderText = "pid";
            this.colid.Name = "colid";
            this.colid.Visible = false;
            // 
            // collId
            // 
            this.collId.HeaderText = "Id";
            this.collId.Name = "collId";
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            // 
            // colgender
            // 
            this.colgender.HeaderText = "Gender";
            this.colgender.Name = "colgender";
            // 
            // colAge
            // 
            this.colAge.HeaderText = "Age";
            this.colAge.Name = "colAge";
            // 
            // colMob
            // 
            this.colMob.HeaderText = "Mobile";
            this.colMob.Name = "colMob";
            // 
            // colstreet
            // 
            this.colstreet.HeaderText = "Street Address";
            this.colstreet.Name = "colstreet";
            // 
            // colVisited
            // 
            this.colVisited.HeaderText = "Visited";
            this.colVisited.Name = "colVisited";
            // 
            // colOP
            // 
            this.colOP.HeaderText = "Opticket";
            this.colOP.Name = "colOP";
            // 
            // colselected
            // 
            this.colselected.HeaderText = "Selected";
            this.colselected.Name = "colselected";
            // 
            // Print_Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 621);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Print_Label";
            this.Text = "Print Label";
            this.Load += new System.EventHandler(this.Print_label_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gridpatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView Gridpatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colid;
        private System.Windows.Forms.DataGridViewTextBoxColumn collId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMob;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVisited;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colselected;
    }
}