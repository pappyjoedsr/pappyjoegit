namespace PappyjoeMVC.View
{
    partial class Patients_First_Appointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patients_First_Appointment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.Lab_Doctorname = new System.Windows.Forms.Label();
            this.cmbDoctor = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_empty = new System.Windows.Forms.Label();
            this.Grvpatientfirstappoint = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerfirstappoint1 = new System.Windows.Forms.DateTimePicker();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerfirstappoint2 = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvpatientfirstappoint)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnprint);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Location = new System.Drawing.Point(3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 72);
            this.panel2.TabIndex = 220;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(20, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(355, 40);
            this.label6.TabIndex = 218;
            this.label6.Text = "Patients First Appointment";
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExport.Location = new System.Drawing.Point(1009, 35);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(108, 30);
            this.btnExport.TabIndex = 216;
            this.btnExport.Text = "EXPORT TO EXCEL";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(1119, 35);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 30);
            this.btnprint.TabIndex = 3;
            this.btnprint.Text = "PRINT";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Tomato;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClose.Location = new System.Drawing.Point(1205, 35);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(85, 30);
            this.buttonClose.TabIndex = 215;
            this.buttonClose.Text = "CLOSE";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Lab_Doctorname
            // 
            this.Lab_Doctorname.AutoSize = true;
            this.Lab_Doctorname.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctorname.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctorname.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctorname.Location = new System.Drawing.Point(617, 24);
            this.Lab_Doctorname.Name = "Lab_Doctorname";
            this.Lab_Doctorname.Size = new System.Drawing.Size(74, 13);
            this.Lab_Doctorname.TabIndex = 218;
            this.Lab_Doctorname.Text = "Doctor Name";
            // 
            // cmbDoctor
            // 
            this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cmbDoctor.FormattingEnabled = true;
            this.cmbDoctor.Location = new System.Drawing.Point(697, 20);
            this.cmbDoctor.Name = "cmbDoctor";
            this.cmbDoctor.Size = new System.Drawing.Size(164, 21);
            this.cmbDoctor.TabIndex = 217;
            this.cmbDoctor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbDoctor_KeyPress);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label_empty);
            this.panel3.Controls.Add(this.Grvpatientfirstappoint);
            this.panel3.Location = new System.Drawing.Point(1, 133);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1298, 613);
            this.panel3.TabIndex = 221;
            // 
            // label_empty
            // 
            this.label_empty.AutoSize = true;
            this.label_empty.BackColor = System.Drawing.Color.Wheat;
            this.label_empty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_empty.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_empty.Location = new System.Drawing.Point(273, 204);
            this.label_empty.Name = "label_empty";
            this.label_empty.Size = new System.Drawing.Size(506, 25);
            this.label_empty.TabIndex = 97;
            this.label_empty.Text = "No Records Found. Please change the Date and try again !..";
            this.label_empty.VisibleChanged += new System.EventHandler(this.label_empty_VisibleChanged);
            // 
            // Grvpatientfirstappoint
            // 
            this.Grvpatientfirstappoint.AllowUserToAddRows = false;
            this.Grvpatientfirstappoint.AllowUserToDeleteRows = false;
            this.Grvpatientfirstappoint.AllowUserToResizeColumns = false;
            this.Grvpatientfirstappoint.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Grvpatientfirstappoint.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Grvpatientfirstappoint.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grvpatientfirstappoint.BackgroundColor = System.Drawing.Color.White;
            this.Grvpatientfirstappoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grvpatientfirstappoint.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.Grvpatientfirstappoint.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvpatientfirstappoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grvpatientfirstappoint.Location = new System.Drawing.Point(3, 3);
            this.Grvpatientfirstappoint.Name = "Grvpatientfirstappoint";
            this.Grvpatientfirstappoint.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Grvpatientfirstappoint.RowHeadersVisible = false;
            this.Grvpatientfirstappoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grvpatientfirstappoint.Size = new System.Drawing.Size(1292, 561);
            this.Grvpatientfirstappoint.TabIndex = 0;
            this.Grvpatientfirstappoint.DataSourceChanged += new System.EventHandler(this.Grvpatientfirstappoint_DataSourceChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.Lab_Doctorname);
            this.panel1.Controls.Add(this.cmbDoctor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dateTimePickerfirstappoint1);
            this.panel1.Controls.Add(this.btnsearch);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dateTimePickerfirstappoint2);
            this.panel1.Location = new System.Drawing.Point(3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1296, 59);
            this.panel1.TabIndex = 219;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(10, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(1006, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(883, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "TOTAL PATIENTS :";
            // 
            // dateTimePickerfirstappoint1
            // 
            this.dateTimePickerfirstappoint1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerfirstappoint1.Location = new System.Drawing.Point(55, 19);
            this.dateTimePickerfirstappoint1.Name = "dateTimePickerfirstappoint1";
            this.dateTimePickerfirstappoint1.Size = new System.Drawing.Size(207, 22);
            this.dateTimePickerfirstappoint1.TabIndex = 4;
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.LimeGreen;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(531, 19);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 110;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gainsboro;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(281, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // dateTimePickerfirstappoint2
            // 
            this.dateTimePickerfirstappoint2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerfirstappoint2.Location = new System.Drawing.Point(314, 19);
            this.dateTimePickerfirstappoint2.Name = "dateTimePickerfirstappoint2";
            this.dateTimePickerfirstappoint2.Size = new System.Drawing.Size(205, 22);
            this.dateTimePickerfirstappoint2.TabIndex = 6;
            // 
            // Patients_First_Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Patients_First_Appointment";
            this.Text = "Patients First Appointment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Patients_first_appointment_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grvpatientfirstappoint)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label Lab_Doctorname;
        private System.Windows.Forms.ComboBox cmbDoctor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_empty;
        private System.Windows.Forms.DataGridView Grvpatientfirstappoint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerfirstappoint1;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerfirstappoint2;
    }
}