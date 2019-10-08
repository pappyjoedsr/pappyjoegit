namespace PappyjoeMVC.View
{
    partial class Trackingnullstatus
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trackingnullstatus));
            this.dataGridView1_treatment_paln = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.img = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addLabOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label41 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_treatment_paln)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1_treatment_paln
            // 
            this.dataGridView1_treatment_paln.AllowUserToAddRows = false;
            this.dataGridView1_treatment_paln.AllowUserToDeleteRows = false;
            this.dataGridView1_treatment_paln.AllowUserToResizeColumns = false;
            this.dataGridView1_treatment_paln.AllowUserToResizeRows = false;
            this.dataGridView1_treatment_paln.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1_treatment_paln.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1_treatment_paln.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1_treatment_paln.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1_treatment_paln.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1_treatment_paln.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1_treatment_paln.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.workName,
            this.Type,
            this.Status,
            this.img,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1_treatment_paln.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1_treatment_paln.Location = new System.Drawing.Point(2, 46);
            this.dataGridView1_treatment_paln.Name = "dataGridView1_treatment_paln";
            this.dataGridView1_treatment_paln.ReadOnly = true;
            this.dataGridView1_treatment_paln.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1_treatment_paln.RowHeadersVisible = false;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1_treatment_paln.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1_treatment_paln.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1_treatment_paln.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1_treatment_paln.Size = new System.Drawing.Size(707, 269);
            this.dataGridView1_treatment_paln.TabIndex = 265;
            this.dataGridView1_treatment_paln.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_treatment_paln_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Work ID";
            this.Id.HeaderText = "Work ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // workName
            // 
            this.workName.DataPropertyName = "Work Name";
            this.workName.HeaderText = "Work Name";
            this.workName.Name = "workName";
            this.workName.ReadOnly = true;
            this.workName.Width = 250;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Work Type";
            this.Type.HeaderText = "Work Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "pt_name";
            this.Status.HeaderText = "Patient";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 150;
            // 
            // img
            // 
            this.img.FillWeight = 50F;
            this.img.HeaderText = "";
            this.img.Image = global::PappyjoeMVC.Properties.Resources.Bill;
            this.img.Name = "img";
            this.img.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "pt_id";
            this.Column1.HeaderText = "pt_id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.addLabOrderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 32);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
            // 
            // addLabOrderToolStripMenuItem
            // 
            this.addLabOrderToolStripMenuItem.Name = "addLabOrderToolStripMenuItem";
            this.addLabOrderToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.addLabOrderToolStripMenuItem.Text = "Add Lab Order";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label41.Location = new System.Drawing.Point(13, 5);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(92, 21);
            this.label41.TabIndex = 266;
            this.label41.Text = "LAB ORDER";
            // 
            // Trackingnullstatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 321);
            this.Controls.Add(this.dataGridView1_treatment_paln);
            this.Controls.Add(this.label41);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Trackingnullstatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab Order";
            this.Load += new System.EventHandler(this.Trackingnullstatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_treatment_paln)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_treatment_paln;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem addLabOrderToolStripMenuItem;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn workName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn img;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}