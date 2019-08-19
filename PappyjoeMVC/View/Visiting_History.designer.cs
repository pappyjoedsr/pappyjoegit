namespace PappyjoeMVC.View
{
    partial class Visiting_History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visiting_History));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvVisitingHistory = new System.Windows.Forms.DataGridView();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pt_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.book_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booked_by = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lab_Msg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.schedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waiting = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePickerdailyappointcount2 = new System.Windows.Forms.DateTimePicker();
            this.btnselect = new System.Windows.Forms.Button();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerdailyappointcount1 = new System.Windows.Forms.DateTimePicker();
            this.Lab_Doctor = new System.Windows.Forms.Label();
            this.comboBoxdoctor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btnExporttoExcel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitingHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVisitingHistory
            // 
            this.dgvVisitingHistory.AllowUserToAddRows = false;
            this.dgvVisitingHistory.AllowUserToDeleteRows = false;
            this.dgvVisitingHistory.AllowUserToResizeColumns = false;
            this.dgvVisitingHistory.AllowUserToResizeRows = false;
            this.dgvVisitingHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVisitingHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisitingHistory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVisitingHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVisitingHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvVisitingHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVisitingHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvVisitingHistory.ColumnHeadersHeight = 30;
            this.dgvVisitingHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvVisitingHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patient_id,
            this.pt_name,
            this.book_datetime,
            this.start_datetime,
            this.booked_by,
            this.status,
            this.duration});
            this.dgvVisitingHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVisitingHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvVisitingHistory.Location = new System.Drawing.Point(0, 0);
            this.dgvVisitingHistory.MultiSelect = false;
            this.dgvVisitingHistory.Name = "dgvVisitingHistory";
            this.dgvVisitingHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVisitingHistory.RowHeadersVisible = false;
            this.dgvVisitingHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvVisitingHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisitingHistory.Size = new System.Drawing.Size(1112, 390);
            this.dgvVisitingHistory.TabIndex = 118;
            // 
            // patient_id
            // 
            this.patient_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.patient_id.DataPropertyName = "patient_id";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patient_id.DefaultCellStyle = dataGridViewCellStyle9;
            this.patient_id.FillWeight = 81.88065F;
            this.patient_id.HeaderText = "ID";
            this.patient_id.Name = "patient_id";
            // 
            // pt_name
            // 
            this.pt_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pt_name.DataPropertyName = "pt_name";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.pt_name.DefaultCellStyle = dataGridViewCellStyle10;
            this.pt_name.FillWeight = 166.1734F;
            this.pt_name.HeaderText = "PATIENT NAME";
            this.pt_name.Name = "pt_name";
            // 
            // book_datetime
            // 
            this.book_datetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.book_datetime.DataPropertyName = "book_datetime";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.book_datetime.DefaultCellStyle = dataGridViewCellStyle11;
            this.book_datetime.FillWeight = 111.6751F;
            this.book_datetime.HeaderText = "BOOKED ON";
            this.book_datetime.Name = "book_datetime";
            // 
            // start_datetime
            // 
            this.start_datetime.DataPropertyName = "start_datetime";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.start_datetime.DefaultCellStyle = dataGridViewCellStyle12;
            this.start_datetime.FillWeight = 89.46581F;
            this.start_datetime.HeaderText = "APPOINTMENT DATE";
            this.start_datetime.Name = "start_datetime";
            // 
            // booked_by
            // 
            this.booked_by.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.booked_by.DataPropertyName = "booked_by";
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.booked_by.DefaultCellStyle = dataGridViewCellStyle13;
            this.booked_by.FillWeight = 159.3434F;
            this.booked_by.HeaderText = "BOOKED BY";
            this.booked_by.Name = "booked_by";
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.DataPropertyName = "status";
            this.status.FillWeight = 138.7734F;
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            // 
            // duration
            // 
            this.duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.duration.DataPropertyName = "duration";
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.duration.DefaultCellStyle = dataGridViewCellStyle14;
            this.duration.FillWeight = 95.35242F;
            this.duration.HeaderText = "DURATION (MINS)";
            this.duration.Name = "duration";
            // 
            // Lab_Msg
            // 
            this.Lab_Msg.AutoSize = true;
            this.Lab_Msg.BackColor = System.Drawing.Color.Wheat;
            this.Lab_Msg.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Msg.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Msg.Location = new System.Drawing.Point(285, 183);
            this.Lab_Msg.Name = "Lab_Msg";
            this.Lab_Msg.Size = new System.Drawing.Size(542, 25);
            this.Lab_Msg.TabIndex = 277;
            this.Lab_Msg.Text = "No Records Found. Please change the date and then try again!..";
            this.Lab_Msg.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.Lab_Msg);
            this.panel1.Controls.Add(this.dgvVisitingHistory);
            this.panel1.Location = new System.Drawing.Point(2, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 390);
            this.panel1.TabIndex = 128;
            // 
            // schedule
            // 
            this.schedule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.schedule.DataPropertyName = "schedule";
            this.schedule.FillWeight = 69.97183F;
            this.schedule.HeaderText = "SCHEDULE";
            this.schedule.Name = "schedule";
            // 
            // waiting
            // 
            this.waiting.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.waiting.DataPropertyName = "waiting";
            this.waiting.FillWeight = 68.66963F;
            this.waiting.HeaderText = "WAITING";
            this.waiting.Name = "waiting";
            // 
            // checkout
            // 
            this.checkout.DataPropertyName = "checkout";
            this.checkout.HeaderText = "CHECKED OUT";
            this.checkout.Name = "checkout";
            // 
            // dateTimePickerdailyappointcount2
            // 
            this.dateTimePickerdailyappointcount2.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount2.Location = new System.Drawing.Point(295, 23);
            this.dateTimePickerdailyappointcount2.Name = "dateTimePickerdailyappointcount2";
            this.dateTimePickerdailyappointcount2.Size = new System.Drawing.Size(197, 22);
            this.dateTimePickerdailyappointcount2.TabIndex = 121;
            // 
            // btnselect
            // 
            this.btnselect.BackColor = System.Drawing.Color.LimeGreen;
            this.btnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnselect.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.ForeColor = System.Drawing.Color.White;
            this.btnselect.Location = new System.Drawing.Point(514, 23);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(75, 23);
            this.btnselect.TabIndex = 124;
            this.btnselect.Text = "Show";
            this.btnselect.UseVisualStyleBackColor = false;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbltotal.Location = new System.Drawing.Point(613, 25);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(133, 17);
            this.lbltotal.TabIndex = 118;
            this.lbltotal.Text = "Total Appointment : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(743, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 119;
            this.label2.Text = "label2";
            // 
            // dateTimePickerdailyappointcount1
            // 
            this.dateTimePickerdailyappointcount1.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerdailyappointcount1.Location = new System.Drawing.Point(53, 23);
            this.dateTimePickerdailyappointcount1.Name = "dateTimePickerdailyappointcount1";
            this.dateTimePickerdailyappointcount1.Size = new System.Drawing.Size(201, 22);
            this.dateTimePickerdailyappointcount1.TabIndex = 120;
            // 
            // Lab_Doctor
            // 
            this.Lab_Doctor.AutoSize = true;
            this.Lab_Doctor.BackColor = System.Drawing.Color.Transparent;
            this.Lab_Doctor.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Doctor.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Lab_Doctor.Location = new System.Drawing.Point(827, 26);
            this.Lab_Doctor.Name = "Lab_Doctor";
            this.Lab_Doctor.Size = new System.Drawing.Size(89, 17);
            this.Lab_Doctor.TabIndex = 125;
            this.Lab_Doctor.Text = "Doctor Name";
            // 
            // comboBoxdoctor
            // 
            this.comboBoxdoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxdoctor.FormattingEnabled = true;
            this.comboBoxdoctor.Location = new System.Drawing.Point(933, 24);
            this.comboBoxdoctor.Name = "comboBoxdoctor";
            this.comboBoxdoctor.Size = new System.Drawing.Size(149, 21);
            this.comboBoxdoctor.TabIndex = 126;
            this.comboBoxdoctor.SelectedIndexChanged += new System.EventHandler(this.comboBoxdoctor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 127;
            this.label1.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(266, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 128;
            this.label3.Text = "To";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.comboBoxdoctor);
            this.panel3.Controls.Add(this.Lab_Doctor);
            this.panel3.Controls.Add(this.dateTimePickerdailyappointcount1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.lbltotal);
            this.panel3.Controls.Add(this.btnselect);
            this.panel3.Controls.Add(this.dateTimePickerdailyappointcount2);
            this.panel3.Location = new System.Drawing.Point(2, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1112, 57);
            this.panel3.TabIndex = 130;
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.LimeGreen;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnprint.ForeColor = System.Drawing.Color.White;
            this.btnprint.Image = ((System.Drawing.Image)(resources.GetObject("btnprint.Image")));
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(1267, 13);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 37);
            this.btnprint.TabIndex = 125;
            this.btnprint.Text = "Print";
            this.btnprint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.btn_Print);
            this.panel2.Controls.Add(this.btnExporttoExcel);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnprint);
            this.panel2.Location = new System.Drawing.Point(1, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1112, 74);
            this.panel2.TabIndex = 129;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Tomato;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Close.Location = new System.Drawing.Point(1022, 40);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(85, 30);
            this.btn_Close.TabIndex = 129;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ForeColor = System.Drawing.Color.White;
            this.btn_Print.Image = global::PappyjoeMVC.Properties.Resources.Print_icon__1_;
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.Location = new System.Drawing.Point(935, 40);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(85, 30);
            this.btn_Print.TabIndex = 128;
            this.btn_Print.Text = "PRINT";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btnExporttoExcel
            // 
            this.btnExporttoExcel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExporttoExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporttoExcel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExporttoExcel.ForeColor = System.Drawing.Color.White;
            this.btnExporttoExcel.Location = new System.Drawing.Point(827, 40);
            this.btnExporttoExcel.Name = "btnExporttoExcel";
            this.btnExporttoExcel.Size = new System.Drawing.Size(106, 30);
            this.btnExporttoExcel.TabIndex = 127;
            this.btnExporttoExcel.Text = "EXPORT TO EXCEL";
            this.btnExporttoExcel.UseVisualStyleBackColor = false;
            this.btnExporttoExcel.Click += new System.EventHandler(this.btnExporttoExcel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(6, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 40);
            this.label4.TabIndex = 120;
            this.label4.Text = "Visiting History";
            // 
            // Visiting_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 530);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Visiting_History";
            this.Text = "Visiting History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Visiting_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitingHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dgvVisitingHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn pt_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn booked_by;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.Label Lab_Msg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn schedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn waiting;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkout;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailyappointcount2;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerdailyappointcount1;
        private System.Windows.Forms.Label Lab_Doctor;
        private System.Windows.Forms.ComboBox comboBoxdoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btnExporttoExcel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}