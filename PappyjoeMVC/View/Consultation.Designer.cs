namespace PappyjoeMVC.View
{
    partial class Consultation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Consultation));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lst_procedure = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbPatient = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxReview = new System.Windows.Forms.CheckBox();
            this.cmbdoctor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lnk_view_template = new System.Windows.Forms.LinkLabel();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.txt_procedure = new System.Windows.Forms.TextBox();
            this.dtp_nextreview = new System.Windows.Forms.DateTimePicker();
            this.cmb_prescription_temp = new System.Windows.Forms.ComboBox();
            this.txt_instruction = new System.Windows.Forms.TextBox();
            this.txt_remarks = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Pt_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lst_procedure);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lbPatient);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.checkBoxReview);
            this.panel2.Controls.Add(this.cmbdoctor);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lnk_view_template);
            this.panel2.Controls.Add(this.txtPatientID);
            this.panel2.Controls.Add(this.txt_cost);
            this.panel2.Controls.Add(this.txt_procedure);
            this.panel2.Controls.Add(this.dtp_nextreview);
            this.panel2.Controls.Add(this.cmb_prescription_temp);
            this.panel2.Controls.Add(this.txt_instruction);
            this.panel2.Controls.Add(this.txt_remarks);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_Pt_search);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(5, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 257);
            this.panel2.TabIndex = 3;
            // 
            // lst_procedure
            // 
            this.lst_procedure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_procedure.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lst_procedure.FormattingEnabled = true;
            this.lst_procedure.Location = new System.Drawing.Point(84, 179);
            this.lst_procedure.Name = "lst_procedure";
            this.lst_procedure.Size = new System.Drawing.Size(229, 69);
            this.lst_procedure.TabIndex = 311;
            this.lst_procedure.Visible = false;
            this.lst_procedure.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lst_procedure_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(11, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 17);
            this.label12.TabIndex = 408;
            this.label12.Text = "Procedure Details";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(338, 134);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 17);
            this.label11.TabIndex = 407;
            this.label11.Text = "Prescription Details";
            // 
            // lbPatient
            // 
            this.lbPatient.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPatient.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbPatient.FormattingEnabled = true;
            this.lbPatient.Location = new System.Drawing.Point(99, 44);
            this.lbPatient.Name = "lbPatient";
            this.lbPatient.Size = new System.Drawing.Size(287, 82);
            this.lbPatient.TabIndex = 309;
            this.lbPatient.Visible = false;
            this.lbPatient.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbPatient_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 406;
            this.label3.Text = "Patient Id";
            // 
            // checkBoxReview
            // 
            this.checkBoxReview.AutoSize = true;
            this.checkBoxReview.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxReview.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBoxReview.Location = new System.Drawing.Point(339, 231);
            this.checkBoxReview.Name = "checkBoxReview";
            this.checkBoxReview.Size = new System.Drawing.Size(117, 19);
            this.checkBoxReview.TabIndex = 405;
            this.checkBoxReview.Text = "Next Review Date";
            this.checkBoxReview.UseVisualStyleBackColor = true;
            // 
            // cmbdoctor
            // 
            this.cmbdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbdoctor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbdoctor.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdoctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cmbdoctor.FormattingEnabled = true;
            this.cmbdoctor.Location = new System.Drawing.Point(489, 18);
            this.cmbdoctor.Name = "cmbdoctor";
            this.cmbdoctor.Size = new System.Drawing.Size(266, 21);
            this.cmbdoctor.TabIndex = 314;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label10.Location = new System.Drawing.Point(45, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 313;
            this.label10.Text = "Cost";
            // 
            // lnk_view_template
            // 
            this.lnk_view_template.AutoSize = true;
            this.lnk_view_template.Location = new System.Drawing.Point(704, 158);
            this.lnk_view_template.Name = "lnk_view_template";
            this.lnk_view_template.Size = new System.Drawing.Size(77, 13);
            this.lnk_view_template.TabIndex = 312;
            this.lnk_view_template.TabStop = true;
            this.lnk_view_template.Text = "View Template";
            this.lnk_view_template.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_view_template_LinkClicked);
            // 
            // txtPatientID
            // 
            this.txtPatientID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPatientID.Enabled = false;
            this.txtPatientID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientID.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtPatientID.Location = new System.Drawing.Point(99, 45);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(287, 22);
            this.txtPatientID.TabIndex = 310;
            // 
            // txt_cost
            // 
            this.txt_cost.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cost.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_cost.Location = new System.Drawing.Point(84, 178);
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.Size = new System.Drawing.Size(56, 22);
            this.txt_cost.TabIndex = 308;
            // 
            // txt_procedure
            // 
            this.txt_procedure.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_procedure.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_procedure.Location = new System.Drawing.Point(85, 155);
            this.txt_procedure.Name = "txt_procedure";
            this.txt_procedure.Size = new System.Drawing.Size(228, 22);
            this.txt_procedure.TabIndex = 307;
            this.txt_procedure.Text = "Search by Procedure Name";
            this.txt_procedure.Click += new System.EventHandler(this.txt_procedure_Click);
            this.txt_procedure.TextChanged += new System.EventHandler(this.txt_procedure_TextChanged);
            // 
            // dtp_nextreview
            // 
            this.dtp_nextreview.Location = new System.Drawing.Point(473, 232);
            this.dtp_nextreview.Name = "dtp_nextreview";
            this.dtp_nextreview.Size = new System.Drawing.Size(228, 20);
            this.dtp_nextreview.TabIndex = 306;
            // 
            // cmb_prescription_temp
            // 
            this.cmb_prescription_temp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_prescription_temp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmb_prescription_temp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_prescription_temp.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.cmb_prescription_temp.FormattingEnabled = true;
            this.cmb_prescription_temp.Location = new System.Drawing.Point(473, 152);
            this.cmb_prescription_temp.Name = "cmb_prescription_temp";
            this.cmb_prescription_temp.Size = new System.Drawing.Size(228, 21);
            this.cmb_prescription_temp.TabIndex = 303;
            // 
            // txt_instruction
            // 
            this.txt_instruction.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_instruction.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_instruction.Location = new System.Drawing.Point(84, 206);
            this.txt_instruction.Multiline = true;
            this.txt_instruction.Name = "txt_instruction";
            this.txt_instruction.Size = new System.Drawing.Size(228, 41);
            this.txt_instruction.TabIndex = 302;
            // 
            // txt_remarks
            // 
            this.txt_remarks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_remarks.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_remarks.Location = new System.Drawing.Point(473, 183);
            this.txt_remarks.Multiline = true;
            this.txt_remarks.Name = "txt_remarks";
            this.txt_remarks.Size = new System.Drawing.Size(228, 46);
            this.txt_remarks.TabIndex = 301;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label9.Location = new System.Drawing.Point(11, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 297;
            this.label9.Text = "Instruction";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(339, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 17);
            this.label7.TabIndex = 296;
            this.label7.Text = "Remarks";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(417, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 295;
            this.label6.Text = "Doctor ";
            this.label6.MouseHover += new System.EventHandler(this.label6_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(339, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 293;
            this.label4.Text = "Prescription Template";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(11, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 291;
            this.label2.Text = "Procedure";
            // 
            // txt_Pt_search
            // 
            this.txt_Pt_search.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pt_search.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txt_Pt_search.Location = new System.Drawing.Point(99, 17);
            this.txt_Pt_search.Name = "txt_Pt_search";
            this.txt_Pt_search.Size = new System.Drawing.Size(288, 22);
            this.txt_Pt_search.TabIndex = 290;
            this.txt_Pt_search.Text = "Search by Patient  and  Name";
            this.txt_Pt_search.Click += new System.EventHandler(this.txt_Pt_search_Click);
            this.txt_Pt_search.TextChanged += new System.EventHandler(this.txt_Pt_search_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 288;
            this.label1.Text = "Patient Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 44);
            this.panel1.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Location = new System.Drawing.Point(11, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 21);
            this.label8.TabIndex = 293;
            this.label8.Text = "Consultation";
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(681, 10);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(92, 30);
            this.btnsave.TabIndex = 276;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(575, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 294;
            this.label5.Text = "+ New Patient";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            this.label5.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            this.label5.MouseHover += new System.EventHandler(this.label5_MouseHover);
            // 
            // Consultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 323);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Consultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultation";
            this.Load += new System.EventHandler(this.Consultation_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lst_procedure;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lbPatient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxReview;
        private System.Windows.Forms.ComboBox cmbdoctor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel lnk_view_template;
        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.TextBox txt_procedure;
        private System.Windows.Forms.DateTimePicker dtp_nextreview;
        private System.Windows.Forms.ComboBox cmb_prescription_temp;
        private System.Windows.Forms.TextBox txt_instruction;
        private System.Windows.Forms.TextBox txt_remarks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Pt_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label5;
    }
}