namespace Pappyjoe
{
    partial class consultation_new_patient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(consultation_new_patient));
            this.label10 = new System.Windows.Forms.Label();
            this.txtpatname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.radmail = new System.Windows.Forms.RadioButton();
            this.radfemail = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_newpatient = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.pnlmore = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.txtxAge = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtLocality = new System.Windows.Forms.TextBox();
            this.txtxStreet = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ddldoctor = new System.Windows.Forms.ComboBox();
            this.lblmore = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.grmedical = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_newpatient.SuspendLayout();
            this.pnlmore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grmedical)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(6, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 289;
            this.label10.Text = "Patient Name";
            // 
            // txtpatname
            // 
            this.txtpatname.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpatname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtpatname.Location = new System.Drawing.Point(113, 14);
            this.txtpatname.Name = "txtpatname";
            this.txtpatname.Size = new System.Drawing.Size(207, 22);
            this.txtpatname.TabIndex = 306;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(6, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 17);
            this.label11.TabIndex = 307;
            this.label11.Text = "Mobile Number";
            // 
            // txtmobile
            // 
            this.txtmobile.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmobile.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtmobile.Location = new System.Drawing.Point(113, 68);
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(207, 22);
            this.txtmobile.TabIndex = 308;
            this.txtmobile.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmobile_KeyPress);
            // 
            // radmail
            // 
            this.radmail.AutoSize = true;
            this.radmail.Location = new System.Drawing.Point(119, 93);
            this.radmail.Name = "radmail";
            this.radmail.Size = new System.Drawing.Size(48, 17);
            this.radmail.TabIndex = 309;
            this.radmail.Text = "Male";
            this.radmail.UseVisualStyleBackColor = true;
            // 
            // radfemail
            // 
            this.radfemail.AutoSize = true;
            this.radfemail.Checked = true;
            this.radfemail.Location = new System.Drawing.Point(173, 93);
            this.radfemail.Name = "radfemail";
            this.radfemail.Size = new System.Drawing.Size(59, 17);
            this.radfemail.TabIndex = 310;
            this.radfemail.TabStop = true;
            this.radfemail.Text = "Female";
            this.radfemail.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(257, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 30);
            this.button1.TabIndex = 311;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_newpatient
            // 
            this.panel_newpatient.BackColor = System.Drawing.Color.White;
            this.panel_newpatient.Controls.Add(this.lblmore);
            this.panel_newpatient.Controls.Add(this.label11);
            this.panel_newpatient.Controls.Add(this.label1);
            this.panel_newpatient.Controls.Add(this.txtPatientId);
            this.panel_newpatient.Controls.Add(this.radfemail);
            this.panel_newpatient.Controls.Add(this.radmail);
            this.panel_newpatient.Controls.Add(this.txtmobile);
            this.panel_newpatient.Controls.Add(this.txtpatname);
            this.panel_newpatient.Controls.Add(this.label10);
            this.panel_newpatient.Location = new System.Drawing.Point(2, 3);
            this.panel_newpatient.Name = "panel_newpatient";
            this.panel_newpatient.Size = new System.Drawing.Size(347, 116);
            this.panel_newpatient.TabIndex = 313;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 314;
            this.label1.Text = "Patient Id";
            // 
            // txtPatientId
            // 
            this.txtPatientId.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtPatientId.Location = new System.Drawing.Point(113, 41);
            this.txtPatientId.MaxLength = 30000;
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(207, 22);
            this.txtPatientId.TabIndex = 313;
            // 
            // pnlmore
            // 
            this.pnlmore.BackColor = System.Drawing.Color.White;
            this.pnlmore.Controls.Add(this.grmedical);
            this.pnlmore.Controls.Add(this.label32);
            this.pnlmore.Controls.Add(this.label12);
            this.pnlmore.Controls.Add(this.ddldoctor);
            this.pnlmore.Controls.Add(this.label31);
            this.pnlmore.Controls.Add(this.txtFileNo);
            this.pnlmore.Controls.Add(this.label21);
            this.pnlmore.Controls.Add(this.label20);
            this.pnlmore.Controls.Add(this.label19);
            this.pnlmore.Controls.Add(this.txtCity);
            this.pnlmore.Controls.Add(this.txtLocality);
            this.pnlmore.Controls.Add(this.txtxStreet);
            this.pnlmore.Controls.Add(this.label23);
            this.pnlmore.Controls.Add(this.txtxAge);
            this.pnlmore.Location = new System.Drawing.Point(2, 122);
            this.pnlmore.Name = "pnlmore";
            this.pnlmore.Size = new System.Drawing.Size(347, 422);
            this.pnlmore.TabIndex = 314;
            this.pnlmore.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label23.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label23.Location = new System.Drawing.Point(6, 14);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 17);
            this.label23.TabIndex = 295;
            this.label23.Text = "Age";
            // 
            // txtxAge
            // 
            this.txtxAge.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtxAge.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtxAge.Location = new System.Drawing.Point(113, 14);
            this.txtxAge.Name = "txtxAge";
            this.txtxAge.Size = new System.Drawing.Size(55, 22);
            this.txtxAge.TabIndex = 294;
            this.txtxAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtxAge_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label21.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label21.Location = new System.Drawing.Point(6, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 17);
            this.label21.TabIndex = 301;
            this.label21.Text = "City";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(6, 75);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 17);
            this.label20.TabIndex = 300;
            this.label20.Text = "Locality";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label19.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label19.Location = new System.Drawing.Point(6, 45);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 17);
            this.label19.TabIndex = 299;
            this.label19.Text = "Street Address";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCity.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtCity.Location = new System.Drawing.Point(113, 100);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(207, 22);
            this.txtCity.TabIndex = 298;
            // 
            // txtLocality
            // 
            this.txtLocality.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtLocality.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtLocality.Location = new System.Drawing.Point(113, 71);
            this.txtLocality.Name = "txtLocality";
            this.txtLocality.Size = new System.Drawing.Size(207, 22);
            this.txtLocality.TabIndex = 297;
            // 
            // txtxStreet
            // 
            this.txtxStreet.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtxStreet.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtxStreet.Location = new System.Drawing.Point(113, 43);
            this.txtxStreet.Name = "txtxStreet";
            this.txtxStreet.Size = new System.Drawing.Size(207, 22);
            this.txtxStreet.TabIndex = 296;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label31.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label31.Location = new System.Drawing.Point(6, 133);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(49, 17);
            this.label31.TabIndex = 303;
            this.label31.Text = "File No";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtFileNo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtFileNo.Location = new System.Drawing.Point(113, 129);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(207, 22);
            this.txtFileNo.TabIndex = 302;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label12.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label12.Location = new System.Drawing.Point(6, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 305;
            this.label12.Text = "Doctor Name";
            // 
            // ddldoctor
            // 
            this.ddldoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddldoctor.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ddldoctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.ddldoctor.FormattingEnabled = true;
            this.ddldoctor.Location = new System.Drawing.Point(113, 159);
            this.ddldoctor.Name = "ddldoctor";
            this.ddldoctor.Size = new System.Drawing.Size(207, 21);
            this.ddldoctor.TabIndex = 304;
            // 
            // lblmore
            // 
            this.lblmore.BackColor = System.Drawing.Color.Gainsboro;
            this.lblmore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblmore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmore.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblmore.Location = new System.Drawing.Point(10, 88);
            this.lblmore.Name = "lblmore";
            this.lblmore.Size = new System.Drawing.Size(58, 20);
            this.lblmore.TabIndex = 315;
            this.lblmore.Text = "+ More";
            this.lblmore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblmore.Click += new System.EventHandler(this.lblmore_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkGreen;
            this.label32.Location = new System.Drawing.Point(4, 192);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(118, 21);
            this.label32.TabIndex = 306;
            this.label32.Text = "Medical History";
            // 
            // grmedical
            // 
            this.grmedical.AllowUserToAddRows = false;
            this.grmedical.AllowUserToDeleteRows = false;
            this.grmedical.AllowUserToResizeColumns = false;
            this.grmedical.AllowUserToResizeRows = false;
            this.grmedical.BackgroundColor = System.Drawing.Color.White;
            this.grmedical.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grmedical.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grmedical.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grmedical.ColumnHeadersVisible = false;
            this.grmedical.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.grmedical.GridColor = System.Drawing.Color.White;
            this.grmedical.Location = new System.Drawing.Point(5, 216);
            this.grmedical.Name = "grmedical";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grmedical.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grmedical.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grmedical.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grmedical.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grmedical.Size = new System.Drawing.Size(336, 199);
            this.grmedical.TabIndex = 307;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "name";
            this.Column1.HeaderText = "Medical History";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // consultation_new_patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(349, 168);
            this.Controls.Add(this.pnlmore);
            this.Controls.Add(this.panel_newpatient);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "consultation_new_patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Patient";
            this.Load += new System.EventHandler(this.consultation_new_patient_Load);
            this.panel_newpatient.ResumeLayout(false);
            this.panel_newpatient.PerformLayout();
            this.pnlmore.ResumeLayout(false);
            this.pnlmore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grmedical)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtpatname;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtmobile;
        private System.Windows.Forms.RadioButton radmail;
        private System.Windows.Forms.RadioButton radfemail;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel_newpatient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Panel pnlmore;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtxAge;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtLocality;
        private System.Windows.Forms.TextBox txtxStreet;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox ddldoctor;
        private System.Windows.Forms.Label lblmore;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGridView grmedical;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}