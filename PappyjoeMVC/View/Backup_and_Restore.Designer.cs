namespace PappyjoeMVC.View
{
    partial class Backup_and_Restore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Backup_and_Restore));
            this.btnrestore = new System.Windows.Forms.Button();
            this.lblrestore = new System.Windows.Forms.Label();
            this.btnbackup = new System.Windows.Forms.Button();
            this.lblbackup = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnrestore
            // 
            this.btnrestore.BackColor = System.Drawing.Color.LimeGreen;
            this.btnrestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrestore.ForeColor = System.Drawing.Color.White;
            this.btnrestore.Location = new System.Drawing.Point(143, 123);
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.Size = new System.Drawing.Size(75, 28);
            this.btnrestore.TabIndex = 129;
            this.btnrestore.Text = "Restore";
            this.btnrestore.UseVisualStyleBackColor = false;
            this.btnrestore.Click += new System.EventHandler(this.btnrestore_Click);
            // 
            // lblrestore
            // 
            this.lblrestore.AutoSize = true;
            this.lblrestore.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblrestore.Location = new System.Drawing.Point(45, 131);
            this.lblrestore.Name = "lblrestore";
            this.lblrestore.Size = new System.Drawing.Size(56, 17);
            this.lblrestore.TabIndex = 128;
            this.lblrestore.Text = "Restore:";
            // 
            // btnbackup
            // 
            this.btnbackup.BackColor = System.Drawing.Color.LimeGreen;
            this.btnbackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbackup.ForeColor = System.Drawing.Color.White;
            this.btnbackup.Location = new System.Drawing.Point(143, 59);
            this.btnbackup.Name = "btnbackup";
            this.btnbackup.Size = new System.Drawing.Size(75, 28);
            this.btnbackup.TabIndex = 127;
            this.btnbackup.Text = "Backup";
            this.btnbackup.UseVisualStyleBackColor = false;
            this.btnbackup.Click += new System.EventHandler(this.btnbackup_Click);
            // 
            // lblbackup
            // 
            this.lblbackup.AutoSize = true;
            this.lblbackup.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblbackup.Location = new System.Drawing.Point(45, 67);
            this.lblbackup.Name = "lblbackup";
            this.lblbackup.Size = new System.Drawing.Size(52, 17);
            this.lblbackup.TabIndex = 126;
            this.lblbackup.Text = "Backup:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(12, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(206, 25);
            this.label19.TabIndex = 130;
            this.label19.Text = "BACKUP AND RESTORE";
            // 
            // Backup_and_Restore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(574, 264);
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.lblrestore);
            this.Controls.Add(this.btnbackup);
            this.Controls.Add(this.lblbackup);
            this.Controls.Add(this.label19);
            this.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Backup_and_Restore";
            this.Text = "Backup and Restore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnrestore;
        private System.Windows.Forms.Label lblrestore;
        private System.Windows.Forms.Button btnbackup;
        private System.Windows.Forms.Label lblbackup;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label19;
    }
}