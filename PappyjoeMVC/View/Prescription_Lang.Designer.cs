namespace PappyjoeMVC.View
{
    partial class Prescription_Lang
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
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveLang = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(248, 76);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(180, 21);
            this.cmbLanguage.TabIndex = 153;
            this.cmbLanguage.SelectedIndexChanged += new System.EventHandler(this.cmbLanguage_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline);
            this.label19.Location = new System.Drawing.Point(26, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(395, 25);
            this.label19.TabIndex = 154;
            this.label19.Text = "Prescription and Appointment SMS Language";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 155;
            this.label1.Text = "Choose prescription language ";
            // 
            // btnSaveLang
            // 
            this.btnSaveLang.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSaveLang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveLang.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveLang.ForeColor = System.Drawing.Color.White;
            this.btnSaveLang.Location = new System.Drawing.Point(453, 74);
            this.btnSaveLang.Name = "btnSaveLang";
            this.btnSaveLang.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLang.TabIndex = 156;
            this.btnSaveLang.Text = "Save";
            this.btnSaveLang.UseVisualStyleBackColor = false;
            this.btnSaveLang.Click += new System.EventHandler(this.btnSaveLang_Click);
            // 
            // Prescription_Lang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveLang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbLanguage);
            this.Name = "Prescription_Lang";
            this.Text = "Prescription Lang";
            this.Load += new System.EventHandler(this.Prescription_Lang_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveLang;
    }
}